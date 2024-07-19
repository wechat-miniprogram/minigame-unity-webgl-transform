using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_MeshRenderer : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_additionalVertexStreams(IntPtr l) {
		try {
			UnityEngine.MeshRenderer self=(UnityEngine.MeshRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.additionalVertexStreams);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_additionalVertexStreams(IntPtr l) {
		try {
			UnityEngine.MeshRenderer self=(UnityEngine.MeshRenderer)checkSelf(l);
			UnityEngine.Mesh v;
			checkType(l,2,out v);
			self.additionalVertexStreams=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_enlightenVertexStream(IntPtr l) {
		try {
			UnityEngine.MeshRenderer self=(UnityEngine.MeshRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.enlightenVertexStream);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_enlightenVertexStream(IntPtr l) {
		try {
			UnityEngine.MeshRenderer self=(UnityEngine.MeshRenderer)checkSelf(l);
			UnityEngine.Mesh v;
			checkType(l,2,out v);
			self.enlightenVertexStream=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_subMeshStartIndex(IntPtr l) {
		try {
			UnityEngine.MeshRenderer self=(UnityEngine.MeshRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.subMeshStartIndex);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.MeshRenderer");
		addMember(l,"additionalVertexStreams",get_additionalVertexStreams,set_additionalVertexStreams,true);
		addMember(l,"enlightenVertexStream",get_enlightenVertexStream,set_enlightenVertexStream,true);
		addMember(l,"subMeshStartIndex",get_subMeshStartIndex,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.MeshRenderer),typeof(UnityEngine.Renderer));
	}
}
