using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_InputField_ContentType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.InputField.ContentType");
		addMember(l,0,"Standard");
		addMember(l,1,"Autocorrected");
		addMember(l,2,"IntegerNumber");
		addMember(l,3,"DecimalNumber");
		addMember(l,4,"Alphanumeric");
		addMember(l,5,"Name");
		addMember(l,6,"EmailAddress");
		addMember(l,7,"Password");
		addMember(l,8,"Pin");
		addMember(l,9,"Custom");
		LuaDLL.lua_pop(l, 1);
	}
}
