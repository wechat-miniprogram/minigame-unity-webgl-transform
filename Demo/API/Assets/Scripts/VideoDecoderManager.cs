using System;

using UnityEngine;

using WeChatWASM;

public class VideoDecoderManager : MonoBehaviour
{
    private WXVideoDecoder wxVideoDecoder = null;
    private Texture2D texture;
    private bool videoPlaying = false;
    private bool firstLoad = true;

    private void Start()
    {
        WX.InitSDK((code) =>
        {
            // 该功能无法在IOS高性能模式使用
            // 该功能无法在开发者工具使用
            CreateVideoDecoder();
        });
    }

    private void CreateVideoDecoder()
    {
        // 8.0.38客户端+3.0.0基础库，才能正常使用
        wxVideoDecoder = WX.CreateVideoDecoder();

        wxVideoDecoder.On("start", (res) =>
        {
            Debug.Log("wxVideoDecoder start:" + res);
            videoPlaying = true;
        });
        wxVideoDecoder.On("stop", (res) =>
        {
            Debug.Log("wxVideoDecoder stop:" + res);
            videoPlaying = false;
        });
        wxVideoDecoder.On("seek", (res) =>
        {
            Debug.Log("wxVideoDecoder seek:" + res);
        });
        wxVideoDecoder.On("bufferchange", (res) =>
        {
            Debug.Log("wxVideoDecoder bufferchange:" + res);
        });
        wxVideoDecoder.On("ended", (res) =>
        {
            Debug.Log("wxVideoDecoder ended:" + res);
            videoPlaying = false;
        });
    }

    private void RenderTexture(byte[] data, int width, int height)
    {
        if (firstLoad)
        {
            firstLoad = false;
            CreateSprite(width, height);
        }

        texture.LoadRawTextureData(data);
        texture.Apply();
    }

    private void CreateSprite(int width, int height)
    {
        texture = new Texture2D(width, height, TextureFormat.RGBA32, false);
        GameObject obj = new GameObject("VideoDecoderRender");
        var sr = obj.AddComponent<SpriteRenderer>();
        sr.sprite = Sprite.Create(texture, new Rect(0, 0, width, height), new Vector2(0.5f, 0.5f));
        sr.flipY = true;
    }

    public void VideoDecoderStart()
    {
        wxVideoDecoder.Start(new VideoDecoderStartOption()
        {
            source = "http://wxsnsdy.tc.qq.com/105/20210/snsdyvideodownload?filekey=30280201010421301f0201690402534804102ca905ce620b1241b726bc41dcff44e00204012882540400&bizid=1023&hy=SH&fileparam=302c020101042530230204136ffd93020457e3c4ff02024ef202031e8d7f02030f42400204045a320a0201000400",
            // VideoDecoder目前只支持画面，无法解析声音，所以需要添加abortAudio
            abortAudio = true,
        });
    }

    public void VideoDecoderStop()
    {
        wxVideoDecoder.Stop();
    }

    public void Update()
    {
        if (videoPlaying && wxVideoDecoder != null)
        {
            var response = wxVideoDecoder.GetFrameData();

            if (response != null && response.data.Length > 0)
            {
                RenderTexture(response.data, (int)response.width, (int)response.height);
            }
        }
    }

    private void OnDestroy()
    {
        if (wxVideoDecoder != null)
        {
            wxVideoDecoder.Remove();
            wxVideoDecoder = null;
        }
    }
}
