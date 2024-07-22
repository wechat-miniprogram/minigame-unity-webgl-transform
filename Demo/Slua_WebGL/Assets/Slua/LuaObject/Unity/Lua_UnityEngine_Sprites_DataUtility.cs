using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Sprites_DataUtility : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Sprites.DataUtility o;
			o=new UnityEngine.Sprites.DataUtility();
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
	static public int GetInnerUV_s(IntPtr l) {
		try {
			UnityEngine.Sprite a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Sprites.DataUtility.GetInnerUV(a1);
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
	static public int GetOuterUV_s(IntPtr l) {
		try {
			UnityEngine.Sprite a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Sprites.DataUtility.GetOuterUV(a1);
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
	static public int GetPadding_s(IntPtr l) {
		try {
			UnityEngine.Sprite a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Sprites.DataUtility.GetPadding(a1);
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
	static public int GetMinSize_s(IntPtr l) {
		try {
			UnityEngine.Sprite a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Sprites.DataUtility.GetMinSize(a1);
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
		getTypeTable(l,"UnityEngine.Sprites.DataUtility");
		addMember(l,GetInnerUV_s);
		addMember(l,GetOuterUV_s);
		addMember(l,GetPadding_s);
		addMember(l,GetMinSize_s);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Sprites.DataUtility));
	}
}
