import moduleHelper from './module-helper';
const videos = {};
const msg = 'Video 不存在!';
export default {
  WXCreateVideo(conf) {
    const id = new Date().getTime()
      .toString(32) + Math.random().toString(32);
    const params = JSON.parse(conf);
    // 如果是主屏下的视频，修改下全局标记，标记不清理透明度
    if (params.underGameView) {
      GameGlobal.enableTransparentCanvas = true;
    }
    videos[id] = wx.createVideo(params);
    return id;
  },
  WXVideoPlay(id) {
    if (videos[id]) {
      videos[id].play();
    } else {
      console.error(msg, id);
    }
  },
  WXVideoAddListener(id, key) {
    if (videos[id]) {
      videos[id][key]((e) => {
        moduleHelper.send('OnVideoCallback', JSON.stringify({
          callbackId: id,
          errMsg: key,
          position: e && e.position,
          buffered: e && e.buffered,
          duration: e && e.duration,
        }));
        if (key === 'onError') {
          GameGlobal.enableTransparentCanvas = false;
          console.error(e);
        }
      });
    } else {
      console.error(msg, id);
    }
  },
  WXVideoDestroy(id) {
    if (videos[id]) {
      videos[id].destroy();
    } else {
      console.error(msg, id);
    }
    GameGlobal.enableTransparentCanvas = false;
  },
  WXVideoExitFullScreen(id) {
    if (videos[id]) {
      videos[id].exitFullScreen();
    } else {
      console.error(msg, id);
    }
  },
  WXVideoPause(id) {
    if (videos[id]) {
      videos[id].pause();
    } else {
      console.error(msg, id);
    }
  },
  WXVideoRequestFullScreen(id, direction) {
    if (videos[id]) {
      videos[id].requestFullScreen(direction);
    } else {
      console.error(msg, id);
    }
  },
  WXVideoSeek(id, time) {
    if (videos[id]) {
      videos[id].seek(time);
    } else {
      console.error(msg, id);
    }
  },
  WXVideoStop(id) {
    if (videos[id]) {
      videos[id].stop();
    } else {
      console.error(msg, id);
    }
  },
  WXVideoRemoveListener(id, key) {
    if (videos[id]) {
      videos[id][key]();
    } else {
      console.error(msg, id);
    }
  },
};
