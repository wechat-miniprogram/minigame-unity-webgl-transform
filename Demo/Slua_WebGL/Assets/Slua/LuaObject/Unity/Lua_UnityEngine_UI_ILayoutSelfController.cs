using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_ILayoutSelfController : LuaObject {
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.ILayoutSelfController");
		createTypeMetatable(l,null, typeof(UnityEngine.UI.ILayoutSelfController));
	}
}
