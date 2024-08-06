using UnityEngine;
using UnityEngine.UI;

// 添加 Button 组件的依赖
[RequireComponent(typeof(Button))]
public class BackToMainSceneButton : MonoBehaviour
{
    private void Awake()
    {
        // 为按钮添加点击事件监听器
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    // 点击事件处理
    private static void OnClick()
    {
        // 加载主场景
        GameManager.Instance.LoadScene("MainScene");
    }
}