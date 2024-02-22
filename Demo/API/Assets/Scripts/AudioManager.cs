using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Networking;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClipLong;
    public AudioClip audioClipShort;
    private AudioClip audioClipCDN;


    void Start()
    {
        StartCoroutine(LoadCDNAudio());
    }

    IEnumerator LoadCDNAudio()
    {
        string uriString = "https://res.wx.qq.com/wechatgame/product/webpack/userupload/20220901/211827/CallMeTeenTop.mp3";
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
            audioSource.loop = false;
            audioSource.Play();
        }
    }

    public void PlayLong()
    {
        if (audioClipLong != null)
        {
            audioSource.clip = audioClipLong;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void PlayShort()
    {
        if (audioClipShort != null)
        {
            audioSource.clip = audioClipShort;
            audioSource.loop = false;
            audioSource.Play();
        }
    }

    public void Pause()
    {
        audioSource.Pause();
    }

    public void Resume()
    {
        audioSource.UnPause();
    }

    public void Stop()
    {
        audioSource.Stop();
    }
}
