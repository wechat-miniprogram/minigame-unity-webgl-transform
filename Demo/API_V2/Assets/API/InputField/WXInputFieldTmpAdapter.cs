using UnityEngine;
using WeChatWASM;
using TMPro;
using UnityEngine.EventSystems;

// 要求该组件必须附加 TMP_InputField 组件
[RequireComponent(typeof(TMP_InputField))]
public class WXInputFieldTmpAdapter : MonoBehaviour, IPointerClickHandler, IPointerExitHandler
{
    private TMP_InputField _inputField; // 存储 TMP_InputField 组件的引用
    private bool _isShowKeyboard = false; // 标记键盘是否显示

    private void Start()
    {
        // 获取挂载在同一游戏对象上的 TMP_InputField 组件
        _inputField = GetComponent<TMP_InputField>();
    }

    // 当指针点击该组件时调用
    public void OnPointerClick(PointerEventData eventData)
    {
        ShowKeyboard(); // 显示键盘
    }

    // 当指针离开该组件时调用
    public void OnPointerExit(PointerEventData eventData)
    {
        // 如果 TMP_InputField 没有被聚焦，则隐藏键盘
        if (!_inputField.isFocused)
        {
            HideKeyboard();
        }
    }

    // 输入法输入回调
    private void OnInput(OnKeyboardInputListenerResult v)
    {
        // 如果 TMP_InputField 被聚焦，则将输入值赋给 TMP_InputField
        if (_inputField.isFocused)
        {
            _inputField.text = v.value;
        }
    }

    // 输入法确认回调
    private void OnConfirm(OnKeyboardInputListenerResult v)
    {
        HideKeyboard(); // 隐藏键盘
    }

    // 输入法完成回调
    private void OnComplete(OnKeyboardInputListenerResult v)
    {
        HideKeyboard(); // 隐藏键盘
    }

    // 显示键盘的方法
    private void ShowKeyboard()
    {
        // 如果键盘已经显示，则直接返回
        if (_isShowKeyboard) return;

        // 调用 WeChat API 显示键盘
        WX.ShowKeyboard(new ShowKeyboardOption()
        {
            defaultValue = _inputField.text,//传入当前文本作为默认值
            maxLength = 20, // 最大输入长度
            confirmType = "go" // 确认按钮类型
        });

        // 绑定键盘事件回调
        WX.OnKeyboardConfirm(this.OnConfirm);
        WX.OnKeyboardComplete(this.OnComplete);
        WX.OnKeyboardInput(this.OnInput);
        _isShowKeyboard = true; // 更新键盘显示状态
    }

    // 隐藏键盘的方法
    private void HideKeyboard()
    {
        // 如果键盘未显示，则直接返回
        if (!_isShowKeyboard) return;

        // 调用 WeChat API 隐藏键盘
        WX.HideKeyboard(new HideKeyboardOption());
        // 移除事件监听
        WX.OffKeyboardInput(this.OnInput);
        WX.OffKeyboardConfirm(this.OnConfirm);
        WX.OffKeyboardComplete(this.OnComplete);
        _isShowKeyboard = false; // 更新键盘显示状态
    }
}
