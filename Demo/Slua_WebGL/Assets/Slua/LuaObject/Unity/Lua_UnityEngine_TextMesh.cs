using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_TextMesh : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_text(IntPtr l) {
		try {
			UnityEngine.TextMesh self=(UnityEngine.TextMesh)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.text);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_text(IntPtr l) {
		try {
			UnityEngine.TextMesh self=(UnityEngine.TextMesh)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.text=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_font(IntPtr l) {
		try {
			UnityEngine.TextMesh self=(UnityEngine.TextMesh)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.font);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_font(IntPtr l) {
		try {
			UnityEngine.TextMesh self=(UnityEngine.TextMesh)checkSelf(l);
			UnityEngine.Font v;
			checkType(l,2,out v);
			self.font=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_fontSize(IntPtr l) {
		try {
			UnityEngine.TextMesh self=(UnityEngine.TextMesh)checkSelf(l);
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
	static public int set_fontSize(IntPtr l) {
		try {
			UnityEngine.TextMesh self=(UnityEngine.TextMesh)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.fontSize=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_fontStyle(IntPtr l) {
		try {
			UnityEngine.TextMesh self=(UnityEngine.TextMesh)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.fontStyle);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_fontStyle(IntPtr l) {
		try {
			UnityEngine.TextMesh self=(UnityEngine.TextMesh)checkSelf(l);
			UnityEngine.FontStyle v;
			v = (UnityEngine.FontStyle)LuaDLL.luaL_checkinteger(l, 2);
			self.fontStyle=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_offsetZ(IntPtr l) {
		try {
			UnityEngine.TextMesh self=(UnityEngine.TextMesh)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.offsetZ);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_offsetZ(IntPtr l) {
		try {
			UnityEngine.TextMesh self=(UnityEngine.TextMesh)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.offsetZ=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_alignment(IntPtr l) {
		try {
			UnityEngine.TextMesh self=(UnityEngine.TextMesh)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.alignment);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_alignment(IntPtr l) {
		try {
			UnityEngine.TextMesh self=(UnityEngine.TextMesh)checkSelf(l);
			UnityEngine.TextAlignment v;
			v = (UnityEngine.TextAlignment)LuaDLL.luaL_checkinteger(l, 2);
			self.alignment=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_anchor(IntPtr l) {
		try {
			UnityEngine.TextMesh self=(UnityEngine.TextMesh)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.anchor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_anchor(IntPtr l) {
		try {
			UnityEngine.TextMesh self=(UnityEngine.TextMesh)checkSelf(l);
			UnityEngine.TextAnchor v;
			v = (UnityEngine.TextAnchor)LuaDLL.luaL_checkinteger(l, 2);
			self.anchor=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_characterSize(IntPtr l) {
		try {
			UnityEngine.TextMesh self=(UnityEngine.TextMesh)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.characterSize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_characterSize(IntPtr l) {
		try {
			UnityEngine.TextMesh self=(UnityEngine.TextMesh)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.characterSize=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_lineSpacing(IntPtr l) {
		try {
			UnityEngine.TextMesh self=(UnityEngine.TextMesh)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.lineSpacing);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_lineSpacing(IntPtr l) {
		try {
			UnityEngine.TextMesh self=(UnityEngine.TextMesh)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.lineSpacing=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_tabSize(IntPtr l) {
		try {
			UnityEngine.TextMesh self=(UnityEngine.TextMesh)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.tabSize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_tabSize(IntPtr l) {
		try {
			UnityEngine.TextMesh self=(UnityEngine.TextMesh)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.tabSize=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_richText(IntPtr l) {
		try {
			UnityEngine.TextMesh self=(UnityEngine.TextMesh)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.richText);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_richText(IntPtr l) {
		try {
			UnityEngine.TextMesh self=(UnityEngine.TextMesh)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.richText=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_color(IntPtr l) {
		try {
			UnityEngine.TextMesh self=(UnityEngine.TextMesh)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.color);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_color(IntPtr l) {
		try {
			UnityEngine.TextMesh self=(UnityEngine.TextMesh)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.color=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.TextMesh");
		addMember(l,"text",get_text,set_text,true);
		addMember(l,"font",get_font,set_font,true);
		addMember(l,"fontSize",get_fontSize,set_fontSize,true);
		addMember(l,"fontStyle",get_fontStyle,set_fontStyle,true);
		addMember(l,"offsetZ",get_offsetZ,set_offsetZ,true);
		addMember(l,"alignment",get_alignment,set_alignment,true);
		addMember(l,"anchor",get_anchor,set_anchor,true);
		addMember(l,"characterSize",get_characterSize,set_characterSize,true);
		addMember(l,"lineSpacing",get_lineSpacing,set_lineSpacing,true);
		addMember(l,"tabSize",get_tabSize,set_tabSize,true);
		addMember(l,"richText",get_richText,set_richText,true);
		addMember(l,"color",get_color,set_color,true);
		createTypeMetatable(l,null, typeof(UnityEngine.TextMesh),typeof(UnityEngine.Component));
	}
}
