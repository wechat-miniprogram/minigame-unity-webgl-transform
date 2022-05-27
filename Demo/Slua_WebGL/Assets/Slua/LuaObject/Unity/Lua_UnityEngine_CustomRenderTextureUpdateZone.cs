using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_CustomRenderTextureUpdateZone : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.CustomRenderTextureUpdateZone o;
			o=new UnityEngine.CustomRenderTextureUpdateZone();
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
	static public int get_updateZoneCenter(IntPtr l) {
		try {
			UnityEngine.CustomRenderTextureUpdateZone self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.updateZoneCenter);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_updateZoneCenter(IntPtr l) {
		try {
			UnityEngine.CustomRenderTextureUpdateZone self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.updateZoneCenter=v;
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
	static public int get_updateZoneSize(IntPtr l) {
		try {
			UnityEngine.CustomRenderTextureUpdateZone self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.updateZoneSize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_updateZoneSize(IntPtr l) {
		try {
			UnityEngine.CustomRenderTextureUpdateZone self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.updateZoneSize=v;
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
	static public int get_rotation(IntPtr l) {
		try {
			UnityEngine.CustomRenderTextureUpdateZone self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.rotation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_rotation(IntPtr l) {
		try {
			UnityEngine.CustomRenderTextureUpdateZone self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.rotation=v;
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
	static public int get_passIndex(IntPtr l) {
		try {
			UnityEngine.CustomRenderTextureUpdateZone self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.passIndex);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_passIndex(IntPtr l) {
		try {
			UnityEngine.CustomRenderTextureUpdateZone self;
			checkValueType(l,1,out self);
			System.Int32 v;
			checkType(l,2,out v);
			self.passIndex=v;
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
	static public int get_needSwap(IntPtr l) {
		try {
			UnityEngine.CustomRenderTextureUpdateZone self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.needSwap);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_needSwap(IntPtr l) {
		try {
			UnityEngine.CustomRenderTextureUpdateZone self;
			checkValueType(l,1,out self);
			System.Boolean v;
			checkType(l,2,out v);
			self.needSwap=v;
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
		getTypeTable(l,"UnityEngine.CustomRenderTextureUpdateZone");
		addMember(l,"updateZoneCenter",get_updateZoneCenter,set_updateZoneCenter,true);
		addMember(l,"updateZoneSize",get_updateZoneSize,set_updateZoneSize,true);
		addMember(l,"rotation",get_rotation,set_rotation,true);
		addMember(l,"passIndex",get_passIndex,set_passIndex,true);
		addMember(l,"needSwap",get_needSwap,set_needSwap,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.CustomRenderTextureUpdateZone),typeof(System.ValueType));
	}
}
