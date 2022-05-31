using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Search_SearchViewFlags : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.Search.SearchViewFlags");
		addMember(l,0,"None");
		addMember(l,16,"Debug");
		addMember(l,32,"NoIndexing");
		addMember(l,256,"Packages");
		addMember(l,2048,"OpenLeftSidePanel");
		addMember(l,4096,"OpenInspectorPreview");
		addMember(l,8192,"Centered");
		addMember(l,16384,"HideSearchBar");
		addMember(l,32768,"CompactView");
		addMember(l,65536,"ListView");
		addMember(l,131072,"GridView");
		addMember(l,262144,"TableView");
		addMember(l,524288,"EnableSearchQuery");
		addMember(l,1048576,"DisableInspectorPreview");
		addMember(l,2097152,"DisableSavedSearchQuery");
		addMember(l,4194304,"OpenInBuilderMode");
		addMember(l,8388608,"OpenInTextMode");
		addMember(l,16777216,"DisableBuilderModeToggle");
		LuaDLL.lua_pop(l, 1);
	}
}
