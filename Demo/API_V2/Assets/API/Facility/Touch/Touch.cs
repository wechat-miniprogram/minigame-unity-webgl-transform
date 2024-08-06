using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;

public class Touch : Details
{
    private bool _isListening = false;

    private static GameObject _squarePrefab;

    private static Dictionary<int, GameObject> _activeSquares;

    private readonly Action<OnTouchStartListenerResult> _onTouchStart = (res) =>
    {
        var result = "Touch Start\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });

        foreach (var touch in res.changedTouches)
        {
            var square = Instantiate(_squarePrefab, GameManager.Instance.detailsController.transform);
            square.transform.position = new Vector3(touch.clientX, touch.clientY, 0);
            _activeSquares.Add(touch.identifier, square);
        }
    };

    private readonly Action<OnTouchStartListenerResult> _onTouchEnd = (res) =>
    {
        var result = "Touch End\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });

        foreach (var touch in res.changedTouches)
        {
            if (!_activeSquares.ContainsKey(touch.identifier)) continue;

            var square = _activeSquares[touch.identifier];
            Destroy(square);
            _activeSquares.Remove(touch.identifier);
        }
    };

    private readonly Action<OnTouchStartListenerResult> _onTouchCancel = (res) =>
    {
        var result = "Touch Cancel\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });

        foreach (var touch in res.changedTouches)
        {
            if (!_activeSquares.ContainsKey(touch.identifier)) continue;

            var square = _activeSquares[touch.identifier];
            Destroy(square);
            _activeSquares.Remove(touch.identifier);
        }
    };

    private readonly Action<OnTouchStartListenerResult> _OnTouchMove = (res) =>
    {
        foreach (var touch in res.changedTouches)
        {
            if (!_activeSquares.ContainsKey(touch.identifier)) continue;

            var square = _activeSquares[touch.identifier];
            square.transform.position = new Vector3(touch.clientX, touch.clientY, 0);
        }
    };

    private void Awake()
    {
        _activeSquares = new Dictionary<int, GameObject>();
    }


    private void Start()
    {
        _squarePrefab = Resources.Load<GameObject>("Prefabs/Square");

        GameManager.Instance.detailsController.BindExtraButtonAction(0, ClearResults);
    }

    // 开始/取消监听触摸事件
    protected override void TestAPI(string[] args)
    {
        if (!_isListening)
        {
            WX.OnTouchStart(_onTouchStart);
            WX.OnTouchEnd(_onTouchEnd);
            WX.OnTouchCancel(_onTouchCancel);
            WX.OnTouchMove(_OnTouchMove);
        }
        else
        {
            WX.OffTouchStart(_onTouchStart);
            WX.OffTouchEnd(_onTouchEnd);
            WX.OffTouchCancel(_onTouchCancel);
            WX.OffTouchMove(_OnTouchMove);
        }
        _isListening = !_isListening;
        GameManager.Instance.detailsController.ChangeInitialButtonText(_isListening ? "取消监听" : "开始监听");
    }

    // 清除结果
    private void ClearResults()
    {
        GameManager.Instance.detailsController.KeepFirstNResults(1);
    }

    private void OnDestroy()
    {
        WX.OffTouchStart(_onTouchStart);
        WX.OffTouchEnd(_onTouchEnd);
        WX.OffTouchCancel(_onTouchCancel);
        WX.OffTouchMove(_OnTouchMove);
    }
}