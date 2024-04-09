import { defineConfig } from "vitepress";

// https://vitepress.dev/reference/site-config
export default defineConfig({
  title: "微信小游戏团结/Unity快适配",
  description: "Wechat Mini Game Unity engine adapter documents.",
  themeConfig: {
    nav: [
      { text: "主页", link: "/" },
      {
        text: "微信小游戏官方文档",
        link: "https://developers.weixin.qq.com/minigame/dev/guide/",
      },
      {
        text: "帮助",
        items: [
          {
            text: "微信开发者社区",
            link: "https://developers.weixin.qq.com/community/develop/question",
          },
          {
            text: "客服助手",
            link: "https://work.weixin.qq.com/kfid/kfcca4feec277f91616",
          },
        ],
      },
      { text: "团结引擎", link: "https://unity.cn/tuanjie/tuanjieyinqing" },
    ],

    sidebar: [
      {
        text: "基本信息",
        items: [
          { text: "简介", link: "/markdown-examples" },
          { text: "安装与使用", link: "/api-examples" },
          { text: "入门指南", link: "/api-examples" },
          { text: "优秀案例", link: "/api-examples" },
        ],
      },
      {
        text: "方案概述与兼容性",
        items: [
          { text: "技术原理", link: "/markdown-examples" },
          { text: "兼容性评估", link: "/api-examples" },
          { text: "推荐引擎版本", link: "/api-examples" },
        ],
      },
      {
        text: "性能优化",
        items: [
          {
            text: "性能优化总览",
            link: "",
          },
          {
            text: "性能优化评估标准",
            link: "",
          },
          {
            text: "启动性能",
            items: [
              {
                text: "提升 Unity WebGL 游戏启动速度",
                link: "/markdown-examples",
              },
              { text: "启动流程与时序", link: "/api-examples" },
              {
                text: "使用 Loader 进行游游戏加载",
                link: "/markdown-examples",
              },
              { text: "资源按需加载概述", link: "/api-examples" },
              {
                text: "使用 AssetBundle 进行资源按需加载",
                link: "/markdown-examples",
              },
              {
                text: "使用 Addressable 进行资源按需加载",
                link: "/api-examples",
              },
              {
                text: "使用 AutoStreaming 进行资源按需加载",
                link: "/markdown-examples",
              },
              { text: "定制启动封面", link: "/api-examples" },
              { text: "设计启动剧情", link: "/markdown-examples" },
              { text: "使用预下载功能", link: "/api-examples" },
              { text: "首场景启动优化", link: "/api-examples" },
              { text: "使用代码分包工具", link: "/api-examples" },
              { text: "启动留存数据上报统计", link: "/api-examples" },
              { text: "最佳实践检测工具", link: "/api-examples" },
              { text: "微信系统字体", link: "/api-examples" },
            ],
          },
          {
            text: "运行性能",
            items: [
              { text: "优化Unity WebGL的运行性能", link: "/markdown-examples" },
              {
                text: "使用 Android CPU Profiler 性能调优",
                link: "/api-examples",
              },
              {
                text: "使用 Unity Profiler 性能调优",
                link: "/markdown-examples",
              },
              { text: "优化Unity WebGL的内存", link: "/api-examples" },
              {
                text: "使用ProfilingMemory分析内存",
                link: "/markdown-examples",
              },
              { text: "压缩纹理优化", link: "/api-examples" },
              { text: "资源优化工具与建议", link: "/markdown-examples" },
              { text: "iOS高性能 与 高性能+ 模式", link: "/api-examples" },
              { text: "优化Unity WebGL的渲染性能", link: "/markdown-examples" },
              { text: "定制微信小游戏的 URP 管线", link: "/markdown-examples" },
              { text: "WebGL2.0渲染支持说明", link: "/markdown-examples" },
            ],
          },
        ],
      },
      {
        text: "版本更新与资源部署",
        items: [
          { text: "小游戏资源部署", link: "/markdown-examples" },
          { text: "小游戏资源缓存", link: "" },
          { text: "小游戏版本更新", link: "/api-examples" },
        ],
      },
      {
        text: "能力适配",
        items: [
          { text: "WX SDK 平台能力适配", link: "/markdown-examples" },
          { text: "屏幕适配", link: "/markdown-examples" },
          { text: "输入法适配", link: "/markdown-examples" },
          { text: "排行榜与微信关系数据", link: "/markdown-examples" },
          { text: "后端服务指引", link: "/markdown-examples" },
          { text: "网络通信适配", link: "/markdown-examples" },
          { text: "使用水印保护代码包安全", link: "/markdown-examples" },
        ],
      },
      {
        text: "调试与异常处理",
        items: [
          { text: "开发错误调试与排查", link: "/markdown-examples" },
          { text: "现网错误日志上报与排查", link: "/api-examples" },
        ],
      },
      {
        text: "其他",
        items: [
          { text: "技术常见问题QA", link: "/api-examples" },
          { text: "问题反馈与联系我们", link: "/markdown-examples" },
          { text: "技术沙龙", link: "/markdown-examples" },
        ],
      },
    ],

    socialLinks: [
      {
        icon: "github",
        link: "https://github.com/wechat-miniprogram/minigame-unity-webgl-transform",
      },
    ],

    search: {
      provider: "local",
    },
  },
  srcDir: "../",
  base: "/minigame-unity-webgl-transform/",
  outDir: "../docs",
  ignoreDeadLinks: true,
  lang: "zh-cn",
});
