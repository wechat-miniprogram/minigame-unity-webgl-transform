using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_SpriteRenderer : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RegisterSpriteChangeCallback(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			UnityEngine.Events.UnityAction<UnityEngine.SpriteRenderer> a1;
			checkDelegate(l,2,out a1);
			self.RegisterSpriteChangeCallback(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int UnregisterSpriteChangeCallback(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			UnityEngine.Events.UnityAction<UnityEngine.SpriteRenderer> a1;
			checkDelegate(l,2,out a1);
			self.UnregisterSpriteChangeCallback(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_sprite(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.sprite);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_sprite(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			UnityEngine.Sprite v;
			checkType(l,2,out v);
			self.sprite=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_drawMode(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.drawMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_drawMode(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			UnityEngine.SpriteDrawMode v;
			v = (UnityEngine.SpriteDrawMode)LuaDLL.luaL_checkinteger(l, 2);
			self.drawMode=v;
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
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
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
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.size=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_adaptiveModeThreshold(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.adaptiveModeThreshold);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_adaptiveModeThreshold(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.adaptiveModeThreshold=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_tileMode(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.tileMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_tileMode(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			UnityEngine.SpriteTileMode v;
			v = (UnityEngine.SpriteTileMode)LuaDLL.luaL_checkinteger(l, 2);
			self.tileMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_color(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.color);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_color(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.color=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maskInteraction(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.maskInteraction);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_maskInteraction(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			UnityEngine.SpriteMaskInteraction v;
			v = (UnityEngine.SpriteMaskInteraction)LuaDLL.luaL_checkinteger(l, 2);
			self.maskInteraction=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_flipX(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.flipX);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_flipX(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.flipX=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_flipY(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.flipY);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_flipY(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.flipY=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_spriteSortPoint(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.spriteSortPoint);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_spriteSortPoint(IntPtr l) {
		try {
			UnityEngine.SpriteRenderer self=(UnityEngine.SpriteRenderer)checkSelf(l);
			UnityEngine.SpriteSortPoint v;
			v = (UnityEngine.SpriteSortPoint)LuaDLL.luaL_checkinteger(l, 2);
			self.spriteSortPoint=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.SpriteRenderer");
		addMember(l,RegisterSpriteChangeCallback);
		addMember(l,UnregisterSpriteChangeCallback);
		addMember(l,"sprite",get_sprite,set_sprite,true);
		addMember(l,"drawMode",get_drawMode,set_drawMode,true);
		addMember(l,"size",get_size,set_size,true);
		addMember(l,"adaptiveModeThreshold",get_adaptiveModeThreshold,set_adaptiveModeThreshold,true);
		addMember(l,"tileMode",get_tileMode,set_tileMode,true);
		addMember(l,"color",get_color,set_color,true);
		addMember(l,"maskInteraction",get_maskInteraction,set_maskInteraction,true);
		addMember(l,"flipX",get_flipX,set_flipX,true);
		addMember(l,"flipY",get_flipY,set_flipY,true);
		addMember(l,"spriteSortPoint",get_spriteSortPoint,set_spriteSortPoint,true);
		createTypeMetatable(l,null, typeof(UnityEngine.SpriteRenderer),typeof(UnityEngine.Renderer));
	}
}
