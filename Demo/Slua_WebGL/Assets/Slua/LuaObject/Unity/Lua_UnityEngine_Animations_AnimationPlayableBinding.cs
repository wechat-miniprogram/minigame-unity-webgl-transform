using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Animations_AnimationPlayableBinding : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Create_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			UnityEngine.Object a2;
			checkType(l,2,out a2);
			var ret=UnityEngine.Animations.AnimationPlayableBinding.Create(a1,a2);
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
		getTypeTable(l,"UnityEngine.Animations.AnimationPlayableBinding");
		addMember(l,Create_s);
		createTypeMetatable(l,null, typeof(UnityEngine.Animations.AnimationPlayableBinding));
	}
}
