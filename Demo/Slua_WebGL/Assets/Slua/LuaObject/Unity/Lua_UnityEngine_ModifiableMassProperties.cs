using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ModifiableMassProperties : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.ModifiableMassProperties o;
			o=new UnityEngine.ModifiableMassProperties();
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
	static public int get_inverseMassScale(IntPtr l) {
		try {
			UnityEngine.ModifiableMassProperties self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.inverseMassScale);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_inverseMassScale(IntPtr l) {
		try {
			UnityEngine.ModifiableMassProperties self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.inverseMassScale=v;
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
	static public int get_inverseInertiaScale(IntPtr l) {
		try {
			UnityEngine.ModifiableMassProperties self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.inverseInertiaScale);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_inverseInertiaScale(IntPtr l) {
		try {
			UnityEngine.ModifiableMassProperties self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.inverseInertiaScale=v;
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
	static public int get_otherInverseMassScale(IntPtr l) {
		try {
			UnityEngine.ModifiableMassProperties self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.otherInverseMassScale);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_otherInverseMassScale(IntPtr l) {
		try {
			UnityEngine.ModifiableMassProperties self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.otherInverseMassScale=v;
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
	static public int get_otherInverseInertiaScale(IntPtr l) {
		try {
			UnityEngine.ModifiableMassProperties self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.otherInverseInertiaScale);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_otherInverseInertiaScale(IntPtr l) {
		try {
			UnityEngine.ModifiableMassProperties self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.otherInverseInertiaScale=v;
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
		getTypeTable(l,"UnityEngine.ModifiableMassProperties");
		addMember(l,"inverseMassScale",get_inverseMassScale,set_inverseMassScale,true);
		addMember(l,"inverseInertiaScale",get_inverseInertiaScale,set_inverseInertiaScale,true);
		addMember(l,"otherInverseMassScale",get_otherInverseMassScale,set_otherInverseMassScale,true);
		addMember(l,"otherInverseInertiaScale",get_otherInverseInertiaScale,set_otherInverseInertiaScale,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ModifiableMassProperties),typeof(System.ValueType));
	}
}
