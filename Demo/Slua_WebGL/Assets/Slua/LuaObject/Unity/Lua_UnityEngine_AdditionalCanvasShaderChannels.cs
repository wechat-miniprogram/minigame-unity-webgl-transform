using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AdditionalCanvasShaderChannels : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.AdditionalCanvasShaderChannels");
		addMember(l,0,"None");
		addMember(l,1,"TexCoord1");
		addMember(l,2,"TexCoord2");
		addMember(l,4,"TexCoord3");
		addMember(l,8,"Normal");
		addMember(l,16,"Tangent");
		LuaDLL.lua_pop(l, 1);
	}
}
