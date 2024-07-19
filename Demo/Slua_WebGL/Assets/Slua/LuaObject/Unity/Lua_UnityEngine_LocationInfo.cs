using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_LocationInfo : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.LocationInfo o;
			o=new UnityEngine.LocationInfo();
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
	static public int get_latitude(IntPtr l) {
		try {
			UnityEngine.LocationInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.latitude);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_longitude(IntPtr l) {
		try {
			UnityEngine.LocationInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.longitude);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_altitude(IntPtr l) {
		try {
			UnityEngine.LocationInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.altitude);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_horizontalAccuracy(IntPtr l) {
		try {
			UnityEngine.LocationInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.horizontalAccuracy);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_verticalAccuracy(IntPtr l) {
		try {
			UnityEngine.LocationInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.verticalAccuracy);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_timestamp(IntPtr l) {
		try {
			UnityEngine.LocationInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.timestamp);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.LocationInfo");
		addMember(l,"latitude",get_latitude,null,true);
		addMember(l,"longitude",get_longitude,null,true);
		addMember(l,"altitude",get_altitude,null,true);
		addMember(l,"horizontalAccuracy",get_horizontalAccuracy,null,true);
		addMember(l,"verticalAccuracy",get_verticalAccuracy,null,true);
		addMember(l,"timestamp",get_timestamp,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.LocationInfo),typeof(System.ValueType));
	}
}
