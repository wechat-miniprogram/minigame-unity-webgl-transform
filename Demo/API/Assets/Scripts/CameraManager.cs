using System;

using UnityEngine;

using WeChatWASM;

public class CameraManager : MonoBehaviour
{
    private WXCamera wxCamera;
    private Texture2D texture;
    private bool firstLoad = true;

    private void Start()
    {
        WX.InitSDK((code) =>
        {
            CreateCamera();
        });
    }

    public void CreateCamera()
    {
        // 该功能无法在IOS高性能模式使用
        // 该功能无法在开发者工具使用
        wxCamera = WX.CreateCamera(new CreateCameraOption()
        {
            x = -144,
            y = -256,
            width = 144,
            height = 256,
            success = (res) =>
            {
                Debug.Log("创建相机成功" + JsonUtility.ToJson(res));
            },
            fail = (res) =>
            {
                Debug.Log("创建相机失败" + JsonUtility.ToJson(res));
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
            RenderTexture(response.data, response.width, response.height);
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
        var systemInfo = WX.GetSystemInfoSync();
        var screenWidth = (int)systemInfo.screenWidth;
        texture = new Texture2D(width, height, TextureFormat.RGBA32, false);
        GameObject obj = new GameObject("CameraRender");
        var sr = obj.AddComponent<SpriteRenderer>();
        sr.sprite = Sprite.Create(texture, new Rect(0, 0, width, height), new Vector2(0.5f, 0.5f));
        sr.flipY = true;
        obj.transform.localScale = new Vector3(screenWidth / width, screenWidth / width, screenWidth / width);
    }

    public void ListenFrameChange()
    {
        wxCamera.ListenFrameChange();
    }

    public void CloseFrameChange()
    {
        wxCamera.CloseFrameChange();
    }

    private void OnDestroy()
    {
        if (wxCamera != null)
        {
            CloseFrameChange();
            wxCamera.Destroy();
            wxCamera = null;
        }
    }
}
