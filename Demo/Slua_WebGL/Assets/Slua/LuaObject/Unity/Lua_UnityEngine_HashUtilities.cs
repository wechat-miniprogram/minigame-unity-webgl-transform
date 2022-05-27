using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_HashUtilities : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AppendHash_s(IntPtr l) {
		try {
			UnityEngine.Hash128 a1;
			checkValueType(l,1,out a1);
			UnityEngine.Hash128 a2;
			checkValueType(l,2,out a2);
			UnityEngine.HashUtilities.AppendHash(ref a1,ref a2);
			pushValue(l,true);
			pushValue(l,a1);
			pushValue(l,a2);
			return 3;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int QuantisedMatrixHash_s(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 a1;
			checkValueType(l,1,out a1);
			UnityEngine.Hash128 a2;
			checkValueType(l,2,out a2);
			UnityEngine.HashUtilities.QuantisedMatrixHash(ref a1,ref a2);
			pushValue(l,true);
			pushValue(l,a1);
			pushValue(l,a2);
			return 3;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int QuantisedVectorHash_s(IntPtr l) {
		try {
			UnityEngine.Vector3 a1;
			checkType(l,1,out a1);
			UnityEngine.Hash128 a2;
			checkValueType(l,2,out a2);
			UnityEngine.HashUtilities.QuantisedVectorHash(ref a1,ref a2);
			pushValue(l,true);
			pushValue(l,a1);
			pushValue(l,a2);
			return 3;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ComputeHash128_s(IntPtr l) {
		try {
			System.Byte[] a1;
			checkArray(l,1,out a1);
			UnityEngine.Hash128 a2;
			checkValueType(l,2,out a2);
			UnityEngine.HashUtilities.ComputeHash128(a1,ref a2);
			pushValue(l,true);
			pushValue(l,a2);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.HashUtilities");
		addMember(l,AppendHash_s);
		addMember(l,QuantisedMatrixHash_s);
		addMember(l,QuantisedVectorHash_s);
		addMember(l,ComputeHash128_s);
		createTypeMetatable(l,null, typeof(UnityEngine.HashUtilities));
	}
}
