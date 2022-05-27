using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_InputField_InputType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.InputField.InputType");
		addMember(l,0,"Standard");
		addMember(l,1,"AutoCorrect");
		addMember(l,2,"Password");
		LuaDLL.lua_pop(l, 1);
	}
}
