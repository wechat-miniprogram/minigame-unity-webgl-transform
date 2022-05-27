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

static bool _isuint64(lua_State *L, int pos)
{
    if (lua_getmetatable(L, pos))
    {            
        lua_getref(L, LUA_RIDX_UINT64); 
        int equal = lua_rawequal(L, -1, -2);
        lua_pop(L, 2);  
        return equal;
    }
    
    return false;
}

bool _str2ulong(const char *s, uint64_t* result) 
{
    char *endptr;
    *result = strtoull(s, &endptr, 10);

    if (endptr == s)
    {
        return false;  
    }

    if (*endptr == 'x' || *endptr == 'X')
    {
        *result = strtoull(s, &endptr, 16);
    }

    if (*endptr == '\0') 
    {
        return true;
    }

    while (isspace((unsigned char)*endptr)) endptr++;  
    return *endptr == '\0';
}

LUALIB_API bool tolua_isuint64(lua_State *L, int pos)
{
    uint64_t num = 0;

    if (lua_type(L, pos) == LUA_TNUMBER)
    {
        return true;
    }
    else if (lua_type(L, pos) == LUA_TSTRING && _str2ulong(lua_tostring(L, pos), &num))
    {
        return true;
    }

    return _isuint64(L, pos);
}

LUALIB_API void tolua_pushuint64(lua_State *L, uint64_t n)
{
    uint64_t* p = (uint64_t*)lua_newuserdata(L, sizeof(uint64_t));
    *p = n;
    lua_getref(L, LUA_RIDX_UINT64);
    lua_setmetatable(L, -2);                
}

//转换一个字符串为 uint64
static uint64_t _ulong(lua_State *L, int pos)
{
    uint64_t n = 0;
    int old = errno;   
    errno = 0;
    const char *str = lua_tostring(L, pos);

    if (!_str2ulong(str, &n))
    {
        luaL_typerror(L, pos, "ulong");
    }

    if (errno == ERANGE)
    {
        errno = old;
        return luaL_error(L, "integral is too large: %s", str);
    }  

    errno = old;
    return n;
}

LUALIB_API uint64_t tolua_touint64(lua_State *L, int pos)
{
    uint64_t n = 0;
    int type = lua_type(L, pos);

    switch(type) 
    {
        case LUA_TNUMBER:         
            n = (uint64_t)lua_tonumber(L, pos);        
            break;    
        case LUA_TSTRING: 
            if (!_str2ulong(lua_tostring(L, pos), &n))
            {
                n = 0;
            }            
            break;
        case LUA_TUSERDATA:     
            if (_isuint64(L, pos))
            {
                n = *(uint64_t*)lua_touserdata(L, pos);            
            }
            break;    
        default:        
            break;
    }

    return n;
}

static uint64_t tolua_checkuint64(lua_State *L, int pos)
{
    uint64_t n = 0;
    int type = lua_type(L, pos);
    
    switch(type)
    {
        case LUA_TNUMBER:
            n = (uint64_t)lua_tonumber(L, pos);
            break;
        case LUA_TSTRING:
            n = _ulong(L, pos);
            break;
        case LUA_TUSERDATA:
            if (_isuint64(L, pos))
            {
                n = *(uint64_t*)lua_touserdata(L, pos);
            }
            break;
        default:
            return luaL_typerror(L, pos, "ulong");
    }
    
    return n;
}

static int _uint64add(lua_State *L)
{
    uint64_t lhs = tolua_checkuint64(L, 1);    
    uint64_t rhs = tolua_checkuint64(L, 2);
    tolua_pushuint64(L, lhs + rhs);
    return 1;
}

static int _uint64sub(lua_State *L)
{
    uint64_t lhs = tolua_checkuint64(L, 1);    
    uint64_t rhs = tolua_checkuint64(L, 2);

    if (lhs > rhs)
    {
        tolua_pushuint64(L, lhs - rhs);
    }
    else
    {
        tolua_pushint64(L, lhs - rhs);
    }
    return 1;
}

static int _uint64mul(lua_State *L)
{
    uint64_t lhs = tolua_checkuint64(L, 1);    
    uint64_t rhs = tolua_checkuint64(L, 2);
    tolua_pushuint64(L, lhs * rhs);
    return 1;    
}

static int _uint64div(lua_State *L)
{
    uint64_t lhs = tolua_checkuint64(L, 1);    
    uint64_t rhs = tolua_checkuint64(L, 2);

    if (rhs == 0) 
    {
        return luaL_error(L, "div by zero");
    }

    tolua_pushuint64(L, lhs / rhs);
    return 1;
}

static int _uint64mod(lua_State *L)
{
    uint64_t lhs = tolua_checkuint64(L, 1);    
    uint64_t rhs = tolua_checkuint64(L, 2);

    if (rhs == 0) 
    {
        return luaL_error(L, "mod by zero");
    }

    tolua_pushuint64(L, lhs % rhs);
    return 1;
}

static int _uint64unm(lua_State *L)
{
    uint64_t lhs = *(uint64_t*)lua_touserdata(L, 1);        
    tolua_pushuint64(L, lhs);
    return 1;
}

static int _uint64pow(lua_State *L)
{
    uint64_t lhs = tolua_checkuint64(L, 1);    
    uint64_t rhs = tolua_checkuint64(L, 2);
    uint64_t ret;
    
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
        sprintf(temp, "%" PRIu64, rhs);    
        return luaL_error(L, "pow by nagtive number: %s", temp);   
    }

    tolua_pushuint64(L, ret);
    return 1;
}

