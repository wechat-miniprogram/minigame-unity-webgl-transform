using System;
using LitJson;
using WeChatWASM;

public class OpenAndClose : Details
{
    private WXFileSystemManager _fileSystemManager;

    // 路径
    // 注意WX.env.USER_DATA_PATH后接字符串需要以/开头
    private static readonly string PathPrefix = WX.env.USER_DATA_PATH + "/OpenAndClose";
    private static readonly string Path1 = PathPrefix + "/exist.txt";
    private static readonly string Path2 = PathPrefix + "/notExist.txt";

    // 文件描述符
    private string[] _fd;

    // 在 Start 方法中初始化
    private void Start()
    {
        // 获取全局唯一的文件管理器
        _fileSystemManager = WX.GetFileSystemManager();

        // 检查并创建目录
        if (_fileSystemManager.AccessSync(PathPrefix) != "access:ok")
        {
            _fileSystemManager.MkdirSync(PathPrefix, true);
        }

        // 初始化文件描述符数组
        _fd = new string[2];
        var fd = _fileSystemManager.OpenSync(new OpenSyncOption()
        {
            filePath = Path1,
            flag = "w+"
        });
        _fileSystemManager.WriteSync(new WriteSyncStringOption()
        {
            fd = fd,
            data = "Original Data "
        });

        // 如果文件存在，则删除
        if (_fileSystemManager.AccessSync(Path2) == "access:ok")
        {
            _fileSystemManager.UnlinkSync(Path2);
        }

        // 绑定按钮事件
        GameManager.Instance.detailsController.BindExtraButtonAction(0, Close);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, ResetDetails);
    }

    // 打开文件
    protected override void TestAPI(string[] args)
    {
        if (args[0] == "同步执行")
        {
            OpenSync(args[1], args[2]);
        }
        else
        {
            OpenAsync(args[1], args[2]);
        }
    }

    // 关闭文件
    private void Close()
    {
        if (options[0] == "同步执行")
        {
            CloseSync(options[1]);
        }
        else
        {
            CloseAsync(options[1]);
        }
    }

    // 重置
    private void ResetDetails()
    {
        // 重置文件描述符数组
        _fd = new string[2];
        var fd = _fileSystemManager.OpenSync(new OpenSyncOption()
        {
            filePath = Path1,
            flag = "w+"
        });
        _fileSystemManager.WriteSync(new WriteSyncStringOption()
        {
            fd = fd,
            data = "Original Data "
        });

        // 如果文件存在，则删除
        if (_fileSystemManager.AccessSync(Path2) == "access:ok")
        {
            _fileSystemManager.UnlinkSync(Path2);
        }

        // 更新结果
        UpdateResults();
        GameManager.Instance.detailsController.SetResultActive(3, false);
        GameManager.Instance.detailsController.SetResultActive(4, false);

        // 显示已重置提示
        WX.ShowToast(new ShowToastOption()
        {
            title = "已重置"
        });
    }

    // 同步打开文件
    private void OpenSync(string filePath, string flag)
    {
        var index = filePath == "/exist.txt" ? 0 : 1;

        try
        {
            _fd[index] = _fileSystemManager.OpenSync(new OpenSyncOption()
            {
                filePath = PathPrefix + filePath,
                flag = flag == "null" ? null : flag
            });
        }
        catch (Exception e)
        {
            WX.ShowModal(new ShowModalOption()
            {
                content = "OpenSync Fail, Exception: " + e.Message
            });
            return;
        }

        // 更新结果
        GameManager.Instance.detailsController.SetResultActive(index + 3, true);

        // 显示打开文件成功提示
        WX.ShowModal(new ShowModalOption()
        {
            content = "OpenSync Success, fd: " + _fd[index]
        });
    }

    // 异步打开文件
    private void OpenAsync(string filePath, string flag)
    {
        var index = filePath == "/exist.txt" ? 0 : 1;

        _fileSystemManager.Open(new OpenOption()
        {
            filePath = filePath,
            flag = flag == "null" ? null : flag,
            success = (res) =>
            {
                _fd[index] = res.fd;
                GameManager.Instance.detailsController.SetResultActive(index + 3, true);
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Open Success, Result: " + JsonMapper.ToJson(res)
                });
            },
            fail = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Open Fail, Result: " + JsonMapper.ToJson(res)
                });
            }
        });
    }

    // 同步关闭文件
    private void CloseSync(string filePath)
    {
        var index = filePath == "/exist.txt" ? 0 : 1;

        _fileSystemManager.CloseSync(new CloseSyncOption()
        {
            fd = _fd[index]
        });

        // 更新结果
        GameManager.Instance.detailsController.SetResultActive(index + 3, false);

        // 显示关闭文件成功提示
        WX.ShowToast(new ShowToastOption()
        {
            title = "CloseSync Success"
        });
    }

    // 异步关闭文件
    private void CloseAsync(string filePath)
    {
        var index = filePath == "/exist.txt" ? 0 : 1;

        _fileSystemManager.Close(new FileSystemManagerCloseOption()
        {
            fd = _fd[index],
            success = (res) =>
            {
                // 更新结果
                GameManager.Instance.detailsController.SetResultActive(index + 3, false);
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Close Success, Result: " + JsonMapper.ToJson(res)
                });
            },
            fail = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Close Fail, Result: " + JsonMapper.ToJson(res)
                });
            }
        });
    }

    // 更新结果
    private void UpdateResults()
    {
        GameManager.Instance.detailsController.SetResultActive(0, _fileSystemManager.AccessSync(Path1) == "access:ok");
        GameManager.Instance.detailsController.SetResultActive(1, _fileSystemManager.AccessSync(Path1) == "access:ok");
    }
}