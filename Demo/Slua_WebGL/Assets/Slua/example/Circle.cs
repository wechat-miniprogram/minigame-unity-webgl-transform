using UnityEngine;
using System.Collections;
using SLua;
using System;

public class Circle : MonoBehaviour {


	LuaSvr svr;
	LuaTable self;
	LuaFunction update;

    [CustomLuaClass]
    public delegate void UpdateDelegate(object self);

    UpdateDelegate ud;

	void Start () {
		svr = new LuaSvr();
		svr.init(null, () =>
		{
			self = (LuaTable)svr.start("circle/circle");
            update = (LuaFunction)self["update"] ;
            ud = update.cast<UpdateDelegate>();
		});
	}
	
	void Update () {
        if (ud != null) ud(self);
	}
}
