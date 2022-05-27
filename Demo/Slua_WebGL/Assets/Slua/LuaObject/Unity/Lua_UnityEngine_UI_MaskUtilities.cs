using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_MaskUtilities : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.MaskUtilities o;
			o=new UnityEngine.UI.MaskUtilities();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Notify2DMaskStateChanged_s(IntPtr l) {
		try {
			UnityEngine.Component a1;
			checkType(l,1,out a1);
			UnityEngine.UI.MaskUtilities.Notify2DMaskStateChanged(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int NotifyStencilStateChanged_s(IntPtr l) {
		try {
			UnityEngine.Component a1;
			checkType(l,1,out a1);
			UnityEngine.UI.MaskUtilities.NotifyStencilStateChanged(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int FindRootSortOverrideCanvas_s(IntPtr l) {
		try {
			UnityEngine.Transform a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.UI.MaskUtilities.FindRootSortOverrideCanvas(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetStencilDepth_s(IntPtr l) {
		try {
			UnityEngine.Transform a1;
			checkType(l,1,out a1);
			UnityEngine.Transform a2;
			checkType(l,2,out a2);
			var ret=UnityEngine.UI.MaskUtilities.GetStencilDepth(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int IsDescendantOrSelf_s(IntPtr l) {
		try {
			UnityEngine.Transform a1;
			checkType(l,1,out a1);
			UnityEngine.Transform a2;
			checkType(l,2,out a2);
			var ret=UnityEngine.UI.MaskUtilities.IsDescendantOrSelf(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetRectMaskForClippable_s(IntPtr l) {
		try {
			UnityEngine.UI.IClippable a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.UI.MaskUtilities.GetRectMaskForClippable(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetRectMasksForClip_s(IntPtr l) {
		try {
			UnityEngine.UI.RectMask2D a1;
			checkType(l,1,out a1);
			System.Collections.Generic.List<UnityEngine.UI.RectMask2D> a2;
			checkType(l,2,out a2);
			UnityEngine.UI.MaskUtilities.GetRectMasksForClip(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.MaskUtilities");
		addMember(l,Notify2DMaskStateChanged_s);
		addMember(l,NotifyStencilStateChanged_s);
		addMember(l,FindRootSortOverrideCanvas_s);
		addMember(l,GetStencilDepth_s);
		addMember(l,IsDescendantOrSelf_s);
		addMember(l,GetRectMaskForClippable_s);
		addMember(l,GetRectMasksForClip_s);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.MaskUtilities));
	}
}
