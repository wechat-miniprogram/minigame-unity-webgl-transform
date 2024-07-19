using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Animations_MuscleHandle : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			UnityEngine.Animations.MuscleHandle o;
			if(matchType(l,argc,2,typeof(UnityEngine.BodyDof))){
				UnityEngine.BodyDof a1;
				a1 = (UnityEngine.BodyDof)LuaDLL.luaL_checkinteger(l, 2);
				o=new UnityEngine.Animations.MuscleHandle(a1);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.HeadDof))){
				UnityEngine.HeadDof a1;
				a1 = (UnityEngine.HeadDof)LuaDLL.luaL_checkinteger(l, 2);
				o=new UnityEngine.Animations.MuscleHandle(a1);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.HumanPartDof),typeof(UnityEngine.LegDof))){
				UnityEngine.HumanPartDof a1;
				a1 = (UnityEngine.HumanPartDof)LuaDLL.luaL_checkinteger(l, 2);
				UnityEngine.LegDof a2;
				a2 = (UnityEngine.LegDof)LuaDLL.luaL_checkinteger(l, 3);
				o=new UnityEngine.Animations.MuscleHandle(a1,a2);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.HumanPartDof),typeof(UnityEngine.ArmDof))){
				UnityEngine.HumanPartDof a1;
				a1 = (UnityEngine.HumanPartDof)LuaDLL.luaL_checkinteger(l, 2);
				UnityEngine.ArmDof a2;
				a2 = (UnityEngine.ArmDof)LuaDLL.luaL_checkinteger(l, 3);
				o=new UnityEngine.Animations.MuscleHandle(a1,a2);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.HumanPartDof),typeof(UnityEngine.FingerDof))){
				UnityEngine.HumanPartDof a1;
				a1 = (UnityEngine.HumanPartDof)LuaDLL.luaL_checkinteger(l, 2);
				UnityEngine.FingerDof a2;
				a2 = (UnityEngine.FingerDof)LuaDLL.luaL_checkinteger(l, 3);
				o=new UnityEngine.Animations.MuscleHandle(a1,a2);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==0){
				o=new UnityEngine.Animations.MuscleHandle();
				pushValue(l,true);
				pushObject(l,o);
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
	static public int GetMuscleHandles_s(IntPtr l) {
		try {
			UnityEngine.Animations.MuscleHandle[] a1;
			checkArray(l,1,out a1);
			UnityEngine.Animations.MuscleHandle.GetMuscleHandles(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_humanPartDof(IntPtr l) {
		try {
			UnityEngine.Animations.MuscleHandle self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.humanPartDof);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_dof(IntPtr l) {
		try {
			UnityEngine.Animations.MuscleHandle self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.dof);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_name(IntPtr l) {
		try {
			UnityEngine.Animations.MuscleHandle self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.name);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_muscleHandleCount(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Animations.MuscleHandle.muscleHandleCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Animations.MuscleHandle");
		addMember(l,GetMuscleHandles_s);
		addMember(l,"humanPartDof",get_humanPartDof,null,true);
		addMember(l,"dof",get_dof,null,true);
		addMember(l,"name",get_name,null,true);
		addMember(l,"muscleHandleCount",get_muscleHandleCount,null,false);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Animations.MuscleHandle),typeof(System.ValueType));
	}
}
