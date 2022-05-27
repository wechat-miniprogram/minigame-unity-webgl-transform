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
    using System.Collections;
    using System.Collections.Generic;
    using System;
    using System.Reflection;
    using System.Runtime.InteropServices;

    // Try to avoid using this class for not export class
    // This class use reflection and not completed, you should write your code for your purpose.
    class LuaVarObject : LuaObject
    {

        /// <summary>
        /// A cache list of MemberInfo, for reflection optimize
        /// </summary>
        static Dictionary<Type, Dictionary<string, List<MemberInfo>>> cachedMemberInfos = new Dictionary<Type, Dictionary<string, List<MemberInfo>>>();

        class MethodWrapper
        {
            object self;
            IList<MemberInfo> mis;
            public MethodWrapper(object self, IList<MemberInfo> mi)
            {
                this.self = self;
                this.mis = mi;
            }

            bool matchType(IntPtr l, int p, LuaTypes lt, Type t)
            {
                if (t.IsPrimitive && t != typeof(bool))
                    return lt == LuaTypes.LUA_TNUMBER;

                if (t == typeof(bool))
                    return lt == LuaTypes.LUA_TBOOLEAN;

                if (t == typeof(string))
                    return lt == LuaTypes.LUA_TSTRING;

                switch (lt)
                {
                    case LuaTypes.LUA_TFUNCTION:
                        return t == typeof(LuaFunction) || t.BaseType == typeof(MulticastDelegate);
                    case LuaTypes.LUA_TTABLE:
                        return t == typeof(LuaTable) || LuaObject.luaTypeCheck(l, p, t.Name);
                    default:
                        return lt == LuaTypes.LUA_TUSERDATA || t == typeof(object);
                }
            }

            object checkVar(IntPtr l, int p, Type t)
            {
                string tn = t.Name;

                switch (tn)
                {
                    case "String":
                        {
                            string str;
                            if (checkType(l, p, out str))
                                return str;
                        }
                        break;
                    case "Decimal":
                        return (decimal)LuaDLL.lua_tonumber(l, p);
                    case "Int64":
                        return (long)LuaDLL.lua_tonumber(l, p);
                    case "UInt64":
                        return (ulong)LuaDLL.lua_tonumber(l, p);
                    case "Int32":
                        return (int)LuaDLL.lua_tointeger(l, p);
                    case "UInt32":
                        return (uint)LuaDLL.lua_tointeger(l, p);
                    case "Single":
                        return (float)LuaDLL.lua_tonumber(l, p);
                    case "Double":
                        return (double)LuaDLL.lua_tonumber(l, p);
                    case "Boolean":
                        return (bool)LuaDLL.lua_toboolean(l, p);
                    case "Byte":
                        return (byte)LuaDLL.lua_tointeger(l, p);
                    case "UInt16":
                        return (ushort)LuaDLL.lua_tointeger(l, p);
                    case "Int16":
                        return (short)LuaDLL.lua_tointeger(l, p);
                    default:
                        // Enum convert
                        if (t.IsEnum)
                        {
                            var num = LuaDLL.lua_tointeger(l, p);
                            return Enum.ToObject(t, num);
                        }
                        return LuaObject.checkVar(l, p);
                }
                return null;
            }

            internal bool matchType(IntPtr l, int from, ParameterInfo[] pis, bool isstatic)
            {
                int top = LuaDLL.lua_gettop(l);
                from = isstatic ? from : from + 1;

                if (top - from + 1 != pis.Length)
                    return false;

                for (int n = 0; n < pis.Length; n++)
                {
                    int p = n + from;
                    LuaTypes t = LuaDLL.lua_type(l, p);
                    if (!matchType(l, p, t, pis[n].ParameterType))
                        return false;
                }
                return true;
            }

            public int invoke(IntPtr l)
            {
                for (int k = 0; k < mis.Count; k++)
                {
                    MethodInfo m = (MethodInfo)mis[k];
                    if (matchType(l, 2, m.GetParameters(), m.IsStatic))
                    {
                        return forceInvoke(l, m);
                    }
                }
                // cannot find best match function, try call first one
                return forceInvoke(l, mis[0] as MethodInfo);
                //return error(l, "Can't find valid overload function {0} to invoke or parameter type mis-matched.", mis[0].Name);
            }

            /// <summary>
            /// invoke a C# method without match check
            /// </summary>
            /// <param name="l"></param>
            /// <param name="m"></param>
            /// <returns></returns>
			private int forceInvoke(IntPtr l, MethodInfo m)
			{
				object[] args;
				checkArgs(l, 1, m, out args);
				object ret = m.Invoke(m.IsStatic ? null : self, args);
				var pis = m.GetParameters();
				pushValue(l, true);
				if (ret != null)
				{
					pushVar(l, ret);
					int ct = 2;
					for (int i = 0; i < pis.Length; ++i) {
						var pi = pis[i];
						if (pi.ParameterType.IsByRef || pi.IsOut) {
							pushValue(l, args[i]);
							++ct;
						}
					}
					return ct;
				}
				return 1;
			}

            public void checkArgs(IntPtr l, int from, MethodInfo m, out object[] args)
            {
                ParameterInfo[] ps = m.GetParameters();
                args = new object[ps.Length];
                int k = 0;
                from = m.IsStatic ? from + 1 : from + 2;

                for (int n = from; n <= LuaDLL.lua_gettop(l); n++, k++)
                {
                    if (k + 1 > ps.Length)
                        break;
                    args[k] = checkVar(l, n, ps[k].ParameterType);
                }
            }
        }


        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static public int luaIndex(IntPtr l)
        {
            try
            {
                ObjectCache oc = ObjectCache.get(l);
                object self = oc.get(l, 1);

                LuaTypes t = LuaDLL.lua_type(l, 2);
                switch (t)
                {
                    case LuaTypes.LUA_TSTRING:
                        return indexString(l, self, LuaDLL.lua_tostring(l, 2));
                    case LuaTypes.LUA_TNUMBER:
                        return indexInt(l, self, LuaDLL.lua_tointeger(l, 2));
                    default:
                        return indexObject(l, self, checkObj(l, 2));
                }
            }
            catch (Exception e)
            {
                return error(l, e);
            }
        }

        static int indexObject(IntPtr l, object self, object key)
        {

            if (self is IDictionary)
            {
                var dict = self as IDictionary;
                
                object v = dict[key];
                pushValue(l, true);
                pushVar(l, v);
                return 2;
            }
            return 0;

        }

        static Type getType(object o)
        {
            if (o is LuaClassObject)
                return (o as LuaClassObject).GetClsType();
            return o.GetType();
        }

        static int indexString(IntPtr l, object self, string key)
        {
            Type t = getType(self);

            if (self is IDictionary)
            {
                if (t.IsGenericType && t.GetGenericArguments()[0] != typeof(string))
                {
                    goto IndexProperty;
                }
                object v = (self as IDictionary)[key];
                if (v != null)
                {
                    pushValue(l, true);
                    pushVar(l, v);
                    return 2;
                }
            }

            IndexProperty:

            var mis = GetCacheMembers(t, key);
            if (mis == null || mis.Count == 0)
            {
                return error(l, "Can't find " + key);
            }

            pushValue(l, true);
            MemberInfo mi = mis[0];
            switch (mi.MemberType)
            {
                case MemberTypes.Property:
                    PropertyInfo p = (PropertyInfo)mi;
                    MethodInfo get = p.GetGetMethod(true);
                    pushVar(l, get.Invoke(self, null));
                    break;
                case MemberTypes.Field:
                    FieldInfo f = (FieldInfo)mi;
                    pushVar(l, f.GetValue(self));
                    break;
                case MemberTypes.Method:
                    LuaCSFunction ff = new MethodWrapper(self, mis).invoke;
                    pushObject(l, ff);
                    break;
                case MemberTypes.Event:
                    break;
                default:
                    return 1;
            }

            return 2;

        }

        /// <summary>
        /// Collect Type Members, including base type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="key"></param>
        /// <param name="memberList"></param>
        static void CollectTypeMembers(Type type, ref Dictionary<string, List<MemberInfo>> membersMap)
        {
            var mems = type.GetMembers(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly); // GetMembers can get basetType's members, but GetMember cannot
            for (var i = 0; i < mems.Length; i++)
            {
                var mem = mems[i];
                List<MemberInfo> members;
                if (!membersMap.TryGetValue(mem.Name, out members))
                {
                    members = membersMap[mem.Name] = new List<MemberInfo>();
                }
                members.Add(mem);
            }
            if (type.BaseType != null)
            {
                CollectTypeMembers(type.BaseType, ref membersMap);
            }

        }
        /// <summary>
        /// Get Member from Type, use reflection, use cache Dictionary
        /// </summary>
        /// <param name="type"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        static IList<MemberInfo> GetCacheMembers(Type type, string key)
        {
            Dictionary<string, List<MemberInfo>> cache;
            if (!cachedMemberInfos.TryGetValue(type, out cache))
            {
                cachedMemberInfos[type] = cache = new Dictionary<string, List<MemberInfo>>();
                // Get Member including all parent fields
                CollectTypeMembers(type, ref cache);
            }
            return cache[key];
        }

        static int newindexString(IntPtr l, object self, string key)
        {
            if (self is IDictionary)
            {
                var dictType = getType(self);
                var valueType = dictType.GetGenericArguments()[1];
                (self as IDictionary)[key] = checkVar(l, 3, valueType);
                return ok(l);
            }

            Type t = getType(self);
            //MemberInfo[] mis = t.GetMember(key, BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            //if (mis.Length == 0)
            //{
            //    return error(l, "Can't find " + key);
            //}

            var mis = GetCacheMembers(t, key);
            if (mis == null || mis.Count == 0)
            {
                return error(l, "Can't find " + key);
            }
            MemberInfo mi = mis[0];
            switch (mi.MemberType)
            {
                case MemberTypes.Property:
                    {
                        PropertyInfo p = (PropertyInfo)mi;
                        MethodInfo set = p.GetSetMethod(true);
                        var value = checkVar(l, 3, p.PropertyType);
                        set.Invoke(self, new object[] { value });
                        break;
                    }
                case MemberTypes.Field:
                    {
                        FieldInfo f = (FieldInfo)mi;
                        var value = checkVar(l, 3, f.FieldType);
                        f.SetValue(self, value);
                        break;
                    }
                case MemberTypes.Method:
                    return error(l, "Method can't set");
                case MemberTypes.Event:
                    return error(l, "Event can't set");

            }
            return ok(l);
        }


        static int indexInt(IntPtr l, object self, int index)
        {
            Type type = getType(self);
            if (self is IList)
            {
                pushValue(l, true);
                pushVar(l, (self as IList)[index]);
                return 2;
            }
            else if (self is IDictionary)
            {
                var dict = (IDictionary)self;// as IDictionary;
                //support enumerate key
                object dictKey = index;
                if (type.IsGenericType)
                {
                    Type keyType = type.GetGenericArguments()[0];

                    if (keyType.IsEnum)
                    {
                        pushValue(l, true);
                        pushVar(l, dict[Enum.Parse(keyType, dictKey.ToString())]);
                        return 2;
                    }

                    dictKey = changeType(dictKey, keyType); // if key is not int but ushort/uint,  IDictionary will cannot find the key and return null!
                }
                
                pushValue(l, true);
                pushVar(l, dict[dictKey]);
                return 2;
            }
            return 0;
        }

        static int newindexInt(IntPtr l, object self, int index)
        {
            Type type = getType(self);
            if (self is IList)
            {
                if (type.IsGenericType)
                {
                    Type t = type.GetGenericArguments()[0];
                    (self as IList)[index] = changeType(checkVar(l, 3), t);
                }
                else
                    (self as IList)[index] = checkVar(l, 3);
            }
            else if (self is IDictionary)
            {
                Type keyType = type.GetGenericArguments()[0];
                object dictKey = index;
                dictKey = changeType(dictKey, keyType); // if key is not int but ushort/uint,  IDictionary will cannot find the key and return null!

                if (type.IsGenericType)
                {
                    Type t = type.GetGenericArguments()[1];
                    (self as IDictionary)[dictKey] = changeType(checkVar(l, 3), t);
                }
                else
                    (self as IDictionary)[dictKey] = checkVar(l, 3);
            }

            pushValue(l, true);
            return 1;
        }

        static int newindexObject(IntPtr l, object self, object k, object v)
        {
            if (self is IDictionary)
            {
                var dict = self as IDictionary;
                var dictType = getType(self);
                var valueType = dictType.GetGenericArguments()[1];

                var key = k;
                var value = changeType(v, valueType);
                dict[key] = value;
            }
            return ok(l);
        }

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static public int luaNewIndex(IntPtr l)
        {
            try
            {
                ObjectCache oc = ObjectCache.get(l);
                object self = oc.get(l, 1);

                LuaTypes t = LuaDLL.lua_type(l, 2);
                switch (t)
                {
                    case LuaTypes.LUA_TSTRING:
                        return newindexString(l, self, LuaDLL.lua_tostring(l, 2));
                    case LuaTypes.LUA_TNUMBER:
                        return newindexInt(l, self, LuaDLL.lua_tointeger(l, 2));
                    default:
                        return newindexObject(l, self, checkVar(l, 2), checkVar(l, 3));
                }
            }
            catch (Exception e)
            {
                return error(l, e);
            }
        }

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static public int methodWrapper(IntPtr l)
        {
            try
            {
                ObjectCache oc = ObjectCache.get(l);
                LuaCSFunction func = (LuaCSFunction)oc.get(l, 1);
                return func(l);
            }
            catch (Exception e)
            {
                return error(l, e);
            }
        }

        static new public void init(IntPtr l)
        {
            LuaDLL.lua_createtable(l, 0, 3);
            pushValue(l, luaIndex);
            LuaDLL.lua_setfield(l, -2, "__index");
            pushValue(l, luaNewIndex);
            LuaDLL.lua_setfield(l, -2, "__newindex");
            LuaDLL.lua_pushcfunction(l, lua_gc);
            LuaDLL.lua_setfield(l, -2, "__gc");
            LuaDLL.lua_setfield(l, LuaIndexes.LUA_REGISTRYINDEX, "LuaVarObject");

            LuaDLL.lua_createtable(l, 0, 1);
            pushValue(l, methodWrapper);
            LuaDLL.lua_setfield(l, -2, "__call");
            LuaDLL.lua_pushcfunction(l, lua_gc);
            LuaDLL.lua_setfield(l, -2, "__gc");
            LuaDLL.lua_setfield(l, LuaIndexes.LUA_REGISTRYINDEX, ObjectCache.getAQName(typeof(LuaCSFunction)));
        }
    }

    class LuaClassObject
    {
        Type cls;

        public LuaClassObject(Type t)
        {
            cls = t;
        }

        public Type GetClsType()
        {
            return cls;
        }
    }
}
