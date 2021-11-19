using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WeChatWASM;
using UnityEngine.SceneManagement;

public class Ranking2 : MonoBehaviour
{
    public Button ShowButton;
    public Button CloseButton;
    /// <summary>
    /// 这个仅仅是为了占位，用透明图是为了排行榜还没展示出来前展示底部内容
    /// </summary>
    public RawImage RankBody;
    public GameObject RankingBox;
    public Button GoButton;

    void Start()
    {

        WX.InitSDK((code) => {

            Init();
        });
    }

    void Init()
    {

        ShowButton.onClick.AddListener(() => {
            RankingBox.SetActive(true);
            // 如果父元素占满整个窗口的话，pivot 设置为（0，0），rotation设置为180，则左上角就是离屏幕的距离
            // 注意这里传x,y,width,height是为了点击区域能正确点击，x,y 是距离屏幕左上角的距离，宽度传 (int)RankBody.rectTransform.rect.width是在canvas的UI Scale Mode为 Constant Pixel Size的情况下设置的。如果是Scale With Screen Size,且设置为以宽度作为缩放，则要这要做一下换算，比如canavs宽度为750，rawImage设置为690 则应该传Screen.width*(690/750)。高度为Screen.height*(690/750)。
            var p = RankBody.transform.position;
            var canvasScaler = GameObject.Find("Canvas").GetComponent<CanvasScaler>();
            float scale = Screen.width / canvasScaler.referenceResolution.x; //这里是按宽度来缩放
            int width = (int)(RankBody.rectTransform.rect.width * scale);
            int height = (int)(RankBody.rectTransform.rect.height * scale);
            WX.ShowOpenData(RankBody.texture, (int)p.x, Screen.height - (int)p.y, width, height);
           
        });

        CloseButton.onClick.AddListener(() => {
            RankingBox.SetActive(false);
            WX.HideOpenData();
        });

        GoButton.onClick.AddListener(() => {
            SceneManager.LoadScene(0);
        });
    }
}
