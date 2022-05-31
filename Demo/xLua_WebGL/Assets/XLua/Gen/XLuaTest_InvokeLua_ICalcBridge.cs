#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System;


namespace XLua.CSObjectWrap
{
    public class XLuaTestInvokeLuaICalcBridge : LuaBase, XLuaTest.InvokeLua.ICalc
    {
	    public static LuaBase __Create(int reference, LuaEnv luaenv)
		{
		    return new XLuaTestInvokeLuaICalcBridge(reference, luaenv);
		}
		
		public XLuaTestInvokeLuaICalcBridge(int reference, LuaEnv luaenv) : base(reference, luaenv)
        {
        }
		
        
		int XLuaTest.InvokeLua.ICalc.Add(int a, int b)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
				RealStatePtr L = luaEnv.L;
				int err_func = LuaAPI.load_error_func(L, luaEnv.errorFuncRef);
				
				
				LuaAPI.lua_getref(L, luaReference);
				LuaAPI.xlua_pushasciistring(L, "Add");
				if (0 != LuaAPI.xlua_pgettable(L, -2))
				{
					luaEnv.ThrowExceptionFromError(err_func - 1);
				}
				if(!LuaAPI.lua_isfunction(L, -1))
				{
					LuaAPI.xlua_pushasciistring(L, "no such function Add");
					luaEnv.ThrowExceptionFromError(err_func - 1);
				}
				LuaAPI.lua_pushvalue(L, -2);
				LuaAPI.lua_remove(L, -3);
				LuaAPI.xlua_pushinteger(L, a);
				LuaAPI.xlua_pushinteger(L, b);
				
				int __gen_error = LuaAPI.lua_pcall(L, 3, 1, err_func);
				if (__gen_error != 0)
					luaEnv.ThrowExceptionFromError(err_func - 1);
				
				
				int __gen_ret = LuaAPI.xlua_tointeger(L, err_func + 1);
				LuaAPI.lua_settop(L, err_func - 1);
				return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        

        
        int XLuaTest.InvokeLua.ICalc.Mult 
        {
            
            get 
            {
#if THREAD_SAFE || HOTFIX_ENABLE
                lock (luaEnv.luaEnvLock)
                {
#endif
					RealStatePtr L = luaEnv.L;
					int oldTop = LuaAPI.lua_gettop(L);
					
					LuaAPI.lua_getref(L, luaReference);
					LuaAPI.xlua_pushasciistring(L, "Mult");
					if (0 != LuaAPI.xlua_pgettable(L, -2))
					{
						luaEnv.ThrowExceptionFromError(oldTop);
					}
					int __gen_ret = LuaAPI.xlua_tointeger(L, -1);
					LuaAPI.lua_pop(L, 2);
					return __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
                }
#endif
            }
            
            
            set
            {
#if THREAD_SAFE || HOTFIX_ENABLE
                lock (luaEnv.luaEnvLock)
                {
#endif
					RealStatePtr L = luaEnv.L;
					int oldTop = LuaAPI.lua_gettop(L);
					
					LuaAPI.lua_getref(L, luaReference);
					LuaAPI.xlua_pushasciistring(L, "Mult");
					LuaAPI.xlua_pushinteger(L, value);
					if (0 != LuaAPI.xlua_psettable(L, -3))
					{
						luaEnv.ThrowExceptionFromError(oldTop);
					}
					LuaAPI.lua_pop(L, 1);
#if THREAD_SAFE || HOTFIX_ENABLE
                }
#endif
            }
            
        }
        
        
        
