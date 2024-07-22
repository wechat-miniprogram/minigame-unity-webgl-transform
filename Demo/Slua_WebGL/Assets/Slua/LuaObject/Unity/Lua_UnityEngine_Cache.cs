using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Cache : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Cache o;
			o=new UnityEngine.Cache();
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
	static public int ClearCache(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.Cache self;
				checkValueType(l,1,out self);
				var ret=self.ClearCache();
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==2){
				UnityEngine.Cache self;
				checkValueType(l,1,out self);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.ClearCache(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function ClearCache to call");
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
			UnityEngine.Cache a1;
			checkValueType(l,1,out a1);
			UnityEngine.Cache a2;
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
			UnityEngine.Cache a1;
			checkValueType(l,1,out a1);
			UnityEngine.Cache a2;
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
	static public int get_valid(IntPtr l) {
		try {
			UnityEngine.Cache self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.valid);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_ready(IntPtr l) {
		try {
			UnityEngine.Cache self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.ready);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_readOnly(IntPtr l) {
		try {
			UnityEngine.Cache self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.readOnly);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_path(IntPtr l) {
		try {
			UnityEngine.Cache self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.path);
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
			UnityEngine.Cache self;
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
	static public int get_spaceFree(IntPtr l) {
		try {
			UnityEngine.Cache self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.spaceFree);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maximumAvailableStorageSpace(IntPtr l) {
		try {
			UnityEngine.Cache self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.maximumAvailableStorageSpace);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_maximumAvailableStorageSpace(IntPtr l) {
		try {
			UnityEngine.Cache self;
			checkValueType(l,1,out self);
			System.Int64 v;
			checkType(l,2,out v);
			self.maximumAvailableStorageSpace=v;
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
	static public int get_spaceOccupied(IntPtr l) {
		try {
			UnityEngine.Cache self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.spaceOccupied);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_expirationDelay(IntPtr l) {
		try {
			UnityEngine.Cache self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.expirationDelay);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_expirationDelay(IntPtr l) {
		try {
			UnityEngine.Cache self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.expirationDelay=v;
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
		getTypeTable(l,"UnityEngine.Cache");
		addMember(l,ClearCache);
		addMember(l,op_Equality);
		addMember(l,op_Inequality);
		addMember(l,"valid",get_valid,null,true);
		addMember(l,"ready",get_ready,null,true);
		addMember(l,"readOnly",get_readOnly,null,true);
		addMember(l,"path",get_path,null,true);
		addMember(l,"index",get_index,null,true);
		addMember(l,"spaceFree",get_spaceFree,null,true);
		addMember(l,"maximumAvailableStorageSpace",get_maximumAvailableStorageSpace,set_maximumAvailableStorageSpace,true);
		addMember(l,"spaceOccupied",get_spaceOccupied,null,true);
		addMember(l,"expirationDelay",get_expirationDelay,set_expirationDelay,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Cache),typeof(System.ValueType));
	}
}
