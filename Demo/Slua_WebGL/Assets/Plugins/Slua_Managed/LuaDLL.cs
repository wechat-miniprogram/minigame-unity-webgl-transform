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

using System;
using System.Runtime.InteropServices;

namespace SLua
{
#pragma warning disable 414
    public class MonoPInvokeCallbackAttribute : System.Attribute
    {
        private Type type;

        public MonoPInvokeCallbackAttribute(Type t)
        {
            type = t;
        }
    }
#pragma warning restore 414

    public enum LuaTypes : int
    {
        LUA_TNONE = -1,
        LUA_TNIL = 0,
        LUA_TBOOLEAN = 1,
        LUA_TLIGHTUSERDATA = 2,
        LUA_TNUMBER = 3,
        LUA_TSTRING = 4,
        LUA_TTABLE = 5,
        LUA_TFUNCTION = 6,
        LUA_TUSERDATA = 7,
        LUA_TTHREAD = 8,
    }

    public enum LuaGCOptions
    {
        LUA_GCSTOP = 0,
        LUA_GCRESTART = 1,
        LUA_GCCOLLECT = 2,
        LUA_GCCOUNT = 3,
        LUA_GCCOUNTB = 4,
        LUA_GCSTEP = 5,
        LUA_GCSETPAUSE = 6,
        LUA_GCSETSTEPMUL = 7,
    }

    public enum LuaThreadStatus : int
    {
        LUA_YIELD = 1,
        LUA_ERRRUN = 2,
        LUA_ERRSYNTAX = 3,
        LUA_ERRMEM = 4,
        LUA_ERRERR = 5,
    }

    public sealed class LuaIndexes
    {
#if LUA_5_3
        // for lua5.3
        public static int LUA_REGISTRYINDEX = -1000000 - 1000;
#else
        // for lua5.1 or luajit
        public static int LUA_REGISTRYINDEX = -10000;
        public static int LUA_GLOBALSINDEX = -10002;
#endif
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ReaderInfo
    {
        public String chunkData;
        public bool finished;
    }

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int LuaCSFunction(IntPtr luaState);
#else
    public delegate int LuaCSFunction(IntPtr luaState);
#endif

    public delegate string LuaChunkReader(IntPtr luaState, ref ReaderInfo data, ref uint size);

    public delegate int LuaFunctionCallback(IntPtr luaState);

    public class LuaDLL
    {
        public static int LUA_MULTRET = -1;

#if (UNITY_IPHONE || UNITY_WEBGL) && !UNITY_EDITOR
        const string LUADLL = "__Internal";
#else
        const string LUADLL = "slua";
#endif

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaS_openextlibs(IntPtr L);

        // Thread Funcs
        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_tothread(IntPtr L, int index);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_xmove(IntPtr from, IntPtr to, int n);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr lua_newthread(IntPtr L);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_status(IntPtr L);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_pushthread(IntPtr L);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_gc(IntPtr luaState, LuaGCOptions what, int data);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr lua_typename(IntPtr luaState, int type);

        public static string lua_typenamestr(IntPtr luaState, LuaTypes type)
        {
            IntPtr p = lua_typename(luaState, (int)type);
            return Marshal.PtrToStringAnsi(p);
        }

        public static string luaL_typename(IntPtr luaState, int stackPos)
        {
            return LuaDLL.lua_typenamestr(luaState, LuaDLL.lua_type(luaState, stackPos));
        }

        public static bool lua_isfunction(IntPtr luaState, int stackPos)
        {
            return lua_type(luaState, stackPos) == LuaTypes.LUA_TFUNCTION;
        }

        public static bool lua_islightuserdata(IntPtr luaState, int stackPos)
        {
            return lua_type(luaState, stackPos) == LuaTypes.LUA_TLIGHTUSERDATA;
        }

        public static bool lua_istable(IntPtr luaState, int stackPos)
        {
            return lua_type(luaState, stackPos) == LuaTypes.LUA_TTABLE;
        }

        public static bool lua_isthread(IntPtr luaState, int stackPos)
        {
            return lua_type(luaState, stackPos) == LuaTypes.LUA_TTHREAD;
        }

