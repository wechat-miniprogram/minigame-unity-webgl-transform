using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_Unity_Rendering_HybridV2_DOTSInstancingPropertyType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"Unity.Rendering.HybridV2.DOTSInstancingPropertyType");
		addMember(l,0,"Unknown");
		addMember(l,1,"Float");
		addMember(l,2,"Half");
		addMember(l,3,"Int");
		addMember(l,4,"Short");
		addMember(l,5,"Uint");
		addMember(l,6,"Bool");
		addMember(l,7,"Struct");
		LuaDLL.lua_pop(l, 1);
	}
}
