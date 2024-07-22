using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_ILayoutController : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetLayoutHorizontal(IntPtr l) {
		try {
			UnityEngine.UI.ILayoutController self=(UnityEngine.UI.ILayoutController)checkSelf(l);
			self.SetLayoutHorizontal();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetLayoutVertical(IntPtr l) {
		try {
			UnityEngine.UI.ILayoutController self=(UnityEngine.UI.ILayoutController)checkSelf(l);
			self.SetLayoutVertical();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.ILayoutController");
		addMember(l,SetLayoutHorizontal);
		addMember(l,SetLayoutVertical);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.ILayoutController));
	}
}
