using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_Unity_Rendering_HybridV2_HybridV2ShaderReflection : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			Unity.Rendering.HybridV2.HybridV2ShaderReflection o;
			o=new Unity.Rendering.HybridV2.HybridV2ShaderReflection();
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
	static public int GetDOTSReflectionVersionNumber_s(IntPtr l) {
		try {
			var ret=Unity.Rendering.HybridV2.HybridV2ShaderReflection.GetDOTSReflectionVersionNumber();
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
	static public int GetDOTSInstancingCbuffers_s(IntPtr l) {
		try {
			UnityEngine.Shader a1;
			checkType(l,1,out a1);
			var ret=Unity.Rendering.HybridV2.HybridV2ShaderReflection.GetDOTSInstancingCbuffers(a1);
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
	static public int GetDOTSInstancingProperties_s(IntPtr l) {
		try {
			UnityEngine.Shader a1;
			checkType(l,1,out a1);
			var ret=Unity.Rendering.HybridV2.HybridV2ShaderReflection.GetDOTSInstancingProperties(a1);
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
		getTypeTable(l,"Unity.Rendering.HybridV2.HybridV2ShaderReflection");
		addMember(l,GetDOTSReflectionVersionNumber_s);
		addMember(l,GetDOTSInstancingCbuffers_s);
		addMember(l,GetDOTSInstancingProperties_s);
		createTypeMetatable(l,constructor, typeof(Unity.Rendering.HybridV2.HybridV2ShaderReflection));
	}
}
