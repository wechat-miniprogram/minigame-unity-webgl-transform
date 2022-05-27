using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Logger : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Logger o;
			UnityEngine.ILogHandler a1;
			checkType(l,2,out a1);
			o=new UnityEngine.Logger(a1);
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
	static public int IsLogTypeAllowed(IntPtr l) {
		try {
			UnityEngine.Logger self=(UnityEngine.Logger)checkSelf(l);
			UnityEngine.LogType a1;
			a1 = (UnityEngine.LogType)LuaDLL.luaL_checkinteger(l, 2);
			var ret=self.IsLogTypeAllowed(a1);
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
	static public int Log(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Logger self=(UnityEngine.Logger)checkSelf(l);
				System.Object a1;
				checkType(l,2,out a1);
				self.Log(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.LogType),typeof(System.Object))){
				UnityEngine.Logger self=(UnityEngine.Logger)checkSelf(l);
				UnityEngine.LogType a1;
				a1 = (UnityEngine.LogType)LuaDLL.luaL_checkinteger(l, 2);
				System.Object a2;
				checkType(l,3,out a2);
				self.Log(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(System.Object))){
				UnityEngine.Logger self=(UnityEngine.Logger)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Object a2;
				checkType(l,3,out a2);
				self.Log(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.LogType),typeof(System.Object),typeof(UnityEngine.Object))){
				UnityEngine.Logger self=(UnityEngine.Logger)checkSelf(l);
				UnityEngine.LogType a1;
				a1 = (UnityEngine.LogType)LuaDLL.luaL_checkinteger(l, 2);
				System.Object a2;
				checkType(l,3,out a2);
				UnityEngine.Object a3;
				checkType(l,4,out a3);
				self.Log(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.LogType),typeof(string),typeof(System.Object))){
				UnityEngine.Logger self=(UnityEngine.Logger)checkSelf(l);
				UnityEngine.LogType a1;
				a1 = (UnityEngine.LogType)LuaDLL.luaL_checkinteger(l, 2);
				System.String a2;
				checkType(l,3,out a2);
				System.Object a3;
				checkType(l,4,out a3);
				self.Log(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(System.Object),typeof(UnityEngine.Object))){
				UnityEngine.Logger self=(UnityEngine.Logger)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Object a2;
				checkType(l,3,out a2);
				UnityEngine.Object a3;
				checkType(l,4,out a3);
				self.Log(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Logger self=(UnityEngine.Logger)checkSelf(l);
				UnityEngine.LogType a1;
				a1 = (UnityEngine.LogType)LuaDLL.luaL_checkinteger(l, 2);
				System.String a2;
				checkType(l,3,out a2);
				System.Object a3;
				checkType(l,4,out a3);
				UnityEngine.Object a4;
				checkType(l,5,out a4);
				self.Log(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Log to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int LogWarning(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.Logger self=(UnityEngine.Logger)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Object a2;
				checkType(l,3,out a2);
				self.LogWarning(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Logger self=(UnityEngine.Logger)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Object a2;
				checkType(l,3,out a2);
				UnityEngine.Object a3;
				checkType(l,4,out a3);
				self.LogWarning(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function LogWarning to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int LogError(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.Logger self=(UnityEngine.Logger)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Object a2;
				checkType(l,3,out a2);
				self.LogError(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Logger self=(UnityEngine.Logger)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Object a2;
				checkType(l,3,out a2);
				UnityEngine.Object a3;
				checkType(l,4,out a3);
				self.LogError(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function LogError to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int LogException(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Logger self=(UnityEngine.Logger)checkSelf(l);
				System.Exception a1;
				checkType(l,2,out a1);
				self.LogException(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Logger self=(UnityEngine.Logger)checkSelf(l);
				System.Exception a1;
				checkType(l,2,out a1);
				UnityEngine.Object a2;
				checkType(l,3,out a2);
				self.LogException(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function LogException to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int LogFormat(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==4){
				UnityEngine.Logger self=(UnityEngine.Logger)checkSelf(l);
				UnityEngine.LogType a1;
				a1 = (UnityEngine.LogType)LuaDLL.luaL_checkinteger(l, 2);
				System.String a2;
				checkType(l,3,out a2);
				System.Object[] a3;
				checkParams(l,4,out a3);
				self.LogFormat(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Logger self=(UnityEngine.Logger)checkSelf(l);
				UnityEngine.LogType a1;
				a1 = (UnityEngine.LogType)LuaDLL.luaL_checkinteger(l, 2);
				UnityEngine.Object a2;
				checkType(l,3,out a2);
				System.String a3;
				checkType(l,4,out a3);
				System.Object[] a4;
				checkParams(l,5,out a4);
				self.LogFormat(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function LogFormat to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_logHandler(IntPtr l) {
		try {
			UnityEngine.Logger self=(UnityEngine.Logger)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.logHandler);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_logHandler(IntPtr l) {
		try {
			UnityEngine.Logger self=(UnityEngine.Logger)checkSelf(l);
			UnityEngine.ILogHandler v;
			checkType(l,2,out v);
			self.logHandler=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_logEnabled(IntPtr l) {
		try {
			UnityEngine.Logger self=(UnityEngine.Logger)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.logEnabled);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_logEnabled(IntPtr l) {
		try {
			UnityEngine.Logger self=(UnityEngine.Logger)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.logEnabled=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_filterLogType(IntPtr l) {
		try {
			UnityEngine.Logger self=(UnityEngine.Logger)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.filterLogType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_filterLogType(IntPtr l) {
		try {
			UnityEngine.Logger self=(UnityEngine.Logger)checkSelf(l);
			UnityEngine.LogType v;
			v = (UnityEngine.LogType)LuaDLL.luaL_checkinteger(l, 2);
			self.filterLogType=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Logger");
		addMember(l,IsLogTypeAllowed);
		addMember(l,Log);
		addMember(l,LogWarning);
		addMember(l,LogError);
		addMember(l,LogException);
		addMember(l,LogFormat);
		addMember(l,"logHandler",get_logHandler,set_logHandler,true);
		addMember(l,"logEnabled",get_logEnabled,set_logEnabled,true);
		addMember(l,"filterLogType",get_filterLogType,set_filterLogType,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Logger));
	}
}
