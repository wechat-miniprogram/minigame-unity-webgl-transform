using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_EventSystems_PointerEventData : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData o;
			UnityEngine.EventSystems.EventSystem a1;
			checkType(l,2,out a1);
			o=new UnityEngine.EventSystems.PointerEventData(a1);
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
	static public int IsPointerMoving(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			var ret=self.IsPointerMoving();
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
	static public int IsScrolling(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			var ret=self.IsScrolling();
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
	static public int get_hovered(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.hovered);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_hovered(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			System.Collections.Generic.List<UnityEngine.GameObject> v;
			checkType(l,2,out v);
			self.hovered=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_pointerEnter(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pointerEnter);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_pointerEnter(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.pointerEnter=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_lastPress(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.lastPress);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_rawPointerPress(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.rawPointerPress);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_rawPointerPress(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.rawPointerPress=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_pointerDrag(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pointerDrag);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_pointerDrag(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.pointerDrag=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_pointerClick(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pointerClick);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_pointerClick(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.pointerClick=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_pointerCurrentRaycast(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pointerCurrentRaycast);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_pointerCurrentRaycast(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			UnityEngine.EventSystems.RaycastResult v;
			checkValueType(l,2,out v);
			self.pointerCurrentRaycast=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_pointerPressRaycast(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pointerPressRaycast);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_pointerPressRaycast(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			UnityEngine.EventSystems.RaycastResult v;
			checkValueType(l,2,out v);
			self.pointerPressRaycast=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_eligibleForClick(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.eligibleForClick);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_eligibleForClick(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.eligibleForClick=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_pointerId(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pointerId);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_pointerId(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.pointerId=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_position(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.position);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_position(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.position=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_delta(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.delta);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_delta(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.delta=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_pressPosition(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pressPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_pressPosition(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.pressPosition=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_clickTime(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.clickTime);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_clickTime(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.clickTime=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_clickCount(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.clickCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_clickCount(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.clickCount=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_scrollDelta(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.scrollDelta);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_scrollDelta(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.scrollDelta=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_useDragThreshold(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.useDragThreshold);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_useDragThreshold(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.useDragThreshold=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_dragging(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.dragging);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_dragging(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.dragging=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_button(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.button);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_button(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData.InputButton v;
			v = (UnityEngine.EventSystems.PointerEventData.InputButton)LuaDLL.luaL_checkinteger(l, 2);
			self.button=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_pressure(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pressure);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_pressure(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.pressure=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_tangentialPressure(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.tangentialPressure);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_tangentialPressure(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.tangentialPressure=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_altitudeAngle(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.altitudeAngle);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_altitudeAngle(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.altitudeAngle=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_azimuthAngle(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.azimuthAngle);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_azimuthAngle(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.azimuthAngle=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_twist(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.twist);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_twist(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.twist=v;
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
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
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
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.radius=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_radiusVariance(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.radiusVariance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_radiusVariance(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.radiusVariance=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_enterEventCamera(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.enterEventCamera);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_pressEventCamera(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pressEventCamera);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_pointerPress(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pointerPress);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_pointerPress(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerEventData self=(UnityEngine.EventSystems.PointerEventData)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.pointerPress=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.EventSystems.PointerEventData");
		addMember(l,IsPointerMoving);
		addMember(l,IsScrolling);
		addMember(l,"hovered",get_hovered,set_hovered,true);
		addMember(l,"pointerEnter",get_pointerEnter,set_pointerEnter,true);
		addMember(l,"lastPress",get_lastPress,null,true);
		addMember(l,"rawPointerPress",get_rawPointerPress,set_rawPointerPress,true);
		addMember(l,"pointerDrag",get_pointerDrag,set_pointerDrag,true);
		addMember(l,"pointerClick",get_pointerClick,set_pointerClick,true);
		addMember(l,"pointerCurrentRaycast",get_pointerCurrentRaycast,set_pointerCurrentRaycast,true);
		addMember(l,"pointerPressRaycast",get_pointerPressRaycast,set_pointerPressRaycast,true);
		addMember(l,"eligibleForClick",get_eligibleForClick,set_eligibleForClick,true);
		addMember(l,"pointerId",get_pointerId,set_pointerId,true);
		addMember(l,"position",get_position,set_position,true);
		addMember(l,"delta",get_delta,set_delta,true);
		addMember(l,"pressPosition",get_pressPosition,set_pressPosition,true);
		addMember(l,"clickTime",get_clickTime,set_clickTime,true);
		addMember(l,"clickCount",get_clickCount,set_clickCount,true);
		addMember(l,"scrollDelta",get_scrollDelta,set_scrollDelta,true);
		addMember(l,"useDragThreshold",get_useDragThreshold,set_useDragThreshold,true);
		addMember(l,"dragging",get_dragging,set_dragging,true);
		addMember(l,"button",get_button,set_button,true);
		addMember(l,"pressure",get_pressure,set_pressure,true);
		addMember(l,"tangentialPressure",get_tangentialPressure,set_tangentialPressure,true);
		addMember(l,"altitudeAngle",get_altitudeAngle,set_altitudeAngle,true);
		addMember(l,"azimuthAngle",get_azimuthAngle,set_azimuthAngle,true);
		addMember(l,"twist",get_twist,set_twist,true);
		addMember(l,"radius",get_radius,set_radius,true);
		addMember(l,"radiusVariance",get_radiusVariance,set_radiusVariance,true);
		addMember(l,"enterEventCamera",get_enterEventCamera,null,true);
		addMember(l,"pressEventCamera",get_pressEventCamera,null,true);
		addMember(l,"pointerPress",get_pointerPress,set_pointerPress,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.EventSystems.PointerEventData),typeof(UnityEngine.EventSystems.BaseEventData));
	}
}
