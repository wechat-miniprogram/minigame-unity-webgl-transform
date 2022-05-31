using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_DeviceOrientation : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.DeviceOrientation");
		addMember(l,0,"Unknown");
		addMember(l,1,"Portrait");
		addMember(l,2,"PortraitUpsideDown");
		addMember(l,3,"LandscapeLeft");
		addMember(l,4,"LandscapeRight");
		addMember(l,5,"FaceUp");
		addMember(l,6,"FaceDown");
		LuaDLL.lua_pop(l, 1);
	}
}
