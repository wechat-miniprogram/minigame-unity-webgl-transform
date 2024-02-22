using LitJson;
using WeChatWASM;

public class LocalCacheFile : Details
{
    private WXFileSystemManager _fileSystemManager;
    
    // 在 Start 方法中初始化
    private void Start()
    {
        // 获取全局唯一的文件管理器
        _fileSystemManager = WX.GetFileSystemManager();

        // 绑定按钮事件
        GameManager.Instance.detailsController.BindExtraButtonAction(0, GenerateCacheFile);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, ClearCacheFile);
        GameManager.Instance.detailsController.BindExtraButtonAction(2, GetCacheFileInfo);
    }
    
    // 刷新缓存文件列表
    private void RefreshCacheFileList()
    {
        GameManager.Instance.detailsController.KeepFirstNResults(1);
        
        // 获取缓存文件列表
        _fileSystemManager.GetSavedFileList(new GetSavedFileListOption()
        {
            success = (res) =>
            {
                // 可视化展示
                foreach (var file in res.fileList)
                {
                    var content = "创建时间：" + file.createTime + "\n" +
                                  "文件大小：" + file.size + "\n" +
                                  "文件路径：" + file.filePath;
                    GameManager.Instance.detailsController.AddResult(new ResultData()
                    {
                        initialContentText = content
                    });
                }
            },
            fail = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "GetSavedFileList Fail, Result: " + JsonMapper.ToJson(res)
                });
            }
        });
    }
    
    // 测试API方法
    protected override void TestAPI(string[] args)
    {
        RefreshCacheFileList();
        WX.ShowToast(new ShowToastOption()
        {
            title = "刷新缓存文件列表成功"
        });
    }
    
    // 生成缓存文件
    private void GenerateCacheFile()
    {
        WX.ShowLoading(new ShowLoadingOption()
        {
            title = "下载临时文件中",
            mask = true
        });
        // 由DownloadFile接口生成临时文件路径
        WX.DownloadFile(new DownloadFileOption()
        {
            url = "https://res.wx.qq.com/wechatgame/product/webpack/userupload/20190813/advideo.MP4",
            success = (res) =>
            {
                WX.HideLoading(new HideLoadingOption());
                WX.ShowLoading(new ShowLoadingOption()
                {
                    title = "缓存文件中",
                    mask = true
                });
                // 将临时文件保存为缓存文件，注意不填写filePath参数才会保存为缓存文件
                _fileSystemManager.SaveFile(new SaveFileOption()
                {
                    tempFilePath = res.tempFilePath,
                    success = (res2) =>
                    {
                        WX.HideLoading(new HideLoadingOption());
                        RefreshCacheFileList();
                        WX.ShowToast(new ShowToastOption()
                        {
                            title = "生成缓存文件成功"
                        });
                    },
                    fail = (res2) =>
                    {
                        WX.HideLoading(new HideLoadingOption());
                        WX.ShowModal(new ShowModalOption()
                        {
                            content = "SaveFile Fail, Result: " + JsonMapper.ToJson(res2)
                        });
                    }
                });

            },
            fail = (res) =>
            {
                WX.HideLoading(new HideLoadingOption());
                WX.ShowModal(new ShowModalOption()
                {
                    content = "DownloadFile Fail, Result: " + JsonMapper.ToJson(res)
                });
            }
        });
    }

    // 清空缓存文件
    private void ClearCacheFile()
    {
        // 获取缓存文件列表
        _fileSystemManager.GetSavedFileList(new GetSavedFileListOption()
        {
            success = (res) =>
            {
                for (var i = 0; i < res.fileList.Length; i++)
                {
                    // 移除单个缓存文件
                    var i1 = i;
                    _fileSystemManager.RemoveSavedFile(new RemoveSavedFileOption()
                    {
                        filePath = res.fileList[i].filePath,
                        success = (res2) =>
                        {
                            if (i1 == res.fileList.Length - 1)
                            {
                                RefreshCacheFileList();
                                WX.ShowToast(new ShowToastOption()
                                {
                                    title = "清空缓存文件成功"
                                });
                            }
                        },
                        fail = (res2) =>
                        {
                            WX.ShowModal(new ShowModalOption()
                            {
                                content = "RemoveSavedFile Fail, Result: " + JsonMapper.ToJson(res2)
                            });
                        }
                    });
                }
            },
            fail = (res) =>
            {
                WX.ShowModal(new                ShowModalOption()
                {
                    content = "GetSavedFileList Fail, Result: " + JsonMapper.ToJson(res)
                });
            }
        });
    }
    
    // 获取缓存文件信息
    private void GetCacheFileInfo()
    {
        // 获取缓存文件列表
        _fileSystemManager.GetSavedFileList(new GetSavedFileListOption()
        {
            success = (res) =>
            {
                if (res.fileList.Length == 0)
                {
                    // 如果没有缓存文件，提示用户
                    WX.ShowModal(new ShowModalOption()
                    {
                        content = "请先生成缓存文件！"
                    });
                }
                else
                {
                    // 获取第一个缓存文件的文件信息
                    _fileSystemManager.GetFileInfo(new GetFileInfoOption()
                    {
                        // 路径可以是代码包绝对路径、本地临时路径、本地路径和本地缓存路径
                        filePath = res.fileList[0].filePath,
                        success = (res2) =>
                        {
                            // 显示文件信息
                            WX.ShowModal(new ShowModalOption()
                            {
                                content = "GetFileInfo Success, Result: " + JsonMapper.ToJson(res2)
                            });
                        },
                        fail = (res2) =>
                        {
                            // 显示错误信息
                            WX.ShowModal(new ShowModalOption()
                            {
                                content = "GetFileInfo Fail, Result: " + JsonMapper.ToJson(res2)
                            });
                        }
                    });
                }
            },
            fail = (res) =>
            {
                // 显示错误信息
                WX.ShowModal(new ShowModalOption()
                {
                    content = "GetSavedFileList Fail, Result: " + JsonMapper.ToJson(res)
                });
            }
        });
    }
}