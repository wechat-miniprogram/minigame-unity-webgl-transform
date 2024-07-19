using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Diagnostics_Utils : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ForceCrash_s(IntPtr l) {
		try {
			UnityEngine.Diagnostics.ForcedCrashCategory a1;
			a1 = (UnityEngine.Diagnostics.ForcedCrashCategory)LuaDLL.luaL_checkinteger(l, 1);
			UnityEngine.Diagnostics.Utils.ForceCrash(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int NativeAssert_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			UnityEngine.Diagnostics.Utils.NativeAssert(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int NativeError_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			UnityEngine.Diagnostics.Utils.NativeError(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int NativeWarning_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			UnityEngine.Diagnostics.Utils.NativeWarning(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Diagnostics.Utils");
		addMember(l,ForceCrash_s);
		addMember(l,NativeAssert_s);
		addMember(l,NativeError_s);
		addMember(l,NativeWarning_s);
		createTypeMetatable(l,null, typeof(UnityEngine.Diagnostics.Utils));
	}
}
