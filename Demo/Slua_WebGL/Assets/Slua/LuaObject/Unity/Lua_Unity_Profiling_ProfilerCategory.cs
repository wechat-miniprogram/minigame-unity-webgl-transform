using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_Unity_Profiling_ProfilerCategory : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			Unity.Profiling.ProfilerCategory o;
			if(argc==2){
				System.String a1;
				checkType(l,2,out a1);
				o=new Unity.Profiling.ProfilerCategory(a1);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==3){
				System.String a1;
				checkType(l,2,out a1);
				Unity.Profiling.ProfilerCategoryColor a2;
				a2 = (Unity.Profiling.ProfilerCategoryColor)LuaDLL.luaL_checkinteger(l, 3);
				o=new Unity.Profiling.ProfilerCategory(a1,a2);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==0){
				o=new Unity.Profiling.ProfilerCategory();
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
	static public int get_Name(IntPtr l) {
		try {
			Unity.Profiling.ProfilerCategory self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.Name);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_Color(IntPtr l) {
		try {
			Unity.Profiling.ProfilerCategory self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.Color);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_Render(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,Unity.Profiling.ProfilerCategory.Render);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_Scripts(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,Unity.Profiling.ProfilerCategory.Scripts);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_Gui(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,Unity.Profiling.ProfilerCategory.Gui);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_Physics(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,Unity.Profiling.ProfilerCategory.Physics);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_Animation(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,Unity.Profiling.ProfilerCategory.Animation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_Ai(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,Unity.Profiling.ProfilerCategory.Ai);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_Audio(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,Unity.Profiling.ProfilerCategory.Audio);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_Video(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,Unity.Profiling.ProfilerCategory.Video);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_Particles(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,Unity.Profiling.ProfilerCategory.Particles);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_Lighting(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,Unity.Profiling.ProfilerCategory.Lighting);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_Network(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,Unity.Profiling.ProfilerCategory.Network);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_Loading(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,Unity.Profiling.ProfilerCategory.Loading);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_Vr(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,Unity.Profiling.ProfilerCategory.Vr);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_Input(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,Unity.Profiling.ProfilerCategory.Input);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_Memory(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,Unity.Profiling.ProfilerCategory.Memory);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_VirtualTexturing(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,Unity.Profiling.ProfilerCategory.VirtualTexturing);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_FileIO(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,Unity.Profiling.ProfilerCategory.FileIO);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_Internal(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,Unity.Profiling.ProfilerCategory.Internal);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"Unity.Profiling.ProfilerCategory");
		addMember(l,"Name",get_Name,null,true);
		addMember(l,"Color",get_Color,null,true);
		addMember(l,"Render",get_Render,null,false);
		addMember(l,"Scripts",get_Scripts,null,false);
		addMember(l,"Gui",get_Gui,null,false);
		addMember(l,"Physics",get_Physics,null,false);
		addMember(l,"Animation",get_Animation,null,false);
		addMember(l,"Ai",get_Ai,null,false);
		addMember(l,"Audio",get_Audio,null,false);
		addMember(l,"Video",get_Video,null,false);
		addMember(l,"Particles",get_Particles,null,false);
		addMember(l,"Lighting",get_Lighting,null,false);
		addMember(l,"Network",get_Network,null,false);
		addMember(l,"Loading",get_Loading,null,false);
		addMember(l,"Vr",get_Vr,null,false);
		addMember(l,"Input",get_Input,null,false);
		addMember(l,"Memory",get_Memory,null,false);
		addMember(l,"VirtualTexturing",get_VirtualTexturing,null,false);
		addMember(l,"FileIO",get_FileIO,null,false);
		addMember(l,"Internal",get_Internal,null,false);
		createTypeMetatable(l,constructor, typeof(Unity.Profiling.ProfilerCategory),typeof(System.ValueType));
	}
}
