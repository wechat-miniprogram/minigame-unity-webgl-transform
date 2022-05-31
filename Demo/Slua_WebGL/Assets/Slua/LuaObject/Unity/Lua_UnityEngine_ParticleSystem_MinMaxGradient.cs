using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystem_MinMaxGradient : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			UnityEngine.ParticleSystem.MinMaxGradient o;
			if(matchType(l,argc,2,typeof(UnityEngine.Color))){
				UnityEngine.Color a1;
				checkType(l,2,out a1);
				o=new UnityEngine.ParticleSystem.MinMaxGradient(a1);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Gradient))){
				UnityEngine.Gradient a1;
				checkType(l,2,out a1);
				o=new UnityEngine.ParticleSystem.MinMaxGradient(a1);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Color),typeof(UnityEngine.Color))){
				UnityEngine.Color a1;
				checkType(l,2,out a1);
				UnityEngine.Color a2;
				checkType(l,3,out a2);
				o=new UnityEngine.ParticleSystem.MinMaxGradient(a1,a2);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Gradient),typeof(UnityEngine.Gradient))){
				UnityEngine.Gradient a1;
				checkType(l,2,out a1);
				UnityEngine.Gradient a2;
				checkType(l,3,out a2);
				o=new UnityEngine.ParticleSystem.MinMaxGradient(a1,a2);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==0){
				o=new UnityEngine.ParticleSystem.MinMaxGradient();
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
	static public int Evaluate(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.ParticleSystem.MinMaxGradient self;
				checkValueType(l,1,out self);
				System.Single a1;
				checkType(l,2,out a1);
				var ret=self.Evaluate(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==3){
				UnityEngine.ParticleSystem.MinMaxGradient self;
				checkValueType(l,1,out self);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				var ret=self.Evaluate(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Evaluate to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_mode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MinMaxGradient self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.mode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_mode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MinMaxGradient self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemGradientMode v;
			v = (UnityEngine.ParticleSystemGradientMode)LuaDLL.luaL_checkinteger(l, 2);
			self.mode=v;
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
	static public int get_gradientMax(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MinMaxGradient self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.gradientMax);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_gradientMax(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MinMaxGradient self;
			checkValueType(l,1,out self);
			UnityEngine.Gradient v;
			checkType(l,2,out v);
			self.gradientMax=v;
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
	static public int get_gradientMin(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MinMaxGradient self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.gradientMin);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_gradientMin(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MinMaxGradient self;
			checkValueType(l,1,out self);
			UnityEngine.Gradient v;
			checkType(l,2,out v);
			self.gradientMin=v;
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
	static public int get_colorMax(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MinMaxGradient self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.colorMax);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_colorMax(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MinMaxGradient self;
			checkValueType(l,1,out self);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.colorMax=v;
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
	static public int get_colorMin(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MinMaxGradient self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.colorMin);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_colorMin(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MinMaxGradient self;
			checkValueType(l,1,out self);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.colorMin=v;
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
	static public int get_color(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MinMaxGradient self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.color);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_color(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MinMaxGradient self;
			checkValueType(l,1,out self);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.color=v;
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
	static public int get_gradient(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MinMaxGradient self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.gradient);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_gradient(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MinMaxGradient self;
			checkValueType(l,1,out self);
			UnityEngine.Gradient v;
			checkType(l,2,out v);
			self.gradient=v;
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
		getTypeTable(l,"UnityEngine.ParticleSystem.MinMaxGradient");
		addMember(l,Evaluate);
		addMember(l,"mode",get_mode,set_mode,true);
		addMember(l,"gradientMax",get_gradientMax,set_gradientMax,true);
		addMember(l,"gradientMin",get_gradientMin,set_gradientMin,true);
		addMember(l,"colorMax",get_colorMax,set_colorMax,true);
		addMember(l,"colorMin",get_colorMin,set_colorMin,true);
		addMember(l,"color",get_color,set_color,true);
		addMember(l,"gradient",get_gradient,set_gradient,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ParticleSystem.MinMaxGradient),typeof(System.ValueType));
	}
}
