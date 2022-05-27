using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_EventSystems_AxisEventData : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.EventSystems.AxisEventData o;
			UnityEngine.EventSystems.EventSystem a1;
			checkType(l,2,out a1);
			o=new UnityEngine.EventSystems.AxisEventData(a1);
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
	static public int get_moveVector(IntPtr l) {
		try {
			UnityEngine.EventSystems.AxisEventData self=(UnityEngine.EventSystems.AxisEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.moveVector);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_moveVector(IntPtr l) {
		try {
			UnityEngine.EventSystems.AxisEventData self=(UnityEngine.EventSystems.AxisEventData)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.moveVector=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_moveDir(IntPtr l) {
		try {
			UnityEngine.EventSystems.AxisEventData self=(UnityEngine.EventSystems.AxisEventData)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.moveDir);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_moveDir(IntPtr l) {
		try {
			UnityEngine.EventSystems.AxisEventData self=(UnityEngine.EventSystems.AxisEventData)checkSelf(l);
			UnityEngine.EventSystems.MoveDirection v;
			v = (UnityEngine.EventSystems.MoveDirection)LuaDLL.luaL_checkinteger(l, 2);
			self.moveDir=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.EventSystems.AxisEventData");
		addMember(l,"moveVector",get_moveVector,set_moveVector,true);
		addMember(l,"moveDir",get_moveDir,set_moveDir,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.EventSystems.AxisEventData),typeof(UnityEngine.EventSystems.BaseEventData));
	}
}
