import moduleHelper from './module-helper';

const audios = {};

const msg = 'InnerAudioContext does not exist!';
const localAudioMap = {};
const downloadingAudioMap = {};
const soundVolumeHandler = {};
const err = function (msg) { GameGlobal.manager.printErr(msg); };
const funs = {
  getFullUrl(v) {
    if (!/^https?:\/\//.test(v)) {
      const cdnPath = GameGlobal.manager.assetPath;
      v = `${cdnPath.replace(/\/$/, '')}/${v.replace(/^\//, '').replace(/^Assets\//, '')}`;
    }
    return encodeURI(v);
  },
  downloadMusic(src) {
    return new Promise((resolve, reject) => {
      wx.downloadFile({
        url: src,
        success(res) {
          if (res.statusCode === 200 && res.tempFilePath) {
            localAudioMap[src] = res.tempFilePath;
            wx.setStorage({
              key: src,
              data: res.tempFilePath,
            }).catch((e) => {});
            resolve(true);
          } else {
            resolve(false);
          }
        },
        fail(e) {
          resolve(false);
          err(e);
        },
      });
    });
  },
  checkLocalFile(src) {
    return new Promise(async (resolve, reject) => {
      let path = localAudioMap[src];
      if (!path) {
        try {
          const res = await new Promise((subResolve, subReject) => {
            wx.getStorage({
              key: src,
              success: (r) => {
                subResolve(r);
              },
              fail: (e) => {
                subReject(e);
              },
            });
          });
          path = res.data;
          localAudioMap[src] = path;
        } catch (e) {}
      }
      if (!path) {
        return resolve(false);
      }
      const fs = wx.getFileSystemManager();
      fs.access({
        path,
        success() {
          // 文件存在
          resolve(true);
        },
        fail() {
          // 文件不存在或其他错误
          resolve(false);
        },
      });
    });
  },
  handleDownloadEnd(src, succeeded) {
    if (!downloadingAudioMap[src]) {
      return;
    }
    while (downloadingAudioMap[src] && downloadingAudioMap[src].length > 0) {
      const item = downloadingAudioMap[src].shift();
      if (!succeeded) {
        item.reject();
      } else {
        item.resolve();
      }
    }
    downloadingAudioMap[src] = null;
  },
};

