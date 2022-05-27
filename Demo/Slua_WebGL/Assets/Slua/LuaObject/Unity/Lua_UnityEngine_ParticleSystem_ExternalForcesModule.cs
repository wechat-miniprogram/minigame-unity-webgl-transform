using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystem_ExternalForcesModule : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ExternalForcesModule o;
			o=new UnityEngine.ParticleSystem.ExternalForcesModule();
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
	static public int IsAffectedBy(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ExternalForcesModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemForceField a1;
			checkType(l,2,out a1);
			var ret=self.IsAffectedBy(a1);
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
	static public int AddInfluence(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ExternalForcesModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemForceField a1;
			checkType(l,2,out a1);
			self.AddInfluence(a1);
			pushValue(l,true);
			setBack(l,self);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RemoveInfluence(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int))){
				UnityEngine.ParticleSystem.ExternalForcesModule self;
				checkValueType(l,1,out self);
				System.Int32 a1;
				checkType(l,2,out a1);
				self.RemoveInfluence(a1);
				pushValue(l,true);
				setBack(l,self);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.ParticleSystemForceField))){
				UnityEngine.ParticleSystem.ExternalForcesModule self;
				checkValueType(l,1,out self);
				UnityEngine.ParticleSystemForceField a1;
				checkType(l,2,out a1);
				self.RemoveInfluence(a1);
				pushValue(l,true);
				setBack(l,self);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function RemoveInfluence to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RemoveAllInfluences(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ExternalForcesModule self;
			checkValueType(l,1,out self);
			self.RemoveAllInfluences();
			pushValue(l,true);
			setBack(l,self);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetInfluence(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ExternalForcesModule self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			UnityEngine.ParticleSystemForceField a2;
			checkType(l,3,out a2);
			self.SetInfluence(a1,a2);
			pushValue(l,true);
			setBack(l,self);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetInfluence(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ExternalForcesModule self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetInfluence(a1);
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
	static public int get_enabled(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ExternalForcesModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.enabled);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_enabled(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ExternalForcesModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.enabled=v;
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
	static public int get_multiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ExternalForcesModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.multiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_multiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ExternalForcesModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.multiplier=v;
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
	static public int get_multiplierCurve(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ExternalForcesModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.multiplierCurve);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_multiplierCurve(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ExternalForcesModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.multiplierCurve=v;
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
	static public int get_influenceFilter(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ExternalForcesModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.influenceFilter);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_influenceFilter(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ExternalForcesModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemGameObjectFilter v;
			v = (UnityEngine.ParticleSystemGameObjectFilter)LuaDLL.luaL_checkinteger(l, 2);
			self.influenceFilter=v;
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
	static public int get_influenceMask(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ExternalForcesModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.influenceMask);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_influenceMask(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ExternalForcesModule self;
			checkValueType(l,1,out self);
			UnityEngine.LayerMask v;
			checkValueType(l,2,out v);
			self.influenceMask=v;
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
	static public int get_influenceCount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ExternalForcesModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.influenceCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.ParticleSystem.ExternalForcesModule");
		addMember(l,IsAffectedBy);
		addMember(l,AddInfluence);
		addMember(l,RemoveInfluence);
		addMember(l,RemoveAllInfluences);
		addMember(l,SetInfluence);
		addMember(l,GetInfluence);
		addMember(l,"enabled",get_enabled,set_enabled,true);
		addMember(l,"multiplier",get_multiplier,set_multiplier,true);
		addMember(l,"multiplierCurve",get_multiplierCurve,set_multiplierCurve,true);
		addMember(l,"influenceFilter",get_influenceFilter,set_influenceFilter,true);
		addMember(l,"influenceMask",get_influenceMask,set_influenceMask,true);
		addMember(l,"influenceCount",get_influenceCount,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ParticleSystem.ExternalForcesModule),typeof(System.ValueType));
	}
}
