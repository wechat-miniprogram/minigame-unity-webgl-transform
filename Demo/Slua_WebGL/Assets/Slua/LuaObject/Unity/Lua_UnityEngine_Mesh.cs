using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Mesh : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Mesh o;
			o=new UnityEngine.Mesh();
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
	static public int SetIndexBufferParams(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			UnityEngine.Rendering.IndexFormat a2;
			a2 = (UnityEngine.Rendering.IndexFormat)LuaDLL.luaL_checkinteger(l, 3);
			self.SetIndexBufferParams(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetVertexAttribute(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetVertexAttribute(a1);
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
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
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
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
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
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
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
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
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
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
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
	static public int GetVertexBufferStride(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
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
	static public int GetNativeVertexBufferPtr(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetNativeVertexBufferPtr(a1);
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
	static public int GetNativeIndexBufferPtr(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			var ret=self.GetNativeIndexBufferPtr();
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
	static public int ClearBlendShapes(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			self.ClearBlendShapes();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetBlendShapeName(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetBlendShapeName(a1);
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
	static public int GetBlendShapeIndex(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.GetBlendShapeIndex(a1);
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
	static public int GetBlendShapeFrameCount(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetBlendShapeFrameCount(a1);
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
	static public int GetBlendShapeFrameWeight(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			var ret=self.GetBlendShapeFrameWeight(a1,a2);
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
	static public int GetBlendShapeFrameVertices(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			UnityEngine.Vector3[] a3;
			checkArray(l,4,out a3);
			UnityEngine.Vector3[] a4;
			checkArray(l,5,out a4);
			UnityEngine.Vector3[] a5;
			checkArray(l,6,out a5);
			self.GetBlendShapeFrameVertices(a1,a2,a3,a4,a5);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AddBlendShapeFrame(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			UnityEngine.Vector3[] a3;
			checkArray(l,4,out a3);
			UnityEngine.Vector3[] a4;
			checkArray(l,5,out a4);
			UnityEngine.Vector3[] a5;
			checkArray(l,6,out a5);
			self.AddBlendShapeFrame(a1,a2,a3,a4,a5);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetBoneWeights(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			Unity.Collections.NativeArray<System.Byte> a1;
			checkValueType(l,2,out a1);
			Unity.Collections.NativeArray<UnityEngine.BoneWeight1> a2;
			checkValueType(l,3,out a2);
			self.SetBoneWeights(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetAllBoneWeights(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			var ret=self.GetAllBoneWeights();
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
	static public int GetBonesPerVertex(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			var ret=self.GetBonesPerVertex();
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
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			UnityEngine.Rendering.SubMeshDescriptor a2;
			checkValueType(l,3,out a2);
			UnityEngine.Rendering.MeshUpdateFlags a3;
			a3 = (UnityEngine.Rendering.MeshUpdateFlags)LuaDLL.luaL_checkinteger(l, 4);
			self.SetSubMesh(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetSubMesh(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
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
	static public int MarkModified(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			self.MarkModified();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetUVDistributionMetric(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetUVDistributionMetric(a1);
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
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			System.Collections.Generic.List<UnityEngine.Vector3> a1;
			checkType(l,2,out a1);
			self.GetVertices(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetVertices(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(List<UnityEngine.Vector3>))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<UnityEngine.Vector3> a1;
				checkType(l,2,out a1);
				self.SetVertices(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector3[]))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				UnityEngine.Vector3[] a1;
				checkArray(l,2,out a1);
				self.SetVertices(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<UnityEngine.Vector3>),typeof(int),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<UnityEngine.Vector3> a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				self.SetVertices(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector3[]),typeof(int),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				UnityEngine.Vector3[] a1;
				checkArray(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				self.SetVertices(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<UnityEngine.Vector3>),typeof(int),typeof(int),typeof(UnityEngine.Rendering.MeshUpdateFlags))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<UnityEngine.Vector3> a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				UnityEngine.Rendering.MeshUpdateFlags a4;
				a4 = (UnityEngine.Rendering.MeshUpdateFlags)LuaDLL.luaL_checkinteger(l, 5);
				self.SetVertices(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector3[]),typeof(int),typeof(int),typeof(UnityEngine.Rendering.MeshUpdateFlags))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				UnityEngine.Vector3[] a1;
				checkArray(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				UnityEngine.Rendering.MeshUpdateFlags a4;
				a4 = (UnityEngine.Rendering.MeshUpdateFlags)LuaDLL.luaL_checkinteger(l, 5);
				self.SetVertices(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetVertices to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetNormals(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			System.Collections.Generic.List<UnityEngine.Vector3> a1;
			checkType(l,2,out a1);
			self.GetNormals(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetNormals(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(List<UnityEngine.Vector3>))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<UnityEngine.Vector3> a1;
				checkType(l,2,out a1);
				self.SetNormals(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector3[]))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				UnityEngine.Vector3[] a1;
				checkArray(l,2,out a1);
				self.SetNormals(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<UnityEngine.Vector3>),typeof(int),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<UnityEngine.Vector3> a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				self.SetNormals(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector3[]),typeof(int),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				UnityEngine.Vector3[] a1;
				checkArray(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				self.SetNormals(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<UnityEngine.Vector3>),typeof(int),typeof(int),typeof(UnityEngine.Rendering.MeshUpdateFlags))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<UnityEngine.Vector3> a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				UnityEngine.Rendering.MeshUpdateFlags a4;
				a4 = (UnityEngine.Rendering.MeshUpdateFlags)LuaDLL.luaL_checkinteger(l, 5);
				self.SetNormals(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector3[]),typeof(int),typeof(int),typeof(UnityEngine.Rendering.MeshUpdateFlags))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				UnityEngine.Vector3[] a1;
				checkArray(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				UnityEngine.Rendering.MeshUpdateFlags a4;
				a4 = (UnityEngine.Rendering.MeshUpdateFlags)LuaDLL.luaL_checkinteger(l, 5);
				self.SetNormals(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetNormals to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetTangents(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			System.Collections.Generic.List<UnityEngine.Vector4> a1;
			checkType(l,2,out a1);
			self.GetTangents(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetTangents(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(List<UnityEngine.Vector4>))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<UnityEngine.Vector4> a1;
				checkType(l,2,out a1);
				self.SetTangents(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector4[]))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				UnityEngine.Vector4[] a1;
				checkArray(l,2,out a1);
				self.SetTangents(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<UnityEngine.Vector4>),typeof(int),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<UnityEngine.Vector4> a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				self.SetTangents(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector4[]),typeof(int),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				UnityEngine.Vector4[] a1;
				checkArray(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				self.SetTangents(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<UnityEngine.Vector4>),typeof(int),typeof(int),typeof(UnityEngine.Rendering.MeshUpdateFlags))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<UnityEngine.Vector4> a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				UnityEngine.Rendering.MeshUpdateFlags a4;
				a4 = (UnityEngine.Rendering.MeshUpdateFlags)LuaDLL.luaL_checkinteger(l, 5);
				self.SetTangents(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector4[]),typeof(int),typeof(int),typeof(UnityEngine.Rendering.MeshUpdateFlags))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				UnityEngine.Vector4[] a1;
				checkArray(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				UnityEngine.Rendering.MeshUpdateFlags a4;
				a4 = (UnityEngine.Rendering.MeshUpdateFlags)LuaDLL.luaL_checkinteger(l, 5);
				self.SetTangents(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetTangents to call");
			return 2;
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
			if(matchType(l,argc,2,typeof(List<UnityEngine.Color>))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<UnityEngine.Color> a1;
				checkType(l,2,out a1);
				self.GetColors(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<UnityEngine.Color32>))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<UnityEngine.Color32> a1;
				checkType(l,2,out a1);
				self.GetColors(a1);
				pushValue(l,true);
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
	static public int SetColors(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(List<UnityEngine.Color>))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<UnityEngine.Color> a1;
				checkType(l,2,out a1);
				self.SetColors(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Color[]))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				UnityEngine.Color[] a1;
				checkArray(l,2,out a1);
				self.SetColors(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<UnityEngine.Color32>))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<UnityEngine.Color32> a1;
				checkType(l,2,out a1);
				self.SetColors(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Color32[]))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				UnityEngine.Color32[] a1;
				checkArray(l,2,out a1);
				self.SetColors(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<UnityEngine.Color>),typeof(int),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<UnityEngine.Color> a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				self.SetColors(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Color[]),typeof(int),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				UnityEngine.Color[] a1;
				checkArray(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				self.SetColors(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<UnityEngine.Color32>),typeof(int),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<UnityEngine.Color32> a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				self.SetColors(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Color32[]),typeof(int),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				UnityEngine.Color32[] a1;
				checkArray(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				self.SetColors(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<UnityEngine.Color>),typeof(int),typeof(int),typeof(UnityEngine.Rendering.MeshUpdateFlags))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<UnityEngine.Color> a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				UnityEngine.Rendering.MeshUpdateFlags a4;
				a4 = (UnityEngine.Rendering.MeshUpdateFlags)LuaDLL.luaL_checkinteger(l, 5);
				self.SetColors(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Color[]),typeof(int),typeof(int),typeof(UnityEngine.Rendering.MeshUpdateFlags))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				UnityEngine.Color[] a1;
				checkArray(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				UnityEngine.Rendering.MeshUpdateFlags a4;
				a4 = (UnityEngine.Rendering.MeshUpdateFlags)LuaDLL.luaL_checkinteger(l, 5);
				self.SetColors(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<UnityEngine.Color32>),typeof(int),typeof(int),typeof(UnityEngine.Rendering.MeshUpdateFlags))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<UnityEngine.Color32> a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				UnityEngine.Rendering.MeshUpdateFlags a4;
				a4 = (UnityEngine.Rendering.MeshUpdateFlags)LuaDLL.luaL_checkinteger(l, 5);
				self.SetColors(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Color32[]),typeof(int),typeof(int),typeof(UnityEngine.Rendering.MeshUpdateFlags))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				UnityEngine.Color32[] a1;
				checkArray(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				UnityEngine.Rendering.MeshUpdateFlags a4;
				a4 = (UnityEngine.Rendering.MeshUpdateFlags)LuaDLL.luaL_checkinteger(l, 5);
				self.SetColors(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetColors to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetUVs(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int),typeof(List<UnityEngine.Vector2>))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Vector2> a2;
				checkType(l,3,out a2);
				self.SetUVs(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(List<UnityEngine.Vector3>))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Vector3> a2;
				checkType(l,3,out a2);
				self.SetUVs(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(List<UnityEngine.Vector4>))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Vector4> a2;
				checkType(l,3,out a2);
				self.SetUVs(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.Vector2[]))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2[] a2;
				checkArray(l,3,out a2);
				self.SetUVs(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.Vector3[]))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector3[] a2;
				checkArray(l,3,out a2);
				self.SetUVs(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.Vector4[]))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector4[] a2;
				checkArray(l,3,out a2);
				self.SetUVs(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(List<UnityEngine.Vector2>),typeof(int),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Vector2> a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				self.SetUVs(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(List<UnityEngine.Vector3>),typeof(int),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Vector3> a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				self.SetUVs(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.Vector3[]),typeof(int),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector3[] a2;
				checkArray(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				self.SetUVs(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(List<UnityEngine.Vector4>),typeof(int),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Vector4> a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				self.SetUVs(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.Vector4[]),typeof(int),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector4[] a2;
				checkArray(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				self.SetUVs(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.Vector2[]),typeof(int),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2[] a2;
				checkArray(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				self.SetUVs(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.Vector3[]),typeof(int),typeof(int),typeof(UnityEngine.Rendering.MeshUpdateFlags))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector3[] a2;
				checkArray(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				UnityEngine.Rendering.MeshUpdateFlags a5;
				a5 = (UnityEngine.Rendering.MeshUpdateFlags)LuaDLL.luaL_checkinteger(l, 6);
				self.SetUVs(a1,a2,a3,a4,a5);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(List<UnityEngine.Vector4>),typeof(int),typeof(int),typeof(UnityEngine.Rendering.MeshUpdateFlags))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Vector4> a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				UnityEngine.Rendering.MeshUpdateFlags a5;
				a5 = (UnityEngine.Rendering.MeshUpdateFlags)LuaDLL.luaL_checkinteger(l, 6);
				self.SetUVs(a1,a2,a3,a4,a5);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(List<UnityEngine.Vector3>),typeof(int),typeof(int),typeof(UnityEngine.Rendering.MeshUpdateFlags))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Vector3> a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				UnityEngine.Rendering.MeshUpdateFlags a5;
				a5 = (UnityEngine.Rendering.MeshUpdateFlags)LuaDLL.luaL_checkinteger(l, 6);
				self.SetUVs(a1,a2,a3,a4,a5);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(List<UnityEngine.Vector2>),typeof(int),typeof(int),typeof(UnityEngine.Rendering.MeshUpdateFlags))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Vector2> a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				UnityEngine.Rendering.MeshUpdateFlags a5;
				a5 = (UnityEngine.Rendering.MeshUpdateFlags)LuaDLL.luaL_checkinteger(l, 6);
				self.SetUVs(a1,a2,a3,a4,a5);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.Vector2[]),typeof(int),typeof(int),typeof(UnityEngine.Rendering.MeshUpdateFlags))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector2[] a2;
				checkArray(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				UnityEngine.Rendering.MeshUpdateFlags a5;
				a5 = (UnityEngine.Rendering.MeshUpdateFlags)LuaDLL.luaL_checkinteger(l, 6);
				self.SetUVs(a1,a2,a3,a4,a5);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.Vector4[]),typeof(int),typeof(int),typeof(UnityEngine.Rendering.MeshUpdateFlags))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector4[] a2;
				checkArray(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				UnityEngine.Rendering.MeshUpdateFlags a5;
				a5 = (UnityEngine.Rendering.MeshUpdateFlags)LuaDLL.luaL_checkinteger(l, 6);
				self.SetUVs(a1,a2,a3,a4,a5);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetUVs to call");
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
			if(matchType(l,argc,2,typeof(int),typeof(List<UnityEngine.Vector2>))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Vector2> a2;
				checkType(l,3,out a2);
				self.GetUVs(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(List<UnityEngine.Vector3>))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Vector3> a2;
				checkType(l,3,out a2);
				self.GetUVs(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(List<UnityEngine.Vector4>))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Vector4> a2;
				checkType(l,3,out a2);
				self.GetUVs(a1,a2);
				pushValue(l,true);
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
	static public int GetVertexAttributes(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				var ret=self.GetVertexAttributes();
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Rendering.VertexAttributeDescriptor[]))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				UnityEngine.Rendering.VertexAttributeDescriptor[] a1;
				checkArray(l,2,out a1);
				var ret=self.GetVertexAttributes(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(List<UnityEngine.Rendering.VertexAttributeDescriptor>))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<UnityEngine.Rendering.VertexAttributeDescriptor> a1;
				checkType(l,2,out a1);
				var ret=self.GetVertexAttributes(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetVertexAttributes to call");
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
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Rendering.VertexAttributeDescriptor[] a2;
				checkValueParams(l,3,out a2);
				self.SetVertexBufferParams(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(Unity.Collections.NativeArray<UnityEngine.Rendering.VertexAttributeDescriptor>))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				Unity.Collections.NativeArray<UnityEngine.Rendering.VertexAttributeDescriptor> a2;
				checkValueType(l,3,out a2);
				self.SetVertexBufferParams(a1,a2);
				pushValue(l,true);
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
	static public int GetVertexBuffer(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetVertexBuffer(a1);
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
	static public int GetIndexBuffer(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			var ret=self.GetIndexBuffer();
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
	static public int GetTriangles(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetTriangles(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(bool))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				var ret=self.GetTriangles(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(List<System.Int32>),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<System.Int32> a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				self.GetTriangles(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<System.Int32>),typeof(int),typeof(bool))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<System.Int32> a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Boolean a3;
				checkType(l,4,out a3);
				self.GetTriangles(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<System.UInt16>),typeof(int),typeof(bool))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<System.UInt16> a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Boolean a3;
				checkType(l,4,out a3);
				self.GetTriangles(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetTriangles to call");
			return 2;
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
			if(argc==2){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetIndices(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(bool))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				var ret=self.GetIndices(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(List<System.Int32>),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<System.Int32> a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				self.GetIndices(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<System.Int32>),typeof(int),typeof(bool))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<System.Int32> a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Boolean a3;
				checkType(l,4,out a3);
				self.GetIndices(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<System.UInt16>),typeof(int),typeof(bool))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<System.UInt16> a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Boolean a3;
				checkType(l,4,out a3);
				self.GetIndices(a1,a2,a3);
				pushValue(l,true);
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
	static public int GetIndexStart(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetIndexStart(a1);
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
	static public int GetIndexCount(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetIndexCount(a1);
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
	static public int GetBaseVertex(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetBaseVertex(a1);
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
	static public int SetTriangles(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(System.Int32[]),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32[] a1;
				checkArray(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				self.SetTriangles(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<System.Int32>),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<System.Int32> a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				self.SetTriangles(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(System.Int32[]),typeof(int),typeof(bool))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32[] a1;
				checkArray(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Boolean a3;
				checkType(l,4,out a3);
				self.SetTriangles(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<System.Int32>),typeof(int),typeof(bool))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<System.Int32> a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Boolean a3;
				checkType(l,4,out a3);
				self.SetTriangles(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(System.Int32[]),typeof(int),typeof(bool),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32[] a1;
				checkArray(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Boolean a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				self.SetTriangles(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(System.UInt16[]),typeof(int),typeof(bool),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.UInt16[] a1;
				checkArray(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Boolean a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				self.SetTriangles(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<System.Int32>),typeof(int),typeof(bool),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<System.Int32> a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Boolean a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				self.SetTriangles(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<System.UInt16>),typeof(int),typeof(bool),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<System.UInt16> a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Boolean a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				self.SetTriangles(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(System.Int32[]),typeof(int),typeof(int),typeof(int),typeof(bool),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32[] a1;
				checkArray(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				System.Boolean a5;
				checkType(l,6,out a5);
				System.Int32 a6;
				checkType(l,7,out a6);
				self.SetTriangles(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(System.UInt16[]),typeof(int),typeof(int),typeof(int),typeof(bool),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.UInt16[] a1;
				checkArray(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				System.Boolean a5;
				checkType(l,6,out a5);
				System.Int32 a6;
				checkType(l,7,out a6);
				self.SetTriangles(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<System.Int32>),typeof(int),typeof(int),typeof(int),typeof(bool),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<System.Int32> a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				System.Boolean a5;
				checkType(l,6,out a5);
				System.Int32 a6;
				checkType(l,7,out a6);
				self.SetTriangles(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<System.UInt16>),typeof(int),typeof(int),typeof(int),typeof(bool),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<System.UInt16> a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				System.Boolean a5;
				checkType(l,6,out a5);
				System.Int32 a6;
				checkType(l,7,out a6);
				self.SetTriangles(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetTriangles to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetIndices(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==4){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32[] a1;
				checkArray(l,2,out a1);
				UnityEngine.MeshTopology a2;
				a2 = (UnityEngine.MeshTopology)LuaDLL.luaL_checkinteger(l, 3);
				System.Int32 a3;
				checkType(l,4,out a3);
				self.SetIndices(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32[] a1;
				checkArray(l,2,out a1);
				UnityEngine.MeshTopology a2;
				a2 = (UnityEngine.MeshTopology)LuaDLL.luaL_checkinteger(l, 3);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Boolean a4;
				checkType(l,5,out a4);
				self.SetIndices(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(System.Int32[]),typeof(UnityEngine.MeshTopology),typeof(int),typeof(bool),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32[] a1;
				checkArray(l,2,out a1);
				UnityEngine.MeshTopology a2;
				a2 = (UnityEngine.MeshTopology)LuaDLL.luaL_checkinteger(l, 3);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Boolean a4;
				checkType(l,5,out a4);
				System.Int32 a5;
				checkType(l,6,out a5);
				self.SetIndices(a1,a2,a3,a4,a5);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(System.UInt16[]),typeof(UnityEngine.MeshTopology),typeof(int),typeof(bool),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.UInt16[] a1;
				checkArray(l,2,out a1);
				UnityEngine.MeshTopology a2;
				a2 = (UnityEngine.MeshTopology)LuaDLL.luaL_checkinteger(l, 3);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Boolean a4;
				checkType(l,5,out a4);
				System.Int32 a5;
				checkType(l,6,out a5);
				self.SetIndices(a1,a2,a3,a4,a5);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<System.Int32>),typeof(UnityEngine.MeshTopology),typeof(int),typeof(bool),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<System.Int32> a1;
				checkType(l,2,out a1);
				UnityEngine.MeshTopology a2;
				a2 = (UnityEngine.MeshTopology)LuaDLL.luaL_checkinteger(l, 3);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Boolean a4;
				checkType(l,5,out a4);
				System.Int32 a5;
				checkType(l,6,out a5);
				self.SetIndices(a1,a2,a3,a4,a5);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<System.UInt16>),typeof(UnityEngine.MeshTopology),typeof(int),typeof(bool),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<System.UInt16> a1;
				checkType(l,2,out a1);
				UnityEngine.MeshTopology a2;
				a2 = (UnityEngine.MeshTopology)LuaDLL.luaL_checkinteger(l, 3);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Boolean a4;
				checkType(l,5,out a4);
				System.Int32 a5;
				checkType(l,6,out a5);
				self.SetIndices(a1,a2,a3,a4,a5);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(System.Int32[]),typeof(int),typeof(int),typeof(UnityEngine.MeshTopology),typeof(int),typeof(bool),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Int32[] a1;
				checkArray(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				UnityEngine.MeshTopology a4;
				a4 = (UnityEngine.MeshTopology)LuaDLL.luaL_checkinteger(l, 5);
				System.Int32 a5;
				checkType(l,6,out a5);
				System.Boolean a6;
				checkType(l,7,out a6);
				System.Int32 a7;
				checkType(l,8,out a7);
				self.SetIndices(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(System.UInt16[]),typeof(int),typeof(int),typeof(UnityEngine.MeshTopology),typeof(int),typeof(bool),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.UInt16[] a1;
				checkArray(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				UnityEngine.MeshTopology a4;
				a4 = (UnityEngine.MeshTopology)LuaDLL.luaL_checkinteger(l, 5);
				System.Int32 a5;
				checkType(l,6,out a5);
				System.Boolean a6;
				checkType(l,7,out a6);
				System.Int32 a7;
				checkType(l,8,out a7);
				self.SetIndices(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<System.Int32>),typeof(int),typeof(int),typeof(UnityEngine.MeshTopology),typeof(int),typeof(bool),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<System.Int32> a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				UnityEngine.MeshTopology a4;
				a4 = (UnityEngine.MeshTopology)LuaDLL.luaL_checkinteger(l, 5);
				System.Int32 a5;
				checkType(l,6,out a5);
				System.Boolean a6;
				checkType(l,7,out a6);
				System.Int32 a7;
				checkType(l,8,out a7);
				self.SetIndices(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<System.UInt16>),typeof(int),typeof(int),typeof(UnityEngine.MeshTopology),typeof(int),typeof(bool),typeof(int))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<System.UInt16> a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				UnityEngine.MeshTopology a4;
				a4 = (UnityEngine.MeshTopology)LuaDLL.luaL_checkinteger(l, 5);
				System.Int32 a5;
				checkType(l,6,out a5);
				System.Boolean a6;
				checkType(l,7,out a6);
				System.Int32 a7;
				checkType(l,8,out a7);
				self.SetIndices(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetIndices to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetSubMeshes(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(UnityEngine.Rendering.SubMeshDescriptor[]),typeof(UnityEngine.Rendering.MeshUpdateFlags))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				UnityEngine.Rendering.SubMeshDescriptor[] a1;
				checkArray(l,2,out a1);
				UnityEngine.Rendering.MeshUpdateFlags a2;
				a2 = (UnityEngine.Rendering.MeshUpdateFlags)LuaDLL.luaL_checkinteger(l, 3);
				self.SetSubMeshes(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<UnityEngine.Rendering.SubMeshDescriptor>),typeof(UnityEngine.Rendering.MeshUpdateFlags))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<UnityEngine.Rendering.SubMeshDescriptor> a1;
				checkType(l,2,out a1);
				UnityEngine.Rendering.MeshUpdateFlags a2;
				a2 = (UnityEngine.Rendering.MeshUpdateFlags)LuaDLL.luaL_checkinteger(l, 3);
				self.SetSubMeshes(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Rendering.SubMeshDescriptor[]),typeof(int),typeof(int),typeof(UnityEngine.Rendering.MeshUpdateFlags))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				UnityEngine.Rendering.SubMeshDescriptor[] a1;
				checkArray(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				UnityEngine.Rendering.MeshUpdateFlags a4;
				a4 = (UnityEngine.Rendering.MeshUpdateFlags)LuaDLL.luaL_checkinteger(l, 5);
				self.SetSubMeshes(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<UnityEngine.Rendering.SubMeshDescriptor>),typeof(int),typeof(int),typeof(UnityEngine.Rendering.MeshUpdateFlags))){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Collections.Generic.List<UnityEngine.Rendering.SubMeshDescriptor> a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				UnityEngine.Rendering.MeshUpdateFlags a4;
				a4 = (UnityEngine.Rendering.MeshUpdateFlags)LuaDLL.luaL_checkinteger(l, 5);
				self.SetSubMeshes(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetSubMeshes to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetBindposes(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			System.Collections.Generic.List<UnityEngine.Matrix4x4> a1;
			checkType(l,2,out a1);
			self.GetBindposes(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetBoneWeights(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			System.Collections.Generic.List<UnityEngine.BoneWeight> a1;
			checkType(l,2,out a1);
			self.GetBoneWeights(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Clear(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				self.Clear();
				pushValue(l,true);
				return 1;
			}
			else if(argc==2){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				System.Boolean a1;
				checkType(l,2,out a1);
				self.Clear(a1);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Clear to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RecalculateBounds(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				self.RecalculateBounds();
				pushValue(l,true);
				return 1;
			}
			else if(argc==2){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				UnityEngine.Rendering.MeshUpdateFlags a1;
				a1 = (UnityEngine.Rendering.MeshUpdateFlags)LuaDLL.luaL_checkinteger(l, 2);
				self.RecalculateBounds(a1);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function RecalculateBounds to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RecalculateNormals(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				self.RecalculateNormals();
				pushValue(l,true);
				return 1;
			}
			else if(argc==2){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				UnityEngine.Rendering.MeshUpdateFlags a1;
				a1 = (UnityEngine.Rendering.MeshUpdateFlags)LuaDLL.luaL_checkinteger(l, 2);
				self.RecalculateNormals(a1);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function RecalculateNormals to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RecalculateTangents(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				self.RecalculateTangents();
				pushValue(l,true);
				return 1;
			}
			else if(argc==2){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				UnityEngine.Rendering.MeshUpdateFlags a1;
				a1 = (UnityEngine.Rendering.MeshUpdateFlags)LuaDLL.luaL_checkinteger(l, 2);
				self.RecalculateTangents(a1);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function RecalculateTangents to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RecalculateUVDistributionMetric(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			self.RecalculateUVDistributionMetric(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RecalculateUVDistributionMetrics(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			self.RecalculateUVDistributionMetrics(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int MarkDynamic(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			self.MarkDynamic();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int UploadMeshData(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			self.UploadMeshData(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Optimize(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			self.Optimize();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OptimizeIndexBuffers(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			self.OptimizeIndexBuffers();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OptimizeReorderVertexBuffer(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			self.OptimizeReorderVertexBuffer();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetTopology(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetTopology(a1);
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
	static public int CombineMeshes(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				UnityEngine.CombineInstance[] a1;
				checkArray(l,2,out a1);
				self.CombineMeshes(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				UnityEngine.CombineInstance[] a1;
				checkArray(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				self.CombineMeshes(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				UnityEngine.CombineInstance[] a1;
				checkArray(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				System.Boolean a3;
				checkType(l,4,out a3);
				self.CombineMeshes(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
				UnityEngine.CombineInstance[] a1;
				checkArray(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				System.Boolean a3;
				checkType(l,4,out a3);
				System.Boolean a4;
				checkType(l,5,out a4);
				self.CombineMeshes(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function CombineMeshes to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AcquireReadOnlyMeshData_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Mesh))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Mesh.AcquireReadOnlyMeshData(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh[]))){
				UnityEngine.Mesh[] a1;
				checkArray(l,1,out a1);
				var ret=UnityEngine.Mesh.AcquireReadOnlyMeshData(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(List<UnityEngine.Mesh>))){
				System.Collections.Generic.List<UnityEngine.Mesh> a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Mesh.AcquireReadOnlyMeshData(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function AcquireReadOnlyMeshData to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AllocateWritableMeshData_s(IntPtr l) {
		try {
			System.Int32 a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Mesh.AllocateWritableMeshData(a1);
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
	static public int ApplyAndDisposeWritableMeshData_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Mesh.MeshDataArray),typeof(UnityEngine.Mesh),typeof(UnityEngine.Rendering.MeshUpdateFlags))){
				UnityEngine.Mesh.MeshDataArray a1;
				checkValueType(l,1,out a1);
				UnityEngine.Mesh a2;
				checkType(l,2,out a2);
				UnityEngine.Rendering.MeshUpdateFlags a3;
				a3 = (UnityEngine.Rendering.MeshUpdateFlags)LuaDLL.luaL_checkinteger(l, 3);
				UnityEngine.Mesh.ApplyAndDisposeWritableMeshData(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh.MeshDataArray),typeof(UnityEngine.Mesh[]),typeof(UnityEngine.Rendering.MeshUpdateFlags))){
				UnityEngine.Mesh.MeshDataArray a1;
				checkValueType(l,1,out a1);
				UnityEngine.Mesh[] a2;
				checkArray(l,2,out a2);
				UnityEngine.Rendering.MeshUpdateFlags a3;
				a3 = (UnityEngine.Rendering.MeshUpdateFlags)LuaDLL.luaL_checkinteger(l, 3);
				UnityEngine.Mesh.ApplyAndDisposeWritableMeshData(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh.MeshDataArray),typeof(List<UnityEngine.Mesh>),typeof(UnityEngine.Rendering.MeshUpdateFlags))){
				UnityEngine.Mesh.MeshDataArray a1;
				checkValueType(l,1,out a1);
				System.Collections.Generic.List<UnityEngine.Mesh> a2;
				checkType(l,2,out a2);
				UnityEngine.Rendering.MeshUpdateFlags a3;
				a3 = (UnityEngine.Rendering.MeshUpdateFlags)LuaDLL.luaL_checkinteger(l, 3);
				UnityEngine.Mesh.ApplyAndDisposeWritableMeshData(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function ApplyAndDisposeWritableMeshData to call");
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
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
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
	static public int set_indexFormat(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			UnityEngine.Rendering.IndexFormat v;
			v = (UnityEngine.Rendering.IndexFormat)LuaDLL.luaL_checkinteger(l, 2);
			self.indexFormat=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_vertexBufferCount(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
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
	static public int get_vertexBufferTarget(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.vertexBufferTarget);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_vertexBufferTarget(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			UnityEngine.GraphicsBuffer.Target v;
			v = (UnityEngine.GraphicsBuffer.Target)LuaDLL.luaL_checkinteger(l, 2);
			self.vertexBufferTarget=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_indexBufferTarget(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.indexBufferTarget);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_indexBufferTarget(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			UnityEngine.GraphicsBuffer.Target v;
			v = (UnityEngine.GraphicsBuffer.Target)LuaDLL.luaL_checkinteger(l, 2);
			self.indexBufferTarget=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_blendShapeCount(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.blendShapeCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_bindposes(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.bindposes);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_bindposes(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			UnityEngine.Matrix4x4[] v;
			checkArray(l,2,out v);
			self.bindposes=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isReadable(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isReadable);
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
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
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
	static public int get_subMeshCount(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
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
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.subMeshCount=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_bounds(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.bounds);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_bounds(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			UnityEngine.Bounds v;
			checkValueType(l,2,out v);
			self.bounds=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_vertices(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.vertices);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_vertices(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			UnityEngine.Vector3[] v;
			checkArray(l,2,out v);
			self.vertices=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_normals(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.normals);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_normals(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			UnityEngine.Vector3[] v;
			checkArray(l,2,out v);
			self.normals=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_tangents(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.tangents);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_tangents(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			UnityEngine.Vector4[] v;
			checkArray(l,2,out v);
			self.tangents=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_uv(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.uv);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_uv(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			UnityEngine.Vector2[] v;
			checkArray(l,2,out v);
			self.uv=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_uv2(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.uv2);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_uv2(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			UnityEngine.Vector2[] v;
			checkArray(l,2,out v);
			self.uv2=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_uv3(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.uv3);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_uv3(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			UnityEngine.Vector2[] v;
			checkArray(l,2,out v);
			self.uv3=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_uv4(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.uv4);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_uv4(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			UnityEngine.Vector2[] v;
			checkArray(l,2,out v);
			self.uv4=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_uv5(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.uv5);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_uv5(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			UnityEngine.Vector2[] v;
			checkArray(l,2,out v);
			self.uv5=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_uv6(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.uv6);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_uv6(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			UnityEngine.Vector2[] v;
			checkArray(l,2,out v);
			self.uv6=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_uv7(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.uv7);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_uv7(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			UnityEngine.Vector2[] v;
			checkArray(l,2,out v);
			self.uv7=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_uv8(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.uv8);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_uv8(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			UnityEngine.Vector2[] v;
			checkArray(l,2,out v);
			self.uv8=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_colors(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.colors);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_colors(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			UnityEngine.Color[] v;
			checkArray(l,2,out v);
			self.colors=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_colors32(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.colors32);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_colors32(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			UnityEngine.Color32[] v;
			checkArray(l,2,out v);
			self.colors32=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_vertexAttributeCount(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.vertexAttributeCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_triangles(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.triangles);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_triangles(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			System.Int32[] v;
			checkArray(l,2,out v);
			self.triangles=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_boneWeights(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.boneWeights);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_boneWeights(IntPtr l) {
		try {
			UnityEngine.Mesh self=(UnityEngine.Mesh)checkSelf(l);
			UnityEngine.BoneWeight[] v;
			checkArray(l,2,out v);
			self.boneWeights=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Mesh");
		addMember(l,SetIndexBufferParams);
		addMember(l,GetVertexAttribute);
		addMember(l,HasVertexAttribute);
		addMember(l,GetVertexAttributeDimension);
		addMember(l,GetVertexAttributeFormat);
		addMember(l,GetVertexAttributeStream);
		addMember(l,GetVertexAttributeOffset);
		addMember(l,GetVertexBufferStride);
		addMember(l,GetNativeVertexBufferPtr);
		addMember(l,GetNativeIndexBufferPtr);
		addMember(l,ClearBlendShapes);
		addMember(l,GetBlendShapeName);
		addMember(l,GetBlendShapeIndex);
		addMember(l,GetBlendShapeFrameCount);
		addMember(l,GetBlendShapeFrameWeight);
		addMember(l,GetBlendShapeFrameVertices);
		addMember(l,AddBlendShapeFrame);
		addMember(l,SetBoneWeights);
		addMember(l,GetAllBoneWeights);
		addMember(l,GetBonesPerVertex);
		addMember(l,SetSubMesh);
		addMember(l,GetSubMesh);
		addMember(l,MarkModified);
		addMember(l,GetUVDistributionMetric);
		addMember(l,GetVertices);
		addMember(l,SetVertices);
		addMember(l,GetNormals);
		addMember(l,SetNormals);
		addMember(l,GetTangents);
		addMember(l,SetTangents);
		addMember(l,GetColors);
		addMember(l,SetColors);
		addMember(l,SetUVs);
		addMember(l,GetUVs);
		addMember(l,GetVertexAttributes);
		addMember(l,SetVertexBufferParams);
		addMember(l,GetVertexBuffer);
		addMember(l,GetIndexBuffer);
		addMember(l,GetTriangles);
		addMember(l,GetIndices);
		addMember(l,GetIndexStart);
		addMember(l,GetIndexCount);
		addMember(l,GetBaseVertex);
		addMember(l,SetTriangles);
		addMember(l,SetIndices);
		addMember(l,SetSubMeshes);
		addMember(l,GetBindposes);
		addMember(l,GetBoneWeights);
		addMember(l,Clear);
		addMember(l,RecalculateBounds);
		addMember(l,RecalculateNormals);
		addMember(l,RecalculateTangents);
		addMember(l,RecalculateUVDistributionMetric);
		addMember(l,RecalculateUVDistributionMetrics);
		addMember(l,MarkDynamic);
		addMember(l,UploadMeshData);
		addMember(l,Optimize);
		addMember(l,OptimizeIndexBuffers);
		addMember(l,OptimizeReorderVertexBuffer);
		addMember(l,GetTopology);
		addMember(l,CombineMeshes);
		addMember(l,AcquireReadOnlyMeshData_s);
		addMember(l,AllocateWritableMeshData_s);
		addMember(l,ApplyAndDisposeWritableMeshData_s);
		addMember(l,"indexFormat",get_indexFormat,set_indexFormat,true);
		addMember(l,"vertexBufferCount",get_vertexBufferCount,null,true);
		addMember(l,"vertexBufferTarget",get_vertexBufferTarget,set_vertexBufferTarget,true);
		addMember(l,"indexBufferTarget",get_indexBufferTarget,set_indexBufferTarget,true);
		addMember(l,"blendShapeCount",get_blendShapeCount,null,true);
		addMember(l,"bindposes",get_bindposes,set_bindposes,true);
		addMember(l,"isReadable",get_isReadable,null,true);
		addMember(l,"vertexCount",get_vertexCount,null,true);
		addMember(l,"subMeshCount",get_subMeshCount,set_subMeshCount,true);
		addMember(l,"bounds",get_bounds,set_bounds,true);
		addMember(l,"vertices",get_vertices,set_vertices,true);
		addMember(l,"normals",get_normals,set_normals,true);
		addMember(l,"tangents",get_tangents,set_tangents,true);
		addMember(l,"uv",get_uv,set_uv,true);
		addMember(l,"uv2",get_uv2,set_uv2,true);
		addMember(l,"uv3",get_uv3,set_uv3,true);
		addMember(l,"uv4",get_uv4,set_uv4,true);
		addMember(l,"uv5",get_uv5,set_uv5,true);
		addMember(l,"uv6",get_uv6,set_uv6,true);
		addMember(l,"uv7",get_uv7,set_uv7,true);
		addMember(l,"uv8",get_uv8,set_uv8,true);
		addMember(l,"colors",get_colors,set_colors,true);
		addMember(l,"colors32",get_colors32,set_colors32,true);
		addMember(l,"vertexAttributeCount",get_vertexAttributeCount,null,true);
		addMember(l,"triangles",get_triangles,set_triangles,true);
		addMember(l,"boneWeights",get_boneWeights,set_boneWeights,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Mesh),typeof(UnityEngine.Object));
	}
}
