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
#if !defined __APPLE__
#include <malloc.h>
#endif
#include <stdbool.h>
#include <math.h>
#include <stdint.h>
#include <stdlib.h>

#include "lua.h"
#include "lualib.h"
#include "lauxlib.h"
#include "tolua.h"

#ifdef _WIN32
#include <windows.h>
#else
#include <time.h>
#include <sys/time.h>
#endif

int toluaflags = FLAG_INDEX_ERROR;
static int tag = 0;  
static int gettag = 0;
static int settag = 0;
static int vptr = 1;

/*---------------------------tolua extend functions--------------------------------*/
LUALIB_API void* tolua_tag()
{
	return &tag;
}

LUALIB_API void tolua_newudata(lua_State *L, int val)
{
	int* pointer = (int*)lua_newuserdata(L, sizeof(int));    
    lua_pushvalue(L, TOLUA_NOPEER);            
    lua_setfenv(L, -2);                        
	*pointer = val;
}

LUALIB_API int tolua_rawnetobj(lua_State *L, int index)
{
    int* udata = (int*)lua_touserdata(L, index);
    
    if (udata != NULL) 
    {
        return *udata;
    }
    else if (lua_istable(L, index))
    {
        lua_pushvalue(L, index);        
        lua_pushlightuserdata(L, &vptr);
        lua_rawget(L, -2);                

        if (lua_isuserdata(L, -1))
        {
            lua_replace(L, index);
            udata = (int*)lua_touserdata(L, index);

            if (udata != NULL) 
            {
                return *udata;
            }
        }    
        else
        {
            lua_pop(L, 1);
        }               
    }    

	return -1;
}

LUALIB_API char* tolua_tocbuffer(const char *csBuffer, int sz)
{
	char* buffer = (char*)malloc(sz+1);
	memcpy(buffer, csBuffer, sz);	
	buffer[sz] = '\0';
	return buffer;
}

LUALIB_API void tolua_freebuffer(void* buffer)
{
  free(buffer);
}

LUALIB_API void tolua_getvec2(lua_State *L, int pos, float* x, float* y)
{
	lua_getref(L, LUA_RIDX_UNPACKVEC2);
	lua_pushvalue(L, pos);
	lua_call(L, 1, 2);
	*x = (float)lua_tonumber(L, -2);
	*y = (float)lua_tonumber(L, -1);
	lua_pop(L, 2);
}

LUALIB_API void tolua_getvec3(lua_State *L, int pos, float* x, float* y, float* z)
{
	lua_getref(L, LUA_RIDX_UNPACKVEC3);
	lua_pushvalue(L, pos);
	lua_call(L, 1, 3);
    *x = (float)lua_tonumber(L, -3);
    *y = (float)lua_tonumber(L, -2);
    *z = (float)lua_tonumber(L, -1);
    lua_pop(L, 3);
}

LUALIB_API void tolua_getvec4(lua_State *L, int pos, float* x, float* y, float* z, float* w)
{
	lua_getref(L, LUA_RIDX_UNPACKVEC4);
	lua_pushvalue(L, pos);
	lua_call(L, 1, 4);
	*x = (float)lua_tonumber(L, -4);
	*y = (float)lua_tonumber(L, -3);
	*z = (float)lua_tonumber(L, -2);
	*w = (float)lua_tonumber(L, -1);
	lua_pop(L, 4);
}

LUALIB_API void tolua_getquat(lua_State *L, int pos, float* x, float* y, float* z, float* w)
{
	lua_getref(L, LUA_RIDX_UNPACKQUAT);
	lua_pushvalue(L, pos);
	lua_call(L, 1, 4);
	*x = (float)lua_tonumber(L, -4);
	*y = (float)lua_tonumber(L, -3);
	*z = (float)lua_tonumber(L, -2);
	*w = (float)lua_tonumber(L, -1);
	lua_pop(L, 4);
}

LUALIB_API void tolua_getclr(lua_State *L, int pos, float* r, float* g, float* b, float* a)
{
	lua_getref(L, LUA_RIDX_UNPACKCLR);
	lua_pushvalue(L, pos);
	lua_call(L, 1, 4);
	*r = (float)lua_tonumber(L, -4);
	*g = (float)lua_tonumber(L, -3);
	*b = (float)lua_tonumber(L, -2);
	*a = (float)lua_tonumber(L, -1);
	lua_pop(L, 4);
}

LUALIB_API int tolua_getlayermask(lua_State *L, int pos)
{
    if (lua_isnumber(L, pos))
    {
        return (int)lua_tointeger(L, pos);
    }

    lua_getref(L, LUA_RIDX_UNPACKLAYERMASK);
    lua_pushvalue(L, pos);
    lua_call(L, 1, 1);
    int mask = (int)lua_tointeger(L, -1);
    lua_pop(L, 1);
    return mask;
}

LUALIB_API void tolua_pushvec2(lua_State *L, float x, float y)
{
	lua_getref(L, LUA_RIDX_PACKVEC2);
	lua_pushnumber(L, x);
	lua_pushnumber(L, y);
	lua_call(L, 2, 1);
}

LUALIB_API void tolua_pushvec3(lua_State *L, float x, float y, float z)
{
	lua_getref(L, LUA_RIDX_PACKVEC3);
	lua_pushnumber(L, x);
	lua_pushnumber(L, y);
	lua_pushnumber(L, z);
	lua_call(L, 3, 1);
}

LUALIB_API void tolua_pushvec4(lua_State *L, float x, float y, float z, float w)
{
	lua_getref(L, LUA_RIDX_PACKVEC4);
	lua_pushnumber(L, x);
	lua_pushnumber(L, y);
	lua_pushnumber(L, z);
	lua_pushnumber(L, w);
	lua_call(L, 4, 1);
}

LUALIB_API void tolua_pushquat(lua_State *L, float x, float y, float z, float w)
{
	lua_getref(L, LUA_RIDX_PACKQUAT);
	lua_pushnumber(L, x);
	lua_pushnumber(L, y);
	lua_pushnumber(L, z);
	lua_pushnumber(L, w);
	lua_call(L, 4, 1);
}

LUALIB_API void tolua_pushclr(lua_State *L, float r, float g, float b, float a)
{
	lua_getref(L, LUA_RIDX_PACKCLR);
	lua_pushnumber(L, r);
	lua_pushnumber(L, g);
	lua_pushnumber(L, b);
	lua_pushnumber(L, a);
	lua_call(L, 4, 1);
}

LUALIB_API void tolua_pushlayermask(lua_State *L, int mask)
{
    lua_getref(L, LUA_RIDX_PACKLAYERMASK);
    lua_pushnumber(L, mask);
    lua_call(L, 1, 1);
}


LUA_API const char* tolua_tolstring(lua_State *L, int index, int* len) 
{
    size_t sz;
    const char *ret = lua_tolstring(L, index, &sz);
    *len = (int)sz;
    return ret;
}

LUA_API void tolua_pushlstring(lua_State *L, const char *s, int l)
{
    lua_pushlstring(L, s, (size_t)l);
}

LUA_API void* tolua_newuserdata(lua_State *L, int sz)
{
    return lua_newuserdata(L, (size_t)sz);    
}

LUA_API int tolua_objlen(lua_State *L, int idx)
{
    size_t len = lua_objlen(L, idx);
    return (int)len;
}

LUA_API bool tolua_toboolean(lua_State *L, int idx) 
{
    int value = lua_toboolean(L, idx);
    return value == 0 ? false : true;
}

LUA_API int32_t tolua_tointeger(lua_State *L, int idx) 
{
    return (int32_t)lua_tointeger(L, idx);
}

LUALIB_API int tolua_loadbuffer(lua_State *L, const char *buff, int sz, const char *name)
{
    return luaL_loadbuffer(L, buff, (size_t)sz, name);
}

static int _lua_getfield(lua_State *L)
{
    const char *name = lua_tostring(L, 2);    
    lua_getfield(L, 1, name);    
    return 1;
}
        
LUA_API int tolua_getfield(lua_State *L, int idx, const char *field)
{
    idx = abs_index(L, idx);    
    lua_pushcfunction(L, _lua_getfield);
    lua_pushvalue(L, idx);
    lua_pushstring(L, field);
    return lua_pcall(L, 2, 1, 0);
}

static int _lua_setfield(lua_State *L)
{
    const char *name = lua_tostring(L, 2);
    lua_setfield(L, 1, name);
    return 0;
}

LUA_API int tolua_setfield(lua_State *L, int idx, const char *key)        
{
    int top = lua_gettop(L);
    idx = abs_index(L, idx);
    lua_pushcfunction(L, _lua_setfield);
    lua_pushvalue(L, idx);
    lua_pushstring(L, key);
    lua_pushvalue(L, top);
    lua_remove(L, top);
    return lua_pcall(L, 3, -1, 0);
}

static int _lua_gettable(lua_State *L)
{    
    lua_gettable(L, 1);    
    return 1;
}

LUA_API int tolua_gettable(lua_State *L, int idx)
{
    int top = lua_gettop(L);
    idx = abs_index(L, idx);
    lua_pushcfunction(L, _lua_gettable);
    lua_pushvalue(L, idx);
    lua_pushvalue(L, top);
    lua_remove(L, top);
    return lua_pcall(L, 2, -1, 0);
}

static int _lua_settable(lua_State *L)
{
    lua_settable(L, 1);
    return 0;
}

LUA_API int tolua_settable(lua_State *L, int idx)
{
    int top = lua_gettop(L);
    idx = abs_index(L, idx);
    lua_pushcfunction(L, _lua_settable);
    lua_pushvalue(L, idx);
    lua_pushvalue(L, top - 1);
    lua_pushvalue(L, top);
    lua_remove(L, top);
    lua_remove(L, top - 1);
    return lua_pcall(L, 3, -1, 0);
}

