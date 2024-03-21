import response from './response';
import { formatJsonStr } from './utils';
const CloudIDObject = {};
function fixWXCallFunctionData(data) {
    
    for (const key in data) {
        if (typeof data[key] === 'object') {
            fixWXCallFunctionData(data[key]);
        }
        else if (typeof data[key] === 'string' && CloudIDObject[data[key]]) {
            data[key] = CloudIDObject[data[key]];
        }
    }
}
export default {
    WXCallFunctionInit(conf) {
        const config = formatJsonStr(conf);
        wx.cloud.init(config);
    },
    WXCallFunction(name, data, conf, s, f, c) {
        const d = JSON.parse(data);
        fixWXCallFunctionData(d);
        wx.cloud.callFunction({
            name,
            data: d,
            config: conf === '' ? null : JSON.parse(conf),
            ...response.handlecloudCallFunction(s, f, c),
        });
    },
    WXCloudID(cloudId) {
        
        const res = wx.cloud.CloudID(cloudId);
        const r = JSON.stringify(res);
        CloudIDObject[r] = res;
        return r;
    },
};
