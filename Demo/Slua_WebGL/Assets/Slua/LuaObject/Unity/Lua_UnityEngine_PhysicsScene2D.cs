using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PhysicsScene2D : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.PhysicsScene2D o;
			o=new UnityEngine.PhysicsScene2D();
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
			UnityEngine.PhysicsScene2D self;
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
			UnityEngine.PhysicsScene2D self;
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
			UnityEngine.PhysicsScene2D self;
			checkValueType(l,1,out self);
			System.Single a1;
			checkType(l,2,out a1);
			var ret=self.Simulate(a1);
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
	static public int Linecast(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(int))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				var ret=self.Linecast(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(UnityEngine.ContactFilter2D))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				UnityEngine.ContactFilter2D a3;
				checkValueType(l,4,out a3);
				var ret=self.Linecast(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(UnityEngine.RaycastHit2D[]),typeof(int))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				UnityEngine.RaycastHit2D[] a3;
				checkArray(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				var ret=self.Linecast(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.RaycastHit2D[]))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				UnityEngine.ContactFilter2D a3;
				checkValueType(l,4,out a3);
				UnityEngine.RaycastHit2D[] a4;
				checkArray(l,5,out a4);
				var ret=self.Linecast(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(UnityEngine.ContactFilter2D),typeof(List<UnityEngine.RaycastHit2D>))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				UnityEngine.ContactFilter2D a3;
				checkValueType(l,4,out a3);
				System.Collections.Generic.List<UnityEngine.RaycastHit2D> a4;
				checkType(l,5,out a4);
				var ret=self.Linecast(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Linecast to call");
			return 2;
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
			if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(float),typeof(int))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				var ret=self.Raycast(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.ContactFilter2D))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				UnityEngine.ContactFilter2D a4;
				checkValueType(l,5,out a4);
				var ret=self.Raycast(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.RaycastHit2D[]),typeof(int))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				UnityEngine.RaycastHit2D[] a4;
				checkArray(l,5,out a4);
				System.Int32 a5;
				checkType(l,6,out a5);
				var ret=self.Raycast(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.RaycastHit2D[]))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				UnityEngine.ContactFilter2D a4;
				checkValueType(l,5,out a4);
				UnityEngine.RaycastHit2D[] a5;
				checkArray(l,6,out a5);
				var ret=self.Raycast(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.ContactFilter2D),typeof(List<UnityEngine.RaycastHit2D>))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				UnityEngine.ContactFilter2D a4;
				checkValueType(l,5,out a4);
				System.Collections.Generic.List<UnityEngine.RaycastHit2D> a5;
				checkType(l,6,out a5);
				var ret=self.Raycast(a1,a2,a3,a4,a5);
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
	static public int CircleCast(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.Vector2),typeof(float),typeof(int))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				UnityEngine.Vector2 a3;
				checkType(l,4,out a3);
				System.Single a4;
				checkType(l,5,out a4);
				System.Int32 a5;
				checkType(l,6,out a5);
				var ret=self.CircleCast(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.ContactFilter2D))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				UnityEngine.Vector2 a3;
				checkType(l,4,out a3);
				System.Single a4;
				checkType(l,5,out a4);
				UnityEngine.ContactFilter2D a5;
				checkValueType(l,6,out a5);
				var ret=self.CircleCast(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.RaycastHit2D[]),typeof(int))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				UnityEngine.Vector2 a3;
				checkType(l,4,out a3);
				System.Single a4;
				checkType(l,5,out a4);
				UnityEngine.RaycastHit2D[] a5;
				checkArray(l,6,out a5);
				System.Int32 a6;
				checkType(l,7,out a6);
				var ret=self.CircleCast(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.RaycastHit2D[]))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				UnityEngine.Vector2 a3;
				checkType(l,4,out a3);
				System.Single a4;
				checkType(l,5,out a4);
				UnityEngine.ContactFilter2D a5;
				checkValueType(l,6,out a5);
				UnityEngine.RaycastHit2D[] a6;
				checkArray(l,7,out a6);
				var ret=self.CircleCast(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.ContactFilter2D),typeof(List<UnityEngine.RaycastHit2D>))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				UnityEngine.Vector2 a3;
				checkType(l,4,out a3);
				System.Single a4;
				checkType(l,5,out a4);
				UnityEngine.ContactFilter2D a5;
				checkValueType(l,6,out a5);
				System.Collections.Generic.List<UnityEngine.RaycastHit2D> a6;
				checkType(l,7,out a6);
				var ret=self.CircleCast(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function CircleCast to call");
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
			if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.Vector2),typeof(float),typeof(int))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				UnityEngine.Vector2 a4;
				checkType(l,5,out a4);
				System.Single a5;
				checkType(l,6,out a5);
				System.Int32 a6;
				checkType(l,7,out a6);
				var ret=self.BoxCast(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.ContactFilter2D))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				UnityEngine.Vector2 a4;
				checkType(l,5,out a4);
				System.Single a5;
				checkType(l,6,out a5);
				UnityEngine.ContactFilter2D a6;
				checkValueType(l,7,out a6);
				var ret=self.BoxCast(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.RaycastHit2D[]),typeof(int))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				UnityEngine.Vector2 a4;
				checkType(l,5,out a4);
				System.Single a5;
				checkType(l,6,out a5);
				UnityEngine.RaycastHit2D[] a6;
				checkArray(l,7,out a6);
				System.Int32 a7;
				checkType(l,8,out a7);
				var ret=self.BoxCast(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.RaycastHit2D[]))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				UnityEngine.Vector2 a4;
				checkType(l,5,out a4);
				System.Single a5;
				checkType(l,6,out a5);
				UnityEngine.ContactFilter2D a6;
				checkValueType(l,7,out a6);
				UnityEngine.RaycastHit2D[] a7;
				checkArray(l,8,out a7);
				var ret=self.BoxCast(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.ContactFilter2D),typeof(List<UnityEngine.RaycastHit2D>))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				UnityEngine.Vector2 a4;
				checkType(l,5,out a4);
				System.Single a5;
				checkType(l,6,out a5);
				UnityEngine.ContactFilter2D a6;
				checkValueType(l,7,out a6);
				System.Collections.Generic.List<UnityEngine.RaycastHit2D> a7;
				checkType(l,8,out a7);
				var ret=self.BoxCast(a1,a2,a3,a4,a5,a6,a7);
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
	static public int CapsuleCast(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(UnityEngine.CapsuleDirection2D),typeof(float),typeof(UnityEngine.Vector2),typeof(float),typeof(int))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				UnityEngine.CapsuleDirection2D a3;
				a3 = (UnityEngine.CapsuleDirection2D)LuaDLL.luaL_checkinteger(l, 4);
				System.Single a4;
				checkType(l,5,out a4);
				UnityEngine.Vector2 a5;
				checkType(l,6,out a5);
				System.Single a6;
				checkType(l,7,out a6);
				System.Int32 a7;
				checkType(l,8,out a7);
				var ret=self.CapsuleCast(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(UnityEngine.CapsuleDirection2D),typeof(float),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.ContactFilter2D))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				UnityEngine.CapsuleDirection2D a3;
				a3 = (UnityEngine.CapsuleDirection2D)LuaDLL.luaL_checkinteger(l, 4);
				System.Single a4;
				checkType(l,5,out a4);
				UnityEngine.Vector2 a5;
				checkType(l,6,out a5);
				System.Single a6;
				checkType(l,7,out a6);
				UnityEngine.ContactFilter2D a7;
				checkValueType(l,8,out a7);
				var ret=self.CapsuleCast(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(UnityEngine.CapsuleDirection2D),typeof(float),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.RaycastHit2D[]),typeof(int))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				UnityEngine.CapsuleDirection2D a3;
				a3 = (UnityEngine.CapsuleDirection2D)LuaDLL.luaL_checkinteger(l, 4);
				System.Single a4;
				checkType(l,5,out a4);
				UnityEngine.Vector2 a5;
				checkType(l,6,out a5);
				System.Single a6;
				checkType(l,7,out a6);
				UnityEngine.RaycastHit2D[] a7;
				checkArray(l,8,out a7);
				System.Int32 a8;
				checkType(l,9,out a8);
				var ret=self.CapsuleCast(a1,a2,a3,a4,a5,a6,a7,a8);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(UnityEngine.CapsuleDirection2D),typeof(float),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.RaycastHit2D[]))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				UnityEngine.CapsuleDirection2D a3;
				a3 = (UnityEngine.CapsuleDirection2D)LuaDLL.luaL_checkinteger(l, 4);
				System.Single a4;
				checkType(l,5,out a4);
				UnityEngine.Vector2 a5;
				checkType(l,6,out a5);
				System.Single a6;
				checkType(l,7,out a6);
				UnityEngine.ContactFilter2D a7;
				checkValueType(l,8,out a7);
				UnityEngine.RaycastHit2D[] a8;
				checkArray(l,9,out a8);
				var ret=self.CapsuleCast(a1,a2,a3,a4,a5,a6,a7,a8);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(UnityEngine.CapsuleDirection2D),typeof(float),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.ContactFilter2D),typeof(List<UnityEngine.RaycastHit2D>))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				UnityEngine.CapsuleDirection2D a3;
				a3 = (UnityEngine.CapsuleDirection2D)LuaDLL.luaL_checkinteger(l, 4);
				System.Single a4;
				checkType(l,5,out a4);
				UnityEngine.Vector2 a5;
				checkType(l,6,out a5);
				System.Single a6;
				checkType(l,7,out a6);
				UnityEngine.ContactFilter2D a7;
				checkValueType(l,8,out a7);
				System.Collections.Generic.List<UnityEngine.RaycastHit2D> a8;
				checkType(l,9,out a8);
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
	static public int GetRayIntersection(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==4){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Ray a1;
				checkValueType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				var ret=self.GetRayIntersection(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==5){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Ray a1;
				checkValueType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				UnityEngine.RaycastHit2D[] a3;
				checkArray(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				var ret=self.GetRayIntersection(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetRayIntersection to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OverlapPoint(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(int))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				var ret=self.OverlapPoint(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.ContactFilter2D))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.ContactFilter2D a2;
				checkValueType(l,3,out a2);
				var ret=self.OverlapPoint(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Collider2D[]),typeof(int))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Collider2D[] a2;
				checkArray(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				var ret=self.OverlapPoint(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.Collider2D[]))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.ContactFilter2D a2;
				checkValueType(l,3,out a2);
				UnityEngine.Collider2D[] a3;
				checkArray(l,4,out a3);
				var ret=self.OverlapPoint(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.ContactFilter2D),typeof(List<UnityEngine.Collider2D>))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.ContactFilter2D a2;
				checkValueType(l,3,out a2);
				System.Collections.Generic.List<UnityEngine.Collider2D> a3;
				checkType(l,4,out a3);
				var ret=self.OverlapPoint(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function OverlapPoint to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OverlapCircle(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(float),typeof(int))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				var ret=self.OverlapCircle(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.ContactFilter2D))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				UnityEngine.ContactFilter2D a3;
				checkValueType(l,4,out a3);
				var ret=self.OverlapCircle(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.Collider2D[]),typeof(int))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				UnityEngine.Collider2D[] a3;
				checkArray(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				var ret=self.OverlapCircle(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.Collider2D[]))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				UnityEngine.ContactFilter2D a3;
				checkValueType(l,4,out a3);
				UnityEngine.Collider2D[] a4;
				checkArray(l,5,out a4);
				var ret=self.OverlapCircle(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.ContactFilter2D),typeof(List<UnityEngine.Collider2D>))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				UnityEngine.ContactFilter2D a3;
				checkValueType(l,4,out a3);
				System.Collections.Generic.List<UnityEngine.Collider2D> a4;
				checkType(l,5,out a4);
				var ret=self.OverlapCircle(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function OverlapCircle to call");
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
			if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(float),typeof(int))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				var ret=self.OverlapBox(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.ContactFilter2D))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				UnityEngine.ContactFilter2D a4;
				checkValueType(l,5,out a4);
				var ret=self.OverlapBox(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.Collider2D[]),typeof(int))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				UnityEngine.Collider2D[] a4;
				checkArray(l,5,out a4);
				System.Int32 a5;
				checkType(l,6,out a5);
				var ret=self.OverlapBox(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.Collider2D[]))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				UnityEngine.ContactFilter2D a4;
				checkValueType(l,5,out a4);
				UnityEngine.Collider2D[] a5;
				checkArray(l,6,out a5);
				var ret=self.OverlapBox(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(float),typeof(UnityEngine.ContactFilter2D),typeof(List<UnityEngine.Collider2D>))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				UnityEngine.ContactFilter2D a4;
				checkValueType(l,5,out a4);
				System.Collections.Generic.List<UnityEngine.Collider2D> a5;
				checkType(l,6,out a5);
				var ret=self.OverlapBox(a1,a2,a3,a4,a5);
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
	static public int OverlapArea(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(int))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				var ret=self.OverlapArea(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(UnityEngine.ContactFilter2D))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				UnityEngine.ContactFilter2D a3;
				checkValueType(l,4,out a3);
				var ret=self.OverlapArea(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(UnityEngine.Collider2D[]),typeof(int))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				UnityEngine.Collider2D[] a3;
				checkArray(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				var ret=self.OverlapArea(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.Collider2D[]))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				UnityEngine.ContactFilter2D a3;
				checkValueType(l,4,out a3);
				UnityEngine.Collider2D[] a4;
				checkArray(l,5,out a4);
				var ret=self.OverlapArea(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(UnityEngine.ContactFilter2D),typeof(List<UnityEngine.Collider2D>))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				UnityEngine.ContactFilter2D a3;
				checkValueType(l,4,out a3);
				System.Collections.Generic.List<UnityEngine.Collider2D> a4;
				checkType(l,5,out a4);
				var ret=self.OverlapArea(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function OverlapArea to call");
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
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(UnityEngine.CapsuleDirection2D),typeof(float),typeof(int))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				UnityEngine.CapsuleDirection2D a3;
				a3 = (UnityEngine.CapsuleDirection2D)LuaDLL.luaL_checkinteger(l, 4);
				System.Single a4;
				checkType(l,5,out a4);
				System.Int32 a5;
				checkType(l,6,out a5);
				var ret=self.OverlapCapsule(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(UnityEngine.CapsuleDirection2D),typeof(float),typeof(UnityEngine.ContactFilter2D))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				UnityEngine.CapsuleDirection2D a3;
				a3 = (UnityEngine.CapsuleDirection2D)LuaDLL.luaL_checkinteger(l, 4);
				System.Single a4;
				checkType(l,5,out a4);
				UnityEngine.ContactFilter2D a5;
				checkValueType(l,6,out a5);
				var ret=self.OverlapCapsule(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(UnityEngine.CapsuleDirection2D),typeof(float),typeof(UnityEngine.Collider2D[]),typeof(int))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				UnityEngine.CapsuleDirection2D a3;
				a3 = (UnityEngine.CapsuleDirection2D)LuaDLL.luaL_checkinteger(l, 4);
				System.Single a4;
				checkType(l,5,out a4);
				UnityEngine.Collider2D[] a5;
				checkArray(l,6,out a5);
				System.Int32 a6;
				checkType(l,7,out a6);
				var ret=self.OverlapCapsule(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(UnityEngine.CapsuleDirection2D),typeof(float),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.Collider2D[]))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				UnityEngine.CapsuleDirection2D a3;
				a3 = (UnityEngine.CapsuleDirection2D)LuaDLL.luaL_checkinteger(l, 4);
				System.Single a4;
				checkType(l,5,out a4);
				UnityEngine.ContactFilter2D a5;
				checkValueType(l,6,out a5);
				UnityEngine.Collider2D[] a6;
				checkArray(l,7,out a6);
				var ret=self.OverlapCapsule(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2),typeof(UnityEngine.CapsuleDirection2D),typeof(float),typeof(UnityEngine.ContactFilter2D),typeof(List<UnityEngine.Collider2D>))){
				UnityEngine.PhysicsScene2D self;
				checkValueType(l,1,out self);
				UnityEngine.Vector2 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,3,out a2);
				UnityEngine.CapsuleDirection2D a3;
				a3 = (UnityEngine.CapsuleDirection2D)LuaDLL.luaL_checkinteger(l, 4);
				System.Single a4;
				checkType(l,5,out a4);
				UnityEngine.ContactFilter2D a5;
				checkValueType(l,6,out a5);
				System.Collections.Generic.List<UnityEngine.Collider2D> a6;
				checkType(l,7,out a6);
				var ret=self.OverlapCapsule(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function OverlapCapsule to call");
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
			UnityEngine.PhysicsScene2D a1;
			checkValueType(l,1,out a1);
			UnityEngine.PhysicsScene2D a2;
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
			UnityEngine.PhysicsScene2D a1;
			checkValueType(l,1,out a1);
			UnityEngine.PhysicsScene2D a2;
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
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OverlapCollider_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Collider2D),typeof(UnityEngine.Collider2D[]),typeof(int))){
				UnityEngine.Collider2D a1;
				checkType(l,1,out a1);
				UnityEngine.Collider2D[] a2;
				checkArray(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.PhysicsScene2D.OverlapCollider(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Collider2D),typeof(UnityEngine.ContactFilter2D),typeof(UnityEngine.Collider2D[]))){
				UnityEngine.Collider2D a1;
				checkType(l,1,out a1);
				UnityEngine.ContactFilter2D a2;
				checkValueType(l,2,out a2);
				UnityEngine.Collider2D[] a3;
				checkArray(l,3,out a3);
				var ret=UnityEngine.PhysicsScene2D.OverlapCollider(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Collider2D),typeof(UnityEngine.ContactFilter2D),typeof(List<UnityEngine.Collider2D>))){
				UnityEngine.Collider2D a1;
				checkType(l,1,out a1);
				UnityEngine.ContactFilter2D a2;
				checkValueType(l,2,out a2);
				System.Collections.Generic.List<UnityEngine.Collider2D> a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.PhysicsScene2D.OverlapCollider(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function OverlapCollider to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.PhysicsScene2D");
		addMember(l,IsValid);
		addMember(l,IsEmpty);
		addMember(l,Simulate);
		addMember(l,Linecast);
		addMember(l,Raycast);
		addMember(l,CircleCast);
		addMember(l,BoxCast);
		addMember(l,CapsuleCast);
		addMember(l,GetRayIntersection);
		addMember(l,OverlapPoint);
		addMember(l,OverlapCircle);
		addMember(l,OverlapBox);
		addMember(l,OverlapArea);
		addMember(l,OverlapCapsule);
		addMember(l,op_Equality);
		addMember(l,op_Inequality);
		addMember(l,OverlapCollider_s);
		createTypeMetatable(l,constructor, typeof(UnityEngine.PhysicsScene2D),typeof(System.ValueType));
	}
}
