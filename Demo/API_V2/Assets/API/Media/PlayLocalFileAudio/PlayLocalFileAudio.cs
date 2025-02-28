using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using WeChatWASM;

public class PlayLocalFileAudio : Details
{
    public AudioSource audioSource;
    public AudioClip currentAudioClip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void DownloadFileAudio()
    {
        WX.DownloadFile(new DownloadFileOption()
        {
            url = "https://res.wx.qq.com/wechatgame/product/webpack/userupload/20220901/211827/CallMeTeenTop.mp3",
            success = (res) =>
            {
                Debug.Log("WX.DownloadFile success");
                if (res.statusCode == 200)
                {
                    Debug.Log(res.tempFilePath);
                    var fs = WX.GetFileSystemManager();
                    var filePath = fs.SaveFileSync(res.tempFilePath, WX.env.USER_DATA_PATH + "/CallMeTeenTop.mp3");
                    StartCoroutine(LoadAndPlayAudio(filePath));
                }
            },
            fail = (res) =>
            {
                Debug.Log("WX.DownloadFile fail");
            },
            complete = (res) =>
            {
                Debug.Log("WX.DownloadFile complete");
            }
        });
    }

    IEnumerator LoadAndPlayAudio(string localFilePath)
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(new Uri(localFilePath), AudioType.MPEG))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(www.error);
            }
            else
            {
                AudioClip audioClip = DownloadHandlerAudioClip.GetContent(www);

                audioSource.clip = audioClip;
                audioSource.Play();
            }
        }
    }
    private void CleanupAudio()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
            audioSource.clip = null;
        }

        if (currentAudioClip != null)
        {
            Destroy(currentAudioClip);
            currentAudioClip = null;
        }
    }
    protected override void TestAPI(string[] args)
    {
        DownloadFileAudio();
    }

    private void OnDestroy()
    {
        CleanupAudio();
    }
}