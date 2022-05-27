/*
The MIT License (MIT)

Copyright (c) 2015-2016 topameng(topameng@qq.com)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#pragma warning(disable : 4996)
#include <string.h>
#include <stdbool.h>
#include <math.h>
#include <stdint.h>
#include <inttypes.h>
#include <stdlib.h>
#include <errno.h>
#include <ctype.h>

#include "lua.h"
#include "lualib.h"
#include "lauxlib.h"
#include "tolua.h"

static bool _isint64(lua_State* L, int pos)
{
    if (lua_getmetatable(L, pos))
    {            
        lua_getref(L, LUA_RIDX_INT64); 
        int equal = lua_rawequal(L, -1, -2);
        lua_pop(L, 2);  
        return equal;
    }
    
    return false;
}

bool _str2long(const char *s, int64_t* result) 
{
    char *endptr;
    *result = strtoll(s, &endptr, 10);

    if (endptr == s)
    {
        return false;  
    }

    if (*endptr == 'x' || *endptr == 'X')
    {
        *result = (int64_t)strtoull(s, &endptr, 16);
    }

    if (*endptr == '\0') 
    {
        return true;
    }

    while (isspace((unsigned char)*endptr)) endptr++;  
    return *endptr == '\0';
}

LUALIB_API bool tolua_isint64(lua_State* L, int pos)
{
    int64_t num;

    if (lua_type(L, pos) == LUA_TNUMBER)
    {
        return true;
    }
    else if (lua_type(L, pos) == LUA_TSTRING && _str2long(lua_tostring(L, pos), &num))
    {
        return true;
    }

    return _isint64(L, pos);
}

LUALIB_API void tolua_pushint64(lua_State* L, int64_t n)
{
    /*if (toluaflags & FLAG_INT64)    
    {
        lua_pushinteger(L, (lua_Integer)n);
    }
    else
    {*/
        int64_t* p = (int64_t*)lua_newuserdata(L, sizeof(int64_t));
        *p = n;
        lua_getref(L, LUA_RIDX_INT64);
        lua_setmetatable(L, -2);            
    //}
}

//转换一个字符串为 int64
static int64_t _long(lua_State* L, int pos)
{
    int64_t n = 0;
    int old = errno;   
    errno = 0;
    const char* str = lua_tostring(L, pos);

    if (!_str2long(str, &n))
    {
        luaL_typerror(L, pos, "long");
    }

    if (errno == ERANGE)
    {
        errno = old;
        return luaL_error(L, "integral is too large: %s", str);
    }  

    errno = old;
    return n;
}

LUALIB_API int64_t tolua_toint64(lua_State* L, int pos)
{
    int64_t n = 0;
    int type = lua_type(L, pos);

    switch(type) 
    {
        case LUA_TNUMBER:         
            n = (int64_t)lua_tonumber(L, pos);        
            break;    
        case LUA_TSTRING: 
            if (!_str2long(lua_tostring(L, pos), &n))
            {
                n = 0;
            }
            break;
        case LUA_TUSERDATA:     
            if (_isint64(L, pos))
            {
                n = *(int64_t*)lua_touserdata(L, pos);            
            }
            break;    
        default:        
            break;
    }

    return n;
}

static int64_t tolua_checkint64(lua_State* L, int pos)
{
    int64_t n = 0;
    int type = lua_type(L, pos);
    
    switch(type)
    {
        case LUA_TNUMBER:
            n = (int64_t)lua_tonumber(L, pos);
            break;
        case LUA_TSTRING:
            n = _long(L, pos);
            break;
        case LUA_TUSERDATA:
            if (_isint64(L, pos))
            {
                n = *(int64_t*)lua_touserdata(L, pos);
            }
            break;
        default:
            return luaL_typerror(L, pos, "long");
    }
    
    return n;
}

static int _int64add(lua_State* L)
{
    int64_t lhs = tolua_checkint64(L, 1);    
    int64_t rhs = tolua_checkint64(L, 2);
    tolua_pushint64(L, lhs + rhs);
    return 1;
}

static int _int64sub(lua_State* L)
{
    int64_t lhs = tolua_checkint64(L, 1);    
    int64_t rhs = tolua_checkint64(L, 2);
    tolua_pushint64(L, lhs - rhs);
    return 1;
}


static int _int64mul(lua_State* L)
{
    int64_t lhs = tolua_checkint64(L, 1);    
    int64_t rhs = tolua_checkint64(L, 2);
    tolua_pushint64(L, lhs * rhs);
    return 1;    
}

static int _int64div(lua_State* L)
{
    int64_t lhs = tolua_checkint64(L, 1);    
    int64_t rhs = tolua_checkint64(L, 2);

    if (rhs == 0) 
    {
        return luaL_error(L, "div by zero");
    }

    tolua_pushint64(L, lhs / rhs);
    return 1;
}

static int _int64mod(lua_State* L)
{
    int64_t lhs = tolua_checkint64(L, 1);    
    int64_t rhs = tolua_checkint64(L, 2);

    if (rhs == 0) 
    {
        return luaL_error(L, "mod by zero");
    }

    tolua_pushint64(L, lhs % rhs);
    return 1;
}

static int _int64unm(lua_State* L)
{
    int64_t lhs = *(int64_t*)lua_touserdata(L, 1);        
    tolua_pushint64(L, -lhs);
    return 1;
}

static int _int64pow(lua_State* L)
{
    int64_t lhs = tolua_checkint64(L, 1);    
    int64_t rhs = tolua_checkint64(L, 2);
    int64_t ret;
    
    if (rhs > 0)
    {
        ret = pow(lhs, rhs);
    }
    else if (rhs == 0)
    {
        ret = 1;
    }
    else
    {   
        char temp[64];
        sprintf(temp, "%" PRId64, rhs);    
        return luaL_error(L, "pow by nagtive number: %s", temp);                 
    }

    tolua_pushint64(L, ret);
    return 1;
}

