using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;
public class OpenData : Details
{
    private void Start()
    {

        GameManager.Instance.detailsController.BindExtraButtonAction(0, checkSession);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, authorize);
        GameManager.Instance.detailsController.BindExtraButtonAction(2, getGroupEnterInfo);
        GameManager.Instance.detailsController.BindExtraButtonAction(3, requirePrivacyAuthorize);
        GameManager.Instance.detailsController.BindExtraButtonAction(4, openPrivacyContract);
        GameManager.Instance.detailsController.BindExtraButtonAction(5, getPrivacySetting);
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        login();
    }

    public void login()
    {
        WX.Login(new LoginOption
        {
            timeout = 2000,
            success = (res) =>
            {
                WX.ShowModal(new ShowModalOption
                {
                    content = JsonMapper.ToJson(res)
                });
            },
            fail = (res) =>
            {
                Debug.Log("fail : " + res.errMsg);
            },
            complete = (res) =>
            {
                Debug.Log("complete");
            }
        });
    }

    public void checkSession()
    {
        WX.CheckSession(new CheckSessionOption
        {
            success = (res) =>
            {
                Debug.Log("success");
            },
            fail = (res) =>
            {
                Debug.Log("fail : " + res.errMsg);
            },
            complete = (res) =>
            {
                Debug.Log("complete");
            }
        });
    }

    public void authorize()
    {
        WX.Authorize(new AuthorizeOption
        {
            scope = "scope.writePhotosAlbum",
            success = (res) =>
            {
                Debug.Log("success");
            },
            fail = (res) =>
            {
                Debug.Log("fail : " + res.errMsg);
            },
            complete = (res) =>
            {
                Debug.Log("complete");
            }
        });
    }

    public void getGroupEnterInfo()
    {
        WX.GetGroupEnterInfo(new GetGroupEnterInfoOption
        {
            success = (res) =>
            {
                WX.ShowModal(new ShowModalOption
                {
                    content = JsonMapper.ToJson(res)
                });
            },
            fail = (res) =>
            {
                Debug.Log("fail : " + res.errMsg);
            },
            complete = (res) =>
            {
                Debug.Log("complete");
            }
        });
    }

    public void requirePrivacyAuthorize()
    {
        WX.RequirePrivacyAuthorize(new RequirePrivacyAuthorizeOption
        {
            success = (res) =>
            {
                Debug.Log("success");
            },
            fail = (res) =>
            {
                Debug.Log("fail : " + res.errMsg);
            },
            complete = (res) =>
            {
                Debug.Log("complete");
            }
        });
    }

    public void openPrivacyContract()
    {
        WX.OpenPrivacyContract(new OpenPrivacyContractOption
        {
            success = (res) =>
            {
                Debug.Log("success");
            },
            fail = (res) =>
            {
                Debug.Log("fail : " + res.errMsg);
            },
            complete = (res) =>
            {
                Debug.Log("complete");
            }
        });
    }

    public void getPrivacySetting()
    {
        WX.GetPrivacySetting(new GetPrivacySettingOption
        {
            success = (res) =>
            {
                Debug.Log("success " + JsonMapper.ToJson(res));
            },
            fail = (res) =>
            {
                Debug.Log("fail : " + res.errMsg);
            },
            complete = (res) =>
            {
                Debug.Log("complete");
            }
        });
    }
}