using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_HorizontalOrVerticalLayoutGroup : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_spacing(IntPtr l) {
		try {
			UnityEngine.UI.HorizontalOrVerticalLayoutGroup self=(UnityEngine.UI.HorizontalOrVerticalLayoutGroup)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.spacing);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_spacing(IntPtr l) {
		try {
			UnityEngine.UI.HorizontalOrVerticalLayoutGroup self=(UnityEngine.UI.HorizontalOrVerticalLayoutGroup)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.spacing=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_childForceExpandWidth(IntPtr l) {
		try {
			UnityEngine.UI.HorizontalOrVerticalLayoutGroup self=(UnityEngine.UI.HorizontalOrVerticalLayoutGroup)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.childForceExpandWidth);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_childForceExpandWidth(IntPtr l) {
		try {
			UnityEngine.UI.HorizontalOrVerticalLayoutGroup self=(UnityEngine.UI.HorizontalOrVerticalLayoutGroup)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.childForceExpandWidth=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_childForceExpandHeight(IntPtr l) {
		try {
			UnityEngine.UI.HorizontalOrVerticalLayoutGroup self=(UnityEngine.UI.HorizontalOrVerticalLayoutGroup)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.childForceExpandHeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_childForceExpandHeight(IntPtr l) {
		try {
			UnityEngine.UI.HorizontalOrVerticalLayoutGroup self=(UnityEngine.UI.HorizontalOrVerticalLayoutGroup)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.childForceExpandHeight=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_childControlWidth(IntPtr l) {
		try {
			UnityEngine.UI.HorizontalOrVerticalLayoutGroup self=(UnityEngine.UI.HorizontalOrVerticalLayoutGroup)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.childControlWidth);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_childControlWidth(IntPtr l) {
		try {
			UnityEngine.UI.HorizontalOrVerticalLayoutGroup self=(UnityEngine.UI.HorizontalOrVerticalLayoutGroup)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.childControlWidth=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_childControlHeight(IntPtr l) {
		try {
			UnityEngine.UI.HorizontalOrVerticalLayoutGroup self=(UnityEngine.UI.HorizontalOrVerticalLayoutGroup)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.childControlHeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_childControlHeight(IntPtr l) {
		try {
			UnityEngine.UI.HorizontalOrVerticalLayoutGroup self=(UnityEngine.UI.HorizontalOrVerticalLayoutGroup)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.childControlHeight=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_childScaleWidth(IntPtr l) {
		try {
			UnityEngine.UI.HorizontalOrVerticalLayoutGroup self=(UnityEngine.UI.HorizontalOrVerticalLayoutGroup)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.childScaleWidth);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_childScaleWidth(IntPtr l) {
		try {
			UnityEngine.UI.HorizontalOrVerticalLayoutGroup self=(UnityEngine.UI.HorizontalOrVerticalLayoutGroup)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.childScaleWidth=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_childScaleHeight(IntPtr l) {
		try {
			UnityEngine.UI.HorizontalOrVerticalLayoutGroup self=(UnityEngine.UI.HorizontalOrVerticalLayoutGroup)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.childScaleHeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_childScaleHeight(IntPtr l) {
		try {
			UnityEngine.UI.HorizontalOrVerticalLayoutGroup self=(UnityEngine.UI.HorizontalOrVerticalLayoutGroup)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.childScaleHeight=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_reverseArrangement(IntPtr l) {
		try {
			UnityEngine.UI.HorizontalOrVerticalLayoutGroup self=(UnityEngine.UI.HorizontalOrVerticalLayoutGroup)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.reverseArrangement);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_reverseArrangement(IntPtr l) {
		try {
			UnityEngine.UI.HorizontalOrVerticalLayoutGroup self=(UnityEngine.UI.HorizontalOrVerticalLayoutGroup)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.reverseArrangement=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.HorizontalOrVerticalLayoutGroup");
		addMember(l,"spacing",get_spacing,set_spacing,true);
		addMember(l,"childForceExpandWidth",get_childForceExpandWidth,set_childForceExpandWidth,true);
		addMember(l,"childForceExpandHeight",get_childForceExpandHeight,set_childForceExpandHeight,true);
		addMember(l,"childControlWidth",get_childControlWidth,set_childControlWidth,true);
		addMember(l,"childControlHeight",get_childControlHeight,set_childControlHeight,true);
		addMember(l,"childScaleWidth",get_childScaleWidth,set_childScaleWidth,true);
		addMember(l,"childScaleHeight",get_childScaleHeight,set_childScaleHeight,true);
		addMember(l,"reverseArrangement",get_reverseArrangement,set_reverseArrangement,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.HorizontalOrVerticalLayoutGroup),typeof(UnityEngine.UI.LayoutGroup));
	}
}
