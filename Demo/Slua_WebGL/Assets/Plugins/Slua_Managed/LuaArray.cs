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
#if !SLUA_STANDALONE
	using UnityEngine;
#endif
	using System.Collections;
	using System.Collections.Generic;
	using System;
	using System.Reflection;
	using System.Runtime.InteropServices;

	class LuaArray : LuaObject
	{


		static int toTable(IntPtr l,Array o)
		{

			if (o == null)
			{
				LuaDLL.lua_pushnil(l);
				return 1;
			}
			LuaDLL.lua_createtable(l, o.Length, 0);
			for (int n = 0; n < o.Length; n++)
			{
				pushVar(l, o.GetValue(n));
				LuaDLL.lua_rawseti(l, -2, n + 1);
			}
			return 1;
		}

		static int length(IntPtr l,Array a)
		{
			pushValue(l, a.Length);
			return 1;
		}

		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static public int len(IntPtr l)
		{
			Array a = (Array)checkSelf(l);
			pushValue(l, a.Length);
			return 1;
		}

		delegate int ArrayPropFunction(IntPtr l, Array a);

		static Dictionary<string, ArrayPropFunction> propMethod = new Dictionary<string, ArrayPropFunction>();
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static public int luaIndex(IntPtr l)
		{
			try
			{
				Array a=(Array)checkSelf(l);
				if (LuaDLL.lua_type(l, 2) == LuaTypes.LUA_TSTRING)
				{
					string mn;
					checkType(l, 2, out mn);
					ArrayPropFunction fun;
					if (propMethod.TryGetValue(mn, out fun))
					{
						pushValue(l, true);
						return fun(l, a) + 1;
					}
					else
						throw new Exception("Can't find property named " + mn);
				}
				else
				{
					int i;
					checkType(l, 2, out i);
					assert(i>0,"index base 1");
					pushValue(l, true);
					pushVar(l, a.GetValue(i-1));
					return 2;
				}	
			}
			catch (Exception e)
			{
				return error(l, e);
			}
		}

		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static public int luaNewIndex(IntPtr l)
		{
			try
			{
				Array a = (Array)checkSelf(l);
				int i;
				checkType(l, 2, out i);
				assert(i>0,"index base 1");
				object o=checkVar(l, 3);
				Type et = a.GetType().GetElementType();
				a.SetValue(changeType(o,et), i-1);
				return ok(l);
			}
			catch (Exception e)
			{
				return error(l, e);
			}
		}

		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static public int tostring(IntPtr l)
		{
			Array a = (Array)checkSelf(l);
			pushValue(l, string.Format("Array<{0}>",a.GetType().GetElementType().Name));
			return 1;
		}

		static new public void init(IntPtr l)
		{

			propMethod["Table"] = toTable;
			propMethod["Length"] = length;

			LuaDLL.lua_createtable(l, 0, 5);
			pushValue(l, luaIndex);
			LuaDLL.lua_setfield(l, -2, "__index");
			pushValue(l, luaNewIndex);
			LuaDLL.lua_setfield(l, -2, "__newindex");
			LuaDLL.lua_pushcfunction(l, lua_gc);
			LuaDLL.lua_setfield(l, -2, "__gc");
			LuaDLL.lua_pushcfunction(l, tostring);
			LuaDLL.lua_setfield(l, -2, "__tostring");
			LuaDLL.lua_pushcfunction(l, len);
			LuaDLL.lua_setfield(l, -2, "__len");

			LuaDLL.lua_setfield(l, LuaIndexes.LUA_REGISTRYINDEX, "LuaArray");
		}
	}
}
