using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using LuaInterface;
using UnityEngine;

public class AssetBundleLoad
{

    public static IEnumerator Init()
    {

#if UNITY_WEBGL && !UNITY_EDITOR
        string[] luaAb = new[]
        {
            "lua.unity3d", "lua_cjson.unity3d", "lua_jit.unity3d",
            "lua_lpeg.unity3d", "lua_misc.unity3d", "lua_protobuf.unity3d", "lua_socket.unity3d", "lua_system.unity3d",
            "lua_system_injection.unity3d", "lua_system_reflection.unity3d", "lua_unityengine.unity3d"
        };
        
#elif UNITY_EDITOR
        string[] luaAb = Directory.GetFiles(Application.streamingAssetsPath, "*.unity3d", SearchOption.AllDirectories);
#endif
        foreach (var name in luaAb)
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            Debug.Log("luaAbs:luna");
             WWW www =WWW.LoadFromCacheOrDownload(Application.streamingAssetsPath+"/"+name,0);
             yield return www;
             AssetBundle bundle =www.assetBundle;
#elif UNITY_EDITOR
            AssetBundle bundle = AssetBundle.LoadFromFile(name);
#endif
            string[] luaFiles = bundle.GetAllAssetNames();
            for (int i = 0; i < luaFiles.Length; ++i)
            {
                string bundname = luaFiles[i].Substring(0, luaFiles[i].LastIndexOf("/")).Replace("assets/temp/", "")
                    .Replace("/", "_");
                LuaFileUtils.Instance.AddSearchBundle(bundname, bundle);
            }
        }

        #if UNITY_WEBGL && !UNITY_EDITOR
            WWW www2 =WWW.LoadFromCacheOrDownload(Application.streamingAssetsPath+"/StreamingAssets",0);
            yield return www2;
            var manifest = www2.assetBundle;
            Debug.Log("manifest:" + manifest);
        #endif

        #if UNITY_EDITOR
            var manifest = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/StreamingAssets");
            Debug.Log("manifest:" + manifest);
        #endif
        yield break;
    }
}