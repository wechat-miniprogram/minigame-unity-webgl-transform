using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_VertexHelper : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			UnityEngine.UI.VertexHelper o;
			if(argc==1){
				o=new UnityEngine.UI.VertexHelper();
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==2){
				UnityEngine.Mesh a1;
				checkType(l,2,out a1);
				o=new UnityEngine.UI.VertexHelper(a1);
				pushValue(l,true);
				pushValue(l,o);
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
	static public int Dispose(IntPtr l) {
		try {
			UnityEngine.UI.VertexHelper self=(UnityEngine.UI.VertexHelper)checkSelf(l);
			self.Dispose();
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
			UnityEngine.UI.VertexHelper self=(UnityEngine.UI.VertexHelper)checkSelf(l);
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
	static public int PopulateUIVertex(IntPtr l) {
		try {
			UnityEngine.UI.VertexHelper self=(UnityEngine.UI.VertexHelper)checkSelf(l);
			UnityEngine.UIVertex a1;
			checkValueType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			self.PopulateUIVertex(ref a1,a2);
			pushValue(l,true);
			pushValue(l,a1);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetUIVertex(IntPtr l) {
		try {
			UnityEngine.UI.VertexHelper self=(UnityEngine.UI.VertexHelper)checkSelf(l);
			UnityEngine.UIVertex a1;
			checkValueType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			self.SetUIVertex(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int FillMesh(IntPtr l) {
		try {
			UnityEngine.UI.VertexHelper self=(UnityEngine.UI.VertexHelper)checkSelf(l);
			UnityEngine.Mesh a1;
			checkType(l,2,out a1);
			self.FillMesh(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AddVert(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.UI.VertexHelper self=(UnityEngine.UI.VertexHelper)checkSelf(l);
				UnityEngine.UIVertex a1;
				checkValueType(l,2,out a1);
				self.AddVert(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==4){
				UnityEngine.UI.VertexHelper self=(UnityEngine.UI.VertexHelper)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.Color32 a2;
				checkValueType(l,3,out a2);
				UnityEngine.Vector4 a3;
				checkType(l,4,out a3);
				self.AddVert(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(argc==7){
				UnityEngine.UI.VertexHelper self=(UnityEngine.UI.VertexHelper)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.Color32 a2;
				checkValueType(l,3,out a2);
				UnityEngine.Vector4 a3;
				checkType(l,4,out a3);
				UnityEngine.Vector4 a4;
				checkType(l,5,out a4);
				UnityEngine.Vector3 a5;
				checkType(l,6,out a5);
				UnityEngine.Vector4 a6;
				checkType(l,7,out a6);
				self.AddVert(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				return 1;
			}
			else if(argc==9){
				UnityEngine.UI.VertexHelper self=(UnityEngine.UI.VertexHelper)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.Color32 a2;
				checkValueType(l,3,out a2);
				UnityEngine.Vector4 a3;
				checkType(l,4,out a3);
				UnityEngine.Vector4 a4;
				checkType(l,5,out a4);
				UnityEngine.Vector4 a5;
				checkType(l,6,out a5);
				UnityEngine.Vector4 a6;
				checkType(l,7,out a6);
				UnityEngine.Vector3 a7;
				checkType(l,8,out a7);
				UnityEngine.Vector4 a8;
				checkType(l,9,out a8);
				self.AddVert(a1,a2,a3,a4,a5,a6,a7,a8);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function AddVert to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AddTriangle(IntPtr l) {
		try {
			UnityEngine.UI.VertexHelper self=(UnityEngine.UI.VertexHelper)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			System.Int32 a3;
			checkType(l,4,out a3);
			self.AddTriangle(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AddUIVertexQuad(IntPtr l) {
		try {
			UnityEngine.UI.VertexHelper self=(UnityEngine.UI.VertexHelper)checkSelf(l);
			UnityEngine.UIVertex[] a1;
			checkArray(l,2,out a1);
			self.AddUIVertexQuad(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AddUIVertexStream(IntPtr l) {
		try {
			UnityEngine.UI.VertexHelper self=(UnityEngine.UI.VertexHelper)checkSelf(l);
			System.Collections.Generic.List<UnityEngine.UIVertex> a1;
			checkType(l,2,out a1);
			System.Collections.Generic.List<System.Int32> a2;
			checkType(l,3,out a2);
			self.AddUIVertexStream(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AddUIVertexTriangleStream(IntPtr l) {
		try {
			UnityEngine.UI.VertexHelper self=(UnityEngine.UI.VertexHelper)checkSelf(l);
			System.Collections.Generic.List<UnityEngine.UIVertex> a1;
			checkType(l,2,out a1);
			self.AddUIVertexTriangleStream(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetUIVertexStream(IntPtr l) {
		try {
			UnityEngine.UI.VertexHelper self=(UnityEngine.UI.VertexHelper)checkSelf(l);
			System.Collections.Generic.List<UnityEngine.UIVertex> a1;
			checkType(l,2,out a1);
			self.GetUIVertexStream(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_currentVertCount(IntPtr l) {
		try {
			UnityEngine.UI.VertexHelper self=(UnityEngine.UI.VertexHelper)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.currentVertCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_currentIndexCount(IntPtr l) {
		try {
			UnityEngine.UI.VertexHelper self=(UnityEngine.UI.VertexHelper)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.currentIndexCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.VertexHelper");
		addMember(l,Dispose);
		addMember(l,Clear);
		addMember(l,PopulateUIVertex);
		addMember(l,SetUIVertex);
		addMember(l,FillMesh);
		addMember(l,AddVert);
		addMember(l,AddTriangle);
		addMember(l,AddUIVertexQuad);
		addMember(l,AddUIVertexStream);
		addMember(l,AddUIVertexTriangleStream);
		addMember(l,GetUIVertexStream);
		addMember(l,"currentVertCount",get_currentVertCount,null,true);
		addMember(l,"currentIndexCount",get_currentIndexCount,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.VertexHelper));
	}
}
