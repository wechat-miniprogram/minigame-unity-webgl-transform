using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_Unity_Rendering_HybridV2_DOTSInstancingCbuffer : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			Unity.Rendering.HybridV2.DOTSInstancingCbuffer o;
			o=new Unity.Rendering.HybridV2.DOTSInstancingCbuffer();
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
	static public int get_NameID(IntPtr l) {
		try {
			Unity.Rendering.HybridV2.DOTSInstancingCbuffer self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.NameID);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_NameID(IntPtr l) {
		try {
			Unity.Rendering.HybridV2.DOTSInstancingCbuffer self;
			checkValueType(l,1,out self);
			System.Int32 v;
			checkType(l,2,out v);
			self.NameID=v;
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
	static public int get_CbufferIndex(IntPtr l) {
		try {
			Unity.Rendering.HybridV2.DOTSInstancingCbuffer self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.CbufferIndex);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_CbufferIndex(IntPtr l) {
		try {
			Unity.Rendering.HybridV2.DOTSInstancingCbuffer self;
			checkValueType(l,1,out self);
			System.Int32 v;
			checkType(l,2,out v);
			self.CbufferIndex=v;
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
	static public int get_SizeBytes(IntPtr l) {
		try {
			Unity.Rendering.HybridV2.DOTSInstancingCbuffer self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.SizeBytes);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_SizeBytes(IntPtr l) {
		try {
			Unity.Rendering.HybridV2.DOTSInstancingCbuffer self;
			checkValueType(l,1,out self);
			System.Int32 v;
			checkType(l,2,out v);
			self.SizeBytes=v;
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
		getTypeTable(l,"Unity.Rendering.HybridV2.DOTSInstancingCbuffer");
		addMember(l,"NameID",get_NameID,set_NameID,true);
		addMember(l,"CbufferIndex",get_CbufferIndex,set_CbufferIndex,true);
		addMember(l,"SizeBytes",get_SizeBytes,set_SizeBytes,true);
		createTypeMetatable(l,constructor, typeof(Unity.Rendering.HybridV2.DOTSInstancingCbuffer),typeof(System.ValueType));
	}
}
