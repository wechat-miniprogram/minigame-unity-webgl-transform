import moduleHelper from "./module-helper";
let shareResolve;
export default {
    WXShareAppMessage(conf){
        wx.shareAppMessage({
            ...JSON.parse(conf)
        });
    },
    WXOnShareAppMessage(conf,isPromise){
        wx.onShareAppMessage(()=>{
            return {
                ...JSON.parse(conf),
                promise:isPromise ? new Promise((resolve)=>{
                    shareResolve = resolve;
                    moduleHelper.send('OnShareAppMessageCallback');
                }):null
            }
        });
    },
    WXOnShareAppMessageResolve(conf){
        if(shareResolve){
            shareResolve(JSON.parse(conf));
        }
    },
}

wx.showShareMenu({
    menus: ['shareAppMessage', 'shareTimeline']
});


