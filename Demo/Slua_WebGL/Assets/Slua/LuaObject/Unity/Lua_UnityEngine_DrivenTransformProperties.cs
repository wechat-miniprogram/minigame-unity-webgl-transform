using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_DrivenTransformProperties : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.DrivenTransformProperties");
		addMember(l,0,"None");
		addMember(l,2,"AnchoredPositionX");
		addMember(l,4,"AnchoredPositionY");
		addMember(l,6,"AnchoredPosition");
		addMember(l,8,"AnchoredPositionZ");
		addMember(l,14,"AnchoredPosition3D");
		addMember(l,16,"Rotation");
		addMember(l,32,"ScaleX");
		addMember(l,64,"ScaleY");
		addMember(l,128,"ScaleZ");
		addMember(l,224,"Scale");
		addMember(l,256,"AnchorMinX");
		addMember(l,512,"AnchorMinY");
		addMember(l,768,"AnchorMin");
		addMember(l,1024,"AnchorMaxX");
		addMember(l,2048,"AnchorMaxY");
		addMember(l,3072,"AnchorMax");
		addMember(l,3840,"Anchors");
		addMember(l,4096,"SizeDeltaX");
		addMember(l,8192,"SizeDeltaY");
		addMember(l,12288,"SizeDelta");
		addMember(l,16384,"PivotX");
		addMember(l,32768,"PivotY");
		addMember(l,49152,"Pivot");
		addMember(l,-1,"All");
		LuaDLL.lua_pop(l, 1);
	}
}
