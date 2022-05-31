using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_IMaskable : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RecalculateMasking(IntPtr l) {
		try {
			UnityEngine.UI.IMaskable self=(UnityEngine.UI.IMaskable)checkSelf(l);
			self.RecalculateMasking();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.IMaskable");
		addMember(l,RecalculateMasking);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.IMaskable));
	}
}
