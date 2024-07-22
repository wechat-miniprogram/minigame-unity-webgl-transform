using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_HelloWorld : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			HelloWorld o;
			o=new HelloWorld();
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
	static public int y(IntPtr l) {
		try {
			HelloWorld self=(HelloWorld)checkSelf(l);
			var ret=self.y();
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
	static public int foo(IntPtr l) {
		try {
			HelloWorld self=(HelloWorld)checkSelf(l);
			var ret=self.foo();
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
	static public int foos(IntPtr l) {
		try {
			HelloWorld self=(HelloWorld)checkSelf(l);
			var ret=self.foos();
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
	static public int gos(IntPtr l) {
		try {
			HelloWorld self=(HelloWorld)checkSelf(l);
			System.Collections.Generic.Dictionary<System.String,UnityEngine.GameObject>[] a1;
			checkArray(l,2,out a1);
			var ret=self.gos(a1);
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
	static public int too(IntPtr l) {
		try {
			HelloWorld self=(HelloWorld)checkSelf(l);
			var ret=self.too();
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
	static public int getList(IntPtr l) {
		try {
			HelloWorld self=(HelloWorld)checkSelf(l);
			var ret=self.getList();
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
	static public int perf(IntPtr l) {
		try {
			HelloWorld self=(HelloWorld)checkSelf(l);
			self.perf();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int func7(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(SLua.LuaFunction))){
				HelloWorld self=(HelloWorld)checkSelf(l);
				SLua.LuaFunction a1;
				checkType(l,2,out a1);
				self.func7(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int))){
				HelloWorld self=(HelloWorld)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				self.func7(a1);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function func7 to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int func8(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				HelloWorld self=(HelloWorld)checkSelf(l);
				var ret=self.func8();
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==2){
				HelloWorld self=(HelloWorld)checkSelf(l);
				System.Collections.Generic.List<System.Int32> a1;
				checkType(l,2,out a1);
				self.func8(a1);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function func8 to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int say_s(IntPtr l) {
		try {
			HelloWorld.say();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int bytes_s(IntPtr l) {
		try {
			var ret=HelloWorld.bytes();
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
	static public int int16Array_s(IntPtr l) {
		try {
			System.Int16[] a1;
			checkArray(l,1,out a1);
			HelloWorld.int16Array(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int vectors_s(IntPtr l) {
		try {
			var ret=HelloWorld.vectors();
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
	static public int nullf_s(IntPtr l) {
		try {
			System.Nullable<System.Int32> a1;
			checkNullable(l,1,out a1);
			HelloWorld.nullf(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int setv_s(IntPtr l) {
		try {
			SLua.LuaTable a1;
			checkType(l,1,out a1);
			HelloWorld.setv(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int getNegInt_s(IntPtr l) {
		try {
			var ret=HelloWorld.getNegInt();
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
	static public int getv_s(IntPtr l) {
		try {
			var ret=HelloWorld.getv();
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
	static public int ofunc_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(System.Type))){
				System.Type a1;
				checkType(l,1,out a1);
				HelloWorld.ofunc(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.GameObject))){
				UnityEngine.GameObject a1;
				checkType(l,1,out a1);
				HelloWorld.ofunc(a1);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function ofunc to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AFunc_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(int))){
				System.Int32 a1;
				checkType(l,1,out a1);
				HelloWorld.AFunc(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(float))){
				System.Single a1;
				checkType(l,1,out a1);
				HelloWorld.AFunc(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(string))){
				System.String a1;
				checkType(l,1,out a1);
				HelloWorld.AFunc(a1);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function AFunc to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AFuncByDouble_s(IntPtr l) {
		try {
			System.Double a1;
			checkType(l,1,out a1);
			HelloWorld.AFunc(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int testvec3_s(IntPtr l) {
		try {
			UnityEngine.Vector3 a1;
			checkType(l,1,out a1);
			HelloWorld.testvec3(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int testset_s(IntPtr l) {
		try {
			UnityEngine.GameObject a1;
			checkType(l,1,out a1);
			HelloWorld.testset(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int test2_s(IntPtr l) {
		try {
			UnityEngine.GameObject a1;
			checkType(l,1,out a1);
			HelloWorld.test2(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int test3_s(IntPtr l) {
		try {
			UnityEngine.GameObject a1;
			checkType(l,1,out a1);
			HelloWorld.test3(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int test4_s(IntPtr l) {
		try {
			UnityEngine.GameObject a1;
			checkType(l,1,out a1);
			HelloWorld.test4(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int test5_s(IntPtr l) {
		try {
			UnityEngine.GameObject a1;
			checkType(l,1,out a1);
			var ret=HelloWorld.test5(a1);
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
	static public int func6_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Object[] a2;
			checkParams(l,2,out a2);
			HelloWorld.func6(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int byteArrayTest_s(IntPtr l) {
		try {
			HelloWorld.byteArrayTest();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int transformArray_s(IntPtr l) {
		try {
			UnityEngine.Transform[] a1;
			checkArray(l,1,out a1);
			HelloWorld.transformArray(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int setObjs_s(IntPtr l) {
		try {
			System.Object[] a1;
			checkArray(l,1,out a1);
			HelloWorld.setObjs(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_cc(IntPtr l) {
		try {
			HelloWorld self=(HelloWorld)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.cc);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_cc(IntPtr l) {
		try {
			HelloWorld self=(HelloWorld)checkSelf(l);
			UnityEngine.Color32 v;
			checkValueType(l,2,out v);
			self.cc=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_someAct(IntPtr l) {
		try {
			HelloWorld self=(HelloWorld)checkSelf(l);
			UnityEngine.Events.UnityAction v;
			int op=checkDelegate(l,2,out v);
			if(op==0) self.someAct=v;
			else if(op==1) self.someAct+=v;
			else if(op==2) self.someAct-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int getItem(IntPtr l) {
		try {
			HelloWorld self=(HelloWorld)checkSelf(l);
			LuaTypes t = LuaDLL.lua_type(l, 2);
			if(matchType(l,2,t,typeof(System.String))){
				string v;
				checkType(l,2,out v);
				var ret = self[v];
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,2,t,typeof(System.Int32))){
				int v;
				checkType(l,2,out v);
				var ret = self[v];
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function getItem to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int setItem(IntPtr l) {
		try {
			HelloWorld self=(HelloWorld)checkSelf(l);
			LuaTypes t = LuaDLL.lua_type(l, 2);
			if(matchType(l,2,t,typeof(System.String))){
				string v;
				checkType(l,2,out v);
				System.Object c;
				checkType(l,3,out c);
				self[v]=c;
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,2,t,typeof(System.Int32))){
				int v;
				checkType(l,2,out v);
				System.Object c;
				checkType(l,3,out c);
				self[v]=c;
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function setItem to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"HelloWorld");
		addMember(l,y);
		addMember(l,foo);
		addMember(l,foos);
		addMember(l,gos);
		addMember(l,too);
		addMember(l,getList);
		addMember(l,perf);
		addMember(l,func7);
		addMember(l,func8);
		addMember(l,say_s);
		addMember(l,bytes_s);
		addMember(l,int16Array_s);
		addMember(l,vectors_s);
		addMember(l,nullf_s);
		addMember(l,setv_s);
		addMember(l,getNegInt_s);
		addMember(l,getv_s);
		addMember(l,ofunc_s);
		addMember(l,AFuncByDouble_s);
		addMember(l,AFunc_s);
		addMember(l,testvec3_s);
		addMember(l,testset_s);
		addMember(l,test2_s);
		addMember(l,test3_s);
		addMember(l,test4_s);
		addMember(l,test5_s);
		addMember(l,func6_s);
		addMember(l,byteArrayTest_s);
		addMember(l,transformArray_s);
		addMember(l,setObjs_s);
		addMember(l,getItem);
		addMember(l,setItem);
		addMember(l,"cc",get_cc,set_cc,true);
		addMember(l,"someAct",null,set_someAct,true);
		createTypeMetatable(l,constructor, typeof(HelloWorld));
	}
}
