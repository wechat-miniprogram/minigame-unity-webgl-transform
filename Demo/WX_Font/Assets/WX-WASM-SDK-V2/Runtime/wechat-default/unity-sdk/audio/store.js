
export const WEBAudio = {
    audioInstanceIdCounter: 0,
    audioInstances: {},
    audioContext: null,
    audioWebEnabled: 0,
    audioCache: [],
    lOrientation: {
        x: 0,
        y: 0,
        z: 0,
        xUp: 0,
        yUp: 0,
        zUp: 0,
    },
    lPosition: { x: 0, y: 0, z: 0 },
    audio3DSupport: 0,
    audioWebSupport: 0,
    bufferSourceNodeLength: 0,
    audioBufferLength: 0, 
};

export const audios = {};

export const localAudioMap = {};

export const downloadingAudioMap = {};

export const soundVolumeHandler = {};
