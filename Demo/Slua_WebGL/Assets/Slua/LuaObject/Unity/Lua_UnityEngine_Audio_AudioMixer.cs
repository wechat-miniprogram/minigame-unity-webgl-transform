using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Audio_AudioMixer : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int FindSnapshot(IntPtr l) {
		try {
			UnityEngine.Audio.AudioMixer self=(UnityEngine.Audio.AudioMixer)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.FindSnapshot(a1);
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
	static public int FindMatchingGroups(IntPtr l) {
		try {
			UnityEngine.Audio.AudioMixer self=(UnityEngine.Audio.AudioMixer)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.FindMatchingGroups(a1);
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
	static public int TransitionToSnapshots(IntPtr l) {
		try {
			UnityEngine.Audio.AudioMixer self=(UnityEngine.Audio.AudioMixer)checkSelf(l);
			UnityEngine.Audio.AudioMixerSnapshot[] a1;
			checkArray(l,2,out a1);
			System.Single[] a2;
			checkArray(l,3,out a2);
			System.Single a3;
			checkType(l,4,out a3);
			self.TransitionToSnapshots(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetFloat(IntPtr l) {
		try {
			UnityEngine.Audio.AudioMixer self=(UnityEngine.Audio.AudioMixer)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			var ret=self.SetFloat(a1,a2);
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
	static public int ClearFloat(IntPtr l) {
		try {
			UnityEngine.Audio.AudioMixer self=(UnityEngine.Audio.AudioMixer)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.ClearFloat(a1);
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
	static public int GetFloat(IntPtr l) {
		try {
			UnityEngine.Audio.AudioMixer self=(UnityEngine.Audio.AudioMixer)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			System.Single a2;
			var ret=self.GetFloat(a1,out a2);
			pushValue(l,true);
			pushValue(l,ret);
			pushValue(l,a2);
			return 3;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_outputAudioMixerGroup(IntPtr l) {
		try {
			UnityEngine.Audio.AudioMixer self=(UnityEngine.Audio.AudioMixer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.outputAudioMixerGroup);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_outputAudioMixerGroup(IntPtr l) {
		try {
			UnityEngine.Audio.AudioMixer self=(UnityEngine.Audio.AudioMixer)checkSelf(l);
			UnityEngine.Audio.AudioMixerGroup v;
			checkType(l,2,out v);
			self.outputAudioMixerGroup=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_updateMode(IntPtr l) {
		try {
			UnityEngine.Audio.AudioMixer self=(UnityEngine.Audio.AudioMixer)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.updateMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_updateMode(IntPtr l) {
		try {
			UnityEngine.Audio.AudioMixer self=(UnityEngine.Audio.AudioMixer)checkSelf(l);
			UnityEngine.Audio.AudioMixerUpdateMode v;
			v = (UnityEngine.Audio.AudioMixerUpdateMode)LuaDLL.luaL_checkinteger(l, 2);
			self.updateMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Audio.AudioMixer");
		addMember(l,FindSnapshot);
		addMember(l,FindMatchingGroups);
		addMember(l,TransitionToSnapshots);
		addMember(l,SetFloat);
		addMember(l,ClearFloat);
		addMember(l,GetFloat);
		addMember(l,"outputAudioMixerGroup",get_outputAudioMixerGroup,set_outputAudioMixerGroup,true);
		addMember(l,"updateMode",get_updateMode,set_updateMode,true);
		createTypeMetatable(l,null, typeof(UnityEngine.Audio.AudioMixer),typeof(UnityEngine.Object));
	}
}
