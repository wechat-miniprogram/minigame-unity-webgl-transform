using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_IExposedPropertyTable : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetReferenceValue(IntPtr l) {
		try {
			UnityEngine.IExposedPropertyTable self=(UnityEngine.IExposedPropertyTable)checkSelf(l);
			UnityEngine.PropertyName a1;
			checkValueType(l,2,out a1);
			UnityEngine.Object a2;
			checkType(l,3,out a2);
			self.SetReferenceValue(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetReferenceValue(IntPtr l) {
		try {
			UnityEngine.IExposedPropertyTable self=(UnityEngine.IExposedPropertyTable)checkSelf(l);
			UnityEngine.PropertyName a1;
			checkValueType(l,2,out a1);
			System.Boolean a2;
			var ret=self.GetReferenceValue(a1,out a2);
			pushValue(l,true);
			pushValue(l,ret);
			pushValue(l,a2);
			return 3;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ClearReferenceValue(IntPtr l) {
		try {
			UnityEngine.IExposedPropertyTable self=(UnityEngine.IExposedPropertyTable)checkSelf(l);
			UnityEngine.PropertyName a1;
			checkValueType(l,2,out a1);
			self.ClearReferenceValue(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.IExposedPropertyTable");
		addMember(l,SetReferenceValue);
		addMember(l,GetReferenceValue);
		addMember(l,ClearReferenceValue);
		createTypeMetatable(l,null, typeof(UnityEngine.IExposedPropertyTable));
	}
}
