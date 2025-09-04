import { defineConfig } from "vitepress";

// https://vitepress.dev/reference/site-config
export default defineConfig({
  title: "微信小游戏Unity/团结快适配",
  description: "Wechat Mini Game Unity engine adapter documents.",
  themeConfig: {
    logo: '/image/vitepress/icon.png',
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
        text: "基本",
        items: [
          { text: "简介", link: "/README" },
          { text: "安装与使用", link: "/Design/SDKInstaller" },
          { text: "入门指南", link: "/Design/Guide" },
          { text: "快速开始", link: "/Design/Transform" },
          { text: "优秀案例", link: "/Design/ShowCase" },
          { text: "更新日志", link: "/CHANGELOG.md" },
        ],
      },
      {
        text: "方案概述与兼容性",
        items: [
          { text: "技术原理", link: "/Design/Summary" },
          { text: "兼容性评估", link: "/Design/Evaluation" },
          { text: "推荐引擎版本", link: "/Design/UnityVersion" },
          { text: "技术常见问题QA", link: "/Design/DevelopmentQAList" },
        ],
      },
      {
        text: "性能优化",
        items: [
          {
            text: "性能优化总览",
            link: "/Design/PerfOptimization",
          },
          {
            text: "性能优化评估标准",
            link: "/Design/PerfMeasure",
          },
          {
            text: "启动性能",
            items: [
              {
                text: "提升游戏启动速度",
                link: "/Design/StartupOptimization",
              },
              { text: "启动流程与时序", link: "/Design/Startup" },
              {
                text: "使用 Loader 进行游游戏加载",
                link: "/Design/UsingLoader",
              },
              { text: "资源按需加载概述", link: "/Design/ResourcesLoading" },
              {
                text: "使用 AssetBundle 按需加载",
                link: "/Design/UsingAssetBundle",
              },
              {
                text: "使用 Addressable 按需加载",
                link: "/Design/UsingAddressable",
              },
              {
                text: "使用 AutoStreaming 按需加载",
                link: "/Design/InstantGameGuide",
              },
              { text: "定制启动封面", link: "/Design/CustomLoading" },
              { text: "设计启动剧情", link: "/Design/LaunchOpera" },
              { text: "使用预下载功能", link: "/Design/UsingPreload" },
              { text: "首场景启动优化", link: "/Design/FirstSceneOptimization" },
              { text: "使用代码分包工具", link: "/Design/WasmSplit" },
              { text: "启动留存数据上报统计", link: "/Design/ReportStartupStat" },
              { text: "最佳实践检测工具", link: "/Design/PerformanceMonitor" },
              { text: "微信系统字体", link: "/Design/WXFont" },
            ],
          },
          {
            text: "运行性能",
            items: [
              { text: "优化 Unity WebGL 的运行性能", link: "/Design/OptimizationPerformence" },
              {
                text: "Android CPU Profiler 性能调优",
                link: "/Design/AndroidProfile",
              },
              {
                text: "Unity Profiler 性能调优",
                link: "/Design/UnityProfiler",
              },
              { text: "优化 Unity WebGL 的内存", link: "/Design/OptimizationMemory" },
              {
                text: "ProfilingMemory分析内存",
                link: "/Design/UsingMemoryProfiler",
              },
              { text: "压缩纹理优化", link: "/Design/CompressedTexture" },
              { text: "资源优化工具与建议", link: "/Design/AssetOptimization" },
              { text: "iOS高性能 与 高性能+ 模式", link: "/Design/iOSOptimization" },
              { text: "优化Unity WebGL的渲染性能", link: "/Design/RenderOptimization" },
              { text: "EmscriptenGLX渲染模式", link: "/Design/EmscriptenGLX" },
              { text: "定制微信小游戏的 URP 管线", link: "/Design/CustomURP" },
              { text: "WebGL2.0渲染支持说明", link: "/Design/WebGL2" },
              { text: "性能深度分析工具", link: "/Design/DeepProfileTool" },
              { text: "高精度时间", link: "/Design/HighPreciseTime" },
              { text: "优化实战: Particle Simulate Budget方案", link: "/Design/ParticleBudget" }, 
              { text: "微信小游戏功耗分析指引 -- iOS 篇", link: "/Design/PowerPerf-iOS" }, 
              { text: "Shader 异步 Warmup", link: "/Design/AsyncShaderWarmup" },
            ],
          },
        ],
      },
      {
        text: "版本更新与资源部署",
        items: [
          { text: "小游戏资源部署", link: "/Design/DataCDN" },
          { text: "小游戏资源缓存", link: "/Design/FileCache" },
          { text: "小游戏版本更新", link: "/Design/Update" },
        ],
      },
      {
        text: "能力适配",
        items: [
          { text: "WX SDK 平台能力适配", link: "/Design/WX_SDK" },
          { text: "音频视频适配", link: "/Design/AudioAndVideo" },
          { text: "屏幕适配", link: "/Design/fixScreen" },
          { text: "输入法适配", link: "/Design/InputAdaptation" },
          { text: "排行榜与微信关系数据", link: "/Design/OpenData" },
          { text: "后端服务指引", link: "/Design/BackendServiceStartup" },
          { text: "网络通信适配", link: "/Design/UsingNetworking" },
          { text: "使用水印保护代码包安全", link: "/Design/wasmWaterMark" },
          { text: "配置构建模板", link: "/Design/BuildTemplate.md" },
          { text: "实时预览工具", link: "/Design/WechatPreview.md" },
        ],
      },
      {
        text: "调试与异常处理",
        items: [
          { text: "开发错误调试与排查", link: "/Design/DebugAndException" },
          { text: "现网错误日志上报与排查", link: "/Design/IssueForProduction" },
          { text: "MiniGameConfig.asset 说明", link: "/Design/AssetDescription" },
        ],
      },
      {
        text: "其他",
        items: [
          { text: "技术常见问题QA", link: "/Design/DevelopmentQAList" },
          { text: "问题反馈与联系我们", link: "/Design/IssueAndContact" },
          { text: "技术沙龙", link: "/Design/Salon" },
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

    footer: {
      message: 'Released under the MIT License.',
      copyright: 'Copyright © 2021 Tencent'
    }
  },
  srcDir: "../",
  base: "/minigame-unity-webgl-transform/",
  outDir: "../docs",
  // ignoreDeadLinks: true,
  lang: "zh-cn",
});