static int _int64eq(lua_State* L)
{
    int64_t lhs = *(int64_t*)lua_touserdata(L, 1);     
    int64_t rhs = *(int64_t*)lua_touserdata(L, 2);     
    lua_pushboolean(L, lhs == rhs);    
    return 1;
}

static int _int64equals(lua_State* L)
{
    int64_t lhs = tolua_checkint64(L, 1);
    int64_t rhs = tolua_toint64(L, 2);
    lua_pushboolean(L, lhs == rhs);
    return 1;
}

static int _int64lt(lua_State* L)
{
    int64_t lhs = tolua_checkint64(L, 1); 
    int64_t rhs = tolua_checkint64(L, 2);
    lua_pushboolean(L, lhs < rhs);
    return 1;
}

static int _int64le(lua_State* L)
{
    int64_t lhs = tolua_checkint64(L, 1); 
    int64_t rhs = tolua_checkint64(L, 2);
    lua_pushboolean(L, lhs <= rhs);
    return 1;
}

static int _int64tostring(lua_State* L)
{    
    if (!tolua_isint64(L, 1))
    {
        return luaL_typerror(L, 1, "long");
    }

    int64_t n = tolua_toint64(L, 1);    
    char temp[64];
    sprintf(temp, "%" PRId64, n);    
    lua_pushstring(L, temp);
    return 1;
}

static int _int64tonum2(lua_State* L)
{
    if (!tolua_isint64(L, 1))
    {
        return luaL_typerror(L, 1, "long");
    }

    int64_t n = tolua_toint64(L, 1);

    //作为无符号数拆分
    if (n != 0)
    {
        uint32_t high = n >> 32;        
        uint32_t low = n & 0xFFFFFFFF;
        lua_pushnumber(L, low);
        lua_pushnumber(L, high);
    }
    else
    {
        lua_pushnumber(L, 0);
        lua_pushnumber(L, 0);
    }

    return 2;
}

int tolua_newint64(lua_State* L)
{
    int64_t n = 0;
    int type = lua_type(L, 1);

    if (type == LUA_TSTRING)
    {        
        n = _long(L, 1);                  
    }
    else if (type == LUA_TNUMBER)
    {
        int64_t n1 = (int64_t)luaL_checknumber(L, 1);
        int64_t n2 = (int64_t)lua_tonumber(L, 2);

        if (n1 < 0 || n1 > UINT_MAX)
        {
            return luaL_error(L, "#1 out of range: %" PRId64, n1);
        }

        if (n2 < 0 || n2 > UINT_MAX)
        {
            return luaL_error(L, "#2 out of range: %" PRId64, n2);
        }

        n = n1 + (n2 << 32);
    }

    tolua_pushint64(L, n);
    return 1;
}


void tolua_openint64(lua_State* L)
{        
    lua_newtable(L);      
    lua_pushvalue(L, -1);
    lua_setglobal(L, "int64");

    lua_getref(L, LUA_RIDX_LOADED);
    lua_pushstring(L, "int64");
    lua_pushvalue(L, -3);
    lua_rawset(L, -3);
    lua_pop(L, 1);

    lua_pushstring(L, "__add"),
    lua_pushcfunction(L, _int64add);
    lua_rawset(L, -3);

    lua_pushstring(L, "__sub"),
    lua_pushcfunction(L, _int64sub);
    lua_rawset(L, -3);

    lua_pushstring(L, "__mul"),
    lua_pushcfunction(L, _int64mul);
    lua_rawset(L, -3);

    lua_pushstring(L, "__div"),
    lua_pushcfunction(L, _int64div);
    lua_rawset(L, -3);

    lua_pushstring(L, "__mod"),
    lua_pushcfunction(L, _int64mod);
    lua_rawset(L, -3);

    lua_pushstring(L, "__unm"),
    lua_pushcfunction(L, _int64unm);
    lua_rawset(L, -3);

    lua_pushstring(L, "__pow"),
    lua_pushcfunction(L, _int64pow);
    lua_rawset(L, -3);    

    lua_pushstring(L, "__tostring");
    lua_pushcfunction(L, _int64tostring);
    lua_rawset(L, -3);      

    lua_pushstring(L, "tostring");
    lua_pushcfunction(L, _int64tostring);
    lua_rawset(L, -3);     

    lua_pushstring(L, "__eq");
    lua_pushcfunction(L, _int64eq);
    lua_rawset(L, -3);  

    lua_pushstring(L, "__lt");
    lua_pushcfunction(L, _int64lt);
    lua_rawset(L, -3); 

    lua_pushstring(L, "__le");
    lua_pushcfunction(L, _int64le);
    lua_rawset(L, -3);     

    lua_pushstring(L, ".name");
    lua_pushstring(L, "int64");
    lua_rawset(L, -3);

    lua_pushstring(L, "new");
    lua_pushcfunction(L, tolua_newint64);
    lua_rawset(L, -3);       

    lua_pushstring(L, "equals");
    lua_pushcfunction(L, _int64equals);
    lua_rawset(L, -3);     

    lua_pushstring(L, "tonum2");
    lua_pushcfunction(L, _int64tonum2);
    lua_rawset(L, -3);        

    lua_pushstring(L, "__index");
    lua_pushvalue(L, -2);
    lua_rawset(L, -3);    

    lua_rawseti(L, LUA_REGISTRYINDEX, LUA_RIDX_INT64);     
}