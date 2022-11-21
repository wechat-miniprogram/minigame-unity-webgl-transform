using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeChatWASM;

public class AudioManager : MonoBehaviour
{
    // cdn路径音频最多支持10个同时在线播放，先下载后的音频（needDownload）最多支持32个同时播放，先初始化10个
    //private static int DEFAULT_AUDIO_COUNT = 10;

    // 创建音频对象池，复用对象
    private static Queue<WXInnerAudioContext> audioPool = new Queue<WXInnerAudioContext>();

    // 当前场景需要预下载的音频列表
    private static string[] audioList = {
        // 短音频
        "https://res.wx.qq.com/wechatgame/product/webpack/userupload/20221108/194356/1.mp3",
        "https://res.wx.qq.com/wechatgame/product/webpack/userupload/20221108/194517/2.mp3",
        "https://res.wx.qq.com/wechatgame/product/webpack/userupload/20221108/194523/3.mp3",
        "https://res.wx.qq.com/wechatgame/product/webpack/userupload/20221108/194530/4.mp3",
        "https://res.wx.qq.com/wechatgame/product/webpack/userupload/20221108/194536/5.mp3",
        // 长音频
        "https://res.wx.qq.com/wechatgame/product/webpack/userupload/20220901/211827/CallMeTeenTop.mp3",
        "https://res.wx.qq.com/wechatgame/product/webpack/userupload/20220815/105451/1.mp3",
        "https://res.wx.qq.com/wechatgame/product/webpack/userupload/20220901/211846/Night-n.mp3",
        "https://res.wx.qq.com/wechatgame/product/webpack/userupload/20220901/211854/Origin-o.mp3",
        "https://res.wx.qq.com/wechatgame/product/webpack/userupload/20220901/211905/Seoul-Night-SN.mp3",
    };

    // 正在播放的音频对象列表
    private static List<WXInnerAudioContext> audioPlayArray = new List<WXInnerAudioContext>();

    // 背景音乐
    private WXInnerAudioContext audioBGM = null;

    private bool isDestroyed = false;

    private int createdAudioCount = 0;

    // 初始化
    public void Start()
    {
        // // 创建音频对象池，创建时设置属性需要下载
        // for (var i = 0; i < DEFAULT_AUDIO_COUNT; i++)
        // {
        //     addAudio(false);
        // };

        // 批量下载音频文件
        downloadAudio();
    }

    // 从缓存池中获取音频实例
    // 注意：发现一些偶现的bug，目前不推荐使用！！
    private WXInnerAudioContext getAudio()
    {
        if (this.isDestroyed)
        {
            return null;
        }

        if (audioPool.Count == 0)
        {
            addAudio(false);
        }

        var audio = audioPool.Dequeue();
        audio.needDownload = true;

        if (!audioPlayArray.Contains(audio))
        {
            audioPlayArray.Add(audio);
        }

        return audio;
    }

    // 从缓存池中获取音频实例
    private WXInnerAudioContext createAudio()
    {
        if (this.isDestroyed)
        {
            return null;
        }

        var audio = addAudio(true);

        if (!audioPlayArray.Contains(audio))
        {
            audioPlayArray.Add(audio);
        }

        return audio;
    }

    // 销毁或回收实例
    private void removeAudio(WXInnerAudioContext audio, bool needDestroy = true)
    {
        audio.OffCanplay();
        if (audioPlayArray.Contains(audio))
        {
            audioPlayArray.Remove(audio);
        }
        if (needDestroy)
        {
            if (WXInnerAudioContext.Dict.ContainsValue(audio))
            {
                audio.Destroy();
                createdAudioCount -= 1;
            }
        }
        else
        {
            if (!audioPool.Contains(audio))
            {
                audioPool.Enqueue(audio);
            }
        }

        Debug.Log("___________________");
        Debug.Log("已创建InnerAudio:" + createdAudioCount + " 对象池:" + audioPool.Count + " 正在播放:" + audioPlayArray.Count);
        Debug.Log("___________________");
    }

