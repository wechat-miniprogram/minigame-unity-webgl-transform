#if ENABLE_LUA_INJECTION
using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Linq;
using UnityEngine;
using UnityEditor;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Unity.CecilTools;
using Unity.CecilTools.Extensions;
using CustomCecilRocks; 
using System.Reflection;
using LuaInterface;
using UnityEditor.Callbacks;
using System.Collections.Generic;
using MethodBody = Mono.Cecil.Cil.MethodBody;

class InjectedMethodInfo
{
    public string methodFullSignature;
    public string methodOverloadSignature;
    public string methodPublishedName;
    public string methodName;
    public int methodIndex;
}

[InitializeOnLoad]
public static class ToLuaInjection
{
    static int offset = 0;
    static int methodCounter = 0;
    static bool EnableSymbols = true;
    static Instruction cursor;
    static VariableDefinition flagDef;
    static VariableDefinition funcDef;
    static TypeReference intTypeRef;
    static TypeReference injectFlagTypeRef;
    static TypeReference noToLuaAttrTypeRef;
    static TypeDefinition injectStationTypeDef;
    static TypeDefinition luaFunctionTypeDef;
    static TypeDefinition luaTableTypeDef;
    static MethodReference injectFlagGetter;
    static MethodReference injectedFuncGetter;
    static HashSet<string> dropTypeGroup = new HashSet<string>();
    static HashSet<string> injectableTypeGroup = new HashSet<string>();
    static Dictionary<MethodDefinition, VariableDefinition> resultTableGroup = new Dictionary<MethodDefinition, VariableDefinition>();
    static SortedDictionary<string, List<InjectedMethodInfo>> bridgeInfo = new SortedDictionary<string, List<InjectedMethodInfo>>();
    static OpCode[] ldargs = new OpCode[] { OpCodes.Ldarg_0, OpCodes.Ldarg_1, OpCodes.Ldarg_2, OpCodes.Ldarg_3 };
    static OpCode[] ldcI4s = new OpCode[] { OpCodes.Ldc_I4_1, OpCodes.Ldc_I4_2, OpCodes.Ldc_I4_4, OpCodes.Ldc_I4_8 };
    const string assemblyPath = "./Library/ScriptAssemblies/Assembly-CSharp.dll";
    const InjectType injectType = InjectType.After | InjectType.Before | InjectType.Replace | InjectType.ReplaceWithPreInvokeBase | InjectType.ReplaceWithPostInvokeBase;
    const InjectFilter injectIgnoring = InjectFilter.IgnoreGeneric | InjectFilter.IgnoreConstructor;// | InjectFilter.IgnoreNoToLuaAttr | InjectFilter.IgnoreProperty;
    static HashSet<string> dropGenericNameGroup = new HashSet<string>
    {
    };
    static HashSet<string> dropNamespaceGroup = new HashSet<string>
    {
        "LuaInterface",
    };
    static HashSet<string> forceInjectTypeGroup = new HashSet<string>
    {
    };

    static ToLuaInjection()
    {
        LoadAndCheckAssembly(true);
        InjectAll();
    }

    static void InjectAll()
    {
        var injectionStatus = EditorPrefs.GetInt(Application.dataPath + "WaitForInjection", 0);
        if (Application.isPlaying || EditorApplication.isCompiling || injectionStatus == 0)
        {
            return;
        }

        bool bInjectInterupted = !LoadBlackList() || ToLuaMenu.UpdateMonoCecil(ref EnableSymbols) != 0 || !LoadBridgeEditorInfo();
        if (!bInjectInterupted)
        {
            CacheInjectableTypeGroup();
            Inject();

            AssetDatabase.Refresh();
        }
    }

    [PostProcessBuildAttribute()]
    static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
    {
        var injectionStatus = EditorPrefs.GetInt(Application.dataPath + "WaitForInjection", 0);
        if (injectionStatus == 0)
        {
            Debug.LogError("Inject Failed!!!");
        }
        EditorPrefs.SetInt(Application.dataPath + "WaitForInjection", 0);
    }

    [PostProcessScene]
    static void OnPostProcessScene()
    {
        if (BuildPipeline.isBuildingPlayer)
        {
            EditorPrefs.SetInt(Application.dataPath + "WaitForInjection", 1);
        }

        InjectAll();
    }

    [DidReloadScripts]
    static void OnDidReloadScripts()
    {
        if (!BuildPipeline.isBuildingPlayer)
        {
            EditorPrefs.SetInt(Application.dataPath + "WaitForInjection", 0);
        }
    }
	
    [MenuItem("Lua/Inject All &i", false, 5)]
    static void InjectByMenu()
    {
        if (Application.isPlaying)
        {
            EditorUtility.DisplayDialog("警告", "游戏运行过程中无法操作", "确定");
            return;
        }

        EditorPrefs.SetInt(Application.dataPath + "WaitForInjection", 1);
        if (EditorApplication.isCompiling)
        {
            EditorUtility.DisplayDialog("警告", "请等待编辑器编译完成", "确定");
            return;
        }

        InjectAll();
    }

    static AssemblyDefinition LoadAndCheckAssembly(bool bPulse)
    {
        var assemblyReader = new ReaderParameters
        {
            ReadSymbols = EnableSymbols,
            AssemblyResolver = GetAssemblyResolver()
        };
        AssemblyDefinition assembly = AssemblyDefinition.ReadAssembly(assemblyPath, assemblyReader);

        var alreadyInjected = assembly.CustomAttributes.Any((attr) =>
        {
            return attr.AttributeType.FullName == "LuaInterface.UseDefinedAttribute";
        });
        EditorPrefs.SetInt(Application.dataPath + "InjectStatus", alreadyInjected ? 1 : 0);

        if (bPulse)
        {
            Clean(assembly);
        }

        return assembly;
    }