        [Obsolete]
        public static void luaL_error(IntPtr luaState, string message)
        {
            //LuaDLL.lua_pushstring(luaState, message);
            //LuaDLL.lua_error(luaState);
        }

        [Obsolete]
        public static void luaL_error(IntPtr luaState, string fmt, params object[] args)
        {
            //string str = string.Format(fmt, args);
            //luaL_error(luaState, str);
        }

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern string luaL_gsub(
            IntPtr luaState,
            string str,
            string pattern,
            string replacement
        );

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_isuserdata(IntPtr luaState, int stackPos);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_rawequal(IntPtr luaState, int stackPos1, int stackPos2);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_setfield(IntPtr luaState, int stackPos, string name);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaL_callmeta(IntPtr luaState, int stackPos, string name);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr luaL_newstate();

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_close(IntPtr luaState);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaL_openlibs(IntPtr luaState);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaL_loadstring(IntPtr luaState, string chunk);

        public static int luaL_dostring(IntPtr luaState, string chunk)
        {
            int result = LuaDLL.luaL_loadstring(luaState, chunk);
            if (result != 0)
                return result;

            return LuaDLL.lua_pcall(luaState, 0, -1, 0);
        }

        public static int lua_dostring(IntPtr luaState, string chunk)
        {
            return LuaDLL.luaL_dostring(luaState, chunk);
        }

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_createtable(IntPtr luaState, int narr, int nrec);

        public static void lua_newtable(IntPtr luaState)
        {
            LuaDLL.lua_createtable(luaState, 0, 0);
        }

#if LUA_5_3
        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_getglobal(IntPtr luaState, string name);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_setglobal(IntPtr luaState, string name);

        public static void lua_insert(IntPtr luaState, int newTop)
        {
            lua_rotate(luaState, newTop, 1);
        }

        public static void lua_pushglobaltable(IntPtr l)
        {
            lua_rawgeti(l, LuaIndexes.LUA_REGISTRYINDEX, 2);
        }

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_rotate(IntPtr luaState, int index, int n);

        public static int lua_rawlen(IntPtr luaState, int stackPos)
        {
            return LuaDLLWrapper.luaS_rawlen(luaState, stackPos);
        }

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaL_loadbufferx(
            IntPtr luaState,
            byte[] buff,
            int size,
            string name,
            IntPtr x
        );

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_callk(
            IntPtr luaState,
            int nArgs,
            int nResults,
            int ctx,
            IntPtr k
        );

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_pcallk(
            IntPtr luaState,
            int nArgs,
            int nResults,
            int errfunc,
            int ctx,
            IntPtr k
        );

        //		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        //		public static extern int luaS_pcall(IntPtr luaState, int nArgs, int nResults, int errfunc);

        public static int lua_call(IntPtr luaState, int nArgs, int nResults)
        {
            return lua_callk(luaState, nArgs, nResults, 0, IntPtr.Zero);
        }

        public static int lua_pcall(IntPtr luaState, int nArgs, int nResults, int errfunc)
        {
            return lua_pcallk(luaState, nArgs, nResults, errfunc, 0, IntPtr.Zero);
        }

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern double lua_tonumberx(IntPtr luaState, int index, IntPtr x);

        public static double lua_tonumber(IntPtr luaState, int index)
        {
            return lua_tonumberx(luaState, index, IntPtr.Zero);
        }

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int64 lua_tointegerx(IntPtr luaState, int index, IntPtr x);

        public static int lua_tointeger(IntPtr luaState, int index)
        {
            return (int)lua_tointegerx(luaState, index, IntPtr.Zero);
        }

        public static int luaL_loadbuffer(IntPtr luaState, byte[] buff, int size, string name)
        {
            return luaL_loadbufferx(luaState, buff, size, name, IntPtr.Zero);
        }

        public static void lua_remove(IntPtr l, int idx)
        {
            lua_rotate(l, (idx), -1);
            lua_pop(l, 1);
        }

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_rawgeti(IntPtr luaState, int tableIndex, Int64 index);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_rawseti(IntPtr luaState, int tableIndex, Int64 index);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushinteger(IntPtr luaState, Int64 i);

