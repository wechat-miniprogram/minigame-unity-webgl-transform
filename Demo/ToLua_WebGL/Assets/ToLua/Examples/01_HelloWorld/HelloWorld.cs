using System;
using LuaInterface;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    void Awake()
    {
        LuaState lua = new LuaState();
        lua.Start();
        string hello =
            @"                
                print('hello tolua#')                                  
            ";

        lua.DoString(hello, "HelloWorld.cs");
        lua.CheckTop();
        lua.Dispose();
        lua = null;
    }
}
