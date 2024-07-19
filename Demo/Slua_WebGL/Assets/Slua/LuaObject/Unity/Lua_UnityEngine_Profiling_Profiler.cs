using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Profiling_Profiler : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetAreaEnabled_s(IntPtr l) {
		try {
			UnityEngine.Profiling.ProfilerArea a1;
			a1 = (UnityEngine.Profiling.ProfilerArea)LuaDLL.luaL_checkinteger(l, 1);
			System.Boolean a2;
			checkType(l,2,out a2);
			UnityEngine.Profiling.Profiler.SetAreaEnabled(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetAreaEnabled_s(IntPtr l) {
		try {
			UnityEngine.Profiling.ProfilerArea a1;
			a1 = (UnityEngine.Profiling.ProfilerArea)LuaDLL.luaL_checkinteger(l, 1);
			var ret=UnityEngine.Profiling.Profiler.GetAreaEnabled(a1);
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
	static public int AddFramesFromFile_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			UnityEngine.Profiling.Profiler.AddFramesFromFile(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int BeginThreadProfiling_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.String a2;
			checkType(l,2,out a2);
			UnityEngine.Profiling.Profiler.BeginThreadProfiling(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int EndThreadProfiling_s(IntPtr l) {
		try {
			UnityEngine.Profiling.Profiler.EndThreadProfiling();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int BeginSample_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				System.String a1;
				checkType(l,1,out a1);
				UnityEngine.Profiling.Profiler.BeginSample(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==2){
				System.String a1;
				checkType(l,1,out a1);
				UnityEngine.Object a2;
				checkType(l,2,out a2);
				UnityEngine.Profiling.Profiler.BeginSample(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function BeginSample to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int EndSample_s(IntPtr l) {
		try {
			UnityEngine.Profiling.Profiler.EndSample();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetRuntimeMemorySizeLong_s(IntPtr l) {
		try {
			UnityEngine.Object a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Profiling.Profiler.GetRuntimeMemorySizeLong(a1);
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
	static public int GetMonoHeapSizeLong_s(IntPtr l) {
		try {
			var ret=UnityEngine.Profiling.Profiler.GetMonoHeapSizeLong();
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
	static public int GetMonoUsedSizeLong_s(IntPtr l) {
		try {
			var ret=UnityEngine.Profiling.Profiler.GetMonoUsedSizeLong();
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
	static public int SetTempAllocatorRequestedSize_s(IntPtr l) {
		try {
			System.UInt32 a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Profiling.Profiler.SetTempAllocatorRequestedSize(a1);
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
	static public int GetTempAllocatorSize_s(IntPtr l) {
		try {
			var ret=UnityEngine.Profiling.Profiler.GetTempAllocatorSize();
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
	static public int GetTotalAllocatedMemoryLong_s(IntPtr l) {
		try {
			var ret=UnityEngine.Profiling.Profiler.GetTotalAllocatedMemoryLong();
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
	static public int GetTotalUnusedReservedMemoryLong_s(IntPtr l) {
		try {
			var ret=UnityEngine.Profiling.Profiler.GetTotalUnusedReservedMemoryLong();
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
	static public int GetTotalReservedMemoryLong_s(IntPtr l) {
		try {
			var ret=UnityEngine.Profiling.Profiler.GetTotalReservedMemoryLong();
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
	static public int GetTotalFragmentationInfo_s(IntPtr l) {
		try {
			Unity.Collections.NativeArray<System.Int32> a1;
			checkValueType(l,1,out a1);
			var ret=UnityEngine.Profiling.Profiler.GetTotalFragmentationInfo(a1);
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
	static public int GetAllocatedMemoryForGraphicsDriver_s(IntPtr l) {
		try {
			var ret=UnityEngine.Profiling.Profiler.GetAllocatedMemoryForGraphicsDriver();
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
	static public int EmitFrameMetaData_s(IntPtr l) {
		try {
			System.Guid a1;
			checkValueType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			System.Array a3;
			checkType(l,3,out a3);
			UnityEngine.Profiling.Profiler.EmitFrameMetaData(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int EmitSessionMetaData_s(IntPtr l) {
		try {
			System.Guid a1;
			checkValueType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			System.Array a3;
			checkType(l,3,out a3);
			UnityEngine.Profiling.Profiler.EmitSessionMetaData(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetCategoryEnabled_s(IntPtr l) {
		try {
			Unity.Profiling.ProfilerCategory a1;
			checkValueType(l,1,out a1);
			System.Boolean a2;
			checkType(l,2,out a2);
			UnityEngine.Profiling.Profiler.SetCategoryEnabled(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int IsCategoryEnabled_s(IntPtr l) {
		try {
			Unity.Profiling.ProfilerCategory a1;
			checkValueType(l,1,out a1);
			var ret=UnityEngine.Profiling.Profiler.IsCategoryEnabled(a1);
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
	static public int GetCategoriesCount_s(IntPtr l) {
		try {
			var ret=UnityEngine.Profiling.Profiler.GetCategoriesCount();
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
	static public int GetAllCategories_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(Unity.Profiling.ProfilerCategory[]))){
				Unity.Profiling.ProfilerCategory[] a1;
				checkArray(l,1,out a1);
				UnityEngine.Profiling.Profiler.GetAllCategories(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(Unity.Collections.NativeArray<Unity.Profiling.ProfilerCategory>))){
				Unity.Collections.NativeArray<Unity.Profiling.ProfilerCategory> a1;
				checkValueType(l,1,out a1);
				UnityEngine.Profiling.Profiler.GetAllCategories(a1);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetAllCategories to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_supported(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Profiling.Profiler.supported);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_logFile(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Profiling.Profiler.logFile);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_logFile(IntPtr l) {
		try {
			string v;
			checkType(l,2,out v);
			UnityEngine.Profiling.Profiler.logFile=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_enableBinaryLog(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Profiling.Profiler.enableBinaryLog);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_enableBinaryLog(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Profiling.Profiler.enableBinaryLog=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maxUsedMemory(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Profiling.Profiler.maxUsedMemory);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_maxUsedMemory(IntPtr l) {
		try {
			int v;
			checkType(l,2,out v);
			UnityEngine.Profiling.Profiler.maxUsedMemory=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_enabled(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Profiling.Profiler.enabled);
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
			bool v;
			checkType(l,2,out v);
			UnityEngine.Profiling.Profiler.enabled=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_enableAllocationCallstacks(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Profiling.Profiler.enableAllocationCallstacks);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_enableAllocationCallstacks(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Profiling.Profiler.enableAllocationCallstacks=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_areaCount(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Profiling.Profiler.areaCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_usedHeapSizeLong(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Profiling.Profiler.usedHeapSizeLong);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Profiling.Profiler");
		addMember(l,SetAreaEnabled_s);
		addMember(l,GetAreaEnabled_s);
		addMember(l,AddFramesFromFile_s);
		addMember(l,BeginThreadProfiling_s);
		addMember(l,EndThreadProfiling_s);
		addMember(l,BeginSample_s);
		addMember(l,EndSample_s);
		addMember(l,GetRuntimeMemorySizeLong_s);
		addMember(l,GetMonoHeapSizeLong_s);
		addMember(l,GetMonoUsedSizeLong_s);
		addMember(l,SetTempAllocatorRequestedSize_s);
		addMember(l,GetTempAllocatorSize_s);
		addMember(l,GetTotalAllocatedMemoryLong_s);
		addMember(l,GetTotalUnusedReservedMemoryLong_s);
		addMember(l,GetTotalReservedMemoryLong_s);
		addMember(l,GetTotalFragmentationInfo_s);
		addMember(l,GetAllocatedMemoryForGraphicsDriver_s);
		addMember(l,EmitFrameMetaData_s);
		addMember(l,EmitSessionMetaData_s);
		addMember(l,SetCategoryEnabled_s);
		addMember(l,IsCategoryEnabled_s);
		addMember(l,GetCategoriesCount_s);
		addMember(l,GetAllCategories_s);
		addMember(l,"supported",get_supported,null,false);
		addMember(l,"logFile",get_logFile,set_logFile,false);
		addMember(l,"enableBinaryLog",get_enableBinaryLog,set_enableBinaryLog,false);
		addMember(l,"maxUsedMemory",get_maxUsedMemory,set_maxUsedMemory,false);
		addMember(l,"enabled",get_enabled,set_enabled,false);
		addMember(l,"enableAllocationCallstacks",get_enableAllocationCallstacks,set_enableAllocationCallstacks,false);
		addMember(l,"areaCount",get_areaCount,null,false);
		addMember(l,"usedHeapSizeLong",get_usedHeapSizeLong,null,false);
		createTypeMetatable(l,null, typeof(UnityEngine.Profiling.Profiler));
	}
}