        public static Int64 luaL_checkinteger(IntPtr luaState, int stackPos)
        {
            luaL_checktype(luaState, stackPos, LuaTypes.LUA_TNUMBER);
            return lua_tointegerx(luaState, stackPos, IntPtr.Zero);
        }

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaS_yield(IntPtr luaState, int nrets);

        public static int lua_yield(IntPtr luaState, int nrets)
        {
            return luaS_yield(luaState, nrets);
        }

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_resume(IntPtr L, IntPtr from, int narg);

        public static int lua_resume(IntPtr L, int narg)
        {
            return lua_resume(L, IntPtr.Zero, narg);
        }

        public static void lua_replace(IntPtr luaState, int index)
        {
            lua_copy(luaState, -1, (index));
            lua_pop(luaState, 1);
        }

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_copy(IntPtr luaState, int from, int toidx);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_isinteger(IntPtr luaState, int p);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_compare(IntPtr luaState, int index1, int index2, int op);

        public static int lua_equal(IntPtr luaState, int index1, int index2)
        {
            return lua_compare(luaState, index1, index2, 0);
        }
#else
        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_resume(IntPtr L, int narg);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_lessthan(IntPtr luaState, int stackPos1, int stackPos2);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_getfenv(IntPtr luaState, int stackPos);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_yield(IntPtr L, int nresults);

        public static void lua_getglobal(IntPtr luaState, string name)
        {
            LuaDLL.lua_pushstring(luaState, name);
            LuaDLL.lua_gettable(luaState, LuaIndexes.LUA_GLOBALSINDEX);
        }

        public static void lua_setglobal(IntPtr luaState, string name)
        {
            LuaDLL.lua_pushstring(luaState, name);
            LuaDLL.lua_insert(luaState, -2);
            LuaDLL.lua_settable(luaState, LuaIndexes.LUA_GLOBALSINDEX);
        }

        public static void lua_pushglobaltable(IntPtr l)
        {
            LuaDLL.lua_pushvalue(l, LuaIndexes.LUA_GLOBALSINDEX);
        }

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_insert(IntPtr luaState, int newTop);

        public static int lua_rawlen(IntPtr luaState, int stackPos)
        {
            return LuaDLLWrapper.luaS_objlen(luaState, stackPos);
        }

        public static int lua_strlen(IntPtr luaState, int stackPos)
        {
            return lua_rawlen(luaState, stackPos);
        }

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_call(IntPtr luaState, int nArgs, int nResults);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_pcall(IntPtr luaState, int nArgs, int nResults, int errfunc);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern double lua_tonumber(IntPtr luaState, int index);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_tointeger(IntPtr luaState, int index);

        public static int luaL_loadbuffer(IntPtr luaState, byte[] buff, int size, string name)
        {
            return LuaDLLWrapper.luaLS_loadbuffer(luaState, buff, size, name);
        }

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_remove(IntPtr luaState, int index);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_rawgeti(IntPtr luaState, int tableIndex, int index);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_rawseti(IntPtr luaState, int tableIndex, int index);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushinteger(IntPtr luaState, IntPtr i);

        public static void lua_pushinteger(IntPtr luaState, int i)
        {
            lua_pushinteger(luaState, (IntPtr)i);
        }

        public static int luaL_checkinteger(IntPtr luaState, int stackPos)
        {
            luaL_checktype(luaState, stackPos, LuaTypes.LUA_TNUMBER);
            return lua_tointeger(luaState, stackPos);
        }

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_replace(IntPtr luaState, int index);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_setfenv(IntPtr luaState, int stackPos);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_equal(IntPtr luaState, int index1, int index2);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaL_loadfile(IntPtr luaState, string filename);
#endif

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_settop(IntPtr luaState, int newTop);

        public static void lua_pop(IntPtr luaState, int amount)
        {
            LuaDLL.lua_settop(luaState, -(amount) - 1);
        }

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_gettable(IntPtr luaState, int index);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_rawget(IntPtr luaState, int index);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_settable(IntPtr luaState, int index);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_rawset(IntPtr luaState, int index);

#if LUA_5_3
        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_setmetatable(IntPtr luaState, int objIndex);
#else
        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_setmetatable(IntPtr luaState, int objIndex);
#endif

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_getmetatable(IntPtr luaState, int objIndex);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushvalue(IntPtr luaState, int index);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_gettop(IntPtr luaState);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern LuaTypes lua_type(IntPtr luaState, int index);

