using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AsyncOperation : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.AsyncOperation o;
			o=new UnityEngine.AsyncOperation();
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
	static public int get_isDone(IntPtr l) {
		try {
			UnityEngine.AsyncOperation self=(UnityEngine.AsyncOperation)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isDone);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_progress(IntPtr l) {
		try {
			UnityEngine.AsyncOperation self=(UnityEngine.AsyncOperation)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.progress);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_priority(IntPtr l) {
		try {
			UnityEngine.AsyncOperation self=(UnityEngine.AsyncOperation)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.priority);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_priority(IntPtr l) {
		try {
			UnityEngine.AsyncOperation self=(UnityEngine.AsyncOperation)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.priority=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_allowSceneActivation(IntPtr l) {
		try {
			UnityEngine.AsyncOperation self=(UnityEngine.AsyncOperation)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.allowSceneActivation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_allowSceneActivation(IntPtr l) {
		try {
			UnityEngine.AsyncOperation self=(UnityEngine.AsyncOperation)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.allowSceneActivation=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.AsyncOperation");
		addMember(l,"isDone",get_isDone,null,true);
		addMember(l,"progress",get_progress,null,true);
		addMember(l,"priority",get_priority,set_priority,true);
		addMember(l,"allowSceneActivation",get_allowSceneActivation,set_allowSceneActivation,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.AsyncOperation),typeof(UnityEngine.YieldInstruction));
	}
}
