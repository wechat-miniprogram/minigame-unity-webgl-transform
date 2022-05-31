using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_U2D_PixelPerfectRendering : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_pixelSnapSpacing(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.U2D.PixelPerfectRendering.pixelSnapSpacing);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_pixelSnapSpacing(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.U2D.PixelPerfectRendering.pixelSnapSpacing=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.U2D.PixelPerfectRendering");
		addMember(l,"pixelSnapSpacing",get_pixelSnapSpacing,set_pixelSnapSpacing,false);
		createTypeMetatable(l,null, typeof(UnityEngine.U2D.PixelPerfectRendering));
	}
}
