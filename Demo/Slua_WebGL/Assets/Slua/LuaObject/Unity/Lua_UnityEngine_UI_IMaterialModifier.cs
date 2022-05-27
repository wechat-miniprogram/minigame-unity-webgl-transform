using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_IMaterialModifier : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetModifiedMaterial(IntPtr l) {
		try {
			UnityEngine.UI.IMaterialModifier self=(UnityEngine.UI.IMaterialModifier)checkSelf(l);
			UnityEngine.Material a1;
			checkType(l,2,out a1);
			var ret=self.GetModifiedMaterial(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.IMaterialModifier");
		addMember(l,GetModifiedMaterial);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.IMaterialModifier));
	}
}
