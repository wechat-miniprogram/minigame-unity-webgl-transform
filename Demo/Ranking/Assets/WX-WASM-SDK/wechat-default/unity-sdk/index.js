import storage from "./storage";
import userInfo from "./userinfo";
import moduleHelper from "./module-helper";
import share from "./share";
import system from "./system";
import login from "./login";
import ad from "./ad";
import canvasHelper from "./canvas";
import fs from "./fs";
import openData from "./open-data";
import input from "./input";
import util from "./util";
import cloud from "./cloud";
import audio from "./audio";
import texture from "./texture";
import pay from "./pay";
import fix from "./fix";
import canvasContext from "./canvas-context";
import video from "./video";

const unityVersion = "$unityVersion$";
window._ScaleRate = 1;
//兼容unity低版本高清屏的问题
if(unityVersion && unityVersion.split('.').slice(0,2).join('')<'20193'){
    var width = window.innerWidth*window.devicePixelRatio;
    var height = window.innerHeight*window.devicePixelRatio;
    canvas.width = width;
    canvas.height = height;
    window._ScaleRate = window.devicePixelRatio;
}


Object.defineProperty(canvas,'clientHeight',{
    get:function(){
        return window.innerHeight * window._ScaleRate;
    },
    configuarble:true
});

Object.defineProperty(canvas,'clientWidth',{
    get:function(){
        return window.innerWidth * window._ScaleRate;
    },
    configuarble:true
});

Object.defineProperty(document.body,'clientHeight',{
    get:function(){
        return window.innerHeight * window._ScaleRate;
    },
    configuarble:true
});

Object.defineProperty(document.body,'clientWidth',{
    get:function(){
        return window.innerWidth * window._ScaleRate;
    },
    configuarble:true
});

fix.init();

const WXWASMSDK = {
    /*
      初始化
     */
    WXInitializeSDK(){
        moduleHelper.init();
        moduleHelper.send('Inited', 200);
        system.init();
    },

    ...login,
    ...system,
    ...storage,
    ...userInfo,
    ...share,
    ...ad,
    ...canvasHelper,
    ...fs,
    ...openData,
    ...input,
    ...util,
    ...cloud,
    ...audio,
    ...texture,
    ...pay,
    ...video,
    canvasContext

};



GameGlobal.WXWASMSDK = WXWASMSDK;