    static void Inject()
    {
        AssemblyDefinition assembly = null;
        try
        {
            assembly = LoadAndCheckAssembly(false);
            if (InjectPrepare(assembly))
            {
                foreach (var module in assembly.Modules)
                {
                    int cursor = 0;
                    int typesCount = module.Types.Count;
                    foreach (var type in module.Types)
                    {
                        ++cursor;
                        EditorUtility.DisplayProgressBar("Injecting:" + module.FullyQualifiedName, type.FullName, (float)cursor / typesCount);
                        if (!InjectProcess(assembly, type))
                        {
                            EditorUtility.ClearProgressBar();
                            return;
                        }
                    }
                }
                EditorUtility.ClearProgressBar();

                UpdateInjectionCacheSize();
                ExportInjectionBridgeInfo();
                WriteInjectedAssembly(assembly, assemblyPath);
                resultTableGroup.Clear();
                EditorApplication.Beep();
                Debug.Log("Lua Injection Finished!");
                EditorPrefs.SetInt(Application.dataPath + "InjectStatus", 1);
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e.ToString());
        }
        finally
        {
            if (assembly != null)
            {
                Clean(assembly);
            }
        }
    }

    static bool InjectPrepare(AssemblyDefinition assembly)
    {
        bool alreadyInjected = EditorPrefs.GetInt(Application.dataPath + "InjectStatus") == 1;
        if (alreadyInjected)
        {
            Debug.Log("Already Injected!");
            return false;
        }
        resultTableGroup.Clear();
        var injectAttrType = assembly.MainModule.Types.Single(type => type.FullName == "LuaInterface.UseDefinedAttribute");
        var attrCtorInfo = injectAttrType.Methods.Single(method => method.IsConstructor);
        assembly.CustomAttributes.Add(new CustomAttribute(attrCtorInfo));

        intTypeRef = assembly.MainModule.TypeSystem.Int32;
        injectFlagTypeRef = assembly.MainModule.TypeSystem.Byte;
        noToLuaAttrTypeRef = assembly.MainModule.Types.Single(type => type.FullName == "LuaInterface.NoToLuaAttribute");
        injectStationTypeDef = assembly.MainModule.Types.Single(type => type.FullName == "LuaInterface.LuaInjectionStation");
        luaFunctionTypeDef = assembly.MainModule.Types.Single(method => method.FullName == "LuaInterface.LuaFunction");
        luaTableTypeDef = assembly.MainModule.Types.Single(method => method.FullName == "LuaInterface.LuaTable");
        injectFlagGetter = injectStationTypeDef.Methods.Single(method => method.Name == "GetInjectFlag");
        injectedFuncGetter = injectStationTypeDef.Methods.Single(method => method.Name == "GetInjectionFunction");

        return true;
    }

    static BaseAssemblyResolver GetAssemblyResolver()
    {
        DefaultAssemblyResolver resolver = new DefaultAssemblyResolver();

        AppDomain.CurrentDomain
                .GetAssemblies()
                .Select(assem => Path.GetDirectoryName(assem.ManifestModule.FullyQualifiedName))
                .Distinct()
                .Foreach(dir => resolver.AddSearchDirectory(dir));

        return resolver;
    }

    static bool InjectProcess(AssemblyDefinition assembly, TypeDefinition type)
    {
        if (!DoesTypeInjectable(type))
        {
            return true;
        }

        foreach (var nestedType in type.NestedTypes)
        {
            if (!InjectProcess(assembly, nestedType))
            {
                return false;
            }
        }

        foreach (var target in type.Methods)
        {
            if (target.IsGenericMethodDefinition())
            {
                continue;
            }
            if (!DoesMethodInjectable(target))
            {
                continue;
            }
            int methodIndex = AppendMethod(target);
            if (methodIndex == -1)
            {
                return false;
            }

            if (target.IsEnumerator())
            {
                InjectCoroutine(assembly, target, methodIndex);
            }
            else
            {
                InjectMethod(assembly, target, methodIndex);
            }
        }

        return true;
    }

    static void FillBegin(MethodDefinition target, int methodIndex)
    {
        MethodBody targetBody = target.Body;
        ILProcessor il = targetBody.GetILProcessor();
        targetBody.InitLocals = true;
        flagDef = new VariableDefinition(injectFlagTypeRef);
        funcDef = new VariableDefinition(luaFunctionTypeDef);
        targetBody.Variables.Add(flagDef);
        targetBody.Variables.Add(funcDef);

        Instruction startInsertPos = targetBody.Instructions[0];
        il.InsertBefore(startInsertPos, il.Create(OpCodes.Ldc_I4, methodIndex));
        il.InsertBefore(startInsertPos, il.Create(OpCodes.Call, injectFlagGetter));
        il.InsertBefore(startInsertPos, il.Create(OpCodes.Stloc, flagDef));
        il.InsertBefore(startInsertPos, il.Create(OpCodes.Ldloc, flagDef));
        il.InsertBefore(startInsertPos, il.Create(OpCodes.Brfalse, startInsertPos));
        il.InsertBefore(startInsertPos, il.Create(OpCodes.Ldc_I4, methodIndex));
        il.InsertBefore(startInsertPos, il.Create(OpCodes.Call, injectedFuncGetter));
        il.InsertBefore(startInsertPos, il.Create(OpCodes.Stloc, funcDef));
        offset = targetBody.Instructions.IndexOf(startInsertPos);
    }

#region GenericMethod
    static void InjectGenericMethod(AssemblyDefinition assembly, MethodDefinition target, int methodIndex)
    {
    }
#endregion GenericMethod

#region Coroutine
    static void InjectCoroutine(AssemblyDefinition assembly, MethodDefinition target, int methodIndex)
    {
        InjectType runtimeInjectType = GetMethodRuntimeInjectType(target);
        if (runtimeInjectType == InjectType.None)
        {
            return;
        }

        target.Body.SimplifyMacros();
        FillBegin(target, methodIndex);
        FillReplaceCoroutine(target, runtimeInjectType & InjectType.Replace);
        FillCoroutineMonitor(target, runtimeInjectType & (~InjectType.Replace), methodIndex);
        target.Body.OptimizeMacros();
    }

