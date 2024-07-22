using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Animations_AnimationLayerMixerPlayable : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationLayerMixerPlayable o;
			o=new UnityEngine.Animations.AnimationLayerMixerPlayable();
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
	static public int GetHandle(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationLayerMixerPlayable self;
			checkValueType(l,1,out self);
			var ret=self.GetHandle();
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
	static public int IsLayerAdditive(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationLayerMixerPlayable self;
			checkValueType(l,1,out self);
			System.UInt32 a1;
			checkType(l,2,out a1);
			var ret=self.IsLayerAdditive(a1);
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
	static public int SetLayerAdditive(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationLayerMixerPlayable self;
			checkValueType(l,1,out self);
			System.UInt32 a1;
			checkType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			self.SetLayerAdditive(a1,a2);
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
	static public int SetLayerMaskFromAvatarMask(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationLayerMixerPlayable self;
			checkValueType(l,1,out self);
			System.UInt32 a1;
			checkType(l,2,out a1);
			UnityEngine.AvatarMask a2;
			checkType(l,3,out a2);
			self.SetLayerMaskFromAvatarMask(a1,a2);
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
	static public int Create_s(IntPtr l) {
		try {
			UnityEngine.Playables.PlayableGraph a1;
			checkValueType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			System.Boolean a3;
			checkType(l,3,out a3);
			var ret=UnityEngine.Animations.AnimationLayerMixerPlayable.Create(a1,a2,a3);
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
	static public int get_Null(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Animations.AnimationLayerMixerPlayable.Null);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Animations.AnimationLayerMixerPlayable");
		addMember(l,GetHandle);
		addMember(l,IsLayerAdditive);
		addMember(l,SetLayerAdditive);
		addMember(l,SetLayerMaskFromAvatarMask);
		addMember(l,Create_s);
		addMember(l,"Null",get_Null,null,false);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Animations.AnimationLayerMixerPlayable),typeof(System.ValueType));
	}
}
