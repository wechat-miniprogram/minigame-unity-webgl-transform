using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using WeChatWASM;

public class AdWithAudio : Details
{
    private WXRewardedVideoAd _rewardedVideoAd;
    public AudioSource audioSource;
    public AudioClip audioClipCDN;

    private void Start()
    {
        StartCoroutine(LoadCDNAudio());

        // 创建激励视频广告组件
        _rewardedVideoAd = WX.CreateRewardedVideoAd(
            new WXCreateRewardedVideoAdParam()
            {
                // adUnitId 请填写自己的广告位 ID
                adUnitId = "adunit-881d549c5a14a7e3"
            }
        );

        _rewardedVideoAd.OnError(err =>
        {
            Debug.Log(JsonUtility.ToJson(err));
        });

        GameManager.Instance.detailsController.BindExtraButtonAction(0, PlayCDN);
    }

    // 创建激励视频广告组件并挂载事件、预加载广告
    protected override void TestAPI(string[] args)
    {
        ShowAd();
    }

    IEnumerator LoadCDNAudio()
    {
        // 创建一个新的游戏对象
        GameObject newGameObject = new GameObject("New GameObject");

        // 添加 AudioSource 组件
        audioSource = newGameObject.AddComponent<AudioSource>();

        string uriString =
            "https://res.wx.qq.com/wechatgame/product/webpack/userupload/20220901/211827/CallMeTeenTop.mp3";
        Uri uri = new Uri(uriString);
        UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(uri, AudioType.MPEG);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            audioClipCDN = DownloadHandlerAudioClip.GetContent(request);
            // yield return new WaitUntil(() => audioClipCDN.loadState == AudioDataLoadState.Loaded);
            // Debug.Log("audioClipCDN loaded, clip length: " + audioClipCDN.length);
        }
        else
        {
            Debug.Log("request error: " + request.error);
        }
    }

    public void PlayCDN()
    {
        if (audioClipCDN != null)
        {
            audioSource.clip = audioClipCDN;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    // 展示广告
    private void ShowAd()
    {
        _rewardedVideoAd.Show(
            res =>
            {
                Debug.Log("Show success");
                Debug.Log(JsonUtility.ToJson(res));
            },
            err =>
            {
                Debug.Log(JsonUtility.ToJson(err));
                _rewardedVideoAd.Load(
                    res =>
                    {
                        Debug.Log("load success");
                        _rewardedVideoAd.Show();
                    },
                    err =>
                    {
                        Debug.Log("load fail");
                        Debug.Log(JsonUtility.ToJson(err));
                    }
                );
            }
        );
    }

    public void Destroy()
    {
        if (audioSource != null)
        {
            audioSource.clip = null;
            audioSource = null;
        }
    }
}
