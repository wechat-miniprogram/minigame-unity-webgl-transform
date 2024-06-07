
import moduleHelper from './module-helper';
import { uid, formatResponse, formatJsonStr, stringifyRes } from './utils';
const onEventLists = {};
let wxOnAddToFavoritesResolveConf;
let wxOnCopyUrlResolveConf;
let wxOnHandoffResolveConf;
let wxOnShareTimelineResolveConf;
let wxOnGameLiveStateChangeResolveConf;
const ClassLists = {};
const ClassOnEventLists = {};
function getClassObject(className, id) {
  if (!ClassLists[className]) {
    ClassLists[className] = {};
  }
  const obj = ClassLists[className][id];
  if (!obj) {
    console.error(`${className} 不存在:`, id);
  }
  return obj;
}
;


function WX_OneWayNoFunction(functionName, ...params) {
  wx[functionName.replace(/^\w/, a => a.toLowerCase())](...params);
}


const onlyReadyResponse = [
  'getSystemSetting',
  'getAppAuthorizeSetting',
];

function WX_SyncFunction(functionName, ...params) {
  return wx[functionName.replace(/^\w/, a => a.toLowerCase())](...params);
}


function WX_ClassOneWayNoFunction(className, functionName, id, ...params) {
  const obj = getClassObject(className, id);
  if (!obj) {
    return;
  }
  obj[functionName.replace(/^\w/, a => a.toLowerCase())](...params);
}
export default {
  WX_OneWayFunction(functionName, successType, failType, completeType, conf, callbackId) {
    const lowerFunctionName = functionName.replace(/^\w/, a => a.toLowerCase());
    const config = formatJsonStr(conf);

    if (lowerFunctionName === 'login') {
      if (!config.timeout) {
        delete config.timeout;
      }
    } else if (lowerFunctionName === 'reportScene') {
      if (GameGlobal.manager && GameGlobal.manager.setGameStage) {
        GameGlobal.manager.setGameStage(config.sceneId);
      }
    }
    wx[lowerFunctionName]({
      ...config,
      success(res) {
        formatResponse(successType, res);
        moduleHelper.send(`${functionName}Callback`, JSON.stringify({
          callbackId, type: 'success', res: JSON.stringify(res),
        }));
      },
      fail(res) {
        formatResponse(failType, res);
        moduleHelper.send(`${functionName}Callback`, JSON.stringify({
          callbackId, type: 'fail', res: JSON.stringify(res),
        }));
      },
      complete(res) {
        formatResponse(completeType, res);
        moduleHelper.send(`${functionName}Callback`, JSON.stringify({
          callbackId, type: 'complete', res: JSON.stringify(res),
        }));
      },
    });
  },
  WX_OneWayNoFunction_v(functionName) {
    WX_OneWayNoFunction(functionName);
  },
  WX_OneWayNoFunction_vs(functionName, param1) {
    WX_OneWayNoFunction(functionName, param1);
  },
  WX_OneWayNoFunction_vt(functionName, param1) {
    const formatParam1 = formatJsonStr(param1);
    WX_OneWayNoFunction(functionName, formatParam1);
  },
  WX_OneWayNoFunction_vst(functionName, param1, param2) {
    const formatParam2 = formatJsonStr(param2);
    WX_OneWayNoFunction(functionName, param1, formatParam2);
  },
  WX_OneWayNoFunction_vsn(functionName, param1, param2) {
    WX_OneWayNoFunction(functionName, param1, param2);
  },
  WX_OneWayNoFunction_vnns(functionName, param1, param2, param3) {
    WX_OneWayNoFunction(functionName, param1, param2, param3);
  },
  WX_OnEventRegister(functionName, resType) {
    if (!onEventLists[functionName]) {
      onEventLists[functionName] = [];
    }
    const callback = (res) => {
      formatResponse(resType, res);
      const resStr = stringifyRes(res);
      moduleHelper.send(`_${functionName}Callback`, resStr);
    };
    onEventLists[functionName].push(callback);
    wx[functionName.replace(/^\w/, a => a.toLowerCase())](callback);
  },
  WX_OffEventRegister(functionName) {
    (onEventLists[functionName] || []).forEach((v) => {
      wx[functionName.replace(/^On/, 'off')](v);
    });
  },
  WX_OnAddToFavorites() {
    const callback = (res) => {
      const resStr = stringifyRes(res);
      moduleHelper.send('_OnAddToFavoritesCallback', resStr);
      return wxOnAddToFavoritesResolveConf;
    };
    wx.onAddToFavorites(callback);
  },
  WX_OnAddToFavorites_Resolve(conf) {
    try {
      wxOnAddToFavoritesResolveConf = formatJsonStr(conf);
      return;
    } catch (e) {
    }
    wxOnAddToFavoritesResolveConf = {};
  },
  WX_OffAddToFavorites() {
    wx.offAddToFavorites();
  },
  WX_OnCopyUrl() {
    const callback = (res) => {
      const resStr = stringifyRes(res);
      moduleHelper.send('_OnCopyUrlCallback', resStr);
      return wxOnCopyUrlResolveConf;
    };
    wx.onCopyUrl(callback);
  },
  WX_OnCopyUrl_Resolve(conf) {
    try {
      wxOnCopyUrlResolveConf = formatJsonStr(conf);
      return;
    } catch (e) {
    }
    wxOnCopyUrlResolveConf = {};
  },
  WX_OffCopyUrl() {
    wx.offCopyUrl();
  },
  WX_OnHandoff() {
    const callback = (res) => {
      const resStr = stringifyRes(res);
      moduleHelper.send('_OnHandoffCallback', resStr);
      return wxOnHandoffResolveConf;
    };
    wx.onHandoff(callback);
  },
  WX_OnHandoff_Resolve(conf) {
    try {
      wxOnHandoffResolveConf = formatJsonStr(conf);
      return;
    } catch (e) {
    }
    wxOnHandoffResolveConf = {};
  },
  WX_OffHandoff() {
    wx.offHandoff();
  },
  WX_OnShareTimeline() {
    const callback = (res) => {
      const resStr = stringifyRes(res);
      moduleHelper.send('_OnShareTimelineCallback', resStr);
      return wxOnShareTimelineResolveConf;
    };
    wx.onShareTimeline(callback);
  },
  WX_OnShareTimeline_Resolve(conf) {
    try {
      wxOnShareTimelineResolveConf = formatJsonStr(conf);
      return;
    } catch (e) {
    }
    wxOnShareTimelineResolveConf = {};
  },
  WX_OffShareTimeline() {
    wx.offShareTimeline();
  },
  WX_OnGameLiveStateChange() {
    const callback = (res) => {
      formatResponse('OnGameLiveStateChangeCallbackResult', res);
      const resStr = stringifyRes(res);
      moduleHelper.send('_OnGameLiveStateChangeCallback', resStr);
      return wxOnGameLiveStateChangeResolveConf;
    };
    wx.onGameLiveStateChange(callback);
  },
  WX_OnGameLiveStateChange_Resolve(conf) {
    try {
      wxOnGameLiveStateChangeResolveConf = formatJsonStr(conf);
      return;
    } catch (e) {
    }
    wxOnGameLiveStateChangeResolveConf = {};
  },
  WX_OffGameLiveStateChange() {
    wx.offGameLiveStateChange();
  },
  WX_SyncFunction_bs(functionName, param1) {
    const res = WX_SyncFunction(functionName, param1);
    return res;
  },
  WX_SyncFunction_t(functionName, returnType) {
    const res = WX_SyncFunction(functionName);
    if (onlyReadyResponse.includes(functionName.replace(/^\w/, a => a.toLowerCase()))) {
      formatResponse(returnType, JSON.parse(JSON.stringify(res)));
      return JSON.stringify(res);
    }
    formatResponse(returnType, res);
    return JSON.stringify(res);
  },
  WX_SyncFunction_tt(functionName, returnType, param1) {
    const res = WX_SyncFunction(functionName, formatJsonStr(param1));
    formatResponse(returnType, res);
    return JSON.stringify(res);
  },
  WX_SyncFunction_b(functionName) {
    const res = WX_SyncFunction(functionName);
    return res;
  },
  WX_SyncFunction_bsnn(functionName, param1, param2, param3) {
    const res = WX_SyncFunction(functionName, param1, param2, param3);
    return res;
  },
  WX_SyncFunction_bt(functionName, param1) {
    const res = WX_SyncFunction(functionName, formatJsonStr(param1));
    return res;
  },
  WX_SyncFunction_nt(functionName, param1) {
    const res = WX_SyncFunction(functionName, formatJsonStr(param1));
    return res;
  },
  WX_SyncFunction_ss(functionName, param1) {
    const res = WX_SyncFunction(functionName, param1);
    return res;
  },
  WX_ClassOneWayFunction(functionName, returnType, successType, failType, completeType, conf) {
    const config = formatJsonStr(conf);
    const callbackId = uid();
    const obj = wx[functionName.replace(/^\w/, a => a.toLowerCase())]({
      ...config,
      success(res) {
        formatResponse(successType, res);
        moduleHelper.send(`${functionName}Callback`, JSON.stringify({
          callbackId, type: 'success', res: JSON.stringify(res),
        }));
      },
      fail(res) {
        formatResponse(failType, res);
        moduleHelper.send(`${functionName}Callback`, JSON.stringify({
          callbackId, type: 'fail', res: JSON.stringify(res),
        }));
      },
      complete(res) {
        formatResponse(completeType, res);
        moduleHelper.send(`${functionName}Callback`, JSON.stringify({
          callbackId, type: 'complete', res: JSON.stringify(res),
        }));
      },
    });
    if (!ClassLists[returnType]) {
      ClassLists[returnType] = {};
    }
    ClassLists[returnType][callbackId] = obj;
    return callbackId;
  },
  WX_ClassFunction(functionName, returnType, option) {
    const obj = wx[functionName.replace(/^\w/, a => a.toLowerCase())](formatJsonStr(option));
    const key = uid();
    if (!ClassLists[returnType]) {
      ClassLists[returnType] = {};
    }
    ClassLists[returnType][key] = obj;
    return key;
  },
  WX_ClassSetProperty(className, id, key, value) {
    const obj = getClassObject(className, id);
    if (!obj) {
      return;
    }
    if (/^\s*(\{.*\}|\[.*\])\s*$/.test(value)) {
      try {
        const jsonValue = JSON.parse(value);
        Object.assign(obj[key], jsonValue);
      } catch (e) {
        obj[key] = value;
      }
    } else {
      obj[key] = value;
    }
  },
  WX_ClassOnEventFunction(className, functionName, returnType, id, eventName) {
    const obj = getClassObject(className, id);
    if (!obj) {
      return;
    }
    if (!ClassOnEventLists[className + functionName]) {
      ClassOnEventLists[className + functionName] = {};
    }
    const callback = (res) => {
      if (returnType !== 'string') {
        formatResponse(returnType, res);
      }
      if (functionName === 'On' && eventName) {
        id = id + eventName;
      }
      const resStr = JSON.stringify({
        callbackId: id,
        res: JSON.stringify(res),
      });
      moduleHelper.send(`_${className}${functionName}Callback`, resStr);
    };
    if (!ClassOnEventLists[className + functionName][id]) {
      ClassOnEventLists[className + functionName][id] = [];
    }
    ClassOnEventLists[className + functionName][id].push(callback);
    if (functionName === 'On' && eventName) {
      obj[functionName.replace(/^\w/, a => a.toLowerCase())](eventName, callback);
    } else {
      obj[functionName.replace(/^\w/, a => a.toLowerCase())](callback);
    }
  },
  WX_ClassOffEventFunction(className, functionName, id, eventName) {
    const obj = getClassObject(className, id);
    if (!obj) {
      return;
    }
    if (functionName === 'Off' && eventName) {
      id = id + eventName;
    }
    if (!ClassOnEventLists[className + functionName][id]) {
      return;
    }
    ClassOnEventLists[className + functionName][id].forEach((v) => {
      if (functionName === 'Off' && eventName) {
        obj[functionName.replace(/^\w/, a => a.toLowerCase())](eventName, v);
      } else {
        obj[functionName.replace(/^\w/, a => a.toLowerCase())](v);
      }
    });
    delete ClassOnEventLists[className + functionName][id];
  },
  WX_ClassOneWayNoFunction_v(className, functionName, id) {
    WX_ClassOneWayNoFunction(className, functionName, id);
  },
  WX_ClassOneWayNoFunction_vs(className, functionName, id, param1) {
    WX_ClassOneWayNoFunction(className, functionName, id, param1);
  },
  WX_ClassOneWayNoFunction_t(className, functionName, returnType, id) {
    const obj = getClassObject(className, id);
    if (!obj) {
      return JSON.stringify(formatResponse(returnType));
    }
    const res = obj[functionName.replace(/^\w/, a => a.toLowerCase())](...params);
    return JSON.stringify(formatResponse(returnType, res, id));
  },
  WX_ClassOneWayNoFunction_vt(className, functionName, id, param1) {
    const formatParam1 = formatJsonStr(param1);
    WX_ClassOneWayNoFunction(className, functionName, id, formatParam1);
  },
  WX_ClassOneWayNoFunction_vn(className, functionName, id, param1) {
    WX_ClassOneWayNoFunction(className, functionName, id, param1);
  },
};
