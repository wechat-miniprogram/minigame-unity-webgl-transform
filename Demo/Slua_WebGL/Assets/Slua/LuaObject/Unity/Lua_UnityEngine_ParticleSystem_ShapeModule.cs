using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystem_ShapeModule : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule o;
			o=new UnityEngine.ParticleSystem.ShapeModule();
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
	static public int get_enabled(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.enabled);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_enabled(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.enabled=v;
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
	static public int get_shapeType(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.shapeType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_shapeType(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemShapeType v;
			v = (UnityEngine.ParticleSystemShapeType)LuaDLL.luaL_checkinteger(l, 2);
			self.shapeType=v;
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
	static public int get_randomDirectionAmount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.randomDirectionAmount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_randomDirectionAmount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.randomDirectionAmount=v;
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
	static public int get_sphericalDirectionAmount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sphericalDirectionAmount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_sphericalDirectionAmount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.sphericalDirectionAmount=v;
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
	static public int get_randomPositionAmount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.randomPositionAmount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_randomPositionAmount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.randomPositionAmount=v;
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
	static public int get_alignToDirection(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.alignToDirection);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_alignToDirection(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.alignToDirection=v;
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
	static public int get_radius(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
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
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.radius=v;
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
	static public int get_radiusMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.radiusMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_radiusMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemShapeMultiModeValue v;
			v = (UnityEngine.ParticleSystemShapeMultiModeValue)LuaDLL.luaL_checkinteger(l, 2);
			self.radiusMode=v;
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
	static public int get_radiusSpread(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.radiusSpread);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_radiusSpread(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.radiusSpread=v;
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
	static public int get_radiusSpeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.radiusSpeed);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_radiusSpeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.radiusSpeed=v;
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
	static public int get_radiusSpeedMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.radiusSpeedMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_radiusSpeedMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.radiusSpeedMultiplier=v;
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
	static public int get_radiusThickness(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.radiusThickness);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_radiusThickness(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.radiusThickness=v;
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
	static public int get_angle(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.angle);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_angle(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.angle=v;
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
	static public int get_length(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
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
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.length=v;
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
	static public int get_boxThickness(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.boxThickness);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_boxThickness(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.boxThickness=v;
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
	static public int get_meshShapeType(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.meshShapeType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_meshShapeType(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemMeshShapeType v;
			v = (UnityEngine.ParticleSystemMeshShapeType)LuaDLL.luaL_checkinteger(l, 2);
			self.meshShapeType=v;
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
	static public int get_mesh(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.mesh);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_mesh(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			UnityEngine.Mesh v;
			checkType(l,2,out v);
			self.mesh=v;
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
	static public int get_meshRenderer(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.meshRenderer);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_meshRenderer(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			UnityEngine.MeshRenderer v;
			checkType(l,2,out v);
			self.meshRenderer=v;
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
	static public int get_skinnedMeshRenderer(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.skinnedMeshRenderer);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_skinnedMeshRenderer(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			UnityEngine.SkinnedMeshRenderer v;
			checkType(l,2,out v);
			self.skinnedMeshRenderer=v;
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
	static public int get_sprite(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sprite);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_sprite(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			UnityEngine.Sprite v;
			checkType(l,2,out v);
			self.sprite=v;
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
	static public int get_spriteRenderer(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.spriteRenderer);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_spriteRenderer(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			UnityEngine.SpriteRenderer v;
			checkType(l,2,out v);
			self.spriteRenderer=v;
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
	static public int get_useMeshMaterialIndex(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.useMeshMaterialIndex);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_useMeshMaterialIndex(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.useMeshMaterialIndex=v;
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
	static public int get_meshMaterialIndex(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.meshMaterialIndex);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_meshMaterialIndex(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.meshMaterialIndex=v;
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
	static public int get_useMeshColors(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.useMeshColors);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_useMeshColors(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.useMeshColors=v;
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
	static public int get_normalOffset(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.normalOffset);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_normalOffset(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.normalOffset=v;
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
	static public int get_meshSpawnMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.meshSpawnMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_meshSpawnMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemShapeMultiModeValue v;
			v = (UnityEngine.ParticleSystemShapeMultiModeValue)LuaDLL.luaL_checkinteger(l, 2);
			self.meshSpawnMode=v;
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
	static public int get_meshSpawnSpread(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.meshSpawnSpread);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_meshSpawnSpread(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.meshSpawnSpread=v;
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
	static public int get_meshSpawnSpeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.meshSpawnSpeed);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_meshSpawnSpeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.meshSpawnSpeed=v;
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
	static public int get_meshSpawnSpeedMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.meshSpawnSpeedMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_meshSpawnSpeedMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.meshSpawnSpeedMultiplier=v;
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
	static public int get_arc(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.arc);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_arc(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.arc=v;
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
	static public int get_arcMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.arcMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_arcMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemShapeMultiModeValue v;
			v = (UnityEngine.ParticleSystemShapeMultiModeValue)LuaDLL.luaL_checkinteger(l, 2);
			self.arcMode=v;
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
	static public int get_arcSpread(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.arcSpread);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_arcSpread(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.arcSpread=v;
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
	static public int get_arcSpeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.arcSpeed);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_arcSpeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.arcSpeed=v;
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
	static public int get_arcSpeedMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.arcSpeedMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_arcSpeedMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.arcSpeedMultiplier=v;
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
	static public int get_donutRadius(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.donutRadius);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_donutRadius(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.donutRadius=v;
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
			UnityEngine.ParticleSystem.ShapeModule self;
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
			UnityEngine.ParticleSystem.ShapeModule self;
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
	static public int get_rotation(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
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
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
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
	static public int get_scale(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.scale);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_scale(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.scale=v;
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
	static public int get_texture(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.texture);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_texture(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			UnityEngine.Texture2D v;
			checkType(l,2,out v);
			self.texture=v;
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
	static public int get_textureClipChannel(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.textureClipChannel);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_textureClipChannel(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemShapeTextureChannel v;
			v = (UnityEngine.ParticleSystemShapeTextureChannel)LuaDLL.luaL_checkinteger(l, 2);
			self.textureClipChannel=v;
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
	static public int get_textureClipThreshold(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.textureClipThreshold);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_textureClipThreshold(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.textureClipThreshold=v;
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
	static public int get_textureColorAffectsParticles(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.textureColorAffectsParticles);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_textureColorAffectsParticles(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.textureColorAffectsParticles=v;
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
	static public int get_textureAlphaAffectsParticles(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.textureAlphaAffectsParticles);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_textureAlphaAffectsParticles(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.textureAlphaAffectsParticles=v;
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
	static public int get_textureBilinearFiltering(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.textureBilinearFiltering);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_textureBilinearFiltering(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.textureBilinearFiltering=v;
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
	static public int get_textureUVChannel(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.textureUVChannel);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_textureUVChannel(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ShapeModule self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.textureUVChannel=v;
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
		getTypeTable(l,"UnityEngine.ParticleSystem.ShapeModule");
		addMember(l,"enabled",get_enabled,set_enabled,true);
		addMember(l,"shapeType",get_shapeType,set_shapeType,true);
		addMember(l,"randomDirectionAmount",get_randomDirectionAmount,set_randomDirectionAmount,true);
		addMember(l,"sphericalDirectionAmount",get_sphericalDirectionAmount,set_sphericalDirectionAmount,true);
		addMember(l,"randomPositionAmount",get_randomPositionAmount,set_randomPositionAmount,true);
		addMember(l,"alignToDirection",get_alignToDirection,set_alignToDirection,true);
		addMember(l,"radius",get_radius,set_radius,true);
		addMember(l,"radiusMode",get_radiusMode,set_radiusMode,true);
		addMember(l,"radiusSpread",get_radiusSpread,set_radiusSpread,true);
		addMember(l,"radiusSpeed",get_radiusSpeed,set_radiusSpeed,true);
		addMember(l,"radiusSpeedMultiplier",get_radiusSpeedMultiplier,set_radiusSpeedMultiplier,true);
		addMember(l,"radiusThickness",get_radiusThickness,set_radiusThickness,true);
		addMember(l,"angle",get_angle,set_angle,true);
		addMember(l,"length",get_length,set_length,true);
		addMember(l,"boxThickness",get_boxThickness,set_boxThickness,true);
		addMember(l,"meshShapeType",get_meshShapeType,set_meshShapeType,true);
		addMember(l,"mesh",get_mesh,set_mesh,true);
		addMember(l,"meshRenderer",get_meshRenderer,set_meshRenderer,true);
		addMember(l,"skinnedMeshRenderer",get_skinnedMeshRenderer,set_skinnedMeshRenderer,true);
		addMember(l,"sprite",get_sprite,set_sprite,true);
		addMember(l,"spriteRenderer",get_spriteRenderer,set_spriteRenderer,true);
		addMember(l,"useMeshMaterialIndex",get_useMeshMaterialIndex,set_useMeshMaterialIndex,true);
		addMember(l,"meshMaterialIndex",get_meshMaterialIndex,set_meshMaterialIndex,true);
		addMember(l,"useMeshColors",get_useMeshColors,set_useMeshColors,true);
		addMember(l,"normalOffset",get_normalOffset,set_normalOffset,true);
		addMember(l,"meshSpawnMode",get_meshSpawnMode,set_meshSpawnMode,true);
		addMember(l,"meshSpawnSpread",get_meshSpawnSpread,set_meshSpawnSpread,true);
		addMember(l,"meshSpawnSpeed",get_meshSpawnSpeed,set_meshSpawnSpeed,true);
		addMember(l,"meshSpawnSpeedMultiplier",get_meshSpawnSpeedMultiplier,set_meshSpawnSpeedMultiplier,true);
		addMember(l,"arc",get_arc,set_arc,true);
		addMember(l,"arcMode",get_arcMode,set_arcMode,true);
		addMember(l,"arcSpread",get_arcSpread,set_arcSpread,true);
		addMember(l,"arcSpeed",get_arcSpeed,set_arcSpeed,true);
		addMember(l,"arcSpeedMultiplier",get_arcSpeedMultiplier,set_arcSpeedMultiplier,true);
		addMember(l,"donutRadius",get_donutRadius,set_donutRadius,true);
		addMember(l,"position",get_position,set_position,true);
		addMember(l,"rotation",get_rotation,set_rotation,true);
		addMember(l,"scale",get_scale,set_scale,true);
		addMember(l,"texture",get_texture,set_texture,true);
		addMember(l,"textureClipChannel",get_textureClipChannel,set_textureClipChannel,true);
		addMember(l,"textureClipThreshold",get_textureClipThreshold,set_textureClipThreshold,true);
		addMember(l,"textureColorAffectsParticles",get_textureColorAffectsParticles,set_textureColorAffectsParticles,true);
		addMember(l,"textureAlphaAffectsParticles",get_textureAlphaAffectsParticles,set_textureAlphaAffectsParticles,true);
		addMember(l,"textureBilinearFiltering",get_textureBilinearFiltering,set_textureBilinearFiltering,true);
		addMember(l,"textureUVChannel",get_textureUVChannel,set_textureUVChannel,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ParticleSystem.ShapeModule),typeof(System.ValueType));
	}
}
