using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Collider : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ClosestPoint(IntPtr l) {
		try {
			UnityEngine.Collider self=(UnityEngine.Collider)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			var ret=self.ClosestPoint(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Raycast(IntPtr l) {
		try {
			UnityEngine.Collider self=(UnityEngine.Collider)checkSelf(l);
			UnityEngine.Ray a1;
			checkValueType(l,2,out a1);
			UnityEngine.RaycastHit a2;
			System.Single a3;
			checkType(l,4,out a3);
			var ret=self.Raycast(a1,out a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			pushValue(l,a2);
			return 3;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ClosestPointOnBounds(IntPtr l) {
		try {
			UnityEngine.Collider self=(UnityEngine.Collider)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			var ret=self.ClosestPointOnBounds(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_enabled(IntPtr l) {
		try {
			UnityEngine.Collider self=(UnityEngine.Collider)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.enabled);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_enabled(IntPtr l) {
		try {
			UnityEngine.Collider self=(UnityEngine.Collider)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.enabled=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_attachedRigidbody(IntPtr l) {
		try {
			UnityEngine.Collider self=(UnityEngine.Collider)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.attachedRigidbody);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_attachedArticulationBody(IntPtr l) {
		try {
			UnityEngine.Collider self=(UnityEngine.Collider)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.attachedArticulationBody);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isTrigger(IntPtr l) {
		try {
			UnityEngine.Collider self=(UnityEngine.Collider)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isTrigger);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_isTrigger(IntPtr l) {
		try {
			UnityEngine.Collider self=(UnityEngine.Collider)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.isTrigger=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_contactOffset(IntPtr l) {
		try {
			UnityEngine.Collider self=(UnityEngine.Collider)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.contactOffset);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_contactOffset(IntPtr l) {
		try {
			UnityEngine.Collider self=(UnityEngine.Collider)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.contactOffset=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_bounds(IntPtr l) {
		try {
			UnityEngine.Collider self=(UnityEngine.Collider)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.bounds);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_hasModifiableContacts(IntPtr l) {
		try {
			UnityEngine.Collider self=(UnityEngine.Collider)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.hasModifiableContacts);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_hasModifiableContacts(IntPtr l) {
		try {
			UnityEngine.Collider self=(UnityEngine.Collider)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.hasModifiableContacts=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_sharedMaterial(IntPtr l) {
		try {
			UnityEngine.Collider self=(UnityEngine.Collider)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.sharedMaterial);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_sharedMaterial(IntPtr l) {
		try {
			UnityEngine.Collider self=(UnityEngine.Collider)checkSelf(l);
			UnityEngine.PhysicMaterial v;
			checkType(l,2,out v);
			self.sharedMaterial=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_material(IntPtr l) {
		try {
			UnityEngine.Collider self=(UnityEngine.Collider)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.material);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_material(IntPtr l) {
		try {
			UnityEngine.Collider self=(UnityEngine.Collider)checkSelf(l);
			UnityEngine.PhysicMaterial v;
			checkType(l,2,out v);
			self.material=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Collider");
		addMember(l,ClosestPoint);
		addMember(l,Raycast);
		addMember(l,ClosestPointOnBounds);
		addMember(l,"enabled",get_enabled,set_enabled,true);
		addMember(l,"attachedRigidbody",get_attachedRigidbody,null,true);
		addMember(l,"attachedArticulationBody",get_attachedArticulationBody,null,true);
		addMember(l,"isTrigger",get_isTrigger,set_isTrigger,true);
		addMember(l,"contactOffset",get_contactOffset,set_contactOffset,true);
		addMember(l,"bounds",get_bounds,null,true);
		addMember(l,"hasModifiableContacts",get_hasModifiableContacts,set_hasModifiableContacts,true);
		addMember(l,"sharedMaterial",get_sharedMaterial,set_sharedMaterial,true);
		addMember(l,"material",get_material,set_material,true);
		createTypeMetatable(l,null, typeof(UnityEngine.Collider),typeof(UnityEngine.Component));
	}
}
