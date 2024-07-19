using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_HashUnsafeUtilities : LuaObject {
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.HashUnsafeUtilities");
		createTypeMetatable(l,null, typeof(UnityEngine.HashUnsafeUtilities));
	}
}
