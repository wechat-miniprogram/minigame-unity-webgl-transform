using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxWithLua : LuaBehaviour
{
    public static int TotalBoxCount = 0;

    public Transform target;

    public override string ScriptName
    {
        get { return "box.lua"; }
    }

    void Start()
    {
        ScriptBehaviourManager.InvokeStarter(this, this.ScriptName);
    }

    void Update()
    {
        ScriptBehaviourManager.InvokeUpdate(this);
    }
}
