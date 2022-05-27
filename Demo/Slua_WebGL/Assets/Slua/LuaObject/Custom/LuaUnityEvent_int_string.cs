
using System;
using System.Collections.Generic;

namespace SLua
{
    public class LuaUnityEvent_int_string : LuaObject
    {

        [SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static public int AddListener(IntPtr l)
        {
            try
            {
                UnityEngine.Events.UnityEvent<int,string> self = checkSelf<UnityEngine.Events.UnityEvent<int,string>>(l);
                UnityEngine.Events.UnityAction<int,string> a1;
                checkType(l, 2, out a1);
                self.AddListener(a1);
				pushValue(l,true);
                return 1;
            }
            catch (Exception e)
            {
				return error(l,e);
            }
        }
        [SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static public int RemoveListener(IntPtr l)
        {
            try
            {
                UnityEngine.Events.UnityEvent<int,string> self = checkSelf<UnityEngine.Events.UnityEvent<int,string>>(l);
                UnityEngine.Events.UnityAction<int,string> a1;
                checkType(l, 2, out a1);
                self.RemoveListener(a1);
				pushValue(l,true);
                return 1;
            }
            catch (Exception e)
            {
                return error(l,e);
            }
        }
        [SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static public int Invoke(IntPtr l)
        {
            try
            {
                UnityEngine.Events.UnityEvent<int,string> self = checkSelf<UnityEngine.Events.UnityEvent<int,string>>(l);
				int a0;
				checkType(l,2,out a0);
				string a1;
				checkType(l,3,out a1);
				self.Invoke(a0,a1);

				pushValue(l,true);
                return 1;
            }
            catch (Exception e)
            {
                return error(l,e);
            }
        }
        static public void reg(IntPtr l)
        {
            getTypeTable(l, typeof(LuaUnityEvent_int_string).FullName);
            addMember(l, AddListener);
            addMember(l, RemoveListener);
            addMember(l, Invoke);
            createTypeMetatable(l, null, typeof(LuaUnityEvent_int_string), typeof(UnityEngine.Events.UnityEventBase));
        }

        static bool checkType(IntPtr l,int p,out UnityEngine.Events.UnityAction<int,string> ua) {
            LuaDLL.luaL_checktype(l, p, LuaTypes.LUA_TFUNCTION);
            LuaDelegate ld;
            checkType(l, p, out ld);
            if (ld.d != null)
            {
                ua = (UnityEngine.Events.UnityAction<int,string>)ld.d;
                return true;
            }
			l = LuaState.get(l).L;
            ua = (int v0,string v1) =>
            {
                int error = pushTry(l);
                pushValue(l,v0);pushValue(l,v1);
                ld.pcall(2, error);
                LuaDLL.lua_settop(l,error - 1);
            };
            ld.d = ua;
            return true;
        }
    }
}
