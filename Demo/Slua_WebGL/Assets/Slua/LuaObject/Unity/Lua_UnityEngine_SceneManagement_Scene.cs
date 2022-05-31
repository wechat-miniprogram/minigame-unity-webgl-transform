using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_SceneManagement_Scene : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.SceneManagement.Scene o;
			o=new UnityEngine.SceneManagement.Scene();
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
	static public int IsValid(IntPtr l) {
		try {
			UnityEngine.SceneManagement.Scene self;
			checkValueType(l,1,out self);
			var ret=self.IsValid();
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
	static public int GetRootGameObjects(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.SceneManagement.Scene self;
				checkValueType(l,1,out self);
				var ret=self.GetRootGameObjects();
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==2){
				UnityEngine.SceneManagement.Scene self;
				checkValueType(l,1,out self);
				System.Collections.Generic.List<UnityEngine.GameObject> a1;
				checkType(l,2,out a1);
				self.GetRootGameObjects(a1);
				pushValue(l,true);
				setBack(l,self);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetRootGameObjects to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int op_Equality(IntPtr l) {
		try {
			UnityEngine.SceneManagement.Scene a1;
			checkValueType(l,1,out a1);
			UnityEngine.SceneManagement.Scene a2;
			checkValueType(l,2,out a2);
			var ret=(a1==a2);
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
	static public int op_Inequality(IntPtr l) {
		try {
			UnityEngine.SceneManagement.Scene a1;
			checkValueType(l,1,out a1);
			UnityEngine.SceneManagement.Scene a2;
			checkValueType(l,2,out a2);
			var ret=(a1!=a2);
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
	static public int get_handle(IntPtr l) {
		try {
			UnityEngine.SceneManagement.Scene self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.handle);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_path(IntPtr l) {
		try {
			UnityEngine.SceneManagement.Scene self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.path);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_name(IntPtr l) {
		try {
			UnityEngine.SceneManagement.Scene self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.name);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_name(IntPtr l) {
		try {
			UnityEngine.SceneManagement.Scene self;
			checkValueType(l,1,out self);
			string v;
			checkType(l,2,out v);
			self.name=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isLoaded(IntPtr l) {
		try {
			UnityEngine.SceneManagement.Scene self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.isLoaded);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_buildIndex(IntPtr l) {
		try {
			UnityEngine.SceneManagement.Scene self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.buildIndex);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isDirty(IntPtr l) {
		try {
			UnityEngine.SceneManagement.Scene self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.isDirty);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_rootCount(IntPtr l) {
		try {
			UnityEngine.SceneManagement.Scene self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.rootCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isSubScene(IntPtr l) {
		try {
			UnityEngine.SceneManagement.Scene self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.isSubScene);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_isSubScene(IntPtr l) {
		try {
			UnityEngine.SceneManagement.Scene self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.isSubScene=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.SceneManagement.Scene");
		addMember(l,IsValid);
		addMember(l,GetRootGameObjects);
		addMember(l,op_Equality);
		addMember(l,op_Inequality);
		addMember(l,"handle",get_handle,null,true);
		addMember(l,"path",get_path,null,true);
		addMember(l,"name",get_name,set_name,true);
		addMember(l,"isLoaded",get_isLoaded,null,true);
		addMember(l,"buildIndex",get_buildIndex,null,true);
		addMember(l,"isDirty",get_isDirty,null,true);
		addMember(l,"rootCount",get_rootCount,null,true);
		addMember(l,"isSubScene",get_isSubScene,set_isSubScene,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.SceneManagement.Scene),typeof(System.ValueType));
	}
}
