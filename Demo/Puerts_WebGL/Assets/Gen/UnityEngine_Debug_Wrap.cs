#if !(EXPERIMENTAL_IL2CPP_PUERTS && ENABLE_IL2CPP)
using System;
using Puerts;

namespace PuertsStaticWrap
{
#pragma warning disable 0219
    public static class UnityEngine_Debug_Wrap
    {
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8ConstructorCallback))]
        internal static IntPtr Constructor(IntPtr isolate, IntPtr info, int paramLen, long data)
        {
            try
            {
                {
                    {
                        var result = new UnityEngine.Debug();

                        return Puerts.Utils.GetObjectPtr(
                            (int)data,
                            typeof(UnityEngine.Debug),
                            result
                        );
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
            return IntPtr.Zero;
        }

        // ==================== constructor end ====================

        // ==================== methods start ====================
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void F_DrawLine(
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
                            Puerts.JsValueType.NativeObject,
                            typeof(UnityEngine.Vector3),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NativeObject,
                            typeof(UnityEngine.Vector3),
                            false,
                            false,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NativeObject,
                            typeof(UnityEngine.Color),
                            false,
                            false,
                            v8Value2,
                            ref argobj2,
                            ref argType2
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Number,
                            typeof(float),
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
                                : StaticTranslate<UnityEngine.Vector3>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        UnityEngine.Vector3 arg0 = (UnityEngine.Vector3)argobj0;
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<UnityEngine.Vector3>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        UnityEngine.Vector3 arg1 = (UnityEngine.Vector3)argobj1;
                        argobj2 =
                            argobj2 != null
                                ? argobj2
                                : StaticTranslate<UnityEngine.Color>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value2,
                                    false
                                );
                        UnityEngine.Color arg2 = (UnityEngine.Color)argobj2;
                        float arg3 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value3, false);

                        UnityEngine.Debug.DrawLine(arg0, arg1, arg2, arg3);

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
                            Puerts.JsValueType.NativeObject,
                            typeof(UnityEngine.Vector3),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NativeObject,
                            typeof(UnityEngine.Vector3),
                            false,
                            false,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NativeObject,
                            typeof(UnityEngine.Color),
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
                                : StaticTranslate<UnityEngine.Vector3>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        UnityEngine.Vector3 arg0 = (UnityEngine.Vector3)argobj0;
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<UnityEngine.Vector3>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        UnityEngine.Vector3 arg1 = (UnityEngine.Vector3)argobj1;
                        argobj2 =
                            argobj2 != null
                                ? argobj2
                                : StaticTranslate<UnityEngine.Color>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value2,
                                    false
                                );
                        UnityEngine.Color arg2 = (UnityEngine.Color)argobj2;

                        UnityEngine.Debug.DrawLine(arg0, arg1, arg2);

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
                            Puerts.JsValueType.NativeObject,
                            typeof(UnityEngine.Vector3),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NativeObject,
                            typeof(UnityEngine.Vector3),
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
                                : StaticTranslate<UnityEngine.Vector3>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        UnityEngine.Vector3 arg0 = (UnityEngine.Vector3)argobj0;
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<UnityEngine.Vector3>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        UnityEngine.Vector3 arg1 = (UnityEngine.Vector3)argobj1;

                        UnityEngine.Debug.DrawLine(arg0, arg1);

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
                            Puerts.JsValueType.NativeObject,
                            typeof(UnityEngine.Vector3),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NativeObject,
                            typeof(UnityEngine.Vector3),
                            false,
                            false,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NativeObject,
                            typeof(UnityEngine.Color),
                            false,
                            false,
                            v8Value2,
                            ref argobj2,
                            ref argType2
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Number,
                            typeof(float),
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
                                : StaticTranslate<UnityEngine.Vector3>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        UnityEngine.Vector3 arg0 = (UnityEngine.Vector3)argobj0;
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<UnityEngine.Vector3>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        UnityEngine.Vector3 arg1 = (UnityEngine.Vector3)argobj1;
                        argobj2 =
                            argobj2 != null
                                ? argobj2
                                : StaticTranslate<UnityEngine.Color>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value2,
                                    false
                                );
                        UnityEngine.Color arg2 = (UnityEngine.Color)argobj2;
                        float arg3 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value3, false);
                        bool arg4 = (bool)PuertsDLL.GetBooleanFromValue(isolate, v8Value4, false);

                        UnityEngine.Debug.DrawLine(arg0, arg1, arg2, arg3, arg4);

                        return;
                    }
                }
                Puerts.PuertsDLL.ThrowException(isolate, "invalid arguments to DrawLine");
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
        internal static void F_DrawRay(
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
                            Puerts.JsValueType.NativeObject,
                            typeof(UnityEngine.Vector3),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NativeObject,
                            typeof(UnityEngine.Vector3),
                            false,
                            false,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NativeObject,
                            typeof(UnityEngine.Color),
                            false,
                            false,
                            v8Value2,
                            ref argobj2,
                            ref argType2
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Number,
                            typeof(float),
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
                                : StaticTranslate<UnityEngine.Vector3>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        UnityEngine.Vector3 arg0 = (UnityEngine.Vector3)argobj0;
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<UnityEngine.Vector3>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        UnityEngine.Vector3 arg1 = (UnityEngine.Vector3)argobj1;
                        argobj2 =
                            argobj2 != null
                                ? argobj2
                                : StaticTranslate<UnityEngine.Color>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value2,
                                    false
                                );
                        UnityEngine.Color arg2 = (UnityEngine.Color)argobj2;
                        float arg3 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value3, false);

                        UnityEngine.Debug.DrawRay(arg0, arg1, arg2, arg3);

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
                            Puerts.JsValueType.NativeObject,
                            typeof(UnityEngine.Vector3),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NativeObject,
                            typeof(UnityEngine.Vector3),
                            false,
                            false,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NativeObject,
                            typeof(UnityEngine.Color),
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
                                : StaticTranslate<UnityEngine.Vector3>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        UnityEngine.Vector3 arg0 = (UnityEngine.Vector3)argobj0;
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<UnityEngine.Vector3>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        UnityEngine.Vector3 arg1 = (UnityEngine.Vector3)argobj1;
                        argobj2 =
                            argobj2 != null
                                ? argobj2
                                : StaticTranslate<UnityEngine.Color>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value2,
                                    false
                                );
                        UnityEngine.Color arg2 = (UnityEngine.Color)argobj2;

                        UnityEngine.Debug.DrawRay(arg0, arg1, arg2);

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
                            Puerts.JsValueType.NativeObject,
                            typeof(UnityEngine.Vector3),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NativeObject,
                            typeof(UnityEngine.Vector3),
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
                                : StaticTranslate<UnityEngine.Vector3>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        UnityEngine.Vector3 arg0 = (UnityEngine.Vector3)argobj0;
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<UnityEngine.Vector3>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        UnityEngine.Vector3 arg1 = (UnityEngine.Vector3)argobj1;

                        UnityEngine.Debug.DrawRay(arg0, arg1);

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
                            Puerts.JsValueType.NativeObject,
                            typeof(UnityEngine.Vector3),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NativeObject,
                            typeof(UnityEngine.Vector3),
                            false,
                            false,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NativeObject,
                            typeof(UnityEngine.Color),
                            false,
                            false,
                            v8Value2,
                            ref argobj2,
                            ref argType2
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Number,
                            typeof(float),
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
                                : StaticTranslate<UnityEngine.Vector3>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        UnityEngine.Vector3 arg0 = (UnityEngine.Vector3)argobj0;
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<UnityEngine.Vector3>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        UnityEngine.Vector3 arg1 = (UnityEngine.Vector3)argobj1;
                        argobj2 =
                            argobj2 != null
                                ? argobj2
                                : StaticTranslate<UnityEngine.Color>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value2,
                                    false
                                );
                        UnityEngine.Color arg2 = (UnityEngine.Color)argobj2;
                        float arg3 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value3, false);
                        bool arg4 = (bool)PuertsDLL.GetBooleanFromValue(isolate, v8Value4, false);

                        UnityEngine.Debug.DrawRay(arg0, arg1, arg2, arg3, arg4);

                        return;
                    }
                }
                Puerts.PuertsDLL.ThrowException(isolate, "invalid arguments to DrawRay");
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
        internal static void F_Break(
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
                    {
                        UnityEngine.Debug.Break();
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
        internal static void F_DebugBreak(
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
                    {
                        UnityEngine.Debug.DebugBreak();
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
        internal static void F_Log(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                if (paramLen == 1)
                {
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    JsValueType argType0 = JsValueType.Invalid;
                    if (
                        ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Any,
                            typeof(System.Object),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                    )
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

                        UnityEngine.Debug.Log(arg0);

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
                            Puerts.JsValueType.Any,
                            typeof(System.Object),
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
                            typeof(UnityEngine.Object),
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
                                : StaticTranslate<System.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        System.Object arg0 = (System.Object)argobj0;
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<UnityEngine.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        UnityEngine.Object arg1 = (UnityEngine.Object)argobj1;

                        UnityEngine.Debug.Log(arg0, arg1);

                        return;
                    }
                }
                Puerts.PuertsDLL.ThrowException(isolate, "invalid arguments to Log");
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
        internal static void F_LogFormat(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                if (paramLen >= 1)
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
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.String,
                            typeof(string),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatchParams(
                            (int)data,
                            isolate,
                            info,
                            Puerts.JsValueType.Any,
                            typeof(System.Object),
                            1,
                            paramLen,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                    )
                    {
                        string arg0 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value0, false);
                        System.Object[] arg1 = ArgHelper.GetParams<System.Object>(
                            (int)data,
                            isolate,
                            info,
                            1,
                            paramLen,
                            v8Value1
                        );

                        UnityEngine.Debug.LogFormat(arg0, arg1);

                        return;
                    }
                }
                if (paramLen == 1)
                {
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    JsValueType argType0 = JsValueType.Invalid;
                    if (
                        ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.String,
                            typeof(string),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                    )
                    {
                        string arg0 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value0, false);

                        UnityEngine.Debug.LogFormat(arg0, default(System.Object));

                        return;
                    }
                }
                if (paramLen >= 2)
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
                            typeof(UnityEngine.Object),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.String,
                            typeof(string),
                            false,
                            false,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                        && ArgHelper.IsMatchParams(
                            (int)data,
                            isolate,
                            info,
                            Puerts.JsValueType.Any,
                            typeof(System.Object),
                            2,
                            paramLen,
                            v8Value2,
                            ref argobj2,
                            ref argType2
                        )
                    )
                    {
                        argobj0 =
                            argobj0 != null
                                ? argobj0
                                : StaticTranslate<UnityEngine.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        UnityEngine.Object arg0 = (UnityEngine.Object)argobj0;
                        string arg1 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value1, false);
                        System.Object[] arg2 = ArgHelper.GetParams<System.Object>(
                            (int)data,
                            isolate,
                            info,
                            2,
                            paramLen,
                            v8Value2
                        );

                        UnityEngine.Debug.LogFormat(arg0, arg1, arg2);

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
                            typeof(UnityEngine.Object),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.String,
                            typeof(string),
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
                                : StaticTranslate<UnityEngine.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        UnityEngine.Object arg0 = (UnityEngine.Object)argobj0;
                        string arg1 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value1, false);

                        UnityEngine.Debug.LogFormat(arg0, arg1, default(System.Object));

                        return;
                    }
                }
                if (paramLen >= 4)
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
                            Puerts.JsValueType.Number,
                            typeof(UnityEngine.LogType),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Number,
                            typeof(UnityEngine.LogOption),
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
                            typeof(UnityEngine.Object),
                            false,
                            false,
                            v8Value2,
                            ref argobj2,
                            ref argType2
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.String,
                            typeof(string),
                            false,
                            false,
                            v8Value3,
                            ref argobj3,
                            ref argType3
                        )
                        && ArgHelper.IsMatchParams(
                            (int)data,
                            isolate,
                            info,
                            Puerts.JsValueType.Any,
                            typeof(System.Object),
                            4,
                            paramLen,
                            v8Value4,
                            ref argobj4,
                            ref argType4
                        )
                    )
                    {
                        UnityEngine.LogType arg0 = (UnityEngine.LogType)
                            StaticTranslate<int>.Get(
                                (int)data,
                                isolate,
                                Puerts.NativeValueApi.GetValueFromArgument,
                                v8Value0,
                                false
                            );
                        UnityEngine.LogOption arg1 = (UnityEngine.LogOption)
                            StaticTranslate<int>.Get(
                                (int)data,
                                isolate,
                                Puerts.NativeValueApi.GetValueFromArgument,
                                v8Value1,
                                false
                            );
                        argobj2 =
                            argobj2 != null
                                ? argobj2
                                : StaticTranslate<UnityEngine.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value2,
                                    false
                                );
                        UnityEngine.Object arg2 = (UnityEngine.Object)argobj2;
                        string arg3 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value3, false);
                        System.Object[] arg4 = ArgHelper.GetParams<System.Object>(
                            (int)data,
                            isolate,
                            info,
                            4,
                            paramLen,
                            v8Value4
                        );

                        UnityEngine.Debug.LogFormat(arg0, arg1, arg2, arg3, arg4);

                        return;
                    }
                }
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
                            Puerts.JsValueType.Number,
                            typeof(UnityEngine.LogType),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Number,
                            typeof(UnityEngine.LogOption),
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
                            typeof(UnityEngine.Object),
                            false,
                            false,
                            v8Value2,
                            ref argobj2,
                            ref argType2
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.String,
                            typeof(string),
                            false,
                            false,
                            v8Value3,
                            ref argobj3,
                            ref argType3
                        )
                    )
                    {
                        UnityEngine.LogType arg0 = (UnityEngine.LogType)
                            StaticTranslate<int>.Get(
                                (int)data,
                                isolate,
                                Puerts.NativeValueApi.GetValueFromArgument,
                                v8Value0,
                                false
                            );
                        UnityEngine.LogOption arg1 = (UnityEngine.LogOption)
                            StaticTranslate<int>.Get(
                                (int)data,
                                isolate,
                                Puerts.NativeValueApi.GetValueFromArgument,
                                v8Value1,
                                false
                            );
                        argobj2 =
                            argobj2 != null
                                ? argobj2
                                : StaticTranslate<UnityEngine.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value2,
                                    false
                                );
                        UnityEngine.Object arg2 = (UnityEngine.Object)argobj2;
                        string arg3 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value3, false);

                        UnityEngine.Debug.LogFormat(arg0, arg1, arg2, arg3, default(System.Object));

                        return;
                    }
                }
                Puerts.PuertsDLL.ThrowException(isolate, "invalid arguments to LogFormat");
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
        internal static void F_LogError(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                if (paramLen == 1)
                {
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    JsValueType argType0 = JsValueType.Invalid;
                    if (
                        ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Any,
                            typeof(System.Object),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                    )
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

                        UnityEngine.Debug.LogError(arg0);

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
                            Puerts.JsValueType.Any,
                            typeof(System.Object),
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
                            typeof(UnityEngine.Object),
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
                                : StaticTranslate<System.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        System.Object arg0 = (System.Object)argobj0;
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<UnityEngine.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        UnityEngine.Object arg1 = (UnityEngine.Object)argobj1;

                        UnityEngine.Debug.LogError(arg0, arg1);

                        return;
                    }
                }
                Puerts.PuertsDLL.ThrowException(isolate, "invalid arguments to LogError");
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
        internal static void F_LogErrorFormat(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                if (paramLen >= 1)
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
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.String,
                            typeof(string),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatchParams(
                            (int)data,
                            isolate,
                            info,
                            Puerts.JsValueType.Any,
                            typeof(System.Object),
                            1,
                            paramLen,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                    )
                    {
                        string arg0 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value0, false);
                        System.Object[] arg1 = ArgHelper.GetParams<System.Object>(
                            (int)data,
                            isolate,
                            info,
                            1,
                            paramLen,
                            v8Value1
                        );

                        UnityEngine.Debug.LogErrorFormat(arg0, arg1);

                        return;
                    }
                }
                if (paramLen == 1)
                {
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    JsValueType argType0 = JsValueType.Invalid;
                    if (
                        ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.String,
                            typeof(string),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                    )
                    {
                        string arg0 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value0, false);

                        UnityEngine.Debug.LogErrorFormat(arg0, default(System.Object));

                        return;
                    }
                }
                if (paramLen >= 2)
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
                            typeof(UnityEngine.Object),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.String,
                            typeof(string),
                            false,
                            false,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                        && ArgHelper.IsMatchParams(
                            (int)data,
                            isolate,
                            info,
                            Puerts.JsValueType.Any,
                            typeof(System.Object),
                            2,
                            paramLen,
                            v8Value2,
                            ref argobj2,
                            ref argType2
                        )
                    )
                    {
                        argobj0 =
                            argobj0 != null
                                ? argobj0
                                : StaticTranslate<UnityEngine.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        UnityEngine.Object arg0 = (UnityEngine.Object)argobj0;
                        string arg1 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value1, false);
                        System.Object[] arg2 = ArgHelper.GetParams<System.Object>(
                            (int)data,
                            isolate,
                            info,
                            2,
                            paramLen,
                            v8Value2
                        );

                        UnityEngine.Debug.LogErrorFormat(arg0, arg1, arg2);

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
                            typeof(UnityEngine.Object),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.String,
                            typeof(string),
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
                                : StaticTranslate<UnityEngine.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        UnityEngine.Object arg0 = (UnityEngine.Object)argobj0;
                        string arg1 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value1, false);

                        UnityEngine.Debug.LogErrorFormat(arg0, arg1, default(System.Object));

                        return;
                    }
                }
                Puerts.PuertsDLL.ThrowException(isolate, "invalid arguments to LogErrorFormat");
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
        internal static void F_ClearDeveloperConsole(
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
                    {
                        UnityEngine.Debug.ClearDeveloperConsole();
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
        internal static void F_LogException(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                if (paramLen == 1)
                {
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    JsValueType argType0 = JsValueType.Invalid;
                    if (
                        ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.NativeObject,
                            typeof(System.Exception),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                    )
                    {
                        argobj0 =
                            argobj0 != null
                                ? argobj0
                                : StaticTranslate<System.Exception>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        System.Exception arg0 = (System.Exception)argobj0;

                        UnityEngine.Debug.LogException(arg0);

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
                            typeof(System.Exception),
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
                            typeof(UnityEngine.Object),
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
                                : StaticTranslate<System.Exception>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        System.Exception arg0 = (System.Exception)argobj0;
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<UnityEngine.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        UnityEngine.Object arg1 = (UnityEngine.Object)argobj1;

                        UnityEngine.Debug.LogException(arg0, arg1);

                        return;
                    }
                }
                Puerts.PuertsDLL.ThrowException(isolate, "invalid arguments to LogException");
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
        internal static void F_LogWarning(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                if (paramLen == 1)
                {
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    JsValueType argType0 = JsValueType.Invalid;
                    if (
                        ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Any,
                            typeof(System.Object),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                    )
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

                        UnityEngine.Debug.LogWarning(arg0);

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
                            Puerts.JsValueType.Any,
                            typeof(System.Object),
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
                            typeof(UnityEngine.Object),
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
                                : StaticTranslate<System.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        System.Object arg0 = (System.Object)argobj0;
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<UnityEngine.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        UnityEngine.Object arg1 = (UnityEngine.Object)argobj1;

                        UnityEngine.Debug.LogWarning(arg0, arg1);

                        return;
                    }
                }
                Puerts.PuertsDLL.ThrowException(isolate, "invalid arguments to LogWarning");
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
        internal static void F_LogWarningFormat(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                if (paramLen >= 1)
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
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.String,
                            typeof(string),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatchParams(
                            (int)data,
                            isolate,
                            info,
                            Puerts.JsValueType.Any,
                            typeof(System.Object),
                            1,
                            paramLen,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                    )
                    {
                        string arg0 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value0, false);
                        System.Object[] arg1 = ArgHelper.GetParams<System.Object>(
                            (int)data,
                            isolate,
                            info,
                            1,
                            paramLen,
                            v8Value1
                        );

                        UnityEngine.Debug.LogWarningFormat(arg0, arg1);

                        return;
                    }
                }
                if (paramLen == 1)
                {
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    JsValueType argType0 = JsValueType.Invalid;
                    if (
                        ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.String,
                            typeof(string),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                    )
                    {
                        string arg0 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value0, false);

                        UnityEngine.Debug.LogWarningFormat(arg0, default(System.Object));

                        return;
                    }
                }
                if (paramLen >= 2)
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
                            typeof(UnityEngine.Object),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.String,
                            typeof(string),
                            false,
                            false,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                        && ArgHelper.IsMatchParams(
                            (int)data,
                            isolate,
                            info,
                            Puerts.JsValueType.Any,
                            typeof(System.Object),
                            2,
                            paramLen,
                            v8Value2,
                            ref argobj2,
                            ref argType2
                        )
                    )
                    {
                        argobj0 =
                            argobj0 != null
                                ? argobj0
                                : StaticTranslate<UnityEngine.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        UnityEngine.Object arg0 = (UnityEngine.Object)argobj0;
                        string arg1 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value1, false);
                        System.Object[] arg2 = ArgHelper.GetParams<System.Object>(
                            (int)data,
                            isolate,
                            info,
                            2,
                            paramLen,
                            v8Value2
                        );

                        UnityEngine.Debug.LogWarningFormat(arg0, arg1, arg2);

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
                            typeof(UnityEngine.Object),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.String,
                            typeof(string),
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
                                : StaticTranslate<UnityEngine.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        UnityEngine.Object arg0 = (UnityEngine.Object)argobj0;
                        string arg1 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value1, false);

                        UnityEngine.Debug.LogWarningFormat(arg0, arg1, default(System.Object));

                        return;
                    }
                }
                Puerts.PuertsDLL.ThrowException(isolate, "invalid arguments to LogWarningFormat");
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
        internal static void F_Assert(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                if (paramLen == 1)
                {
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    JsValueType argType0 = JsValueType.Invalid;
                    if (
                        ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Boolean,
                            typeof(bool),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                    )
                    {
                        bool arg0 = (bool)PuertsDLL.GetBooleanFromValue(isolate, v8Value0, false);

                        UnityEngine.Debug.Assert(arg0);

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
                            Puerts.JsValueType.Boolean,
                            typeof(bool),
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
                            typeof(UnityEngine.Object),
                            false,
                            false,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                    )
                    {
                        bool arg0 = (bool)PuertsDLL.GetBooleanFromValue(isolate, v8Value0, false);
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<UnityEngine.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        UnityEngine.Object arg1 = (UnityEngine.Object)argobj1;

                        UnityEngine.Debug.Assert(arg0, arg1);

                        return;
                    }
                    if (
                        ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Boolean,
                            typeof(bool),
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
                    )
                    {
                        bool arg0 = (bool)PuertsDLL.GetBooleanFromValue(isolate, v8Value0, false);
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

                        UnityEngine.Debug.Assert(arg0, arg1);

                        return;
                    }
                    if (
                        ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Boolean,
                            typeof(bool),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.String,
                            typeof(string),
                            false,
                            false,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                    )
                    {
                        bool arg0 = (bool)PuertsDLL.GetBooleanFromValue(isolate, v8Value0, false);
                        string arg1 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value1, false);

                        UnityEngine.Debug.Assert(arg0, arg1);

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
                            Puerts.JsValueType.Boolean,
                            typeof(bool),
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
                            typeof(UnityEngine.Object),
                            false,
                            false,
                            v8Value2,
                            ref argobj2,
                            ref argType2
                        )
                    )
                    {
                        bool arg0 = (bool)PuertsDLL.GetBooleanFromValue(isolate, v8Value0, false);
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
                                : StaticTranslate<UnityEngine.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value2,
                                    false
                                );
                        UnityEngine.Object arg2 = (UnityEngine.Object)argobj2;

                        UnityEngine.Debug.Assert(arg0, arg1, arg2);

                        return;
                    }
                    if (
                        ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Boolean,
                            typeof(bool),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.String,
                            typeof(string),
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
                            typeof(UnityEngine.Object),
                            false,
                            false,
                            v8Value2,
                            ref argobj2,
                            ref argType2
                        )
                    )
                    {
                        bool arg0 = (bool)PuertsDLL.GetBooleanFromValue(isolate, v8Value0, false);
                        string arg1 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value1, false);
                        argobj2 =
                            argobj2 != null
                                ? argobj2
                                : StaticTranslate<UnityEngine.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value2,
                                    false
                                );
                        UnityEngine.Object arg2 = (UnityEngine.Object)argobj2;

                        UnityEngine.Debug.Assert(arg0, arg1, arg2);

                        return;
                    }
                }
                Puerts.PuertsDLL.ThrowException(isolate, "invalid arguments to Assert");
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
        internal static void F_AssertFormat(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                if (paramLen >= 2)
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
                            Puerts.JsValueType.Boolean,
                            typeof(bool),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.String,
                            typeof(string),
                            false,
                            false,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                        && ArgHelper.IsMatchParams(
                            (int)data,
                            isolate,
                            info,
                            Puerts.JsValueType.Any,
                            typeof(System.Object),
                            2,
                            paramLen,
                            v8Value2,
                            ref argobj2,
                            ref argType2
                        )
                    )
                    {
                        bool arg0 = (bool)PuertsDLL.GetBooleanFromValue(isolate, v8Value0, false);
                        string arg1 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value1, false);
                        System.Object[] arg2 = ArgHelper.GetParams<System.Object>(
                            (int)data,
                            isolate,
                            info,
                            2,
                            paramLen,
                            v8Value2
                        );

                        UnityEngine.Debug.AssertFormat(arg0, arg1, arg2);

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
                            Puerts.JsValueType.Boolean,
                            typeof(bool),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.String,
                            typeof(string),
                            false,
                            false,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                    )
                    {
                        bool arg0 = (bool)PuertsDLL.GetBooleanFromValue(isolate, v8Value0, false);
                        string arg1 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value1, false);

                        UnityEngine.Debug.AssertFormat(arg0, arg1, default(System.Object));

                        return;
                    }
                }
                if (paramLen >= 3)
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
                            Puerts.JsValueType.Boolean,
                            typeof(bool),
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
                            typeof(UnityEngine.Object),
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
                        && ArgHelper.IsMatchParams(
                            (int)data,
                            isolate,
                            info,
                            Puerts.JsValueType.Any,
                            typeof(System.Object),
                            3,
                            paramLen,
                            v8Value3,
                            ref argobj3,
                            ref argType3
                        )
                    )
                    {
                        bool arg0 = (bool)PuertsDLL.GetBooleanFromValue(isolate, v8Value0, false);
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<UnityEngine.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        UnityEngine.Object arg1 = (UnityEngine.Object)argobj1;
                        string arg2 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value2, false);
                        System.Object[] arg3 = ArgHelper.GetParams<System.Object>(
                            (int)data,
                            isolate,
                            info,
                            3,
                            paramLen,
                            v8Value3
                        );

                        UnityEngine.Debug.AssertFormat(arg0, arg1, arg2, arg3);

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
                            Puerts.JsValueType.Boolean,
                            typeof(bool),
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
                            typeof(UnityEngine.Object),
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
                        bool arg0 = (bool)PuertsDLL.GetBooleanFromValue(isolate, v8Value0, false);
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<UnityEngine.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        UnityEngine.Object arg1 = (UnityEngine.Object)argobj1;
                        string arg2 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value2, false);

                        UnityEngine.Debug.AssertFormat(arg0, arg1, arg2, default(System.Object));

                        return;
                    }
                }
                Puerts.PuertsDLL.ThrowException(isolate, "invalid arguments to AssertFormat");
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
        internal static void F_LogAssertion(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                if (paramLen == 1)
                {
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    JsValueType argType0 = JsValueType.Invalid;
                    if (
                        ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Any,
                            typeof(System.Object),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                    )
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

                        UnityEngine.Debug.LogAssertion(arg0);

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
                            Puerts.JsValueType.Any,
                            typeof(System.Object),
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
                            typeof(UnityEngine.Object),
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
                                : StaticTranslate<System.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        System.Object arg0 = (System.Object)argobj0;
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<UnityEngine.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        UnityEngine.Object arg1 = (UnityEngine.Object)argobj1;

                        UnityEngine.Debug.LogAssertion(arg0, arg1);

                        return;
                    }
                }
                Puerts.PuertsDLL.ThrowException(isolate, "invalid arguments to LogAssertion");
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
        internal static void F_LogAssertionFormat(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                if (paramLen >= 1)
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
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.String,
                            typeof(string),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatchParams(
                            (int)data,
                            isolate,
                            info,
                            Puerts.JsValueType.Any,
                            typeof(System.Object),
                            1,
                            paramLen,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                    )
                    {
                        string arg0 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value0, false);
                        System.Object[] arg1 = ArgHelper.GetParams<System.Object>(
                            (int)data,
                            isolate,
                            info,
                            1,
                            paramLen,
                            v8Value1
                        );

                        UnityEngine.Debug.LogAssertionFormat(arg0, arg1);

                        return;
                    }
                }
                if (paramLen == 1)
                {
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    JsValueType argType0 = JsValueType.Invalid;
                    if (
                        ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.String,
                            typeof(string),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                    )
                    {
                        string arg0 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value0, false);

                        UnityEngine.Debug.LogAssertionFormat(arg0, default(System.Object));

                        return;
                    }
                }
                if (paramLen >= 2)
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
                            typeof(UnityEngine.Object),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.String,
                            typeof(string),
                            false,
                            false,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                        && ArgHelper.IsMatchParams(
                            (int)data,
                            isolate,
                            info,
                            Puerts.JsValueType.Any,
                            typeof(System.Object),
                            2,
                            paramLen,
                            v8Value2,
                            ref argobj2,
                            ref argType2
                        )
                    )
                    {
                        argobj0 =
                            argobj0 != null
                                ? argobj0
                                : StaticTranslate<UnityEngine.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        UnityEngine.Object arg0 = (UnityEngine.Object)argobj0;
                        string arg1 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value1, false);
                        System.Object[] arg2 = ArgHelper.GetParams<System.Object>(
                            (int)data,
                            isolate,
                            info,
                            2,
                            paramLen,
                            v8Value2
                        );

                        UnityEngine.Debug.LogAssertionFormat(arg0, arg1, arg2);

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
                            typeof(UnityEngine.Object),
                            false,
                            false,
                            v8Value0,
                            ref argobj0,
                            ref argType0
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.String,
                            typeof(string),
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
                                : StaticTranslate<UnityEngine.Object>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        UnityEngine.Object arg0 = (UnityEngine.Object)argobj0;
                        string arg1 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value1, false);

                        UnityEngine.Debug.LogAssertionFormat(arg0, arg1, default(System.Object));

                        return;
                    }
                }
                Puerts.PuertsDLL.ThrowException(isolate, "invalid arguments to LogAssertionFormat");
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
        internal static void G_unityLogger(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var result = UnityEngine.Debug.unityLogger;
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
        internal static void G_developerConsoleVisible(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var result = UnityEngine.Debug.developerConsoleVisible;
                Puerts.PuertsDLL.ReturnBoolean(isolate, info, result);
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
        internal static void S_developerConsoleVisible(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                object argobj0 = null;
                bool arg0 = (bool)PuertsDLL.GetBooleanFromValue(isolate, v8Value0, false);
                UnityEngine.Debug.developerConsoleVisible = arg0;
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
        internal static void G_isDebugBuild(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var result = UnityEngine.Debug.isDebugBuild;
                Puerts.PuertsDLL.ReturnBoolean(isolate, info, result);
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
        // ==================== operator end ====================
        // ==================== events start ====================
        // ==================== events end ====================
    }
#pragma warning disable 0219
}
#endif
