using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_SystemInfo : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.SystemInfo o;
			o=new UnityEngine.SystemInfo();
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
	static public int SupportsRenderTextureFormat_s(IntPtr l) {
		try {
			UnityEngine.RenderTextureFormat a1;
			a1 = (UnityEngine.RenderTextureFormat)LuaDLL.luaL_checkinteger(l, 1);
			var ret=UnityEngine.SystemInfo.SupportsRenderTextureFormat(a1);
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
	static public int SupportsBlendingOnRenderTextureFormat_s(IntPtr l) {
		try {
			UnityEngine.RenderTextureFormat a1;
			a1 = (UnityEngine.RenderTextureFormat)LuaDLL.luaL_checkinteger(l, 1);
			var ret=UnityEngine.SystemInfo.SupportsBlendingOnRenderTextureFormat(a1);
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
	static public int SupportsRandomWriteOnRenderTextureFormat_s(IntPtr l) {
		try {
			UnityEngine.RenderTextureFormat a1;
			a1 = (UnityEngine.RenderTextureFormat)LuaDLL.luaL_checkinteger(l, 1);
			var ret=UnityEngine.SystemInfo.SupportsRandomWriteOnRenderTextureFormat(a1);
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
	static public int SupportsTextureFormat_s(IntPtr l) {
		try {
			UnityEngine.TextureFormat a1;
			a1 = (UnityEngine.TextureFormat)LuaDLL.luaL_checkinteger(l, 1);
			var ret=UnityEngine.SystemInfo.SupportsTextureFormat(a1);
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
	static public int SupportsVertexAttributeFormat_s(IntPtr l) {
		try {
			UnityEngine.Rendering.VertexAttributeFormat a1;
			a1 = (UnityEngine.Rendering.VertexAttributeFormat)LuaDLL.luaL_checkinteger(l, 1);
			System.Int32 a2;
			checkType(l,2,out a2);
			var ret=UnityEngine.SystemInfo.SupportsVertexAttributeFormat(a1,a2);
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
	static public int IsFormatSupported_s(IntPtr l) {
		try {
			UnityEngine.Experimental.Rendering.GraphicsFormat a1;
			a1 = (UnityEngine.Experimental.Rendering.GraphicsFormat)LuaDLL.luaL_checkinteger(l, 1);
			UnityEngine.Experimental.Rendering.FormatUsage a2;
			a2 = (UnityEngine.Experimental.Rendering.FormatUsage)LuaDLL.luaL_checkinteger(l, 2);
			var ret=UnityEngine.SystemInfo.IsFormatSupported(a1,a2);
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
	static public int GetCompatibleFormat_s(IntPtr l) {
		try {
			UnityEngine.Experimental.Rendering.GraphicsFormat a1;
			a1 = (UnityEngine.Experimental.Rendering.GraphicsFormat)LuaDLL.luaL_checkinteger(l, 1);
			UnityEngine.Experimental.Rendering.FormatUsage a2;
			a2 = (UnityEngine.Experimental.Rendering.FormatUsage)LuaDLL.luaL_checkinteger(l, 2);
			var ret=UnityEngine.SystemInfo.GetCompatibleFormat(a1,a2);
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
	static public int GetGraphicsFormat_s(IntPtr l) {
		try {
			UnityEngine.Experimental.Rendering.DefaultFormat a1;
			a1 = (UnityEngine.Experimental.Rendering.DefaultFormat)LuaDLL.luaL_checkinteger(l, 1);
			var ret=UnityEngine.SystemInfo.GetGraphicsFormat(a1);
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
	static public int GetRenderTextureSupportedMSAASampleCount_s(IntPtr l) {
		try {
			UnityEngine.RenderTextureDescriptor a1;
			checkValueType(l,1,out a1);
			var ret=UnityEngine.SystemInfo.GetRenderTextureSupportedMSAASampleCount(a1);
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
	static public int get_unsupportedIdentifier(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.unsupportedIdentifier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_batteryLevel(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.batteryLevel);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_batteryStatus(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UnityEngine.SystemInfo.batteryStatus);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_operatingSystem(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.operatingSystem);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_operatingSystemFamily(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UnityEngine.SystemInfo.operatingSystemFamily);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_processorType(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.processorType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_processorFrequency(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.processorFrequency);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_processorCount(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.processorCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_systemMemorySize(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.systemMemorySize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_deviceUniqueIdentifier(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.deviceUniqueIdentifier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_deviceName(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.deviceName);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_deviceModel(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.deviceModel);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsAccelerometer(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsAccelerometer);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsGyroscope(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsGyroscope);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsLocationService(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsLocationService);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsVibration(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsVibration);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsAudio(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsAudio);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_deviceType(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UnityEngine.SystemInfo.deviceType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_graphicsMemorySize(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.graphicsMemorySize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_graphicsDeviceName(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.graphicsDeviceName);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_graphicsDeviceVendor(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.graphicsDeviceVendor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_graphicsDeviceID(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.graphicsDeviceID);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_graphicsDeviceVendorID(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.graphicsDeviceVendorID);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_graphicsDeviceType(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UnityEngine.SystemInfo.graphicsDeviceType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_graphicsUVStartsAtTop(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.graphicsUVStartsAtTop);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_graphicsDeviceVersion(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.graphicsDeviceVersion);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_graphicsShaderLevel(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.graphicsShaderLevel);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_graphicsMultiThreaded(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.graphicsMultiThreaded);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_renderingThreadingMode(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UnityEngine.SystemInfo.renderingThreadingMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_hasHiddenSurfaceRemovalOnGPU(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.hasHiddenSurfaceRemovalOnGPU);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_hasDynamicUniformArrayIndexingInFragmentShaders(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.hasDynamicUniformArrayIndexingInFragmentShaders);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsShadows(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsShadows);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsRawShadowDepthSampling(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsRawShadowDepthSampling);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsMotionVectors(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsMotionVectors);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supports3DTextures(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supports3DTextures);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsCompressed3DTextures(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsCompressed3DTextures);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supports2DArrayTextures(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supports2DArrayTextures);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supports3DRenderTextures(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supports3DRenderTextures);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsCubemapArrayTextures(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsCubemapArrayTextures);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_copyTextureSupport(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UnityEngine.SystemInfo.copyTextureSupport);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsComputeShaders(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsComputeShaders);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsGeometryShaders(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsGeometryShaders);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsTessellationShaders(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsTessellationShaders);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsRenderTargetArrayIndexFromVertexShader(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsRenderTargetArrayIndexFromVertexShader);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsInstancing(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsInstancing);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsHardwareQuadTopology(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsHardwareQuadTopology);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supports32bitsIndexBuffer(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supports32bitsIndexBuffer);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsSparseTextures(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsSparseTextures);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportedRenderTargetCount(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportedRenderTargetCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsSeparatedRenderTargetsBlend(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsSeparatedRenderTargetsBlend);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportedRandomWriteTargetCount(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportedRandomWriteTargetCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsMultisampledTextures(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsMultisampledTextures);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsMultisampled2DArrayTextures(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsMultisampled2DArrayTextures);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsMultisampleAutoResolve(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsMultisampleAutoResolve);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsTextureWrapMirrorOnce(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsTextureWrapMirrorOnce);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_usesReversedZBuffer(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.usesReversedZBuffer);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_npotSupport(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UnityEngine.SystemInfo.npotSupport);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maxTextureSize(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.maxTextureSize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maxCubemapSize(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.maxCubemapSize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maxComputeBufferInputsVertex(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.maxComputeBufferInputsVertex);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maxComputeBufferInputsFragment(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.maxComputeBufferInputsFragment);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maxComputeBufferInputsGeometry(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.maxComputeBufferInputsGeometry);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maxComputeBufferInputsDomain(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.maxComputeBufferInputsDomain);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maxComputeBufferInputsHull(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.maxComputeBufferInputsHull);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maxComputeBufferInputsCompute(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.maxComputeBufferInputsCompute);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maxComputeWorkGroupSize(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.maxComputeWorkGroupSize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maxComputeWorkGroupSizeX(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.maxComputeWorkGroupSizeX);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maxComputeWorkGroupSizeY(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.maxComputeWorkGroupSizeY);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maxComputeWorkGroupSizeZ(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.maxComputeWorkGroupSizeZ);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsAsyncCompute(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsAsyncCompute);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsGpuRecorder(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsGpuRecorder);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsGraphicsFence(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsGraphicsFence);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsAsyncGPUReadback(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsAsyncGPUReadback);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsRayTracing(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsRayTracing);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsSetConstantBuffer(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsSetConstantBuffer);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_constantBufferOffsetAlignment(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.constantBufferOffsetAlignment);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maxGraphicsBufferSize(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.maxGraphicsBufferSize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_hasMipMaxLevel(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.hasMipMaxLevel);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsMipStreaming(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsMipStreaming);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_usesLoadStoreActions(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.usesLoadStoreActions);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_hdrDisplaySupportFlags(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UnityEngine.SystemInfo.hdrDisplaySupportFlags);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsConservativeRaster(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsConservativeRaster);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsMultiview(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsMultiview);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsStoreAndResolveAction(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsStoreAndResolveAction);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supportsMultisampleResolveDepth(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SystemInfo.supportsMultisampleResolveDepth);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.SystemInfo");
		addMember(l,SupportsRenderTextureFormat_s);
		addMember(l,SupportsBlendingOnRenderTextureFormat_s);
		addMember(l,SupportsRandomWriteOnRenderTextureFormat_s);
		addMember(l,SupportsTextureFormat_s);
		addMember(l,SupportsVertexAttributeFormat_s);
		addMember(l,IsFormatSupported_s);
		addMember(l,GetCompatibleFormat_s);
		addMember(l,GetGraphicsFormat_s);
		addMember(l,GetRenderTextureSupportedMSAASampleCount_s);
		addMember(l,"unsupportedIdentifier",get_unsupportedIdentifier,null,false);
		addMember(l,"batteryLevel",get_batteryLevel,null,false);
		addMember(l,"batteryStatus",get_batteryStatus,null,false);
		addMember(l,"operatingSystem",get_operatingSystem,null,false);
		addMember(l,"operatingSystemFamily",get_operatingSystemFamily,null,false);
		addMember(l,"processorType",get_processorType,null,false);
		addMember(l,"processorFrequency",get_processorFrequency,null,false);
		addMember(l,"processorCount",get_processorCount,null,false);
		addMember(l,"systemMemorySize",get_systemMemorySize,null,false);
		addMember(l,"deviceUniqueIdentifier",get_deviceUniqueIdentifier,null,false);
		addMember(l,"deviceName",get_deviceName,null,false);
		addMember(l,"deviceModel",get_deviceModel,null,false);
		addMember(l,"supportsAccelerometer",get_supportsAccelerometer,null,false);
		addMember(l,"supportsGyroscope",get_supportsGyroscope,null,false);
		addMember(l,"supportsLocationService",get_supportsLocationService,null,false);
		addMember(l,"supportsVibration",get_supportsVibration,null,false);
		addMember(l,"supportsAudio",get_supportsAudio,null,false);
		addMember(l,"deviceType",get_deviceType,null,false);
		addMember(l,"graphicsMemorySize",get_graphicsMemorySize,null,false);
		addMember(l,"graphicsDeviceName",get_graphicsDeviceName,null,false);
		addMember(l,"graphicsDeviceVendor",get_graphicsDeviceVendor,null,false);
		addMember(l,"graphicsDeviceID",get_graphicsDeviceID,null,false);
		addMember(l,"graphicsDeviceVendorID",get_graphicsDeviceVendorID,null,false);
		addMember(l,"graphicsDeviceType",get_graphicsDeviceType,null,false);
		addMember(l,"graphicsUVStartsAtTop",get_graphicsUVStartsAtTop,null,false);
		addMember(l,"graphicsDeviceVersion",get_graphicsDeviceVersion,null,false);
		addMember(l,"graphicsShaderLevel",get_graphicsShaderLevel,null,false);
		addMember(l,"graphicsMultiThreaded",get_graphicsMultiThreaded,null,false);
		addMember(l,"renderingThreadingMode",get_renderingThreadingMode,null,false);
		addMember(l,"hasHiddenSurfaceRemovalOnGPU",get_hasHiddenSurfaceRemovalOnGPU,null,false);
		addMember(l,"hasDynamicUniformArrayIndexingInFragmentShaders",get_hasDynamicUniformArrayIndexingInFragmentShaders,null,false);
		addMember(l,"supportsShadows",get_supportsShadows,null,false);
		addMember(l,"supportsRawShadowDepthSampling",get_supportsRawShadowDepthSampling,null,false);
		addMember(l,"supportsMotionVectors",get_supportsMotionVectors,null,false);
		addMember(l,"supports3DTextures",get_supports3DTextures,null,false);
		addMember(l,"supportsCompressed3DTextures",get_supportsCompressed3DTextures,null,false);
		addMember(l,"supports2DArrayTextures",get_supports2DArrayTextures,null,false);
		addMember(l,"supports3DRenderTextures",get_supports3DRenderTextures,null,false);
		addMember(l,"supportsCubemapArrayTextures",get_supportsCubemapArrayTextures,null,false);
		addMember(l,"copyTextureSupport",get_copyTextureSupport,null,false);
		addMember(l,"supportsComputeShaders",get_supportsComputeShaders,null,false);
		addMember(l,"supportsGeometryShaders",get_supportsGeometryShaders,null,false);
		addMember(l,"supportsTessellationShaders",get_supportsTessellationShaders,null,false);
		addMember(l,"supportsRenderTargetArrayIndexFromVertexShader",get_supportsRenderTargetArrayIndexFromVertexShader,null,false);
		addMember(l,"supportsInstancing",get_supportsInstancing,null,false);
		addMember(l,"supportsHardwareQuadTopology",get_supportsHardwareQuadTopology,null,false);
		addMember(l,"supports32bitsIndexBuffer",get_supports32bitsIndexBuffer,null,false);
		addMember(l,"supportsSparseTextures",get_supportsSparseTextures,null,false);
		addMember(l,"supportedRenderTargetCount",get_supportedRenderTargetCount,null,false);
		addMember(l,"supportsSeparatedRenderTargetsBlend",get_supportsSeparatedRenderTargetsBlend,null,false);
		addMember(l,"supportedRandomWriteTargetCount",get_supportedRandomWriteTargetCount,null,false);
		addMember(l,"supportsMultisampledTextures",get_supportsMultisampledTextures,null,false);
		addMember(l,"supportsMultisampled2DArrayTextures",get_supportsMultisampled2DArrayTextures,null,false);
		addMember(l,"supportsMultisampleAutoResolve",get_supportsMultisampleAutoResolve,null,false);
		addMember(l,"supportsTextureWrapMirrorOnce",get_supportsTextureWrapMirrorOnce,null,false);
		addMember(l,"usesReversedZBuffer",get_usesReversedZBuffer,null,false);
		addMember(l,"npotSupport",get_npotSupport,null,false);
		addMember(l,"maxTextureSize",get_maxTextureSize,null,false);
		addMember(l,"maxCubemapSize",get_maxCubemapSize,null,false);
		addMember(l,"maxComputeBufferInputsVertex",get_maxComputeBufferInputsVertex,null,false);
		addMember(l,"maxComputeBufferInputsFragment",get_maxComputeBufferInputsFragment,null,false);
		addMember(l,"maxComputeBufferInputsGeometry",get_maxComputeBufferInputsGeometry,null,false);
		addMember(l,"maxComputeBufferInputsDomain",get_maxComputeBufferInputsDomain,null,false);
		addMember(l,"maxComputeBufferInputsHull",get_maxComputeBufferInputsHull,null,false);
		addMember(l,"maxComputeBufferInputsCompute",get_maxComputeBufferInputsCompute,null,false);
		addMember(l,"maxComputeWorkGroupSize",get_maxComputeWorkGroupSize,null,false);
		addMember(l,"maxComputeWorkGroupSizeX",get_maxComputeWorkGroupSizeX,null,false);
		addMember(l,"maxComputeWorkGroupSizeY",get_maxComputeWorkGroupSizeY,null,false);
		addMember(l,"maxComputeWorkGroupSizeZ",get_maxComputeWorkGroupSizeZ,null,false);
		addMember(l,"supportsAsyncCompute",get_supportsAsyncCompute,null,false);
		addMember(l,"supportsGpuRecorder",get_supportsGpuRecorder,null,false);
		addMember(l,"supportsGraphicsFence",get_supportsGraphicsFence,null,false);
		addMember(l,"supportsAsyncGPUReadback",get_supportsAsyncGPUReadback,null,false);
		addMember(l,"supportsRayTracing",get_supportsRayTracing,null,false);
		addMember(l,"supportsSetConstantBuffer",get_supportsSetConstantBuffer,null,false);
		addMember(l,"constantBufferOffsetAlignment",get_constantBufferOffsetAlignment,null,false);
		addMember(l,"maxGraphicsBufferSize",get_maxGraphicsBufferSize,null,false);
		addMember(l,"hasMipMaxLevel",get_hasMipMaxLevel,null,false);
		addMember(l,"supportsMipStreaming",get_supportsMipStreaming,null,false);
		addMember(l,"usesLoadStoreActions",get_usesLoadStoreActions,null,false);
		addMember(l,"hdrDisplaySupportFlags",get_hdrDisplaySupportFlags,null,false);
		addMember(l,"supportsConservativeRaster",get_supportsConservativeRaster,null,false);
		addMember(l,"supportsMultiview",get_supportsMultiview,null,false);
		addMember(l,"supportsStoreAndResolveAction",get_supportsStoreAndResolveAction,null,false);
		addMember(l,"supportsMultisampleResolveDepth",get_supportsMultisampleResolveDepth,null,false);
		createTypeMetatable(l,constructor, typeof(UnityEngine.SystemInfo));
	}
}
