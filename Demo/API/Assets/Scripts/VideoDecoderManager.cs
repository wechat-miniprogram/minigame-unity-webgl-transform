using System;

using UnityEngine;

using WeChatWASM;

public class VideoDecoderManager : MonoBehaviour
{
    private WXVideoDecoder wxVideoDecoder = null;
    private Texture2D texture;
    private bool videoPlaying = false;
    private bool firstLoad = true;
    private bool needRender = true;

    private void Start()
    {
        WX.InitSDK((code) =>
        {
            CreateVideoDecoder();
        });
    }

    private void CreateVideoDecoder()
    {
        wxVideoDecoder = WX.CreateVideoDecoder();

        wxVideoDecoder.On("start", (res) =>
        {
            Debug.Log("wxVideoDecoder start:" + res);
            videoPlaying = true;
        });
        wxVideoDecoder.On("stop", (res) =>
        {
            Debug.Log("wxVideoDecoder stop:" + res);
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
        wxVideoDecoder.Start(new VideoDecoderStartOption()
        {
            source = "https://img.nga.178.com/attachments/mon_202212/06/-9oxvQ0-cth3XaZ2tT6wS8w-8w.mp4",
            abortAudio = true,
        });
    }

    public void Mock()
    {
        Debug.Log(GetTime());

        // mock data;
        var ArrayBuffer = new byte[480 * 480 * 4];
        CreateSprite(ArrayBuffer, 480, 480, true);
    }

    private long GetTime()
    {
        return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;
    }

    private void CreateSprite(byte[] data, double width, double height, bool mock)
    {
        if (firstLoad)
        {
            var createTime = GetTime();
            firstLoad = false;
            var getWidth = (int)width;
            var getHeight = (int)height;
            RenderSprite(getWidth, getHeight);
            Debug.Log("createSprite need:");
            Debug.Log(GetTime() - createTime);
        }

        if (needRender)
        {
            var readDataTime = GetTime();

            if (mock)
            {
                // 随机
                for (int i = 0; i < data.Length; i += 4)
                {
                    // Color color = new Color(data[i] / 255f, data[i + 1] / 255f, data[i + 2] / 255f);
                    Color color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
                    var index = (int)System.Math.Floor((double)i / 4);
                    var x = index % width;
                    var y = (int)System.Math.Floor((double)(index / width));

                    // 此处的y是反着的
                    texture.SetPixel((int)x, (int)(height - y), color);
                }
            }
            else
            {
                // 此处的y轴是镜像翻转的
                texture.LoadRawTextureData(data);

                // for (int i = 0; i < data.Length; i += 4)
                // {
                //     Color color = new Color(data[i] / 255f, data[i + 1] / 255f, data[i + 2] / 255f);
                //     // Color color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
                //     var index = (int)System.Math.Floor((double)i / 4);
                //     var x = index % width;
                //     var y = (int)System.Math.Floor((double)(index / width));
                //     // 此处的y是反着的
                //     texture.SetPixel((int) x, (int) (height - y), color);
                // }
            }

            texture.Apply();
            Debug.Log("updateTexture need:");
            Debug.Log(GetTime() - readDataTime);
        }
    }

    private void RenderSprite(int width, int height)
    {
        var screenWidth = 480;
        texture = new Texture2D(width, height, TextureFormat.RGBA32, false);
        Sprite cameraSprite = Sprite.Create(texture, new Rect(0, 0, width, height), new Vector2(0.5f, 0.5f));
        GameObject obj = new GameObject("CameraSprite");
        var sr = obj.AddComponent<SpriteRenderer>();
        sr.sprite = cameraSprite;
        obj.transform.localScale = new Vector3(screenWidth / width, screenWidth / width, screenWidth / width);
    }

    public void Update()
    {
        if (videoPlaying && wxVideoDecoder != null)
        {
            var response = wxVideoDecoder.GetFrameData();

            if (response.data.Length > 0)
            {
                CreateSprite(response.data, response.width, response.height, false);
            }
        }
    }

    private void OnDestroy()
    {
        wxVideoDecoder.Remove();
        wxVideoDecoder = null;
    }
}
