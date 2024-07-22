using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Jobs_IJobParallelForTransform : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Execute(IntPtr l) {
		try {
			UnityEngine.Jobs.IJobParallelForTransform self=(UnityEngine.Jobs.IJobParallelForTransform)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			UnityEngine.Jobs.TransformAccess a2;
			checkValueType(l,3,out a2);
			self.Execute(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Jobs.IJobParallelForTransform");
		addMember(l,Execute);
		createTypeMetatable(l,null, typeof(UnityEngine.Jobs.IJobParallelForTransform));
	}
}
