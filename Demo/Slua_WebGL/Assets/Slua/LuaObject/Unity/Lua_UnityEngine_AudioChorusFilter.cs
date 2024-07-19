using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AudioChorusFilter : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_dryMix(IntPtr l) {
		try {
			UnityEngine.AudioChorusFilter self=(UnityEngine.AudioChorusFilter)checkSelf(l);
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
			UnityEngine.AudioChorusFilter self=(UnityEngine.AudioChorusFilter)checkSelf(l);
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
	static public int get_wetMix1(IntPtr l) {
		try {
			UnityEngine.AudioChorusFilter self=(UnityEngine.AudioChorusFilter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.wetMix1);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_wetMix1(IntPtr l) {
		try {
			UnityEngine.AudioChorusFilter self=(UnityEngine.AudioChorusFilter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.wetMix1=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_wetMix2(IntPtr l) {
		try {
			UnityEngine.AudioChorusFilter self=(UnityEngine.AudioChorusFilter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.wetMix2);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_wetMix2(IntPtr l) {
		try {
			UnityEngine.AudioChorusFilter self=(UnityEngine.AudioChorusFilter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.wetMix2=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_wetMix3(IntPtr l) {
		try {
			UnityEngine.AudioChorusFilter self=(UnityEngine.AudioChorusFilter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.wetMix3);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_wetMix3(IntPtr l) {
		try {
			UnityEngine.AudioChorusFilter self=(UnityEngine.AudioChorusFilter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.wetMix3=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_delay(IntPtr l) {
		try {
			UnityEngine.AudioChorusFilter self=(UnityEngine.AudioChorusFilter)checkSelf(l);
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
			UnityEngine.AudioChorusFilter self=(UnityEngine.AudioChorusFilter)checkSelf(l);
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
	static public int get_rate(IntPtr l) {
		try {
			UnityEngine.AudioChorusFilter self=(UnityEngine.AudioChorusFilter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.rate);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_rate(IntPtr l) {
		try {
			UnityEngine.AudioChorusFilter self=(UnityEngine.AudioChorusFilter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.rate=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_depth(IntPtr l) {
		try {
			UnityEngine.AudioChorusFilter self=(UnityEngine.AudioChorusFilter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.depth);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_depth(IntPtr l) {
		try {
			UnityEngine.AudioChorusFilter self=(UnityEngine.AudioChorusFilter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.depth=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.AudioChorusFilter");
		addMember(l,"dryMix",get_dryMix,set_dryMix,true);
		addMember(l,"wetMix1",get_wetMix1,set_wetMix1,true);
		addMember(l,"wetMix2",get_wetMix2,set_wetMix2,true);
		addMember(l,"wetMix3",get_wetMix3,set_wetMix3,true);
		addMember(l,"delay",get_delay,set_delay,true);
		addMember(l,"rate",get_rate,set_rate,true);
		addMember(l,"depth",get_depth,set_depth,true);
		createTypeMetatable(l,null, typeof(UnityEngine.AudioChorusFilter),typeof(UnityEngine.Behaviour));
	}
}
