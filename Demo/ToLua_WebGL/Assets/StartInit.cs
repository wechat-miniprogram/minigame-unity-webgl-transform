using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartInit : MonoBehaviour
{


    IEnumerator Init()
    {
        yield return AssetBundleLoad.Init();
        Init();
    }

    protected void Awake()
    {

        //        AssetBundleLoad.Init();
        //        Init();
        StartCoroutine(Init());

//#if UNITY_5_4_OR_NEWER
//        SceneManager.sceneLoaded += OnSceneLoaded;
//#endif        
    }
}
