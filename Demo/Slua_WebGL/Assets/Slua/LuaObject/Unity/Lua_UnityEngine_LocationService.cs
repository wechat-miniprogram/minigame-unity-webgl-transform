using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_LocationService : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.LocationService o;
			o=new UnityEngine.LocationService();
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
	static public int Start(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.LocationService self=(UnityEngine.LocationService)checkSelf(l);
				self.Start();
				pushValue(l,true);
				return 1;
			}
			else if(argc==2){
				UnityEngine.LocationService self=(UnityEngine.LocationService)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				self.Start(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UnityEngine.LocationService self=(UnityEngine.LocationService)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				self.Start(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Start to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Stop(IntPtr l) {
		try {
			UnityEngine.LocationService self=(UnityEngine.LocationService)checkSelf(l);
			self.Stop();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isEnabledByUser(IntPtr l) {
		try {
			UnityEngine.LocationService self=(UnityEngine.LocationService)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isEnabledByUser);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_status(IntPtr l) {
		try {
			UnityEngine.LocationService self=(UnityEngine.LocationService)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.status);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_lastData(IntPtr l) {
		try {
			UnityEngine.LocationService self=(UnityEngine.LocationService)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.lastData);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.LocationService");
		addMember(l,Start);
		addMember(l,Stop);
		addMember(l,"isEnabledByUser",get_isEnabledByUser,null,true);
		addMember(l,"status",get_status,null,true);
		addMember(l,"lastData",get_lastData,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.LocationService));
	}
}
