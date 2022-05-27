using System;
using System.Collections;
using System.Collections.Generic;

namespace LuaInterface
{
    [Flags]
    public enum InjectType
    {
        None = 0,
        After = 1,
        Before = 1 << 1,
        Replace = 1 << 2,
        ReplaceWithPreInvokeBase = 1 << 3,
        ReplaceWithPostInvokeBase = 1 << 4
    }

    public class LuaInjectionStation
    {
        public const byte NOT_INJECTION_FLAG = 0;
        public const byte INVALID_INJECTION_FLAG = byte.MaxValue;

        static int cacheSize = 0;
        static byte[] injectionFlagCache;
        static LuaFunction[] injectFunctionCache;

        static LuaInjectionStation()
        {
            injectionFlagCache = new byte[cacheSize];
            injectFunctionCache = new LuaFunction[cacheSize];
        }

        [NoToLua]
        public static byte GetInjectFlag(int index)
        {
            byte result = injectionFlagCache[index];

            if (result == INVALID_INJECTION_FLAG)
            {
                return NOT_INJECTION_FLAG;
            }
            else if (result == NOT_INJECTION_FLAG)
            {
                /// Delay injection not supported
                if (LuaState.GetInjectInitState(index))
                {
                    injectionFlagCache[index] = INVALID_INJECTION_FLAG;
                }
            }

            return result;
        }

        [NoToLua]
        public static LuaFunction GetInjectionFunction(int index)
        {
            return injectFunctionCache[index];
        }

        public static void CacheInjectFunction(int index, byte injectFlag, LuaFunction func)
        {
            if (index >= cacheSize)
            {
                return;
            }

            injectFunctionCache[index] = func;
            injectionFlagCache[index] = injectFlag;
        }

        public static void Clear()
        {
            for (int i = 0, len = injectionFlagCache.Length; i < len; ++i)
            {
                injectionFlagCache[i] = 0;
                injectFunctionCache[i] = null;
            }
        }
    }
}
