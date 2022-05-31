using UnityEngine;
using SLua;

public class MultiState : MonoBehaviour {

	LuaSvr svr;
	LuaState[] ls=new LuaState[10];
    LuaFunction update;
    LuaTable self;
	// Use this for initialization
	void Start () {
		svr = new LuaSvr ();
		svr.init (null, complete);
	}

	void complete() {
		// create 10 lua state
		for (int n = 0; n < 10; n++) {
			ls[n] = new LuaState ();

            ls[n].Name = (string.Format("LuaState {0}", n));
			ls[n].doString (string.Format ("print('this is #{0} lua state')", n));

			ls[n].openSluaLib();
			ls[n].doString(@"
            local n=0 
            LuaTimer.Add(0,1000,
                function() print('timer print '..tostring(n)) 
                n=n+1
                return true 
            end)");
		}
        ls[0].bindUnity();

        ls[0].doFile("circle/circle");
        self = (LuaTable)ls[0].run("main");
		update = (LuaFunction)self["update"];
	}
	
	// Update is called once per frame
	void Update () {
		if (update != null) update.call(self);
	}

	void OnDestroy() {
		for (int n = 0; n < 10; n++) {
            if(ls[n]!=null)
			    ls [n].Dispose ();
		}
	}
}
