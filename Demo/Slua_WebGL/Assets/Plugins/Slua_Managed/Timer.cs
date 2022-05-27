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

namespace SLua
{
	using System;
	using System.Collections.Generic;
	
	public class LuaTimer : LuaObject
	{
		const int TimerMaxInit = 16;
		class Timer
		{
			internal int sn;
			internal int cycle;
			internal int deadline;
			internal Func<int, bool> handler;
			internal bool delete;
            internal IntPtr L;
			internal List<Timer> container;
		}
		class Wheel
		{
			internal static int dial_scale = 256;
			internal int head;
			internal List<Timer>[] vecDial;
			internal int dialSize;
			internal int timeRange;
			internal Wheel nextWheel;
			internal Wheel(int dialSize)
			{
				this.dialSize = dialSize;
				this.timeRange = dialSize * dial_scale;
				this.head = 0;
				this.vecDial = new List<Timer>[dial_scale];
				for (int i = 0; i < dial_scale; ++i)
				{
					this.vecDial[i] = new List<Timer>(TimerMaxInit);
				}
			}
			internal List<Timer> nextDial()
			{
				return vecDial[head++];
			}
			internal void add(int delay, Timer tm)
			{
				var container = vecDial[(head + (delay - (dialSize - jiffies_msec)) / dialSize) % dial_scale];
				container.Add(tm);
				tm.container = container;
			}
		}
		static int nextSn = 0;
		static int jiffies_msec = 20;
		static float jiffies_sec = jiffies_msec * .001f;
		static Wheel[] wheels;
		static float pileSecs;
		static float nowTime;
		static Dictionary<int, Timer> mapSnTimer;
		static List<Timer> executeTimers;

		static int intpow(int n, int m)
		{
			int ret = 1;
			for (int i = 0; i < m; ++i)
				ret *= n;
			return ret;
		}
		
		static void innerAdd(int deadline, Timer tm)
		{
			tm.deadline = deadline;
			int delay = Math.Max(0, deadline - now());
			Wheel suitableWheel = wheels[wheels.Length - 1];
			for (int i = 0; i < wheels.Length; ++i)
			{
				var wheel = wheels[i];
				if (delay < wheel.timeRange)
				{
					suitableWheel = wheel;
					break;
				}
			}
			suitableWheel.add(delay, tm);
		}
		
		static void innerDel(Timer tm)
		{
			innerDel(tm, true);
		}
		
		static void innerDel(Timer tm,bool removeFromMap)
		{
			tm.delete = true;
			if (tm.container != null)
			{
				tm.container.Remove(tm);
				tm.container = null;
			}
			if (removeFromMap) mapSnTimer.Remove(tm.sn);
		}
		
		static int now()
		{
			return (int)(nowTime * 1000);
		}
		
		internal static void tick(float deltaTime)
		{
			if (executeTimers == null)
				return;

			//UnityEngine.Profiling.Profiler.BeginSample ("timer tick");
			nowTime += deltaTime;
			pileSecs += deltaTime;
			int cycle = 0;
			while (pileSecs >= jiffies_sec)
			{
				pileSecs -= jiffies_sec;
				cycle++;
			}
			for (int i = 0; i < cycle; ++i)
			{
				var timers = wheels[0].nextDial();
				for (int j = 0; j < timers.Count; ++j)
				{
					var tm = timers[j];
					executeTimers.Add(tm);
				}
				timers.Clear();
				
				for (int j = 0; j < wheels.Length; ++j)
				{
					var wheel = wheels[j];
					if (wheel.head == Wheel.dial_scale)
					{
						wheel.head = 0;
						if (wheel.nextWheel != null)
						{
							var tms = wheel.nextWheel.nextDial();
							for (int k = 0; k < tms.Count; ++k)
							{
								var tm = tms[k];
								if (tm.delete)
								{
									mapSnTimer.Remove(tm.sn);
								}
								else
								{
									innerAdd(tm.deadline, tm);
								}
							}
							tms.Clear();
						}
					}
					else
					{
						break;
					}
				}
			}
			// run timer callback
			for (int n=0;n<executeTimers.Count;n++)
			{
				var tm = executeTimers[n];
				// if callback return true or any value!=false, 
				// re-add timer to new wheel
				if (!tm.delete && tm.handler(tm.sn) && tm.cycle > 0)
				{
					innerAdd(now() + tm.cycle, tm);
				}
				else
				{
					mapSnTimer.Remove(tm.sn);
				}
			}
			executeTimers.Clear();
			//UnityEngine.Profiling.Profiler.EndSample ();
		}
        static bool inited = false;
		static void init()
		{
            if (inited) return;
            inited = true;

			wheels = new Wheel[4];
			for (int i = 0; i < 4; ++i)
			{
				wheels[i] = new Wheel(jiffies_msec * intpow(Wheel.dial_scale, i));
				if (i > 0)
				{
					wheels[i - 1].nextWheel = wheels[i];
				}
			}
			mapSnTimer = new Dictionary<int, Timer>();
			executeTimers = new List<Timer>(TimerMaxInit);
		}
		
