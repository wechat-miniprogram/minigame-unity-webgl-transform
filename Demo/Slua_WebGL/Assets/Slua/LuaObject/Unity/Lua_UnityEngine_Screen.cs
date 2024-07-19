using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Screen : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Screen o;
			o=new UnityEngine.Screen();
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
	static public int SetResolution_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(int),typeof(int),typeof(UnityEngine.FullScreenMode))){
				System.Int32 a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.FullScreenMode a3;
				a3 = (UnityEngine.FullScreenMode)LuaDLL.luaL_checkinteger(l, 3);
				UnityEngine.Screen.SetResolution(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(int),typeof(bool))){
				System.Int32 a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				System.Boolean a3;
				checkType(l,3,out a3);
				UnityEngine.Screen.SetResolution(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(int),typeof(UnityEngine.FullScreenMode),typeof(int))){
				System.Int32 a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.FullScreenMode a3;
				a3 = (UnityEngine.FullScreenMode)LuaDLL.luaL_checkinteger(l, 3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Screen.SetResolution(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(int),typeof(bool),typeof(int))){
				System.Int32 a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				System.Boolean a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Screen.SetResolution(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetResolution to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetDisplayLayout_s(IntPtr l) {
		try {
			System.Collections.Generic.List<UnityEngine.DisplayInfo> a1;
			checkType(l,1,out a1);
			UnityEngine.Screen.GetDisplayLayout(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int MoveMainWindowTo_s(IntPtr l) {
		try {
			UnityEngine.DisplayInfo a1;
			checkValueType(l,1,out a1);
			UnityEngine.Vector2Int a2;
			checkValueType(l,2,out a2);
			var ret=UnityEngine.Screen.MoveMainWindowTo(in a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			pushValue(l,a1);
			return 3;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_width(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Screen.width);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_height(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Screen.height);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_dpi(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Screen.dpi);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_currentResolution(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Screen.currentResolution);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_resolutions(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Screen.resolutions);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_fullScreen(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Screen.fullScreen);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_fullScreen(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Screen.fullScreen=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_fullScreenMode(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UnityEngine.Screen.fullScreenMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_fullScreenMode(IntPtr l) {
		try {
			UnityEngine.FullScreenMode v;
			v = (UnityEngine.FullScreenMode)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.Screen.fullScreenMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_safeArea(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Screen.safeArea);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_cutouts(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Screen.cutouts);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_autorotateToPortrait(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Screen.autorotateToPortrait);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_autorotateToPortrait(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Screen.autorotateToPortrait=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_autorotateToPortraitUpsideDown(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Screen.autorotateToPortraitUpsideDown);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_autorotateToPortraitUpsideDown(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Screen.autorotateToPortraitUpsideDown=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_autorotateToLandscapeLeft(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Screen.autorotateToLandscapeLeft);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_autorotateToLandscapeLeft(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Screen.autorotateToLandscapeLeft=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_autorotateToLandscapeRight(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Screen.autorotateToLandscapeRight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_autorotateToLandscapeRight(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Screen.autorotateToLandscapeRight=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_orientation(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UnityEngine.Screen.orientation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_orientation(IntPtr l) {
		try {
			UnityEngine.ScreenOrientation v;
			v = (UnityEngine.ScreenOrientation)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.Screen.orientation=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_sleepTimeout(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Screen.sleepTimeout);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_sleepTimeout(IntPtr l) {
		try {
			int v;
			checkType(l,2,out v);
			UnityEngine.Screen.sleepTimeout=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_brightness(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Screen.brightness);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_brightness(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.Screen.brightness=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_mainWindowPosition(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Screen.mainWindowPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_mainWindowDisplayInfo(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Screen.mainWindowDisplayInfo);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Screen");
		addMember(l,SetResolution_s);
		addMember(l,GetDisplayLayout_s);
		addMember(l,MoveMainWindowTo_s);
		addMember(l,"width",get_width,null,false);
		addMember(l,"height",get_height,null,false);
		addMember(l,"dpi",get_dpi,null,false);
		addMember(l,"currentResolution",get_currentResolution,null,false);
		addMember(l,"resolutions",get_resolutions,null,false);
		addMember(l,"fullScreen",get_fullScreen,set_fullScreen,false);
		addMember(l,"fullScreenMode",get_fullScreenMode,set_fullScreenMode,false);
		addMember(l,"safeArea",get_safeArea,null,false);
		addMember(l,"cutouts",get_cutouts,null,false);
		addMember(l,"autorotateToPortrait",get_autorotateToPortrait,set_autorotateToPortrait,false);
		addMember(l,"autorotateToPortraitUpsideDown",get_autorotateToPortraitUpsideDown,set_autorotateToPortraitUpsideDown,false);
		addMember(l,"autorotateToLandscapeLeft",get_autorotateToLandscapeLeft,set_autorotateToLandscapeLeft,false);
		addMember(l,"autorotateToLandscapeRight",get_autorotateToLandscapeRight,set_autorotateToLandscapeRight,false);
		addMember(l,"orientation",get_orientation,set_orientation,false);
		addMember(l,"sleepTimeout",get_sleepTimeout,set_sleepTimeout,false);
		addMember(l,"brightness",get_brightness,set_brightness,false);
		addMember(l,"mainWindowPosition",get_mainWindowPosition,null,false);
		addMember(l,"mainWindowDisplayInfo",get_mainWindowDisplayInfo,null,false);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Screen));
	}
}
