/* eslint-disable indent */
import { getFriendRankData, getGroupFriendsRankData, setUserRecord } from './data/index';
import getFriendRankXML from './render/tpls/friendRank';
import getFriendRankStyle from './render/styles/friendRank';
import getTipsXML from './render/tpls/tips';
import getTipsStyle from './render/styles/tips';
import { showLoading } from './loading';
const Layout = requirePlugin('Layout').default;
const RANK_KEY = 'user_rank';
const sharedCanvas = wx.getSharedCanvas();
const sharedContext = sharedCanvas.getContext('2d');
// test
setUserRecord(RANK_KEY, Math.ceil(Math.random() * 1000));
const MessageType = {
    WX_RENDER: 'WXRender',
    WX_DESTROY: 'WXDestroy',
    SHOW_FRIENDS_RANK: 'showFriendsRank',
    SHOW_GROUP_FRIENDS_RANK: 'showGroupFriendsRank',
    SET_USER_RECORD: 'setUserRecord',
};
/**
 * 绑定邀请好友事件
 * 温馨提示，这里仅仅是示意，请注意修改 shareMessageToFriend 参数
 */
const initShareEvents = () => {
    // 绑定邀请
    const shareBtnList = Layout.getElementsByClassName('shareToBtn');
    shareBtnList
        && shareBtnList.forEach((item) => {
            item.on('click', () => {
                if (item.dataset.isSelf === 'false') {
                    wx.shareMessageToFriend({
                        openId: item.dataset.id,
                        title: '最强战力排行榜！谁是第一？',
                        imageUrl: 'https://mmgame.qpic.cn/image/5f9144af9f0e32d50fb878e5256d669fa1ae6fdec77550849bfee137be995d18/0',
                    });
                }
            });
        });
};
/**
 * 初始化开放域，主要是使得 Layout 能够正确处理跨引擎的事件处理
 * 如果游戏里面有移动开放数据域对应的 RawImage，也需要抛事件过来执行Layout.updateViewPort
 */
const initOpenDataCanvas = async (data) => {
    Layout.updateViewPort({
        x: data.x / data.devicePixelRatio,
        y: data.y / data.devicePixelRatio,
        width: data.width / data.devicePixelRatio,
        height: data.height / data.devicePixelRatio,
    });
};
// 给定 xml 和 style，渲染至 sharedCanvas
function LayoutWithTplAndStyle(xml, style) {
    Layout.clear();
    Layout.init(xml, style);
    Layout.layout(sharedContext);
    console.log(Layout);
}
// 仅仅渲染一些提示，比如数据加载中、当前无授权等
function renderTips(tips = '') {
    LayoutWithTplAndStyle(getTipsXML({
        tips,
    }), getTipsStyle({
        width: sharedCanvas.width,
        height: sharedCanvas.height,
    }));
}
// 将好友排行榜数据渲染在 sharedCanvas
async function renderFriendsRank() {
    showLoading();
    try {
        const data = await getFriendRankData(RANK_KEY);
        if (!data.length) {
            renderTips('暂无好友数据');
            return;
        }
        LayoutWithTplAndStyle(getFriendRankXML({
            data,
        }), getFriendRankStyle({
            width: sharedCanvas.width,
            height: sharedCanvas.height,
        }));
        initShareEvents();
    }
    catch (e) {
        console.error('renderFriendsRank error', e);
        renderTips('请进入设置页允许获取微信朋友信息');
    }
}
// 渲染群排行榜
async function renderGroupFriendsRank(shareTicket) {
    showLoading();
    try {
        const data = await getGroupFriendsRankData(shareTicket, RANK_KEY);
        if (!data.length) {
            renderTips('暂无群同玩好友数据');
            return;
        }
        LayoutWithTplAndStyle(getFriendRankXML({
            data,
        }), getFriendRankStyle({
            width: sharedCanvas.width,
            height: sharedCanvas.height,
        }));
    }
    catch (e) {
        renderTips('群同玩好友数据加载失败');
    }
}
function main() {
    wx.onMessage((data) => {
        console.log('[WX OpenData] onMessage', data);
        if (typeof data === 'string') {
            try {
                // eslint-disable-next-line no-param-reassign
                data = JSON.parse(data);
            }
            catch (e) {
                console.error('[WX OpenData] onMessage data is not a object');
                return;
            }
        }
        switch (data.type) {
            // 来自 WX Unity SDK 的信息
            case MessageType.WX_RENDER:
                initOpenDataCanvas(data);
                break;
            // 来自 WX Unity SDK 的信息
            case MessageType.WX_DESTROY:
                Layout.clearAll();
                break;
            // 下面为业务自定义消息
            case MessageType.SHOW_FRIENDS_RANK:
                renderFriendsRank();
                break;
            case MessageType.SHOW_GROUP_FRIENDS_RANK:
                renderGroupFriendsRank(data.shareTicket);
                break;
            case MessageType.SET_USER_RECORD:
                setUserRecord(RANK_KEY, data.score);
                break;
            default:
                console.error(`[WX OpenData] onMessage type 「${data.type}」 is not supported`);
                break;
        }
    });
}
main();
