using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystem_TextureSheetAnimationModule : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule o;
			o=new UnityEngine.ParticleSystem.TextureSheetAnimationModule();
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
	static public int AddSprite(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			UnityEngine.Sprite a1;
			checkType(l,2,out a1);
			self.AddSprite(a1);
			pushValue(l,true);
			setBack(l,self);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RemoveSprite(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			self.RemoveSprite(a1);
			pushValue(l,true);
			setBack(l,self);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetSprite(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			UnityEngine.Sprite a2;
			checkType(l,3,out a2);
			self.SetSprite(a1,a2);
			pushValue(l,true);
			setBack(l,self);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetSprite(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetSprite(a1);
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
	static public int get_enabled(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.enabled);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_enabled(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.enabled=v;
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
	static public int get_mode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
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
	static public int set_mode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemAnimationMode v;
			v = (UnityEngine.ParticleSystemAnimationMode)LuaDLL.luaL_checkinteger(l, 2);
			self.mode=v;
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
	static public int get_timeMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.timeMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_timeMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemAnimationTimeMode v;
			v = (UnityEngine.ParticleSystemAnimationTimeMode)LuaDLL.luaL_checkinteger(l, 2);
			self.timeMode=v;
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
	static public int get_fps(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.fps);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_fps(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.fps=v;
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
	static public int get_numTilesX(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.numTilesX);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_numTilesX(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.numTilesX=v;
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
	static public int get_numTilesY(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.numTilesY);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_numTilesY(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.numTilesY=v;
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
	static public int get_animation(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.animation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_animation(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemAnimationType v;
			v = (UnityEngine.ParticleSystemAnimationType)LuaDLL.luaL_checkinteger(l, 2);
			self.animation=v;
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
	static public int get_rowMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.rowMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_rowMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemAnimationRowMode v;
			v = (UnityEngine.ParticleSystemAnimationRowMode)LuaDLL.luaL_checkinteger(l, 2);
			self.rowMode=v;
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
	static public int get_frameOverTime(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.frameOverTime);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_frameOverTime(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.frameOverTime=v;
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
	static public int get_frameOverTimeMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.frameOverTimeMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_frameOverTimeMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.frameOverTimeMultiplier=v;
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
	static public int get_startFrame(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startFrame);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startFrame(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.startFrame=v;
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
	static public int get_startFrameMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startFrameMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startFrameMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.startFrameMultiplier=v;
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
	static public int get_cycleCount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.cycleCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_cycleCount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.cycleCount=v;
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
	static public int get_rowIndex(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.rowIndex);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_rowIndex(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.rowIndex=v;
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
	static public int get_uvChannelMask(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.uvChannelMask);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_uvChannelMask(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			UnityEngine.Rendering.UVChannelFlags v;
			v = (UnityEngine.Rendering.UVChannelFlags)LuaDLL.luaL_checkinteger(l, 2);
			self.uvChannelMask=v;
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
	static public int get_spriteCount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.spriteCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_speedRange(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.speedRange);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_speedRange(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TextureSheetAnimationModule self;
			checkValueType(l,1,out self);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.speedRange=v;
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
		getTypeTable(l,"UnityEngine.ParticleSystem.TextureSheetAnimationModule");
		addMember(l,AddSprite);
		addMember(l,RemoveSprite);
		addMember(l,SetSprite);
		addMember(l,GetSprite);
		addMember(l,"enabled",get_enabled,set_enabled,true);
		addMember(l,"mode",get_mode,set_mode,true);
		addMember(l,"timeMode",get_timeMode,set_timeMode,true);
		addMember(l,"fps",get_fps,set_fps,true);
		addMember(l,"numTilesX",get_numTilesX,set_numTilesX,true);
		addMember(l,"numTilesY",get_numTilesY,set_numTilesY,true);
		addMember(l,"animation",get_animation,set_animation,true);
		addMember(l,"rowMode",get_rowMode,set_rowMode,true);
		addMember(l,"frameOverTime",get_frameOverTime,set_frameOverTime,true);
		addMember(l,"frameOverTimeMultiplier",get_frameOverTimeMultiplier,set_frameOverTimeMultiplier,true);
		addMember(l,"startFrame",get_startFrame,set_startFrame,true);
		addMember(l,"startFrameMultiplier",get_startFrameMultiplier,set_startFrameMultiplier,true);
		addMember(l,"cycleCount",get_cycleCount,set_cycleCount,true);
		addMember(l,"rowIndex",get_rowIndex,set_rowIndex,true);
		addMember(l,"uvChannelMask",get_uvChannelMask,set_uvChannelMask,true);
		addMember(l,"spriteCount",get_spriteCount,null,true);
		addMember(l,"speedRange",get_speedRange,set_speedRange,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ParticleSystem.TextureSheetAnimationModule),typeof(System.ValueType));
	}
}
