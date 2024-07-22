import { getCurrTime, promisify } from './utils';
const getFriendCloudStorage = promisify(wx.getFriendCloudStorage);
const getGroupCloudStorage = promisify(wx.getGroupCloudStorage);
const setUserCloudStorage = promisify(wx.setUserCloudStorage);
const getUserInfo = promisify(wx.getUserInfo);
export function getSelfData() {
    return getUserInfo({
        openIdList: ['selfOpenId'],
    }).then((res) => res.data[0] || {});
}
let getSelfPromise;
function getWxGameData(item) {
    let source;
    try {
        source = JSON.parse(item.KVDataList[0].value);
    }
    catch (e) {
        source = {
            wxgame: {
                score: 0,
                update_time: getCurrTime(),
            },
        };
    }
    return source.wxgame;
}
function rankDataFilter(res, selfUserInfo = false) {
    const data = (res.data || []).filter((item) => item.KVDataList && item.KVDataList.length);
    return data
        .map((item) => {
        const { score, update_time: updateTime } = getWxGameData(item);
        item.score = score;
        item.update_time = updateTime;
                if (selfUserInfo && selfUserInfo.avatarUrl === item.avatarUrl) {
            item.isSelf = true;
        }
        return item;
    })
        
        .sort((a, b) => b.score - a.score);
}
export function getFriendRankData(key, needMarkSelf = true) {
    console.log('[WX OpenData] getFriendRankData with key: ', key);
    return getFriendCloudStorage({
        keyList: [key],
    }).then((res) => {
        console.log('[WX OpenData] getFriendRankData success: ', res);
        if (needMarkSelf) {
            getSelfPromise = getSelfPromise || getSelfData();
            return getSelfPromise.then(userInfo => rankDataFilter(res, userInfo));
        }
        return rankDataFilter(res);
    });
}
export function getGroupFriendsRankData(shareTicket, key, needMarkSelf = true) {
    console.log('[WX OpenData] getGroupFriendsRankData with shareTicket and key: ', shareTicket, key);
    return getGroupCloudStorage({
        shareTicket,
        keyList: [key],
    }).then((res) => {
        console.log('[WX OpenData] getGroupFriendsRankData success: ', res);
        if (needMarkSelf) {
            getSelfPromise = getSelfPromise || getSelfData();
            return getSelfPromise.then(userInfo => rankDataFilter(res, userInfo));
        }
        return rankDataFilter(res);
    });
}
export function setUserRecord(key, score = 0, extra = {}) {
    console.log('[WX OpenData] setUserRecord: ', score);
    return setUserCloudStorage({
        KVDataList: [
            {
                key,
                value: JSON.stringify({
                    wxgame: {
                        score,
                        
                        update_time: getCurrTime(),
                    },
                    
                    ...extra,
                }),
            },
        ],
    }).then((res) => {
        console.log('[WX OpenData] setUserRecord success: ', res);
    });
}
