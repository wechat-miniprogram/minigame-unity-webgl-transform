//绘制引擎文档可以参考  https://wechat-miniprogram.github.io/minigame-canvas-engine/
import Layout from './open-data-js-sdk/minigame-canvas-engine/index';
import SDK from "./open-data-js-sdk/index";

function main(conf) {
    //这里写你的业务逻辑，unity里面调用 WX.ShowOpenData 会自动执行到这里，WX.HideOpenData会自动销毁
    Mod.registerBitmap();
    Mod.init(conf);
}

const Mod = {
    data: {
        //这里是假数据
        star: [
            {
                name: "飞翔的猪",
                score: 10000,
                picUrl: 'open-data/image/face.png'
            },
            {
                name: "飞翔的猪哥哥",
                score: 9999,
                picUrl: 'open-data/image/face.png'
            },
            {
                name: "飞翔的猪第第",
                score: 9982,
                picUrl: 'open-data/image/face.png'
            },
            {
                name: "飞翔的猪哥哥",
                score: 9999,
                picUrl: 'open-data/image/face.png'
            },
            {
                name: "飞翔的猪第第",
                score: 9982,
                picUrl: 'open-data/image/face.png'
            },
            {
                name: "飞翔9",
                score: 999,
                picUrl: 'open-data/image/face.png'
            },
            {
                name: "飞翔8",
                score: 998,
                picUrl: 'open-data/image/face.png'
            },
            {
                name: "飞翔7",
                score: 997,
                picUrl: 'open-data/image/face.png'
            },
            {
                name: "飞翔6",
                score: 996,
                picUrl: 'open-data/image/face.png'
            }
        ],
        money: [
            {
                name: "飞翔的企鹅",
                score: 6666,
                picUrl: 'open-data/image/face.png'
            },
            {
                name: "飞翔的企鹅1",
                score: 5555,
                picUrl: 'open-data/image/face2.png'
            },
            {
                name: "飞翔的企鹅2",
                score: 333,
                picUrl: 'open-data/image/face2.png'
            },
            {
                name: "飞翔的企鹅3",
                score: 222,
                picUrl: 'open-data/image/face.png'
            },
        ],
        rank: "StarRank"
    },
    init(conf) {
        const {x /*屏幕左上角横坐标*/, y/*屏幕左上角纵坐标*/, width/*渲染区域宽度大小*/, height/*渲染区域高度大小*/, devicePixelRatio/*像素密度比*/} = conf;
        this.conf = conf;
        let template = this.getTemplate();
        let style = this.getStyle();
        Layout.clear();
        Layout.init(template, style);
        let canvas = wx.getSharedCanvas();
        let ctx = canvas.getContext('2d');
        Layout.updateViewPort({
            width: width / devicePixelRatio,
            height: height / devicePixelRatio,
            x: x / devicePixelRatio,
            y: y / devicePixelRatio
        });
        Layout.layout(ctx);
        this.bindEvent();
    },
    bindEvent() {
        //绑定点击事件
        const StarRank = Layout.getElementsById('StarRank')[0];
        const MoneyBank = Layout.getElementsById('MoneyBank')[0];
        StarRank.on('click', () => {
            this.data.rank = 'StarRank';
            this.init(this.conf);
        });

        MoneyBank.on('click', () => {
            this.data.rank = 'MoneyBank';
            this.init(this.conf);
        });
    },
    getHeaderTemplate() {
        //顶部tab切换
        const data = this.data;
        return `<view class="header">
        <image id="StarRank" 
        ${
            data.rank === 'StarRank' ?
                'class="headerItem" src="open-data/image/x1.png"' :
                'class="headerItem headerImageOff" src="open-data/image/f2.png"'
        }></image>
        <image id="MoneyBank"
         ${
            data.rank !== 'StarRank' ?
                'class="headerItem" src="open-data/image/f1.png"' :
                'class="headerItem headerImageOff" src="open-data/image/x2.png"'
        }></image>
    </view>`
    },
    getScrollListTemplate() {
        //滚动列表每一项
        let list, scoreImg;
        if (this.data.rank === "StarRank") {
            list = this.data.star;
            scoreImg = 'open-data/image/star.png'
        } else {
            list = this.data.money;
            scoreImg = 'open-data/image/money.png'
        }
        return list.map((v, k) => {
            var medalPic = 'open-data/image/green.png';
            if (k === 0) {
                medalPic = 'open-data/image/gold.png';
            } else if (k === 1) {
                medalPic = 'open-data/image/silver.png';
            }
            return `
        <view class="listItem">
            <image class="listItemBg" src="${k < 2 ? 'open-data/image/c.png' : 'open-data/image/b.png'}"></image>
            <view class="listItemNumBox">
                <image class="listItemMedal" src="${medalPic}"></image>
                <bitmaptext font="fnt_number-export" class="listItemNum" value="${k + 1}"></bitmaptext>
            </view>
            <image class="listHeadImg" src="${v.picUrl}"></image>

            <text class="listItemName" value="${v.name}"></text>
            <image class="listItemScoreImg" src="${scoreImg}"></image>
            <text class="listItemScore" value="${v.score}"></text>
        </view>`
        }).join('');
    },
    getSelfTemplate(){
        //展示自己的排名
        return `
        <view class="listItem listItemSelf">
            <image class="listItemBg" src="open-data/image/a.png"></image>
            <view class="listItemNumBox">
                <image class="listItemMedal" src="open-data/image/green.png"></image>
                <bitmaptext font="fnt_number-export" class="listItemNum" value="23"></bitmaptext>
            </view>
            <image class="listHeadImg" src='open-data/image/face.png'></image>

            <text class="listItemName" value="自己的名字"></text>
            <image class="listItemScoreImg" src="open-data/image/star.png"></image>
            <text class="listItemScore" value="129"></text>
        </view>`
    },
    getTemplate() {
        return `
            <view class="container" id="main">
                ${this.getHeaderTemplate()}
                <scrollview class="list">
                    ${this.getScrollListTemplate()}
                </scrollview>
                ${this.getSelfTemplate()}
            </view>`;
    },
    getStyle() {
        const {width, height} = this.conf;
        //todo 这里元素的宽度高度最好都根据传过来的宽度和高度按比例做计算缩放，这样在不同尺寸的手机上才不会显得尺寸不对
        let style = {
            container: {
                width:width,
                height:height,
                backgroundColor: "#0c626e"
            },
            header: {
                flexDirection: 'row',
                height: 50,
                width,
                justifyContent: 'center',
                alignItems: 'center',
            },
            headerItem: {
                width: width / 2,
                height: 50,
            },
            headerImageOff: {
                height: 42,
                marginTop: 8
            },
            title: {
                width,
                height: 28,
                backgroundColor: "#0c626e",
                flexDirection: 'row',
            },
            titleText: {
                color: '#fff',
                lineHeight: 28,
                fontSize: 20,
                verticalAlign: 'middle',
                height: 24
            },
            titleText1: {
                marginLeft: 16
            },
            titleText2: {
                marginLeft: 40,
                width: width / 2,
            },
            list: {
                width,
                height: height - 178,
            },
            listItemSelf:{
                marginTop: 30
            },
            listItem: {
                width,
                height: 88,
                flexDirection: 'row',
                alignItems: 'center',
            },
            listItemBg: {
                position: "absolute",
                width,
                height: 86,
                borderRadius: 8
            },
            listItemMedal: {
                position: "absolute",
                width: 40,
                height: 40
            },
            listItemNumBox: {
                width: 40,
                height: 40,
                marginRight: 10,
                marginLeft: 6,
            },
            listItemNum: {
                fontSize: 28,
                fontWeight: 'bold',
                lineHeight: 28,
                height: 40,
                textAlign: 'center',
                width: 40,
                verticalAlign: 'middle'
            },
            listHeadImg: {
                borderRadius: 6,
                width: 48,
                height: 48,
                marginRight: 8,
            },
            listItemScore: {
                fontSize: 24,
                fontWeight: 'bold',
                height: 40,
                lineHeight: 40,
                color: '#fff',
                width: 60,
                marginLeft: 10
            },
            listItemScoreImg: {
                width: 28,
                height: 28
            },
            listItemName: {
                color: '#fff',
                verticalAlign: 'middle',
                fontSize: 22,
                lineHeight: 40,
                height: 40,
                width: 142,
                textOverflow: 'ellipsis'
            }
        };
        return style;
    },
    registerBitmap() {
        //用了bitmapFont才需要
        Layout.registBitMapFont(
            'fnt_number-export',
            'open-data/image/fnt_number-export.png',
            `info face="fnt_number-export" size=50 bold=0 italic=0 charset="" unicode=0 stretchH=100 smooth=1 aa=1 padding=0,0,0,0 spacing=1,1
common lineHeight=60 base=26 scaleW=190 scaleH=181 pages=1 packed=0 alphaChnl=1 redChnl=0 greenChnl=0 blueChnl=0
page id=0 file="fnt_number-export.png"
chars count=15
char id=31561 x=0 y=61 width=60 height=61 xoffset=0 yoffset=2 xadvance=57 page=0 chnl=0 letter="等"
char id=32423 x=0 y=0 width=62 height=60 xoffset=0 yoffset=2 xadvance=59 page=0 chnl=0 letter="级"
char id=46 x=168 y=116 width=21 height=21 xoffset=0 yoffset=39 xadvance=18 page=0 chnl=0 letter="."
char id=49 x=145 y=0 width=27 height=57 xoffset=0 yoffset=3 xadvance=24 page=0 chnl=0 letter="1"
char id=50 x=44 y=123 width=41 height=57 xoffset=0 yoffset=3 xadvance=38 page=0 chnl=0 letter="2"
char id=51 x=102 y=58 width=40 height=57 xoffset=0 yoffset=3 xadvance=37 page=0 chnl=0 letter="3"
char id=52 x=143 y=58 width=40 height=57 xoffset=0 yoffset=3 xadvance=37 page=0 chnl=0 letter="4"
char id=53 x=0 y=123 width=43 height=57 xoffset=0 yoffset=3 xadvance=40 page=0 chnl=0 letter="5"
char id=54 x=127 y=116 width=40 height=57 xoffset=0 yoffset=3 xadvance=37 page=0 chnl=0 letter="6"
char id=55 x=86 y=119 width=40 height=57 xoffset=0 yoffset=3 xadvance=37 page=0 chnl=0 letter="7"
char id=56 x=63 y=0 width=40 height=57 xoffset=0 yoffset=3 xadvance=37 page=0 chnl=0 letter="8"
char id=57 x=104 y=0 width=40 height=57 xoffset=0 yoffset=3 xadvance=37 page=0 chnl=0 letter="9"
char id=48 x=61 y=61 width=40 height=57 xoffset=0 yoffset=3 xadvance=37 page=0 chnl=0 letter="0"
char id=32 x=0 y=0 width=0 height=0 xoffset=0 yoffset=0 xadvance=0 page=0 chnl=0 letter=" "
char id=9 x=0 y=0 width=0 height=0 xoffset=0 yoffset=0 xadvance=0 page=0 chnl=0 letter="	"

kernings count=0`
        )
    }
}

SDK.start(main);
