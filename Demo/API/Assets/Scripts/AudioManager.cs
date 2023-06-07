using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using WeChatWASM;

public class AudioManager : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip AudioClipLong;
    public AudioClip AudioClipShort;

    public void PlayLong()
    {
        AudioSource.clip = AudioClipLong;
        AudioSource.loop = true;
        AudioSource.Play();
    }

    public void PlayShort()
    {
        AudioSource.clip = AudioClipShort;
        AudioSource.loop = false;
        AudioSource.Play();
    }

    public void Pause()
    {
        AudioSource.Pause();
    }

    public void Resume()
    {
        AudioSource.UnPause();
    }

    public void Stop()
    {
        AudioSource.Stop();
    }
}
