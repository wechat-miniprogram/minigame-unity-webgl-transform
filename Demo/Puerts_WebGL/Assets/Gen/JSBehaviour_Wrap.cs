#if !(EXPERIMENTAL_IL2CPP_PUERTS && ENABLE_IL2CPP)
using System;
using Puerts;

namespace PuertsStaticWrap
{
#pragma warning disable 0219
    public static class JSBehaviour_Wrap
    {
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8ConstructorCallback))]
        internal static IntPtr Constructor(IntPtr isolate, IntPtr info, int paramLen, long data)
        {
            try
            {
                {
                    {
                        var result = new JSBehaviour();

                        return Puerts.Utils.GetObjectPtr((int)data, typeof(JSBehaviour), result);
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
        // ==================== methods end ====================

        // ==================== properties start ====================
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8FunctionCallback))]
        internal static void G_ScriptName(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = Puerts.Utils.GetSelf((int)data, self) as JSBehaviour;
                var result = obj.ScriptName;
                Puerts.PuertsDLL.ReturnString(isolate, info, result);
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
        internal static void G_ScriptOnDestroy(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = Puerts.Utils.GetSelf((int)data, self) as JSBehaviour;
                var result = obj.ScriptOnDestroy;
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
        internal static void S_ScriptOnDestroy(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = Puerts.Utils.GetSelf((int)data, self) as JSBehaviour;
                IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                object argobj0 = null;
                argobj0 =
                    argobj0 != null
                        ? argobj0
                        : StaticTranslate<System.Action>.Get(
                            (int)data,
                            isolate,
                            NativeValueApi.GetValueFromArgument,
                            v8Value0,
                            false
                        );
                System.Action arg0 = (System.Action)argobj0;
                obj.ScriptOnDestroy = arg0;
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
