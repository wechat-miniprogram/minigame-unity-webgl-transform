using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_InputField_CharacterValidation : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.InputField.CharacterValidation");
		addMember(l,0,"None");
		addMember(l,1,"Integer");
		addMember(l,2,"Decimal");
		addMember(l,3,"Alphanumeric");
		addMember(l,4,"Name");
		addMember(l,5,"EmailAddress");
		LuaDLL.lua_pop(l, 1);
	}
}
