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

using System.Collections;
namespace SLua
{
    using UnityEngine;

    public static class UnityExtension
    {
        public static Coroutine StartCoroutine(this MonoBehaviour mb, LuaFunction func)
        {
            return mb.StartCoroutine(LuaCoroutine(func));
        }

        // 该类型返回给 yield return 时 视为传值 效果等价于 yield break
        internal class YieldBreak
        {
            public object[] values;
            
            public YieldBreak(params object[] values)
            {
                this.values = values;
            }
        }

        internal static IEnumerator LuaCoroutine(LuaFunction func)
        {
            var thread = new LuaThreadWrapper(func);
            object[] return_values = null;
            while (true)
            {
                object yield_from_lua;
                if (!thread.Resume(out yield_from_lua, return_values))
                {
                    return_values = null;
                    break;
                }

                var enumerator = yield_from_lua as IEnumerator;
                if (enumerator != null) 
                {
                    // 如果是迭代器，则尝试自己迭代，并检测 YieldBreak 传值指令
                    while (enumerator.MoveNext())
                    {
                        var current = enumerator.Current;
                        var obj_t = current as YieldBreak;
                        if (obj_t != null)
                        {
                            return_values = obj_t.values;
                            break; // 丢弃当前迭代器
                        }
                        else
                        {
                            return_values = null;
                            yield return current;
                        }
                    }
                }
                else
                {
                    yield return yield_from_lua;
                }
            }
        }
    }
}