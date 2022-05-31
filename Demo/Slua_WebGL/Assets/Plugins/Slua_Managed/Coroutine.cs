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

#if !SLUA_STANDALONE
namespace SLua
{
	using UnityEngine;
	using System.Collections;
	using SLua;
	using System;

	public class LuaCoroutine : LuaObject
	{

		static MonoBehaviour mb;

		static public void reg(IntPtr l, MonoBehaviour m)
		{
			mb = m;
			reg(l, Yieldk, "UnityEngine");

			string yield =
@"
local Yield = UnityEngine.Yieldk

uCoroutine = uCoroutine or {}

uCoroutine.create = function(x)

	local co = coroutine.create(x)
	coroutine.resume(co)
	return co

end

uCoroutine.yield = function(x)

	local co, ismain = coroutine.running()
	if ismain then error('Can not yield in main thread') end

	if type(x) == 'thread' and coroutine.status(x) ~= 'dead' then
		repeat
			Yield(nil, function() coroutine.resume(co) end)
			coroutine.yield()
		until coroutine.status(x) == 'dead'
	else
		Yield(x, function() coroutine.resume(co) end)
		coroutine.yield()
	end

end

-- backward compatibility of older versions
UnityEngine.Yield = uCoroutine.yield
";
			LuaState.get(l).doString(yield);
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		static public int Yieldk(IntPtr l)
		{
			try
			{
				if (LuaDLL.lua_pushthread(l) == 1)
				{
					return error(l, "should put Yield call into lua coroutine.");
				}
				object y = checkObj(l, 1);
				LuaFunction f;
				checkType(l, 2, out f);

				mb.StartCoroutine(yieldReturn(y, f));
				pushValue(l, true);
				return 1;
			}
			catch (Exception e)
			{
				return error(l, e);
			}
		}

		static public IEnumerator yieldReturn(object y, LuaFunction f)
		{
			if (y is IEnumerator)
				yield return mb.StartCoroutine((IEnumerator)y);
			else
				yield return y;
			f.call();
		}

	}
}
#endif
