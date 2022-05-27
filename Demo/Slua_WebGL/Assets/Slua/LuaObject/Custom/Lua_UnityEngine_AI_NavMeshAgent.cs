using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AI_NavMeshAgent : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetDestination(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			var ret=self.SetDestination(a1);
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
	static public int ActivateCurrentOffMeshLink(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			self.ActivateCurrentOffMeshLink(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CompleteOffMeshLink(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			self.CompleteOffMeshLink();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Warp(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			var ret=self.Warp(a1);
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
	static public int Move(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			self.Move(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ResetPath(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			self.ResetPath();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetPath(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			UnityEngine.AI.NavMeshPath a1;
			checkType(l,2,out a1);
			var ret=self.SetPath(a1);
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
	static public int FindClosestEdge(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			UnityEngine.AI.NavMeshHit a1;
			var ret=self.FindClosestEdge(out a1);
			pushValue(l,true);
			pushValue(l,ret);
			pushValue(l,a1);
			return 3;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Raycast(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			UnityEngine.AI.NavMeshHit a2;
			var ret=self.Raycast(a1,out a2);
			pushValue(l,true);
			pushValue(l,ret);
			pushValue(l,a2);
			return 3;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CalculatePath(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			UnityEngine.AI.NavMeshPath a2;
			checkType(l,3,out a2);
			var ret=self.CalculatePath(a1,a2);
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
	static public int SamplePathPosition(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			UnityEngine.AI.NavMeshHit a3;
			var ret=self.SamplePathPosition(a1,a2,out a3);
			pushValue(l,true);
			pushValue(l,ret);
			pushValue(l,a3);
			return 3;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetAreaCost(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			self.SetAreaCost(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetAreaCost(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetAreaCost(a1);
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
	static public int get_destination(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.destination);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_destination(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.destination=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_stoppingDistance(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.stoppingDistance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_stoppingDistance(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.stoppingDistance=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_velocity(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.velocity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_velocity(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.velocity=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_nextPosition(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.nextPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_nextPosition(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.nextPosition=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_steeringTarget(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.steeringTarget);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_desiredVelocity(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.desiredVelocity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_remainingDistance(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.remainingDistance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_baseOffset(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.baseOffset);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_baseOffset(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.baseOffset=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isOnOffMeshLink(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isOnOffMeshLink);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_currentOffMeshLinkData(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.currentOffMeshLinkData);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_nextOffMeshLinkData(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.nextOffMeshLinkData);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_autoTraverseOffMeshLink(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.autoTraverseOffMeshLink);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_autoTraverseOffMeshLink(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.autoTraverseOffMeshLink=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_autoBraking(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.autoBraking);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_autoBraking(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.autoBraking=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_autoRepath(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.autoRepath);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_autoRepath(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.autoRepath=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_hasPath(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.hasPath);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_pathPending(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pathPending);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isPathStale(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isPathStale);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_pathStatus(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.pathStatus);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_pathEndPosition(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pathEndPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isStopped(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isStopped);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_isStopped(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.isStopped=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_path(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.path);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_path(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			UnityEngine.AI.NavMeshPath v;
			checkType(l,2,out v);
			self.path=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_navMeshOwner(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.navMeshOwner);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_agentTypeID(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.agentTypeID);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_agentTypeID(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.agentTypeID=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_areaMask(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.areaMask);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_areaMask(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.areaMask=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_speed(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.speed);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_speed(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.speed=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_angularSpeed(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.angularSpeed);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_angularSpeed(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.angularSpeed=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_acceleration(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.acceleration);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_acceleration(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.acceleration=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_updatePosition(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.updatePosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_updatePosition(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.updatePosition=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_updateRotation(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.updateRotation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_updateRotation(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.updateRotation=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_updateUpAxis(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.updateUpAxis);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_updateUpAxis(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.updateUpAxis=v;
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
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
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
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.radius=v;
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
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
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
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.height=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_obstacleAvoidanceType(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.obstacleAvoidanceType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_obstacleAvoidanceType(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			UnityEngine.AI.ObstacleAvoidanceType v;
			v = (UnityEngine.AI.ObstacleAvoidanceType)LuaDLL.luaL_checkinteger(l, 2);
			self.obstacleAvoidanceType=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_avoidancePriority(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.avoidancePriority);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_avoidancePriority(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.avoidancePriority=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isOnNavMesh(IntPtr l) {
		try {
			UnityEngine.AI.NavMeshAgent self=(UnityEngine.AI.NavMeshAgent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isOnNavMesh);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.AI.NavMeshAgent");
		addMember(l,SetDestination);
		addMember(l,ActivateCurrentOffMeshLink);
		addMember(l,CompleteOffMeshLink);
		addMember(l,Warp);
		addMember(l,Move);
		addMember(l,ResetPath);
		addMember(l,SetPath);
		addMember(l,FindClosestEdge);
		addMember(l,Raycast);
		addMember(l,CalculatePath);
		addMember(l,SamplePathPosition);
		addMember(l,SetAreaCost);
		addMember(l,GetAreaCost);
		addMember(l,"destination",get_destination,set_destination,true);
		addMember(l,"stoppingDistance",get_stoppingDistance,set_stoppingDistance,true);
		addMember(l,"velocity",get_velocity,set_velocity,true);
		addMember(l,"nextPosition",get_nextPosition,set_nextPosition,true);
		addMember(l,"steeringTarget",get_steeringTarget,null,true);
		addMember(l,"desiredVelocity",get_desiredVelocity,null,true);
		addMember(l,"remainingDistance",get_remainingDistance,null,true);
		addMember(l,"baseOffset",get_baseOffset,set_baseOffset,true);
		addMember(l,"isOnOffMeshLink",get_isOnOffMeshLink,null,true);
		addMember(l,"currentOffMeshLinkData",get_currentOffMeshLinkData,null,true);
		addMember(l,"nextOffMeshLinkData",get_nextOffMeshLinkData,null,true);
		addMember(l,"autoTraverseOffMeshLink",get_autoTraverseOffMeshLink,set_autoTraverseOffMeshLink,true);
		addMember(l,"autoBraking",get_autoBraking,set_autoBraking,true);
		addMember(l,"autoRepath",get_autoRepath,set_autoRepath,true);
		addMember(l,"hasPath",get_hasPath,null,true);
		addMember(l,"pathPending",get_pathPending,null,true);
		addMember(l,"isPathStale",get_isPathStale,null,true);
		addMember(l,"pathStatus",get_pathStatus,null,true);
		addMember(l,"pathEndPosition",get_pathEndPosition,null,true);
		addMember(l,"isStopped",get_isStopped,set_isStopped,true);
		addMember(l,"path",get_path,set_path,true);
		addMember(l,"navMeshOwner",get_navMeshOwner,null,true);
		addMember(l,"agentTypeID",get_agentTypeID,set_agentTypeID,true);
		addMember(l,"areaMask",get_areaMask,set_areaMask,true);
		addMember(l,"speed",get_speed,set_speed,true);
		addMember(l,"angularSpeed",get_angularSpeed,set_angularSpeed,true);
		addMember(l,"acceleration",get_acceleration,set_acceleration,true);
		addMember(l,"updatePosition",get_updatePosition,set_updatePosition,true);
		addMember(l,"updateRotation",get_updateRotation,set_updateRotation,true);
		addMember(l,"updateUpAxis",get_updateUpAxis,set_updateUpAxis,true);
		addMember(l,"radius",get_radius,set_radius,true);
		addMember(l,"height",get_height,set_height,true);
		addMember(l,"obstacleAvoidanceType",get_obstacleAvoidanceType,set_obstacleAvoidanceType,true);
		addMember(l,"avoidancePriority",get_avoidancePriority,set_avoidancePriority,true);
		addMember(l,"isOnNavMesh",get_isOnNavMesh,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.AI.NavMeshAgent),typeof(UnityEngine.Behaviour));
	}
}
