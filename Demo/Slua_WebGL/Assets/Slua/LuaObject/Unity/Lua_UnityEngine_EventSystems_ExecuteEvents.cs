using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_EventSystems_ExecuteEvents : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Execute_s(IntPtr l) {
		try {
			UnityEngine.GameObject a1;
			checkType(l,1,out a1);
			UnityEngine.EventSystems.BaseEventData a2;
			checkType(l,2,out a2);
			UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IEventSystemHandler> a3;
			checkDelegate(l,3,out a3);
			var ret=UnityEngine.EventSystems.ExecuteEvents.Execute<UnityEngine.EventSystems.IEventSystemHandler>(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ExecuteHierarchy_s(IntPtr l) {
		try {
			UnityEngine.GameObject a1;
			checkType(l,1,out a1);
			UnityEngine.EventSystems.BaseEventData a2;
			checkType(l,2,out a2);
			UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IEventSystemHandler> a3;
			checkDelegate(l,3,out a3);
			var ret=UnityEngine.EventSystems.ExecuteEvents.ExecuteHierarchy<UnityEngine.EventSystems.IEventSystemHandler>(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CanHandleEvent_s(IntPtr l) {
		try {
			UnityEngine.GameObject a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.EventSystems.ExecuteEvents.CanHandleEvent<UnityEngine.EventSystems.IEventSystemHandler>(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetEventHandler_s(IntPtr l) {
		try {
			UnityEngine.GameObject a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.EventSystems.ExecuteEvents.GetEventHandler<UnityEngine.EventSystems.IEventSystemHandler>(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.EventSystems.ExecuteEvents");
		addMember(l,Execute_s);
		addMember(l,ExecuteHierarchy_s);
		addMember(l,CanHandleEvent_s);
		addMember(l,GetEventHandler_s);
		addMember(l,"pointerMoveHandler",null,null,true);
		addMember(l,"pointerEnterHandler",null,null,true);
		addMember(l,"pointerExitHandler",null,null,true);
		addMember(l,"pointerDownHandler",null,null,true);
		addMember(l,"pointerUpHandler",null,null,true);
		addMember(l,"pointerClickHandler",null,null,true);
		addMember(l,"initializePotentialDrag",null,null,true);
		addMember(l,"beginDragHandler",null,null,true);
		addMember(l,"dragHandler",null,null,true);
		addMember(l,"endDragHandler",null,null,true);
		addMember(l,"dropHandler",null,null,true);
		addMember(l,"scrollHandler",null,null,true);
		addMember(l,"updateSelectedHandler",null,null,true);
		addMember(l,"selectHandler",null,null,true);
		addMember(l,"deselectHandler",null,null,true);
		addMember(l,"moveHandler",null,null,true);
		addMember(l,"submitHandler",null,null,true);
		addMember(l,"cancelHandler",null,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.EventSystems.ExecuteEvents));
	}
}
