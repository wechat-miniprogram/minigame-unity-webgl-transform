# 输入法适配

在小游戏中Unity游戏唤不起输入法，需要使用WX_SDK中提供的方法来唤起输入法，并做简单的逻辑修改来适配。
如下以UGUI的Input组件为例，需要给Input 绑定以下脚本：
```
public class Inputs : MonoBehaviour,IPointerClickHandler,IPointerExitHandler
{
    public InputField input;
    public void OnPointerClick(PointerEventData eventData)
    {
        // 监听点击事件唤起微信输入法
        WX.ShowKeyboard(new WXShowKeyboardParam()
        {
            // 这里的参数根据需要自行设置，参见https://developers.weixin.qq.com/minigame/dev/api/ui/keyboard/wx.showKeyboard.html
            defaultValue = input.text,
            maxLength = 20,
            confirmType="go"
        }) ;

        //绑定回调
        WX.OnKeyboardConfirm(OnConfirm);
        WX.OnKeyboardComplete(OnComplete);


    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // 隐藏输入法
        if (!input.isFocused)
        {
            WX.HideKeyboard();
            //删除掉相关事件监听
            WX.OffKeyboardInput(OnInput);
            WX.OffKeyboardConfirm(OnConfirm);
            WX.OffKeyboardComplete(OnComplete);
        }

    }

    public void OnInput(string v)
    {

        if (input.isFocused)
        {
            input.text = v;
        }
        
    }

    public void OnConfirm(string v)
    {
        // 输入法confirm回调
        if (input.isFocused)
        {
          
        }
    }

    public void OnComplete(string v)
    {
        // 输入法complete回调
        if (input.isFocused)
        {

        }
    }


    void Start()
    {
        
    }

}
```