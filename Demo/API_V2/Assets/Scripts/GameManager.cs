using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using WeChatWASM;
using TMPro;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    // 单例模式，方便其他脚本访问 GameManager 实例
    public static GameManager Instance { get; private set; }

    // 隐藏的公共属性，用于访问 DetailsController 脚本
    [HideInInspector]
    public DetailsController detailsController;

    // 字体相关
    [Header("Font")]
    public Font font;
    public Action<Font> OnFontLoaded;

    [Header("TMP_Font")]
    public TMP_FontAsset TMP_font;
    public Action<TMP_FontAsset> OnTMPFontLoaded;


    // 用于在 MainCanvas 和 DetailsCanvas 之间切换
    [Header("Canvas Switch")]
    [SerializeField]
    private GameObject mainCanvas;

    [SerializeField]
    private GameObject detailsCanvas;
    private bool _isMainCanvasActive = true;

    // 用于获取微信小游戏的系统信息
    [Header("System Info")]
    public WindowInfo WindowInfo;
    public ClientRect MenuButtonBoundingClientRect;

    private void Awake()
    {
        // 如果已经有一个 GameManager 实例，销毁当前实例并返回
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        // 设置当前实例为单例实例
        Instance = this;

        // 当场景切换时，不销毁 GameManager 实例
        DontDestroyOnLoad(gameObject);

        GetReferences();

        // 初始化微信小游戏 SDK
        WX.InitSDK(
            (code) =>
            {
                Debug.Log("InitSDK: " + code);

                // 获取微信小游戏的字体
                var fallbackFont = Application.streamingAssetsPath + "/Fz.ttf";
                WX.GetWXFont(
                    fallbackFont,
                    (wxFont) =>
                    {
                        if (!wxFont)
                            return;

                        this.font = wxFont;
                        OnFontLoaded?.Invoke(wxFont);

                        // 将普通字体转换为 TMP 字体资源
                        TMP_FontAsset tmpFontAsset = TMP_FontAsset.CreateFontAsset(wxFont);
                        this.TMP_font = tmpFontAsset;
                        OnTMPFontLoaded?.Invoke(tmpFontAsset);
                    }
                );

                // 获取微信小游戏的系统信息
                WindowInfo = WX.GetWindowInfo();
                MenuButtonBoundingClientRect = WX.GetMenuButtonBoundingClientRect();

                // 非小游戏与预览环境下防止报错
                WindowInfo ??= new WindowInfo { safeArea = new SafeArea() };
                MenuButtonBoundingClientRect ??= new ClientRect();
            }
        );
    }

    private void Start()
    {
        mainCanvas.SetActive(true);
        detailsCanvas.SetActive(false);
        detailsController.ClearDetails();
    }

    // 切换 MainCanvas 和 DetailsCanvas 的显示状态
    public void SwitchCanvas()
    {
        if (!_isMainCanvasActive)
        {
            // 提前销毁时机 防止预期外的行为发生
            detailsController.ClearDetails();
        }
        _isMainCanvasActive = !_isMainCanvasActive;
        mainCanvas.SetActive(_isMainCanvasActive);
        detailsCanvas.SetActive(!_isMainCanvasActive);
    }

    // 加载指定名称的场景
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    // 异步加载指定名称的场景
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        var asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        // 等待场景加载完成
        while (asyncOperation != null && !asyncOperation.isDone)
        {
            yield return null;
        }

        // 场景加载完成后执行的操作
        if (sceneName == "MainScene")
        {
            GetReferences();
        }
    }

    // 获取场景中的引用
    private void GetReferences()
    {
        mainCanvas = GetSceneRootGO("Main Canvas");
        detailsCanvas = GetSceneRootGO("Details Canvas");
        detailsController = detailsCanvas.GetComponent<DetailsController>();
    }

    // 根据名称获取场景中的根游戏对象
    private GameObject GetSceneRootGO(string goName)
    {
        // 获取当前场景中的所有根物体
        var rootObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        // 遍历所有顶层游戏对象，找到名字为name的游戏对象则返回，否则返回null
        return rootObjects.FirstOrDefault(obj => obj.name == goName);
    }
}
