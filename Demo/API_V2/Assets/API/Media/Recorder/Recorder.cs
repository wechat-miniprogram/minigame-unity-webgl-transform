using UnityEngine;
using WeChatWASM;

public class Recorder : Details {
    private static WXRecorderManager _recorderManager;
    private WXUploadTask _uploadTask;

    private string _tempFilePath;

    private void Start() {
        // RecorderManager是全局唯一的
        if (_recorderManager == null) {
            _recorderManager = WX.GetRecorderManager();
        }

        _recorderManager.OnStart(() => {
            Debug.Log("recorder onStart");
        });

        _recorderManager.OnPause(() => {
            Debug.Log("recorder onPause");
        });

        _recorderManager.OnResume(() => {
            Debug.Log("recorder onResume");
        });

        _recorderManager.OnStop((res) => {
            Debug.Log("recorder onStop");
            Debug.Log(res.tempFilePath);
            Debug.Log(res.duration);
            Debug.Log(res.fileSize);
            _tempFilePath = res.tempFilePath;
        });

        _recorderManager.OnFrameRecorded((res) => {
            Debug.Log("recorder onFrameRecorded");
            Debug.Log(res.frameBuffer.Length);
            Debug.Log(res.isLastFrame);
        });

        _recorderManager.OnInterruptionBegin(() => {
            Debug.Log("recorder onInterruptionBegin");
        });

        _recorderManager.OnInterruptionEnd(() => {
            Debug.Log("recorder onInterruptionEnd");
        });

        GameManager.Instance.detailsController.BindExtraButtonAction(0, RecorderPause);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, RecorderResume);
        GameManager.Instance.detailsController.BindExtraButtonAction(2, RecorderStop);
        GameManager.Instance.detailsController.BindExtraButtonAction(3, RecorderPlay);
        GameManager.Instance.detailsController.BindExtraButtonAction(4, UploadFile);
    }

    // 开始
    protected override void TestAPI(string[] args) {
        _recorderManager.Start(new RecorderManagerStartOption() {
            duration = 10000,
            sampleRate = 44100,
            numberOfChannels = 1,
            encodeBitRate = 192000,
            format = "aac",
            frameSize = 50
        });
    }

    // 暂停
    public void RecorderPause() {
        _recorderManager.Pause();
    }

    // 恢复
    public void RecorderResume() {
        _recorderManager.Resume();
    }

    // 停止
    public void RecorderStop() {
        _recorderManager.Stop();
    }

    // 播放
    public void RecorderPlay() {
        // 播放临时路径里的音频，此处不可设置needDownload，因为已经在本地文件了
        var audioPlayRightNow = WX.CreateInnerAudioContext(new InnerAudioContextParam());
        audioPlayRightNow.src = _tempFilePath;
        audioPlayRightNow.OnPlay(() => {
            Debug.Log("recorder audio OnPlay");
        });
        audioPlayRightNow.OnCanplay(() => {
            Debug.Log("recorder audio OnCanplay");
            audioPlayRightNow.Play();
        });
        audioPlayRightNow.OnError((res) => {
            Debug.Log("recorder audio OnError");
        });
    }

    // 上传
    public void UploadFile() {
        _uploadTask = WX.UploadFile(new UploadFileOption() {
            url = "xxxxxxxx", // 此处填写开发者自己的后台地址
            filePath = _tempFilePath,
            name = "test",
            timeout = 10000,
            success = (successResult) => {
                Debug.Log("successResult");
                Debug.Log(JsonUtility.ToJson(successResult));
            },
            fail = (failResult) => {
                Debug.Log("failResult");
                Debug.Log(JsonUtility.ToJson(failResult));
            },
            complete = (completeResult) => {
                Debug.Log("completeResult");
                Debug.Log(JsonUtility.ToJson(completeResult));
            }
        });

        _uploadTask.OnHeadersReceived((data) => {
            Debug.Log("onHeadersReceived");
            Debug.Log(JsonUtility.ToJson(data.header));
        });

        _uploadTask.OnProgressUpdate((data) => {
            Debug.Log("onProgressUpdate");
            Debug.Log(data.progress);
            Debug.Log(data.totalBytesSent);
            Debug.Log(data.totalBytesExpectedToSend);
        });
    }

    private void OnDestroy() {
        _recorderManager.Stop();
    }
}