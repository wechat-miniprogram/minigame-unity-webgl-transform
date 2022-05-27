using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_CustomRenderTexture : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			UnityEngine.CustomRenderTexture o;
			if(argc==5){
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				UnityEngine.RenderTextureFormat a3;
				a3 = (UnityEngine.RenderTextureFormat)LuaDLL.luaL_checkinteger(l, 4);
				UnityEngine.RenderTextureReadWrite a4;
				a4 = (UnityEngine.RenderTextureReadWrite)LuaDLL.luaL_checkinteger(l, 5);
				o=new UnityEngine.CustomRenderTexture(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(int),typeof(UnityEngine.RenderTextureFormat))){
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				UnityEngine.RenderTextureFormat a3;
				a3 = (UnityEngine.RenderTextureFormat)LuaDLL.luaL_checkinteger(l, 4);
				o=new UnityEngine.CustomRenderTexture(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==3){
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				o=new UnityEngine.CustomRenderTexture(a1,a2);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(int),typeof(UnityEngine.Experimental.Rendering.DefaultFormat))){
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				UnityEngine.Experimental.Rendering.DefaultFormat a3;
				a3 = (UnityEngine.Experimental.Rendering.DefaultFormat)LuaDLL.luaL_checkinteger(l, 4);
				o=new UnityEngine.CustomRenderTexture(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(int),typeof(UnityEngine.Experimental.Rendering.GraphicsFormat))){
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				UnityEngine.Experimental.Rendering.GraphicsFormat a3;
				a3 = (UnityEngine.Experimental.Rendering.GraphicsFormat)LuaDLL.luaL_checkinteger(l, 4);
				o=new UnityEngine.CustomRenderTexture(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			return error(l,"New object failed.");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Update(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
				self.Update();
				pushValue(l,true);
				return 1;
			}
			else if(argc==2){
				UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				self.Update(a1);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Update to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Initialize(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			self.Initialize();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ClearUpdateZones(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			self.ClearUpdateZones();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetUpdateZones(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			System.Collections.Generic.List<UnityEngine.CustomRenderTextureUpdateZone> a1;
			checkType(l,2,out a1);
			self.GetUpdateZones(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetDoubleBufferRenderTexture(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			var ret=self.GetDoubleBufferRenderTexture();
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
	static public int EnsureDoubleBufferConsistency(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			self.EnsureDoubleBufferConsistency();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetUpdateZones(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			UnityEngine.CustomRenderTextureUpdateZone[] a1;
			checkArray(l,2,out a1);
			self.SetUpdateZones(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_material(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.material);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_material(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			UnityEngine.Material v;
			checkType(l,2,out v);
			self.material=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_initializationMaterial(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.initializationMaterial);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_initializationMaterial(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			UnityEngine.Material v;
			checkType(l,2,out v);
			self.initializationMaterial=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_initializationTexture(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.initializationTexture);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_initializationTexture(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			UnityEngine.Texture v;
			checkType(l,2,out v);
			self.initializationTexture=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_initializationSource(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.initializationSource);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_initializationSource(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			UnityEngine.CustomRenderTextureInitializationSource v;
			v = (UnityEngine.CustomRenderTextureInitializationSource)LuaDLL.luaL_checkinteger(l, 2);
			self.initializationSource=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_initializationColor(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.initializationColor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_initializationColor(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.initializationColor=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_updateMode(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.updateMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_updateMode(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			UnityEngine.CustomRenderTextureUpdateMode v;
			v = (UnityEngine.CustomRenderTextureUpdateMode)LuaDLL.luaL_checkinteger(l, 2);
			self.updateMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_initializationMode(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.initializationMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_initializationMode(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			UnityEngine.CustomRenderTextureUpdateMode v;
			v = (UnityEngine.CustomRenderTextureUpdateMode)LuaDLL.luaL_checkinteger(l, 2);
			self.initializationMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_updateZoneSpace(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.updateZoneSpace);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_updateZoneSpace(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			UnityEngine.CustomRenderTextureUpdateZoneSpace v;
			v = (UnityEngine.CustomRenderTextureUpdateZoneSpace)LuaDLL.luaL_checkinteger(l, 2);
			self.updateZoneSpace=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_shaderPass(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.shaderPass);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_shaderPass(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.shaderPass=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_cubemapFaceMask(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.cubemapFaceMask);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_cubemapFaceMask(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			System.UInt32 v;
			checkType(l,2,out v);
			self.cubemapFaceMask=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_doubleBuffered(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.doubleBuffered);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_doubleBuffered(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.doubleBuffered=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_wrapUpdateZones(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.wrapUpdateZones);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_wrapUpdateZones(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.wrapUpdateZones=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_updatePeriod(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.updatePeriod);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_updatePeriod(IntPtr l) {
		try {
			UnityEngine.CustomRenderTexture self=(UnityEngine.CustomRenderTexture)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.updatePeriod=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.CustomRenderTexture");
		addMember(l,Update);
		addMember(l,Initialize);
		addMember(l,ClearUpdateZones);
		addMember(l,GetUpdateZones);
		addMember(l,GetDoubleBufferRenderTexture);
		addMember(l,EnsureDoubleBufferConsistency);
		addMember(l,SetUpdateZones);
		addMember(l,"material",get_material,set_material,true);
		addMember(l,"initializationMaterial",get_initializationMaterial,set_initializationMaterial,true);
		addMember(l,"initializationTexture",get_initializationTexture,set_initializationTexture,true);
		addMember(l,"initializationSource",get_initializationSource,set_initializationSource,true);
		addMember(l,"initializationColor",get_initializationColor,set_initializationColor,true);
		addMember(l,"updateMode",get_updateMode,set_updateMode,true);
		addMember(l,"initializationMode",get_initializationMode,set_initializationMode,true);
		addMember(l,"updateZoneSpace",get_updateZoneSpace,set_updateZoneSpace,true);
		addMember(l,"shaderPass",get_shaderPass,set_shaderPass,true);
		addMember(l,"cubemapFaceMask",get_cubemapFaceMask,set_cubemapFaceMask,true);
		addMember(l,"doubleBuffered",get_doubleBuffered,set_doubleBuffered,true);
		addMember(l,"wrapUpdateZones",get_wrapUpdateZones,set_wrapUpdateZones,true);
		addMember(l,"updatePeriod",get_updatePeriod,set_updatePeriod,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.CustomRenderTexture),typeof(UnityEngine.RenderTexture));
	}
}
