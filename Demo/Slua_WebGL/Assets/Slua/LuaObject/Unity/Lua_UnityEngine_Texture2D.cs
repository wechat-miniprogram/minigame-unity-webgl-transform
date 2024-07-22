using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Texture2D : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			UnityEngine.Texture2D o;
			if(matchType(l,argc,2,typeof(int),typeof(int),typeof(UnityEngine.Experimental.Rendering.DefaultFormat),typeof(UnityEngine.Experimental.Rendering.TextureCreationFlags))){
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				UnityEngine.Experimental.Rendering.DefaultFormat a3;
				a3 = (UnityEngine.Experimental.Rendering.DefaultFormat)LuaDLL.luaL_checkinteger(l, 4);
				UnityEngine.Experimental.Rendering.TextureCreationFlags a4;
				a4 = (UnityEngine.Experimental.Rendering.TextureCreationFlags)LuaDLL.luaL_checkinteger(l, 5);
				o=new UnityEngine.Texture2D(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(int),typeof(UnityEngine.Experimental.Rendering.GraphicsFormat),typeof(UnityEngine.Experimental.Rendering.TextureCreationFlags))){
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				UnityEngine.Experimental.Rendering.GraphicsFormat a3;
				a3 = (UnityEngine.Experimental.Rendering.GraphicsFormat)LuaDLL.luaL_checkinteger(l, 4);
				UnityEngine.Experimental.Rendering.TextureCreationFlags a4;
				a4 = (UnityEngine.Experimental.Rendering.TextureCreationFlags)LuaDLL.luaL_checkinteger(l, 5);
				o=new UnityEngine.Texture2D(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(int),typeof(UnityEngine.Experimental.Rendering.GraphicsFormat),typeof(int),typeof(UnityEngine.Experimental.Rendering.TextureCreationFlags))){
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				UnityEngine.Experimental.Rendering.GraphicsFormat a3;
				a3 = (UnityEngine.Experimental.Rendering.GraphicsFormat)LuaDLL.luaL_checkinteger(l, 4);
				System.Int32 a4;
				checkType(l,5,out a4);
				UnityEngine.Experimental.Rendering.TextureCreationFlags a5;
				a5 = (UnityEngine.Experimental.Rendering.TextureCreationFlags)LuaDLL.luaL_checkinteger(l, 6);
				o=new UnityEngine.Texture2D(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(int),typeof(UnityEngine.TextureFormat),typeof(int),typeof(bool))){
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				UnityEngine.TextureFormat a3;
				a3 = (UnityEngine.TextureFormat)LuaDLL.luaL_checkinteger(l, 4);
				System.Int32 a4;
				checkType(l,5,out a4);
				System.Boolean a5;
				checkType(l,6,out a5);
				o=new UnityEngine.Texture2D(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(int),typeof(UnityEngine.TextureFormat),typeof(bool),typeof(bool))){
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				UnityEngine.TextureFormat a3;
				a3 = (UnityEngine.TextureFormat)LuaDLL.luaL_checkinteger(l, 4);
				System.Boolean a4;
				checkType(l,5,out a4);
				System.Boolean a5;
				checkType(l,6,out a5);
				o=new UnityEngine.Texture2D(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(int),typeof(UnityEngine.TextureFormat),typeof(bool))){
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				UnityEngine.TextureFormat a3;
				a3 = (UnityEngine.TextureFormat)LuaDLL.luaL_checkinteger(l, 4);
				System.Boolean a4;
				checkType(l,5,out a4);
				o=new UnityEngine.Texture2D(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==3){
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				o=new UnityEngine.Texture2D(a1,a2);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			return error(l,"New object failed.");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Compress(IntPtr l) {
		try {
			UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			self.Compress(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ClearRequestedMipmapLevel(IntPtr l) {
		try {
			UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
			self.ClearRequestedMipmapLevel();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int IsRequestedMipmapLevelLoaded(IntPtr l) {
		try {
			UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
			var ret=self.IsRequestedMipmapLevelLoaded();
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
	static public int ClearMinimumMipmapLevel(IntPtr l) {
		try {
			UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
			self.ClearMinimumMipmapLevel();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int UpdateExternalTexture(IntPtr l) {
		try {
			UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
			System.IntPtr a1;
			checkType(l,2,out a1);
			self.UpdateExternalTexture(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetRawTextureData(IntPtr l) {
		try {
			UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
			var ret=self.GetRawTextureData();
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
	static public int GetPixels(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				var ret=self.GetPixels();
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==2){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetPixels(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==5){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				var ret=self.GetPixels(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==6){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				System.Int32 a5;
				checkType(l,6,out a5);
				var ret=self.GetPixels(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetPixels to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetPixels32(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				var ret=self.GetPixels32();
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==2){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetPixels32(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetPixels32 to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int PackTextures(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				UnityEngine.Texture2D[] a1;
				checkArray(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				var ret=self.PackTextures(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==4){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				UnityEngine.Texture2D[] a1;
				checkArray(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				var ret=self.PackTextures(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==5){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				UnityEngine.Texture2D[] a1;
				checkArray(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Boolean a4;
				checkType(l,5,out a4);
				var ret=self.PackTextures(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function PackTextures to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetPixel(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==4){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				UnityEngine.Color a3;
				checkType(l,4,out a3);
				self.SetPixel(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				UnityEngine.Color a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				self.SetPixel(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetPixel to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetPixels(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				UnityEngine.Color[] a1;
				checkArray(l,2,out a1);
				self.SetPixels(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				UnityEngine.Color[] a1;
				checkArray(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				self.SetPixels(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(argc==6){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				UnityEngine.Color[] a5;
				checkArray(l,6,out a5);
				self.SetPixels(a1,a2,a3,a4,a5);
				pushValue(l,true);
				return 1;
			}
			else if(argc==7){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				UnityEngine.Color[] a5;
				checkArray(l,6,out a5);
				System.Int32 a6;
				checkType(l,7,out a6);
				self.SetPixels(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetPixels to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetPixel(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				var ret=self.GetPixel(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==4){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				var ret=self.GetPixel(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetPixel to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetPixelBilinear(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				var ret=self.GetPixelBilinear(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==4){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				var ret=self.GetPixelBilinear(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetPixelBilinear to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int LoadRawTextureData(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				System.Byte[] a1;
				checkArray(l,2,out a1);
				self.LoadRawTextureData(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				System.IntPtr a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				self.LoadRawTextureData(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function LoadRawTextureData to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Apply(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				self.Apply();
				pushValue(l,true);
				return 1;
			}
			else if(argc==2){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				System.Boolean a1;
				checkType(l,2,out a1);
				self.Apply(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				System.Boolean a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				self.Apply(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Apply to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Reinitialize(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				var ret=self.Reinitialize(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(int),typeof(UnityEngine.TextureFormat),typeof(bool))){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				UnityEngine.TextureFormat a3;
				a3 = (UnityEngine.TextureFormat)LuaDLL.luaL_checkinteger(l, 4);
				System.Boolean a4;
				checkType(l,5,out a4);
				var ret=self.Reinitialize(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(int),typeof(UnityEngine.Experimental.Rendering.GraphicsFormat),typeof(bool))){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				UnityEngine.Experimental.Rendering.GraphicsFormat a3;
				a3 = (UnityEngine.Experimental.Rendering.GraphicsFormat)LuaDLL.luaL_checkinteger(l, 4);
				System.Boolean a4;
				checkType(l,5,out a4);
				var ret=self.Reinitialize(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Reinitialize to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ReadPixels(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==4){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				UnityEngine.Rect a1;
				checkValueType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				self.ReadPixels(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				UnityEngine.Rect a1;
				checkValueType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Boolean a4;
				checkType(l,5,out a4);
				self.ReadPixels(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function ReadPixels to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetPixels32(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				UnityEngine.Color32[] a1;
				checkArray(l,2,out a1);
				self.SetPixels32(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				UnityEngine.Color32[] a1;
				checkArray(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				self.SetPixels32(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(argc==6){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				UnityEngine.Color32[] a5;
				checkArray(l,6,out a5);
				self.SetPixels32(a1,a2,a3,a4,a5);
				pushValue(l,true);
				return 1;
			}
			else if(argc==7){
				UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				UnityEngine.Color32[] a5;
				checkArray(l,6,out a5);
				System.Int32 a6;
				checkType(l,7,out a6);
				self.SetPixels32(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetPixels32 to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CreateExternalTexture_s(IntPtr l) {
		try {
			System.Int32 a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			UnityEngine.TextureFormat a3;
			a3 = (UnityEngine.TextureFormat)LuaDLL.luaL_checkinteger(l, 3);
			System.Boolean a4;
			checkType(l,4,out a4);
			System.Boolean a5;
			checkType(l,5,out a5);
			System.IntPtr a6;
			checkType(l,6,out a6);
			var ret=UnityEngine.Texture2D.CreateExternalTexture(a1,a2,a3,a4,a5,a6);
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
	static public int GenerateAtlas_s(IntPtr l) {
		try {
			UnityEngine.Vector2[] a1;
			checkArray(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			System.Int32 a3;
			checkType(l,3,out a3);
			System.Collections.Generic.List<UnityEngine.Rect> a4;
			checkType(l,4,out a4);
			var ret=UnityEngine.Texture2D.GenerateAtlas(a1,a2,a3,a4);
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
	static public int get_format(IntPtr l) {
		try {
			UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
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
	static public int get_whiteTexture(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Texture2D.whiteTexture);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_blackTexture(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Texture2D.blackTexture);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_redTexture(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Texture2D.redTexture);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_grayTexture(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Texture2D.grayTexture);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_linearGrayTexture(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Texture2D.linearGrayTexture);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_normalTexture(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Texture2D.normalTexture);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isReadable(IntPtr l) {
		try {
			UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isReadable);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_vtOnly(IntPtr l) {
		try {
			UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.vtOnly);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_streamingMipmaps(IntPtr l) {
		try {
			UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.streamingMipmaps);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_streamingMipmapsPriority(IntPtr l) {
		try {
			UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.streamingMipmapsPriority);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_requestedMipmapLevel(IntPtr l) {
		try {
			UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.requestedMipmapLevel);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_requestedMipmapLevel(IntPtr l) {
		try {
			UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.requestedMipmapLevel=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_minimumMipmapLevel(IntPtr l) {
		try {
			UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.minimumMipmapLevel);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_minimumMipmapLevel(IntPtr l) {
		try {
			UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.minimumMipmapLevel=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_calculatedMipmapLevel(IntPtr l) {
		try {
			UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.calculatedMipmapLevel);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_desiredMipmapLevel(IntPtr l) {
		try {
			UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.desiredMipmapLevel);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_loadingMipmapLevel(IntPtr l) {
		try {
			UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.loadingMipmapLevel);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_loadedMipmapLevel(IntPtr l) {
		try {
			UnityEngine.Texture2D self=(UnityEngine.Texture2D)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.loadedMipmapLevel);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Texture2D");
		addMember(l,Compress);
		addMember(l,ClearRequestedMipmapLevel);
		addMember(l,IsRequestedMipmapLevelLoaded);
		addMember(l,ClearMinimumMipmapLevel);
		addMember(l,UpdateExternalTexture);
		addMember(l,GetRawTextureData);
		addMember(l,GetPixels);
		addMember(l,GetPixels32);
		addMember(l,PackTextures);
		addMember(l,SetPixel);
		addMember(l,SetPixels);
		addMember(l,GetPixel);
		addMember(l,GetPixelBilinear);
		addMember(l,LoadRawTextureData);
		addMember(l,Apply);
		addMember(l,Reinitialize);
		addMember(l,ReadPixels);
		addMember(l,SetPixels32);
		addMember(l,CreateExternalTexture_s);
		addMember(l,GenerateAtlas_s);
		addMember(l,"format",get_format,null,true);
		addMember(l,"whiteTexture",get_whiteTexture,null,false);
		addMember(l,"blackTexture",get_blackTexture,null,false);
		addMember(l,"redTexture",get_redTexture,null,false);
		addMember(l,"grayTexture",get_grayTexture,null,false);
		addMember(l,"linearGrayTexture",get_linearGrayTexture,null,false);
		addMember(l,"normalTexture",get_normalTexture,null,false);
		addMember(l,"isReadable",get_isReadable,null,true);
		addMember(l,"vtOnly",get_vtOnly,null,true);
		addMember(l,"streamingMipmaps",get_streamingMipmaps,null,true);
		addMember(l,"streamingMipmapsPriority",get_streamingMipmapsPriority,null,true);
		addMember(l,"requestedMipmapLevel",get_requestedMipmapLevel,set_requestedMipmapLevel,true);
		addMember(l,"minimumMipmapLevel",get_minimumMipmapLevel,set_minimumMipmapLevel,true);
		addMember(l,"calculatedMipmapLevel",get_calculatedMipmapLevel,null,true);
		addMember(l,"desiredMipmapLevel",get_desiredMipmapLevel,null,true);
		addMember(l,"loadingMipmapLevel",get_loadingMipmapLevel,null,true);
		addMember(l,"loadedMipmapLevel",get_loadedMipmapLevel,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Texture2D),typeof(UnityEngine.Texture));
	}
}
