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
	using System;
	using System.Reflection;
	using System.Collections.Generic;

	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Struct | AttributeTargets.Delegate | AttributeTargets.Interface)]
	public class CustomLuaClassAttribute : System.Attribute
	{
		public CustomLuaClassAttribute()
		{
			//
		}
	}

	public class DoNotToLuaAttribute : System.Attribute
	{
		public DoNotToLuaAttribute()
		{
			//
		}
	}

	public class LuaBinderAttribute : System.Attribute
	{
		public int order;
		public LuaBinderAttribute(int order)
		{
			this.order = order;
		}
	}

	[AttributeUsage(AttributeTargets.Method)]
	public class StaticExportAttribute : System.Attribute
	{
		public StaticExportAttribute()
		{
			//
		}
	}

	[AttributeUsage(AttributeTargets.Method)]
	public class LuaOverrideAttribute : System.Attribute {
		public string fn;
		public LuaOverrideAttribute(string fn) {
			this.fn = fn;
		}
	}

	public class OverloadLuaClassAttribute : System.Attribute {
		public OverloadLuaClassAttribute(Type target) {
			targetType = target;
		}
		public Type targetType;
	}


    public class LuaOut { }

	public partial class LuaObject
	{

		static protected LuaCSFunction lua_gc = new LuaCSFunction(luaGC);
		static protected LuaCSFunction lua_add = new LuaCSFunction(luaAdd);
		static protected LuaCSFunction lua_sub = new LuaCSFunction(luaSub);
		static protected LuaCSFunction lua_mul = new LuaCSFunction(luaMul);
		static protected LuaCSFunction lua_div = new LuaCSFunction(luaDiv);
		static protected LuaCSFunction lua_unm = new LuaCSFunction(luaUnm);
		static protected LuaCSFunction lua_eq = new LuaCSFunction(luaEq);
        static protected LuaCSFunction lua_lt = new LuaCSFunction(luaLt);
        static protected LuaCSFunction lua_le = new LuaCSFunction(luaLe);
        static protected LuaCSFunction lua_tostring = new LuaCSFunction(ToString);

		const string DelgateTable = "__LuaDelegate";
		static protected Dictionary<MethodBase, string> methodDict = new Dictionary<MethodBase, string>();

		internal const int VersionNumber = 0x1500;

		public static void init(IntPtr l)
		{
			// object method
			LuaDLL.lua_createtable(l, 0, 4);
			addMember(l, ToString);
			addMember(l, GetHashCode);
			addMember(l, Equals);
			addMember(l, GetType);
            addMember(l, Unlink);
			LuaDLL.lua_setfield(l, LuaIndexes.LUA_REGISTRYINDEX, "__luabaseobject");

        }

		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static public int ToString(IntPtr l)
		{
			try
			{
				object obj = checkVar(l, 1);
				pushValue(l, true);
				pushValue(l, obj.ToString());
				return 2;
			}
			catch (Exception e)
			{
				return error(l, e);
			}
		}

		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static public int GetHashCode(IntPtr l)
		{
			try
			{
				object obj = checkVar(l, 1);
				pushValue(l, true);
				pushValue(l, obj.GetHashCode());
				return 2;
			}
			catch (Exception e)
			{
				return error(l, e);
			}
		}

		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static public int Equals(IntPtr l)
		{
			try
			{
				object obj = checkVar(l, 1);
				object other = checkVar(l, 2);
				pushValue(l, true);
				pushValue(l, obj.Equals(other));
				return 2;
			}
			catch (Exception e)
			{
				return error(l, e);
			}
		}

		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static public int GetType(IntPtr l)
		{
			try
			{
				object obj = checkVar(l, 1);
				pushValue(l, true);
				pushObject(l, obj.GetType());
				return 2;
			}
			catch (Exception e)
			{
				return error(l, e);
			}
		}

		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static public int Unlink(IntPtr l)
		{
			try
			{
                ObjectCache oc = ObjectCache.get(l);
                oc.destoryObject(l,1);
                pushValue(l, true);
                return 1;
			}
			catch (Exception e)
			{
				return error(l, e);
			}
		}

		static int getOpFunction(IntPtr l, string f, string tip)
		{
			int err = pushTry(l);
			checkLuaObject(l, 1);

			while (!LuaDLL.lua_isnil(l, -1))
			{
				LuaDLL.lua_getfield(l, -1, f);
				if (!LuaDLL.lua_isnil(l, -1))
				{
					LuaDLL.lua_remove(l, -2);
					break;
				}
				LuaDLL.lua_pop(l, 1); //pop nil
				LuaDLL.lua_getfield(l, -1, "__parent");
				LuaDLL.lua_remove(l, -2); //pop base
			}

			if (LuaDLL.lua_isnil(l, -1))
			{
				LuaDLL.lua_pop(l, 1);
				throw new Exception(string.Format("No {0} operator", tip));
			}
			return err;
		}

		static int luaOp(IntPtr l, string f, string tip)
		{
			int err = getOpFunction(l, f, tip);
			LuaDLL.lua_pushvalue(l, 1);
			LuaDLL.lua_pushvalue(l, 2);
            if (LuaDLL.lua_pcall(l, 2, 1, err) != 0)
                LuaDLL.lua_pop(l, 1);
			LuaDLL.lua_remove(l, err);
			pushValue(l, true);
			LuaDLL.lua_insert(l, -2);
			return 2;
		}


		static int luaUnaryOp(IntPtr l, string f, string tip)
		{
			int err = getOpFunction(l, f, tip);
			LuaDLL.lua_pushvalue(l, 1);
			if (LuaDLL.lua_pcall(l, 1, 1, err) != 0)
				LuaDLL.lua_pop(l, 1);
			LuaDLL.lua_remove(l, err);
			pushValue(l, true);
			LuaDLL.lua_insert(l, -2);
			return 2;
		}

		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static public int luaAdd(IntPtr l)
		{
			try
			{
				return luaOp(l, "op_Addition", "add");
			}
			catch(Exception e)
			{
				return error(l, e);
			}
		}

		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static public int luaSub(IntPtr l)
		{
			try
			{
				return luaOp(l, "op_Subtraction", "sub");
			}
			catch (Exception e)
			{
				return error(l, e);
			}
		}

		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static public int luaMul(IntPtr l)
		{
			try
			{
				return luaOp(l, "op_Multiply", "mul");
			}
			catch (Exception e)
			{
				return error(l, e);
			}
		}

		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static public int luaDiv(IntPtr l)
		{
			try
			{
				return luaOp(l, "op_Division", "div");
			}
			catch (Exception e)
			{
				return error(l, e);
			}
		}

		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static public int luaUnm(IntPtr l)
		{
			try
			{
				return luaUnaryOp(l, "op_UnaryNegation", "unm");
			}
			catch (Exception e)
			{
				return error(l, e);
			}
		}

		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static public int luaEq(IntPtr l)
		{
			try
			{
				return luaOp(l, "op_Equality", "eq");
			}
			catch (Exception e)
			{
				return error(l, e);
			}
		}

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static public int luaLt(IntPtr l)
        {
			try
			{
				return luaOp(l, "op_LessThan", "lt");
			}
			catch (Exception e)
			{
				return error(l, e);
			}
        }

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static public int luaLe(IntPtr l)
        {
			try
			{
				return luaOp(l, "op_LessThanOrEqual", "le");
			}
			catch (Exception e)
			{
				return error(l, e);
			}
        }

		public static void getEnumTable(IntPtr l, string t)
		{
			newTypeTable(l, t);
		}

		public static void getTypeTable(IntPtr l, string t)
		{
			newTypeTable(l, t);
			// for static
			LuaDLL.lua_newtable(l);
			// for instance
			LuaDLL.lua_newtable(l);
		}

		public static void newTypeTable(IntPtr l, string name)
		{
			string[] subt = name.Split('.');

			LuaDLL.lua_pushglobaltable(l);

			foreach(string t in subt)
			{
				LuaDLL.lua_pushstring(l, t);
				LuaDLL.lua_rawget(l, -2);
				if (LuaDLL.lua_isnil(l, -1))
				{
					LuaDLL.lua_pop(l, 1);
					LuaDLL.lua_createtable(l, 0, 0);
					LuaDLL.lua_pushstring(l, t);
					LuaDLL.lua_pushvalue(l, -2);
					LuaDLL.lua_rawset(l, -4);
				}
				LuaDLL.lua_remove(l, -2);
			}
		}

		public static void createTypeMetatable(IntPtr l, Type self)
		{
			createTypeMetatable(l, null, self, null);
		}

		public static void createTypeMetatable(IntPtr l, LuaCSFunction con, Type self)
		{
			createTypeMetatable(l, con, self, null);
		}

        static void checkMethodValid(LuaCSFunction f)
        {
#if UNITY_EDITOR
            if (f != null && !Attribute.IsDefined(f.Method, typeof(MonoPInvokeCallbackAttribute)))
            {
				Logger.LogError(string.Format("MonoPInvokeCallbackAttribute not defined for LuaCSFunction {0}.", f.Method));
            }
#endif
        }

		public static void createTypeMetatable(IntPtr l, LuaCSFunction con, Type self, Type parent)
		{
			checkMethodValid(con);

			// set parent
			bool parentSet = false;
			LuaDLL.lua_pushstring(l, "__parent");
			while (parent != null && parent != typeof(object) && parent != typeof(ValueType))
			{
				LuaDLL.luaL_getmetatable(l, ObjectCache.getAQName(parent));
				// if parentType is not exported to lua
				if (LuaDLL.lua_isnil(l, -1))
				{
					LuaDLL.lua_pop(l, 1);
					parent = parent.BaseType;
				}
				else
				{
					LuaDLL.lua_rawset(l, -3);

					LuaDLL.lua_pushstring(l, "__parent");
					LuaDLL.luaL_getmetatable(l, parent.FullName);
					LuaDLL.lua_rawset(l, -4);

					parentSet = true;
					break;
				}
			}

			if(!parentSet)
			{
				LuaDLL.luaL_getmetatable(l, "__luabaseobject");
				LuaDLL.lua_rawset(l, -3);
			}

			completeInstanceMeta(l, self);
			completeTypeMeta(l, con, self);

			LuaDLL.lua_pop(l, 1); // pop type Table
		}

		static void completeTypeMeta(IntPtr l, LuaCSFunction con, Type self)
		{
            LuaState L = LuaState.get(l);

			LuaDLL.lua_pushstring(l, ObjectCache.getAQName(self));
			LuaDLL.lua_setfield(l, -3, "__fullname");

			L.index_func.push(l);
			LuaDLL.lua_setfield(l, -2, "__index");

			L.newindex_func.push(l);
			LuaDLL.lua_setfield(l, -2, "__newindex");

			if (con == null) con = noConstructor;

			pushValue(l, con);
			LuaDLL.lua_setfield(l, -2, "__call");

			LuaDLL.lua_pushcfunction(l, typeToString);
			LuaDLL.lua_setfield(l, -2, "__tostring");

			LuaDLL.lua_pushvalue(l, -1);
			LuaDLL.lua_setmetatable(l, -3);

			LuaDLL.lua_setfield(l, LuaIndexes.LUA_REGISTRYINDEX, self.FullName);
		}

		private static void completeInstanceMeta(IntPtr l, Type self)
		{
            LuaState L = LuaState.get(l);

			LuaDLL.lua_pushstring(l, "__typename");
			LuaDLL.lua_pushstring(l, self.Name);
			LuaDLL.lua_rawset(l, -3);

			// for instance
			L.index_func.push(l);
			LuaDLL.lua_setfield(l, -2, "__index");

			L.newindex_func.push(l);
			LuaDLL.lua_setfield(l, -2, "__newindex");

			pushValue(l, lua_add);
			LuaDLL.lua_setfield(l, -2, "__add");
			pushValue(l, lua_sub);
			LuaDLL.lua_setfield(l, -2, "__sub");
			pushValue(l, lua_mul);
			LuaDLL.lua_setfield(l, -2, "__mul");
			pushValue(l, lua_div);
			LuaDLL.lua_setfield(l, -2, "__div");
			pushValue(l, lua_unm);
			LuaDLL.lua_setfield(l, -2, "__unm");
			pushValue(l, lua_eq);
			LuaDLL.lua_setfield(l, -2, "__eq");
            pushValue(l, lua_le);
            LuaDLL.lua_setfield(l, -2, "__le");
            pushValue(l, lua_lt);
            LuaDLL.lua_setfield(l, -2, "__lt");
			pushValue(l, lua_tostring);
			LuaDLL.lua_setfield(l, -2, "__tostring");

			LuaDLL.lua_pushcfunction(l, lua_gc);
			LuaDLL.lua_setfield(l, -2, "__gc");

			if (self.IsValueType && isImplByLua(self))
			{
				LuaDLL.lua_pushvalue(l, -1);
                LuaDLL.lua_setglobal(l, self.FullName + ".Instance");
			}
			LuaDLL.lua_setfield(l, LuaIndexes.LUA_REGISTRYINDEX,  ObjectCache.getAQName(self));
		}


		public static bool isImplByLua(Type t)
		{
#if !SLUA_STANDALONE
			return t == typeof(Color)
				|| t == typeof(Vector2)
				|| t == typeof(Vector3)
				|| t == typeof(Vector4)
				|| t == typeof(Quaternion);
#else
		    return false;
#endif
		}


		public static void reg(IntPtr l, LuaCSFunction func, string ns)
		{
            checkMethodValid(func);

            newTypeTable(l, ns);
			pushValue(l, func);
			LuaDLL.lua_setfield(l, -2, func.Method.Name);
			LuaDLL.lua_pop(l, 1);
		}

		protected static void addMember(IntPtr l, LuaCSFunction func)
		{
            checkMethodValid(func);

			pushValue(l, func);
			string name = func.Method.Name;
			if (name.EndsWith("_s"))
			{
				name = name.Substring(0, name.Length - 2);
				LuaDLL.lua_setfield(l, -3, name);
			}
			else
				LuaDLL.lua_setfield(l, -2, name);
		}

		protected static void addMember(IntPtr l, LuaCSFunction func, bool instance)
		{
            checkMethodValid(func);

			pushValue(l, func);
			string name = func.Method.Name;
			LuaDLL.lua_setfield(l, instance ? -2 : -3, name);
		}

		protected static void addMember(IntPtr l, string name, LuaCSFunction get, LuaCSFunction set, bool instance)
		{
            checkMethodValid(get);
            checkMethodValid(set);

            int t = instance ? -2 : -3;

			LuaDLL.lua_createtable(l, 2, 0);
			if (get == null)
				LuaDLL.lua_pushnil(l);
			else
				pushValue(l, get);
			LuaDLL.lua_rawseti(l, -2, 1);

			if (set == null)
				LuaDLL.lua_pushnil(l);
			else
				pushValue(l, set);
			LuaDLL.lua_rawseti(l, -2, 2);

			LuaDLL.lua_setfield(l, t, name);
		}

		protected static void addMember(IntPtr l, int v, string name)
		{
			LuaDLL.lua_pushinteger(l, v);
			LuaDLL.lua_setfield(l, -2, name);
		}

		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static public int luaGC(IntPtr l)
		{
			int index = LuaDLL.luaS_rawnetobj(l, 1);
			if (index > 0)
			{
				ObjectCache t = ObjectCache.get(l);
				t.gc(index);
			}
			return 0;
		}
#if !SLUA_STANDALONE
        static internal void gc(IntPtr l,int p,UnityEngine.Object o)
        {
            // set ud's metatable is nil avoid gc again
            LuaDLL.lua_pushnil(l);
            LuaDLL.lua_setmetatable(l, p);

            ObjectCache t = ObjectCache.get(l);
            t.gc(o);
        }
#endif

		static public void checkLuaObject(IntPtr l, int p)
		{
			LuaDLL.lua_getmetatable(l, p);
			if (LuaDLL.lua_isnil(l, -1))
			{
				LuaDLL.lua_pop(l, 1);
				throw new Exception("expect luaobject as first argument");
			}
		}

		public static void pushObject(IntPtr l, object o)
		{
			ObjectCache oc = ObjectCache.get(l);
			oc.push(l, o);
		}

		public static void pushObject(IntPtr l, Array o)
		{
			ObjectCache oc = ObjectCache.get(l);
			oc.push(l, o);
		}

		// lightobj is non-exported object used for re-get from c#, not for lua
		public static void pushLightObject(IntPtr l, object t)
		{
			ObjectCache oc = ObjectCache.get(l);
			oc.push(l, t, false);
		}

		public static int pushTry(IntPtr l)
		{
            var state = LuaState.get(l);
            if (!state.isMainThread())
			{
				Logger.LogError("Can't call lua function in bg thread");
				return 0;
			}

            return state.pushTry(l);
		}

		public static bool matchType(IntPtr l, int p, LuaTypes lt, Type t)
		{
			if (t == typeof(object))
			{
				return true;
			}
			else if (t == typeof(Type) && isTypeTable(l, p))
			{
				return true;
			}
			else if (t == typeof(char[]) || t==typeof(byte[]))
			{
				return lt == LuaTypes.LUA_TSTRING || lt == LuaTypes.LUA_TUSERDATA;
			}

			switch (lt)
			{
                case LuaTypes.LUA_TNIL:
                    return !t.IsValueType && !t.IsPrimitive;
				case LuaTypes.LUA_TNUMBER:
#if LUA_5_3
					if (LuaDLL.lua_isinteger(l, p) > 0)
						return (t.IsPrimitive && t != typeof(float) && t != typeof(double)) || t.IsEnum;
					else
						return t == typeof(float) || t == typeof(double);
#else
					return t.IsPrimitive || t.IsEnum;
#endif
				case LuaTypes.LUA_TUSERDATA:
					object o = checkObj (l, p);
					Type ot = o.GetType ();
					return ot == t || ot.IsSubclassOf (t) || t.IsAssignableFrom (ot);
				case LuaTypes.LUA_TSTRING:
					return t == typeof(string);
				case LuaTypes.LUA_TBOOLEAN:
					return t == typeof(bool);
				case LuaTypes.LUA_TTABLE:
					{
						if (t == typeof(LuaTable) || t.IsArray)
							return true;
						else if (t.IsValueType)
							return luaTypeCheck(l, p, t.Name);
						else if (LuaDLL.luaS_subclassof(l, p, t.Name) == 1)
							return true;
						else
							return false;
					}
				case LuaTypes.LUA_TFUNCTION:
					return t == typeof(LuaFunction) || t.BaseType == typeof(MulticastDelegate);
                case LuaTypes.LUA_TTHREAD:
                    return t == typeof(LuaThread);

			}
			return false;
		}

		public static bool isTypeTable(IntPtr l, int p)
		{
			if (LuaDLL.lua_type(l, p) != LuaTypes.LUA_TTABLE)
				return false;
			LuaDLL.lua_pushstring(l, "__fullname");
			LuaDLL.lua_rawget(l, p);
			if (LuaDLL.lua_isnil(l, -1))
			{
				LuaDLL.lua_pop(l, 1);
				return false;
			}
			return true;
		}

		public static bool isLuaClass(IntPtr l, int p)
		{
			return LuaDLL.luaS_subclassof(l, p, null) == 1;
		}

		static bool isLuaValueType(IntPtr l, int p)
		{
			return LuaDLL.luaS_checkluatype(l, p, null) == 1;
		}

		public static bool matchType(IntPtr l, int p, Type t1)
		{
			LuaTypes t = LuaDLL.lua_type(l, p);
			return matchType(l, p, t, t1);
		}

		public static bool matchType(IntPtr l, int total, int from, Type t1)
		{
			if (total - from + 1 != 1)
				return false;

			return matchType(l, from, t1);
		}

		public static bool matchType(IntPtr l, int total, int from, Type t1, Type t2)
		{
			if (total - from + 1 != 2)
				return false;

			return matchType(l, from, t1) && matchType(l, from + 1, t2);
		}

		public static bool matchType(IntPtr l, int total, int from, Type t1, Type t2, Type t3)
		{
			if (total - from + 1 != 3)
				return false;

			return matchType(l, from, t1) && matchType(l, from + 1, t2) && matchType(l, from + 2, t3);
		}

		public static bool matchType(IntPtr l, int total, int from, Type t1, Type t2, Type t3, Type t4)
		{
			if (total - from + 1 != 4)
				return false;

			return matchType(l, from, t1) && matchType(l, from + 1, t2) && matchType(l, from + 2, t3) && matchType(l, from + 3, t4);
		}

		public static bool matchType(IntPtr l, int total, int from, Type t1, Type t2, Type t3, Type t4, Type t5)
		{
			if (total - from + 1 != 5)
				return false;

			return matchType(l, from, t1) && matchType(l, from + 1, t2) && matchType(l, from + 2, t3) && matchType(l, from + 3, t4)
				&& matchType(l, from + 4, t5);
		}

		public static bool matchType
			(IntPtr l, int total, int from, Type t1, Type t2, Type t3, Type t4, Type t5,Type t6)
		{
			if (total - from + 1 != 6)
				return false;

			return matchType(l, from, t1) && matchType(l, from + 1, t2) && matchType(l, from + 2, t3) && matchType(l, from + 3, t4)
				&& matchType(l, from + 4, t5)
				&& matchType(l, from + 5, t6);
		}

		public static bool matchType
			(IntPtr l, int total, int from, Type t1, Type t2, Type t3, Type t4, Type t5,Type t6,Type t7)
		{
			if (total - from + 1 != 7)
				return false;

			return matchType(l, from, t1) && matchType(l, from + 1, t2) && matchType(l, from + 2, t3) && matchType(l, from + 3, t4)
				&& matchType(l, from + 4, t5)
				&& matchType(l, from + 5, t6)
				&& matchType(l, from + 6, t7);
		}

		public static bool matchType
			(IntPtr l, int total, int from, Type t1, Type t2, Type t3, Type t4, Type t5,Type t6,Type t7,Type t8)
		{
			if (total - from + 1 != 8)
				return false;

			return matchType(l, from, t1) && matchType(l, from + 1, t2) && matchType(l, from + 2, t3) && matchType(l, from + 3, t4)
				&& matchType(l, from + 4, t5)
				&& matchType(l, from + 5, t6)
				&& matchType(l, from + 6, t7)
				&& matchType(l, from + 7, t8);
		}


		public static bool matchType
			(IntPtr l, int total, int from, Type t1, Type t2, Type t3, Type t4, Type t5,Type t6,Type t7,Type t8,Type t9)
		{
			if (total - from + 1 != 9)
				return false;

			return matchType(l, from, t1) && matchType(l, from + 1, t2) && matchType(l, from + 2, t3) && matchType(l, from + 3, t4)
				&& matchType(l, from + 4, t5)
				&& matchType(l, from + 5, t6)
				&& matchType(l, from + 6, t7)
				&& matchType(l, from + 7, t8)
				&& matchType(l, from + 8, t9);
		}

		public static bool matchType
			(IntPtr l, int total, int from, Type t1, Type t2, Type t3, Type t4, Type t5,Type t6,Type t7,Type t8,Type t9,Type t10)
		{
			if (total - from + 1 != 10)
				return false;

			return matchType(l, from, t1) && matchType(l, from + 1, t2) && matchType(l, from + 2, t3) && matchType(l, from + 3, t4)
				&& matchType(l, from + 4, t5)
					&& matchType(l, from + 5, t6)
					&& matchType(l, from + 6, t7)
					&& matchType(l, from + 7, t8)
					&& matchType(l, from + 8, t9)
					&& matchType(l, from + 9, t10);
		}

        public static bool matchType(IntPtr l, int total, int from, params Type[] t)
        {
            if (total - from + 1 != t.Length)
                return false;

            for (int i = 0; i < t.Length; ++i)
            {
                if (!matchType(l, from + i, t[i]))
                    return false;
            }

            return true;
        }

        public static bool matchType(IntPtr l, int total, int from, ParameterInfo[] pars)
		{
			if (total - from + 1 != pars.Length)
				return false;

			for (int n = 0; n < pars.Length; n++)
			{
				int p = n + from;
				LuaTypes t = LuaDLL.lua_type(l, p);
				if (!matchType(l, p, t, pars[n].ParameterType))
					return false;
			}
			return true;
		}

		static public bool luaTypeCheck(IntPtr l, int p, string t)
		{
			return LuaDLL.luaS_checkluatype(l, p, t) != 0;
		}

		static LuaDelegate newDelegate(IntPtr l, int p)
		{
			LuaState state = LuaState.get(l);

			LuaDLL.lua_pushvalue(l, p); // push function

			int fref = LuaDLL.luaL_ref(l, LuaIndexes.LUA_REGISTRYINDEX); // new ref function
			LuaDelegate f = new LuaDelegate(l, fref);
			LuaDLL.lua_pushvalue(l, p);
			LuaDLL.lua_pushinteger(l, fref);
			LuaDLL.lua_settable(l, -3); // __LuaDelegate[func]= fref
			state.delgateMap[fref] = f;
			return f;
		}

		static public void removeDelgate(IntPtr l, int r)
		{
			LuaDLL.lua_getglobal(l, DelgateTable);
			LuaDLL.lua_getref(l, r); // push key
			LuaDLL.lua_pushnil(l); // push nil value
			LuaDLL.lua_settable(l, -3); // remove function from __LuaDelegate table
			LuaDLL.lua_pop(l, 1); // pop __LuaDelegate
		}

		static public object checkObj(IntPtr l, int p)
		{
			ObjectCache oc = ObjectCache.get(l);
			return oc.get(l, p);
		}

        static public bool checkArray<T>(IntPtr l, int p, out T[] ta)
        {
            if (LuaDLL.lua_type(l, p) == LuaTypes.LUA_TTABLE)
            {
                int n = LuaDLL.lua_rawlen(l, p);
                ta = new T[n];
                for (int k = 0; k < n; k++)
                {
                    LuaDLL.lua_rawgeti(l, p, k + 1);
                    object obj = checkVar(l, -1);
                    if (obj is IConvertible)
                    {
                        ta[k] = (T)Convert.ChangeType(obj, typeof(T));
                    }
                    else
                    {
                        ta[k] = (T)obj;
                    }
                    LuaDLL.lua_pop(l, 1);
                }
                return true;
            }
            else
            {
                Array array = checkObj(l, p) as Array;
                ta = array as T[];
                return ta != null;
            }
        }

        static public bool checkParams<T>(IntPtr l, int p, out T[] pars) where T:class
		{
			int top = LuaDLL.lua_gettop(l);
			if (top - p >= 0)
			{
				pars = new T[top - p + 1];
				for (int n = p, k = 0; n <= top; n++, k++)
				{
					checkType(l, n, out pars[k]);
				}
				return true;
			}
			pars = new T[0];
			return true;
		}

		static public bool checkValueParams<T>(IntPtr l, int p, out T[] pars) where T : struct
		{
			int top = LuaDLL.lua_gettop(l);
			if (top - p >= 0)
			{
				pars = new T[top - p + 1];
				for (int n = p, k = 0; n <= top; n++, k++)
				{
					checkValueType(l, n, out pars[k]);
				}
				return true;
			}
			pars = new T[0];
			return true;
		}

		static public bool checkParams(IntPtr l, int p, out float[] pars)
		{
			int top = LuaDLL.lua_gettop(l);
			if (top - p >= 0)
			{
				pars = new float[top - p + 1];
				for (int n = p, k = 0; n <= top; n++, k++)
				{
					checkType(l, n, out pars[k]);
				}
				return true;
			}
			pars = new float[0];
			return true;
		}

		static public bool checkParams(IntPtr l, int p, out int[] pars)
		{
			int top = LuaDLL.lua_gettop(l);
			if (top - p >= 0)
			{
				pars = new int[top - p + 1];
				for (int n = p, k = 0; n <= top; n++, k++)
				{
					checkType(l, n, out pars[k]);
				}
				return true;
			}
			pars = new int[0];
			return true;
		}



		static public bool checkParams(IntPtr l, int p, out string[] pars)
		{
			int top = LuaDLL.lua_gettop(l);
			if (top - p >= 0)
			{
				pars = new string[top - p + 1];
				for (int n = p, k = 0; n <= top; n++, k++)
				{
					checkType(l, n, out pars[k]);
				}
				return true;
			}
			pars = new string[0];
			return true;
		}

		static public bool checkParams(IntPtr l, int p, out char[] pars)
		{
			LuaDLL.luaL_checktype(l, p, LuaTypes.LUA_TSTRING);
			string s;
			checkType(l, p, out s);
			pars = s.ToCharArray();
			return true;
		}

        static public object checkVar(IntPtr l, int p, Type t)
        {
			object obj = checkVar(l, p);
            try
            {
                if (t.IsEnum)
                {
                    // double to int
                    var number = Convert.ChangeType(obj, typeof(int));
                    return Enum.ToObject(t, number);
                }

				object convertObj = null;
				if(obj!=null) {
	                if (t.IsInstanceOfType(obj))
	                {
	                    convertObj = obj; // if t is parent of obj, ignore change type
	                }
	                else
	                {
	                    convertObj = Convert.ChangeType(obj, t);
	                }
				}
                return obj == null ? null : convertObj;
            }
            catch(Exception e) {
				throw new Exception(string.Format("parameter {0} expected {1}, got {2}, exception: {3}", p, t.Name, obj == null ? "null" : obj.GetType().Name, e.Message));
            }
        }

		static public object checkVar(IntPtr l, int p)
		{
			LuaTypes type = LuaDLL.lua_type(l, p);
			switch (type)
			{
				case LuaTypes.LUA_TNUMBER:
					{
						return LuaDLL.lua_tonumber(l, p);
					}
				case LuaTypes.LUA_TSTRING:
					{
						return LuaDLL.lua_tostring(l, p);
					}
				case LuaTypes.LUA_TBOOLEAN:
					{
						return LuaDLL.lua_toboolean(l, p);
					}
				case LuaTypes.LUA_TFUNCTION:
					{
						LuaFunction v;
						LuaObject.checkType(l, p, out v);
						return v;
					}
				case LuaTypes.LUA_TTABLE:
					{
						if (isLuaValueType(l, p))
						{
#if !SLUA_STANDALONE
							if (luaTypeCheck(l, p, "Vector2"))
							{
								Vector2 v;
								checkType(l, p, out v);
								return v;
							}
							else if (luaTypeCheck(l, p, "Vector3"))
							{
								Vector3 v;
								checkType(l, p, out v);
								return v;
							}
							else if (luaTypeCheck(l, p, "Vector4"))
							{
								Vector4 v;
								checkType(l, p, out v);
								return v;
							}
							else if (luaTypeCheck(l, p, "Quaternion"))
							{
								Quaternion v;
								checkType(l, p, out v);
								return v;
							}
							else if (luaTypeCheck(l, p, "Color"))
							{
								Color c;
								checkType(l, p, out c);
								return c;
							}
#endif
							Logger.LogError("unknown lua value type");
							return null;
						}
						else if (isLuaClass(l, p))
						{
							return checkObj(l, p);
						}
						else
						{
							LuaTable v;
							checkType(l,p,out v);
							return v;
						}
					}
				case LuaTypes.LUA_TUSERDATA:
					return LuaObject.checkObj(l, p);
                case LuaTypes.LUA_TTHREAD:
                    {
                        LuaThread lt;
                        LuaObject.checkType(l, p, out lt);
                        return lt;
                    }
				default:
					return null;
			}
		}


		public static void pushValue(IntPtr l, object o)
		{
			pushVar(l, o);
		}

		public static void pushValue(IntPtr l, Array a)
		{
			pushObject(l, a);
		}

		public static void pushVar(IntPtr l, object o)
		{
			if (o == null)
			{
				LuaDLL.lua_pushnil(l);
				return;
			}


			Type t = o.GetType();

            LuaState.PushVarDelegate push;
            LuaState ls = LuaState.get(l);
			if (ls.tryGetTypePusher(t, out push))
				push(l, o);
			else if (t.IsEnum)
			{
				pushEnum(l, Convert.ToInt32(o));
			}
			else if (t.IsArray)
				pushObject(l, (Array)o);
			else
				pushObject(l, o);

		}



		public static T checkSelf<T>(IntPtr l)
		{
			object o = checkObj(l, 1);
			if (o != null)
			{
				return (T)o;
			}
			throw new Exception("arg 1 expect self, but get null");
		}

		public static object checkSelf(IntPtr l)
		{
			object o = checkObj(l, 1);
			if (o == null)
				throw new Exception("expect self, but get null");
			return o;
		}

		public static void setBack(IntPtr l, object o)
		{
			ObjectCache t = ObjectCache.get(l);
			t.setBack(l, 1, o);
		}

#if !SLUA_STANDALONE
		public static void setBack(IntPtr l, Vector3 v)
		{
			LuaDLL.luaS_setDataVec(l, 1, v.x, v.y, v.z, float.NaN);
		}

		public static void setBack(IntPtr l, Vector2 v)
		{
			LuaDLL.luaS_setDataVec(l, 1, v.x, v.y, float.NaN, float.NaN);
		}

		public static void setBack(IntPtr l, Vector4 v)
		{
			LuaDLL.luaS_setDataVec(l, 1, v.x, v.y, v.z, v.w);
		}

		public static void setBack(IntPtr l, Quaternion v)
		{
			LuaDLL.luaS_setDataVec(l, 1, v.x, v.y, v.z, v.w);
		}

        public static void setBack(IntPtr l, Color v)
        {
            LuaDLL.luaS_setDataVec(l, 1, v.r, v.g, v.b, v.a);
        }
#endif

        public static int extractFunction(IntPtr l, int p)
		{
			int op = 0;
			LuaTypes t = LuaDLL.lua_type(l, p);
			switch (t)
			{
				case LuaTypes.LUA_TNIL:
				case LuaTypes.LUA_TUSERDATA:
					op = 0;
					break;

				case LuaTypes.LUA_TTABLE:

					LuaDLL.lua_rawgeti(l, p, 1);
					LuaDLL.lua_pushstring(l, "+=");
					if (LuaDLL.lua_rawequal(l, -1, -2) == 1)
						op = 1;
					else
						op = 2;

					LuaDLL.lua_pop(l, 2);
					LuaDLL.lua_rawgeti(l, p, 2);
					break;
				case LuaTypes.LUA_TFUNCTION:
					LuaDLL.lua_pushvalue(l, p);
					break;
				default:
					throw new Exception("expect valid Delegate");
			}
			return op;
		}

		static public int checkDelegate<T>(IntPtr l, int p, out T ua) where T : class
		{
			int op = extractFunction(l, p);
			if (LuaDLL.lua_isnil(l, p))
			{
				ua = null;
				return op;
			}
			else if (LuaDLL.lua_isuserdata(l, p) == 1)
			{
				ua = checkObj(l, p) as T;
				return op;
			}
			LuaDelegate ld;
			checkType(l, -1, out ld);
			LuaDLL.lua_pop(l, 1);
			if (ld.d != null)
			{
				ua = ld.d as T;
				return op;
			}

			l = LuaState.get(l).L;

			ua = delegateCast(ld,typeof(T)) as T;
			ld.d = ua;
			return op;
		}

        // cast luafunction to delegation with type of t
        internal static Delegate delegateCast(LuaFunction f,Type t) {
            ObjectCache oc = ObjectCache.get(f.L);
            MethodInfo mi = oc.getDelegateMethod(t);
            if (mi == null)
                return null;

            return Delegate.CreateDelegate(t, f, mi, true);
        }


		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static public int noConstructor(IntPtr l)
		{
			return error(l, "Can't new this object");
		}

		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static public int typeToString(IntPtr l)
		{
			LuaDLL.lua_pushstring (l, "__fullname");
			LuaDLL.lua_rawget (l, -2);
			return 1;
		}

		static protected string GetMethodName(MethodBase method)
		{
			string result = "";

			if (!methodDict.TryGetValue(method, out result))
			{
				Type classType = method.ReflectedType;
				result = string.Format("{0}.{1}", classType.Name, method.Name);
				methodDict.Add(method, result);
			}
			return result;
		}

		static public int error(IntPtr l,Exception e)
		{
			LuaDLL.lua_pushboolean(l, false);
			LuaDLL.lua_pushstring(l, e.ToString());
			return 2;
		}

		static public int error(IntPtr l, string err)
		{
			LuaDLL.lua_pushboolean(l, false);
			LuaDLL.lua_pushstring(l, err);
			return 2;
		}

		static public int error(IntPtr l, string err, params object[] args)
		{
			err = string.Format(err, args);
			LuaDLL.lua_pushboolean(l, false);
			LuaDLL.lua_pushstring(l, err);
			return 2;
		}

		static public int ok(IntPtr l)
		{
			LuaDLL.lua_pushboolean(l, true);
			return 1;
		}

		static public int ok(IntPtr l, int retCount)
		{
			LuaDLL.lua_pushboolean(l, true);
			LuaDLL.lua_insert(l, -(retCount + 1));
			return retCount + 1;
		}

		static public void assert(bool cond,string err) {
			if(!cond) throw new Exception(err);
		}

        /// <summary>
        /// Change Type, alternative for Convert.ChangeType, but has exception handling
        /// change fail, return origin value directly, useful for some LuaVarObject value assign
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="t"></param>
        /// <returns></returns>
	    static public object changeType(object obj, Type t)
        {
            if (t == typeof (object)) return obj;
            if (obj.GetType() == t) return obj;

            try
            {
                return Convert.ChangeType(obj, t);
            }
            catch
            {
                return obj;
            }
	    }
	}

}
