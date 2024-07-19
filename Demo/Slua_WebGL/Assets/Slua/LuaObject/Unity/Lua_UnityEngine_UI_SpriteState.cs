using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_SpriteState : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.SpriteState o;
			o=new UnityEngine.UI.SpriteState();
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
	static public int get_highlightedSprite(IntPtr l) {
		try {
			UnityEngine.UI.SpriteState self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.highlightedSprite);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_highlightedSprite(IntPtr l) {
		try {
			UnityEngine.UI.SpriteState self;
			checkValueType(l,1,out self);
			UnityEngine.Sprite v;
			checkType(l,2,out v);
			self.highlightedSprite=v;
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
	static public int get_pressedSprite(IntPtr l) {
		try {
			UnityEngine.UI.SpriteState self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.pressedSprite);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_pressedSprite(IntPtr l) {
		try {
			UnityEngine.UI.SpriteState self;
			checkValueType(l,1,out self);
			UnityEngine.Sprite v;
			checkType(l,2,out v);
			self.pressedSprite=v;
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
	static public int get_selectedSprite(IntPtr l) {
		try {
			UnityEngine.UI.SpriteState self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.selectedSprite);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_selectedSprite(IntPtr l) {
		try {
			UnityEngine.UI.SpriteState self;
			checkValueType(l,1,out self);
			UnityEngine.Sprite v;
			checkType(l,2,out v);
			self.selectedSprite=v;
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
	static public int get_disabledSprite(IntPtr l) {
		try {
			UnityEngine.UI.SpriteState self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.disabledSprite);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_disabledSprite(IntPtr l) {
		try {
			UnityEngine.UI.SpriteState self;
			checkValueType(l,1,out self);
			UnityEngine.Sprite v;
			checkType(l,2,out v);
			self.disabledSprite=v;
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
		getTypeTable(l,"UnityEngine.UI.SpriteState");
		addMember(l,"highlightedSprite",get_highlightedSprite,set_highlightedSprite,true);
		addMember(l,"pressedSprite",get_pressedSprite,set_pressedSprite,true);
		addMember(l,"selectedSprite",get_selectedSprite,set_selectedSprite,true);
		addMember(l,"disabledSprite",get_disabledSprite,set_disabledSprite,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.SpriteState),typeof(System.ValueType));
	}
}
