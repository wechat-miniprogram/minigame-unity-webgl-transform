using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_RuntimePlatform : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.RuntimePlatform");
		addMember(l,0,"OSXEditor");
		addMember(l,1,"OSXPlayer");
		addMember(l,2,"WindowsPlayer");
		addMember(l,3,"OSXWebPlayer");
		addMember(l,4,"OSXDashboardPlayer");
		addMember(l,5,"WindowsWebPlayer");
		addMember(l,7,"WindowsEditor");
		addMember(l,8,"IPhonePlayer");
		addMember(l,9,"PS3");
		addMember(l,10,"XBOX360");
		addMember(l,11,"Android");
		addMember(l,12,"NaCl");
		addMember(l,13,"LinuxPlayer");
		addMember(l,15,"FlashPlayer");
		addMember(l,16,"LinuxEditor");
		addMember(l,17,"WebGLPlayer");
		addMember(l,18,"MetroPlayerX86");
		addMember(l,18,"WSAPlayerX86");
		addMember(l,19,"MetroPlayerX64");
		addMember(l,19,"WSAPlayerX64");
		addMember(l,20,"MetroPlayerARM");
		addMember(l,20,"WSAPlayerARM");
		addMember(l,21,"WP8Player");
		addMember(l,22,"BlackBerryPlayer");
		addMember(l,22,"BB10Player");
		addMember(l,23,"TizenPlayer");
		addMember(l,24,"PSP2");
		addMember(l,25,"PS4");
		addMember(l,26,"PSM");
		addMember(l,27,"XboxOne");
		addMember(l,28,"SamsungTVPlayer");
		addMember(l,30,"WiiU");
		addMember(l,31,"tvOS");
		addMember(l,32,"Switch");
		addMember(l,33,"Lumin");
		addMember(l,34,"Stadia");
		addMember(l,35,"CloudRendering");
		addMember(l,36,"GameCoreScarlett");
		addMember(l,36,"GameCoreXboxSeries");
		addMember(l,37,"GameCoreXboxOne");
		addMember(l,38,"PS5");
		addMember(l,39,"EmbeddedLinuxArm64");
		addMember(l,40,"EmbeddedLinuxArm32");
		addMember(l,41,"EmbeddedLinuxX64");
		addMember(l,42,"EmbeddedLinuxX86");
		addMember(l,43,"LinuxServer");
		addMember(l,44,"WindowsServer");
		addMember(l,45,"OSXServer");
		LuaDLL.lua_pop(l, 1);
	}
}
