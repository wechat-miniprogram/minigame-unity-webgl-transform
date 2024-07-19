using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Cubemap : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			UnityEngine.Cubemap o;
			if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.Experimental.Rendering.DefaultFormat),typeof(UnityEngine.Experimental.Rendering.TextureCreationFlags))){
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Experimental.Rendering.DefaultFormat a2;
				a2 = (UnityEngine.Experimental.Rendering.DefaultFormat)LuaDLL.luaL_checkinteger(l, 3);
				UnityEngine.Experimental.Rendering.TextureCreationFlags a3;
				a3 = (UnityEngine.Experimental.Rendering.TextureCreationFlags)LuaDLL.luaL_checkinteger(l, 4);
				o=new UnityEngine.Cubemap(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.Experimental.Rendering.GraphicsFormat),typeof(UnityEngine.Experimental.Rendering.TextureCreationFlags))){
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Experimental.Rendering.GraphicsFormat a2;
				a2 = (UnityEngine.Experimental.Rendering.GraphicsFormat)LuaDLL.luaL_checkinteger(l, 3);
				UnityEngine.Experimental.Rendering.TextureCreationFlags a3;
				a3 = (UnityEngine.Experimental.Rendering.TextureCreationFlags)LuaDLL.luaL_checkinteger(l, 4);
				o=new UnityEngine.Cubemap(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.TextureFormat),typeof(int))){
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.TextureFormat a2;
				a2 = (UnityEngine.TextureFormat)LuaDLL.luaL_checkinteger(l, 3);
				System.Int32 a3;
				checkType(l,4,out a3);
				o=new UnityEngine.Cubemap(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==5){
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Experimental.Rendering.GraphicsFormat a2;
				a2 = (UnityEngine.Experimental.Rendering.GraphicsFormat)LuaDLL.luaL_checkinteger(l, 3);
				UnityEngine.Experimental.Rendering.TextureCreationFlags a3;
				a3 = (UnityEngine.Experimental.Rendering.TextureCreationFlags)LuaDLL.luaL_checkinteger(l, 4);
				System.Int32 a4;
				checkType(l,5,out a4);
				o=new UnityEngine.Cubemap(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(UnityEngine.TextureFormat),typeof(bool))){
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.TextureFormat a2;
				a2 = (UnityEngine.TextureFormat)LuaDLL.luaL_checkinteger(l, 3);
				System.Boolean a3;
				checkType(l,4,out a3);
				o=new UnityEngine.Cubemap(a1,a2,a3);
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
	static public int UpdateExternalTexture(IntPtr l) {
		try {
			UnityEngine.Cubemap self=(UnityEngine.Cubemap)checkSelf(l);
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
	static public int SmoothEdges(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.Cubemap self=(UnityEngine.Cubemap)checkSelf(l);
				self.SmoothEdges();
				pushValue(l,true);
				return 1;
			}
			else if(argc==2){
				UnityEngine.Cubemap self=(UnityEngine.Cubemap)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				self.SmoothEdges(a1);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SmoothEdges to call");
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
			if(argc==2){
				UnityEngine.Cubemap self=(UnityEngine.Cubemap)checkSelf(l);
				UnityEngine.CubemapFace a1;
				a1 = (UnityEngine.CubemapFace)LuaDLL.luaL_checkinteger(l, 2);
				var ret=self.GetPixels(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==3){
				UnityEngine.Cubemap self=(UnityEngine.Cubemap)checkSelf(l);
				UnityEngine.CubemapFace a1;
				a1 = (UnityEngine.CubemapFace)LuaDLL.luaL_checkinteger(l, 2);
				System.Int32 a2;
				checkType(l,3,out a2);
				var ret=self.GetPixels(a1,a2);
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
	static public int SetPixels(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.Cubemap self=(UnityEngine.Cubemap)checkSelf(l);
				UnityEngine.Color[] a1;
				checkArray(l,2,out a1);
				UnityEngine.CubemapFace a2;
				a2 = (UnityEngine.CubemapFace)LuaDLL.luaL_checkinteger(l, 3);
				self.SetPixels(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Cubemap self=(UnityEngine.Cubemap)checkSelf(l);
				UnityEngine.Color[] a1;
				checkArray(l,2,out a1);
				UnityEngine.CubemapFace a2;
				a2 = (UnityEngine.CubemapFace)LuaDLL.luaL_checkinteger(l, 3);
				System.Int32 a3;
				checkType(l,4,out a3);
				self.SetPixels(a1,a2,a3);
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
	static public int ClearRequestedMipmapLevel(IntPtr l) {
		try {
			UnityEngine.Cubemap self=(UnityEngine.Cubemap)checkSelf(l);
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
			UnityEngine.Cubemap self=(UnityEngine.Cubemap)checkSelf(l);
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
	static public int SetPixel(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==5){
				UnityEngine.Cubemap self=(UnityEngine.Cubemap)checkSelf(l);
				UnityEngine.CubemapFace a1;
				a1 = (UnityEngine.CubemapFace)LuaDLL.luaL_checkinteger(l, 2);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				UnityEngine.Color a4;
				checkType(l,5,out a4);
				self.SetPixel(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(argc==6){
				UnityEngine.Cubemap self=(UnityEngine.Cubemap)checkSelf(l);
				UnityEngine.CubemapFace a1;
				a1 = (UnityEngine.CubemapFace)LuaDLL.luaL_checkinteger(l, 2);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				UnityEngine.Color a4;
				checkType(l,5,out a4);
				System.Int32 a5;
				checkType(l,6,out a5);
				self.SetPixel(a1,a2,a3,a4,a5);
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
	static public int GetPixel(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==4){
				UnityEngine.Cubemap self=(UnityEngine.Cubemap)checkSelf(l);
				UnityEngine.CubemapFace a1;
				a1 = (UnityEngine.CubemapFace)LuaDLL.luaL_checkinteger(l, 2);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				var ret=self.GetPixel(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==5){
				UnityEngine.Cubemap self=(UnityEngine.Cubemap)checkSelf(l);
				UnityEngine.CubemapFace a1;
				a1 = (UnityEngine.CubemapFace)LuaDLL.luaL_checkinteger(l, 2);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				var ret=self.GetPixel(a1,a2,a3,a4);
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
	static public int Apply(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.Cubemap self=(UnityEngine.Cubemap)checkSelf(l);
				self.Apply();
				pushValue(l,true);
				return 1;
			}
			else if(argc==2){
				UnityEngine.Cubemap self=(UnityEngine.Cubemap)checkSelf(l);
				System.Boolean a1;
				checkType(l,2,out a1);
				self.Apply(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Cubemap self=(UnityEngine.Cubemap)checkSelf(l);
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
	static public int CreateExternalTexture_s(IntPtr l) {
		try {
			System.Int32 a1;
			checkType(l,1,out a1);
			UnityEngine.TextureFormat a2;
			a2 = (UnityEngine.TextureFormat)LuaDLL.luaL_checkinteger(l, 2);
			System.Boolean a3;
			checkType(l,3,out a3);
			System.IntPtr a4;
			checkType(l,4,out a4);
			var ret=UnityEngine.Cubemap.CreateExternalTexture(a1,a2,a3,a4);
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
			UnityEngine.Cubemap self=(UnityEngine.Cubemap)checkSelf(l);
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
	static public int get_isReadable(IntPtr l) {
		try {
			UnityEngine.Cubemap self=(UnityEngine.Cubemap)checkSelf(l);
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
	static public int get_streamingMipmaps(IntPtr l) {
		try {
			UnityEngine.Cubemap self=(UnityEngine.Cubemap)checkSelf(l);
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
			UnityEngine.Cubemap self=(UnityEngine.Cubemap)checkSelf(l);
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
			UnityEngine.Cubemap self=(UnityEngine.Cubemap)checkSelf(l);
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
			UnityEngine.Cubemap self=(UnityEngine.Cubemap)checkSelf(l);
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
	static public int get_desiredMipmapLevel(IntPtr l) {
		try {
			UnityEngine.Cubemap self=(UnityEngine.Cubemap)checkSelf(l);
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
			UnityEngine.Cubemap self=(UnityEngine.Cubemap)checkSelf(l);
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
			UnityEngine.Cubemap self=(UnityEngine.Cubemap)checkSelf(l);
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
		getTypeTable(l,"UnityEngine.Cubemap");
		addMember(l,UpdateExternalTexture);
		addMember(l,SmoothEdges);
		addMember(l,GetPixels);
		addMember(l,SetPixels);
		addMember(l,ClearRequestedMipmapLevel);
		addMember(l,IsRequestedMipmapLevelLoaded);
		addMember(l,SetPixel);
		addMember(l,GetPixel);
		addMember(l,Apply);
		addMember(l,CreateExternalTexture_s);
		addMember(l,"format",get_format,null,true);
		addMember(l,"isReadable",get_isReadable,null,true);
		addMember(l,"streamingMipmaps",get_streamingMipmaps,null,true);
		addMember(l,"streamingMipmapsPriority",get_streamingMipmapsPriority,null,true);
		addMember(l,"requestedMipmapLevel",get_requestedMipmapLevel,set_requestedMipmapLevel,true);
		addMember(l,"desiredMipmapLevel",get_desiredMipmapLevel,null,true);
		addMember(l,"loadingMipmapLevel",get_loadingMipmapLevel,null,true);
		addMember(l,"loadedMipmapLevel",get_loadedMipmapLevel,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Cubemap),typeof(UnityEngine.Texture));
	}
}
