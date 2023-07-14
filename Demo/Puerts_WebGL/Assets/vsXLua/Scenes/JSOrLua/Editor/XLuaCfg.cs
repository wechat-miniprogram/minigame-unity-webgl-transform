using XLua;
using System.Collections.Generic;

public static class XLuaCfg
{
    [BlackList]
    public static List<List<string>> BlackList = new List<List<string>>()  {
        new List<string>(){ "UnityEngine.Resources", "InstanceIDsToValidArray", "System.ReadOnlySpan`1[System.Int32]", "System.Span`1[System.Boolean]"},
        new List<string>(){ "UnityEngine.Transform", "TransformDirections", "System.ReadOnlySpan`1[UnityEngine.Vector3]","System.Span`1[UnityEngine.Vector3]" },
        new List<string>(){ "UnityEngine.Transform", "TransformDirections", "System.Span`1[UnityEngine.Vector3]"},
        new List<string>(){ "UnityEngine.Transform", "InverseTransformDirections", "System.ReadOnlySpan`1[UnityEngine.Vector3]","System.Span`1[UnityEngine.Vector3]" },
        new List<string>(){ "UnityEngine.Transform", "InverseTransformDirections", "System.Span`1[UnityEngine.Vector3]"},
        new List<string>(){ "UnityEngine.Transform", "TransformVectors" , "System.ReadOnlySpan`1[UnityEngine.Vector3]", "System.Span`1[UnityEngine.Vector3]"},
        new List<string>(){ "UnityEngine.Transform", "TransformVectors", "System.Span`1[UnityEngine.Vector3]"},
        new List<string>(){ "UnityEngine.Transform", "InverseTransformVectors", "System.ReadOnlySpan`1[UnityEngine.Vector3]","System.Span`1[UnityEngine.Vector3]" },
        new List<string>(){ "UnityEngine.Transform", "InverseTransformVectors", "System.Span`1[UnityEngine.Vector3]" },
        new List<string>(){ "UnityEngine.Transform", "TransformPoints", "System.ReadOnlySpan`1[UnityEngine.Vector3]", "System.Span`1[UnityEngine.Vector3]" },
        new List<string>(){ "UnityEngine.Transform", "TransformPoints", "System.Span`1[UnityEngine.Vector3]"},
        new List<string>(){ "UnityEngine.Transform", "InverseTransformPoints", "System.ReadOnlySpan`1[UnityEngine.Vector3]","System.Span`1[UnityEngine.Vector3]" },
        new List<string>(){ "UnityEngine.Transform", "InverseTransformPoints", "System.Span`1[UnityEngine.Vector3]"},
        new List<string>(){ "UnityEngine.Light", "SetLightDirty" },
        new List<string>(){ "UnityEngine.Light", "shadowAngle" },
        new List<string>(){ "UnityEngine.Light", "shadowRadius" },
        new List<string>(){ "UnityEngine.Resources", "InstanceIDsToValidArray"},
    };
}