using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Transform : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetParent(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				UnityEngine.Transform a1;
				checkType(l,2,out a1);
				self.SetParent(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				UnityEngine.Transform a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				self.SetParent(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetParent to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetPositionAndRotation(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			UnityEngine.Quaternion a2;
			checkType(l,3,out a2);
			self.SetPositionAndRotation(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Translate(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				self.Translate(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector3),typeof(UnityEngine.Space))){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.Space a2;
				a2 = (UnityEngine.Space)LuaDLL.luaL_checkinteger(l, 3);
				self.Translate(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector3),typeof(UnityEngine.Transform))){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.Transform a2;
				checkType(l,3,out a2);
				self.Translate(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				self.Translate(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(float),typeof(float),typeof(float),typeof(UnityEngine.Space))){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				UnityEngine.Space a4;
				a4 = (UnityEngine.Space)LuaDLL.luaL_checkinteger(l, 5);
				self.Translate(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(float),typeof(float),typeof(float),typeof(UnityEngine.Transform))){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				UnityEngine.Transform a4;
				checkType(l,5,out a4);
				self.Translate(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Translate to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Rotate(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				self.Rotate(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector3),typeof(UnityEngine.Space))){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.Space a2;
				a2 = (UnityEngine.Space)LuaDLL.luaL_checkinteger(l, 3);
				self.Rotate(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector3),typeof(float))){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				self.Rotate(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(float),typeof(float),typeof(float))){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				self.Rotate(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector3),typeof(float),typeof(UnityEngine.Space))){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				UnityEngine.Space a3;
				a3 = (UnityEngine.Space)LuaDLL.luaL_checkinteger(l, 4);
				self.Rotate(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				UnityEngine.Space a4;
				a4 = (UnityEngine.Space)LuaDLL.luaL_checkinteger(l, 5);
				self.Rotate(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Rotate to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RotateAround(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			System.Single a3;
			checkType(l,4,out a3);
			self.RotateAround(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int LookAt(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(UnityEngine.Transform))){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				UnityEngine.Transform a1;
				checkType(l,2,out a1);
				self.LookAt(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector3))){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				self.LookAt(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Transform),typeof(UnityEngine.Vector3))){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				UnityEngine.Transform a1;
				checkType(l,2,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,3,out a2);
				self.LookAt(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector3),typeof(UnityEngine.Vector3))){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,3,out a2);
				self.LookAt(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function LookAt to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int TransformDirection(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				var ret=self.TransformDirection(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==4){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				var ret=self.TransformDirection(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function TransformDirection to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int InverseTransformDirection(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				var ret=self.InverseTransformDirection(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==4){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				var ret=self.InverseTransformDirection(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function InverseTransformDirection to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int TransformVector(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				var ret=self.TransformVector(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==4){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				var ret=self.TransformVector(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function TransformVector to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int InverseTransformVector(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				var ret=self.InverseTransformVector(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==4){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				var ret=self.InverseTransformVector(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function InverseTransformVector to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int TransformPoint(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				var ret=self.TransformPoint(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==4){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				var ret=self.TransformPoint(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function TransformPoint to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int InverseTransformPoint(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				var ret=self.InverseTransformPoint(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==4){
				UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				var ret=self.InverseTransformPoint(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function InverseTransformPoint to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int DetachChildren(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			self.DetachChildren();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetAsFirstSibling(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			self.SetAsFirstSibling();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetAsLastSibling(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			self.SetAsLastSibling();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetSiblingIndex(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			self.SetSiblingIndex(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetSiblingIndex(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			var ret=self.GetSiblingIndex();
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
	static public int Find(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.Find(a1);
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
	static public int IsChildOf(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			UnityEngine.Transform a1;
			checkType(l,2,out a1);
			var ret=self.IsChildOf(a1);
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
	static public int GetChild(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetChild(a1);
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
	static public int get_position(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.position);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_position(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.position=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_localPosition(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.localPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_localPosition(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.localPosition=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_eulerAngles(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.eulerAngles);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_eulerAngles(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.eulerAngles=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_localEulerAngles(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.localEulerAngles);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_localEulerAngles(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.localEulerAngles=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_right(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.right);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_right(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.right=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_up(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.up);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_up(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.up=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_forward(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.forward);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_forward(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.forward=v;
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
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
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
	static public int set_rotation(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			UnityEngine.Quaternion v;
			checkType(l,2,out v);
			self.rotation=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_localRotation(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.localRotation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_localRotation(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			UnityEngine.Quaternion v;
			checkType(l,2,out v);
			self.localRotation=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_localScale(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.localScale);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_localScale(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.localScale=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_parent(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.parent);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_parent(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			UnityEngine.Transform v;
			checkType(l,2,out v);
			self.parent=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_worldToLocalMatrix(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.worldToLocalMatrix);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_localToWorldMatrix(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.localToWorldMatrix);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_root(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.root);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_childCount(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.childCount);
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
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
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
	static public int get_hasChanged(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.hasChanged);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_hasChanged(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.hasChanged=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_hierarchyCapacity(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.hierarchyCapacity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_hierarchyCapacity(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.hierarchyCapacity=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_hierarchyCount(IntPtr l) {
		try {
			UnityEngine.Transform self=(UnityEngine.Transform)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.hierarchyCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Transform");
		addMember(l,SetParent);
		addMember(l,SetPositionAndRotation);
		addMember(l,Translate);
		addMember(l,Rotate);
		addMember(l,RotateAround);
		addMember(l,LookAt);
		addMember(l,TransformDirection);
		addMember(l,InverseTransformDirection);
		addMember(l,TransformVector);
		addMember(l,InverseTransformVector);
		addMember(l,TransformPoint);
		addMember(l,InverseTransformPoint);
		addMember(l,DetachChildren);
		addMember(l,SetAsFirstSibling);
		addMember(l,SetAsLastSibling);
		addMember(l,SetSiblingIndex);
		addMember(l,GetSiblingIndex);
		addMember(l,Find);
		addMember(l,IsChildOf);
		addMember(l,GetChild);
		addMember(l,"position",get_position,set_position,true);
		addMember(l,"localPosition",get_localPosition,set_localPosition,true);
		addMember(l,"eulerAngles",get_eulerAngles,set_eulerAngles,true);
		addMember(l,"localEulerAngles",get_localEulerAngles,set_localEulerAngles,true);
		addMember(l,"right",get_right,set_right,true);
		addMember(l,"up",get_up,set_up,true);
		addMember(l,"forward",get_forward,set_forward,true);
		addMember(l,"rotation",get_rotation,set_rotation,true);
		addMember(l,"localRotation",get_localRotation,set_localRotation,true);
		addMember(l,"localScale",get_localScale,set_localScale,true);
		addMember(l,"parent",get_parent,set_parent,true);
		addMember(l,"worldToLocalMatrix",get_worldToLocalMatrix,null,true);
		addMember(l,"localToWorldMatrix",get_localToWorldMatrix,null,true);
		addMember(l,"root",get_root,null,true);
		addMember(l,"childCount",get_childCount,null,true);
		addMember(l,"lossyScale",get_lossyScale,null,true);
		addMember(l,"hasChanged",get_hasChanged,set_hasChanged,true);
		addMember(l,"hierarchyCapacity",get_hierarchyCapacity,set_hierarchyCapacity,true);
		addMember(l,"hierarchyCount",get_hierarchyCount,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.Transform),typeof(UnityEngine.Component));
	}
}
