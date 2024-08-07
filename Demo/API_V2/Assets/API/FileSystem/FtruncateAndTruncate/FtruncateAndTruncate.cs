using LitJson;
using WeChatWASM;

public class FtruncateAndTruncate : Details
{
    private WXFileSystemManager _fileSystemManager;

    // 文件路径
    // 注意WX.env.USER_DATA_PATH后接字符串需要以/开头
    private static readonly string PathPrefix = WX.env.USER_DATA_PATH + "/FtruncateAndTruncate";
    private static readonly string Path = PathPrefix + "/hello.txt";

    // 文件描述符
    private string _fd;

    // 在 Start 方法中初始化
    private void Start()
    {
        // 获取全局唯一的文件管理器
        _fileSystemManager = WX.GetFileSystemManager();

        // 检查文件路径是否存在，不存在则创建
        if (_fileSystemManager.AccessSync(PathPrefix) != "access:ok")
        {
            _fileSystemManager.MkdirSync(PathPrefix, true);
        }

        // 打开文件，并将文件描述符存储在 _fd 变量中
        _fd = _fileSystemManager.OpenSync(new OpenSyncOption() { filePath = Path, flag = "w+" });
        // 向文件中写入原始数据
        _fileSystemManager.WriteSync(
            new WriteSyncStringOption() { fd = _fd, data = "Original Data " }
        );

        // 绑定还原按钮
        GameManager.Instance.detailsController.BindExtraButtonAction(0, ResetFile);
    }

    // 根据参数调用截断文件的方法
    protected override void TestAPI(string[] args)
    {
        if (args[0] == "文件描述符")
        {
            RunFtruncate(args[1], args[2]);
        }
        else
        {
            RunTruncate(args[1], args[2]);
        }
    }

    // 根据同步或异步模式调用 Ftruncate 方法
    private void RunFtruncate(string mode, string length)
    {
        if (mode == "同步执行")
        {
            RunFtruncateSync(length);
        }
        else
        {
            RunFtruncateAsync(length);
        }
    }

    // 异步执行 Ftruncate 方法
    private void RunFtruncateAsync(string length)
    {
        _fileSystemManager.Ftruncate(
            new FtruncateOption()
            {
                fd = _fd,
                length = int.Parse(length),
                success = (res) =>
                {
                    // 成功回调，显示文件截断成功信息
                    WX.ShowModal(
                        new ShowModalOption()
                        {
                            content = "Ftruncate Success, Result: " + JsonMapper.ToJson(res)
                        }
                    );

                    UpdateResult();
                },
                fail = (res) =>
                {
                    // 失败回调，显示文件截断失败信息
                    WX.ShowModal(
                        new ShowModalOption()
                        {
                            content = "Ftruncate Fail, Result: " + JsonMapper.ToJson(res)
                        }
                    );
                }
            }
        );
    }

    // 同步执行 Ftruncate 方法
    private void RunFtruncateSync(string length)
    {
        _fileSystemManager.FtruncateSync(
            new FtruncateSyncOption() { fd = _fd, length = int.Parse(length) }
        );

        UpdateResult();

        // 显示文件截断成功提示
        WX.ShowToast(new ShowToastOption() { title = "FtruncateSync Success" });
    }

    // 根据同步或异步模式调用 Truncate 方法
    private void RunTruncate(string mode, string length)
    {
        if (mode == "同步执行")
        {
            RunTruncateSync(length);
        }
        else
        {
            RunTruncateAsync(length);
        }
    }

    // 异步执行 Truncate 方法
    private void RunTruncateAsync(string length)
    {
        _fileSystemManager.Truncate(
            new TruncateOption()
            {
                filePath = Path,
                length = int.Parse(length),
                success = (res) =>
                {
                    // 成功回调，显示文件截断成功信息
                    WX.ShowModal(
                        new ShowModalOption()
                        {
                            content = "Truncate Success, Result: " + JsonMapper.ToJson(res)
                        }
                    );

                    UpdateResult();
                },
                fail = (res) =>
                {
                    // 失败回调，显示文件截断失败信息
                    WX.ShowModal(
                        new ShowModalOption()
                        {
                            content = "Truncate Fail, Result: " + JsonMapper.ToJson(res)
                        }
                    );
                }
            }
        );
    }

    // 同步执行 Truncate 方法
    private void RunTruncateSync(string length)
    {
        _fileSystemManager.TruncateSync(
            new TruncateSyncOption() { filePath = Path, length = int.Parse(length) }
        );

        // 更新结果
        UpdateResult();

        // 显示文件截断成功提示
        WX.ShowToast(new ShowToastOption() { title = "TruncateSync Success" });
    }

    // 更新结果
    private void UpdateResult()
    {
        // 读取文件内容并更新结果
        GameManager
            .Instance.detailsController.resultObjects[0]
            .GetComponent<ResultController>()
            .ChangeContent(_fileSystemManager.ReadFileSync(Path, "utf8"));
    }

    // 重置文件
    private void ResetFile()
    {
        // 重新打开文件，并写入原始数据
        _fd = _fileSystemManager.OpenSync(new OpenSyncOption() { filePath = Path, flag = "w+" });
        _fileSystemManager.WriteSync(
            new WriteSyncStringOption() { fd = _fd, data = "Original Data " }
        );
        // 更新结果
        UpdateResult();

        // 显示文件已重置提示
        WX.ShowToast(new ShowToastOption() { title = "已重置文件" });
    }
}
