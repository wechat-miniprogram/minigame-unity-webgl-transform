using WeChatWASM;

// 定义自定义数据类型，类型要跟自定义属性中定义的类型一致
[System.Serializable]
public class EventData
{
    public string data1;
    public int data2;
}

public class ReportEvent : Details
{
    // 测试 API
    protected override void TestAPI(string[] args)
    {
        Report(args[0], args[1]);
    }

    // 事件上报
    private void Report(string stringdata, string intdata)
    {
        EventData eventData = new EventData
        {
            data1 = stringdata,
            data2 = int.Parse(intdata)
        };

        WX.ReportEvent("test", eventData);

        // 显示成功的提示
        WX.ShowToast(new ShowToastOption()
        {
            title = "事件已上传，可以到we分析平台中查看"
        });
    }
}
