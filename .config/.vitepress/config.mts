import { defineConfig } from 'vitepress'

// https://vitepress.dev/reference/site-config
export default defineConfig({
  title: "微信小游戏团结/Unity快适配方案",
  description: "Wechat Mini Game Unity engine adapter documents.",
  themeConfig: {
    nav: [
      { text: '主页', link: '/' },
      { text: '微信小游戏官方文档', link: 'https://developers.weixin.qq.com/minigame/dev/guide/' },
      {
        text: '帮助',
        items: [
          { text: '微信开发者社区', link: 'https://developers.weixin.qq.com/community/develop/question' },
          { text: '客服助手', link: 'https://work.weixin.qq.com/kfid/kfcca4feec277f91616' },
        ],
      },
      { text: '团结引擎', link: 'https://unity.cn/tuanjie/tuanjieyinqing' },
    ],

    sidebar: [
      {
        text: 'Examples',
        items: [
          { text: 'Markdown Examples', link: '/markdown-examples' },
          { text: 'Runtime API Examples', link: '/api-examples' }
        ]
      }
    ],

    socialLinks: [
      { icon: 'github', link: 'https://github.com/wechat-miniprogram/minigame-unity-webgl-transform' }
    ],

    search: {
      provider: 'local',
    }
  },
  srcDir: '../',
  base: '/minigame-unity-webgl-transform/',
  outDir: '../docs',
  // ignoreDeadLinks: true,
  lang: 'zh-cn'
})
