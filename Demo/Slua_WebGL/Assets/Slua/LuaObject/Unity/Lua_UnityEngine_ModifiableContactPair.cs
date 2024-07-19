using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ModifiableContactPair : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair o;
			o=new UnityEngine.ModifiableContactPair();
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
	static public int GetPoint(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetPoint(a1);
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
	static public int SetPoint(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			self.SetPoint(a1,a2);
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
	static public int GetNormal(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetNormal(a1);
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
	static public int SetNormal(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			self.SetNormal(a1,a2);
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
	static public int GetSeparation(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetSeparation(a1);
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
	static public int SetSeparation(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			self.SetSeparation(a1,a2);
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
	static public int GetTargetVelocity(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetTargetVelocity(a1);
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
	static public int SetTargetVelocity(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			self.SetTargetVelocity(a1,a2);
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
	static public int GetBounciness(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetBounciness(a1);
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
	static public int SetBounciness(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			self.SetBounciness(a1,a2);
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
	static public int GetStaticFriction(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetStaticFriction(a1);
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
	static public int SetStaticFriction(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			self.SetStaticFriction(a1,a2);
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
	static public int GetDynamicFriction(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetDynamicFriction(a1);
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
	static public int SetDynamicFriction(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			self.SetDynamicFriction(a1,a2);
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
	static public int GetMaxImpulse(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetMaxImpulse(a1);
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
	static public int SetMaxImpulse(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			self.SetMaxImpulse(a1,a2);
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
	static public int IgnoreContact(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			self.IgnoreContact(a1);
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
	static public int GetFaceIndex(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetFaceIndex(a1);
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
	static public int get_rotation(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
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
	static public int set_rotation(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			UnityEngine.Quaternion v;
			checkType(l,2,out v);
			self.rotation=v;
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
	static public int get_position(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
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
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.position=v;
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
	static public int get_otherRotation(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.otherRotation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_otherRotation(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			UnityEngine.Quaternion v;
			checkType(l,2,out v);
			self.otherRotation=v;
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
	static public int get_otherPosition(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.otherPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_otherPosition(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.otherPosition=v;
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
	static public int get_colliderInstanceID(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.colliderInstanceID);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_otherColliderInstanceID(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.otherColliderInstanceID);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_bodyInstanceID(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.bodyInstanceID);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_otherBodyInstanceID(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.otherBodyInstanceID);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_contactCount(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.contactCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_massProperties(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.massProperties);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_massProperties(IntPtr l) {
		try {
			UnityEngine.ModifiableContactPair self;
			checkValueType(l,1,out self);
			UnityEngine.ModifiableMassProperties v;
			checkValueType(l,2,out v);
			self.massProperties=v;
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
		getTypeTable(l,"UnityEngine.ModifiableContactPair");
		addMember(l,GetPoint);
		addMember(l,SetPoint);
		addMember(l,GetNormal);
		addMember(l,SetNormal);
		addMember(l,GetSeparation);
		addMember(l,SetSeparation);
		addMember(l,GetTargetVelocity);
		addMember(l,SetTargetVelocity);
		addMember(l,GetBounciness);
		addMember(l,SetBounciness);
		addMember(l,GetStaticFriction);
		addMember(l,SetStaticFriction);
		addMember(l,GetDynamicFriction);
		addMember(l,SetDynamicFriction);
		addMember(l,GetMaxImpulse);
		addMember(l,SetMaxImpulse);
		addMember(l,IgnoreContact);
		addMember(l,GetFaceIndex);
		addMember(l,"rotation",get_rotation,set_rotation,true);
		addMember(l,"position",get_position,set_position,true);
		addMember(l,"otherRotation",get_otherRotation,set_otherRotation,true);
		addMember(l,"otherPosition",get_otherPosition,set_otherPosition,true);
		addMember(l,"colliderInstanceID",get_colliderInstanceID,null,true);
		addMember(l,"otherColliderInstanceID",get_otherColliderInstanceID,null,true);
		addMember(l,"bodyInstanceID",get_bodyInstanceID,null,true);
		addMember(l,"otherBodyInstanceID",get_otherBodyInstanceID,null,true);
		addMember(l,"contactCount",get_contactCount,null,true);
		addMember(l,"massProperties",get_massProperties,set_massProperties,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ModifiableContactPair),typeof(System.ValueType));
	}
}