		static int fetchSn()
		{
			return ++nextSn;
		}
		
		internal static int add(IntPtr L,int delay, Action<int> handler)
		{
			return add(L,delay, 0, (int sn) =>
            {
				handler(sn);
				return false;
			});
		}
		
		internal static int add(IntPtr L,int delay, int cycle, Func<int, bool> handler)
		{
			Timer tm = new Timer();
			tm.sn = fetchSn();
			tm.cycle = cycle;
			tm.handler = handler;
            tm.L = L;
			mapSnTimer[tm.sn] = tm;
			innerAdd(now() + delay, tm);
			return tm.sn;
		}
		
		internal static void del(int sn)
		{
			Timer tm;
			if (mapSnTimer.TryGetValue(sn, out tm))
			{
				innerDel(tm);
			}
		}
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		public static int Delete(IntPtr l)
		{
			try{
				int id;
				checkType(l, 1, out id);
				del(id);
				return ok(l);
			}catch(Exception e)
			{
				return LuaObject.error(l, e);
			}
		}
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		public static int Add(IntPtr l)
		{
			try{
				int top = LuaDLL.lua_gettop(l);
				if (top == 2)
				{
					int delay;
					checkType(l, 1, out delay);
					LuaDelegate ld;
					checkType(l, 2, out ld);
					Action<int> ua;
					if (ld.d != null)
						ua = (Action<int>)ld.d;
					else
					{
						IntPtr ml = LuaState.get(l).L;
						ua = (int id) =>
						{
							int error = pushTry(ml);
							pushValue(ml, id);
							ld.pcall(1, error);
							LuaDLL.lua_settop(ml, error - 1);
						};
					}
					ld.d = ua;
					pushValue(l, true);
					pushValue(l, add(l, delay, ua));
					return 2;
				}
				else if (top == 3)
				{
					int delay, cycle;
					checkType(l, 1, out delay);
					checkType(l, 2, out cycle);
					LuaDelegate ld;
					checkType(l, 3, out ld);
					Func<int, bool> ua;
					
					if (ld.d != null)
						ua = (Func<int, bool>)ld.d;
					else
					{
						IntPtr ml = LuaState.get(l).L;
						ua = (int id) =>
						{
							int error = pushTry(ml);
							pushValue(ml, id);
							ld.pcall(1, error);
							bool ret = LuaDLL.lua_toboolean(ml, -1);
							LuaDLL.lua_settop(ml, error - 1);
							return ret;
						};
					}
					ld.d = ua;
					pushValue(l, true);
					pushValue(l, add(l, delay, cycle, ua));
					return 2;
				}
				return LuaObject.error(l,"Argument error");
			}catch(Exception e)
			{
				return LuaObject.error(l, e);
			}
		}
		
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		public static int DeleteAll(IntPtr l)
		{
			if (mapSnTimer == null) return 0;
			try
			{
                List<int> rts = new List<int>();
				foreach (var t in mapSnTimer)
				{
                    if (t.Value.L == l)
                    {
                        innerDel(t.Value, false);
                        rts.Add(t.Key);
                    }
				}
                foreach (int k in rts)
                    mapSnTimer.Remove(k);
				
				pushValue(l, true);
				return 1;
			}
			catch (Exception e)
			{
				return LuaObject.error(l, e);
			}
		}
		
		
		static public void reg(IntPtr l)
		{
			init();
			getTypeTable(l, "LuaTimer");
			addMember(l, Add, false);
			addMember(l, Delete, false);
			addMember(l, DeleteAll, false);
			createTypeMetatable(l, typeof(LuaTimer));
		}
	}
	
}