import{_ as a,c as n,o as s,a4 as e}from"./chunks/framework.Br2U662V.js";const m=JSON.parse('{"title":"SDK 调用微信API","description":"","frontmatter":{},"headers":[],"relativePath":"Design/WX_SDK.md","filePath":"Design/WX_SDK.md"}'),p={name:"Design/WX_SDK.md"},l=e(`<h1 id="sdk-调用微信api" tabindex="-1">SDK 调用微信API <a class="header-anchor" href="#sdk-调用微信api" aria-label="Permalink to &quot;SDK 调用微信API&quot;">​</a></h1><p>将 WX-WASM-SDK 这个目录拷贝至unity工程 Assets目录下,在主入口初始化，回调后再执行你的主逻辑</p><div class="language- vp-adaptive-theme"><button title="Copy Code" class="copy"></button><span class="lang"></span><pre class="shiki shiki-themes github-light github-dark vp-code"><code><span class="line"><span>WX.InitSDK((int code)=&gt; {</span></span>
<span class="line"><span>// 你的主逻辑</span></span>
<span class="line"><span>});</span></span></code></pre></div><p>API可以直接看<code>WX.cs</code>这个文件，里面有<code>详细注释说明</code>。</p><p>本Unity的SDK的API大体与<a href="https://developers.weixin.qq.com/minigame/dev/guide/" target="_blank" rel="noreferrer">官网</a>的JS版本API类似，使用时可以参考之。 如JS版的banner广告的调用如下：</p><div class="language- vp-adaptive-theme"><button title="Copy Code" class="copy"></button><span class="lang"></span><pre class="shiki shiki-themes github-light github-dark vp-code"><code><span class="line"><span>    var bannerAd = wx.createBannerAd({</span></span>
<span class="line"><span>        adUnitId: &quot;xxxx&quot;,</span></span>
<span class="line"><span>        adIntervals: 30,</span></span>
<span class="line"><span>        style: {</span></span>
<span class="line"><span>            left: 0,</span></span>
<span class="line"><span>            top: 0,</span></span>
<span class="line"><span>            width: 600,</span></span>
<span class="line"><span>            height:200</span></span>
<span class="line"><span>        }</span></span>
<span class="line"><span>    });</span></span>
<span class="line"><span>    bannerAd.onLoad(() =&gt; {</span></span>
<span class="line"><span>        bannerAd.show();</span></span>
<span class="line"><span>    });</span></span>
<span class="line"><span>    bannerAd.onError((res)=&gt;{</span></span>
<span class="line"><span>        console.log(res);</span></span>
<span class="line"><span>    });</span></span></code></pre></div><p>而对于Unity版的调用如下：</p><div class="language- vp-adaptive-theme"><button title="Copy Code" class="copy"></button><span class="lang"></span><pre class="shiki shiki-themes github-light github-dark vp-code"><code><span class="line"><span></span></span>
<span class="line"><span>    var bannerAd = WX.CreateBannerAd(new WXCreateBannerAdParam()</span></span>
<span class="line"><span>    {</span></span>
<span class="line"><span>        adUnitId = &quot;xxxx&quot;,</span></span>
<span class="line"><span>        adIntervals = 30,</span></span>
<span class="line"><span>        style = new Style()</span></span>
<span class="line"><span>        {</span></span>
<span class="line"><span>            left = 0,</span></span>
<span class="line"><span>            top = 0,</span></span>
<span class="line"><span>            width = 600,</span></span>
<span class="line"><span>            height = 200</span></span>
<span class="line"><span>        }</span></span>
<span class="line"><span>    });</span></span>
<span class="line"><span>    </span></span>
<span class="line"><span>    bannerAd.OnLoad(()=&gt; {</span></span>
<span class="line"><span>        bannerAd.Show();</span></span>
<span class="line"><span>    });</span></span>
<span class="line"><span>    bannerAd.OnError((WXADErrorResponse res)=&gt;</span></span>
<span class="line"><span>    {</span></span>
<span class="line"><span>        Debug.Log(res.errCode);</span></span>
<span class="line"><span>    });</span></span></code></pre></div><p>大体是将JS版中的<code>wx</code>替换为Unity版的<code>WX</code>,然后对应方法名首字母由小写改为大写，如<code>createBannerAd</code>就变为<code>CreateBannerAd</code></p><h2 id="开发建议" tabindex="-1">开发建议 <a class="header-anchor" href="#开发建议" aria-label="Permalink to &quot;开发建议&quot;">​</a></h2><h3 id="demo-api示例" tabindex="-1">Demo API示例 <a class="header-anchor" href="#demo-api示例" aria-label="Permalink to &quot;Demo API示例&quot;">​</a></h3><p>使用示例我们会逐渐补充到<a href="https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/tree/main/Demo" target="_blank" rel="noreferrer">Demo</a>, 其中API项目为常见到使用范例，请优先查阅用法。</p><h3 id="联调效率" tabindex="-1">联调效率 <a class="header-anchor" href="#联调效率" aria-label="Permalink to &quot;联调效率&quot;">​</a></h3><p>如果开发者有简单的JS代码经验，建议先以JS方式直接修改minigame的JS代码进行调试，完成之后再使用C# SDK修改Unity工程：</p><ol><li>只保留game.js前面import部分，其余删除，即不运行游戏逻辑。</li><li>增加以下代码：</li></ol><div class="language- vp-adaptive-theme"><button title="Copy Code" class="copy"></button><span class="lang"></span><pre class="shiki shiki-themes github-light github-dark vp-code"><code><span class="line"><span>    const gl = GameGlobal.canvas.getContext(&#39;webgl&#39;) </span></span>
<span class="line"><span>    gl.clear(gl.COLOR_BUFFER_BIT);</span></span></code></pre></div><ol start="3"><li>使用JS编写需要调试的API</li></ol><h2 id="注意事项" tabindex="-1">注意事项 <a class="header-anchor" href="#注意事项" aria-label="Permalink to &quot;注意事项&quot;">​</a></h2><ol><li>广告接口是否需要上线后才能调试</li></ol><ul><li>是的，需要上线并累计UV&gt;1000才可以开通广告主</li></ul>`,20),i=[l];function t(o,c,r,d,h,g){return s(),n("div",null,i)}const b=a(p,[["render",t]]);export{m as __pageData,b as default};
