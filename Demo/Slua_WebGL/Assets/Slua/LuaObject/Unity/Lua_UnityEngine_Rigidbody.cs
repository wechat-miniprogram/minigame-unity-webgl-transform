using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Rigidbody : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetDensity(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			self.SetDensity(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int MovePosition(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			self.MovePosition(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int MoveRotation(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			UnityEngine.Quaternion a1;
			checkType(l,2,out a1);
			self.MoveRotation(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Sleep(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			self.Sleep();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int IsSleeping(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			var ret=self.IsSleeping();
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
	static public int WakeUp(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			self.WakeUp();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ResetCenterOfMass(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			self.ResetCenterOfMass();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ResetInertiaTensor(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			self.ResetInertiaTensor();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetRelativePointVelocity(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			var ret=self.GetRelativePointVelocity(a1);
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
	static public int GetPointVelocity(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			var ret=self.GetPointVelocity(a1);
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
	static public int AddForce(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				self.AddForce(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.ForceMode a2;
				a2 = (UnityEngine.ForceMode)LuaDLL.luaL_checkinteger(l, 3);
				self.AddForce(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				self.AddForce(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				UnityEngine.ForceMode a4;
				a4 = (UnityEngine.ForceMode)LuaDLL.luaL_checkinteger(l, 5);
				self.AddForce(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function AddForce to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AddRelativeForce(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				self.AddRelativeForce(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.ForceMode a2;
				a2 = (UnityEngine.ForceMode)LuaDLL.luaL_checkinteger(l, 3);
				self.AddRelativeForce(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				self.AddRelativeForce(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				UnityEngine.ForceMode a4;
				a4 = (UnityEngine.ForceMode)LuaDLL.luaL_checkinteger(l, 5);
				self.AddRelativeForce(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function AddRelativeForce to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AddTorque(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				self.AddTorque(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.ForceMode a2;
				a2 = (UnityEngine.ForceMode)LuaDLL.luaL_checkinteger(l, 3);
				self.AddTorque(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				self.AddTorque(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				UnityEngine.ForceMode a4;
				a4 = (UnityEngine.ForceMode)LuaDLL.luaL_checkinteger(l, 5);
				self.AddTorque(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function AddTorque to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AddRelativeTorque(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				self.AddRelativeTorque(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.ForceMode a2;
				a2 = (UnityEngine.ForceMode)LuaDLL.luaL_checkinteger(l, 3);
				self.AddRelativeTorque(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				self.AddRelativeTorque(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				UnityEngine.ForceMode a4;
				a4 = (UnityEngine.ForceMode)LuaDLL.luaL_checkinteger(l, 5);
				self.AddRelativeTorque(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function AddRelativeTorque to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AddForceAtPosition(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,3,out a2);
				self.AddForceAtPosition(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,3,out a2);
				UnityEngine.ForceMode a3;
				a3 = (UnityEngine.ForceMode)LuaDLL.luaL_checkinteger(l, 4);
				self.AddForceAtPosition(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function AddForceAtPosition to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AddExplosionForce(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==4){
				UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				self.AddExplosionForce(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				System.Single a4;
				checkType(l,5,out a4);
				self.AddExplosionForce(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(argc==6){
				UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				System.Single a4;
				checkType(l,5,out a4);
				UnityEngine.ForceMode a5;
				a5 = (UnityEngine.ForceMode)LuaDLL.luaL_checkinteger(l, 6);
				self.AddExplosionForce(a1,a2,a3,a4,a5);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function AddExplosionForce to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ClosestPointOnBounds(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			var ret=self.ClosestPointOnBounds(a1);
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
	static public int SweepTest(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.RaycastHit a2;
				var ret=self.SweepTest(a1,out a2);
				pushValue(l,true);
				pushValue(l,ret);
				pushValue(l,a2);
				return 3;
			}
			else if(argc==4){
				UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.RaycastHit a2;
				System.Single a3;
				checkType(l,4,out a3);
				var ret=self.SweepTest(a1,out a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				pushValue(l,a2);
				return 3;
			}
			else if(argc==5){
				UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.RaycastHit a2;
				System.Single a3;
				checkType(l,4,out a3);
				UnityEngine.QueryTriggerInteraction a4;
				a4 = (UnityEngine.QueryTriggerInteraction)LuaDLL.luaL_checkinteger(l, 5);
				var ret=self.SweepTest(a1,out a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				pushValue(l,a2);
				return 3;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SweepTest to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SweepTestAll(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				var ret=self.SweepTestAll(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==3){
				UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				var ret=self.SweepTestAll(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==4){
				UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				UnityEngine.QueryTriggerInteraction a3;
				a3 = (UnityEngine.QueryTriggerInteraction)LuaDLL.luaL_checkinteger(l, 4);
				var ret=self.SweepTestAll(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SweepTestAll to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_velocity(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.velocity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_velocity(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.velocity=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_angularVelocity(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.angularVelocity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_angularVelocity(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.angularVelocity=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_drag(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.drag);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_drag(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.drag=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_angularDrag(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.angularDrag);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_angularDrag(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.angularDrag=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_mass(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.mass);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_mass(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.mass=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_useGravity(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.useGravity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_useGravity(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.useGravity=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maxDepenetrationVelocity(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.maxDepenetrationVelocity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_maxDepenetrationVelocity(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.maxDepenetrationVelocity=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isKinematic(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isKinematic);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_isKinematic(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.isKinematic=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_freezeRotation(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.freezeRotation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_freezeRotation(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.freezeRotation=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_constraints(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.constraints);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_constraints(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			UnityEngine.RigidbodyConstraints v;
			v = (UnityEngine.RigidbodyConstraints)LuaDLL.luaL_checkinteger(l, 2);
			self.constraints=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_collisionDetectionMode(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.collisionDetectionMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_collisionDetectionMode(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			UnityEngine.CollisionDetectionMode v;
			v = (UnityEngine.CollisionDetectionMode)LuaDLL.luaL_checkinteger(l, 2);
			self.collisionDetectionMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_centerOfMass(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.centerOfMass);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_centerOfMass(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.centerOfMass=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_worldCenterOfMass(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.worldCenterOfMass);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_inertiaTensorRotation(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.inertiaTensorRotation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_inertiaTensorRotation(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			UnityEngine.Quaternion v;
			checkType(l,2,out v);
			self.inertiaTensorRotation=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_inertiaTensor(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.inertiaTensor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_inertiaTensor(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.inertiaTensor=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_detectCollisions(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.detectCollisions);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_detectCollisions(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.detectCollisions=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_position(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
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
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
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
	static public int get_rotation(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
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
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
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
	static public int get_interpolation(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.interpolation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_interpolation(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			UnityEngine.RigidbodyInterpolation v;
			v = (UnityEngine.RigidbodyInterpolation)LuaDLL.luaL_checkinteger(l, 2);
			self.interpolation=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_solverIterations(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.solverIterations);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_solverIterations(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.solverIterations=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_sleepThreshold(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.sleepThreshold);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_sleepThreshold(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.sleepThreshold=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maxAngularVelocity(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.maxAngularVelocity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_maxAngularVelocity(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.maxAngularVelocity=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_solverVelocityIterations(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.solverVelocityIterations);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_solverVelocityIterations(IntPtr l) {
		try {
			UnityEngine.Rigidbody self=(UnityEngine.Rigidbody)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.solverVelocityIterations=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Rigidbody");
		addMember(l,SetDensity);
		addMember(l,MovePosition);
		addMember(l,MoveRotation);
		addMember(l,Sleep);
		addMember(l,IsSleeping);
		addMember(l,WakeUp);
		addMember(l,ResetCenterOfMass);
		addMember(l,ResetInertiaTensor);
		addMember(l,GetRelativePointVelocity);
		addMember(l,GetPointVelocity);
		addMember(l,AddForce);
		addMember(l,AddRelativeForce);
		addMember(l,AddTorque);
		addMember(l,AddRelativeTorque);
		addMember(l,AddForceAtPosition);
		addMember(l,AddExplosionForce);
		addMember(l,ClosestPointOnBounds);
		addMember(l,SweepTest);
		addMember(l,SweepTestAll);
		addMember(l,"velocity",get_velocity,set_velocity,true);
		addMember(l,"angularVelocity",get_angularVelocity,set_angularVelocity,true);
		addMember(l,"drag",get_drag,set_drag,true);
		addMember(l,"angularDrag",get_angularDrag,set_angularDrag,true);
		addMember(l,"mass",get_mass,set_mass,true);
		addMember(l,"useGravity",get_useGravity,set_useGravity,true);
		addMember(l,"maxDepenetrationVelocity",get_maxDepenetrationVelocity,set_maxDepenetrationVelocity,true);
		addMember(l,"isKinematic",get_isKinematic,set_isKinematic,true);
		addMember(l,"freezeRotation",get_freezeRotation,set_freezeRotation,true);
		addMember(l,"constraints",get_constraints,set_constraints,true);
		addMember(l,"collisionDetectionMode",get_collisionDetectionMode,set_collisionDetectionMode,true);
		addMember(l,"centerOfMass",get_centerOfMass,set_centerOfMass,true);
		addMember(l,"worldCenterOfMass",get_worldCenterOfMass,null,true);
		addMember(l,"inertiaTensorRotation",get_inertiaTensorRotation,set_inertiaTensorRotation,true);
		addMember(l,"inertiaTensor",get_inertiaTensor,set_inertiaTensor,true);
		addMember(l,"detectCollisions",get_detectCollisions,set_detectCollisions,true);
		addMember(l,"position",get_position,set_position,true);
		addMember(l,"rotation",get_rotation,set_rotation,true);
		addMember(l,"interpolation",get_interpolation,set_interpolation,true);
		addMember(l,"solverIterations",get_solverIterations,set_solverIterations,true);
		addMember(l,"sleepThreshold",get_sleepThreshold,set_sleepThreshold,true);
		addMember(l,"maxAngularVelocity",get_maxAngularVelocity,set_maxAngularVelocity,true);
		addMember(l,"solverVelocityIterations",get_solverVelocityIterations,set_solverVelocityIterations,true);
		createTypeMetatable(l,null, typeof(UnityEngine.Rigidbody),typeof(UnityEngine.Component));
	}
}
