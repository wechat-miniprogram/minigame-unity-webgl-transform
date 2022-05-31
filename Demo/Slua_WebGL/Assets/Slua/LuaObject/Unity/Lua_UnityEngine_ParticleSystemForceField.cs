using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystemForceField : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_shape(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.shape);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_shape(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			UnityEngine.ParticleSystemForceFieldShape v;
			v = (UnityEngine.ParticleSystemForceFieldShape)LuaDLL.luaL_checkinteger(l, 2);
			self.shape=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_startRange(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.startRange);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startRange(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.startRange=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_endRange(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.endRange);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_endRange(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.endRange=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_length(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.length);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_length(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.length=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_gravityFocus(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.gravityFocus);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_gravityFocus(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.gravityFocus=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_rotationRandomness(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.rotationRandomness);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_rotationRandomness(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.rotationRandomness=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_multiplyDragByParticleSize(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.multiplyDragByParticleSize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_multiplyDragByParticleSize(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.multiplyDragByParticleSize=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_multiplyDragByParticleVelocity(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.multiplyDragByParticleVelocity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_multiplyDragByParticleVelocity(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.multiplyDragByParticleVelocity=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_vectorField(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.vectorField);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_vectorField(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			UnityEngine.Texture3D v;
			checkType(l,2,out v);
			self.vectorField=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_directionX(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.directionX);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_directionX(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.directionX=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_directionY(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.directionY);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_directionY(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.directionY=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_directionZ(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.directionZ);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_directionZ(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.directionZ=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_gravity(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.gravity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_gravity(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.gravity=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_rotationSpeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.rotationSpeed);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_rotationSpeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.rotationSpeed=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_rotationAttraction(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.rotationAttraction);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_rotationAttraction(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.rotationAttraction=v;
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
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
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
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
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
	static public int get_vectorFieldSpeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.vectorFieldSpeed);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_vectorFieldSpeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.vectorFieldSpeed=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_vectorFieldAttraction(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.vectorFieldAttraction);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_vectorFieldAttraction(IntPtr l) {
		try {
			UnityEngine.ParticleSystemForceField self=(UnityEngine.ParticleSystemForceField)checkSelf(l);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.vectorFieldAttraction=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.ParticleSystemForceField");
		addMember(l,"shape",get_shape,set_shape,true);
		addMember(l,"startRange",get_startRange,set_startRange,true);
		addMember(l,"endRange",get_endRange,set_endRange,true);
		addMember(l,"length",get_length,set_length,true);
		addMember(l,"gravityFocus",get_gravityFocus,set_gravityFocus,true);
		addMember(l,"rotationRandomness",get_rotationRandomness,set_rotationRandomness,true);
		addMember(l,"multiplyDragByParticleSize",get_multiplyDragByParticleSize,set_multiplyDragByParticleSize,true);
		addMember(l,"multiplyDragByParticleVelocity",get_multiplyDragByParticleVelocity,set_multiplyDragByParticleVelocity,true);
		addMember(l,"vectorField",get_vectorField,set_vectorField,true);
		addMember(l,"directionX",get_directionX,set_directionX,true);
		addMember(l,"directionY",get_directionY,set_directionY,true);
		addMember(l,"directionZ",get_directionZ,set_directionZ,true);
		addMember(l,"gravity",get_gravity,set_gravity,true);
		addMember(l,"rotationSpeed",get_rotationSpeed,set_rotationSpeed,true);
		addMember(l,"rotationAttraction",get_rotationAttraction,set_rotationAttraction,true);
		addMember(l,"drag",get_drag,set_drag,true);
		addMember(l,"vectorFieldSpeed",get_vectorFieldSpeed,set_vectorFieldSpeed,true);
		addMember(l,"vectorFieldAttraction",get_vectorFieldAttraction,set_vectorFieldAttraction,true);
		createTypeMetatable(l,null, typeof(UnityEngine.ParticleSystemForceField),typeof(UnityEngine.Behaviour));
	}
}
