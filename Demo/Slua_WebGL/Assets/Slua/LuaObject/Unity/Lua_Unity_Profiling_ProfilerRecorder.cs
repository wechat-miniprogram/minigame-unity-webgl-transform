using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_Unity_Profiling_ProfilerRecorder : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			Unity.Profiling.ProfilerRecorder o;
			if(matchType(l,argc,2,typeof(string),typeof(int),typeof(Unity.Profiling.ProfilerRecorderOptions))){
				System.String a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				Unity.Profiling.ProfilerRecorderOptions a3;
				a3 = (Unity.Profiling.ProfilerRecorderOptions)LuaDLL.luaL_checkinteger(l, 4);
				o=new Unity.Profiling.ProfilerRecorder(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(string),typeof(int),typeof(Unity.Profiling.ProfilerRecorderOptions))){
				System.String a1;
				checkType(l,2,out a1);
				System.String a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				Unity.Profiling.ProfilerRecorderOptions a4;
				a4 = (Unity.Profiling.ProfilerRecorderOptions)LuaDLL.luaL_checkinteger(l, 5);
				o=new Unity.Profiling.ProfilerRecorder(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(Unity.Profiling.ProfilerCategory),typeof(string),typeof(int),typeof(Unity.Profiling.ProfilerRecorderOptions))){
				Unity.Profiling.ProfilerCategory a1;
				checkValueType(l,2,out a1);
				System.String a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				Unity.Profiling.ProfilerRecorderOptions a4;
				a4 = (Unity.Profiling.ProfilerRecorderOptions)LuaDLL.luaL_checkinteger(l, 5);
				o=new Unity.Profiling.ProfilerRecorder(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(Unity.Profiling.ProfilerMarker),typeof(int),typeof(Unity.Profiling.ProfilerRecorderOptions))){
				Unity.Profiling.ProfilerMarker a1;
				checkValueType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				Unity.Profiling.ProfilerRecorderOptions a3;
				a3 = (Unity.Profiling.ProfilerRecorderOptions)LuaDLL.luaL_checkinteger(l, 4);
				o=new Unity.Profiling.ProfilerRecorder(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(Unity.Profiling.LowLevel.Unsafe.ProfilerRecorderHandle),typeof(int),typeof(Unity.Profiling.ProfilerRecorderOptions))){
				Unity.Profiling.LowLevel.Unsafe.ProfilerRecorderHandle a1;
				checkValueType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				Unity.Profiling.ProfilerRecorderOptions a3;
				a3 = (Unity.Profiling.ProfilerRecorderOptions)LuaDLL.luaL_checkinteger(l, 4);
				o=new Unity.Profiling.ProfilerRecorder(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==0){
				o=new Unity.Profiling.ProfilerRecorder();
				pushValue(l,true);
				pushObject(l,o);
				return 2;
			}
			return error(l,"New object failed.");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Start(IntPtr l) {
		try {
			Unity.Profiling.ProfilerRecorder self;
			checkValueType(l,1,out self);
			self.Start();
			pushValue(l,true);
			setBack(l,self);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Stop(IntPtr l) {
		try {
			Unity.Profiling.ProfilerRecorder self;
			checkValueType(l,1,out self);
			self.Stop();
			pushValue(l,true);
			setBack(l,self);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Reset(IntPtr l) {
		try {
			Unity.Profiling.ProfilerRecorder self;
			checkValueType(l,1,out self);
			self.Reset();
			pushValue(l,true);
			setBack(l,self);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetSample(IntPtr l) {
		try {
			Unity.Profiling.ProfilerRecorder self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetSample(a1);
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
	static public int ToArray(IntPtr l) {
		try {
			Unity.Profiling.ProfilerRecorder self;
			checkValueType(l,1,out self);
			var ret=self.ToArray();
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
	static public int Dispose(IntPtr l) {
		try {
			Unity.Profiling.ProfilerRecorder self;
			checkValueType(l,1,out self);
			self.Dispose();
			pushValue(l,true);
			setBack(l,self);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int StartNew_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				Unity.Profiling.ProfilerMarker a1;
				checkValueType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				Unity.Profiling.ProfilerRecorderOptions a3;
				a3 = (Unity.Profiling.ProfilerRecorderOptions)LuaDLL.luaL_checkinteger(l, 3);
				var ret=Unity.Profiling.ProfilerRecorder.StartNew(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==4){
				Unity.Profiling.ProfilerCategory a1;
				checkValueType(l,1,out a1);
				System.String a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				Unity.Profiling.ProfilerRecorderOptions a4;
				a4 = (Unity.Profiling.ProfilerRecorderOptions)LuaDLL.luaL_checkinteger(l, 4);
				var ret=Unity.Profiling.ProfilerRecorder.StartNew(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function StartNew to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_Valid(IntPtr l) {
		try {
			Unity.Profiling.ProfilerRecorder self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.Valid);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_DataType(IntPtr l) {
		try {
			Unity.Profiling.ProfilerRecorder self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.DataType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_UnitType(IntPtr l) {
		try {
			Unity.Profiling.ProfilerRecorder self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.UnitType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_CurrentValue(IntPtr l) {
		try {
			Unity.Profiling.ProfilerRecorder self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.CurrentValue);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_CurrentValueAsDouble(IntPtr l) {
		try {
			Unity.Profiling.ProfilerRecorder self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.CurrentValueAsDouble);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_LastValue(IntPtr l) {
		try {
			Unity.Profiling.ProfilerRecorder self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.LastValue);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_LastValueAsDouble(IntPtr l) {
		try {
			Unity.Profiling.ProfilerRecorder self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.LastValueAsDouble);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_Capacity(IntPtr l) {
		try {
			Unity.Profiling.ProfilerRecorder self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.Capacity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_Count(IntPtr l) {
		try {
			Unity.Profiling.ProfilerRecorder self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.Count);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_IsRunning(IntPtr l) {
		try {
			Unity.Profiling.ProfilerRecorder self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.IsRunning);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_WrappedAround(IntPtr l) {
		try {
			Unity.Profiling.ProfilerRecorder self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.WrappedAround);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"Unity.Profiling.ProfilerRecorder");
		addMember(l,Start);
		addMember(l,Stop);
		addMember(l,Reset);
		addMember(l,GetSample);
		addMember(l,ToArray);
		addMember(l,Dispose);
		addMember(l,StartNew_s);
		addMember(l,"Valid",get_Valid,null,true);
		addMember(l,"DataType",get_DataType,null,true);
		addMember(l,"UnitType",get_UnitType,null,true);
		addMember(l,"CurrentValue",get_CurrentValue,null,true);
		addMember(l,"CurrentValueAsDouble",get_CurrentValueAsDouble,null,true);
		addMember(l,"LastValue",get_LastValue,null,true);
		addMember(l,"LastValueAsDouble",get_LastValueAsDouble,null,true);
		addMember(l,"Capacity",get_Capacity,null,true);
		addMember(l,"Count",get_Count,null,true);
		addMember(l,"IsRunning",get_IsRunning,null,true);
		addMember(l,"WrappedAround",get_WrappedAround,null,true);
		createTypeMetatable(l,constructor, typeof(Unity.Profiling.ProfilerRecorder),typeof(System.ValueType));
	}
}