    // 创建InnerAudioContext实例
    // 参数needDestroy表示是否需要在播放完之后销毁，目前建议都先销毁再创建使用
    private WXInnerAudioContext addAudio(bool needDestroy = true)
    {
        if (createdAudioCount > 32)
        {
            Debug.LogError("最多只支持同时使用32个InnerAudio");
        }

        var audio = WX.CreateInnerAudioContext(new InnerAudioContextParam() { needDownload = true });

        createdAudioCount += 1;

        // 自动播放停止
        audio.OnEnded(() =>
        {
            Debug.Log(audio.instanceId + " OnEnded");
            removeAudio(audio, needDestroy);
        });

        // 加载出错
        audio.OnError(() =>
        {
            Debug.Log(audio.instanceId + "audio OnError");
            audio.Stop();
            removeAudio(audio, needDestroy);
        });

        // 手动停止
        audio.OnStop(() =>
        {
            Debug.Log(audio.instanceId + "audio OnStop");
            removeAudio(audio, needDestroy);
        });

        // 暂停
        audio.OnPause(() =>
        {
            Debug.Log(audio.instanceId + "audio OnPause");
        });

        // 播放成功
        audio.OnPlay(() =>
        {
            Debug.Log(audio.instanceId + "audio OnPlay");
        });

        if (!needDestroy)
        {
            audioPool.Enqueue(audio);
        }

        return audio;
    }

    // 预下载音频
    private void downloadAudio()
    {
        // 预下载音频
        WX.PreDownloadAudios(audioList, (int res) =>
        {
            if (res == 0)
            {
                // 下载成功

                // 下载后播放第2个音频
                // playAfterDownload(1);
            }
            else
            {
                // 下载失败
            }
        });
    }

    // 播放音频
    public void playAfterDownload(int index, bool isShort)
    {
        var audioIndex = createAudio();

        if (audioIndex == null)
        {
            return;
        }

        // 如果要设置的src和原音频对象一致，可以直接播放
        if (audioIndex.src == audioList[index])
        {
            audioIndex.Play();
        }
        else
        {
            // 对于已经设置了needDownload为true的audio，设置src后就会开始下载对应的音频文件
            // 如果该文件已经下载过，并且配置了缓存本地，就不会重复下载
            // 如果该文件没有下载过，等同于先调用WX.PreDownloadAudios下载后再播放
            audioIndex.src = audioList[index];

            // 短音频可以直接调用Play
            if (isShort)
            {
                audioIndex.Play();
            }
            else
            {
                // 长音频在可以播放时播放
                audioIndex.OnCanplay(() =>
                {
                    audioIndex.Play();
                });
            }
        }
    }

    // 不缓存立即播放
    public void playRightNow(int index)
    {
        // 如果是需要在当前场景立刻播放的音频，则不设置needDownload，音频会边下边播
        // 但是再次使用该音频时会因为没有下载而需要再次下载，并不推荐这样使用
        var audioPlayRightNow = createAudio();

        audioPlayRightNow.needDownload = false;

        if (audioPlayRightNow == null)
        {
            return;
        }

        // 如果要设置的src和原音频对象一致，可以直接播放
        if (audioPlayRightNow.src == audioList[index])
        {
            audioPlayRightNow.Play();
        }
        else
        {
            // 如果当前音频已经下载过，并且配置了缓存本地，就算设置needDownload为false也不会重复下载
            audioPlayRightNow.src = audioList[index];

            // 在可以播放时播放
            audioPlayRightNow.OnCanplay(() =>
            {
                audioPlayRightNow.Play();
            });
        }
    }

    // 暂停所有在播放的音乐
    public void pauseAllAudio()
    {
        audioPlayArray.ForEach(audio =>
        {
            audio.Pause();
        });
    }

    // 重新播放所有在播放的音乐
    public void resumeAllAudio()
    {
        audioPlayArray.ForEach(audio =>
        {
            // innerAudio没有resume，直接用play重新播放
            audio.Play();
        });
    }

    // 停止所有在播放的音乐
    public void stopAllAudio()
    {
        audioPlayArray.ForEach(audio =>
        {
            audio.OffCanplay();
            audio.Stop();
        });
    }

    // 播放短音频
    public void playShort()
    {
        var index = new System.Random().Next(0, 5);
        Debug.Log("playShort:" + index);

        playAfterDownload(index, true);
    }

    // 同时播放5个短音频（测试用）
    public void playShort5()
    {
        for (var i = 0; i < 5; i++)
        {
            this.playShort();
        };
    }

    // 播放背景音乐
    public void playBGM()
    {
        var index = new System.Random().Next(5, 10);
        Debug.Log("Play:" + index);

        if (audioBGM != null)
        {
            removeAudio(audioBGM, true);
        }
        // 长音频在使用后需要销毁
        audioBGM = createAudio();
        // audioBGM.loop = true;
        audioBGM.src = audioList[index];
        audioBGM.OnCanplay(() =>
        {
            audioBGM.Play();
        });
        // 自动播放停止
        audioBGM.OnEnded(() =>
        {
            audioBGM = null;
        });
        // 手动停止
        audioBGM.OnStop(() =>
        {
            audioBGM = null;
        });
    }

    // 销毁场景
    private void OnDestroy()
    {
        this.isDestroyed = true;
        this.stopAllAudio();
    }
}