import{_ as n,c as s,o as a,a4 as p}from"./chunks/framework.Br2U662V.js";const g=JSON.parse('{"title":"输入法适配","description":"","frontmatter":{},"headers":[],"relativePath":"Design/InputAdaptation.md","filePath":"Design/InputAdaptation.md"}'),e={name:"Design/InputAdaptation.md"},l=p(`<h1 id="输入法适配" tabindex="-1">输入法适配 <a class="header-anchor" href="#输入法适配" aria-label="Permalink to &quot;输入法适配&quot;">​</a></h1><h3 id="支持2022-input-field组件自动适配-低版本或者其他组件暂不支持" tabindex="-1">支持2022 Input Field组件自动适配，低版本或者其他组件暂不支持 <a class="header-anchor" href="#支持2022-input-field组件自动适配-低版本或者其他组件暂不支持" aria-label="Permalink to &quot;支持2022 Input Field组件自动适配，低版本或者其他组件暂不支持&quot;">​</a></h3><h3 id="低版本兼容" tabindex="-1">低版本兼容： <a class="header-anchor" href="#低版本兼容" aria-label="Permalink to &quot;低版本兼容：&quot;">​</a></h3><p>在小游戏中Unity游戏唤不起输入法，需要使用WX_SDK中提供的方法来唤起输入法，并做简单的逻辑修改来适配。</p><p>详细示例请参考<a href="https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/tree/main/Demo/API" target="_blank" rel="noreferrer">API Demo</a></p><p>以UGUI的Input组件为例，需要给Input 绑定以下脚本：</p><div class="language- vp-adaptive-theme"><button title="Copy Code" class="copy"></button><span class="lang"></span><pre class="shiki shiki-themes github-light github-dark vp-code"><code><span class="line"><span>using UnityEngine;</span></span>
<span class="line"><span>using System.Collections;</span></span>
<span class="line"><span>using WeChatWASM;</span></span>
<span class="line"><span>using UnityEngine.UI;</span></span>
<span class="line"><span>using UnityEngine.EventSystems;</span></span>
<span class="line"><span></span></span>
<span class="line"><span>public class Inputs : MonoBehaviour, IPointerClickHandler, IPointerExitHandler</span></span>
<span class="line"><span>{</span></span>
<span class="line"><span>    public InputField input;</span></span>
<span class="line"><span>    private bool isShowKeyboard = false;</span></span>
<span class="line"><span>    public void OnPointerClick(PointerEventData eventData)</span></span>
<span class="line"><span>    {</span></span>
<span class="line"><span>        Debug.Log(&quot;OnPointerClick&quot;);</span></span>
<span class="line"><span>        ShowKeyboard();</span></span>
<span class="line"><span>    }</span></span>
<span class="line"><span></span></span>
<span class="line"><span>    public void OnPointerExit(PointerEventData eventData)</span></span>
<span class="line"><span>    {</span></span>
<span class="line"><span>        Debug.Log(&quot;OnPointerExit&quot;);</span></span>
<span class="line"><span>        if (!input.isFocused)</span></span>
<span class="line"><span>        {</span></span>
<span class="line"><span>            HideKeyboard();</span></span>
<span class="line"><span>        }</span></span>
<span class="line"><span>    }</span></span>
<span class="line"><span></span></span>
<span class="line"><span>    public void OnInput(OnKeyboardInputListenerResult v)</span></span>
<span class="line"><span>    {</span></span>
<span class="line"><span>        Debug.Log(&quot;onInput&quot;);</span></span>
<span class="line"><span>        Debug.Log(v.value);</span></span>
<span class="line"><span>        if (input.isFocused)</span></span>
<span class="line"><span>        {</span></span>
<span class="line"><span>            input.text = v.value;</span></span>
<span class="line"><span>        }</span></span>
<span class="line"><span>    }</span></span>
<span class="line"><span></span></span>
<span class="line"><span>    public void OnConfirm(OnKeyboardInputListenerResult v)</span></span>
<span class="line"><span>    {</span></span>
<span class="line"><span>        // 输入法confirm回调</span></span>
<span class="line"><span>        Debug.Log(&quot;onConfirm&quot;);</span></span>
<span class="line"><span>        Debug.Log(v.value);</span></span>
<span class="line"><span>        HideKeyboard();</span></span>
<span class="line"><span>    }</span></span>
<span class="line"><span></span></span>
<span class="line"><span>    public void OnComplete(OnKeyboardInputListenerResult v)</span></span>
<span class="line"><span>    {</span></span>
<span class="line"><span>        // 输入法complete回调</span></span>
<span class="line"><span>        Debug.Log(&quot;OnComplete&quot;);</span></span>
<span class="line"><span>        Debug.Log(v.value);</span></span>
<span class="line"><span>        HideKeyboard();</span></span>
<span class="line"><span>    }</span></span>
<span class="line"><span></span></span>
<span class="line"><span>    private void ShowKeyboard()</span></span>
<span class="line"><span>    {</span></span>
<span class="line"><span>        if (!isShowKeyboard)</span></span>
<span class="line"><span>        {</span></span>
<span class="line"><span>            WX.ShowKeyboard(new ShowKeyboardOption()</span></span>
<span class="line"><span>            {</span></span>
<span class="line"><span>                defaultValue = &quot;xxx&quot;,</span></span>
<span class="line"><span>                maxLength = 20,</span></span>
<span class="line"><span>                confirmType = &quot;go&quot;</span></span>
<span class="line"><span>            });</span></span>
<span class="line"><span></span></span>
<span class="line"><span>            //绑定回调</span></span>
<span class="line"><span>            WX.OnKeyboardConfirm(OnConfirm);</span></span>
<span class="line"><span>            WX.OnKeyboardComplete(OnComplete);</span></span>
<span class="line"><span>            WX.OnKeyboardInput(OnInput);</span></span>
<span class="line"><span>            isShowKeyboard = true;</span></span>
<span class="line"><span>        }</span></span>
<span class="line"><span>    }</span></span>
<span class="line"><span></span></span>
<span class="line"><span>    private void HideKeyboard()</span></span>
<span class="line"><span>    {</span></span>
<span class="line"><span>        if (isShowKeyboard)</span></span>
<span class="line"><span>        {</span></span>
<span class="line"><span>            WX.HideKeyboard(new HideKeyboardOption());</span></span>
<span class="line"><span>            //删除掉相关事件监听</span></span>
<span class="line"><span>            WX.OffKeyboardInput(OnInput);</span></span>
<span class="line"><span>            WX.OffKeyboardConfirm(OnConfirm);</span></span>
<span class="line"><span>            WX.OffKeyboardComplete(OnComplete);</span></span>
<span class="line"><span>            isShowKeyboard = false;</span></span>
<span class="line"><span>        }</span></span>
<span class="line"><span>    }</span></span>
<span class="line"><span>}</span></span></code></pre></div>`,7),i=[l];function t(o,c,r,u,d,b){return a(),s("div",null,i)}const m=n(e,[["render",t]]);export{g as __pageData,m as default};
