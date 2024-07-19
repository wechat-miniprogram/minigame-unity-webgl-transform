using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Animations_IAnimationWindowPreview : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int StartPreview(IntPtr l) {
		try {
			UnityEngine.Animations.IAnimationWindowPreview self=(UnityEngine.Animations.IAnimationWindowPreview)checkSelf(l);
			self.StartPreview();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int StopPreview(IntPtr l) {
		try {
			UnityEngine.Animations.IAnimationWindowPreview self=(UnityEngine.Animations.IAnimationWindowPreview)checkSelf(l);
			self.StopPreview();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int UpdatePreviewGraph(IntPtr l) {
		try {
			UnityEngine.Animations.IAnimationWindowPreview self=(UnityEngine.Animations.IAnimationWindowPreview)checkSelf(l);
			UnityEngine.Playables.PlayableGraph a1;
			checkValueType(l,2,out a1);
			self.UpdatePreviewGraph(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int BuildPreviewGraph(IntPtr l) {
		try {
			UnityEngine.Animations.IAnimationWindowPreview self=(UnityEngine.Animations.IAnimationWindowPreview)checkSelf(l);
			UnityEngine.Playables.PlayableGraph a1;
			checkValueType(l,2,out a1);
			UnityEngine.Playables.Playable a2;
			checkValueType(l,3,out a2);
			var ret=self.BuildPreviewGraph(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Animations.IAnimationWindowPreview");
		addMember(l,StartPreview);
		addMember(l,StopPreview);
		addMember(l,UpdatePreviewGraph);
		addMember(l,BuildPreviewGraph);
		createTypeMetatable(l,null, typeof(UnityEngine.Animations.IAnimationWindowPreview));
	}
}
