using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ResourceRequest : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.ResourceRequest o;
			o=new UnityEngine.ResourceRequest();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_asset(IntPtr l) {
		try {
			UnityEngine.ResourceRequest self=(UnityEngine.ResourceRequest)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.asset);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.ResourceRequest");
		addMember(l,"asset",get_asset,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ResourceRequest),typeof(UnityEngine.AsyncOperation));
	}
}
