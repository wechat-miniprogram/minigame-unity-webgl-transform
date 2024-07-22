using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Camera_RenderRequestMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.Camera.RenderRequestMode");
		addMember(l,0,"None");
		addMember(l,1,"ObjectId");
		addMember(l,2,"Depth");
		addMember(l,3,"VertexNormal");
		addMember(l,4,"WorldPosition");
		addMember(l,5,"EntityId");
		addMember(l,6,"BaseColor");
		addMember(l,7,"SpecularColor");
		addMember(l,8,"Metallic");
		addMember(l,9,"Emission");
		addMember(l,10,"Normal");
		addMember(l,11,"Smoothness");
		addMember(l,12,"Occlusion");
		addMember(l,13,"DiffuseColor");
		LuaDLL.lua_pop(l, 1);
	}
}
