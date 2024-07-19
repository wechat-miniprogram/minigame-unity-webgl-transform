using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_SecondarySpriteTexture : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.SecondarySpriteTexture o;
			o=new UnityEngine.SecondarySpriteTexture();
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
	static public int get_name(IntPtr l) {
		try {
			UnityEngine.SecondarySpriteTexture self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.name);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_name(IntPtr l) {
		try {
			UnityEngine.SecondarySpriteTexture self;
			checkValueType(l,1,out self);
			System.String v;
			checkType(l,2,out v);
			self.name=v;
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
	static public int get_texture(IntPtr l) {
		try {
			UnityEngine.SecondarySpriteTexture self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.texture);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_texture(IntPtr l) {
		try {
			UnityEngine.SecondarySpriteTexture self;
			checkValueType(l,1,out self);
			UnityEngine.Texture2D v;
			checkType(l,2,out v);
			self.texture=v;
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
		getTypeTable(l,"UnityEngine.SecondarySpriteTexture");
		addMember(l,"name",get_name,set_name,true);
		addMember(l,"texture",get_texture,set_texture,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.SecondarySpriteTexture),typeof(System.ValueType));
	}
}
