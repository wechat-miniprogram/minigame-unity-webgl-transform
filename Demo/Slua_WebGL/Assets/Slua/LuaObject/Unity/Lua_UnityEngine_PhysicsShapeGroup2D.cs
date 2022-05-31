using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PhysicsShapeGroup2D : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.PhysicsShapeGroup2D o;
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			o=new UnityEngine.PhysicsShapeGroup2D(a1,a2);
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
	static public int Clear(IntPtr l) {
		try {
			UnityEngine.PhysicsShapeGroup2D self=(UnityEngine.PhysicsShapeGroup2D)checkSelf(l);
			self.Clear();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Add(IntPtr l) {
		try {
			UnityEngine.PhysicsShapeGroup2D self=(UnityEngine.PhysicsShapeGroup2D)checkSelf(l);
			UnityEngine.PhysicsShapeGroup2D a1;
			checkType(l,2,out a1);
			self.Add(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetShapeData(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(List<UnityEngine.PhysicsShape2D>),typeof(List<UnityEngine.Vector2>))){
				UnityEngine.PhysicsShapeGroup2D self=(UnityEngine.PhysicsShapeGroup2D)checkSelf(l);
				System.Collections.Generic.List<UnityEngine.PhysicsShape2D> a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Vector2> a2;
				checkType(l,3,out a2);
				self.GetShapeData(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(Unity.Collections.NativeArray<UnityEngine.PhysicsShape2D>),typeof(Unity.Collections.NativeArray<UnityEngine.Vector2>))){
				UnityEngine.PhysicsShapeGroup2D self=(UnityEngine.PhysicsShapeGroup2D)checkSelf(l);
				Unity.Collections.NativeArray<UnityEngine.PhysicsShape2D> a1;
				checkValueType(l,2,out a1);
				Unity.Collections.NativeArray<UnityEngine.Vector2> a2;
				checkValueType(l,3,out a2);
				self.GetShapeData(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetShapeData to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetShapeVertices(IntPtr l) {
		try {
			UnityEngine.PhysicsShapeGroup2D self=(UnityEngine.PhysicsShapeGroup2D)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Collections.Generic.List<UnityEngine.Vector2> a2;
			checkType(l,3,out a2);
			self.GetShapeVertices(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetShapeVertex(IntPtr l) {
		try {
			UnityEngine.PhysicsShapeGroup2D self=(UnityEngine.PhysicsShapeGroup2D)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			var ret=self.GetShapeVertex(a1,a2);
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
	static public int SetShapeVertex(IntPtr l) {
		try {
			UnityEngine.PhysicsShapeGroup2D self=(UnityEngine.PhysicsShapeGroup2D)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			UnityEngine.Vector2 a3;
			checkType(l,4,out a3);
			self.SetShapeVertex(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetShapeRadius(IntPtr l) {
		try {
			UnityEngine.PhysicsShapeGroup2D self=(UnityEngine.PhysicsShapeGroup2D)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			self.SetShapeRadius(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetShapeAdjacentVertices(IntPtr l) {
		try {
			UnityEngine.PhysicsShapeGroup2D self=(UnityEngine.PhysicsShapeGroup2D)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			System.Boolean a3;
			checkType(l,4,out a3);
			UnityEngine.Vector2 a4;
			checkType(l,5,out a4);
			UnityEngine.Vector2 a5;
			checkType(l,6,out a5);
			self.SetShapeAdjacentVertices(a1,a2,a3,a4,a5);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int DeleteShape(IntPtr l) {
		try {
			UnityEngine.PhysicsShapeGroup2D self=(UnityEngine.PhysicsShapeGroup2D)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			self.DeleteShape(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetShape(IntPtr l) {
		try {
			UnityEngine.PhysicsShapeGroup2D self=(UnityEngine.PhysicsShapeGroup2D)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetShape(a1);
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
	static public int AddCircle(IntPtr l) {
		try {
			UnityEngine.PhysicsShapeGroup2D self=(UnityEngine.PhysicsShapeGroup2D)checkSelf(l);
			UnityEngine.Vector2 a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			var ret=self.AddCircle(a1,a2);
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
	static public int AddCapsule(IntPtr l) {
		try {
			UnityEngine.PhysicsShapeGroup2D self=(UnityEngine.PhysicsShapeGroup2D)checkSelf(l);
			UnityEngine.Vector2 a1;
			checkType(l,2,out a1);
			UnityEngine.Vector2 a2;
			checkType(l,3,out a2);
			System.Single a3;
			checkType(l,4,out a3);
			var ret=self.AddCapsule(a1,a2,a3);
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
	static public int AddBox(IntPtr l) {
		try {
			UnityEngine.PhysicsShapeGroup2D self=(UnityEngine.PhysicsShapeGroup2D)checkSelf(l);
			UnityEngine.Vector2 a1;
			checkType(l,2,out a1);
			UnityEngine.Vector2 a2;
			checkType(l,3,out a2);
			System.Single a3;
			checkType(l,4,out a3);
			System.Single a4;
			checkType(l,5,out a4);
			var ret=self.AddBox(a1,a2,a3,a4);
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
	static public int AddPolygon(IntPtr l) {
		try {
			UnityEngine.PhysicsShapeGroup2D self=(UnityEngine.PhysicsShapeGroup2D)checkSelf(l);
			System.Collections.Generic.List<UnityEngine.Vector2> a1;
			checkType(l,2,out a1);
			var ret=self.AddPolygon(a1);
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
	static public int AddEdges(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.PhysicsShapeGroup2D self=(UnityEngine.PhysicsShapeGroup2D)checkSelf(l);
				System.Collections.Generic.List<UnityEngine.Vector2> a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				var ret=self.AddEdges(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==7){
				UnityEngine.PhysicsShapeGroup2D self=(UnityEngine.PhysicsShapeGroup2D)checkSelf(l);
				System.Collections.Generic.List<UnityEngine.Vector2> a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				System.Boolean a3;
				checkType(l,4,out a3);
				UnityEngine.Vector2 a4;
				checkType(l,5,out a4);
				UnityEngine.Vector2 a5;
				checkType(l,6,out a5);
				System.Single a6;
				checkType(l,7,out a6);
				var ret=self.AddEdges(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function AddEdges to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_shapeCount(IntPtr l) {
		try {
			UnityEngine.PhysicsShapeGroup2D self=(UnityEngine.PhysicsShapeGroup2D)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.shapeCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_vertexCount(IntPtr l) {
		try {
			UnityEngine.PhysicsShapeGroup2D self=(UnityEngine.PhysicsShapeGroup2D)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.vertexCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_localToWorldMatrix(IntPtr l) {
		try {
			UnityEngine.PhysicsShapeGroup2D self=(UnityEngine.PhysicsShapeGroup2D)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.localToWorldMatrix);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_localToWorldMatrix(IntPtr l) {
		try {
			UnityEngine.PhysicsShapeGroup2D self=(UnityEngine.PhysicsShapeGroup2D)checkSelf(l);
			UnityEngine.Matrix4x4 v;
			checkValueType(l,2,out v);
			self.localToWorldMatrix=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.PhysicsShapeGroup2D");
		addMember(l,Clear);
		addMember(l,Add);
		addMember(l,GetShapeData);
		addMember(l,GetShapeVertices);
		addMember(l,GetShapeVertex);
		addMember(l,SetShapeVertex);
		addMember(l,SetShapeRadius);
		addMember(l,SetShapeAdjacentVertices);
		addMember(l,DeleteShape);
		addMember(l,GetShape);
		addMember(l,AddCircle);
		addMember(l,AddCapsule);
		addMember(l,AddBox);
		addMember(l,AddPolygon);
		addMember(l,AddEdges);
		addMember(l,"shapeCount",get_shapeCount,null,true);
		addMember(l,"vertexCount",get_vertexCount,null,true);
		addMember(l,"localToWorldMatrix",get_localToWorldMatrix,set_localToWorldMatrix,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.PhysicsShapeGroup2D));
	}
}
