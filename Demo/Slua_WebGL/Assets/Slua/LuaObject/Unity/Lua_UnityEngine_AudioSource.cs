using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AudioSource : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Play(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
				self.Play();
				pushValue(l,true);
				return 1;
			}
			else if(argc==2){
				UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
				System.UInt64 a1;
				checkType(l,2,out a1);
				self.Play(a1);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Play to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int PlayDelayed(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			self.PlayDelayed(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int PlayScheduled(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			System.Double a1;
			checkType(l,2,out a1);
			self.PlayScheduled(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int PlayOneShot(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
				UnityEngine.AudioClip a1;
				checkType(l,2,out a1);
				self.PlayOneShot(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
				UnityEngine.AudioClip a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				self.PlayOneShot(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function PlayOneShot to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetScheduledStartTime(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			System.Double a1;
			checkType(l,2,out a1);
			self.SetScheduledStartTime(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetScheduledEndTime(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			System.Double a1;
			checkType(l,2,out a1);
			self.SetScheduledEndTime(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Stop(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			self.Stop();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Pause(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			self.Pause();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int UnPause(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			self.UnPause();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetCustomCurve(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			UnityEngine.AudioSourceCurveType a1;
			a1 = (UnityEngine.AudioSourceCurveType)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.AnimationCurve a2;
			checkType(l,3,out a2);
			self.SetCustomCurve(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetCustomCurve(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			UnityEngine.AudioSourceCurveType a1;
			a1 = (UnityEngine.AudioSourceCurveType)LuaDLL.luaL_checkinteger(l, 2);
			var ret=self.GetCustomCurve(a1);
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
	static public int GetOutputData(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			System.Single[] a1;
			checkArray(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			self.GetOutputData(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetSpectrumData(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			System.Single[] a1;
			checkArray(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			UnityEngine.FFTWindow a3;
			a3 = (UnityEngine.FFTWindow)LuaDLL.luaL_checkinteger(l, 4);
			self.GetSpectrumData(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetSpatializerFloat(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			var ret=self.SetSpatializerFloat(a1,a2);
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
	static public int GetSpatializerFloat(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Single a2;
			var ret=self.GetSpatializerFloat(a1,out a2);
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
	static public int GetAmbisonicDecoderFloat(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Single a2;
			var ret=self.GetAmbisonicDecoderFloat(a1,out a2);
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
	static public int SetAmbisonicDecoderFloat(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			var ret=self.SetAmbisonicDecoderFloat(a1,a2);
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
	static public int PlayClipAtPoint_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.AudioClip a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				UnityEngine.AudioSource.PlayClipAtPoint(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UnityEngine.AudioClip a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				UnityEngine.AudioSource.PlayClipAtPoint(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function PlayClipAtPoint to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_volume(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.volume);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_volume(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.volume=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_pitch(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pitch);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_pitch(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.pitch=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_time(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.time);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_time(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.time=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_timeSamples(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.timeSamples);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_timeSamples(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.timeSamples=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_clip(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.clip);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_clip(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			UnityEngine.AudioClip v;
			checkType(l,2,out v);
			self.clip=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_outputAudioMixerGroup(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
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
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
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
	static public int get_isPlaying(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isPlaying);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isVirtual(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isVirtual);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_loop(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.loop);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_loop(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.loop=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_ignoreListenerVolume(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.ignoreListenerVolume);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_ignoreListenerVolume(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.ignoreListenerVolume=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_playOnAwake(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.playOnAwake);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_playOnAwake(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.playOnAwake=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_ignoreListenerPause(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.ignoreListenerPause);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_ignoreListenerPause(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.ignoreListenerPause=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_velocityUpdateMode(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.velocityUpdateMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_velocityUpdateMode(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			UnityEngine.AudioVelocityUpdateMode v;
			v = (UnityEngine.AudioVelocityUpdateMode)LuaDLL.luaL_checkinteger(l, 2);
			self.velocityUpdateMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_panStereo(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.panStereo);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_panStereo(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.panStereo=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_spatialBlend(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.spatialBlend);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_spatialBlend(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.spatialBlend=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_spatialize(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.spatialize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_spatialize(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.spatialize=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_spatializePostEffects(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.spatializePostEffects);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_spatializePostEffects(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.spatializePostEffects=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_reverbZoneMix(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.reverbZoneMix);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_reverbZoneMix(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.reverbZoneMix=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_bypassEffects(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.bypassEffects);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_bypassEffects(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.bypassEffects=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_bypassListenerEffects(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.bypassListenerEffects);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_bypassListenerEffects(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.bypassListenerEffects=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_bypassReverbZones(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.bypassReverbZones);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_bypassReverbZones(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.bypassReverbZones=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_dopplerLevel(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.dopplerLevel);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_dopplerLevel(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.dopplerLevel=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_spread(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.spread);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_spread(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.spread=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_priority(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.priority);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_priority(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.priority=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_mute(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.mute);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_mute(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.mute=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_minDistance(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.minDistance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_minDistance(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.minDistance=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maxDistance(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.maxDistance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_maxDistance(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.maxDistance=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_rolloffMode(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.rolloffMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_rolloffMode(IntPtr l) {
		try {
			UnityEngine.AudioSource self=(UnityEngine.AudioSource)checkSelf(l);
			UnityEngine.AudioRolloffMode v;
			v = (UnityEngine.AudioRolloffMode)LuaDLL.luaL_checkinteger(l, 2);
			self.rolloffMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.AudioSource");
		addMember(l,Play);
		addMember(l,PlayDelayed);
		addMember(l,PlayScheduled);
		addMember(l,PlayOneShot);
		addMember(l,SetScheduledStartTime);
		addMember(l,SetScheduledEndTime);
		addMember(l,Stop);
		addMember(l,Pause);
		addMember(l,UnPause);
		addMember(l,SetCustomCurve);
		addMember(l,GetCustomCurve);
		addMember(l,GetOutputData);
		addMember(l,GetSpectrumData);
		addMember(l,SetSpatializerFloat);
		addMember(l,GetSpatializerFloat);
		addMember(l,GetAmbisonicDecoderFloat);
		addMember(l,SetAmbisonicDecoderFloat);
		addMember(l,PlayClipAtPoint_s);
		addMember(l,"volume",get_volume,set_volume,true);
		addMember(l,"pitch",get_pitch,set_pitch,true);
		addMember(l,"time",get_time,set_time,true);
		addMember(l,"timeSamples",get_timeSamples,set_timeSamples,true);
		addMember(l,"clip",get_clip,set_clip,true);
		addMember(l,"outputAudioMixerGroup",get_outputAudioMixerGroup,set_outputAudioMixerGroup,true);
		addMember(l,"isPlaying",get_isPlaying,null,true);
		addMember(l,"isVirtual",get_isVirtual,null,true);
		addMember(l,"loop",get_loop,set_loop,true);
		addMember(l,"ignoreListenerVolume",get_ignoreListenerVolume,set_ignoreListenerVolume,true);
		addMember(l,"playOnAwake",get_playOnAwake,set_playOnAwake,true);
		addMember(l,"ignoreListenerPause",get_ignoreListenerPause,set_ignoreListenerPause,true);
		addMember(l,"velocityUpdateMode",get_velocityUpdateMode,set_velocityUpdateMode,true);
		addMember(l,"panStereo",get_panStereo,set_panStereo,true);
		addMember(l,"spatialBlend",get_spatialBlend,set_spatialBlend,true);
		addMember(l,"spatialize",get_spatialize,set_spatialize,true);
		addMember(l,"spatializePostEffects",get_spatializePostEffects,set_spatializePostEffects,true);
		addMember(l,"reverbZoneMix",get_reverbZoneMix,set_reverbZoneMix,true);
		addMember(l,"bypassEffects",get_bypassEffects,set_bypassEffects,true);
		addMember(l,"bypassListenerEffects",get_bypassListenerEffects,set_bypassListenerEffects,true);
		addMember(l,"bypassReverbZones",get_bypassReverbZones,set_bypassReverbZones,true);
		addMember(l,"dopplerLevel",get_dopplerLevel,set_dopplerLevel,true);
		addMember(l,"spread",get_spread,set_spread,true);
		addMember(l,"priority",get_priority,set_priority,true);
		addMember(l,"mute",get_mute,set_mute,true);
		addMember(l,"minDistance",get_minDistance,set_minDistance,true);
		addMember(l,"maxDistance",get_maxDistance,set_maxDistance,true);
		addMember(l,"rolloffMode",get_rolloffMode,set_rolloffMode,true);
		createTypeMetatable(l,null, typeof(UnityEngine.AudioSource),typeof(UnityEngine.AudioBehaviour));
	}
}
