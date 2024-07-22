using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Input : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Input o;
			o=new UnityEngine.Input();
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
	static public int GetAxis_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Input.GetAxis(a1);
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
	static public int GetAxisRaw_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Input.GetAxisRaw(a1);
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
	static public int GetButton_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Input.GetButton(a1);
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
	static public int GetButtonDown_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Input.GetButtonDown(a1);
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
	static public int GetButtonUp_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Input.GetButtonUp(a1);
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
	static public int GetMouseButton_s(IntPtr l) {
		try {
			System.Int32 a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Input.GetMouseButton(a1);
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
	static public int GetMouseButtonDown_s(IntPtr l) {
		try {
			System.Int32 a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Input.GetMouseButtonDown(a1);
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
	static public int GetMouseButtonUp_s(IntPtr l) {
		try {
			System.Int32 a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Input.GetMouseButtonUp(a1);
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
	static public int ResetInputAxes_s(IntPtr l) {
		try {
			UnityEngine.Input.ResetInputAxes();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetJoystickNames_s(IntPtr l) {
		try {
			var ret=UnityEngine.Input.GetJoystickNames();
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
	static public int GetTouch_s(IntPtr l) {
		try {
			System.Int32 a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Input.GetTouch(a1);
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
	static public int GetAccelerationEvent_s(IntPtr l) {
		try {
			System.Int32 a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Input.GetAccelerationEvent(a1);
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
	static public int GetKey_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.KeyCode))){
				UnityEngine.KeyCode a1;
				a1 = (UnityEngine.KeyCode)LuaDLL.luaL_checkinteger(l, 1);
				var ret=UnityEngine.Input.GetKey(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(string))){
				System.String a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Input.GetKey(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetKey to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetKeyUp_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.KeyCode))){
				UnityEngine.KeyCode a1;
				a1 = (UnityEngine.KeyCode)LuaDLL.luaL_checkinteger(l, 1);
				var ret=UnityEngine.Input.GetKeyUp(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(string))){
				System.String a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Input.GetKeyUp(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetKeyUp to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetKeyDown_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.KeyCode))){
				UnityEngine.KeyCode a1;
				a1 = (UnityEngine.KeyCode)LuaDLL.luaL_checkinteger(l, 1);
				var ret=UnityEngine.Input.GetKeyDown(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(string))){
				System.String a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Input.GetKeyDown(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetKeyDown to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_simulateMouseWithTouches(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Input.simulateMouseWithTouches);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_simulateMouseWithTouches(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Input.simulateMouseWithTouches=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_anyKey(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Input.anyKey);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_anyKeyDown(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Input.anyKeyDown);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_inputString(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Input.inputString);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_mousePosition(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Input.mousePosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_mouseScrollDelta(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Input.mouseScrollDelta);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_imeCompositionMode(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UnityEngine.Input.imeCompositionMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_imeCompositionMode(IntPtr l) {
		try {
			UnityEngine.IMECompositionMode v;
			v = (UnityEngine.IMECompositionMode)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.Input.imeCompositionMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_compositionString(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Input.compositionString);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_imeIsSelected(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Input.imeIsSelected);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_compositionCursorPos(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Input.compositionCursorPos);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_compositionCursorPos(IntPtr l) {
		try {
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			UnityEngine.Input.compositionCursorPos=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_mousePresent(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Input.mousePresent);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_touchCount(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Input.touchCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_touchPressureSupported(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Input.touchPressureSupported);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_stylusTouchSupported(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Input.stylusTouchSupported);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_touchSupported(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Input.touchSupported);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_multiTouchEnabled(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Input.multiTouchEnabled);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_multiTouchEnabled(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Input.multiTouchEnabled=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_deviceOrientation(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UnityEngine.Input.deviceOrientation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_acceleration(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Input.acceleration);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_compensateSensors(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Input.compensateSensors);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_compensateSensors(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Input.compensateSensors=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_accelerationEventCount(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Input.accelerationEventCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_backButtonLeavesApp(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Input.backButtonLeavesApp);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_backButtonLeavesApp(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Input.backButtonLeavesApp=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_location(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Input.location);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_compass(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Input.compass);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_gyro(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Input.gyro);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_touches(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Input.touches);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_accelerationEvents(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Input.accelerationEvents);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Input");
		addMember(l,GetAxis_s);
		addMember(l,GetAxisRaw_s);
		addMember(l,GetButton_s);
		addMember(l,GetButtonDown_s);
		addMember(l,GetButtonUp_s);
		addMember(l,GetMouseButton_s);
		addMember(l,GetMouseButtonDown_s);
		addMember(l,GetMouseButtonUp_s);
		addMember(l,ResetInputAxes_s);
		addMember(l,GetJoystickNames_s);
		addMember(l,GetTouch_s);
		addMember(l,GetAccelerationEvent_s);
		addMember(l,GetKey_s);
		addMember(l,GetKeyUp_s);
		addMember(l,GetKeyDown_s);
		addMember(l,"simulateMouseWithTouches",get_simulateMouseWithTouches,set_simulateMouseWithTouches,false);
		addMember(l,"anyKey",get_anyKey,null,false);
		addMember(l,"anyKeyDown",get_anyKeyDown,null,false);
		addMember(l,"inputString",get_inputString,null,false);
		addMember(l,"mousePosition",get_mousePosition,null,false);
		addMember(l,"mouseScrollDelta",get_mouseScrollDelta,null,false);
		addMember(l,"imeCompositionMode",get_imeCompositionMode,set_imeCompositionMode,false);
		addMember(l,"compositionString",get_compositionString,null,false);
		addMember(l,"imeIsSelected",get_imeIsSelected,null,false);
		addMember(l,"compositionCursorPos",get_compositionCursorPos,set_compositionCursorPos,false);
		addMember(l,"mousePresent",get_mousePresent,null,false);
		addMember(l,"touchCount",get_touchCount,null,false);
		addMember(l,"touchPressureSupported",get_touchPressureSupported,null,false);
		addMember(l,"stylusTouchSupported",get_stylusTouchSupported,null,false);
		addMember(l,"touchSupported",get_touchSupported,null,false);
		addMember(l,"multiTouchEnabled",get_multiTouchEnabled,set_multiTouchEnabled,false);
		addMember(l,"deviceOrientation",get_deviceOrientation,null,false);
		addMember(l,"acceleration",get_acceleration,null,false);
		addMember(l,"compensateSensors",get_compensateSensors,set_compensateSensors,false);
		addMember(l,"accelerationEventCount",get_accelerationEventCount,null,false);
		addMember(l,"backButtonLeavesApp",get_backButtonLeavesApp,set_backButtonLeavesApp,false);
		addMember(l,"location",get_location,null,false);
		addMember(l,"compass",get_compass,null,false);
		addMember(l,"gyro",get_gyro,null,false);
		addMember(l,"touches",get_touches,null,false);
		addMember(l,"accelerationEvents",get_accelerationEvents,null,false);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Input));
	}
}
