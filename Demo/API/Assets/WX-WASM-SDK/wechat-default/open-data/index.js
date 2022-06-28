//绘制引擎文档可以参考  https://wechat-miniprogram.github.io/minigame-canvas-engine/
import Layout from './open-data-js-sdk/minigame-canvas-engine/index';
import SDK from "./open-data-js-sdk/index";

function main({x /*屏幕左上角横坐标*/, y/*屏幕左上角纵坐标*/, width/*渲染区域宽度大小*/, height/*渲染区域高度大小*/, devicePixelRatio/*像素密度比*/}){
    //这里写你的业务逻辑，unity里面调用 WX.ShowOpenData 会自动执行到这里，WX.HideOpenData会自动销毁


    //以下是demo可以删除掉, 体验demo可以参考 https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/tree/main/Demo/Ranking/MiniGame/minigame

    // demo开始
    let template = `
    <view id="container">
    <text id="testText" class="redText" value="hello canvas"></text>
    </view>
`;
    let style = {
        container: {
            width: 200,
            height: 100,
            backgroundColor: '#ffffff',
            justContent: 'center',
            alignItems: 'center',
        },
        testText: {
            color: '#ffffff',
            width: 200,
            height: 50,
            lineHeight: 50,
            fontSize: 20,
            textAlign: 'center',
            backgroundColor: '#ffff00',
        },
        // 文字的最终颜色为#ff0000
        redText: {
            color: '#ff0000',
        }
    };
    Layout.init(template, style);
    const list = Layout.getElementsById('testText');
    let id = 0;
    list.forEach(item => {
        item.on('click', (e) => {
            console.log(e, item);
            list[0].value = "hhh"+(++id);
        });
    });
    let canvas = wx.getSharedCanvas();
    let ctx   = canvas.getContext('2d');
    Layout.updateViewPort({
        width: width / devicePixelRatio,
        height: height / devicePixelRatio,
        x: x / devicePixelRatio,
        y: y / devicePixelRatio
    });
    Layout.layout(ctx);

    // demo结束
}

SDK.start(main);
