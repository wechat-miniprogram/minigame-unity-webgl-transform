using UnityEngine;
using UnityEngine.UI;
using System;
using XLua;

public class LuaBehaviour : MonoBehaviour
{   
    public virtual string ScriptName { get; }

    public static Action ScriptUpdate = null;
    public Action ScriptOnDestroy = null;

    static LuaEnv env;

    void Start()
    {
        if (env == null) env = new LuaEnv();
        if (ScriptName == "" || ScriptName == null) throw new Exception("ScriptName is empty");

        var scriptEnv = env.NewTable();
        LuaTable meta = env.NewTable();
        meta.Set("__index", env.Global);
        scriptEnv.SetMetaTable(meta);
        meta.Dispose();

        scriptEnv.Set("mb", this);
        env.DoString(Resources.Load<TextAsset>(this.ScriptName).text, this.ScriptName, scriptEnv);
    }

    static int lastUpdateFrameCount = 0;
    void Update()
    {
        if (lastUpdateFrameCount != UnityEngine.Time.frameCount)
        {
            env.Tick();
            if (ScriptUpdate != null) ScriptUpdate();
        }
    }
    void OnDestroy()
    {
        if (ScriptOnDestroy != null) ScriptOnDestroy();
    }
}