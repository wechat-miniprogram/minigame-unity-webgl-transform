using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_InputField : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetTextWithoutNotify(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			self.SetTextWithoutNotify(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int MoveTextEnd(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			self.MoveTextEnd(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int MoveTextStart(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			self.MoveTextStart(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnBeginDrag(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnBeginDrag(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnDrag(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnDrag(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnEndDrag(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnEndDrag(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnPointerDown(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnPointerDown(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ProcessEvent(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.Event a1;
			checkType(l,2,out a1);
			self.ProcessEvent(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnUpdateSelected(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.EventSystems.BaseEventData a1;
			checkType(l,2,out a1);
			self.OnUpdateSelected(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ForceLabelUpdate(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			self.ForceLabelUpdate();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Rebuild(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.UI.CanvasUpdate a1;
			a1 = (UnityEngine.UI.CanvasUpdate)LuaDLL.luaL_checkinteger(l, 2);
			self.Rebuild(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int LayoutComplete(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			self.LayoutComplete();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GraphicUpdateComplete(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			self.GraphicUpdateComplete();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ActivateInputField(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			self.ActivateInputField();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnSelect(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.EventSystems.BaseEventData a1;
			checkType(l,2,out a1);
			self.OnSelect(a1);
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
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
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
	static public int DeactivateInputField(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			self.DeactivateInputField();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnDeselect(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.EventSystems.BaseEventData a1;
			checkType(l,2,out a1);
			self.OnDeselect(a1);
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
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
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
	static public int CalculateLayoutInputHorizontal(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
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
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
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
	static public int get_shouldHideMobileInput(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.shouldHideMobileInput);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_shouldHideMobileInput(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.shouldHideMobileInput=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_shouldActivateOnSelect(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.shouldActivateOnSelect);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_shouldActivateOnSelect(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.shouldActivateOnSelect=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_text(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
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
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
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
	static public int get_isFocused(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isFocused);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_caretBlinkRate(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.caretBlinkRate);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_caretBlinkRate(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.caretBlinkRate=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_caretWidth(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.caretWidth);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_caretWidth(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.caretWidth=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_textComponent(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.textComponent);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_textComponent(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.UI.Text v;
			checkType(l,2,out v);
			self.textComponent=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_placeholder(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.placeholder);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_placeholder(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.UI.Graphic v;
			checkType(l,2,out v);
			self.placeholder=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_caretColor(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.caretColor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_caretColor(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.caretColor=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_customCaretColor(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.customCaretColor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_customCaretColor(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.customCaretColor=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_selectionColor(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.selectionColor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_selectionColor(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.selectionColor=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_onEndEdit(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.onEndEdit);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_onEndEdit(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.UI.InputField.EndEditEvent v;
			checkType(l,2,out v);
			self.onEndEdit=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_onSubmit(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.onSubmit);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_onSubmit(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.UI.InputField.SubmitEvent v;
			checkType(l,2,out v);
			self.onSubmit=v;
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
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
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
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.UI.InputField.OnChangeEvent v;
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
	static public int set_onValidateInput(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.UI.InputField.OnValidateInput v;
			int op=checkDelegate(l,2,out v);
			if(op==0) self.onValidateInput=v;
			else if(op==1) self.onValidateInput+=v;
			else if(op==2) self.onValidateInput-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_characterLimit(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.characterLimit);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_characterLimit(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.characterLimit=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_contentType(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.contentType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_contentType(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.UI.InputField.ContentType v;
			v = (UnityEngine.UI.InputField.ContentType)LuaDLL.luaL_checkinteger(l, 2);
			self.contentType=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_lineType(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.lineType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_lineType(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.UI.InputField.LineType v;
			v = (UnityEngine.UI.InputField.LineType)LuaDLL.luaL_checkinteger(l, 2);
			self.lineType=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_inputType(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.inputType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_inputType(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.UI.InputField.InputType v;
			v = (UnityEngine.UI.InputField.InputType)LuaDLL.luaL_checkinteger(l, 2);
			self.inputType=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_touchScreenKeyboard(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.touchScreenKeyboard);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_keyboardType(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.keyboardType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_keyboardType(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.TouchScreenKeyboardType v;
			v = (UnityEngine.TouchScreenKeyboardType)LuaDLL.luaL_checkinteger(l, 2);
			self.keyboardType=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_characterValidation(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.characterValidation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_characterValidation(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			UnityEngine.UI.InputField.CharacterValidation v;
			v = (UnityEngine.UI.InputField.CharacterValidation)LuaDLL.luaL_checkinteger(l, 2);
			self.characterValidation=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_readOnly(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.readOnly);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_readOnly(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.readOnly=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_multiLine(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.multiLine);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_asteriskChar(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.asteriskChar);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_asteriskChar(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			System.Char v;
			checkType(l,2,out v);
			self.asteriskChar=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_wasCanceled(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.wasCanceled);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_caretPosition(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.caretPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_caretPosition(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.caretPosition=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_selectionAnchorPosition(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.selectionAnchorPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_selectionAnchorPosition(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.selectionAnchorPosition=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_selectionFocusPosition(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.selectionFocusPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_selectionFocusPosition(IntPtr l) {
		try {
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.selectionFocusPosition=v;
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
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
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
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
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
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
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
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
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
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
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
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
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
			UnityEngine.UI.InputField self=(UnityEngine.UI.InputField)checkSelf(l);
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
		getTypeTable(l,"UnityEngine.UI.InputField");
		addMember(l,SetTextWithoutNotify);
		addMember(l,MoveTextEnd);
		addMember(l,MoveTextStart);
		addMember(l,OnBeginDrag);
		addMember(l,OnDrag);
		addMember(l,OnEndDrag);
		addMember(l,OnPointerDown);
		addMember(l,ProcessEvent);
		addMember(l,OnUpdateSelected);
		addMember(l,ForceLabelUpdate);
		addMember(l,Rebuild);
		addMember(l,LayoutComplete);
		addMember(l,GraphicUpdateComplete);
		addMember(l,ActivateInputField);
		addMember(l,OnSelect);
		addMember(l,OnPointerClick);
		addMember(l,DeactivateInputField);
		addMember(l,OnDeselect);
		addMember(l,OnSubmit);
		addMember(l,CalculateLayoutInputHorizontal);
		addMember(l,CalculateLayoutInputVertical);
		addMember(l,"shouldHideMobileInput",get_shouldHideMobileInput,set_shouldHideMobileInput,true);
		addMember(l,"shouldActivateOnSelect",get_shouldActivateOnSelect,set_shouldActivateOnSelect,true);
		addMember(l,"text",get_text,set_text,true);
		addMember(l,"isFocused",get_isFocused,null,true);
		addMember(l,"caretBlinkRate",get_caretBlinkRate,set_caretBlinkRate,true);
		addMember(l,"caretWidth",get_caretWidth,set_caretWidth,true);
		addMember(l,"textComponent",get_textComponent,set_textComponent,true);
		addMember(l,"placeholder",get_placeholder,set_placeholder,true);
		addMember(l,"caretColor",get_caretColor,set_caretColor,true);
		addMember(l,"customCaretColor",get_customCaretColor,set_customCaretColor,true);
		addMember(l,"selectionColor",get_selectionColor,set_selectionColor,true);
		addMember(l,"onEndEdit",get_onEndEdit,set_onEndEdit,true);
		addMember(l,"onSubmit",get_onSubmit,set_onSubmit,true);
		addMember(l,"onValueChanged",get_onValueChanged,set_onValueChanged,true);
		addMember(l,"onValidateInput",null,set_onValidateInput,true);
		addMember(l,"characterLimit",get_characterLimit,set_characterLimit,true);
		addMember(l,"contentType",get_contentType,set_contentType,true);
		addMember(l,"lineType",get_lineType,set_lineType,true);
		addMember(l,"inputType",get_inputType,set_inputType,true);
		addMember(l,"touchScreenKeyboard",get_touchScreenKeyboard,null,true);
		addMember(l,"keyboardType",get_keyboardType,set_keyboardType,true);
		addMember(l,"characterValidation",get_characterValidation,set_characterValidation,true);
		addMember(l,"readOnly",get_readOnly,set_readOnly,true);
		addMember(l,"multiLine",get_multiLine,null,true);
		addMember(l,"asteriskChar",get_asteriskChar,set_asteriskChar,true);
		addMember(l,"wasCanceled",get_wasCanceled,null,true);
		addMember(l,"caretPosition",get_caretPosition,set_caretPosition,true);
		addMember(l,"selectionAnchorPosition",get_selectionAnchorPosition,set_selectionAnchorPosition,true);
		addMember(l,"selectionFocusPosition",get_selectionFocusPosition,set_selectionFocusPosition,true);
		addMember(l,"minWidth",get_minWidth,null,true);
		addMember(l,"preferredWidth",get_preferredWidth,null,true);
		addMember(l,"flexibleWidth",get_flexibleWidth,null,true);
		addMember(l,"minHeight",get_minHeight,null,true);
		addMember(l,"preferredHeight",get_preferredHeight,null,true);
		addMember(l,"flexibleHeight",get_flexibleHeight,null,true);
		addMember(l,"layoutPriority",get_layoutPriority,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.InputField),typeof(UnityEngine.UI.Selectable));
	}
}
