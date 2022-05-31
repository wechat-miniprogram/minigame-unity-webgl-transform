using System;
using System.Collections.Generic;
namespace SLua {
	[LuaBinder(3)]
	public class BindCustom {
		public static Action<IntPtr>[] GetBindList() {
			Action<IntPtr>[] list= {
				Lua_Custom.reg,
				Lua_Deleg.reg,
				Lua_foostruct.reg,
				Lua_FloatEvent.reg,
				Lua_ListViewEvent.reg,
				Lua_SLuaTest.reg,
				Lua_System_Collections_Generic_List_1_int.reg,
				Lua_XXList.reg,
				Lua_AbsClass.reg,
				Lua_HelloWorld.reg,
				Lua_NewCoroutine.reg,
				Lua_Custom_IFoo.reg,
				Lua_System_String.reg,
				Lua_System_Collections_Generic_List_1_UnityEngine_UICharInfo.reg,
				Lua_System_Collections_Generic_List_1_string.reg,
				Lua_UnityEngine_Networking_UnityWebRequest.reg,
				Lua_UnityEngine_AI_NavMeshAgent.reg,
				Lua_UnityEngine_AI_NavMeshPath.reg,
				Lua_UnityEngine_AI_NavMeshHit.reg,
				Lua_UnityEngine_AI_NavMesh.reg,
			};
			return list;
		}
	}
}
