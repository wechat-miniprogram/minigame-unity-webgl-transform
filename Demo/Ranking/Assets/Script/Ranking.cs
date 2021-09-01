using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WeChatWASM;

public class Ranking : MonoBehaviour
{
    public Button ShowButton;
    public Button CloseButton;
    public RawImage RankBody;
    public GameObject RankingBox;

    void Start()
    {
        WX.InitSDK((code)=> {

            Init();
        });
    }

    void Init()
    {
        ShowButton.onClick.AddListener(()=> {
            RankingBox.SetActive(true);
            // 如果父元素占满整个窗口的话，pivot 设置为（0，0），rotation设置为180，则左上角就是离屏幕的距离
            var p = RankBody.transform.position;
            WX.ShowOpenData(RankBody.texture, (int)p.x, Screen.height-(int)p.y, (int)RankBody.rectTransform.rect.width, (int)RankBody.rectTransform.rect.height);
        });

        CloseButton.onClick.AddListener(()=> {
            RankingBox.SetActive(false);
            WX.HideOpenData();
        });
    }

}
