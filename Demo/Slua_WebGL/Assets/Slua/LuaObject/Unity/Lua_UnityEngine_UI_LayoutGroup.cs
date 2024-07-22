using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_LayoutGroup : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CalculateLayoutInputHorizontal(IntPtr l) {
		try {
			UnityEngine.UI.LayoutGroup self=(UnityEngine.UI.LayoutGroup)checkSelf(l);
			self.CalculateLayoutInputHorizontal();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CalculateLayoutInputVertical(IntPtr l) {
		try {
			UnityEngine.UI.LayoutGroup self=(UnityEngine.UI.LayoutGroup)checkSelf(l);
			self.CalculateLayoutInputVertical();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetLayoutHorizontal(IntPtr l) {
		try {
			UnityEngine.UI.LayoutGroup self=(UnityEngine.UI.LayoutGroup)checkSelf(l);
			self.SetLayoutHorizontal();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetLayoutVertical(IntPtr l) {
		try {
			UnityEngine.UI.LayoutGroup self=(UnityEngine.UI.LayoutGroup)checkSelf(l);
			self.SetLayoutVertical();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_padding(IntPtr l) {
		try {
			UnityEngine.UI.LayoutGroup self=(UnityEngine.UI.LayoutGroup)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.padding);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_padding(IntPtr l) {
		try {
			UnityEngine.UI.LayoutGroup self=(UnityEngine.UI.LayoutGroup)checkSelf(l);
			UnityEngine.RectOffset v;
			checkType(l,2,out v);
			self.padding=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_childAlignment(IntPtr l) {
		try {
			UnityEngine.UI.LayoutGroup self=(UnityEngine.UI.LayoutGroup)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.childAlignment);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_childAlignment(IntPtr l) {
		try {
			UnityEngine.UI.LayoutGroup self=(UnityEngine.UI.LayoutGroup)checkSelf(l);
			UnityEngine.TextAnchor v;
			v = (UnityEngine.TextAnchor)LuaDLL.luaL_checkinteger(l, 2);
			self.childAlignment=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_minWidth(IntPtr l) {
		try {
			UnityEngine.UI.LayoutGroup self=(UnityEngine.UI.LayoutGroup)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.minWidth);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_preferredWidth(IntPtr l) {
		try {
			UnityEngine.UI.LayoutGroup self=(UnityEngine.UI.LayoutGroup)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.preferredWidth);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_flexibleWidth(IntPtr l) {
		try {
			UnityEngine.UI.LayoutGroup self=(UnityEngine.UI.LayoutGroup)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.flexibleWidth);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_minHeight(IntPtr l) {
		try {
			UnityEngine.UI.LayoutGroup self=(UnityEngine.UI.LayoutGroup)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.minHeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_preferredHeight(IntPtr l) {
		try {
			UnityEngine.UI.LayoutGroup self=(UnityEngine.UI.LayoutGroup)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.preferredHeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_flexibleHeight(IntPtr l) {
		try {
			UnityEngine.UI.LayoutGroup self=(UnityEngine.UI.LayoutGroup)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.flexibleHeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_layoutPriority(IntPtr l) {
		try {
			UnityEngine.UI.LayoutGroup self=(UnityEngine.UI.LayoutGroup)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.layoutPriority);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.LayoutGroup");
		addMember(l,CalculateLayoutInputHorizontal);
		addMember(l,CalculateLayoutInputVertical);
		addMember(l,SetLayoutHorizontal);
		addMember(l,SetLayoutVertical);
		addMember(l,"padding",get_padding,set_padding,true);
		addMember(l,"childAlignment",get_childAlignment,set_childAlignment,true);
		addMember(l,"minWidth",get_minWidth,null,true);
		addMember(l,"preferredWidth",get_preferredWidth,null,true);
		addMember(l,"flexibleWidth",get_flexibleWidth,null,true);
		addMember(l,"minHeight",get_minHeight,null,true);
		addMember(l,"preferredHeight",get_preferredHeight,null,true);
		addMember(l,"flexibleHeight",get_flexibleHeight,null,true);
		addMember(l,"layoutPriority",get_layoutPriority,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.LayoutGroup),typeof(UnityEngine.EventSystems.UIBehaviour));
	}
}
