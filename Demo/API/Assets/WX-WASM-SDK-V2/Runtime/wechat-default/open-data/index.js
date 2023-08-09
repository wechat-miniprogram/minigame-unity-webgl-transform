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

setUserRecord(RANK_KEY, Math.ceil(Math.random() * 1000));
const MessageType = {
    WX_RENDER: 'WXRender',
    WX_DESTROY: 'WXDestroy',
    SHOW_FRIENDS_RANK: 'showFriendsRank',
    SHOW_GROUP_FRIENDS_RANK: 'showGroupFriendsRank',
    SET_USER_RECORD: 'setUserRecord',
};
const initShareEvents = () => {
    
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
const initOpenDataCanvas = async (data) => {
    Layout.updateViewPort({
        x: data.x / data.devicePixelRatio,
        y: data.y / data.devicePixelRatio,
        width: data.width / data.devicePixelRatio,
        height: data.height / data.devicePixelRatio,
    });
};

function LayoutWithTplAndStyle(xml, style) {
    Layout.clear();
    Layout.init(xml, style);
    Layout.layout(sharedContext);
    console.log(Layout);
}

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
                
                data = JSON.parse(data);
            }
            catch (e) {
                console.error('[WX OpenData] onMessage data is not a object');
                return;
            }
        }
        switch (data.type) {
            
            case MessageType.WX_RENDER:
                initOpenDataCanvas(data);
                break;
            
            case MessageType.WX_DESTROY:
                Layout.clearAll();
                break;
            
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
