using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Graphics : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Graphics o;
			o=new UnityEngine.Graphics();
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
	static public int ClearRandomWriteTargets_s(IntPtr l) {
		try {
			UnityEngine.Graphics.ClearRandomWriteTargets();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ExecuteCommandBuffer_s(IntPtr l) {
		try {
			UnityEngine.Rendering.CommandBuffer a1;
			checkType(l,1,out a1);
			UnityEngine.Graphics.ExecuteCommandBuffer(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ExecuteCommandBufferAsync_s(IntPtr l) {
		try {
			UnityEngine.Rendering.CommandBuffer a1;
			checkType(l,1,out a1);
			UnityEngine.Rendering.ComputeQueueType a2;
			a2 = (UnityEngine.Rendering.ComputeQueueType)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.Graphics.ExecuteCommandBufferAsync(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetRenderTarget_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.RenderTargetSetup))){
				UnityEngine.RenderTargetSetup a1;
				checkValueType(l,1,out a1);
				UnityEngine.Graphics.SetRenderTarget(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.RenderTexture))){
				UnityEngine.RenderTexture a1;
				checkType(l,1,out a1);
				UnityEngine.Graphics.SetRenderTarget(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.RenderBuffer[]),typeof(UnityEngine.RenderBuffer))){
				UnityEngine.RenderBuffer[] a1;
				checkArray(l,1,out a1);
				UnityEngine.RenderBuffer a2;
				checkValueType(l,2,out a2);
				UnityEngine.Graphics.SetRenderTarget(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.RenderTexture),typeof(int))){
				UnityEngine.RenderTexture a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Graphics.SetRenderTarget(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.RenderBuffer),typeof(UnityEngine.RenderBuffer))){
				UnityEngine.RenderBuffer a1;
				checkValueType(l,1,out a1);
				UnityEngine.RenderBuffer a2;
				checkValueType(l,2,out a2);
				UnityEngine.Graphics.SetRenderTarget(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.RenderTexture),typeof(int),typeof(UnityEngine.CubemapFace))){
				UnityEngine.RenderTexture a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.CubemapFace a3;
				a3 = (UnityEngine.CubemapFace)LuaDLL.luaL_checkinteger(l, 3);
				UnityEngine.Graphics.SetRenderTarget(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.RenderBuffer),typeof(UnityEngine.RenderBuffer),typeof(int))){
				UnityEngine.RenderBuffer a1;
				checkValueType(l,1,out a1);
				UnityEngine.RenderBuffer a2;
				checkValueType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				UnityEngine.Graphics.SetRenderTarget(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.RenderTexture),typeof(int),typeof(UnityEngine.CubemapFace),typeof(int))){
				UnityEngine.RenderTexture a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.CubemapFace a3;
				a3 = (UnityEngine.CubemapFace)LuaDLL.luaL_checkinteger(l, 3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Graphics.SetRenderTarget(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.RenderBuffer),typeof(UnityEngine.RenderBuffer),typeof(int),typeof(UnityEngine.CubemapFace))){
				UnityEngine.RenderBuffer a1;
				checkValueType(l,1,out a1);
				UnityEngine.RenderBuffer a2;
				checkValueType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				UnityEngine.CubemapFace a4;
				a4 = (UnityEngine.CubemapFace)LuaDLL.luaL_checkinteger(l, 4);
				UnityEngine.Graphics.SetRenderTarget(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(argc==5){
				UnityEngine.RenderBuffer a1;
				checkValueType(l,1,out a1);
				UnityEngine.RenderBuffer a2;
				checkValueType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				UnityEngine.CubemapFace a4;
				a4 = (UnityEngine.CubemapFace)LuaDLL.luaL_checkinteger(l, 4);
				System.Int32 a5;
				checkType(l,5,out a5);
				UnityEngine.Graphics.SetRenderTarget(a1,a2,a3,a4,a5);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetRenderTarget to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetRandomWriteTarget_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(int),typeof(UnityEngine.RenderTexture))){
				System.Int32 a1;
				checkType(l,1,out a1);
				UnityEngine.RenderTexture a2;
				checkType(l,2,out a2);
				UnityEngine.Graphics.SetRandomWriteTarget(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(UnityEngine.ComputeBuffer))){
				System.Int32 a1;
				checkType(l,1,out a1);
				UnityEngine.ComputeBuffer a2;
				checkType(l,2,out a2);
				UnityEngine.Graphics.SetRandomWriteTarget(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(UnityEngine.GraphicsBuffer))){
				System.Int32 a1;
				checkType(l,1,out a1);
				UnityEngine.GraphicsBuffer a2;
				checkType(l,2,out a2);
				UnityEngine.Graphics.SetRandomWriteTarget(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(UnityEngine.ComputeBuffer),typeof(bool))){
				System.Int32 a1;
				checkType(l,1,out a1);
				UnityEngine.ComputeBuffer a2;
				checkType(l,2,out a2);
				System.Boolean a3;
				checkType(l,3,out a3);
				UnityEngine.Graphics.SetRandomWriteTarget(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(UnityEngine.GraphicsBuffer),typeof(bool))){
				System.Int32 a1;
				checkType(l,1,out a1);
				UnityEngine.GraphicsBuffer a2;
				checkType(l,2,out a2);
				System.Boolean a3;
				checkType(l,3,out a3);
				UnityEngine.Graphics.SetRandomWriteTarget(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetRandomWriteTarget to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CopyTexture_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Texture a1;
				checkType(l,1,out a1);
				UnityEngine.Texture a2;
				checkType(l,2,out a2);
				UnityEngine.Graphics.CopyTexture(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Texture a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Texture a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Graphics.CopyTexture(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(argc==6){
				UnityEngine.Texture a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				UnityEngine.Texture a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				UnityEngine.Graphics.CopyTexture(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				return 1;
			}
			else if(argc==12){
				UnityEngine.Texture a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				System.Int32 a7;
				checkType(l,7,out a7);
				UnityEngine.Texture a8;
				checkType(l,8,out a8);
				System.Int32 a9;
				checkType(l,9,out a9);
				System.Int32 a10;
				checkType(l,10,out a10);
				System.Int32 a11;
				checkType(l,11,out a11);
				System.Int32 a12;
				checkType(l,12,out a12);
				UnityEngine.Graphics.CopyTexture(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11,a12);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function CopyTexture to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ConvertTexture_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Texture a1;
				checkType(l,1,out a1);
				UnityEngine.Texture a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Graphics.ConvertTexture(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==4){
				UnityEngine.Texture a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Texture a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.Graphics.ConvertTexture(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function ConvertTexture to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CreateAsyncGraphicsFence_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==0){
				var ret=UnityEngine.Graphics.CreateAsyncGraphicsFence();
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==1){
				UnityEngine.Rendering.SynchronisationStage a1;
				a1 = (UnityEngine.Rendering.SynchronisationStage)LuaDLL.luaL_checkinteger(l, 1);
				var ret=UnityEngine.Graphics.CreateAsyncGraphicsFence(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function CreateAsyncGraphicsFence to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CreateGraphicsFence_s(IntPtr l) {
		try {
			UnityEngine.Rendering.GraphicsFenceType a1;
			a1 = (UnityEngine.Rendering.GraphicsFenceType)LuaDLL.luaL_checkinteger(l, 1);
			UnityEngine.Rendering.SynchronisationStageFlags a2;
			a2 = (UnityEngine.Rendering.SynchronisationStageFlags)LuaDLL.luaL_checkinteger(l, 2);
			var ret=UnityEngine.Graphics.CreateGraphicsFence(a1,a2);
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
	static public int WaitOnAsyncGraphicsFence_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.Rendering.GraphicsFence a1;
				checkValueType(l,1,out a1);
				UnityEngine.Graphics.WaitOnAsyncGraphicsFence(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==2){
				UnityEngine.Rendering.GraphicsFence a1;
				checkValueType(l,1,out a1);
				UnityEngine.Rendering.SynchronisationStage a2;
				a2 = (UnityEngine.Rendering.SynchronisationStage)LuaDLL.luaL_checkinteger(l, 2);
				UnityEngine.Graphics.WaitOnAsyncGraphicsFence(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function WaitOnAsyncGraphicsFence to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CopyBuffer_s(IntPtr l) {
		try {
			UnityEngine.GraphicsBuffer a1;
			checkType(l,1,out a1);
			UnityEngine.GraphicsBuffer a2;
			checkType(l,2,out a2);
			UnityEngine.Graphics.CopyBuffer(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int DrawTexture_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Rect a1;
				checkValueType(l,1,out a1);
				UnityEngine.Texture a2;
				checkType(l,2,out a2);
				UnityEngine.Graphics.DrawTexture(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Rect a1;
				checkValueType(l,1,out a1);
				UnityEngine.Texture a2;
				checkType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				UnityEngine.Graphics.DrawTexture(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Rect a1;
				checkValueType(l,1,out a1);
				UnityEngine.Texture a2;
				checkType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Graphics.DrawTexture(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(argc==6){
				UnityEngine.Rect a1;
				checkValueType(l,1,out a1);
				UnityEngine.Texture a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				UnityEngine.Graphics.DrawTexture(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Rect),typeof(UnityEngine.Texture),typeof(UnityEngine.Rect),typeof(int),typeof(int),typeof(int),typeof(int))){
				UnityEngine.Rect a1;
				checkValueType(l,1,out a1);
				UnityEngine.Texture a2;
				checkType(l,2,out a2);
				UnityEngine.Rect a3;
				checkValueType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				System.Int32 a7;
				checkType(l,7,out a7);
				UnityEngine.Graphics.DrawTexture(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Rect),typeof(UnityEngine.Texture),typeof(int),typeof(int),typeof(int),typeof(int),typeof(UnityEngine.Material))){
				UnityEngine.Rect a1;
				checkValueType(l,1,out a1);
				UnityEngine.Texture a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				UnityEngine.Material a7;
				checkType(l,7,out a7);
				UnityEngine.Graphics.DrawTexture(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Rect),typeof(UnityEngine.Texture),typeof(int),typeof(int),typeof(int),typeof(int),typeof(UnityEngine.Material),typeof(int))){
				UnityEngine.Rect a1;
				checkValueType(l,1,out a1);
				UnityEngine.Texture a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				UnityEngine.Material a7;
				checkType(l,7,out a7);
				System.Int32 a8;
				checkType(l,8,out a8);
				UnityEngine.Graphics.DrawTexture(a1,a2,a3,a4,a5,a6,a7,a8);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Rect),typeof(UnityEngine.Texture),typeof(UnityEngine.Rect),typeof(int),typeof(int),typeof(int),typeof(int),typeof(UnityEngine.Color))){
				UnityEngine.Rect a1;
				checkValueType(l,1,out a1);
				UnityEngine.Texture a2;
				checkType(l,2,out a2);
				UnityEngine.Rect a3;
				checkValueType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				System.Int32 a7;
				checkType(l,7,out a7);
				UnityEngine.Color a8;
				checkType(l,8,out a8);
				UnityEngine.Graphics.DrawTexture(a1,a2,a3,a4,a5,a6,a7,a8);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Rect),typeof(UnityEngine.Texture),typeof(UnityEngine.Rect),typeof(int),typeof(int),typeof(int),typeof(int),typeof(UnityEngine.Material))){
				UnityEngine.Rect a1;
				checkValueType(l,1,out a1);
				UnityEngine.Texture a2;
				checkType(l,2,out a2);
				UnityEngine.Rect a3;
				checkValueType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				System.Int32 a7;
				checkType(l,7,out a7);
				UnityEngine.Material a8;
				checkType(l,8,out a8);
				UnityEngine.Graphics.DrawTexture(a1,a2,a3,a4,a5,a6,a7,a8);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Rect),typeof(UnityEngine.Texture),typeof(UnityEngine.Rect),typeof(int),typeof(int),typeof(int),typeof(int),typeof(UnityEngine.Material),typeof(int))){
				UnityEngine.Rect a1;
				checkValueType(l,1,out a1);
				UnityEngine.Texture a2;
				checkType(l,2,out a2);
				UnityEngine.Rect a3;
				checkValueType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				System.Int32 a7;
				checkType(l,7,out a7);
				UnityEngine.Material a8;
				checkType(l,8,out a8);
				System.Int32 a9;
				checkType(l,9,out a9);
				UnityEngine.Graphics.DrawTexture(a1,a2,a3,a4,a5,a6,a7,a8,a9);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Rect),typeof(UnityEngine.Texture),typeof(UnityEngine.Rect),typeof(int),typeof(int),typeof(int),typeof(int),typeof(UnityEngine.Color),typeof(UnityEngine.Material))){
				UnityEngine.Rect a1;
				checkValueType(l,1,out a1);
				UnityEngine.Texture a2;
				checkType(l,2,out a2);
				UnityEngine.Rect a3;
				checkValueType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				System.Int32 a7;
				checkType(l,7,out a7);
				UnityEngine.Color a8;
				checkType(l,8,out a8);
				UnityEngine.Material a9;
				checkType(l,9,out a9);
				UnityEngine.Graphics.DrawTexture(a1,a2,a3,a4,a5,a6,a7,a8,a9);
				pushValue(l,true);
				return 1;
			}
			else if(argc==10){
				UnityEngine.Rect a1;
				checkValueType(l,1,out a1);
				UnityEngine.Texture a2;
				checkType(l,2,out a2);
				UnityEngine.Rect a3;
				checkValueType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				System.Int32 a7;
				checkType(l,7,out a7);
				UnityEngine.Color a8;
				checkType(l,8,out a8);
				UnityEngine.Material a9;
				checkType(l,9,out a9);
				System.Int32 a10;
				checkType(l,10,out a10);
				UnityEngine.Graphics.DrawTexture(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function DrawTexture to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RenderMesh_s(IntPtr l) {
		try {
			UnityEngine.RenderParams a1;
			checkValueType(l,1,out a1);
			UnityEngine.Mesh a2;
			checkType(l,2,out a2);
			System.Int32 a3;
			checkType(l,3,out a3);
			UnityEngine.Matrix4x4 a4;
			checkValueType(l,4,out a4);
			System.Nullable<UnityEngine.Matrix4x4> a5;
			checkNullable(l,5,out a5);
			UnityEngine.Graphics.RenderMesh(in a1,a2,a3,a4,a5);
			pushValue(l,true);
			pushValue(l,a1);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RenderMeshIndirect_s(IntPtr l) {
		try {
			UnityEngine.RenderParams a1;
			checkValueType(l,1,out a1);
			UnityEngine.Mesh a2;
			checkType(l,2,out a2);
			UnityEngine.GraphicsBuffer a3;
			checkType(l,3,out a3);
			System.Int32 a4;
			checkType(l,4,out a4);
			System.Int32 a5;
			checkType(l,5,out a5);
			UnityEngine.Graphics.RenderMeshIndirect(in a1,a2,a3,a4,a5);
			pushValue(l,true);
			pushValue(l,a1);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RenderMeshPrimitives_s(IntPtr l) {
		try {
			UnityEngine.RenderParams a1;
			checkValueType(l,1,out a1);
			UnityEngine.Mesh a2;
			checkType(l,2,out a2);
			System.Int32 a3;
			checkType(l,3,out a3);
			System.Int32 a4;
			checkType(l,4,out a4);
			UnityEngine.Graphics.RenderMeshPrimitives(in a1,a2,a3,a4);
			pushValue(l,true);
			pushValue(l,a1);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RenderPrimitives_s(IntPtr l) {
		try {
			UnityEngine.RenderParams a1;
			checkValueType(l,1,out a1);
			UnityEngine.MeshTopology a2;
			a2 = (UnityEngine.MeshTopology)LuaDLL.luaL_checkinteger(l, 2);
			System.Int32 a3;
			checkType(l,3,out a3);
			System.Int32 a4;
			checkType(l,4,out a4);
			UnityEngine.Graphics.RenderPrimitives(in a1,a2,a3,a4);
			pushValue(l,true);
			pushValue(l,a1);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RenderPrimitivesIndexed_s(IntPtr l) {
		try {
			UnityEngine.RenderParams a1;
			checkValueType(l,1,out a1);
			UnityEngine.MeshTopology a2;
			a2 = (UnityEngine.MeshTopology)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.GraphicsBuffer a3;
			checkType(l,3,out a3);
			System.Int32 a4;
			checkType(l,4,out a4);
			System.Int32 a5;
			checkType(l,5,out a5);
			System.Int32 a6;
			checkType(l,6,out a6);
			UnityEngine.Graphics.RenderPrimitivesIndexed(in a1,a2,a3,a4,a5,a6);
			pushValue(l,true);
			pushValue(l,a1);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RenderPrimitivesIndirect_s(IntPtr l) {
		try {
			UnityEngine.RenderParams a1;
			checkValueType(l,1,out a1);
			UnityEngine.MeshTopology a2;
			a2 = (UnityEngine.MeshTopology)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.GraphicsBuffer a3;
			checkType(l,3,out a3);
			System.Int32 a4;
			checkType(l,4,out a4);
			System.Int32 a5;
			checkType(l,5,out a5);
			UnityEngine.Graphics.RenderPrimitivesIndirect(in a1,a2,a3,a4,a5);
			pushValue(l,true);
			pushValue(l,a1);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RenderPrimitivesIndexedIndirect_s(IntPtr l) {
		try {
			UnityEngine.RenderParams a1;
			checkValueType(l,1,out a1);
			UnityEngine.MeshTopology a2;
			a2 = (UnityEngine.MeshTopology)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.GraphicsBuffer a3;
			checkType(l,3,out a3);
			UnityEngine.GraphicsBuffer a4;
			checkType(l,4,out a4);
			System.Int32 a5;
			checkType(l,5,out a5);
			System.Int32 a6;
			checkType(l,6,out a6);
			UnityEngine.Graphics.RenderPrimitivesIndexedIndirect(in a1,a2,a3,a4,a5,a6);
			pushValue(l,true);
			pushValue(l,a1);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int DrawMeshNow_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Matrix4x4 a2;
				checkValueType(l,2,out a2);
				UnityEngine.Graphics.DrawMeshNow(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Matrix4x4),typeof(int))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Matrix4x4 a2;
				checkValueType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				UnityEngine.Graphics.DrawMeshNow(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Vector3),typeof(UnityEngine.Quaternion))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				UnityEngine.Quaternion a3;
				checkType(l,3,out a3);
				UnityEngine.Graphics.DrawMeshNow(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				UnityEngine.Quaternion a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Graphics.DrawMeshNow(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function DrawMeshNow to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int DrawMesh_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==4){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Matrix4x4 a2;
				checkValueType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Graphics.DrawMesh(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Matrix4x4),typeof(UnityEngine.Material),typeof(int),typeof(UnityEngine.Camera))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Matrix4x4 a2;
				checkValueType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Camera a5;
				checkType(l,5,out a5);
				UnityEngine.Graphics.DrawMesh(a1,a2,a3,a4,a5);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Vector3),typeof(UnityEngine.Quaternion),typeof(UnityEngine.Material),typeof(int))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				UnityEngine.Quaternion a3;
				checkType(l,3,out a3);
				UnityEngine.Material a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				UnityEngine.Graphics.DrawMesh(a1,a2,a3,a4,a5);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Matrix4x4),typeof(UnityEngine.Material),typeof(int),typeof(UnityEngine.Camera),typeof(int))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Matrix4x4 a2;
				checkValueType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Camera a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				UnityEngine.Graphics.DrawMesh(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Vector3),typeof(UnityEngine.Quaternion),typeof(UnityEngine.Material),typeof(int),typeof(UnityEngine.Camera))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				UnityEngine.Quaternion a3;
				checkType(l,3,out a3);
				UnityEngine.Material a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				UnityEngine.Camera a6;
				checkType(l,6,out a6);
				UnityEngine.Graphics.DrawMesh(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Vector3),typeof(UnityEngine.Quaternion),typeof(UnityEngine.Material),typeof(int),typeof(UnityEngine.Camera),typeof(int))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				UnityEngine.Quaternion a3;
				checkType(l,3,out a3);
				UnityEngine.Material a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				UnityEngine.Camera a6;
				checkType(l,6,out a6);
				System.Int32 a7;
				checkType(l,7,out a7);
				UnityEngine.Graphics.DrawMesh(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Matrix4x4),typeof(UnityEngine.Material),typeof(int),typeof(UnityEngine.Camera),typeof(int),typeof(UnityEngine.MaterialPropertyBlock))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Matrix4x4 a2;
				checkValueType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Camera a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				UnityEngine.MaterialPropertyBlock a7;
				checkType(l,7,out a7);
				UnityEngine.Graphics.DrawMesh(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Matrix4x4),typeof(UnityEngine.Material),typeof(int),typeof(UnityEngine.Camera),typeof(int),typeof(UnityEngine.MaterialPropertyBlock),typeof(bool))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Matrix4x4 a2;
				checkValueType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Camera a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				UnityEngine.MaterialPropertyBlock a7;
				checkType(l,7,out a7);
				System.Boolean a8;
				checkType(l,8,out a8);
				UnityEngine.Graphics.DrawMesh(a1,a2,a3,a4,a5,a6,a7,a8);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Vector3),typeof(UnityEngine.Quaternion),typeof(UnityEngine.Material),typeof(int),typeof(UnityEngine.Camera),typeof(int),typeof(UnityEngine.MaterialPropertyBlock))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				UnityEngine.Quaternion a3;
				checkType(l,3,out a3);
				UnityEngine.Material a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				UnityEngine.Camera a6;
				checkType(l,6,out a6);
				System.Int32 a7;
				checkType(l,7,out a7);
				UnityEngine.MaterialPropertyBlock a8;
				checkType(l,8,out a8);
				UnityEngine.Graphics.DrawMesh(a1,a2,a3,a4,a5,a6,a7,a8);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Matrix4x4),typeof(UnityEngine.Material),typeof(int),typeof(UnityEngine.Camera),typeof(int),typeof(UnityEngine.MaterialPropertyBlock),typeof(UnityEngine.Rendering.ShadowCastingMode))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Matrix4x4 a2;
				checkValueType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Camera a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				UnityEngine.MaterialPropertyBlock a7;
				checkType(l,7,out a7);
				UnityEngine.Rendering.ShadowCastingMode a8;
				a8 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 8);
				UnityEngine.Graphics.DrawMesh(a1,a2,a3,a4,a5,a6,a7,a8);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Matrix4x4),typeof(UnityEngine.Material),typeof(int),typeof(UnityEngine.Camera),typeof(int),typeof(UnityEngine.MaterialPropertyBlock),typeof(bool),typeof(bool))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Matrix4x4 a2;
				checkValueType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Camera a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				UnityEngine.MaterialPropertyBlock a7;
				checkType(l,7,out a7);
				System.Boolean a8;
				checkType(l,8,out a8);
				System.Boolean a9;
				checkType(l,9,out a9);
				UnityEngine.Graphics.DrawMesh(a1,a2,a3,a4,a5,a6,a7,a8,a9);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Vector3),typeof(UnityEngine.Quaternion),typeof(UnityEngine.Material),typeof(int),typeof(UnityEngine.Camera),typeof(int),typeof(UnityEngine.MaterialPropertyBlock),typeof(bool))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				UnityEngine.Quaternion a3;
				checkType(l,3,out a3);
				UnityEngine.Material a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				UnityEngine.Camera a6;
				checkType(l,6,out a6);
				System.Int32 a7;
				checkType(l,7,out a7);
				UnityEngine.MaterialPropertyBlock a8;
				checkType(l,8,out a8);
				System.Boolean a9;
				checkType(l,9,out a9);
				UnityEngine.Graphics.DrawMesh(a1,a2,a3,a4,a5,a6,a7,a8,a9);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Matrix4x4),typeof(UnityEngine.Material),typeof(int),typeof(UnityEngine.Camera),typeof(int),typeof(UnityEngine.MaterialPropertyBlock),typeof(UnityEngine.Rendering.ShadowCastingMode),typeof(bool))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Matrix4x4 a2;
				checkValueType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Camera a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				UnityEngine.MaterialPropertyBlock a7;
				checkType(l,7,out a7);
				UnityEngine.Rendering.ShadowCastingMode a8;
				a8 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 8);
				System.Boolean a9;
				checkType(l,9,out a9);
				UnityEngine.Graphics.DrawMesh(a1,a2,a3,a4,a5,a6,a7,a8,a9);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Vector3),typeof(UnityEngine.Quaternion),typeof(UnityEngine.Material),typeof(int),typeof(UnityEngine.Camera),typeof(int),typeof(UnityEngine.MaterialPropertyBlock),typeof(UnityEngine.Rendering.ShadowCastingMode))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				UnityEngine.Quaternion a3;
				checkType(l,3,out a3);
				UnityEngine.Material a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				UnityEngine.Camera a6;
				checkType(l,6,out a6);
				System.Int32 a7;
				checkType(l,7,out a7);
				UnityEngine.MaterialPropertyBlock a8;
				checkType(l,8,out a8);
				UnityEngine.Rendering.ShadowCastingMode a9;
				a9 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 9);
				UnityEngine.Graphics.DrawMesh(a1,a2,a3,a4,a5,a6,a7,a8,a9);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Vector3),typeof(UnityEngine.Quaternion),typeof(UnityEngine.Material),typeof(int),typeof(UnityEngine.Camera),typeof(int),typeof(UnityEngine.MaterialPropertyBlock),typeof(bool),typeof(bool))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				UnityEngine.Quaternion a3;
				checkType(l,3,out a3);
				UnityEngine.Material a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				UnityEngine.Camera a6;
				checkType(l,6,out a6);
				System.Int32 a7;
				checkType(l,7,out a7);
				UnityEngine.MaterialPropertyBlock a8;
				checkType(l,8,out a8);
				System.Boolean a9;
				checkType(l,9,out a9);
				System.Boolean a10;
				checkType(l,10,out a10);
				UnityEngine.Graphics.DrawMesh(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Matrix4x4),typeof(UnityEngine.Material),typeof(int),typeof(UnityEngine.Camera),typeof(int),typeof(UnityEngine.MaterialPropertyBlock),typeof(bool),typeof(bool),typeof(bool))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Matrix4x4 a2;
				checkValueType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Camera a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				UnityEngine.MaterialPropertyBlock a7;
				checkType(l,7,out a7);
				System.Boolean a8;
				checkType(l,8,out a8);
				System.Boolean a9;
				checkType(l,9,out a9);
				System.Boolean a10;
				checkType(l,10,out a10);
				UnityEngine.Graphics.DrawMesh(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Matrix4x4),typeof(UnityEngine.Material),typeof(int),typeof(UnityEngine.Camera),typeof(int),typeof(UnityEngine.MaterialPropertyBlock),typeof(UnityEngine.Rendering.ShadowCastingMode),typeof(bool),typeof(UnityEngine.Transform))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Matrix4x4 a2;
				checkValueType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Camera a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				UnityEngine.MaterialPropertyBlock a7;
				checkType(l,7,out a7);
				UnityEngine.Rendering.ShadowCastingMode a8;
				a8 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 8);
				System.Boolean a9;
				checkType(l,9,out a9);
				UnityEngine.Transform a10;
				checkType(l,10,out a10);
				UnityEngine.Graphics.DrawMesh(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Vector3),typeof(UnityEngine.Quaternion),typeof(UnityEngine.Material),typeof(int),typeof(UnityEngine.Camera),typeof(int),typeof(UnityEngine.MaterialPropertyBlock),typeof(UnityEngine.Rendering.ShadowCastingMode),typeof(bool))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				UnityEngine.Quaternion a3;
				checkType(l,3,out a3);
				UnityEngine.Material a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				UnityEngine.Camera a6;
				checkType(l,6,out a6);
				System.Int32 a7;
				checkType(l,7,out a7);
				UnityEngine.MaterialPropertyBlock a8;
				checkType(l,8,out a8);
				UnityEngine.Rendering.ShadowCastingMode a9;
				a9 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 9);
				System.Boolean a10;
				checkType(l,10,out a10);
				UnityEngine.Graphics.DrawMesh(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Vector3),typeof(UnityEngine.Quaternion),typeof(UnityEngine.Material),typeof(int),typeof(UnityEngine.Camera),typeof(int),typeof(UnityEngine.MaterialPropertyBlock),typeof(bool),typeof(bool),typeof(bool))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				UnityEngine.Quaternion a3;
				checkType(l,3,out a3);
				UnityEngine.Material a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				UnityEngine.Camera a6;
				checkType(l,6,out a6);
				System.Int32 a7;
				checkType(l,7,out a7);
				UnityEngine.MaterialPropertyBlock a8;
				checkType(l,8,out a8);
				System.Boolean a9;
				checkType(l,9,out a9);
				System.Boolean a10;
				checkType(l,10,out a10);
				System.Boolean a11;
				checkType(l,11,out a11);
				UnityEngine.Graphics.DrawMesh(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Matrix4x4),typeof(UnityEngine.Material),typeof(int),typeof(UnityEngine.Camera),typeof(int),typeof(UnityEngine.MaterialPropertyBlock),typeof(UnityEngine.Rendering.ShadowCastingMode),typeof(bool),typeof(UnityEngine.Transform),typeof(bool))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Matrix4x4 a2;
				checkValueType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Camera a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				UnityEngine.MaterialPropertyBlock a7;
				checkType(l,7,out a7);
				UnityEngine.Rendering.ShadowCastingMode a8;
				a8 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 8);
				System.Boolean a9;
				checkType(l,9,out a9);
				UnityEngine.Transform a10;
				checkType(l,10,out a10);
				System.Boolean a11;
				checkType(l,11,out a11);
				UnityEngine.Graphics.DrawMesh(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Vector3),typeof(UnityEngine.Quaternion),typeof(UnityEngine.Material),typeof(int),typeof(UnityEngine.Camera),typeof(int),typeof(UnityEngine.MaterialPropertyBlock),typeof(UnityEngine.Rendering.ShadowCastingMode),typeof(bool),typeof(UnityEngine.Transform))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				UnityEngine.Quaternion a3;
				checkType(l,3,out a3);
				UnityEngine.Material a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				UnityEngine.Camera a6;
				checkType(l,6,out a6);
				System.Int32 a7;
				checkType(l,7,out a7);
				UnityEngine.MaterialPropertyBlock a8;
				checkType(l,8,out a8);
				UnityEngine.Rendering.ShadowCastingMode a9;
				a9 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 9);
				System.Boolean a10;
				checkType(l,10,out a10);
				UnityEngine.Transform a11;
				checkType(l,11,out a11);
				UnityEngine.Graphics.DrawMesh(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Matrix4x4),typeof(UnityEngine.Material),typeof(int),typeof(UnityEngine.Camera),typeof(int),typeof(UnityEngine.MaterialPropertyBlock),typeof(UnityEngine.Rendering.ShadowCastingMode),typeof(bool),typeof(UnityEngine.Transform),typeof(UnityEngine.Rendering.LightProbeUsage))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Matrix4x4 a2;
				checkValueType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Camera a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				UnityEngine.MaterialPropertyBlock a7;
				checkType(l,7,out a7);
				UnityEngine.Rendering.ShadowCastingMode a8;
				a8 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 8);
				System.Boolean a9;
				checkType(l,9,out a9);
				UnityEngine.Transform a10;
				checkType(l,10,out a10);
				UnityEngine.Rendering.LightProbeUsage a11;
				a11 = (UnityEngine.Rendering.LightProbeUsage)LuaDLL.luaL_checkinteger(l, 11);
				UnityEngine.Graphics.DrawMesh(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Matrix4x4),typeof(UnityEngine.Material),typeof(int),typeof(UnityEngine.Camera),typeof(int),typeof(UnityEngine.MaterialPropertyBlock),typeof(UnityEngine.Rendering.ShadowCastingMode),typeof(bool),typeof(UnityEngine.Transform),typeof(UnityEngine.Rendering.LightProbeUsage),typeof(UnityEngine.LightProbeProxyVolume))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Matrix4x4 a2;
				checkValueType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Camera a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				UnityEngine.MaterialPropertyBlock a7;
				checkType(l,7,out a7);
				UnityEngine.Rendering.ShadowCastingMode a8;
				a8 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 8);
				System.Boolean a9;
				checkType(l,9,out a9);
				UnityEngine.Transform a10;
				checkType(l,10,out a10);
				UnityEngine.Rendering.LightProbeUsage a11;
				a11 = (UnityEngine.Rendering.LightProbeUsage)LuaDLL.luaL_checkinteger(l, 11);
				UnityEngine.LightProbeProxyVolume a12;
				checkType(l,12,out a12);
				UnityEngine.Graphics.DrawMesh(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11,a12);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(UnityEngine.Vector3),typeof(UnityEngine.Quaternion),typeof(UnityEngine.Material),typeof(int),typeof(UnityEngine.Camera),typeof(int),typeof(UnityEngine.MaterialPropertyBlock),typeof(UnityEngine.Rendering.ShadowCastingMode),typeof(bool),typeof(UnityEngine.Transform),typeof(bool))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				UnityEngine.Quaternion a3;
				checkType(l,3,out a3);
				UnityEngine.Material a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				UnityEngine.Camera a6;
				checkType(l,6,out a6);
				System.Int32 a7;
				checkType(l,7,out a7);
				UnityEngine.MaterialPropertyBlock a8;
				checkType(l,8,out a8);
				UnityEngine.Rendering.ShadowCastingMode a9;
				a9 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 9);
				System.Boolean a10;
				checkType(l,10,out a10);
				UnityEngine.Transform a11;
				checkType(l,11,out a11);
				System.Boolean a12;
				checkType(l,12,out a12);
				UnityEngine.Graphics.DrawMesh(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11,a12);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function DrawMesh to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int DrawMeshInstanced_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(int),typeof(UnityEngine.Material),typeof(UnityEngine.Matrix4x4[]))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				UnityEngine.Matrix4x4[] a4;
				checkArray(l,4,out a4);
				UnityEngine.Graphics.DrawMeshInstanced(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(int),typeof(UnityEngine.Material),typeof(List<UnityEngine.Matrix4x4>))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				System.Collections.Generic.List<UnityEngine.Matrix4x4> a4;
				checkType(l,4,out a4);
				UnityEngine.Graphics.DrawMeshInstanced(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(int),typeof(UnityEngine.Material),typeof(UnityEngine.Matrix4x4[]),typeof(int))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				UnityEngine.Matrix4x4[] a4;
				checkArray(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				UnityEngine.Graphics.DrawMeshInstanced(a1,a2,a3,a4,a5);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(int),typeof(UnityEngine.Material),typeof(List<UnityEngine.Matrix4x4>),typeof(UnityEngine.MaterialPropertyBlock))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				System.Collections.Generic.List<UnityEngine.Matrix4x4> a4;
				checkType(l,4,out a4);
				UnityEngine.MaterialPropertyBlock a5;
				checkType(l,5,out a5);
				UnityEngine.Graphics.DrawMeshInstanced(a1,a2,a3,a4,a5);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(int),typeof(UnityEngine.Material),typeof(UnityEngine.Matrix4x4[]),typeof(int),typeof(UnityEngine.MaterialPropertyBlock))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				UnityEngine.Matrix4x4[] a4;
				checkArray(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				UnityEngine.MaterialPropertyBlock a6;
				checkType(l,6,out a6);
				UnityEngine.Graphics.DrawMeshInstanced(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(int),typeof(UnityEngine.Material),typeof(List<UnityEngine.Matrix4x4>),typeof(UnityEngine.MaterialPropertyBlock),typeof(UnityEngine.Rendering.ShadowCastingMode))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				System.Collections.Generic.List<UnityEngine.Matrix4x4> a4;
				checkType(l,4,out a4);
				UnityEngine.MaterialPropertyBlock a5;
				checkType(l,5,out a5);
				UnityEngine.Rendering.ShadowCastingMode a6;
				a6 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 6);
				UnityEngine.Graphics.DrawMeshInstanced(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(int),typeof(UnityEngine.Material),typeof(UnityEngine.Matrix4x4[]),typeof(int),typeof(UnityEngine.MaterialPropertyBlock),typeof(UnityEngine.Rendering.ShadowCastingMode))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				UnityEngine.Matrix4x4[] a4;
				checkArray(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				UnityEngine.MaterialPropertyBlock a6;
				checkType(l,6,out a6);
				UnityEngine.Rendering.ShadowCastingMode a7;
				a7 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 7);
				UnityEngine.Graphics.DrawMeshInstanced(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(int),typeof(UnityEngine.Material),typeof(List<UnityEngine.Matrix4x4>),typeof(UnityEngine.MaterialPropertyBlock),typeof(UnityEngine.Rendering.ShadowCastingMode),typeof(bool))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				System.Collections.Generic.List<UnityEngine.Matrix4x4> a4;
				checkType(l,4,out a4);
				UnityEngine.MaterialPropertyBlock a5;
				checkType(l,5,out a5);
				UnityEngine.Rendering.ShadowCastingMode a6;
				a6 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 6);
				System.Boolean a7;
				checkType(l,7,out a7);
				UnityEngine.Graphics.DrawMeshInstanced(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(int),typeof(UnityEngine.Material),typeof(List<UnityEngine.Matrix4x4>),typeof(UnityEngine.MaterialPropertyBlock),typeof(UnityEngine.Rendering.ShadowCastingMode),typeof(bool),typeof(int))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				System.Collections.Generic.List<UnityEngine.Matrix4x4> a4;
				checkType(l,4,out a4);
				UnityEngine.MaterialPropertyBlock a5;
				checkType(l,5,out a5);
				UnityEngine.Rendering.ShadowCastingMode a6;
				a6 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 6);
				System.Boolean a7;
				checkType(l,7,out a7);
				System.Int32 a8;
				checkType(l,8,out a8);
				UnityEngine.Graphics.DrawMeshInstanced(a1,a2,a3,a4,a5,a6,a7,a8);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(int),typeof(UnityEngine.Material),typeof(UnityEngine.Matrix4x4[]),typeof(int),typeof(UnityEngine.MaterialPropertyBlock),typeof(UnityEngine.Rendering.ShadowCastingMode),typeof(bool))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				UnityEngine.Matrix4x4[] a4;
				checkArray(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				UnityEngine.MaterialPropertyBlock a6;
				checkType(l,6,out a6);
				UnityEngine.Rendering.ShadowCastingMode a7;
				a7 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 7);
				System.Boolean a8;
				checkType(l,8,out a8);
				UnityEngine.Graphics.DrawMeshInstanced(a1,a2,a3,a4,a5,a6,a7,a8);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(int),typeof(UnityEngine.Material),typeof(UnityEngine.Matrix4x4[]),typeof(int),typeof(UnityEngine.MaterialPropertyBlock),typeof(UnityEngine.Rendering.ShadowCastingMode),typeof(bool),typeof(int))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				UnityEngine.Matrix4x4[] a4;
				checkArray(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				UnityEngine.MaterialPropertyBlock a6;
				checkType(l,6,out a6);
				UnityEngine.Rendering.ShadowCastingMode a7;
				a7 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 7);
				System.Boolean a8;
				checkType(l,8,out a8);
				System.Int32 a9;
				checkType(l,9,out a9);
				UnityEngine.Graphics.DrawMeshInstanced(a1,a2,a3,a4,a5,a6,a7,a8,a9);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(int),typeof(UnityEngine.Material),typeof(List<UnityEngine.Matrix4x4>),typeof(UnityEngine.MaterialPropertyBlock),typeof(UnityEngine.Rendering.ShadowCastingMode),typeof(bool),typeof(int),typeof(UnityEngine.Camera))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				System.Collections.Generic.List<UnityEngine.Matrix4x4> a4;
				checkType(l,4,out a4);
				UnityEngine.MaterialPropertyBlock a5;
				checkType(l,5,out a5);
				UnityEngine.Rendering.ShadowCastingMode a6;
				a6 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 6);
				System.Boolean a7;
				checkType(l,7,out a7);
				System.Int32 a8;
				checkType(l,8,out a8);
				UnityEngine.Camera a9;
				checkType(l,9,out a9);
				UnityEngine.Graphics.DrawMeshInstanced(a1,a2,a3,a4,a5,a6,a7,a8,a9);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(int),typeof(UnityEngine.Material),typeof(UnityEngine.Matrix4x4[]),typeof(int),typeof(UnityEngine.MaterialPropertyBlock),typeof(UnityEngine.Rendering.ShadowCastingMode),typeof(bool),typeof(int),typeof(UnityEngine.Camera))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				UnityEngine.Matrix4x4[] a4;
				checkArray(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				UnityEngine.MaterialPropertyBlock a6;
				checkType(l,6,out a6);
				UnityEngine.Rendering.ShadowCastingMode a7;
				a7 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 7);
				System.Boolean a8;
				checkType(l,8,out a8);
				System.Int32 a9;
				checkType(l,9,out a9);
				UnityEngine.Camera a10;
				checkType(l,10,out a10);
				UnityEngine.Graphics.DrawMeshInstanced(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(int),typeof(UnityEngine.Material),typeof(List<UnityEngine.Matrix4x4>),typeof(UnityEngine.MaterialPropertyBlock),typeof(UnityEngine.Rendering.ShadowCastingMode),typeof(bool),typeof(int),typeof(UnityEngine.Camera),typeof(UnityEngine.Rendering.LightProbeUsage))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				System.Collections.Generic.List<UnityEngine.Matrix4x4> a4;
				checkType(l,4,out a4);
				UnityEngine.MaterialPropertyBlock a5;
				checkType(l,5,out a5);
				UnityEngine.Rendering.ShadowCastingMode a6;
				a6 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 6);
				System.Boolean a7;
				checkType(l,7,out a7);
				System.Int32 a8;
				checkType(l,8,out a8);
				UnityEngine.Camera a9;
				checkType(l,9,out a9);
				UnityEngine.Rendering.LightProbeUsage a10;
				a10 = (UnityEngine.Rendering.LightProbeUsage)LuaDLL.luaL_checkinteger(l, 10);
				UnityEngine.Graphics.DrawMeshInstanced(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(int),typeof(UnityEngine.Material),typeof(List<UnityEngine.Matrix4x4>),typeof(UnityEngine.MaterialPropertyBlock),typeof(UnityEngine.Rendering.ShadowCastingMode),typeof(bool),typeof(int),typeof(UnityEngine.Camera),typeof(UnityEngine.Rendering.LightProbeUsage),typeof(UnityEngine.LightProbeProxyVolume))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				System.Collections.Generic.List<UnityEngine.Matrix4x4> a4;
				checkType(l,4,out a4);
				UnityEngine.MaterialPropertyBlock a5;
				checkType(l,5,out a5);
				UnityEngine.Rendering.ShadowCastingMode a6;
				a6 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 6);
				System.Boolean a7;
				checkType(l,7,out a7);
				System.Int32 a8;
				checkType(l,8,out a8);
				UnityEngine.Camera a9;
				checkType(l,9,out a9);
				UnityEngine.Rendering.LightProbeUsage a10;
				a10 = (UnityEngine.Rendering.LightProbeUsage)LuaDLL.luaL_checkinteger(l, 10);
				UnityEngine.LightProbeProxyVolume a11;
				checkType(l,11,out a11);
				UnityEngine.Graphics.DrawMeshInstanced(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(int),typeof(UnityEngine.Material),typeof(UnityEngine.Matrix4x4[]),typeof(int),typeof(UnityEngine.MaterialPropertyBlock),typeof(UnityEngine.Rendering.ShadowCastingMode),typeof(bool),typeof(int),typeof(UnityEngine.Camera),typeof(UnityEngine.Rendering.LightProbeUsage))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				UnityEngine.Matrix4x4[] a4;
				checkArray(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				UnityEngine.MaterialPropertyBlock a6;
				checkType(l,6,out a6);
				UnityEngine.Rendering.ShadowCastingMode a7;
				a7 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 7);
				System.Boolean a8;
				checkType(l,8,out a8);
				System.Int32 a9;
				checkType(l,9,out a9);
				UnityEngine.Camera a10;
				checkType(l,10,out a10);
				UnityEngine.Rendering.LightProbeUsage a11;
				a11 = (UnityEngine.Rendering.LightProbeUsage)LuaDLL.luaL_checkinteger(l, 11);
				UnityEngine.Graphics.DrawMeshInstanced(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11);
				pushValue(l,true);
				return 1;
			}
			else if(argc==12){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				UnityEngine.Matrix4x4[] a4;
				checkArray(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				UnityEngine.MaterialPropertyBlock a6;
				checkType(l,6,out a6);
				UnityEngine.Rendering.ShadowCastingMode a7;
				a7 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 7);
				System.Boolean a8;
				checkType(l,8,out a8);
				System.Int32 a9;
				checkType(l,9,out a9);
				UnityEngine.Camera a10;
				checkType(l,10,out a10);
				UnityEngine.Rendering.LightProbeUsage a11;
				a11 = (UnityEngine.Rendering.LightProbeUsage)LuaDLL.luaL_checkinteger(l, 11);
				UnityEngine.LightProbeProxyVolume a12;
				checkType(l,12,out a12);
				UnityEngine.Graphics.DrawMeshInstanced(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11,a12);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function DrawMeshInstanced to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int DrawMeshInstancedProcedural_s(IntPtr l) {
		try {
			UnityEngine.Mesh a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			UnityEngine.Material a3;
			checkType(l,3,out a3);
			UnityEngine.Bounds a4;
			checkValueType(l,4,out a4);
			System.Int32 a5;
			checkType(l,5,out a5);
			UnityEngine.MaterialPropertyBlock a6;
			checkType(l,6,out a6);
			UnityEngine.Rendering.ShadowCastingMode a7;
			a7 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 7);
			System.Boolean a8;
			checkType(l,8,out a8);
			System.Int32 a9;
			checkType(l,9,out a9);
			UnityEngine.Camera a10;
			checkType(l,10,out a10);
			UnityEngine.Rendering.LightProbeUsage a11;
			a11 = (UnityEngine.Rendering.LightProbeUsage)LuaDLL.luaL_checkinteger(l, 11);
			UnityEngine.LightProbeProxyVolume a12;
			checkType(l,12,out a12);
			UnityEngine.Graphics.DrawMeshInstancedProcedural(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11,a12);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int DrawMeshInstancedIndirect_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(int),typeof(UnityEngine.Material),typeof(UnityEngine.Bounds),typeof(UnityEngine.ComputeBuffer),typeof(int),typeof(UnityEngine.MaterialPropertyBlock),typeof(UnityEngine.Rendering.ShadowCastingMode),typeof(bool),typeof(int),typeof(UnityEngine.Camera),typeof(UnityEngine.Rendering.LightProbeUsage))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				UnityEngine.Bounds a4;
				checkValueType(l,4,out a4);
				UnityEngine.ComputeBuffer a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				UnityEngine.MaterialPropertyBlock a7;
				checkType(l,7,out a7);
				UnityEngine.Rendering.ShadowCastingMode a8;
				a8 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 8);
				System.Boolean a9;
				checkType(l,9,out a9);
				System.Int32 a10;
				checkType(l,10,out a10);
				UnityEngine.Camera a11;
				checkType(l,11,out a11);
				UnityEngine.Rendering.LightProbeUsage a12;
				a12 = (UnityEngine.Rendering.LightProbeUsage)LuaDLL.luaL_checkinteger(l, 12);
				UnityEngine.Graphics.DrawMeshInstancedIndirect(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11,a12);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(int),typeof(UnityEngine.Material),typeof(UnityEngine.Bounds),typeof(UnityEngine.GraphicsBuffer),typeof(int),typeof(UnityEngine.MaterialPropertyBlock),typeof(UnityEngine.Rendering.ShadowCastingMode),typeof(bool),typeof(int),typeof(UnityEngine.Camera),typeof(UnityEngine.Rendering.LightProbeUsage))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				UnityEngine.Bounds a4;
				checkValueType(l,4,out a4);
				UnityEngine.GraphicsBuffer a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				UnityEngine.MaterialPropertyBlock a7;
				checkType(l,7,out a7);
				UnityEngine.Rendering.ShadowCastingMode a8;
				a8 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 8);
				System.Boolean a9;
				checkType(l,9,out a9);
				System.Int32 a10;
				checkType(l,10,out a10);
				UnityEngine.Camera a11;
				checkType(l,11,out a11);
				UnityEngine.Rendering.LightProbeUsage a12;
				a12 = (UnityEngine.Rendering.LightProbeUsage)LuaDLL.luaL_checkinteger(l, 12);
				UnityEngine.Graphics.DrawMeshInstancedIndirect(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11,a12);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(int),typeof(UnityEngine.Material),typeof(UnityEngine.Bounds),typeof(UnityEngine.ComputeBuffer),typeof(int),typeof(UnityEngine.MaterialPropertyBlock),typeof(UnityEngine.Rendering.ShadowCastingMode),typeof(bool),typeof(int),typeof(UnityEngine.Camera),typeof(UnityEngine.Rendering.LightProbeUsage),typeof(UnityEngine.LightProbeProxyVolume))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				UnityEngine.Bounds a4;
				checkValueType(l,4,out a4);
				UnityEngine.ComputeBuffer a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				UnityEngine.MaterialPropertyBlock a7;
				checkType(l,7,out a7);
				UnityEngine.Rendering.ShadowCastingMode a8;
				a8 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 8);
				System.Boolean a9;
				checkType(l,9,out a9);
				System.Int32 a10;
				checkType(l,10,out a10);
				UnityEngine.Camera a11;
				checkType(l,11,out a11);
				UnityEngine.Rendering.LightProbeUsage a12;
				a12 = (UnityEngine.Rendering.LightProbeUsage)LuaDLL.luaL_checkinteger(l, 12);
				UnityEngine.LightProbeProxyVolume a13;
				checkType(l,13,out a13);
				UnityEngine.Graphics.DrawMeshInstancedIndirect(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11,a12,a13);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Mesh),typeof(int),typeof(UnityEngine.Material),typeof(UnityEngine.Bounds),typeof(UnityEngine.GraphicsBuffer),typeof(int),typeof(UnityEngine.MaterialPropertyBlock),typeof(UnityEngine.Rendering.ShadowCastingMode),typeof(bool),typeof(int),typeof(UnityEngine.Camera),typeof(UnityEngine.Rendering.LightProbeUsage),typeof(UnityEngine.LightProbeProxyVolume))){
				UnityEngine.Mesh a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				UnityEngine.Bounds a4;
				checkValueType(l,4,out a4);
				UnityEngine.GraphicsBuffer a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				UnityEngine.MaterialPropertyBlock a7;
				checkType(l,7,out a7);
				UnityEngine.Rendering.ShadowCastingMode a8;
				a8 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 8);
				System.Boolean a9;
				checkType(l,9,out a9);
				System.Int32 a10;
				checkType(l,10,out a10);
				UnityEngine.Camera a11;
				checkType(l,11,out a11);
				UnityEngine.Rendering.LightProbeUsage a12;
				a12 = (UnityEngine.Rendering.LightProbeUsage)LuaDLL.luaL_checkinteger(l, 12);
				UnityEngine.LightProbeProxyVolume a13;
				checkType(l,13,out a13);
				UnityEngine.Graphics.DrawMeshInstancedIndirect(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11,a12,a13);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function DrawMeshInstancedIndirect to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int DrawProceduralNow_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.MeshTopology a1;
				a1 = (UnityEngine.MeshTopology)LuaDLL.luaL_checkinteger(l, 1);
				System.Int32 a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				UnityEngine.Graphics.DrawProceduralNow(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(argc==4){
				UnityEngine.MeshTopology a1;
				a1 = (UnityEngine.MeshTopology)LuaDLL.luaL_checkinteger(l, 1);
				UnityEngine.GraphicsBuffer a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Graphics.DrawProceduralNow(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function DrawProceduralNow to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int DrawProceduralIndirectNow_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.MeshTopology),typeof(UnityEngine.ComputeBuffer),typeof(int))){
				UnityEngine.MeshTopology a1;
				a1 = (UnityEngine.MeshTopology)LuaDLL.luaL_checkinteger(l, 1);
				UnityEngine.ComputeBuffer a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				UnityEngine.Graphics.DrawProceduralIndirectNow(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.MeshTopology),typeof(UnityEngine.GraphicsBuffer),typeof(int))){
				UnityEngine.MeshTopology a1;
				a1 = (UnityEngine.MeshTopology)LuaDLL.luaL_checkinteger(l, 1);
				UnityEngine.GraphicsBuffer a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				UnityEngine.Graphics.DrawProceduralIndirectNow(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.MeshTopology),typeof(UnityEngine.GraphicsBuffer),typeof(UnityEngine.ComputeBuffer),typeof(int))){
				UnityEngine.MeshTopology a1;
				a1 = (UnityEngine.MeshTopology)LuaDLL.luaL_checkinteger(l, 1);
				UnityEngine.GraphicsBuffer a2;
				checkType(l,2,out a2);
				UnityEngine.ComputeBuffer a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Graphics.DrawProceduralIndirectNow(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.MeshTopology),typeof(UnityEngine.GraphicsBuffer),typeof(UnityEngine.GraphicsBuffer),typeof(int))){
				UnityEngine.MeshTopology a1;
				a1 = (UnityEngine.MeshTopology)LuaDLL.luaL_checkinteger(l, 1);
				UnityEngine.GraphicsBuffer a2;
				checkType(l,2,out a2);
				UnityEngine.GraphicsBuffer a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Graphics.DrawProceduralIndirectNow(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function DrawProceduralIndirectNow to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int DrawProcedural_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==10){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				UnityEngine.Bounds a2;
				checkValueType(l,2,out a2);
				UnityEngine.MeshTopology a3;
				a3 = (UnityEngine.MeshTopology)LuaDLL.luaL_checkinteger(l, 3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				UnityEngine.Camera a6;
				checkType(l,6,out a6);
				UnityEngine.MaterialPropertyBlock a7;
				checkType(l,7,out a7);
				UnityEngine.Rendering.ShadowCastingMode a8;
				a8 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 8);
				System.Boolean a9;
				checkType(l,9,out a9);
				System.Int32 a10;
				checkType(l,10,out a10);
				UnityEngine.Graphics.DrawProcedural(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10);
				pushValue(l,true);
				return 1;
			}
			else if(argc==11){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				UnityEngine.Bounds a2;
				checkValueType(l,2,out a2);
				UnityEngine.MeshTopology a3;
				a3 = (UnityEngine.MeshTopology)LuaDLL.luaL_checkinteger(l, 3);
				UnityEngine.GraphicsBuffer a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				UnityEngine.Camera a7;
				checkType(l,7,out a7);
				UnityEngine.MaterialPropertyBlock a8;
				checkType(l,8,out a8);
				UnityEngine.Rendering.ShadowCastingMode a9;
				a9 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 9);
				System.Boolean a10;
				checkType(l,10,out a10);
				System.Int32 a11;
				checkType(l,11,out a11);
				UnityEngine.Graphics.DrawProcedural(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function DrawProcedural to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int DrawProceduralIndirect_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Material),typeof(UnityEngine.Bounds),typeof(UnityEngine.MeshTopology),typeof(UnityEngine.ComputeBuffer),typeof(int),typeof(UnityEngine.Camera),typeof(UnityEngine.MaterialPropertyBlock),typeof(UnityEngine.Rendering.ShadowCastingMode),typeof(bool),typeof(int))){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				UnityEngine.Bounds a2;
				checkValueType(l,2,out a2);
				UnityEngine.MeshTopology a3;
				a3 = (UnityEngine.MeshTopology)LuaDLL.luaL_checkinteger(l, 3);
				UnityEngine.ComputeBuffer a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				UnityEngine.Camera a6;
				checkType(l,6,out a6);
				UnityEngine.MaterialPropertyBlock a7;
				checkType(l,7,out a7);
				UnityEngine.Rendering.ShadowCastingMode a8;
				a8 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 8);
				System.Boolean a9;
				checkType(l,9,out a9);
				System.Int32 a10;
				checkType(l,10,out a10);
				UnityEngine.Graphics.DrawProceduralIndirect(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Material),typeof(UnityEngine.Bounds),typeof(UnityEngine.MeshTopology),typeof(UnityEngine.GraphicsBuffer),typeof(int),typeof(UnityEngine.Camera),typeof(UnityEngine.MaterialPropertyBlock),typeof(UnityEngine.Rendering.ShadowCastingMode),typeof(bool),typeof(int))){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				UnityEngine.Bounds a2;
				checkValueType(l,2,out a2);
				UnityEngine.MeshTopology a3;
				a3 = (UnityEngine.MeshTopology)LuaDLL.luaL_checkinteger(l, 3);
				UnityEngine.GraphicsBuffer a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				UnityEngine.Camera a6;
				checkType(l,6,out a6);
				UnityEngine.MaterialPropertyBlock a7;
				checkType(l,7,out a7);
				UnityEngine.Rendering.ShadowCastingMode a8;
				a8 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 8);
				System.Boolean a9;
				checkType(l,9,out a9);
				System.Int32 a10;
				checkType(l,10,out a10);
				UnityEngine.Graphics.DrawProceduralIndirect(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Material),typeof(UnityEngine.Bounds),typeof(UnityEngine.MeshTopology),typeof(UnityEngine.GraphicsBuffer),typeof(UnityEngine.ComputeBuffer),typeof(int),typeof(UnityEngine.Camera),typeof(UnityEngine.MaterialPropertyBlock),typeof(UnityEngine.Rendering.ShadowCastingMode),typeof(bool),typeof(int))){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				UnityEngine.Bounds a2;
				checkValueType(l,2,out a2);
				UnityEngine.MeshTopology a3;
				a3 = (UnityEngine.MeshTopology)LuaDLL.luaL_checkinteger(l, 3);
				UnityEngine.GraphicsBuffer a4;
				checkType(l,4,out a4);
				UnityEngine.ComputeBuffer a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				UnityEngine.Camera a7;
				checkType(l,7,out a7);
				UnityEngine.MaterialPropertyBlock a8;
				checkType(l,8,out a8);
				UnityEngine.Rendering.ShadowCastingMode a9;
				a9 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 9);
				System.Boolean a10;
				checkType(l,10,out a10);
				System.Int32 a11;
				checkType(l,11,out a11);
				UnityEngine.Graphics.DrawProceduralIndirect(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Material),typeof(UnityEngine.Bounds),typeof(UnityEngine.MeshTopology),typeof(UnityEngine.GraphicsBuffer),typeof(UnityEngine.GraphicsBuffer),typeof(int),typeof(UnityEngine.Camera),typeof(UnityEngine.MaterialPropertyBlock),typeof(UnityEngine.Rendering.ShadowCastingMode),typeof(bool),typeof(int))){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				UnityEngine.Bounds a2;
				checkValueType(l,2,out a2);
				UnityEngine.MeshTopology a3;
				a3 = (UnityEngine.MeshTopology)LuaDLL.luaL_checkinteger(l, 3);
				UnityEngine.GraphicsBuffer a4;
				checkType(l,4,out a4);
				UnityEngine.GraphicsBuffer a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				UnityEngine.Camera a7;
				checkType(l,7,out a7);
				UnityEngine.MaterialPropertyBlock a8;
				checkType(l,8,out a8);
				UnityEngine.Rendering.ShadowCastingMode a9;
				a9 = (UnityEngine.Rendering.ShadowCastingMode)LuaDLL.luaL_checkinteger(l, 9);
				System.Boolean a10;
				checkType(l,10,out a10);
				System.Int32 a11;
				checkType(l,11,out a11);
				UnityEngine.Graphics.DrawProceduralIndirect(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function DrawProceduralIndirect to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Blit_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Texture),typeof(UnityEngine.RenderTexture))){
				UnityEngine.Texture a1;
				checkType(l,1,out a1);
				UnityEngine.RenderTexture a2;
				checkType(l,2,out a2);
				UnityEngine.Graphics.Blit(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Texture),typeof(UnityEngine.Material))){
				UnityEngine.Texture a1;
				checkType(l,1,out a1);
				UnityEngine.Material a2;
				checkType(l,2,out a2);
				UnityEngine.Graphics.Blit(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Texture),typeof(UnityEngine.RenderTexture),typeof(UnityEngine.Material))){
				UnityEngine.Texture a1;
				checkType(l,1,out a1);
				UnityEngine.RenderTexture a2;
				checkType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				UnityEngine.Graphics.Blit(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Texture),typeof(UnityEngine.Material),typeof(int))){
				UnityEngine.Texture a1;
				checkType(l,1,out a1);
				UnityEngine.Material a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				UnityEngine.Graphics.Blit(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Texture),typeof(UnityEngine.RenderTexture),typeof(int),typeof(int))){
				UnityEngine.Texture a1;
				checkType(l,1,out a1);
				UnityEngine.RenderTexture a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Graphics.Blit(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Texture),typeof(UnityEngine.RenderTexture),typeof(UnityEngine.Vector2),typeof(UnityEngine.Vector2))){
				UnityEngine.Texture a1;
				checkType(l,1,out a1);
				UnityEngine.RenderTexture a2;
				checkType(l,2,out a2);
				UnityEngine.Vector2 a3;
				checkType(l,3,out a3);
				UnityEngine.Vector2 a4;
				checkType(l,4,out a4);
				UnityEngine.Graphics.Blit(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Texture),typeof(UnityEngine.RenderTexture),typeof(UnityEngine.Material),typeof(int))){
				UnityEngine.Texture a1;
				checkType(l,1,out a1);
				UnityEngine.RenderTexture a2;
				checkType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Graphics.Blit(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Texture),typeof(UnityEngine.Material),typeof(int),typeof(int))){
				UnityEngine.Texture a1;
				checkType(l,1,out a1);
				UnityEngine.Material a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Graphics.Blit(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Texture a1;
				checkType(l,1,out a1);
				UnityEngine.RenderTexture a2;
				checkType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				UnityEngine.Graphics.Blit(a1,a2,a3,a4,a5);
				pushValue(l,true);
				return 1;
			}
			else if(argc==6){
				UnityEngine.Texture a1;
				checkType(l,1,out a1);
				UnityEngine.RenderTexture a2;
				checkType(l,2,out a2);
				UnityEngine.Vector2 a3;
				checkType(l,3,out a3);
				UnityEngine.Vector2 a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				System.Int32 a6;
				checkType(l,6,out a6);
				UnityEngine.Graphics.Blit(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Blit to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int BlitMultiTap_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==4){
				UnityEngine.Texture a1;
				checkType(l,1,out a1);
				UnityEngine.RenderTexture a2;
				checkType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				UnityEngine.Vector2[] a4;
				checkParams(l,4,out a4);
				UnityEngine.Graphics.BlitMultiTap(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Texture a1;
				checkType(l,1,out a1);
				UnityEngine.RenderTexture a2;
				checkType(l,2,out a2);
				UnityEngine.Material a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Vector2[] a5;
				checkParams(l,5,out a5);
				UnityEngine.Graphics.BlitMultiTap(a1,a2,a3,a4,a5);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function BlitMultiTap to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_activeColorGamut(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UnityEngine.Graphics.activeColorGamut);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_activeTier(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UnityEngine.Graphics.activeTier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_activeTier(IntPtr l) {
		try {
			UnityEngine.Rendering.GraphicsTier v;
			v = (UnityEngine.Rendering.GraphicsTier)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.Graphics.activeTier=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_preserveFramebufferAlpha(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Graphics.preserveFramebufferAlpha);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_minOpenGLESVersion(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UnityEngine.Graphics.minOpenGLESVersion);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_activeColorBuffer(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Graphics.activeColorBuffer);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_activeDepthBuffer(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Graphics.activeDepthBuffer);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Graphics");
		addMember(l,ClearRandomWriteTargets_s);
		addMember(l,ExecuteCommandBuffer_s);
		addMember(l,ExecuteCommandBufferAsync_s);
		addMember(l,SetRenderTarget_s);
		addMember(l,SetRandomWriteTarget_s);
		addMember(l,CopyTexture_s);
		addMember(l,ConvertTexture_s);
		addMember(l,CreateAsyncGraphicsFence_s);
		addMember(l,CreateGraphicsFence_s);
		addMember(l,WaitOnAsyncGraphicsFence_s);
		addMember(l,CopyBuffer_s);
		addMember(l,DrawTexture_s);
		addMember(l,RenderMesh_s);
		addMember(l,RenderMeshIndirect_s);
		addMember(l,RenderMeshPrimitives_s);
		addMember(l,RenderPrimitives_s);
		addMember(l,RenderPrimitivesIndexed_s);
		addMember(l,RenderPrimitivesIndirect_s);
		addMember(l,RenderPrimitivesIndexedIndirect_s);
		addMember(l,DrawMeshNow_s);
		addMember(l,DrawMesh_s);
		addMember(l,DrawMeshInstanced_s);
		addMember(l,DrawMeshInstancedProcedural_s);
		addMember(l,DrawMeshInstancedIndirect_s);
		addMember(l,DrawProceduralNow_s);
		addMember(l,DrawProceduralIndirectNow_s);
		addMember(l,DrawProcedural_s);
		addMember(l,DrawProceduralIndirect_s);
		addMember(l,Blit_s);
		addMember(l,BlitMultiTap_s);
		addMember(l,"activeColorGamut",get_activeColorGamut,null,false);
		addMember(l,"activeTier",get_activeTier,set_activeTier,false);
		addMember(l,"preserveFramebufferAlpha",get_preserveFramebufferAlpha,null,false);
		addMember(l,"minOpenGLESVersion",get_minOpenGLESVersion,null,false);
		addMember(l,"activeColorBuffer",get_activeColorBuffer,null,false);
		addMember(l,"activeDepthBuffer",get_activeDepthBuffer,null,false);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Graphics));
	}
}
