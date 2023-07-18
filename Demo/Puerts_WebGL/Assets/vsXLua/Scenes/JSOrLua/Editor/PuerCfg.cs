using Puerts;
using System;
using System.Collections.Generic;

[Configure]
public class PuerCfg {
    [Binding]
    public static List<Type> types {
        get {
            return new List<Type>{
                typeof(UnityEngine.Vector3),
                typeof(UnityEngine.Vector2),
                typeof(UnityEngine.Quaternion),
                typeof(UnityEngine.Random),
                typeof(UnityEngine.Transform),
                typeof(UnityEngine.GameObject),
                typeof(UnityEngine.Object),
                typeof(UnityEngine.Time),
                typeof(UnityEngine.UI.Text),
                typeof(UnityEngine.Application),
                typeof(UnityEngine.MonoBehaviour),
                typeof(UnityEngine.Behaviour),
                typeof(UnityEngine.Component),
                typeof(System.Delegate),
                typeof(Puerts.TSLoader.TSLoader),
                typeof(Puerts.DefaultLoader),
                typeof(Joystick), 
                typeof(GameWithJS),
                typeof(BoxWithJS),
                typeof(JSBehaviour),
                typeof(ScriptBehaviourManager)
            };
        }
    }

    [Filter]
    public static bool Filter(System.Reflection.MemberInfo mb) 
    {
        if (mb.DeclaringType == typeof(UnityEngine.MonoBehaviour) && mb.Name == "runInEditMode") {
            return true;
        }
        if (mb.DeclaringType == typeof(UnityEngine.UI.Text) && mb.Name == "OnRebuildRequested") {
            return true;
        }
        return false;
    }
}