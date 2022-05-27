
using System;
using System.Collections.Generic;
namespace SLua
{
    public partial class LuaDelegation : LuaObject
    {

        static internal bool Lua_Deleg_GetBundleInfoDelegate(LuaFunction ld ,string a1,int a2,int a3,ref System.Int32 a4,out System.String a5,out System.Int32 a6) {
            IntPtr l = ld.L;
            int error = pushTry(l);

			pushValue(l,a1);
			pushValue(l,a2);
			pushValue(l,a3);
			pushValue(l,a4);
			ld.pcall(4, error);
			bool ret;
			checkType(l,error+1,out ret);
			checkType(l,error+2,out a4);
			checkType(l,error+3,out a5);
			checkType(l,error+4,out a6);
			LuaDLL.lua_settop(l, error-1);
			return ret;
		}
	}
}
