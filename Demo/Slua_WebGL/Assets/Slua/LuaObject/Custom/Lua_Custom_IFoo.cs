using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_Custom_IFoo : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int getInt(IntPtr l) {
		try {
			Custom.IFoo self=(Custom.IFoo)checkSelf(l);
			var ret=self.getInt();
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
	static public int setInt(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				Custom.IFoo self=(Custom.IFoo)checkSelf(l);
				System.Int32 a2;
				checkType(l,2,out a2);
				self.setInt(a2);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				Custom.IFoo self=(Custom.IFoo)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				self.setInt(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function setInt to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"Custom.IFoo");
		addMember(l,getInt);
		addMember(l,setInt);
		createTypeMetatable(l,null, typeof(Custom.IFoo));
	}
}
