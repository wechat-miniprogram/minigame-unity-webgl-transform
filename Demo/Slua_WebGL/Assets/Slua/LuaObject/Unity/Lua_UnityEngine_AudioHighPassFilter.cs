using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AudioHighPassFilter : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_cutoffFrequency(IntPtr l) {
		try {
			UnityEngine.AudioHighPassFilter self=(UnityEngine.AudioHighPassFilter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.cutoffFrequency);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_cutoffFrequency(IntPtr l) {
		try {
			UnityEngine.AudioHighPassFilter self=(UnityEngine.AudioHighPassFilter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.cutoffFrequency=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_highpassResonanceQ(IntPtr l) {
		try {
			UnityEngine.AudioHighPassFilter self=(UnityEngine.AudioHighPassFilter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.highpassResonanceQ);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_highpassResonanceQ(IntPtr l) {
		try {
			UnityEngine.AudioHighPassFilter self=(UnityEngine.AudioHighPassFilter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.highpassResonanceQ=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.AudioHighPassFilter");
		addMember(l,"cutoffFrequency",get_cutoffFrequency,set_cutoffFrequency,true);
		addMember(l,"highpassResonanceQ",get_highpassResonanceQ,set_highpassResonanceQ,true);
		createTypeMetatable(l,null, typeof(UnityEngine.AudioHighPassFilter),typeof(UnityEngine.Behaviour));
	}
}
