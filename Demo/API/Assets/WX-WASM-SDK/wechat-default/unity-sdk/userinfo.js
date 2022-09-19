import response from "./response";

const userInfoButtons = {};
import moduleHelper from "./module-helper";

export default {
    /*userInfo按钮*/
    WXCreateUserInfoButton(x, y, width, height, lang, withCredentials){
        const button = wx.createUserInfoButton({
            type: 'text',
            text: '',
            withCredentials,
            lang,
            style: {
                left: x/window.devicePixelRatio,
                top: y/window.devicePixelRatio,
                width: width/window.devicePixelRatio,
                height: height/window.devicePixelRatio,
                backgroundColor: 'rgba(0,0,0,0)',
                color: 'rgba(0,0,0,0)',
                textAlign: 'center',
                fontSize: 0,
                borderRadius: 0
            }
        });

        const key = new Date().getTime().toString(32)+Math.random().toString(32);
        userInfoButtons[key] = button;
        return key;
    },

    WXUserInfoButtonShow(id){
        const button = userInfoButtons[id];
        if(!button){
            return false;
        }
        button.show();
    },
    WXUserInfoButtonDestroy(id){
        const button = userInfoButtons[id];
        if(!button){
            return false;
        }
        button.destroy();
        delete userInfoButtons[id];
    },
    WXUserInfoButtonHide(id){
        const button = userInfoButtons[id];
        if(!button){
            return false;
        }
        button.hide();
    },
    WXUserInfoButtonOffTap(id){
        const button = userInfoButtons[id];
        if(!button){
            return false;
        }
        button.offTap();
    },
    WXUserInfoButtonOnTap(id){
        const button = userInfoButtons[id];
        if(!button){
            return false;
        }
        button.onTap((res)=>{
            res.userInfo = res.userInfo || {};
            moduleHelper.send('UserInfoButtonOnTapCallback',JSON.stringify({
                callbackId:id,
                errCode:res.err_code || (res.errMsg.indexOf('getUserInfo:fail')===0? 1 : 0),
                errMsg:res.errMsg || '',
                signature:res.signature || '',
                encryptedData: res.encryptedData || '',
                iv:res.iv|| '',
                cloudID:res.cloudID || '',
                userInfoRaw:JSON.stringify({
                    nickName:res.userInfo.nickName || '',
                    avatarUrl:res.userInfo.avatarUrl || '',
                    country:res.userInfo.country || '',
                    province:res.userInfo.province || '',
                    city:res.userInfo.city || '',
                    language:res.userInfo.language || '',
                    gender:res.userInfo.gender || 0
                }),
            }));
        });
    },
}
