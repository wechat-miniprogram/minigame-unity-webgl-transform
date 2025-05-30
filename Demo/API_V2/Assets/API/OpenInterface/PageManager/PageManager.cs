using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeChatWASM;

public class PageManager : Details
{
    private WXPageManager recommendPageManager;
    private bool isPageManagerActive = false;
    
    private void LoadRecommend()
    {
        if (recommendPageManager == null)
        {
            // 创建页面管理器实例
            recommendPageManager = WX.CreatePageManager();
            if (recommendPageManager == null)
            {
                throw new System.Exception("当前基础库版本暂不支持。");
            }
        }

        if (!isPageManagerActive)
        {
            // 显示推荐页面
            recommendPageManager.Show(new ShowOption
            {
                openlink = "TWFRCqV5WeM2AkMXhKwJ03MhfPOieJfAsvXKUbWvQFQtLyyA5etMPabBehga950uzfZcH3Vi3QeEh41xRGEVFw",
            });
        }
        else
        {
            // 销毁页面管理器
            DestroyPageManager();
        }

        isPageManagerActive = !isPageManagerActive;
        GameManager.Instance.detailsController.ChangeInitialButtonText(
            isPageManagerActive ? "销毁推荐组件" : "显示推荐组件"
        );
    }

    void DestroyPageManager()
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
        DestroyPageManager();
    }
}