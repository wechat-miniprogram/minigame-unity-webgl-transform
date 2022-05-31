using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Shader : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetDependency(IntPtr l) {
		try {
			UnityEngine.Shader self=(UnityEngine.Shader)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.GetDependency(a1);
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
	static public int GetPassCountInSubshader(IntPtr l) {
		try {
			UnityEngine.Shader self=(UnityEngine.Shader)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetPassCountInSubshader(a1);
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
	static public int FindPassTagValue(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.Shader self=(UnityEngine.Shader)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				UnityEngine.Rendering.ShaderTagId a2;
				checkValueType(l,3,out a2);
				var ret=self.FindPassTagValue(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==4){
				UnityEngine.Shader self=(UnityEngine.Shader)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				UnityEngine.Rendering.ShaderTagId a3;
				checkValueType(l,4,out a3);
				var ret=self.FindPassTagValue(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function FindPassTagValue to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int FindSubshaderTagValue(IntPtr l) {
		try {
			UnityEngine.Shader self=(UnityEngine.Shader)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			UnityEngine.Rendering.ShaderTagId a2;
			checkValueType(l,3,out a2);
			var ret=self.FindSubshaderTagValue(a1,a2);
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
	static public int GetPropertyCount(IntPtr l) {
		try {
			UnityEngine.Shader self=(UnityEngine.Shader)checkSelf(l);
			var ret=self.GetPropertyCount();
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
	static public int FindPropertyIndex(IntPtr l) {
		try {
			UnityEngine.Shader self=(UnityEngine.Shader)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.FindPropertyIndex(a1);
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
	static public int GetPropertyName(IntPtr l) {
		try {
			UnityEngine.Shader self=(UnityEngine.Shader)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetPropertyName(a1);
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
	static public int GetPropertyNameId(IntPtr l) {
		try {
			UnityEngine.Shader self=(UnityEngine.Shader)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetPropertyNameId(a1);
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
	static public int GetPropertyType(IntPtr l) {
		try {
			UnityEngine.Shader self=(UnityEngine.Shader)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetPropertyType(a1);
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
	static public int GetPropertyDescription(IntPtr l) {
		try {
			UnityEngine.Shader self=(UnityEngine.Shader)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetPropertyDescription(a1);
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
	static public int GetPropertyFlags(IntPtr l) {
		try {
			UnityEngine.Shader self=(UnityEngine.Shader)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetPropertyFlags(a1);
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
	static public int GetPropertyAttributes(IntPtr l) {
		try {
			UnityEngine.Shader self=(UnityEngine.Shader)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetPropertyAttributes(a1);
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
	static public int GetPropertyDefaultFloatValue(IntPtr l) {
		try {
			UnityEngine.Shader self=(UnityEngine.Shader)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetPropertyDefaultFloatValue(a1);
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
	static public int GetPropertyDefaultVectorValue(IntPtr l) {
		try {
			UnityEngine.Shader self=(UnityEngine.Shader)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetPropertyDefaultVectorValue(a1);
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
	static public int GetPropertyRangeLimits(IntPtr l) {
		try {
			UnityEngine.Shader self=(UnityEngine.Shader)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetPropertyRangeLimits(a1);
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
	static public int GetPropertyTextureDimension(IntPtr l) {
		try {
			UnityEngine.Shader self=(UnityEngine.Shader)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetPropertyTextureDimension(a1);
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
	static public int GetPropertyTextureDefaultName(IntPtr l) {
		try {
			UnityEngine.Shader self=(UnityEngine.Shader)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetPropertyTextureDefaultName(a1);
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
	static public int FindTextureStack(IntPtr l) {
		try {
			UnityEngine.Shader self=(UnityEngine.Shader)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.String a2;
			System.Int32 a3;
			var ret=self.FindTextureStack(a1,out a2,out a3);
			pushValue(l,true);
			pushValue(l,ret);
			pushValue(l,a2);
			pushValue(l,a3);
			return 4;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Find_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Shader.Find(a1);
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
	static public int EnableKeyword_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string))){
				System.String a1;
				checkType(l,1,out a1);
				UnityEngine.Shader.EnableKeyword(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Rendering.GlobalKeyword))){
				UnityEngine.Rendering.GlobalKeyword a1;
				checkValueType(l,1,out a1);
				UnityEngine.Shader.EnableKeyword(in a1);
				pushValue(l,true);
				pushValue(l,a1);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function EnableKeyword to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int DisableKeyword_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string))){
				System.String a1;
				checkType(l,1,out a1);
				UnityEngine.Shader.DisableKeyword(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Rendering.GlobalKeyword))){
				UnityEngine.Rendering.GlobalKeyword a1;
				checkValueType(l,1,out a1);
				UnityEngine.Shader.DisableKeyword(in a1);
				pushValue(l,true);
				pushValue(l,a1);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function DisableKeyword to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int IsKeywordEnabled_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string))){
				System.String a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Shader.IsKeywordEnabled(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Rendering.GlobalKeyword))){
				UnityEngine.Rendering.GlobalKeyword a1;
				checkValueType(l,1,out a1);
				var ret=UnityEngine.Shader.IsKeywordEnabled(in a1);
				pushValue(l,true);
				pushValue(l,ret);
				pushValue(l,a1);
				return 3;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function IsKeywordEnabled to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetKeyword_s(IntPtr l) {
		try {
			UnityEngine.Rendering.GlobalKeyword a1;
			checkValueType(l,1,out a1);
			System.Boolean a2;
			checkType(l,2,out a2);
			UnityEngine.Shader.SetKeyword(in a1,a2);
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
	static public int WarmupAllShaders_s(IntPtr l) {
		try {
			UnityEngine.Shader.WarmupAllShaders();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int PropertyToID_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Shader.PropertyToID(a1);
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
	static public int SetGlobalInt_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string),typeof(int))){
				System.String a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Shader.SetGlobalInt(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(int))){
				System.Int32 a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Shader.SetGlobalInt(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetGlobalInt to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetGlobalFloat_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string),typeof(float))){
				System.String a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				UnityEngine.Shader.SetGlobalFloat(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(float))){
				System.Int32 a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				UnityEngine.Shader.SetGlobalFloat(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetGlobalFloat to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetGlobalInteger_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string),typeof(int))){
				System.String a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Shader.SetGlobalInteger(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(int))){
				System.Int32 a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.Shader.SetGlobalInteger(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetGlobalInteger to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetGlobalVector_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string),typeof(UnityEngine.Vector4))){
				System.String a1;
				checkType(l,1,out a1);
				UnityEngine.Vector4 a2;
				checkType(l,2,out a2);
				UnityEngine.Shader.SetGlobalVector(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(UnityEngine.Vector4))){
				System.Int32 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector4 a2;
				checkType(l,2,out a2);
				UnityEngine.Shader.SetGlobalVector(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetGlobalVector to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetGlobalColor_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string),typeof(UnityEngine.Color))){
				System.String a1;
				checkType(l,1,out a1);
				UnityEngine.Color a2;
				checkType(l,2,out a2);
				UnityEngine.Shader.SetGlobalColor(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(UnityEngine.Color))){
				System.Int32 a1;
				checkType(l,1,out a1);
				UnityEngine.Color a2;
				checkType(l,2,out a2);
				UnityEngine.Shader.SetGlobalColor(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetGlobalColor to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetGlobalMatrix_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string),typeof(UnityEngine.Matrix4x4))){
				System.String a1;
				checkType(l,1,out a1);
				UnityEngine.Matrix4x4 a2;
				checkValueType(l,2,out a2);
				UnityEngine.Shader.SetGlobalMatrix(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(UnityEngine.Matrix4x4))){
				System.Int32 a1;
				checkType(l,1,out a1);
				UnityEngine.Matrix4x4 a2;
				checkValueType(l,2,out a2);
				UnityEngine.Shader.SetGlobalMatrix(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetGlobalMatrix to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetGlobalTexture_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string),typeof(UnityEngine.Texture))){
				System.String a1;
				checkType(l,1,out a1);
				UnityEngine.Texture a2;
				checkType(l,2,out a2);
				UnityEngine.Shader.SetGlobalTexture(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(UnityEngine.Texture))){
				System.Int32 a1;
				checkType(l,1,out a1);
				UnityEngine.Texture a2;
				checkType(l,2,out a2);
				UnityEngine.Shader.SetGlobalTexture(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(string),typeof(UnityEngine.RenderTexture),typeof(UnityEngine.Rendering.RenderTextureSubElement))){
				System.String a1;
				checkType(l,1,out a1);
				UnityEngine.RenderTexture a2;
				checkType(l,2,out a2);
				UnityEngine.Rendering.RenderTextureSubElement a3;
				a3 = (UnityEngine.Rendering.RenderTextureSubElement)LuaDLL.luaL_checkinteger(l, 3);
				UnityEngine.Shader.SetGlobalTexture(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(UnityEngine.RenderTexture),typeof(UnityEngine.Rendering.RenderTextureSubElement))){
				System.Int32 a1;
				checkType(l,1,out a1);
				UnityEngine.RenderTexture a2;
				checkType(l,2,out a2);
				UnityEngine.Rendering.RenderTextureSubElement a3;
				a3 = (UnityEngine.Rendering.RenderTextureSubElement)LuaDLL.luaL_checkinteger(l, 3);
				UnityEngine.Shader.SetGlobalTexture(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetGlobalTexture to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetGlobalBuffer_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string),typeof(UnityEngine.ComputeBuffer))){
				System.String a1;
				checkType(l,1,out a1);
				UnityEngine.ComputeBuffer a2;
				checkType(l,2,out a2);
				UnityEngine.Shader.SetGlobalBuffer(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(UnityEngine.ComputeBuffer))){
				System.Int32 a1;
				checkType(l,1,out a1);
				UnityEngine.ComputeBuffer a2;
				checkType(l,2,out a2);
				UnityEngine.Shader.SetGlobalBuffer(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(string),typeof(UnityEngine.GraphicsBuffer))){
				System.String a1;
				checkType(l,1,out a1);
				UnityEngine.GraphicsBuffer a2;
				checkType(l,2,out a2);
				UnityEngine.Shader.SetGlobalBuffer(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(UnityEngine.GraphicsBuffer))){
				System.Int32 a1;
				checkType(l,1,out a1);
				UnityEngine.GraphicsBuffer a2;
				checkType(l,2,out a2);
				UnityEngine.Shader.SetGlobalBuffer(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetGlobalBuffer to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetGlobalConstantBuffer_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string),typeof(UnityEngine.ComputeBuffer),typeof(int),typeof(int))){
				System.String a1;
				checkType(l,1,out a1);
				UnityEngine.ComputeBuffer a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Shader.SetGlobalConstantBuffer(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(UnityEngine.ComputeBuffer),typeof(int),typeof(int))){
				System.Int32 a1;
				checkType(l,1,out a1);
				UnityEngine.ComputeBuffer a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Shader.SetGlobalConstantBuffer(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(string),typeof(UnityEngine.GraphicsBuffer),typeof(int),typeof(int))){
				System.String a1;
				checkType(l,1,out a1);
				UnityEngine.GraphicsBuffer a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Shader.SetGlobalConstantBuffer(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(UnityEngine.GraphicsBuffer),typeof(int),typeof(int))){
				System.Int32 a1;
				checkType(l,1,out a1);
				UnityEngine.GraphicsBuffer a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				UnityEngine.Shader.SetGlobalConstantBuffer(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetGlobalConstantBuffer to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetGlobalFloatArray_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string),typeof(List<System.Single>))){
				System.String a1;
				checkType(l,1,out a1);
				System.Collections.Generic.List<System.Single> a2;
				checkType(l,2,out a2);
				UnityEngine.Shader.SetGlobalFloatArray(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(List<System.Single>))){
				System.Int32 a1;
				checkType(l,1,out a1);
				System.Collections.Generic.List<System.Single> a2;
				checkType(l,2,out a2);
				UnityEngine.Shader.SetGlobalFloatArray(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(string),typeof(System.Single[]))){
				System.String a1;
				checkType(l,1,out a1);
				System.Single[] a2;
				checkArray(l,2,out a2);
				UnityEngine.Shader.SetGlobalFloatArray(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(System.Single[]))){
				System.Int32 a1;
				checkType(l,1,out a1);
				System.Single[] a2;
				checkArray(l,2,out a2);
				UnityEngine.Shader.SetGlobalFloatArray(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetGlobalFloatArray to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetGlobalVectorArray_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string),typeof(List<UnityEngine.Vector4>))){
				System.String a1;
				checkType(l,1,out a1);
				System.Collections.Generic.List<UnityEngine.Vector4> a2;
				checkType(l,2,out a2);
				UnityEngine.Shader.SetGlobalVectorArray(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(List<UnityEngine.Vector4>))){
				System.Int32 a1;
				checkType(l,1,out a1);
				System.Collections.Generic.List<UnityEngine.Vector4> a2;
				checkType(l,2,out a2);
				UnityEngine.Shader.SetGlobalVectorArray(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(string),typeof(UnityEngine.Vector4[]))){
				System.String a1;
				checkType(l,1,out a1);
				UnityEngine.Vector4[] a2;
				checkArray(l,2,out a2);
				UnityEngine.Shader.SetGlobalVectorArray(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(UnityEngine.Vector4[]))){
				System.Int32 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector4[] a2;
				checkArray(l,2,out a2);
				UnityEngine.Shader.SetGlobalVectorArray(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetGlobalVectorArray to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetGlobalMatrixArray_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string),typeof(List<UnityEngine.Matrix4x4>))){
				System.String a1;
				checkType(l,1,out a1);
				System.Collections.Generic.List<UnityEngine.Matrix4x4> a2;
				checkType(l,2,out a2);
				UnityEngine.Shader.SetGlobalMatrixArray(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(List<UnityEngine.Matrix4x4>))){
				System.Int32 a1;
				checkType(l,1,out a1);
				System.Collections.Generic.List<UnityEngine.Matrix4x4> a2;
				checkType(l,2,out a2);
				UnityEngine.Shader.SetGlobalMatrixArray(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(string),typeof(UnityEngine.Matrix4x4[]))){
				System.String a1;
				checkType(l,1,out a1);
				UnityEngine.Matrix4x4[] a2;
				checkArray(l,2,out a2);
				UnityEngine.Shader.SetGlobalMatrixArray(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(UnityEngine.Matrix4x4[]))){
				System.Int32 a1;
				checkType(l,1,out a1);
				UnityEngine.Matrix4x4[] a2;
				checkArray(l,2,out a2);
				UnityEngine.Shader.SetGlobalMatrixArray(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetGlobalMatrixArray to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetGlobalInt_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string))){
				System.String a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Shader.GetGlobalInt(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(int))){
				System.Int32 a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Shader.GetGlobalInt(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetGlobalInt to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetGlobalFloat_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string))){
				System.String a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Shader.GetGlobalFloat(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(int))){
				System.Int32 a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Shader.GetGlobalFloat(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetGlobalFloat to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetGlobalInteger_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string))){
				System.String a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Shader.GetGlobalInteger(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(int))){
				System.Int32 a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Shader.GetGlobalInteger(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetGlobalInteger to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetGlobalVector_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string))){
				System.String a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Shader.GetGlobalVector(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(int))){
				System.Int32 a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Shader.GetGlobalVector(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetGlobalVector to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetGlobalColor_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string))){
				System.String a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Shader.GetGlobalColor(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(int))){
				System.Int32 a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Shader.GetGlobalColor(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetGlobalColor to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetGlobalMatrix_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string))){
				System.String a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Shader.GetGlobalMatrix(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(int))){
				System.Int32 a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Shader.GetGlobalMatrix(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetGlobalMatrix to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetGlobalTexture_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string))){
				System.String a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Shader.GetGlobalTexture(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(int))){
				System.Int32 a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Shader.GetGlobalTexture(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetGlobalTexture to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetGlobalFloatArray_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string))){
				System.String a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Shader.GetGlobalFloatArray(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(int))){
				System.Int32 a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Shader.GetGlobalFloatArray(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(string),typeof(List<System.Single>))){
				System.String a1;
				checkType(l,1,out a1);
				System.Collections.Generic.List<System.Single> a2;
				checkType(l,2,out a2);
				UnityEngine.Shader.GetGlobalFloatArray(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(List<System.Single>))){
				System.Int32 a1;
				checkType(l,1,out a1);
				System.Collections.Generic.List<System.Single> a2;
				checkType(l,2,out a2);
				UnityEngine.Shader.GetGlobalFloatArray(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetGlobalFloatArray to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetGlobalVectorArray_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string))){
				System.String a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Shader.GetGlobalVectorArray(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(int))){
				System.Int32 a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Shader.GetGlobalVectorArray(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(string),typeof(List<UnityEngine.Vector4>))){
				System.String a1;
				checkType(l,1,out a1);
				System.Collections.Generic.List<UnityEngine.Vector4> a2;
				checkType(l,2,out a2);
				UnityEngine.Shader.GetGlobalVectorArray(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(List<UnityEngine.Vector4>))){
				System.Int32 a1;
				checkType(l,1,out a1);
				System.Collections.Generic.List<UnityEngine.Vector4> a2;
				checkType(l,2,out a2);
				UnityEngine.Shader.GetGlobalVectorArray(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetGlobalVectorArray to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetGlobalMatrixArray_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string))){
				System.String a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Shader.GetGlobalMatrixArray(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(int))){
				System.Int32 a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Shader.GetGlobalMatrixArray(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(string),typeof(List<UnityEngine.Matrix4x4>))){
				System.String a1;
				checkType(l,1,out a1);
				System.Collections.Generic.List<UnityEngine.Matrix4x4> a2;
				checkType(l,2,out a2);
				UnityEngine.Shader.GetGlobalMatrixArray(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(int),typeof(List<UnityEngine.Matrix4x4>))){
				System.Int32 a1;
				checkType(l,1,out a1);
				System.Collections.Generic.List<UnityEngine.Matrix4x4> a2;
				checkType(l,2,out a2);
				UnityEngine.Shader.GetGlobalMatrixArray(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetGlobalMatrixArray to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maximumLOD(IntPtr l) {
		try {
			UnityEngine.Shader self=(UnityEngine.Shader)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.maximumLOD);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_maximumLOD(IntPtr l) {
		try {
			UnityEngine.Shader self=(UnityEngine.Shader)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.maximumLOD=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_globalMaximumLOD(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Shader.globalMaximumLOD);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_globalMaximumLOD(IntPtr l) {
		try {
			int v;
			checkType(l,2,out v);
			UnityEngine.Shader.globalMaximumLOD=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isSupported(IntPtr l) {
		try {
			UnityEngine.Shader self=(UnityEngine.Shader)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isSupported);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_globalRenderPipeline(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Shader.globalRenderPipeline);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_globalRenderPipeline(IntPtr l) {
		try {
			string v;
			checkType(l,2,out v);
			UnityEngine.Shader.globalRenderPipeline=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_enabledGlobalKeywords(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Shader.enabledGlobalKeywords);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_globalKeywords(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Shader.globalKeywords);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_keywordSpace(IntPtr l) {
		try {
			UnityEngine.Shader self=(UnityEngine.Shader)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.keywordSpace);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_renderQueue(IntPtr l) {
		try {
			UnityEngine.Shader self=(UnityEngine.Shader)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.renderQueue);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_passCount(IntPtr l) {
		try {
			UnityEngine.Shader self=(UnityEngine.Shader)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.passCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_subshaderCount(IntPtr l) {
		try {
			UnityEngine.Shader self=(UnityEngine.Shader)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.subshaderCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Shader");
		addMember(l,GetDependency);
		addMember(l,GetPassCountInSubshader);
		addMember(l,FindPassTagValue);
		addMember(l,FindSubshaderTagValue);
		addMember(l,GetPropertyCount);
		addMember(l,FindPropertyIndex);
		addMember(l,GetPropertyName);
		addMember(l,GetPropertyNameId);
		addMember(l,GetPropertyType);
		addMember(l,GetPropertyDescription);
		addMember(l,GetPropertyFlags);
		addMember(l,GetPropertyAttributes);
		addMember(l,GetPropertyDefaultFloatValue);
		addMember(l,GetPropertyDefaultVectorValue);
		addMember(l,GetPropertyRangeLimits);
		addMember(l,GetPropertyTextureDimension);
		addMember(l,GetPropertyTextureDefaultName);
		addMember(l,FindTextureStack);
		addMember(l,Find_s);
		addMember(l,EnableKeyword_s);
		addMember(l,DisableKeyword_s);
		addMember(l,IsKeywordEnabled_s);
		addMember(l,SetKeyword_s);
		addMember(l,WarmupAllShaders_s);
		addMember(l,PropertyToID_s);
		addMember(l,SetGlobalInt_s);
		addMember(l,SetGlobalFloat_s);
		addMember(l,SetGlobalInteger_s);
		addMember(l,SetGlobalVector_s);
		addMember(l,SetGlobalColor_s);
		addMember(l,SetGlobalMatrix_s);
		addMember(l,SetGlobalTexture_s);
		addMember(l,SetGlobalBuffer_s);
		addMember(l,SetGlobalConstantBuffer_s);
		addMember(l,SetGlobalFloatArray_s);
		addMember(l,SetGlobalVectorArray_s);
		addMember(l,SetGlobalMatrixArray_s);
		addMember(l,GetGlobalInt_s);
		addMember(l,GetGlobalFloat_s);
		addMember(l,GetGlobalInteger_s);
		addMember(l,GetGlobalVector_s);
		addMember(l,GetGlobalColor_s);
		addMember(l,GetGlobalMatrix_s);
		addMember(l,GetGlobalTexture_s);
		addMember(l,GetGlobalFloatArray_s);
		addMember(l,GetGlobalVectorArray_s);
		addMember(l,GetGlobalMatrixArray_s);
		addMember(l,"maximumLOD",get_maximumLOD,set_maximumLOD,true);
		addMember(l,"globalMaximumLOD",get_globalMaximumLOD,set_globalMaximumLOD,false);
		addMember(l,"isSupported",get_isSupported,null,true);
		addMember(l,"globalRenderPipeline",get_globalRenderPipeline,set_globalRenderPipeline,false);
		addMember(l,"enabledGlobalKeywords",get_enabledGlobalKeywords,null,false);
		addMember(l,"globalKeywords",get_globalKeywords,null,false);
		addMember(l,"keywordSpace",get_keywordSpace,null,true);
		addMember(l,"renderQueue",get_renderQueue,null,true);
		addMember(l,"passCount",get_passCount,null,true);
		addMember(l,"subshaderCount",get_subshaderCount,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.Shader),typeof(UnityEngine.Object));
	}
}
