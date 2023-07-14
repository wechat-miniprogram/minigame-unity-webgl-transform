using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Puerts.TSLoader;
using Puerts;

[XLua.LuaCallCSharp]
public class PerformanceHelper
{
    public static int ReturnNumber(int num)
    {
        return num;
    }
    public static Vector3 ReturnVector(int x, int y, int z)
    {
        return new Vector3(x, y, z);
    }

    public static Text JSNumber;
    public static Text JSVector;
    public static Text JSFibonacci;
    public static Text LuaNumber;
    public static Text LuaVector;
    public static Text LuaFibonacci;
}

public class Performance : MonoBehaviour
{
    public Text JSNumber;
    public Text JSVector;
    public Text JSFibonacci;
    public Text LuaNumber;
    public Text LuaVector;
    public Text LuaFibonacci;
    public Text CSFibonacci;

    public static DateTime ZERO = new DateTime(1970, 1, 1, 0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        PerformanceHelper.JSNumber = JSNumber;
        PerformanceHelper.JSVector = JSVector;
        PerformanceHelper.JSFibonacci = JSFibonacci;
        PerformanceHelper.LuaNumber = LuaNumber;
        PerformanceHelper.LuaVector = LuaVector;
        PerformanceHelper.LuaFibonacci = LuaFibonacci;

        Puerts.JsEnv JsEnv = Puerts.WebGL.MainEnv.Get(new TSLoader());
        JsEnv.ExecuteModule("performance.mjs");
        
        XLua.LuaEnv env = new XLua.LuaEnv();
        env.DoString(Resources.Load<TextAsset>("performance.lua").text);

        var start = (DateTime.Now - ZERO).TotalMilliseconds;
        for (int i = 0; i < 100000; i++) {
            fibonacci(12);
        }
        double csTime = (DateTime.Now - ZERO).TotalMilliseconds - start;
        CSFibonacci.text = "CS Fibonacci:" + Math.Round(csTime) + " ms";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    int fibonacci(int level) {
        if (level == 0) return 0;
        if (level == 1) return 1;
        return fibonacci(level - 1) + fibonacci(level - 2);
    }
}
