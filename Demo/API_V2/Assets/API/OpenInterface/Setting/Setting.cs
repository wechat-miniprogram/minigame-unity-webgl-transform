using System.Collections.Generic;
using UnityEngine;
using WeChatWASM;

public class Setting : Details {
    private void Start() {
        GameManager.Instance.detailsController.BindExtraButtonAction(0, getSetting);
    }

    protected override void TestAPI(string[] args) {
        openSetting();
    }

    public void openSetting() {
        WX.OpenSetting(new OpenSettingOption() {
            success = res => {
                Debug.Log("success " + JsonUtility.ToJson(res));
            },
            fail = res => {
                Debug.Log("fail " + JsonUtility.ToJson(res));
            },
            complete = (res) => {
                Debug.Log("complete " + JsonUtility.ToJson(res));
            }
        });
    }

    public void getSetting() {
        WX.GetSetting(new GetSettingOption() {
            success = res => {
                Debug.Log("success " + JsonUtility.ToJson(res));
            },
            fail = res => {
                Debug.Log("fail " + JsonUtility.ToJson(res));
            },
            complete = (res) => {
                Debug.Log("complete " + JsonUtility.ToJson(res));
            }
        });
    }
}