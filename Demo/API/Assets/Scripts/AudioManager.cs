using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeChatWASM;

public class AudioManager : MonoBehaviour
{
    // cdn路径音频最多支持10个同时在线播放，先下载后的音频（needDownload）最多支持32个同时播放，先初始化10个
    private static int DEFAULT_AUDIO_COUNT = 10;

    // 创建音频队列
    private static Queue<WXInnerAudioContext> audioPool = new Queue<WXInnerAudioContext>();

    // 当前场景需要预下载的音频列表
    private static string[] audioList = {
        "https://res.wx.qq.com/wechatgame/product/webpack/userupload/20220901/211827/CallMeTeenTop.mp3",
        "https://res.wx.qq.com/wechatgame/product/webpack/userupload/20220815/105451/1.mp3",
        "https://res.wx.qq.com/wechatgame/product/webpack/userupload/20220901/211846/Night-n.mp3",
        "https://res.wx.qq.com/wechatgame/product/webpack/userupload/20220901/211854/Origin-o.mp3",
        "https://res.wx.qq.com/wechatgame/product/webpack/userupload/20220901/211905/Seoul-Night-SN.mp3",
    };

    // 正在播放的音频对象列表
    private static List<WXInnerAudioContext> audioPlayArray = new List<WXInnerAudioContext>();

    private bool isDestroyed = false;

    // 初始化
    public void Start()
    {
        // 创建音频对象池，创建时设置属性需要下载
        for (var i = 0; i < DEFAULT_AUDIO_COUNT; i++)
        {
            addAudio();
        };

        // 批量下载音频文件
        downloadAudio();

        // 先下载后播放第3个音频
        playAfterDownload(2);

        // 立即播放（但不会缓存到本地）第1个音频
        playRightNow(0);
    }

    private WXInnerAudioContext getAudio()
    {
        if (this.isDestroyed) {
            return null;
        }

        if (audioPool.Count == 0)
        {
            addAudio();
        }

        var audio = audioPool.Dequeue();

        audioPlayArray.Add(audio);

        return audio;
    }

    private void removeAudio(WXInnerAudioContext audio)
    {
        if (audioPlayArray.Contains(audio))
        {
            audio.OffCanplay();
            audioPlayArray.Remove(audio);
            audioPool.Enqueue(audio);
        }
    }

    private WXInnerAudioContext addAudio()
    {
        var audio = WX.CreateInnerAudioContext(new InnerAudioContextParam() { needDownload = true });

        // 自动播放停止
        audio.OnEnded(() =>
        {
            removeAudio(audio);
        });

        // 加载出错
        audio.OnError(() =>
        {
            removeAudio(audio);
        });

        // 手动停止
        audio.OnStop(() =>
        {
            removeAudio(audio);
        });

        audioPool.Enqueue(audio);

        return audio;
    }

    private void downloadAudio()
    {
        // 预下载音频
        WX.PreDownloadAudios(audioList, (int res) =>
        {
            if (res == 0)
            {
                // 下载成功

                // 下载后播放第2个音频
                playAfterDownload(1);
            }
            else
            {
                // 下载失败
            }
        });
    }

    public void playAfterDownload(int index)
    {
        var audioIndex = getAudio();

        if (audioIndex == null) {
            return;
        }

        // 如果没有下文修改needDownload为false的函数，理论上创建的所有音频都是true，可以省去这一条
        audioIndex.needDownload = true;

        // 对于已经设置了needDownload为true的audio，设置src后就会开始下载对应的音频文件
        // 如果该文件已经下载过，并且配置了缓存本地，就不会重复下载
        // 如果该文件没有下载过，等同于先调用WX.PreDownloadAudios下载后再播放
        audioIndex.src = audioList[index];

        // 在可以播放时播放
        audioIndex.OnCanplay(() =>
        {
            audioIndex.Play();
        });
    }

    public void playRightNow(int index)
    {
        // 如果是需要在当前场景立刻播放的音频，则不设置needDownload，音频会边下边播
        // 但是再次使用该音频时会因为没有下载而需要再次下载，并不推荐这样使用
        var audioPlayRightNow = getAudio();

        if (audioPlayRightNow == null) {
            return;
        }

        // 修改src会触发下载，所以设置needDownload属性要在修改src之前
        audioPlayRightNow.needDownload = false;

        // 如果当前音频已经下载过，并且配置了缓存本地，就算设置needDownload为false也不会重复下载
        audioPlayRightNow.src = audioList[index];

        // 在可以播放时播放
        audioPlayRightNow.OnCanplay(() =>
        {
            audioPlayRightNow.Play();
        });
    }

    public void stopAllAudio()
    {
        audioPlayArray.ForEach(audio => {
            audio.OffCanplay();
            audio.Stop();
        });
    }

    public void playRandom()
    {
        var index = new System.Random().Next(0, audioList.Length);
        Debug.Log("Play:" + index);
        Debug.Log("PlayAudioLength:" + audioPlayArray.Count);

        playRightNow(index);
    }

    private void OnDestroy()
    {
        this.isDestroyed = true;
        this.stopAllAudio();
    }
}