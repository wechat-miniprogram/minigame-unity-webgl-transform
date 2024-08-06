using System;
using UnityEngine;
using WeChatWASM;

public class Stat : Details
{
    private WXFileSystemManager _fileSystemManager;

    // 路径
    // 注意WX.env.USER_DATA_PATH后接字符串需要以/开头
    private static readonly string PathPrefix = WX.env.USER_DATA_PATH + "/Stat";
    private static readonly string Path5 = PathPrefix + "/Five.txt";
    private static readonly string DirPath = PathPrefix + "/dir";
    private static readonly string Path6 = PathPrefix + "/dir/Six.txt";
    private static readonly string Path8 = PathPrefix + "/dir/Eight.txt";
    private static readonly string Path9 = PathPrefix + "/dir/Nine.txt";

    // 失败回调
    private Action<WXStatResponse> onFail = (res) =>
    {
        WX.ShowModal(new ShowModalOption()
        {
            content = "Stat Fail"
        });
    };

    private void Start()
    {
        // 获取全局唯一的文件管理器
        _fileSystemManager = WX.GetFileSystemManager();

        // 检查并创建目录
        if (_fileSystemManager.AccessSync(DirPath) != "access:ok")
        {
            _fileSystemManager.MkdirSync(DirPath, true);
        }

        // 创建文件
        _fileSystemManager.OpenSync(new OpenSyncOption()
        {
            filePath = Path5,
            flag = "w+"
        });
        _fileSystemManager.OpenSync(new OpenSyncOption()
        {
            filePath = Path6,
            flag = "w+"
        });
        _fileSystemManager.OpenSync(new OpenSyncOption()
        {
            filePath = Path8,
            flag = "w+"
        });
        _fileSystemManager.OpenSync(new OpenSyncOption()
        {
            filePath = Path9,
            flag = "w+"
        });

        // 写入文件内容
        _fileSystemManager.WriteFileSync(Path5, "Five words form this statement.");
        _fileSystemManager.WriteFileSync(Path6, "Six words make up this sentence.");
        _fileSystemManager.WriteFileSync(Path8, "This phrase has a total of eight words.");
        _fileSystemManager.WriteFileSync(Path9, "Here, you'll find a sentence with nine words.");
    }

    // 获取文件状态
    protected override void TestAPI(string[] args)
    {
        if (args[0] == "同步执行")
        {
            RunSync(args[1]);
        }
        else
        {
            RunAsync(args[1], args[2]);
        }
    }

    // 同步获取文件状态
    private void RunSync(string path)
    {
        var fileStats = _fileSystemManager.StatSync(PathPrefix + path);

        UpdateResults(fileStats);
        WX.ShowToast(new ShowToastOption()
        {
            title = "StatSync Success"
        });
    }

    // 异步获取文件状态
    private void RunAsync(string path, string recursive)
    {
        if (recursive == "null")
        {
            _fileSystemManager.Stat(new WXStatOption()
            {
                path = PathPrefix + path,
                success = (res) =>
                {
                    UpdateResults(res.stats.ToArray());
                    WX.ShowToast(new ShowToastOption()
                    {
                        title = "Stat Success"
                    });
                },
                fail = onFail
            });
        }
        else
        {
            _fileSystemManager.Stat(new WXStatOption()
            {
                path = PathPrefix + path,
                recursive = recursive == "true",
                success = (res) =>
                {
                    if (recursive == "true")
                    {
                        UpdateResults(res.stats.ToArray());
                        WX.ShowToast(new ShowToastOption()
                        {
                            title = "Stat Success"
                        });
                    }
                    else
                    {
                        UpdateResults(res.one_stat);
                        WX.ShowToast(new ShowToastOption()
                        {
                            title = "Stat Success"
                        });
                    }

                },
                fail = onFail
            });
        }
    }

    // 清除结果
    private void ClearResults()
    {
        GameManager.Instance.detailsController.KeepFirstNResults(5);
    }

    // 更新结果
    private void UpdateResults(WXStat[] fileStats)
    {
        ClearResults();

        foreach (var fileStat in fileStats)
        {
            GameManager.Instance.detailsController.AddResult(new ResultData()
            {
                initialContentText = "文件路径：" + fileStat.path
                                                    + "\n文件的类型和存取的权限：" + fileStat.stats.mode
                                                    + "\n文件大小，单位：B：" + fileStat.stats.size
                                                    + "\n文件最近一次被存取或被执行的时间：" + fileStat.stats.lastAccessedTime
                                                    + "\n文件最后一次被修改的时间：" + fileStat.stats.lastModifiedTime
            });
        }
    }

    // 更新结果
    private void UpdateResults(WXStatInfo stats)
    {
        ClearResults();

        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = "文件的类型和存取的权限：" + stats.mode
                                                + "\n文件大小，单位：B：" + stats.size
                                                + "\n文件最近一次被存取或被执行的时间：" + stats.lastAccessedTime
                                                + "\n文件最后一次被修改的时间：" + stats.lastModifiedTime
        });
    }
}