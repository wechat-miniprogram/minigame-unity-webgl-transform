using System.Globalization;
using UnityEngine;

public class FrameRate : Details
{
    private float _lastUpdateShowTime = 0f; // 上一次更新帧率的时间

    private readonly float _updateTime = 0.05f; // 更新显示帧率的时间间隔

    private int _frames = 0; // 帧数

    private float _fps = 0; // 帧率

    private void Start()
    {
        GameManager.Instance.detailsController.BindExtraButtonAction(0, this.SetFPS60);
    }

    private void Update()
    {
        _frames++;
        if (Time.realtimeSinceStartup - _lastUpdateShowTime >= _updateTime)
        {
            _fps = _frames / (Time.realtimeSinceStartup - _lastUpdateShowTime);
            _frames = 0;
            _lastUpdateShowTime = Time.realtimeSinceStartup;
        }

        GameManager.Instance.detailsController.ChangeResultContent(0, _fps.ToString(CultureInfo.CurrentCulture));
    }

    protected override void TestAPI(string[] args)
    {
        SetFPS30();
    }

    private void SetFPS30()
    {
        Application.targetFrameRate = 30;
    }

    private void SetFPS60()
    {
        Application.targetFrameRate = 60;
    }

    private void Destroy()
    {
        SetFPS60();
    }
}
