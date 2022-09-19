import response from "./response";
let CloudIDObject = {};
function fixWXCallFunctionData(data){
    for(var key in data){
        if(typeof data[key] == 'object'){
            fixWXCallFunctionData(data[key])
        }else if(typeof data[key] == 'string' && CloudIDObject[data[key]]){
            data[key] = CloudIDObject[data[key]];
        }
    }
}
export default {
    WXCallFunctionInit(conf){
        if(typeof conf === 'string'){
            conf = JSON.parse(conf);
        }
        wx.cloud.init(conf);
    },
    WXCallFunction(name,data,conf,s,f,c) {
        var d = JSON.parse(data);
        fixWXCallFunctionData(d);
        wx.cloud.callFunction({
            name: name,
            data: d,
            config: conf == "" ? null : JSON.parse(conf),
            ...response.handlecloudCallFunction(s,f,c)
        })
    },
    WXCloudID(cloudId){
        var res = wx.cloud.CloudID(cloudId);
        var r =  JSON.stringify(res);
        CloudIDObject[r] = res;
        return r;
    }
}
