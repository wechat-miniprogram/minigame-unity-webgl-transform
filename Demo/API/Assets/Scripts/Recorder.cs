using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeChatWASM;

public class Recorder : MonoBehaviour
{
    private WXRecorderManager recorderManager;
    private WXUploadTask uploadTask;

    private string tempFilePath;

    void Start()
    {
        Debug.Log("RecorderManager");

        recorderManager = WX.GetRecorderManager();

        recorderManager.OnStart(() =>
        {
            Debug.Log("recorder onStart");
        });

        recorderManager.OnPause(() =>
        {
            Debug.Log("recorder onPause");
        });

        recorderManager.OnResume(() =>
        {
            Debug.Log("recorder onResume");
        });

        recorderManager.OnStop((res) =>
        {
            Debug.Log("recorder onStop");
            Debug.Log(res.tempFilePath);
            Debug.Log(res.duration);
            Debug.Log(res.fileSize);
            tempFilePath = res.tempFilePath;
        });

        recorderManager.OnFrameRecorded((res) =>
        {
            Debug.Log("recorder onFrameRecorded");
            Debug.Log(res.frameBuffer.Length);
            Debug.Log(res.isLastFrame);
        });

        recorderManager.OnInterruptionBegin(() =>
        {
            Debug.Log("recorder onInterruptionBegin");
        });

        recorderManager.OnInterruptionEnd(() =>
        {
            Debug.Log("recorder onInterruptionEnd");
        });
    }

    public void recorderStart()
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

        recorderManager.Start(options);
    }

    public void recorderStop()
    {
        recorderManager.Stop();
    }

    public void recorderPause()
    {
        recorderManager.Pause();
    }

    public void recorderResume()
    {
        recorderManager.Resume();
    }

    public void recorderPlay()
    {
        // 播放临时路径里的音频，此处不可设置needDownload，因为已经在本地文件了
        var audioPlayRightNow = WX.CreateInnerAudioContext(new InnerAudioContextParam() {});
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
        audioPlayRightNow.OnError(() =>
        {
            Debug.Log("recorder audio OnError");
        });
    }

    public void uploadFile()
    {
        uploadTask = WX.UploadFile(new UploadFileOption()
        {
            url = "xxxxxxxx", // 开发者自己的后台地址
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
}
