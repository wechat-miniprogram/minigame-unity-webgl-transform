using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;

public class Photo : Details
{
    private void Start()
    {
        // 绑定额外的按钮操作
        GameManager.Instance.detailsController.BindExtraButtonAction(0, previewMedia);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, previewImage);
        GameManager.Instance.detailsController.BindExtraButtonAction(2, compressImage);
        GameManager.Instance.detailsController.BindExtraButtonAction(3, chooseMessageFile);
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        saveImageToPhotosAlbum();
    }

    // 图片路径需使用本地路径
    public void saveImageToPhotosAlbum()
    {
        WX.SaveImageToPhotosAlbum(
            new SaveImageToPhotosAlbumOption
            {
                filePath = "xxxx",
                success = (res) =>
                {
                    Debug.Log("success");
                },
                fail = (res) =>
                {
                    Debug.Log("fail:" + res.errMsg);
                },
                complete = (res) =>
                {
                    Debug.Log("complete!");
                }
            }
        );
    }

    public void previewMedia()
    {
        WX.PreviewMedia(
            new PreviewMediaOption
            {
                sources = new MediaSource[]
                {
                    new MediaSource { url = "xxxxx", type = "image" },
                    new MediaSource { url = "yyyy", type = "image" }
                },
                current = 0,
                showmenu = true,
                referrerPolicy = "no-referrer",
                success = (res) =>
                {
                    Debug.Log("success");
                },
                fail = (res) =>
                {
                    Debug.Log("fail:" + res.errMsg);
                },
                complete = (res) =>
                {
                    Debug.Log("complete!");
                }
            }
        );
    }

    public void previewImage()
    {
        WX.PreviewImage(
            new PreviewImageOption
            {
                urls = new string[] { "xxx", "yyy" },
                showmenu = true,
                success = (res) =>
                {
                    Debug.Log("success");
                },
                fail = (res) =>
                {
                    Debug.Log("fail:" + res.errMsg);
                },
                complete = (res) =>
                {
                    Debug.Log("complete!");
                }
            }
        );
    }

    public void compressImage()
    {
        WX.CompressImage(
            new CompressImageOption
            {
                src = "xxxx",
                quality = 80,
                compressedWidth = 500,
                compressedHeight = 500,
                success = (res) =>
                {
                    Debug.Log("success " + JsonMapper.ToJson(res));
                },
                fail = (res) =>
                {
                    Debug.Log("fail:" + res.errMsg);
                },
                complete = (res) =>
                {
                    Debug.Log("complete!");
                }
            }
        );
    }

    public void chooseMessageFile()
    {
        WX.ChooseMessageFile(
            new ChooseMessageFileOption
            {
                count = 10,
                type = "image",
                success = (res) =>
                {
                    Debug.Log("success " + JsonMapper.ToJson(res));
                },
                fail = (res) =>
                {
                    Debug.Log("fail:" + res.errMsg);
                },
                complete = (res) =>
                {
                    Debug.Log("complete!");
                }
            }
        );
    }
}
