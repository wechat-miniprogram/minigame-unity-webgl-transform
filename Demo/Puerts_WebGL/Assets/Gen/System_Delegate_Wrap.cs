#if !(EXPERIMENTAL_IL2CPP_PUERTS && ENABLE_IL2CPP)
using System;
using Puerts;

namespace PuertsStaticWrap
{
#pragma warning disable 0219
    public static class System_Delegate_Wrap
    {
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8ConstructorCallback))]
        internal static IntPtr Constructor(IntPtr isolate, IntPtr info, int paramLen, long data)
        {
            try
            {
                Puerts.PuertsDLL.ThrowException(
                    isolate,
                    "invalid arguments to "
                        + typeof(System.Delegate).GetFriendlyName()
                        + " constructor"
                );
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(
                    isolate,
                    "c# exception:" + e.Message + ",stack:" + e.StackTrace
                );
            }
            return IntPtr.Zero;
        }

        // ==================== constructor end ====================

        // ==================== methods start ====================
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void F_CreateDelegate(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                if (paramLen == 4)
                {
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    JsValueType argType0 = JsValueType.Invalid;
                    IntPtr v8Value1 = PuertsDLL.GetArgumentValue(info, 1);
                    object argobj1 = null;
                    JsValueType argType1 = JsValueType.Invalid;
                    IntPtr v8Value2 = PuertsDLL.GetArgumentValue(info, 2);
                    object argobj2 = null;
                    JsValueType argType2 = JsValueType.Invalid;
                    IntPtr v8Value3 = PuertsDLL.GetArgumentValue(info, 3);
                    object argobj3 = null;
                    JsValueType argType3 = JsValueType.Invalid;
                    if (
                        ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.NativeObject,
                            typeof(System.Type),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Any,
                            typeof(System.Object),
                            false,
                            false,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.NativeObject,
                            typeof(System.Reflection.MethodInfo),
                            false,
                            false,
                            v8Value2,
                            ref argobj2,
                            ref argType2
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Boolean,
                            typeof(bool),
                            false,
                            false,
                            v8Value3,
                            ref argobj3,
                            ref argType3
                        )
                    )
                    {
                        argobj0 =
                            argobj0 != null
                                ? argobj0
                                : StaticTranslate<System.Type>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        System.Type arg0 = (System.Type)argobj0;
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<System.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        System.Object arg1 = (System.Object)argobj1;
                        argobj2 =
                            argobj2 != null
                                ? argobj2
                                : StaticTranslate<System.Reflection.MethodInfo>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value2,
                                    false
                                );
                        System.Reflection.MethodInfo arg2 = (System.Reflection.MethodInfo)argobj2;
                        bool arg3 = (bool)PuertsDLL.GetBooleanFromValue(isolate, v8Value3, false);

                        var result = System.Delegate.CreateDelegate(arg0, arg1, arg2, arg3);

                        Puerts.ResultHelper.Set((int)data, isolate, info, result);
                        return;
                    }
                    if (
                        ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.NativeObject,
                            typeof(System.Type),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.NativeObject,
                            typeof(System.Type),
                            false,
                            false,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.String,
                            typeof(string),
                            false,
                            false,
                            v8Value2,
                            ref argobj2,
                            ref argType2
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Boolean,
                            typeof(bool),
                            false,
                            false,
                            v8Value3,
                            ref argobj3,
                            ref argType3
                        )
                    )
                    {
                        argobj0 =
                            argobj0 != null
                                ? argobj0
                                : StaticTranslate<System.Type>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        System.Type arg0 = (System.Type)argobj0;
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<System.Type>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        System.Type arg1 = (System.Type)argobj1;
                        string arg2 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value2, false);
                        bool arg3 = (bool)PuertsDLL.GetBooleanFromValue(isolate, v8Value3, false);

                        var result = System.Delegate.CreateDelegate(arg0, arg1, arg2, arg3);

                        Puerts.ResultHelper.Set((int)data, isolate, info, result);
                        return;
                    }
                    if (
                        ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.NativeObject,
                            typeof(System.Type),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Any,
                            typeof(System.Object),
                            false,
                            false,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.String,
                            typeof(string),
                            false,
                            false,
                            v8Value2,
                            ref argobj2,
                            ref argType2
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Boolean,
                            typeof(bool),
                            false,
                            false,
                            v8Value3,
                            ref argobj3,
                            ref argType3
                        )
                    )
                    {
                        argobj0 =
                            argobj0 != null
                                ? argobj0
                                : StaticTranslate<System.Type>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        System.Type arg0 = (System.Type)argobj0;
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<System.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        System.Object arg1 = (System.Object)argobj1;
                        string arg2 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value2, false);
                        bool arg3 = (bool)PuertsDLL.GetBooleanFromValue(isolate, v8Value3, false);

                        var result = System.Delegate.CreateDelegate(arg0, arg1, arg2, arg3);

                        Puerts.ResultHelper.Set((int)data, isolate, info, result);
                        return;
                    }
                }
                if (paramLen == 3)
                {
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    JsValueType argType0 = JsValueType.Invalid;
                    IntPtr v8Value1 = PuertsDLL.GetArgumentValue(info, 1);
                    object argobj1 = null;
                    JsValueType argType1 = JsValueType.Invalid;
                    IntPtr v8Value2 = PuertsDLL.GetArgumentValue(info, 2);
                    object argobj2 = null;
                    JsValueType argType2 = JsValueType.Invalid;
                    if (
                        ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.NativeObject,
                            typeof(System.Type),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Any,
                            typeof(System.Object),
                            false,
                            false,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.NativeObject,
                            typeof(System.Reflection.MethodInfo),
                            false,
                            false,
                            v8Value2,
                            ref argobj2,
                            ref argType2
                        )
                    )
                    {
                        argobj0 =
                            argobj0 != null
                                ? argobj0
                                : StaticTranslate<System.Type>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        System.Type arg0 = (System.Type)argobj0;
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<System.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        System.Object arg1 = (System.Object)argobj1;
                        argobj2 =
                            argobj2 != null
                                ? argobj2
                                : StaticTranslate<System.Reflection.MethodInfo>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value2,
                                    false
                                );
                        System.Reflection.MethodInfo arg2 = (System.Reflection.MethodInfo)argobj2;

                        var result = System.Delegate.CreateDelegate(arg0, arg1, arg2);

                        Puerts.ResultHelper.Set((int)data, isolate, info, result);
                        return;
                    }
                    if (
                        ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.NativeObject,
                            typeof(System.Type),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.NativeObject,
                            typeof(System.Reflection.MethodInfo),
                            false,
                            false,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Boolean,
                            typeof(bool),
                            false,
                            false,
                            v8Value2,
                            ref argobj2,
                            ref argType2
                        )
                    )
                    {
                        argobj0 =
                            argobj0 != null
                                ? argobj0
                                : StaticTranslate<System.Type>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        System.Type arg0 = (System.Type)argobj0;
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<System.Reflection.MethodInfo>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        System.Reflection.MethodInfo arg1 = (System.Reflection.MethodInfo)argobj1;
                        bool arg2 = (bool)PuertsDLL.GetBooleanFromValue(isolate, v8Value2, false);

                        var result = System.Delegate.CreateDelegate(arg0, arg1, arg2);

                        Puerts.ResultHelper.Set((int)data, isolate, info, result);
                        return;
                    }
                    if (
                        ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.NativeObject,
                            typeof(System.Type),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Any,
                            typeof(System.Object),
                            false,
                            false,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.String,
                            typeof(string),
                            false,
                            false,
                            v8Value2,
                            ref argobj2,
                            ref argType2
                        )
                    )
                    {
                        argobj0 =
                            argobj0 != null
                                ? argobj0
                                : StaticTranslate<System.Type>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        System.Type arg0 = (System.Type)argobj0;
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<System.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        System.Object arg1 = (System.Object)argobj1;
                        string arg2 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value2, false);

                        var result = System.Delegate.CreateDelegate(arg0, arg1, arg2);

                        Puerts.ResultHelper.Set((int)data, isolate, info, result);
                        return;
                    }
                    if (
                        ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.NativeObject,
                            typeof(System.Type),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.NativeObject,
                            typeof(System.Type),
                            false,
                            false,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.String,
                            typeof(string),
                            false,
                            false,
                            v8Value2,
                            ref argobj2,
                            ref argType2
                        )
                    )
                    {
                        argobj0 =
                            argobj0 != null
                                ? argobj0
                                : StaticTranslate<System.Type>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        System.Type arg0 = (System.Type)argobj0;
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<System.Type>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        System.Type arg1 = (System.Type)argobj1;
                        string arg2 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value2, false);

                        var result = System.Delegate.CreateDelegate(arg0, arg1, arg2);

                        Puerts.ResultHelper.Set((int)data, isolate, info, result);
                        return;
                    }
                }
                if (paramLen == 2)
                {
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    JsValueType argType0 = JsValueType.Invalid;
                    IntPtr v8Value1 = PuertsDLL.GetArgumentValue(info, 1);
                    object argobj1 = null;
                    JsValueType argType1 = JsValueType.Invalid;
                    if (
                        ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.NativeObject,
                            typeof(System.Type),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.NativeObject,
                            typeof(System.Reflection.MethodInfo),
                            false,
                            false,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                    )
                    {
                        argobj0 =
                            argobj0 != null
                                ? argobj0
                                : StaticTranslate<System.Type>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        System.Type arg0 = (System.Type)argobj0;
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<System.Reflection.MethodInfo>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        System.Reflection.MethodInfo arg1 = (System.Reflection.MethodInfo)argobj1;

                        var result = System.Delegate.CreateDelegate(arg0, arg1);

                        Puerts.ResultHelper.Set((int)data, isolate, info, result);
                        return;
                    }
                }
                if (paramLen == 5)
                {
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    JsValueType argType0 = JsValueType.Invalid;
                    IntPtr v8Value1 = PuertsDLL.GetArgumentValue(info, 1);
                    object argobj1 = null;
                    JsValueType argType1 = JsValueType.Invalid;
                    IntPtr v8Value2 = PuertsDLL.GetArgumentValue(info, 2);
                    object argobj2 = null;
                    JsValueType argType2 = JsValueType.Invalid;
                    IntPtr v8Value3 = PuertsDLL.GetArgumentValue(info, 3);
                    object argobj3 = null;
                    JsValueType argType3 = JsValueType.Invalid;
                    IntPtr v8Value4 = PuertsDLL.GetArgumentValue(info, 4);
                    object argobj4 = null;
                    JsValueType argType4 = JsValueType.Invalid;
                    if (
                        ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.NativeObject,
                            typeof(System.Type),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.NativeObject,
                            typeof(System.Type),
                            false,
                            false,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.String,
                            typeof(string),
                            false,
                            false,
                            v8Value2,
                            ref argobj2,
                            ref argType2
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Boolean,
                            typeof(bool),
                            false,
                            false,
                            v8Value3,
                            ref argobj3,
                            ref argType3
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Boolean,
                            typeof(bool),
                            false,
                            false,
                            v8Value4,
                            ref argobj4,
                            ref argType4
                        )
                    )
                    {
                        argobj0 =
                            argobj0 != null
                                ? argobj0
                                : StaticTranslate<System.Type>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        System.Type arg0 = (System.Type)argobj0;
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<System.Type>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        System.Type arg1 = (System.Type)argobj1;
                        string arg2 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value2, false);
                        bool arg3 = (bool)PuertsDLL.GetBooleanFromValue(isolate, v8Value3, false);
                        bool arg4 = (bool)PuertsDLL.GetBooleanFromValue(isolate, v8Value4, false);

                        var result = System.Delegate.CreateDelegate(arg0, arg1, arg2, arg3, arg4);

                        Puerts.ResultHelper.Set((int)data, isolate, info, result);
                        return;
                    }
                    if (
                        ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.NativeObject,
                            typeof(System.Type),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Any,
                            typeof(System.Object),
                            false,
                            false,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.String,
                            typeof(string),
                            false,
                            false,
                            v8Value2,
                            ref argobj2,
                            ref argType2
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Boolean,
                            typeof(bool),
                            false,
                            false,
                            v8Value3,
                            ref argobj3,
                            ref argType3
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Boolean,
                            typeof(bool),
                            false,
                            false,
                            v8Value4,
                            ref argobj4,
                            ref argType4
                        )
                    )
                    {
                        argobj0 =
                            argobj0 != null
                                ? argobj0
                                : StaticTranslate<System.Type>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        System.Type arg0 = (System.Type)argobj0;
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<System.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        System.Object arg1 = (System.Object)argobj1;
                        string arg2 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value2, false);
                        bool arg3 = (bool)PuertsDLL.GetBooleanFromValue(isolate, v8Value3, false);
                        bool arg4 = (bool)PuertsDLL.GetBooleanFromValue(isolate, v8Value4, false);

                        var result = System.Delegate.CreateDelegate(arg0, arg1, arg2, arg3, arg4);

                        Puerts.ResultHelper.Set((int)data, isolate, info, result);
                        return;
                    }
                }
                Puerts.PuertsDLL.ThrowException(isolate, "invalid arguments to CreateDelegate");
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(
                    isolate,
                    "c# exception:" + e.Message + ",stack:" + e.StackTrace
                );
            }
        }

        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void M_DynamicInvoke(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = Puerts.Utils.GetSelf((int)data, self) as System.Delegate;

                if (paramLen >= 0)
                {
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    JsValueType argType0 = JsValueType.Invalid;
                    if (
                        ArgHelper.IsMatchParams(
                            (int)data,
                            isolate,
                            info,
                            Puerts.JsValueType.Any,
                            typeof(System.Object),
                            0,
                            paramLen,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                    )
                    {
                        System.Object[] arg0 = ArgHelper.GetParams<System.Object>(
                            (int)data,
                            isolate,
                            info,
                            0,
                            paramLen,
                            v8Value0
                        );

                        var result = obj.DynamicInvoke(arg0);

                        Puerts.ResultHelper.Set((int)data, isolate, info, result);
                        return;
                    }
                }
                if (paramLen == 0)
                {
                    {
                        var result = obj.DynamicInvoke(default(System.Object));

                        Puerts.ResultHelper.Set((int)data, isolate, info, result);
                        return;
                    }
                }
                Puerts.PuertsDLL.ThrowException(isolate, "invalid arguments to DynamicInvoke");
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(
                    isolate,
                    "c# exception:" + e.Message + ",stack:" + e.StackTrace
                );
            }
        }

        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void M_Clone(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = Puerts.Utils.GetSelf((int)data, self) as System.Delegate;

                {
                    {
                        var result = obj.Clone();

                        Puerts.ResultHelper.Set((int)data, isolate, info, result);
                    }
                }
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(
                    isolate,
                    "c# exception:" + e.Message + ",stack:" + e.StackTrace
                );
            }
        }

        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void M_Equals(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = Puerts.Utils.GetSelf((int)data, self) as System.Delegate;

                {
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    ;
                    {
                        argobj0 =
                            argobj0 != null
                                ? argobj0
                                : StaticTranslate<System.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        System.Object arg0 = (System.Object)argobj0;

                        var result = obj.Equals(arg0);

                        Puerts.PuertsDLL.ReturnBoolean(isolate, info, result);
                    }
                }
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(
                    isolate,
                    "c# exception:" + e.Message + ",stack:" + e.StackTrace
                );
            }
        }

        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void M_GetHashCode(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = Puerts.Utils.GetSelf((int)data, self) as System.Delegate;

                {
                    {
                        var result = obj.GetHashCode();

                        Puerts.PuertsDLL.ReturnNumber(isolate, info, result);
                    }
                }
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(
                    isolate,
                    "c# exception:" + e.Message + ",stack:" + e.StackTrace
                );
            }
        }

        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void M_GetObjectData(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = Puerts.Utils.GetSelf((int)data, self) as System.Delegate;

                {
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    ;
                    IntPtr v8Value1 = PuertsDLL.GetArgumentValue(info, 1);
                    object argobj1 = null;
                    ;
                    {
                        argobj0 =
                            argobj0 != null
                                ? argobj0
                                : StaticTranslate<System.Runtime.Serialization.SerializationInfo>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        System.Runtime.Serialization.SerializationInfo arg0 =
                            (System.Runtime.Serialization.SerializationInfo)argobj0;
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<System.Runtime.Serialization.StreamingContext>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        System.Runtime.Serialization.StreamingContext arg1 =
                            (System.Runtime.Serialization.StreamingContext)argobj1;

                        obj.GetObjectData(arg0, arg1);
                    }
                }
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(
                    isolate,
                    "c# exception:" + e.Message + ",stack:" + e.StackTrace
                );
            }
        }

        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void M_GetInvocationList(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = Puerts.Utils.GetSelf((int)data, self) as System.Delegate;

                {
                    {
                        var result = obj.GetInvocationList();

                        Puerts.ResultHelper.Set((int)data, isolate, info, result);
                    }
                }
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(
                    isolate,
                    "c# exception:" + e.Message + ",stack:" + e.StackTrace
                );
            }
        }

        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void F_Combine(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                if (paramLen == 2)
                {
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    JsValueType argType0 = JsValueType.Invalid;
                    IntPtr v8Value1 = PuertsDLL.GetArgumentValue(info, 1);
                    object argobj1 = null;
                    JsValueType argType1 = JsValueType.Invalid;
                    if (
                        ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.NativeObject,
                            typeof(System.Delegate),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.NativeObject,
                            typeof(System.Delegate),
                            false,
                            false,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                    )
                    {
                        argobj0 =
                            argobj0 != null
                                ? argobj0
                                : StaticTranslate<System.Delegate>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        System.Delegate arg0 = (System.Delegate)argobj0;
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<System.Delegate>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        System.Delegate arg1 = (System.Delegate)argobj1;

                        var result = System.Delegate.Combine(arg0, arg1);

                        Puerts.ResultHelper.Set((int)data, isolate, info, result);
                        return;
                    }
                }
                if (paramLen >= 0)
                {
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    JsValueType argType0 = JsValueType.Invalid;
                    if (
                        ArgHelper.IsMatchParams(
                            (int)data,
                            isolate,
                            info,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.NativeObject,
                            typeof(System.Delegate),
                            0,
                            paramLen,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                    )
                    {
                        System.Delegate[] arg0 = ArgHelper.GetParams<System.Delegate>(
                            (int)data,
                            isolate,
                            info,
                            0,
                            paramLen,
                            v8Value0
                        );

                        var result = System.Delegate.Combine(arg0);

                        Puerts.ResultHelper.Set((int)data, isolate, info, result);
                        return;
                    }
                }
                if (paramLen == 0)
                {
                    {
                        var result = System.Delegate.Combine(default(System.Delegate));

                        Puerts.ResultHelper.Set((int)data, isolate, info, result);
                        return;
                    }
                }
                Puerts.PuertsDLL.ThrowException(isolate, "invalid arguments to Combine");
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(
                    isolate,
                    "c# exception:" + e.Message + ",stack:" + e.StackTrace
                );
            }
        }

        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void F_Remove(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                {
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    ;
                    IntPtr v8Value1 = PuertsDLL.GetArgumentValue(info, 1);
                    object argobj1 = null;
                    ;
                    {
                        argobj0 =
                            argobj0 != null
                                ? argobj0
                                : StaticTranslate<System.Delegate>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        System.Delegate arg0 = (System.Delegate)argobj0;
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<System.Delegate>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        System.Delegate arg1 = (System.Delegate)argobj1;

                        var result = System.Delegate.Remove(arg0, arg1);

                        Puerts.ResultHelper.Set((int)data, isolate, info, result);
                    }
                }
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(
                    isolate,
                    "c# exception:" + e.Message + ",stack:" + e.StackTrace
                );
            }
        }

        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void F_RemoveAll(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                {
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    ;
                    IntPtr v8Value1 = PuertsDLL.GetArgumentValue(info, 1);
                    object argobj1 = null;
                    ;
                    {
                        argobj0 =
                            argobj0 != null
                                ? argobj0
                                : StaticTranslate<System.Delegate>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        System.Delegate arg0 = (System.Delegate)argobj0;
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<System.Delegate>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        System.Delegate arg1 = (System.Delegate)argobj1;

                        var result = System.Delegate.RemoveAll(arg0, arg1);

                        Puerts.ResultHelper.Set((int)data, isolate, info, result);
                    }
                }
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(
                    isolate,
                    "c# exception:" + e.Message + ",stack:" + e.StackTrace
                );
            }
        }

        // ==================== methods end ====================

        // ==================== properties start ====================
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void G_Method(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = Puerts.Utils.GetSelf((int)data, self) as System.Delegate;
                var result = obj.Method;
                Puerts.ResultHelper.Set((int)data, isolate, info, result);
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(
                    isolate,
                    "c# exception:" + e.Message + ",stack:" + e.StackTrace
                );
            }
        }

        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void G_Target(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = Puerts.Utils.GetSelf((int)data, self) as System.Delegate;
                var result = obj.Target;
                Puerts.ResultHelper.Set((int)data, isolate, info, result);
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(
                    isolate,
                    "c# exception:" + e.Message + ",stack:" + e.StackTrace
                );
            }
        }

        // ==================== properties end ====================
        // ==================== array item get/set start ====================


        // ==================== array item get/set end ====================
        // ==================== operator start ====================
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void O_op_Equality(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                {
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    JsValueType argType0 = JsValueType.Invalid;
                    IntPtr v8Value1 = PuertsDLL.GetArgumentValue(info, 1);
                    object argobj1 = null;
                    JsValueType argType1 = JsValueType.Invalid;

                    {
                        argobj0 =
                            argobj0 != null
                                ? argobj0
                                : StaticTranslate<System.Delegate>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        System.Delegate arg0 = (System.Delegate)argobj0;
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<System.Delegate>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        System.Delegate arg1 = (System.Delegate)argobj1;
                        var result = arg0 == arg1;
                        Puerts.PuertsDLL.ReturnBoolean(isolate, info, result);
                    }
                }
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(
                    isolate,
                    "c# exception:" + e.Message + ",stack:" + e.StackTrace
                );
            }
        }

        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void O_op_Inequality(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                {
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    JsValueType argType0 = JsValueType.Invalid;
                    IntPtr v8Value1 = PuertsDLL.GetArgumentValue(info, 1);
                    object argobj1 = null;
                    JsValueType argType1 = JsValueType.Invalid;

                    {
                        argobj0 =
                            argobj0 != null
                                ? argobj0
                                : StaticTranslate<System.Delegate>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        System.Delegate arg0 = (System.Delegate)argobj0;
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<System.Delegate>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        System.Delegate arg1 = (System.Delegate)argobj1;
                        var result = arg0 != arg1;
                        Puerts.PuertsDLL.ReturnBoolean(isolate, info, result);
                    }
                }
            }
            catch (Exception e)
            {
                Puerts.PuertsDLL.ThrowException(
                    isolate,
                    "c# exception:" + e.Message + ",stack:" + e.StackTrace
                );
            }
        }
        // ==================== operator end ====================
        // ==================== events start ====================
        // ==================== events end ====================
    }
#pragma warning disable 0219
}
#endif
