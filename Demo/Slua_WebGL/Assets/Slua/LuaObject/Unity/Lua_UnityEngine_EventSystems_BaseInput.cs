using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_EventSystems_BaseInput : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetMouseButtonDown(IntPtr l) {
		try {
			UnityEngine.EventSystems.BaseInput self=(UnityEngine.EventSystems.BaseInput)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetMouseButtonDown(a1);
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
	static public int GetMouseButtonUp(IntPtr l) {
		try {
			UnityEngine.EventSystems.BaseInput self=(UnityEngine.EventSystems.BaseInput)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetMouseButtonUp(a1);
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
	static public int GetMouseButton(IntPtr l) {
		try {
			UnityEngine.EventSystems.BaseInput self=(UnityEngine.EventSystems.BaseInput)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetMouseButton(a1);
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
	static public int GetTouch(IntPtr l) {
		try {
			UnityEngine.EventSystems.BaseInput self=(UnityEngine.EventSystems.BaseInput)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetTouch(a1);
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
	static public int GetAxisRaw(IntPtr l) {
		try {
			UnityEngine.EventSystems.BaseInput self=(UnityEngine.EventSystems.BaseInput)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.GetAxisRaw(a1);
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
	static public int GetButtonDown(IntPtr l) {
		try {
			UnityEngine.EventSystems.BaseInput self=(UnityEngine.EventSystems.BaseInput)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.GetButtonDown(a1);
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
	static public int get_compositionString(IntPtr l) {
		try {
			UnityEngine.EventSystems.BaseInput self=(UnityEngine.EventSystems.BaseInput)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.compositionString);
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
			UnityEngine.EventSystems.BaseInput self=(UnityEngine.EventSystems.BaseInput)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.imeCompositionMode);
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
			UnityEngine.EventSystems.BaseInput self=(UnityEngine.EventSystems.BaseInput)checkSelf(l);
			UnityEngine.IMECompositionMode v;
			v = (UnityEngine.IMECompositionMode)LuaDLL.luaL_checkinteger(l, 2);
			self.imeCompositionMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_compositionCursorPos(IntPtr l) {
		try {
			UnityEngine.EventSystems.BaseInput self=(UnityEngine.EventSystems.BaseInput)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.compositionCursorPos);
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
			UnityEngine.EventSystems.BaseInput self=(UnityEngine.EventSystems.BaseInput)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.compositionCursorPos=v;
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
			UnityEngine.EventSystems.BaseInput self=(UnityEngine.EventSystems.BaseInput)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.mousePresent);
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
			UnityEngine.EventSystems.BaseInput self=(UnityEngine.EventSystems.BaseInput)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.mousePosition);
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
			UnityEngine.EventSystems.BaseInput self=(UnityEngine.EventSystems.BaseInput)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.mouseScrollDelta);
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
			UnityEngine.EventSystems.BaseInput self=(UnityEngine.EventSystems.BaseInput)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.touchSupported);
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
			UnityEngine.EventSystems.BaseInput self=(UnityEngine.EventSystems.BaseInput)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.touchCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.EventSystems.BaseInput");
		addMember(l,GetMouseButtonDown);
		addMember(l,GetMouseButtonUp);
		addMember(l,GetMouseButton);
		addMember(l,GetTouch);
		addMember(l,GetAxisRaw);
		addMember(l,GetButtonDown);
		addMember(l,"compositionString",get_compositionString,null,true);
		addMember(l,"imeCompositionMode",get_imeCompositionMode,set_imeCompositionMode,true);
		addMember(l,"compositionCursorPos",get_compositionCursorPos,set_compositionCursorPos,true);
		addMember(l,"mousePresent",get_mousePresent,null,true);
		addMember(l,"mousePosition",get_mousePosition,null,true);
		addMember(l,"mouseScrollDelta",get_mouseScrollDelta,null,true);
		addMember(l,"touchSupported",get_touchSupported,null,true);
		addMember(l,"touchCount",get_touchCount,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.EventSystems.BaseInput),typeof(UnityEngine.EventSystems.UIBehaviour));
	}
}
