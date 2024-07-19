﻿import storage from './storage';
import userInfo from './userinfo';
import moduleHelper from './module-helper';
import share from './share';
import ad from './ad';
import canvasHelper from './canvas';
import fs from './fs';
import openData from './open-data';
import util from './util';
import cloud from './cloud';
import audio from './audio';
import texture from './texture';
import fix from './fix';
import canvasContext from './canvas-context';
import video from './video';
import logger from './logger';
import shortAudio from './short-audio';
import gameClub from './game-club';
import sdk from './sdk';
import camera from './camera';
import recorder from './recorder';
import uploadFile from './upload-file';
import gameRecorder from './game-recorder';

const unityVersion = '$unityVersion$';
GameGlobal.unityNamespace = GameGlobal.unityNamespace || {};
GameGlobal.unityNamespace.unityVersion = unityVersion;

window._ScaleRate = 1;
// 兼容unity低版本高清屏的问题
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
  configuarble: true,
});

Object.defineProperty(canvas, 'clientWidth', {
  get() {
    return window.innerWidth * window._ScaleRate;
  },
  configuarble: true,
});

Object.defineProperty(document.body, 'clientHeight', {
  get() {
    return window.innerHeight * window._ScaleRate;
  },
  configuarble: true,
});

Object.defineProperty(document.body, 'clientWidth', {
  get() {
    return window.innerWidth * window._ScaleRate;
  },
  configuarble: true,
});

Object.defineProperty(document, 'fullscreenEnabled', {
  get() {
    return true;
  },
  configuarble: true,
});

fix.init();

const WXWASMSDK = {
  /*
      初始化
     */
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
  ...shortAudio,
  ...gameClub,
  canvasContext,
  ...sdk,
  ...camera,
  ...recorder,
  ...uploadFile,
  ...gameRecorder,
};


GameGlobal.WXWASMSDK = WXWASMSDK;