    static void FillReplaceCoroutine(MethodDefinition target, InjectType runtimeInjectType)
    {
        if (runtimeInjectType == InjectType.None)
        {
            return;
        }

        MethodBody targetBody = target.Body;
        ILProcessor il = targetBody.GetILProcessor();
        cursor = GetMethodNextInsertPosition(target, null, false);

        if (cursor != null)
        {
            il.InsertBefore(cursor, il.Create(OpCodes.Ldloc, flagDef));
            il.InsertBefore(cursor, il.Create(ldcI4s[(int)InjectType.Replace / 2]));
            il.InsertBefore(cursor, il.Create(OpCodes.Bne_Un, cursor));

            il.InsertBefore(cursor, il.Create(OpCodes.Ldloc, funcDef));
            FillArgs(target, cursor, null);
            il.InsertBefore(cursor, il.Create(OpCodes.Call, GetLuaMethodInvoker(target, false, false)));
            il.InsertBefore(cursor, il.Create(OpCodes.Ret));
        }
    }

    static void FillCoroutineMonitor(MethodDefinition target, InjectType runtimeInjectType, int methodIndex)
    {
        if (runtimeInjectType == InjectType.None)
        {
            return;
        }

        MethodBody targetBody = target.Body;
        FieldDefinition hostField = null;
        var coroutineEntity = targetBody.Variables[0].VariableType.Resolve();
        if (!target.DeclaringType.NestedTypes.Any(type => coroutineEntity == type))
        {
            return;
        }

        cursor = GetMethodNextInsertPosition(target, cursor, true);
        CopyCoroutineCreatorReference(target, coroutineEntity, ref hostField);
        var coroutineCarrier = coroutineEntity.Methods.Single(method => method.Name == "MoveNext");
        CopyCreatorArgsToCarrier(target, coroutineCarrier);
        FillBegin(coroutineCarrier, methodIndex);
        var fillInjectInfoFunc = GetCoroutineInjectInfoFiller(target, hostField);
        FillInjectMethod(coroutineCarrier, fillInjectInfoFunc, runtimeInjectType & InjectType.After);
        FillInjectMethod(coroutineCarrier, fillInjectInfoFunc, runtimeInjectType & InjectType.Before);
    }

    static Action<MethodDefinition, InjectType> GetCoroutineInjectInfoFiller(MethodDefinition coroutineCreator, FieldDefinition hostRef)
    {
        return (coroutineCarrier, runtimeInjectType) =>
        {
            MethodBody targetBody = coroutineCarrier.Body;
            ILProcessor il = targetBody.GetILProcessor();

            il.InsertBefore(cursor, il.Create(OpCodes.Ldloc, funcDef));
            if (coroutineCreator.HasThis)
            {
                il.InsertBefore(cursor, il.Create(OpCodes.Ldarg_0));
                il.InsertBefore(cursor, il.Create(OpCodes.Ldfld, hostRef));
            }
            CopyCarrierFieldsToArg(coroutineCreator, coroutineCarrier);
            FillCoroutineState(coroutineCarrier);

            il.InsertBefore(cursor, il.Create(OpCodes.Call, GetLuaMethodInvoker(coroutineCreator, true, true)));
        };
    }

    static void CopyCoroutineCreatorReference(MethodDefinition coroutineCreator, TypeDefinition coroutineCarrier, ref FieldDefinition hostField)
    {
        if (coroutineCreator.HasThis)
        {
            ILProcessor il = coroutineCreator.Body.GetILProcessor();

            hostField = new FieldDefinition("__iHost", Mono.Cecil.FieldAttributes.Public, coroutineCreator.DeclaringType);
            coroutineCarrier.Fields.Add(hostField);
            il.InsertBefore(cursor, il.Create(OpCodes.Ldloc_0));
            il.InsertBefore(cursor, il.Create(OpCodes.Ldarg_0));
            il.InsertBefore(cursor, il.Create(OpCodes.Stfld, hostField));
        }
    }

    static void CopyCreatorArgsToCarrier(MethodDefinition coroutineCreator, MethodDefinition coroutineCarrier)
    {
        ILProcessor il = coroutineCreator.Body.GetILProcessor();
        var carrierFields = coroutineCarrier.DeclaringType.Fields;

        coroutineCreator
            .Parameters
            .Foreach(param =>
            {
                var name = "<$>" + param.Name;
                if (!carrierFields.Any(field => field.Name == name))
                {
                    var hostArg = new FieldDefinition(name, Mono.Cecil.FieldAttributes.Public, param.ParameterType);
                    carrierFields.Add(hostArg);
                    il.InsertBefore(cursor, il.Create(OpCodes.Ldloc_0));
                    il.InsertBefore(cursor, il.Create(OpCodes.Ldarg, param));
                    il.InsertBefore(cursor, il.Create(OpCodes.Stfld, hostArg));
                }
            });
    }

    static void CopyCarrierFieldsToArg(MethodDefinition coroutineCreator, MethodDefinition coroutineCarrier)
    {
        ILProcessor il = coroutineCarrier.Body.GetILProcessor();
        var carrierFields = coroutineCarrier.DeclaringType.Fields;

        coroutineCreator
            .Parameters
            .Select(param => "<$>" + param.Name)
            .Foreach(name =>
            {
                var arg = carrierFields.Single(field => field.Name == name);
                il.InsertBefore(cursor, il.Create(OpCodes.Ldarg_0));
                il.InsertBefore(cursor, il.Create(OpCodes.Ldfld, arg));
            });
    }

