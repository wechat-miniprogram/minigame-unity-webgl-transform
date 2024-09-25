using System;
using Puerts;
using UnityEngine;
using UnityEngine.UI;

public class JSBehaviour : MonoBehaviour
{
    public virtual string ScriptName { get; }

    public Action ScriptOnDestroy = null;

    void OnDestroy()
    {
        if (ScriptOnDestroy != null)
            ScriptOnDestroy();
    }
}
