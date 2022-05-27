using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_Dropdown : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetValueWithoutNotify(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			self.SetValueWithoutNotify(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RefreshShownValue(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			self.RefreshShownValue();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AddOptions(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(List<UnityEngine.UI.Dropdown.OptionData>))){
				UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
				System.Collections.Generic.List<UnityEngine.UI.Dropdown.OptionData> a1;
				checkType(l,2,out a1);
				self.AddOptions(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<System.String>))){
				UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
				System.Collections.Generic.List<System.String> a1;
				checkType(l,2,out a1);
				self.AddOptions(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(List<UnityEngine.Sprite>))){
				UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
				System.Collections.Generic.List<UnityEngine.Sprite> a1;
				checkType(l,2,out a1);
				self.AddOptions(a1);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function AddOptions to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ClearOptions(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			self.ClearOptions();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnPointerClick(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnPointerClick(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnSubmit(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			UnityEngine.EventSystems.BaseEventData a1;
			checkType(l,2,out a1);
			self.OnSubmit(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnCancel(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			UnityEngine.EventSystems.BaseEventData a1;
			checkType(l,2,out a1);
			self.OnCancel(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Show(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			self.Show();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Hide(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			self.Hide();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_template(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.template);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_template(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			UnityEngine.RectTransform v;
			checkType(l,2,out v);
			self.template=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_captionText(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.captionText);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_captionText(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			UnityEngine.UI.Text v;
			checkType(l,2,out v);
			self.captionText=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_captionImage(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.captionImage);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_captionImage(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			UnityEngine.UI.Image v;
			checkType(l,2,out v);
			self.captionImage=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_itemText(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.itemText);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_itemText(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			UnityEngine.UI.Text v;
			checkType(l,2,out v);
			self.itemText=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_itemImage(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.itemImage);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_itemImage(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			UnityEngine.UI.Image v;
			checkType(l,2,out v);
			self.itemImage=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_options(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
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
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
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
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_onValueChanged(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.onValueChanged);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_onValueChanged(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			UnityEngine.UI.Dropdown.DropdownEvent v;
			checkType(l,2,out v);
			self.onValueChanged=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_alphaFadeSpeed(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.alphaFadeSpeed);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_alphaFadeSpeed(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.alphaFadeSpeed=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_value(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.value);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_value(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown self=(UnityEngine.UI.Dropdown)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.value=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Dropdown");
		addMember(l,SetValueWithoutNotify);
		addMember(l,RefreshShownValue);
		addMember(l,AddOptions);
		addMember(l,ClearOptions);
		addMember(l,OnPointerClick);
		addMember(l,OnSubmit);
		addMember(l,OnCancel);
		addMember(l,Show);
		addMember(l,Hide);
		addMember(l,"template",get_template,set_template,true);
		addMember(l,"captionText",get_captionText,set_captionText,true);
		addMember(l,"captionImage",get_captionImage,set_captionImage,true);
		addMember(l,"itemText",get_itemText,set_itemText,true);
		addMember(l,"itemImage",get_itemImage,set_itemImage,true);
		addMember(l,"options",get_options,set_options,true);
		addMember(l,"onValueChanged",get_onValueChanged,set_onValueChanged,true);
		addMember(l,"alphaFadeSpeed",get_alphaFadeSpeed,set_alphaFadeSpeed,true);
		addMember(l,"value",get_value,set_value,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Dropdown),typeof(UnityEngine.UI.Selectable));
	}
}
