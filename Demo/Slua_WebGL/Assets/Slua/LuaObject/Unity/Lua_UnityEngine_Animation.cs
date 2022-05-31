using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Animation : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Stop(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
				self.Stop();
				pushValue(l,true);
				return 1;
			}
			else if(argc==2){
				UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				self.Stop(a1);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Stop to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Rewind(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
				self.Rewind();
				pushValue(l,true);
				return 1;
			}
			else if(argc==2){
				UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				self.Rewind(a1);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Rewind to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Sample(IntPtr l) {
		try {
			UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
			self.Sample();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int IsPlaying(IntPtr l) {
		try {
			UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.IsPlaying(a1);
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
	static public int Play(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
				var ret=self.Play();
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.PlayMode))){
				UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
				UnityEngine.PlayMode a1;
				a1 = (UnityEngine.PlayMode)LuaDLL.luaL_checkinteger(l, 2);
				var ret=self.Play(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(string))){
				UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				var ret=self.Play(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==3){
				UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				UnityEngine.PlayMode a2;
				a2 = (UnityEngine.PlayMode)LuaDLL.luaL_checkinteger(l, 3);
				var ret=self.Play(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
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
	static public int CrossFade(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				self.CrossFade(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				self.CrossFade(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				UnityEngine.PlayMode a3;
				a3 = (UnityEngine.PlayMode)LuaDLL.luaL_checkinteger(l, 4);
				self.CrossFade(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function CrossFade to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Blend(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				self.Blend(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				self.Blend(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				self.Blend(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Blend to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CrossFadeQueued(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				var ret=self.CrossFadeQueued(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==3){
				UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				var ret=self.CrossFadeQueued(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==4){
				UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				UnityEngine.QueueMode a3;
				a3 = (UnityEngine.QueueMode)LuaDLL.luaL_checkinteger(l, 4);
				var ret=self.CrossFadeQueued(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==5){
				UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				UnityEngine.QueueMode a3;
				a3 = (UnityEngine.QueueMode)LuaDLL.luaL_checkinteger(l, 4);
				UnityEngine.PlayMode a4;
				a4 = (UnityEngine.PlayMode)LuaDLL.luaL_checkinteger(l, 5);
				var ret=self.CrossFadeQueued(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function CrossFadeQueued to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int PlayQueued(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				var ret=self.PlayQueued(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==3){
				UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				UnityEngine.QueueMode a2;
				a2 = (UnityEngine.QueueMode)LuaDLL.luaL_checkinteger(l, 3);
				var ret=self.PlayQueued(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==4){
				UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				UnityEngine.QueueMode a2;
				a2 = (UnityEngine.QueueMode)LuaDLL.luaL_checkinteger(l, 3);
				UnityEngine.PlayMode a3;
				a3 = (UnityEngine.PlayMode)LuaDLL.luaL_checkinteger(l, 4);
				var ret=self.PlayQueued(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function PlayQueued to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AddClip(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
				UnityEngine.AnimationClip a1;
				checkType(l,2,out a1);
				System.String a2;
				checkType(l,3,out a2);
				self.AddClip(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
				UnityEngine.AnimationClip a1;
				checkType(l,2,out a1);
				System.String a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				self.AddClip(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(argc==6){
				UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
				UnityEngine.AnimationClip a1;
				checkType(l,2,out a1);
				System.String a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				System.Boolean a5;
				checkType(l,6,out a5);
				self.AddClip(a1,a2,a3,a4,a5);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function AddClip to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RemoveClip(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(UnityEngine.AnimationClip))){
				UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
				UnityEngine.AnimationClip a1;
				checkType(l,2,out a1);
				self.RemoveClip(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string))){
				UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				self.RemoveClip(a1);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function RemoveClip to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetClipCount(IntPtr l) {
		try {
			UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
			var ret=self.GetClipCount();
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
	static public int SyncLayer(IntPtr l) {
		try {
			UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			self.SyncLayer(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetClip(IntPtr l) {
		try {
			UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.GetClip(a1);
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
	static public int get_clip(IntPtr l) {
		try {
			UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
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
			UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
			UnityEngine.AnimationClip v;
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
	static public int get_playAutomatically(IntPtr l) {
		try {
			UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.playAutomatically);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_playAutomatically(IntPtr l) {
		try {
			UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.playAutomatically=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_wrapMode(IntPtr l) {
		try {
			UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.wrapMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_wrapMode(IntPtr l) {
		try {
			UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
			UnityEngine.WrapMode v;
			v = (UnityEngine.WrapMode)LuaDLL.luaL_checkinteger(l, 2);
			self.wrapMode=v;
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
			UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
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
	static public int get_animatePhysics(IntPtr l) {
		try {
			UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.animatePhysics);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_animatePhysics(IntPtr l) {
		try {
			UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.animatePhysics=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_cullingType(IntPtr l) {
		try {
			UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.cullingType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_cullingType(IntPtr l) {
		try {
			UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
			UnityEngine.AnimationCullingType v;
			v = (UnityEngine.AnimationCullingType)LuaDLL.luaL_checkinteger(l, 2);
			self.cullingType=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_localBounds(IntPtr l) {
		try {
			UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.localBounds);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_localBounds(IntPtr l) {
		try {
			UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
			UnityEngine.Bounds v;
			checkValueType(l,2,out v);
			self.localBounds=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int getItem(IntPtr l) {
		try {
			UnityEngine.Animation self=(UnityEngine.Animation)checkSelf(l);
			string v;
			checkType(l,2,out v);
			var ret = self[v];
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
		getTypeTable(l,"UnityEngine.Animation");
		addMember(l,Stop);
		addMember(l,Rewind);
		addMember(l,Sample);
		addMember(l,IsPlaying);
		addMember(l,Play);
		addMember(l,CrossFade);
		addMember(l,Blend);
		addMember(l,CrossFadeQueued);
		addMember(l,PlayQueued);
		addMember(l,AddClip);
		addMember(l,RemoveClip);
		addMember(l,GetClipCount);
		addMember(l,SyncLayer);
		addMember(l,GetClip);
		addMember(l,getItem);
		addMember(l,"clip",get_clip,set_clip,true);
		addMember(l,"playAutomatically",get_playAutomatically,set_playAutomatically,true);
		addMember(l,"wrapMode",get_wrapMode,set_wrapMode,true);
		addMember(l,"isPlaying",get_isPlaying,null,true);
		addMember(l,"animatePhysics",get_animatePhysics,set_animatePhysics,true);
		addMember(l,"cullingType",get_cullingType,set_cullingType,true);
		addMember(l,"localBounds",get_localBounds,set_localBounds,true);
		createTypeMetatable(l,null, typeof(UnityEngine.Animation),typeof(UnityEngine.Behaviour));
	}
}
