using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Font : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			UnityEngine.Font o;
			if(argc==1){
				o=new UnityEngine.Font();
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==2){
				System.String a1;
				checkType(l,2,out a1);
				o=new UnityEngine.Font(a1);
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
	static public int HasCharacter(IntPtr l) {
		try {
			UnityEngine.Font self=(UnityEngine.Font)checkSelf(l);
			System.Char a1;
			checkType(l,2,out a1);
			var ret=self.HasCharacter(a1);
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
	static public int GetCharacterInfo(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.Font self=(UnityEngine.Font)checkSelf(l);
				System.Char a1;
				checkType(l,2,out a1);
				UnityEngine.CharacterInfo a2;
				var ret=self.GetCharacterInfo(a1,out a2);
				pushValue(l,true);
				pushValue(l,ret);
				pushValue(l,a2);
				return 3;
			}
			else if(argc==4){
				UnityEngine.Font self=(UnityEngine.Font)checkSelf(l);
				System.Char a1;
				checkType(l,2,out a1);
				UnityEngine.CharacterInfo a2;
				System.Int32 a3;
				checkType(l,4,out a3);
				var ret=self.GetCharacterInfo(a1,out a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				pushValue(l,a2);
				return 3;
			}
			else if(argc==5){
				UnityEngine.Font self=(UnityEngine.Font)checkSelf(l);
				System.Char a1;
				checkType(l,2,out a1);
				UnityEngine.CharacterInfo a2;
				System.Int32 a3;
				checkType(l,4,out a3);
				UnityEngine.FontStyle a4;
				a4 = (UnityEngine.FontStyle)LuaDLL.luaL_checkinteger(l, 5);
				var ret=self.GetCharacterInfo(a1,out a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				pushValue(l,a2);
				return 3;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetCharacterInfo to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RequestCharactersInTexture(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Font self=(UnityEngine.Font)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				self.RequestCharactersInTexture(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Font self=(UnityEngine.Font)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				self.RequestCharactersInTexture(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Font self=(UnityEngine.Font)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				UnityEngine.FontStyle a3;
				a3 = (UnityEngine.FontStyle)LuaDLL.luaL_checkinteger(l, 4);
				self.RequestCharactersInTexture(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function RequestCharactersInTexture to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CreateDynamicFontFromOSFont_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string),typeof(int))){
				System.String a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Font.CreateDynamicFontFromOSFont(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(System.String[]),typeof(int))){
				System.String[] a1;
				checkArray(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Font.CreateDynamicFontFromOSFont(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function CreateDynamicFontFromOSFont to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetMaxVertsForString_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Font.GetMaxVertsForString(a1);
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
	static public int GetOSInstalledFontNames_s(IntPtr l) {
		try {
			var ret=UnityEngine.Font.GetOSInstalledFontNames();
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
	static public int GetPathsToOSFonts_s(IntPtr l) {
		try {
			var ret=UnityEngine.Font.GetPathsToOSFonts();
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
	static public int get_material(IntPtr l) {
		try {
			UnityEngine.Font self=(UnityEngine.Font)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.material);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_material(IntPtr l) {
		try {
			UnityEngine.Font self=(UnityEngine.Font)checkSelf(l);
			UnityEngine.Material v;
			checkType(l,2,out v);
			self.material=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_fontNames(IntPtr l) {
		try {
			UnityEngine.Font self=(UnityEngine.Font)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.fontNames);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_fontNames(IntPtr l) {
		try {
			UnityEngine.Font self=(UnityEngine.Font)checkSelf(l);
			System.String[] v;
			checkArray(l,2,out v);
			self.fontNames=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_dynamic(IntPtr l) {
		try {
			UnityEngine.Font self=(UnityEngine.Font)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.dynamic);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_ascent(IntPtr l) {
		try {
			UnityEngine.Font self=(UnityEngine.Font)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.ascent);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_fontSize(IntPtr l) {
		try {
			UnityEngine.Font self=(UnityEngine.Font)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.fontSize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_characterInfo(IntPtr l) {
		try {
			UnityEngine.Font self=(UnityEngine.Font)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.characterInfo);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_characterInfo(IntPtr l) {
		try {
			UnityEngine.Font self=(UnityEngine.Font)checkSelf(l);
			UnityEngine.CharacterInfo[] v;
			checkArray(l,2,out v);
			self.characterInfo=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_lineHeight(IntPtr l) {
		try {
			UnityEngine.Font self=(UnityEngine.Font)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.lineHeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Font");
		addMember(l,HasCharacter);
		addMember(l,GetCharacterInfo);
		addMember(l,RequestCharactersInTexture);
		addMember(l,CreateDynamicFontFromOSFont_s);
		addMember(l,GetMaxVertsForString_s);
		addMember(l,GetOSInstalledFontNames_s);
		addMember(l,GetPathsToOSFonts_s);
		addMember(l,"material",get_material,set_material,true);
		addMember(l,"fontNames",get_fontNames,set_fontNames,true);
		addMember(l,"dynamic",get_dynamic,null,true);
		addMember(l,"ascent",get_ascent,null,true);
		addMember(l,"fontSize",get_fontSize,null,true);
		addMember(l,"characterInfo",get_characterInfo,set_characterInfo,true);
		addMember(l,"lineHeight",get_lineHeight,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Font),typeof(UnityEngine.Object));
	}
}
