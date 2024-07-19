using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_JetBrains_Annotations_CollectionAccessType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"JetBrains.Annotations.CollectionAccessType");
		addMember(l,0,"None");
		addMember(l,1,"Read");
		addMember(l,2,"ModifyExistingContent");
		addMember(l,6,"UpdatedContent");
		LuaDLL.lua_pop(l, 1);
	}
}