static int tolua_closure(lua_State *L)
{
    lua_CFunction fn = (lua_CFunction)lua_tocfunction(L, lua_upvalueindex(2));
    int r = fn(L);    
    
    if (lua_toboolean(L, lua_upvalueindex(1)))
    {
        lua_pushboolean(L, 0);
        lua_replace(L, lua_upvalueindex(1));
        return lua_error(L);
    }
    
    return r;
}

//hack for luac, 避免luac error破坏包裹c#函数的异常块(luajit采用的是类似c++异常)
LUA_API int tolua_pushcfunction(lua_State *L, lua_CFunction fn)
{        
    lua_pushboolean(L, 0);
    lua_pushcfunction(L, fn);
    lua_pushcclosure(L, tolua_closure, 2);
    return 0;
}

static int tolua_pusherror(lua_State *L, const char *fmt, ...)
{
    va_list argp;
    va_start(argp, fmt);
    luaL_where(L, 1);
    lua_pushvfstring(L, fmt, argp);
    va_end(argp);
    lua_concat(L, 2);
    return 1;
}

LUALIB_API int tolua_argerror(lua_State *L, int narg, const char *extramsg)
{
    lua_Debug ar;
    
    if (!lua_getstack(L, 0, &ar))  /* no stack frame? */
    {
        return tolua_pusherror(L, "bad argument #%d (%s)", narg, extramsg);        
    }

    lua_getinfo(L, "n", &ar);

    if (strcmp(ar.namewhat, "method") == 0) 
    {
        narg--;  /* do not count `self' */

        if (narg == 0)  /* error is in the self argument itself? */
        {
            return tolua_pusherror(L, "calling " LUA_QS " on bad self (%s)", ar.name, extramsg);
        }
    }

    if (ar.name == NULL)
    {
        ar.name = "?";
    }    

    return tolua_pusherror(L, "bad argument #%d to " LUA_QS " (%s)", narg, ar.name, extramsg);
}

LUALIB_API int tolua_error(lua_State *L, const char *msg)
{
    lua_pushboolean(L, 1);
    lua_replace(L, lua_upvalueindex(1));
    lua_pushstring(L, msg);
    return 1;
}

LUALIB_API int tolua_getn(lua_State *L, int i)
{
    return tolua_objlen(L, i);
}

LUALIB_API int tolua_strlen(const char *str)
{
    if (str == NULL)
    {
        return 0;
    }

    int len = (int)strlen(str);
    return len;
}

static bool _preload(lua_State *L)
{    
    lua_settop(L, 2); 
    lua_getmetatable(L, 1);
    lua_pushstring(L, ".name");             //stack: t key mt ".name"
    lua_rawget(L, -2);                      //stack: t key mt space

    if (!lua_isnil(L, -1))                  //stack: t key mt space
    {                      
        lua_getref(L, LUA_RIDX_PRELOAD);    //stack: t key mt space preload
        lua_pushvalue(L, -2);               //stack: t key mt space preload space
        lua_pushstring(L, ".");             //stack: t key mt space preload space.
        lua_pushvalue(L, 2);                //stack: t key mt space preload space.key
        lua_concat(L, 3);                   //stack: t key mt space preload key1
        lua_pushvalue(L, -1);               //stack: t key mt space preload key1 key1
        lua_rawget(L, -3);                  //stack: t key mt space preload key1 value

        if (!lua_isnil(L, -1)) 
        {      
            lua_pop(L, 1);                      //stack: t key mt space preload key1
            lua_getref(L, LUA_RIDX_REQUIRE);    //stack: t key mt space preload key1 require
            lua_pushvalue(L, -2);
            lua_call(L, 1, 1);                         
            return true;
        }        
    }

    lua_settop(L, 2); 
    return false;
}

static int class_index_event(lua_State *L)
{
	int t = lua_type(L, 1);

    if (t == LUA_TUSERDATA)
    {    	
        lua_getfenv(L,1);

        if (!lua_rawequal(L, -1, TOLUA_NOPEER))     // stack: t k env
        {
            while (lua_istable(L, -1))                       // stack: t k v mt 
            {      
                lua_pushvalue(L, 2); 
                lua_rawget(L, -2);
            
                if (!lua_isnil(L, -1))
                {                    
                    return 1;
                }

                lua_pop(L, 1);
                lua_pushlightuserdata(L, &gettag);          
                lua_rawget(L, -2);                      //stack: obj key env tget
            
                if (lua_istable(L, -1))
                {                    
                    lua_pushvalue(L, 2);                //stack: obj key env tget key
                    lua_rawget(L, -2);                  //stack: obj key env tget func 

                    if (lua_isfunction(L, -1))
                    {                        
                        lua_pushvalue(L, 1);
                        lua_call(L, 1, 1);
                        return 1;
                    }    

                    lua_pop(L, 1);                 
                }

                lua_pop(L, 1); 

                if (lua_getmetatable(L, -1) == 0)               // stack: t k v mt mt
                {
                    lua_pushnil(L);
                }

                lua_remove(L, -2);                              // stack: t k v mt
            }        
        };

        lua_settop(L,2);                                        				
    	lua_pushvalue(L, 1);						// stack: obj key obj	

    	while (lua_getmetatable(L, -1) != 0)
    	{        	
        	lua_remove(L, -2);						// stack: obj key mt

			if (lua_isnumber(L,2))                 	// check if key is a numeric value
			{		    
		    	lua_pushstring(L,".geti");
		    	lua_rawget(L,-2);                   // stack: obj key mt func

		    	if (lua_isfunction(L,-1))
		    	{
		        	lua_pushvalue(L,1);
		        	lua_pushvalue(L,2);
		        	lua_call(L,2,1);
		        	return 1;
		    	}
			}
			else
        	{
        		lua_pushvalue(L, 2);			    // stack: obj key mt key
        		lua_rawget(L, -2);					// stack: obj key mt value        

        		if (!lua_isnil(L, -1))
        		{
        	    	return 1;
        		}
                
                lua_pop(L, 1);
				lua_pushlightuserdata(L, &gettag);        	
        		lua_rawget(L, -2);					//stack: obj key mt tget

        		if (lua_istable(L, -1))
        		{
        	    	lua_pushvalue(L, 2);			//stack: obj key mt tget key
        	    	lua_rawget(L, -2);           	//stack: obj key mt tget value 

        	    	if (lua_isfunction(L, -1))
        	    	{
        	        	lua_pushvalue(L, 1);
        	        	lua_call(L, 1, 1);
        	        	return 1;
        	    	}                    
        		}
    		}

            lua_settop(L, 3);
        }

        lua_settop(L, 2);
        int *udata = (int*)lua_touserdata(L, 1);

        if (*udata == LUA_NULL_USERDATA)
        {
            return luaL_error(L, "attemp to index %s on a nil value", lua_tostring(L, 2));   
        }
        
        if (toluaflags & FLAG_INDEX_ERROR)
        {
            return luaL_error(L, "field or property %s does not exist", lua_tostring(L, 2));
        }        
    }
    else if(t == LUA_TTABLE)
    {
    	lua_pushvalue(L,1);                          //stack: obj key obj

		while (lua_getmetatable(L, -1) != 0)         //stack: obj key obj mt
    	{
        	lua_remove(L, -2);						// stack: obj key mt

        	lua_pushvalue(L, 2);			    	// stack: obj key mt key
        	lua_rawget(L, -2);						// stack: obj key mt value        

        	if (!lua_isnil(L, -1))
        	{
        		if (lua_isfunction(L, -1))			//cache static function
        		{
        			lua_pushvalue(L, 2);           // stack: obj key mt value key
        			lua_pushvalue(L, -2);          // stack: obj key mt value key value
        			lua_rawset(L, 1);
        		}

        	    return 1;
        	}        	
        	
            lua_pop(L, 1);        
			lua_pushlightuserdata(L, &gettag);        	
        	lua_rawget(L, -2);						//stack: obj key mt tget

        	if (lua_istable(L, -1))
        	{
        	    lua_pushvalue(L, 2);				//stack: obj key mt tget key
        	    lua_rawget(L, -2);           		//stack: obj key mt tget value 

        	    if (lua_isfunction(L, -1))
        	    {        	        	
                    lua_pushvalue(L, 1);
        	        lua_call(L, 1, 1);
        	        return 1;
        	    }
        	}
    		
        	lua_settop(L, 3);
    	}        
        
        if (_preload(L))
        {
            return 1;
        }          
        
        if (toluaflags & FLAG_INDEX_ERROR)
        {
            return luaL_error(L, "field or property %s does not exist", lua_tostring(L, 2));               
        }      
    }

    lua_pushnil(L);
    return 1;
}

static void storeatubox (lua_State *L, int lo)
{
    lua_getfenv(L, lo);                         // stack: t, k, v, _env

    if (lua_rawequal(L, -1, TOLUA_NOPEER)) 
    {
        lua_pop(L, 1);
        return;
        //lua_newtable(L);                        // stack: t, k, v, t
        //lua_pushvalue(L, -1);                   // stack: t, k, v, t, t        
        //lua_setfenv(L, lo);                     // stack: t, k, v, t
    };

    lua_insert(L, -3);
    lua_settable(L, -3);
    lua_pop(L, 1);
}

