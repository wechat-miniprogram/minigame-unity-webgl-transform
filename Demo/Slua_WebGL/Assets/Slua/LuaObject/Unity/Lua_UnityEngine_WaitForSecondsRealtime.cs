using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_WaitForSecondsRealtime : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.WaitForSecondsRealtime o;
			System.Single a1;
			checkType(l,2,out a1);
			o=new UnityEngine.WaitForSecondsRealtime(a1);
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
	static public int Reset(IntPtr l) {
		try {
			UnityEngine.WaitForSecondsRealtime self=(UnityEngine.WaitForSecondsRealtime)checkSelf(l);
			self.Reset();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_waitTime(IntPtr l) {
		try {
			UnityEngine.WaitForSecondsRealtime self=(UnityEngine.WaitForSecondsRealtime)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.waitTime);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_waitTime(IntPtr l) {
		try {
			UnityEngine.WaitForSecondsRealtime self=(UnityEngine.WaitForSecondsRealtime)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.waitTime=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_keepWaiting(IntPtr l) {
		try {
			UnityEngine.WaitForSecondsRealtime self=(UnityEngine.WaitForSecondsRealtime)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.keepWaiting);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.WaitForSecondsRealtime");
		addMember(l,Reset);
		addMember(l,"waitTime",get_waitTime,set_waitTime,true);
		addMember(l,"keepWaiting",get_keepWaiting,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.WaitForSecondsRealtime),typeof(UnityEngine.CustomYieldInstruction));
	}
}
