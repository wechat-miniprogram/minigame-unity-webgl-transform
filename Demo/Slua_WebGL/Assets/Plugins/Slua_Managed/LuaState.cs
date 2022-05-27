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
//#define LUA_DEBUG



namespace SLua
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Text;
#if LUA_DEBUG
    using System.Security.Cryptography;
#endif
#if !SLUA_STANDALONE
    using UnityEngine;
#else
    using System.IO;
#endif

    abstract public class LuaVar : IDisposable
    {
        protected LuaState state = null;
        protected int valueref = 0;



        public IntPtr L
        {
            get
            {
                return state.L;
            }
        }

        public int Ref
        {
            get
            {
                return valueref;
            }
        }

        public LuaVar()
        {
            state = null;
        }

        public LuaVar(LuaState l, int r)
        {
            state = l;
            valueref = r;
        }

        public LuaVar(IntPtr l, int r)
        {
            state = LuaState.get(l);
            valueref = r;
        }

        ~LuaVar()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        static void unref(IntPtr l, int r) {
            LuaDLL.lua_unref(l, r);
        }

        public virtual void Dispose(bool disposeManagedResources)
        {
            if (valueref != 0)
            {
                state.gcRef(unref, valueref);
                valueref = 0;
            }
        }

        public void push(IntPtr l)
        {
            LuaDLL.lua_getref(l, valueref);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is LuaVar)
            {
                return this == (LuaVar)obj;
            }
            return false;
        }

        public static bool operator ==(LuaVar x, LuaVar y)
        {
            if ((object)x == null || (object)y == null)
                return (object)x == (object)y;

            return Equals(x, y) == 1;
        }

        public static bool operator !=(LuaVar x, LuaVar y)
        {
            if ((object)x == null || (object)y == null)
                return (object)x != (object)y;

            return Equals(x, y) != 1;
        }

        static int Equals(LuaVar x, LuaVar y)
        {
            x.push(x.L);
            y.push(x.L);
            int ok = LuaDLL.lua_equal(x.L, -1, -2);
            LuaDLL.lua_pop(x.L, 2);
            return ok;
        }
    }

    public class LuaThread : LuaVar
    {
        public LuaThread(IntPtr l, int r)
            : base(l, r)
        { }
    }

    public class LuaDelegate : LuaFunction
    {
        public object d;

        public LuaDelegate(IntPtr l, int r)
            : base(l, r)
        {
        }

        static void unref(IntPtr l, int r) {
            LuaObject.removeDelgate(l, r);
            LuaDLL.lua_unref(l, r);
        }

        public override void Dispose(bool disposeManagedResources)
        {
            if (valueref != 0)
            {
                state.gcRef(unref, valueref);
                valueref = 0;
            }

        }
    }

    public class LuaFunction : LuaVar
    {
        public LuaFunction(LuaState l, int r)
            : base(l, r)
        {
        }

        public LuaFunction(IntPtr l, int r)
            : base(l, r)
        {
        }

        public bool pcall(int nArgs, int errfunc)
        {

            if (!state.isMainThread())
            {
                Logger.LogError("Can't call lua function in bg thread");
                return false;
            }

            LuaDLL.lua_getref(L, valueref);

            if (!LuaDLL.lua_isfunction(L, -1))
            {
                LuaDLL.lua_pop(L, 1);
                throw new Exception("Call invalid function.");
            }

            LuaDLL.lua_insert(L, -nArgs - 1);
            if (LuaDLL.lua_pcall(L, nArgs, -1, errfunc) != 0)
            {
                LuaDLL.lua_pop(L, 1);
                return false;
            }
            return true;
        }

        bool innerCall(int nArgs, int errfunc)
        {
            bool ret = pcall(nArgs, errfunc);
            LuaDLL.lua_remove(L, errfunc);
            return ret;
        }


        public object call()
        {
            int error = LuaObject.pushTry(state.L);
            if (innerCall(0, error))
            {
                return state.topObjects(error - 1);
            }
            return null;
        }

        public object call(params object[] args)
        {
            int error = LuaObject.pushTry(state.L);

            for (int n = 0; args != null && n < args.Length; n++)
            {
                LuaObject.pushVar(L, args[n]);
            }

            if (innerCall(args != null ? args.Length : 0, error))
            {
                return state.topObjects(error - 1);
            }

            return null;
        }

		public object call(LuaTable self, params object[] args)
		{
			int error = LuaObject.pushTry(state.L);

			LuaObject.pushVar(L, self);

			for (int n = 0; args != null && n < args.Length; n++)
			{
				LuaObject.pushVar(L, args[n]);
			}

			if (innerCall((args != null ? args.Length : 0) + 1, error))
			{
				return state.topObjects(error - 1);
			}

			return null;
		}

        public T cast<T>() where T:class {
            return LuaObject.delegateCast(this, typeof(T)) as T;
        }
    }

    public class LuaTable : LuaVar, IEnumerable<LuaTable.TablePair>
    {


        public struct TablePair
        {
            public object key;
            public object value;
        }
        public LuaTable(IntPtr l, int r)
            : base(l, r)
        {
        }

        public LuaTable(LuaState l, int r)
            : base(l, r)
        {
        }

        public LuaTable(LuaState state)
            : base(state, 0)
        {

            LuaDLL.lua_newtable(L);
            valueref = LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
        }

        // if wholekey is true, don't split key by '.'
        public object get(string key,bool wholekey=false,bool rawget=false) {
            return state.getObject(valueref, key, wholekey,rawget);
        }

        // if wholekey is true, don't split key by '.'
        public void set(string key,object v,bool wholekey=false,bool rawset=false) {
            state.setObject(valueref, key, v, wholekey,rawset);
        }

        public object this[string key]
        {
            get
            {
                return state.getObject(valueref, key);
            }

            set
            {
                state.setObject(valueref, key, value);
            }
        }

        public object this[int index]
        {
            get
            {
                return state.getObject(valueref, index);
            }

            set
            {
                state.setObject(valueref, index, value);
            }
        }

        public object invoke(string func, params object[] args)
        {
            using (LuaFunction f = (LuaFunction)this[func])
            {
                if (f != null)
                {
                    return f.call(args);
                }
            }
            throw new Exception(string.Format("Can't find {0} function", func));
        }

        public int length()
        {
            int n = LuaDLL.lua_gettop(L);
            push(L);
            int l = LuaDLL.lua_rawlen(L, -1);
            LuaDLL.lua_settop(L, n);
            return l;
        }

        public bool IsEmpty
        {
            get
            {
                int top = LuaDLL.lua_gettop(L);
                LuaDLL.lua_getref(L, this.Ref);
                LuaDLL.lua_pushnil(L);
                bool ret = LuaDLL.lua_next(L, -2) > 0;
                LuaDLL.lua_settop(L, top);
                return !ret;
            }
        }

        public class Enumerator : IEnumerator<TablePair>, IDisposable
        {
            LuaTable t;
            int indext = -1;
            TablePair current = new TablePair();
            int iterPhase = 0;

            public Enumerator(LuaTable table)
            {
                t = table;
                Reset();
            }

            public bool MoveNext()
            {
                if (indext < 0)
                    return false;

                if (iterPhase == 0)
                {
                    LuaDLL.lua_pushnil(t.L);
                    iterPhase = 1;
                }
                else
                    LuaDLL.lua_pop(t.L, 1);

                //var ty = LuaDLL.lua_type(t.L, -1);
                bool ret = LuaDLL.lua_next(t.L, indext) > 0;
                if (!ret) iterPhase = 2;

                return ret;
            }

            public void Reset()
            {
                LuaDLL.lua_getref(t.L, t.Ref);
                indext = LuaDLL.lua_gettop(t.L);
            }

            public void Dispose()
            {
                if (iterPhase == 1)
                    LuaDLL.lua_pop(t.L, 2);

                LuaDLL.lua_remove(t.L, indext);
            }

            public TablePair Current
            {
                get
                {
                    current.key = LuaObject.checkVar(t.L, -2);
                    current.value = LuaObject.checkVar(t.L, -1);
                    return current;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }
        }

        public IEnumerator<TablePair> GetEnumerator()
        {
            return new LuaTable.Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }





    public class LuaState : IDisposable
    {
        IntPtr l_;
        int mainThread = 0;
        internal WeakDictionary<int, LuaDelegate> delgateMap = new WeakDictionary<int, LuaDelegate>();
#if LUA_DEBUG
        static Dictionary<string, string> debugStringMap = new Dictionary<string, string>();
#endif
		public int cachedDelegateCount{
			get{
				return this.delgateMap.AliveCount;
			}
		}

        public IntPtr L
        {
            get
            {

                if (!isMainThread())
                {
                    Logger.LogError("Can't access lua in bg thread");
                    throw new Exception("Can't access lua in bg thread");
                }

                if (l_ == IntPtr.Zero)
                {
                    Logger.LogError("LuaState had been destroyed, can't used yet");
                    throw new Exception("LuaState had been destroyed, can't used yet");
                }

                return l_;
            }
            set
            {
                l_ = value;
            }
        }

        public IntPtr handle
        {
            get
            {
                return L;
            }
        }

        public int Top { get { return LuaDLL.lua_gettop(L); } }

		public delegate byte[] LoaderDelegate(string fn, ref string absoluteFn);
        public delegate void OutputDelegate(string msg);
        public delegate void PushVarDelegate(IntPtr l, object o);

        public LoaderDelegate loaderDelegate;
        public OutputDelegate logDelegate;
        public OutputDelegate errorDelegate;
		public OutputDelegate warnDelegate;


        public delegate void UnRefAction(IntPtr l, int r);
        struct UnrefPair
        {
            public UnRefAction act;
            public int r;
        }
        Queue<UnrefPair> refQueue;
        public int PCallCSFunctionRef = 0;
        Dictionary<Type, PushVarDelegate> typePushMap = new Dictionary<Type, PushVarDelegate>();

        public static Dictionary<IntPtr, LuaState> statemap = new Dictionary<IntPtr, LuaState>();
        static IntPtr oldptr = IntPtr.Zero;
        static LuaState oldstate = null;
        static public LuaCSFunction errorFunc = new LuaCSFunction(errorReport);
        int errorRef = 0;

        internal LuaFunction newindex_func;
        internal LuaFunction index_func;
        const string DelgateTable = "__LuaDelegate";
        bool openedSluaLib = false;

        LuaFunction dumpstack;

        public bool isMainThread()
        {
            return System.Threading.Thread.CurrentThread.ManagedThreadId == mainThread;
        }

#if !SLUA_STANDALONE
        internal LuaSvrGameObject lgo;
#endif

        static public LuaState get(IntPtr l)
        {
            if (l == oldptr)
                return oldstate;

            LuaState ls;
            if (statemap.TryGetValue(l, out ls))
            {
                oldptr = l;
                oldstate = ls;
                return ls;
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



        public void openSluaLib()
        {

            LuaArray.init(L);
            LuaVarObject.init(L);

            LuaDLL.lua_newtable(L);
            LuaDLL.lua_setglobal(L, DelgateTable);

#if !SLUA_STANDALONE
            LuaTimer.reg(L);
            LuaCoroutine.reg(L, lgo);
#endif
            Lua_SLua_ByteArray.reg(L);
            Helper.reg(L);

            openedSluaLib = true;
        }

        public void openExtLib()
        {
            LuaDLL.luaS_openextlibs(L);
            LuaSocketMini.reg(L);
        }

        public void bindUnity()
        {
            if (!openedSluaLib)
                openSluaLib();

            LuaSvr.doBind(L);
            LuaValueType.reg(L);
        }

        public IEnumerator bindUnity(Action<int> _tick, Action complete)
        {
            if (!openedSluaLib)
                openSluaLib();

            yield return LuaSvr.doBind(L, _tick, complete);
            LuaValueType.reg(L);
        }

        static public LuaState main
        {
            get
            {
                return LuaSvr.mainState;
            }
        }

        public string Name
        {
            get;
            set;
        }

        public LuaState()
        {
            if (mainThread == 0)
                mainThread = System.Threading.Thread.CurrentThread.ManagedThreadId;

            L = LuaDLL.luaL_newstate();
            statemap[L] = this;



            refQueue = new Queue<UnrefPair>();
            ObjectCache.make(L);

            LuaDLL.lua_atpanic(L, panicCallback);

            LuaDLL.luaL_openlibs(L);

            string PCallCSFunction = @"
local assert = assert
local function check(ok,...)
	assert(ok, ...)
	return ...
end
return function(cs_func)
	return function(...)
		return check(cs_func(...))
	end
end
";

            LuaDLL.lua_dostring(L, PCallCSFunction);
            PCallCSFunctionRef = LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);

            string newindexfun = @"

local getmetatable=getmetatable
local rawget=rawget
local error=error
local type=type
local function newindex(ud,k,v)
    local t=getmetatable(ud)
    repeat
        local h=rawget(t,k)
        if h then
            if h[2] then
                h[2](ud,v)
                return
            else
                error('property '..k..' is read only')
            end
        end
        t=rawget(t,'__parent')
    until t==nil
    error('can not find '..k)
end

return newindex
";

            string indexfun = @"
local type=type
local error=error
local rawget=rawget
local getmetatable=getmetatable
local function index(ud,k)
    local t=getmetatable(ud)
    repeat
        local fun=rawget(t,k)
        local tp=type(fun)
        if tp=='function' then
            return fun
        elseif tp=='table' then
            local f=fun[1]
            if f then
                return f(ud)
            else
                error('property '..k..' is write only')
            end
        end
        t = rawget(t,'__parent')
    until t==nil
    error('Can not find '..k)
end

return index
";

            newindex_func = (LuaFunction)doString(newindexfun);
            index_func = (LuaFunction)doString(indexfun);

            setupPushVar();

            pcall(L, init);

            createGameObject();
        }

        void createGameObject()
        {
#if !SLUA_STANDALONE
            if (lgo == null
#if UNITY_EDITOR
                && UnityEditor.EditorApplication.isPlaying
#endif
            )
            {
                GameObject go = new GameObject("LuaSvrProxy");
                lgo = go.AddComponent<LuaSvrGameObject>();
                GameObject.DontDestroyOnLoad(go);
                lgo.onUpdate = this.tick;
                lgo.state = this;
            }
#endif
        }

        void destroyGameObject()
        {
#if !SLUA_STANDALONE
#if UNITY_EDITOR
            if (UnityEditor.EditorApplication.isPlaying)
#endif
            {
                if (lgo != null)
                {
                    GameObject go = lgo.gameObject;
                    GameObject.Destroy(lgo);
                    GameObject.Destroy(go);
                }
            }
#endif
        }

        virtual protected void tick()
        {
            checkRef();
        }


        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int init(IntPtr L)
        {
            LuaDLL.lua_pushlightuserdata(L, L);
            LuaDLL.lua_setglobal(L, "__main_state");

            LuaDLL.lua_pushcfunction(L, print);
            LuaDLL.lua_setglobal(L, "print");

            LuaDLL.lua_pushcfunction(L, printerror);
            LuaDLL.lua_setglobal(L, "printerror");

			LuaDLL.lua_pushcfunction(L, warn);
			LuaDLL.lua_setglobal(L, "warn");

#if LUA_DEBUG
            LuaDLL.lua_pushcfunction(L, getStringFromMD5); 
            LuaDLL.lua_setglobal(L, "getStringFromMD5");
#endif

            pushcsfunction(L, import);
            LuaDLL.lua_setglobal(L, "import");


            string resumefunc = @"
local resume = coroutine.resume
local function check(co, ok, err, ...)
	if not ok then UnityEngine.Debug.LogError(debug.traceback(co,err)) end
	return ok, err, ...
end
coroutine.resume=function(co,...)
	return check(co, resume(co,...))
end
";

            // overload resume function for report error
            var state = LuaState.get(L);
            state.doString(resumefunc);

            // https://github.com/pkulchenko/MobDebug/blob/master/src/mobdebug.lua#L290
            // Dump only 3 stacks, or it will return null (I don't know why)
            string dumpstackfunc = @"
local dumpstack=function()
  function vars(f)
    local dump = """"
    local func = debug.getinfo(f, ""f"").func
    local i = 1
    local locals = {}
    -- get locals
    while true do
      local name, value = debug.getlocal(f, i)
      if not name then break end
      if string.sub(name, 1, 1) ~= '(' then 
        dump = dump ..  ""    "" .. name .. ""="" .. tostring(value) .. ""\n"" 
      end
      i = i + 1
    end
    -- get varargs (these use negative indices)
    i = 1
    while true do
      local name, value = debug.getlocal(f, -i)
      -- `not name` should be enough, but LuaJIT 2.0.0 incorrectly reports `(*temporary)` names here
      if not name or name ~= ""(*vararg)"" then break end
      dump = dump ..  ""    "" .. name .. ""="" .. tostring(value) .. ""\n""
      i = i + 1
    end
    -- get upvalues
    i = 1
    while func do -- check for func as it may be nil for tail calls
      local name, value = debug.getupvalue(func, i)
      if not name then break end
      dump = dump ..  ""    "" .. name .. ""="" .. tostring(value) .. ""\n""
      i = i + 1
    end
    return dump
  end
  local dump = """"
  for i = 3, 100 do
    local source = debug.getinfo(i, ""S"")
    if not source then break end
    dump = dump .. ""- stack"" .. tostring(i-2) .. ""\n""
    dump = dump .. vars(i+1)
    if source.what == 'main' then break end
  end
  return dump
end
return dumpstack
";

            state.dumpstack = state.doString(dumpstackfunc) as LuaFunction;

#if UNITY_ANDROID
            // fix android performance drop with JIT on according to luajit mailist post
            state.doString("if jit then require('jit.opt').start('sizemcode=256','maxmcode=256') for i=1,1000 do end end");
#endif

            pushcsfunction(L, dofile);
            LuaDLL.lua_setglobal(L, "dofile");

            pushcsfunction(L, loadfile);
            LuaDLL.lua_setglobal(L, "loadfile");

            pushcsfunction(L, loader);
            int loaderFunc = LuaDLL.lua_gettop(L);

            LuaDLL.lua_getglobal(L, "package");
#if LUA_5_3
			LuaDLL.lua_getfield(L, -1, "searchers");
#else
            LuaDLL.lua_getfield(L, -1, "loaders");
#endif
            int loaderTable = LuaDLL.lua_gettop(L);

            // Shift table elements right
            for (int e = LuaDLL.lua_rawlen(L, loaderTable) + 1; e > 2; e--)
            {
                LuaDLL.lua_rawgeti(L, loaderTable, e - 1);
                LuaDLL.lua_rawseti(L, loaderTable, e);
            }
            LuaDLL.lua_pushvalue(L, loaderFunc);
            LuaDLL.lua_rawseti(L, loaderTable, 2);
            LuaDLL.lua_settop(L, 0);
            return 0;
        }

        void Close()
        {
            destroyGameObject();
            LuaTimer.DeleteAll(L);

            if (L != IntPtr.Zero)
            {
                Logger.Log("Finalizing Lua State.");
                // be careful, if you close lua vm, make sure you don't use lua state again,
                // comment this line as default for avoid unexpected crash.
                LuaDLL.lua_close(L);

                ObjectCache.del(L);
                ObjectCache.clear();

                statemap.Remove(L);

                oldptr = IntPtr.Zero;
                oldstate = null;
                L = IntPtr.Zero;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        public virtual void Dispose(bool dispose)
        {
            if (dispose)
            {
                Close();
            }
        }

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int errorReport(IntPtr L)
        {
            s.Length = 0;
            LuaDLL.lua_getglobal(L, "debug");
            LuaDLL.lua_getfield(L, -1, "traceback");
            LuaDLL.lua_pushvalue(L, 1);
            LuaDLL.lua_pushnumber(L, 2);
            LuaDLL.lua_call(L, 2, 1);
            LuaDLL.lua_remove(L, -2);
            s.Append(LuaDLL.lua_tostring(L, -1));
            LuaDLL.lua_pop(L, 1);

            LuaState state = LuaState.get(L);
            state.dumpstack.push(L);
            LuaDLL.lua_call(L, 0, 1);
            s.Append("\n");
            s.Append(LuaDLL.lua_tostring(L, -1));
            LuaDLL.lua_pop(L, 1);

            string str = s.ToString();
            Logger.LogError(str, true);
            if (state.errorDelegate != null)
            {
                state.errorDelegate(str);
            }

            return 0;
        }

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        internal static int import(IntPtr l)
        {
            try
            {
                LuaDLL.luaL_checktype(l, 1, LuaTypes.LUA_TSTRING);
                string str = LuaDLL.lua_tostring(l, 1);

                string[] ns = str.Split('.');

                LuaDLL.lua_pushglobaltable(l);

                for (int n = 0; n < ns.Length; n++)
                {
                    LuaDLL.lua_getfield(l, -1, ns[n]);
                    if (!LuaDLL.lua_istable(l, -1))
                    {
                        return LuaObject.error(l, "expect {0} is type table", ns);
                    }
                    LuaDLL.lua_remove(l, -2);
                }

                LuaDLL.lua_pushnil(l);
                while (LuaDLL.lua_next(l, -2) != 0)
                {
                    string key = LuaDLL.lua_tostring(l, -2);
                    LuaDLL.lua_getglobal(l, key);
                    if (!LuaDLL.lua_isnil(l, -1))
                    {
                        LuaDLL.lua_pop(l, 1);
                        return LuaObject.error(l, "{0} had existed, import can't overload it.", key);
                    }
                    LuaDLL.lua_pop(l, 1);
                    LuaDLL.lua_setglobal(l, key);
                }

                LuaDLL.lua_pop(l, 1);

                LuaObject.pushValue(l, true);
                return 1;
            }
            catch (Exception e)
            {
                return LuaObject.error(l, e);
            }
        }

        internal static void pcall(IntPtr l, LuaCSFunction f)
        {
            int err = LuaObject.pushTry(l);
            LuaDLL.lua_pushcfunction(l, f);
            if (LuaDLL.lua_pcall(l, 0, 0, err) != 0)
            {
                LuaDLL.lua_pop(l, 1);
            }
            LuaDLL.lua_remove(l, err);
        }



        static public bool printTrace = true;
        private static StringBuilder s = new StringBuilder();

		static string stackString(IntPtr L,int n)
		{
			s.Length = 0;

			LuaDLL.lua_getglobal(L, "tostring");

			for (int i = 1; i <= n; i++)
			{
				if (i > 1)
				{
					s.Append("    ");
				}

				LuaDLL.lua_pushvalue(L, -1);
				LuaDLL.lua_pushvalue(L, i);

				LuaDLL.lua_call(L, 1, 1);
				s.Append(LuaDLL.lua_tostring(L, -1));
				LuaDLL.lua_pop(L, 1);
			}

			if (printTrace
#if UNITY_EDITOR
				 && SLuaSetting.Instance.PrintTrace
#endif
			   )
			{
				LuaDLL.lua_getglobal(L, "debug");
				LuaDLL.lua_getfield(L, -1, "traceback");
				LuaDLL.lua_call(L, 0, 1);
				s.Append("\n");
				s.Append(LuaDLL.lua_tostring(L, -1));
			}

            return s.ToString();
		}


        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        internal static int print(IntPtr L)
        {
            int n = LuaDLL.lua_gettop(L);
            string str = stackString(L,n);
            Logger.Log(str, true);

            LuaState state = LuaState.get(L);
            if (state.logDelegate != null)
            {
                state.logDelegate(s.ToString());
            }

            LuaDLL.lua_settop(L, n);

			return 0;
		}
        
        // copy from print()
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        internal static int printerror(IntPtr L)
        {
            int n = LuaDLL.lua_gettop(L);
            string str = stackString(L,n);
            Logger.LogError(str, true);

            LuaState state = LuaState.get(L);
            if (state.errorDelegate != null)
            {
                state.errorDelegate(s.ToString());
            }

            LuaDLL.lua_settop(L, n);

            return 0;
        }

		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		internal static int warn(IntPtr L)
		{
			int n = LuaDLL.lua_gettop(L);
			string str = stackString (L, n);
			Logger.LogWarning(str);
			LuaState state = LuaState.get(L);
			if (state.warnDelegate != null)
			{
				state.warnDelegate(s.ToString());
			}

			LuaDLL.lua_settop(L, n);
			return 0;
		}



        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		internal static int loadfile(IntPtr L)
		{
			loader(L);

			if (LuaDLL.lua_isnil(L, -1))
			{
				string fileName = LuaDLL.lua_tostring(L, 1);
				return LuaObject.error(L, "Can't find {0}", fileName);
			}
			return 2;
		}

		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		internal static int dofile(IntPtr L)
		{
			int n = LuaDLL.lua_gettop(L);

			loader(L);
			if (!LuaDLL.lua_toboolean(L, -2))
			{
				return 2;
			}
			else
			{
				if (LuaDLL.lua_isnil(L, -1))
				{
					string fileName = LuaDLL.lua_tostring(L, 1);
					return LuaObject.error(L, "Can't find {0}", fileName);
				}
				int k = LuaDLL.lua_gettop(L);
				LuaDLL.lua_call(L, 0, LuaDLL.LUA_MULTRET);
				k = LuaDLL.lua_gettop(L);
				return k - n;
			}
		}

		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		static public int panicCallback(IntPtr l)
		{
			string reason = string.Format("unprotected error in call to Lua API ({0})", LuaDLL.lua_tostring(l, -1));
			throw new Exception(reason);
		}

		static public void pushcsfunction(IntPtr L, LuaCSFunction function)
		{
			LuaDLL.lua_getref(L, get(L).PCallCSFunctionRef);
			LuaDLL.lua_pushcclosure(L, function, 0);
			LuaDLL.lua_call(L, 1, 1);
		}
#if LUA_DEBUG
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static public int getStringFromMD5(IntPtr L) {
			string str = LuaDLL.lua_tostring(L, -1);
            string destString = "";

            if (debugStringMap.ContainsKey(str))
            {
                destString = debugStringMap[str];
            }
            LuaObject.pushValue(L, destString);
            return 1;
        }

        static public string getStringMD5(string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);
            byte[] md5Data = md5.ComputeHash(bytes, 0, bytes.Length);
            md5.Clear();

            string destString = "";
            for (int i = 0; i < md5Data.Length; i++)
            {
                destString += System.Convert.ToString(md5Data[i], 16).PadLeft(2, '0');
            }
            destString = destString.PadLeft(32, '0');
            return destString;
        }
#endif

        public object doString(string str)
		{
#if LUA_DEBUG
            //get str's md5 string
            string stringMd5 = getStringMD5(str);
            debugStringMap.Add(stringMd5, str);
            return doString(str, stringMd5);
#else
            return doString(str, "temp buffer");
#endif
        }

		public object doString(string str, string chunkname)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(str);

			object obj;
			if (doBuffer(bytes, chunkname, out obj))
				return obj;
			return null; ;
		}

		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		internal static int loader(IntPtr L)
		{
            LuaState state = LuaState.get(L);
			string fileName = LuaDLL.lua_tostring(L, 1);
			string absoluteFn = "";
			byte[] bytes = state.loadFile(fileName, ref absoluteFn);
			if (bytes != null)
			{
#if LUA_DEBUG	
				if (absoluteFn != "") {
					fileName = absoluteFn;
				}
#endif
				if (LuaDLL.luaL_loadbuffer(L, bytes, bytes.Length, "@" + fileName) == 0)
				{
					LuaObject.pushValue(L, true);
					LuaDLL.lua_insert(L, -2);
					return 2;
				}
				else
				{
					string errstr = LuaDLL.lua_tostring(L, -1);
					return LuaObject.error(L, errstr);
				}
			}
			LuaObject.pushValue(L, true);
			LuaDLL.lua_pushnil(L);
			return 2;
		}

		public object doFile(string fn)
		{
			string absoluteFn = "";
			byte[] bytes = loadFile(fn , ref absoluteFn);
			if (bytes == null)
			{
				Logger.LogError(string.Format("Can't find {0}", fn));
				return null;
			}

#if LUA_DEBUG	
			if (absoluteFn != "") {
				fn = absoluteFn;
			}
#endif
			object obj;
			if (doBuffer(bytes, "@" + fn, out obj))
				return obj;
			return null;
		}

	    /// <summary>
	    /// Ensure remove BOM from bytes
	    /// </summary>
	    /// <param name="bytes"></param>
	    /// <returns></returns>
	    public static byte[] CleanUTF8Bom(byte[] bytes)
	    {
            if (bytes.Length > 3 && bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF)
            {
                var oldBytes = bytes;
                bytes = new byte[bytes.Length - 3];
                Array.Copy(oldBytes, 3, bytes, 0, bytes.Length);
            }
            return bytes;
	    }

		public bool doBuffer(byte[] bytes, string fn, out object ret)
        {        
            // ensure no utf-8 bom, LuaJIT can read BOM, but Lua cannot!
		    bytes = CleanUTF8Bom(bytes);
            ret = null;
			int errfunc = LuaObject.pushTry(L);
			if (LuaDLL.luaL_loadbuffer(L, bytes, bytes.Length, fn) == 0)
			{
				if (LuaDLL.lua_pcall(L, 0, LuaDLL.LUA_MULTRET, errfunc) != 0)
				{
					LuaDLL.lua_pop(L, 2);
					return false;
				}
				LuaDLL.lua_remove(L, errfunc); // pop error function
				ret = topObjects(errfunc - 1);
				return true;
			}
			string err = LuaDLL.lua_tostring(L, -1);
			LuaDLL.lua_pop(L, 2);
			throw new Exception(err);
		}

#if UNITY_EDITOR
		static TextAsset loadAsset(string fn) {
			TextAsset asset;
#if UNITY_5
			asset = UnityEditor.AssetDatabase.LoadAssetAtPath<TextAsset> (fn);
#else
			asset = (TextAsset)UnityEditor.AssetDatabase.LoadAssetAtPath (fn, typeof(TextAsset));
#endif
			return asset;
		}
#endif

		internal byte[] loadFile (string fn, ref string absoluteFn)
		{
			try {
				byte[] bytes;
				if (loaderDelegate != null)
					bytes = loaderDelegate (fn, ref absoluteFn);
				else {
#if !SLUA_STANDALONE
					fn = fn.Replace (".", "/");

					TextAsset asset = null;

#if UNITY_EDITOR


					if (SLuaSetting.Instance.jitType == JITBUILDTYPE.none) {
						asset = (TextAsset)Resources.Load (fn);
					}
					else if (SLuaSetting.Instance.jitType == JITBUILDTYPE.X86) {
						asset = loadAsset("Assets/Slua/jit/jitx86/" + fn + ".bytes");
					} else if (SLuaSetting.Instance.jitType == JITBUILDTYPE.X64) {
						asset = loadAsset("Assets/Slua/jit/jitx64/" + fn + ".bytes");
					} else if (SLuaSetting.Instance.jitType == JITBUILDTYPE.GC64) {
						asset = loadAsset("Assets/Slua/jit/jitgc64/" + fn + ".bytes");
					}

#if LUA_DEBUG
					//get asset's absolute path
					string assetFn = UnityEditor.AssetDatabase.GetAssetPath(asset);
					if (assetFn != ""){
						//find out asset path, remove assetFn's first "Asset/"
						int idx = assetFn.IndexOf("/");
						if(idx > 0){
							absoluteFn = Application.dataPath + assetFn.Substring(idx);
						}
					}
#endif
#else
					asset = (TextAsset)Resources.Load(fn);
#endif

					if (asset == null)
						return null;
					bytes = asset.bytes;
#else
					bytes = File.ReadAllBytes(fn);
#endif
				}
				return bytes;
			} catch (Exception e) {
				throw new Exception (e.Message);
			}
		}


		internal object getObject(string key, bool wholekey=false, bool rawget=false)
		{
			LuaDLL.lua_pushglobaltable(L);
            object o;
            if (wholekey)
                o = getObject(new string[] { key },rawget);
            else
			    o = getObject(key.Split(new char[] { '.' }),rawget);
			LuaDLL.lua_pop(L, 1);
			return o;
		}

        internal void setObject(string key, object v, bool wholekey = false, bool rawset = false)
		{
			LuaDLL.lua_pushglobaltable(L);
            if (wholekey)
                setObject(new string[] { key }, v, rawset);
            else
			    setObject(key.Split(new char[] { '.' }), v, rawset);
			LuaDLL.lua_pop(L, 1);
		}

		internal object getObject(string[] remainingPath,bool rawget=false)
		{
			object returnValue = null;
			for (int i = 0; i < remainingPath.Length; i++)
			{
				LuaDLL.lua_pushstring(L, remainingPath[i]);
                if (rawget)
                    LuaDLL.lua_rawget(L, -2);
                else
				    LuaDLL.lua_gettable(L, -2);
				returnValue = this.getObject(L, -1);
				LuaDLL.lua_remove(L, -2);
				if (returnValue == null) break;
			}
			return returnValue;
		}


        internal object getObject(int reference, string field, bool wholekey = false, bool rawget = false)
		{
			int oldTop = LuaDLL.lua_gettop(L);
			LuaDLL.lua_getref(L, reference);
            object returnValue;
            if (wholekey)
                returnValue = getObject(new string[]{field}, rawget);
            else
                returnValue = getObject(field.Split(new char[] { '.' }), rawget);
			LuaDLL.lua_settop(L, oldTop);
			return returnValue;
		}

		internal object getObject(int reference, int index,bool rawget=false)
		{
            if (index >= 1)
            {
                LuaDLL.lua_getref (L, reference);
                if (rawget)
                    LuaDLL.lua_rawgeti(L, -1, index);
                else
                {
                    LuaDLL.lua_pushinteger(L, index);
                    LuaDLL.lua_gettable(L, -2);
                }
				object returnValue = getObject (L, -1);
                LuaDLL.lua_pop(L, 2);
                return returnValue;
			} else {
				LuaDLL.lua_getref (L, reference);
				LuaDLL.lua_pushinteger (L, index);
				LuaDLL.lua_gettable (L, -2);
				object returnValue = getObject (L, -1);
                LuaDLL.lua_pop(L, 2);
                return returnValue;
			}
		}

        internal object getObject(int reference, object field,bool rawget=false)
		{
			int oldTop = LuaDLL.lua_gettop(L);
			LuaDLL.lua_getref(L, reference);
			LuaObject.pushObject(L, field);
            if (rawget)
                LuaDLL.lua_rawget(L, -2);
            else
			    LuaDLL.lua_gettable(L, -2);
			object returnValue = getObject(L, -1);
			LuaDLL.lua_settop(L, oldTop);
			return returnValue;
		}

		internal void setObject(string[] remainingPath, object o, bool rawset=false)
		{
			int top = LuaDLL.lua_gettop(L);
			for (int i = 0; i < remainingPath.Length - 1; i++)
			{
				LuaDLL.lua_pushstring(L, remainingPath[i]);
                if (rawset)
                    LuaDLL.lua_rawget(L, -2);
                else
				    LuaDLL.lua_gettable(L, -2);
			}
			LuaDLL.lua_pushstring(L, remainingPath[remainingPath.Length - 1]);
			LuaObject.pushVar(L, o);
            if (rawset)
                LuaDLL.lua_rawset(L, -3);
            else
			    LuaDLL.lua_settable(L, -3);
			LuaDLL.lua_settop(L, top);
		}


        internal void setObject(int reference, string field, object o, bool wholekey = false, bool rawset = false)
		{
			int oldTop = LuaDLL.lua_gettop(L);
			LuaDLL.lua_getref(L, reference);
            if (wholekey)
                setObject(new string[] { field }, o, rawset);
            else
                setObject(field.Split(new char[] { '.' }), o, rawset);
			LuaDLL.lua_settop(L, oldTop);
		}

        internal void setObject(int reference, int index, object o, bool rawset=false)
		{
			if (index >= 1) {
				LuaDLL.lua_getref (L, reference);

                if (rawset)
                {
                    LuaObject.pushVar(L, o);
                    LuaDLL.lua_rawseti(L, -2, index);
                }
                else
                {
                    LuaDLL.lua_pushinteger(L, index);
                    LuaObject.pushVar(L, o);
                    LuaDLL.lua_settable(L, -3);
                }
				LuaDLL.lua_pop (L, 1);
			} else {
				LuaDLL.lua_getref (L, reference);
				LuaDLL.lua_pushinteger (L, index);
				LuaObject.pushVar (L, o);
                if (rawset)
                    LuaDLL.lua_rawset(L, -3);
                else
				    LuaDLL.lua_settable (L, -3);
				LuaDLL.lua_pop (L, 1);
			}
		}

		internal void setObject(int reference, object field, object o, bool rawset)
		{
			int oldTop = LuaDLL.lua_gettop(L);
			LuaDLL.lua_getref(L, reference);
			LuaObject.pushObject(L, field);
			LuaObject.pushObject(L, o);
			LuaDLL.lua_settable(L, -3);
			LuaDLL.lua_settop(L, oldTop);
		}

		internal object topObjects(int from)
		{
			int top = LuaDLL.lua_gettop(L);
			int nArgs = top - from;
			if (nArgs == 0)
				return null;
			else if (nArgs == 1)
			{
				object o = LuaObject.checkVar(L, top);
				LuaDLL.lua_pop(L, 1);
				return o;
			}
			else
			{
				object[] o = new object[nArgs];
				for (int n = 1; n <= nArgs; n++)
				{
					o[n - 1] = LuaObject.checkVar(L, from + n);

				}
				LuaDLL.lua_settop(L, from);
				return o;
			}
		}

		object getObject(IntPtr l, int p)
		{
			p = LuaDLL.lua_absindex(l, p);
			return LuaObject.checkVar(l, p);
		}

		public LuaFunction getFunction(string key)
		{
			return (LuaFunction)this[key];
		}

		public LuaTable getTable(string key)
		{
			return (LuaTable)this[key];
		}


		public object this[string path]
		{
			get
			{
				return this.getObject(path);
			}
			set
			{
				this.setObject(path, value);
			}
		}

		public void gcRef(UnRefAction act, int r)
		{
			UnrefPair u = new UnrefPair();
			u.act = act;
			u.r = r;
			lock (refQueue)
			{
				refQueue.Enqueue(u);
			}
		}

		public void checkRef()
		{
			int cnt = 0;
			// fix il2cpp lock issue on iOS
			lock (refQueue)
			{
				cnt = refQueue.Count;
			}

			var l = L;
			for (int n = 0; n < cnt; n++)
			{
				UnrefPair u;
				lock (refQueue)
				{
					u = refQueue.Dequeue();
				}
				u.act(l, u.r);
			}
		}

        public void regPushVar(Type t, PushVarDelegate d) { typePushMap[t] = d; }
        public bool tryGetTypePusher(Type t, out PushVarDelegate d) { return typePushMap.TryGetValue(t, out d); }

        void setupPushVar()
        {
            typePushMap[typeof(float)] = (IntPtr L, object o) =>
            {
                LuaDLL.lua_pushnumber(L, (float)o);
            };
            typePushMap[typeof(double)] = (IntPtr L, object o) =>
            {
                LuaDLL.lua_pushnumber(L, (double)o);
            };

            typePushMap[typeof(int)] =
                (IntPtr L, object o) =>
                {
                    LuaDLL.lua_pushinteger(L, (int)o);
                };

            typePushMap[typeof(uint)] =
                (IntPtr L, object o) =>
                {
                    LuaDLL.lua_pushnumber(L, Convert.ToUInt32(o));
                };

            typePushMap[typeof(short)] =
                (IntPtr L, object o) =>
                {
                    LuaDLL.lua_pushinteger(L, (short)o);
                };

            typePushMap[typeof(ushort)] =
               (IntPtr L, object o) =>
               {
                   LuaDLL.lua_pushinteger(L, (ushort)o);
               };

            typePushMap[typeof(sbyte)] =
               (IntPtr L, object o) =>
               {
                   LuaDLL.lua_pushinteger(L, (sbyte)o);
               };

            typePushMap[typeof(byte)] =
               (IntPtr L, object o) =>
               {
                   LuaDLL.lua_pushinteger(L, (byte)o);
               };


            typePushMap[typeof(Int64)] =
                typePushMap[typeof(UInt64)] =
                (IntPtr L, object o) =>
                {
#if LUA_5_3
					LuaDLL.lua_pushinteger(L, (long)o);
#else
                    LuaDLL.lua_pushnumber(L, System.Convert.ToDouble(o));
#endif
                };

            typePushMap[typeof(string)] = (IntPtr L, object o) =>
            {
                LuaDLL.lua_pushstring(L, (string)o);
            };

            typePushMap[typeof(bool)] = (IntPtr L, object o) =>
            {
                LuaDLL.lua_pushboolean(L, (bool)o);
            };

            typePushMap[typeof(LuaTable)] =
                typePushMap[typeof(LuaFunction)] =
                typePushMap[typeof(LuaThread)] =
                (IntPtr L, object o) =>
                {
                    ((LuaVar)o).push(L);
                };

            typePushMap[typeof(LuaCSFunction)] = (IntPtr L, object o) =>
            {
                LuaObject.pushValue(L, (LuaCSFunction)o);
            };

#if !SLUA_STANDALONE
            regPushVar(typeof(UnityEngine.Vector2), (IntPtr L, object o) => { LuaObject.pushValue(L, (UnityEngine.Vector2)o); });
            regPushVar(typeof(UnityEngine.Vector3), (IntPtr L, object o) => { LuaObject.pushValue(L, (UnityEngine.Vector3)o); });
            regPushVar(typeof(UnityEngine.Vector4), (IntPtr L, object o) => { LuaObject.pushValue(L, (UnityEngine.Vector4)o); });
            regPushVar(typeof(UnityEngine.Quaternion), (IntPtr L, object o) => { LuaObject.pushValue(L, (UnityEngine.Quaternion)o); });
            regPushVar(typeof(UnityEngine.Color), (IntPtr L, object o) => { LuaObject.pushValue(L, (UnityEngine.Color)o); });
#endif
        }

		public int pushTry(IntPtr L)
        {
            if (errorRef == 0)
            {
                LuaDLL.lua_pushcfunction(L, LuaState.errorFunc);
                LuaDLL.lua_pushvalue(L, -1);
                errorRef = LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
            }
            else
            {
                LuaDLL.lua_getref(L, errorRef);
            }
            return LuaDLL.lua_gettop(L);
        }

        public object run(string entry) {
            using (LuaFunction func = getFunction(entry))
			{
				if (func != null)
					return func.call();
			}
            return null;
        }
    }
}