static int class_newindex_event(lua_State *L)
{
	int t = lua_type(L, 1);

	if (t == LUA_TUSERDATA)
    {
        bool useEnv = false;
        lua_getfenv(L, 1);

        if (!lua_rawequal(L, -1, TOLUA_NOPEER)) 
        {             
            useEnv = true;

            while (lua_istable(L, -1))                       // stack: t k v mt 
            {       
                lua_pushvalue(L, 2);                        // stack: t k v mt k
                lua_rawget(L, -2);                          // stack: t k v mt value        

                if (!lua_isnil(L, -1))
                {                    
                    lua_pop(L, 1);
                    lua_insert(L, -3);
                    lua_rawset(L, -3);
                    return 0;
                }

                lua_pop(L, 1);                
                lua_pushlightuserdata(L, &settag);              // stack: t k v mt tset
                lua_rawget(L, -2);                   

                if (lua_istable(L, -1)) 
                {
                    lua_pushvalue(L, 2);                         // stack: t k v mt tset k
                    lua_rawget(L, -2);                    

                    if (lua_isfunction(L, -1)) 
                    {                          
                        lua_pushvalue(L, 1); 
                        lua_pushvalue(L, 3); 
                        lua_call(L, 2, 0);
                        return 0;
                    }

                    lua_pop(L, 1);                              // stack: t k v mt tset 
                }  

                lua_pop(L, 1);                                  // stack: t k v mt

                if (lua_getmetatable(L, -1) == 0)               // stack: t k v mt mt
                {
                    lua_pushnil(L);
                }

                lua_remove(L, -2);                              // stack: t k v mt
            }              
        }

        lua_settop(L, 3);
    	lua_getmetatable(L,1);

    	while (lua_istable(L, -1))                			// stack: t k v mt
    	{        	
    		if (lua_isnumber(L, 2))
    		{
				lua_pushstring(L,".seti");
                lua_rawget(L,-2);                      		// stack: obj key mt func

                if (lua_isfunction(L,-1))
                {
                    lua_pushvalue(L,1);
                    lua_pushvalue(L,2);
                    lua_pushvalue(L,3);
                    lua_call(L,3,0);                    
                }

                return 0;
    		}
    		else
        	{
        		lua_pushlightuserdata(L, &settag);
        		lua_rawget(L, -2);                      	// stack: t k v mt tset

        		if (lua_istable(L, -1))
        		{
            		lua_pushvalue(L, 2);
            		lua_rawget(L, -2);                     	// stack: t k v mt tset func

            		if (lua_isfunction(L, -1))
            		{
                		lua_pushvalue(L, 1);
                		lua_pushvalue(L, 3);
                		lua_call(L, 2, 0);
                		return 0;
            		}

            		lua_pop(L, 1);                          // stack: t k v mt tset 
        		}

        		lua_pop(L, 1);                              // stack: t k v mt 

        		if (lua_getmetatable(L, -1) == 0)           // stack: t k v mt mt
        		{
            		lua_pushnil(L);
        		}

        		lua_remove(L, -2);                          // stack: t k v mt 
        	}
    	}

        lua_settop(L, 3);                                       // stack: t k v
        int* udata = (int*)lua_touserdata(L, 1);

        if (*udata == LUA_NULL_USERDATA)
        {
            return luaL_error(L, "attemp to index %s on a nil value", lua_tostring(L, 2));   
        }        

        if (useEnv) 
        {
            lua_getfenv(L, 1);                         // stack: t, k, v, _env
            lua_insert(L, -3);
            lua_settable(L, -3);
            lua_pop(L, 1);
            return 0;
        }                       
	}
	else if (t == LUA_TTABLE)
	{
		lua_getmetatable(L, 1);								// stack: t k v mt 

		while (lua_istable(L, -1))                			// stack: t k v mt 
    	{  		
			lua_pushlightuserdata(L, &settag);				// stack: t k v mt tset
        	lua_rawget(L, -2);       

        	if (lua_istable(L,-1)) 
        	{
            	lua_pushvalue(L,2);  						// stack: t k v mt tset k
            	lua_rawget(L,-2);

            	if (lua_isfunction(L,-1)) 
            	{  
                	lua_pushvalue(L,1); 
                	lua_pushvalue(L,3); 
                	lua_call(L,2,0);
                	return 0;
            	}

            	lua_pop(L, 1);                          	// stack: t k v mt tset 
        	}  

			lua_pop(L, 1);                              	// stack: t k v mt

        	if (lua_getmetatable(L, -1) == 0)           	// stack: t k v mt mt
        	{
            	lua_pushnil(L);
        	}

        	lua_remove(L, -2);                          	// stack: t k v mt
        }      
	}

    lua_settop(L, 3); 
    return luaL_error(L, "field or property %s does not exist", lua_tostring(L, 2));      
}

static int enum_index_event (lua_State *L)
{
	lua_getmetatable(L, 1);									//stack: t, k, mt

	if (lua_istable(L, -1))
	{
		lua_pushvalue(L, 2);								//stack: t, k, mt, k
		lua_rawget(L, -2);									//stack: t, k, mt, v

		if (!lua_isnil(L, -1))
		{		
			return 1;
		}

		lua_pop(L, 1);										//stack: t, k, mt
		lua_pushlightuserdata(L, &gettag);		
		lua_rawget(L, -2); 									//stack: t, k, mt, tget

		if (lua_istable(L,-1)) 
		{
            lua_pushvalue(L,2);  							//stack: t k mt tget k
            lua_rawget(L,-2);								//stack: t k mt tget v

           	if (lua_isfunction(L,-1)) 
			{  
				lua_call(L, 0, 1);					
				lua_pushvalue(L,2); 				
				lua_pushvalue(L,-2); 				
				lua_rawset(L, 3);		
				return 1;			
			}

			lua_pop(L, 1);
        }			
	}

	lua_settop(L, 2);
	lua_pushnil(L);
	return 1;	
}

static int enum_newindex_event(lua_State *L)
{	
	luaL_error(L, "the left-hand side of an assignment must be a variable, a property or an indexer");
    return 1;
}

static int static_index_event(lua_State *L)
{    
    lua_pushvalue(L, 2);                    //stack: t key key
    lua_rawget(L, 1);                       //stack: t key value        

    if (!lua_isnil(L, -1))
    {
        return 1;
    }

    lua_pop(L, 1);            
    lua_pushlightuserdata(L, &gettag);      //stack: t key tag    
    lua_rawget(L, 1);                       //stack: t key tget

    if (lua_istable(L, -1))
    {
        lua_pushvalue(L, 2);                //stack: obj key tget key
        lua_rawget(L, -2);                  //stack: obj key tget func 

        if (lua_isfunction(L, -1))
        {                       
            lua_call(L, 0, 1);
            return 1;
        }        
    }
    
    lua_settop(L, 2);

    if (_preload(L))
    {
        return 1;
    }
    
    if (toluaflags & FLAG_INDEX_ERROR)
    {
        luaL_error(L, "field or property %s does not exist", lua_tostring(L, 2));    
    }

    return 1;
}

static int static_newindex_event(lua_State *L)
{
    lua_pushlightuserdata(L, &settag);              //stack: t k v tag
    lua_rawget(L, 1);                               //stack: t k v tset

    if (lua_istable(L,-1)) 
    {
        lua_pushvalue(L, 2);                         //stack: t k v tset k
        lua_rawget(L, -2);                           //stack: t k v tset func

        if (lua_isfunction(L, -1))
        {    
            lua_pushvalue(L,1); 
            lua_pushvalue(L,3); 
            lua_call(L,2,0);
            return 0;
        }
    }

    lua_settop(L, 3); 
    luaL_error(L, "field or property %s does not exist", lua_tostring(L, 2));
    return 1;
}

static int vptr_index_event(lua_State *L)
{    
    lua_pushlightuserdata(L, &vptr);
    lua_rawget(L, 1);                                   // stack: t key u
    lua_replace(L, 1);                                  // stack: u key
    lua_pushvalue(L, 1);                                // stack: u key u

    while (lua_getmetatable(L, -1) != 0)
    {
        lua_remove(L, -2);                              // stack: u key mt
        lua_pushvalue(L, 2);                            // stack: u key mt key
        lua_rawget(L, -2);                              // stack: u key mt value        

        if (!lua_isnil(L, -1))
        {
            return 1;
        }
        
        lua_pop(L, 1);        
        lua_pushlightuserdata(L, &gettag);          
        lua_rawget(L, -2);                              //stack: u key mt tget

        if (lua_istable(L, -1))
        {
            lua_pushvalue(L, 2);                        //stack: obj key mt tget key
            lua_rawget(L, -2);                          //stack: obj key mt tget value 

            if (lua_isfunction(L, -1))
            {
                lua_pushvalue(L, 1);
                lua_call(L, 1, 1);
                return 1;
            }
        }

        lua_settop(L, 3);
    }

    lua_settop(L, 2);
    lua_pushnil(L);
    return 1;
}

static int vptr_newindex_event(lua_State *L)
{    
    lua_pushlightuserdata(L, &vptr);
    lua_rawget(L, 1);                                   // stack: t key v u        
    lua_getmetatable(L, -1);

    while (lua_istable(L, -1))                          // stack: u k v mt
    {           
        lua_pushlightuserdata(L, &settag);
        lua_rawget(L, -2);                              // stack: u k v mt tset

        if (lua_istable(L, -1))
        {
            lua_pushvalue(L, 2);
            lua_rawget(L, -2);                          // stack: u k v mt tset func

            if (lua_isfunction(L, -1))
            {
                lua_pushvalue(L, 4);
                lua_pushvalue(L, 3);
                lua_call(L, 2, 0);
                return 0;
            }

            lua_pop(L, 1);                              // stack: t k v mt tset 
        }

        lua_pop(L, 1);                                  // stack: t k v mt 

        if (lua_getmetatable(L, -1) == 0)               // stack: t k v mt mt
        {
            lua_pushnil(L);
        }

        lua_remove(L, -2);                              // stack: t k v mt             
    }

    lua_settop(L, 3);    
    return 1;
}

LUALIB_API bool tolua_isvptrtable(lua_State *L, int index)
{    
    lua_pushlightuserdata(L, &vptr);
    lua_rawget(L, index);
    bool flag = lua_isnil(L, -1) ? false : true;
    lua_pop(L, 1);
    return flag;
}

