using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_RenderTextureFormat : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.RenderTextureFormat");
		addMember(l,0,"ARGB32");
		addMember(l,1,"Depth");
		addMember(l,2,"ARGBHalf");
		addMember(l,3,"Shadowmap");
		addMember(l,4,"RGB565");
		addMember(l,5,"ARGB4444");
		addMember(l,6,"ARGB1555");
		addMember(l,7,"Default");
		addMember(l,8,"ARGB2101010");
		addMember(l,9,"DefaultHDR");
		addMember(l,10,"ARGB64");
		addMember(l,11,"ARGBFloat");
		addMember(l,12,"RGFloat");
		addMember(l,13,"RGHalf");
		addMember(l,14,"RFloat");
		addMember(l,15,"RHalf");
		addMember(l,16,"R8");
		addMember(l,17,"ARGBInt");
		addMember(l,18,"RGInt");
		addMember(l,19,"RInt");
		addMember(l,20,"BGRA32");
		addMember(l,22,"RGB111110Float");
		addMember(l,23,"RG32");
		addMember(l,24,"RGBAUShort");
		addMember(l,25,"RG16");
		addMember(l,26,"BGRA10101010_XR");
		addMember(l,27,"BGR101010_XR");
		addMember(l,28,"R16");
		LuaDLL.lua_pop(l, 1);
	}
}
