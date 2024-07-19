using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Animations_AnimationStreamHandleUtility : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int WriteInts_s(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationStream a1;
			checkValueType(l,1,out a1);
			Unity.Collections.NativeArray<UnityEngine.Animations.PropertyStreamHandle> a2;
			checkValueType(l,2,out a2);
			Unity.Collections.NativeArray<System.Int32> a3;
			checkValueType(l,3,out a3);
			System.Boolean a4;
			checkType(l,4,out a4);
			UnityEngine.Animations.AnimationStreamHandleUtility.WriteInts(a1,a2,a3,a4);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int WriteFloats_s(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationStream a1;
			checkValueType(l,1,out a1);
			Unity.Collections.NativeArray<UnityEngine.Animations.PropertyStreamHandle> a2;
			checkValueType(l,2,out a2);
			Unity.Collections.NativeArray<System.Single> a3;
			checkValueType(l,3,out a3);
			System.Boolean a4;
			checkType(l,4,out a4);
			UnityEngine.Animations.AnimationStreamHandleUtility.WriteFloats(a1,a2,a3,a4);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ReadInts_s(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationStream a1;
			checkValueType(l,1,out a1);
			Unity.Collections.NativeArray<UnityEngine.Animations.PropertyStreamHandle> a2;
			checkValueType(l,2,out a2);
			Unity.Collections.NativeArray<System.Int32> a3;
			checkValueType(l,3,out a3);
			UnityEngine.Animations.AnimationStreamHandleUtility.ReadInts(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ReadFloats_s(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationStream a1;
			checkValueType(l,1,out a1);
			Unity.Collections.NativeArray<UnityEngine.Animations.PropertyStreamHandle> a2;
			checkValueType(l,2,out a2);
			Unity.Collections.NativeArray<System.Single> a3;
			checkValueType(l,3,out a3);
			UnityEngine.Animations.AnimationStreamHandleUtility.ReadFloats(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Animations.AnimationStreamHandleUtility");
		addMember(l,WriteInts_s);
		addMember(l,WriteFloats_s);
		addMember(l,ReadInts_s);
		addMember(l,ReadFloats_s);
		createTypeMetatable(l,null, typeof(UnityEngine.Animations.AnimationStreamHandleUtility));
	}
}
