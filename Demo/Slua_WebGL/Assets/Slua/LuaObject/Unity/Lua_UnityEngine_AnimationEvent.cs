using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AnimationEvent : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.AnimationEvent o;
			o=new UnityEngine.AnimationEvent();
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
	static public int get_stringParameter(IntPtr l) {
		try {
			UnityEngine.AnimationEvent self=(UnityEngine.AnimationEvent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.stringParameter);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_stringParameter(IntPtr l) {
		try {
			UnityEngine.AnimationEvent self=(UnityEngine.AnimationEvent)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.stringParameter=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_floatParameter(IntPtr l) {
		try {
			UnityEngine.AnimationEvent self=(UnityEngine.AnimationEvent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.floatParameter);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_floatParameter(IntPtr l) {
		try {
			UnityEngine.AnimationEvent self=(UnityEngine.AnimationEvent)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.floatParameter=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_intParameter(IntPtr l) {
		try {
			UnityEngine.AnimationEvent self=(UnityEngine.AnimationEvent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.intParameter);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_intParameter(IntPtr l) {
		try {
			UnityEngine.AnimationEvent self=(UnityEngine.AnimationEvent)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.intParameter=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_objectReferenceParameter(IntPtr l) {
		try {
			UnityEngine.AnimationEvent self=(UnityEngine.AnimationEvent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.objectReferenceParameter);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_objectReferenceParameter(IntPtr l) {
		try {
			UnityEngine.AnimationEvent self=(UnityEngine.AnimationEvent)checkSelf(l);
			UnityEngine.Object v;
			checkType(l,2,out v);
			self.objectReferenceParameter=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_functionName(IntPtr l) {
		try {
			UnityEngine.AnimationEvent self=(UnityEngine.AnimationEvent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.functionName);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_functionName(IntPtr l) {
		try {
			UnityEngine.AnimationEvent self=(UnityEngine.AnimationEvent)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.functionName=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_time(IntPtr l) {
		try {
			UnityEngine.AnimationEvent self=(UnityEngine.AnimationEvent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.time);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_time(IntPtr l) {
		try {
			UnityEngine.AnimationEvent self=(UnityEngine.AnimationEvent)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.time=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_messageOptions(IntPtr l) {
		try {
			UnityEngine.AnimationEvent self=(UnityEngine.AnimationEvent)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.messageOptions);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_messageOptions(IntPtr l) {
		try {
			UnityEngine.AnimationEvent self=(UnityEngine.AnimationEvent)checkSelf(l);
			UnityEngine.SendMessageOptions v;
			v = (UnityEngine.SendMessageOptions)LuaDLL.luaL_checkinteger(l, 2);
			self.messageOptions=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isFiredByLegacy(IntPtr l) {
		try {
			UnityEngine.AnimationEvent self=(UnityEngine.AnimationEvent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isFiredByLegacy);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isFiredByAnimator(IntPtr l) {
		try {
			UnityEngine.AnimationEvent self=(UnityEngine.AnimationEvent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isFiredByAnimator);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_animationState(IntPtr l) {
		try {
			UnityEngine.AnimationEvent self=(UnityEngine.AnimationEvent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.animationState);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_animatorStateInfo(IntPtr l) {
		try {
			UnityEngine.AnimationEvent self=(UnityEngine.AnimationEvent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.animatorStateInfo);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_animatorClipInfo(IntPtr l) {
		try {
			UnityEngine.AnimationEvent self=(UnityEngine.AnimationEvent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.animatorClipInfo);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.AnimationEvent");
		addMember(l,"stringParameter",get_stringParameter,set_stringParameter,true);
		addMember(l,"floatParameter",get_floatParameter,set_floatParameter,true);
		addMember(l,"intParameter",get_intParameter,set_intParameter,true);
		addMember(l,"objectReferenceParameter",get_objectReferenceParameter,set_objectReferenceParameter,true);
		addMember(l,"functionName",get_functionName,set_functionName,true);
		addMember(l,"time",get_time,set_time,true);
		addMember(l,"messageOptions",get_messageOptions,set_messageOptions,true);
		addMember(l,"isFiredByLegacy",get_isFiredByLegacy,null,true);
		addMember(l,"isFiredByAnimator",get_isFiredByAnimator,null,true);
		addMember(l,"animationState",get_animationState,null,true);
		addMember(l,"animatorStateInfo",get_animatorStateInfo,null,true);
		addMember(l,"animatorClipInfo",get_animatorClipInfo,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.AnimationEvent));
	}
}
