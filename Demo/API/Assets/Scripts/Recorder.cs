using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeChatWASM;

public class Recorder : MonoBehaviour
{
    private static WXRecorderManager RecorderManager;
    private WXUploadTask uploadTask;

    private string tempFilePath;

    void Start()
    {
        if (RecorderManager != null)
        {
            // 已创建
            Debug.Log("已创建");
            return;
        }
        // RecorderManager是全局唯一的
        RecorderManager = WX.GetRecorderManager();

        RecorderManager.OnStart(() =>
        {
            Debug.Log("recorder onStart");
        });

        RecorderManager.OnPause(() =>
        {
            Debug.Log("recorder onPause");
        });

        RecorderManager.OnResume(() =>
        {
            Debug.Log("recorder onResume");
        });

        RecorderManager.OnStop((res) =>
        {
            Debug.Log("recorder onStop");
            Debug.Log(res.tempFilePath);
            Debug.Log(res.duration);
            Debug.Log(res.fileSize);
            tempFilePath = res.tempFilePath;
        });

        RecorderManager.OnFrameRecorded((res) =>
        {
            Debug.Log("recorder onFrameRecorded");
            Debug.Log(res.frameBuffer.Length);
            Debug.Log(res.isLastFrame);
        });

        RecorderManager.OnInterruptionBegin(() =>
        {
            Debug.Log("recorder onInterruptionBegin");
        });

        RecorderManager.OnInterruptionEnd(() =>
        {
            Debug.Log("recorder onInterruptionEnd");
        });
    }

    public void RecorderStart()
    {
        var options = new RecorderManagerStartOption()
        {
            duration = 10000,
            sampleRate = 44100,
            numberOfChannels = 1,
            encodeBitRate = 192000,
            format = "aac",
            frameSize = 50
        };

        RecorderManager.Start(options);
    }

    public void RecorderStop()
    {
        RecorderManager.Stop();
    }

    public void RecorderPause()
    {
        RecorderManager.Pause();
    }

    public void RecorderResume()
    {
        RecorderManager.Resume();
    }

    public void RecorderPlay()
    {
        // 播放临时路径里的音频，此处不可设置needDownload，因为已经在本地文件了
        var audioPlayRightNow = WX.CreateInnerAudioContext(new InnerAudioContextParam() { });
        audioPlayRightNow.src = tempFilePath;
        audioPlayRightNow.OnPlay(() =>
        {
            Debug.Log("recorder audio OnPlay");
        });
        audioPlayRightNow.OnCanplay(() =>
        {
            Debug.Log("recorder audio OnCanplay");
            audioPlayRightNow.Play();
        });
        audioPlayRightNow.OnError((res) =>
        {
            Debug.Log("recorder audio OnError");
        });
    }

    public void UploadFile()
    {
        uploadTask = WX.UploadFile(new UploadFileOption()
        {
            url = "xxxxxxxx", // 此处填写开发者自己的后台地址
            filePath = tempFilePath,
            name = "test",
            timeout = 10000,
            success = (successResult) =>
            {
                Debug.Log("successResult");
                Debug.Log(JsonUtility.ToJson(successResult));
            },
            fail = (failResult) =>
            {
                Debug.Log("failResult");
                Debug.Log(JsonUtility.ToJson(failResult));
            },
            complete = (completeResult) =>
            {
                Debug.Log("completeResult");
                Debug.Log(JsonUtility.ToJson(completeResult));
            }
        });

        uploadTask.OnHeadersReceived((data) =>
        {
            Debug.Log("onHeadersReceived");
            Debug.Log(JsonUtility.ToJson(data.header));
        });

        uploadTask.OnProgressUpdate((data) =>
        {
            Debug.Log("onProgressUpdate");
            Debug.Log(data.progress);
            Debug.Log(data.totalBytesSent);
            Debug.Log(data.totalBytesExpectedToSend);
        });
    }

    private void OnDestroy()
    {
        RecorderManager.Stop();
    }
}
