
import storage from './storage';
import userInfo from './userinfo';
import moduleHelper from './module-helper';
import share from './share';
import ad from './ad';
import canvasHelper from './canvas';
import fs from './fs';
import openData from './open-data';
import util from './util';
import cloud from './cloud';
import audio from './audio/index';
import texture from './texture';
import fix from './fix';
import canvasContext from './canvas-context';
import video from './video';
import logger from './logger';
import gameClub from './game-club';
import sdk from './sdk';
import camera from './camera';
import recorder from './recorder';
import uploadFile from './upload-file';
import gameRecorder from './game-recorder';
import chat from './chat';
import font from './font/index';
import authorize from './authorize';
import videoDecoder from './video/index';
import mobileKeyboard from './mobileKeyboard/index';
import touch from './touch/index';
import TCPSocket from './TCPSocket/index';
import UDPSocket from './UDPSocket/index';
import bluetooth from './bluetooth/index';
import gyroscope from './gyroscope/index';
const unityVersion = '$unityVersion$';
GameGlobal.unityNamespace = GameGlobal.unityNamespace || {};
GameGlobal.unityNamespace.unityVersion = unityVersion;
window._ScaleRate = 1;

if (unityVersion && unityVersion.split('.').slice(0, 2)
    .join('') < '20193') {
    const width = window.innerWidth * window.devicePixelRatio;
    const height = window.innerHeight * window.devicePixelRatio;
    canvas.width = width;
    canvas.height = height;
    window._ScaleRate = window.devicePixelRatio;
}
Object.defineProperty(canvas, 'clientHeight', {
    get() {
        return window.innerHeight * window._ScaleRate;
    },
    configurable: true,
});
Object.defineProperty(canvas, 'clientWidth', {
    get() {
        return window.innerWidth * window._ScaleRate;
    },
    configurable: true,
});
Object.defineProperty(document.body, 'clientHeight', {
    get() {
        return window.innerHeight * window._ScaleRate;
    },
    configurable: true,
});
Object.defineProperty(document.body, 'clientWidth', {
    get() {
        return window.innerWidth * window._ScaleRate;
    },
    configurable: true,
});
Object.defineProperty(document, 'fullscreenEnabled', {
    get() {
        return true;
    },
    configurable: true,
});
fix.init();
const WXWASMSDK = {
        WXInitializeSDK() {
        moduleHelper.init();
        moduleHelper.send('Inited', 200);
    },
    ...storage,
    ...userInfo,
    ...share,
    ...ad,
    ...canvasHelper,
    ...fs,
    ...openData,
    ...util,
    ...cloud,
    ...audio,
    ...texture,
    ...video,
    ...logger,
    ...gameClub,
    canvasContext,
    ...sdk,
    ...camera,
    ...recorder,
    ...uploadFile,
    ...gameRecorder,
    ...chat,
    ...font,
    ...authorize,
    ...videoDecoder,
    ...mobileKeyboard,
    ...touch,
    ...TCPSocket,
    ...UDPSocket,
    ...bluetooth,
    ...gyroscope,
};
GameGlobal.WXWASMSDK = WXWASMSDK;
