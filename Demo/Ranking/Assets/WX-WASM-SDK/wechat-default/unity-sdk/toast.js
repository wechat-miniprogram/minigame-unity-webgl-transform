import response from "./response";
import moduleHelper from "./module-helper";

export default {
    WXShowToast(title, icon, duration, mask,  s,  f,  c){
        wx.showToast({
            title, icon, duration, mask:Boolean(mask),
            ...response.handleText(s,f,c)
        });
    },
    WXHideToast(s,  f,  c){
        wx.hideToast({
            ...response.handleText(s,f,c)
        });
    },
    WXShowModal(conf,s,  f,  c){
        wx.showModal({
            ...JSON.parse(conf),
            ...response.handle(response.modalFormat,s,f,c)
        });
    },
    WXShowLoading(conf,s,  f,  c){
        wx.showLoading({
            ...JSON.parse(conf),
            ...response.handleText(s,f,c)
        });
    },
    WXHideLoading(s,  f,  c){
        wx.hideLoading({
            ...response.handleText(s,f,c)
        });
    }
}