const WEBAudio = {
  audioInstanceIdCounter: 0,
  audioInstances: {},
  audioContext: null,
  audioWebEnabled: 0,
  audioCache: [],
  lOrientation: {
    x: 0, y: 0, z: 0, xUp: 0, yUp: 0, zUp: 0,
  },
  lPosition: { x: 0, y: 0, z: 0 },
};
export default {
  WXCreateInnerAudioContext(src, loop, startTime, autoplay, volume, playbackRate, needDownload) {
    const id = new Date().getTime().toString(32) + Math.random().toString(32);
    audios[id] = wx.createInnerAudioContext();
    playbackRate = 1; // 先强制为1，android客户端有bug，设为其他值的话
    audios[id]._needDownload = needDownload;
    audios[id]._src = src;
    if (src) {
      src = funs.getFullUrl(src);
      funs.checkLocalFile(src).then((exist) => {
        if (exist) {
          audios[id].src = localAudioMap[src];
          funs.handleDownloadEnd(src, true);
        } else if (needDownload) {
          const successFun = function () {
            audios[id].src = localAudioMap[src];
          };
          const failFun = function () {
            moduleHelper.send('OnAudioCallback', JSON.stringify({
              callbackId: id,
              errMsg: 'onError',
            }));
          };
          if (!downloadingAudioMap[src]) {
            downloadingAudioMap[src] = [];
          }
          downloadingAudioMap[src].unshift({
            resolve: successFun, reject: failFun,
          });
          if (!downloadingAudioMap[src].isDownloading) {
            downloadingAudioMap[src].isDownloading = true;
            funs.downloadMusic(src).then((succeeded) => {
              funs.handleDownloadEnd(src, succeeded);
            });
          }
        } else {
          audios[id].src = src;
        }
      });
    }

    if (loop) {
      audios[id].loop = true;
    }
    if (autoplay) {
      audios[id].autoplay = true;
    }
    if (startTime > 0) {
      audios[id].startTime = +startTime.toFixed(2);
    }
    if (volume !== 1) {
      audios[id].volume = +volume.toFixed(2);
    }
    if (playbackRate !== 1) {
      audios[id].playbackRate = +playbackRate.toFixed(2);
    }
    return id;
  },
  WXInnerAudioContextSetBool(id, k, v) {
    if (audios[id]) {
      audios[id][k] = Boolean(+v);
    } else {
      console.error(msg, id);
    }
  },
  WXInnerAudioContextSetString(id, k, v) {
    if (audios[id]) {
      if (k === 'src') {
        v = funs.getFullUrl(v);
        if (localAudioMap[v]) {
          v = localAudioMap[v];
        }
      }
      audios[id][k] = v;
    } else {
      console.error(msg, id);
    }
  },
  WXInnerAudioContextSetFloat(id, k, v) {
    if (audios[id]) {
      audios[id][k] = +v.toFixed(2);
    } else {
      console.error(msg, id);
    }
  },
  WXInnerAudioContextGetFloat(id, k) {
    if (audios[id]) {
      return audios[id][k];
    }
    console.error(msg, id);
    return 0;
  },
  WXInnerAudioContextGetBool(id, k) {
    if (audios[id]) {
      return audios[id][k];
    }
    console.error(msg, id);
    return false;
  },
  WXInnerAudioContextPlay(id) {
    if (audios[id]) {
      audios[id].play();
    } else {
      console.error(msg, id);
    }
  },
  WXInnerAudioContextPause(id) {
    if (audios[id]) {
      audios[id].pause();
    } else {
      console.error(msg, id);
    }
  },
  WXInnerAudioContextStop(id) {
    if (audios[id]) {
      audios[id].stop();
    } else {
      console.error(msg, id);
    }
  },
  WXInnerAudioContextDestroy(id) {
    if (audios[id]) {
      audios[id].destroy();
      delete audios[id];
    } else {
      console.error(msg, id);
    }
  },
  WXInnerAudioContextSeek(id, position) {
    if (audios[id]) {
      audios[id].seek(+position.toFixed(3));
    } else {
      console.error(msg, id);
    }
  },
  WXInnerAudioContextAddListener(id, key) {
    if (audios[id]) {
      function AddListener() {
        if (key === 'onCanplay') {
          audios[id][key]((e) => {
            // 兼容基础库获取属性异常的bug
            const { duration, buffered, referrerPolicy } = audios[id];
            setTimeout(() => {
              moduleHelper.send('OnAudioCallback', JSON.stringify({
                callbackId: id,
                errMsg: key,
              }));
            }, 0);
          });
        } else {
          audios[id][key]((e) => {
            moduleHelper.send('OnAudioCallback', JSON.stringify({
              callbackId: id,
              errMsg: key,
            }));
            if (key === 'onError') {
              console.error(e);
            }
          });
        }
      }

      if (!audios[id].src && audios[id]._needDownload && audios[id]._src) {
        const src = funs.getFullUrl(audios[id]._src);
        if (!downloadingAudioMap[src]) {
          downloadingAudioMap[src] = [];
        }
        downloadingAudioMap[src].push({
          resolve: AddListener,
          reject: () => {},
        });
      } else {
        AddListener();
      }
    } else {
      console.error(msg, id);
    }
  },
  WXInnerAudioContextRemoveListener(id, key) {
    if (audios[id]) {
      audios[id][key]();
    } else {
      console.error(msg, id);
    }
  },
  WXPreDownloadAudios(paths, id) {
    const list = paths.split(',');
    Promise.all(list.map((v) => {
      const src = funs.getFullUrl(v);
      return new Promise(async (resolve, reject) => {
        if (!downloadingAudioMap[src]) {
          downloadingAudioMap[src] = [{
            resolve, reject,
          }];
          const exist = await funs.checkLocalFile(src);
          if (exist) {
            funs.handleDownloadEnd(src, true);
            return;
          }
          const succeeded = await funs.downloadMusic(src);
          funs.handleDownloadEnd(src, succeeded);
        } else {
          downloadingAudioMap[src].push({
            resolve, reject,
          });
        }
      });
    })).then(() => {
      moduleHelper.send('WXPreDownloadAudiosCallback', JSON.stringify({
        callbackId: id.toString(),
        errMsg: '0',
      }));
    }).catch((e) => {
      moduleHelper.send('WXPreDownloadAudiosCallback', JSON.stringify({
        callbackId: id.toString(),
        errMsg: '1',
      }));
    });
  },
  // -------------------Unity Audio适配--------------------
  _JS_Sound_Create_Channel(callback, userData) {
    if (WEBAudio.audioWebEnabled == 0) return;
    var channel = {
      gain: WEBAudio.audioContext.createGain(),
      panner: WEBAudio.audioContext.createPanner(),
      threeD: false,
      playUrl(startTime, url, startOffset) {
        try {
          this.setup(url);
          const chan = this;
          this.source.onended = function () {
            chan.disconnectSource();
            if (callback) GameGlobal.unityNamespace.Module.dynCall_vi(callback, [userData]);
          };
          this.source.start(startTime, startOffset);
          this.source.playbackStartTime = startTime - startOffset / this.source.playbackRate.value;
        } catch (e) {
          err(`playUrl error. Exception: ${e}`);
        }
      },
      playBuffer(startTime, buffer, startOffset) {
        try {
          this.setup();
          this.source.buffer = buffer;
          const chan = this;
          this.source.onended = function () {
            chan.disconnectSource();
            if (callback) GameGlobal.unityNamespace.Module.dynCall_vi(callback, [userData]);
          };
          this.source.start(startTime, startOffset);
          this.source.playbackStartTime = startTime - startOffset / this.source.playbackRate.value;
        } catch (e) {
          err(`playUrl error. Exception: ${e}`);
        }
      },
      disconnectSource() {
        if (this.source && !this.source.isPausedMockNode) {
          this.source.onended = null;
          this.source.disconnect();
          if (this.source.mediaElement) {
            const url = this.source.mediaElement.src;
            this.source.mediaElement.pause();
            this.source.mediaElement.src = '';
            delete this.source.mediaElement;
            URL.revokeObjectURL(url);
          }
          delete this.source;
        }
      },
      stop(delay) {
        if (channel.source && channel.source.buffer) {
          try {
            channel.source.stop(WEBAudio.audioContext.currentTime + delay);
          } catch (e) {}
          if (delay == 0) {
            channel.disconnectSource();
          }
        }
      },
      pause() {
        const s = this.source;
        if (!s) return;
        if (s.mediaElement) {
          this.pauseMediaElement();
          return;
        }
        const pausedSource = {
          isPausedMockNode: true,
          loop: s.loop,
          loopStart: s.loopStart,
          loopEnd: s.loopEnd,
          buffer: s.buffer,
          url: s.mediaElement ? s.mediaElement.src : null,
          playbackRate: s.playbackRate.value,
          playbackPausedAtPosition: s.estimatePlaybackPosition(),
          setPitch(v) {
            this.playbackRate = v;
          },
        };
        this.stop(0);
        this.disconnectSource();
        this.source = pausedSource;
      },
      resume() {
        const pausedSource = this.source;
        if (pausedSource && pausedSource.mediaElement) {
          pausedSource.start();
          return;
        }
        if (!pausedSource || !pausedSource.isPausedMockNode) return;
        delete this.source;
        if (pausedSource.url) {
          this.playUrl(
            WEBAudio.audioContext.currentTime
                      - Math.min(0, pausedSource.playbackPausedAtPosition),
            pausedSource.url,
            Math.max(0, pausedSource.playbackPausedAtPosition),
          );
        } else {
          this.playBuffer(
            WEBAudio.audioContext.currentTime
                      - Math.min(0, pausedSource.playbackPausedAtPosition),
            pausedSource.buffer,
            Math.max(0, pausedSource.playbackPausedAtPosition),
          );
        }
        this.source.loop = pausedSource.loop;
        this.source.loopStart = pausedSource.loopStart;
        this.source.loopEnd = pausedSource.loopEnd;
        this.source.setPitch(pausedSource.playbackRate);
      },
      setup(url) {
        if (this.source && !this.source.isPausedMockNode) return;
        if (!url) {
          this.source = WEBAudio.audioContext.createBufferSource();
        } else {
          this.mediaElement = WEBAudio.audioCache.length
            ? WEBAudio.audioCache.pop()
            : new Audio();
          this.mediaElement.preload = 'metadata';
          this.mediaElement.src = url;
          this.source = WEBAudio.audioContext.createMediaElementSource(
            this.mediaElement,
          );
          this.source.playbackRate = {};
          const { source } = this;
          Object.defineProperty(this.source, 'loop', {
            get() {
              return source.mediaElement.loop;
            },
            set(v) {
              source.mediaElement.loop = v;
            },
          });
          Object.defineProperty(this.source.playbackRate, 'value', {
            get() {
              return source.mediaElement.playbackRate;
            },
            set(v) {
              source.mediaElement.playbackRate = v;
            },
          });
          Object.defineProperty(this.source, 'currentTime', {
            get() {
              return source.mediaElement.currentTime;
            },
            set(v) {
              source.mediaElement.currentTime = v;
            },
          });
          Object.defineProperty(this.source, 'mute', {
            get() {
              return source.mediaElement.mute;
            },
            set(v) {
              source.mediaElement.mute = v;
            },
          });
          const self = this;
          this.playPromise = null;
          this.pauseRequested = false;
          this.pauseMediaElement = function () {
            if (self.playPromise) {
              self.pauseRequested = true;
            } else {
              source.mediaElement.pause();
            }
          };
          const _startPlayback = function (offset) {
            if (self.playPromise) {
              self.pauseRequested = false;
              return;
            }
            source.mediaElement.currentTime = offset;
            self.playPromise = source.mediaElement.play();
            if (self.playPromise) {
              self.playPromise.then(() => {
                if (self.pauseRequested) {
                  source.mediaElement.pause();
                  self.pauseRequested = false;
                }
                self.playPromise = null;
              });
            }
          };
          this.source.start = function (startTime, offset) {
            const startDelayThresholdMS = 4;
            const startDelayMS = (startTime - WEBAudio.audioContext.currentTime) * 1e3;
            if (startDelayMS > startDelayThresholdMS) {
              setTimeout(() => {
                _startPlayback(offset);
              }, startDelayMS);
            } else {
              _startPlayback(offset);
            }
          };
          this.source.stop = function () {
            self.pauseMediaElement();
          };
        }
        this.source.estimatePlaybackPosition = function () {
          let t = (WEBAudio.audioContext.currentTime - this.playbackStartTime)
                      * this.playbackRate.value;
          if (this.loop && t >= this.loopStart) {
            t = ((t - this.loopStart) % (this.loopEnd - this.loopStart))
                          + this.loopStart;
          }
          return t;
        };
        this.source.setPitch = function (newPitch) {
          const curPosition = this.estimatePlaybackPosition();
          if (curPosition >= 0) {
            this.playbackStartTime = WEBAudio.audioContext.currentTime - curPosition / newPitch;
          }
          this.playbackRate.value = newPitch;
        };
        this.setupPanning();
      },
      setupPanning() {
        if (this.source.isPausedMockNode) return;
        this.source.disconnect();
        if (this.threeD) {
          this.source.connect(this.panner);
          this.panner.connect(this.gain);
        } else {
          this.panner.disconnect();
          this.source.connect(this.gain);
        }
      },
    };
    channel.panner.rolloffFactor = 0;
    channel.gain.connect(WEBAudio.audioContext.destination);
    WEBAudio.audioInstances[++WEBAudio.audioInstanceIdCounter] = channel;
    return WEBAudio.audioInstanceIdCounter;
  },
  _JS_Sound_GetLength(bufferInstance) {
    if (WEBAudio.audioWebEnabled == 0) return 0;
    const sound = WEBAudio.audioInstances[bufferInstance];
    if (sound.buffer) {
      const sampleRateRatio = 44100 / sound.buffer.sampleRate;
      return sound.buffer.length * sampleRateRatio;
    }
    return sound.mediaElement.duration * 44100;
  },
  _JS_Sound_GetLoadState(bufferInstance) {
    if (WEBAudio.audioWebEnabled == 0) return 2;
    const sound = WEBAudio.audioInstances[bufferInstance];
    if (sound.error) return 2;
    if (sound.buffer || sound.url) return 0;
    return 1;
  },
  _JS_Sound_Init() {
    try {
      window.AudioContext = window.AudioContext || window.webkitAudioContext;
      if (window.AudioContext) {
        WEBAudio.audioContext = new AudioContext();
      }
      if (wx && wx.createWebAudioContext) {
        WEBAudio.audioContext = wx.createWebAudioContext();
        console.log('use wx WebAudio');
      }
      if (!WEBAudio.audioContext) {
        err('Minigame Web Audio API not suppoted');
        return;
      }
      const tryToResumeAudioContext = function () {
        if (WEBAudio.audioContext.state === 'suspended') {
          WEBAudio.audioContext.resume();
        } else clearInterval(resumeInterval);
      };
      // var resumeInterval =  setInterval(tryToResumeAudioContext, 400);
      WEBAudio.audioWebEnabled = 1;
      wx.onHide((result) => { WEBAudio.audioContext.suspend(); });
      wx.onShow((result) => { WEBAudio.audioContext.resume(); });
    } catch (e) {
      err('Web Audio API is not supported in this browser');
    }
  },
  _JS_Sound_Load(ptr, length, decompress) {
    if (WEBAudio.audioWebEnabled == 0) return 0;
    const sound = {
      buffer: null,
      error: false,
    };
    WEBAudio.audioInstances[++WEBAudio.audioInstanceIdCounter] = sound;
    const audioData = GameGlobal.unityNamespace.Module.HEAPU8.buffer.slice(ptr, ptr + length);
    WEBAudio.audioContext.decodeAudioData(
      audioData,
      (buffer) => {
        sound.buffer = buffer;
      },
      (error) => {
        sound.error = true;
        console.log(`Decode error: ${error}`);
      },
    );
    return WEBAudio.audioInstanceIdCounter;
  },
  _JS_Sound_Load_PCM(channels, length, sampleRate, ptr) {
    if (WEBAudio.audioWebEnabled == 0) return 0;
    const sound = {
      buffer: WEBAudio.audioContext.createBuffer(channels, length, sampleRate),
      error: false,
    };
    for (let i = 0; i < channels; i++) {
      const offs = (ptr >> 2) + length * i;
      const { buffer } = sound;
      const copyToChannel = buffer.copyToChannel
              || function (source, channelNumber, startInChannel) {
                const clipped = source.subarray(
                  0,
                  Math.min(source.length, this.length - (startInChannel | 0)),
                );
                this.getChannelData(channelNumber | 0).set(clipped, startInChannel | 0);
              };
      copyToChannel.apply(buffer, [GameGlobal.unityNamespace.Module.HEAPF32.subarray(offs, offs + length), i, 0]);
    }
    WEBAudio.audioInstances[++WEBAudio.audioInstanceIdCounter] = sound;
    return WEBAudio.audioInstanceIdCounter;
  },
  _JS_Sound_Play(bufferInstance, channelInstance, offset, delay) {
    WXWASMSDK._JS_Sound_Stop(channelInstance, 0);
    if (WEBAudio.audioWebEnabled == 0) return;
    const sound = WEBAudio.audioInstances[bufferInstance];
    const channel = WEBAudio.audioInstances[channelInstance];
    if (sound.url) {
      try {
        channel.playUrl(
          WEBAudio.audioContext.currentTime + delay,
          sound.url,
          offset,
        );
      } catch (e) {
        err(`playUrl error. Exception: ${e}`);
      }
    } else if (sound.buffer) {
      try {
        channel.playBuffer(
          WEBAudio.audioContext.currentTime + delay,
          sound.buffer,
          offset,
        );
      } catch (e) {
        err(`playBuffer error. Exception: ${e}`);
      }
    } else console.log('Trying to play sound which is not loaded.');
  },
  _JS_Sound_ReleaseInstance(instance) {
    delete WEBAudio.audioInstances[instance];
  },
  _JS_Sound_ResumeIfNeeded() {
    if (WEBAudio.audioWebEnabled == 0) return;
    if (WEBAudio.audioContext.state === 'suspended') { WEBAudio.audioContext.resume(); }
  },
  _JS_Sound_Set3D(channelInstance, threeD) {
    const channel = WEBAudio.audioInstances[channelInstance];
    if (channel.threeD != threeD) {
      channel.threeD = threeD;
      if (!channel.source) {
        channel.setup();
      }
      channel.setupPanning();
    }
  },
  _JS_Sound_SetListenerOrientation(x, y, z, xUp, yUp, zUp) {
    if (WEBAudio.audioWebEnabled == 0) return;
    x = x > 0 ? 0 : x;
    y = y > 0 ? 0 : y;
    z = z > 0 ? 0 : z;
    xUp = xUp < 0 ? 0 : xUp;
    yUp = yUp < 0 ? 0 : yUp;
    zUp = zUp < 0 ? 0 : zUp;
    if (x == WEBAudio.lOrientation.x && y == WEBAudio.lOrientation.y && z == WEBAudio.lOrientation.z && xUp == WEBAudio.lOrientation.xUp && yUp == WEBAudio.lOrientation.yUp && zUp == WEBAudio.lOrientation.zUp) { return; }
    WEBAudio.lOrientation.x = x;
    WEBAudio.lOrientation.y = y;
    WEBAudio.lOrientation.z = z;
    WEBAudio.lOrientation.xUp = xUp;
    WEBAudio.lOrientation.yUp = yUp;
    WEBAudio.lOrientation.zUp = zUp;
    if (WEBAudio.audioContext.listener.forwardX) {
      WEBAudio.audioContext.listener.forwardX.setValueAtTime(
        -x,
        WEBAudio.audioContext.currentTime,
      );
      WEBAudio.audioContext.listener.forwardY.setValueAtTime(
        -y,
        WEBAudio.audioContext.currentTime,
      );
      WEBAudio.audioContext.listener.forwardZ.setValueAtTime(
        -z,
        WEBAudio.audioContext.currentTime,
      );
      WEBAudio.audioContext.listener.upX.setValueAtTime(
        xUp,
        WEBAudio.audioContext.currentTime,
      );
      WEBAudio.audioContext.listener.upY.setValueAtTime(
        yUp,
        WEBAudio.audioContext.currentTime,
      );
      WEBAudio.audioContext.listener.upZ.setValueAtTime(
        zUp,
        WEBAudio.audioContext.currentTime,
      );
    } else {
      WEBAudio.audioContext.listener.setOrientation(-x, -y, -z, xUp, yUp, zUp);
    }
  },
  _JS_Sound_SetListenerPosition(x, y, z) {
    if (WEBAudio.audioWebEnabled == 0) return;
    x = x < 0 ? 0 : x;
    y = y < 0 ? 0 : y;
    z = z < 0 ? 0 : z;
    if (x == WEBAudio.lPosition.x && y == WEBAudio.lPosition.y && z == WEBAudio.lPosition.z) { return; }
    WEBAudio.lPosition.x = x;
    WEBAudio.lPosition.y = y;
    WEBAudio.lPosition.z = z;
    if (WEBAudio.audioContext.listener.positionX) {
      WEBAudio.audioContext.listener.positionX.setValueAtTime(
        x,
        WEBAudio.audioContext.currentTime,
      );
      WEBAudio.audioContext.listener.positionY.setValueAtTime(
        y,
        WEBAudio.audioContext.currentTime,
      );
      WEBAudio.audioContext.listener.positionZ.setValueAtTime(
        z,
        WEBAudio.audioContext.currentTime,
      );
    } else {
      WEBAudio.audioContext.listener.setPosition(x, y, z);
    }
  },
  _JS_Sound_SetLoop(channelInstance, loop) {
    if (WEBAudio.audioWebEnabled == 0) return;
    const channel = WEBAudio.audioInstances[channelInstance];
    if (!channel.source) {
      channel.setup();
    }
    channel.source.loop = loop > 0;
  },
  _JS_Sound_SetLoopPoints(channelInstance, loopStart, loopEnd) {
    if (WEBAudio.audioWebEnabled == 0) return;
    const channel = WEBAudio.audioInstances[channelInstance];
    if (!channel.source) {
      channel.setup();
    }
    channel.source.loopStart = loopStart;
    channel.source.loopEnd = loopEnd;
  },
  _JS_Sound_SetPaused(channelInstance, paused) {
    if (WEBAudio.audioWebEnabled == 0) return;
    const channel = WEBAudio.audioInstances[channelInstance];
    const channelCurrentlyPaused = !channel.source || channel.source.isPausedMockNode;
    if (paused != channelCurrentlyPaused) {
      if (paused) channel.pause();
      else channel.resume();
    }
  },
  _JS_Sound_SetPitch(channelInstance, v) {
    if (WEBAudio.audioWebEnabled == 0) return;
    try {
      WEBAudio.audioInstances[channelInstance].source.setPitch(v);
    } catch (e) {
      err(`Invalid audio pitch ${v} specified to WebAudio backend!`);
    }
  },
  _JS_Sound_SetPosition(channelInstance, x, y, z) {
    if (WEBAudio.audioWebEnabled == 0) return;
    const channel = WEBAudio.audioInstances[channelInstance];
    if (channel.x != x || channel.y != y || channel.z != z) {
      channel.panner.setPosition(x, y, z);
      channel.x = x;
      channel.y = y;
      channel.z = z;
    }
  },

  _JS_Sound_SetVolume(channelInstance, v) {
    if (WEBAudio.audioWebEnabled == 0) return;
    try {
      const volume = Number(v.toFixed(2));
      if (soundVolumeHandler[channelInstance] === volume) { return; }
      soundVolumeHandler[channelInstance] = volume;
      WEBAudio.audioInstances[channelInstance].gain.gain.setValueAtTime(
        volume,
        WEBAudio.audioContext.currentTime,
      );
    } catch (e) {
      err(`Invalid audio volume ${v} specified to WebAudio backend!`);
    }
  },
  _JS_Sound_Stop(channelInstance, delay) {
    if (WEBAudio.audioWebEnabled == 0) return;
    const channel = WEBAudio.audioInstances[channelInstance];
    channel.stop(delay);
  },


};

// 声音被打断后自动帮用户恢复
const HandleInterruption = {
  init() {
    let InterruptList = {};
    wx.onHide(() => {
      for (const key in audios) {
        if (!audios[key].paused) {
          InterruptList[key] = true;
        }
      }
    });
    wx.onShow(() => {
      for (const key in audios) {
        if (audios[key].paused && InterruptList[key]) {
          audios[key].play();
        }
      }
      InterruptList = {};
    });
    wx.onAudioInterruptionBegin(() => {
      for (const key in audios) {
        if (!audios[key].paused) {
          InterruptList[key] = true;
        }
      }
    });
    wx.onAudioInterruptionEnd(() => {
      for (const key in audios) {
        if (audios[key].paused && InterruptList[key]) {
          audios[key].play();
        }
      }
      InterruptList = {};
    });
  },
};

HandleInterruption.init();