    static void FillCoroutineState(MethodDefinition coroutineCarrier)
    {
        MethodBody targetBody = coroutineCarrier.Body;
        ILProcessor il = targetBody.GetILProcessor();

        il.InsertBefore(cursor, il.Create(OpCodes.Ldarg_0));
        var stateField = coroutineCarrier.DeclaringType.Fields.Single(field => field.Name == "$PC");
        il.InsertBefore(cursor, il.Create(OpCodes.Ldfld, stateField));
    }

#endregion Coroutine

#region NormalMethod
    static void InjectMethod(AssemblyDefinition assembly, MethodDefinition target, int methodIndex)
    {
        target.Body.SimplifyMacros();
        FillBegin(target, methodIndex);
        InjectType runtimeInjectType = GetMethodRuntimeInjectType(target);
        FillInjectMethod(target, FillInjectInfo, runtimeInjectType & InjectType.After);
        FillInjectMethod(target, FillInjectInfo, runtimeInjectType & (~InjectType.After));
        target.Body.OptimizeMacros();
    }

    static void FillInjectMethod(MethodDefinition target, Action<MethodDefinition, InjectType> fillInjectInfo, InjectType runtimeInjectType)
    {
        if (runtimeInjectType == InjectType.None)
        {
            return;
        }

        MethodBody targetBody = target.Body;
        ILProcessor il = targetBody.GetILProcessor();
        cursor = GetMethodNextInsertPosition(target, null, runtimeInjectType.HasFlag(InjectType.After));

        while (cursor != null)
        {
            bool bAfterInject = runtimeInjectType == InjectType.After;
            Instruction startPos = il.Create(OpCodes.Ldloc, flagDef);
            if (bAfterInject)
            {
                /// Replace instruction with references reserved
                Instruction endPos = il.Create(OpCodes.Ret);
                int replaceIndex = targetBody.Instructions.IndexOf(cursor);
                cursor.OpCode = startPos.OpCode;
                cursor.Operand = startPos.Operand;
                il.InsertAfter(targetBody.Instructions[replaceIndex], endPos);
                cursor = targetBody.Instructions[replaceIndex + 1];
            }
            else il.InsertBefore(cursor, startPos);
            il.InsertBefore(cursor, il.Create(ldcI4s[(int)InjectType.After / 2]));
            il.InsertBefore(cursor, il.Create(bAfterInject ? OpCodes.Bne_Un : OpCodes.Ble_Un, cursor));

            fillInjectInfo(target, runtimeInjectType);
            cursor = GetMethodNextInsertPosition(target, cursor, runtimeInjectType.HasFlag(InjectType.After));
        }
    }

    static void FillInjectInfo(MethodDefinition target, InjectType runtimeInjectType)
    {
        FillBaseCall(target, runtimeInjectType, true);
        FillLuaMethodCall(target, runtimeInjectType == InjectType.After);
        FillBaseCall(target, runtimeInjectType, false);
        FillJumpInfo(target, runtimeInjectType == InjectType.After);
    }

    static void FillBaseCall(MethodDefinition target, InjectType runtimeInjectType, bool preCall)
    {
        MethodBody targetBody = target.Body;
        ILProcessor il = targetBody.GetILProcessor();
        InjectType curBaseInjectType = preCall ? InjectType.ReplaceWithPreInvokeBase : InjectType.ReplaceWithPostInvokeBase;

        if (runtimeInjectType.HasFlag(curBaseInjectType))
        {
            Instruction end = il.Create(OpCodes.Nop);
            il.InsertBefore(cursor, end);
            il.InsertBefore(end, il.Create(OpCodes.Ldloc, flagDef));
            il.InsertBefore(end, il.Create(OpCodes.Ldc_I4, (int)curBaseInjectType));
            il.InsertBefore(end, il.Create(OpCodes.Bne_Un, end));

            FillArgs(target, end, PostProcessBaseMethodArg);
            il.InsertBefore(end, il.Create(OpCodes.Call, target.GetBaseMethodInstance()));
            if (!target.ReturnVoid())
            {
                il.InsertBefore(end, il.Create(OpCodes.Pop));
            }
        }
    }

    static void FillLuaMethodCall(MethodDefinition target, bool bConfirmPopReturnValue)
    {
        ILProcessor il = target.Body.GetILProcessor();
        Instruction start = il.Create(OpCodes.Ldloc, funcDef);

        if (cursor.Previous.OpCode == OpCodes.Nop)
        {
            cursor.Previous.OpCode = start.OpCode;
            cursor.Previous.Operand = start.Operand;
        }
        else
        {
            il.InsertBefore(cursor, start);
        }

        FillArgs(target, cursor, ParseArgumentReference);
        il.InsertBefore(cursor, il.Create(OpCodes.Call, GetLuaMethodInvoker(target, bConfirmPopReturnValue, false)));

        CacheResultTable(target, bConfirmPopReturnValue);
        UpdatePassedByReferenceParams(target, bConfirmPopReturnValue);
    }

    static void CacheResultTable(MethodDefinition target, bool bConfirmPopReturnValue)
    {
        ILProcessor il = target.Body.GetILProcessor();
        if (target.GotPassedByReferenceParam())
        {
            il.InsertBefore(cursor, il.Create(OpCodes.Stloc, GetResultTable(target)));
        }
    }

    static VariableDefinition GetResultTable(MethodDefinition target)
    {
        VariableDefinition luaTable = null;
        resultTableGroup.TryGetValue(target, out luaTable);
        if (luaTable == null)
        {
            luaTable = new VariableDefinition(luaTableTypeDef);
            target.Body.Variables.Add(luaTable);
            resultTableGroup.Add(target, luaTable);
        }

        return luaTable;
    }

