using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_ColorBlock : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.ColorBlock o;
			o=new UnityEngine.UI.ColorBlock();
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
	static public int op_Equality(IntPtr l) {
		try {
			UnityEngine.UI.ColorBlock a1;
			checkValueType(l,1,out a1);
			UnityEngine.UI.ColorBlock a2;
			checkValueType(l,2,out a2);
			var ret=(a1==a2);
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
	static public int op_Inequality(IntPtr l) {
		try {
			UnityEngine.UI.ColorBlock a1;
			checkValueType(l,1,out a1);
			UnityEngine.UI.ColorBlock a2;
			checkValueType(l,2,out a2);
			var ret=(a1!=a2);
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
	static public int get_defaultColorBlock(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.UI.ColorBlock.defaultColorBlock);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_defaultColorBlock(IntPtr l) {
		try {
			UnityEngine.UI.ColorBlock v;
			checkValueType(l,2,out v);
			UnityEngine.UI.ColorBlock.defaultColorBlock=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_normalColor(IntPtr l) {
		try {
			UnityEngine.UI.ColorBlock self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.normalColor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_normalColor(IntPtr l) {
		try {
			UnityEngine.UI.ColorBlock self;
			checkValueType(l,1,out self);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.normalColor=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_highlightedColor(IntPtr l) {
		try {
			UnityEngine.UI.ColorBlock self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.highlightedColor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_highlightedColor(IntPtr l) {
		try {
			UnityEngine.UI.ColorBlock self;
			checkValueType(l,1,out self);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.highlightedColor=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_pressedColor(IntPtr l) {
		try {
			UnityEngine.UI.ColorBlock self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.pressedColor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_pressedColor(IntPtr l) {
		try {
			UnityEngine.UI.ColorBlock self;
			checkValueType(l,1,out self);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.pressedColor=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_selectedColor(IntPtr l) {
		try {
			UnityEngine.UI.ColorBlock self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.selectedColor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_selectedColor(IntPtr l) {
		try {
			UnityEngine.UI.ColorBlock self;
			checkValueType(l,1,out self);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.selectedColor=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_disabledColor(IntPtr l) {
		try {
			UnityEngine.UI.ColorBlock self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.disabledColor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_disabledColor(IntPtr l) {
		try {
			UnityEngine.UI.ColorBlock self;
			checkValueType(l,1,out self);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.disabledColor=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_colorMultiplier(IntPtr l) {
		try {
			UnityEngine.UI.ColorBlock self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.colorMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_colorMultiplier(IntPtr l) {
		try {
			UnityEngine.UI.ColorBlock self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.colorMultiplier=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_fadeDuration(IntPtr l) {
		try {
			UnityEngine.UI.ColorBlock self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.fadeDuration);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_fadeDuration(IntPtr l) {
		try {
			UnityEngine.UI.ColorBlock self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.fadeDuration=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.ColorBlock");
		addMember(l,op_Equality);
		addMember(l,op_Inequality);
		addMember(l,"defaultColorBlock",get_defaultColorBlock,set_defaultColorBlock,false);
		addMember(l,"normalColor",get_normalColor,set_normalColor,true);
		addMember(l,"highlightedColor",get_highlightedColor,set_highlightedColor,true);
		addMember(l,"pressedColor",get_pressedColor,set_pressedColor,true);
		addMember(l,"selectedColor",get_selectedColor,set_selectedColor,true);
		addMember(l,"disabledColor",get_disabledColor,set_disabledColor,true);
		addMember(l,"colorMultiplier",get_colorMultiplier,set_colorMultiplier,true);
		addMember(l,"fadeDuration",get_fadeDuration,set_fadeDuration,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.ColorBlock),typeof(System.ValueType));
	}
}
