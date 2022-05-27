using System;
using UnityEngine;
using WeChatWASM;

class CheckFrame : MonoBehaviour
{
    int frameCnt = 0;
    private void Update()
    {
        frameCnt++;
        if (frameCnt == 2)
        {
            #if UNITY_WEBGL && !UNITY_EDITOR
            WX.HideLoadingPage();
            #endif
            Destroy(this);
        }
    }
}

class HideLoadingPage : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnGameLaunch()
    {
        var gameObject = new GameObject("HideLoadingPage");
        gameObject.AddComponent<CheckFrame>();
        DontDestroyOnLoad(gameObject);
    }
}
