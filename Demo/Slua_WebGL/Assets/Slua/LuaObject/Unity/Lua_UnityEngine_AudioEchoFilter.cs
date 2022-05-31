using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AudioEchoFilter : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_delay(IntPtr l) {
		try {
			UnityEngine.AudioEchoFilter self=(UnityEngine.AudioEchoFilter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.delay);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_delay(IntPtr l) {
		try {
			UnityEngine.AudioEchoFilter self=(UnityEngine.AudioEchoFilter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.delay=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_decayRatio(IntPtr l) {
		try {
			UnityEngine.AudioEchoFilter self=(UnityEngine.AudioEchoFilter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.decayRatio);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_decayRatio(IntPtr l) {
		try {
			UnityEngine.AudioEchoFilter self=(UnityEngine.AudioEchoFilter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.decayRatio=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_dryMix(IntPtr l) {
		try {
			UnityEngine.AudioEchoFilter self=(UnityEngine.AudioEchoFilter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.dryMix);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_dryMix(IntPtr l) {
		try {
			UnityEngine.AudioEchoFilter self=(UnityEngine.AudioEchoFilter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.dryMix=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_wetMix(IntPtr l) {
		try {
			UnityEngine.AudioEchoFilter self=(UnityEngine.AudioEchoFilter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.wetMix);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_wetMix(IntPtr l) {
		try {
			UnityEngine.AudioEchoFilter self=(UnityEngine.AudioEchoFilter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.wetMix=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.AudioEchoFilter");
		addMember(l,"delay",get_delay,set_delay,true);
		addMember(l,"decayRatio",get_decayRatio,set_decayRatio,true);
		addMember(l,"dryMix",get_dryMix,set_dryMix,true);
		addMember(l,"wetMix",get_wetMix,set_wetMix,true);
		createTypeMetatable(l,null, typeof(UnityEngine.AudioEchoFilter),typeof(UnityEngine.Behaviour));
	}
}
