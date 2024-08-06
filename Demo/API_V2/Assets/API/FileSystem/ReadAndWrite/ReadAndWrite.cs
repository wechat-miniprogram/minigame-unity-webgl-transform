using System;
using System.Text;
using LitJson;
using UnityEngine;
using WeChatWASM;

public class ReadAndWrite : Details {
    private static WXFileSystemManager _fileSystemManager;

    // 路径
    // 注意WX.env.USER_DATA_PATH后接字符串需要以/开头
    private static readonly string PathPrefix = WX.env.USER_DATA_PATH + "/ReadAndWrite";
    private static readonly string Path = PathPrefix + "/hello.txt";

    // 用于读取数据的缓存
    private byte[] _buffer;

    // 文件描述符
    private string _fd;

    // 数据
    private string _stringData = "String Data ";
    private byte[] _bufferData = { 66, 117, 102, 102, 101, 114, 32, 68, 97, 116, 97, 32 };

    // 回调函数
    private Action<WriteSuccessCallbackResult> onWriteSuccess = (res) => {
        UpdateFileContent();
        WX.ShowModal(new ShowModalOption() {
            content = "Write Success, Result: " + JsonMapper.ToJson(res)
        });
    };
    private Action<FileError> onWriteFail = (res) => {
        WX.ShowModal(new ShowModalOption() {
            content = "Write Fail, Result: " + JsonMapper.ToJson(res)
        });
    };

    // 在 Start 方法中初始化
    private void Start() {
        // 获取全局唯一的文件管理器
        _fileSystemManager = WX.GetFileSystemManager();

        // 检查并创建目录
        if (_fileSystemManager.AccessSync(PathPrefix) != "access:ok") {
            _fileSystemManager.MkdirSync(PathPrefix, true);
        }

        // 打开文件，并写入初始数据
        _fd = _fileSystemManager.OpenSync(new OpenSyncOption() {
            filePath = Path,
            flag = "w+"
        });

        _fileSystemManager.WriteSync(new WriteSyncStringOption() {
            fd = _fd,
            data = "Original Data "
        });

        // 绑定按钮事件
        GameManager.Instance.detailsController.BindExtraButtonAction(0, Write);
    }

    /***** Buttons *****/
    // 读取文件
    protected override void TestAPI(string[] args) {
        _buffer = new byte[20];

        // 根据参数决定执行同步读取还是异步读取
        if (args[0] == "同步执行") {
            ReadSync(args[2], args[3], args[5]);
        } else {
            ReadAsync(args[2], args[3], args[5]);
        }
    }

    // 写入文件
    private void Write() {
        // 根据参数决定执行同步写入还是异步写入
        if (options[0] == "同步执行") {
            WriteSync(options[1], options[2], options[3], options[4], options[5]);
        } else {
            WriteAsync(options[1], options[2], options[3], options[4], options[5]);
        }
    }
    /***** Buttons *****/

    // 同步读取
    private void ReadSync(string offset, string length, string position) {
        WX.ShowModal(new ShowModalOption() {
            content = "ReadSync接口暂无法正常使用"
        });
        return;
        var readResult = _fileSystemManager.ReadSync(new ReadSyncOption() {
            arrayBuffer = _buffer,
            fd = _fd,
            length = length == "null" ? null : (double?)int.Parse(length),
            offset = offset == "null" ? null : (double?)int.Parse(offset),
            position = position == "null" ? null : (double?)int.Parse(position)
        });

        // 更新读取结果
        UpdateReadResult();
        WX.ShowToast(new ShowToastOption() {
            title = "ReadSync Success"
        });

        // 下列buffer为同一份引用
        Debug.Log("option buffer: " + JsonMapper.ToJson(_buffer));
        Debug.Log("result buffer: " + JsonMapper.ToJson(readResult.arrayBuffer));
    }

    // 异步读取
    private void ReadAsync(string offset, string length, string position) {
        _fileSystemManager.Read(new ReadOption() {
            arrayBuffer = _buffer,
            fd = _fd,
            length = length == "null" ? null : (double?)int.Parse(length),
            offset = offset == "null" ? null : (double?)int.Parse(offset),
            position = position == "null" ? null : (double?)int.Parse(position),
            success = (res) => {
                // 更新读取结果
                UpdateReadResult();
                WX.ShowModal(new ShowModalOption() {
                    content = "Read Success, bytesRead: " + res.bytesRead
                });
                // 下列buffer为同一份引用
                // Debug.Log("option buffer: " + JsonMapper.ToJson(_buffer));
                // Debug.Log("result buffer: " + JsonMapper.ToJson(res.arrayBuffer));
            },
            fail = (res) => {
                WX.ShowModal(new ShowModalOption() {
                    content = "Read Fail, Result: " + JsonMapper.ToJson(res)
                });
            }
        });
    }

    // 同步写入
    private void WriteSync(string dataType, string offset, string length, string encoding, string position) {
        WriteResult writeResult;
        if (dataType == "string") {
            writeResult = _fileSystemManager.WriteSync(new WriteSyncStringOption() {
                data = _stringData,
                fd = _fd,
                encoding = encoding == "null" ? null : encoding,
                length = length == "null" ? null : (double?)int.Parse(length),
                offset = offset == "null" ? null : (double?)int.Parse(offset),
                position = position == "null" ? null : (double?)int.Parse(position)
            });
        } else {
            writeResult = _fileSystemManager.WriteSync(new WriteSyncOption() {
                data = _bufferData,
                fd = _fd,
                encoding = encoding == "null" ? null : encoding,
                length = length == "null" ? null : (double?)int.Parse(length),
                offset = offset == "null" ? null : (double?)int.Parse(offset),
                position = position == "null" ? null : (double?)int.Parse(position)
            });
        }
        // 更新文件内容
        UpdateFileContent();
        WX.ShowModal(new ShowModalOption() {
            content = "Write Success, Result: " + JsonMapper.ToJson(writeResult)
        });
    }

    // 异步写入
    private void WriteAsync(string dataType, string offset, string length, string encoding, string position) {
        if (dataType == "string") {
            _fileSystemManager.Write(new WriteStringOption() {
                data = _stringData,
                fd = _fd,
                encoding = encoding == "null" ? null : encoding,
                length = length == "null" ? null : (double?)int.Parse(length),
                offset = offset == "null" ? null : (double?)int.Parse(offset),
                position = position == "null" ? null : (double?)int.Parse(position),
                success = onWriteSuccess,
                fail = onWriteFail
            });
        } else {
            _fileSystemManager.Write(new WriteOption() {
                data = _bufferData,
                fd = _fd,
                encoding = encoding == "null" ? null : encoding,
                length = length == "null" ? null : (double?)int.Parse(length),
                offset = offset == "null" ? null : (double?)int.Parse(offset),
                position = position == "null" ? null : (double?)int.Parse(position),
                success = onWriteSuccess,
                fail = onWriteFail
            });
        }
    }

    // 更新读取结果
    private void UpdateReadResult() {
        // 使用UTF8编码显示读取内容
        GameManager.Instance.detailsController.ChangeResultContent(0, Encoding.UTF8.GetString(_buffer));
    }

    // 更新文件内容
    private static void UpdateFileContent() {
        // 使用UTF8编码显示文件内容
        GameManager.Instance.detailsController.ChangeResultContent(1, _fileSystemManager.ReadFileSync(Path, "utf8"));
    }
}