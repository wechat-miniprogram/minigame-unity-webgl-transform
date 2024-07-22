using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_RenderTextureDescriptor : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			UnityEngine.RenderTextureDescriptor o;
			if(argc==3){
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				o=new UnityEngine.RenderTextureDescriptor(a1,a2);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==4){
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				UnityEngine.RenderTextureFormat a3;
				a3 = (UnityEngine.RenderTextureFormat)LuaDLL.luaL_checkinteger(l, 4);
				o=new UnityEngine.RenderTextureDescriptor(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(int),typeof(UnityEngine.RenderTextureFormat),typeof(int))){
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				UnityEngine.RenderTextureFormat a3;
				a3 = (UnityEngine.RenderTextureFormat)LuaDLL.luaL_checkinteger(l, 4);
				System.Int32 a4;
				checkType(l,5,out a4);
				o=new UnityEngine.RenderTextureDescriptor(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(int),typeof(UnityEngine.Experimental.Rendering.GraphicsFormat),typeof(int))){
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				UnityEngine.Experimental.Rendering.GraphicsFormat a3;
				a3 = (UnityEngine.Experimental.Rendering.GraphicsFormat)LuaDLL.luaL_checkinteger(l, 4);
				System.Int32 a4;
				checkType(l,5,out a4);
				o=new UnityEngine.RenderTextureDescriptor(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(int),typeof(UnityEngine.RenderTextureFormat),typeof(int),typeof(int))){
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				UnityEngine.RenderTextureFormat a3;
				a3 = (UnityEngine.RenderTextureFormat)LuaDLL.luaL_checkinteger(l, 4);
				System.Int32 a4;
				checkType(l,5,out a4);
				System.Int32 a5;
				checkType(l,6,out a5);
				o=new UnityEngine.RenderTextureDescriptor(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(int),typeof(UnityEngine.Experimental.Rendering.GraphicsFormat),typeof(int),typeof(int))){
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				UnityEngine.Experimental.Rendering.GraphicsFormat a3;
				a3 = (UnityEngine.Experimental.Rendering.GraphicsFormat)LuaDLL.luaL_checkinteger(l, 4);
				System.Int32 a4;
				checkType(l,5,out a4);
				System.Int32 a5;
				checkType(l,6,out a5);
				o=new UnityEngine.RenderTextureDescriptor(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(int),typeof(UnityEngine.Experimental.Rendering.GraphicsFormat),typeof(UnityEngine.Experimental.Rendering.GraphicsFormat))){
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				UnityEngine.Experimental.Rendering.GraphicsFormat a3;
				a3 = (UnityEngine.Experimental.Rendering.GraphicsFormat)LuaDLL.luaL_checkinteger(l, 4);
				UnityEngine.Experimental.Rendering.GraphicsFormat a4;
				a4 = (UnityEngine.Experimental.Rendering.GraphicsFormat)LuaDLL.luaL_checkinteger(l, 5);
				o=new UnityEngine.RenderTextureDescriptor(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(int),typeof(UnityEngine.Experimental.Rendering.GraphicsFormat),typeof(UnityEngine.Experimental.Rendering.GraphicsFormat),typeof(int))){
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				UnityEngine.Experimental.Rendering.GraphicsFormat a3;
				a3 = (UnityEngine.Experimental.Rendering.GraphicsFormat)LuaDLL.luaL_checkinteger(l, 4);
				UnityEngine.Experimental.Rendering.GraphicsFormat a4;
				a4 = (UnityEngine.Experimental.Rendering.GraphicsFormat)LuaDLL.luaL_checkinteger(l, 5);
				System.Int32 a5;
				checkType(l,6,out a5);
				o=new UnityEngine.RenderTextureDescriptor(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==0){
				o=new UnityEngine.RenderTextureDescriptor();
				pushValue(l,true);
				pushObject(l,o);
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
	static public int get_width(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.width);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_width(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.width=v;
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
	static public int get_height(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
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
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.height=v;
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
	static public int get_msaaSamples(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.msaaSamples);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_msaaSamples(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.msaaSamples=v;
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
	static public int get_volumeDepth(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.volumeDepth);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_volumeDepth(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.volumeDepth=v;
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
	static public int get_mipCount(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.mipCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_mipCount(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.mipCount=v;
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
	static public int get_graphicsFormat(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.graphicsFormat);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_graphicsFormat(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			UnityEngine.Experimental.Rendering.GraphicsFormat v;
			v = (UnityEngine.Experimental.Rendering.GraphicsFormat)LuaDLL.luaL_checkinteger(l, 2);
			self.graphicsFormat=v;
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
	static public int get_stencilFormat(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.stencilFormat);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_stencilFormat(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			UnityEngine.Experimental.Rendering.GraphicsFormat v;
			v = (UnityEngine.Experimental.Rendering.GraphicsFormat)LuaDLL.luaL_checkinteger(l, 2);
			self.stencilFormat=v;
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
	static public int get_depthStencilFormat(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.depthStencilFormat);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_depthStencilFormat(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			UnityEngine.Experimental.Rendering.GraphicsFormat v;
			v = (UnityEngine.Experimental.Rendering.GraphicsFormat)LuaDLL.luaL_checkinteger(l, 2);
			self.depthStencilFormat=v;
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
	static public int get_colorFormat(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.colorFormat);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_colorFormat(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			UnityEngine.RenderTextureFormat v;
			v = (UnityEngine.RenderTextureFormat)LuaDLL.luaL_checkinteger(l, 2);
			self.colorFormat=v;
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
	static public int get_sRGB(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sRGB);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_sRGB(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.sRGB=v;
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
	static public int get_depthBufferBits(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.depthBufferBits);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_depthBufferBits(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.depthBufferBits=v;
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
	static public int get_dimension(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.dimension);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_dimension(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			UnityEngine.Rendering.TextureDimension v;
			v = (UnityEngine.Rendering.TextureDimension)LuaDLL.luaL_checkinteger(l, 2);
			self.dimension=v;
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
	static public int get_shadowSamplingMode(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.shadowSamplingMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_shadowSamplingMode(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			UnityEngine.Rendering.ShadowSamplingMode v;
			v = (UnityEngine.Rendering.ShadowSamplingMode)LuaDLL.luaL_checkinteger(l, 2);
			self.shadowSamplingMode=v;
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
	static public int get_vrUsage(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.vrUsage);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_vrUsage(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			UnityEngine.VRTextureUsage v;
			v = (UnityEngine.VRTextureUsage)LuaDLL.luaL_checkinteger(l, 2);
			self.vrUsage=v;
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
	static public int get_flags(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.flags);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_memoryless(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.memoryless);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_memoryless(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			UnityEngine.RenderTextureMemoryless v;
			v = (UnityEngine.RenderTextureMemoryless)LuaDLL.luaL_checkinteger(l, 2);
			self.memoryless=v;
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
	static public int get_useMipMap(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.useMipMap);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_useMipMap(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.useMipMap=v;
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
	static public int get_autoGenerateMips(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.autoGenerateMips);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_autoGenerateMips(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.autoGenerateMips=v;
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
	static public int get_enableRandomWrite(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.enableRandomWrite);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_enableRandomWrite(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.enableRandomWrite=v;
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
	static public int get_bindMS(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.bindMS);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_bindMS(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.bindMS=v;
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
	static public int get_useDynamicScale(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.useDynamicScale);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_useDynamicScale(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.useDynamicScale=v;
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
		getTypeTable(l,"UnityEngine.RenderTextureDescriptor");
		addMember(l,"width",get_width,set_width,true);
		addMember(l,"height",get_height,set_height,true);
		addMember(l,"msaaSamples",get_msaaSamples,set_msaaSamples,true);
		addMember(l,"volumeDepth",get_volumeDepth,set_volumeDepth,true);
		addMember(l,"mipCount",get_mipCount,set_mipCount,true);
		addMember(l,"graphicsFormat",get_graphicsFormat,set_graphicsFormat,true);
		addMember(l,"stencilFormat",get_stencilFormat,set_stencilFormat,true);
		addMember(l,"depthStencilFormat",get_depthStencilFormat,set_depthStencilFormat,true);
		addMember(l,"colorFormat",get_colorFormat,set_colorFormat,true);
		addMember(l,"sRGB",get_sRGB,set_sRGB,true);
		addMember(l,"depthBufferBits",get_depthBufferBits,set_depthBufferBits,true);
		addMember(l,"dimension",get_dimension,set_dimension,true);
		addMember(l,"shadowSamplingMode",get_shadowSamplingMode,set_shadowSamplingMode,true);
		addMember(l,"vrUsage",get_vrUsage,set_vrUsage,true);
		addMember(l,"flags",get_flags,null,true);
		addMember(l,"memoryless",get_memoryless,set_memoryless,true);
		addMember(l,"useMipMap",get_useMipMap,set_useMipMap,true);
		addMember(l,"autoGenerateMips",get_autoGenerateMips,set_autoGenerateMips,true);
		addMember(l,"enableRandomWrite",get_enableRandomWrite,set_enableRandomWrite,true);
		addMember(l,"bindMS",get_bindMS,set_bindMS,true);
		addMember(l,"useDynamicScale",get_useDynamicScale,set_useDynamicScale,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.RenderTextureDescriptor),typeof(System.ValueType));
	}
}
