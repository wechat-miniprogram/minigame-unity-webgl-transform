import {moduleName} from "./conf";

export default {
    _send:null,
    init(){
        this._send = GameGlobal.Module.SendMessage;
    },
    send(method,str){
        if(!this._send){
            this.init();
        }
        this._send(moduleName,method,str);
    }
}