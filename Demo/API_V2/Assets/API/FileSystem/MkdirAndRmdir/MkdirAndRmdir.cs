using LitJson;
using WeChatWASM;

public class MkdirAndRmdir : Details
{
    private WXFileSystemManager _fileSystemManager;
    
    // 路径
    // 注意WX.env.USER_DATA_PATH后接字符串需要以/开头
    private static readonly string PathPrefix = WX.env.USER_DATA_PATH + "/MkdirAndRmdir";
    private static readonly string PathA = PathPrefix + "/a";
    private static readonly string PathB = PathPrefix + "/a/b";
    
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

        // 如果目录已存在，则删除
        if (_fileSystemManager.AccessSync(PathA) == "access:ok")
        {
            _fileSystemManager.RmdirSync(PathA, true);
        }

        // 绑定按钮事件
        GameManager.Instance.detailsController.BindExtraButtonAction(0, RmDir);
    }
    
    // 创建目录
    protected override void TestAPI(string[] args)
    {
        if (args[0] == "同步执行")
        {
            MkdirSync(args[1], args[2]);
        }
        else
        {
            MkdirAsync(args[1], args[2]);
        }
    }
    
    // 删除目录
    private void RmDir()
    {
        if (options[0] == "同步执行")
        {
            RmdirSync(options[1], options[2]);
        }
        else
        {
            RmdirAsync(options[1], options[2]);
        }
    }

    // 同步创建目录
    private void MkdirSync(string dirPath, string recursive)
    {
        WX.ShowModal(new ShowModalOption()
        {
           content = "MkdirSync Result: " + _fileSystemManager.MkdirSync(PathPrefix + dirPath, recursive == "true")
        });
        UpdateResult();
    }

    // 异步创建目录
    private void MkdirAsync(string dirPath, string recursive)
    {
        _fileSystemManager.Mkdir(new MkdirParam()
        {
            dirPath = PathPrefix + dirPath,
            recursive = recursive == "true",
            success = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "MkdirAsync Success, Result: " + JsonMapper.ToJson(res)
                });
                UpdateResult();
            },
            fail = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "MkdirAsync Fail, Result: " + JsonMapper.ToJson(res)
                });
            }
        });
    }
    
    // 同步删除目录
    private void RmdirSync(string dirPath, string recursive)
    {
        WX.ShowModal(new ShowModalOption()
        {
            content = "RmdirSync Result: " + _fileSystemManager.RmdirSync(PathPrefix + dirPath, recursive == "true")
        });
        
        UpdateResult();
    }
    
    // 异步删除目录
    private void RmdirAsync(string dirPath, string recursive)
    {
        _fileSystemManager.Rmdir(new RmdirParam()
        {
            dirPath = PathPrefix + dirPath,
            recursive = recursive == "true",
            success = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "RmdirAsync Success, Result: " + JsonMapper.ToJson(res)
                });
                UpdateResult();
            },
            fail = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "RmdirAsync Fail, Result: " + JsonMapper.ToJson(res)
                });
            }
        });
    }

    // 更新结果
    private void UpdateResult()
    {
        GameManager.Instance.detailsController.SetResultActive(0, _fileSystemManager.AccessSync(PathA) == "access:ok");
        GameManager.Instance.detailsController.SetResultActive(1, _fileSystemManager.AccessSync(PathB) == "access:ok");
    }
}