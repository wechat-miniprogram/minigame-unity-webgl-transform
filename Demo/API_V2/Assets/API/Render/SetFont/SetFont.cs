using UnityEngine;
using WeChatWASM;

public class SetFont : Details
{
    protected override void TestAPI(string[] args)
    {
        LoadFont();
    }

    private void LoadFont()
    {
        var font = WX.LoadFont("TencentSans-W7.subset.ttf");
        Debug.Log(font);
    }
}
