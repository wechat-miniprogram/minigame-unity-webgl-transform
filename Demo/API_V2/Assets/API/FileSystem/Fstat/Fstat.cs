using LitJson;
using WeChatWASM;

public class Fstat : Details {
    // 文件系统管理器
    private WXFileSystemManager _fileSystemManager;

    // 文件路径
    // 注意WX.env.USER_DATA_PATH后接字符串需要以/开头
    private static readonly string PathPrefix = WX.env.USER_DATA_PATH + "/Fstat";
    private static readonly string Path = PathPrefix + "/hello.txt";

    // 文件描述符
    private string _fd;

    // 在 Start 方法中初始化
    private void Start() {
        // 获取全局唯一的文件管理器
        _fileSystemManager = WX.GetFileSystemManager();

        // 检查文件路径是否存在，不存在则创建
        if (_fileSystemManager.AccessSync(PathPrefix) != "access:ok") {
            _fileSystemManager.MkdirSync(PathPrefix, true);
        }

        // 打开文件，并将文件描述符存储在 _fd 变量中
        _fd = _fileSystemManager.OpenSync(new OpenSyncOption() {
            filePath = Path,
            flag = "w+"
        });
        // 向文件中写入原始数据
        _fileSystemManager.WriteSync(new WriteSyncStringOption() {
            fd = _fd,
            data = "Original Data "
        });
    }

    // 根据参数调用同步或异步方法
    protected override void TestAPI(string[] args) {
        if (args[0] == "同步执行") {
            RunSync();
        } else {
            RunAsync();
        }
    }

    // 异步方法
    private void RunAsync() {
        // 调用 Fstat 方法获取文件信息
        _fileSystemManager.Fstat(new FstatOption() {
            fd = _fd,
            success = (res) => {
                // 成功回调，显示文件信息
                WX.ShowModal(new ShowModalOption() {
                    content = "Fstat Success, Result: " + JsonMapper.ToJson(res)
                });
            },
            fail = (res) => {
                // 失败回调，显示错误信息
                WX.ShowModal(new ShowModalOption() {
                    content = "Fstat Fail, Result: " + JsonMapper.ToJson(res)
                });
            }
        });
    }

    // 同步方法
    private void RunSync() {
        // 调用 FstatSync 方法获取文件信息，并显示结果
        WX.ShowModal(new ShowModalOption() {
            content = "FstatSync Result: " + JsonMapper.ToJson(_fileSystemManager.FstatSync(new FstatSyncOption() {
                fd = _fd
            }))
        });
    }
}