using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Mesh_MeshData : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Mesh.MeshData o;
			o=new UnityEngine.Mesh.MeshData();
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
	static public int GetVertexBufferStride(IntPtr l) {
		try {
			UnityEngine.Mesh.MeshData self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetVertexBufferStride(a1);
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
	static public int HasVertexAttribute(IntPtr l) {
		try {
			UnityEngine.Mesh.MeshData self;
			checkValueType(l,1,out self);
			UnityEngine.Rendering.VertexAttribute a1;
			a1 = (UnityEngine.Rendering.VertexAttribute)LuaDLL.luaL_checkinteger(l, 2);
			var ret=self.HasVertexAttribute(a1);
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
	static public int GetVertexAttributeDimension(IntPtr l) {
		try {
			UnityEngine.Mesh.MeshData self;
			checkValueType(l,1,out self);
			UnityEngine.Rendering.VertexAttribute a1;
			a1 = (UnityEngine.Rendering.VertexAttribute)LuaDLL.luaL_checkinteger(l, 2);
			var ret=self.GetVertexAttributeDimension(a1);
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
	static public int GetVertexAttributeFormat(IntPtr l) {
		try {
			UnityEngine.Mesh.MeshData self;
			checkValueType(l,1,out self);
			UnityEngine.Rendering.VertexAttribute a1;
			a1 = (UnityEngine.Rendering.VertexAttribute)LuaDLL.luaL_checkinteger(l, 2);
			var ret=self.GetVertexAttributeFormat(a1);
			pushValue(l,true);
			pushEnum(l,(int)ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetVertexAttributeStream(IntPtr l) {
		try {
			UnityEngine.Mesh.MeshData self;
			checkValueType(l,1,out self);
			UnityEngine.Rendering.VertexAttribute a1;
			a1 = (UnityEngine.Rendering.VertexAttribute)LuaDLL.luaL_checkinteger(l, 2);
			var ret=self.GetVertexAttributeStream(a1);
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
	static public int GetVertexAttributeOffset(IntPtr l) {
		try {
			UnityEngine.Mesh.MeshData self;
			checkValueType(l,1,out self);
			UnityEngine.Rendering.VertexAttribute a1;
			a1 = (UnityEngine.Rendering.VertexAttribute)LuaDLL.luaL_checkinteger(l, 2);
			var ret=self.GetVertexAttributeOffset(a1);
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
	static public int GetVertices(IntPtr l) {
		try {
			UnityEngine.Mesh.MeshData self;
			checkValueType(l,1,out self);
			Unity.Collections.NativeArray<UnityEngine.Vector3> a1;
			checkValueType(l,2,out a1);
			self.GetVertices(a1);
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
	static public int GetNormals(IntPtr l) {
		try {
			UnityEngine.Mesh.MeshData self;
			checkValueType(l,1,out self);
			Unity.Collections.NativeArray<UnityEngine.Vector3> a1;
			checkValueType(l,2,out a1);
			self.GetNormals(a1);
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
	static public int GetTangents(IntPtr l) {
		try {
			UnityEngine.Mesh.MeshData self;
			checkValueType(l,1,out self);
			Unity.Collections.NativeArray<UnityEngine.Vector4> a1;
			checkValueType(l,2,out a1);
			self.GetTangents(a1);
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
	static public int GetColors(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(Unity.Collections.NativeArray<UnityEngine.Color>))){
				UnityEngine.Mesh.MeshData self;
				checkValueType(l,1,out self);
				Unity.Collections.NativeArray<UnityEngine.Color> a1;
				checkValueType(l,2,out a1);
				self.GetColors(a1);
				pushValue(l,true);
				setBack(l,self);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(Unity.Collections.NativeArray<UnityEngine.Color32>))){
				UnityEngine.Mesh.MeshData self;
				checkValueType(l,1,out self);
				Unity.Collections.NativeArray<UnityEngine.Color32> a1;
				checkValueType(l,2,out a1);
				self.GetColors(a1);
				pushValue(l,true);
				setBack(l,self);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetColors to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetUVs(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int),typeof(Unity.Collections.NativeArray<UnityEngine.Vector2>))){
				UnityEngine.Mesh.MeshData self;
				checkValueType(l,1,out self);
				System.Int32 a1;
				checkType(l,2,out a1);
				Unity.Collections.NativeArray<UnityEngine.Vector2> a2;
				checkValueType(l,3,out a2);
				self.GetUVs(a1,a2);
				pushValue(l,true);
				setBack(l,self);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(Unity.Collections.NativeArray<UnityEngine.Vector3>))){
				UnityEngine.Mesh.MeshData self;
				checkValueType(l,1,out self);
				System.Int32 a1;
				checkType(l,2,out a1);
				Unity.Collections.NativeArray<UnityEngine.Vector3> a2;
				checkValueType(l,3,out a2);
				self.GetUVs(a1,a2);
				pushValue(l,true);
				setBack(l,self);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(Unity.Collections.NativeArray<UnityEngine.Vector4>))){
				UnityEngine.Mesh.MeshData self;
				checkValueType(l,1,out self);
				System.Int32 a1;
				checkType(l,2,out a1);
				Unity.Collections.NativeArray<UnityEngine.Vector4> a2;
				checkValueType(l,3,out a2);
				self.GetUVs(a1,a2);
				pushValue(l,true);
				setBack(l,self);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetUVs to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetVertexBufferParams(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.Rendering.VertexAttributeDescriptor[]))){
				UnityEngine.Mesh.MeshData self;
				checkValueType(l,1,out self);
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Rendering.VertexAttributeDescriptor[] a2;
				checkValueParams(l,3,out a2);
				self.SetVertexBufferParams(a1,a2);
				pushValue(l,true);
				setBack(l,self);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(Unity.Collections.NativeArray<UnityEngine.Rendering.VertexAttributeDescriptor>))){
				UnityEngine.Mesh.MeshData self;
				checkValueType(l,1,out self);
				System.Int32 a1;
				checkType(l,2,out a1);
				Unity.Collections.NativeArray<UnityEngine.Rendering.VertexAttributeDescriptor> a2;
				checkValueType(l,3,out a2);
				self.SetVertexBufferParams(a1,a2);
				pushValue(l,true);
				setBack(l,self);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetVertexBufferParams to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetIndexBufferParams(IntPtr l) {
		try {
			UnityEngine.Mesh.MeshData self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			UnityEngine.Rendering.IndexFormat a2;
			a2 = (UnityEngine.Rendering.IndexFormat)LuaDLL.luaL_checkinteger(l, 3);
			self.SetIndexBufferParams(a1,a2);
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
	static public int GetIndices(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(Unity.Collections.NativeArray<System.UInt16>),typeof(int),typeof(bool))){
				UnityEngine.Mesh.MeshData self;
				checkValueType(l,1,out self);
				Unity.Collections.NativeArray<System.UInt16> a1;
				checkValueType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Boolean a3;
				checkType(l,4,out a3);
				self.GetIndices(a1,a2,a3);
				pushValue(l,true);
				setBack(l,self);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(Unity.Collections.NativeArray<System.Int32>),typeof(int),typeof(bool))){
				UnityEngine.Mesh.MeshData self;
				checkValueType(l,1,out self);
				Unity.Collections.NativeArray<System.Int32> a1;
				checkValueType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Boolean a3;
				checkType(l,4,out a3);
				self.GetIndices(a1,a2,a3);
				pushValue(l,true);
				setBack(l,self);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetIndices to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetSubMesh(IntPtr l) {
		try {
			UnityEngine.Mesh.MeshData self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetSubMesh(a1);
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
	static public int SetSubMesh(IntPtr l) {
		try {
			UnityEngine.Mesh.MeshData self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			UnityEngine.Rendering.SubMeshDescriptor a2;
			checkValueType(l,3,out a2);
			UnityEngine.Rendering.MeshUpdateFlags a3;
			a3 = (UnityEngine.Rendering.MeshUpdateFlags)LuaDLL.luaL_checkinteger(l, 4);
			self.SetSubMesh(a1,a2,a3);
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
	static public int get_vertexCount(IntPtr l) {
		try {
			UnityEngine.Mesh.MeshData self;
			checkValueType(l,1,out self);
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
	static public int get_vertexBufferCount(IntPtr l) {
		try {
			UnityEngine.Mesh.MeshData self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.vertexBufferCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_indexFormat(IntPtr l) {
		try {
			UnityEngine.Mesh.MeshData self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.indexFormat);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_subMeshCount(IntPtr l) {
		try {
			UnityEngine.Mesh.MeshData self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.subMeshCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_subMeshCount(IntPtr l) {
		try {
			UnityEngine.Mesh.MeshData self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.subMeshCount=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Mesh.MeshData");
		addMember(l,GetVertexBufferStride);
		addMember(l,HasVertexAttribute);
		addMember(l,GetVertexAttributeDimension);
		addMember(l,GetVertexAttributeFormat);
		addMember(l,GetVertexAttributeStream);
		addMember(l,GetVertexAttributeOffset);
		addMember(l,GetVertices);
		addMember(l,GetNormals);
		addMember(l,GetTangents);
		addMember(l,GetColors);
		addMember(l,GetUVs);
		addMember(l,SetVertexBufferParams);
		addMember(l,SetIndexBufferParams);
		addMember(l,GetIndices);
		addMember(l,GetSubMesh);
		addMember(l,SetSubMesh);
		addMember(l,"vertexCount",get_vertexCount,null,true);
		addMember(l,"vertexBufferCount",get_vertexBufferCount,null,true);
		addMember(l,"indexFormat",get_indexFormat,null,true);
		addMember(l,"subMeshCount",get_subMeshCount,set_subMeshCount,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Mesh.MeshData),typeof(System.ValueType));
	}
}
