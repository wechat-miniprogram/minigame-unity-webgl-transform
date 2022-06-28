import Layout from './minigame-canvas-engine/index';
//绘制引擎文档可以参考  https://wechat-miniprogram.github.io/minigame-canvas-engine/
let isDestroyed = true; //是否已经被销毁

export default {
    /**
     * 初始化
     * @param fun 主逻辑开始的函数，unity里面调用 WX.ShowOpenData 会通知到这里
     */
    start(fun){
        wx.onMessage(data => {
            if(data.type === "WXDestroy"){
                isDestroyed = true;
                return Layout.clearAll();
            }else if(data.type === "WXRender"){
                Layout.repaint();
                if(isDestroyed){
                    isDestroyed = false;
                    fun(data);
                }
            }
        });
    }
}
