using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_MonoBehaviour : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int IsInvoking(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.MonoBehaviour self=(UnityEngine.MonoBehaviour)checkSelf(l);
				var ret=self.IsInvoking();
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==2){
				UnityEngine.MonoBehaviour self=(UnityEngine.MonoBehaviour)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				var ret=self.IsInvoking(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function IsInvoking to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CancelInvoke(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.MonoBehaviour self=(UnityEngine.MonoBehaviour)checkSelf(l);
				self.CancelInvoke();
				pushValue(l,true);
				return 1;
			}
			else if(argc==2){
				UnityEngine.MonoBehaviour self=(UnityEngine.MonoBehaviour)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				self.CancelInvoke(a1);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function CancelInvoke to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Invoke(IntPtr l) {
		try {
			UnityEngine.MonoBehaviour self=(UnityEngine.MonoBehaviour)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			self.Invoke(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int InvokeRepeating(IntPtr l) {
		try {
			UnityEngine.MonoBehaviour self=(UnityEngine.MonoBehaviour)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			System.Single a3;
			checkType(l,4,out a3);
			self.InvokeRepeating(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int StartCoroutine(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(string))){
				UnityEngine.MonoBehaviour self=(UnityEngine.MonoBehaviour)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				var ret=self.StartCoroutine(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(System.Collections.IEnumerator))){
				UnityEngine.MonoBehaviour self=(UnityEngine.MonoBehaviour)checkSelf(l);
				System.Collections.IEnumerator a1;
				checkType(l,2,out a1);
				var ret=self.StartCoroutine(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(SLua.LuaFunction))){
				UnityEngine.MonoBehaviour self=(UnityEngine.MonoBehaviour)checkSelf(l);
				SLua.LuaFunction a2;
				checkType(l,2,out a2);
				var ret=self.StartCoroutine(a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==3){
				UnityEngine.MonoBehaviour self=(UnityEngine.MonoBehaviour)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Object a2;
				checkType(l,3,out a2);
				var ret=self.StartCoroutine(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function StartCoroutine to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int StopCoroutine(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(System.Collections.IEnumerator))){
				UnityEngine.MonoBehaviour self=(UnityEngine.MonoBehaviour)checkSelf(l);
				System.Collections.IEnumerator a1;
				checkType(l,2,out a1);
				self.StopCoroutine(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Coroutine))){
				UnityEngine.MonoBehaviour self=(UnityEngine.MonoBehaviour)checkSelf(l);
				UnityEngine.Coroutine a1;
				checkType(l,2,out a1);
				self.StopCoroutine(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string))){
				UnityEngine.MonoBehaviour self=(UnityEngine.MonoBehaviour)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				self.StopCoroutine(a1);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function StopCoroutine to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int StopAllCoroutines(IntPtr l) {
		try {
			UnityEngine.MonoBehaviour self=(UnityEngine.MonoBehaviour)checkSelf(l);
			self.StopAllCoroutines();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int print_s(IntPtr l) {
		try {
			System.Object a1;
			checkType(l,1,out a1);
			UnityEngine.MonoBehaviour.print(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.MonoBehaviour");
		addMember(l,IsInvoking);
		addMember(l,CancelInvoke);
		addMember(l,Invoke);
		addMember(l,InvokeRepeating);
		addMember(l,StartCoroutine);
		addMember(l,StopCoroutine);
		addMember(l,StopAllCoroutines);
		addMember(l,print_s);
		createTypeMetatable(l,null, typeof(UnityEngine.MonoBehaviour),typeof(UnityEngine.Behaviour));
	}
}
