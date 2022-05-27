using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_InputField_LineType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.InputField.LineType");
		addMember(l,0,"SingleLine");
		addMember(l,1,"MultiLineSubmit");
		addMember(l,2,"MultiLineNewline");
		LuaDLL.lua_pop(l, 1);
	}
}
