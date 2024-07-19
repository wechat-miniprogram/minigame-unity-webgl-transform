using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_LowLevel_PlayerLoop : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.LowLevel.PlayerLoop o;
			o=new UnityEngine.LowLevel.PlayerLoop();
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
	static public int GetDefaultPlayerLoop_s(IntPtr l) {
		try {
			var ret=UnityEngine.LowLevel.PlayerLoop.GetDefaultPlayerLoop();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetCurrentPlayerLoop_s(IntPtr l) {
		try {
			var ret=UnityEngine.LowLevel.PlayerLoop.GetCurrentPlayerLoop();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetPlayerLoop_s(IntPtr l) {
		try {
			UnityEngine.LowLevel.PlayerLoopSystem a1;
			checkValueType(l,1,out a1);
			UnityEngine.LowLevel.PlayerLoop.SetPlayerLoop(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.LowLevel.PlayerLoop");
		addMember(l,GetDefaultPlayerLoop_s);
		addMember(l,GetCurrentPlayerLoop_s);
		addMember(l,SetPlayerLoop_s);
		createTypeMetatable(l,constructor, typeof(UnityEngine.LowLevel.PlayerLoop));
	}
}