LUALIB_API void tolua_setindex(lua_State *L)
{
	lua_pushstring(L, "__index");
	lua_pushcfunction(L, class_index_event);
	lua_rawset(L, -3);
}

LUALIB_API void tolua_setnewindex(lua_State *L)
{
	lua_pushstring(L, "__newindex");
	lua_pushcfunction(L, class_newindex_event);
	lua_rawset(L, -3);
}

LUALIB_API bool tolua_pushudata(lua_State *L, int index)
{
	lua_getref(L, LUA_RIDX_UBOX);			// stack: ubox
	lua_rawgeti(L, -1, index); 				// stack: ubox, obj

	if (!lua_isnil(L, -1))
	{
		lua_remove(L, -2); 					// stack: obj
		return true;
	}

	lua_pop(L, 2);
	return false;
}

LUALIB_API void tolua_pushnewudata(lua_State *L, int metaRef, int index)
{
	lua_getref(L, LUA_RIDX_UBOX);
	tolua_newudata(L, index);
	lua_getref(L, metaRef);
	lua_setmetatable(L, -2);
	lua_pushvalue(L, -1);
	lua_rawseti(L, -3, index);
	lua_remove(L, -2);	
}

static int module_index_event(lua_State *L)
{    
    lua_pushvalue(L, 2);                    //stack: t key key
    lua_rawget(L, 1);                       //stack: t key value            

    if (!lua_isnil(L, -1))
    {
        return 1;
    }

    lua_pop(L, 1);                          //stack: t key 
    lua_pushstring(L, ".name");             //stack: t key ".name"
    lua_rawget(L, 1);        

    if (!lua_isnil(L, -1))                  //stack: t key space
    {                      
        lua_getref(L, LUA_RIDX_PRELOAD);    //stack: t key space preload
        lua_pushvalue(L, -2);
        lua_pushstring(L, ".");
        lua_pushvalue(L, 2);
        lua_concat(L, 3);                   //stack: t key space preload key
        lua_pushvalue(L, -1);               //stack: t key space preload key1 key1
        lua_rawget(L, -3);                  //stack: t key space preload key1 value        

        if (!lua_isnil(L, -1)) 
        {      
            lua_pop(L, 1);                      //stack: t key space preload key1
            lua_getref(L, LUA_RIDX_REQUIRE);
            lua_pushvalue(L, -2);
            lua_call(L, 1, 1);                    
        }
        else
        {
            lua_pushnil(L);                            
        }
    }
    
    return 1;
}

typedef struct stringbuffer 
{        
  const char *buffer;
  size_t len;
} stringbuffer;

static stringbuffer sb;

void initmodulebuffer()
{
    sb.len = 0;
    sb.buffer = NULL;
}

void pushmodule(lua_State *L, const char *str)
{    
    luaL_Buffer b;
    luaL_buffinit(L, &b);

    if (sb.len > 0)
    {
        luaL_addlstring(&b, sb.buffer, sb.len);
        luaL_addchar(&b, '.');
    }

    luaL_addstring(&b, str);
    luaL_pushresult(&b);    
    sb.buffer = lua_tolstring(L, -1, &sb.len);    
}

LUALIB_API bool tolua_beginmodule(lua_State *L, const char *name)
{
    if (name != NULL)
    {                
        lua_pushstring(L, name);			//stack key
        lua_rawget(L, -2);					//stack value

        if (lua_isnil(L, -1))  
        {
            lua_pop(L, 1);
            lua_newtable(L);				//stack table

            lua_pushstring(L, "__index");
            lua_pushcfunction(L, module_index_event);
            lua_rawset(L, -3);

            lua_pushstring(L, name);        //stack table name         
            lua_pushstring(L, ".name");     //stack table name ".name"            
            pushmodule(L, name);            //stack table name ".name" module            
            lua_rawset(L, -4);              //stack table name            
            lua_pushvalue(L, -2);			//stack table name table
            lua_rawset(L, -4);   			//stack table

            lua_pushvalue(L, -1);
            lua_setmetatable(L, -2);
            return true;
        }
        else if (lua_istable(L, -1))
        {
            if (lua_getmetatable(L, -1) == 0)
            {
                lua_pushstring(L, "__index");
                lua_pushcfunction(L, module_index_event);
                lua_rawset(L, -3);

                lua_pushstring(L, name);        //stack table name         
                lua_pushstring(L, ".name");     //stack table name ".name"            
                pushmodule(L, name);            //stack table name ".name" module            
                lua_rawset(L, -4);              //stack table name            
                lua_pushvalue(L, -2);           //stack table name table
                lua_rawset(L, -4);              //stack table

                lua_pushvalue(L, -1);
                lua_setmetatable(L, -2);                    
            }
            else
            {
                lua_pushstring(L, ".name");
                lua_gettable(L, -3);      
                sb.buffer = lua_tolstring(L, -1, &sb.len);                    
                lua_pop(L, 2);
            }

            return true;
        }

        return false;
    }
    else
    {                
        lua_pushvalue(L, LUA_GLOBALSINDEX);
        return true;
    }                
}

LUALIB_API void tolua_endmodule(lua_State *L)
{
    lua_pop(L, 1);
    int len = (int)sb.len;

    while(len-- >= 0)
    {
        if (sb.buffer[len] == '.')
        {
            sb.len = len;
            return;
        }
    }

    sb.len = 0;
}

static int class_new_event(lua_State *L)
{         
    if (!lua_istable(L, 1))
    {
        return luaL_typerror(L, 1, "table");        
    }

    int count = lua_gettop(L); 
    lua_pushvalue(L,1);  

    if (lua_getmetatable(L,-1))
    {   
        lua_remove(L,-2);                      
        lua_pushstring(L, "New");               
        lua_rawget(L,-2);    

        if (lua_isfunction(L,-1))
        {            
            for (int i = 2; i <= count; i++)
            {
                lua_pushvalue(L, i);                    
            }

            lua_call(L, count - 1, 1);
            return 1;
        }

        lua_settop(L,3);
    }    

    return luaL_error(L,"attempt to perform ctor operation failed");    
}

static void _pushfullname(lua_State *L, int pos)
{
    if (sb.len > 0)
    {
        lua_pushlstring(L, sb.buffer, sb.len);
        lua_pushstring(L, ".");
        lua_pushvalue(L,  pos < 0 ? pos - 2 : pos + 2);
        lua_concat(L, 3);
    }
    else
    {
        lua_pushvalue(L, pos);
    }
}

static void _addtoloaded(lua_State *L)
{
    lua_getref(L, LUA_RIDX_LOADED);
    _pushfullname(L, -3);
    lua_pushvalue(L, -3);
    lua_rawset(L, -3);
    lua_pop(L, 1);
}

LUALIB_API int tolua_beginclass(lua_State *L, const char *name, int baseType, int ref)
{
    int reference = ref;
    lua_pushstring(L, name);                
    lua_newtable(L);      
    _addtoloaded(L);

    if (ref == LUA_REFNIL)        
    {
        lua_newtable(L);
        lua_pushvalue(L, -1);
        reference = luaL_ref(L, LUA_REGISTRYINDEX); 
    }
    else
    {
        lua_getref(L, reference);    
    }

    if (baseType != 0)
    {
        lua_getref(L, baseType);        
        lua_setmetatable(L, -2);
    }
           
    lua_pushlightuserdata(L, &tag);
    lua_pushnumber(L, 1);
    lua_rawset(L, -3);

    lua_pushstring(L, ".name");
    _pushfullname(L, -4);
    lua_rawset(L, -3);

    lua_pushstring(L, ".ref");
    lua_pushinteger(L, reference);
    lua_rawset(L, -3);

    lua_pushstring(L, "__call");
    lua_pushcfunction(L, class_new_event);
    lua_rawset(L, -3);

    tolua_setindex(L);
    tolua_setnewindex(L); 
    return reference;
}


LUALIB_API void tolua_endclass(lua_State *L)
{
	lua_setmetatable(L, -2);
    lua_rawset(L, -3);            
}

/*void settablename(lua_State *L, const char *label, const char *name)
{
    lua_pushstring(L, "name");
    char cname[128];
    int l1 = strlen(label);
    int l2 = strlen(name)    ;
    strncat(cname, label, 128 - l1);
    strncat(cname, name, 128 - l1 - l2);
    lua_pushstring(L, cname);
    lua_rawset(L, -3);
}*/

LUALIB_API int tolua_beginenum(lua_State *L, const char *name)
{
	lua_pushstring(L, name);                               
    lua_newtable(L);                                       
    _addtoloaded(L);
    lua_newtable(L);
    lua_pushvalue(L, -1);
    int reference = luaL_ref(L, LUA_REGISTRYINDEX);            
    lua_pushlightuserdata(L, &tag);
    lua_pushnumber(L, 1);
    lua_rawset(L, -3);

    lua_pushstring(L, ".name");
    _pushfullname(L, -4);  
    lua_rawset(L, -3);

	lua_pushstring(L, "__index");
	lua_pushcfunction(L, enum_index_event);
	lua_rawset(L, -3);

	lua_pushstring(L, "__newindex");
	lua_pushcfunction(L, enum_newindex_event);
	lua_rawset(L, -3);	

	return reference;
}

LUALIB_API void tolua_endenum(lua_State *L)
{
	lua_setmetatable(L, -2);
    lua_rawset(L, -3);    
}

LUALIB_API void tolua_beginstaticclass(lua_State *L, const char *name)
{    
    lua_pushstring(L, name);  
    lua_newtable(L);
    _addtoloaded(L);
    lua_pushvalue(L, -1);

    lua_pushlightuserdata(L, &tag);
    lua_pushnumber(L, 1);
    lua_rawset(L, -3);

    lua_pushstring(L, ".name");
    _pushfullname(L, -4);
    lua_rawset(L, -3);

    lua_pushstring(L, "__index");
    lua_pushcfunction(L, static_index_event);
    lua_rawset(L, -3);

    lua_pushstring(L, "__newindex");
    lua_pushcfunction(L, static_newindex_event);
    lua_rawset(L, -3);      
}

