using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Animations_PositionConstraint : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetSources(IntPtr l) {
		try {
			UnityEngine.Animations.PositionConstraint self=(UnityEngine.Animations.PositionConstraint)checkSelf(l);
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
			UnityEngine.Animations.PositionConstraint self=(UnityEngine.Animations.PositionConstraint)checkSelf(l);
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
			UnityEngine.Animations.PositionConstraint self=(UnityEngine.Animations.PositionConstraint)checkSelf(l);
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
			UnityEngine.Animations.PositionConstraint self=(UnityEngine.Animations.PositionConstraint)checkSelf(l);
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
			UnityEngine.Animations.PositionConstraint self=(UnityEngine.Animations.PositionConstraint)checkSelf(l);
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
			UnityEngine.Animations.PositionConstraint self=(UnityEngine.Animations.PositionConstraint)checkSelf(l);
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
			UnityEngine.Animations.PositionConstraint self=(UnityEngine.Animations.PositionConstraint)checkSelf(l);
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
			UnityEngine.Animations.PositionConstraint self=(UnityEngine.Animations.PositionConstraint)checkSelf(l);
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
	static public int get_translationAtRest(IntPtr l) {
		try {
			UnityEngine.Animations.PositionConstraint self=(UnityEngine.Animations.PositionConstraint)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.translationAtRest);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_translationAtRest(IntPtr l) {
		try {
			UnityEngine.Animations.PositionConstraint self=(UnityEngine.Animations.PositionConstraint)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.translationAtRest=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_translationOffset(IntPtr l) {
		try {
			UnityEngine.Animations.PositionConstraint self=(UnityEngine.Animations.PositionConstraint)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.translationOffset);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_translationOffset(IntPtr l) {
		try {
			UnityEngine.Animations.PositionConstraint self=(UnityEngine.Animations.PositionConstraint)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.translationOffset=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_translationAxis(IntPtr l) {
		try {
			UnityEngine.Animations.PositionConstraint self=(UnityEngine.Animations.PositionConstraint)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.translationAxis);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_translationAxis(IntPtr l) {
		try {
			UnityEngine.Animations.PositionConstraint self=(UnityEngine.Animations.PositionConstraint)checkSelf(l);
			UnityEngine.Animations.Axis v;
			v = (UnityEngine.Animations.Axis)LuaDLL.luaL_checkinteger(l, 2);
			self.translationAxis=v;
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
			UnityEngine.Animations.PositionConstraint self=(UnityEngine.Animations.PositionConstraint)checkSelf(l);
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
			UnityEngine.Animations.PositionConstraint self=(UnityEngine.Animations.PositionConstraint)checkSelf(l);
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
			UnityEngine.Animations.PositionConstraint self=(UnityEngine.Animations.PositionConstraint)checkSelf(l);
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
			UnityEngine.Animations.PositionConstraint self=(UnityEngine.Animations.PositionConstraint)checkSelf(l);
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
	static public int get_sourceCount(IntPtr l) {
		try {
			UnityEngine.Animations.PositionConstraint self=(UnityEngine.Animations.PositionConstraint)checkSelf(l);
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
		getTypeTable(l,"UnityEngine.Animations.PositionConstraint");
		addMember(l,GetSources);
		addMember(l,SetSources);
		addMember(l,AddSource);
		addMember(l,RemoveSource);
		addMember(l,GetSource);
		addMember(l,SetSource);
		addMember(l,"weight",get_weight,set_weight,true);
		addMember(l,"translationAtRest",get_translationAtRest,set_translationAtRest,true);
		addMember(l,"translationOffset",get_translationOffset,set_translationOffset,true);
		addMember(l,"translationAxis",get_translationAxis,set_translationAxis,true);
		addMember(l,"constraintActive",get_constraintActive,set_constraintActive,true);
		addMember(l,"locked",get_locked,set_locked,true);
		addMember(l,"sourceCount",get_sourceCount,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.Animations.PositionConstraint),typeof(UnityEngine.Behaviour));
	}
}
