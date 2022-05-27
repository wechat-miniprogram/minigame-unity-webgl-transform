using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_CharacterInfo : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.CharacterInfo o;
			o=new UnityEngine.CharacterInfo();
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
	static public int get_index(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.index);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_index(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			System.Int32 v;
			checkType(l,2,out v);
			self.index=v;
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
	static public int get_size(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.size);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_size(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			System.Int32 v;
			checkType(l,2,out v);
			self.size=v;
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
	static public int get_style(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.style);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_style(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			UnityEngine.FontStyle v;
			v = (UnityEngine.FontStyle)LuaDLL.luaL_checkinteger(l, 2);
			self.style=v;
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
	static public int get_advance(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.advance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_advance(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.advance=v;
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
	static public int get_glyphWidth(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.glyphWidth);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_glyphWidth(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.glyphWidth=v;
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
	static public int get_glyphHeight(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.glyphHeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_glyphHeight(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.glyphHeight=v;
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
	static public int get_bearing(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.bearing);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_bearing(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.bearing=v;
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
	static public int get_minY(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.minY);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_minY(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.minY=v;
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
	static public int get_maxY(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.maxY);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_maxY(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.maxY=v;
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
	static public int get_minX(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.minX);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_minX(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.minX=v;
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
	static public int get_maxX(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.maxX);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_maxX(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.maxX=v;
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
	static public int get_uvBottomLeft(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.uvBottomLeft);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_uvBottomLeft(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.uvBottomLeft=v;
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
	static public int get_uvBottomRight(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.uvBottomRight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_uvBottomRight(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.uvBottomRight=v;
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
	static public int get_uvTopRight(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.uvTopRight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_uvTopRight(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.uvTopRight=v;
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
	static public int get_uvTopLeft(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.uvTopLeft);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_uvTopLeft(IntPtr l) {
		try {
			UnityEngine.CharacterInfo self;
			checkValueType(l,1,out self);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.uvTopLeft=v;
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
		getTypeTable(l,"UnityEngine.CharacterInfo");
		addMember(l,"index",get_index,set_index,true);
		addMember(l,"size",get_size,set_size,true);
		addMember(l,"style",get_style,set_style,true);
		addMember(l,"advance",get_advance,set_advance,true);
		addMember(l,"glyphWidth",get_glyphWidth,set_glyphWidth,true);
		addMember(l,"glyphHeight",get_glyphHeight,set_glyphHeight,true);
		addMember(l,"bearing",get_bearing,set_bearing,true);
		addMember(l,"minY",get_minY,set_minY,true);
		addMember(l,"maxY",get_maxY,set_maxY,true);
		addMember(l,"minX",get_minX,set_minX,true);
		addMember(l,"maxX",get_maxX,set_maxX,true);
		addMember(l,"uvBottomLeft",get_uvBottomLeft,set_uvBottomLeft,true);
		addMember(l,"uvBottomRight",get_uvBottomRight,set_uvBottomRight,true);
		addMember(l,"uvTopRight",get_uvTopRight,set_uvTopRight,true);
		addMember(l,"uvTopLeft",get_uvTopLeft,set_uvTopLeft,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.CharacterInfo),typeof(System.ValueType));
	}
}