LUALIB_API void tolua_endstaticclass(lua_State *L)
{
    lua_setmetatable(L, -2);
    lua_rawset(L, -3);    
}

LUALIB_API void tolua_constant(lua_State *L, const char *name, double value)
{
    lua_pushstring(L, name);
    lua_pushnumber(L, value);
    lua_rawset(L,-3);
}

LUALIB_API void tolua_function(lua_State *L, const char *name, lua_CFunction fn)
{
  	lua_pushstring(L, name);
    tolua_pushcfunction(L, fn);
  	lua_rawset(L, -3);

    /*lua_pushstring(L, name);
    lua_pushcfunction(L, fn);
    lua_rawset(L, -3);*/
}

LUALIB_API void tolua_variable(lua_State *L, const char *name, lua_CFunction get, lua_CFunction set)
{                
    lua_pushlightuserdata(L, &gettag);
    lua_rawget(L, -2);

    if (!lua_istable(L, -1))
    {
        /* create .get table, leaving it at the top */
        lua_pop(L, 1);
        lua_newtable(L);        
        lua_pushlightuserdata(L, &gettag);
        lua_pushvalue(L, -2);
        lua_rawset(L, -4);
    }

    lua_pushstring(L, name);
    //lua_pushcfunction(L, get);
    tolua_pushcfunction(L, get);
    lua_rawset(L, -3);                  /* store variable */
    lua_pop(L, 1);                      /* pop .get table */

    /* set func */
    if (set != NULL)
    {        
        lua_pushlightuserdata(L, &settag);
        lua_rawget(L, -2);

        if (!lua_istable(L, -1))
        {
            /* create .set table, leaving it at the top */
            lua_pop(L, 1);
            lua_newtable(L);            
            lua_pushlightuserdata(L, &settag);
            lua_pushvalue(L, -2);
            lua_rawset(L, -4);
        }

        lua_pushstring(L, name);
        //lua_pushcfunction(L, set);
        tolua_pushcfunction(L, set);
        lua_rawset(L, -3);                  /* store variable */
        lua_pop(L, 1);                      /* pop .set table */
    }
}

LUALIB_API int toluaL_ref(lua_State *L)
{
	int stackPos = abs_index(L, -1);	
	lua_getref(L, LUA_RIDX_FIXEDMAP);
	lua_pushvalue(L, stackPos);
	lua_rawget(L, -2);

	if (!lua_isnil(L, -1))
	{
		int ref = (int)lua_tointeger(L, -1);
		lua_pop(L, 3);
		return ref;
	}
	else
	{
		lua_pushvalue(L, stackPos);
		int ref = luaL_ref(L, LUA_REGISTRYINDEX);
		lua_pushvalue(L, stackPos);
		lua_pushinteger(L, ref);
		lua_rawset(L, -4);
		lua_pop(L, 3);
		return ref;
	}
}

LUALIB_API void toluaL_unref(lua_State *L, int reference)
{
	lua_getref(L, LUA_RIDX_FIXEDMAP);
	lua_getref(L, reference);
	lua_pushnil(L);
	lua_rawset(L, -3);
	luaL_unref(L, LUA_REGISTRYINDEX, reference);
	lua_pop(L, 1);
}

LUA_API lua_State* tolua_getmainstate(lua_State *L1)
{
	lua_rawgeti(L1, LUA_REGISTRYINDEX, LUA_RIDX_MAINTHREAD);
	lua_State *L = lua_tothread(L1, -1);
	lua_pop(L1, 1);
	return L;
}

LUA_API int tolua_getvaluetype(lua_State *L, int stackPos)
{
	stackPos = abs_index(L, stackPos);
	lua_getref(L, LUA_RIDX_CHECKVALUE);
	lua_pushvalue(L, stackPos);
	lua_call(L, 1, 1);
	int ret = (int)lua_tonumber(L, -1);
	lua_pop(L, 1);
	return ret;
}

LUALIB_API bool tolua_createtable(lua_State *L, const char *path, int szhint)
{
	const char *e = NULL;
	lua_pushvalue(L, LUA_GLOBALSINDEX);						//stack _G

	do 
	{
	  e = strchr(path, '.');
	  if (e == NULL) e = path + strlen(path);
	  lua_pushlstring(L, path, e - path);					//stack _G key
	  lua_rawget(L, -2);									//stack _G value
	  int type = lua_type(L, -1);

	  if (type == LUA_TNIL) 
	  {  
	    lua_pop(L, 1); 										//stack _G
	    lua_createtable(L, 0, (*e == '.' ? 1 : szhint));	//stack _G table
	    lua_pushlstring(L, path, e - path);					//stack _G table name
	    lua_pushvalue(L, -2);								//stack _G table name table
	    lua_settable(L, -4);  								//stack _G table
	  }
	  else if (type != LUA_TTABLE) 
	  {  
	    lua_pop(L, 2);  
	    return false;  
	  }

	  lua_remove(L, -2);  									//stack table
	  path = e + 1;
	} while (*e == '.');

	return true;
}

LUALIB_API bool tolua_beginpremodule(lua_State *L, const char *path, int szhint)
{
    const char *e = NULL;
    const char *name = path;
    lua_pushvalue(L, LUA_GLOBALSINDEX);                     //stack _G

    do 
    {
        e = strchr(path, '.');
        if (e == NULL) e = path + strlen(path);
        lua_pushlstring(L, path, e - path);                   //stack t key
        lua_rawget(L, -2);                                    //stack t value
        int type = lua_type(L, -1);

        if (type == LUA_TNIL) 
        {
            lua_pop(L, 1);                                      //stack t
            lua_createtable(L, 0, (*e == '.' ? 1 : szhint));    //stack t table
            lua_pushlstring(L, path, e - path);                 //stack t table name
            lua_pushvalue(L, -2);                               //stack t table name table
            lua_settable(L, -4);                                //stack t table

            lua_pushstring(L, ".name");        
            pushmodule(L, name);
            lua_rawset(L, -3);               

            lua_pushstring(L, "__index");
            lua_pushcfunction(L, module_index_event);
            lua_rawset(L, -3);    
        }
        else if (type != LUA_TTABLE) 
        {  
            lua_pop(L, 1);  
            return false;  
        }

        lua_remove(L, -2);                                    //stack table
        path = e + 1;
    } while (*e == '.');

    lua_pushstring(L, ".name");
    lua_gettable(L, -2);      
    sb.buffer = lua_tolstring(L, -1, &sb.len);    
    lua_pop(L, 1);
    return true;
}

LUALIB_API bool tolua_endpremodule(lua_State *L, int ref)
{    
    lua_getref(L, ref);
    lua_pushstring(L, ".name");
    lua_rawget(L, -2);                

    if (!tolua_createtable(L, lua_tostring(L, -1), 0))
    {
        lua_pushnil(L);
    }
    
    sb.len = 0;
    return true;
}

LUALIB_API bool tolua_addpreload(lua_State *L, const char *path)
{    
    const char *e = NULL;
    const char *name = path;
    int top = lua_gettop(L);
    lua_pushvalue(L, LUA_GLOBALSINDEX);                         //stack _G

    do 
    {
        e = strchr(path, '.');
        if (e == NULL) e = path + strlen(path);
        lua_pushlstring(L, path, e - path);                     //stack t key
        lua_rawget(L, -2);                                      //stack t value
        int type = lua_type(L, -1);

        if (type == LUA_TNIL) 
        {
            lua_pop(L, 1);                                      //stack t
            lua_createtable(L, 0, 0);                           //stack t table
            lua_pushlstring(L, path, e - path);                 //stack t table name
            lua_pushvalue(L, -2);                               //stack t table name table
            lua_settable(L, -4);                                //stack t table

            lua_pushstring(L, ".name");        
            lua_pushstring(L, name);
            lua_rawset(L, -3);               

            lua_pushstring(L, "__index");
            lua_pushcfunction(L, module_index_event);
            lua_rawset(L, -3);    
        }
        else if (type != LUA_TTABLE) 
        {  
            lua_settop(L, top);
            return false;  
        }

        lua_remove(L, -2);                                      //stack table
        path = e + 1;
    } while (*e == '.');

    lua_settop(L, top);
    return true;
}

LUALIB_API int tolua_getclassref(lua_State *L, int pos)
{    
    lua_getmetatable(L, pos);           //mt
    lua_pushstring(L, ".ref");          //mt .ref
    lua_rawget(L, -2);                  //mt ref
    int ref = lua_tointeger(L, -1);         
    return ref;
}

LUALIB_API bool tolua_pushluatable(lua_State *L, const char *path)
{
	const char *e = NULL;
	lua_pushvalue(L, LUA_GLOBALSINDEX);	

	do 
	{
	  e = strchr(path, '.');
	  if (e == NULL) e = path + strlen(path);
	  lua_pushlstring(L, path, e - path);
	  lua_rawget(L, -2);

	  if (!lua_istable(L, -1))
	  {  
	    lua_pop(L, 2); 
	    return false;
	  }

	  lua_remove(L, -2);  
	  path = e + 1;
	} while (*e == '.');

	return true;
}

