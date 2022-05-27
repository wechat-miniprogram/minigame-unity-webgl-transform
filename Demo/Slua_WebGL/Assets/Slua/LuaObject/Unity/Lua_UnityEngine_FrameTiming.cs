using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_FrameTiming : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.FrameTiming o;
			o=new UnityEngine.FrameTiming();
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
	static public int get_cpuTimePresentCalled(IntPtr l) {
		try {
			UnityEngine.FrameTiming self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.cpuTimePresentCalled);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_cpuTimePresentCalled(IntPtr l) {
		try {
			UnityEngine.FrameTiming self;
			checkValueType(l,1,out self);
			System.UInt64 v;
			checkType(l,2,out v);
			self.cpuTimePresentCalled=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_cpuFrameTime(IntPtr l) {
		try {
			UnityEngine.FrameTiming self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.cpuFrameTime);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_cpuFrameTime(IntPtr l) {
		try {
			UnityEngine.FrameTiming self;
			checkValueType(l,1,out self);
			System.Double v;
			checkType(l,2,out v);
			self.cpuFrameTime=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_cpuTimeFrameComplete(IntPtr l) {
		try {
			UnityEngine.FrameTiming self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.cpuTimeFrameComplete);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_cpuTimeFrameComplete(IntPtr l) {
		try {
			UnityEngine.FrameTiming self;
			checkValueType(l,1,out self);
			System.UInt64 v;
			checkType(l,2,out v);
			self.cpuTimeFrameComplete=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_gpuFrameTime(IntPtr l) {
		try {
			UnityEngine.FrameTiming self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.gpuFrameTime);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_gpuFrameTime(IntPtr l) {
		try {
			UnityEngine.FrameTiming self;
			checkValueType(l,1,out self);
			System.Double v;
			checkType(l,2,out v);
			self.gpuFrameTime=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_heightScale(IntPtr l) {
		try {
			UnityEngine.FrameTiming self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.heightScale);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_heightScale(IntPtr l) {
		try {
			UnityEngine.FrameTiming self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.heightScale=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_widthScale(IntPtr l) {
		try {
			UnityEngine.FrameTiming self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.widthScale);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_widthScale(IntPtr l) {
		try {
			UnityEngine.FrameTiming self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.widthScale=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_syncInterval(IntPtr l) {
		try {
			UnityEngine.FrameTiming self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.syncInterval);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_syncInterval(IntPtr l) {
		try {
			UnityEngine.FrameTiming self;
			checkValueType(l,1,out self);
			System.UInt32 v;
			checkType(l,2,out v);
			self.syncInterval=v;
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
		getTypeTable(l,"UnityEngine.FrameTiming");
		addMember(l,"cpuTimePresentCalled",get_cpuTimePresentCalled,set_cpuTimePresentCalled,true);
		addMember(l,"cpuFrameTime",get_cpuFrameTime,set_cpuFrameTime,true);
		addMember(l,"cpuTimeFrameComplete",get_cpuTimeFrameComplete,set_cpuTimeFrameComplete,true);
		addMember(l,"gpuFrameTime",get_gpuFrameTime,set_gpuFrameTime,true);
		addMember(l,"heightScale",get_heightScale,set_heightScale,true);
		addMember(l,"widthScale",get_widthScale,set_widthScale,true);
		addMember(l,"syncInterval",get_syncInterval,set_syncInterval,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.FrameTiming),typeof(System.ValueType));
	}
}
