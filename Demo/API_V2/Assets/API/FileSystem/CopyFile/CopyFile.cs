using LitJson;
using WeChatWASM;

public class CopyFile : Details
{
    private WXFileSystemManager _fileSystemManager;

    // 路径
    // 注意WX.env.USER_DATA_PATH后接字符串需要以/开头
    private static readonly string PathPrefix = WX.env.USER_DATA_PATH + "/CopyFile";
    private static readonly string Path = PathPrefix + "/hello.txt";
    private static readonly string SyncPath = PathPrefix + "/copyFileSync.txt";
    private static readonly string AsyncPath = PathPrefix + "/copyFileAsync.txt";

    private void Start()
    {
        // 获取全局唯一的文件管理器
        _fileSystemManager = WX.GetFileSystemManager();

        // 检查文件夹是否存在，如果不存在则创建
        if (_fileSystemManager.AccessSync(PathPrefix) != "access:ok")
        {
            _fileSystemManager.MkdirSync(PathPrefix, true);
        }

        // 打开文件并写入数据
        var fd = _fileSystemManager.OpenSync(new OpenSyncOption()
        {
            filePath = Path,
            flag = "w+"
        });

        _fileSystemManager.WriteSync(new WriteSyncStringOption()
        {
            fd = fd,
            data = "Original Data "
        });

        // 如果复制的文件已存在，则删除
        if (_fileSystemManager.AccessSync(SyncPath) == "access:ok")
        {
            _fileSystemManager.UnlinkSync(SyncPath);
        }
        if (_fileSystemManager.AccessSync(AsyncPath) == "access:ok")
        {
            _fileSystemManager.UnlinkSync(AsyncPath);
        }

        // 绑定额外的按钮操作
        GameManager.Instance.detailsController.BindExtraButtonAction(0, ClearCopyFile);
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        if (args[0] == "同步执行")
        {
            RunSync(); // 同步执行
        }
        else
        {
            RunAsync(); // 异步执行
        }
    }

    // 异步复制文件
    private void RunAsync()
    {
        _fileSystemManager.CopyFile(new CopyFileParam()
        {
            srcPath = Path,
            destPath = AsyncPath,
            success = (res) =>
            {
                // 显示成功的模态对话框
                WX.ShowModal(new ShowModalOption()
                {
                    content = "CopeFile Success, Result: " + JsonMapper.ToJson(res)
                                                           + "\nCopied File Content: " + _fileSystemManager.ReadFileSync(AsyncPath, "utf8")
                });
                UpdateResults(); // 更新结果
            },
            fail = (res) =>
            {
                // 显示失败的模态对话框
                WX.ShowModal(new ShowModalOption()
                {
                    content = "CopyFile Fail, Result: " + JsonMapper.ToJson(res)
                });
            }
        });
    }

    // 同步复制文件
    private void RunSync()
    {
        // 显示同步复制文件的结果
        WX.ShowModal(new ShowModalOption()
        {
            content = "CopyFileSync Result: " + _fileSystemManager.CopyFileSync(Path, SyncPath)
            + "\nCopied File Content: " + _fileSystemManager.ReadFileSync(Path, "utf8")
        });
        UpdateResults(); // 更新结果
    }

    // 清除复制的文件
    private void ClearCopyFile()
    {
        // 如果复制的文件已存在，则删除
        if (_fileSystemManager.AccessSync(SyncPath) == "access:ok")
        {
            _fileSystemManager.UnlinkSync(SyncPath);
        }
        if (_fileSystemManager.AccessSync(AsyncPath) == "access:ok")
        {
            _fileSystemManager.UnlinkSync(AsyncPath);
        }

        UpdateResults(); // 更新结果

        // 显示已清除复制文件的提示
        WX.ShowToast(new ShowToastOption()
        {
            title = "已清除复制文件"
        });
    }

    // 更新结果显示
    private void UpdateResults()
    {
        GameManager.Instance.detailsController.SetResultActive(0, _fileSystemManager.AccessSync(Path) == "access:ok");
        GameManager.Instance.detailsController.SetResultActive(1, _fileSystemManager.AccessSync(SyncPath) == "access:ok");
        GameManager.Instance.detailsController.SetResultActive(2, _fileSystemManager.AccessSync(AsyncPath) == "access:ok");
    }
}