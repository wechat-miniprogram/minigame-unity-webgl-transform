using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using WeChatWASM;

public class Share : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        WX.InitSDK((code) => { });

        WX.OnTouchStart((res) =>
        {
            WXCanvas.ToTempFilePath(new WXToTempFilePathParam()
            {
                x = 0,
                y = 0,
                width = 375,
                height = 300,
                destWidth = 375,
                destHeight = 300,
                success = (result) =>
                {
                    Debug.Log("ToTempFilePath success" + JsonUtility.ToJson(result));
                    WX.ShareAppMessage(new ShareAppMessageOption()
                    {
                        title = "share title",
                        imageUrl = result.tempFilePath,
                    });
                },
                fail = (result) =>
                {
                    Debug.Log("ToTempFilePath fail" + JsonUtility.ToJson(result));
                },
                complete = (result) =>
                {
                    Debug.Log("ToTempFilePath complete" + JsonUtility.ToJson(result));
                },
            });
        });
    }
}
