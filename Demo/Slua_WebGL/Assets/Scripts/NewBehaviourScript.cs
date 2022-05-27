using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SLua;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update

    LuaSvr l;
    LuaTable self;
    LuaFunction update;

    void Start()
    {
        Debug.LogError("=====NoStart======");
        l = new LuaSvr();
        l.init(null, () => {
            LuaSvr.mainState.doString("print('=========lua hello world===')");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
