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
	using System.Runtime.CompilerServices;
    using System.Reflection;
    using System.Linq;

    public class ObjectCache
	{
		static Dictionary<IntPtr, ObjectCache> multiState = new Dictionary<IntPtr, ObjectCache>();

		static IntPtr oldl = IntPtr.Zero;
		static internal ObjectCache oldoc = null;


		#if SLUA_DEBUG || UNITY_EDITOR

		public static List<string> GetAllManagedObjectNames(){
			List<string> names = new List<string>();
			foreach(var cache in multiState.Values){
				foreach(var o in cache.objMap.Keys){
					names.Add(cache.objNameDebugs[o]);
				}
			}
			return names;
		}

		public static List<string> GetAlreadyDestroyedObjectNames(){
			List<string> names = new List<string>();
			foreach(var cache in multiState.Values){
				foreach(var o in cache.objMap.Keys){
					if(o is Object &&(o as Object).Equals(null)){
						names.Add(cache.objNameDebugs[o]);
					}
				}
			}
			return names;
		}

		#endif

		public static ObjectCache get(IntPtr l)
		{
			if (oldl == l)
				return oldoc;
			ObjectCache oc;
			if (multiState.TryGetValue(l, out oc))
			{
				oldl = l;
				oldoc = oc;
				return oc;
			}

			LuaDLL.lua_getglobal(l, "__main_state");
			if (LuaDLL.lua_isnil(l, -1))
			{
				LuaDLL.lua_pop(l, 1);
				return null;
			}

			IntPtr nl = LuaDLL.lua_touserdata(l, -1);
			LuaDLL.lua_pop(l, 1);
			if (nl != l)
				return get(nl);
			return null;
		}

		class FreeList : Dictionary<int, object>
		{
			private int id = 1;
			public int add(object o)
			{
				Add(id, o);
				return id++;
			}

			public void del(int i)
			{
				this.Remove(i);
			}

			public bool get(int i, out object o)
			{
				return TryGetValue(i, out o);
			}

			public object get(int i)
			{
				object o;
				if (TryGetValue(i, out o))
					return o;
				return null;
			}

			public void set(int i, object o)
			{
				this[i] = o;
			}
		}

		FreeList cache = new FreeList();
        public class ObjEqualityComparer : IEqualityComparer<object>
        {
            public new bool Equals(object x, object y)
            {

                return ReferenceEquals(x, y);
            }

            public int GetHashCode(object obj)
            {
                return RuntimeHelpers.GetHashCode(obj);
            }
        }

		Dictionary<object, int> objMap = new Dictionary<object, int>(new ObjEqualityComparer());
        public Dictionary<object, int>.KeyCollection Objs { get { return objMap.Keys; } }

		#if SLUA_DEBUG || UNITY_EDITOR
		Dictionary<object,string> objNameDebugs = new Dictionary<object, string>(new ObjEqualityComparer());

		private static string getDebugFullName(UnityEngine.Transform transform){
			if (transform.parent == null) {
				return transform.gameObject.ToString();
			}
			return getDebugName (transform.parent) + "/" + transform.name;
		}

		private static string getDebugName(object o ){
			if (o is UnityEngine.GameObject) {
				var go = o as UnityEngine.GameObject;
				return getDebugFullName (go.transform);
			} else if (o is UnityEngine.Component) {
				var comp = o as UnityEngine.Component;
				return getDebugFullName (comp.transform);
			}
			return o.ToString ();

		}

		#endif

        int udCacheRef = 0;


		public ObjectCache(IntPtr l)
		{
			LuaDLL.lua_newtable(l);
			LuaDLL.lua_newtable(l);
			LuaDLL.lua_pushstring(l, "v");
			LuaDLL.lua_setfield(l, -2, "__mode");
			LuaDLL.lua_setmetatable(l, -2);
			udCacheRef = LuaDLL.luaL_ref(l, LuaIndexes.LUA_REGISTRYINDEX);
		}


		static public void clear()
		{

			oldl = IntPtr.Zero;
			oldoc = null;

		}
		internal static void del(IntPtr l)
		{
			multiState.Remove(l);
		}

		internal static void make(IntPtr l)
		{
			ObjectCache oc = new ObjectCache(l);
			multiState[l] = oc;
			oldl = l;
			oldoc = oc;
		}

        public int size()
        {
            return objMap.Count;
        }

		internal void gc(int index)
		{
			object o;
			if (cache.get(index, out o))
			{
				int oldindex;
				if (isGcObject(o) && objMap.TryGetValue(o,out oldindex) && oldindex==index)
				{
					objMap.Remove(o);
					#if SLUA_DEBUG || UNITY_EDITOR 
					objNameDebugs.Remove(o);
					#endif
				}
				cache.del(index);
            }
		}
#if !SLUA_STANDALONE
        internal void gc(UnityEngine.Object o)
        {
            int index;
            if(objMap.TryGetValue(o, out index))
            {
                objMap.Remove(o);
                cache.del(index);
		#if SLUA_DEBUG || UNITY_EDITOR 
				objNameDebugs.Remove(o);
		#endif
            }
        }
#endif

		internal int add(object o)
		{
			int objIndex = cache.add(o);
			if (isGcObject(o))
			{
				objMap[o] = objIndex;
				#if SLUA_DEBUG || UNITY_EDITOR
				objNameDebugs[o] = getDebugName(o);
				#endif
			}
			return objIndex;
		}

        internal void destoryObject(IntPtr l, int p) {
            int index = LuaDLL.luaS_rawnetobj(l, p);
            gc(index);
        }

		internal object get(IntPtr l, int p)
		{

			int index = LuaDLL.luaS_rawnetobj(l, p);
			object o;
			if (index != -1 && cache.get(index, out o))
			{
				return o;
			}
			return null;

		}

		internal void setBack(IntPtr l, int p, object o)
		{

			int index = LuaDLL.luaS_rawnetobj(l, p);
			if (index != -1)
			{
				cache.set(index, o);
			}

		}

		internal void push(IntPtr l, object o)
		{
			push(l, o, true);
		}

		internal void push(IntPtr l, Array o)
		{
			int index = allocID (l, o);
			if (index < 0)
				return;

			LuaDLL.luaS_pushobject(l, index, "LuaArray", true, udCacheRef);
		}

		internal int allocID(IntPtr l,object o) {

			int index = -1;

			if (o == null)
			{
				LuaDLL.lua_pushnil(l);
				return index;
			}

			bool gco = isGcObject(o);
			bool found = gco && objMap.TryGetValue(o, out index);
			if (found)
			{
				if (LuaDLL.luaS_getcacheud(l, index, udCacheRef) == 1)
					return -1;
			}

			index = add(o);
			return index;
		}

		internal void pushInterface(IntPtr l, object o, Type t)
		{

			int index = allocID(l, o);
			if (index < 0)
				return;

			LuaDLL.luaS_pushobject(l, index, getAQName(t), true, udCacheRef);
		}


		internal void push(IntPtr l, object o, bool checkReflect)
		{
			
			int index = allocID (l, o);
			if (index < 0)
				return;

			bool gco = isGcObject(o);

#if SLUA_CHECK_REFLECTION
			int isReflect = LuaDLL.luaS_pushobject(l, index, getAQName(o), gco, udCacheRef);
			if (isReflect != 0 && checkReflect && !(o is LuaClassObject))
			{
				Logger.LogWarning(string.Format("{0} not exported, using reflection instead", o.ToString()));
			}
#elif SLUA_TRY_PUSHBASE
            Type t = o.GetType();
            while (t!=typeof(Object)) {
                LuaDLL.luaL_getmetatable(l, getAQName(t));
                if (!LuaDLL.lua_isnil(l, -1))
                {
                    LuaDLL.lua_pop(l, 1);
                    LuaDLL.luaS_pushobject(l, index, getAQName(t), gco, udCacheRef);
                    return;
                }
                LuaDLL.lua_pop(l, 1);
                t = t.BaseType;
            }
            LuaDLL.luaS_pushobject(l, index, getAQName(o), gco, udCacheRef);
#else
            LuaDLL.luaS_pushobject(l, index, getAQName(o), gco, udCacheRef);
#endif

		}

		static Dictionary<Type, string> aqnameMap = new Dictionary<Type, string>();
		static string getAQName(object o)
		{
			Type t = o.GetType();
			return getAQName(t);
		}

		internal static string getAQName(Type t)
		{
			string name;
			if (aqnameMap.TryGetValue(t, out name))
			{
				return name;
			}
			name = t.AssemblyQualifiedName;
			aqnameMap[t] = name;
			return name;
		}


		bool isGcObject(object obj)
		{
			return obj.GetType().IsValueType == false;
		}

        public bool isObjInLua(object obj)
        {
            return objMap.ContainsKey(obj);
        }

        // find type in current domain
        static Type getTypeInGlobal(string name) {
            Type t = Type.GetType(name);
            if (t!=null) return t;

			Assembly[] ams = AppDomain.CurrentDomain.GetAssemblies();

			for (int n = 0; n < ams.Length; n++)
			{
				Assembly a = ams[n];
				Type[] ts = null;
				try
				{
					ts = a.GetExportedTypes();
					for (int k = 0; k < ts.Length; k++)
					{
						t = ts[k];
                        if (t.Name == name)
                            return t;
					}
				}
				catch
				{
					continue;
				}
			}
            return null;
        }

        static Type typeofLD;
        WeakDictionary<Type, MethodInfo> methodCache = new WeakDictionary<Type, MethodInfo>();

        internal MethodInfo getDelegateMethod(Type t) {
            MethodInfo mi;
            if (methodCache.TryGetValue(t, out mi))
                return mi;

			if (typeofLD == null)
				typeofLD = getTypeInGlobal("LuaDelegation");

			if (typeofLD == null) return null;

            MethodInfo[] mis = typeofLD.GetMethods(BindingFlags.Static|BindingFlags.NonPublic);
            for (int n = 0; n < mis.Length;n++) {
                mi = mis[n];
                if (isMethodCompatibleWithDelegate(mi, t))
                {
                    methodCache.Add(t,mi);
                    return mi;
                }
            }
            return null;
        }

		static bool isMethodCompatibleWithDelegate(MethodInfo target,Type dt)
		{
			MethodInfo ds = dt.GetMethod("Invoke");

			bool parametersEqual = ds
				.GetParameters()
				.Select(x => x.ParameterType)
                .SequenceEqual(target.GetParameters().Skip(1)
				.Select(x => x.ParameterType));

			return ds.ReturnType == target.ReturnType &&
				   parametersEqual;
		}
	}
}

