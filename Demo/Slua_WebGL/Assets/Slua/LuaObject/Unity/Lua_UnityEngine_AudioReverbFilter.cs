using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AudioReverbFilter : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_reverbPreset(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.reverbPreset);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_reverbPreset(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			UnityEngine.AudioReverbPreset v;
			v = (UnityEngine.AudioReverbPreset)LuaDLL.luaL_checkinteger(l, 2);
			self.reverbPreset=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_dryLevel(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.dryLevel);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_dryLevel(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.dryLevel=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_room(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.room);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_room(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.room=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_roomHF(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.roomHF);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_roomHF(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.roomHF=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_decayTime(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.decayTime);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_decayTime(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.decayTime=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_decayHFRatio(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.decayHFRatio);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_decayHFRatio(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.decayHFRatio=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_reflectionsLevel(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.reflectionsLevel);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_reflectionsLevel(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.reflectionsLevel=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_reflectionsDelay(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.reflectionsDelay);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_reflectionsDelay(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.reflectionsDelay=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_reverbLevel(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.reverbLevel);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_reverbLevel(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.reverbLevel=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_reverbDelay(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.reverbDelay);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_reverbDelay(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.reverbDelay=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_diffusion(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.diffusion);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_diffusion(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.diffusion=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_density(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.density);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_density(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.density=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_hfReference(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.hfReference);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_hfReference(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.hfReference=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_roomLF(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.roomLF);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_roomLF(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.roomLF=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_lfReference(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.lfReference);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_lfReference(IntPtr l) {
		try {
			UnityEngine.AudioReverbFilter self=(UnityEngine.AudioReverbFilter)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.lfReference=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.AudioReverbFilter");
		addMember(l,"reverbPreset",get_reverbPreset,set_reverbPreset,true);
		addMember(l,"dryLevel",get_dryLevel,set_dryLevel,true);
		addMember(l,"room",get_room,set_room,true);
		addMember(l,"roomHF",get_roomHF,set_roomHF,true);
		addMember(l,"decayTime",get_decayTime,set_decayTime,true);
		addMember(l,"decayHFRatio",get_decayHFRatio,set_decayHFRatio,true);
		addMember(l,"reflectionsLevel",get_reflectionsLevel,set_reflectionsLevel,true);
		addMember(l,"reflectionsDelay",get_reflectionsDelay,set_reflectionsDelay,true);
		addMember(l,"reverbLevel",get_reverbLevel,set_reverbLevel,true);
		addMember(l,"reverbDelay",get_reverbDelay,set_reverbDelay,true);
		addMember(l,"diffusion",get_diffusion,set_diffusion,true);
		addMember(l,"density",get_density,set_density,true);
		addMember(l,"hfReference",get_hfReference,set_hfReference,true);
		addMember(l,"roomLF",get_roomLF,set_roomLF,true);
		addMember(l,"lfReference",get_lfReference,set_lfReference,true);
		createTypeMetatable(l,null, typeof(UnityEngine.AudioReverbFilter),typeof(UnityEngine.Behaviour));
	}
}
