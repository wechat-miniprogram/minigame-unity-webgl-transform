using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_Unity_Rendering_HybridV2_DOTSInstancingProperty : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			Unity.Rendering.HybridV2.DOTSInstancingProperty o;
			o=new Unity.Rendering.HybridV2.DOTSInstancingProperty();
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
	static public int get_MetadataNameID(IntPtr l) {
		try {
			Unity.Rendering.HybridV2.DOTSInstancingProperty self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.MetadataNameID);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_MetadataNameID(IntPtr l) {
		try {
			Unity.Rendering.HybridV2.DOTSInstancingProperty self;
			checkValueType(l,1,out self);
			System.Int32 v;
			checkType(l,2,out v);
			self.MetadataNameID=v;
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
	static public int get_ConstantNameID(IntPtr l) {
		try {
			Unity.Rendering.HybridV2.DOTSInstancingProperty self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.ConstantNameID);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_ConstantNameID(IntPtr l) {
		try {
			Unity.Rendering.HybridV2.DOTSInstancingProperty self;
			checkValueType(l,1,out self);
			System.Int32 v;
			checkType(l,2,out v);
			self.ConstantNameID=v;
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
			Unity.Rendering.HybridV2.DOTSInstancingProperty self;
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
			Unity.Rendering.HybridV2.DOTSInstancingProperty self;
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
	static public int get_MetadataOffset(IntPtr l) {
		try {
			Unity.Rendering.HybridV2.DOTSInstancingProperty self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.MetadataOffset);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_MetadataOffset(IntPtr l) {
		try {
			Unity.Rendering.HybridV2.DOTSInstancingProperty self;
			checkValueType(l,1,out self);
			System.Int32 v;
			checkType(l,2,out v);
			self.MetadataOffset=v;
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
			Unity.Rendering.HybridV2.DOTSInstancingProperty self;
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
			Unity.Rendering.HybridV2.DOTSInstancingProperty self;
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
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_ConstantType(IntPtr l) {
		try {
			Unity.Rendering.HybridV2.DOTSInstancingProperty self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.ConstantType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_ConstantType(IntPtr l) {
		try {
			Unity.Rendering.HybridV2.DOTSInstancingProperty self;
			checkValueType(l,1,out self);
			Unity.Rendering.HybridV2.DOTSInstancingPropertyType v;
			v = (Unity.Rendering.HybridV2.DOTSInstancingPropertyType)LuaDLL.luaL_checkinteger(l, 2);
			self.ConstantType=v;
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
	static public int get_Cols(IntPtr l) {
		try {
			Unity.Rendering.HybridV2.DOTSInstancingProperty self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.Cols);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_Cols(IntPtr l) {
		try {
			Unity.Rendering.HybridV2.DOTSInstancingProperty self;
			checkValueType(l,1,out self);
			System.Int32 v;
			checkType(l,2,out v);
			self.Cols=v;
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
	static public int get_Rows(IntPtr l) {
		try {
			Unity.Rendering.HybridV2.DOTSInstancingProperty self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.Rows);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_Rows(IntPtr l) {
		try {
			Unity.Rendering.HybridV2.DOTSInstancingProperty self;
			checkValueType(l,1,out self);
			System.Int32 v;
			checkType(l,2,out v);
			self.Rows=v;
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
		getTypeTable(l,"Unity.Rendering.HybridV2.DOTSInstancingProperty");
		addMember(l,"MetadataNameID",get_MetadataNameID,set_MetadataNameID,true);
		addMember(l,"ConstantNameID",get_ConstantNameID,set_ConstantNameID,true);
		addMember(l,"CbufferIndex",get_CbufferIndex,set_CbufferIndex,true);
		addMember(l,"MetadataOffset",get_MetadataOffset,set_MetadataOffset,true);
		addMember(l,"SizeBytes",get_SizeBytes,set_SizeBytes,true);
		addMember(l,"ConstantType",get_ConstantType,set_ConstantType,true);
		addMember(l,"Cols",get_Cols,set_Cols,true);
		addMember(l,"Rows",get_Rows,set_Rows,true);
		createTypeMetatable(l,constructor, typeof(Unity.Rendering.HybridV2.DOTSInstancingProperty),typeof(System.ValueType));
	}
}
