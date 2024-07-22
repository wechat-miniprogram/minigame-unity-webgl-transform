using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_Dropdown_OptionDataList : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown.OptionDataList o;
			o=new UnityEngine.UI.Dropdown.OptionDataList();
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
	static public int get_options(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown.OptionDataList self=(UnityEngine.UI.Dropdown.OptionDataList)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.options);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_options(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown.OptionDataList self=(UnityEngine.UI.Dropdown.OptionDataList)checkSelf(l);
			List<UnityEngine.UI.Dropdown.OptionData> v;
			checkType(l,2,out v);
			self.options=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Dropdown.OptionDataList");
		addMember(l,"options",get_options,set_options,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Dropdown.OptionDataList));
	}
}