    static void UpdatePassedByReferenceParams(MethodDefinition target, bool bConfirmPopReturnValue)
    {
        if (!target.GotPassedByReferenceParam())
        {
            return;
        }

        int updateCount = 0;
        ILProcessor il = target.Body.GetILProcessor();
        VariableDefinition luaTable = GetResultTable(target);
        var rawGetGenericMethod = luaTableTypeDef.Methods.Single(method => method.Name == "RawGetIndex");

        foreach (var param in target.Parameters)
        {
            if (!param.ParameterType.IsByReference)
            {
                continue;
            }

            var paramType = ElementType.For(param.ParameterType);
            il.InsertBefore(cursor, il.Create(OpCodes.Ldarg, param));
            il.InsertBefore(cursor, il.Create(OpCodes.Ldloc, luaTable));
            il.InsertBefore(cursor, il.Create(OpCodes.Ldc_I4, ++updateCount));
            il.InsertBefore(cursor, il.Create(OpCodes.Call, rawGetGenericMethod.MakeGenericMethod(paramType)));
            if (paramType.IsValueType)
            {
                il.InsertBefore(cursor, il.Create(OpCodes.Stobj, paramType));
            }
            else
            {
                il.InsertBefore(cursor, il.Create(OpCodes.Stind_Ref));
            }
        }

        if (!bConfirmPopReturnValue && !target.ReturnVoid())
        {
            il.InsertBefore(cursor, il.Create(OpCodes.Ldloc, luaTable));
            il.InsertBefore(cursor, il.Create(OpCodes.Ldc_I4, ++updateCount));
            il.InsertBefore(cursor, il.Create(OpCodes.Call, rawGetGenericMethod.MakeGenericMethod(target.ReturnType)));
        }
    }

    static void FillJumpInfo(MethodDefinition target, bool bConfirmPopReturnValue)
    {
        MethodBody targetBody = target.Body;
        ILProcessor il = targetBody.GetILProcessor();

        if (!bConfirmPopReturnValue)
        {
            Instruction retIns = il.Create(OpCodes.Ret);
            if (!injectType.HasFlag(InjectType.Before))
            {
                if (cursor.Previous.OpCode == OpCodes.Nop)
                {
                    cursor.Previous.OpCode = retIns.OpCode;
                    cursor.Previous.Operand = retIns.Operand;
                    retIns = cursor.Previous;
                }
                else
                {
                    il.InsertBefore(cursor, retIns);
                }
            }
            else
            {
                Instruction start = il.Create(OpCodes.Ldloc, flagDef);
                if (cursor.Previous.OpCode == OpCodes.Nop)
                {
                    cursor.Previous.OpCode = start.OpCode;
                    cursor.Previous.Operand = start.Operand;
                    il.InsertAfter(cursor.Previous, retIns);
                }
                else
                {
                    il.InsertBefore(cursor, retIns);
                    il.InsertBefore(retIns, start);
                }

                Instruction popIns = il.Create(OpCodes.Pop);
                bool bGotReturnValue = !target.ReturnVoid();
                if (bGotReturnValue)
                {
                    il.InsertBefore(cursor, popIns);
                }
                il.InsertBefore(retIns, il.Create(ldcI4s[(int)InjectType.Before / 2]));
                il.InsertBefore(retIns, il.Create(OpCodes.Ble_Un, bGotReturnValue ? popIns : cursor));
            }
        }
        else if (cursor.Previous.OpCode == OpCodes.Nop)
        {
            targetBody.Instructions.Remove(cursor.Previous);
        }
    }
#endregion NormalMethod

    static void FillArgs(MethodDefinition target, Instruction endPoint, Action<MethodDefinition, Instruction, int> parseReferenceProcess)
    {
        MethodBody targetBody = target.Body;
        ILProcessor il = targetBody.GetILProcessor();
        int paramCount = target.Parameters.Count + (target.HasThis ? 1 : 0);

        for (int i = 0; i < paramCount; ++i)
        {
            if (i < ldargs.Length)
            {
                il.InsertBefore(endPoint, il.Create(ldargs[i]));
            }
            else if (i <= byte.MaxValue)
            {
                il.InsertBefore(endPoint, il.Create(OpCodes.Ldarg_S, (byte)i));
            }
            else
            {
                il.InsertBefore(endPoint, il.Create(OpCodes.Ldarg, (short)i));
            }

            if (parseReferenceProcess != null)
            {
                parseReferenceProcess(target, endPoint, i);
            }
        }
    }

    static void PostProcessBaseMethodArg(MethodDefinition target, Instruction endPoint, int paramIndex)
    {
        var declaringType = target.DeclaringType;
        ILProcessor il = target.Body.GetILProcessor();
        if (paramIndex == 0 && declaringType.IsValueType)
        {
            il.InsertBefore(endPoint, il.Create(OpCodes.Ldobj, declaringType));
            il.InsertBefore(endPoint, il.Create(OpCodes.Box, declaringType));
        }
    }

    static void ParseArgumentReference(MethodDefinition target, Instruction endPoint, int paramIndex)
    {
        ParameterDefinition param = null;
        ILProcessor il = target.Body.GetILProcessor();

        if (target.HasThis)
        {
            if (paramIndex > 0)
            {
                param = target.Parameters[paramIndex - 1];
            }
            else if (target.DeclaringType.IsValueType)
            {
                il.InsertBefore(endPoint, il.Create(OpCodes.Ldobj, target.DeclaringType));
            }
        }
        else if (!target.HasThis)
        {
            param = target.Parameters[paramIndex];
        }

        if (param != null && param.ParameterType.IsByReference)
        {
            TypeReference paramType = ElementType.For(param.ParameterType);
            if (paramType.IsValueType)
            {
                il.InsertBefore(endPoint, il.Create(OpCodes.Ldobj, paramType));
            }
            else
            {
                il.InsertBefore(endPoint, il.Create(OpCodes.Ldind_Ref));
            }
        }
    }

