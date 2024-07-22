using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_NewCoroutine : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int MyMethod_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			SLua.LuaFunction a3;
			checkType(l,3,out a3);
			var ret=NewCoroutine.MyMethod(a1,a2,a3);
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
		getTypeTable(l,"NewCoroutine");
		addMember(l,MyMethod_s);
		createTypeMetatable(l,null, typeof(NewCoroutine),typeof(UnityEngine.MonoBehaviour));
	}
}
