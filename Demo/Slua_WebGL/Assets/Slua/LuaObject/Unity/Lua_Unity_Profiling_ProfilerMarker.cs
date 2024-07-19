using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_Unity_Profiling_ProfilerMarker : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			Unity.Profiling.ProfilerMarker o;
			if(argc==2){
				System.String a1;
				checkType(l,2,out a1);
				o=new Unity.Profiling.ProfilerMarker(a1);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==3){
				Unity.Profiling.ProfilerCategory a1;
				checkValueType(l,2,out a1);
				System.String a2;
				checkType(l,3,out a2);
				o=new Unity.Profiling.ProfilerMarker(a1,a2);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==4){
				Unity.Profiling.ProfilerCategory a1;
				checkValueType(l,2,out a1);
				System.String a2;
				checkType(l,3,out a2);
				Unity.Profiling.LowLevel.MarkerFlags a3;
				a3 = (Unity.Profiling.LowLevel.MarkerFlags)LuaDLL.luaL_checkinteger(l, 4);
				o=new Unity.Profiling.ProfilerMarker(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==0){
				o=new Unity.Profiling.ProfilerMarker();
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
	static public int Begin(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				Unity.Profiling.ProfilerMarker self;
				checkValueType(l,1,out self);
				self.Begin();
				pushValue(l,true);
				setBack(l,self);
				return 1;
			}
			else if(argc==2){
				Unity.Profiling.ProfilerMarker self;
				checkValueType(l,1,out self);
				UnityEngine.Object a1;
				checkType(l,2,out a1);
				self.Begin(a1);
				pushValue(l,true);
				setBack(l,self);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Begin to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int End(IntPtr l) {
		try {
			Unity.Profiling.ProfilerMarker self;
			checkValueType(l,1,out self);
			self.End();
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
	static public int Auto(IntPtr l) {
		try {
			Unity.Profiling.ProfilerMarker self;
			checkValueType(l,1,out self);
			var ret=self.Auto();
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
	static public int get_Handle(IntPtr l) {
		try {
			Unity.Profiling.ProfilerMarker self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.Handle);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"Unity.Profiling.ProfilerMarker");
		addMember(l,Begin);
		addMember(l,End);
		addMember(l,Auto);
		addMember(l,"Handle",get_Handle,null,true);
		createTypeMetatable(l,constructor, typeof(Unity.Profiling.ProfilerMarker),typeof(System.ValueType));
	}
}
