import response from "./response";
import moduleHelper from "./module-helper";
let shareResolve;
export default {
    WXUpdateShareMenu(conf,s,f,c){
        let param = JSON.parse(conf);
        if(param.templateInfoRaw.length){
            param.templateInfo = {
                parameterList:param.templateInfoRaw.map(v=>JSON.parse(v))
            }
        }
        wx.updateShareMenu({
            ...param,
            ...response.handleText(s,f,c)
        });
    },
    WXShowShareMenu(conf,s,f,c){
        wx.showShareMenu({
            ...JSON.parse(conf),
            ...response.handleText(s,f,c)
        });
    },
    WXHideShareMenu(conf,s,f,c){
        wx.hideShareMenu({
            ...JSON.parse(conf),
            ...response.handleText(s,f,c)
        });
    },
    WXShareAppMessage(conf){
        wx.shareAppMessage({
            ...JSON.parse(conf)
        });
    },
    WXSetMessageToFriendQuery(num){
        return wx.setMessageToFriendQuery({
            shareMessageToFriendScene:num
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
    WXOnShareTimeline(conf,needCallback){
        wx.onShareTimeline(()=>{
            if(needCallback){
                moduleHelper.send('OnShareTimelineCallback');
            }
            return JSON.parse(conf)
        });
    },
    WXOnAddToFavorites(conf,needCallback){
        wx.onAddToFavorites(()=>{
            if(needCallback){
                moduleHelper.send('OnAddToFavoritesCallback');
            }
            return JSON.parse(conf)
        });
    },
    WXOffShareTimeline(){
        wx.offShareTimeline();
    },
    WXOffShareAppMessage(){
        wx.offShareAppMessage();
    },
    WXOffAddToFavorites(){
        wx.offAddToFavorites();
    },
    WXGetShareInfo(conf,s,f,c){
        wx.getShareInfo({
            ...JSON.parse(conf),
            ...response.handleShareInfo(s,f,c)
        });
    },
    WXAuthPrivateMessage(conf,s,f,c){
        wx.authPrivateMessage({
            ...JSON.parse(conf),
            ...response.handleAuthPrivateMessage(s,f,c)
        });
    }
}

wx.showShareMenu({
    menus: ['shareAppMessage', 'shareTimeline']
});


