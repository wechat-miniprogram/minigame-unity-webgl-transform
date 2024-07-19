
using System;
using System.Collections.Generic;
namespace SLua
{
    public partial class LuaDelegation : LuaObject
    {

        static internal System.Char Lua_UnityEngine_UI_InputField_OnValidateInput(LuaFunction ld ,string a1,int a2,System.Char a3) {
            IntPtr l = ld.L;
            int error = pushTry(l);

			pushValue(l,a1);
			pushValue(l,a2);
			pushValue(l,a3);
			ld.pcall(3, error);
			System.Char ret;
			checkType(l,error+1,out ret);
			LuaDLL.lua_settop(l, error-1);
			return ret;
		}
	}
}
