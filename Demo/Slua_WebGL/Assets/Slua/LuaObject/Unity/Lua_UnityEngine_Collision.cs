using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Collision : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Collision o;
			o=new UnityEngine.Collision();
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
	static public int GetContact(IntPtr l) {
		try {
			UnityEngine.Collision self=(UnityEngine.Collision)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetContact(a1);
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
	static public int GetContacts(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(UnityEngine.ContactPoint[]))){
				UnityEngine.Collision self=(UnityEngine.Collision)checkSelf(l);
				UnityEngine.ContactPoint[] a1;
				checkArray(l,2,out a1);
				var ret=self.GetContacts(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(List<UnityEngine.ContactPoint>))){
				UnityEngine.Collision self=(UnityEngine.Collision)checkSelf(l);
				System.Collections.Generic.List<UnityEngine.ContactPoint> a1;
				checkType(l,2,out a1);
				var ret=self.GetContacts(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetContacts to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_relativeVelocity(IntPtr l) {
		try {
			UnityEngine.Collision self=(UnityEngine.Collision)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.relativeVelocity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_rigidbody(IntPtr l) {
		try {
			UnityEngine.Collision self=(UnityEngine.Collision)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.rigidbody);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_articulationBody(IntPtr l) {
		try {
			UnityEngine.Collision self=(UnityEngine.Collision)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.articulationBody);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_body(IntPtr l) {
		try {
			UnityEngine.Collision self=(UnityEngine.Collision)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.body);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_collider(IntPtr l) {
		try {
			UnityEngine.Collision self=(UnityEngine.Collision)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.collider);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_transform(IntPtr l) {
		try {
			UnityEngine.Collision self=(UnityEngine.Collision)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.transform);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_gameObject(IntPtr l) {
		try {
			UnityEngine.Collision self=(UnityEngine.Collision)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.gameObject);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_contactCount(IntPtr l) {
		try {
			UnityEngine.Collision self=(UnityEngine.Collision)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.contactCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_contacts(IntPtr l) {
		try {
			UnityEngine.Collision self=(UnityEngine.Collision)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.contacts);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_impulse(IntPtr l) {
		try {
			UnityEngine.Collision self=(UnityEngine.Collision)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.impulse);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Collision");
		addMember(l,GetContact);
		addMember(l,GetContacts);
		addMember(l,"relativeVelocity",get_relativeVelocity,null,true);
		addMember(l,"rigidbody",get_rigidbody,null,true);
		addMember(l,"articulationBody",get_articulationBody,null,true);
		addMember(l,"body",get_body,null,true);
		addMember(l,"collider",get_collider,null,true);
		addMember(l,"transform",get_transform,null,true);
		addMember(l,"gameObject",get_gameObject,null,true);
		addMember(l,"contactCount",get_contactCount,null,true);
		addMember(l,"contacts",get_contacts,null,true);
		addMember(l,"impulse",get_impulse,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Collision));
	}
}
