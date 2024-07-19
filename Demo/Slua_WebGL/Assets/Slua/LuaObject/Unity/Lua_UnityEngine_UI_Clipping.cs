using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_Clipping : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int FindCullAndClipWorldRect_s(IntPtr l) {
		try {
			System.Collections.Generic.List<UnityEngine.UI.RectMask2D> a1;
			checkType(l,1,out a1);
			System.Boolean a2;
			var ret=UnityEngine.UI.Clipping.FindCullAndClipWorldRect(a1,out a2);
			pushValue(l,true);
			pushValue(l,ret);
			pushValue(l,a2);
			return 3;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Clipping");
		addMember(l,FindCullAndClipWorldRect_s);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Clipping));
	}
}
