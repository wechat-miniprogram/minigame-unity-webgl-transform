using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_EventSystems_RaycastResult : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult o;
			o=new UnityEngine.EventSystems.RaycastResult();
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
	static public int Clear(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			self.Clear();
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
	static public int get_module(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.module);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_module(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			UnityEngine.EventSystems.BaseRaycaster v;
			checkType(l,2,out v);
			self.module=v;
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
	static public int get_distance(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.distance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_distance(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.distance=v;
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
	static public int get_index(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.index);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_index(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.index=v;
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
	static public int get_depth(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.depth);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_depth(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			System.Int32 v;
			checkType(l,2,out v);
			self.depth=v;
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
	static public int get_sortingLayer(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sortingLayer);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_sortingLayer(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			System.Int32 v;
			checkType(l,2,out v);
			self.sortingLayer=v;
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
	static public int get_sortingOrder(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sortingOrder);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_sortingOrder(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			System.Int32 v;
			checkType(l,2,out v);
			self.sortingOrder=v;
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
	static public int get_worldPosition(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.worldPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_worldPosition(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.worldPosition=v;
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
	static public int get_worldNormal(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.worldNormal);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_worldNormal(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.worldNormal=v;
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
	static public int get_screenPosition(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.screenPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_screenPosition(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.screenPosition=v;
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
	static public int get_displayIndex(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.displayIndex);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_displayIndex(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			System.Int32 v;
			checkType(l,2,out v);
			self.displayIndex=v;
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
	static public int get_gameObject(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.gameObject);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_gameObject(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.gameObject=v;
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
	static public int get_isValid(IntPtr l) {
		try {
			UnityEngine.EventSystems.RaycastResult self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.isValid);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.EventSystems.RaycastResult");
		addMember(l,Clear);
		addMember(l,"module",get_module,set_module,true);
		addMember(l,"distance",get_distance,set_distance,true);
		addMember(l,"index",get_index,set_index,true);
		addMember(l,"depth",get_depth,set_depth,true);
		addMember(l,"sortingLayer",get_sortingLayer,set_sortingLayer,true);
		addMember(l,"sortingOrder",get_sortingOrder,set_sortingOrder,true);
		addMember(l,"worldPosition",get_worldPosition,set_worldPosition,true);
		addMember(l,"worldNormal",get_worldNormal,set_worldNormal,true);
		addMember(l,"screenPosition",get_screenPosition,set_screenPosition,true);
		addMember(l,"displayIndex",get_displayIndex,set_displayIndex,true);
		addMember(l,"gameObject",get_gameObject,set_gameObject,true);
		addMember(l,"isValid",get_isValid,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.EventSystems.RaycastResult),typeof(System.ValueType));
	}
}
