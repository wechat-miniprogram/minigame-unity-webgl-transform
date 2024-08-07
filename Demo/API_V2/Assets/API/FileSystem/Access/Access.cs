using LitJson;
using WeChatWASM;

public class Access : Details
{
    private WXFileSystemManager _fileSystemManager;

    // 路径
    // 注意WX.env.USER_DATA_PATH后接字符串需要以/开头
    private static readonly string PathPrefix = WX.env.USER_DATA_PATH + "/Access";
    private static readonly string DictionaryPath = PathPrefix + "/exist";
    private static readonly string FilePath = PathPrefix + "/exist/exist.txt";

    private void Start()
    {
        // 获取全局唯一的文件管理器
        _fileSystemManager = WX.GetFileSystemManager();

        // 检查文件夹是否存在，如果不存在则创建
        if (_fileSystemManager.AccessSync(DictionaryPath) != "access:ok")
        {
            _fileSystemManager.MkdirSync(DictionaryPath, true);
        }

        // 打开文件并写入数据
        var fd = _fileSystemManager.OpenSync(
            new OpenSyncOption() { filePath = FilePath, flag = "w+" }
        );
        _fileSystemManager.WriteSync(
            new WriteSyncStringOption() { fd = fd, data = "Original Data " }
        );
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        if (args[0] == "同步执行")
        {
            RunSync(args[1]); // 同步执行
        }
        else
        {
            RunAsync(args[1]); // 异步执行
        }
    }

    // 异步访问文件
    private void RunAsync(string path)
    {
        _fileSystemManager.Access(
            new AccessParam()
            {
                path = PathPrefix + path,
                success = (res) =>
                {
                    // 访问成功，显示结果
                    WX.ShowModal(
                        new ShowModalOption()
                        {
                            content = "Access Success, Result: " + JsonMapper.ToJson(res)
                        }
                    );
                },
                fail = (res) =>
                {
                    // 访问失败，显示结果
                    WX.ShowModal(
                        new ShowModalOption()
                        {
                            content = "Access Fail, Result: " + JsonMapper.ToJson(res)
                        }
                    );
                }
            }
        );
    }

    // 同步访问文件
    private void RunSync(string path)
    {
        // 显示同步访问的结果
        WX.ShowModal(
            new ShowModalOption()
            {
                content = "AccessSync Result: " + _fileSystemManager.AccessSync(PathPrefix + path)
            }
        );
    }
}
