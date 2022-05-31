using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Jobs_TransformAccessArray : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			UnityEngine.Jobs.TransformAccessArray o;
			if(matchType(l,argc,2,typeof(UnityEngine.Transform[]),typeof(int))){
				UnityEngine.Transform[] a1;
				checkArray(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				o=new UnityEngine.Jobs.TransformAccessArray(a1,a2);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(int))){
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				o=new UnityEngine.Jobs.TransformAccessArray(a1,a2);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==0){
				o=new UnityEngine.Jobs.TransformAccessArray();
				pushValue(l,true);
				pushObject(l,o);
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
	static public int Dispose(IntPtr l) {
		try {
			UnityEngine.Jobs.TransformAccessArray self;
			checkValueType(l,1,out self);
			self.Dispose();
			pushValue(l,true);
			setBack(l,self);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Add(IntPtr l) {
		try {
			UnityEngine.Jobs.TransformAccessArray self;
			checkValueType(l,1,out self);
			UnityEngine.Transform a1;
			checkType(l,2,out a1);
			self.Add(a1);
			pushValue(l,true);
			setBack(l,self);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RemoveAtSwapBack(IntPtr l) {
		try {
			UnityEngine.Jobs.TransformAccessArray self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			self.RemoveAtSwapBack(a1);
			pushValue(l,true);
			setBack(l,self);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetTransforms(IntPtr l) {
		try {
			UnityEngine.Jobs.TransformAccessArray self;
			checkValueType(l,1,out self);
			UnityEngine.Transform[] a1;
			checkArray(l,2,out a1);
			self.SetTransforms(a1);
			pushValue(l,true);
			setBack(l,self);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Allocate_s(IntPtr l) {
		try {
			System.Int32 a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			UnityEngine.Jobs.TransformAccessArray a3;
			UnityEngine.Jobs.TransformAccessArray.Allocate(a1,a2,out a3);
			pushValue(l,true);
			pushValue(l,a3);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isCreated(IntPtr l) {
		try {
			UnityEngine.Jobs.TransformAccessArray self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.isCreated);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_capacity(IntPtr l) {
		try {
			UnityEngine.Jobs.TransformAccessArray self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.capacity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_capacity(IntPtr l) {
		try {
			UnityEngine.Jobs.TransformAccessArray self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.capacity=v;
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
	static public int get_length(IntPtr l) {
		try {
			UnityEngine.Jobs.TransformAccessArray self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.length);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int getItem(IntPtr l) {
		try {
			UnityEngine.Jobs.TransformAccessArray self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			var ret = self[v];
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
	static public int setItem(IntPtr l) {
		try {
			UnityEngine.Jobs.TransformAccessArray self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			UnityEngine.Transform c;
			checkType(l,3,out c);
			self[v]=c;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Jobs.TransformAccessArray");
		addMember(l,Dispose);
		addMember(l,Add);
		addMember(l,RemoveAtSwapBack);
		addMember(l,SetTransforms);
		addMember(l,Allocate_s);
		addMember(l,getItem);
		addMember(l,setItem);
		addMember(l,"isCreated",get_isCreated,null,true);
		addMember(l,"capacity",get_capacity,set_capacity,true);
		addMember(l,"length",get_length,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Jobs.TransformAccessArray),typeof(System.ValueType));
	}
}
