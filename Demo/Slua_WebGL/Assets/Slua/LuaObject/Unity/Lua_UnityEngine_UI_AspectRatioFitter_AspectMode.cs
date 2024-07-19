using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_AspectRatioFitter_AspectMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.AspectRatioFitter.AspectMode");
		addMember(l,0,"None");
		addMember(l,1,"WidthControlsHeight");
		addMember(l,2,"HeightControlsWidth");
		addMember(l,3,"FitInParent");
		addMember(l,4,"EnvelopeParent");
		LuaDLL.lua_pop(l, 1);
	}
}
