using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_HDROutputSettings : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RequestHDRModeChange(IntPtr l) {
		try {
			UnityEngine.HDROutputSettings self=(UnityEngine.HDROutputSettings)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			self.RequestHDRModeChange(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_displays(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.HDROutputSettings.displays);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_displays(IntPtr l) {
		try {
			UnityEngine.HDROutputSettings[] v;
			checkArray(l,2,out v);
			UnityEngine.HDROutputSettings.displays=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_main(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.HDROutputSettings.main);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_active(IntPtr l) {
		try {
			UnityEngine.HDROutputSettings self=(UnityEngine.HDROutputSettings)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.active);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_available(IntPtr l) {
		try {
			UnityEngine.HDROutputSettings self=(UnityEngine.HDROutputSettings)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.available);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_automaticHDRTonemapping(IntPtr l) {
		try {
			UnityEngine.HDROutputSettings self=(UnityEngine.HDROutputSettings)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.automaticHDRTonemapping);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_automaticHDRTonemapping(IntPtr l) {
		try {
			UnityEngine.HDROutputSettings self=(UnityEngine.HDROutputSettings)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.automaticHDRTonemapping=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_displayColorGamut(IntPtr l) {
		try {
			UnityEngine.HDROutputSettings self=(UnityEngine.HDROutputSettings)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.displayColorGamut);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_format(IntPtr l) {
		try {
			UnityEngine.HDROutputSettings self=(UnityEngine.HDROutputSettings)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.format);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_graphicsFormat(IntPtr l) {
		try {
			UnityEngine.HDROutputSettings self=(UnityEngine.HDROutputSettings)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.graphicsFormat);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_paperWhiteNits(IntPtr l) {
		try {
			UnityEngine.HDROutputSettings self=(UnityEngine.HDROutputSettings)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.paperWhiteNits);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_paperWhiteNits(IntPtr l) {
		try {
			UnityEngine.HDROutputSettings self=(UnityEngine.HDROutputSettings)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.paperWhiteNits=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maxFullFrameToneMapLuminance(IntPtr l) {
		try {
			UnityEngine.HDROutputSettings self=(UnityEngine.HDROutputSettings)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.maxFullFrameToneMapLuminance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maxToneMapLuminance(IntPtr l) {
		try {
			UnityEngine.HDROutputSettings self=(UnityEngine.HDROutputSettings)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.maxToneMapLuminance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_minToneMapLuminance(IntPtr l) {
		try {
			UnityEngine.HDROutputSettings self=(UnityEngine.HDROutputSettings)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.minToneMapLuminance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_HDRModeChangeRequested(IntPtr l) {
		try {
			UnityEngine.HDROutputSettings self=(UnityEngine.HDROutputSettings)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.HDRModeChangeRequested);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.HDROutputSettings");
		addMember(l,RequestHDRModeChange);
		addMember(l,"displays",get_displays,set_displays,false);
		addMember(l,"main",get_main,null,false);
		addMember(l,"active",get_active,null,true);
		addMember(l,"available",get_available,null,true);
		addMember(l,"automaticHDRTonemapping",get_automaticHDRTonemapping,set_automaticHDRTonemapping,true);
		addMember(l,"displayColorGamut",get_displayColorGamut,null,true);
		addMember(l,"format",get_format,null,true);
		addMember(l,"graphicsFormat",get_graphicsFormat,null,true);
		addMember(l,"paperWhiteNits",get_paperWhiteNits,set_paperWhiteNits,true);
		addMember(l,"maxFullFrameToneMapLuminance",get_maxFullFrameToneMapLuminance,null,true);
		addMember(l,"maxToneMapLuminance",get_maxToneMapLuminance,null,true);
		addMember(l,"minToneMapLuminance",get_minToneMapLuminance,null,true);
		addMember(l,"HDRModeChangeRequested",get_HDRModeChangeRequested,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.HDROutputSettings));
	}
}
