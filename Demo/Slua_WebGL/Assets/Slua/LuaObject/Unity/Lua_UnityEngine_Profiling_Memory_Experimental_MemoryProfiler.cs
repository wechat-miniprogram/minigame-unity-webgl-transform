using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Profiling_Memory_Experimental_MemoryProfiler : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Profiling.Memory.Experimental.MemoryProfiler o;
			o=new UnityEngine.Profiling.Memory.Experimental.MemoryProfiler();
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
	static public int TakeSnapshot_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				System.String a1;
				checkType(l,1,out a1);
				System.Action<System.String,System.Boolean> a2;
				checkDelegate(l,2,out a2);
				UnityEngine.Profiling.Memory.Experimental.CaptureFlags a3;
				a3 = (UnityEngine.Profiling.Memory.Experimental.CaptureFlags)LuaDLL.luaL_checkinteger(l, 3);
				UnityEngine.Profiling.Memory.Experimental.MemoryProfiler.TakeSnapshot(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(argc==4){
				System.String a1;
				checkType(l,1,out a1);
				System.Action<System.String,System.Boolean> a2;
				checkDelegate(l,2,out a2);
				System.Action<System.String,System.Boolean,UnityEngine.Profiling.Experimental.DebugScreenCapture> a3;
				checkDelegate(l,3,out a3);
				UnityEngine.Profiling.Memory.Experimental.CaptureFlags a4;
				a4 = (UnityEngine.Profiling.Memory.Experimental.CaptureFlags)LuaDLL.luaL_checkinteger(l, 4);
				UnityEngine.Profiling.Memory.Experimental.MemoryProfiler.TakeSnapshot(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function TakeSnapshot to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int TakeTempSnapshot_s(IntPtr l) {
		try {
			System.Action<System.String,System.Boolean> a1;
			checkDelegate(l,1,out a1);
			UnityEngine.Profiling.Memory.Experimental.CaptureFlags a2;
			a2 = (UnityEngine.Profiling.Memory.Experimental.CaptureFlags)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.Profiling.Memory.Experimental.MemoryProfiler.TakeTempSnapshot(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Profiling.Memory.Experimental.MemoryProfiler");
		addMember(l,TakeSnapshot_s);
		addMember(l,TakeTempSnapshot_s);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Profiling.Memory.Experimental.MemoryProfiler));
	}
}