    static Instruction GetMethodNextInsertPosition(MethodDefinition target, Instruction curPoint, bool bInsertBeforeRet)
    {
        MethodBody targetBody = target.Body;
        if (target.IsConstructor || bInsertBeforeRet)
        {
            if (curPoint != null)
            {
                return targetBody.Instructions
                    .SkipWhile(ins => ins != curPoint)
                    .FirstOrDefault(ins => ins != curPoint && ins.OpCode == OpCodes.Ret);
            }
            else
            {
                return targetBody.Instructions
                    .FirstOrDefault(ins => ins.OpCode == OpCodes.Ret);
            }
        }
        else
        {
            if (curPoint != null) return null;
            else return targetBody.Instructions[offset];
        }
    }

    static InjectType GetMethodRuntimeInjectType(MethodDefinition target)
    {
        InjectType type = injectType;

        //bool bOverrideParantMethodFlag = target.IsVirtual && target.IsReuseSlot;
        var parantMethod = target.GetBaseMethodInstance();
        if (target.IsConstructor)
        {
            type &= ~InjectType.Before;
            type &= ~InjectType.Replace;
            type &= ~InjectType.ReplaceWithPostInvokeBase;
            type &= ~InjectType.ReplaceWithPreInvokeBase;
        }
        else if (parantMethod == null || target.IsEnumerator())
        {
            type &= ~InjectType.ReplaceWithPostInvokeBase;
            type &= ~InjectType.ReplaceWithPreInvokeBase;
        }
        else if (!target.HasBody)
        {
            type &= ~InjectType.After;
            type &= ~InjectType.Before;
        }

        return type;
    }

    static MethodReference GetLuaMethodInvoker(MethodDefinition prototypeMethod, bool bIgnoreReturnValue, bool bAppendCoroutineState)
    {
        MethodReference injectMethod = null;

        GetLuaInvoker(prototypeMethod, bIgnoreReturnValue, bAppendCoroutineState, ref injectMethod);
        FillLuaInvokerGenericArguments(prototypeMethod, bIgnoreReturnValue, bAppendCoroutineState, ref injectMethod);

        return injectMethod;
    }

    static void GetLuaInvoker(MethodDefinition prototypeMethod, bool bIgnoreReturnValue, bool bAppendCoroutineState, ref MethodReference invoker)
    {
        bool bRequireResult = prototypeMethod.GotPassedByReferenceParam()
            || (!bIgnoreReturnValue && !prototypeMethod.ReturnVoid());
        string methodName = bRequireResult ? "Invoke" : "Call";
        int paramCount = prototypeMethod.Parameters.Count;
        int paramExtraCount = prototypeMethod.HasThis ? 1 : 0;
        paramExtraCount = bAppendCoroutineState ? paramExtraCount + 1 : paramExtraCount;
        paramCount += paramExtraCount;
        invoker = luaFunctionTypeDef.Methods.FirstOrDefault(method =>
        {
            return method.Name == methodName && method.Parameters.Count == paramCount && bRequireResult == !method.ReturnVoid();
        });

        if (invoker == null)
        {
            Debug.Log(prototypeMethod.FullName + " Got too many parameters!!!Skipped!!!");
        }
    }

    static void FillLuaInvokerGenericArguments(MethodDefinition prototypeMethod, bool bIgnoreReturnValue, bool bAppendCoroutineState, ref MethodReference invoker)
    {
        if (invoker.HasGenericParameters)
        {
            GenericInstanceMethod genericInjectMethod = new GenericInstanceMethod(invoker.CloneMethod());

            if (prototypeMethod.HasThis)
            {
                genericInjectMethod.GenericArguments.Add(prototypeMethod.DeclaringType);
            }
            foreach (ParameterDefinition parameter in prototypeMethod.Parameters)
            {
                var paramType = parameter.ParameterType.IsByReference ? ElementType.For(parameter.ParameterType) : parameter.ParameterType;
                genericInjectMethod.GenericArguments.Add(paramType);
            }
            if (bAppendCoroutineState)
            {
                genericInjectMethod.GenericArguments.Add(intTypeRef);
            }
            if (prototypeMethod.GotPassedByReferenceParam())
            {
                genericInjectMethod.GenericArguments.Add(luaTableTypeDef);
            }
            else if (!bIgnoreReturnValue && !prototypeMethod.ReturnVoid())
            {
                genericInjectMethod.GenericArguments.Add(prototypeMethod.ReturnType);
            }

            invoker = genericInjectMethod;
        }
    }

    static void UpdateInjectionCacheSize()
    {
        var staticConstructor = injectStationTypeDef.Methods.Single((method) =>
        {
            return method.Name == ".cctor";
        });

        var il = staticConstructor.Body.GetILProcessor();
        Instruction loadStaticFieldIns = null;
        loadStaticFieldIns = staticConstructor
            .Body
            .Instructions
            .FirstOrDefault(ins =>
            {
                return ins.OpCode == OpCodes.Ldsfld
                       && (ins.Operand as FieldReference).Name == "cacheSize";
            });

        var loadCacheSizeIns = il.Create(OpCodes.Ldc_I4, methodCounter + 1);
        il.InsertBefore(loadStaticFieldIns, loadCacheSizeIns);
        il.InsertBefore(loadStaticFieldIns, il.Create(OpCodes.Stsfld, (loadStaticFieldIns.Operand as FieldReference)));
    }

    static void WriteInjectedAssembly(AssemblyDefinition assembly, string assemblyPath)
    {
        var writerParameters = new WriterParameters { WriteSymbols = EnableSymbols };
        assembly.Write(assemblyPath, writerParameters);
    }

    static void ExportInjectionBridgeInfo()
    {
        ExportInjectionPublishInfo(bridgeInfo);
        ExportInjectionEditorInfo(bridgeInfo);
    }

