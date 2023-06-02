import moduleHelper from './module-helper';
import { formatJsonStr } from './utils';
let shareResolve;
export default {
    WXShareAppMessage(conf) {
        wx.shareAppMessage({
            ...formatJsonStr(conf),
        });
    },
    WXOnShareAppMessage(conf, isPromise) {
        wx.onShareAppMessage(() => ({
            ...formatJsonStr(conf),
            promise: isPromise
                ? new Promise((resolve) => {
                    shareResolve = resolve;
                    moduleHelper.send('OnShareAppMessageCallback');
                })
                : null,
        }));
    },
    WXOnShareAppMessageResolve(conf) {
        if (shareResolve) {
            shareResolve(formatJsonStr(conf));
        }
    },
};
wx.showShareMenu({
    menus: ['shareAppMessage', 'shareTimeline'],
});
