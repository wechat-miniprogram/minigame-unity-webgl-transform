// The MIT License (MIT)

// Copyright 2015 Siney/Pangweiwei siney@yeah.net
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections;

namespace SLua
{
    using UnityEngine;

    public class LuaThreadWrapper : LuaVar
    {
        private IntPtr _thread;
        
        public LuaThreadWrapper(LuaFunction func)
         : base()
        {
            // Logger.Log(string.Format("LuaThreadWrapper.ctor/1: {0}", LuaDLL.lua_gettop(func.L)));
            state = LuaState.get(func.L);
            _thread = LuaDLL.lua_newthread(func.L);
            valueref = LuaDLL.luaL_ref(func.L, LuaIndexes.LUA_REGISTRYINDEX);
            func.push(func.L);
            LuaDLL.lua_xmove(func.L, _thread, 1);
			// Logger.Log(string.Format("LuaThreadWrapper.ctor/2: {0}", LuaDLL.lua_gettop(func.L)));
        }

        ~LuaThreadWrapper()
        {
            // Debug.Log("~LuaThreadWrapper");
            Dispose(false);
        }

		public override void Dispose(bool disposeManagedResources)
        {
            base.Dispose(disposeManagedResources);
            _thread = IntPtr.Zero;
        }

        public bool EqualsTo(IntPtr L)
        {
            return _thread == L;
        }

        private object TopObjects(int nArgs)
        {
            if (nArgs == 0)
                return null;
            else if (nArgs == 1)
            {
                object o = LuaObject.checkVar(_thread, -1);
                return o;
            }
            else
            {
                object[] o = new object[nArgs];
                for (int n = 1; n <= nArgs; n++)
                {
                    o[n - 1] = LuaObject.checkVar(_thread, n);
                }
                return o;
            }
        }

        public bool Resume(out object retVal, object[] args)
        {
            if (_thread == IntPtr.Zero)
            {
                // Logger.LogError("thread: already disposed?");
                retVal = null;
                return false;
            }
            var status = LuaDLL.lua_status(_thread);
            if (status != 0 && status != (int)LuaThreadStatus.LUA_YIELD)
            {
                Logger.LogError("thread: wrong status ?= " + status);
                retVal = null;
                return false;
            }
            var size = args != null ? args.Length : 0;
            for (var i = 0; i < size; ++i) 
            {
                LuaObject.pushVar(_thread, args[i]);
            }
            var result = LuaDLL.lua_resume(_thread, size);
            if (result != (int)LuaThreadStatus.LUA_YIELD)
            {
                if (result != 0)
                {
                    string error = LuaDLL.lua_tostring(_thread, -1);
                    Logger.LogError(string.Format("wrong result ?= {0} err: {1}", result, error));
                }
                retVal = null;
                return false;
            }
            var nArgsFromYield = LuaDLL.lua_gettop(_thread);
            retVal = TopObjects(nArgsFromYield);
            return true;
        }
    }
}
