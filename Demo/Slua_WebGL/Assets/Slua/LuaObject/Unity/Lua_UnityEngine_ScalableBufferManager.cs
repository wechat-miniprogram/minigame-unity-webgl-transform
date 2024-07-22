using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ScalableBufferManager : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ResizeBuffers_s(IntPtr l) {
		try {
			System.Single a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			UnityEngine.ScalableBufferManager.ResizeBuffers(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_widthScaleFactor(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.ScalableBufferManager.widthScaleFactor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_heightScaleFactor(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.ScalableBufferManager.heightScaleFactor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.ScalableBufferManager");
		addMember(l,ResizeBuffers_s);
		addMember(l,"widthScaleFactor",get_widthScaleFactor,null,false);
		addMember(l,"heightScaleFactor",get_heightScaleFactor,null,false);
		createTypeMetatable(l,null, typeof(UnityEngine.ScalableBufferManager));
	}
}
