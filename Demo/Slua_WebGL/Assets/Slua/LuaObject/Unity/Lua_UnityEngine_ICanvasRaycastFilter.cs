using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ICanvasRaycastFilter : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int IsRaycastLocationValid(IntPtr l) {
		try {
			UnityEngine.ICanvasRaycastFilter self=(UnityEngine.ICanvasRaycastFilter)checkSelf(l);
			UnityEngine.Vector2 a1;
			checkType(l,2,out a1);
			UnityEngine.Camera a2;
			checkType(l,3,out a2);
			var ret=self.IsRaycastLocationValid(a1,a2);
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
		getTypeTable(l,"UnityEngine.ICanvasRaycastFilter");
		addMember(l,IsRaycastLocationValid);
		createTypeMetatable(l,null, typeof(UnityEngine.ICanvasRaycastFilter));
	}
}
