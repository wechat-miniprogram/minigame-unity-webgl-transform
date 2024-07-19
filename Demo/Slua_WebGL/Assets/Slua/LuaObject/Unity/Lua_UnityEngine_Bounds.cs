using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Bounds : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Bounds o;
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			o=new UnityEngine.Bounds(a1,a2);
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
	static public int SetMinMax(IntPtr l) {
		try {
			UnityEngine.Bounds self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			self.SetMinMax(a1,a2);
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
	static public int Encapsulate(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(UnityEngine.Vector3))){
				UnityEngine.Bounds self;
				checkValueType(l,1,out self);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				self.Encapsulate(a1);
				pushValue(l,true);
				setBack(l,self);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Bounds))){
				UnityEngine.Bounds self;
				checkValueType(l,1,out self);
				UnityEngine.Bounds a1;
				checkValueType(l,2,out a1);
				self.Encapsulate(a1);
				pushValue(l,true);
				setBack(l,self);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Encapsulate to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Expand(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(float))){
				UnityEngine.Bounds self;
				checkValueType(l,1,out self);
				System.Single a1;
				checkType(l,2,out a1);
				self.Expand(a1);
				pushValue(l,true);
				setBack(l,self);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector3))){
				UnityEngine.Bounds self;
				checkValueType(l,1,out self);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				self.Expand(a1);
				pushValue(l,true);
				setBack(l,self);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Expand to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Intersects(IntPtr l) {
		try {
			UnityEngine.Bounds self;
			checkValueType(l,1,out self);
			UnityEngine.Bounds a1;
			checkValueType(l,2,out a1);
			var ret=self.Intersects(a1);
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
	static public int IntersectRay(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Bounds self;
				checkValueType(l,1,out self);
				UnityEngine.Ray a1;
				checkValueType(l,2,out a1);
				var ret=self.IntersectRay(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==3){
				UnityEngine.Bounds self;
				checkValueType(l,1,out self);
				UnityEngine.Ray a1;
				checkValueType(l,2,out a1);
				System.Single a2;
				var ret=self.IntersectRay(a1,out a2);
				pushValue(l,true);
				pushValue(l,ret);
				pushValue(l,a2);
				return 3;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function IntersectRay to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Contains(IntPtr l) {
		try {
			UnityEngine.Bounds self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			var ret=self.Contains(a1);
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
	static public int SqrDistance(IntPtr l) {
		try {
			UnityEngine.Bounds self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			var ret=self.SqrDistance(a1);
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
	static public int ClosestPoint(IntPtr l) {
		try {
			UnityEngine.Bounds self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			var ret=self.ClosestPoint(a1);
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
	static public int op_Equality(IntPtr l) {
		try {
			UnityEngine.Bounds a1;
			checkValueType(l,1,out a1);
			UnityEngine.Bounds a2;
			checkValueType(l,2,out a2);
			var ret=(a1==a2);
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
	static public int op_Inequality(IntPtr l) {
		try {
			UnityEngine.Bounds a1;
			checkValueType(l,1,out a1);
			UnityEngine.Bounds a2;
			checkValueType(l,2,out a2);
			var ret=(a1!=a2);
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
	static public int get_center(IntPtr l) {
		try {
			UnityEngine.Bounds self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.center);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_center(IntPtr l) {
		try {
			UnityEngine.Bounds self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.center=v;
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
			UnityEngine.Bounds self;
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
			UnityEngine.Bounds self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
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
	static public int get_extents(IntPtr l) {
		try {
			UnityEngine.Bounds self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.extents);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_extents(IntPtr l) {
		try {
			UnityEngine.Bounds self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.extents=v;
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
	static public int get_min(IntPtr l) {
		try {
			UnityEngine.Bounds self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.min);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_min(IntPtr l) {
		try {
			UnityEngine.Bounds self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.min=v;
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
	static public int get_max(IntPtr l) {
		try {
			UnityEngine.Bounds self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.max);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_max(IntPtr l) {
		try {
			UnityEngine.Bounds self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.max=v;
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
		getTypeTable(l,"UnityEngine.Bounds");
		addMember(l,SetMinMax);
		addMember(l,Encapsulate);
		addMember(l,Expand);
		addMember(l,Intersects);
		addMember(l,IntersectRay);
		addMember(l,Contains);
		addMember(l,SqrDistance);
		addMember(l,ClosestPoint);
		addMember(l,op_Equality);
		addMember(l,op_Inequality);
		addMember(l,"center",get_center,set_center,true);
		addMember(l,"size",get_size,set_size,true);
		addMember(l,"extents",get_extents,set_extents,true);
		addMember(l,"min",get_min,set_min,true);
		addMember(l,"max",get_max,set_max,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Bounds),typeof(System.ValueType));
	}
}
