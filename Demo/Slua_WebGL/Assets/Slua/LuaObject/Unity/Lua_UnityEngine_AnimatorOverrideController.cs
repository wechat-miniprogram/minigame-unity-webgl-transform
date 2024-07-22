using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AnimatorOverrideController : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			UnityEngine.AnimatorOverrideController o;
			if(argc==1){
				o=new UnityEngine.AnimatorOverrideController();
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==2){
				UnityEngine.RuntimeAnimatorController a1;
				checkType(l,2,out a1);
				o=new UnityEngine.AnimatorOverrideController(a1);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			return error(l,"New object failed.");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetOverrides(IntPtr l) {
		try {
			UnityEngine.AnimatorOverrideController self=(UnityEngine.AnimatorOverrideController)checkSelf(l);
			System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<UnityEngine.AnimationClip,UnityEngine.AnimationClip>> a1;
			checkType(l,2,out a1);
			self.GetOverrides(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ApplyOverrides(IntPtr l) {
		try {
			UnityEngine.AnimatorOverrideController self=(UnityEngine.AnimatorOverrideController)checkSelf(l);
			System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<UnityEngine.AnimationClip,UnityEngine.AnimationClip>> a1;
			checkType(l,2,out a1);
			self.ApplyOverrides(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_runtimeAnimatorController(IntPtr l) {
		try {
			UnityEngine.AnimatorOverrideController self=(UnityEngine.AnimatorOverrideController)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.runtimeAnimatorController);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_runtimeAnimatorController(IntPtr l) {
		try {
			UnityEngine.AnimatorOverrideController self=(UnityEngine.AnimatorOverrideController)checkSelf(l);
			UnityEngine.RuntimeAnimatorController v;
			checkType(l,2,out v);
			self.runtimeAnimatorController=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_overridesCount(IntPtr l) {
		try {
			UnityEngine.AnimatorOverrideController self=(UnityEngine.AnimatorOverrideController)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.overridesCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int getItem(IntPtr l) {
		try {
			UnityEngine.AnimatorOverrideController self=(UnityEngine.AnimatorOverrideController)checkSelf(l);
			LuaTypes t = LuaDLL.lua_type(l, 2);
			if(matchType(l,2,t,typeof(System.String))){
				string v;
				checkType(l,2,out v);
				var ret = self[v];
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,2,t,typeof(UnityEngine.AnimationClip))){
				UnityEngine.AnimationClip v;
				checkType(l,2,out v);
				var ret = self[v];
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function getItem to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int setItem(IntPtr l) {
		try {
			UnityEngine.AnimatorOverrideController self=(UnityEngine.AnimatorOverrideController)checkSelf(l);
			LuaTypes t = LuaDLL.lua_type(l, 2);
			if(matchType(l,2,t,typeof(System.String))){
				string v;
				checkType(l,2,out v);
				UnityEngine.AnimationClip c;
				checkType(l,3,out c);
				self[v]=c;
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,2,t,typeof(UnityEngine.AnimationClip))){
				UnityEngine.AnimationClip v;
				checkType(l,2,out v);
				UnityEngine.AnimationClip c;
				checkType(l,3,out c);
				self[v]=c;
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function setItem to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.AnimatorOverrideController");
		addMember(l,GetOverrides);
		addMember(l,ApplyOverrides);
		addMember(l,getItem);
		addMember(l,setItem);
		addMember(l,"runtimeAnimatorController",get_runtimeAnimatorController,set_runtimeAnimatorController,true);
		addMember(l,"overridesCount",get_overridesCount,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.AnimatorOverrideController),typeof(UnityEngine.RuntimeAnimatorController));
	}
}