    static void ExportInjectionPublishInfo(SortedDictionary<string, List<InjectedMethodInfo>> data)
    {
        var temp = data.ToDictionary(
            typeInfo => typeInfo.Key,
            typeinfo =>
            {
                return typeinfo.Value
                            .OrderBy(methodInfo => methodInfo.methodPublishedName)
                            .ToDictionary(
                                methodInfo => methodInfo.methodPublishedName,
                                methodInfo => methodInfo.methodIndex
                            );
            }
        );

        StringBuilder sb = StringBuilderCache.Acquire();
        sb.Append("return ");
        ToLuaText.TransferDic(temp, sb);
        sb.Remove(sb.Length - 1, 1);
        File.WriteAllText(CustomSettings.baseLuaDir + "System/Injection/InjectionBridgeInfo.lua", StringBuilderCache.GetStringAndRelease(sb));
    }

    static int AppendMethod(MethodDefinition method)
    {
        string methodSignature = GetMethodSignature(method);
        string methodFullSignature = method.FullName;
        InjectedMethodInfo newInfo = new InjectedMethodInfo();
        string typeName = ToLuaInjectionHelper.GetTypeName(method.DeclaringType, true);
        List<InjectedMethodInfo> typeMethodIndexGroup = null;
        bridgeInfo.TryGetValue(typeName, out typeMethodIndexGroup);

        if (typeMethodIndexGroup == null)
        {
            typeMethodIndexGroup = new List<InjectedMethodInfo>();
            newInfo.methodPublishedName = method.Name;
            bridgeInfo.Add(typeName, typeMethodIndexGroup);
        }
        else
        {
            InjectedMethodInfo existInfo = typeMethodIndexGroup.Find(info => info.methodOverloadSignature == methodSignature);

            if (existInfo == null)
            {
                existInfo = typeMethodIndexGroup.Find(info => info.methodName == method.Name);
                if (existInfo != null)
                {
                    newInfo.methodPublishedName = methodSignature;
                    existInfo.methodPublishedName = existInfo.methodOverloadSignature;
                }
                else
                {
                    newInfo.methodPublishedName = method.Name;
                }
            }
            else
            {
                if (existInfo.methodFullSignature != methodFullSignature)
                {
                    Debug.LogError(typeName + "." + existInfo.methodPublishedName + " 签名跟历史签名不一致，无法增量，Injection中断，请修改函数签名、或者直接删掉InjectionBridgeEditorInfo.xml（该操作会导致无法兼容线上版的包体，需要强制换包）！");
                    EditorPrefs.SetInt(Application.dataPath + "WaitForInjection", 0);
                    return -1;
                }
                return existInfo.methodIndex;
            }
        }

        newInfo.methodName = method.Name;
        newInfo.methodOverloadSignature = methodSignature;
        newInfo.methodFullSignature = methodFullSignature;
        newInfo.methodIndex = ++methodCounter;
        typeMethodIndexGroup.Add(newInfo);

        return methodCounter;
    }

    static string GetMethodSignature(MethodDefinition method)
    {
        StringBuilder paramsTypeNameBuilder = StringBuilderCache.Acquire();
        paramsTypeNameBuilder.Append(method.Name);

        foreach (var param in method.Parameters)
        {
            paramsTypeNameBuilder
                .Append("-")
                .Append(ToLuaInjectionHelper.GetTypeName(param.ParameterType));
        }

        return StringBuilderCache.GetStringAndRelease(paramsTypeNameBuilder);
    }

    static void ExportInjectionEditorInfo(SortedDictionary<string, List<InjectedMethodInfo>> data)
    {
        string incrementalFilePath = CustomSettings.injectionFilesPath + "InjectionBridgeEditorInfo.xml";
        if (File.Exists(incrementalFilePath))
        {
            File.Delete(incrementalFilePath);
        }

        var doc = new XmlDocument();
        var fileInforRoot = doc.CreateElement("Root");
        doc.AppendChild(fileInforRoot);

        foreach (var type in data)
        {
            XmlElement typeNode = doc.CreateElement("Type");
            typeNode.SetAttribute("Name", type.Key);

            var sortedMethodsGroup = type.Value.OrderBy(info => info.methodPublishedName);
            foreach (var method in sortedMethodsGroup)
            {
                XmlElement typeMethodNode = doc.CreateElement("Method");
                typeMethodNode.SetAttribute("Name", method.methodName);
                typeMethodNode.SetAttribute("PublishedName", method.methodPublishedName);
                typeMethodNode.SetAttribute("Signature", method.methodOverloadSignature);
                typeMethodNode.SetAttribute("FullSignature", method.methodFullSignature);
                typeMethodNode.SetAttribute("Index", method.methodIndex.ToString());
                typeNode.AppendChild(typeMethodNode);
            }

            fileInforRoot.AppendChild(typeNode);
        }

        doc.Save(incrementalFilePath);
    }

    static bool LoadBridgeEditorInfo()
    {
        bridgeInfo.Clear();
        methodCounter = 0;
        string incrementalFilePath = CustomSettings.injectionFilesPath + "InjectionBridgeEditorInfo.xml";
        if (!File.Exists(incrementalFilePath))
        {
            return true;
        }

        var doc = new XmlDocument();
        doc.Load(incrementalFilePath);
        var fileInfoRoot = doc.FindChildByName("Root");
        if (fileInfoRoot == null)
        {
            return true;
        }

        foreach (XmlNode typeChild in fileInfoRoot.ChildNodes)
        {
            List<InjectedMethodInfo> typeMethodInfo = new List<InjectedMethodInfo>();
            string typeName = typeChild.FindAttributeByName("Name").Value;

            foreach (XmlNode methodChild in typeChild.ChildNodes)
            {
                InjectedMethodInfo info = new InjectedMethodInfo();
                info.methodName = methodChild.FindAttributeByName("Name").Value;
                info.methodPublishedName = methodChild.FindAttributeByName("PublishedName").Value;
                info.methodOverloadSignature = methodChild.FindAttributeByName("Signature").Value;
                info.methodFullSignature = methodChild.FindAttributeByName("FullSignature").Value;
                info.methodIndex = int.Parse(methodChild.FindAttributeByName("Index").Value);
                typeMethodInfo.Add(info);
                methodCounter = Math.Max(methodCounter, info.methodIndex);
            }

            bridgeInfo.Add(typeName, typeMethodInfo);
        }

        return true;
    }

