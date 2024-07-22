using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_ILayoutIgnorer : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_ignoreLayout(IntPtr l) {
		try {
			UnityEngine.UI.ILayoutIgnorer self=(UnityEngine.UI.ILayoutIgnorer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.ignoreLayout);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.ILayoutIgnorer");
		addMember(l,"ignoreLayout",get_ignoreLayout,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.ILayoutIgnorer));
	}
}
