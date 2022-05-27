using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_Navigation : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Navigation o;
			o=new UnityEngine.UI.Navigation();
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
	static public int get_mode(IntPtr l) {
		try {
			UnityEngine.UI.Navigation self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.mode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_mode(IntPtr l) {
		try {
			UnityEngine.UI.Navigation self;
			checkValueType(l,1,out self);
			UnityEngine.UI.Navigation.Mode v;
			v = (UnityEngine.UI.Navigation.Mode)LuaDLL.luaL_checkinteger(l, 2);
			self.mode=v;
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
	static public int get_wrapAround(IntPtr l) {
		try {
			UnityEngine.UI.Navigation self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.wrapAround);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_wrapAround(IntPtr l) {
		try {
			UnityEngine.UI.Navigation self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.wrapAround=v;
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
	static public int get_selectOnUp(IntPtr l) {
		try {
			UnityEngine.UI.Navigation self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.selectOnUp);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_selectOnUp(IntPtr l) {
		try {
			UnityEngine.UI.Navigation self;
			checkValueType(l,1,out self);
			UnityEngine.UI.Selectable v;
			checkType(l,2,out v);
			self.selectOnUp=v;
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
	static public int get_selectOnDown(IntPtr l) {
		try {
			UnityEngine.UI.Navigation self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.selectOnDown);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_selectOnDown(IntPtr l) {
		try {
			UnityEngine.UI.Navigation self;
			checkValueType(l,1,out self);
			UnityEngine.UI.Selectable v;
			checkType(l,2,out v);
			self.selectOnDown=v;
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
	static public int get_selectOnLeft(IntPtr l) {
		try {
			UnityEngine.UI.Navigation self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.selectOnLeft);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_selectOnLeft(IntPtr l) {
		try {
			UnityEngine.UI.Navigation self;
			checkValueType(l,1,out self);
			UnityEngine.UI.Selectable v;
			checkType(l,2,out v);
			self.selectOnLeft=v;
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
	static public int get_selectOnRight(IntPtr l) {
		try {
			UnityEngine.UI.Navigation self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.selectOnRight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_selectOnRight(IntPtr l) {
		try {
			UnityEngine.UI.Navigation self;
			checkValueType(l,1,out self);
			UnityEngine.UI.Selectable v;
			checkType(l,2,out v);
			self.selectOnRight=v;
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
	static public int get_defaultNavigation(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.UI.Navigation.defaultNavigation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Navigation");
		addMember(l,"mode",get_mode,set_mode,true);
		addMember(l,"wrapAround",get_wrapAround,set_wrapAround,true);
		addMember(l,"selectOnUp",get_selectOnUp,set_selectOnUp,true);
		addMember(l,"selectOnDown",get_selectOnDown,set_selectOnDown,true);
		addMember(l,"selectOnLeft",get_selectOnLeft,set_selectOnLeft,true);
		addMember(l,"selectOnRight",get_selectOnRight,set_selectOnRight,true);
		addMember(l,"defaultNavigation",get_defaultNavigation,null,false);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Navigation),typeof(System.ValueType));
	}
}
