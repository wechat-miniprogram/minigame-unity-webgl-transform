using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Camera_RenderRequestOutputSpace : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.Camera.RenderRequestOutputSpace");
		addMember(l,0,"UV0");
		addMember(l,1,"UV1");
		addMember(l,2,"UV2");
		addMember(l,3,"UV3");
		addMember(l,4,"UV4");
		addMember(l,5,"UV5");
		addMember(l,6,"UV6");
		addMember(l,7,"UV7");
		addMember(l,8,"UV8");
		addMember(l,-1,"ScreenSpace");
		LuaDLL.lua_pop(l, 1);
	}
}
