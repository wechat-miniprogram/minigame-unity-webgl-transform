using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using WeChatWASM;

public class WebRequest : Details {
    // Start is called before the first frame update
    void Start() {
        GameManager.Instance.detailsController.BindExtraButtonAction(0, testPost);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, testGet);
    }

    // 测试API
    protected override void TestAPI(string[] args) {
        testPut();
    }

    private void testGet() {
        StartCoroutine(Get());
    }

    private void testPost() {
        StartCoroutine(Post());
    }

    private void testPut() {
        StartCoroutine(Put());
    }

    IEnumerator Get() {
        UnityWebRequest webRequest = UnityWebRequest.Get("https://postman-echo.com/get");

        yield return webRequest.SendWebRequest();

        if (webRequest.isHttpError || webRequest.isNetworkError)
            Debug.Log(webRequest.error);
        else {
            Debug.Log("get complete: " + webRequest.downloadHandler.text);
        }

    }

    IEnumerator Post() {
        WWWForm form = new WWWForm();
        //键值对
        form.AddField("key", "value");
        form.AddField("name", "mafanwei");
        form.AddField("blog", "qwe25878");

        UnityWebRequest webRequest = UnityWebRequest.Post("https://postman-echo.com/post", form);

        yield return webRequest.SendWebRequest();

        if (webRequest.isHttpError || webRequest.isNetworkError)
            Debug.Log(webRequest.error);
        else {
            Debug.Log("post complete: " + webRequest.downloadHandler.text);
        }
    }

    IEnumerator Put() {
        byte[] myData = System.Text.Encoding.UTF8.GetBytes("This is some test data");
        UnityWebRequest www = UnityWebRequest.Put("https://postman-echo.com/put", myData);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        } else {
            Debug.Log("Put complete: " + www.downloadHandler.text);
        }
    }
}