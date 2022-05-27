using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_IClipper : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int PerformClipping(IntPtr l) {
		try {
			UnityEngine.UI.IClipper self=(UnityEngine.UI.IClipper)checkSelf(l);
			self.PerformClipping();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.IClipper");
		addMember(l,PerformClipping);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.IClipper));
	}
}
