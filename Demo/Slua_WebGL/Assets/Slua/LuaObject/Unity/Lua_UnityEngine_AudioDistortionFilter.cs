using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AudioDistortionFilter : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_distortionLevel(IntPtr l) {
		try {
			UnityEngine.AudioDistortionFilter self=(UnityEngine.AudioDistortionFilter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.distortionLevel);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_distortionLevel(IntPtr l) {
		try {
			UnityEngine.AudioDistortionFilter self=(UnityEngine.AudioDistortionFilter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.distortionLevel=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.AudioDistortionFilter");
		addMember(l,"distortionLevel",get_distortionLevel,set_distortionLevel,true);
		createTypeMetatable(l,null, typeof(UnityEngine.AudioDistortionFilter),typeof(UnityEngine.Behaviour));
	}
}
