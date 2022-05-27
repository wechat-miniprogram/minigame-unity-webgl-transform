using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
#if !SLUA_STANDALONE
using UnityEngine;
#endif

namespace SLua{
	public static class Lua3rdDLL{
		static Dictionary<string, LuaCSFunction> DLLRegFuncs = new Dictionary<string, LuaCSFunction>();
		
		static Lua3rdDLL(){
			// LuaSocketDLL.Reg(DLLRegFuncs);
		}
		
		public static void open(IntPtr L){
			var typenames = Lua3rdMeta.Instance.typesWithAttribtues;
			var assemblys = AppDomain.CurrentDomain.GetAssemblies();
			Assembly assembly = null;
			foreach(var ass in assemblys){
				if(ass.GetName().Name == "Assembly-CSharp"){
					assembly = ass;
					break;
				}
			}
			if(assembly != null){
				foreach(var typename in typenames){
					var type = assembly.GetType(typename);
					var methods = type.GetMethods(BindingFlags.Static|BindingFlags.Public);
					foreach(var method in methods){
						var attr = System.Attribute.GetCustomAttribute(method,typeof(LualibRegAttribute)) as LualibRegAttribute;
						if(attr != null){
							var csfunc = Delegate.CreateDelegate(typeof(LuaCSFunction),method) as LuaCSFunction;
							DLLRegFuncs.Add(attr.luaName,csfunc);
						}
					}
				}
			}
			
			if(DLLRegFuncs.Count == 0){
				return;
			}
			
			LuaDLL.lua_getglobal(L, "package");
			LuaDLL.lua_getfield(L, -1, "preload");
			foreach (KeyValuePair<string, LuaCSFunction> pair in DLLRegFuncs) {
				LuaDLL.lua_pushcfunction (L, pair.Value);
				LuaDLL.lua_setfield(L, -2, pair.Key);
			}
			
			LuaDLL.lua_settop(L, 0);
		}


		[AttributeUsage(AttributeTargets.Method)]
		public class LualibRegAttribute:System.Attribute{

			public string luaName;
			public LualibRegAttribute(string luaName){
				this.luaName = luaName;
			}
		}
	}

}