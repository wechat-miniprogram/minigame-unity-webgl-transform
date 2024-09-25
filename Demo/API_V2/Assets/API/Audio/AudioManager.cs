using UnityEngine;
using UnityEngine.Networking;

public class AudioManager : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip AudioClipLong;
    public AudioClip AudioClipShort;

    // 播放长音频并循环播放
    public void PlayLong()
    {
        AudioSource.clip = AudioClipLong;
        AudioSource.loop = true;
        AudioSource.Play();
    }

    // 播放短音频（不循环）
    public void PlayShort()
    {
        AudioSource.clip = AudioClipShort;
        AudioSource.loop = false;
        AudioSource.Play();
    }

    // 暂停音频播放
    public void Pause()
    {
        AudioSource.Pause();
    }

    // 恢复音频播放
    public void Resume()
    {
        AudioSource.UnPause();
    }

    // 停止音频播放
    public void Stop()
    {
        AudioSource.Stop();
    }

    public void playDelayed()
    {
        AudioSource.clip = AudioClipLong;
        AudioSource.loop = true;
        AudioSource.PlayDelayed(3);
    }
}
