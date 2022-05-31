using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystemJobs_IJobParticleSystemParallelFor : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Execute(IntPtr l) {
		try {
			UnityEngine.ParticleSystemJobs.IJobParticleSystemParallelFor self=(UnityEngine.ParticleSystemJobs.IJobParticleSystemParallelFor)checkSelf(l);
			UnityEngine.ParticleSystemJobs.ParticleSystemJobData a1;
			checkValueType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
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
		getTypeTable(l,"UnityEngine.ParticleSystemJobs.IJobParticleSystemParallelFor");
		addMember(l,Execute);
		createTypeMetatable(l,null, typeof(UnityEngine.ParticleSystemJobs.IJobParticleSystemParallelFor));
	}
}
