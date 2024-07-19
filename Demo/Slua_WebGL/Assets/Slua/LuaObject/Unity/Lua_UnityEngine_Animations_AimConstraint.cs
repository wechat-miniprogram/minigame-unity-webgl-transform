using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Animations_AimConstraint : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetSources(IntPtr l) {
		try {
			UnityEngine.Animations.AimConstraint self=(UnityEngine.Animations.AimConstraint)checkSelf(l);
			System.Collections.Generic.List<UnityEngine.Animations.ConstraintSource> a1;
			checkType(l,2,out a1);
			self.GetSources(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetSources(IntPtr l) {
		try {
			UnityEngine.Animations.AimConstraint self=(UnityEngine.Animations.AimConstraint)checkSelf(l);
			System.Collections.Generic.List<UnityEngine.Animations.ConstraintSource> a1;
			checkType(l,2,out a1);
			self.SetSources(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AddSource(IntPtr l) {
		try {
			UnityEngine.Animations.AimConstraint self=(UnityEngine.Animations.AimConstraint)checkSelf(l);
			UnityEngine.Animations.ConstraintSource a1;
			checkValueType(l,2,out a1);
			var ret=self.AddSource(a1);
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
	static public int RemoveSource(IntPtr l) {
		try {
			UnityEngine.Animations.AimConstraint self=(UnityEngine.Animations.AimConstraint)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			self.RemoveSource(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetSource(IntPtr l) {
		try {
			UnityEngine.Animations.AimConstraint self=(UnityEngine.Animations.AimConstraint)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetSource(a1);
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
	static public int SetSource(IntPtr l) {
		try {
			UnityEngine.Animations.AimConstraint self=(UnityEngine.Animations.AimConstraint)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			UnityEngine.Animations.ConstraintSource a2;
			checkValueType(l,3,out a2);
			self.SetSource(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_weight(IntPtr l) {
		try {
			UnityEngine.Animations.AimConstraint self=(UnityEngine.Animations.AimConstraint)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.weight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_weight(IntPtr l) {
		try {
			UnityEngine.Animations.AimConstraint self=(UnityEngine.Animations.AimConstraint)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.weight=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_constraintActive(IntPtr l) {
		try {
			UnityEngine.Animations.AimConstraint self=(UnityEngine.Animations.AimConstraint)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.constraintActive);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_constraintActive(IntPtr l) {
		try {
			UnityEngine.Animations.AimConstraint self=(UnityEngine.Animations.AimConstraint)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.constraintActive=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_locked(IntPtr l) {
		try {
			UnityEngine.Animations.AimConstraint self=(UnityEngine.Animations.AimConstraint)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.locked);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_locked(IntPtr l) {
		try {
			UnityEngine.Animations.AimConstraint self=(UnityEngine.Animations.AimConstraint)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.locked=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_rotationAtRest(IntPtr l) {
		try {
			UnityEngine.Animations.AimConstraint self=(UnityEngine.Animations.AimConstraint)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.rotationAtRest);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_rotationAtRest(IntPtr l) {
		try {
			UnityEngine.Animations.AimConstraint self=(UnityEngine.Animations.AimConstraint)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.rotationAtRest=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_rotationOffset(IntPtr l) {
		try {
			UnityEngine.Animations.AimConstraint self=(UnityEngine.Animations.AimConstraint)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.rotationOffset);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_rotationOffset(IntPtr l) {
		try {
			UnityEngine.Animations.AimConstraint self=(UnityEngine.Animations.AimConstraint)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.rotationOffset=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_rotationAxis(IntPtr l) {
		try {
			UnityEngine.Animations.AimConstraint self=(UnityEngine.Animations.AimConstraint)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.rotationAxis);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_rotationAxis(IntPtr l) {
		try {
			UnityEngine.Animations.AimConstraint self=(UnityEngine.Animations.AimConstraint)checkSelf(l);
			UnityEngine.Animations.Axis v;
			v = (UnityEngine.Animations.Axis)LuaDLL.luaL_checkinteger(l, 2);
			self.rotationAxis=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_aimVector(IntPtr l) {
		try {
			UnityEngine.Animations.AimConstraint self=(UnityEngine.Animations.AimConstraint)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.aimVector);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_aimVector(IntPtr l) {
		try {
			UnityEngine.Animations.AimConstraint self=(UnityEngine.Animations.AimConstraint)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.aimVector=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_upVector(IntPtr l) {
		try {
			UnityEngine.Animations.AimConstraint self=(UnityEngine.Animations.AimConstraint)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.upVector);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_upVector(IntPtr l) {
		try {
			UnityEngine.Animations.AimConstraint self=(UnityEngine.Animations.AimConstraint)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.upVector=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_worldUpVector(IntPtr l) {
		try {
			UnityEngine.Animations.AimConstraint self=(UnityEngine.Animations.AimConstraint)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.worldUpVector);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_worldUpVector(IntPtr l) {
		try {
			UnityEngine.Animations.AimConstraint self=(UnityEngine.Animations.AimConstraint)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.worldUpVector=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_worldUpObject(IntPtr l) {
		try {
			UnityEngine.Animations.AimConstraint self=(UnityEngine.Animations.AimConstraint)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.worldUpObject);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_worldUpObject(IntPtr l) {
		try {
			UnityEngine.Animations.AimConstraint self=(UnityEngine.Animations.AimConstraint)checkSelf(l);
			UnityEngine.Transform v;
			checkType(l,2,out v);
			self.worldUpObject=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_worldUpType(IntPtr l) {
		try {
			UnityEngine.Animations.AimConstraint self=(UnityEngine.Animations.AimConstraint)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.worldUpType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_worldUpType(IntPtr l) {
		try {
			UnityEngine.Animations.AimConstraint self=(UnityEngine.Animations.AimConstraint)checkSelf(l);
			UnityEngine.Animations.AimConstraint.WorldUpType v;
			v = (UnityEngine.Animations.AimConstraint.WorldUpType)LuaDLL.luaL_checkinteger(l, 2);
			self.worldUpType=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_sourceCount(IntPtr l) {
		try {
			UnityEngine.Animations.AimConstraint self=(UnityEngine.Animations.AimConstraint)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.sourceCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Animations.AimConstraint");
		addMember(l,GetSources);
		addMember(l,SetSources);
		addMember(l,AddSource);
		addMember(l,RemoveSource);
		addMember(l,GetSource);
		addMember(l,SetSource);
		addMember(l,"weight",get_weight,set_weight,true);
		addMember(l,"constraintActive",get_constraintActive,set_constraintActive,true);
		addMember(l,"locked",get_locked,set_locked,true);
		addMember(l,"rotationAtRest",get_rotationAtRest,set_rotationAtRest,true);
		addMember(l,"rotationOffset",get_rotationOffset,set_rotationOffset,true);
		addMember(l,"rotationAxis",get_rotationAxis,set_rotationAxis,true);
		addMember(l,"aimVector",get_aimVector,set_aimVector,true);
		addMember(l,"upVector",get_upVector,set_upVector,true);
		addMember(l,"worldUpVector",get_worldUpVector,set_worldUpVector,true);
		addMember(l,"worldUpObject",get_worldUpObject,set_worldUpObject,true);
		addMember(l,"worldUpType",get_worldUpType,set_worldUpType,true);
		addMember(l,"sourceCount",get_sourceCount,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.Animations.AimConstraint),typeof(UnityEngine.Behaviour));
	}
}
