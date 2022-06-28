using UnityEngine;
using System.Collections;
using WeChatWASM;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inputs : MonoBehaviour, IPointerClickHandler, IPointerExitHandler
{
    public InputField input;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("ooooo");
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
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // 隐藏输入法
        if (!input.isFocused)
        {
            WX.HideKeyboard(new HideKeyboardOption());
            //删除掉相关事件监听
            WX.OffKeyboardInput(OnInput);
            WX.OffKeyboardConfirm(OnConfirm);
            WX.OffKeyboardComplete(OnComplete);
        }

    }

    public void OnInput(OnKeyboardInputCallbackResult v)
    {
        Debug.Log("onInput");
        Debug.Log(v.value);
        if (input.isFocused)
        {
            input.text = v.value;
        }

    }

    public void OnConfirm(OnKeyboardInputCallbackResult v)
    {
        // 输入法confirm回调
        Debug.Log("onConfirm");
        Debug.Log(v.value);
    }

    public void OnComplete(OnKeyboardInputCallbackResult v)
    {
        // 输入法complete回调
        Debug.Log("OnComplete");
        Debug.Log(v.value);
    }


    void Start()
    {

    }

}
