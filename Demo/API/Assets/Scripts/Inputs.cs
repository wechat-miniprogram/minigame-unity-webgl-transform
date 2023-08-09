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
