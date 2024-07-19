using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PhysicsJobOptions2D : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D o;
			o=new UnityEngine.PhysicsJobOptions2D();
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
	static public int get_useMultithreading(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.useMultithreading);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_useMultithreading(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.useMultithreading=v;
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
	static public int get_useConsistencySorting(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.useConsistencySorting);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_useConsistencySorting(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.useConsistencySorting=v;
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
	static public int get_interpolationPosesPerJob(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.interpolationPosesPerJob);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_interpolationPosesPerJob(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.interpolationPosesPerJob=v;
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
	static public int get_newContactsPerJob(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.newContactsPerJob);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_newContactsPerJob(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.newContactsPerJob=v;
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
	static public int get_collideContactsPerJob(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.collideContactsPerJob);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_collideContactsPerJob(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.collideContactsPerJob=v;
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
	static public int get_clearFlagsPerJob(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.clearFlagsPerJob);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_clearFlagsPerJob(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.clearFlagsPerJob=v;
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
	static public int get_clearBodyForcesPerJob(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.clearBodyForcesPerJob);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_clearBodyForcesPerJob(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.clearBodyForcesPerJob=v;
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
	static public int get_syncDiscreteFixturesPerJob(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.syncDiscreteFixturesPerJob);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_syncDiscreteFixturesPerJob(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.syncDiscreteFixturesPerJob=v;
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
	static public int get_syncContinuousFixturesPerJob(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.syncContinuousFixturesPerJob);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_syncContinuousFixturesPerJob(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.syncContinuousFixturesPerJob=v;
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
	static public int get_findNearestContactsPerJob(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.findNearestContactsPerJob);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_findNearestContactsPerJob(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.findNearestContactsPerJob=v;
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
	static public int get_updateTriggerContactsPerJob(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.updateTriggerContactsPerJob);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_updateTriggerContactsPerJob(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.updateTriggerContactsPerJob=v;
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
	static public int get_islandSolverCostThreshold(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.islandSolverCostThreshold);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_islandSolverCostThreshold(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.islandSolverCostThreshold=v;
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
	static public int get_islandSolverBodyCostScale(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.islandSolverBodyCostScale);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_islandSolverBodyCostScale(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.islandSolverBodyCostScale=v;
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
	static public int get_islandSolverContactCostScale(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.islandSolverContactCostScale);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_islandSolverContactCostScale(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.islandSolverContactCostScale=v;
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
	static public int get_islandSolverJointCostScale(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.islandSolverJointCostScale);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_islandSolverJointCostScale(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.islandSolverJointCostScale=v;
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
	static public int get_islandSolverBodiesPerJob(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.islandSolverBodiesPerJob);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_islandSolverBodiesPerJob(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.islandSolverBodiesPerJob=v;
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
	static public int get_islandSolverContactsPerJob(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.islandSolverContactsPerJob);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_islandSolverContactsPerJob(IntPtr l) {
		try {
			UnityEngine.PhysicsJobOptions2D self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.islandSolverContactsPerJob=v;
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
		getTypeTable(l,"UnityEngine.PhysicsJobOptions2D");
		addMember(l,"useMultithreading",get_useMultithreading,set_useMultithreading,true);
		addMember(l,"useConsistencySorting",get_useConsistencySorting,set_useConsistencySorting,true);
		addMember(l,"interpolationPosesPerJob",get_interpolationPosesPerJob,set_interpolationPosesPerJob,true);
		addMember(l,"newContactsPerJob",get_newContactsPerJob,set_newContactsPerJob,true);
		addMember(l,"collideContactsPerJob",get_collideContactsPerJob,set_collideContactsPerJob,true);
		addMember(l,"clearFlagsPerJob",get_clearFlagsPerJob,set_clearFlagsPerJob,true);
		addMember(l,"clearBodyForcesPerJob",get_clearBodyForcesPerJob,set_clearBodyForcesPerJob,true);
		addMember(l,"syncDiscreteFixturesPerJob",get_syncDiscreteFixturesPerJob,set_syncDiscreteFixturesPerJob,true);
		addMember(l,"syncContinuousFixturesPerJob",get_syncContinuousFixturesPerJob,set_syncContinuousFixturesPerJob,true);
		addMember(l,"findNearestContactsPerJob",get_findNearestContactsPerJob,set_findNearestContactsPerJob,true);
		addMember(l,"updateTriggerContactsPerJob",get_updateTriggerContactsPerJob,set_updateTriggerContactsPerJob,true);
		addMember(l,"islandSolverCostThreshold",get_islandSolverCostThreshold,set_islandSolverCostThreshold,true);
		addMember(l,"islandSolverBodyCostScale",get_islandSolverBodyCostScale,set_islandSolverBodyCostScale,true);
		addMember(l,"islandSolverContactCostScale",get_islandSolverContactCostScale,set_islandSolverContactCostScale,true);
		addMember(l,"islandSolverJointCostScale",get_islandSolverJointCostScale,set_islandSolverJointCostScale,true);
		addMember(l,"islandSolverBodiesPerJob",get_islandSolverBodiesPerJob,set_islandSolverBodiesPerJob,true);
		addMember(l,"islandSolverContactsPerJob",get_islandSolverContactsPerJob,set_islandSolverContactsPerJob,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.PhysicsJobOptions2D),typeof(System.ValueType));
	}
}
