import { isAndroid, isPc, webAudioNeedResume, isSupportBufferURL, isSupportPlayBackRate } from '../../check-version';
import { WEBAudio, soundVolumeHandler } from './store';
import { TEMP_DIR_PATH } from './const';
import { createInnerAudio, destroyInnerAudio, printErrMsg, resumeWebAudio } from './utils';

const defaultSoundLength = 441000;
export class AudioChannelInstance {
    gain;
    source;
    threeD = false; 
    callback = 0;
    userData = 0;
    constructor(callback, userData) {
        if (WEBAudio.audioContext) {
            this.gain = WEBAudio.audioContext.createGain();
            if (this.gain) {
                this.gain.connect(WEBAudio.audioContext.destination);
            }
        }
        this.callback = callback;
        this.userData = userData;
    }
    release() {
        this.disconnectSource();
        if (this.gain) {
            this.gain.disconnect();
        }
    }
    playUrl(startTime, url, startOffset, volume, soundClip) {
        try {
            this.setup(url);
            if (!this.source || !this.source.mediaElement) {
                return;
            }
            if (typeof volume !== 'undefined') {
                this.source.mediaElement.volume = volume;
            }
            this.source.mediaElement.onPlay(() => {
                if (typeof this.source !== 'undefined') {
                    this.source.isPlaying = true;
                    if (!this.source.loop && this.source.mediaElement) {
                        const { duration } = this.source.mediaElement;
                        if (duration) {
                            if (this.source.stopTicker) {
                                clearTimeout(this.source.stopTicker);
                                this.source.stopTicker = undefined;
                            }
                            const time = Math.floor(duration * 1000) + 1000;
                            this.source.stopTicker = setTimeout(() => {
                                if (this.source && this.source.mediaElement) {
                                    this.source.mediaElement.stop();
                                }
                            }, time);
                        }
                    }
                }
            });
            this.source.mediaElement.onPause(() => {
                if (typeof this.source !== 'undefined') {
                    this.source.isPlaying = false;
                    if (this.source.stopTicker) {
                        clearTimeout(this.source.stopTicker);
                        this.source.stopTicker = undefined;
                    }
                }
            });
            this.source.mediaElement.onStop(() => {
                if (typeof this.source !== 'undefined') {
                    if (this.source.playAfterStop) {
                        this.source._reset();
                        if (typeof this.source.mediaElement !== 'undefined') {
                            this.source.mediaElement.play();
                        }
                        return;
                    }
                    this.source._reset();
                    this.disconnectSource();
                }
                if (this.callback) {
                    GameGlobal.unityNamespace.Module.dynCall_vi(this.callback, [this.userData]);
                }
            });
            this.source.mediaElement.onEnded(() => {
                if (typeof this.source !== 'undefined') {
                    this.source._reset();
                    this.disconnectSource();
                }
                if (this.callback) {
                    GameGlobal.unityNamespace.Module.dynCall_vi(this.callback, [this.userData]);
                }
            });
            this.source.mediaElement.onError((e) => {
                printErrMsg(e);
                const { errMsg } = e;
                
                if (errMsg && errMsg.indexOf('play audio fail') < 0) {
                    return;
                }
                
                if (typeof this.source !== 'undefined' && this.source.mediaElement) {
                    this.source._reset();
                    this.source.mediaElement.stop();
                }
            });
            this.source.mediaElement.onCanplay(() => {
                if (typeof this.source !== 'undefined' && this.source.mediaElement) {
                    
                    
                    const { duration } = this.source.mediaElement;
                    setTimeout(() => {
                        if (soundClip && this.source && this.source.mediaElement) {
                            soundClip.length = Math.round(this.source.mediaElement.duration * 44100);
                        }
                    }, 0);
                }
            });
            this.source.start(startTime, startOffset);
            this.source.playbackStartTime = startTime - startOffset / this.source.playbackRateValue;
        }
        catch (e) {
            printErrMsg(`playUrl error. Exception: ${e}`);
        }
    }
    playBuffer(startTime, buffer, startOffset) {
        try {
            this.setup();
            if (!this.source) {
                return;
            }
            this.source.buffer = buffer;
            this.source.onended = () => {
                this.disconnectSource();
                if (this.callback) {
                    GameGlobal.unityNamespace.Module.dynCall_vi(this.callback, [this.userData]);
                }
            };
            this.source.start(startTime, startOffset);
            this.source.playbackStartTime = startTime - startOffset / this.source.playbackRateValue;
        }
        catch (e) {
            printErrMsg(`playBuffer error. Exception: ${e}`);
        }
    }
    disconnectSource() {
        if (this.source) {
            if (this.source.mediaElement) {
                destroyInnerAudio(this.source.instanceId, false);
                delete this.source.mediaElement;
                delete this.source;
            }
            else if (!this.source.isPausedMockNode) {
                this.source.onended = null;
                if (this.source.disconnect) {
                    this.source.disconnect();
                }
                if (GameGlobal.isIOSHighPerformanceMode) {
                    this.source.buffer = null;
                }
                WEBAudio.bufferSourceNodeLength -= 1;
                delete this.source;
            }
            else {
                this.source.buffer = null;
            }
        }
    }
    stop(delay) {
        if (!WEBAudio.audioContext) {
            return;
        }
        if (this.source) {
            if (this.source.buffer) {
                try {
                    this.source.stop(WEBAudio.audioContext.currentTime + delay);
                }
                catch (e) { }
                if (delay == 0) {
                    this.disconnectSource();
                }
            }
            else if (this.source.mediaElement) {
                this.source.stop(delay);
            }
        }
    }
    isPaused() {
        if (!this.source) {
            return true;
        }
        if (this.source.isPausedMockNode) {
            return true;
        }
        if (this.source.mediaElement) {
            return (this.source.mediaElement.paused || this.source.pauseRequested) ?? true;
        }
        return false;
    }
    pause() {
        const { source } = this;
        if (!source) {
            return;
        }
        if (source.mediaElement) {
            source._pauseMediaElement();
            return;
        }
        if (source.isPausedMockNode) {
            return;
        }
        const pausedSource = {
            isPausedMockNode: true,
            loop: source.loop,
            loopStart: source.loopStart,
            loopEnd: source.loopEnd,
            buffer: source.buffer,
            playbackRate: source.playbackRateValue,
            playbackPausedAtPosition: source.estimatePlaybackPosition(),
            setPitch(v) {
                this.playbackRate = v;
            },
            _reset() { },
        };
        this.stop(0);
        this.disconnectSource();
        this.source = pausedSource;
    }
    resume() {
        if (!WEBAudio.audioContext) {
            return;
        }
        if (!this.source) {
            return;
        }
        if (this.source.mediaElement) {
            this.source.start();
            return;
        }
        const pausedSource = this.source;
        if (!pausedSource.isPausedMockNode) {
            return;
        }
        delete this.source;
        if (!pausedSource.buffer) {
            return;
        }
        this.playBuffer(WEBAudio.audioContext.currentTime - Math.min(0, pausedSource.playbackPausedAtPosition), pausedSource.buffer, Math.max(0, pausedSource.playbackPausedAtPosition));
        const getSource = this.source;
        if (getSource) {
            getSource.loop = pausedSource.loop;
            getSource.loopStart = pausedSource.loopStart;
            getSource.loopEnd = pausedSource.loopEnd;
            getSource.setPitch(pausedSource.playbackRate);
        }
    }
    setVolume(volume) {
        if (!WEBAudio.audioContext) {
            return;
        }
        if (this.source) {
            if (this.source.buffer && this.gain) {
                this.gain.gain.setValueAtTime(volume, WEBAudio.audioContext.currentTime);
            }
            else if (this.source.mediaElement) {
                this.source.mediaElement.volume = volume;
            }
        }
    }
    setup(url) {
        if (!WEBAudio.audioContext) {
            return;
        }
        if (this.source && !this.source.isPausedMockNode) {
            if (!this.source.url) {
                if (typeof url !== 'undefined') {
                    
                    this.stop(0);
                }
                else {
                    
                }
            }
            else if (typeof url === 'undefined') {
                if (typeof this.source !== 'undefined') {
                    
                    this.source._reset();
                }
                this.disconnectSource();
            }
            else {
                
                
                this.source._reset();
                this.disconnectSource();
            }
        }
        if (!url) {
            this.source = WEBAudio.audioContext.createBufferSource();
            WEBAudio.bufferSourceNodeLength += 1;
            const { source } = this;
            Object.defineProperty(this.source, 'playbackRateValue', {
                get() {
                    return source?.playbackRate.value ?? 0;
                },
                set(v) {
                    if (!source) {
                        return;
                    }
                    source.playbackRate.value = v;
                },
            });
        }
        else {
            const { audio: getAudio, id: instanceId } = createInnerAudio();
            getAudio.src = url;
            const innerFixPlay = () => {
                if (!this.source) {
                    return;
                }
                this.source.needCanPlay = true;
                if (this.source.fixPlayTicker) {
                    
                    clearTimeout(this.source.fixPlayTicker);
                    delete this.source.fixPlayTicker;
                }
                
                this.source.fixPlayTicker = setTimeout(() => {
                    if (this.source && this.source.mediaElement && this.source.needCanPlay && !this.source.isPlaying) {
                        this.source.mediaElement.play();
                    }
                }, 2000);
            };
            const innerPlay = () => {
                if (this.source && this.source.mediaElement) {
                    if (isSupportBufferURL && this.source.readyToPlay) {
                        if (this.source.stopCache) {
                            this.source.stopCache = false;
                            this.source.playAfterStop = true;
                        }
                        else if (!this.source.isPlaying) {
                            
                            if (isAndroid) {
                                innerFixPlay();
                            }
                            this.source.mediaElement.play();
                        }
                    }
                    else {
                        this.source.mediaElement.onCanplay(() => {
                            if (!this.source) {
                                return;
                            }
                            this.source.needCanPlay = false;
                            this.source.readyToPlay = true;
                            if (typeof this.source.mediaElement !== 'undefined') {
                                
                                
                                const { duration } = this.source.mediaElement;
                                this.source.mediaElement.offCanplay();
                            }
                            if (this.source.stopCache) {
                                this.source.stopCache = false;
                                this.source.playAfterStop = true;
                            }
                            else if (!this.source.isPlaying) {
                                
                                if (isAndroid) {
                                    innerFixPlay();
                                }
                                if (typeof this.source.mediaElement !== 'undefined') {
                                    this.source.mediaElement.play();
                                }
                            }
                        });
                        innerFixPlay();
                    }
                }
            };
            
            const _reset = () => {
                if (!this.source) {
                    return;
                }
                this.source.readyToPlay = false;
                this.source.isPlaying = false;
                this.source.stopCache = false;
                this.source.playAfterStop = false;
                this.source.needCanPlay = false;
                if (this.source.stopTicker) {
                    clearTimeout(this.source.stopTicker);
                    this.source.stopTicker = undefined;
                }
            };
            
            const _pauseMediaElement = () => {
                if (typeof this.source === 'undefined') {
                    return;
                }
                if (this.source.playTimeout) {
                    this.source.pauseRequested = true;
                }
                else if (this.source.isPlaying && this.source.mediaElement) {
                    this.source.mediaElement.pause();
                }
            };
            
            const _startPlayback = (offset) => {
                if (typeof this.source === 'undefined' || !this.source.mediaElement) {
                    return;
                }
                if (this.source.playTimeout) {
                    if (typeof this.source.mediaElement.seek === 'function') {
                        this.source.mediaElement.seek(offset);
                    }
                    else {
                        this.source.mediaElement.currentTime = offset;
                    }
                    this.source.pauseRequested = false;
                    return;
                }
                innerPlay();
                if (typeof this.source.mediaElement.seek === 'function') {
                    this.source.mediaElement.seek(offset);
                }
                else {
                    this.source.mediaElement.currentTime = offset;
                }
            };
            const start = (startTime, offset) => {
                if (typeof this.source === 'undefined') {
                    return;
                }
                if (typeof startTime === 'undefined' && typeof offset === 'undefined') {
                    innerPlay();
                    return;
                }
                if (typeof startTime === 'undefined') {
                    startTime = 0;
                }
                if (typeof offset === 'undefined') {
                    offset = 0;
                }
                const startDelayThresholdMS = 4;
                const startDelayMS = startTime * 1e3;
                if (startDelayMS > startDelayThresholdMS) {
                    if (this.source.playTimeout) {
                        clearTimeout(this.source.playTimeout);
                    }
                    this.source.playTimeout = setTimeout(() => {
                        if (typeof this.source !== 'undefined') {
                            delete this.source.playTimeout;
                            this.source._startPlayback(offset || 0);
                        }
                    }, startDelayMS);
                }
                else {
                    this.source._startPlayback(offset);
                }
            };
            const stop = (stopTime) => {
                if (typeof this.source === 'undefined') {
                    return;
                }
                if (typeof stopTime === 'undefined') {
                    stopTime = 0;
                }
                const stopDelayThresholdMS = 4;
                const stopDelayMS = stopTime * 1e3;
                if (stopDelayMS > stopDelayThresholdMS) {
                    setTimeout(() => {
                        if (this.source && this.source.mediaElement) {
                            this.source.stopCache = true;
                            this.source.mediaElement.stop();
                        }
                    }, stopDelayMS);
                }
                else if (this.source.mediaElement) {
                    this.source.stopCache = true;
                    this.source.mediaElement.stop();
                }
            };
            this.source = {
                instanceId,
                mediaElement: getAudio,
                url,
                playbackStartTime: 0,
                pauseRequested: false,
                _reset,
                _pauseMediaElement,
                _startPlayback,
                start,
                stop,
            };
            
            
            const { buffered, referrerPolicy, volume } = getAudio;
            const { source } = this;
            Object.defineProperty(this.source, 'loopStart', {
                get() {
                    return 0;
                },
                
                set(v) { },
            });
            Object.defineProperty(source, 'loopEnd', {
                get() {
                    return 0;
                },
                
                set(v) { },
            });
            Object.defineProperty(source, 'loop', {
                get() {
                    return source?.mediaElement?.loop ?? false;
                },
                set(v) {
                    if (!source || !source.mediaElement) {
                        return;
                    }
                    source.mediaElement.loop = v;
                },
            });
            Object.defineProperty(source, 'playbackRateValue', {
                get() {
                    return source?.mediaElement?.playbackRate ?? 0;
                },
                set(v) {
                    if (!source || !source.mediaElement) {
                        return;
                    }
                    
                    if (!isSupportPlayBackRate) {
                        source.mediaElement.playbackRate = 1;
                    }
                    else {
                        source.mediaElement.playbackRate = v;
                    }
                },
            });
            Object.defineProperty(source, 'currentTime', {
                get() {
                    return source?.mediaElement?.currentTime ?? 0;
                },
                set(v) {
                    if (!source || !source.mediaElement) {
                        return;
                    }
                    if (typeof source.mediaElement.seek === 'function') {
                        source.mediaElement.seek(v);
                    }
                    else {
                        source.mediaElement.currentTime = v;
                    }
                },
            });
        }
        if (!this.source) {
            return;
        }
        this.source.estimatePlaybackPosition = () => {
            if (!this.source) {
                return 0;
            }
            let t;
            if (WEBAudio.audioContext) {
                t = (WEBAudio.audioContext.currentTime - this.source.playbackStartTime) * this.source.playbackRateValue;
            }
            else {
                t = -this.source.playbackStartTime * this.source.playbackRateValue;
            }
            if (this.source.loop && t >= this.source.loopStart) {
                t = ((t - this.source.loopStart) % (this.source.loopEnd - this.source.loopStart)) + this.source.loopStart;
            }
            return t;
        };
        this.source.setPitch = (newPitch) => {
            if (!this.source) {
                return 0;
            }
            const curPosition = this.source.estimatePlaybackPosition();
            if (curPosition >= 0) {
                if (WEBAudio.audioContext) {
                    this.source.playbackStartTime = WEBAudio.audioContext.currentTime - curPosition / newPitch;
                }
            }
            this.source.playbackRateValue = newPitch;
        };
        this.setupPanning();
    }
    setupPanning() {
        if (typeof this.source === 'undefined') {
            return;
        }
        if (this.source.isPausedMockNode) {
            return;
        }
        if (this.source.disconnect && this.source.connect) {
            this.source.disconnect();
            if (this.gain) {
                this.source.connect(this.gain);
            }
        }
    }
    isStopped() {
        return !this.source;
    }
}
export default {
    _JS_Sound_Create_Channel(callback, userData) {
        if (!WEBAudio.audioContext || WEBAudio.audioWebEnabled === 0) {
            return 0;
        }
        const channel = new AudioChannelInstance(callback, userData);
        WEBAudio.audioInstances[++WEBAudio.audioInstanceIdCounter] = channel;
        return WEBAudio.audioInstanceIdCounter;
    },
    _JS_Sound_GetLength(bufferInstance) {
        if (WEBAudio.audioWebEnabled === 0) {
            return defaultSoundLength;
        }
        const soundClip = WEBAudio.audioInstances[bufferInstance];
        if (!soundClip) {
            return defaultSoundLength;
        }
        if (soundClip && soundClip.buffer) {
            const sampleRateRatio = 44100 / soundClip.buffer.sampleRate;
            return soundClip.buffer.length * sampleRateRatio;
        }
        return soundClip.length || defaultSoundLength;
    },
    _JS_Sound_GetLoadState(bufferInstance) {
        if (WEBAudio.audioWebEnabled === 0) {
            return 2;
        }
        const soundClip = WEBAudio.audioInstances[bufferInstance];
        if (!soundClip || soundClip.error) {
            return 2;
        }
        if (soundClip.buffer || soundClip.url) {
            return 0;
        }
        return 1;
    },
    _JS_Sound_Init() {
        try {
            if (wx && wx.createWebAudioContext) {
                WEBAudio.audioContext = wx.createWebAudioContext();
                console.log('use wx WebAudio');
            }
            if (!WEBAudio.audioContext) {
                printErrMsg('Minigame Web Audio API not suppoted');
                return;
            }
            WEBAudio.audioWebSupport = 1;
            WEBAudio.audioWebEnabled = 1;
            let webAutoResumeTicker = null;
            wx.onHide(() => {
                if (webAutoResumeTicker) {
                    clearTimeout(webAutoResumeTicker);
                    webAutoResumeTicker = null;
                }
                WEBAudio.audioContext?.suspend();
            });
            wx.onShow(() => {
                WEBAudio.audioContext?.resume();
            });
            if (webAudioNeedResume) {
                
                webAutoResumeTicker = setTimeout(() => {
                    resumeWebAudio();
                }, 2000);
            }
        }
        catch (e) {
            printErrMsg('Web Audio API is not supported in this browser');
        }
    },
    _JS_Sound_IsStopped(channelInstance) {
        if (WEBAudio.audioWebEnabled == 0) {
            return true;
        }
        const channel = WEBAudio.audioInstances[channelInstance];
        if (!channel) {
            return true;
        }
        return channel.isStopped();
    },
    _JS_Sound_Load(ptr, length, decompress) {
        if (!WEBAudio.audioContext || WEBAudio.audioWebEnabled === 0) {
            return 0;
        }
        const audioData = GameGlobal.unityNamespace.Module.HEAPU8.buffer.slice(ptr, ptr + length);
        
        if (length > 131072) {
            decompress = 0;
        }
        else {
            decompress = 1;
        }
        
        if (isAndroid || isPc) {
            decompress = 1;
        }
        if (decompress && WEBAudio.audioWebSupport) {
            const soundClip = {
                buffer: null,
                error: false,
                release() {
                    this.buffer = null;
                    WEBAudio.audioBufferLength -= length;
                },
            };
            WEBAudio.audioContext.decodeAudioData(audioData, (buffer) => {
                soundClip.buffer = buffer;
                WEBAudio.audioBufferLength += length;
            }, (error) => {
                soundClip.error = true;
                console.log(`Decode error: ${error}`);
            });
            WEBAudio.audioInstances[++WEBAudio.audioInstanceIdCounter] = soundClip;
        }
        else {
            const soundClip = {
                error: false,
                length: 441000,
                url: undefined,
                release() {
                    WEBAudio.audioBufferLength -= length;
                    if (isSupportBufferURL && this.url) {
                        wx.revokeBufferURL(this.url);
                    }
                    delete this.url;
                },
            };
            if (isSupportBufferURL) {
                const url = wx.createBufferURL(audioData);
                soundClip.url = url;
                WEBAudio.audioBufferLength += length;
            }
            else {
                const tempFilePath = `${TEMP_DIR_PATH}/temp-audio${ptr + length}.mp3`;
                if (GameGlobal.manager.getCachePath(tempFilePath)) {
                    soundClip.url = tempFilePath;
                    WEBAudio.audioBufferLength += length;
                }
                else {
                    GameGlobal.manager
                        .writeFile(tempFilePath, audioData)
                        .then(() => {
                        soundClip.url = tempFilePath;
                        WEBAudio.audioBufferLength += length;
                    })
                        .catch((res) => {
                        soundClip.error = true;
                        printErrMsg(res);
                    });
                }
            }
            WEBAudio.audioInstances[++WEBAudio.audioInstanceIdCounter] = soundClip;
        }
        return WEBAudio.audioInstanceIdCounter;
    },
    _JS_Sound_Load_PCM(channels, length, sampleRate, ptr) {
        if (!WEBAudio.audioContext || WEBAudio.audioWebSupport === 0 || WEBAudio.audioWebEnabled === 0) {
            return 0;
        }
        const sound = {
            buffer: WEBAudio.audioContext.createBuffer(channels, length, sampleRate),
            error: false,
            release: () => { },
        };
        for (let i = 0; i < channels; i++) {
            const offs = (ptr >> 2) + length * i;
            const { buffer } = sound;
            const copyToChannel = buffer.copyToChannel
                || function (source, channelNumber, startInChannel) {
                    const clipped = source.subarray(0, Math.min(source.length, buffer.length - (startInChannel | 0)));
                    buffer.getChannelData(channelNumber | 0).set(clipped, startInChannel | 0);
                };
            copyToChannel.apply(buffer, [GameGlobal.unityNamespace.Module.HEAPF32.subarray(offs, offs + length), i, 0]);
        }
        WEBAudio.audioInstances[++WEBAudio.audioInstanceIdCounter] = sound;
        return WEBAudio.audioInstanceIdCounter;
    },
    _JS_Sound_Play(bufferInstance, channelInstance, offset, delay) {
        if (!WEBAudio.audioContext || WEBAudio.audioWebEnabled === 0) {
            return;
        }
        WXWASMSDK._JS_Sound_Stop(channelInstance, 0);
        const soundClip = WEBAudio.audioInstances[bufferInstance];
        const channel = WEBAudio.audioInstances[channelInstance];
        if (soundClip && soundClip.url) {
            try {
                channel.playUrl(delay, soundClip.url, offset, soundVolumeHandler[channelInstance], soundClip);
            }
            catch (e) {
                printErrMsg(`playUrl error. Exception: ${e}`);
            }
        }
        else if (soundClip && soundClip.buffer) {
            try {
                channel.playBuffer(WEBAudio.audioContext.currentTime + delay, soundClip.buffer, offset);
            }
            catch (e) {
                printErrMsg(`playBuffer error. Exception: ${e}`);
            }
        }
        else {
            console.log('Trying to play sound which is not loaded.');
        }
    },
    _JS_Sound_ReleaseInstance(instance) {
        if (WEBAudio.audioWebEnabled === 0) {
            return;
        }
        const object = WEBAudio.audioInstances[instance];
        if (object) {
            object.release();
        }
        delete WEBAudio.audioInstances[instance];
    },
    _JS_Sound_ResumeIfNeeded() {
        if (WEBAudio.audioWebSupport === 0 || WEBAudio.audioWebEnabled === 0) {
            return;
        }
        resumeWebAudio();
    },
    _JS_Sound_Set3D(channelInstance, threeD) {
        if (WEBAudio.audio3DSupport === 0 || WEBAudio.audioWebEnabled === 0) {
            return;
        }
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
        if (!WEBAudio.audioContext
            || WEBAudio.audio3DSupport === 0
            || WEBAudio.audioWebSupport === 0
            || WEBAudio.audioWebEnabled === 0) {
            return;
        }
        x = x > 0 ? 0 : x;
        y = y > 0 ? 0 : y;
        z = z > 0 ? 0 : z;
        xUp = xUp < 0 ? 0 : xUp;
        yUp = yUp < 0 ? 0 : yUp;
        zUp = zUp < 0 ? 0 : zUp;
        if (x == WEBAudio.lOrientation.x
            && y == WEBAudio.lOrientation.y
            && z == WEBAudio.lOrientation.z
            && xUp == WEBAudio.lOrientation.xUp
            && yUp == WEBAudio.lOrientation.yUp
            && zUp == WEBAudio.lOrientation.zUp) {
            return;
        }
        WEBAudio.lOrientation.x = x;
        WEBAudio.lOrientation.y = y;
        WEBAudio.lOrientation.z = z;
        WEBAudio.lOrientation.xUp = xUp;
        WEBAudio.lOrientation.yUp = yUp;
        WEBAudio.lOrientation.zUp = zUp;
        if (WEBAudio.audioContext.listener.forwardX) {
            WEBAudio.audioContext.listener.forwardX.setValueAtTime(-x, WEBAudio.audioContext.currentTime);
            WEBAudio.audioContext.listener.forwardY.setValueAtTime(-y, WEBAudio.audioContext.currentTime);
            WEBAudio.audioContext.listener.forwardZ.setValueAtTime(-z, WEBAudio.audioContext.currentTime);
            WEBAudio.audioContext.listener.upX.setValueAtTime(xUp, WEBAudio.audioContext.currentTime);
            WEBAudio.audioContext.listener.upY.setValueAtTime(yUp, WEBAudio.audioContext.currentTime);
            WEBAudio.audioContext.listener.upZ.setValueAtTime(zUp, WEBAudio.audioContext.currentTime);
        }
        else {
            WEBAudio.audioContext.listener.setOrientation(-x, -y, -z, xUp, yUp, zUp);
        }
    },
    _JS_Sound_SetListenerPosition(x, y, z) {
        if (!WEBAudio.audioContext
            || WEBAudio.audio3DSupport === 0
            || WEBAudio.audioWebSupport === 0
            || WEBAudio.audioWebEnabled === 0) {
            return;
        }
        x = x < 0 ? 0 : x;
        y = y < 0 ? 0 : y;
        z = z < 0 ? 0 : z;
        if (x == WEBAudio.lPosition.x && y == WEBAudio.lPosition.y && z == WEBAudio.lPosition.z) {
            return;
        }
        WEBAudio.lPosition.x = x;
        WEBAudio.lPosition.y = y;
        WEBAudio.lPosition.z = z;
        if (WEBAudio.audioContext.listener.positionX) {
            WEBAudio.audioContext.listener.positionX.setValueAtTime(x, WEBAudio.audioContext.currentTime);
            WEBAudio.audioContext.listener.positionY.setValueAtTime(y, WEBAudio.audioContext.currentTime);
            WEBAudio.audioContext.listener.positionZ.setValueAtTime(z, WEBAudio.audioContext.currentTime);
        }
        else {
            WEBAudio.audioContext.listener.setPosition(x, y, z);
        }
    },
    _JS_Sound_SetLoop(channelInstance, loop) {
        if (WEBAudio.audioWebEnabled === 0) {
            return;
        }
        const channel = WEBAudio.audioInstances[channelInstance];
        if (!channel.source) {
            channel.setup();
        }
        if (!channel.source) {
            return;
        }
        channel.source.loop = loop > 0;
    },
    _JS_Sound_SetLoopPoints(channelInstance, loopStart, loopEnd) {
        if (WEBAudio.audioWebEnabled === 0) {
            return;
        }
        const channel = WEBAudio.audioInstances[channelInstance];
        if (!channel.source) {
            channel.setup();
        }
        if (!channel.source) {
            return;
        }
        channel.source.loopStart = loopStart;
        channel.source.loopEnd = loopEnd;
    },
    _JS_Sound_SetPaused(channelInstance, paused) {
        if (WEBAudio.audioWebEnabled === 0) {
            return;
        }
        const channel = WEBAudio.audioInstances[channelInstance];
        if (!!paused !== channel.isPaused()) {
            if (paused) {
                channel.pause();
            }
            else {
                channel.resume();
            }
        }
    },
    _JS_Sound_SetPitch(channelInstance, v) {
        if (WEBAudio.audio3DSupport === 0 || WEBAudio.audioWebSupport === 0 || WEBAudio.audioWebEnabled === 0) {
            return;
        }
        try {
            WEBAudio.audioInstances[channelInstance].source?.setPitch(v);
        }
        catch (e) {
            printErrMsg(`Invalid audio pitch ${v} specified to WebAudio backend!`);
        }
    },
    
    _JS_Sound_SetPosition(channelInstance, x, y, z) {
        if (WEBAudio.audio3DSupport === 0 || WEBAudio.audioWebSupport === 0 || WEBAudio.audioWebEnabled === 0) {
            return;
        }
        console.error('不支持3d音效');
    },
    _JS_Sound_SetVolume(channelInstance, v) {
        if (WEBAudio.audioWebEnabled === 0) {
            return;
        }
        try {
            const volume = Number(v.toFixed(2));
            const cur = soundVolumeHandler[channelInstance];
            if (cur === volume) {
                return;
            }
            
            if (cur == undefined && v == 1) {
                return;
            }
            soundVolumeHandler[channelInstance] = volume;
            const channel = WEBAudio.audioInstances[channelInstance];
            channel.setVolume(volume);
        }
        catch (e) {
            printErrMsg(`Invalid audio volume ${v} specified to WebAudio backend!`);
        }
    },
    _JS_Sound_Stop(channelInstance, delay) {
        if (WEBAudio.audioWebEnabled === 0) {
            return;
        }
        const channel = WEBAudio.audioInstances[channelInstance];
        channel.stop(delay);
    },
};