LUALIB_API const char* tolua_typename(lua_State *L, int lo)
{
    int tag = lua_type(L,lo);
    
    if (tag == LUA_TNONE)
    {
		lua_pushstring(L,"[no object]");
    }
    else if (tag != LUA_TUSERDATA && tag != LUA_TTABLE)
    {
        lua_pushstring(L, lua_typename(L,tag));
    }
    else if (tag == LUA_TUSERDATA)
    {
        if (!lua_getmetatable(L,lo))
        {
            lua_pushstring(L, lua_typename(L,tag));
        }
        else
        {
            lua_pushstring(L, ".name");
            lua_rawget(L, -2);

            if (!lua_isstring(L,-1))
            {
                lua_pop(L,1);
                lua_pushstring(L,"[undefined]");
            }
        }
    }
    else  //is table
    {
        lua_pushvalue(L,lo);        

        if (!lua_getmetatable(L,lo))
        {
            lua_pop(L,1);
            lua_pushstring(L,"table");
        }
        else
        {
            lua_pushstring(L, ".name");
            lua_rawget(L, -2);

            lua_pushstring(L,"class ");
            lua_insert(L,-2);
            lua_concat(L,2);
        }
    }

    return lua_tostring(L, -1);
}

LUALIB_API int tolua_getmetatableref(lua_State *L, int pos)
{
	int ref = LUA_REFNIL;	

    if (lua_getmetatable(L, pos) != 0)
    {
        lua_pushstring(L, ".ref");
        lua_rawget(L, -2);	

        if (lua_isnumber(L, -1))
        {
            ref = (int)lua_tointeger(L, -1);
        }

        lua_pop(L, 2);
    }

    return ref;
}

static lua_State* getthread(lua_State *L, int *arg) 
{
    if (lua_isthread(L, 1)) 
    {
        *arg = 1;
        return lua_tothread(L, 1);
    }
    else 
    {
        *arg = 0;
        return L;  
    }
}

static int traceback(lua_State *L) 
{
    int arg;
    lua_State *L1 = getthread(L, &arg);
    const char *msg = lua_tostring(L, arg + 1);

    if (msg == NULL && !lua_isnoneornil(L, arg + 1))  
    {
        lua_pushvalue(L, arg + 1);  
    }
    else 
    {
        if (NULL != strstr(msg, "stack traceback:"))
        {
            lua_pushvalue(L, arg + 1);
            return 1;
        }

        int level = (int)luaL_optinteger(L, arg + 2, (L == L1) ? 1 : 0);
#ifdef LUAJIT_VERSION            
        luaL_traceback(L, L1, msg, level);
#else        
        lua_getref(L, LUA_RIDX_TRACEBACK);
        lua_pushthread(L1);
        lua_pushvalue(L, arg + 1);
        lua_pushnumber(L, level + 1);
        lua_call(L, 3, 1);   
#endif            
    }     

    return 1;
}

LUALIB_API int tolua_beginpcall(lua_State *L, int reference)
{	
    lua_getref(L, LUA_RIDX_CUSTOMTRACEBACK);
	int top = lua_gettop(L);
	lua_getref(L, reference);
	return top;
}

LUALIB_API void tolua_pushtraceback(lua_State *L)
{
	lua_getref(L, LUA_RIDX_CUSTOMTRACEBACK);
}

/*static const int sentinel_ = 0;
#define sentinel ((void *)&sentinel_)

static int _require(lua_State *L)
{
    const char *name = luaL_checkstring(L, 1);    
    lua_settop(L, 1);  
    const char *key = luaL_gsub(L, name, "/", ".");            
    lua_getfield(L, LUA_REGISTRYINDEX, "_LOADED");
    lua_getfield(L, 3, key);

    if (lua_toboolean(L, -1)) 
    {  
        if (lua_touserdata(L, -1) == sentinel)  
        {
            luaL_error(L, "loop or previous error loading module " LUA_QS, name);
        }

        return 1;  //package is already loaded
    }

    // else must load it; iterate over available loaders
    lua_getfield(L, LUA_ENVIRONINDEX, "loaders");

    if (!lua_istable(L, -1))
    {
        luaL_error(L, LUA_QL("package.loaders") " must be a table");
    }

    lua_pushliteral(L, "");  //error message accumulator

    for(int i = 1; ; i++) 
    {
        lua_rawgeti(L, -2, i);  // get a loader

        if (lua_isnil(L, -1))
        {
            luaL_error(L, "module " LUA_QS " not found:%s", name, lua_tostring(L, -2));
        }

        lua_pushstring(L, name);
        lua_call(L, 1, 1);  

        if (lua_isfunction(L, -1))  // did it find module?
        {
            break;  // module loaded successfully
        }
        else if (lua_isstring(L, -1))  // loader returned error message?
        {
            lua_concat(L, 2);  // accumulate it
        }
        else
        {
            lua_pop(L, 1);            
        }    
    }

    lua_pushlightuserdata(L, sentinel);
    lua_setfield(L, 3, key);   // _LOADED[name] = sentinel
    lua_pushstring(L, name);    // pass name as argument to module
    lua_call(L, 1, 1);          // run loaded module

    if (!lua_isnil(L, -1))  // non-nil return? 
    {
        lua_setfield(L, 3, key);  // _LOADED[name] = returned value
    }

    lua_getfield(L, 3, key);

    if (lua_touserdata(L, -1) == sentinel) 
    {   // module did not set a value? 
        lua_pushboolean(L, 1);          // use true as result
        lua_pushvalue(L, -1);           // extra copy to be returned
        lua_setfield(L, 3, key);        // _LOADED[name] = true 
    }

    return 1;
}

void tolua_openrequire(lua_State *L)
{    
    lua_getglobal(L, "require");
    lua_pushcfunction(L, _require);
    lua_getfenv(L, -2);
    lua_setfenv(L, -2);
    lua_setglobal(L, "require");
    lua_pop(L, 1);
}*/

LUALIB_API int tolua_require(lua_State *L, const char *fileName)
{
    int top = lua_gettop(L);
    lua_getref(L, LUA_RIDX_CUSTOMTRACEBACK);
    lua_getref(L, LUA_RIDX_REQUIRE);
    lua_pushstring(L, fileName);        
    int ret = lua_pcall(L, 1, -1, top + 1);
    lua_remove(L, top + 1);    
    return ret;
}


/*LUALIB_API bool tolua_checkluaslot(lua_State *L, int stackPos, int *func, int *table)
{
    lua_pushstring(L, "__call");      
    lua_rawget(L, stackPos);

    if (lua_isfunction(L, -1))
    {
        *func = toluaL_ref(L);        
    }
    else
    {
        lua_pop(L, 1);
        return false;
    }

    lua_pushvalue(L, stackPos);
    *table = toluaL_ref(L);    
    return true;
}*/

/*static int do_operator (lua_State *L, const char *op)
{
    if (lua_isuserdata(L,1))
    {        
        lua_pushvalue(L,1);  

        while (lua_getmetatable(L,-1))
        {   
            lua_remove(L,-2);                      
            lua_pushstring(L,op);               
            lua_rawget(L,-2);    

            if (lua_isfunction(L,-1))
            {
                lua_pushvalue(L,1);
                lua_pushvalue(L,2);
                lua_call(L,2,1);
                return 1;
            }

            lua_settop(L,3);
        }
    }

    luaL_error(L,"attempt to perform operation %s failed", op);
    return 0;
}

static int class_add_event (lua_State *L)
{
    return do_operator(L,"op_Addition");
}

static int class_sub_event (lua_State *L)
{
    return do_operator(L,"op_Subtraction");
}

static int class_mul_event (lua_State *L)
{
    return do_operator(L,"op_Multiply");
}

static int class_div_event (lua_State *L)
{
    return do_operator(L,"op_Division");
}

static int class_equals_event (lua_State *L)
{
    return do_operator(L,"op_Equality");
}*/


#ifdef _WIN32
double tolua_timegettime()
{
	FILETIME ft;
	double t;
	GetSystemTimeAsFileTime(&ft);
	/* Windows file time (time since January 1, 1601 (UTC)) */
	t = ft.dwLowDateTime / 1.0e7 + ft.dwHighDateTime*(4294967296.0 / 1.0e7);
	/* convert to Unix Epoch time (time since January 1, 1970 (UTC)) */
	return (t - 11644473600.0);
}
#else
double tolua_timegettime()
{
	struct timeval v;
	gettimeofday(&v, (struct timezone *) NULL);
	/* Unix Epoch time (time since January 1, 1970 (UTC)) */
	return v.tv_sec + v.tv_usec / 1.0e6;
}
#endif

static int tolua_gettime(lua_State *L)
{
	lua_pushnumber(L, tolua_timegettime());
	return 1;
}

static int tolua_bnd_setpeer(lua_State *L) 
{
    // stack: userdata, table
    if (!lua_isuserdata(L, -2)) 
    {
        return luaL_error(L, "Invalid argument #1 to setpeer: userdata expected.");        
    }

    if (lua_isnil(L, 2)) 
    {
        lua_pop(L, 1);
        lua_pushvalue(L, TOLUA_NOPEER);
        lua_setfenv(L, -2);
    }        
    else
    {
        lua_pushvalue(L, 2);                //stack: u p p
        lua_setfenv(L, -3);                 //stack: u p
        lua_newtable(L);                    //stack: u p vt        
        
        lua_pushlightuserdata(L, &vptr);    
        lua_pushvalue(L, 1);
        lua_rawset(L, -3);
        //lua_pushvalue(L, 1);
        //lua_rawseti(L, -2, 1);

        lua_getref(L, LUA_RIDX_VPTR);       //stack: u p vt mt
        lua_setmetatable(L, -2);            //stack: u p vt

        lua_pushstring(L, "base");          //stack: u p vt "base"
        lua_pushvalue(L, -2);               //stack: u p vt "base" vt
        lua_rawset(L, 2);                   //stack: u p vt    
        lua_pop(L, 1);
    }

    return 0;
};

static int tolua_bnd_getpeer(lua_State *L) 
{    
    lua_getfenv(L, -1);

    if (lua_rawequal(L, -1, TOLUA_NOPEER)) 
    {
        lua_pop(L, 1);
        lua_pushnil(L);
    };

    return 1;
};

