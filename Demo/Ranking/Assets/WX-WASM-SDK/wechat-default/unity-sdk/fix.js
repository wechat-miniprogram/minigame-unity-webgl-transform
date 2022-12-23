// 用来修复一些unity跟小游戏的差异问题

export default {
  init() {
    this.fixTimer();
  },
  // 基础库现在返回的id都是固定值了，会导致unity拿到的id有问题，所以这里做个中间映射
  fixTimer() {
    const wm = {};
    const _setTimeout = window.setTimeout;
    let id = 0;
    const getId = function () {
      id++;
      if (id > 100000000) {
        id = 0;
      }
      return id;
    };
    window.setTimeout = function (vCallback, nDelay) {
      const aArgs = Array.prototype.slice.call(arguments, 2);
      const id = getId();
      const t = _setTimeout(vCallback instanceof Function ? () => {
        vCallback.apply(null, aArgs);
        delete wm[id];
      } : vCallback, nDelay);
      wm[id] = t;
      return id;
    };
    const _clearTimeout = window.clearTimeout;
    window.clearTimeout = function (id) {
      const t = wm[id];
      if (t) {
        _clearTimeout(t);
        delete wm[id];
      }
    };

    const _setInterval = window.setInterval;
    window.setInterval = function (vCallback, nDelay) {
      const aArgs = Array.prototype.slice.call(arguments, 2);
      const id = getId();
      const t = _setInterval(vCallback instanceof Function ? () => {
        vCallback.apply(null, aArgs);
      } : vCallback, nDelay);
      wm[id] = t;
      return id;
    };
    const _clearInterval = window.clearInterval;
    window.clearInterval = function (id) {
      const t = wm[id];
      if (t) {
        _clearInterval(t);
        delete wm[id];
      }
    };

    const _requestAnimationFrame = window.requestAnimationFrame;
    window.requestAnimationFrame = function (vCallback) {
      const id = getId();
      const t = _requestAnimationFrame(() => {
        vCallback();
        delete wm[id];
      });
      wm[id] = t;
      return id;
    };
    const _cancelAnimationFrame = window.cancelAnimationFrame;
    window.cancelAnimationFrame = function (id) {
      const t = wm[id];
      if (t) {
        _cancelAnimationFrame(t);
        delete wm[id];
      }
    };
  },
};
