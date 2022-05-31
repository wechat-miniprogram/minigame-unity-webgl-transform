using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_FontData : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.FontData o;
			o=new UnityEngine.UI.FontData();
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
	static public int get_defaultFontData(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.UI.FontData.defaultFontData);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_font(IntPtr l) {
		try {
			UnityEngine.UI.FontData self=(UnityEngine.UI.FontData)checkSelf(l);
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
			UnityEngine.UI.FontData self=(UnityEngine.UI.FontData)checkSelf(l);
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
			UnityEngine.UI.FontData self=(UnityEngine.UI.FontData)checkSelf(l);
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
			UnityEngine.UI.FontData self=(UnityEngine.UI.FontData)checkSelf(l);
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
			UnityEngine.UI.FontData self=(UnityEngine.UI.FontData)checkSelf(l);
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
			UnityEngine.UI.FontData self=(UnityEngine.UI.FontData)checkSelf(l);
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
	static public int get_bestFit(IntPtr l) {
		try {
			UnityEngine.UI.FontData self=(UnityEngine.UI.FontData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.bestFit);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_bestFit(IntPtr l) {
		try {
			UnityEngine.UI.FontData self=(UnityEngine.UI.FontData)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.bestFit=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_minSize(IntPtr l) {
		try {
			UnityEngine.UI.FontData self=(UnityEngine.UI.FontData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.minSize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_minSize(IntPtr l) {
		try {
			UnityEngine.UI.FontData self=(UnityEngine.UI.FontData)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.minSize=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maxSize(IntPtr l) {
		try {
			UnityEngine.UI.FontData self=(UnityEngine.UI.FontData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.maxSize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_maxSize(IntPtr l) {
		try {
			UnityEngine.UI.FontData self=(UnityEngine.UI.FontData)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.maxSize=v;
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
			UnityEngine.UI.FontData self=(UnityEngine.UI.FontData)checkSelf(l);
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
			UnityEngine.UI.FontData self=(UnityEngine.UI.FontData)checkSelf(l);
			UnityEngine.TextAnchor v;
			v = (UnityEngine.TextAnchor)LuaDLL.luaL_checkinteger(l, 2);
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
	static public int get_alignByGeometry(IntPtr l) {
		try {
			UnityEngine.UI.FontData self=(UnityEngine.UI.FontData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.alignByGeometry);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_alignByGeometry(IntPtr l) {
		try {
			UnityEngine.UI.FontData self=(UnityEngine.UI.FontData)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.alignByGeometry=v;
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
			UnityEngine.UI.FontData self=(UnityEngine.UI.FontData)checkSelf(l);
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
			UnityEngine.UI.FontData self=(UnityEngine.UI.FontData)checkSelf(l);
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
	static public int get_horizontalOverflow(IntPtr l) {
		try {
			UnityEngine.UI.FontData self=(UnityEngine.UI.FontData)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.horizontalOverflow);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_horizontalOverflow(IntPtr l) {
		try {
			UnityEngine.UI.FontData self=(UnityEngine.UI.FontData)checkSelf(l);
			UnityEngine.HorizontalWrapMode v;
			v = (UnityEngine.HorizontalWrapMode)LuaDLL.luaL_checkinteger(l, 2);
			self.horizontalOverflow=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_verticalOverflow(IntPtr l) {
		try {
			UnityEngine.UI.FontData self=(UnityEngine.UI.FontData)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.verticalOverflow);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_verticalOverflow(IntPtr l) {
		try {
			UnityEngine.UI.FontData self=(UnityEngine.UI.FontData)checkSelf(l);
			UnityEngine.VerticalWrapMode v;
			v = (UnityEngine.VerticalWrapMode)LuaDLL.luaL_checkinteger(l, 2);
			self.verticalOverflow=v;
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
			UnityEngine.UI.FontData self=(UnityEngine.UI.FontData)checkSelf(l);
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
			UnityEngine.UI.FontData self=(UnityEngine.UI.FontData)checkSelf(l);
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
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.FontData");
		addMember(l,"defaultFontData",get_defaultFontData,null,false);
		addMember(l,"font",get_font,set_font,true);
		addMember(l,"fontSize",get_fontSize,set_fontSize,true);
		addMember(l,"fontStyle",get_fontStyle,set_fontStyle,true);
		addMember(l,"bestFit",get_bestFit,set_bestFit,true);
		addMember(l,"minSize",get_minSize,set_minSize,true);
		addMember(l,"maxSize",get_maxSize,set_maxSize,true);
		addMember(l,"alignment",get_alignment,set_alignment,true);
		addMember(l,"alignByGeometry",get_alignByGeometry,set_alignByGeometry,true);
		addMember(l,"richText",get_richText,set_richText,true);
		addMember(l,"horizontalOverflow",get_horizontalOverflow,set_horizontalOverflow,true);
		addMember(l,"verticalOverflow",get_verticalOverflow,set_verticalOverflow,true);
		addMember(l,"lineSpacing",get_lineSpacing,set_lineSpacing,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.FontData));
	}
}
