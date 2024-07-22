using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_CustomRenderTextureManager : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetAllCustomRenderTextures_s(IntPtr l) {
		try {
			System.Collections.Generic.List<UnityEngine.CustomRenderTexture> a1;
			checkType(l,1,out a1);
			UnityEngine.CustomRenderTextureManager.GetAllCustomRenderTextures(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.CustomRenderTextureManager");
		addMember(l,GetAllCustomRenderTextures_s);
		createTypeMetatable(l,null, typeof(UnityEngine.CustomRenderTextureManager));
	}
}
