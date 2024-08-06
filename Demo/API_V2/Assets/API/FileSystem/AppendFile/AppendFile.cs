using System;
using LitJson;
using WeChatWASM;

public class AppendFile : Details {
    private static WXFileSystemManager _fileSystemManager;

    // 路径
    // 注意WX.env.USER_DATA_PATH后接字符串需要以/开头
    private static readonly string PathPrefix = WX.env.USER_DATA_PATH + "/AppendFile";
    private static readonly string Path = PathPrefix + "/hello.txt";

    // 数据
    private string _stringData = "String Data ";
    private byte[] _bufferData = { 66, 117, 102, 102, 101, 114, 32, 68, 97, 116, 97, 32 };

    // 成功和失败的回调函数
    private Action<WXTextResponse> onSuccess = (res) => {
        // 显示成功的模态对话框
        WX.ShowModal(new ShowModalOption() {
            content = "AppendFile Success, Result: " + JsonMapper.ToJson(res)
        });
        UpdateResult(); // 更新结果
    };
    private Action<WXTextResponse> onFail = (res) => {
        // 显示失败的模态对话框
        WX.ShowModal(new ShowModalOption() {
            content = "AppendFile Fail, Result: " + JsonMapper.ToJson(res)
        });
    };

    private void Start() {
        // 获取全局唯一的文件管理器
        _fileSystemManager = WX.GetFileSystemManager();

        // 检查文件夹是否存在，如果不存在则创建
        if (_fileSystemManager.AccessSync(PathPrefix) != "access:ok") {
            _fileSystemManager.MkdirSync(PathPrefix, true);
        }

        // 打开文件并写入数据
        var fd = _fileSystemManager.OpenSync(new OpenSyncOption() {
            filePath = Path,
            flag = "w+"
        });

        _fileSystemManager.WriteSync(new WriteSyncStringOption() {
            fd = fd,
            data = "Original Data "
        });

        // 绑定额外的按钮操作
        GameManager.Instance.detailsController.BindExtraButtonAction(0, ResetFile);
    }

    // 测试 API
    protected override void TestAPI(string[] args) {
        if (args[0] == "同步执行") {
            RunSync(args[1], args[2]); // 同步执行
        } else {
            RunAsync(args[1], args[2]); // 异步执行
        }
    }

    // 异步追加文件
    private void RunAsync(string dataType, string encoding) {
        if (dataType == "byte[]") {
            if (encoding == "null") {
                _fileSystemManager.AppendFile(new WriteFileParam() {
                    filePath = Path,
                    data = _bufferData,
                    success = onSuccess,
                    fail = onFail
                });
            } else {
                _fileSystemManager.AppendFile(new WriteFileParam() {
                    filePath = Path,
                    data = _bufferData,
                    encoding = encoding,
                    success = onSuccess,
                    fail = onFail
                });
            }
        } else {
            if (encoding == "null") {
                _fileSystemManager.AppendFile(new WriteFileStringParam() {
                    filePath = Path,
                    data = _stringData,
                    success = onSuccess,
                    fail = onFail
                });
            } else {
                _fileSystemManager.AppendFile(new WriteFileStringParam() {
                    filePath = Path,
                    data = _stringData,
                    encoding = encoding,
                    success = onSuccess,
                    fail = onFail
                });
            }
        }
    }

    // 同步追加文件
    private void RunSync(string dataType, string encoding) {
        if (dataType == "byte[]") {
            if (encoding == "null") {
                _fileSystemManager.AppendFileSync(Path, _bufferData);
            } else {
                _fileSystemManager.AppendFileSync(Path, _bufferData, encoding);
            }
        } else {
            if (encoding == "null") {
                _fileSystemManager.AppendFileSync(Path, _stringData);
            } else {
                _fileSystemManager.AppendFileSync(Path, _stringData, encoding);
            }
        }

        UpdateResult(); // 更新结果

        // 显示成功的提示
        WX.ShowToast(new ShowToastOption() {
            title = "AppendFileSync Success"
        });
    }

    // 更新文件内容显示结果
    private static void UpdateResult() {
        GameManager.Instance.detailsController.ChangeResultContent(0, _fileSystemManager.ReadFileSync(Path, "utf8"));
    }

    // 重置文件内容
    private void ResetFile() {
        // 重新打开文件并写入原始数据
        var fd = _fileSystemManager.OpenSync(new OpenSyncOption() {
            filePath = Path,
            flag = "w+"
        });
        _fileSystemManager.WriteSync(new WriteSyncStringOption() {
            fd = fd,
            data = "Original Data "
        });

        UpdateResult(); // 更新结果

        // 显示已重置文件的提示
        WX.ShowToast(new ShowToastOption() {
            title = "已重置文件"
        });
    }
}