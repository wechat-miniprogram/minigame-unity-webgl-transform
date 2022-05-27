using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PhysicsScene : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.PhysicsScene o;
			o=new UnityEngine.PhysicsScene();
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
	static public int IsValid(IntPtr l) {
		try {
			UnityEngine.PhysicsScene self;
			checkValueType(l,1,out self);
			var ret=self.IsValid();
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
	static public int IsEmpty(IntPtr l) {
		try {
			UnityEngine.PhysicsScene self;
			checkValueType(l,1,out self);
			var ret=self.IsEmpty();
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
	static public int Simulate(IntPtr l) {
		try {
			UnityEngine.PhysicsScene self;
			checkValueType(l,1,out self);
			System.Single a1;
			checkType(l,2,out a1);
			self.Simulate(a1);
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
	static public int Raycast(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==6){
				UnityEngine.PhysicsScene self;
				checkValueType(l,1,out self);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				UnityEngine.QueryTriggerInteraction a5;
				a5 = (UnityEngine.QueryTriggerInteraction)LuaDLL.luaL_checkinteger(l, 6);
				var ret=self.Raycast(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector3),typeof(UnityEngine.Vector3),typeof(LuaOut),typeof(float),typeof(int),typeof(UnityEngine.QueryTriggerInteraction))){
				UnityEngine.PhysicsScene self;
				checkValueType(l,1,out self);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,3,out a2);
				UnityEngine.RaycastHit a3;
				System.Single a4;
				checkType(l,5,out a4);
				System.Int32 a5;
				checkType(l,6,out a5);
				UnityEngine.QueryTriggerInteraction a6;
				a6 = (UnityEngine.QueryTriggerInteraction)LuaDLL.luaL_checkinteger(l, 7);
				var ret=self.Raycast(a1,a2,out a3,a4,a5,a6);
				pushValue(l,true);
				pushValue(l,ret);
				pushValue(l,a3);
				return 3;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector3),typeof(UnityEngine.Vector3),typeof(UnityEngine.RaycastHit[]),typeof(float),typeof(int),typeof(UnityEngine.QueryTriggerInteraction))){
				UnityEngine.PhysicsScene self;
				checkValueType(l,1,out self);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,3,out a2);
				UnityEngine.RaycastHit[] a3;
				checkArray(l,4,out a3);
				System.Single a4;
				checkType(l,5,out a4);
				System.Int32 a5;
				checkType(l,6,out a5);
				UnityEngine.QueryTriggerInteraction a6;
				a6 = (UnityEngine.QueryTriggerInteraction)LuaDLL.luaL_checkinteger(l, 7);
				var ret=self.Raycast(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Raycast to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CapsuleCast(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(UnityEngine.Vector3),typeof(UnityEngine.Vector3),typeof(float),typeof(UnityEngine.Vector3),typeof(LuaOut),typeof(float),typeof(int),typeof(UnityEngine.QueryTriggerInteraction))){
				UnityEngine.PhysicsScene self;
				checkValueType(l,1,out self);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				UnityEngine.Vector3 a4;
				checkType(l,5,out a4);
				UnityEngine.RaycastHit a5;
				System.Single a6;
				checkType(l,7,out a6);
				System.Int32 a7;
				checkType(l,8,out a7);
				UnityEngine.QueryTriggerInteraction a8;
				a8 = (UnityEngine.QueryTriggerInteraction)LuaDLL.luaL_checkinteger(l, 9);
				var ret=self.CapsuleCast(a1,a2,a3,a4,out a5,a6,a7,a8);
				pushValue(l,true);
				pushValue(l,ret);
				pushValue(l,a5);
				return 3;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector3),typeof(UnityEngine.Vector3),typeof(float),typeof(UnityEngine.Vector3),typeof(UnityEngine.RaycastHit[]),typeof(float),typeof(int),typeof(UnityEngine.QueryTriggerInteraction))){
				UnityEngine.PhysicsScene self;
				checkValueType(l,1,out self);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				UnityEngine.Vector3 a4;
				checkType(l,5,out a4);
				UnityEngine.RaycastHit[] a5;
				checkArray(l,6,out a5);
				System.Single a6;
				checkType(l,7,out a6);
				System.Int32 a7;
				checkType(l,8,out a7);
				UnityEngine.QueryTriggerInteraction a8;
				a8 = (UnityEngine.QueryTriggerInteraction)LuaDLL.luaL_checkinteger(l, 9);
				var ret=self.CapsuleCast(a1,a2,a3,a4,a5,a6,a7,a8);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function CapsuleCast to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OverlapCapsule(IntPtr l) {
		try {
			UnityEngine.PhysicsScene self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			System.Single a3;
			checkType(l,4,out a3);
			UnityEngine.Collider[] a4;
			checkArray(l,5,out a4);
			System.Int32 a5;
			checkType(l,6,out a5);
			UnityEngine.QueryTriggerInteraction a6;
			a6 = (UnityEngine.QueryTriggerInteraction)LuaDLL.luaL_checkinteger(l, 7);
			var ret=self.OverlapCapsule(a1,a2,a3,a4,a5,a6);
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
	static public int SphereCast(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(UnityEngine.Vector3),typeof(float),typeof(UnityEngine.Vector3),typeof(LuaOut),typeof(float),typeof(int),typeof(UnityEngine.QueryTriggerInteraction))){
				UnityEngine.PhysicsScene self;
				checkValueType(l,1,out self);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				UnityEngine.Vector3 a3;
				checkType(l,4,out a3);
				UnityEngine.RaycastHit a4;
				System.Single a5;
				checkType(l,6,out a5);
				System.Int32 a6;
				checkType(l,7,out a6);
				UnityEngine.QueryTriggerInteraction a7;
				a7 = (UnityEngine.QueryTriggerInteraction)LuaDLL.luaL_checkinteger(l, 8);
				var ret=self.SphereCast(a1,a2,a3,out a4,a5,a6,a7);
				pushValue(l,true);
				pushValue(l,ret);
				pushValue(l,a4);
				return 3;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector3),typeof(float),typeof(UnityEngine.Vector3),typeof(UnityEngine.RaycastHit[]),typeof(float),typeof(int),typeof(UnityEngine.QueryTriggerInteraction))){
				UnityEngine.PhysicsScene self;
				checkValueType(l,1,out self);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				UnityEngine.Vector3 a3;
				checkType(l,4,out a3);
				UnityEngine.RaycastHit[] a4;
				checkArray(l,5,out a4);
				System.Single a5;
				checkType(l,6,out a5);
				System.Int32 a6;
				checkType(l,7,out a6);
				UnityEngine.QueryTriggerInteraction a7;
				a7 = (UnityEngine.QueryTriggerInteraction)LuaDLL.luaL_checkinteger(l, 8);
				var ret=self.SphereCast(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SphereCast to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OverlapSphere(IntPtr l) {
		try {
			UnityEngine.PhysicsScene self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			UnityEngine.Collider[] a3;
			checkArray(l,4,out a3);
			System.Int32 a4;
			checkType(l,5,out a4);
			UnityEngine.QueryTriggerInteraction a5;
			a5 = (UnityEngine.QueryTriggerInteraction)LuaDLL.luaL_checkinteger(l, 6);
			var ret=self.OverlapSphere(a1,a2,a3,a4,a5);
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
	static public int BoxCast(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(UnityEngine.Vector3),typeof(UnityEngine.Vector3),typeof(UnityEngine.Vector3),typeof(LuaOut))){
				UnityEngine.PhysicsScene self;
				checkValueType(l,1,out self);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,3,out a2);
				UnityEngine.Vector3 a3;
				checkType(l,4,out a3);
				UnityEngine.RaycastHit a4;
				var ret=self.BoxCast(a1,a2,a3,out a4);
				pushValue(l,true);
				pushValue(l,ret);
				pushValue(l,a4);
				return 3;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector3),typeof(UnityEngine.Vector3),typeof(UnityEngine.Vector3),typeof(UnityEngine.RaycastHit[]))){
				UnityEngine.PhysicsScene self;
				checkValueType(l,1,out self);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,3,out a2);
				UnityEngine.Vector3 a3;
				checkType(l,4,out a3);
				UnityEngine.RaycastHit[] a4;
				checkArray(l,5,out a4);
				var ret=self.BoxCast(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector3),typeof(UnityEngine.Vector3),typeof(UnityEngine.Vector3),typeof(LuaOut),typeof(UnityEngine.Quaternion),typeof(float),typeof(int),typeof(UnityEngine.QueryTriggerInteraction))){
				UnityEngine.PhysicsScene self;
				checkValueType(l,1,out self);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,3,out a2);
				UnityEngine.Vector3 a3;
				checkType(l,4,out a3);
				UnityEngine.RaycastHit a4;
				UnityEngine.Quaternion a5;
				checkType(l,6,out a5);
				System.Single a6;
				checkType(l,7,out a6);
				System.Int32 a7;
				checkType(l,8,out a7);
				UnityEngine.QueryTriggerInteraction a8;
				a8 = (UnityEngine.QueryTriggerInteraction)LuaDLL.luaL_checkinteger(l, 9);
				var ret=self.BoxCast(a1,a2,a3,out a4,a5,a6,a7,a8);
				pushValue(l,true);
				pushValue(l,ret);
				pushValue(l,a4);
				return 3;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector3),typeof(UnityEngine.Vector3),typeof(UnityEngine.Vector3),typeof(UnityEngine.RaycastHit[]),typeof(UnityEngine.Quaternion),typeof(float),typeof(int),typeof(UnityEngine.QueryTriggerInteraction))){
				UnityEngine.PhysicsScene self;
				checkValueType(l,1,out self);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,3,out a2);
				UnityEngine.Vector3 a3;
				checkType(l,4,out a3);
				UnityEngine.RaycastHit[] a4;
				checkArray(l,5,out a4);
				UnityEngine.Quaternion a5;
				checkType(l,6,out a5);
				System.Single a6;
				checkType(l,7,out a6);
				System.Int32 a7;
				checkType(l,8,out a7);
				UnityEngine.QueryTriggerInteraction a8;
				a8 = (UnityEngine.QueryTriggerInteraction)LuaDLL.luaL_checkinteger(l, 9);
				var ret=self.BoxCast(a1,a2,a3,a4,a5,a6,a7,a8);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function BoxCast to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OverlapBox(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==4){
				UnityEngine.PhysicsScene self;
				checkValueType(l,1,out self);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,3,out a2);
				UnityEngine.Collider[] a3;
				checkArray(l,4,out a3);
				var ret=self.OverlapBox(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==7){
				UnityEngine.PhysicsScene self;
				checkValueType(l,1,out self);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,3,out a2);
				UnityEngine.Collider[] a3;
				checkArray(l,4,out a3);
				UnityEngine.Quaternion a4;
				checkType(l,5,out a4);
				System.Int32 a5;
				checkType(l,6,out a5);
				UnityEngine.QueryTriggerInteraction a6;
				a6 = (UnityEngine.QueryTriggerInteraction)LuaDLL.luaL_checkinteger(l, 7);
				var ret=self.OverlapBox(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function OverlapBox to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int op_Equality(IntPtr l) {
		try {
			UnityEngine.PhysicsScene a1;
			checkValueType(l,1,out a1);
			UnityEngine.PhysicsScene a2;
			checkValueType(l,2,out a2);
			var ret=(a1==a2);
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
	static public int op_Inequality(IntPtr l) {
		try {
			UnityEngine.PhysicsScene a1;
			checkValueType(l,1,out a1);
			UnityEngine.PhysicsScene a2;
			checkValueType(l,2,out a2);
			var ret=(a1!=a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.PhysicsScene");
		addMember(l,IsValid);
		addMember(l,IsEmpty);
		addMember(l,Simulate);
		addMember(l,Raycast);
		addMember(l,CapsuleCast);
		addMember(l,OverlapCapsule);
		addMember(l,SphereCast);
		addMember(l,OverlapSphere);
		addMember(l,BoxCast);
		addMember(l,OverlapBox);
		addMember(l,op_Equality);
		addMember(l,op_Inequality);
		createTypeMetatable(l,constructor, typeof(UnityEngine.PhysicsScene),typeof(System.ValueType));
	}
}
