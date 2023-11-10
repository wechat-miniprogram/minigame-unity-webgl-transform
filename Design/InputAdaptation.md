# 输入法适配

- 支持2022 Input Field组件自动适配，低版本或者其他组件暂不支持

- 低版本兼容：

在小游戏中Unity游戏唤不起输入法，需要使用WX_SDK中提供的方法来唤起输入法，并做简单的逻辑修改来适配。

详细示例请参考[API Demo](https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/tree/main/Demo/API)

以UGUI的Input组件为例，需要给Input 绑定以下脚本：
```
using UnityEngine;
using System.Collections;
using WeChatWASM;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inputs : MonoBehaviour, IPointerClickHandler, IPointerExitHandler
{
    public InputField input;
    private bool isShowKeyboard = false;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
        ShowKeyboard();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");
        if (!input.isFocused)
        {
            HideKeyboard();
        }
    }

    public void OnInput(OnKeyboardInputListenerResult v)
    {
        Debug.Log("onInput");
        Debug.Log(v.value);
        if (input.isFocused)
        {
            input.text = v.value;
        }
    }

    public void OnConfirm(OnKeyboardInputListenerResult v)
    {
        // 输入法confirm回调
        Debug.Log("onConfirm");
        Debug.Log(v.value);
        HideKeyboard();
    }

    public void OnComplete(OnKeyboardInputListenerResult v)
    {
        // 输入法complete回调
        Debug.Log("OnComplete");
        Debug.Log(v.value);
        HideKeyboard();
    }

    private void ShowKeyboard()
    {
        if (!isShowKeyboard)
        {
            WX.ShowKeyboard(new ShowKeyboardOption()
            {
                defaultValue = "xxx",
                maxLength = 20,
                confirmType = "go"
            });

            //绑定回调
            WX.OnKeyboardConfirm(OnConfirm);
            WX.OnKeyboardComplete(OnComplete);
            WX.OnKeyboardInput(OnInput);
            isShowKeyboard = true;
        }
    }

    private void HideKeyboard()
    {
        if (isShowKeyboard)
        {
            WX.HideKeyboard(new HideKeyboardOption());
            //删除掉相关事件监听
            WX.OffKeyboardInput(OnInput);
            WX.OffKeyboardConfirm(OnConfirm);
            WX.OffKeyboardComplete(OnComplete);
            isShowKeyboard = false;
        }
    }
}
```
