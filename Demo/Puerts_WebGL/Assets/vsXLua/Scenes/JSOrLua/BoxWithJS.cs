using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Puerts.TSLoader;

public class BoxWithJS : JSBehaviour
{
    public static int TotalBoxCount = 0;
    
    public Transform target;

    public override string ScriptName { get { return "box.mjs"; } }

    void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        positionSetter.x = this.transform.position.x;
        positionSetter.y = this.transform.position.y;
        positionSetter.z = this.transform.position.z;
#endif
        ScriptBehaviourManager.InvokeStarter(this, this.ScriptName);
#if UNITY_WEBGL && !UNITY_EDITOR
        this.transform.position = positionSetter;
        this.transform.rotation = rotationSetter;
#endif
    }
    
    void Update()
    {
        ScriptBehaviourManager.InvokeUpdate(this);
#if UNITY_WEBGL && !UNITY_EDITOR
        this.transform.position = positionSetter;
        this.transform.rotation = rotationSetter;
#endif
    }

    protected Vector3 positionSetter = new Vector3();
    protected Quaternion rotationSetter = new Quaternion();

    public int GetPositionSetterPointer()
    {
        unsafe 
        {
            fixed (Vector3* ptr = &positionSetter)
            {
                return (int)(IntPtr)(ptr);
            }
        }
    }
    public int GetRotationSetterPointer()
    {
        unsafe 
        {
            fixed (Quaternion* ptr = &rotationSetter)
            {
                return (int)(IntPtr)(ptr);
            }
        }
    }
}
