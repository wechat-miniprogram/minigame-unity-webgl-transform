using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_Slider_Direction : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.Slider.Direction");
		addMember(l,0,"LeftToRight");
		addMember(l,1,"RightToLeft");
		addMember(l,2,"BottomToTop");
		addMember(l,3,"TopToBottom");
		LuaDLL.lua_pop(l, 1);
	}
}
