# 为何需要音频优化

1. Unity2021 版本之前的音频不支持压缩音频，在引擎 CPU 侧解压会消耗大量内存
2. iOS 高性能模式下，Unity WebGL 默认使用 WebAudio 会消耗游戏进程大量内存(特别是时长较大的音频)

我们建议将 Unity Audio 替换成 SDK 中的音频 API 控制播放。如果工作量太大，也建议替换长音频(如 BGM)。

## API 使用

### 接口使用

参考[微信开发者文档](https://developers.weixin.qq.com/minigame/dev/api/media/audio/InnerAudioContext.html)

## 参考示例
```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeChatWASM;

public class AudioManager : MonoBehaviour
{
    // cdn路径音频最多支持10个同时在线播放，先下载后的音频（needDownload）最多支持32个同时播放，先初始化10个
    private static int DEFAULT_AUDIO_COUNT = 10;

    // 创建音频队列
    private Queue<WXInnerAudioContext> audioPool = new Queue<WXInnerAudioContext>();

    // 当前场景需要预下载的音频列表
    private string[] audioList = {
        "https://xxxxxx.mp3",
        "https://xxxxxx.mp3",
        "https://xxxxxx.mp3",
    };

    // 正在播放的音频对象列表
    private List<WXInnerAudioContext> audioPlayArray = new List<WXInnerAudioContext>();

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
        audioPlayArray.ForEach(audio => audio.Stop());
    }
}
```

## 示例补充说明
- 示例只是作为参考，可以不按照示例，以开发者文档为准
- WX.CreateInnerAudioContext 返回的音频对象是可以复用的，可以多次调用 Play 方法播放，但是如果需要多个音频同时播放就要创建多个音频对象。
- 其中音频 src 为音频地址，可填本地路径如 Audios/xx.wav，运行时会自动和配置的音频地址前缀(默认为 DATA_CDN/Assets)做拼接得到最终线上地址。
- 音频需要等待`onCanplay`事件之后再调用`Play`播放。onCanplay 事件是表示，当前音频已经可以播了，

## 保存文件到本地

在使用 WX.CreateInnerAudioContext 时设置了 needDownload 属性或者使用 WX.PreDownloadAudios 下载音频时，会自动把符合[自动缓存规则](https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/blob/main/Design/FileCache.md#%E4%BA%8C%E5%93%AA%E4%BA%9B%E8%B5%84%E6%BA%90%E4%BC%9A%E8%87%AA%E5%8A%A8%E7%BC%93%E5%AD%98)的文件保存到本地，下次启动游戏时可以无需下载

## 导出设置

勾选使用微信音频 API，并填上"游戏资源 CDN"，比如填写的地址为https://wx.qq.com/data/ ，而 API 的 src 地址为 Audio/Chill_1.wav，则最终请求路径会自动拼接前缀 DATA_CDN/Assets(其中 Assets 路径可通过 MiniGameConfig.asset 更改), 即https://wx.qq.com/data/Assets/Audio/Chill_1.wav。

## 将音频文件上传 CDN

游戏内的音频会被导出到导出目录的 Assets 文件夹下，需要将其上传至您的 CDN，保证用户能访问到

![avatar](../image/assets2.png)

## 注意事项

- 使用微信音频 API 后音频无需再监听 onAudioInterruptionBegin，onAudioInterruptionEnd 事件，插件会自动处理。
- 音频未使用 needDownload=true 或 PreDownloadAudios 的情况下，音频文件是不还被缓存的，多次创建并播放同样音频会造成多次下载。需要游戏逻辑自己负责缓存音频对象（就是 WX.CreateInnerAudioContext 的对象需要自己缓存）。
