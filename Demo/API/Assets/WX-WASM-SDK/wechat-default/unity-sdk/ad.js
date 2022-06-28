import moduleHelper from './module-helper';
import response from './response';

const ads = {};

export default {
  WXCreateBannerAd(conf) {
    conf = JSON.parse(conf);
    conf.style = JSON.parse(conf.styleRaw);
    const ad = wx.createBannerAd(conf);
    const key = new Date().getTime().toString(32) + Math.random().toString(32);
    ads[key] = ad;
    ad.onError((res) => {
      console.error(res);
      moduleHelper.send('ADOnErrorCallback', JSON.stringify({
        callbackId: key,
        errMsg: res.errMsg,
        errCode: res.errCode || res.err_code,
      }));
    });
    ad.onLoad(() => {
      moduleHelper.send('ADOnLoadCallback', JSON.stringify({
        callbackId: key,
        errMsg: '',
      }));
    });
    ad.onResize((res) => {
      moduleHelper.send('ADOnResizeCallback', JSON.stringify({
        callbackId: key,
        errMsg: '',
        ...res,
      }));
    });
    return key;
  },
  WXCreateFixedBottomMiddleBannerAd(adUnitId, adIntervals, height) {
    const info = wx.getSystemInfoSync();
    const ad = wx.createBannerAd({
      adUnitId,
      adIntervals,
      style: {
        left: 0,
        top: info.windowHeight - height,
        height,
        width: info.windowWeight,
      },
    });
    const key = new Date().getTime().toString(32) + Math.random().toString(32);
    ads[key] = ad;
    ad.onError((res) => {
      console.error(res);
      moduleHelper.send('ADOnErrorCallback', JSON.stringify({
        callbackId: key,
        errMsg: res.errMsg,
        errCode: res.errCode || res.err_code,
      }));
    });
    ad.onLoad(() => {
      moduleHelper.send('ADOnLoadCallback', JSON.stringify({
        callbackId: key,
        errMsg: '',
      }));
    });
    const oldWidth = info.windowWidth;
    ad.onResize((res) => {
      if (Math.abs(res.height - height) > 1 || Math.abs(res.width - oldWidth) > 1) {
        ad.style.left = parseInt((info.windowWidth - res.width) / 2);
        ad.style.top = parseInt(info.windowHeight - res.height);
      }
      moduleHelper.send('ADOnResizeCallback', JSON.stringify({
        callbackId: key,
        errMsg: '',
        ...res,
      }));
    });
    return key;
  },
  WXCreateRewardedVideoAd(conf) {
    conf = JSON.parse(conf);
    const ad = wx.createRewardedVideoAd(conf);
    const key = new Date().getTime().toString(32) + Math.random().toString(32);
    ads[key] = ad;
    if (!conf.multiton) { // 单例模式要处理一下
      ad.offLoad();
      ad.offError();
      ad.offClose();
    }
    ad.onError((res) => {
      console.error(res);
      moduleHelper.send('ADOnErrorCallback', JSON.stringify({
        callbackId: key,
        errMsg: res.errMsg,
        errCode: res.errCode || res.err_code,
      }));
    });
    ad.onLoad(() => {
      moduleHelper.send('ADOnLoadCallback', JSON.stringify({
        callbackId: key,
        errMsg: '',
      }));
    });
    ad.onClose((res) => {
      moduleHelper.send('ADOnVideoCloseCallback', JSON.stringify({
        callbackId: key,
        errMsg: '',
        ...res,
      }));
    });
    return key;
  },
  WXCreateInterstitialAd(conf) {
    conf = JSON.parse(conf);
    const ad = wx.createInterstitialAd(conf);
    const key = new Date().getTime().toString(32) + Math.random().toString(32);
    ads[key] = ad;
    ad.onError((res) => {
      console.error(res);
      moduleHelper.send('ADOnErrorCallback', JSON.stringify({
        callbackId: key,
        errMsg: res.errMsg,
        errCode: res.errCode || res.err_code,
      }));
    });
    ad.onLoad(() => {
      moduleHelper.send('ADOnLoadCallback', JSON.stringify({
        callbackId: key,
        errMsg: '',
      }));
    });
    ad.onClose(() => {
      moduleHelper.send('ADOnCloseCallback', JSON.stringify({
        callbackId: key,
        errMsg: '',
      }));
    });
    return key;
  },
  WXCreateGridAd(conf) {
    conf = JSON.parse(conf);
    conf.style = JSON.parse(conf.styleRaw);
    const ad = wx.createGridAd(conf);
    const key = new Date().getTime().toString(32) + Math.random().toString(32);
    ads[key] = ad;
    ad.onError((res) => {
      console.error(res);
      moduleHelper.send('ADOnErrorCallback', JSON.stringify({
        callbackId: key,
        errMsg: res.errMsg,
        errCode: res.errCode || res.err_code,
      }));
    });
    ad.onLoad(() => {
      moduleHelper.send('ADOnLoadCallback', JSON.stringify({
        callbackId: key,
        errMsg: '',
      }));
    });
    ad.onResize((res) => {
      moduleHelper.send('ADOnResizeCallback', JSON.stringify({
        callbackId: key,
        errMsg: '',
        ...res,
      }));
    });
    return key;
  },
  WXCreateCustomAd(conf) {
    conf = JSON.parse(conf);
    conf.style = JSON.parse(conf.styleRaw);
    const ad = wx.createCustomAd(conf);
    const key = new Date().getTime().toString(32) + Math.random().toString(32);
    ads[key] = ad;
    ad.onError((res) => {
      console.error(res);
      moduleHelper.send('ADOnErrorCallback', JSON.stringify({
        callbackId: key,
        errMsg: res.errMsg,
        errCode: res.errCode || res.err_code,
      }));
    });
    ad.onLoad(() => {
      moduleHelper.send('ADOnLoadCallback', JSON.stringify({
        callbackId: key,
        errMsg: '',
      }));
    });
    ad.onClose(() => {
      moduleHelper.send('ADOnCloseCallback', JSON.stringify({
        callbackId: key,
        errMsg: '',
      }));
    });
    return key;
  },
  WXADStyleChange(id, key, value) {
    if (!ads[id]) {
      return false;
    }
    ads[id].style[key] = value;
  },
  WXShowAd(id, succ, fail) {
    if (!ads[id]) {
      return false;
    }
    ads[id].show().then(() => {
      response.textFormat(succ, {
        errMsg: 'show:ok',
      });
    }).catch((e) => {
      response.textFormat(fail, {
        errMsg: e.errMsg || '',
      });
    });
  },
  WXShowAd2(id, branchId, branchDim, succ, fail) {
    if (!ads[id]) {
      return false;
    }
    ads[id].show({ branchId, branchDim }).then(() => {
      response.textFormat(succ, {
        errMsg: 'show:ok',
      });
    }).catch((e) => {
      response.textFormat(fail, {
        errMsg: e.errMsg || '',
      });
    });
  },
  WXHideAd(id, succ, fail) {
    if (!ads[id]) {
      return false;
    }
    if (succ || fail) {
      ads[id].hide().then((v) => {
        response.textFormat(succ, {
          errMsg: 'hide:ok',
        });
      }).catch((e) => {
        response.textFormat(fail, {
          errMsg: e.errMsg || '',
        });
      });
    } else {
      ads[id].hide();
    }
  },
  WXADDestroy(id) {
    if (!ads[id]) {
      return false;
    }
    ads[id].destroy();
    delete ads[id];
  },
  WXADLoad(id, succ, fail) {
    if (!ads[id]) {
      return false;
    }
    ads[id].load().then(() => {
      response.textFormat(succ, {});
    }).catch((res) => {
      moduleHelper.send('ADLoadErrorCallback', JSON.stringify({
        callbackId: fail,
        ...res,
      }));
    });
  },
  WXReportShareBehavior(id, conf) {
    if (!ads[id]) {
      return '{}';
    }
    return JSON.stringify(ads[id].reportShareBehavior(JSON.parse(conf)));
  },
};
