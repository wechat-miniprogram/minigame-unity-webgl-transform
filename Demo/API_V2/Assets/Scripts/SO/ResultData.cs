using System;

[Serializable]
public class ResultData
{
    public bool isDisableInitially;

    public string initialTitleText; // 为空时不生成标题

    public string initialContentText; // 为空时不生成内容
}