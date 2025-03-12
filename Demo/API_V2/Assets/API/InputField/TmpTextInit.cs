using UnityEngine;
using TMPro;

// 添加 Text 组件的依赖
[RequireComponent(typeof(TMP_Text))]
public class TMPTextInit : MonoBehaviour
{
    private TMP_Text _text;
    

    private void Awake()
    {
        // 获取 Text 组件
        _text = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        // 如果 GameManager 的字体已经加载，直接设置 Text 的字体
        if (GameManager.Instance.font != null)
        {
            _text.font = GameManager.Instance.fonts;
        }
        else
        {
            // 如果字体还未加载，添加字体加载事件监听器
            GameManager.Instance.OnTMPFontLoaded += OnFontLoaded;
        }
    }

    private void OnDestroy()
    {
        // 移除字体加载事件监听器
        GameManager.Instance.OnTMPFontLoaded -= OnFontLoaded;
    }

    // 当字体加载完成时，设置 Text 的字体
    private void OnFontLoaded(TMP_FontAsset fonts)
    {
        _text.font = fonts;
    }
}
