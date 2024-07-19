using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_FrameTimingManager : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CaptureFrameTimings_s(IntPtr l) {
		try {
			UnityEngine.FrameTimingManager.CaptureFrameTimings();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetLatestTimings_s(IntPtr l) {
		try {
			System.UInt32 a1;
			checkType(l,1,out a1);
			UnityEngine.FrameTiming[] a2;
			checkArray(l,2,out a2);
			var ret=UnityEngine.FrameTimingManager.GetLatestTimings(a1,a2);
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
	static public int GetVSyncsPerSecond_s(IntPtr l) {
		try {
			var ret=UnityEngine.FrameTimingManager.GetVSyncsPerSecond();
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
	static public int GetGpuTimerFrequency_s(IntPtr l) {
		try {
			var ret=UnityEngine.FrameTimingManager.GetGpuTimerFrequency();
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
	static public int GetCpuTimerFrequency_s(IntPtr l) {
		try {
			var ret=UnityEngine.FrameTimingManager.GetCpuTimerFrequency();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.FrameTimingManager");
		addMember(l,CaptureFrameTimings_s);
		addMember(l,GetLatestTimings_s);
		addMember(l,GetVSyncsPerSecond_s);
		addMember(l,GetGpuTimerFrequency_s);
		addMember(l,GetCpuTimerFrequency_s);
		createTypeMetatable(l,null, typeof(UnityEngine.FrameTimingManager));
	}
}
