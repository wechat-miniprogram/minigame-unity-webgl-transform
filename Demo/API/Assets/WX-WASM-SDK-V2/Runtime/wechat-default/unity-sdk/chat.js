import moduleHelper from './module-helper';
import { formatJsonStr, uid } from './utils';

let MiniGameChat;

let instance;

let onList;
function createMiniGameChat(options, callback) {
    try {
        if (typeof requirePlugin !== 'undefined') {
            if (!MiniGameChat) {
                
                MiniGameChat = requirePlugin('MiniGameChat', {
                    enableRequireHostModule: true,
                    customEnv: {
                        wx,
                    },
                }).default;
            }
            if (instance) {
                return '';
            }
            instance = new MiniGameChat(options);
            if (typeof instance === 'undefined' || typeof instance.on === 'undefined') {
                
                console.error('MiniGameChat create error');
                return '';
            }
            // 等待插件初始化完成
            instance.on('ready', () => {
                if (!GameGlobal.miniGameChat) {
                    GameGlobal.miniGameChat = instance;
                    if (!onList) {
                        onList = {};
                    }
                    
                    Object.keys(onList).forEach((eventType) => {
                        if (!onList) {
                            onList = {};
                        }
                        Object.values(onList[eventType]).forEach((callback) => {
                            instance.on(eventType, callback);
                        });
                    });
                    instance.emit('ready');
                    callback(instance);
                }
            });
            instance.on('error', (err) => {
                console.log('插件初始化失败', err);
            });
            return uid();
        }
    }
    catch (e) {
        
        console.error(e);
        
        return '';
    }
}
export default {
    WXChatCreate(optionsStr) {
        const options = formatJsonStr(optionsStr);
        return createMiniGameChat({
            x: options.x,
            y: options.y,
            autoShow: false,
            logoUrl: options.logoUrl || '',
            movable: options.movable,
            enableSnap: options.enableSnap,
            scale: options.scale,
        }, (instance) => {
            instance.on('error', (err) => {
                console.error('error', err);
            });
        });
    },
    WXChatHide() {
        if (!GameGlobal.miniGameChat) {
            return;
        }
        GameGlobal.miniGameChat.hide();
    },
    WXChatShow(optionsStr) {
        if (!GameGlobal.miniGameChat) {
            return;
        }
        const options = formatJsonStr(optionsStr);
        GameGlobal.miniGameChat.show({
            x: options.x,
            y: options.y,
        });
    },
    WXChatClose() {
        if (!GameGlobal.miniGameChat) {
            return;
        }
        GameGlobal.miniGameChat.close();
    },
    WXChatOpen(key) {
        if (!GameGlobal.miniGameChat) {
            return;
        }
        GameGlobal.miniGameChat.open(key || '');
    },
    WXChatSetTabs(keysStr) {
        if (!GameGlobal.miniGameChat) {
            return;
        }
        if (!keysStr) {
            // eslint-disable-next-line no-param-reassign
            keysStr = '[]';
        }
        const keys = JSON.parse(keysStr);
        GameGlobal.miniGameChat.setTabs(keys);
    },
    WXChatOff(eventType) {
        const { miniGameChat } = GameGlobal;
        if (!miniGameChat) {
            return;
        }
        if (!miniGameChat || typeof onList === 'undefined' || typeof onList[eventType] === 'undefined') {
            return;
        }
        
        for (const key in Object.keys(onList[eventType])) {
            const callback = onList[eventType][key];
            if (callback) {
                miniGameChat.off(eventType, callback);
            }
        }
        onList[eventType] = {};
    },
    WXChatOn(eventType) {
        const callbackId = uid();
        const callback = (res) => {
            let result = '';
            if (res) {
                result = JSON.stringify(res);
            }
            const resStr = JSON.stringify({
                eventType,
                result,
            });
            moduleHelper.send('OnWXChatCallback', resStr);
        };
        if (!onList) {
            onList = {};
        }
        if (typeof onList[eventType] === 'undefined') {
            onList[eventType] = {};
        }
        if (onList[eventType]) {
            onList[eventType][callbackId] = callback;
            const { miniGameChat } = GameGlobal;
            if (miniGameChat) {
                miniGameChat.on(eventType, callback);
            }
            return callbackId;
        }
        return '';
    },
    WXChatSetSignature(signature) {
        const { miniGameChat } = GameGlobal;
        if (miniGameChat) {
            miniGameChat.setChatSignature({ signature });
        }
    },
};
