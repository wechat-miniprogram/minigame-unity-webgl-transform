#if !(EXPERIMENTAL_IL2CPP_PUERTS && ENABLE_IL2CPP)
using System;
using Puerts;

namespace PuertsStaticWrap
{
#pragma warning disable 0219
    public static class ScriptBehaviourManager_Wrap
    {
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8ConstructorCallback))]
        internal static IntPtr Constructor(IntPtr isolate, IntPtr info, int paramLen, long data)
        {
            try
            {
                {
                    {
                        var result = new ScriptBehaviourManager();

                        return Puerts.Utils.GetObjectPtr(
                            (int)data,
                            typeof(ScriptBehaviourManager),
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
        internal static void F_AddUpdate(
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
                                : StaticTranslate<System.Action>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value1,
                                    false
                                );
                        System.Action arg1 = (System.Action)argobj1;

                        ScriptBehaviourManager.AddUpdate(arg0, arg1);
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
        internal static void F_InvokeUpdate(
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
                                : StaticTranslate<UnityEngine.MonoBehaviour>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        UnityEngine.MonoBehaviour arg0 = (UnityEngine.MonoBehaviour)argobj0;

                        ScriptBehaviourManager.InvokeUpdate(arg0);
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
        internal static void F_InvokeStarter(
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
                                : StaticTranslate<UnityEngine.MonoBehaviour>.Get(
                                    (int)data,
                                    isolate,
                                    NativeValueApi.GetValueFromArgument,
                                    v8Value0,
                                    false
                                );
                        UnityEngine.MonoBehaviour arg0 = (UnityEngine.MonoBehaviour)argobj0;
                        string arg1 = (string)
                            PuertsDLL.GetStringFromValue(isolate, v8Value1, false);

                        ScriptBehaviourManager.InvokeStarter(arg0, arg1);
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