static int _uint64eq(lua_State *L)
{
    uint64_t lhs = *(uint64_t*)lua_touserdata(L, 1);     
    uint64_t rhs = *(uint64_t*)lua_touserdata(L, 2);     
    lua_pushboolean(L, lhs == rhs);    
    return 1;
}

static int _uint64equals(lua_State *L)
{
    uint64_t lhs = tolua_checkuint64(L, 1);
    uint64_t rhs = tolua_touint64(L, 2);
    lua_pushboolean(L, lhs == rhs);
    return 1;
}

static int _uint64lt(lua_State *L)
{
    uint64_t lhs = tolua_checkuint64(L, 1); 
    uint64_t rhs = tolua_checkuint64(L, 2);
    lua_pushboolean(L, lhs < rhs);
    return 1;
}

static int _uint64le(lua_State *L)
{
    uint64_t lhs = tolua_checkuint64(L, 1); 
    uint64_t rhs = tolua_checkuint64(L, 2);
    lua_pushboolean(L, lhs <= rhs);
    return 1;
}

static int _uint64tostring(lua_State *L)
{    
    if (!tolua_isuint64(L, 1))
    {
        return luaL_typerror(L, 1, "ulong");
    }

    uint64_t n = tolua_touint64(L, 1);    
    char temp[64];
    sprintf(temp, "%" PRIu64, n);    
    lua_pushstring(L, temp);
    return 1;
}

static int _uint64tonum2(lua_State *L)
{
    if (!tolua_isuint64(L, 1))
    {
        return luaL_typerror(L, 1, "ulong");
    }

    uint64_t n = tolua_touint64(L, 1);

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

int tolua_newuint64(lua_State *L)
{
    uint64_t n = 0;
    int type = lua_type(L, 1);

    if (type == LUA_TSTRING)
    {        
        n = _ulong(L, 1);                  
    }
    else if (type == LUA_TNUMBER)
    {
        uint64_t n1 = (uint64_t)luaL_checknumber(L, 1);
        uint64_t n2 = (uint64_t)lua_tonumber(L, 2);

        if (n1 < 0 || n1 > UINT_MAX)
        {
            return luaL_error(L, "#1 out of range: %" PRIu64, n1);
        }

        if (n2 < 0 || n2 > UINT_MAX)
        {
            return luaL_error(L, "#2 out of range: %" PRIu64, n2);
        }

        n = n1 + (n2 << 32);
    }

    tolua_pushuint64(L, n);
    return 1;
}


void tolua_openuint64(lua_State *L)
{        
    lua_newtable(L);      
    lua_pushvalue(L, -1);
    lua_setglobal(L, "uint64");

    lua_getref(L, LUA_RIDX_LOADED);
    lua_pushstring(L, "uint64");
    lua_pushvalue(L, -3);
    lua_rawset(L, -3);
    lua_pop(L, 1);

    lua_pushstring(L, "__add"),
    lua_pushcfunction(L, _uint64add);
    lua_rawset(L, -3);

    lua_pushstring(L, "__sub"),
    lua_pushcfunction(L, _uint64sub);
    lua_rawset(L, -3);

    lua_pushstring(L, "__mul"),
    lua_pushcfunction(L, _uint64mul);
    lua_rawset(L, -3);

    lua_pushstring(L, "__div"),
    lua_pushcfunction(L, _uint64div);
    lua_rawset(L, -3);

    lua_pushstring(L, "__mod"),
    lua_pushcfunction(L, _uint64mod);
    lua_rawset(L, -3);

    lua_pushstring(L, "__unm"),
    lua_pushcfunction(L, _uint64unm);
    lua_rawset(L, -3);

    lua_pushstring(L, "__pow"),
    lua_pushcfunction(L, _uint64pow);
    lua_rawset(L, -3);    

    lua_pushstring(L, "__tostring");
    lua_pushcfunction(L, _uint64tostring);
    lua_rawset(L, -3);      

    lua_pushstring(L, "tostring");
    lua_pushcfunction(L, _uint64tostring);
    lua_rawset(L, -3);     

    lua_pushstring(L, "__eq");
    lua_pushcfunction(L, _uint64eq);
    lua_rawset(L, -3);  

    lua_pushstring(L, "__lt");
    lua_pushcfunction(L, _uint64lt);
    lua_rawset(L, -3); 

    lua_pushstring(L, "__le");
    lua_pushcfunction(L, _uint64le);
    lua_rawset(L, -3);     

    lua_pushstring(L, ".name");
    lua_pushstring(L, "uint64");
    lua_rawset(L, -3);

    lua_pushstring(L, "new");
    lua_pushcfunction(L, tolua_newuint64);
    lua_rawset(L, -3);       

    lua_pushstring(L, "equals");
    lua_pushcfunction(L, _uint64equals);
    lua_rawset(L, -3);     

    lua_pushstring(L, "tonum2");
    lua_pushcfunction(L, _uint64tonum2);
    lua_rawset(L, -3);        

    lua_pushstring(L, "__index");
    lua_pushvalue(L, -2);
    lua_rawset(L, -3);    

    lua_rawseti(L, LUA_REGISTRYINDEX, LUA_RIDX_UINT64);     
}