        public static bool lua_isnil(IntPtr luaState, int index)
        {
            return (LuaDLL.lua_type(luaState, index) == LuaTypes.LUA_TNIL);
        }

        public static bool lua_isnumber(IntPtr luaState, int index)
        {
            return LuaDLLWrapper.lua_isnumber(luaState, index) > 0;
        }

        public static bool lua_isboolean(IntPtr luaState, int index)
        {
            return LuaDLL.lua_type(luaState, index) == LuaTypes.LUA_TBOOLEAN;
        }

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaL_ref(IntPtr luaState, int registryIndex);

        public static void lua_getref(IntPtr luaState, int reference)
        {
            LuaDLL.lua_rawgeti(luaState, LuaIndexes.LUA_REGISTRYINDEX, reference);
        }

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaL_unref(IntPtr luaState, int registryIndex, int reference);

        public static void lua_unref(IntPtr luaState, int reference)
        {
            LuaDLL.luaL_unref(luaState, LuaIndexes.LUA_REGISTRYINDEX, reference);
        }

        public static bool lua_isstring(IntPtr luaState, int index)
        {
            return LuaDLLWrapper.lua_isstring(luaState, index) > 0;
        }

        public static bool lua_iscfunction(IntPtr luaState, int index)
        {
            return LuaDLLWrapper.lua_iscfunction(luaState, index) > 0;
        }

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushnil(IntPtr luaState);

        public static void luaL_checktype(IntPtr luaState, int p, LuaTypes t)
        {
            LuaTypes ct = LuaDLL.lua_type(luaState, p);
            if (ct != t)
            {
                throw new Exception(
                    string.Format(
                        "arg {0} expect {1}, got {2}",
                        p,
                        lua_typenamestr(luaState, t),
                        lua_typenamestr(luaState, ct)
                    )
                );
            }
        }

        public static void lua_pushcfunction(IntPtr luaState, LuaCSFunction function)
        {
#if SLUA_STANDALONE
            // Add all LuaCSFunction�� or they will be GC collected!  (problem at windows, .net framework 4.5, `CallbackOnCollectedDelegated` exception)
            GCHandle.Alloc(function);
#endif
            IntPtr fn = Marshal.GetFunctionPointerForDelegate(function);
            lua_pushcclosure(luaState, fn, 0);
        }

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr lua_tocfunction(IntPtr luaState, int index);

        public static bool lua_toboolean(IntPtr luaState, int index)
        {
            return LuaDLLWrapper.lua_toboolean(luaState, index) > 0;
        }

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr luaS_tolstring32(IntPtr luaState, int index, out int strLen);

        public static string lua_tostring(IntPtr luaState, int index)
        {
            int strlen;

            IntPtr str = luaS_tolstring32(luaState, index, out strlen); // fix il2cpp 64 bit
            string s = null;
            if (strlen > 0 && str != IntPtr.Zero)
            {
                s = Marshal.PtrToStringAnsi(str);
                // fallback method
                if (s == null)
                {
                    byte[] b = new byte[strlen];
                    Marshal.Copy(str, b, 0, strlen);
                    s = System.Text.Encoding.Default.GetString(b);
                }
            }
            return (s == null) ? string.Empty : s;
        }

        public static byte[] lua_tobytes(IntPtr luaState, int index)
        {
            int strlen;

            IntPtr str = luaS_tolstring32(luaState, index, out strlen); // fix il2cpp 64 bit

            if (str != IntPtr.Zero)
            {
                byte[] bytes = new byte[strlen];
                Marshal.Copy(str, bytes, 0, strlen);
                return bytes;
            }
            return null;
        }

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr lua_atpanic(IntPtr luaState, LuaCSFunction panicf);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushnumber(IntPtr luaState, double number);

