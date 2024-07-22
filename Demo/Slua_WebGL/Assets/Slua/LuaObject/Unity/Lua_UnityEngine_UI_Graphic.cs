using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_Graphic : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetAllDirty(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			self.SetAllDirty();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetLayoutDirty(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			self.SetLayoutDirty();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetVerticesDirty(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			self.SetVerticesDirty();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetMaterialDirty(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			self.SetMaterialDirty();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnCullingChanged(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			self.OnCullingChanged();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Rebuild(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			UnityEngine.UI.CanvasUpdate a1;
			a1 = (UnityEngine.UI.CanvasUpdate)LuaDLL.luaL_checkinteger(l, 2);
			self.Rebuild(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int LayoutComplete(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			self.LayoutComplete();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GraphicUpdateComplete(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			self.GraphicUpdateComplete();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetNativeSize(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			self.SetNativeSize();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Raycast(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			UnityEngine.Vector2 a1;
			checkType(l,2,out a1);
			UnityEngine.Camera a2;
			checkType(l,3,out a2);
			var ret=self.Raycast(a1,a2);
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
	static public int PixelAdjustPoint(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			UnityEngine.Vector2 a1;
			checkType(l,2,out a1);
			var ret=self.PixelAdjustPoint(a1);
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
	static public int GetPixelAdjustedRect(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			var ret=self.GetPixelAdjustedRect();
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
	static public int CrossFadeColor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==5){
				UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
				UnityEngine.Color a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Boolean a3;
				checkType(l,4,out a3);
				System.Boolean a4;
				checkType(l,5,out a4);
				self.CrossFadeColor(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(argc==6){
				UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
				UnityEngine.Color a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Boolean a3;
				checkType(l,4,out a3);
				System.Boolean a4;
				checkType(l,5,out a4);
				System.Boolean a5;
				checkType(l,6,out a5);
				self.CrossFadeColor(a1,a2,a3,a4,a5);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function CrossFadeColor to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CrossFadeAlpha(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			System.Boolean a3;
			checkType(l,4,out a3);
			self.CrossFadeAlpha(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RegisterDirtyLayoutCallback(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			UnityEngine.Events.UnityAction a1;
			checkDelegate(l,2,out a1);
			self.RegisterDirtyLayoutCallback(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int UnregisterDirtyLayoutCallback(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			UnityEngine.Events.UnityAction a1;
			checkDelegate(l,2,out a1);
			self.UnregisterDirtyLayoutCallback(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RegisterDirtyVerticesCallback(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			UnityEngine.Events.UnityAction a1;
			checkDelegate(l,2,out a1);
			self.RegisterDirtyVerticesCallback(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int UnregisterDirtyVerticesCallback(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			UnityEngine.Events.UnityAction a1;
			checkDelegate(l,2,out a1);
			self.UnregisterDirtyVerticesCallback(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RegisterDirtyMaterialCallback(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			UnityEngine.Events.UnityAction a1;
			checkDelegate(l,2,out a1);
			self.RegisterDirtyMaterialCallback(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int UnregisterDirtyMaterialCallback(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			UnityEngine.Events.UnityAction a1;
			checkDelegate(l,2,out a1);
			self.UnregisterDirtyMaterialCallback(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_defaultGraphicMaterial(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.UI.Graphic.defaultGraphicMaterial);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_color(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.color);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_color(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.color=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_raycastTarget(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.raycastTarget);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_raycastTarget(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.raycastTarget=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_raycastPadding(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.raycastPadding);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_raycastPadding(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			UnityEngine.Vector4 v;
			checkType(l,2,out v);
			self.raycastPadding=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_depth(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.depth);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_rectTransform(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.rectTransform);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_canvas(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.canvas);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_canvasRenderer(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.canvasRenderer);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_defaultMaterial(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.defaultMaterial);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_material(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.material);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_material(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			UnityEngine.Material v;
			checkType(l,2,out v);
			self.material=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_materialForRendering(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.materialForRendering);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_mainTexture(IntPtr l) {
		try {
			UnityEngine.UI.Graphic self=(UnityEngine.UI.Graphic)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.mainTexture);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Graphic");
		addMember(l,SetAllDirty);
		addMember(l,SetLayoutDirty);
		addMember(l,SetVerticesDirty);
		addMember(l,SetMaterialDirty);
		addMember(l,OnCullingChanged);
		addMember(l,Rebuild);
		addMember(l,LayoutComplete);
		addMember(l,GraphicUpdateComplete);
		addMember(l,SetNativeSize);
		addMember(l,Raycast);
		addMember(l,PixelAdjustPoint);
		addMember(l,GetPixelAdjustedRect);
		addMember(l,CrossFadeColor);
		addMember(l,CrossFadeAlpha);
		addMember(l,RegisterDirtyLayoutCallback);
		addMember(l,UnregisterDirtyLayoutCallback);
		addMember(l,RegisterDirtyVerticesCallback);
		addMember(l,UnregisterDirtyVerticesCallback);
		addMember(l,RegisterDirtyMaterialCallback);
		addMember(l,UnregisterDirtyMaterialCallback);
		addMember(l,"defaultGraphicMaterial",get_defaultGraphicMaterial,null,false);
		addMember(l,"color",get_color,set_color,true);
		addMember(l,"raycastTarget",get_raycastTarget,set_raycastTarget,true);
		addMember(l,"raycastPadding",get_raycastPadding,set_raycastPadding,true);
		addMember(l,"depth",get_depth,null,true);
		addMember(l,"rectTransform",get_rectTransform,null,true);
		addMember(l,"canvas",get_canvas,null,true);
		addMember(l,"canvasRenderer",get_canvasRenderer,null,true);
		addMember(l,"defaultMaterial",get_defaultMaterial,null,true);
		addMember(l,"material",get_material,set_material,true);
		addMember(l,"materialForRendering",get_materialForRendering,null,true);
		addMember(l,"mainTexture",get_mainTexture,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Graphic),typeof(UnityEngine.EventSystems.UIBehaviour));
	}
}
