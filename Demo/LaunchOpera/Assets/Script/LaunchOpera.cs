using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using UnityEngine.UI;
using WeChatWASM;

public class LaunchOpera : MonoBehaviour
{
    public Button ResetNewUser;
    public Button SyncDemo;
    public Button AsyncDemo;
    public Button CustomPrgressDemo;

    // Start is called before the first frame update
    void Start()
    {
        ResetNewUser.onClick.AddListener(() =>
        {
            WX.RemoveStorageSync("launchOperaLocalData_Demo");
            WX.ShowToast(
                new ShowToastOption()
                {
                    title = "Cleaned up, please restart the game",
                    icon = "none",
                }
            );
        });

        SyncDemo.onClick.AddListener(() =>
        {
            WX.RemoveStorageSync("launchOperaLocalData_Async");
            WX.ShowModal(
                new ShowModalOption()
                {
                    content =
                        "Successfully set, restart the game and when a new user starts playing the LaunchOpera, otherwise it will not be played.",
                    showCancel = false,
                }
            );
        });

        AsyncDemo.onClick.AddListener(() =>
        {
            WX.StorageSetStringSync("launchOperaLocalData_Async", "1");
            WX.ShowModal(
                new ShowModalOption()
                {
                    content =
                        "Successfully set, restart the game and New users play the complete LaunchOpera, while old users only play the logo video.",
                    showCancel = false,
                }
            );
        });

        CustomPrgressDemo.onClick.AddListener(() =>
        {
            WX.StorageSetStringSync("launchOperaLocalData_UseCustomProgress", "1");
            WX.ShowModal(
                new ShowModalOption()
                {
                    content =
                        "Successfully set, restart the game and progress bar will eventually stop at 85%",
                    showCancel = false,
                }
            );

            string req = JsonMapper.ToJson(new object[] { 1, "a", false });
            Debug.Log(req);
            WX.GetLaunchOperaHandler().SetPercentage(0.5);
        });

        // CustomProgress Test
        // 70% + 30% * 0.5 = 85%
        WX.GetLaunchOperaHandler().SetPercentage(0.5);

        // On LaunchOpera End
        WX.GetLaunchOperaHandler()
            .onEnd(
                (status) =>
                {
                    WX.ShowToast(
                        new ShowToastOption()
                        {
                            title = "C#(WASM) received the ending callback event!",
                            icon = "none",
                        }
                    );
                }
            );
    }

    private class JsMethodInfo
    {
        public string function;
        public object[] args;

        public JsMethodInfo(string func, object[] args)
        {
            this.function = func;
            this.args = args == null ? new object[] { } : args;
        }
    }

    // Update is called once per frame
    void Update() { }
}
