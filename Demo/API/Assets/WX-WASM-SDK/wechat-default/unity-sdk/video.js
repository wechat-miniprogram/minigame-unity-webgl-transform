const videos = {};
const msg = 'Video 不存在!';
import moduleHelper from "./module-helper";
export default {
    WXCreateVideo(conf){
        const id = new Date().getTime().toString(32)+Math.random().toString(32);
        videos[id] = wx.createVideo(JSON.parse(conf));
        return id;
    },
    WXVideoPlay(id){
        if(videos[id]){
            videos[id].play();
        }else{
            console.error(msg,id);
        }
    },
    WXVideoAddListener(id,key){
        if(videos[id]){
            videos[id][key](function(e){
                moduleHelper.send('OnVideoCallback',JSON.stringify({
                    callbackId:id,
                    errMsg:key,
                    position:e && e.position,
                    buffered:e && e.buffered,
                    duration:e && e.duration
                }));
                if(key === 'onError'){
                    console.error(e);
                }
            });
        }else{
            console.error(msg,id);
        }
    },
    WXVideoDestroy(id){
        if(videos[id]){
            videos[id].destroy();
        }else{
            console.error(msg,id);
        }
    },
    WXVideoExitFullScreen(id){
        if(videos[id]){
            videos[id].exitFullScreen();
        }else{
            console.error(msg,id);
        }
    },
    WXVideoPause(id){
        if(videos[id]){
            videos[id].pause();
        }else{
            console.error(msg,id);
        }
    },
    WXVideoRequestFullScreen(id,direction){
        if(videos[id]){
            videos[id].requestFullScreen(direction);
        }else{
            console.error(msg,id);
        }
    },
    WXVideoSeek(id,time){
        if(videos[id]){
            videos[id].seek(time);
        }else{
            console.error(msg,id);
        }
    },
    WXVideoStop(id){
        if(videos[id]){
            videos[id].stop();
        }else{
            console.error(msg,id);
        }
    },
    WXVideoRemoveListener(id,key){
        if(videos[id]){
            videos[id][key]();
        }else{
            console.error(msg,id);
        }
    }
}
