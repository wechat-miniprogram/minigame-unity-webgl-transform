using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Puerts;
using Puerts.TSLoader;

public class JsMonoBehaviour : MonoBehaviour
{
    static JsEnv env;

    public string JSClassName;

    // Start is called before the first frame update
    public Action JsStart;
    void Start()
    {
        if (env == null) {
            env = Puerts.WebGL.MainEnv.Get(new TSLoader(), 9222);
        }
        
        Action<JsMonoBehaviour> init = env.ExecuteModule<Action<JsMonoBehaviour>>("entry.mjs", JSClassName);
        init(this);
        if (JsStart!= null) JsStart();
    }

    // Update is called once per frame
    public Action JsUpdate;
    void Update()
    {
        if (env == null) return;
        env.Tick();
        if (JsUpdate!= null) JsUpdate();
    }

    public Action<Collider> JsOnTriggerEnter;
    void OnTriggerEnter(Collider other) {
        if (JsOnTriggerEnter != null) JsOnTriggerEnter(other);
    }
}
