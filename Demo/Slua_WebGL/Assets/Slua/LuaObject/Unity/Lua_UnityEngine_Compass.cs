using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Compass : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Compass o;
			o=new UnityEngine.Compass();
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
	static public int get_magneticHeading(IntPtr l) {
		try {
			UnityEngine.Compass self=(UnityEngine.Compass)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.magneticHeading);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_trueHeading(IntPtr l) {
		try {
			UnityEngine.Compass self=(UnityEngine.Compass)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.trueHeading);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_headingAccuracy(IntPtr l) {
		try {
			UnityEngine.Compass self=(UnityEngine.Compass)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.headingAccuracy);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_rawVector(IntPtr l) {
		try {
			UnityEngine.Compass self=(UnityEngine.Compass)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.rawVector);
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
			UnityEngine.Compass self=(UnityEngine.Compass)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.timestamp);
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
			UnityEngine.Compass self=(UnityEngine.Compass)checkSelf(l);
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
			UnityEngine.Compass self=(UnityEngine.Compass)checkSelf(l);
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
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Compass");
		addMember(l,"magneticHeading",get_magneticHeading,null,true);
		addMember(l,"trueHeading",get_trueHeading,null,true);
		addMember(l,"headingAccuracy",get_headingAccuracy,null,true);
		addMember(l,"rawVector",get_rawVector,null,true);
		addMember(l,"timestamp",get_timestamp,null,true);
		addMember(l,"enabled",get_enabled,set_enabled,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Compass));
	}
}
