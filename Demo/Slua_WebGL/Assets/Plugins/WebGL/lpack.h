#ifndef LPACK_H
#define LPACK_H

#include "lua.h"

#ifndef LUAPACKLIB_API
#define LUAPACKLIB_API extern
#endif

/*-------------------------------------------------------------------------*\
 * Initializes the library.
 \*-------------------------------------------------------------------------*/
LUAPACKLIB_API int luaopen_pack(lua_State *L);

#endif /* LPACK_H */
