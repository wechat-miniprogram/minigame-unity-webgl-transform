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
    using System.Runtime.InteropServices;
    using System.Reflection;
    using System.Collections;
    using System.Text;
    using System.Security;



    /**     Modify Record:
     
    lua_xmove：        return void
    //lua_gc：           LuaDLLWrapper： enum->int。 
      
    lua_objlen：　　   lua 5.1：  luaS_objlen　size_t->int
    lua_rawlen:        lua 5.3：  luaS_rawlen　size_t->int
     
    lua_setmetatable： lua 5.1 return int
                       lua 5.3 return void
     
    //lua_type：         LuaDLLWrapper：  return int->enum
    lua_isnumber：　   LuaDLLWrapper：　return bool->int  
    lua_isstring:      LuaDLLWrapper：　return bool->int
    lua_iscfunction:   LuaDLLWrapper：　return bool->int
 
    lua_call:          5.1 return int->void
     
    lua_toboolean:     LuaDLLWrapper：   return bool->int
     
    lua_atpanic:       return void->intptr 
     
    lua_pushboolean:   LuaDLLWrapper： bool ->int
    lua_pushlstring:   LuaDLLWrapper: luaS_pushlstring. size_t->int

    luaL_getmetafield:  LuaDLLWrapper: return bool->int
    luaL_loadbuffe:     LuaDLLWrapper  luaLS_loadbuffer  size_t  CharSet
     
    lua_error:         return void->int
    lua_checkstack：　　LuaDLLWrapper　return bool->int


    **/

    public class LuaDLLWrapper
    {

#if (UNITY_IPHONE || UNITY_WEBGL) && !UNITY_EDITOR
	const string LUADLL = "__Internal";
#else
        const string LUADLL = "slua";
#endif

#if LUA_5_3
        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaS_rawlen(IntPtr luaState, int index);
#else
		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaS_objlen(IntPtr luaState, int stackPos);
#endif


        //[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        //public static extern int lua_gc(IntPtr luaState, int what, int data);

        //[DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
        //public static extern int lua_type(IntPtr luaState, int index);

        [DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern int lua_isnumber(IntPtr luaState, int index);


        [DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern int lua_isstring(IntPtr luaState, int index);

        [DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern int lua_iscfunction(IntPtr luaState, int index);

        [DllImport(LUADLL,CallingConvention=CallingConvention.Cdecl)]
		public static extern int lua_toboolean(IntPtr luaState, int index);


        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void lua_pushboolean(IntPtr luaState, int value);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void luaS_pushlstring(IntPtr luaState, byte[] str, int size);


        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaL_getmetafield(IntPtr luaState, int stackPos, string field);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaLS_loadbuffer(IntPtr luaState, byte[] buff, int size, string name);

        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lua_checkstack(IntPtr luaState, int extra);
    }


}
