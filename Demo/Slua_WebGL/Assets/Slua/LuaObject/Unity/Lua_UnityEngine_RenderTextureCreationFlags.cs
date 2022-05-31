using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_RenderTextureCreationFlags : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.RenderTextureCreationFlags");
		addMember(l,1,"MipMap");
		addMember(l,2,"AutoGenerateMips");
		addMember(l,4,"SRGB");
		addMember(l,8,"EyeTexture");
		addMember(l,16,"EnableRandomWrite");
		addMember(l,32,"CreatedFromScript");
		addMember(l,128,"AllowVerticalFlip");
		addMember(l,256,"NoResolvedColorSurface");
		addMember(l,1024,"DynamicallyScalable");
		addMember(l,2048,"BindMS");
		LuaDLL.lua_pop(l, 1);
	}
}
