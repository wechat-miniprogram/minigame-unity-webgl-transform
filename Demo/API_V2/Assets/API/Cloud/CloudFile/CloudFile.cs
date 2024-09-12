using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;

public class CloudFile : Details
{
    private void Start()
    {
        GameManager.Instance.detailsController.BindExtraButtonAction(0, CloudDownloadFile);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, CloudDeleteFile);
        GameManager.Instance.detailsController.BindExtraButtonAction(2, CloudGetTempFileURL);

        WX.cloud.Init(); // 注意初始化
    }

    protected override void TestAPI(string[] args)
    {
        this.CloudUploadFile();
    }

    // 使用默认云开发操作实例调用云托管
    private void CloudUploadFile()
    {
        WX.cloud.UploadFile(new UploadFileParam()
        {
            cloudPath = "abilityOpen.png", // 云存储文件路径
            filePath = "/abilityOpen.png", // 实际文件路径
            success = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Cloud UploadFile Success: " + JsonMapper.ToJson(res)
                });
            },
            fail = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Cloud UploadFile Fail: " + JsonMapper.ToJson(res)
                });
            },
            complete = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Cloud UploadFile Complete: " + JsonMapper.ToJson(res)
                });
            }
        });
    }

    private void CloudDownloadFile()
    {
        WX.cloud.DownloadFile(new DownloadFileParam()
        {
            fileID = "cloud://cloud1-xxx/abilityOpen.png", // 云存储文件路径
            success = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Cloud DownloadFile Success: " + JsonMapper.ToJson(res)
                });
            },
            fail = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Cloud DownloadFile Fail: " + JsonMapper.ToJson(res)
                });
            },
            complete = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Cloud DownloadFile Complete: " + JsonMapper.ToJson(res)
                });
            }
        });
    }

    private void CloudDeleteFile()
    {
        WX.cloud.DeleteFile(new DeleteFileParam()
        {
            fileList = new [] { "cloud://cloud1-xxx/abilityOpen.png" }, // 云存储文件路径
            success = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Cloud DeleteFile Success: " + JsonMapper.ToJson(res)
                });
            },
            fail = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Cloud DeleteFile Fail: " + JsonMapper.ToJson(res)
                });
            },
            complete = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Cloud DeleteFile Complete: " + JsonMapper.ToJson(res)
                });
            }
        });
    }

    private void CloudGetTempFileURL()
    {
        WX.cloud.GetTempFileURL(new GetTempFileURLParam()
        {
            fileList = new [] { "cloud://cloud1-xxx/abilityOpen.png" }, // 云存储文件路径
            success = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Cloud GetTempFileURL Success: " + JsonMapper.ToJson(res)
                });
            },
            fail = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Cloud GetTempFileURL Fail: " + JsonMapper.ToJson(res)
                });
            },
            complete = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Cloud GetTempFileURL Complete: " + JsonMapper.ToJson(res)
                });
            }
        });
    }
}
