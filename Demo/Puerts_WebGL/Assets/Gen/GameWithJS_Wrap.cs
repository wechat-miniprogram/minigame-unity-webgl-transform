#if !(EXPERIMENTAL_IL2CPP_PUERTS && ENABLE_IL2CPP)
using System;
using Puerts;

namespace PuertsStaticWrap
{
#pragma warning disable 0219
    public static class GameWithJS_Wrap
    {
        [Puerts.MonoPInvokeCallback(typeof(Puerts.V8ConstructorCallback))]
        internal static IntPtr Constructor(IntPtr isolate, IntPtr info, int paramLen, long data)
        {
            try
            {
                {
                    {
                        var result = new GameWithJS();

                        return Puerts.Utils.GetObjectPtr((int)data, typeof(GameWithJS), result);
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
                var obj = Puerts.Utils.GetSelf((int)data, self) as GameWithJS;
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
        internal static void G_SubPrefab(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = Puerts.Utils.GetSelf((int)data, self) as GameWithJS;
                var result = obj.SubPrefab;
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
        internal static void S_SubPrefab(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = Puerts.Utils.GetSelf((int)data, self) as GameWithJS;
                IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                object argobj0 = null;
                argobj0 =
                    argobj0 != null
                        ? argobj0
                        : StaticTranslate<UnityEngine.GameObject>.Get(
                            (int)data,
                            isolate,
                            NativeValueApi.GetValueFromArgument,
                            v8Value0,
                            false
                        );
                UnityEngine.GameObject arg0 = (UnityEngine.GameObject)argobj0;
                obj.SubPrefab = arg0;
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
        internal static void G_Main(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = Puerts.Utils.GetSelf((int)data, self) as GameWithJS;
                var result = obj.Main;
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
        internal static void S_Main(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = Puerts.Utils.GetSelf((int)data, self) as GameWithJS;
                IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                object argobj0 = null;
                argobj0 =
                    argobj0 != null
                        ? argobj0
                        : StaticTranslate<UnityEngine.GameObject>.Get(
                            (int)data,
                            isolate,
                            NativeValueApi.GetValueFromArgument,
                            v8Value0,
                            false
                        );
                UnityEngine.GameObject arg0 = (UnityEngine.GameObject)argobj0;
                obj.Main = arg0;
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
        internal static void G_Joystick(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = Puerts.Utils.GetSelf((int)data, self) as GameWithJS;
                var result = obj.Joystick;
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
        internal static void S_Joystick(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = Puerts.Utils.GetSelf((int)data, self) as GameWithJS;
                IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                object argobj0 = null;
                argobj0 =
                    argobj0 != null
                        ? argobj0
                        : StaticTranslate<Joystick>.Get(
                            (int)data,
                            isolate,
                            NativeValueApi.GetValueFromArgument,
                            v8Value0,
                            false
                        );
                Joystick arg0 = (Joystick)argobj0;
                obj.Joystick = arg0;
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
        internal static void G_FpsText(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = Puerts.Utils.GetSelf((int)data, self) as GameWithJS;
                var result = obj.FpsText;
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
        internal static void S_FpsText(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = Puerts.Utils.GetSelf((int)data, self) as GameWithJS;
                IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                object argobj0 = null;
                argobj0 =
                    argobj0 != null
                        ? argobj0
                        : StaticTranslate<UnityEngine.UI.Text>.Get(
                            (int)data,
                            isolate,
                            NativeValueApi.GetValueFromArgument,
                            v8Value0,
                            false
                        );
                UnityEngine.UI.Text arg0 = (UnityEngine.UI.Text)argobj0;
                obj.FpsText = arg0;
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
        internal static void G_BoxText(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = Puerts.Utils.GetSelf((int)data, self) as GameWithJS;
                var result = obj.BoxText;
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
        internal static void S_BoxText(
            IntPtr isolate,
            IntPtr info,
            IntPtr self,
            int paramLen,
            long data
        )
        {
            try
            {
                var obj = Puerts.Utils.GetSelf((int)data, self) as GameWithJS;
                IntPtr v8Value0 = PuertsDLL.GetArgumentValue(info, 0);
                object argobj0 = null;
                argobj0 =
                    argobj0 != null
                        ? argobj0
                        : StaticTranslate<UnityEngine.UI.Text>.Get(
                            (int)data,
                            isolate,
                            NativeValueApi.GetValueFromArgument,
                            v8Value0,
                            false
                        );
                UnityEngine.UI.Text arg0 = (UnityEngine.UI.Text)argobj0;
                obj.BoxText = arg0;
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
