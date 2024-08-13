using System;
using System.Collections.Generic;
using Puerts;
using Puerts.TSLoader;
using UnityEngine;
using XLua;

public class ScriptBehaviourManager
{
    protected static LuaEnv luaEnv;
    protected static JsEnv jsEnv;

    private static Dictionary<Type, Action> callbacks = new Dictionary<Type, Action>();

    public static void AddUpdate(Type mbType, Action callback)
    {
        Action _callback;
        if (callbacks.TryGetValue(mbType, out _callback))
        {
            _callback += callback;
            callbacks[mbType] = _callback;
        }
        else
        {
            callbacks.Add(mbType, callback);
            lastUpdateFrameCounts.Add(mbType, 0);
        }
    }

    static Dictionary<Type, int> lastUpdateFrameCounts = new Dictionary<Type, int>();

    public static void InvokeUpdate<T>(T mb)
        where T : MonoBehaviour
    {
        Action _callback;
        var mbType = typeof(T);
        if (callbacks.TryGetValue(mbType, out _callback))
        {
            if (lastUpdateFrameCounts[mbType] != UnityEngine.Time.frameCount)
            {
                _callback();
                lastUpdateFrameCounts[mbType] = UnityEngine.Time.frameCount;
            }
        }
    }

    private static Dictionary<Type, Action<MonoBehaviour>> starters =
        new Dictionary<Type, Action<MonoBehaviour>>();

    public static void InvokeStarter<T>(T mb, string ScriptName)
        where T : MonoBehaviour
    {
        if (ScriptName == "" || ScriptName == null)
            throw new Exception("ScriptName is empty");

        Action<MonoBehaviour> starter;
        var mbType = typeof(T);
        if (!starters.TryGetValue(mbType, out starter))
        {
            if (typeof(LuaBehaviour).IsAssignableFrom(mbType))
            {
                if (luaEnv == null)
                    luaEnv = new XLua.LuaEnv();
                var scriptEnv = luaEnv.NewTable();
                LuaTable meta = luaEnv.NewTable();
                meta.Set("__index", luaEnv.Global);
                scriptEnv.SetMetaTable(meta);
                meta.Dispose();

                luaEnv.DoString(Resources.Load<TextAsset>(ScriptName).text, ScriptName, scriptEnv);
                starter = scriptEnv.Get<Action<MonoBehaviour>>("start");
            }
            else
            {
                if (jsEnv == null)
                {
                    var loader = new TSLoader(
                        System.IO.Path.Combine(Application.dataPath, "../Puer-Project/out")
                    );
                    jsEnv = Puerts.WebGL.MainEnv.Get(loader);
                }
                starter = jsEnv.ExecuteModule<Action<MonoBehaviour>>(ScriptName, "default");
            }
            starters.Add(typeof(T), starter);
        }
        starter(mb);
    }
}
