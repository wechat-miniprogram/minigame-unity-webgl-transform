using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Camera_RenderRequest : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			UnityEngine.Camera.RenderRequest o;
			if(argc==3){
				UnityEngine.Camera.RenderRequestMode a1;
				a1 = (UnityEngine.Camera.RenderRequestMode)LuaDLL.luaL_checkinteger(l, 2);
				UnityEngine.RenderTexture a2;
				checkType(l,3,out a2);
				o=new UnityEngine.Camera.RenderRequest(a1,a2);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==4){
				UnityEngine.Camera.RenderRequestMode a1;
				a1 = (UnityEngine.Camera.RenderRequestMode)LuaDLL.luaL_checkinteger(l, 2);
				UnityEngine.Camera.RenderRequestOutputSpace a2;
				a2 = (UnityEngine.Camera.RenderRequestOutputSpace)LuaDLL.luaL_checkinteger(l, 3);
				UnityEngine.RenderTexture a3;
				checkType(l,4,out a3);
				o=new UnityEngine.Camera.RenderRequest(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==0){
				o=new UnityEngine.Camera.RenderRequest();
				pushValue(l,true);
				pushObject(l,o);
				return 2;
			}
			return error(l,"New object failed.");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isValid(IntPtr l) {
		try {
			UnityEngine.Camera.RenderRequest self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.isValid);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_mode(IntPtr l) {
		try {
			UnityEngine.Camera.RenderRequest self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.mode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_result(IntPtr l) {
		try {
			UnityEngine.Camera.RenderRequest self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.result);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_outputSpace(IntPtr l) {
		try {
			UnityEngine.Camera.RenderRequest self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.outputSpace);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Camera.RenderRequest");
		addMember(l,"isValid",get_isValid,null,true);
		addMember(l,"mode",get_mode,null,true);
		addMember(l,"result",get_result,null,true);
		addMember(l,"outputSpace",get_outputSpace,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Camera.RenderRequest),typeof(System.ValueType));
	}
}
