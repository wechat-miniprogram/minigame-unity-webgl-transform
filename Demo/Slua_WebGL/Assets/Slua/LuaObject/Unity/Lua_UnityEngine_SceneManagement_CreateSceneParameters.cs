using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_SceneManagement_CreateSceneParameters : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.SceneManagement.CreateSceneParameters o;
			UnityEngine.SceneManagement.LocalPhysicsMode a1;
			a1 = (UnityEngine.SceneManagement.LocalPhysicsMode)LuaDLL.luaL_checkinteger(l, 2);
			o=new UnityEngine.SceneManagement.CreateSceneParameters(a1);
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_localPhysicsMode(IntPtr l) {
		try {
			UnityEngine.SceneManagement.CreateSceneParameters self;
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
			UnityEngine.SceneManagement.CreateSceneParameters self;
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
		getTypeTable(l,"UnityEngine.SceneManagement.CreateSceneParameters");
		addMember(l,"localPhysicsMode",get_localPhysicsMode,set_localPhysicsMode,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.SceneManagement.CreateSceneParameters),typeof(System.ValueType));
	}
}
