
using System;
using System.Collections.Generic;
namespace SLua
{
    public partial class LuaDelegation : LuaObject
    {

        static internal void Lua_UnityEngine_Events_UnityAction(LuaFunction ld ) {
            IntPtr l = ld.L;
            int error = pushTry(l);

			ld.pcall(0, error);
			LuaDLL.lua_settop(l, error-1);
		}
	}
}
