using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_IAnimationClipSource : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetAnimationClips(IntPtr l) {
		try {
			UnityEngine.IAnimationClipSource self=(UnityEngine.IAnimationClipSource)checkSelf(l);
			System.Collections.Generic.List<UnityEngine.AnimationClip> a1;
			checkType(l,2,out a1);
			self.GetAnimationClips(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.IAnimationClipSource");
		addMember(l,GetAnimationClips);
		createTypeMetatable(l,null, typeof(UnityEngine.IAnimationClipSource));
	}
}
