using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PhysicsShape2D : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.PhysicsShape2D o;
			o=new UnityEngine.PhysicsShape2D();
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
	static public int get_shapeType(IntPtr l) {
		try {
			UnityEngine.PhysicsShape2D self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.shapeType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_shapeType(IntPtr l) {
		try {
			UnityEngine.PhysicsShape2D self;
			checkValueType(l,1,out self);
			UnityEngine.PhysicsShapeType2D v;
			v = (UnityEngine.PhysicsShapeType2D)LuaDLL.luaL_checkinteger(l, 2);
			self.shapeType=v;
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
	static public int get_radius(IntPtr l) {
		try {
			UnityEngine.PhysicsShape2D self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.radius);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_radius(IntPtr l) {
		try {
			UnityEngine.PhysicsShape2D self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.radius=v;
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
	static public int get_vertexStartIndex(IntPtr l) {
		try {
			UnityEngine.PhysicsShape2D self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.vertexStartIndex);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_vertexStartIndex(IntPtr l) {
		try {
			UnityEngine.PhysicsShape2D self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.vertexStartIndex=v;
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
	static public int get_vertexCount(IntPtr l) {
		try {
			UnityEngine.PhysicsShape2D self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.vertexCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_vertexCount(IntPtr l) {
		try {
			UnityEngine.PhysicsShape2D self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.vertexCount=v;
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
	static public int get_useAdjacentStart(IntPtr l) {
		try {
			UnityEngine.PhysicsShape2D self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.useAdjacentStart);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_useAdjacentStart(IntPtr l) {
		try {
			UnityEngine.PhysicsShape2D self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.useAdjacentStart=v;
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
	static public int get_useAdjacentEnd(IntPtr l) {
		try {
			UnityEngine.PhysicsShape2D self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.useAdjacentEnd);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_useAdjacentEnd(IntPtr l) {
		try {
			UnityEngine.PhysicsShape2D self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.useAdjacentEnd=v;
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
	static public int get_adjacentStart(IntPtr l) {
		try {
			UnityEngine.PhysicsShape2D self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.adjacentStart);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_adjacentStart(IntPtr l) {
		try {
			UnityEngine.PhysicsShape2D self;
			checkValueType(l,1,out self);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.adjacentStart=v;
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
	static public int get_adjacentEnd(IntPtr l) {
		try {
			UnityEngine.PhysicsShape2D self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.adjacentEnd);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_adjacentEnd(IntPtr l) {
		try {
			UnityEngine.PhysicsShape2D self;
			checkValueType(l,1,out self);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.adjacentEnd=v;
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
		getTypeTable(l,"UnityEngine.PhysicsShape2D");
		addMember(l,"shapeType",get_shapeType,set_shapeType,true);
		addMember(l,"radius",get_radius,set_radius,true);
		addMember(l,"vertexStartIndex",get_vertexStartIndex,set_vertexStartIndex,true);
		addMember(l,"vertexCount",get_vertexCount,set_vertexCount,true);
		addMember(l,"useAdjacentStart",get_useAdjacentStart,set_useAdjacentStart,true);
		addMember(l,"useAdjacentEnd",get_useAdjacentEnd,set_useAdjacentEnd,true);
		addMember(l,"adjacentStart",get_adjacentStart,set_adjacentStart,true);
		addMember(l,"adjacentEnd",get_adjacentEnd,set_adjacentEnd,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.PhysicsShape2D),typeof(System.ValueType));
	}
}
