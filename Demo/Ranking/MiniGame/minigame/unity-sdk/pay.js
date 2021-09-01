import response from "./response";
export default {
    WXRequestMidasPayment(conf,s,f,c){
        wx.requestMidasPayment({
            ...JSON.parse(conf),
            ...response.handleTextLongBack(s,f,c)
        })
    },
    WXRequestMidasFriendPayment(conf,s,f,c){
        wx.requestMidasFriendPayment({
            ...JSON.parse(conf),
            ...response.handleTextLongBack(s,f,c)
        })
    }
}