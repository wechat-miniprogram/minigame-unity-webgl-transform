using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_IMeshModifier : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ModifyMesh(IntPtr l) {
		try {
			UnityEngine.UI.IMeshModifier self=(UnityEngine.UI.IMeshModifier)checkSelf(l);
			UnityEngine.UI.VertexHelper a1;
			checkType(l,2,out a1);
			self.ModifyMesh(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.IMeshModifier");
		addMember(l,ModifyMesh);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.IMeshModifier));
	}
}
