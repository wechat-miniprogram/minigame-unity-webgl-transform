using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AnimationClip : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.AnimationClip o;
			o=new UnityEngine.AnimationClip();
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
	static public int SampleAnimation(IntPtr l) {
		try {
			UnityEngine.AnimationClip self=(UnityEngine.AnimationClip)checkSelf(l);
			UnityEngine.GameObject a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			self.SampleAnimation(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetCurve(IntPtr l) {
		try {
			UnityEngine.AnimationClip self=(UnityEngine.AnimationClip)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			System.Type a2;
			checkType(l,3,out a2);
			System.String a3;
			checkType(l,4,out a3);
			UnityEngine.AnimationCurve a4;
			checkType(l,5,out a4);
			self.SetCurve(a1,a2,a3,a4);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int EnsureQuaternionContinuity(IntPtr l) {
		try {
			UnityEngine.AnimationClip self=(UnityEngine.AnimationClip)checkSelf(l);
			self.EnsureQuaternionContinuity();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ClearCurves(IntPtr l) {
		try {
			UnityEngine.AnimationClip self=(UnityEngine.AnimationClip)checkSelf(l);
			self.ClearCurves();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AddEvent(IntPtr l) {
		try {
			UnityEngine.AnimationClip self=(UnityEngine.AnimationClip)checkSelf(l);
			UnityEngine.AnimationEvent a1;
			checkType(l,2,out a1);
			self.AddEvent(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_length(IntPtr l) {
		try {
			UnityEngine.AnimationClip self=(UnityEngine.AnimationClip)checkSelf(l);
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
	static public int get_frameRate(IntPtr l) {
		try {
			UnityEngine.AnimationClip self=(UnityEngine.AnimationClip)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.frameRate);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_frameRate(IntPtr l) {
		try {
			UnityEngine.AnimationClip self=(UnityEngine.AnimationClip)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.frameRate=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_wrapMode(IntPtr l) {
		try {
			UnityEngine.AnimationClip self=(UnityEngine.AnimationClip)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.wrapMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_wrapMode(IntPtr l) {
		try {
			UnityEngine.AnimationClip self=(UnityEngine.AnimationClip)checkSelf(l);
			UnityEngine.WrapMode v;
			v = (UnityEngine.WrapMode)LuaDLL.luaL_checkinteger(l, 2);
			self.wrapMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_localBounds(IntPtr l) {
		try {
			UnityEngine.AnimationClip self=(UnityEngine.AnimationClip)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.localBounds);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_localBounds(IntPtr l) {
		try {
			UnityEngine.AnimationClip self=(UnityEngine.AnimationClip)checkSelf(l);
			UnityEngine.Bounds v;
			checkValueType(l,2,out v);
			self.localBounds=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_legacy(IntPtr l) {
		try {
			UnityEngine.AnimationClip self=(UnityEngine.AnimationClip)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.legacy);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_legacy(IntPtr l) {
		try {
			UnityEngine.AnimationClip self=(UnityEngine.AnimationClip)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.legacy=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_humanMotion(IntPtr l) {
		try {
			UnityEngine.AnimationClip self=(UnityEngine.AnimationClip)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.humanMotion);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_empty(IntPtr l) {
		try {
			UnityEngine.AnimationClip self=(UnityEngine.AnimationClip)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.empty);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_hasGenericRootTransform(IntPtr l) {
		try {
			UnityEngine.AnimationClip self=(UnityEngine.AnimationClip)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.hasGenericRootTransform);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_hasMotionFloatCurves(IntPtr l) {
		try {
			UnityEngine.AnimationClip self=(UnityEngine.AnimationClip)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.hasMotionFloatCurves);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_hasMotionCurves(IntPtr l) {
		try {
			UnityEngine.AnimationClip self=(UnityEngine.AnimationClip)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.hasMotionCurves);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_hasRootCurves(IntPtr l) {
		try {
			UnityEngine.AnimationClip self=(UnityEngine.AnimationClip)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.hasRootCurves);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_events(IntPtr l) {
		try {
			UnityEngine.AnimationClip self=(UnityEngine.AnimationClip)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.events);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_events(IntPtr l) {
		try {
			UnityEngine.AnimationClip self=(UnityEngine.AnimationClip)checkSelf(l);
			UnityEngine.AnimationEvent[] v;
			checkArray(l,2,out v);
			self.events=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.AnimationClip");
		addMember(l,SampleAnimation);
		addMember(l,SetCurve);
		addMember(l,EnsureQuaternionContinuity);
		addMember(l,ClearCurves);
		addMember(l,AddEvent);
		addMember(l,"length",get_length,null,true);
		addMember(l,"frameRate",get_frameRate,set_frameRate,true);
		addMember(l,"wrapMode",get_wrapMode,set_wrapMode,true);
		addMember(l,"localBounds",get_localBounds,set_localBounds,true);
		addMember(l,"legacy",get_legacy,set_legacy,true);
		addMember(l,"humanMotion",get_humanMotion,null,true);
		addMember(l,"empty",get_empty,null,true);
		addMember(l,"hasGenericRootTransform",get_hasGenericRootTransform,null,true);
		addMember(l,"hasMotionFloatCurves",get_hasMotionFloatCurves,null,true);
		addMember(l,"hasMotionCurves",get_hasMotionCurves,null,true);
		addMember(l,"hasRootCurves",get_hasRootCurves,null,true);
		addMember(l,"events",get_events,set_events,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.AnimationClip),typeof(UnityEngine.Motion));
	}
}
