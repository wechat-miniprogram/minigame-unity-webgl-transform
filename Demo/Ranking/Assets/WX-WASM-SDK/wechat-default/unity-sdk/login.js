import response from "./response";

export default {
    /*登录*/
    WXLogin(s,f,c){
        wx.login(response.handleLogin(s,f,c));
    },
    WXCheckSession(s,f,c){
        wx.checkSession(response.handleText(s,f,c));
    },
    WXAuthorize(scope,s,f,c){
        wx.authorize({
            scope,
            ...response.handleText(s,f,c)
        });
    },
}