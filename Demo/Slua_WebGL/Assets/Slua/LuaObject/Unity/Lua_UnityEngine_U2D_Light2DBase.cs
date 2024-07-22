using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_U2D_Light2DBase : LuaObject {
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.U2D.Light2DBase");
		createTypeMetatable(l,null, typeof(UnityEngine.U2D.Light2DBase),typeof(UnityEngine.MonoBehaviour));
	}
}
