using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Vector2Int : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Vector2Int o;
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			o=new UnityEngine.Vector2Int(a1,a2);
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
	static public int Set(IntPtr l) {
		try {
			UnityEngine.Vector2Int self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			self.Set(a1,a2);
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
	static public int Scale(IntPtr l) {
		try {
			UnityEngine.Vector2Int self;
			checkValueType(l,1,out self);
			UnityEngine.Vector2Int a1;
			checkValueType(l,2,out a1);
			self.Scale(a1);
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
	static public int Clamp(IntPtr l) {
		try {
			UnityEngine.Vector2Int self;
			checkValueType(l,1,out self);
			UnityEngine.Vector2Int a1;
			checkValueType(l,2,out a1);
			UnityEngine.Vector2Int a2;
			checkValueType(l,3,out a2);
			self.Clamp(a1,a2);
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
	static public int Distance_s(IntPtr l) {
		try {
			UnityEngine.Vector2Int a1;
			checkValueType(l,1,out a1);
			UnityEngine.Vector2Int a2;
			checkValueType(l,2,out a2);
			var ret=UnityEngine.Vector2Int.Distance(a1,a2);
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
	static public int Min_s(IntPtr l) {
		try {
			UnityEngine.Vector2Int a1;
			checkValueType(l,1,out a1);
			UnityEngine.Vector2Int a2;
			checkValueType(l,2,out a2);
			var ret=UnityEngine.Vector2Int.Min(a1,a2);
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
	static public int Max_s(IntPtr l) {
		try {
			UnityEngine.Vector2Int a1;
			checkValueType(l,1,out a1);
			UnityEngine.Vector2Int a2;
			checkValueType(l,2,out a2);
			var ret=UnityEngine.Vector2Int.Max(a1,a2);
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
	static public int Scale_s(IntPtr l) {
		try {
			UnityEngine.Vector2Int a1;
			checkValueType(l,1,out a1);
			UnityEngine.Vector2Int a2;
			checkValueType(l,2,out a2);
			var ret=UnityEngine.Vector2Int.Scale(a1,a2);
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
	static public int FloorToInt_s(IntPtr l) {
		try {
			UnityEngine.Vector2 a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Vector2Int.FloorToInt(a1);
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
	static public int CeilToInt_s(IntPtr l) {
		try {
			UnityEngine.Vector2 a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Vector2Int.CeilToInt(a1);
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
	static public int RoundToInt_s(IntPtr l) {
		try {
			UnityEngine.Vector2 a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Vector2Int.RoundToInt(a1);
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
	static public int op_UnaryNegation(IntPtr l) {
		try {
			UnityEngine.Vector2Int a1;
			checkValueType(l,1,out a1);
			var ret=-a1;
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
	static public int op_Addition(IntPtr l) {
		try {
			UnityEngine.Vector2Int a1;
			checkValueType(l,1,out a1);
			UnityEngine.Vector2Int a2;
			checkValueType(l,2,out a2);
			var ret=a1+a2;
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
	static public int op_Subtraction(IntPtr l) {
		try {
			UnityEngine.Vector2Int a1;
			checkValueType(l,1,out a1);
			UnityEngine.Vector2Int a2;
			checkValueType(l,2,out a2);
			var ret=a1-a2;
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
	static public int op_Multiply(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Vector2Int),typeof(UnityEngine.Vector2Int))){
				UnityEngine.Vector2Int a1;
				checkValueType(l,1,out a1);
				UnityEngine.Vector2Int a2;
				checkValueType(l,2,out a2);
				var ret=a1*a2;
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(UnityEngine.Vector2Int))){
				System.Int32 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2Int a2;
				checkValueType(l,2,out a2);
				var ret=a1*a2;
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector2Int),typeof(int))){
				UnityEngine.Vector2Int a1;
				checkValueType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				var ret=a1*a2;
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function op_Multiply to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int op_Division(IntPtr l) {
		try {
			UnityEngine.Vector2Int a1;
			checkValueType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			var ret=a1/a2;
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
			UnityEngine.Vector2Int a1;
			checkValueType(l,1,out a1);
			UnityEngine.Vector2Int a2;
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
			UnityEngine.Vector2Int a1;
			checkValueType(l,1,out a1);
			UnityEngine.Vector2Int a2;
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
	static public int get_x(IntPtr l) {
		try {
			UnityEngine.Vector2Int self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.x);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_x(IntPtr l) {
		try {
			UnityEngine.Vector2Int self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.x=v;
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
	static public int get_y(IntPtr l) {
		try {
			UnityEngine.Vector2Int self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.y);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_y(IntPtr l) {
		try {
			UnityEngine.Vector2Int self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.y=v;
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
	static public int get_magnitude(IntPtr l) {
		try {
			UnityEngine.Vector2Int self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.magnitude);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_sqrMagnitude(IntPtr l) {
		try {
			UnityEngine.Vector2Int self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sqrMagnitude);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_zero(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Vector2Int.zero);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_one(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Vector2Int.one);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_up(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Vector2Int.up);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_down(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Vector2Int.down);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_left(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Vector2Int.left);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_right(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Vector2Int.right);
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
			UnityEngine.Vector2Int self;
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
			UnityEngine.Vector2Int self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			int c;
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
		getTypeTable(l,"UnityEngine.Vector2Int");
		addMember(l,Set);
		addMember(l,Scale);
		addMember(l,Clamp);
		addMember(l,Distance_s);
		addMember(l,Min_s);
		addMember(l,Max_s);
		addMember(l,Scale_s);
		addMember(l,FloorToInt_s);
		addMember(l,CeilToInt_s);
		addMember(l,RoundToInt_s);
		addMember(l,op_UnaryNegation);
		addMember(l,op_Addition);
		addMember(l,op_Subtraction);
		addMember(l,op_Multiply);
		addMember(l,op_Division);
		addMember(l,op_Equality);
		addMember(l,op_Inequality);
		addMember(l,getItem);
		addMember(l,setItem);
		addMember(l,"x",get_x,set_x,true);
		addMember(l,"y",get_y,set_y,true);
		addMember(l,"magnitude",get_magnitude,null,true);
		addMember(l,"sqrMagnitude",get_sqrMagnitude,null,true);
		addMember(l,"zero",get_zero,null,false);
		addMember(l,"one",get_one,null,false);
		addMember(l,"up",get_up,null,false);
		addMember(l,"down",get_down,null,false);
		addMember(l,"left",get_left,null,false);
		addMember(l,"right",get_right,null,false);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Vector2Int),typeof(System.ValueType));
	}
}
