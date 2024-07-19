using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_ILayoutElement : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CalculateLayoutInputHorizontal(IntPtr l) {
		try {
			UnityEngine.UI.ILayoutElement self=(UnityEngine.UI.ILayoutElement)checkSelf(l);
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
			UnityEngine.UI.ILayoutElement self=(UnityEngine.UI.ILayoutElement)checkSelf(l);
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
	static public int get_minWidth(IntPtr l) {
		try {
			UnityEngine.UI.ILayoutElement self=(UnityEngine.UI.ILayoutElement)checkSelf(l);
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
			UnityEngine.UI.ILayoutElement self=(UnityEngine.UI.ILayoutElement)checkSelf(l);
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
			UnityEngine.UI.ILayoutElement self=(UnityEngine.UI.ILayoutElement)checkSelf(l);
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
			UnityEngine.UI.ILayoutElement self=(UnityEngine.UI.ILayoutElement)checkSelf(l);
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
			UnityEngine.UI.ILayoutElement self=(UnityEngine.UI.ILayoutElement)checkSelf(l);
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
			UnityEngine.UI.ILayoutElement self=(UnityEngine.UI.ILayoutElement)checkSelf(l);
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
			UnityEngine.UI.ILayoutElement self=(UnityEngine.UI.ILayoutElement)checkSelf(l);
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
		getTypeTable(l,"UnityEngine.UI.ILayoutElement");
		addMember(l,CalculateLayoutInputHorizontal);
		addMember(l,CalculateLayoutInputVertical);
		addMember(l,"minWidth",get_minWidth,null,true);
		addMember(l,"preferredWidth",get_preferredWidth,null,true);
		addMember(l,"flexibleWidth",get_flexibleWidth,null,true);
		addMember(l,"minHeight",get_minHeight,null,true);
		addMember(l,"preferredHeight",get_preferredHeight,null,true);
		addMember(l,"flexibleHeight",get_flexibleHeight,null,true);
		addMember(l,"layoutPriority",get_layoutPriority,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.ILayoutElement));
	}
}
