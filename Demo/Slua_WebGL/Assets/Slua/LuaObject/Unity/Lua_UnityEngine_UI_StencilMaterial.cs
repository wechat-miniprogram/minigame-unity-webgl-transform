using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_StencilMaterial : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Add_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==5){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Rendering.StencilOp a3;
				a3 = (UnityEngine.Rendering.StencilOp)LuaDLL.luaL_checkinteger(l, 3);
				UnityEngine.Rendering.CompareFunction a4;
				a4 = (UnityEngine.Rendering.CompareFunction)LuaDLL.luaL_checkinteger(l, 4);
				UnityEngine.Rendering.ColorWriteMask a5;
				a5 = (UnityEngine.Rendering.ColorWriteMask)LuaDLL.luaL_checkinteger(l, 5);
				var ret=UnityEngine.UI.StencilMaterial.Add(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==7){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Rendering.StencilOp a3;
				a3 = (UnityEngine.Rendering.StencilOp)LuaDLL.luaL_checkinteger(l, 3);
				UnityEngine.Rendering.CompareFunction a4;
				a4 = (UnityEngine.Rendering.CompareFunction)LuaDLL.luaL_checkinteger(l, 4);
				UnityEngine.Rendering.ColorWriteMask a5;
				a5 = (UnityEngine.Rendering.ColorWriteMask)LuaDLL.luaL_checkinteger(l, 5);
				System.Int32 a6;
				checkType(l,6,out a6);
				System.Int32 a7;
				checkType(l,7,out a7);
				var ret=UnityEngine.UI.StencilMaterial.Add(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Add to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Remove_s(IntPtr l) {
		try {
			UnityEngine.Material a1;
			checkType(l,1,out a1);
			UnityEngine.UI.StencilMaterial.Remove(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ClearAll_s(IntPtr l) {
		try {
			UnityEngine.UI.StencilMaterial.ClearAll();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.StencilMaterial");
		addMember(l,Add_s);
		addMember(l,Remove_s);
		addMember(l,ClearAll_s);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.StencilMaterial));
	}
}
