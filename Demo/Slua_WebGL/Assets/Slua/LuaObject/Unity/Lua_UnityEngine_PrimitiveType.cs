using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PrimitiveType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.PrimitiveType");
		addMember(l,0,"Sphere");
		addMember(l,1,"Capsule");
		addMember(l,2,"Cylinder");
		addMember(l,3,"Cube");
		addMember(l,4,"Plane");
		addMember(l,5,"Quad");
		LuaDLL.lua_pop(l, 1);
	}
}
