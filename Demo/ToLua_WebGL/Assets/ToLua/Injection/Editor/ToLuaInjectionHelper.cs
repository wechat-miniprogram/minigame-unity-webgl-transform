#if ENABLE_LUA_INJECTION
using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Unity.CecilTools;
using System.Linq;

[Flags]
public enum InjectFilter
{
    IgnoreConstructor = 1,
    IgnoreProperty = 1 << 1,
    IgnoreGeneric = 1 << 2,
    IgnoreNoToLuaAttr = 1 << 3,
}

public static class ToLuaInjectionHelper
{
    public static string GetArrayRank(TypeReference t)
    {
        ArrayType type = t as ArrayType;
        int count = type.Rank;

        if (count == 1)
        {
            return "[]";
        }

        using (CString.Block())
        {
            CString sb = CString.Alloc(64);
            sb.Append('[');

            for (int i = 1; i < count; i++)
            {
                sb.Append(',');
            }

            sb.Append(']');
            return sb.ToString();
        }
    }

    public static string GetTypeName(TypeReference t, bool bFull = false)
    {
        if (t.IsArray)
        {
            string str = GetTypeName(ElementType.For(t));
            str += GetArrayRank(t);
            return str;
        }
        else if (t.IsByReference)
        {
            //t = t.GetElementType();
            return GetTypeName(ElementType.For(t)) + "&";
        }
        else if (t.IsGenericInstance)
        {
            return GetGenericName(t, bFull);
        }
        else if (t.MetadataType == MetadataType.Void)
        {
            return "void";
        }
        else
        {
            string name = GetPrimitiveTypeStr(t, bFull);
            return name.Replace('+', '.');
        }
    }

    public static string[] GetGenericName(Mono.Collections.Generic.Collection<TypeReference> types, int offset, int count, bool bFull)
    {
        string[] results = new string[count];

        for (int i = 0; i < count; i++)
        {
            int pos = i + offset;

            if (types[pos].IsGenericInstance)
            {
                results[i] = GetGenericName(types[pos], bFull);
            }
            else
            {
                results[i] = GetTypeName(types[pos]);
            }
        }

        return results;
    }

    public static MethodReference GetBaseMethodInstance(this MethodDefinition target)
    {
        MethodDefinition baseMethodDef = null;
        var baseType = target.DeclaringType.BaseType;

        while (baseType != null)
        {
            if (baseType.MetadataToken.TokenType == TokenType.TypeRef)
            {
                break;
            }

            var baseTypeDef = baseType.Resolve();
            baseMethodDef = MetadataResolver.GetMethod(baseTypeDef.Methods, target);
            if (baseMethodDef != null && !baseMethodDef.IsAbstract)
            {
                if (baseType.IsGenericInstance)
                {
                    MethodReference baseMethodRef = baseType.Module.Import(baseMethodDef);
                    var baseTypeInstance = (GenericInstanceType)baseType;
                    return baseMethodRef.MakeGenericMethod(baseTypeInstance.GenericArguments.ToArray());
                }
                break;
            }
            else baseMethodDef = null;

           baseType = baseTypeDef.BaseType;
        }

        return baseMethodDef;
    }

    public static bool IsGenericTypeDefinition(this TypeReference type)
    {
        if (type.HasGenericParameters)
        {
            return true;
        }
        else if (type.IsByReference || type.IsArray)
        {
            return ElementType.For(type).IsGenericTypeDefinition();
        }
        else if (type.IsNested)
        {
            var parent = type.DeclaringType;
            while (parent != null)
            {
                if (parent.IsGenericTypeDefinition())
                {
                    return true;
                }

                if (parent.IsNested)
                {
                    parent = parent.DeclaringType;
                }
                else
                {
                    break;
                }
            }
        }

        return type.IsGenericParameter;
    }

    public static bool IsGenericMethodDefinition(this MethodDefinition md)
    {
        if (md.HasGenericParameters
#if UNITY_5_2 || UNITY_5_3 || UNITY_5_3_OR_NEWER
            || md.ContainsGenericParameter
#endif
            )
        {
            return true;
        }

        if (md.DeclaringType != null && md.DeclaringType.IsGenericTypeDefinition())
        {
            return true;
        }

        if (md.ReturnType.IsGenericTypeDefinition())
        {
            return true;
        }

        foreach (var param in md.Parameters)
        {
            if (param.ParameterType.IsGenericTypeDefinition())
            {
                return true;
            }
        }

        return false;
    }

    public static bool GotPassedByReferenceParam(this MethodReference md)
    {
        return md.Parameters.Any(param => param.ParameterType.IsByReference);
    }

    public static TypeReference MakeGenericType(this TypeReference self, params TypeReference[] arguments)
    {
        if (self.GenericParameters.Count != arguments.Length)
        {
            throw new ArgumentException();
        }

        var instance = new GenericInstanceType(self);
        foreach (var argument in arguments)
        {
            instance.GenericArguments.Add(argument);
        }

        return instance;
    }

