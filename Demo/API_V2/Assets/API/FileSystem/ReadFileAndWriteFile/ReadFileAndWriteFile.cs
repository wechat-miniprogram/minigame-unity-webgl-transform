using System;
using LitJson;
using WeChatWASM;

public class ReadFileAndWriteFile : Details
{
    private static WXFileSystemManager _fileSystemManager;

    // 路径
    // 注意WX.env.USER_DATA_PATH后接字符串需要以/开头
    private static readonly string PathPrefix = WX.env.USER_DATA_PATH + "/ReadFileAndWriteFile";
    private static readonly string Path = PathPrefix + "/hello.txt";

    // 数据
    private string _stringData = "String Data ";
    private byte[] _bufferData = { 66, 117, 102, 102, 101, 114, 32, 68, 97, 116, 97, 32 };

    // 回调函数
    private Action<WXTextResponse> onWriteFileSuccess = (res) =>
    {
        UpdateFileContent();
        WX.ShowModal(
            new ShowModalOption()
            {
                content = "WriteFile Success, Result: " + JsonMapper.ToJson(res)
            }
        );
    };
    private Action<WXTextResponse> onWriteFileFail = (res) =>
    {
        WX.ShowModal(
            new ShowModalOption() { content = "WriteFile Fail, Result: " + JsonMapper.ToJson(res) }
        );
    };

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

        // 创建文件
        var fd = _fileSystemManager.OpenSync(new OpenSyncOption() { filePath = Path, flag = "w+" });

        // 写入初始数据
        _fileSystemManager.WriteSync(
            new WriteSyncStringOption() { fd = fd, data = "Original Data " }
        );

        // 绑定按钮事件
        GameManager.Instance.detailsController.BindExtraButtonAction(0, WriteFile);
    }

    // 读取文件
    protected override void TestAPI(string[] args)
    {
        if (args[0] == "同步执行")
        {
            ReadFileSync(args[2], args[3], args[4]);
        }
        else
        {
            ReadFileAsync(args[2], args[3], args[4]);
        }
    }

    // 写入文件
    private void WriteFile()
    {
        if (options[0] == "同步执行")
        {
            WriteFileSync(options[1], options[2]);
        }
        else
        {
            WriteFileAsync(options[1], options[2]);
        }
    }

    // 同步读取文件
    private void ReadFileSync(string encoding, string position, string length)
    {
        if (encoding == "null")
        {
            var readResult = _fileSystemManager.ReadFileSync(
                Path,
                position == "null" ? null : (long?)int.Parse(position),
                length == "null" ? null : (long?)int.Parse(length)
            );
            UpdateReadResult(readResult);
        }
        else
        {
            var readResult = _fileSystemManager.ReadFileSync(
                Path,
                encoding,
                position == "null" ? null : (long?)int.Parse(position),
                length == "null" ? null : (long?)int.Parse(length)
            );
            UpdateReadResult(readResult);
        }

        WX.ShowToast(new ShowToastOption() { title = "ReadFileSync Success" });
    }

    // 异步读取文件
    private void ReadFileAsync(string encoding, string position, string length)
    {
        _fileSystemManager.ReadFile(
            new ReadFileParam()
            {
                filePath = Path,
                encoding = encoding == "null" ? null : encoding,
                position = position == "null" ? null : (long?)int.Parse(position),
                length = length == "null" ? null : (long?)int.Parse(length),
                success = (res) =>
                {
                    // 若encoding为null，则数据位于res.binData，否则数据位于res.stringData
                    if (encoding == "null")
                    {
                        UpdateReadResult(res.binData);
                    }
                    else
                    {
                        UpdateReadResult(res.stringData);
                    }
                    WX.ShowToast(new ShowToastOption() { title = "ReadFile Success" });
                }
            }
        );
    }

    // 同步写入文件
    private void WriteFileSync(string dataType, string encoding)
    {
        if (dataType == "string")
        {
            if (encoding == "null")
            {
                _fileSystemManager.WriteFileSync(Path, _stringData);
            }
            else
            {
                _fileSystemManager.WriteFileSync(Path, _stringData, encoding);
            }
        }
        else
        {
            if (encoding == "null")
            {
                _fileSystemManager.WriteFileSync(Path, _bufferData);
            }
            else
            {
                _fileSystemManager.WriteFileSync(Path, _bufferData, encoding);
            }
        }

        // 更新文件内容
        UpdateFileContent();
        WX.ShowToast(new ShowToastOption() { title = "WriteFile Success" });
    }

    // 异步写入文件
    private void WriteFileAsync(string dataType, string encoding)
    {
        if (dataType == "string")
        {
            if (encoding == "null")
            {
                _fileSystemManager.WriteFile(
                    new WriteFileStringParam()
                    {
                        filePath = Path,
                        data = _stringData,
                        success = onWriteFileSuccess,
                        fail = onWriteFileFail
                    }
                );
            }
            else
            {
                _fileSystemManager.WriteFile(
                    new WriteFileStringParam()
                    {
                        filePath = Path,
                        data = _stringData,
                        encoding = encoding,
                        success = onWriteFileSuccess,
                        fail = onWriteFileFail
                    }
                );
            }
        }
        else
        {
            if (encoding == "null")
            {
                _fileSystemManager.WriteFile(
                    new WriteFileParam()
                    {
                        filePath = Path,
                        data = _bufferData,
                        success = onWriteFileSuccess,
                        fail = onWriteFileFail
                    }
                );
            }
            else
            {
                _fileSystemManager.WriteFile(
                    new WriteFileParam()
                    {
                        filePath = Path,
                        data = _bufferData,
                        encoding = encoding,
                        success = onWriteFileSuccess,
                        fail = onWriteFileFail
                    }
                );
            }
        }
    }

    // 更新读取结果（字节数组）
    private void UpdateReadResult(byte[] readResult)
    {
        GameManager.Instance.detailsController.ChangeResultContent(
            0,
            JsonMapper.ToJson(readResult)
        );
    }

    // 更新读取结果（字符串）
    private void UpdateReadResult(string readResult)
    {
        GameManager.Instance.detailsController.ChangeResultContent(0, readResult);
    }

    // 更新文件内容
    private static void UpdateFileContent()
    {
        // 使用UTF8编码显示文件内容
        GameManager.Instance.detailsController.ChangeResultContent(
            1,
            _fileSystemManager.ReadFileSync(Path, "utf8")
        );
    }
}
