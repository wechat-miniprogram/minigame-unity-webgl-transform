using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_CustomYieldInstruction : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int MoveNext(IntPtr l) {
		try {
			UnityEngine.CustomYieldInstruction self=(UnityEngine.CustomYieldInstruction)checkSelf(l);
			var ret=self.MoveNext();
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
	static public int Reset(IntPtr l) {
		try {
			UnityEngine.CustomYieldInstruction self=(UnityEngine.CustomYieldInstruction)checkSelf(l);
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
	static public int get_keepWaiting(IntPtr l) {
		try {
			UnityEngine.CustomYieldInstruction self=(UnityEngine.CustomYieldInstruction)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.keepWaiting);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_Current(IntPtr l) {
		try {
			UnityEngine.CustomYieldInstruction self=(UnityEngine.CustomYieldInstruction)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.Current);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.CustomYieldInstruction");
		addMember(l,MoveNext);
		addMember(l,Reset);
		addMember(l,"keepWaiting",get_keepWaiting,null,true);
		addMember(l,"Current",get_Current,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.CustomYieldInstruction));
	}
}
