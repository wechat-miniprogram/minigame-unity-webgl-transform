using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Event : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			UnityEngine.Event o;
			if(argc==1){
				o=new UnityEngine.Event();
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int))){
				System.Int32 a1;
				checkType(l,2,out a1);
				o=new UnityEngine.Event(a1);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Event))){
				UnityEngine.Event a1;
				checkType(l,2,out a1);
				o=new UnityEngine.Event(a1);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			return error(l,"New object failed.");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetTypeForControl(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetTypeForControl(a1);
			pushValue(l,true);
			pushEnum(l,(int)ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Use(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			self.Use();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int PopEvent_s(IntPtr l) {
		try {
			UnityEngine.Event a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Event.PopEvent(a1);
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
	static public int GetEventCount_s(IntPtr l) {
		try {
			var ret=UnityEngine.Event.GetEventCount();
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
	static public int KeyboardEvent_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Event.KeyboardEvent(a1);
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
	static public int get_rawType(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.rawType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_mousePosition(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.mousePosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_mousePosition(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.mousePosition=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_delta(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.delta);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_delta(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.delta=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_pointerType(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.pointerType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_pointerType(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			UnityEngine.PointerType v;
			v = (UnityEngine.PointerType)LuaDLL.luaL_checkinteger(l, 2);
			self.pointerType=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_button(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.button);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_button(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.button=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_modifiers(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.modifiers);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_modifiers(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			UnityEngine.EventModifiers v;
			v = (UnityEngine.EventModifiers)LuaDLL.luaL_checkinteger(l, 2);
			self.modifiers=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_pressure(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pressure);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_pressure(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.pressure=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_clickCount(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.clickCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_clickCount(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.clickCount=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_character(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.character);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_character(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			System.Char v;
			checkType(l,2,out v);
			self.character=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_keyCode(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.keyCode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_keyCode(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			UnityEngine.KeyCode v;
			v = (UnityEngine.KeyCode)LuaDLL.luaL_checkinteger(l, 2);
			self.keyCode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_displayIndex(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.displayIndex);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_displayIndex(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.displayIndex=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_type(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.type);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_type(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			UnityEngine.EventType v;
			v = (UnityEngine.EventType)LuaDLL.luaL_checkinteger(l, 2);
			self.type=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_commandName(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.commandName);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_commandName(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.commandName=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_shift(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.shift);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_shift(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.shift=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_control(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.control);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_control(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.control=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_alt(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.alt);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_alt(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.alt=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_command(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.command);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_command(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.command=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_capsLock(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.capsLock);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_capsLock(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.capsLock=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_numeric(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.numeric);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_numeric(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.numeric=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_functionKey(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.functionKey);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_current(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Event.current);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_current(IntPtr l) {
		try {
			UnityEngine.Event v;
			checkType(l,2,out v);
			UnityEngine.Event.current=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isKey(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isKey);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isMouse(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isMouse);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isScrollWheel(IntPtr l) {
		try {
			UnityEngine.Event self=(UnityEngine.Event)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isScrollWheel);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Event");
		addMember(l,GetTypeForControl);
		addMember(l,Use);
		addMember(l,PopEvent_s);
		addMember(l,GetEventCount_s);
		addMember(l,KeyboardEvent_s);
		addMember(l,"rawType",get_rawType,null,true);
		addMember(l,"mousePosition",get_mousePosition,set_mousePosition,true);
		addMember(l,"delta",get_delta,set_delta,true);
		addMember(l,"pointerType",get_pointerType,set_pointerType,true);
		addMember(l,"button",get_button,set_button,true);
		addMember(l,"modifiers",get_modifiers,set_modifiers,true);
		addMember(l,"pressure",get_pressure,set_pressure,true);
		addMember(l,"clickCount",get_clickCount,set_clickCount,true);
		addMember(l,"character",get_character,set_character,true);
		addMember(l,"keyCode",get_keyCode,set_keyCode,true);
		addMember(l,"displayIndex",get_displayIndex,set_displayIndex,true);
		addMember(l,"type",get_type,set_type,true);
		addMember(l,"commandName",get_commandName,set_commandName,true);
		addMember(l,"shift",get_shift,set_shift,true);
		addMember(l,"control",get_control,set_control,true);
		addMember(l,"alt",get_alt,set_alt,true);
		addMember(l,"command",get_command,set_command,true);
		addMember(l,"capsLock",get_capsLock,set_capsLock,true);
		addMember(l,"numeric",get_numeric,set_numeric,true);
		addMember(l,"functionKey",get_functionKey,null,true);
		addMember(l,"current",get_current,set_current,false);
		addMember(l,"isKey",get_isKey,null,true);
		addMember(l,"isMouse",get_isMouse,null,true);
		addMember(l,"isScrollWheel",get_isScrollWheel,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Event));
	}
}
