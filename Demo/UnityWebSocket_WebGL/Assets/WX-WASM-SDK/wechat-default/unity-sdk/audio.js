const audios = {};
import moduleHelper from "./module-helper";
const msg = 'InnerAudioContext does not exist!';
const localAudioMap = {};
const soundVolumeHandler = {};
const err = function(msg){GameGlobal.manager.printErr(msg)}
const funs = {
    getFullUrl(v) {
        if (!/^https?:\/\//.test(v)) {
            const cdnPath = GameGlobal.manager.assetPath;
            v = cdnPath.replace(/\/$/, '') + '/' + v.replace(/^\//, '').replace(/^Assets\//, '');
        }
        return encodeURI(v);
    }
};

var WEBAudio = {
    audioInstanceIdCounter: 0,
    audioInstances: {},
    audioContext: null,
    audioWebEnabled: 0,
    audioCache: [],
    lOrientation: {x:0, y:0, z:0, xUp:0, yUp:0, zUp:0},
    lPosition: {x:0, y:0, z:0}
};
export default {
    WXCreateInnerAudioContext(src, loop, startTime, autoplay, volume, playbackRate, needDownload) {
        const id = new Date().getTime().toString(32) + Math.random().toString(32);
        audios[id] = wx.createInnerAudioContext();
        if (src) {
            src = funs.getFullUrl(src);
            if (localAudioMap[src]) {
                audios[id].src = localAudioMap[src];
            } else if (needDownload) {
                wx.downloadFile({
                    url: src,
                    success(res) {
                        // 只要服务器有响应数据，就会把响应内容写入文件并进入 success 回调，业务需要自行判断是否下载到了想要的内容
                        if (res.statusCode === 200 && res.tempFilePath) {
                            localAudioMap[src] = res.tempFilePath;
                            audios[id].src = localAudioMap[src];
                        } else {
                            moduleHelper.send('OnAudioCallback', JSON.stringify({
                                callbackId: id,
                                errMsg: "onError"
                            }));
                        }
                    },
                    error(e) {
                        moduleHelper.send('OnAudioCallback', JSON.stringify({
                            callbackId: id,
                            errMsg: "onError"
                        }));
                        console.error(e);
                    }
                });
            } else {
                audios[id].src = src;
            }
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
        } else {
            console.error(msg, id);
            return 0;
        }
    },
    WXInnerAudioContextGetBool(id, k) {
        if (audios[id]) {
            return audios[id][k];
        } else {
            console.error(msg, id);
            return false;
        }
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
            audios[id][key](function (e) {
                moduleHelper.send('OnAudioCallback', JSON.stringify({
                    callbackId: id,
                    errMsg: key
                }));
                if (key === 'onError') {
                    console.error(e);
                }
            });
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
        var list = paths.split(',');
        Promise.all(list.map(v => {
            var src = funs.getFullUrl(v);
            return new Promise((resolve, reject) => {
                if (localAudioMap[src]) {
                    resolve();
                }
                wx.downloadFile({
                    url: funs.getFullUrl(src),
                    success(res) {
                        if (res.statusCode === 200 && res.tempFilePath) {
                            localAudioMap[src] = res.tempFilePath;
                            resolve();
                        } else {
                            reject();
                        }
                    },
                    error(e) {
                        reject(e);
                        console.error(e);
                    }
                });
            })
        })).then(() => {
            moduleHelper.send('WXPreDownloadAudiosCallback', JSON.stringify({
                callbackId: id.toString(),
                errMsg: "0"
            }));
        }).catch(e => {
            moduleHelper.send('WXPreDownloadAudiosCallback', JSON.stringify({
                callbackId: id.toString(),
                errMsg: "1"
            }));
        })

    },
    //-------------------Unity Audio适配--------------------
    _JS_Sound_Create_Channel(callback, userData) {
        if (WEBAudio.audioWebEnabled == 0) return;
        var channel = {
            gain: WEBAudio.audioContext.createGain(),
            panner: WEBAudio.audioContext.createPanner(),
            threeD: false,
            playUrl: function (startTime, url, startOffset) {
                try {
                    this.setup(url);
                    var chan = this;
                    this.source.onended = function () {
                        chan.disconnectSource();
                        if (callback) GameGlobal.unityNamespace.Module.dynCall_vi(callback, [userData]);
                    };
                    this.source.start(startTime, startOffset);
                    this.source.playbackStartTime =
                        startTime - startOffset / this.source.playbackRate.value;
                } catch (e) {
                    err("playUrl error. Exception: " + e);
                }
            },
            playBuffer: function (startTime, buffer, startOffset) {
                try {
                    this.setup();
                    this.source.buffer = buffer;
                    var chan = this;
                    this.source.onended = function () {
                        chan.disconnectSource();
                        if (callback) GameGlobal.unityNamespace.Module.dynCall_vi(callback, [userData]);
                    };
                    this.source.start(startTime, startOffset);
                    this.source.playbackStartTime =
                        startTime - startOffset / this.source.playbackRate.value;
                } catch (e) {
                    err("playUrl error. Exception: " + e);
                }
            },
            disconnectSource: function () {
                if (this.source && !this.source.isPausedMockNode) {
                    this.source.onended = null;
                    this.source.disconnect();
                    if (this.source.mediaElement) {
                        var url = this.source.mediaElement.src;
                        this.source.mediaElement.pause();
                        this.source.mediaElement.src = "";
                        delete this.source.mediaElement;
                        URL.revokeObjectURL(url);
                    }
                    delete this.source;
                }
            },
            stop: function (delay) {
                if (channel.source && channel.source.buffer) {
                    try {
                        channel.source.stop(WEBAudio.audioContext.currentTime + delay);
                    } catch (e) {}
                    if (delay == 0) {
                        channel.disconnectSource();
                    }
                }
            },
            pause: function () {
                var s = this.source;
                if (!s) return;
                if (s.mediaElement) {
                    this.pauseMediaElement();
                    return;
                }
                var pausedSource = {
                    isPausedMockNode: true,
                    loop: s.loop,
                    loopStart: s.loopStart,
                    loopEnd: s.loopEnd,
                    buffer: s.buffer,
                    url: s.mediaElement ? s.mediaElement.src : null,
                    playbackRate: s.playbackRate.value,
                    playbackPausedAtPosition: s.estimatePlaybackPosition(),
                    setPitch: function (v) {
                        this.playbackRate = v;
                    },
                };
                this.stop(0);
                this.disconnectSource();
                this.source = pausedSource;
            },
            resume: function () {
                var pausedSource = this.source;
                if (pausedSource && pausedSource.mediaElement) {
                    pausedSource.start();
                    return;
                }
                if (!pausedSource || !pausedSource.isPausedMockNode) return;
                delete this.source;
                if (pausedSource.url) {
                    this.playUrl(
                        WEBAudio.audioContext.currentTime -
                        Math.min(0, pausedSource.playbackPausedAtPosition),
                        pausedSource.url,
                        Math.max(0, pausedSource.playbackPausedAtPosition)
                    );
                } else {
                    this.playBuffer(
                        WEBAudio.audioContext.currentTime -
                        Math.min(0, pausedSource.playbackPausedAtPosition),
                        pausedSource.buffer,
                        Math.max(0, pausedSource.playbackPausedAtPosition)
                    );
                }
                this.source.loop = pausedSource.loop;
                this.source.loopStart = pausedSource.loopStart;
                this.source.loopEnd = pausedSource.loopEnd;
                this.source.setPitch(pausedSource.playbackRate);
            },
            setup: function (url) {
                if (this.source && !this.source.isPausedMockNode) return;
                if (!url) {
                    this.source = WEBAudio.audioContext.createBufferSource();
                } else {
                    this.mediaElement = WEBAudio.audioCache.length ?
                        WEBAudio.audioCache.pop() :
                        new Audio();
                    this.mediaElement.preload = "metadata";
                    this.mediaElement.src = url;
                    this.source = WEBAudio.audioContext.createMediaElementSource(
                        this.mediaElement
                    );
                    this.source.playbackRate = {};
                    var source = this.source;
                    Object.defineProperty(this.source, "loop", {
                        get: function () {
                            return source.mediaElement.loop;
                        },
                        set: function (v) {
                            source.mediaElement.loop = v;
                        },
                    });
                    Object.defineProperty(this.source.playbackRate, "value", {
                        get: function () {
                            return source.mediaElement.playbackRate;
                        },
                        set: function (v) {
                            source.mediaElement.playbackRate = v;
                        },
                    });
                    Object.defineProperty(this.source, "currentTime", {
                        get: function () {
                            return source.mediaElement.currentTime;
                        },
                        set: function (v) {
                            source.mediaElement.currentTime = v;
                        },
                    });
                    Object.defineProperty(this.source, "mute", {
                        get: function () {
                            return source.mediaElement.mute;
                        },
                        set: function (v) {
                            source.mediaElement.mute = v;
                        },
                    });
                    var self = this;
                    this.playPromise = null;
                    this.pauseRequested = false;
                    this.pauseMediaElement = function () {
                        if (self.playPromise) {
                            self.pauseRequested = true;
                        } else {
                            source.mediaElement.pause();
                        }
                    };
                    var _startPlayback = function (offset) {
                        if (self.playPromise) {
                            self.pauseRequested = false;
                            return;
                        }
                        source.mediaElement.currentTime = offset;
                        self.playPromise = source.mediaElement.play();
                        if (self.playPromise) {
                            self.playPromise.then(function () {
                                if (self.pauseRequested) {
                                    source.mediaElement.pause();
                                    self.pauseRequested = false;
                                }
                                self.playPromise = null;
                            });
                        }
                    };
                    this.source.start = function (startTime, offset) {
                        var startDelayThresholdMS = 4;
                        var startDelayMS =
                            (startTime - WEBAudio.audioContext.currentTime) * 1e3;
                        if (startDelayMS > startDelayThresholdMS) {
                            setTimeout(function () {
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
                    var t =
                        (WEBAudio.audioContext.currentTime - this.playbackStartTime) *
                        this.playbackRate.value;
                    if (this.loop && t >= this.loopStart) {
                        t =
                            ((t - this.loopStart) % (this.loopEnd - this.loopStart)) +
                            this.loopStart;
                    }
                    return t;
                };
                this.source.setPitch = function (newPitch) {
                    var curPosition = this.estimatePlaybackPosition();
                    if (curPosition >= 0) {
                        this.playbackStartTime =
                            WEBAudio.audioContext.currentTime - curPosition / newPitch;
                    }
                    this.playbackRate.value = newPitch;
                };
                this.setupPanning();
            },
            setupPanning: function () {
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
        var sound = WEBAudio.audioInstances[bufferInstance];
        if (sound.buffer) {
            var sampleRateRatio = 44100 / sound.buffer.sampleRate;
            return sound.buffer.length * sampleRateRatio;
        }
        return sound.mediaElement.duration * 44100;
    },
    _JS_Sound_GetLoadState(bufferInstance) {
        if (WEBAudio.audioWebEnabled == 0) return 2;
        var sound = WEBAudio.audioInstances[bufferInstance];
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
                console.log("use wx WebAudio");
            } 
            if (!WEBAudio.audioContext) {
                err('Minigame Web Audio API not suppoted')
                return
            }
            var tryToResumeAudioContext = function () {
                if (WEBAudio.audioContext.state === "suspended") {
                    WEBAudio.audioContext.resume();
                }
                else clearInterval(resumeInterval);
            };
            // var resumeInterval =  setInterval(tryToResumeAudioContext, 400);
            WEBAudio.audioWebEnabled = 1;
            wx.onShow((result) => {WEBAudio.audioContext.resume()});
        } catch (e) {
            err("Web Audio API is not supported in this browser");
        }
    },
    _JS_Sound_Load(ptr, length, decompress) {
        if (WEBAudio.audioWebEnabled == 0) return 0;
        var sound = {
            buffer: null,
            error: false
        };
        WEBAudio.audioInstances[++WEBAudio.audioInstanceIdCounter] = sound;
        var audioData = GameGlobal.unityNamespace.Module.HEAPU8.buffer.slice(ptr, ptr + length);
        WEBAudio.audioContext.decodeAudioData(
            audioData,
            function (buffer) {
                sound.buffer = buffer;
            },
            function (error) {
                sound.error = true;
                console.log("Decode error: " + error);
            }
        );
        return WEBAudio.audioInstanceIdCounter;
    },
    _JS_Sound_Load_PCM(channels, length, sampleRate, ptr) {
        if (WEBAudio.audioWebEnabled == 0) return 0;
        var sound = {
            buffer: WEBAudio.audioContext.createBuffer(channels, length, sampleRate),
            error: false,
        };
        for (var i = 0; i < channels; i++) {
            var offs = (ptr >> 2) + length * i;
            var buffer = sound.buffer;
            var copyToChannel =
                buffer["copyToChannel"] ||
                function (source, channelNumber, startInChannel) {
                    var clipped = source.subarray(
                        0,
                        Math.min(source.length, this.length - (startInChannel | 0))
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
        var sound = WEBAudio.audioInstances[bufferInstance];
        var channel = WEBAudio.audioInstances[channelInstance];
        if (sound.url) {
            try {
                channel.playUrl(
                    WEBAudio.audioContext.currentTime + delay,
                    sound.url,
                    offset
                );
            } catch (e) {
                err("playUrl error. Exception: " + e);
            }
        } else if (sound.buffer) {
            try {
                channel.playBuffer(
                    WEBAudio.audioContext.currentTime + delay,
                    sound.buffer,
                    offset
                );
            } catch (e) {
                err("playBuffer error. Exception: " + e);
            }
        } else console.log("Trying to play sound which is not loaded.");
    },
    _JS_Sound_ReleaseInstance(instance) {
        delete WEBAudio.audioInstances[instance];
    },
    _JS_Sound_ResumeIfNeeded() {
        if (WEBAudio.audioWebEnabled == 0) return;
        if (WEBAudio.audioContext.state === "suspended")
            WEBAudio.audioContext.resume();
    },
    _JS_Sound_Set3D(channelInstance, threeD) {
        var channel = WEBAudio.audioInstances[channelInstance];
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
        if (x==WEBAudio.lOrientation.x && y==WEBAudio.lOrientation.y && z==WEBAudio.lOrientation.z && xUp==WEBAudio.lOrientation.xUp && yUp==WEBAudio.lOrientation.yUp && zUp==WEBAudio.lOrientation.zUp){return;}
        WEBAudio.lOrientation.x = x;
        WEBAudio.lOrientation.y = y;
        WEBAudio.lOrientation.z = z; 
        WEBAudio.lOrientation.xUp = xUp; 
        WEBAudio.lOrientation.yUp = yUp; 
        WEBAudio.lOrientation.zUp = zUp; 
        if (WEBAudio.audioContext.listener.forwardX) {
            WEBAudio.audioContext.listener.forwardX.setValueAtTime(
                -x,
                WEBAudio.audioContext.currentTime
            );
            WEBAudio.audioContext.listener.forwardY.setValueAtTime(
                -y,
                WEBAudio.audioContext.currentTime
            );
            WEBAudio.audioContext.listener.forwardZ.setValueAtTime(
                -z,
                WEBAudio.audioContext.currentTime
            );
            WEBAudio.audioContext.listener.upX.setValueAtTime(
                xUp,
                WEBAudio.audioContext.currentTime
            );
            WEBAudio.audioContext.listener.upY.setValueAtTime(
                yUp,
                WEBAudio.audioContext.currentTime
            );
            WEBAudio.audioContext.listener.upZ.setValueAtTime(
                zUp,
                WEBAudio.audioContext.currentTime
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
        if (x==WEBAudio.lPosition.x && y==WEBAudio.lPosition.y && z==WEBAudio.lPosition.z){return;}
        WEBAudio.lPosition.x = x;
        WEBAudio.lPosition.y = y;
        WEBAudio.lPosition.z = z;        
        if (WEBAudio.audioContext.listener.positionX) {
            WEBAudio.audioContext.listener.positionX.setValueAtTime(
                x,
                WEBAudio.audioContext.currentTime
            );
            WEBAudio.audioContext.listener.positionY.setValueAtTime(
                y,
                WEBAudio.audioContext.currentTime
            );
            WEBAudio.audioContext.listener.positionZ.setValueAtTime(
                z,
                WEBAudio.audioContext.currentTime
            );
        } else {
            WEBAudio.audioContext.listener.setPosition(x, y, z);
        }
    },
    _JS_Sound_SetLoop(channelInstance, loop) {
        if (WEBAudio.audioWebEnabled == 0) return;
        var channel = WEBAudio.audioInstances[channelInstance];
        if (!channel.source) {
            channel.setup();
        }
        channel.source.loop = loop > 0 ? true : false;
    },
    _JS_Sound_SetLoopPoints(channelInstance, loopStart, loopEnd) {
        if (WEBAudio.audioWebEnabled == 0) return;
        var channel = WEBAudio.audioInstances[channelInstance];
        if (!channel.source) {
            channel.setup();
        }
        channel.source.loopStart = loopStart;
        channel.source.loopEnd = loopEnd;
    },
    _JS_Sound_SetPaused(channelInstance, paused) {
        if (WEBAudio.audioWebEnabled == 0) return;
        var channel = WEBAudio.audioInstances[channelInstance];
        var channelCurrentlyPaused = !channel.source || channel.source.isPausedMockNode;
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
            err("Invalid audio pitch " + v + " specified to WebAudio backend!");
        }
    },
    _JS_Sound_SetPosition(channelInstance, x, y, z) {
        if (WEBAudio.audioWebEnabled == 0) return;
        var channel = WEBAudio.audioInstances[channelInstance];
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
            let volume =  Number(v.toFixed(2));
            if (soundVolumeHandler[channelInstance] === volume) {return;}
            soundVolumeHandler[channelInstance] = volume;            
            WEBAudio.audioInstances[channelInstance].gain.gain.setValueAtTime(
                volume,
                WEBAudio.audioContext.currentTime
            );
        } catch (e) {
            err("Invalid audio volume " + v + " specified to WebAudio backend!");
        }
    },
    _JS_Sound_Stop(channelInstance, delay) {
        if (WEBAudio.audioWebEnabled == 0) return;
        var channel = WEBAudio.audioInstances[channelInstance];
        channel.stop(delay);
    }


}

//声音被打断后自动帮用户恢复
const HandleInterruption = {
    init() {
        var InterruptList = {};
        wx.onHide(function () {
            for (var key in audios) {
                if (!audios[key].paused) {
                    InterruptList[key] = true;
                }
            }
        });
        wx.onShow(function () {
            for (var key in audios) {
                if (audios[key].paused && InterruptList[key]) {
                    audios[key].play();
                }
            }
            InterruptList = {};
        });
        wx.onAudioInterruptionBegin(function () {
            for (var key in audios) {
                if (!audios[key].paused) {
                    InterruptList[key] = true;
                }
            }
        });
        wx.onAudioInterruptionEnd(function () {
            for (var key in audios) {
                if (audios[key].paused && InterruptList[key]) {
                    audios[key].play();
                }
            }
            InterruptList = {};
        });
    }
};

HandleInterruption.init();