using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_MeshColliderCookingOptions : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.MeshColliderCookingOptions");
		addMember(l,0,"None");
		addMember(l,1,"InflateConvexMesh");
		addMember(l,2,"CookForFasterSimulation");
		addMember(l,4,"EnableMeshCleaning");
		addMember(l,8,"WeldColocatedVertices");
		addMember(l,16,"UseFastMidphase");
		LuaDLL.lua_pop(l, 1);
	}
}
