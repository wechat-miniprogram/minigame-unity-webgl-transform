// The MIT License (MIT)

// Copyright 2015 Siney/Pangweiwei siney@yeah.net
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

// uncomment this will use static binder(class BindCustom/BindUnity), 
// init will not use reflection to speed up the speed
//#define USE_STATIC_BINDER  

namespace SLua
{
	using System;
	using System.Threading;
	using System.Collections;
	using System.Collections.Generic;
	using System.Reflection;
	#if !SLUA_STANDALONE
	using UnityEngine;
	using Debug = UnityEngine.Debug;
	#endif

	public enum LuaSvrFlag {
		LSF_BASIC = 0,
		LSF_EXTLIB = 1,
		LSF_3RDDLL = 2,
	};

	public class LuaSvr 
	{
		static public MainState mainState;

		public class MainState : LuaState {

			int errorReported = 0;

			protected override void tick() {
				base.tick ();
				#if !SLUA_STANDALONE
				LuaTimer.tick(Time.deltaTime);
				#endif
				checkTop ();
			}

			internal void checkTop()
			{
				if (LuaDLL.lua_gettop(L) != errorReported)
				{
					errorReported = LuaDLL.lua_gettop(L);
					Logger.LogError(string.Format("Some function not remove temp value({0}) from lua stack. You should fix it.",LuaDLL.luaL_typename(L,errorReported)));
				}
			}
		}

		public LuaSvr()
		{
			mainState = new MainState();
            mainState.Name = "main";
		}

		static List<Action<IntPtr>> collectBindInfo() {

			List<Action<IntPtr>> list = new List<Action<IntPtr>>();

			#if !SLUA_STANDALONE
			#if !USE_STATIC_BINDER
			Assembly[] ams = AppDomain.CurrentDomain.GetAssemblies();

			List<Type> bindlist = new List<Type>();
			for (int n = 0; n < ams.Length;n++ )
			{
				Assembly a = ams[n];
				Type[] ts = null;
				try
				{
					ts = a.GetExportedTypes();
				}
				catch
				{
					continue;
				}
				for (int k = 0; k < ts.Length; k++)
				{
					Type t = ts[k];
					if (t.IsDefined(typeof(LuaBinderAttribute), false))
					{
						bindlist.Add(t);
					}
				}
			}

			bindlist.Sort(new System.Comparison<Type>((Type a, Type b) => {
				LuaBinderAttribute la = System.Attribute.GetCustomAttribute( a, typeof(LuaBinderAttribute) ) as LuaBinderAttribute;
				LuaBinderAttribute lb = System.Attribute.GetCustomAttribute( b, typeof(LuaBinderAttribute) ) as LuaBinderAttribute;

				return la.order.CompareTo(lb.order);
			}));

			for (int n = 0; n < bindlist.Count; n++)
			{
				Type t = bindlist[n];
				var sublist = (Action<IntPtr>[])t.GetMethod("GetBindList").Invoke(null, null);
				list.AddRange(sublist);
			}
			#else
			var assemblyName = "Assembly-CSharp";
			Assembly assembly = Assembly.Load(assemblyName);
			list.AddRange(getBindList(assembly,"SLua.BindUnity"));
			list.AddRange(getBindList(assembly,"SLua.BindUnityUI"));
			list.AddRange(getBindList(assembly,"SLua.BindDll"));
			list.AddRange(getBindList(assembly,"SLua.BindCustom"));
			#endif
			#endif

			return list;

		}


		static internal void doBind(IntPtr L)
		{
			var list = collectBindInfo ();

			int count = list.Count;
			for (int n = 0; n < count; n++)
			{
				Action<IntPtr> action = list[n];
				action(L);
			}
		}



		static internal IEnumerator doBind(IntPtr L,Action<int> _tick,Action complete)
		{
			Action<int> tick = (int p) => {
				if (_tick != null)
					_tick (p);
			};

			tick (0);
			var list = collectBindInfo ();

			tick (2);

			int bindProgress = 2;
			int lastProgress = bindProgress;
			for (int n = 0; n < list.Count; n++)
			{
				Action<IntPtr> action = list[n];
				action(L);
				bindProgress = (int)(((float)n / list.Count) * 98.0) + 2;
				if (_tick!=null && lastProgress != bindProgress && bindProgress % 5 == 0) {
                    lastProgress = bindProgress;
					tick (bindProgress);
					yield return null;
				}
			}

			tick (100);
			complete ();
		}

		Action<IntPtr>[] getBindList(Assembly assembly,string ns) {
			Type t=assembly.GetType(ns);
			if(t!=null)
				return (Action<IntPtr>[]) t.GetMethod("GetBindList").Invoke(null, null);
			return new Action<IntPtr>[0];
		}

        protected void doinit(LuaState L,LuaSvrFlag flag)
		{
			L.openSluaLib ();
			LuaValueType.reg(L.L);
			if ((flag & LuaSvrFlag.LSF_EXTLIB)!=0) {
				L.openExtLib ();
			}

			if((flag & LuaSvrFlag.LSF_3RDDLL)!=0)
				Lua3rdDLL.open(L.L);

		}

		public void init(Action<int> tick,Action complete,LuaSvrFlag flag=LuaSvrFlag.LSF_BASIC|LuaSvrFlag.LSF_EXTLIB)
		{
			
			IntPtr L = mainState.L;
			LuaObject.init(L);

			#if SLUA_STANDALONE
			doBind(L);
			doinit(mainState, flag);
			complete();
			mainState.checkTop();
			#else


			#if UNITY_EDITOR
			if (!UnityEditor.EditorApplication.isPlaying)
			{
				doBind(L);
				doinit(mainState, flag);
				complete();
				mainState.checkTop();
			}
			else
			{
			#endif
				mainState.lgo.StartCoroutine(doBind(L,tick, () =>
					{
						doinit(mainState, flag);
						complete();
						mainState.checkTop();
					}));
			#if UNITY_EDITOR
			}
			#endif
			#endif
		}

		public object start(string main)
		{
			if (main != null)
			{
				mainState.doFile(main);
                return mainState.run("main");
			}
			return null;
		}
	}
}
