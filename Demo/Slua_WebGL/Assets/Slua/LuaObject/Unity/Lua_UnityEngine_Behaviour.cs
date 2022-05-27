using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Behaviour : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_enabled(IntPtr l) {
		try {
			UnityEngine.Behaviour self=(UnityEngine.Behaviour)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.enabled);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_enabled(IntPtr l) {
		try {
			UnityEngine.Behaviour self=(UnityEngine.Behaviour)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.enabled=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isActiveAndEnabled(IntPtr l) {
		try {
			UnityEngine.Behaviour self=(UnityEngine.Behaviour)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isActiveAndEnabled);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Behaviour");
		addMember(l,"enabled",get_enabled,set_enabled,true);
		addMember(l,"isActiveAndEnabled",get_isActiveAndEnabled,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.Behaviour),typeof(UnityEngine.Component));
	}
}
