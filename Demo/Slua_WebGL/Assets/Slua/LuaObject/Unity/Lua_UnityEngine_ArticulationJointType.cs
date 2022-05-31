using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ArticulationJointType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.ArticulationJointType");
		addMember(l,0,"FixedJoint");
		addMember(l,1,"PrismaticJoint");
		addMember(l,2,"RevoluteJoint");
		addMember(l,3,"SphericalJoint");
		LuaDLL.lua_pop(l, 1);
	}
}
