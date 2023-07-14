using System.Collections.Generic;
using Puerts;
using System;
using UnityEngine;

[Configure]
public class PuertsTestCfg
{
    [Binding]
    static IEnumerable<Type> Bindings
    {
        get
        {
            return new List<Type>()
            {
                typeof(PerformanceHelper),
                typeof(System.Type),
                typeof(UnityEngine.UI.Text),
            };
        }
    }

    [BlittableCopy]
    static IEnumerable<Type> Blittables
    {
        get
        {
            return new List<Type>()
            {
                //打开这个可以优化Vector3的GC，但需要开启unsafe编译
                typeof(UnityEngine.Vector3),
            };
        }
    }

    [Filter]
    public static bool F(System.Reflection.MemberInfo mi) 
    {
        if (mi.Name == "SetLightDirty" || mi.Name == "shadowAngle" || mi.Name == "Radius") return true;
        if (mi.Name == "MakeGenericSignatureType" || mi.Name == "IsCollectible" || mi.Name == "OnRebuildRequested") return true;
        return false;
    }

    [XLua.BlackList]
    public static List<List<string>> BlackList = new List<List<string>> {
        new List<string>() { "UnityEngine.Light", "shadowRadius"},
        new List<string>() { "UnityEngine.Light", "shadowAngle"},
        new List<string>() { "UnityEngine.Light", "SetLightDirty"},
    };
}