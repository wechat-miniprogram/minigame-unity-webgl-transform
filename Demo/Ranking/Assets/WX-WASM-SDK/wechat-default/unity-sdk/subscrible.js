import response from "./response";
export default {
    WXRequestSubscribeSystemMessage(list,s,f,c){
        wx.requestSubscribeSystemMessage({
            msgTypeList: list.split(','),
            ...response.handle(response.subscribeSystemMessageFormat,s,f,c)
        })
    }
}
