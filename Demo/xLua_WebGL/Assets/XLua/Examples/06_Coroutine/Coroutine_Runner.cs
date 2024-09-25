using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace XLuaTest
{
    public class Coroutine_Runner : MonoBehaviour { }

    public static class CoroutineConfig
    {
        [LuaCallCSharp]
        public static List<Type> LuaCallCSharp
        {
            get { return new List<Type>() { typeof(WaitForSeconds), typeof(WWW) }; }
        }
    }
}
