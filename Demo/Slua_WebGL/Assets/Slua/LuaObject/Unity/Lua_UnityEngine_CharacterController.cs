using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_CharacterController : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SimpleMove(IntPtr l) {
		try {
			UnityEngine.CharacterController self=(UnityEngine.CharacterController)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			var ret=self.SimpleMove(a1);
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
	static public int Move(IntPtr l) {
		try {
			UnityEngine.CharacterController self=(UnityEngine.CharacterController)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			var ret=self.Move(a1);
			pushValue(l,true);
			pushEnum(l,(int)ret);
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
			UnityEngine.CharacterController self=(UnityEngine.CharacterController)checkSelf(l);
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
	static public int get_isGrounded(IntPtr l) {
		try {
			UnityEngine.CharacterController self=(UnityEngine.CharacterController)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isGrounded);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_collisionFlags(IntPtr l) {
		try {
			UnityEngine.CharacterController self=(UnityEngine.CharacterController)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.collisionFlags);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_radius(IntPtr l) {
		try {
			UnityEngine.CharacterController self=(UnityEngine.CharacterController)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.radius);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_radius(IntPtr l) {
		try {
			UnityEngine.CharacterController self=(UnityEngine.CharacterController)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.radius=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_height(IntPtr l) {
		try {
			UnityEngine.CharacterController self=(UnityEngine.CharacterController)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.height);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_height(IntPtr l) {
		try {
			UnityEngine.CharacterController self=(UnityEngine.CharacterController)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.height=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_center(IntPtr l) {
		try {
			UnityEngine.CharacterController self=(UnityEngine.CharacterController)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.center);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_center(IntPtr l) {
		try {
			UnityEngine.CharacterController self=(UnityEngine.CharacterController)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.center=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_slopeLimit(IntPtr l) {
		try {
			UnityEngine.CharacterController self=(UnityEngine.CharacterController)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.slopeLimit);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_slopeLimit(IntPtr l) {
		try {
			UnityEngine.CharacterController self=(UnityEngine.CharacterController)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.slopeLimit=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_stepOffset(IntPtr l) {
		try {
			UnityEngine.CharacterController self=(UnityEngine.CharacterController)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.stepOffset);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_stepOffset(IntPtr l) {
		try {
			UnityEngine.CharacterController self=(UnityEngine.CharacterController)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.stepOffset=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_skinWidth(IntPtr l) {
		try {
			UnityEngine.CharacterController self=(UnityEngine.CharacterController)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.skinWidth);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_skinWidth(IntPtr l) {
		try {
			UnityEngine.CharacterController self=(UnityEngine.CharacterController)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.skinWidth=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_minMoveDistance(IntPtr l) {
		try {
			UnityEngine.CharacterController self=(UnityEngine.CharacterController)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.minMoveDistance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_minMoveDistance(IntPtr l) {
		try {
			UnityEngine.CharacterController self=(UnityEngine.CharacterController)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.minMoveDistance=v;
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
			UnityEngine.CharacterController self=(UnityEngine.CharacterController)checkSelf(l);
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
			UnityEngine.CharacterController self=(UnityEngine.CharacterController)checkSelf(l);
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
	static public int get_enableOverlapRecovery(IntPtr l) {
		try {
			UnityEngine.CharacterController self=(UnityEngine.CharacterController)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.enableOverlapRecovery);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_enableOverlapRecovery(IntPtr l) {
		try {
			UnityEngine.CharacterController self=(UnityEngine.CharacterController)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.enableOverlapRecovery=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.CharacterController");
		addMember(l,SimpleMove);
		addMember(l,Move);
		addMember(l,"velocity",get_velocity,null,true);
		addMember(l,"isGrounded",get_isGrounded,null,true);
		addMember(l,"collisionFlags",get_collisionFlags,null,true);
		addMember(l,"radius",get_radius,set_radius,true);
		addMember(l,"height",get_height,set_height,true);
		addMember(l,"center",get_center,set_center,true);
		addMember(l,"slopeLimit",get_slopeLimit,set_slopeLimit,true);
		addMember(l,"stepOffset",get_stepOffset,set_stepOffset,true);
		addMember(l,"skinWidth",get_skinWidth,set_skinWidth,true);
		addMember(l,"minMoveDistance",get_minMoveDistance,set_minMoveDistance,true);
		addMember(l,"detectCollisions",get_detectCollisions,set_detectCollisions,true);
		addMember(l,"enableOverlapRecovery",get_enableOverlapRecovery,set_enableOverlapRecovery,true);
		createTypeMetatable(l,null, typeof(UnityEngine.CharacterController),typeof(UnityEngine.Collider));
	}
}
