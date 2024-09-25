using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartInit : MonoBehaviour
{
    IEnumerator StartInit()
    {
        yield return AssetBundleLoad.Init();
        Init();
    }

    protected void Awake()
    {
        Instance = this;

        //        AssetBundleLoad.Init();
        //        Init();
        StartCoroutine(StartInit());

#if UNITY_5_4_OR_NEWER
        SceneManager.sceneLoaded += OnSceneLoaded;
#endif
    }
}
