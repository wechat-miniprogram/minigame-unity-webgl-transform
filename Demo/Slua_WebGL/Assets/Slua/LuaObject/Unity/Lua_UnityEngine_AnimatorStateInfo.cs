using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AnimatorStateInfo : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.AnimatorStateInfo o;
			o=new UnityEngine.AnimatorStateInfo();
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
	static public int IsName(IntPtr l) {
		try {
			UnityEngine.AnimatorStateInfo self;
			checkValueType(l,1,out self);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.IsName(a1);
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
	static public int IsTag(IntPtr l) {
		try {
			UnityEngine.AnimatorStateInfo self;
			checkValueType(l,1,out self);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.IsTag(a1);
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
	static public int get_fullPathHash(IntPtr l) {
		try {
			UnityEngine.AnimatorStateInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.fullPathHash);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_shortNameHash(IntPtr l) {
		try {
			UnityEngine.AnimatorStateInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.shortNameHash);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_normalizedTime(IntPtr l) {
		try {
			UnityEngine.AnimatorStateInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.normalizedTime);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_length(IntPtr l) {
		try {
			UnityEngine.AnimatorStateInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.length);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_speed(IntPtr l) {
		try {
			UnityEngine.AnimatorStateInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.speed);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_speedMultiplier(IntPtr l) {
		try {
			UnityEngine.AnimatorStateInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.speedMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_tagHash(IntPtr l) {
		try {
			UnityEngine.AnimatorStateInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.tagHash);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_loop(IntPtr l) {
		try {
			UnityEngine.AnimatorStateInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.loop);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.AnimatorStateInfo");
		addMember(l,IsName);
		addMember(l,IsTag);
		addMember(l,"fullPathHash",get_fullPathHash,null,true);
		addMember(l,"shortNameHash",get_shortNameHash,null,true);
		addMember(l,"normalizedTime",get_normalizedTime,null,true);
		addMember(l,"length",get_length,null,true);
		addMember(l,"speed",get_speed,null,true);
		addMember(l,"speedMultiplier",get_speedMultiplier,null,true);
		addMember(l,"tagHash",get_tagHash,null,true);
		addMember(l,"loop",get_loop,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.AnimatorStateInfo),typeof(System.ValueType));
	}
}
