import response from "./response";
import moduleHelper from "./module-helper";

let lastShowTime = 0;

wx.onKeyboardInput((res)=>{
    moduleHelper.send("OnKeyboardInputCallBack",res.value || '');
});

wx.onKeyboardConfirm((res)=>{
    moduleHelper.send("OnKeyboardConfirmCallBack",res.value || '');
});

wx.onKeyboardComplete((res)=>{
    moduleHelper.send("OnKeyboardCompleteCallBack",res.value || '');
});

const mod = {
    WXUpdateKeyboard(value,s,f,c){
        wx.updateKeyboard({
            value,
            ...response.handleText(s,f,c)
        })
    },
    WXShowKeyboard(conf,s,f,c){
        lastShowTime = new Date().getTime();
        wx.showKeyboard({
            ...JSON.parse(conf),
            ...response.handleText(s,f,c)
        });
    },
    WXHideKeyboard(s,f,c){
        if(new Date().getTime() - lastShowTime <500){
            return false;
        }
        wx.hideKeyboard({
            ...response.handleText(s,f,c)
        });
    }
};
export default mod;