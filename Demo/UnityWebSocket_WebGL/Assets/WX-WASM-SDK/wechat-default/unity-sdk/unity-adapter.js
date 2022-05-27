const WEBAudio = {
    audioInstances: [],
    audioContext: {},
    audioWebEnabled: 0,
    audioBufferInstances: [],
};
const disableAudio = false;
const disableAudioOptimization = false;
const UnityAdapter = {};
UnityAdapter._JS_Sound_Init = function () {
    WEBAudio.audioWebEnabled = 0;
};
UnityAdapter._JS_Sound_Load = function (ptr, length) {
    const sound = wx.createInnerAudioContext();
    let soundIndex = -1;
    for (let i = 0; i < WEBAudio.audioInstances.length; ++i) {
        const audio = WEBAudio.audioInstances[i];
        if (!audio) {
            WEBAudio.audioInstances[i] = sound;
            soundIndex = i;
            break;
        }
    }
    if (soundIndex === -1) {
        soundIndex = WEBAudio.audioInstances.push(sound) - 1;
    }
    let soundBufferIndex = -1;
    for (let i = 0; i < WEBAudio.audioBufferInstances.length; ++i) {
        const audioBuffer = WEBAudio.audioBufferInstances[i];
        if (audioBuffer.ptr === ptr && audioBuffer.length === length) {
            sound.buffer = audioBuffer.filePath;
            soundBufferIndex = i;
            break;
        }
    }
    if (soundBufferIndex === -1) {
        soundBufferIndex =
            WEBAudio.audioBufferInstances.push({
                ptr,
                length,
                filePath: null,
            }) - 1;
    }
    if (!WEBAudio.audioBufferInstances[soundBufferIndex].filePath) {
        if (wx.createBufferURL && typeof wx.createBufferURL === 'function') {
            const url = wx.createBufferURL(GameGlobal.unityNamespace.Module.HEAPU8.buffer.slice(ptr, ptr + length));
            sound.buffer = url;
            WEBAudio.audioBufferInstances[soundBufferIndex].filePath = url;
        }
        else {
            const filePath = `${wx.env.USER_DATA_PATH}/audiowxgameaudio${soundBufferIndex}`;
            wx.getFileSystemManager().writeFile({
                filePath,
                data: GameGlobal.unityNamespace.Module.HEAPU8.buffer.slice(ptr, ptr + length),
                encoding: 'binary',
                success() {
                    sound.buffer = filePath;
                    WEBAudio.audioBufferInstances[soundBufferIndex].filePath = filePath;
                },
                fail() {
                    sound.error = true;
                },
            });
        }
    }
    return soundIndex;
};
UnityAdapter._JS_Sound_Create_Channel = function (_callback, _userData) {
    if (disableAudio) {
        return false;
    }
    let channelIndex = -1;
    for (let i = 0; i < WEBAudio.audioInstances.length; ++i) {
        const channel = WEBAudio.audioInstances[i];
        if (!channel) {
            WEBAudio.audioContext[i] = wx.createInnerAudioContext();
            channelIndex = i;
            break;
        }
    }
    if (channelIndex === -1) {
        channelIndex = WEBAudio.audioInstances.push(wx.createInnerAudioContext()) - 1;
    }
    return channelIndex;
};
UnityAdapter._JS_Sound_Play = function (bufferInstance, channelInstance, _offset, _delay) {
    if (disableAudio) {
        return false;
    }
    // stop sound which is playing in the channel currently.
    // UnityAdapter._JS_Sound_Stop(channelInstance, 0);
    let sound = WEBAudio.audioInstances[bufferInstance];
    if (sound.buffer) {
        sound = WEBAudio.audioInstances[bufferInstance];
        const channel = WEBAudio.audioInstances[channelInstance];
        channel.src = sound.buffer;
        sound.duration = channel.duration;
        if (channel.play) {
            channel.play();
        }
    }
    else {
        console.log('play with null buffer');
    }
    return;
};
UnityAdapter._JS_Sound_SetLoop = function (channelInstance, loop) {
    if (disableAudio) {
        return false;
    }
    WEBAudio.audioInstances[channelInstance].loop = Boolean(loop);
    return;
};
UnityAdapter._JS_Sound_Set3D = function (_channelInstance, _threeD) {
    // console.log("not support in wxgame");
};
UnityAdapter._JS_Sound_Stop = function (channelInstance, delay) {
    if (disableAudio) {
        return false;
    }
    const audioInstance = WEBAudio.audioInstances[channelInstance];
    if (delay === 0) {
        if (audioInstance.stop) {
            audioInstance.stop();
        }
        audioInstance.onEnded = function () { };
    }
    else {
        setTimeout(() => {
            if (audioInstance.stop) {
                audioInstance.stop();
            }
        }, delay);
    }
    return;
};
const soundVolumeHandler = {};
UnityAdapter._JS_Sound_SetVolume = function (channelInstance, v) {
    if (disableAudio) {
        return false;
    }
    if (disableAudioOptimization) {
        WEBAudio.audioInstances[channelInstance].volume = Number(v.toFixed(2));
        return false;
    }
    if (soundVolumeHandler[channelInstance] === Number(v.toFixed(2))) {
        return false;
    }
    soundVolumeHandler[channelInstance] = Number(v.toFixed(2));
    WEBAudio.audioInstances[channelInstance].volume = Number(soundVolumeHandler[channelInstance]);
    return;
};
UnityAdapter._JS_Sound_SetPitch = function (channelInstance, v) {
    return; // todo 客户端有bug，先屏蔽，等客户端修复再打开
    WEBAudio.audioInstances[channelInstance].playbackRate = v;
    return;
};
UnityAdapter._JS_Sound_GetLoadState = function (bufferInstance) {
    if (disableAudio) {
        return false;
    }
    const sound = WEBAudio.audioInstances[bufferInstance];
    if (sound.buffer)
        return 0;
    if (sound.error)
        return 2;
    return 1;
};
UnityAdapter._JS_Sound_ResumeIfNeeded = function () {
    // 这里是页面点击的时候会来检查，这里不需要
};
UnityAdapter._JS_Sound_GetLength = function (bufferInstance) {
    if (disableAudio) {
        return false;
    }
    const sound = WEBAudio.audioInstances[bufferInstance];
    return sound.duration;
};
UnityAdapter._JS_Sound_ReleaseInstance = function (instance) {
    let audioInstance = WEBAudio.audioInstances[instance];
    audioInstance.destroy && audioInstance.destroy();
    audioInstance = null;
};
GameGlobal.unityNamespace.UnityAdapter = UnityAdapter;
