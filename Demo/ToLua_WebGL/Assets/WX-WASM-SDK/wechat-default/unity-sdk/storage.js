const PreLoadKeys = "$PreLoadKeys"; //Unity插件会替换这里，不要改这里

const storage = {
    _cacheData:{}, //缓存数据，避免同步操作带来的卡顿
    _handleList:[], //io队列，避免时序问题和同时大量的io操作
    isRunning:false,
    isCallDeletedAll:false,
    getData(key,defaultValue){
        var v = this._cacheData[key];
        if(v === null){
            return defaultValue;
        }
        if(typeof v!== 'undefined'){
            return v;
        }
        if(this.isCallDeletedAll){
            return defaultValue;
        }
        try {
            v = wx.getStorageSync(key);
            this._cacheData[key] = v !== "" ? v : null;
            return v === "" ? defaultValue : v;
        } catch (e) {
            console.error(e);
            return defaultValue;
        }
    },
    setData(key,value){
        this._cacheData[key] = value;
        this._handleList.push({
            type:"setData",
            key,
            value
        });
        this._doRun();
    },
    deleteKey(key){
        this._cacheData[key] = null;
        this._handleList.push({
            type:"deleteKey",
            key
        });
        this._doRun();
    },
    deleteAll(){
        for(let key in this._cacheData){
            this._cacheData[key] = null;
        }
        this.isCallDeletedAll = true;
        this._handleList.push({
            type:"deleteAll"
        });
        this._doRun();
    },
    _doRun(){
        if(this.isRunning || this._handleList.length === 0){
            return false;
        }
        this.isRunning = true;
        const task = this._handleList.shift();
        if(task.type === 'setData'){
            wx.setStorage({
                key:task.key,
                data:task.value,
                fail:function({errMsg}){
                    console.error(errMsg);
                },
                complete:()=>{
                    this.isRunning = false;
                    this._doRun();
                }
            });
        }else if(task.type === 'deleteKey'){
            wx.removeStorage({
                key:task.key,
                fail:function({errMsg}){
                    console.error(errMsg);
                },
                complete:()=>{
                    this.isRunning = false;
                    this._doRun();
                }
            });
        }else if(task.type === 'deleteAll'){
            wx.clearStorage({
                fail:function({errMsg}){
                    console.error(errMsg);
                },
                complete:()=>{
                    this.isRunning = false;
                    this._doRun();
                }
            });
        }else{
            this.isRunning = false;
            this._doRun();
        }
    },
    init(){
        if(Array.isArray(PreLoadKeys) && PreLoadKeys.length>0){
            const key = PreLoadKeys.shift();
            wx.getStorage({
                key,
                success(res){
                    storage._cacheData[key] = res.data;
                    storage.init();
                },
                fail(){
                    storage._cacheData[key] = null;
                    storage.init();
                }
            });
        }
    }
};

setTimeout(()=>{
    storage.init();
},0);

export default {
    /*
       本地存储
     */
    WXStorageGetIntSync(key,defaultValue){
        return +storage.getData(key,defaultValue);
    },
    WXStorageSetIntSync(key,value){
        storage.setData(key,value);
    },
    WXStorageGetFloatSync(key,defaultValue){
        return +storage.getData(key,defaultValue);
    },
    WXStorageSetFloatSync(key,value){
        storage.setData(key,value);
    },
    WXStorageGetStringSync(key,defaultValue){
        return storage.getData(key,defaultValue) || '';
    },
    WXStorageSetStringSync(key,value){
        storage.setData(key,value);
    },
    WXStorageDeleteAllSync(){
        storage.deleteAll();
    },
    WXStorageDeleteKeySync(key){
        storage.deleteKey(key);
    },
    WXStorageHasKeySync(key){
        return storage.getData(key,'') !== '';
    }
}
