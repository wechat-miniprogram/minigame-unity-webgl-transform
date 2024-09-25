# 输入法适配

### 支持2022和团结引擎的 Input Field 组件自动适配，低版本或者其他组件暂不支持自动适配

### 低版本兼容：

在小游戏中Unity游戏唤不起输入法，需要使用WX_SDK中提供的方法来唤起输入法，并做简单的逻辑修改来适配。

详细示例请参考[API Demo](https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/tree/main/Demo/API_V2)

以UGUI的Input组件为例，需要给Input 绑定以下脚本：
```csharp
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
            defaultValue = "xxx",
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
```
