
export default {
    init() {
        this.fixTimer();
    },
    
    fixTimer() {
        const wm = {};
        const privateSetTimeout = window.setTimeout;
        let id = 0;
        const getId = function () {
            id += 1;
            if (id > 100000000) {
                id = 0;
            }
            return id;
        };
        
        window.setTimeout = function (vCallback, nDelay) {
            const aArgs = Array.prototype.slice.call(arguments, 2);
            const id = getId();
            const t = privateSetTimeout(vCallback instanceof Function
                ? () => {
                    
                    vCallback.apply(null, aArgs);
                    delete wm[id];
                }
                : vCallback, nDelay);
            wm[id] = t;
            return id;
        };
        const privateClearTimeout = window.clearTimeout;
        
        window.clearTimeout = function (id) {
            if (id) {
                const t = wm[id];
                if (t) {
                    privateClearTimeout(t);
                    delete wm[id];
                }
            }
        };
        const privateSetInterval = window.setInterval;
        
        window.setInterval = function (vCallback, nDelay) {
            const aArgs = Array.prototype.slice.call(arguments, 2);
            const id = getId();
            const t = privateSetInterval(vCallback instanceof Function
                ? () => {
                    
                    vCallback.apply(null, aArgs);
                }
                : vCallback, nDelay);
            wm[id] = t;
            return id;
        };
        const privateClearInterval = window.clearInterval;
        
        window.clearInterval = function (id) {
            if (id) {
                const t = wm[id];
                if (t) {
                    privateClearInterval(t);
                    delete wm[id];
                }
            }
        };
        const privateRequestAnimationFrame = window.requestAnimationFrame;
        window.requestAnimationFrame = function (vCallback) {
            const id = getId();
            const t = privateRequestAnimationFrame(() => {
                vCallback(0);
                delete wm[id];
            });
            wm[id] = t;
            return id;
        };
        const privateCancelAnimationFrame = window.cancelAnimationFrame;
        window.cancelAnimationFrame = function (id) {
            const t = wm[id];
            if (t) {
                privateCancelAnimationFrame(t);
                delete wm[id];
            }
        };
    },
};
