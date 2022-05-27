using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_TrailRenderer : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetPosition(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			self.SetPosition(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetPosition(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetPosition(a1);
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
	static public int Clear(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			self.Clear();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int BakeMesh(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
				UnityEngine.Mesh a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				self.BakeMesh(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(argc==4){
				UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
				UnityEngine.Mesh a1;
				checkType(l,2,out a1);
				UnityEngine.Camera a2;
				checkType(l,3,out a2);
				System.Boolean a3;
				checkType(l,4,out a3);
				self.BakeMesh(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function BakeMesh to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetPositions(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(UnityEngine.Vector3[]))){
				UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
				UnityEngine.Vector3[] a1;
				checkArray(l,2,out a1);
				self.SetPositions(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(Unity.Collections.NativeArray<UnityEngine.Vector3>))){
				UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
				Unity.Collections.NativeArray<UnityEngine.Vector3> a1;
				checkValueType(l,2,out a1);
				self.SetPositions(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(Unity.Collections.NativeSlice<UnityEngine.Vector3>))){
				UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
				Unity.Collections.NativeSlice<UnityEngine.Vector3> a1;
				checkValueType(l,2,out a1);
				self.SetPositions(a1);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetPositions to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AddPosition(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			self.AddPosition(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_time(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.time);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_time(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.time=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_startWidth(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.startWidth);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startWidth(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.startWidth=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_endWidth(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.endWidth);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_endWidth(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.endWidth=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_widthMultiplier(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.widthMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_widthMultiplier(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.widthMultiplier=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_autodestruct(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.autodestruct);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_autodestruct(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.autodestruct=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_emitting(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.emitting);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_emitting(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.emitting=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_numCornerVertices(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.numCornerVertices);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_numCornerVertices(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.numCornerVertices=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_numCapVertices(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.numCapVertices);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_numCapVertices(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.numCapVertices=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_minVertexDistance(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.minVertexDistance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_minVertexDistance(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.minVertexDistance=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_startColor(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.startColor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startColor(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.startColor=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_endColor(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.endColor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_endColor(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.endColor=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_positionCount(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.positionCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_shadowBias(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.shadowBias);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_shadowBias(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.shadowBias=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_generateLightingData(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.generateLightingData);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_generateLightingData(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.generateLightingData=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_textureMode(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.textureMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_textureMode(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			UnityEngine.LineTextureMode v;
			v = (UnityEngine.LineTextureMode)LuaDLL.luaL_checkinteger(l, 2);
			self.textureMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_alignment(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.alignment);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_alignment(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			UnityEngine.LineAlignment v;
			v = (UnityEngine.LineAlignment)LuaDLL.luaL_checkinteger(l, 2);
			self.alignment=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_widthCurve(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.widthCurve);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_widthCurve(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			UnityEngine.AnimationCurve v;
			checkType(l,2,out v);
			self.widthCurve=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_colorGradient(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.colorGradient);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_colorGradient(IntPtr l) {
		try {
			UnityEngine.TrailRenderer self=(UnityEngine.TrailRenderer)checkSelf(l);
			UnityEngine.Gradient v;
			checkType(l,2,out v);
			self.colorGradient=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.TrailRenderer");
		addMember(l,SetPosition);
		addMember(l,GetPosition);
		addMember(l,Clear);
		addMember(l,BakeMesh);
		addMember(l,SetPositions);
		addMember(l,AddPosition);
		addMember(l,"time",get_time,set_time,true);
		addMember(l,"startWidth",get_startWidth,set_startWidth,true);
		addMember(l,"endWidth",get_endWidth,set_endWidth,true);
		addMember(l,"widthMultiplier",get_widthMultiplier,set_widthMultiplier,true);
		addMember(l,"autodestruct",get_autodestruct,set_autodestruct,true);
		addMember(l,"emitting",get_emitting,set_emitting,true);
		addMember(l,"numCornerVertices",get_numCornerVertices,set_numCornerVertices,true);
		addMember(l,"numCapVertices",get_numCapVertices,set_numCapVertices,true);
		addMember(l,"minVertexDistance",get_minVertexDistance,set_minVertexDistance,true);
		addMember(l,"startColor",get_startColor,set_startColor,true);
		addMember(l,"endColor",get_endColor,set_endColor,true);
		addMember(l,"positionCount",get_positionCount,null,true);
		addMember(l,"shadowBias",get_shadowBias,set_shadowBias,true);
		addMember(l,"generateLightingData",get_generateLightingData,set_generateLightingData,true);
		addMember(l,"textureMode",get_textureMode,set_textureMode,true);
		addMember(l,"alignment",get_alignment,set_alignment,true);
		addMember(l,"widthCurve",get_widthCurve,set_widthCurve,true);
		addMember(l,"colorGradient",get_colorGradient,set_colorGradient,true);
		createTypeMetatable(l,null, typeof(UnityEngine.TrailRenderer),typeof(UnityEngine.Renderer));
	}
}
