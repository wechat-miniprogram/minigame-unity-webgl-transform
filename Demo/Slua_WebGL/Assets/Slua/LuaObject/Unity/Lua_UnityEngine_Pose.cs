using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Pose : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Pose o;
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			UnityEngine.Quaternion a2;
			checkType(l,3,out a2);
			o=new UnityEngine.Pose(a1,a2);
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
	static public int GetTransformedBy(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(UnityEngine.Pose))){
				UnityEngine.Pose self;
				checkValueType(l,1,out self);
				UnityEngine.Pose a1;
				checkValueType(l,2,out a1);
				var ret=self.GetTransformedBy(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Transform))){
				UnityEngine.Pose self;
				checkValueType(l,1,out self);
				UnityEngine.Transform a1;
				checkType(l,2,out a1);
				var ret=self.GetTransformedBy(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetTransformedBy to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int op_Equality(IntPtr l) {
		try {
			UnityEngine.Pose a1;
			checkValueType(l,1,out a1);
			UnityEngine.Pose a2;
			checkValueType(l,2,out a2);
			var ret=(a1==a2);
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
	static public int op_Inequality(IntPtr l) {
		try {
			UnityEngine.Pose a1;
			checkValueType(l,1,out a1);
			UnityEngine.Pose a2;
			checkValueType(l,2,out a2);
			var ret=(a1!=a2);
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
	static public int get_position(IntPtr l) {
		try {
			UnityEngine.Pose self;
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
			UnityEngine.Pose self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
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
	static public int get_rotation(IntPtr l) {
		try {
			UnityEngine.Pose self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.rotation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_rotation(IntPtr l) {
		try {
			UnityEngine.Pose self;
			checkValueType(l,1,out self);
			UnityEngine.Quaternion v;
			checkType(l,2,out v);
			self.rotation=v;
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
	static public int get_forward(IntPtr l) {
		try {
			UnityEngine.Pose self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.forward);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_right(IntPtr l) {
		try {
			UnityEngine.Pose self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.right);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_up(IntPtr l) {
		try {
			UnityEngine.Pose self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.up);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_identity(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Pose.identity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Pose");
		addMember(l,GetTransformedBy);
		addMember(l,op_Equality);
		addMember(l,op_Inequality);
		addMember(l,"position",get_position,set_position,true);
		addMember(l,"rotation",get_rotation,set_rotation,true);
		addMember(l,"forward",get_forward,null,true);
		addMember(l,"right",get_right,null,true);
		addMember(l,"up",get_up,null,true);
		addMember(l,"identity",get_identity,null,false);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Pose),typeof(System.ValueType));
	}
}