		event System.EventHandler<XLuaTest.PropertyChangedEventArgs> XLuaTest.InvokeLua.ICalc.PropertyChanged
		{
			add
			{
#if THREAD_SAFE || HOTFIX_ENABLE
				lock (luaEnv.luaEnvLock)
				{
#endif
					RealStatePtr L = luaEnv.L;
					int err_func = LuaAPI.load_error_func(L, luaEnv.errorFuncRef);
					ObjectTranslator translator = luaEnv.translator;
				
					LuaAPI.lua_getref(L, luaReference);
					LuaAPI.xlua_pushasciistring(L, "add_PropertyChanged");
					if (0 != LuaAPI.xlua_pgettable(L, -2))
					{
						luaEnv.ThrowExceptionFromError(err_func - 1);
					}
					if(!LuaAPI.lua_isfunction(L, -1))
					{
						LuaAPI.xlua_pushasciistring(L, "no such function add_PropertyChanged");
						luaEnv.ThrowExceptionFromError(err_func - 1);
					}
					LuaAPI.lua_pushvalue(L, -2);
					LuaAPI.lua_remove(L, -3);
					translator.Push(L, value);
					
					int __gen_error = LuaAPI.lua_pcall(L, 2, 0, err_func);
					if (__gen_error != 0)
						luaEnv.ThrowExceptionFromError(err_func - 1);
				
					LuaAPI.lua_settop(L, err_func - 1);
#if THREAD_SAFE || HOTFIX_ENABLE
				}
#endif
			}

			remove
			{
#if THREAD_SAFE || HOTFIX_ENABLE
				lock (luaEnv.luaEnvLock)
				{
#endif
					RealStatePtr L = luaEnv.L;
					int err_func = LuaAPI.load_error_func(L, luaEnv.errorFuncRef);
					ObjectTranslator translator = luaEnv.translator;
				
					LuaAPI.lua_getref(L, luaReference);
					LuaAPI.xlua_pushasciistring(L, "remove_PropertyChanged");
					if (0 != LuaAPI.xlua_pgettable(L, -2))
					{
						luaEnv.ThrowExceptionFromError(err_func - 1);
					}
					if(!LuaAPI.lua_isfunction(L, -1))
					{
						LuaAPI.xlua_pushasciistring(L, "no such function remove_PropertyChanged");
						luaEnv.ThrowExceptionFromError(err_func - 1);
					}
					LuaAPI.lua_pushvalue(L, -2);
					LuaAPI.lua_remove(L, -3);
					translator.Push(L, value);
					
					int __gen_error = LuaAPI.lua_pcall(L, 2, 0, err_func);
					if (__gen_error != 0)
						luaEnv.ThrowExceptionFromError(err_func - 1);
				
					LuaAPI.lua_settop(L, err_func - 1);
#if THREAD_SAFE || HOTFIX_ENABLE
				}
#endif
			}
		}
        
		
		
        object XLuaTest.InvokeLua.ICalc.this[int index]
		{
		    get
			{
#if THREAD_SAFE || HOTFIX_ENABLE
				lock (luaEnv.luaEnvLock)
				{
#endif
					RealStatePtr L = luaEnv.L;
					int err_func = LuaAPI.load_error_func(L, luaEnv.errorFuncRef);
					ObjectTranslator translator = luaEnv.translator;
				
					LuaAPI.lua_getref(L, luaReference);
					LuaAPI.xlua_pushasciistring(L, "get_Item");
					if (0 != LuaAPI.xlua_pgettable(L, -2))
					{
						luaEnv.ThrowExceptionFromError(err_func - 1);
					}
					if(!LuaAPI.lua_isfunction(L, -1))
					{
						LuaAPI.xlua_pushasciistring(L, "no such function get_Item");
						luaEnv.ThrowExceptionFromError(err_func - 1);
					}
					LuaAPI.lua_pushvalue(L, -2);
					LuaAPI.lua_remove(L, -3);
					LuaAPI.xlua_pushinteger(L, index);
					
					int __gen_error = LuaAPI.lua_pcall(L, 2, 1, err_func);
					if (__gen_error != 0)
						luaEnv.ThrowExceptionFromError(err_func - 1);
				
					
					object __gen_ret = translator.GetObject(L, err_func + 1, typeof(object));
					LuaAPI.lua_settop(L, err_func - 1);
					return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
				}
#endif
			}
		
		
			set
			{
#if THREAD_SAFE || HOTFIX_ENABLE
				lock (luaEnv.luaEnvLock)
				{
#endif
					RealStatePtr L = luaEnv.L;
					int err_func = LuaAPI.load_error_func(L, luaEnv.errorFuncRef);
					ObjectTranslator translator = luaEnv.translator;
				
					LuaAPI.lua_getref(L, luaReference);
					LuaAPI.xlua_pushasciistring(L, "set_Item");
					if (0 != LuaAPI.xlua_pgettable(L, -2))
					{
						luaEnv.ThrowExceptionFromError(err_func - 1);
					}
					if(!LuaAPI.lua_isfunction(L, -1))
					{
						LuaAPI.xlua_pushasciistring(L, "no such function set_Item");
						luaEnv.ThrowExceptionFromError(err_func - 1);
					}
					LuaAPI.lua_pushvalue(L, -2);
					LuaAPI.lua_remove(L, -3);
					LuaAPI.xlua_pushinteger(L, index);
					translator.PushAny(L, value);
					
					int __gen_error = LuaAPI.lua_pcall(L, 3, 0, err_func);
					if (__gen_error != 0)
						luaEnv.ThrowExceptionFromError(err_func - 1);
				
					
					
					LuaAPI.lua_settop(L, err_func - 1);
					
#if THREAD_SAFE || HOTFIX_ENABLE
				}
#endif
			} 
		
		}
        
	}
}
