using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabBase : MonoBehaviour
{
    public static List<PrefabBase> instances = new List<PrefabBase>();

    public PrefabBase()
        : base()
    {
        instances.Add(this);
    }

    public virtual void ManualUpdate() { }

    public virtual void ManualFixedUpdate() { }
}
