using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AudioListener : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetOutputData_s(IntPtr l) {
		try {
			System.Single[] a1;
			checkArray(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			UnityEngine.AudioListener.GetOutputData(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetSpectrumData_s(IntPtr l) {
		try {
			System.Single[] a1;
			checkArray(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			UnityEngine.FFTWindow a3;
			a3 = (UnityEngine.FFTWindow)LuaDLL.luaL_checkinteger(l, 3);
			UnityEngine.AudioListener.GetSpectrumData(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_volume(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.AudioListener.volume);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_volume(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.AudioListener.volume=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_pause(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.AudioListener.pause);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_pause(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.AudioListener.pause=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_velocityUpdateMode(IntPtr l) {
		try {
			UnityEngine.AudioListener self=(UnityEngine.AudioListener)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.velocityUpdateMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_velocityUpdateMode(IntPtr l) {
		try {
			UnityEngine.AudioListener self=(UnityEngine.AudioListener)checkSelf(l);
			UnityEngine.AudioVelocityUpdateMode v;
			v = (UnityEngine.AudioVelocityUpdateMode)LuaDLL.luaL_checkinteger(l, 2);
			self.velocityUpdateMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.AudioListener");
		addMember(l,GetOutputData_s);
		addMember(l,GetSpectrumData_s);
		addMember(l,"volume",get_volume,set_volume,false);
		addMember(l,"pause",get_pause,set_pause,false);
		addMember(l,"velocityUpdateMode",get_velocityUpdateMode,set_velocityUpdateMode,true);
		createTypeMetatable(l,null, typeof(UnityEngine.AudioListener),typeof(UnityEngine.AudioBehaviour));
	}
}
