using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_WebCamTexture : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			UnityEngine.WebCamTexture o;
			if(argc==5){
				System.String a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				o=new UnityEngine.WebCamTexture(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(int),typeof(int))){
				System.String a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				o=new UnityEngine.WebCamTexture(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==2){
				System.String a1;
				checkType(l,2,out a1);
				o=new UnityEngine.WebCamTexture(a1);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(int),typeof(int))){
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				o=new UnityEngine.WebCamTexture(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==3){
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				o=new UnityEngine.WebCamTexture(a1,a2);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==1){
				o=new UnityEngine.WebCamTexture();
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
	static public int Play(IntPtr l) {
		try {
			UnityEngine.WebCamTexture self=(UnityEngine.WebCamTexture)checkSelf(l);
			self.Play();
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
			UnityEngine.WebCamTexture self=(UnityEngine.WebCamTexture)checkSelf(l);
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
	static public int Stop(IntPtr l) {
		try {
			UnityEngine.WebCamTexture self=(UnityEngine.WebCamTexture)checkSelf(l);
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
	static public int GetPixel(IntPtr l) {
		try {
			UnityEngine.WebCamTexture self=(UnityEngine.WebCamTexture)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			var ret=self.GetPixel(a1,a2);
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
				UnityEngine.WebCamTexture self=(UnityEngine.WebCamTexture)checkSelf(l);
				var ret=self.GetPixels();
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==5){
				UnityEngine.WebCamTexture self=(UnityEngine.WebCamTexture)checkSelf(l);
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
				UnityEngine.WebCamTexture self=(UnityEngine.WebCamTexture)checkSelf(l);
				var ret=self.GetPixels32();
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==2){
				UnityEngine.WebCamTexture self=(UnityEngine.WebCamTexture)checkSelf(l);
				UnityEngine.Color32[] a1;
				checkArray(l,2,out a1);
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
	static public int get_devices(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.WebCamTexture.devices);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isPlaying(IntPtr l) {
		try {
			UnityEngine.WebCamTexture self=(UnityEngine.WebCamTexture)checkSelf(l);
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
	static public int get_deviceName(IntPtr l) {
		try {
			UnityEngine.WebCamTexture self=(UnityEngine.WebCamTexture)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.deviceName);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_deviceName(IntPtr l) {
		try {
			UnityEngine.WebCamTexture self=(UnityEngine.WebCamTexture)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.deviceName=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_requestedFPS(IntPtr l) {
		try {
			UnityEngine.WebCamTexture self=(UnityEngine.WebCamTexture)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.requestedFPS);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_requestedFPS(IntPtr l) {
		try {
			UnityEngine.WebCamTexture self=(UnityEngine.WebCamTexture)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.requestedFPS=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_requestedWidth(IntPtr l) {
		try {
			UnityEngine.WebCamTexture self=(UnityEngine.WebCamTexture)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.requestedWidth);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_requestedWidth(IntPtr l) {
		try {
			UnityEngine.WebCamTexture self=(UnityEngine.WebCamTexture)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.requestedWidth=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_requestedHeight(IntPtr l) {
		try {
			UnityEngine.WebCamTexture self=(UnityEngine.WebCamTexture)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.requestedHeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_requestedHeight(IntPtr l) {
		try {
			UnityEngine.WebCamTexture self=(UnityEngine.WebCamTexture)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.requestedHeight=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_videoRotationAngle(IntPtr l) {
		try {
			UnityEngine.WebCamTexture self=(UnityEngine.WebCamTexture)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.videoRotationAngle);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_videoVerticallyMirrored(IntPtr l) {
		try {
			UnityEngine.WebCamTexture self=(UnityEngine.WebCamTexture)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.videoVerticallyMirrored);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_didUpdateThisFrame(IntPtr l) {
		try {
			UnityEngine.WebCamTexture self=(UnityEngine.WebCamTexture)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.didUpdateThisFrame);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_autoFocusPoint(IntPtr l) {
		try {
			UnityEngine.WebCamTexture self=(UnityEngine.WebCamTexture)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.autoFocusPoint);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_autoFocusPoint(IntPtr l) {
		try {
			UnityEngine.WebCamTexture self=(UnityEngine.WebCamTexture)checkSelf(l);
			System.Nullable<UnityEngine.Vector2> v;
			checkNullable(l,2,out v);
			self.autoFocusPoint=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isDepth(IntPtr l) {
		try {
			UnityEngine.WebCamTexture self=(UnityEngine.WebCamTexture)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isDepth);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.WebCamTexture");
		addMember(l,Play);
		addMember(l,Pause);
		addMember(l,Stop);
		addMember(l,GetPixel);
		addMember(l,GetPixels);
		addMember(l,GetPixels32);
		addMember(l,"devices",get_devices,null,false);
		addMember(l,"isPlaying",get_isPlaying,null,true);
		addMember(l,"deviceName",get_deviceName,set_deviceName,true);
		addMember(l,"requestedFPS",get_requestedFPS,set_requestedFPS,true);
		addMember(l,"requestedWidth",get_requestedWidth,set_requestedWidth,true);
		addMember(l,"requestedHeight",get_requestedHeight,set_requestedHeight,true);
		addMember(l,"videoRotationAngle",get_videoRotationAngle,null,true);
		addMember(l,"videoVerticallyMirrored",get_videoVerticallyMirrored,null,true);
		addMember(l,"didUpdateThisFrame",get_didUpdateThisFrame,null,true);
		addMember(l,"autoFocusPoint",get_autoFocusPoint,set_autoFocusPoint,true);
		addMember(l,"isDepth",get_isDepth,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.WebCamTexture),typeof(UnityEngine.Texture));
	}
}
