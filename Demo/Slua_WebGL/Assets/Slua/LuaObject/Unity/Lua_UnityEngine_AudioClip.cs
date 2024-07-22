using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AudioClip : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int LoadAudioData(IntPtr l) {
		try {
			UnityEngine.AudioClip self=(UnityEngine.AudioClip)checkSelf(l);
			var ret=self.LoadAudioData();
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
	static public int UnloadAudioData(IntPtr l) {
		try {
			UnityEngine.AudioClip self=(UnityEngine.AudioClip)checkSelf(l);
			var ret=self.UnloadAudioData();
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
	static public int GetData(IntPtr l) {
		try {
			UnityEngine.AudioClip self=(UnityEngine.AudioClip)checkSelf(l);
			System.Single[] a1;
			checkArray(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			var ret=self.GetData(a1,a2);
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
	static public int SetData(IntPtr l) {
		try {
			UnityEngine.AudioClip self=(UnityEngine.AudioClip)checkSelf(l);
			System.Single[] a1;
			checkArray(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			var ret=self.SetData(a1,a2);
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
	static public int Create_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==5){
				System.String a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Boolean a5;
				checkType(l,5,out a5);
				var ret=UnityEngine.AudioClip.Create(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==6){
				System.String a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Boolean a5;
				checkType(l,5,out a5);
				UnityEngine.AudioClip.PCMReaderCallback a6;
				checkDelegate(l,6,out a6);
				var ret=UnityEngine.AudioClip.Create(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==7){
				System.String a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Boolean a5;
				checkType(l,5,out a5);
				UnityEngine.AudioClip.PCMReaderCallback a6;
				checkDelegate(l,6,out a6);
				UnityEngine.AudioClip.PCMSetPositionCallback a7;
				checkDelegate(l,7,out a7);
				var ret=UnityEngine.AudioClip.Create(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Create to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_length(IntPtr l) {
		try {
			UnityEngine.AudioClip self=(UnityEngine.AudioClip)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.length);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_samples(IntPtr l) {
		try {
			UnityEngine.AudioClip self=(UnityEngine.AudioClip)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.samples);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_channels(IntPtr l) {
		try {
			UnityEngine.AudioClip self=(UnityEngine.AudioClip)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.channels);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_frequency(IntPtr l) {
		try {
			UnityEngine.AudioClip self=(UnityEngine.AudioClip)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.frequency);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_loadType(IntPtr l) {
		try {
			UnityEngine.AudioClip self=(UnityEngine.AudioClip)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.loadType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_preloadAudioData(IntPtr l) {
		try {
			UnityEngine.AudioClip self=(UnityEngine.AudioClip)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.preloadAudioData);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_ambisonic(IntPtr l) {
		try {
			UnityEngine.AudioClip self=(UnityEngine.AudioClip)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.ambisonic);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_loadInBackground(IntPtr l) {
		try {
			UnityEngine.AudioClip self=(UnityEngine.AudioClip)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.loadInBackground);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_loadState(IntPtr l) {
		try {
			UnityEngine.AudioClip self=(UnityEngine.AudioClip)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.loadState);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.AudioClip");
		addMember(l,LoadAudioData);
		addMember(l,UnloadAudioData);
		addMember(l,GetData);
		addMember(l,SetData);
		addMember(l,Create_s);
		addMember(l,"length",get_length,null,true);
		addMember(l,"samples",get_samples,null,true);
		addMember(l,"channels",get_channels,null,true);
		addMember(l,"frequency",get_frequency,null,true);
		addMember(l,"loadType",get_loadType,null,true);
		addMember(l,"preloadAudioData",get_preloadAudioData,null,true);
		addMember(l,"ambisonic",get_ambisonic,null,true);
		addMember(l,"loadInBackground",get_loadInBackground,null,true);
		addMember(l,"loadState",get_loadState,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.AudioClip),typeof(UnityEngine.Object));
	}
}
