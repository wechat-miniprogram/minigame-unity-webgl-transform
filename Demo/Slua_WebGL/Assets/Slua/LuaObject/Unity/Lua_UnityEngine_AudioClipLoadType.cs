using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AudioClipLoadType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.AudioClipLoadType");
		addMember(l,0,"DecompressOnLoad");
		addMember(l,1,"CompressedInMemory");
		addMember(l,2,"Streaming");
		LuaDLL.lua_pop(l, 1);
	}
}
