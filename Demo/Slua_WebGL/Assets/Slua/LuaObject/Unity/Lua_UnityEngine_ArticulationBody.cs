using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ArticulationBody : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AddForce(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				self.AddForce(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.ForceMode a2;
				a2 = (UnityEngine.ForceMode)LuaDLL.luaL_checkinteger(l, 3);
				self.AddForce(a1,a2);
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
				UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				self.AddRelativeForce(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.ForceMode a2;
				a2 = (UnityEngine.ForceMode)LuaDLL.luaL_checkinteger(l, 3);
				self.AddRelativeForce(a1,a2);
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
				UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				self.AddTorque(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.ForceMode a2;
				a2 = (UnityEngine.ForceMode)LuaDLL.luaL_checkinteger(l, 3);
				self.AddTorque(a1,a2);
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
				UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				self.AddRelativeTorque(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.ForceMode a2;
				a2 = (UnityEngine.ForceMode)LuaDLL.luaL_checkinteger(l, 3);
				self.AddRelativeTorque(a1,a2);
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
				UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,3,out a2);
				self.AddForceAtPosition(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(argc==4){
				UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
	static public int ResetCenterOfMass(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
	static public int Sleep(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
	static public int TeleportRoot(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			UnityEngine.Quaternion a2;
			checkType(l,3,out a2);
			self.TeleportRoot(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetClosestPoint(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			var ret=self.GetClosestPoint(a1);
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
	static public int GetRelativePointVelocity(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
	static public int GetDenseJacobian(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			UnityEngine.ArticulationJacobian a1;
			checkValueType(l,2,out a1);
			var ret=self.GetDenseJacobian(ref a1);
			pushValue(l,true);
			pushValue(l,ret);
			pushValue(l,a1);
			return 3;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetJointPositions(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			System.Collections.Generic.List<System.Single> a1;
			checkType(l,2,out a1);
			var ret=self.GetJointPositions(a1);
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
	static public int SetJointPositions(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			System.Collections.Generic.List<System.Single> a1;
			checkType(l,2,out a1);
			self.SetJointPositions(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetJointVelocities(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			System.Collections.Generic.List<System.Single> a1;
			checkType(l,2,out a1);
			var ret=self.GetJointVelocities(a1);
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
	static public int SetJointVelocities(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			System.Collections.Generic.List<System.Single> a1;
			checkType(l,2,out a1);
			self.SetJointVelocities(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetJointAccelerations(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			System.Collections.Generic.List<System.Single> a1;
			checkType(l,2,out a1);
			var ret=self.GetJointAccelerations(a1);
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
	static public int SetJointAccelerations(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			System.Collections.Generic.List<System.Single> a1;
			checkType(l,2,out a1);
			self.SetJointAccelerations(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetJointForces(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			System.Collections.Generic.List<System.Single> a1;
			checkType(l,2,out a1);
			var ret=self.GetJointForces(a1);
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
	static public int SetJointForces(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			System.Collections.Generic.List<System.Single> a1;
			checkType(l,2,out a1);
			self.SetJointForces(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetDriveTargets(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			System.Collections.Generic.List<System.Single> a1;
			checkType(l,2,out a1);
			var ret=self.GetDriveTargets(a1);
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
	static public int SetDriveTargets(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			System.Collections.Generic.List<System.Single> a1;
			checkType(l,2,out a1);
			self.SetDriveTargets(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetDriveTargetVelocities(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			System.Collections.Generic.List<System.Single> a1;
			checkType(l,2,out a1);
			var ret=self.GetDriveTargetVelocities(a1);
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
	static public int SetDriveTargetVelocities(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			System.Collections.Generic.List<System.Single> a1;
			checkType(l,2,out a1);
			self.SetDriveTargetVelocities(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetDofStartIndices(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			System.Collections.Generic.List<System.Int32> a1;
			checkType(l,2,out a1);
			var ret=self.GetDofStartIndices(a1);
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
	static public int SnapAnchorToClosestContact(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			self.SnapAnchorToClosestContact();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_jointType(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.jointType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_jointType(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			UnityEngine.ArticulationJointType v;
			v = (UnityEngine.ArticulationJointType)LuaDLL.luaL_checkinteger(l, 2);
			self.jointType=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_anchorPosition(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.anchorPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_anchorPosition(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.anchorPosition=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_parentAnchorPosition(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.parentAnchorPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_parentAnchorPosition(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.parentAnchorPosition=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_anchorRotation(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.anchorRotation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_anchorRotation(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			UnityEngine.Quaternion v;
			checkType(l,2,out v);
			self.anchorRotation=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_parentAnchorRotation(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.parentAnchorRotation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_parentAnchorRotation(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			UnityEngine.Quaternion v;
			checkType(l,2,out v);
			self.parentAnchorRotation=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isRoot(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isRoot);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_matchAnchors(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.matchAnchors);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_matchAnchors(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.matchAnchors=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_linearLockX(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.linearLockX);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_linearLockX(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			UnityEngine.ArticulationDofLock v;
			v = (UnityEngine.ArticulationDofLock)LuaDLL.luaL_checkinteger(l, 2);
			self.linearLockX=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_linearLockY(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.linearLockY);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_linearLockY(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			UnityEngine.ArticulationDofLock v;
			v = (UnityEngine.ArticulationDofLock)LuaDLL.luaL_checkinteger(l, 2);
			self.linearLockY=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_linearLockZ(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.linearLockZ);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_linearLockZ(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			UnityEngine.ArticulationDofLock v;
			v = (UnityEngine.ArticulationDofLock)LuaDLL.luaL_checkinteger(l, 2);
			self.linearLockZ=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_swingYLock(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.swingYLock);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_swingYLock(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			UnityEngine.ArticulationDofLock v;
			v = (UnityEngine.ArticulationDofLock)LuaDLL.luaL_checkinteger(l, 2);
			self.swingYLock=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_swingZLock(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.swingZLock);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_swingZLock(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			UnityEngine.ArticulationDofLock v;
			v = (UnityEngine.ArticulationDofLock)LuaDLL.luaL_checkinteger(l, 2);
			self.swingZLock=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_twistLock(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.twistLock);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_twistLock(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			UnityEngine.ArticulationDofLock v;
			v = (UnityEngine.ArticulationDofLock)LuaDLL.luaL_checkinteger(l, 2);
			self.twistLock=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_xDrive(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.xDrive);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_xDrive(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			UnityEngine.ArticulationDrive v;
			checkValueType(l,2,out v);
			self.xDrive=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_yDrive(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.yDrive);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_yDrive(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			UnityEngine.ArticulationDrive v;
			checkValueType(l,2,out v);
			self.yDrive=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_zDrive(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.zDrive);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_zDrive(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			UnityEngine.ArticulationDrive v;
			checkValueType(l,2,out v);
			self.zDrive=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_immovable(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.immovable);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_immovable(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.immovable=v;
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
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
	static public int get_linearDamping(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.linearDamping);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_linearDamping(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.linearDamping=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_angularDamping(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.angularDamping);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_angularDamping(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.angularDamping=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_jointFriction(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.jointFriction);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_jointFriction(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.jointFriction=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_velocity(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
	static public int get_mass(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
	static public int get_centerOfMass(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
	static public int get_inertiaTensor(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
	static public int get_inertiaTensorRotation(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
	static public int get_sleepThreshold(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
	static public int get_solverIterations(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
	static public int get_solverVelocityIterations(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maxAngularVelocity(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
	static public int get_maxLinearVelocity(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.maxLinearVelocity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_maxLinearVelocity(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.maxLinearVelocity=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maxJointVelocity(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.maxJointVelocity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_maxJointVelocity(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.maxJointVelocity=v;
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
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
	static public int get_jointPosition(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.jointPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_jointPosition(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			UnityEngine.ArticulationReducedSpace v;
			checkValueType(l,2,out v);
			self.jointPosition=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_jointVelocity(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.jointVelocity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_jointVelocity(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			UnityEngine.ArticulationReducedSpace v;
			checkValueType(l,2,out v);
			self.jointVelocity=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_jointAcceleration(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.jointAcceleration);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_jointAcceleration(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			UnityEngine.ArticulationReducedSpace v;
			checkValueType(l,2,out v);
			self.jointAcceleration=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_jointForce(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.jointForce);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_jointForce(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			UnityEngine.ArticulationReducedSpace v;
			checkValueType(l,2,out v);
			self.jointForce=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_dofCount(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.dofCount);
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
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
	static public int get_collisionDetectionMode(IntPtr l) {
		try {
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
			UnityEngine.ArticulationBody self=(UnityEngine.ArticulationBody)checkSelf(l);
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
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.ArticulationBody");
		addMember(l,AddForce);
		addMember(l,AddRelativeForce);
		addMember(l,AddTorque);
		addMember(l,AddRelativeTorque);
		addMember(l,AddForceAtPosition);
		addMember(l,ResetCenterOfMass);
		addMember(l,ResetInertiaTensor);
		addMember(l,Sleep);
		addMember(l,IsSleeping);
		addMember(l,WakeUp);
		addMember(l,TeleportRoot);
		addMember(l,GetClosestPoint);
		addMember(l,GetRelativePointVelocity);
		addMember(l,GetPointVelocity);
		addMember(l,GetDenseJacobian);
		addMember(l,GetJointPositions);
		addMember(l,SetJointPositions);
		addMember(l,GetJointVelocities);
		addMember(l,SetJointVelocities);
		addMember(l,GetJointAccelerations);
		addMember(l,SetJointAccelerations);
		addMember(l,GetJointForces);
		addMember(l,SetJointForces);
		addMember(l,GetDriveTargets);
		addMember(l,SetDriveTargets);
		addMember(l,GetDriveTargetVelocities);
		addMember(l,SetDriveTargetVelocities);
		addMember(l,GetDofStartIndices);
		addMember(l,SnapAnchorToClosestContact);
		addMember(l,"jointType",get_jointType,set_jointType,true);
		addMember(l,"anchorPosition",get_anchorPosition,set_anchorPosition,true);
		addMember(l,"parentAnchorPosition",get_parentAnchorPosition,set_parentAnchorPosition,true);
		addMember(l,"anchorRotation",get_anchorRotation,set_anchorRotation,true);
		addMember(l,"parentAnchorRotation",get_parentAnchorRotation,set_parentAnchorRotation,true);
		addMember(l,"isRoot",get_isRoot,null,true);
		addMember(l,"matchAnchors",get_matchAnchors,set_matchAnchors,true);
		addMember(l,"linearLockX",get_linearLockX,set_linearLockX,true);
		addMember(l,"linearLockY",get_linearLockY,set_linearLockY,true);
		addMember(l,"linearLockZ",get_linearLockZ,set_linearLockZ,true);
		addMember(l,"swingYLock",get_swingYLock,set_swingYLock,true);
		addMember(l,"swingZLock",get_swingZLock,set_swingZLock,true);
		addMember(l,"twistLock",get_twistLock,set_twistLock,true);
		addMember(l,"xDrive",get_xDrive,set_xDrive,true);
		addMember(l,"yDrive",get_yDrive,set_yDrive,true);
		addMember(l,"zDrive",get_zDrive,set_zDrive,true);
		addMember(l,"immovable",get_immovable,set_immovable,true);
		addMember(l,"useGravity",get_useGravity,set_useGravity,true);
		addMember(l,"linearDamping",get_linearDamping,set_linearDamping,true);
		addMember(l,"angularDamping",get_angularDamping,set_angularDamping,true);
		addMember(l,"jointFriction",get_jointFriction,set_jointFriction,true);
		addMember(l,"velocity",get_velocity,set_velocity,true);
		addMember(l,"angularVelocity",get_angularVelocity,set_angularVelocity,true);
		addMember(l,"mass",get_mass,set_mass,true);
		addMember(l,"centerOfMass",get_centerOfMass,set_centerOfMass,true);
		addMember(l,"worldCenterOfMass",get_worldCenterOfMass,null,true);
		addMember(l,"inertiaTensor",get_inertiaTensor,set_inertiaTensor,true);
		addMember(l,"inertiaTensorRotation",get_inertiaTensorRotation,set_inertiaTensorRotation,true);
		addMember(l,"sleepThreshold",get_sleepThreshold,set_sleepThreshold,true);
		addMember(l,"solverIterations",get_solverIterations,set_solverIterations,true);
		addMember(l,"solverVelocityIterations",get_solverVelocityIterations,set_solverVelocityIterations,true);
		addMember(l,"maxAngularVelocity",get_maxAngularVelocity,set_maxAngularVelocity,true);
		addMember(l,"maxLinearVelocity",get_maxLinearVelocity,set_maxLinearVelocity,true);
		addMember(l,"maxJointVelocity",get_maxJointVelocity,set_maxJointVelocity,true);
		addMember(l,"maxDepenetrationVelocity",get_maxDepenetrationVelocity,set_maxDepenetrationVelocity,true);
		addMember(l,"jointPosition",get_jointPosition,set_jointPosition,true);
		addMember(l,"jointVelocity",get_jointVelocity,set_jointVelocity,true);
		addMember(l,"jointAcceleration",get_jointAcceleration,set_jointAcceleration,true);
		addMember(l,"jointForce",get_jointForce,set_jointForce,true);
		addMember(l,"dofCount",get_dofCount,null,true);
		addMember(l,"index",get_index,null,true);
		addMember(l,"collisionDetectionMode",get_collisionDetectionMode,set_collisionDetectionMode,true);
		createTypeMetatable(l,null, typeof(UnityEngine.ArticulationBody),typeof(UnityEngine.Behaviour));
	}
}