        public static void lua_pushboolean(IntPtr luaState, bool value)
        {
            LuaDLLWrapper.lua_pushboolean(luaState, value ? 1 : 0);
        }

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushstring(IntPtr luaState, string str);

        public static void lua_pushlstring(IntPtr luaState, byte[] str, int size)
        {
            LuaDLLWrapper.luaS_pushlstring(luaState, str, size);
        }

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaL_newmetatable(IntPtr luaState, string meta);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_getfield(IntPtr luaState, int stackPos, string meta);

        public static void luaL_getmetatable(IntPtr luaState, string meta)
        {
            LuaDLL.lua_getfield(luaState, LuaIndexes.LUA_REGISTRYINDEX, meta);
        }

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr luaL_checkudata(IntPtr luaState, int stackPos, string meta);

        public static bool luaL_getmetafield(IntPtr luaState, int stackPos, string field)
        {
            return LuaDLLWrapper.luaL_getmetafield(luaState, stackPos, field) > 0;
        }

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_load(
            IntPtr luaState,
            LuaChunkReader chunkReader,
            ref ReaderInfo data,
            string chunkName
        );

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_error(IntPtr luaState);

        public static bool lua_checkstack(IntPtr luaState, int extra)
        {
            return LuaDLLWrapper.lua_checkstack(luaState, extra) > 0;
        }

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_next(IntPtr luaState, int index);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushlightuserdata(IntPtr luaState, IntPtr udata);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaL_where(IntPtr luaState, int level);

        public static double luaL_checknumber(IntPtr luaState, int stackPos)
        {
            luaL_checktype(luaState, stackPos, LuaTypes.LUA_TNUMBER);
            return lua_tonumber(luaState, stackPos);
        }

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_concat(IntPtr luaState, int n);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaS_newuserdata(IntPtr luaState, int val);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaS_rawnetobj(IntPtr luaState, int obj);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr lua_touserdata(IntPtr luaState, int index);

        public static int lua_absindex(IntPtr luaState, int index)
        {
            return index > 0 ? index : lua_gettop(luaState) + index + 1;
        }

        public static int lua_upvalueindex(int i)
        {
#if LUA_5_3
            return LuaIndexes.LUA_REGISTRYINDEX - i;
#else
            return LuaIndexes.LUA_GLOBALSINDEX - i;
#endif
        }

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushcclosure(IntPtr l, IntPtr f, int nup);

        public static void lua_pushcclosure(IntPtr l, LuaCSFunction f, int nup)
        {
#if SLUA_STANDALONE
            // Add all LuaCSFunction�� or they will be GC collected!  (problem at windows, .net framework 4.5, `CallbackOnCollectedDelegated` exception)
            GCHandle.Alloc(f);
#endif
            IntPtr fn = Marshal.GetFunctionPointerForDelegate(f);
            lua_pushcclosure(l, fn, nup);
        }

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaS_checkVector2(IntPtr l, int p, out float x, out float y);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaS_checkVector3(
            IntPtr l,
            int p,
            out float x,
            out float y,
            out float z
        );

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaS_checkVector4(
            IntPtr l,
            int p,
            out float x,
            out float y,
            out float z,
            out float w
        );

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaS_checkQuaternion(
            IntPtr l,
            int p,
            out float x,
            out float y,
            out float z,
            out float w
        );

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaS_checkColor(
            IntPtr l,
            int p,
            out float x,
            out float y,
            out float z,
            out float w
        );

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaS_pushVector2(IntPtr l, float x, float y);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaS_pushVector3(IntPtr l, float x, float y, float z);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaS_pushVector4(IntPtr l, float x, float y, float z, float w);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaS_pushQuaternion(IntPtr l, float x, float y, float z, float w);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaS_pushColor(IntPtr l, float x, float y, float z, float w);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaS_setDataVec(
            IntPtr l,
            int p,
            float x,
            float y,
            float z,
            float w
        );

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaS_checkluatype(IntPtr l, int p, string t);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaS_pushobject(IntPtr l, int index, string t, bool gco, int cref);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaS_getcacheud(IntPtr l, int index, int cref);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaS_subclassof(IntPtr l, int index, string t);
    }
}
