//用来修复一些unity跟小游戏的差异问题

export default {
    init(){
        this.fixTimer();
    },
    //基础库现在返回的id都是固定值了，会导致unity拿到的id有问题，所以这里做个中间映射
    fixTimer(){
        const wm = {};
        let _setTimeout = window.setTimeout;
        let id = 0;
        const getId = function(){
            id++;
            if(id>100000000){
                id = 0;
            }
            return id;
        };
        window.setTimeout = function(vCallback, nDelay){
            let aArgs = Array.prototype.slice.call(arguments, 2);
            let id = getId();
            let t = _setTimeout(vCallback instanceof Function ? function() {
                vCallback.apply(null, aArgs);
                delete wm[id];
            } : vCallback, nDelay);
            wm[id] = t;
            return id;
        };
        let _clearTimeout = window.clearTimeout;
        window.clearTimeout = function(id){
            let t = wm[id];
            if(t){
                _clearTimeout(t);
                delete wm[id];
            }
        };

        let _setInterval = window.setInterval;
        window.setInterval = function(vCallback, nDelay){
            let aArgs = Array.prototype.slice.call(arguments, 2);
            let id = getId();
            let t = _setInterval(vCallback instanceof Function ? function() {
                vCallback.apply(null, aArgs);
            } : vCallback, nDelay);
            wm[id] = t;
            return id;
        };
        let _clearInterval = window.clearInterval;
        window.clearInterval = function(id){
            let t = wm[id];
            if(t){
                _clearInterval(t);
                delete wm[id];
            }
        };

        let _requestAnimationFrame = window.requestAnimationFrame;
        window.requestAnimationFrame = function(vCallback){
            let id = getId();
            let t = _requestAnimationFrame(function (){
                vCallback();
                delete wm[id];
            });
            wm[id] = t;
            return id;
        }
        let _cancelAnimationFrame = window.cancelAnimationFrame;
        window.cancelAnimationFrame = function(id){
            let t = wm[id];
            if(t){
                _cancelAnimationFrame(t);
                delete wm[id];
            }
        };
    }
}
