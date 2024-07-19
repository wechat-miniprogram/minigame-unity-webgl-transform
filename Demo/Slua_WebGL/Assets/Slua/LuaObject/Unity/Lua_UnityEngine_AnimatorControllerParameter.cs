using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AnimatorControllerParameter : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.AnimatorControllerParameter o;
			o=new UnityEngine.AnimatorControllerParameter();
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
	static public int get_nameHash(IntPtr l) {
		try {
			UnityEngine.AnimatorControllerParameter self=(UnityEngine.AnimatorControllerParameter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.nameHash);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_type(IntPtr l) {
		try {
			UnityEngine.AnimatorControllerParameter self=(UnityEngine.AnimatorControllerParameter)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.type);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_type(IntPtr l) {
		try {
			UnityEngine.AnimatorControllerParameter self=(UnityEngine.AnimatorControllerParameter)checkSelf(l);
			UnityEngine.AnimatorControllerParameterType v;
			v = (UnityEngine.AnimatorControllerParameterType)LuaDLL.luaL_checkinteger(l, 2);
			self.type=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_defaultFloat(IntPtr l) {
		try {
			UnityEngine.AnimatorControllerParameter self=(UnityEngine.AnimatorControllerParameter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.defaultFloat);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_defaultFloat(IntPtr l) {
		try {
			UnityEngine.AnimatorControllerParameter self=(UnityEngine.AnimatorControllerParameter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.defaultFloat=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_defaultInt(IntPtr l) {
		try {
			UnityEngine.AnimatorControllerParameter self=(UnityEngine.AnimatorControllerParameter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.defaultInt);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_defaultInt(IntPtr l) {
		try {
			UnityEngine.AnimatorControllerParameter self=(UnityEngine.AnimatorControllerParameter)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.defaultInt=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_defaultBool(IntPtr l) {
		try {
			UnityEngine.AnimatorControllerParameter self=(UnityEngine.AnimatorControllerParameter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.defaultBool);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_defaultBool(IntPtr l) {
		try {
			UnityEngine.AnimatorControllerParameter self=(UnityEngine.AnimatorControllerParameter)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.defaultBool=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.AnimatorControllerParameter");
		addMember(l,"nameHash",get_nameHash,null,true);
		addMember(l,"type",get_type,set_type,true);
		addMember(l,"defaultFloat",get_defaultFloat,set_defaultFloat,true);
		addMember(l,"defaultInt",get_defaultInt,set_defaultInt,true);
		addMember(l,"defaultBool",get_defaultBool,set_defaultBool,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.AnimatorControllerParameter));
	}
}
