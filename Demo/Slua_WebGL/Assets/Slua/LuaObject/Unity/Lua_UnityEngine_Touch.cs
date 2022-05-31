using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Touch : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Touch o;
			o=new UnityEngine.Touch();
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
	static public int get_fingerId(IntPtr l) {
		try {
			UnityEngine.Touch self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.fingerId);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_fingerId(IntPtr l) {
		try {
			UnityEngine.Touch self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.fingerId=v;
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
	static public int get_position(IntPtr l) {
		try {
			UnityEngine.Touch self;
			checkValueType(l,1,out self);
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
			UnityEngine.Touch self;
			checkValueType(l,1,out self);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.position=v;
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
	static public int get_rawPosition(IntPtr l) {
		try {
			UnityEngine.Touch self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.rawPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_rawPosition(IntPtr l) {
		try {
			UnityEngine.Touch self;
			checkValueType(l,1,out self);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.rawPosition=v;
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
	static public int get_deltaPosition(IntPtr l) {
		try {
			UnityEngine.Touch self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.deltaPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_deltaPosition(IntPtr l) {
		try {
			UnityEngine.Touch self;
			checkValueType(l,1,out self);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.deltaPosition=v;
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
	static public int get_deltaTime(IntPtr l) {
		try {
			UnityEngine.Touch self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.deltaTime);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_deltaTime(IntPtr l) {
		try {
			UnityEngine.Touch self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.deltaTime=v;
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
	static public int get_tapCount(IntPtr l) {
		try {
			UnityEngine.Touch self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.tapCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_tapCount(IntPtr l) {
		try {
			UnityEngine.Touch self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.tapCount=v;
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
	static public int get_phase(IntPtr l) {
		try {
			UnityEngine.Touch self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.phase);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_phase(IntPtr l) {
		try {
			UnityEngine.Touch self;
			checkValueType(l,1,out self);
			UnityEngine.TouchPhase v;
			v = (UnityEngine.TouchPhase)LuaDLL.luaL_checkinteger(l, 2);
			self.phase=v;
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
	static public int get_pressure(IntPtr l) {
		try {
			UnityEngine.Touch self;
			checkValueType(l,1,out self);
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
			UnityEngine.Touch self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.pressure=v;
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
	static public int get_maximumPossiblePressure(IntPtr l) {
		try {
			UnityEngine.Touch self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.maximumPossiblePressure);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_maximumPossiblePressure(IntPtr l) {
		try {
			UnityEngine.Touch self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.maximumPossiblePressure=v;
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
	static public int get_type(IntPtr l) {
		try {
			UnityEngine.Touch self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.type);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_type(IntPtr l) {
		try {
			UnityEngine.Touch self;
			checkValueType(l,1,out self);
			UnityEngine.TouchType v;
			v = (UnityEngine.TouchType)LuaDLL.luaL_checkinteger(l, 2);
			self.type=v;
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
	static public int get_altitudeAngle(IntPtr l) {
		try {
			UnityEngine.Touch self;
			checkValueType(l,1,out self);
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
			UnityEngine.Touch self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.altitudeAngle=v;
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
	static public int get_azimuthAngle(IntPtr l) {
		try {
			UnityEngine.Touch self;
			checkValueType(l,1,out self);
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
			UnityEngine.Touch self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.azimuthAngle=v;
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
			UnityEngine.Touch self;
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
			UnityEngine.Touch self;
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
	static public int get_radiusVariance(IntPtr l) {
		try {
			UnityEngine.Touch self;
			checkValueType(l,1,out self);
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
			UnityEngine.Touch self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.radiusVariance=v;
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
		getTypeTable(l,"UnityEngine.Touch");
		addMember(l,"fingerId",get_fingerId,set_fingerId,true);
		addMember(l,"position",get_position,set_position,true);
		addMember(l,"rawPosition",get_rawPosition,set_rawPosition,true);
		addMember(l,"deltaPosition",get_deltaPosition,set_deltaPosition,true);
		addMember(l,"deltaTime",get_deltaTime,set_deltaTime,true);
		addMember(l,"tapCount",get_tapCount,set_tapCount,true);
		addMember(l,"phase",get_phase,set_phase,true);
		addMember(l,"pressure",get_pressure,set_pressure,true);
		addMember(l,"maximumPossiblePressure",get_maximumPossiblePressure,set_maximumPossiblePressure,true);
		addMember(l,"type",get_type,set_type,true);
		addMember(l,"altitudeAngle",get_altitudeAngle,set_altitudeAngle,true);
		addMember(l,"azimuthAngle",get_azimuthAngle,set_azimuthAngle,true);
		addMember(l,"radius",get_radius,set_radius,true);
		addMember(l,"radiusVariance",get_radiusVariance,set_radiusVariance,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Touch),typeof(System.ValueType));
	}
}
