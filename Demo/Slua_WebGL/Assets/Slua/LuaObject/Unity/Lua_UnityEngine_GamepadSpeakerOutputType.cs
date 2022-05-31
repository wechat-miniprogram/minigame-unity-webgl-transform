using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_GamepadSpeakerOutputType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.GamepadSpeakerOutputType");
		addMember(l,0,"Speaker");
		addMember(l,1,"Vibration");
		addMember(l,2,"SecondaryVibration");
		LuaDLL.lua_pop(l, 1);
	}
}
