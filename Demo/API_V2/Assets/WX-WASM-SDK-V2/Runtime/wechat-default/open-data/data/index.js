/* eslint-disable no-param-reassign */
import { getCurrTime, promisify } from './utils';
const getFriendCloudStorage = promisify(wx.getFriendCloudStorage);
const getGroupCloudStorage = promisify(wx.getGroupCloudStorage);
const setUserCloudStorage = promisify(wx.setUserCloudStorage);
const getUserInfo = promisify(wx.getUserInfo);
/**
 * 获取用户信息
 * API文档可见：https://developers.weixin.qq.com/minigame/dev/api/open-api/data/OpenDataContext-wx.getUserInfo.html
 */
export function getSelfData() {
    return getUserInfo({
        openIdList: ['selfOpenId'],
    }).then((res) => res.data[0] || {});
}
let getSelfPromise;
/**
 * 将 UserGameData 数据反序列化
 * @param { UserGameData } item
 * https://developers.weixin.qq.com/minigame/dev/api/open-api/data/UserGameData.html
 */
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
/**
 * 处理 getFriendCloudStorage 和 getGroupCloudStorage 返回的在玩好友数据
 */
function rankDataFilter(res, selfUserInfo = false) {
    const data = (res.data || []).filter((item) => item.KVDataList && item.KVDataList.length);
    return data
        .map((item) => {
        const { score, update_time: updateTime } = getWxGameData(item);
        item.score = score;
        item.update_time = updateTime;
        /**
         * 请注意，这里判断是否为自己并不算特别严谨的做法
         * 比较严谨的做法是从游戏域将openid传进来，示例为了简化，简单通过 avatarUrl 来判断
         */
        if (selfUserInfo && selfUserInfo.avatarUrl === item.avatarUrl) {
            item.isSelf = true;
        }
        return item;
    })
        // 升序排序
        .sort((a, b) => b.score - a.score);
}
/**
 * 获取好友排行榜列表
 * API文档可见：https://developers.weixin.qq.com/minigame/dev/api/open-api/data/wx.getFriendCloudStorage.html
 */
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
/**
 * 获取群同玩成员的游戏数据。小游戏通过群分享卡片打开的情况下才可以调用。该接口需要用户授权，且只在开放数据域下可用。
 * API文档可见: https://developers.weixin.qq.com/minigame/dev/api/open-api/data/wx.getGroupCloudStorage.html
 */
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
/**
 * 写入用户排行榜数据，value 的值一般只需要为 Object 经过 JSON.stringify 的字符串即可。
 * 但排行榜支持展示在游戏中心，因此这里统一用游戏中心需要的数据结构执行上报，需要展示在游戏中心的数据可以经过以下操作：
 * mp.weixin.qq.com 的小游戏管理后台“设置 - 游戏 - 排行榜设置”下配置对应的 key 以及相关排行榜属性。
 * @param { String } key   排行榜对应的 key
 * @param { Number } score 排行榜对应的分数
 * @param { Object } extra 除了分数还需要写入的其他字段，不需要不填即可
 * @example
 * setUserRecord('user_rank', 100, { type: 'coin' })
 */
export function setUserRecord(key, score = 0, extra = {}) {
    console.log('[WX OpenData] setUserRecord: ', score);
    return setUserCloudStorage({
        KVDataList: [
            {
                key,
                value: JSON.stringify({
                    wxgame: {
                        score,
                        // 时间单位：秒
                        update_time: getCurrTime(),
                    },
                    // wxgame下开发者不可自定义其他字段， wxgame同级开发者可自由定义，比如定义一个detail 字段，用于存储取得该分数的中间状态。
                    ...extra,
                }),
            },
        ],
    }).then((res) => {
        console.log('[WX OpenData] setUserRecord success: ', res);
    });
}
