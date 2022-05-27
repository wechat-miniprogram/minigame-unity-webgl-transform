using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PhysicsShapeType2D : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.PhysicsShapeType2D");
		addMember(l,0,"Circle");
		addMember(l,1,"Capsule");
		addMember(l,2,"Polygon");
		addMember(l,3,"Edges");
		LuaDLL.lua_pop(l, 1);
	}
}
