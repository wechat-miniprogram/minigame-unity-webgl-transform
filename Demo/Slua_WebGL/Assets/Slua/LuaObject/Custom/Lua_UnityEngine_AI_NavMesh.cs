using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AI_NavMesh : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Raycast_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Vector3),typeof(UnityEngine.Vector3),typeof(LuaOut),typeof(int))){
				UnityEngine.Vector3 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				UnityEngine.AI.NavMeshHit a3;
				System.Int32 a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.AI.NavMesh.Raycast(a1,a2,out a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				pushValue(l,a3);
				return 3;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector3),typeof(UnityEngine.Vector3),typeof(LuaOut),typeof(UnityEngine.AI.NavMeshQueryFilter))){
				UnityEngine.Vector3 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				UnityEngine.AI.NavMeshHit a3;
				UnityEngine.AI.NavMeshQueryFilter a4;
				checkValueType(l,4,out a4);
				var ret=UnityEngine.AI.NavMesh.Raycast(a1,a2,out a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				pushValue(l,a3);
				return 3;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Raycast to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CalculatePath_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Vector3),typeof(UnityEngine.Vector3),typeof(int),typeof(UnityEngine.AI.NavMeshPath))){
				UnityEngine.Vector3 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				UnityEngine.AI.NavMeshPath a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.AI.NavMesh.CalculatePath(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector3),typeof(UnityEngine.Vector3),typeof(UnityEngine.AI.NavMeshQueryFilter),typeof(UnityEngine.AI.NavMeshPath))){
				UnityEngine.Vector3 a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				UnityEngine.AI.NavMeshQueryFilter a3;
				checkValueType(l,3,out a3);
				UnityEngine.AI.NavMeshPath a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.AI.NavMesh.CalculatePath(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function CalculatePath to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int FindClosestEdge_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Vector3),typeof(LuaOut),typeof(int))){
				UnityEngine.Vector3 a1;
				checkType(l,1,out a1);
				UnityEngine.AI.NavMeshHit a2;
				System.Int32 a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.AI.NavMesh.FindClosestEdge(a1,out a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				pushValue(l,a2);
				return 3;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector3),typeof(LuaOut),typeof(UnityEngine.AI.NavMeshQueryFilter))){
				UnityEngine.Vector3 a1;
				checkType(l,1,out a1);
				UnityEngine.AI.NavMeshHit a2;
				UnityEngine.AI.NavMeshQueryFilter a3;
				checkValueType(l,3,out a3);
				var ret=UnityEngine.AI.NavMesh.FindClosestEdge(a1,out a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				pushValue(l,a2);
				return 3;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function FindClosestEdge to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SamplePosition_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Vector3),typeof(LuaOut),typeof(float),typeof(int))){
				UnityEngine.Vector3 a1;
				checkType(l,1,out a1);
				UnityEngine.AI.NavMeshHit a2;
				System.Single a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				var ret=UnityEngine.AI.NavMesh.SamplePosition(a1,out a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				pushValue(l,a2);
				return 3;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Vector3),typeof(LuaOut),typeof(float),typeof(UnityEngine.AI.NavMeshQueryFilter))){
				UnityEngine.Vector3 a1;
				checkType(l,1,out a1);
				UnityEngine.AI.NavMeshHit a2;
				System.Single a3;
				checkType(l,3,out a3);
				UnityEngine.AI.NavMeshQueryFilter a4;
				checkValueType(l,4,out a4);
				var ret=UnityEngine.AI.NavMesh.SamplePosition(a1,out a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				pushValue(l,a2);
				return 3;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SamplePosition to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetAreaCost_s(IntPtr l) {
		try {
			System.Int32 a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			UnityEngine.AI.NavMesh.SetAreaCost(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetAreaCost_s(IntPtr l) {
		try {
			System.Int32 a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.AI.NavMesh.GetAreaCost(a1);
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
	static public int GetAreaFromName_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.AI.NavMesh.GetAreaFromName(a1);
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
	static public int CalculateTriangulation_s(IntPtr l) {
		try {
			var ret=UnityEngine.AI.NavMesh.CalculateTriangulation();
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
	static public int AddNavMeshData_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.AI.NavMeshData a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.AI.NavMesh.AddNavMeshData(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==3){
				UnityEngine.AI.NavMeshData a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				UnityEngine.Quaternion a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.AI.NavMesh.AddNavMeshData(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function AddNavMeshData to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RemoveNavMeshData_s(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshDataInstance a1;
			checkValueType(l,1,out a1);
			UnityEngine.AI.NavMesh.RemoveNavMeshData(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AddLink_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.AI.NavMeshLinkData a1;
				checkValueType(l,1,out a1);
				var ret=UnityEngine.AI.NavMesh.AddLink(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==3){
				UnityEngine.AI.NavMeshLinkData a1;
				checkValueType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				UnityEngine.Quaternion a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.AI.NavMesh.AddLink(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function AddLink to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RemoveLink_s(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshLinkInstance a1;
			checkValueType(l,1,out a1);
			UnityEngine.AI.NavMesh.RemoveLink(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CreateSettings_s(IntPtr l) {
		try {
			var ret=UnityEngine.AI.NavMesh.CreateSettings();
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
	static public int RemoveSettings_s(IntPtr l) {
		try {
			System.Int32 a1;
			checkType(l,1,out a1);
			UnityEngine.AI.NavMesh.RemoveSettings(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetSettingsByID_s(IntPtr l) {
		try {
			System.Int32 a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.AI.NavMesh.GetSettingsByID(a1);
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
	static public int GetSettingsCount_s(IntPtr l) {
		try {
			var ret=UnityEngine.AI.NavMesh.GetSettingsCount();
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
	static public int GetSettingsByIndex_s(IntPtr l) {
		try {
			System.Int32 a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.AI.NavMesh.GetSettingsByIndex(a1);
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
	static public int GetSettingsNameFromID_s(IntPtr l) {
		try {
			System.Int32 a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.AI.NavMesh.GetSettingsNameFromID(a1);
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
	static public int RemoveAllNavMeshData_s(IntPtr l) {
		try {
			UnityEngine.AI.NavMesh.RemoveAllNavMeshData();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_AllAreas(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.AI.NavMesh.AllAreas);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_onPreUpdate(IntPtr l) {
		try {
			UnityEngine.AI.NavMesh.OnNavMeshPreUpdate v;
			int op=checkDelegate(l,2,out v);
			if(op==0) UnityEngine.AI.NavMesh.onPreUpdate=v;
			else if(op==1) UnityEngine.AI.NavMesh.onPreUpdate+=v;
			else if(op==2) UnityEngine.AI.NavMesh.onPreUpdate-=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_avoidancePredictionTime(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.AI.NavMesh.avoidancePredictionTime);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_avoidancePredictionTime(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.AI.NavMesh.avoidancePredictionTime=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_pathfindingIterationsPerFrame(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.AI.NavMesh.pathfindingIterationsPerFrame);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_pathfindingIterationsPerFrame(IntPtr l) {
		try {
			int v;
			checkType(l,2,out v);
			UnityEngine.AI.NavMesh.pathfindingIterationsPerFrame=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.AI.NavMesh");
		addMember(l,Raycast_s);
		addMember(l,CalculatePath_s);
		addMember(l,FindClosestEdge_s);
		addMember(l,SamplePosition_s);
		addMember(l,SetAreaCost_s);
		addMember(l,GetAreaCost_s);
		addMember(l,GetAreaFromName_s);
		addMember(l,CalculateTriangulation_s);
		addMember(l,AddNavMeshData_s);
		addMember(l,RemoveNavMeshData_s);
		addMember(l,AddLink_s);
		addMember(l,RemoveLink_s);
		addMember(l,CreateSettings_s);
		addMember(l,RemoveSettings_s);
		addMember(l,GetSettingsByID_s);
		addMember(l,GetSettingsCount_s);
		addMember(l,GetSettingsByIndex_s);
		addMember(l,GetSettingsNameFromID_s);
		addMember(l,RemoveAllNavMeshData_s);
		addMember(l,"AllAreas",get_AllAreas,null,false);
		addMember(l,"onPreUpdate",null,set_onPreUpdate,false);
		addMember(l,"avoidancePredictionTime",get_avoidancePredictionTime,set_avoidancePredictionTime,false);
		addMember(l,"pathfindingIterationsPerFrame",get_pathfindingIterationsPerFrame,set_pathfindingIterationsPerFrame,false);
		createTypeMetatable(l,null, typeof(UnityEngine.AI.NavMesh));
	}
}
