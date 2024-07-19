using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_BillboardRenderer : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_billboard(IntPtr l) {
		try {
			UnityEngine.BillboardRenderer self=(UnityEngine.BillboardRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.billboard);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_billboard(IntPtr l) {
		try {
			UnityEngine.BillboardRenderer self=(UnityEngine.BillboardRenderer)checkSelf(l);
			UnityEngine.BillboardAsset v;
			checkType(l,2,out v);
			self.billboard=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.BillboardRenderer");
		addMember(l,"billboard",get_billboard,set_billboard,true);
		createTypeMetatable(l,null, typeof(UnityEngine.BillboardRenderer),typeof(UnityEngine.Renderer));
	}
}
