using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AudioRenderer : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.AudioRenderer o;
			o=new UnityEngine.AudioRenderer();
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
	static public int Start_s(IntPtr l) {
		try {
			var ret=UnityEngine.AudioRenderer.Start();
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
	static public int Stop_s(IntPtr l) {
		try {
			var ret=UnityEngine.AudioRenderer.Stop();
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
	static public int GetSampleCountForCaptureFrame_s(IntPtr l) {
		try {
			var ret=UnityEngine.AudioRenderer.GetSampleCountForCaptureFrame();
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
	static public int Render_s(IntPtr l) {
		try {
			Unity.Collections.NativeArray<System.Single> a1;
			checkValueType(l,1,out a1);
			var ret=UnityEngine.AudioRenderer.Render(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.AudioRenderer");
		addMember(l,Start_s);
		addMember(l,Stop_s);
		addMember(l,GetSampleCountForCaptureFrame_s);
		addMember(l,Render_s);
		createTypeMetatable(l,constructor, typeof(UnityEngine.AudioRenderer));
	}
}