static int tolua_bnd_getfunction(lua_State *L)
{
    lua_pushvalue(L, 1);                            // stack: obj key obj

    while (lua_getmetatable(L, -1) != 0)            // stack: obj key mt
    {            
        lua_remove(L, -2);                          // stack: obj key mt

        lua_pushvalue(L, 2);                        // stack: obj key mt key
        lua_rawget(L, -2);                          // stack: obj key mt value        

        if (!lua_isfunction(L, -1))
        {
            return 1;
        }
        else
        {
            lua_pop(L, 1);
        }
        
        lua_pushlightuserdata(L, &gettag);          
        lua_rawget(L, -2);                          //stack: obj key mt tget

        if (lua_istable(L, -1))
        {
            lua_pushvalue(L, 2);                    //stack: obj key mt tget key
            lua_rawget(L, -2);                      //stack: obj key mt tget value 

            if (lua_isfunction(L, -1))
            {                                           
                return 1;
            }
        }
            
        lua_settop(L, 3);                           //stack: obj key mt
    }

    lua_settop(L, 2);
    lua_pushnil(L);
    return 1;
}

static int tolua_bnd_type (lua_State *L)
{
    tolua_typename(L,lua_gettop(L));
    return 1;
}

static int tolua_initgettable(lua_State *L)
{
    if (!lua_istable(L, 1))
    {        
        return luaL_typerror(L, 1, "table");         
    }

    lua_newtable(L);
    lua_pushlightuserdata(L, &gettag);
    lua_pushvalue(L, -2);    
    lua_rawset(L, 1);
    return 1;
}

static int tolua_initsettable(lua_State *L)
{
    if (!lua_istable(L, 1))
    {        
        return luaL_typerror(L, 1, "table");         
    }

    lua_newtable(L);
    lua_pushlightuserdata(L, &settag);    
    lua_pushvalue(L, -2);    
    lua_rawset(L, 1);
    return 1;
}

void tolua_openvptr(lua_State *L)
{
    lua_newtable(L);        

    lua_pushstring(L, "__index");
    lua_pushcfunction(L, vptr_index_event);
    lua_rawset(L, -3);  

    lua_pushstring(L, "__newindex");
    lua_pushcfunction(L, vptr_newindex_event);
    lua_rawset(L, -3);  

    lua_rawseti(L, LUA_REGISTRYINDEX, LUA_RIDX_VPTR); 
}

static const struct luaL_Reg tolua_funcs[] = 
{
	{ "gettime", tolua_gettime },
	{ "typename", tolua_bnd_type },
	{ "setpeer", tolua_bnd_setpeer},
	{ "getpeer", tolua_bnd_getpeer},
    { "getfunction", tolua_bnd_getfunction},
    { "initset", tolua_initsettable},
    { "initget", tolua_initgettable},
    { "int64", tolua_newint64},        
    { "uint64", tolua_newuint64},
    { "traceback", traceback},
	{ NULL, NULL }
};

void tolua_setluabaseridx(lua_State *L)
{    
	for (int i = 1; i <= 64; i++)
	{
		lua_pushinteger(L, i);
		lua_rawseti(L, LUA_REGISTRYINDEX, i);
	}

    //同lua5.1.5之后版本放入mainstate和_G
	lua_pushthread(L);
	lua_rawseti(L, LUA_REGISTRYINDEX, LUA_RIDX_MAINTHREAD);

	lua_pushvalue(L, LUA_GLOBALSINDEX);
	lua_rawseti(L, LUA_REGISTRYINDEX, LUA_RIDX_GLOBALS);

    //cache require函数
    lua_getglobal(L, "require");
    lua_rawseti(L, LUA_REGISTRYINDEX, LUA_RIDX_REQUIRE);      
}

void tolua_openpreload(lua_State *L)
{
    lua_getglobal(L, "package");
    lua_pushstring(L, "preload");
    lua_rawget(L, -2);
    lua_rawseti(L, LUA_REGISTRYINDEX, LUA_RIDX_PRELOAD);    
    lua_pushstring(L, "loaded");
    lua_rawget(L, -2);
    lua_rawseti(L, LUA_REGISTRYINDEX, LUA_RIDX_LOADED);    
    lua_pop(L, 1);
}

void tolua_opentraceback(lua_State *L)
{
    lua_getglobal(L, "debug");
    lua_pushstring(L, "traceback");
    lua_rawget(L, -2);
    lua_pushvalue(L, -1);
    lua_setfield(L, LUA_GLOBALSINDEX, "traceback");            
    lua_rawseti(L, LUA_REGISTRYINDEX, LUA_RIDX_TRACEBACK);
    lua_pop(L, 1);    

    lua_pushcfunction(L, traceback);
    lua_rawseti(L, LUA_REGISTRYINDEX, LUA_RIDX_CUSTOMTRACEBACK);    
}

void tolua_openubox(lua_State *L)
{
	lua_newtable(L);
	lua_newtable(L);            
	lua_pushstring(L, "__mode");
	lua_pushstring(L, "v");
	lua_rawset(L, -3);
	lua_setmetatable(L, -2);            
	lua_rawseti(L, LUA_REGISTRYINDEX, LUA_RIDX_UBOX);	
}

void tolua_openfixedmap(lua_State *L)
{
	lua_newtable(L);
	//lua_newtable(L);
	//lua_pushstring(L, "__mode");
	//lua_pushstring(L, "k");
	//lua_rawset(L, -3);
	//lua_setmetatable(L, -2);    	
	lua_rawseti(L, LUA_REGISTRYINDEX, LUA_RIDX_FIXEDMAP);		
}


void tolua_openvaluetype(lua_State *L)
{
	lua_getglobal(L, "GetLuaValueType");
	lua_rawseti(L, LUA_REGISTRYINDEX, LUA_RIDX_CHECKVALUE);	
}

void tolua_openluavec3(lua_State *L)
{    
	lua_getglobal(L, "Vector3");

    if (!lua_istable(L, 1))
    {        
        luaL_error(L, "Vector3 does not exist or not be loaded");
        return;
    }

	lua_pushstring(L, "New");
	lua_rawget(L, -2);
	lua_rawseti(L, LUA_REGISTRYINDEX, LUA_RIDX_PACKVEC3);	
	lua_pushstring(L, "Get");
	lua_rawget(L, -2);
	lua_rawseti(L, LUA_REGISTRYINDEX, LUA_RIDX_UNPACKVEC3);	
	lua_pop(L, 1);
}

void tolua_openluavec2(lua_State *L)
{    
	lua_getglobal(L, "Vector2");

    if (!lua_istable(L, 1))
    {        
        luaL_error(L, "Vector2 does not exist or not be loaded");
        return;
    }

	lua_pushstring(L, "New");
	lua_rawget(L, -2);
	lua_rawseti(L, LUA_REGISTRYINDEX, LUA_RIDX_PACKVEC2);	
	lua_pushstring(L, "Get");
	lua_rawget(L, -2);
	lua_rawseti(L, LUA_REGISTRYINDEX, LUA_RIDX_UNPACKVEC2);	
	lua_pop(L, 1);
}

void tolua_openluavec4(lua_State *L)
{    
	lua_getglobal(L, "Vector4");

    if (!lua_istable(L, 1))
    {        
        luaL_error(L, "Vector4 does not exist or not be loaded");
        return;
    }

	lua_pushstring(L, "New");
	lua_rawget(L, -2);
	lua_rawseti(L, LUA_REGISTRYINDEX, LUA_RIDX_PACKVEC4);	
	lua_pushstring(L, "Get");
	lua_rawget(L, -2);
	lua_rawseti(L, LUA_REGISTRYINDEX, LUA_RIDX_UNPACKVEC4);	
	lua_pop(L, 1);
}

void tolua_openluaclr(lua_State *L)
{    
	lua_getglobal(L, "Color");

    if (!lua_istable(L, 1))
    {        
        luaL_error(L, "Color does not exist or not be loaded");
        return;
    }

	lua_pushstring(L, "New");
	lua_rawget(L, -2);
	lua_rawseti(L, LUA_REGISTRYINDEX, LUA_RIDX_PACKCLR);	
	lua_pushstring(L, "Get");
	lua_rawget(L, -2);
	lua_rawseti(L, LUA_REGISTRYINDEX, LUA_RIDX_UNPACKCLR);	
	lua_pop(L, 1);
}

void tolua_openluaquat(lua_State *L)
{    
	lua_getglobal(L, "Quaternion");

    if (!lua_istable(L, 1))
    {        
        luaL_error(L, "Quaternion does not exist or not be loaded");
        return;
    }

	lua_pushstring(L, "New");
	lua_rawget(L, -2);
	lua_rawseti(L, LUA_REGISTRYINDEX, LUA_RIDX_PACKQUAT);	
	lua_pushstring(L, "Get");
	lua_rawget(L, -2);
	lua_rawseti(L, LUA_REGISTRYINDEX, LUA_RIDX_UNPACKQUAT);		
	lua_pop(L, 1);
}

void tolua_openlualayermask(lua_State *L)
{    
    lua_getglobal(L, "LayerMask");   

    if (!lua_istable(L, 1))
    {        
        luaL_error(L, "LayerMask does not exist or not be loaded");
        return;
    }

    lua_pushstring(L, "New");
    lua_rawget(L, -2);
    lua_rawseti(L, LUA_REGISTRYINDEX, LUA_RIDX_PACKLAYERMASK);   
    lua_pushstring(L, "Get");
    lua_rawget(L, -2);
    lua_rawseti(L, LUA_REGISTRYINDEX, LUA_RIDX_UNPACKLAYERMASK); 
    lua_pop(L, 1);
}

