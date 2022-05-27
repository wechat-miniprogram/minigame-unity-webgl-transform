using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Profiling_Recorder : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int FilterToCurrentThread(IntPtr l) {
		try {
			UnityEngine.Profiling.Recorder self=(UnityEngine.Profiling.Recorder)checkSelf(l);
			self.FilterToCurrentThread();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CollectFromAllThreads(IntPtr l) {
		try {
			UnityEngine.Profiling.Recorder self=(UnityEngine.Profiling.Recorder)checkSelf(l);
			self.CollectFromAllThreads();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Get_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Profiling.Recorder.Get(a1);
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
	static public int get_isValid(IntPtr l) {
		try {
			UnityEngine.Profiling.Recorder self=(UnityEngine.Profiling.Recorder)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isValid);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_enabled(IntPtr l) {
		try {
			UnityEngine.Profiling.Recorder self=(UnityEngine.Profiling.Recorder)checkSelf(l);
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
			UnityEngine.Profiling.Recorder self=(UnityEngine.Profiling.Recorder)checkSelf(l);
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
	static public int get_elapsedNanoseconds(IntPtr l) {
		try {
			UnityEngine.Profiling.Recorder self=(UnityEngine.Profiling.Recorder)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.elapsedNanoseconds);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_gpuElapsedNanoseconds(IntPtr l) {
		try {
			UnityEngine.Profiling.Recorder self=(UnityEngine.Profiling.Recorder)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.gpuElapsedNanoseconds);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_sampleBlockCount(IntPtr l) {
		try {
			UnityEngine.Profiling.Recorder self=(UnityEngine.Profiling.Recorder)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.sampleBlockCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_gpuSampleBlockCount(IntPtr l) {
		try {
			UnityEngine.Profiling.Recorder self=(UnityEngine.Profiling.Recorder)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.gpuSampleBlockCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Profiling.Recorder");
		addMember(l,FilterToCurrentThread);
		addMember(l,CollectFromAllThreads);
		addMember(l,Get_s);
		addMember(l,"isValid",get_isValid,null,true);
		addMember(l,"enabled",get_enabled,set_enabled,true);
		addMember(l,"elapsedNanoseconds",get_elapsedNanoseconds,null,true);
		addMember(l,"gpuElapsedNanoseconds",get_gpuElapsedNanoseconds,null,true);
		addMember(l,"sampleBlockCount",get_sampleBlockCount,null,true);
		addMember(l,"gpuSampleBlockCount",get_gpuSampleBlockCount,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.Profiling.Recorder));
	}
}
