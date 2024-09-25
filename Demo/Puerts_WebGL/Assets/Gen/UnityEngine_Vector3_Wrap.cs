#if !(EXPERIMENTAL_IL2CPP_PUERTS && ENABLE_IL2CPP)
using System;
using Puerts;

namespace PuertsStaticWrap
{
#pragma warning disable 0219
    public static class UnityEngine_Vector3_Wrap
    {
        static UnityEngine.Vector3 HeapValue;

        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8ConstructorCallback))]
        internal static unsafe IntPtr Constructor(
            IntPtr isolate,
            IntPtr info,
            int paramLen,
            long data
        )
        {
            try
            {
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
                            Puerts.JsValueType.Number,
                            typeof(float),
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
                            typeof(float),
                            false,
                            false,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Number,
                            typeof(float),
                            false,
                            false,
                            v8Value2,
                            ref argobj2,
                            ref argType2
                        )
                    )
                    {
                        float arg0 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value0, false);
                        float arg1 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value1, false);
                        float arg2 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value2, false);
                        HeapValue = new UnityEngine.Vector3(arg0, arg1, arg2);

                        fixed (UnityEngine.Vector3* result = &HeapValue)
                        {
                            return new IntPtr(result);
                        }
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
                            Puerts.JsValueType.Number,
                            typeof(float),
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
                            typeof(float),
                            false,
                            false,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                    )
                    {
                        float arg0 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value0, false);
                        float arg1 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value1, false);
                        HeapValue = new UnityEngine.Vector3(arg0, arg1);

                        fixed (UnityEngine.Vector3* result = &HeapValue)
                        {
                            return new IntPtr(result);
                        }
                    }
                }
                if (paramLen == 0)
                {
                    {
                        HeapValue = new UnityEngine.Vector3();

                        fixed (UnityEngine.Vector3* result = &HeapValue)
                        {
                            return new IntPtr(result);
                        }
                    }
                }

                Puerts.PuertsDLL.ThrowException(
                    isolate,
                    "invalid arguments to "
                        + typeof(UnityEngine.Vector3).GetFriendlyName()
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
        internal static void F_Lerp(
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
                    IntPtr v8Value2 = PuertsDLL.GetArgumentValue(info, 2);
                    object argobj2 = null;
                    ;
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
                        float arg2 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value2, false);

                        var result = UnityEngine.Vector3.Lerp(arg0, arg1, arg2);

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
        internal static void F_LerpUnclamped(
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
                    IntPtr v8Value2 = PuertsDLL.GetArgumentValue(info, 2);
                    object argobj2 = null;
                    ;
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
                        float arg2 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value2, false);

                        var result = UnityEngine.Vector3.LerpUnclamped(arg0, arg1, arg2);

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
        internal static void F_MoveTowards(
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
                    IntPtr v8Value2 = PuertsDLL.GetArgumentValue(info, 2);
                    object argobj2 = null;
                    ;
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
                        float arg2 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value2, false);

                        var result = UnityEngine.Vector3.MoveTowards(arg0, arg1, arg2);

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
        internal static void F_SmoothDamp(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
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
                            typeof(UnityEngine.Vector3),
                            true,
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
                            Puerts.JsValueType.Number,
                            typeof(float),
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
                                : StaticTranslate<UnityEngine.Vector3>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value2,
                                    true
                                );
                        UnityEngine.Vector3 arg2 = (UnityEngine.Vector3)argobj2;
                        float arg3 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value3, false);
                        float arg4 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value4, false);

                        var result = UnityEngine.Vector3.SmoothDamp(
                            arg0,
                            arg1,
                            ref arg2,
                            arg3,
                            arg4
                        );

                        StaticTranslate<UnityEngine.Vector3>.Set(
                            (int)data,
                            isolate,
                            Puerts.NativeValueApi.SetValueToByRefArgument,
                            v8Value2,
                            arg2
                        );
                        Puerts.ResultHelper.Set((int)data, isolate, info, result);
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
                            typeof(UnityEngine.Vector3),
                            true,
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
                                : StaticTranslate<UnityEngine.Vector3>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value2,
                                    true
                                );
                        UnityEngine.Vector3 arg2 = (UnityEngine.Vector3)argobj2;
                        float arg3 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value3, false);

                        var result = UnityEngine.Vector3.SmoothDamp(arg0, arg1, ref arg2, arg3);

                        StaticTranslate<UnityEngine.Vector3>.Set(
                            (int)data,
                            isolate,
                            Puerts.NativeValueApi.SetValueToByRefArgument,
                            v8Value2,
                            arg2
                        );
                        Puerts.ResultHelper.Set((int)data, isolate, info, result);
                        return;
                    }
                }
                if (paramLen == 6)
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
                    IntPtr v8Value5 = PuertsDLL.GetArgumentValue(info, 5);
                    object argobj5 = null;
                    JsValueType argType5 = JsValueType.Invalid;
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
                            typeof(UnityEngine.Vector3),
                            true,
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
                            Puerts.JsValueType.Number,
                            typeof(float),
                            false,
                            false,
                            v8Value4,
                            ref argobj4,
                            ref argType4
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Number,
                            typeof(float),
                            false,
                            false,
                            v8Value5,
                            ref argobj5,
                            ref argType5
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
                                : StaticTranslate<UnityEngine.Vector3>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value2,
                                    true
                                );
                        UnityEngine.Vector3 arg2 = (UnityEngine.Vector3)argobj2;
                        float arg3 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value3, false);
                        float arg4 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value4, false);
                        float arg5 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value5, false);

                        var result = UnityEngine.Vector3.SmoothDamp(
                            arg0,
                            arg1,
                            ref arg2,
                            arg3,
                            arg4,
                            arg5
                        );

                        StaticTranslate<UnityEngine.Vector3>.Set(
                            (int)data,
                            isolate,
                            Puerts.NativeValueApi.SetValueToByRefArgument,
                            v8Value2,
                            arg2
                        );
                        Puerts.ResultHelper.Set((int)data, isolate, info, result);
                        return;
                    }
                }
                Puerts.PuertsDLL.ThrowException(isolate, "invalid arguments to SmoothDamp");
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
        internal static unsafe void M_Set(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = (UnityEngine.Vector3*)self;

                {
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    ;
                    IntPtr v8Value1 = PuertsDLL.GetArgumentValue(info, 1);
                    object argobj1 = null;
                    ;
                    IntPtr v8Value2 = PuertsDLL.GetArgumentValue(info, 2);
                    object argobj2 = null;
                    ;
                    {
                        float arg0 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value0, false);
                        float arg1 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value1, false);
                        float arg2 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value2, false);

                        (*obj).Set(arg0, arg1, arg2);
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
        internal static void F_Scale(
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

                        var result = UnityEngine.Vector3.Scale(arg0, arg1);

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
        internal static unsafe void M_Scale(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = (UnityEngine.Vector3*)self;

                {
                    IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                    object argobj0 = null;
                    ;
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

                        (*obj).Scale(arg0);
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
        internal static void F_Cross(
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

                        var result = UnityEngine.Vector3.Cross(arg0, arg1);

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
        internal static unsafe void M_GetHashCode(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = (UnityEngine.Vector3*)self;

                if (paramLen == 0)
                {
                    {
                        var result = (*obj).GetHashCode();

                        Puerts.PuertsDLL.ReturnNumber(isolate, info, result);
                        return;
                    }
                }
                Puerts.PuertsDLL.ThrowException(isolate, "invalid arguments to GetHashCode");
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
        internal static unsafe void M_Equals(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = (UnityEngine.Vector3*)self;

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

                        var result = (*obj).Equals(arg0);

                        Puerts.PuertsDLL.ReturnBoolean(isolate, info, result);
                        return;
                    }
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

                        var result = (*obj).Equals(arg0);

                        Puerts.PuertsDLL.ReturnBoolean(isolate, info, result);
                        return;
                    }
                }
                Puerts.PuertsDLL.ThrowException(isolate, "invalid arguments to Equals");
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
        internal static void F_Reflect(
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

                        var result = UnityEngine.Vector3.Reflect(arg0, arg1);

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
        internal static void F_Normalize(
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

                        var result = UnityEngine.Vector3.Normalize(arg0);

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
        internal static unsafe void M_Normalize(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = (UnityEngine.Vector3*)self;

                {
                    {
                        (*obj).Normalize();
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
        internal static void F_Dot(
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

                        var result = UnityEngine.Vector3.Dot(arg0, arg1);

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
        internal static void F_Project(
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

                        var result = UnityEngine.Vector3.Project(arg0, arg1);

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
        internal static void F_ProjectOnPlane(
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

                        var result = UnityEngine.Vector3.ProjectOnPlane(arg0, arg1);

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
        internal static void F_Angle(
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

                        var result = UnityEngine.Vector3.Angle(arg0, arg1);

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
        internal static void F_SignedAngle(
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
                    IntPtr v8Value2 = PuertsDLL.GetArgumentValue(info, 2);
                    object argobj2 = null;
                    ;
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
                                : StaticTranslate<UnityEngine.Vector3>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value2,
                                    false
                                );
                        UnityEngine.Vector3 arg2 = (UnityEngine.Vector3)argobj2;

                        var result = UnityEngine.Vector3.SignedAngle(arg0, arg1, arg2);

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
        internal static void F_Distance(
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

                        var result = UnityEngine.Vector3.Distance(arg0, arg1);

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
        internal static void F_ClampMagnitude(
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
                                : StaticTranslate<UnityEngine.Vector3>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        UnityEngine.Vector3 arg0 = (UnityEngine.Vector3)argobj0;
                        float arg1 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value1, false);

                        var result = UnityEngine.Vector3.ClampMagnitude(arg0, arg1);

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
        internal static void F_Magnitude(
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

                        var result = UnityEngine.Vector3.Magnitude(arg0);

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
        internal static void F_SqrMagnitude(
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

                        var result = UnityEngine.Vector3.SqrMagnitude(arg0);

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
        internal static void F_Min(
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

                        var result = UnityEngine.Vector3.Min(arg0, arg1);

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
        internal static void F_Max(
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

                        var result = UnityEngine.Vector3.Max(arg0, arg1);

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
        internal static unsafe void M_ToString(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = (UnityEngine.Vector3*)self;

                if (paramLen == 0)
                {
                    {
                        var result = (*obj).ToString();

                        Puerts.PuertsDLL.ReturnString(isolate, info, result);
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

                        var result = (*obj).ToString(arg0);

                        Puerts.PuertsDLL.ReturnString(isolate, info, result);
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
                            Puerts.JsValueType.NullOrUndefined | Puerts.JsValueType.String,
                            typeof(string),
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
                            typeof(System.IFormatProvider),
                            false,
                            false,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                    )
                    {
                        string arg0 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value0, false);
                        argobj1 =
                            argobj1 != null
                                ? argobj1
                                : StaticTranslate<System.IFormatProvider>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        System.IFormatProvider arg1 = (System.IFormatProvider)argobj1;

                        var result = (*obj).ToString(arg0, arg1);

                        Puerts.PuertsDLL.ReturnString(isolate, info, result);
                        return;
                    }
                }
                Puerts.PuertsDLL.ThrowException(isolate, "invalid arguments to ToString");
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
        internal static void F_Slerp(
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
                    IntPtr v8Value2 = PuertsDLL.GetArgumentValue(info, 2);
                    object argobj2 = null;
                    ;
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
                        float arg2 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value2, false);

                        var result = UnityEngine.Vector3.Slerp(arg0, arg1, arg2);

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
        internal static void F_SlerpUnclamped(
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
                    IntPtr v8Value2 = PuertsDLL.GetArgumentValue(info, 2);
                    object argobj2 = null;
                    ;
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
                        float arg2 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value2, false);

                        var result = UnityEngine.Vector3.SlerpUnclamped(arg0, arg1, arg2);

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
        internal static void F_OrthoNormalize(
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
                            Puerts.JsValueType.NativeObject,
                            typeof(UnityEngine.Vector3),
                            true,
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
                            true,
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
                                    true
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
                                    true
                                );
                        UnityEngine.Vector3 arg1 = (UnityEngine.Vector3)argobj1;

                        UnityEngine.Vector3.OrthoNormalize(ref arg0, ref arg1);

                        StaticTranslate<UnityEngine.Vector3>.Set(
                            (int)data,
                            isolate,
                            Puerts.NativeValueApi.SetValueToByRefArgument,
                            v8Value0,
                            arg0
                        );
                        StaticTranslate<UnityEngine.Vector3>.Set(
                            (int)data,
                            isolate,
                            Puerts.NativeValueApi.SetValueToByRefArgument,
                            v8Value1,
                            arg1
                        );
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
                            true,
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
                            true,
                            false,
                            v8Value1,
                            ref argobj1,
                            ref argType1
                        )
                        && ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.NativeObject,
                            typeof(UnityEngine.Vector3),
                            true,
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
                                    true
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
                                    true
                                );
                        UnityEngine.Vector3 arg1 = (UnityEngine.Vector3)argobj1;
                        argobj2 =
                            argobj2 != null
                                ? argobj2
                                : StaticTranslate<UnityEngine.Vector3>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value2,
                                    true
                                );
                        UnityEngine.Vector3 arg2 = (UnityEngine.Vector3)argobj2;

                        UnityEngine.Vector3.OrthoNormalize(ref arg0, ref arg1, ref arg2);

                        StaticTranslate<UnityEngine.Vector3>.Set(
                            (int)data,
                            isolate,
                            Puerts.NativeValueApi.SetValueToByRefArgument,
                            v8Value0,
                            arg0
                        );
                        StaticTranslate<UnityEngine.Vector3>.Set(
                            (int)data,
                            isolate,
                            Puerts.NativeValueApi.SetValueToByRefArgument,
                            v8Value1,
                            arg1
                        );
                        StaticTranslate<UnityEngine.Vector3>.Set(
                            (int)data,
                            isolate,
                            Puerts.NativeValueApi.SetValueToByRefArgument,
                            v8Value2,
                            arg2
                        );
                        return;
                    }
                }
                Puerts.PuertsDLL.ThrowException(isolate, "invalid arguments to OrthoNormalize");
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
        internal static void F_RotateTowards(
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
                    IntPtr v8Value2 = PuertsDLL.GetArgumentValue(info, 2);
                    object argobj2 = null;
                    ;
                    IntPtr v8Value3 = PuertsDLL.GetArgumentValue(info, 3);
                    object argobj3 = null;
                    ;
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
                        float arg2 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value2, false);
                        float arg3 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value3, false);

                        var result = UnityEngine.Vector3.RotateTowards(arg0, arg1, arg2, arg3);

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
        internal static unsafe void G_normalized(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = (UnityEngine.Vector3*)self;
                var result = (*obj).normalized;
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
        internal static unsafe void G_magnitude(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = (UnityEngine.Vector3*)self;
                var result = (*obj).magnitude;
                Puerts.PuertsDLL.ReturnNumber(isolate, info, result);
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
        internal static unsafe void G_sqrMagnitude(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = (UnityEngine.Vector3*)self;
                var result = (*obj).sqrMagnitude;
                Puerts.PuertsDLL.ReturnNumber(isolate, info, result);
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
        internal static void G_zero(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var result = UnityEngine.Vector3.zero;
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
        internal static void G_one(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var result = UnityEngine.Vector3.one;
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
        internal static void G_forward(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var result = UnityEngine.Vector3.forward;
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
        internal static void G_back(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var result = UnityEngine.Vector3.back;
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
        internal static void G_up(IntPtr isolate, IntPtr info, IntPtr self, int paramLen, long data)
        {
            try
            {
                var result = UnityEngine.Vector3.up;
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
        internal static void G_down(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var result = UnityEngine.Vector3.down;
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
        internal static void G_left(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var result = UnityEngine.Vector3.left;
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
        internal static void G_right(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var result = UnityEngine.Vector3.right;
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
        internal static void G_positiveInfinity(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var result = UnityEngine.Vector3.positiveInfinity;
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
        internal static void G_negativeInfinity(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var result = UnityEngine.Vector3.negativeInfinity;
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
        internal static void G_kEpsilon(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var result = UnityEngine.Vector3.kEpsilon;
                Puerts.PuertsDLL.ReturnNumber(isolate, info, result);
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
        internal static void G_kEpsilonNormalSqrt(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var result = UnityEngine.Vector3.kEpsilonNormalSqrt;
                Puerts.PuertsDLL.ReturnNumber(isolate, info, result);
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
        internal static unsafe void G_x(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = (UnityEngine.Vector3*)self;
                var result = (*obj).x;
                Puerts.PuertsDLL.ReturnNumber(isolate, info, result);
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
        internal static unsafe void S_x(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = (UnityEngine.Vector3*)self;
                IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                object argobj0 = null;
                float arg0 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value0, false);
                (*obj).x = arg0;
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
        internal static unsafe void G_y(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = (UnityEngine.Vector3*)self;
                var result = (*obj).y;
                Puerts.PuertsDLL.ReturnNumber(isolate, info, result);
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
        internal static unsafe void S_y(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = (UnityEngine.Vector3*)self;
                IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                object argobj0 = null;
                float arg0 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value0, false);
                (*obj).y = arg0;
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
        internal static unsafe void G_z(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = (UnityEngine.Vector3*)self;
                var result = (*obj).z;
                Puerts.PuertsDLL.ReturnNumber(isolate, info, result);
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
        internal static unsafe void S_z(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = (UnityEngine.Vector3*)self;
                IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                object argobj0 = null;
                float arg0 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value0, false);
                (*obj).z = arg0;
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

        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static unsafe void GetItem(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = (UnityEngine.Vector3*)self;
                IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                object argobj0 = null;
                JsValueType argType0 = JsValueType.Invalid;
                if (
                    ArgHelper.IsMatch(
                        (int)data,
                        isolate,
                        Puerts.JsValueType.Number,
                        typeof(int),
                        false,
                        false,
                        v8Value0,
                        ref argobj0,
                        ref argType0
                    )
                )
                {
                    int arg0 = (int)PuertsDLL.GetNumberFromValue(isolate, v8Value0, false);
                    var result = (*obj)[arg0];
                    Puerts.PuertsDLL.ReturnNumber(isolate, info, result);
                    return;
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
        internal static unsafe void SetItem(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = (UnityEngine.Vector3*)self;
                IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                object argobj0 = null;
                JsValueType argType0 = JsValueType.Invalid;

                if (
                    ArgHelper.IsMatch(
                        (int)data,
                        isolate,
                        Puerts.JsValueType.Number,
                        typeof(int),
                        false,
                        false,
                        v8Value0,
                        ref argobj0,
                        ref argType0
                    )
                )
                {
                    int arg0 = (int)PuertsDLL.GetNumberFromValue(isolate, v8Value0, false);

                    IntPtr v8Value1 = PuertsDLL.GetArgumentValue(info, 1);
                    object argobj1 = null;
                    float arg1 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value1, false);

                    (*obj)[arg0] = arg1;
                    return;
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

        // ==================== array item get/set end ====================
        // ==================== operator start ====================
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void O_op_Addition(
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
                        var result = arg0 + arg1;
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
        internal static void O_op_Subtraction(
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
                        var result = arg0 - arg1;
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
        internal static void O_op_UnaryNegation(
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
                        var result = -arg0;
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
        internal static void O_op_Multiply(
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
                            Puerts.JsValueType.Number,
                            typeof(float),
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
                        float arg1 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value1, false);
                        var result = arg0 * arg1;
                        Puerts.ResultHelper.Set((int)data, isolate, info, result);
                        return;
                    }
                    if (
                        ArgHelper.IsMatch(
                            (int)data,
                            isolate,
                            Puerts.JsValueType.Number,
                            typeof(float),
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
                        float arg0 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value0, false);
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
                        var result = arg0 * arg1;
                        Puerts.ResultHelper.Set((int)data, isolate, info, result);
                        return;
                    }
                }
                Puerts.PuertsDLL.ThrowException(isolate, "invalid arguments to op_Multiply");
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
        internal static void O_op_Division(
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
                                : StaticTranslate<UnityEngine.Vector3>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        UnityEngine.Vector3 arg0 = (UnityEngine.Vector3)argobj0;
                        float arg1 = (float)PuertsDLL.GetNumberFromValue(isolate, v8Value1, false);
                        var result = arg0 / arg1;
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


        unsafe internal static UnityEngine.Vector3 StaticGetter(
            int jsEnvIdx,
            IntPtr isolate,
            Puerts.IGetValueFromJs getValueApi,
            IntPtr value,
            bool isByRef
        )
        {
            UnityEngine.Vector3* result = (UnityEngine.Vector3*)
                getValueApi.GetNativeObject(isolate, value, isByRef);
            return result == null ? default(UnityEngine.Vector3) : *result;
        }

        internal static unsafe void StaticSetter(
            int jsEnvIdx,
            IntPtr isolate,
            Puerts.ISetValueToJs setValueApi,
            IntPtr value,
            UnityEngine.Vector3 val
        )
        {
            HeapValue = val;
            fixed (UnityEngine.Vector3* result = &HeapValue)
            {
                var typeId = Puerts.JsEnv.jsEnvs[jsEnvIdx].GetTypeId(typeof(UnityEngine.Vector3));
                setValueApi.SetNativeObject(isolate, value, typeId, new IntPtr(result));
            }
        }

        public static void InitBlittableCopy(Puerts.JsEnv jsEnv)
        {
            Puerts.StaticTranslate<UnityEngine.Vector3>.ReplaceDefault(StaticSetter, StaticGetter);
            jsEnv.RegisterGeneralGetSet(
                typeof(UnityEngine.Vector3),
                (
                    int jsEnvIdx,
                    IntPtr isolate,
                    Puerts.IGetValueFromJs getValueApi,
                    IntPtr value,
                    bool isByRef
                ) =>
                {
                    return StaticGetter(jsEnvIdx, isolate, getValueApi, value, isByRef);
                },
                (
                    int jsEnvIdx,
                    IntPtr isolate,
                    Puerts.ISetValueToJs setValueApi,
                    IntPtr value,
                    object obj
                ) =>
                {
                    StaticSetter(jsEnvIdx, isolate, setValueApi, value, (UnityEngine.Vector3)obj);
                }
            );
        }
    }
#pragma warning disable 0219
}
#endif
