const events = [];
const EventsManager = {
    /**
     *  注册一个事件并持续监听
     *  @param eventName 事件名称
     *  @param callback 事件的触发函数
    */
    on(eventName, callback) {
        events.push({
            eventName,
            callback,
            once: false,
        });
    },
    /**
     *  注册一个事件并最多只触发一次
     *  @param eventName 事件名称
     *  @param callback 事件的触发函数
    */
    once(eventName, callback) {
        events.push({
            eventName,
            callback,
            once: true,
        });
    },
    /**
     *  卸载一个事件
     *  @param eventName 事件名称
     *  @param callback 事件句柄，若缺省将卸载所有同名事件
    */
    off(eventName, callback) {
        events.forEach((item, index) => {
            if (item.eventName === eventName) {
                if (!callback || item.callback === callback) {
                    events.splice(index, 1);
                }
            }
        });
    },
    emit(eventName, ...args) {
        const res = [];
        const indexs = [];
        events.forEach((item, index) => {
            if (item.eventName === eventName) {
                res.push(item.callback(...args));
                if (item.once) {
                    indexs.unshift(index);
                }
            }
        });
        indexs.forEach((value) => {
            events.splice(value, 1);
        });
        return res;
    },
};
GameGlobal.events = EventsManager;
