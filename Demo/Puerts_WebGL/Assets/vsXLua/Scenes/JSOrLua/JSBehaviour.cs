using UnityEngine;
using UnityEngine.UI;
using System;
using Puerts;

public class JSBehaviour : MonoBehaviour
{   
    public virtual string ScriptName { get; }

    public Action ScriptOnDestroy = null;

    void OnDestroy()
    {
        if (ScriptOnDestroy != null) ScriptOnDestroy();
    }
    
}