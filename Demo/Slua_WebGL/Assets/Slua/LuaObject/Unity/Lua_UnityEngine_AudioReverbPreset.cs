using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AudioReverbPreset : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.AudioReverbPreset");
		addMember(l,0,"Off");
		addMember(l,1,"Generic");
		addMember(l,2,"PaddedCell");
		addMember(l,3,"Room");
		addMember(l,4,"Bathroom");
		addMember(l,5,"Livingroom");
		addMember(l,6,"Stoneroom");
		addMember(l,7,"Auditorium");
		addMember(l,8,"Concerthall");
		addMember(l,9,"Cave");
		addMember(l,10,"Arena");
		addMember(l,11,"Hangar");
		addMember(l,12,"CarpetedHallway");
		addMember(l,13,"Hallway");
		addMember(l,14,"StoneCorridor");
		addMember(l,15,"Alley");
		addMember(l,16,"Forest");
		addMember(l,17,"City");
		addMember(l,18,"Mountains");
		addMember(l,19,"Quarry");
		addMember(l,20,"Plain");
		addMember(l,21,"ParkingLot");
		addMember(l,22,"SewerPipe");
		addMember(l,23,"Underwater");
		addMember(l,24,"Drugged");
		addMember(l,25,"Dizzy");
		addMember(l,26,"Psychotic");
		addMember(l,27,"User");
		LuaDLL.lua_pop(l, 1);
	}
}
