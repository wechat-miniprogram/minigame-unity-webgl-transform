using LitJson;
using UnityEngine;
using WeChatWASM;
using System;
// 缓存数据类型
[System.Serializable]
public class Data
{
    public string data1;
    public int data2;
}

public class Storage : Details
{
    private readonly Action<OnBackgroundFetchDataListenerResult> _onBackgroundFetchData = (res) => {
        var result = "onBackgroundFetchData\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private void Start()
    {
        // 监听收到 backgroundFetch 数据事件。
        WX.OnBackgroundFetchData(_onBackgroundFetchData);

        
        GameManager.Instance.detailsController.BindExtraButtonAction(0, getStorage);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, removeStorage);
        GameManager.Instance.detailsController.BindExtraButtonAction(2, removeStorageSync);
        GameManager.Instance.detailsController.BindExtraButtonAction(3, getStorageInfoSync);
        GameManager.Instance.detailsController.BindExtraButtonAction(4, getStorageInfo);
        GameManager.Instance.detailsController.BindExtraButtonAction(5, setBackgroundFetchToken);
        GameManager.Instance.detailsController.BindExtraButtonAction(6, getBackgroundFetchToken);
        GameManager.Instance.detailsController.BindExtraButtonAction(7, getBackgroundFetchData);
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        setStorageSync();
    }

    public void setStorageSync() {
        var d = new Data {
            data1 = "test",
            data2 = 1
        };
        PlayerPrefs.SetString("test1", JsonUtility.ToJson(d));
        PlayerPrefs.Save();
        WX.ShowToast(new ShowToastOption
        {
            title = "设置成功"            
        });
    }


    public void removeStorageSync() {
        WX.RemoveStorageSync("test1");
        WX.ShowToast(new ShowToastOption
        {
            title = "删除test1成功"            
        });
    }

    public void removeStorage() {
        WX.RemoveStorage(new RemoveStorageOption
        {
            key = "test2",
            success = (res) => {
                WX.ShowToast(new ShowToastOption
                {
                    title = "删除test2成功"            
                });
            },
            fail = (res) => {
                Debug.Log("fail: " + res.errMsg);
            },
            complete = (res) => {
                Debug.Log("complete");
            }
        });
    }

    public void getStorageInfoSync() {
       GetStorageInfoSyncOption res = WX.GetStorageInfoSync();
       WX.ShowModal(new ShowModalOption 
       {
            content = JsonMapper.ToJson(res)
       });
    }

    public void getStorageInfo() {
        WX.GetStorageInfo(new GetStorageInfoOption
        {
            success = (res) => {
                WX.ShowModal(new ShowModalOption 
                {
                    content = JsonMapper.ToJson(res)
                });
            },
            fail = (res) => {
                Debug.Log("fail: " + res.errMsg);
            },
            complete = (res) => {
                Debug.Log("complete");
            }
        });
    }

    public void getStorage() {
        var res = PlayerPrefs.GetString("test1");
        Debug.Log("playerperfs: " + res);
        
        WX.ShowModal(new ShowModalOption 
        {
            content = res
        });
    }

    public void setBackgroundFetchToken() {
        WX.SetBackgroundFetchToken(new SetBackgroundFetchTokenOption 
        {
            token = "abcdefghijklmn",
            success = (res) => {
                WX.ShowToast(new ShowToastOption 
                {
                    title = "设置成功"
                });
            },
            fail = (res) => {
                Debug.Log("fail: " + res.errMsg);
            },
            complete = (res) => {
                Debug.Log("complete");
            }
        });
    }

    public void getBackgroundFetchToken() {
        WX.GetBackgroundFetchToken(new GetBackgroundFetchTokenOption 
        {
            success = (res) => {
                WX.ShowModal(new ShowModalOption 
                {
                    content = JsonMapper.ToJson(res)
                });
            },
            fail = (res) => {
                Debug.Log("fail: " + res.errMsg);
            },
            complete = (res) => {
                Debug.Log("complete");
            }
        });
    }

    public void getBackgroundFetchData() {
        WX.GetBackgroundFetchData(new GetBackgroundFetchDataOption 
        {
            fetchType = "pre",
            success = (res) => {
                WX.ShowModal(new ShowModalOption 
                {
                    content = JsonMapper.ToJson(res)
                });
            },
            fail = (res) => {
                Debug.Log("fail: " + res.errMsg);
            },
            complete = (res) => {
                Debug.Log("complete");
            }
        });
    }
}

