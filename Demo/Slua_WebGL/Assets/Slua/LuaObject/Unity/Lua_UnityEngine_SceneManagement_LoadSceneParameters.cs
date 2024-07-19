using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_SceneManagement_LoadSceneParameters : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			UnityEngine.SceneManagement.LoadSceneParameters o;
			if(argc==2){
				UnityEngine.SceneManagement.LoadSceneMode a1;
				a1 = (UnityEngine.SceneManagement.LoadSceneMode)LuaDLL.luaL_checkinteger(l, 2);
				o=new UnityEngine.SceneManagement.LoadSceneParameters(a1);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==3){
				UnityEngine.SceneManagement.LoadSceneMode a1;
				a1 = (UnityEngine.SceneManagement.LoadSceneMode)LuaDLL.luaL_checkinteger(l, 2);
				UnityEngine.SceneManagement.LocalPhysicsMode a2;
				a2 = (UnityEngine.SceneManagement.LocalPhysicsMode)LuaDLL.luaL_checkinteger(l, 3);
				o=new UnityEngine.SceneManagement.LoadSceneParameters(a1,a2);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==0){
				o=new UnityEngine.SceneManagement.LoadSceneParameters();
				pushValue(l,true);
				pushObject(l,o);
				return 2;
			}
			return error(l,"New object failed.");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_loadSceneMode(IntPtr l) {
		try {
			UnityEngine.SceneManagement.LoadSceneParameters self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.loadSceneMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_loadSceneMode(IntPtr l) {
		try {
			UnityEngine.SceneManagement.LoadSceneParameters self;
			checkValueType(l,1,out self);
			UnityEngine.SceneManagement.LoadSceneMode v;
			v = (UnityEngine.SceneManagement.LoadSceneMode)LuaDLL.luaL_checkinteger(l, 2);
			self.loadSceneMode=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_localPhysicsMode(IntPtr l) {
		try {
			UnityEngine.SceneManagement.LoadSceneParameters self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.localPhysicsMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_localPhysicsMode(IntPtr l) {
		try {
			UnityEngine.SceneManagement.LoadSceneParameters self;
			checkValueType(l,1,out self);
			UnityEngine.SceneManagement.LocalPhysicsMode v;
			v = (UnityEngine.SceneManagement.LocalPhysicsMode)LuaDLL.luaL_checkinteger(l, 2);
			self.localPhysicsMode=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.SceneManagement.LoadSceneParameters");
		addMember(l,"loadSceneMode",get_loadSceneMode,set_loadSceneMode,true);
		addMember(l,"localPhysicsMode",get_localPhysicsMode,set_localPhysicsMode,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.SceneManagement.LoadSceneParameters),typeof(System.ValueType));
	}
}