void tolua_openupdate(lua_State *L)
{
    lua_getglobal(L, "Update");

    if (!lua_isfunction(L, 1))
    {
        luaL_error(L, "Update function does not exist or not be loaded");
        return;
    }

    lua_rawseti(L, LUA_REGISTRYINDEX, LUA_RIDX_UPDATE);    
    lua_getglobal(L, "LateUpdate");

    if (!lua_isfunction(L, 1))
    {
        luaL_error(L, "LateUpdate function does not exist or not be loaded");
        return;
    }

    lua_rawseti(L, LUA_REGISTRYINDEX, LUA_RIDX_LATEUPDATE);  
    lua_getglobal(L, "FixedUpdate");

    if (!lua_isfunction(L, 1))
    {
        luaL_error(L, "FixedUpdate function does not exist or not be loaded");
        return;
    }

    lua_rawseti(L, LUA_REGISTRYINDEX, LUA_RIDX_FIXEDUPDATE);      
}


static int _openlualibs(lua_State *L)
{
    tolua_openvaluetype(L);
    tolua_openluavec3(L);
    tolua_openluavec2(L);
    tolua_openluavec4(L);
    tolua_openluaclr(L);
    tolua_openluaquat(L);   
    tolua_openlualayermask(L);
    tolua_openupdate(L);
    return 0;
}

LUALIB_API int tolua_openlualibs(lua_State *L)
{    
    lua_pushcfunction(L, _openlualibs);
    return lua_pcall(L, 0, -1, 0);    
}

static int mathf_ispoweroftwo(lua_State *L)
{
    lua_Integer mask = luaL_checkinteger(L, 1);
    bool flag = (mask & (mask-1)) == 0 ? true : false;
    lua_pushboolean(L, flag);
    return 1;
}

lua_Integer NextPowerOfTwo(lua_Integer v)
{
    v -= 1;
    v |= v >> 16;
    v |= v >> 8;
    v |= v >> 4;
    v |= v >> 2;
    v |= v >> 1;
    return v + 1;
}

static int mathf_nextpoweroftwo(lua_State *L)
{
    lua_Integer v = luaL_checkinteger(L, 1);
    v = NextPowerOfTwo(v);
    lua_pushnumber(L, v);
    return 1;
}

static int mathf_closestpoweroftwo(lua_State *L)
{
    lua_Integer v = luaL_checkinteger(L, 1);
    lua_Integer nextPower = NextPowerOfTwo (v);
    lua_Integer prevPower = nextPower >> 1;    

    if (v - prevPower < nextPower - v)
    {
        lua_pushnumber(L, prevPower);        
    }
    else
    {    
        lua_pushnumber(L, nextPower);
    }

    return 1;
}

static int mathf_gammatolinearspace(lua_State *L)
{
    lua_Number value = luaL_checknumber(L, 1);

    if (value <= 0.04045f)
    {
        value /= 12.92f;
    }
    else if (value < 1.0f)
    {    
        value = pow((value + 0.055f)/1.055f, 2.4f);
    }
    else
    {
        value = pow(value, 2.4f);
    }

    lua_pushnumber(L, value);
    return 1;    
}

static int mathf_lineartogammaspace (lua_State *L)
{
    lua_Number value = luaL_checknumber(L, 1);

    if (value <= 0.0f)
    {    
        value = 0;
    }
    else if (value <= 0.0031308f)
    {
        value *= 12.92f;
    }
    else if (value <= 1.0f)
    {
        value = 1.055f * powf(value, 0.41666f) - 0.055f;
    }
    else
    {
        value = powf(value, 0.41666f);
    }

    lua_pushnumber(L, value);
    return 1;
}

static int mathf_normalize(lua_State *L)
{
    float x = (float)lua_tonumber(L, 1);
    float y = (float)lua_tonumber(L, 2);
    float z = (float)lua_tonumber(L, 3);

    float len = sqrt(x * x + y * y + z * z);
    
    if (len == 1)
    {
        lua_pushnumber(L, x);
        lua_pushnumber(L, y);
        lua_pushnumber(L, z);
    }
    else if (len > 1e-5)
    {
        lua_pushnumber(L, x);
        lua_pushnumber(L, y);
        lua_pushnumber(L, z);
    }
    else    
    {
        lua_pushnumber(L, 0);
        lua_pushnumber(L, 0);
        lua_pushnumber(L, 0);
    }

    return 3;
}

static const struct luaL_Reg tolua_mathf[] = 
{
    { "NextPowerOfTwo", mathf_nextpoweroftwo },
    { "ClosestPowerOfTwo", mathf_closestpoweroftwo },
    { "IsPowerOfTwo", mathf_ispoweroftwo},
    { "GammaToLinearSpace", mathf_gammatolinearspace},
    { "LinearToGammaSpace", mathf_lineartogammaspace},
    { "Normalize", mathf_normalize},
    { NULL, NULL }
};

LUALIB_API void tolua_openlibs(lua_State *L)
{   
    initmodulebuffer();
    luaL_openlibs(L);   
    int top = lua_gettop(L);    

    tolua_setluabaseridx(L);    
    tolua_opentraceback(L);
    tolua_openpreload(L);
    tolua_openubox(L);
    tolua_openfixedmap(L);    
    tolua_openint64(L);
    tolua_openuint64(L);
    tolua_openvptr(L);    
    //tolua_openrequire(L);

    luaL_register(L, "Mathf", tolua_mathf);     
    luaL_register(L, "tolua", tolua_funcs);    

    lua_getglobal(L, "tolua");

    lua_pushstring(L, "gettag");
    lua_pushlightuserdata(L, &gettag);
    lua_rawset(L, -3);

    lua_pushstring(L, "settag");
    lua_pushlightuserdata(L, &settag);
    lua_rawset(L, -3);

    lua_pushstring(L, "version");
    lua_pushstring(L, "1.0.7");
    lua_rawset(L, -3);

    lua_settop(L,top);
}

LUALIB_API void tolua_setflag(int bit, bool flag)
{
    if (flag)
    {
        toluaflags |= bit;    
    }
    else
    {
        toluaflags &= ~bit;    
    }
}

LUALIB_API bool tolua_getflag(int bit)
{
    return toluaflags & bit ? true : false;
}

static luaL_Buffer lua_buffer[3];
static int _bufferIndex = 0;

LUALIB_API luaL_Buffer* tolua_buffinit(lua_State *L)
{
    luaL_Buffer* buffer = &lua_buffer[_bufferIndex & 3];
    luaL_buffinit(L, buffer);
    ++_bufferIndex;
    return buffer;
}

LUALIB_API void tolua_addlstring(luaL_Buffer *b, const char *s, int l)
{
    luaL_addlstring(b, s, (size_t)l);
}

LUALIB_API void tolua_addstring(luaL_Buffer *b, const char *s)
{
    luaL_addstring(b, s);
}

LUALIB_API void tolua_pushresult(luaL_Buffer *b)
{
    luaL_pushresult(b);
}

LUALIB_API void tolua_addchar(luaL_Buffer *b, char c)
{
    luaL_addchar(b, c);
}

LUALIB_API int tolua_update(lua_State *L, float deltaTime, float unscaledTime)
{
    int top = tolua_beginpcall(L, LUA_RIDX_UPDATE);
    lua_pushnumber(L, deltaTime);
    lua_pushnumber(L, unscaledTime);
    return lua_pcall(L, 2, -1, top);
}

LUALIB_API int tolua_lateupdate(lua_State *L)
{
    int top = tolua_beginpcall(L, LUA_RIDX_LATEUPDATE);
    return lua_pcall(L, 0, -1, top);
}

LUALIB_API int tolua_fixedupdate(lua_State *L, float fixedTime)
{
    int top = tolua_beginpcall(L, LUA_RIDX_FIXEDUPDATE);
    lua_pushnumber(L, fixedTime);
    return lua_pcall(L, 1, -1, top);
}

static int index_op_this(lua_State *L)
{
    lua_pushvalue(L, 2);                                //stack: t, k, k
    lua_rawget(L, -2);                                  //stack: t, k, v

    if (!lua_isnil(L, -1))
    {       
        lua_pushlightuserdata(L, &vptr);               // stack: t, k, v, vptr
        lua_rawget(L, 1);                              // stack: t, k, v, u
        lua_replace(L, 1);                             // stack: u, k, v
    }    

    return 1;
}

static int newindex_op_this(lua_State *L)
{
    lua_pushvalue(L, 2);                                //stack: t, k, v, k
    lua_rawget(L, 1);                                   //stack: t, k, v, f

    if (!lua_isnil(L, -1))
    {       
        lua_pushlightuserdata(L, &vptr);               // stack: t, k, v, f, vptr
        lua_rawget(L, 1);                              // stack: t, k, v, f, u
        lua_replace(L, 1);                             // stack: u, k, v, f
    }    

    return 1;
}

LUALIB_API void tolua_regthis(lua_State *L, lua_CFunction get, lua_CFunction set)
{
    lua_newtable(L);                        //u t
    
    lua_pushlightuserdata(L, &vptr);    
    lua_pushvalue(L, -3);
    lua_rawset(L, -3);

    if (get != NULL)
    {
        lua_pushstring(L, "get");    
        tolua_pushcfunction(L, get);
        lua_rawset(L, -3);                  
    }

    if (set != NULL)
    {
        lua_pushstring(L, "set");    
        tolua_pushcfunction(L, set);
        lua_rawset(L, -3);          
    }    

    lua_pushstring(L, "__index");
    lua_pushcfunction(L, index_op_this);
    lua_rawset(L, -3);  

    lua_pushstring(L, "__newindex");
    lua_pushcfunction(L, newindex_op_this);
    lua_rawset(L, -3);          
}

LUALIB_API int tolua_where (lua_State *L, int level) 
{
    lua_Debug ar;

    if (lua_getstack(L, level, &ar)) 
    {  
        lua_getinfo(L, "Sl", &ar);  

        if (ar.currentline > 0) 
        {              
            lua_pushstring(L, ar.source);
            return ar.currentline;
        }
    }

    lua_pushliteral(L, "");
    return -1;
}