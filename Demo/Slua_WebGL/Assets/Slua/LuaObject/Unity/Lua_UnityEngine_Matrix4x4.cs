using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Matrix4x4 : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 o;
			UnityEngine.Vector4 a1;
			checkType(l,2,out a1);
			UnityEngine.Vector4 a2;
			checkType(l,3,out a2);
			UnityEngine.Vector4 a3;
			checkType(l,4,out a3);
			UnityEngine.Vector4 a4;
			checkType(l,5,out a4);
			o=new UnityEngine.Matrix4x4(a1,a2,a3,a4);
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
	static public int ValidTRS(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			var ret=self.ValidTRS();
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
	static public int SetTRS(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			UnityEngine.Quaternion a2;
			checkType(l,3,out a2);
			UnityEngine.Vector3 a3;
			checkType(l,4,out a3);
			self.SetTRS(a1,a2,a3);
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
	static public int GetColumn(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetColumn(a1);
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
	static public int GetRow(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetRow(a1);
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
	static public int GetPosition(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			var ret=self.GetPosition();
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
	static public int SetColumn(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			UnityEngine.Vector4 a2;
			checkType(l,3,out a2);
			self.SetColumn(a1,a2);
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
	static public int SetRow(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			UnityEngine.Vector4 a2;
			checkType(l,3,out a2);
			self.SetRow(a1,a2);
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
	static public int MultiplyPoint(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			var ret=self.MultiplyPoint(a1);
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
	static public int MultiplyPoint3x4(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			var ret=self.MultiplyPoint3x4(a1);
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
	static public int MultiplyVector(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			var ret=self.MultiplyVector(a1);
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
	static public int TransformPlane(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			UnityEngine.Plane a1;
			checkValueType(l,2,out a1);
			var ret=self.TransformPlane(a1);
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
	static public int Determinant_s(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 a1;
			checkValueType(l,1,out a1);
			var ret=UnityEngine.Matrix4x4.Determinant(a1);
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
	static public int TRS_s(IntPtr l) {
		try {
			UnityEngine.Vector3 a1;
			checkType(l,1,out a1);
			UnityEngine.Quaternion a2;
			checkType(l,2,out a2);
			UnityEngine.Vector3 a3;
			checkType(l,3,out a3);
			var ret=UnityEngine.Matrix4x4.TRS(a1,a2,a3);
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
	static public int Inverse3DAffine_s(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 a1;
			checkValueType(l,1,out a1);
			UnityEngine.Matrix4x4 a2;
			checkValueType(l,2,out a2);
			var ret=UnityEngine.Matrix4x4.Inverse3DAffine(a1,ref a2);
			pushValue(l,true);
			pushValue(l,ret);
			pushValue(l,a2);
			return 3;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Inverse_s(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 a1;
			checkValueType(l,1,out a1);
			var ret=UnityEngine.Matrix4x4.Inverse(a1);
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
	static public int Transpose_s(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 a1;
			checkValueType(l,1,out a1);
			var ret=UnityEngine.Matrix4x4.Transpose(a1);
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
	static public int Ortho_s(IntPtr l) {
		try {
			System.Single a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			System.Single a4;
			checkType(l,4,out a4);
			System.Single a5;
			checkType(l,5,out a5);
			System.Single a6;
			checkType(l,6,out a6);
			var ret=UnityEngine.Matrix4x4.Ortho(a1,a2,a3,a4,a5,a6);
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
	static public int Perspective_s(IntPtr l) {
		try {
			System.Single a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			System.Single a4;
			checkType(l,4,out a4);
			var ret=UnityEngine.Matrix4x4.Perspective(a1,a2,a3,a4);
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
	static public int LookAt_s(IntPtr l) {
		try {
			UnityEngine.Vector3 a1;
			checkType(l,1,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,2,out a2);
			UnityEngine.Vector3 a3;
			checkType(l,3,out a3);
			var ret=UnityEngine.Matrix4x4.LookAt(a1,a2,a3);
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
	static public int Frustum_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.FrustumPlanes a1;
				checkValueType(l,1,out a1);
				var ret=UnityEngine.Matrix4x4.Frustum(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==6){
				System.Single a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				var ret=UnityEngine.Matrix4x4.Frustum(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Frustum to call");
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
			if(matchType(l,argc,1,typeof(UnityEngine.Matrix4x4),typeof(UnityEngine.Matrix4x4))){
				UnityEngine.Matrix4x4 a1;
				checkValueType(l,1,out a1);
				UnityEngine.Matrix4x4 a2;
				checkValueType(l,2,out a2);
				var ret=a1*a2;
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Matrix4x4),typeof(UnityEngine.Vector4))){
				UnityEngine.Matrix4x4 a1;
				checkValueType(l,1,out a1);
				UnityEngine.Vector4 a2;
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
	static public int op_Equality(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 a1;
			checkValueType(l,1,out a1);
			UnityEngine.Matrix4x4 a2;
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
			UnityEngine.Matrix4x4 a1;
			checkValueType(l,1,out a1);
			UnityEngine.Matrix4x4 a2;
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
	static public int Scale_s(IntPtr l) {
		try {
			UnityEngine.Vector3 a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Matrix4x4.Scale(a1);
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
	static public int Translate_s(IntPtr l) {
		try {
			UnityEngine.Vector3 a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Matrix4x4.Translate(a1);
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
	static public int Rotate_s(IntPtr l) {
		try {
			UnityEngine.Quaternion a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Matrix4x4.Rotate(a1);
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
	static public int get_m00(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.m00);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_m00(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.m00=v;
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
	static public int get_m10(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.m10);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_m10(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.m10=v;
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
	static public int get_m20(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.m20);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_m20(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.m20=v;
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
	static public int get_m30(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.m30);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_m30(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.m30=v;
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
	static public int get_m01(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.m01);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_m01(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.m01=v;
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
	static public int get_m11(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.m11);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_m11(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.m11=v;
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
	static public int get_m21(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.m21);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_m21(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.m21=v;
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
	static public int get_m31(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.m31);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_m31(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.m31=v;
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
	static public int get_m02(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.m02);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_m02(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.m02=v;
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
	static public int get_m12(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.m12);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_m12(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.m12=v;
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
	static public int get_m22(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.m22);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_m22(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.m22=v;
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
	static public int get_m32(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.m32);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_m32(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.m32=v;
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
	static public int get_m03(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.m03);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_m03(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.m03=v;
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
	static public int get_m13(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.m13);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_m13(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.m13=v;
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
	static public int get_m23(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.m23);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_m23(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.m23=v;
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
	static public int get_m33(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.m33);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_m33(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.m33=v;
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
	static public int get_rotation(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.rotation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_lossyScale(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.lossyScale);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isIdentity(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.isIdentity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_determinant(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.determinant);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_decomposeProjection(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.decomposeProjection);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_inverse(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.inverse);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_transpose(IntPtr l) {
		try {
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.transpose);
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
			pushValue(l,UnityEngine.Matrix4x4.zero);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_identity(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Matrix4x4.identity);
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
			UnityEngine.Matrix4x4 self;
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
			UnityEngine.Matrix4x4 self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			float c;
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
		getTypeTable(l,"UnityEngine.Matrix4x4");
		addMember(l,ValidTRS);
		addMember(l,SetTRS);
		addMember(l,GetColumn);
		addMember(l,GetRow);
		addMember(l,GetPosition);
		addMember(l,SetColumn);
		addMember(l,SetRow);
		addMember(l,MultiplyPoint);
		addMember(l,MultiplyPoint3x4);
		addMember(l,MultiplyVector);
		addMember(l,TransformPlane);
		addMember(l,Determinant_s);
		addMember(l,TRS_s);
		addMember(l,Inverse3DAffine_s);
		addMember(l,Inverse_s);
		addMember(l,Transpose_s);
		addMember(l,Ortho_s);
		addMember(l,Perspective_s);
		addMember(l,LookAt_s);
		addMember(l,Frustum_s);
		addMember(l,op_Multiply);
		addMember(l,op_Equality);
		addMember(l,op_Inequality);
		addMember(l,Scale_s);
		addMember(l,Translate_s);
		addMember(l,Rotate_s);
		addMember(l,getItem);
		addMember(l,setItem);
		addMember(l,"m00",get_m00,set_m00,true);
		addMember(l,"m10",get_m10,set_m10,true);
		addMember(l,"m20",get_m20,set_m20,true);
		addMember(l,"m30",get_m30,set_m30,true);
		addMember(l,"m01",get_m01,set_m01,true);
		addMember(l,"m11",get_m11,set_m11,true);
		addMember(l,"m21",get_m21,set_m21,true);
		addMember(l,"m31",get_m31,set_m31,true);
		addMember(l,"m02",get_m02,set_m02,true);
		addMember(l,"m12",get_m12,set_m12,true);
		addMember(l,"m22",get_m22,set_m22,true);
		addMember(l,"m32",get_m32,set_m32,true);
		addMember(l,"m03",get_m03,set_m03,true);
		addMember(l,"m13",get_m13,set_m13,true);
		addMember(l,"m23",get_m23,set_m23,true);
		addMember(l,"m33",get_m33,set_m33,true);
		addMember(l,"rotation",get_rotation,null,true);
		addMember(l,"lossyScale",get_lossyScale,null,true);
		addMember(l,"isIdentity",get_isIdentity,null,true);
		addMember(l,"determinant",get_determinant,null,true);
		addMember(l,"decomposeProjection",get_decomposeProjection,null,true);
		addMember(l,"inverse",get_inverse,null,true);
		addMember(l,"transpose",get_transpose,null,true);
		addMember(l,"zero",get_zero,null,false);
		addMember(l,"identity",get_identity,null,false);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Matrix4x4),typeof(System.ValueType));
	}
}
