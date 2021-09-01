import response from "./response";

export default {
    WXCallFunctionInit(conf){
        if(typeof conf === 'string'){
            conf = JSON.parse(conf);
        }
        wx.cloud.init(conf);
    },
    WXCallFunction(name,data,conf,s,f,c) {
        wx.cloud.callFunction({
            name: name,
            data: JSON.parse(data),
            config: conf == "" ? null : JSON.parse(conf),
            ...response.handlecloudCallFunction(s,f,c)
        })
    }
}