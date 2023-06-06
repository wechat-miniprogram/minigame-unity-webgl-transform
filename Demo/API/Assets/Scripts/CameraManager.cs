using System;

using UnityEngine;

using WeChatWASM;

public class CameraManager : MonoBehaviour
{
    private WXCamera wxCamera;
    private Texture2D originalTexture;
    private Texture2D flippedTexture;
    private bool firstLoad = true;
    private bool needRender = true;

    private void Start()
    {
        WX.InitSDK((code) =>
        {
            this.CreateCamera();
        });
    }

    public void CreateCamera()
    {
        // 无法在IOS高性能模式下使用
        wxCamera = WX.CreateCamera(new CreateCameraOption()
        {
            x = -144,
            y = -256,
            width = 144,
            height = 256,
            success = (res) =>
            {
                Debug.Log("成功" + JsonUtility.ToJson(res));
            },
            fail = (res) =>
            {
                Debug.Log("失败" + JsonUtility.ToJson(res));
            },
            complete = (res) =>
            {
                Debug.Log("完成" + JsonUtility.ToJson(res));
            }

        });

        wxCamera.OnAuthCancel(() =>
        {
            // 游戏兼容用户不允许授权使用摄像头的情况
            Debug.Log("游戏兼容用户不允许授权使用摄像头的情况");
        });

        wxCamera.OnStop(() =>
        {
            // 摄像头暂停，如退出后台
            Debug.Log("摄像头暂停，如退出后台");
        });

        wxCamera.OnCameraFrame((response) =>
        {
            // 获取每帧数据
            DrawCamera(response.data, response.width, response.height);
        });

        wxCamera.ListenFrameChange();
    }

    private static byte[] FlipVertical(byte[] originalPixels, int width, int height)
    {
        byte[] flippedPixels = new byte[width * height];

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                flippedPixels[(height - i - 1) * width + j] = originalPixels[i * width + j];
            }
        }

        return flippedPixels;
    }

    private void DrawCamera(byte[] data, int width, int height)
    {
        if (firstLoad)
        {
            firstLoad = false;
            CreateSprite(width, height);
        }

        if (needRender)
        {
            originalTexture.LoadRawTextureData(data);
            originalTexture.Apply();

            for (int i = 0; i < height; i++)
            {
                Graphics.CopyTexture(originalTexture, 0, i, flippedTexture, 0, height - 1 - i);
            }

            UnityEngine.Object.Destroy(originalTexture);
        }
    }

    private void CreateSprite(int width, int height)
    {
        var systemInfo = WX.GetSystemInfoSync();
        var screenWidth = (int)systemInfo.screenWidth;
        originalTexture = new Texture2D(width, height, TextureFormat.RGBA32, false);
        flippedTexture = new Texture2D(width, height, TextureFormat.RGBA32, false);
        Sprite cameraSprite = Sprite.Create(flippedTexture, new Rect(0, 0, width, height), new Vector2(0.5f, 0.5f));
        GameObject obj = new GameObject("CameraSprite");
        var sr = obj.AddComponent<SpriteRenderer>();
        sr.sprite = cameraSprite;
        obj.transform.localScale = new Vector3(screenWidth / width, screenWidth / width, screenWidth / width);
    }

    public void ToggleRender()
    {
        needRender = !needRender;
    }

    public void CloseFrameChange()
    {
        wxCamera.CloseFrameChange();
    }

    private void OnDestroy()
    {
        CloseFrameChange();
        wxCamera.Destroy();
    }
}
