using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_RenderParams : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.RenderParams o;
			UnityEngine.Material a1;
			checkType(l,2,out a1);
			o=new UnityEngine.RenderParams(a1);
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
	static public int get_layer(IntPtr l) {
		try {
			UnityEngine.RenderParams self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.layer);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_layer(IntPtr l) {
		try {
			UnityEngine.RenderParams self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.layer=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_renderingLayerMask(IntPtr l) {
		try {
			UnityEngine.RenderParams self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.renderingLayerMask);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_renderingLayerMask(IntPtr l) {
		try {
			UnityEngine.RenderParams self;
			checkValueType(l,1,out self);
			System.UInt32 v;
			checkType(l,2,out v);
			self.renderingLayerMask=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_rendererPriority(IntPtr l) {
		try {
			UnityEngine.RenderParams self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.rendererPriority);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_rendererPriority(IntPtr l) {
		try {
			UnityEngine.RenderParams self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.rendererPriority=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_worldBounds(IntPtr l) {
		try {
			UnityEngine.RenderParams self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.worldBounds);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_worldBounds(IntPtr l) {
		try {
			UnityEngine.RenderParams self;
			checkValueType(l,1,out self);
			UnityEngine.Bounds v;
			checkValueType(l,2,out v);
			self.worldBounds=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_camera(IntPtr l) {
		try {
			UnityEngine.RenderParams self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.camera);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_camera(IntPtr l) {
		try {
			UnityEngine.RenderParams self;
			checkValueType(l,1,out self);
			UnityEngine.Camera v;
			checkType(l,2,out v);
			self.camera=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_motionVectorMode(IntPtr l) {
		try {
			UnityEngine.RenderParams self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.motionVectorMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_motionVectorMode(IntPtr l) {
		try {
			UnityEngine.RenderParams self;
			checkValueType(l,1,out self);
			UnityEngine.MotionVectorGenerationMode v;
			v = (UnityEngine.MotionVectorGenerationMode)LuaDLL.luaL_checkinteger(l, 2);
			self.motionVectorMode=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_reflectionProbeUsage(IntPtr l) {
		try {
			UnityEngine.RenderParams self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.reflectionProbeUsage);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_reflectionProbeUsage(IntPtr l) {
		try {
			UnityEngine.RenderParams self;
			checkValueType(l,1,out self);
			UnityEngine.Rendering.ReflectionProbeUsage v;
			v = (UnityEngine.Rendering.ReflectionProbeUsage)LuaDLL.luaL_checkinteger(l, 2);
			self.reflectionProbeUsage=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_material(IntPtr l) {
		try {
			UnityEngine.RenderParams self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.material);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_material(IntPtr l) {
		try {
			UnityEngine.RenderParams self;
			checkValueType(l,1,out self);
			UnityEngine.Material v;
			checkType(l,2,out v);
			self.material=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_matProps(IntPtr l) {
		try {
			UnityEngine.RenderParams self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.matProps);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_matProps(IntPtr l) {
		try {
			UnityEngine.RenderParams self;
			checkValueType(l,1,out self);
			UnityEngine.MaterialPropertyBlock v;
			checkType(l,2,out v);
			self.matProps=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_shadowCastingMode(IntPtr l) {
		try {
			UnityEngine.RenderParams self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.shadowCastingMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_shadowCastingMode(IntPtr l) {
		try {
			UnityEngine.RenderParams self;
			checkValueType(l,1,out self);
			UnityEngine.Rendering.ShadowCastingMode v;
			v = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 2);
			self.shadowCastingMode=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_receiveShadows(IntPtr l) {
		try {
			UnityEngine.RenderParams self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.receiveShadows);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_receiveShadows(IntPtr l) {
		try {
			UnityEngine.RenderParams self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.receiveShadows=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_lightProbeUsage(IntPtr l) {
		try {
			UnityEngine.RenderParams self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.lightProbeUsage);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_lightProbeUsage(IntPtr l) {
		try {
			UnityEngine.RenderParams self;
			checkValueType(l,1,out self);
			UnityEngine.Rendering.LightProbeUsage v;
			v = (UnityEngine.Rendering.LightProbeUsage)LuaDLL.luaL_checkinteger(l, 2);
			self.lightProbeUsage=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_lightProbeProxyVolume(IntPtr l) {
		try {
			UnityEngine.RenderParams self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.lightProbeProxyVolume);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_lightProbeProxyVolume(IntPtr l) {
		try {
			UnityEngine.RenderParams self;
			checkValueType(l,1,out self);
			UnityEngine.LightProbeProxyVolume v;
			checkType(l,2,out v);
			self.lightProbeProxyVolume=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.RenderParams");
		addMember(l,"layer",get_layer,set_layer,true);
		addMember(l,"renderingLayerMask",get_renderingLayerMask,set_renderingLayerMask,true);
		addMember(l,"rendererPriority",get_rendererPriority,set_rendererPriority,true);
		addMember(l,"worldBounds",get_worldBounds,set_worldBounds,true);
		addMember(l,"camera",get_camera,set_camera,true);
		addMember(l,"motionVectorMode",get_motionVectorMode,set_motionVectorMode,true);
		addMember(l,"reflectionProbeUsage",get_reflectionProbeUsage,set_reflectionProbeUsage,true);
		addMember(l,"material",get_material,set_material,true);
		addMember(l,"matProps",get_matProps,set_matProps,true);
		addMember(l,"shadowCastingMode",get_shadowCastingMode,set_shadowCastingMode,true);
		addMember(l,"receiveShadows",get_receiveShadows,set_receiveShadows,true);
		addMember(l,"lightProbeUsage",get_lightProbeUsage,set_lightProbeUsage,true);
		addMember(l,"lightProbeProxyVolume",get_lightProbeProxyVolume,set_lightProbeProxyVolume,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.RenderParams),typeof(System.ValueType));
	}
}
