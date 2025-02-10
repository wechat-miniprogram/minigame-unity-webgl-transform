using UnityEngine;
using WeChatWASM;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// 添加 InputField 组件的依赖
[RequireComponent(typeof(InputField))]
public class WXInputFieldAdapter : MonoBehaviour, IPointerClickHandler, IPointerExitHandler
{
    private InputField _inputField;
    private bool _isShowKeyboard = false;

    private void Start()
    {
        _inputField = GetComponent<InputField>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
        ShowKeyboard();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");
        if (!_inputField.isFocused)
        {
            HideKeyboard();
        }
    }

    private void OnInput(OnKeyboardInputListenerResult v)
    {
        Debug.Log("onInput");
        Debug.Log(v.value);
        if (_inputField.isFocused)
        {
            _inputField.text = v.value;
        }
    }

    private void OnConfirm(OnKeyboardInputListenerResult v)
    {
        // 输入法confirm回调
        Debug.Log("onConfirm");
        Debug.Log(v.value);
        HideKeyboard();
    }

    private void OnComplete(OnKeyboardInputListenerResult v)
    {
        // 输入法complete回调
        Debug.Log("OnComplete");
        Debug.Log(v.value);
        HideKeyboard();
    }

    private void ShowKeyboard()
    {
        if (_isShowKeyboard) return;

        WX.ShowKeyboard(new ShowKeyboardOption()
        {
            defaultValue = _inputField.text,
            maxLength = 20,
            confirmType = "go"
        });

        //绑定回调
        WX.OnKeyboardConfirm(this.OnConfirm);
        WX.OnKeyboardComplete(this.OnComplete);
        WX.OnKeyboardInput(this.OnInput);
        _isShowKeyboard = true;
    }

    private void HideKeyboard()
    {
        if (!_isShowKeyboard) return;

        WX.HideKeyboard(new HideKeyboardOption());
        //删除掉相关事件监听
        WX.OffKeyboardInput(this.OnInput);
        WX.OffKeyboardConfirm(this.OnConfirm);
        WX.OffKeyboardComplete(this.OnComplete);
        _isShowKeyboard = false;
    }
}