    static void Clean(AssemblyDefinition assembly)
    {
        if (assembly.MainModule.SymbolReader != null)
        {
            assembly.MainModule.SymbolReader.Dispose();
        }
    }

    static void CacheInjectableTypeGroup()
    {
        injectableTypeGroup.Clear();

        Assembly assebly = Assembly.Load("Assembly-CSharp");
        foreach (Type t in assebly.GetTypes())
        {
            if (DoesTypeInjectable(t))
            {
                injectableTypeGroup.Add(t.FullName);
            }
        }
    }

    static bool DoesTypeInjectable(Type type)
    {
        if (dropTypeGroup.Contains(type.FullName) || (type.DeclaringType != null && dropTypeGroup.Contains(type.DeclaringType.FullName)))
        {
            return false;
        }

        if (type.IsGenericType)
        {
            Type genericTypeDefinition = type.GetGenericTypeDefinition();
            if (dropGenericNameGroup.Contains(genericTypeDefinition.FullName))
            {
                return false;
            }
        }

        if (typeof(System.Delegate).IsAssignableFrom(type))
        {
            return false;
        }

        if (type.FullName.Contains("<") || type.IsInterface)
        {
            return false;
        }

        if (!injectIgnoring.HasFlag(InjectFilter.IgnoreNoToLuaAttr))
        {
            foreach (var attr in type.GetCustomAttributes(true))
            {
                Type attrT = attr.GetType();
                if (attrT == typeof(LuaInterface.NoToLuaAttribute))
                {
                    return false;
                }
            }
        }

        return true;
    }

    static bool DoesTypeInjectable(TypeDefinition type)
    {
        if (dropNamespaceGroup.Contains(type.SafeNamespace()))
        {
            return false;
        }

        if (!injectableTypeGroup.Contains(type.FullName.Replace("/", "+")))
        {
            return false;
        }

        if (injectIgnoring.HasFlag(InjectFilter.IgnoreConstructor) && type.Methods.Count == 1)
        {
            return false;
        }

        if (!injectIgnoring.HasFlag(InjectFilter.IgnoreNoToLuaAttr))
        {
            if (type.CustomAttributes.Any((attr) => attr.AttributeType == noToLuaAttrTypeRef))
            {
                return false;
            }
        }

        return true;
    }

    static bool DoesMethodInjectable(MethodDefinition method)
    {
        if (method.IsSpecialName)
        {
            if (method.Name == ".cctor")
            {
                return false;
            }

            bool bIgnoreConstructor = injectIgnoring.HasFlag(InjectFilter.IgnoreConstructor)
                                    || method.DeclaringType.IsAssignableTo("UnityEngine.MonoBehaviour")
                                    || method.DeclaringType.IsAssignableTo("UnityEngine.ScriptableObject");
            if (method.IsConstructor)
            {
                if (bIgnoreConstructor)
                {
                    return false;
                }
            }
            else
            {
                ///Skip add_、remove_、op_、Finalize
                if (!method.IsGetter && !method.IsSetter)
                {
                    return false;
                }
            }
        }

        if (method.Name.Contains("<") || method.IsUnmanaged || method.IsAbstract || method.IsPInvokeImpl || !method.HasBody)
        {
            return false;
        }

        /// Skip Unsafe
        if (method.Body.Variables.Any(var => var.VariableType.IsPointer) || method.Parameters.Any(param => param.ParameterType.IsPinned))
        {
            return false;
        }

        /// Hmm... Sometimes method.IsSpecialName Got False
        if (method.Name == "Finalize")
        {
            return false;
        }

        if ((method.IsGetter || method.IsSetter) && injectIgnoring.HasFlag(InjectFilter.IgnoreProperty))
        {
            return false;
        }

        if (!injectIgnoring.HasFlag(InjectFilter.IgnoreNoToLuaAttr))
        {
            if (method.CustomAttributes.Any((attr) => attr.AttributeType == noToLuaAttrTypeRef))
            {
                return false;
            }
        }

        if (method.ReturnType.IsAssignableTo("System.Collections.IEnumerable"))
        {
            return false;
        }

        MethodReference luaInjector = null;
        GetLuaInvoker(method, true, false, ref luaInjector);
        if (luaInjector == null)
        {
            return false;
        }

        return true;
    }

    static bool LoadBlackList()
    {
        if (File.Exists(InjectionBlackListGenerator.blackListFilePath))
        {
            dropTypeGroup.UnionWith(File.ReadAllLines(InjectionBlackListGenerator.blackListFilePath));
            dropTypeGroup.ExceptWith(forceInjectTypeGroup);
        }
        else
        {
            if (EditorUtility.DisplayDialog("警告", "由于Injection会额外增加代码量，故可以先设置一些Injection跳过的代码目录(比如NGUI插件代码目录)，减少生成的代码量", "设置黑名单", "全量生成"))
            {
                InjectionBlackListGenerator.Open();
                InjectionBlackListGenerator.onBlackListGenerated += InjectAll;
                return false;
            }
        }

        return true;
    }
}

public static class SystemXMLExtension
{
    public static XmlNode FindChildByName(this XmlNode root, string childName)
    {
        var child = root.FirstChild;
        while (child != null)
        {
            if (child.Name.Equals(childName))
            {
                return child;
            }
            else
            {
                child = child.NextSibling;
            }
        }

        return null;
    }

    public static XmlAttribute FindAttributeByName(this XmlNode node, string attributeName)
    {
        var attributeCollection = node.Attributes;
        for (int i = 0; i < attributeCollection.Count; i++)
        {
            if (attributeCollection[i].Name.Equals(attributeName))
            {
                return attributeCollection[i];
            }
        }

        return null;
    }
}

#endif