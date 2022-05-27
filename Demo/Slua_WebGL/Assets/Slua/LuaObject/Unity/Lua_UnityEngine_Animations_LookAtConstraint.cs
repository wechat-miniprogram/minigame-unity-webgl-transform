using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Animations_LookAtConstraint : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetSources(IntPtr l) {
		try {
			UnityEngine.Animations.LookAtConstraint self=(UnityEngine.Animations.LookAtConstraint)checkSelf(l);
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
			UnityEngine.Animations.LookAtConstraint self=(UnityEngine.Animations.LookAtConstraint)checkSelf(l);
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
			UnityEngine.Animations.LookAtConstraint self=(UnityEngine.Animations.LookAtConstraint)checkSelf(l);
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
			UnityEngine.Animations.LookAtConstraint self=(UnityEngine.Animations.LookAtConstraint)checkSelf(l);
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
			UnityEngine.Animations.LookAtConstraint self=(UnityEngine.Animations.LookAtConstraint)checkSelf(l);
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
			UnityEngine.Animations.LookAtConstraint self=(UnityEngine.Animations.LookAtConstraint)checkSelf(l);
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
			UnityEngine.Animations.LookAtConstraint self=(UnityEngine.Animations.LookAtConstraint)checkSelf(l);
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
			UnityEngine.Animations.LookAtConstraint self=(UnityEngine.Animations.LookAtConstraint)checkSelf(l);
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
	static public int get_roll(IntPtr l) {
		try {
			UnityEngine.Animations.LookAtConstraint self=(UnityEngine.Animations.LookAtConstraint)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.roll);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_roll(IntPtr l) {
		try {
			UnityEngine.Animations.LookAtConstraint self=(UnityEngine.Animations.LookAtConstraint)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.roll=v;
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
			UnityEngine.Animations.LookAtConstraint self=(UnityEngine.Animations.LookAtConstraint)checkSelf(l);
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
			UnityEngine.Animations.LookAtConstraint self=(UnityEngine.Animations.LookAtConstraint)checkSelf(l);
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
			UnityEngine.Animations.LookAtConstraint self=(UnityEngine.Animations.LookAtConstraint)checkSelf(l);
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
			UnityEngine.Animations.LookAtConstraint self=(UnityEngine.Animations.LookAtConstraint)checkSelf(l);
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
			UnityEngine.Animations.LookAtConstraint self=(UnityEngine.Animations.LookAtConstraint)checkSelf(l);
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
			UnityEngine.Animations.LookAtConstraint self=(UnityEngine.Animations.LookAtConstraint)checkSelf(l);
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
			UnityEngine.Animations.LookAtConstraint self=(UnityEngine.Animations.LookAtConstraint)checkSelf(l);
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
			UnityEngine.Animations.LookAtConstraint self=(UnityEngine.Animations.LookAtConstraint)checkSelf(l);
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
	static public int get_worldUpObject(IntPtr l) {
		try {
			UnityEngine.Animations.LookAtConstraint self=(UnityEngine.Animations.LookAtConstraint)checkSelf(l);
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
			UnityEngine.Animations.LookAtConstraint self=(UnityEngine.Animations.LookAtConstraint)checkSelf(l);
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
	static public int get_useUpObject(IntPtr l) {
		try {
			UnityEngine.Animations.LookAtConstraint self=(UnityEngine.Animations.LookAtConstraint)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.useUpObject);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_useUpObject(IntPtr l) {
		try {
			UnityEngine.Animations.LookAtConstraint self=(UnityEngine.Animations.LookAtConstraint)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.useUpObject=v;
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
			UnityEngine.Animations.LookAtConstraint self=(UnityEngine.Animations.LookAtConstraint)checkSelf(l);
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
		getTypeTable(l,"UnityEngine.Animations.LookAtConstraint");
		addMember(l,GetSources);
		addMember(l,SetSources);
		addMember(l,AddSource);
		addMember(l,RemoveSource);
		addMember(l,GetSource);
		addMember(l,SetSource);
		addMember(l,"weight",get_weight,set_weight,true);
		addMember(l,"roll",get_roll,set_roll,true);
		addMember(l,"constraintActive",get_constraintActive,set_constraintActive,true);
		addMember(l,"locked",get_locked,set_locked,true);
		addMember(l,"rotationAtRest",get_rotationAtRest,set_rotationAtRest,true);
		addMember(l,"rotationOffset",get_rotationOffset,set_rotationOffset,true);
		addMember(l,"worldUpObject",get_worldUpObject,set_worldUpObject,true);
		addMember(l,"useUpObject",get_useUpObject,set_useUpObject,true);
		addMember(l,"sourceCount",get_sourceCount,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.Animations.LookAtConstraint),typeof(UnityEngine.Behaviour));
	}
}
