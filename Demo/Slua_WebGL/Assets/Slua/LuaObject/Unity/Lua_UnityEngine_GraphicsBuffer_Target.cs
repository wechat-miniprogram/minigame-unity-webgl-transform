using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_GraphicsBuffer_Target : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.GraphicsBuffer.Target");
		addMember(l,1,"Vertex");
		addMember(l,2,"Index");
		addMember(l,4,"CopySource");
		addMember(l,8,"CopyDestination");
		addMember(l,16,"Structured");
		addMember(l,32,"Raw");
		addMember(l,64,"Append");
		addMember(l,128,"Counter");
		addMember(l,256,"IndirectArguments");
		addMember(l,512,"Constant");
		LuaDLL.lua_pop(l, 1);
	}
}
