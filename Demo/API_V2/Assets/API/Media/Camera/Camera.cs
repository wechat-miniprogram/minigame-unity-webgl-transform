using UnityEngine;
using WeChatWASM;

public class Camera : Details {
    private WXCamera _camera;
    private Texture2D _texture;
    private bool _firstLoad = true;

    private bool _isListening = false;
    private void Start() {
        // 该功能无法在IOS高性能模式使用
        // 该功能无法在开发者工具使用
        _camera = WX.CreateCamera(new CreateCameraOption() {
            x = -144,
            y = -256,
            width = 144,
            height = 256,
            success = (res) => {
                Debug.Log("创建相机成功" + JsonUtility.ToJson(res));
            },
            fail = (res) => {
                Debug.Log("创建相机失败" + JsonUtility.ToJson(res));
            }
        });

        _camera.OnAuthCancel(() => {
            // 游戏兼容用户不允许授权使用摄像头的情况
            Debug.Log("游戏兼容用户不允许授权使用摄像头的情况");
        });

        _camera.OnStop(() => {
            // 摄像头暂停，如退出后台
            Debug.Log("摄像头暂停，如退出后台");
        });

        _camera.OnCameraFrame((response) => {
            // 获取每帧数据
            RenderTexture(response.data, response.width, response.height);
        });
    }

    protected override void TestAPI(string[] args) {
        if (_isListening) {
            _camera.CloseFrameChange();
            GameManager.Instance.detailsController.ChangeInitialButtonText("开始监听帧数据");
        } else {
            _camera.ListenFrameChange();
            GameManager.Instance.detailsController.ChangeInitialButtonText("停止监听帧数据");
        }

        _isListening = !_isListening;
    }

    private void RenderTexture(byte[] data, int width, int height) {
        if (_firstLoad) {
            _firstLoad = false;
            CreateSprite(width, height);
        }

        _texture.LoadRawTextureData(data);
        _texture.Apply();
    }

    private void CreateSprite(int width, int height) {
        _texture = new Texture2D(width, height, TextureFormat.RGBA32, false);
        var obj = new GameObject("CameraRender");
        var sr = obj.AddComponent<SpriteRenderer>();
        sr.sprite = Sprite.Create(_texture, new Rect(0, 0, width, height), new Vector2(0.5f, 0.5f));
        sr.flipY = true;
    }

    private void OnDestroy() {
        if (_camera != null) {
            _camera.CloseFrameChange();
            _camera.Destroy();
            _camera = null;
        }
    }
}