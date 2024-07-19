using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_Deleg : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int callD_s(IntPtr l) {
		try {
			Deleg.callD();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int setcallback2_s(IntPtr l) {
		try {
			System.Action<System.Int32> a1;
			checkDelegate(l,1,out a1);
			System.Action<System.String> a2;
			checkDelegate(l,2,out a2);
			Deleg.setcallback2(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int testFunc_s(IntPtr l) {
		try {
			System.Func<System.Int32> a1;
			checkDelegate(l,1,out a1);
			Deleg.testFunc(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int testAction_s(IntPtr l) {
		try {
			System.Action<System.Int32,System.String> a1;
			checkDelegate(l,1,out a1);
			Deleg.testAction(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int testDAction_s(IntPtr l) {
		try {
			System.Action<System.Int32,System.Collections.Generic.Dictionary<System.Int32,System.Object>> a1;
			checkDelegate(l,1,out a1);
			Deleg.testDAction(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int callDAction_s(IntPtr l) {
		try {
			Deleg.callDAction();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int getFunc_s(IntPtr l) {
		try {
			System.Func<System.Int32,System.String,System.Boolean> a1;
			checkDelegate(l,1,out a1);
			var ret=Deleg.getFunc(a1);
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
	static public int set_d(IntPtr l) {
		try {
			Deleg.GetBundleInfoDelegate v;
			int op=checkDelegate(l,2,out v);
			if(op==0) Deleg.d=v;
			else if(op==1) Deleg.d+=v;
			else if(op==2) Deleg.d-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_s(IntPtr l) {
		try {
			Deleg.SimpleDelegate v;
			int op=checkDelegate(l,2,out v);
			if(op==0) Deleg.s=v;
			else if(op==1) Deleg.s+=v;
			else if(op==2) Deleg.s-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_daction(IntPtr l) {
		try {
			System.Action<System.Int32,System.Collections.Generic.Dictionary<System.Int32,System.Object>> v;
			int op=checkDelegate(l,2,out v);
			if(op==0) Deleg.daction=v;
			else if(op==1) Deleg.daction+=v;
			else if(op==2) Deleg.daction-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_dx(IntPtr l) {
		try {
			Deleg.GetBundleInfoDelegate v;
			int op=checkDelegate(l,2,out v);
			if(op==0) Deleg.dx=v;
			else if(op==1) Deleg.dx+=v;
			else if(op==2) Deleg.dx-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"Deleg");
		addMember(l,callD_s);
		addMember(l,setcallback2_s);
		addMember(l,testFunc_s);
		addMember(l,testAction_s);
		addMember(l,testDAction_s);
		addMember(l,callDAction_s);
		addMember(l,getFunc_s);
		addMember(l,"d",null,set_d,false);
		addMember(l,"s",null,set_s,false);
		addMember(l,"daction",null,set_daction,false);
		addMember(l,"dx",null,set_dx,false);
		createTypeMetatable(l,null, typeof(Deleg),typeof(UnityEngine.MonoBehaviour));
	}
}
