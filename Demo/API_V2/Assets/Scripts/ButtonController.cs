using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private Button _button;
    private Text _text;

    private void Awake()
    {
        // 获取子对象的 Button 组件
        _button = transform.Find("Button").GetComponent<Button>();
        // 获取子对象的 Text 组件
        _text = transform.Find("Button/Text").GetComponent<Text>();
    }

    // 添加按钮监听事件
    public void AddButtonListener(UnityAction action)
    {
        _button.onClick.AddListener(action);
    }

    // 更改按钮文本
    public void ChangeButtonText(string text)
    {
        _text.text = text;
    }
}