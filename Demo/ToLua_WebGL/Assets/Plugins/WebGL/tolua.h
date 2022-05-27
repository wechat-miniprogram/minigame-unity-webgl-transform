#ifndef tolua_h
#define tolua_h

#if !defined(LUA_RIDX_MAINTHREAD)
#define LUA_RIDX_MAINTHREAD	1
#endif

#if !defined(LUA_RIDX_GLOBALS)
#define LUA_RIDX_GLOBALS 2
#endif

#define LUA_RIDX_TRACEBACK 			3
#define LUA_RIDX_UBOX 				4
#define LUA_RIDX_FIXEDMAP			5
#define LUA_RIDX_CHECKVALUE			6
#define LUA_RIDX_PACKVEC3			7
#define LUA_RIDX_UNPACKVEC3			8
#define LUA_RIDX_PACKVEC2 			9
#define LUA_RIDX_UNPACKVEC2			10
#define LUA_RIDX_PACKVEC4			11
#define LUA_RIDX_UNPACKVEC4			12
#define LUA_RIDX_PACKQUAT			13
#define LUA_RIDX_UNPACKQUAT			14
#define LUA_RIDX_PACKCLR			15
#define LUA_RIDX_UNPACKCLR			16
#define LUA_RIDX_PACKLAYERMASK      17
#define LUA_RIDX_UNPACKLAYERMASK    18
#define LUA_RIDX_REQUIRE            19
#define LUA_RIDX_INT64              20
#define LUA_RIDX_VPTR               21
#define LUA_RIDX_UPDATE				22
#define LUA_RIDX_LATEUPDATE			23
#define LUA_RIDX_FIXEDUPDATE		24
#define LUA_RIDX_PRELOAD			25
#define LUA_RIDX_LOADED				26
#define LUA_RIDX_UINT64				27
#define LUA_RIDX_CUSTOMTRACEBACK 	28

#define LUA_NULL_USERDATA 	1
#define TOLUA_NOPEER    	LUA_REGISTRYINDEX 		
#define FLAG_INDEX_ERROR 	1
#define FLAG_INT64       	2

#define MAX_ITEM 512

#define abs_index(L, i)  ((i) > 0 || (i) <= LUA_REGISTRYINDEX ? (i) : lua_gettop(L) + (i) + 1)

void tolua_openint64(lua_State* L);
int  tolua_newint64(lua_State* L);
void tolua_pushint64(lua_State* L, int64_t n);

void tolua_openuint64(lua_State* L);
int  tolua_newuint64(lua_State* L);

extern int toluaflags;

#endif