    public static MethodReference MakeGenericMethod(this MethodReference self, params TypeReference[] arguments)
    {
        if (self.DeclaringType.IsGenericTypeDefinition())
        {
            return self.CloneMethod(self.DeclaringType.MakeGenericType(arguments));
        }
        else
        {
            var genericInstanceMethod = new GenericInstanceMethod(self.CloneMethod());

            foreach (var argument in arguments)
            {
                genericInstanceMethod.GenericArguments.Add(argument);
            }

            return genericInstanceMethod;
        }
    }

    public static MethodReference CloneMethod(this MethodReference self, TypeReference declaringType = null)
    {
        var reference = new MethodReference(self.Name, self.ReturnType, declaringType ?? self.DeclaringType)
        {
            HasThis = self.HasThis,
            ExplicitThis = self.ExplicitThis,
            CallingConvention = self.CallingConvention,
        };

        foreach (ParameterDefinition parameterDef in self.Parameters)
        {
            reference.Parameters.Add(new ParameterDefinition(parameterDef.Name, parameterDef.Attributes, parameterDef.ParameterType));
        }

        foreach (GenericParameter genParamDef in self.GenericParameters)
        {
            reference.GenericParameters.Add(new GenericParameter(genParamDef.Name, reference));
        }

        return reference;
    }

    public static bool IsEnumerator(this MethodDefinition md)
    {
        return md.ReturnType.FullName == "System.Collections.IEnumerator";
    }

    public static bool ReturnVoid(this MethodDefinition target)
    {
        return target.ReturnType.FullName == "System.Void";
    }

    public static bool HasFlag(this LuaInterface.InjectType flag, LuaInterface.InjectType destFlag)
    {
        return (flag & destFlag) == destFlag;
    }

    public static bool HasFlag(this LuaInterface.InjectType flag, byte destFlag)
    {
        return ((byte)flag & destFlag) == destFlag;
    }

    public static bool HasFlag(this InjectFilter flag, InjectFilter destFlag)
    {
        return (flag & destFlag) == destFlag;
    }

    public static string GetPrimitiveTypeStr(TypeReference t, bool bFull)
    {
        switch (t.MetadataType)
        {
            case MetadataType.Single:
                return "float";
            case MetadataType.String:
                return "string";
            case MetadataType.Int32:
                return "int";
            case MetadataType.Double:
                return "double";
            case MetadataType.Boolean:
                return "bool";
            case MetadataType.UInt32:
                return "uint";
            case MetadataType.SByte:
                return "sbyte";
            case MetadataType.Byte:
                return "byte";
            case MetadataType.Int16:
                return "short";
            case MetadataType.UInt16:
                return "ushort";
            case MetadataType.Char:
                return "char";
            case MetadataType.Int64:
                return "long";
            case MetadataType.UInt64:
                return "ulong";
            case MetadataType.Object:
                return "object";
            default:
                return bFull ? t.FullName.Replace("/", "+") : t.Name;
        }
    }

    static string CombineTypeStr(string space, string name)
    {
        if (string.IsNullOrEmpty(space))
        {
            return name;
        }
        else
        {
            return space + "." + name;
        }
    }

    static string GetGenericName(TypeReference t, bool bFull)
    {
        GenericInstanceType type = t as GenericInstanceType;
        var gArgs = type.GenericArguments;

        string typeName = bFull ? t.FullName.Replace("/", "+") : t.Name;
        int count = gArgs.Count;
        int pos = typeName.IndexOf("[");

        if (pos > 0)
        {
            typeName = typeName.Substring(0, pos);
        }

        string str = null;
        string name = null;
        int offset = 0;
        pos = typeName.IndexOf("+");

        while (pos > 0)
        {
            str = typeName.Substring(0, pos);
            typeName = typeName.Substring(pos + 1);
            pos = str.IndexOf('`');

            if (pos > 0)
            {
                count = (int)(str[pos + 1] - '0');
                str = str.Substring(0, pos);
                str += "<" + string.Join(",", GetGenericName(gArgs, offset, count, bFull)) + ">";
                offset += count;
            }

            name = CombineTypeStr(name, str);
            pos = typeName.IndexOf("+");
        }

        str = typeName;

        if (offset < gArgs.Count)
        {
            pos = str.IndexOf('`');
            count = (int)(str[pos + 1] - '0');
            str = str.Substring(0, pos);
            str += "<" + string.Join(",", GetGenericName(gArgs, offset, count, bFull)) + ">";
        }

        return CombineTypeStr(name, str);
    }

    public static void Foreach<T>(this IEnumerable<T> source, Action<T> callback)
    {
        foreach (var val in source)
        {
            callback(val);
        }
    }
}
#endif