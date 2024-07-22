using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Animations_ParentConstraint : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetTranslationOffset(IntPtr l) {
		try {
			UnityEngine.Animations.ParentConstraint self=(UnityEngine.Animations.ParentConstraint)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetTranslationOffset(a1);
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
	static public int SetTranslationOffset(IntPtr l) {
		try {
			UnityEngine.Animations.ParentConstraint self=(UnityEngine.Animations.ParentConstraint)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			self.SetTranslationOffset(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetRotationOffset(IntPtr l) {
		try {
			UnityEngine.Animations.ParentConstraint self=(UnityEngine.Animations.ParentConstraint)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetRotationOffset(a1);
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
	static public int SetRotationOffset(IntPtr l) {
		try {
			UnityEngine.Animations.ParentConstraint self=(UnityEngine.Animations.ParentConstraint)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			self.SetRotationOffset(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetSources(IntPtr l) {
		try {
			UnityEngine.Animations.ParentConstraint self=(UnityEngine.Animations.ParentConstraint)checkSelf(l);
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
			UnityEngine.Animations.ParentConstraint self=(UnityEngine.Animations.ParentConstraint)checkSelf(l);
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
			UnityEngine.Animations.ParentConstraint self=(UnityEngine.Animations.ParentConstraint)checkSelf(l);
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
			UnityEngine.Animations.ParentConstraint self=(UnityEngine.Animations.ParentConstraint)checkSelf(l);
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
			UnityEngine.Animations.ParentConstraint self=(UnityEngine.Animations.ParentConstraint)checkSelf(l);
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
			UnityEngine.Animations.ParentConstraint self=(UnityEngine.Animations.ParentConstraint)checkSelf(l);
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
			UnityEngine.Animations.ParentConstraint self=(UnityEngine.Animations.ParentConstraint)checkSelf(l);
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
			UnityEngine.Animations.ParentConstraint self=(UnityEngine.Animations.ParentConstraint)checkSelf(l);
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
			UnityEngine.Animations.ParentConstraint self=(UnityEngine.Animations.ParentConstraint)checkSelf(l);
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
			UnityEngine.Animations.ParentConstraint self=(UnityEngine.Animations.ParentConstraint)checkSelf(l);
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
			UnityEngine.Animations.ParentConstraint self=(UnityEngine.Animations.ParentConstraint)checkSelf(l);
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
			UnityEngine.Animations.ParentConstraint self=(UnityEngine.Animations.ParentConstraint)checkSelf(l);
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
			UnityEngine.Animations.ParentConstraint self=(UnityEngine.Animations.ParentConstraint)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.sourceCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_translationAtRest(IntPtr l) {
		try {
			UnityEngine.Animations.ParentConstraint self=(UnityEngine.Animations.ParentConstraint)checkSelf(l);
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
			UnityEngine.Animations.ParentConstraint self=(UnityEngine.Animations.ParentConstraint)checkSelf(l);
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
	static public int get_rotationAtRest(IntPtr l) {
		try {
			UnityEngine.Animations.ParentConstraint self=(UnityEngine.Animations.ParentConstraint)checkSelf(l);
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
			UnityEngine.Animations.ParentConstraint self=(UnityEngine.Animations.ParentConstraint)checkSelf(l);
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
	static public int get_translationOffsets(IntPtr l) {
		try {
			UnityEngine.Animations.ParentConstraint self=(UnityEngine.Animations.ParentConstraint)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.translationOffsets);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_translationOffsets(IntPtr l) {
		try {
			UnityEngine.Animations.ParentConstraint self=(UnityEngine.Animations.ParentConstraint)checkSelf(l);
			UnityEngine.Vector3[] v;
			checkArray(l,2,out v);
			self.translationOffsets=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_rotationOffsets(IntPtr l) {
		try {
			UnityEngine.Animations.ParentConstraint self=(UnityEngine.Animations.ParentConstraint)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.rotationOffsets);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_rotationOffsets(IntPtr l) {
		try {
			UnityEngine.Animations.ParentConstraint self=(UnityEngine.Animations.ParentConstraint)checkSelf(l);
			UnityEngine.Vector3[] v;
			checkArray(l,2,out v);
			self.rotationOffsets=v;
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
			UnityEngine.Animations.ParentConstraint self=(UnityEngine.Animations.ParentConstraint)checkSelf(l);
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
			UnityEngine.Animations.ParentConstraint self=(UnityEngine.Animations.ParentConstraint)checkSelf(l);
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
	static public int get_rotationAxis(IntPtr l) {
		try {
			UnityEngine.Animations.ParentConstraint self=(UnityEngine.Animations.ParentConstraint)checkSelf(l);
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
			UnityEngine.Animations.ParentConstraint self=(UnityEngine.Animations.ParentConstraint)checkSelf(l);
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
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Animations.ParentConstraint");
		addMember(l,GetTranslationOffset);
		addMember(l,SetTranslationOffset);
		addMember(l,GetRotationOffset);
		addMember(l,SetRotationOffset);
		addMember(l,GetSources);
		addMember(l,SetSources);
		addMember(l,AddSource);
		addMember(l,RemoveSource);
		addMember(l,GetSource);
		addMember(l,SetSource);
		addMember(l,"weight",get_weight,set_weight,true);
		addMember(l,"constraintActive",get_constraintActive,set_constraintActive,true);
		addMember(l,"locked",get_locked,set_locked,true);
		addMember(l,"sourceCount",get_sourceCount,null,true);
		addMember(l,"translationAtRest",get_translationAtRest,set_translationAtRest,true);
		addMember(l,"rotationAtRest",get_rotationAtRest,set_rotationAtRest,true);
		addMember(l,"translationOffsets",get_translationOffsets,set_translationOffsets,true);
		addMember(l,"rotationOffsets",get_rotationOffsets,set_rotationOffsets,true);
		addMember(l,"translationAxis",get_translationAxis,set_translationAxis,true);
		addMember(l,"rotationAxis",get_rotationAxis,set_rotationAxis,true);
		createTypeMetatable(l,null, typeof(UnityEngine.Animations.ParentConstraint),typeof(UnityEngine.Behaviour));
	}
}
