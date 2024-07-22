using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_GraphicsBuffer_IndirectDrawArgs : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.GraphicsBuffer.IndirectDrawArgs o;
			o=new UnityEngine.GraphicsBuffer.IndirectDrawArgs();
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
			pushValue(l,UnityEngine.GraphicsBuffer.IndirectDrawArgs.size);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_vertexCountPerInstance(IntPtr l) {
		try {
			UnityEngine.GraphicsBuffer.IndirectDrawArgs self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.vertexCountPerInstance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_vertexCountPerInstance(IntPtr l) {
		try {
			UnityEngine.GraphicsBuffer.IndirectDrawArgs self;
			checkValueType(l,1,out self);
			System.UInt32 v;
			checkType(l,2,out v);
			self.vertexCountPerInstance=v;
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
			UnityEngine.GraphicsBuffer.IndirectDrawArgs self;
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
			UnityEngine.GraphicsBuffer.IndirectDrawArgs self;
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
	static public int get_startVertex(IntPtr l) {
		try {
			UnityEngine.GraphicsBuffer.IndirectDrawArgs self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startVertex);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startVertex(IntPtr l) {
		try {
			UnityEngine.GraphicsBuffer.IndirectDrawArgs self;
			checkValueType(l,1,out self);
			System.UInt32 v;
			checkType(l,2,out v);
			self.startVertex=v;
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
			UnityEngine.GraphicsBuffer.IndirectDrawArgs self;
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
			UnityEngine.GraphicsBuffer.IndirectDrawArgs self;
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
		getTypeTable(l,"UnityEngine.GraphicsBuffer.IndirectDrawArgs");
		addMember(l,"size",get_size,null,false);
		addMember(l,"vertexCountPerInstance",get_vertexCountPerInstance,set_vertexCountPerInstance,true);
		addMember(l,"instanceCount",get_instanceCount,set_instanceCount,true);
		addMember(l,"startVertex",get_startVertex,set_startVertex,true);
		addMember(l,"startInstance",get_startInstance,set_startInstance,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.GraphicsBuffer.IndirectDrawArgs),typeof(System.ValueType));
	}
}
