using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AudioSourceCurveType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.AudioSourceCurveType");
		addMember(l,0,"CustomRolloff");
		addMember(l,1,"SpatialBlend");
		addMember(l,2,"ReverbZoneMix");
		addMember(l,3,"Spread");
		LuaDLL.lua_pop(l, 1);
	}
}
