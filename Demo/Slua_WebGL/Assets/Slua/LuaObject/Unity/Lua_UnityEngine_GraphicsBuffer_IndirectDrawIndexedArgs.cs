using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_GraphicsBuffer_IndirectDrawIndexedArgs : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.GraphicsBuffer.IndirectDrawIndexedArgs o;
			o=new UnityEngine.GraphicsBuffer.IndirectDrawIndexedArgs();
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
	static public int get_size(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.GraphicsBuffer.IndirectDrawIndexedArgs.size);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_indexCountPerInstance(IntPtr l) {
		try {
			UnityEngine.GraphicsBuffer.IndirectDrawIndexedArgs self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.indexCountPerInstance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_indexCountPerInstance(IntPtr l) {
		try {
			UnityEngine.GraphicsBuffer.IndirectDrawIndexedArgs self;
			checkValueType(l,1,out self);
			System.UInt32 v;
			checkType(l,2,out v);
			self.indexCountPerInstance=v;
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
	static public int get_instanceCount(IntPtr l) {
		try {
			UnityEngine.GraphicsBuffer.IndirectDrawIndexedArgs self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.instanceCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_instanceCount(IntPtr l) {
		try {
			UnityEngine.GraphicsBuffer.IndirectDrawIndexedArgs self;
			checkValueType(l,1,out self);
			System.UInt32 v;
			checkType(l,2,out v);
			self.instanceCount=v;
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
	static public int get_startIndex(IntPtr l) {
		try {
			UnityEngine.GraphicsBuffer.IndirectDrawIndexedArgs self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startIndex);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startIndex(IntPtr l) {
		try {
			UnityEngine.GraphicsBuffer.IndirectDrawIndexedArgs self;
			checkValueType(l,1,out self);
			System.UInt32 v;
			checkType(l,2,out v);
			self.startIndex=v;
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
	static public int get_baseVertexIndex(IntPtr l) {
		try {
			UnityEngine.GraphicsBuffer.IndirectDrawIndexedArgs self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.baseVertexIndex);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_baseVertexIndex(IntPtr l) {
		try {
			UnityEngine.GraphicsBuffer.IndirectDrawIndexedArgs self;
			checkValueType(l,1,out self);
			System.UInt32 v;
			checkType(l,2,out v);
			self.baseVertexIndex=v;
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
	static public int get_startInstance(IntPtr l) {
		try {
			UnityEngine.GraphicsBuffer.IndirectDrawIndexedArgs self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startInstance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startInstance(IntPtr l) {
		try {
			UnityEngine.GraphicsBuffer.IndirectDrawIndexedArgs self;
			checkValueType(l,1,out self);
			System.UInt32 v;
			checkType(l,2,out v);
			self.startInstance=v;
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
		getTypeTable(l,"UnityEngine.GraphicsBuffer.IndirectDrawIndexedArgs");
		addMember(l,"size",get_size,null,false);
		addMember(l,"indexCountPerInstance",get_indexCountPerInstance,set_indexCountPerInstance,true);
		addMember(l,"instanceCount",get_instanceCount,set_instanceCount,true);
		addMember(l,"startIndex",get_startIndex,set_startIndex,true);
		addMember(l,"baseVertexIndex",get_baseVertexIndex,set_baseVertexIndex,true);
		addMember(l,"startInstance",get_startInstance,set_startInstance,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.GraphicsBuffer.IndirectDrawIndexedArgs),typeof(System.ValueType));
	}
}
