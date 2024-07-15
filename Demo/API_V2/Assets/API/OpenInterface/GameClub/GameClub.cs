using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using WeChatWASM;

public class GameClub : Details
{
    private int[] _data = { 1, 2 };

    // Start is called before the first frame update
    private void Start()
    {
        //Placeholder for later tests
    }

    // ≤‚ ‘ API
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

}
