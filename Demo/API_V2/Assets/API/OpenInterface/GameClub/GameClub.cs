using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using WeChatWASM;
using System.Threading;

public class GameClub : Details
{
    private int[] _data = { 1, 3, 4 };

    private WXGameClubButton _gameClubButton;

    // Start is called before the first frame update
    private void Start()
    {
        var result = WX.GetLaunchOptionsSync();
        Debug.Log(JsonUtility.ToJson(result));

        StartCoroutine(CreateGameClubButton(1.0f));

        GameManager.Instance.detailsController.BindExtraButtonAction(0, GameClubButtonSwitch);
    }

    IEnumerator CreateGameClubButton(float delay)
    {
        yield return new WaitForSeconds(delay);

        Vector2 size = GameManager.Instance.detailsController.GetInitialButtonSize();
        Vector2 position = GameManager.Instance.detailsController.GetButtonPosition(0);
        var systemInfo = WX.GetSystemInfoSync();
        _gameClubButton = WX.CreateGameClubButton(new WXCreateGameClubButtonParam()
        {
            type = GameClubButtonType.text,
            style = new GameClubButtonStyle()
            {
                left = Math.Abs((int)(position.x / systemInfo.pixelRatio)),
                top = Math.Abs((int)(position.y / systemInfo.pixelRatio)),
                width = (int)(size.x * systemInfo.screenWidth / 1080f),
                height = (int)(size.y * systemInfo.screenWidth / 1080f),
            }
        });
    }

    // 测试API
    protected override void TestAPI(string[] args)
    {
        getGameClubData();
    }

    private void getGameClubData()
    {
        GetGameClubDataOption option = new GetGameClubDataOption();

        option.dataTypeList = new DataType[_data.Length];

        for (int i = 0; i < _data.Length; i++)
        {
            option.dataTypeList[i] = new DataType();
            option.dataTypeList[i].type = _data[i];
        }

        option.fail = (res) =>
        {
            Debug.Log("GetGameClubData fail: " + res.errMsg);
        };

        option.complete = (res) =>
        {
            Debug.Log("GetGameClubData complete: " + JsonUtility.ToJson(res));
        };

        option.success = (res) =>
        {
            Debug.Log("GetGameClubData success: " + JsonUtility.ToJson(res));
            Debug.Log("encryptedData:" + res.encryptedData);
        };

        WX.GetGameClubData(option);
    }

    private bool _isGameClubShow = false;

    // 切换游戏圈按钮显示/隐藏
    private void GameClubButtonSwitch()
    {
        // if (_isGameClubShow)
        // {
        //     // 显示游戏圈按钮
        //     _gameClubButton.Show();
        //     GameManager.Instance.detailsController.ChangeExtraButtonText(0, "隐藏游戏圈按钮");
        // }
        // else
        // {
        //     // 隐藏游戏圈按钮
        //     _gameClubButton.Hide();
        //     GameManager.Instance.detailsController.ChangeExtraButtonText(0, "显示游戏圈按钮");
        // }
        // _isGameClubShow = !_isGameClubShow;
    }

    private void GameClubButtonDestroy()
    {
        Debug.Log("gameclub destroy");
        _gameClubButton.Destroy();
    }

    public void Destroy()
    {
        if (_gameClubButton != null)
        {
            _gameClubButton.Hide();
            GameClubButtonDestroy();
            _gameClubButton = null;
        }
    }

}