using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AudioBehaviour : LuaObject {
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.AudioBehaviour");
		createTypeMetatable(l,null, typeof(UnityEngine.AudioBehaviour),typeof(UnityEngine.Behaviour));
	}
}
