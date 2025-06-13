using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeChatWASM;

public class PageManager : Details
{
    private WXPageManager recommendPageManager;
    private const string OPENLINK = "TWFRCqV5WeM2AkMXhKwJ03MhfPOieJfAsvXKUbWvQFQtLyyA5etMPabBehga950uzfZcH3Vi3QeEh41xRGEVFw";

    private void LoadRecommend()
    {
        if (recommendPageManager == null)
        {
            // 创建页面管理器实例
            recommendPageManager = WX.CreatePageManager();

            // 监听组件加载完毕事件
            recommendPageManager.On("ready", (res) =>
            {
                WX.ShowModal(new ShowModalOption
                {
                    title = "监听ready",
                    content = "ready",
                    success = (res) =>
                    {
                        Debug.Log("Ready success" + res);
                    },
                });
                Debug.Log("组件加载完毕触发");
            });

            // 加载推荐页面
            recommendPageManager.Load(new LoadOption
            {
                openlink = OPENLINK,
            });
        }
    }

    private void ShowRecommend()
    {
        if (recommendPageManager == null)
        {
            // 如果还没有创建页面管理器，直接创建并show（会自动执行一次load）
            recommendPageManager = WX.CreatePageManager();

            // 监听用户展示组件时触发
            recommendPageManager.On("show", (res) =>
            {
                WX.ShowModal(new ShowModalOption
                {
                    title = "监听show",
                    content = "show",
                    success = (res) =>
                    {
                        Debug.Log("Show success" + res);
                    },
                });
                Debug.Log("用户展示组件时触发");
            });

            // 监听用户关闭组件时触发
            recommendPageManager.On("destroy", (res) =>
            {
                WX.ShowModal(new ShowModalOption
                {
                    title = "监听destroy",
                    content = "destroy",
                    success = (res) =>
                    {
                        Debug.Log("Destroy success" + res);
                    },
                });
                Debug.Log($"用户关闭组件时触发，是否是相关推荐:");
            });

            // 监听组件发生错误时触发
            recommendPageManager.On("error", (res) =>
            {
                WX.ShowModal(new ShowModalOption
                {
                    title = "监听error",
                    content = "error",
                    success = (res) =>
                    {
                        Debug.Log("Error success" + res);
                    },
                });
                Debug.LogError($"组件发生错误时触发:");
            });


            recommendPageManager.Show(new ShowOption
            {
                openlink = OPENLINK,
            });
        }
        else
        {
            // 已经执行过load，直接show即可
            recommendPageManager.Show(new ShowOption());
        }
    }

    private void Start()
    {
        GameManager.Instance.detailsController.BindExtraButtonAction(0, ShowRecommend);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, DestroyRecommend);
    }

    private void DestroyRecommend()
    {
        if (recommendPageManager != null)
        {
            // 销毁页面管理器
            recommendPageManager.Destroy();
            recommendPageManager = null;
        }
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        LoadRecommend();
    }

    private void OnDestroy()
    {
        DestroyRecommend();
    }
}