using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_CustomCollider2D : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetCustomShapes(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.CustomCollider2D self=(UnityEngine.CustomCollider2D)checkSelf(l);
				UnityEngine.PhysicsShapeGroup2D a1;
				checkType(l,2,out a1);
				var ret=self.GetCustomShapes(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==3){
				UnityEngine.CustomCollider2D self=(UnityEngine.CustomCollider2D)checkSelf(l);
				Unity.Collections.NativeArray<UnityEngine.PhysicsShape2D> a1;
				checkValueType(l,2,out a1);
				Unity.Collections.NativeArray<UnityEngine.Vector2> a2;
				checkValueType(l,3,out a2);
				var ret=self.GetCustomShapes(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==4){
				UnityEngine.CustomCollider2D self=(UnityEngine.CustomCollider2D)checkSelf(l);
				UnityEngine.PhysicsShapeGroup2D a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				var ret=self.GetCustomShapes(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetCustomShapes to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetCustomShapes(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.CustomCollider2D self=(UnityEngine.CustomCollider2D)checkSelf(l);
				UnityEngine.PhysicsShapeGroup2D a1;
				checkType(l,2,out a1);
				self.SetCustomShapes(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UnityEngine.CustomCollider2D self=(UnityEngine.CustomCollider2D)checkSelf(l);
				Unity.Collections.NativeArray<UnityEngine.PhysicsShape2D> a1;
				checkValueType(l,2,out a1);
				Unity.Collections.NativeArray<UnityEngine.Vector2> a2;
				checkValueType(l,3,out a2);
				self.SetCustomShapes(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetCustomShapes to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetCustomShape(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==4){
				UnityEngine.CustomCollider2D self=(UnityEngine.CustomCollider2D)checkSelf(l);
				UnityEngine.PhysicsShapeGroup2D a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				self.SetCustomShape(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(argc==5){
				UnityEngine.CustomCollider2D self=(UnityEngine.CustomCollider2D)checkSelf(l);
				Unity.Collections.NativeArray<UnityEngine.PhysicsShape2D> a1;
				checkValueType(l,2,out a1);
				Unity.Collections.NativeArray<UnityEngine.Vector2> a2;
				checkValueType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				self.SetCustomShape(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetCustomShape to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ClearCustomShapes(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.CustomCollider2D self=(UnityEngine.CustomCollider2D)checkSelf(l);
				self.ClearCustomShapes();
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UnityEngine.CustomCollider2D self=(UnityEngine.CustomCollider2D)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				self.ClearCustomShapes(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function ClearCustomShapes to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_customShapeCount(IntPtr l) {
		try {
			UnityEngine.CustomCollider2D self=(UnityEngine.CustomCollider2D)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.customShapeCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_customVertexCount(IntPtr l) {
		try {
			UnityEngine.CustomCollider2D self=(UnityEngine.CustomCollider2D)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.customVertexCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.CustomCollider2D");
		addMember(l,GetCustomShapes);
		addMember(l,SetCustomShapes);
		addMember(l,SetCustomShape);
		addMember(l,ClearCustomShapes);
		addMember(l,"customShapeCount",get_customShapeCount,null,true);
		addMember(l,"customVertexCount",get_customVertexCount,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.CustomCollider2D),typeof(UnityEngine.Collider2D));
	}
}
