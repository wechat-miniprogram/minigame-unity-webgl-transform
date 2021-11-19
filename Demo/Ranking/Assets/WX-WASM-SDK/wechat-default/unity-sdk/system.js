import {langConf} from "./conf";
import response from "./response";
import moduleHelper from "./module-helper";

let systemInfo = {};

wx.getSystemInfo({
    success(res){
        systemInfo = res;
    }
});

let isVibrating = false;
const vibratingSuccessList = [];
const vibratingCompleteList = [];
const vibratingFailList = [];


export default {
    init(){
        wx.onShow((res)=>{
            res.referrerInfo = res.referrerInfo || {};
            moduleHelper.send("OnShowCallback",JSON.stringify({
                scene:res.scene || '',
                queryRaw:JSON.stringify(res.query),
                shareTicket:res.shareTicket || '',
                referrerInfoRaw:JSON.stringify({
                    appId:res.referrerInfo.appId || '' ,
                    extraDataRaw:JSON.stringify(res.referrerInfo.extraData || {})
                })
            }));
        });
        wx.onHide(()=>{
            moduleHelper.send("OnHideCallback");
        });

        wx.onAudioInterruptionBegin(()=>{
            moduleHelper.send("OnAudioInterruptionBeginCallback");
        });

        wx.onAudioInterruptionEnd(()=>{
            moduleHelper.send("OnAudioInterruptionEndCallback");
        });

        function formatEvent(v){
            //这里将坐标转换为Unity的坐标
            return {
                identifier:parseInt(v.identifier),
                clientX : parseInt(v.clientX * devicePixelRatio),
                clientY : parseInt((window.innerHeight - v.clientY) * devicePixelRatio),
                pageX : parseInt(v.pageX * devicePixelRatio),
                pageY : parseInt((window.innerHeight - v.pageY) * devicePixelRatio)
            }
        }

        wx.onTouchStart((res)=>{
            var touches = res.touches.map(v=>formatEvent(v));
            moduleHelper.send('OnTouchStartCallBack',JSON.stringify({
                touches,
                timeStamp:parseInt(res.timeStamp),
                changedTouches:res.changedTouches.map(v=>formatEvent(v))
            }));
        });

        wx.onTouchEnd((res)=>{
            var touches = res.touches.map(v=>formatEvent(v));
            moduleHelper.send('OnTouchEndCallBack',JSON.stringify({
                touches,
                timeStamp:parseInt(res.timeStamp),
                changedTouches:res.changedTouches.map(v=>formatEvent(v))
            }));
        });

        wx.onTouchMove((res)=>{
            var touches = res.touches.map(v=>formatEvent(v));
            moduleHelper.send('OnTouchMoveCallBack',JSON.stringify({
                touches,
                timeStamp:parseInt(res.timeStamp),
                changedTouches:res.changedTouches.map(v=>formatEvent(v))
            }));
        });

        wx.onNetworkStatusChange((res)=>{
            moduleHelper.send('WXOnNetworkStatusChangeCallback',JSON.stringify(res));
        });

    },
    /*获取客户端语言*/
    WXGetSystemLanguage(){
        const lang = (systemInfo.language || navigator.language).toLowerCase().replace('_','-');
        let item = langConf.find(v=>{
            return (lang === v[0]) || (lang === v[0].split('-')[0]);
        });
        return item ? item[1] : 'Unknown';
    },

    /*获取系统信息*/
    WXGetSystemInfo(s,f,c){
        wx.getSystemInfo({
            success(res){
                systemInfo = res;
                send(s,res);
            },
            fail(res){
                send(f,res);
            },
            complete(res){
                send(c,res);
            }
        });
        function send(id,res){
            if(!id){
                return false;
            }
            res.safeAreaRaw = JSON.stringify(res.safeArea || {});
            moduleHelper.send('SysInfoResponseCallback', JSON.stringify({
                callbackId:id,
                ...res
            }));
        }
    },
    WXGetSystemInfoSync(){
        let res = systemInfo;
        try{
            res = wx.getSystemInfoSync();
            systemInfo = res;
        }catch (e) {
            console.error(e);
        }
        res.safeAreaRaw = JSON.stringify(systemInfo.safeArea || {});
        return JSON.stringify(res);
    },

    /*
       振动
     */
    VibrateShort(s,f,c){
        if(s){
            vibratingSuccessList.push(s);
        }
        if(f){
            vibratingFailList.push(f);
        }
        if(c){
            vibratingCompleteList.push(c);
        }
        if(isVibrating){
            return false;
        }
        isVibrating = true;
        wx.vibrateShort({
            success(res){
                while (vibratingSuccessList.length){
                    response.textFormat(vibratingSuccessList.shift(),res);
                }
            },
            fail(res){
                while (vibratingFailList.length){
                    response.textFormat(vibratingFailList.shift(),res);
                }
            },
            complete(res){
                isVibrating = false;
                while (vibratingCompleteList.length){
                    response.textFormat(vibratingCompleteList.shift(),res);
                }
            }
        });
    },
    VibrateLong(s,f,c){
        if(s){
            vibratingSuccessList.push(s);
        }
        if(f){
            vibratingFailList.push(f);
        }
        if(c){
            vibratingCompleteList.push(c);
        }
        if(isVibrating){
            return false;
        }
        isVibrating = true;
        wx.vibrateLong({
            success(res){
                while (vibratingSuccessList.length){
                    response.textFormat(vibratingSuccessList.shift(),res);
                }
            },
            fail(res){
                while (vibratingFailList.length){
                    response.textFormat(vibratingFailList.shift(),res);
                }
            },
            complete(res){
                isVibrating = false;
                while (vibratingCompleteList.length){
                    response.textFormat(vibratingCompleteList.shift(),res);
                }
            }
        });
    },
    /*生命周期*/
    WXGetLaunchOptionsSync(){
        const res = wx.getLaunchOptionsSync();
        res.referrerInfo = res.referrerInfo || {};
        return JSON.stringify({
            scene:res.scene || '',
            queryRaw:JSON.stringify(res.query),
            shareTicket:res.shareTicket || '',
            referrerInfoRaw:JSON.stringify({
                appId:res.referrerInfo.appId || '' ,
                extraDataRaw:JSON.stringify(res.referrerInfo.extraData || {})
            })
        })
    },

    /*网络*/
    WXGetNetworkType(s,f,c){
        wx.getNetworkType(response.handleNetworkType(s,f,c))
    },

    /*屏幕*/
    WXSetKeepScreenOn(keepScreenOn,s,f,c){
        wx.setKeepScreenOn({
            keepScreenOn: keepScreenOn == 1,
            ...response.handleText(s,f,c)
        })
    },

    /*跳转*/
    WXExitMiniProgram(s,f,c){
        wx.exitMiniProgram(response.handleText(s,f,c));
    },

    /*客服消息*/
    WXOpenCustomerServiceConversation(conf,s,f,c){
        wx.openCustomerServiceConversation({
            ...JSON.parse(conf),
            ...response.handleText(s,f,c)
        })
    },

    /*剪切板*/
    WXSetClipboardData(data,s, f, c){
        wx.setClipboardData({
            data,
            ...response.handleText(s,f,c)
        });
    },
    WXGetClipboardData(s, f, c){
        wx.getClipboardData({
            ...response.handleClipboard(s,f,c)
        })
    }
}
