using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_BoxCollider : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_center(IntPtr l) {
		try {
			UnityEngine.BoxCollider self=(UnityEngine.BoxCollider)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.center);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_center(IntPtr l) {
		try {
			UnityEngine.BoxCollider self=(UnityEngine.BoxCollider)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.center=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_size(IntPtr l) {
		try {
			UnityEngine.BoxCollider self=(UnityEngine.BoxCollider)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.size);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_size(IntPtr l) {
		try {
			UnityEngine.BoxCollider self=(UnityEngine.BoxCollider)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.size=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.BoxCollider");
		addMember(l,"center",get_center,set_center,true);
		addMember(l,"size",get_size,set_size,true);
		createTypeMetatable(l,null, typeof(UnityEngine.BoxCollider),typeof(UnityEngine.Collider));
	}
}
