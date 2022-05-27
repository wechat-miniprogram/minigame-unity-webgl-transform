using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Audio_AudioMixerUpdateMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.Audio.AudioMixerUpdateMode");
		addMember(l,0,"Normal");
		addMember(l,1,"UnscaledTime");
		LuaDLL.lua_pop(l, 1);
	}
}
