import moduleHelper from './module-helper';
import { formatJsonStr, getListObject, uid } from './utils';
const gameClubButtonList = {};
const typeEnum = {
    0: 'text',
    1: 'image',
};
const iconEnum = {
    0: 'green',
    1: 'white',
    2: 'dark',
    3: 'light',
};
const getObject = getListObject(gameClubButtonList, 'gameClubButton');
export default {
    WXCreateGameClubButton(conf) {
        const config = formatJsonStr(conf);
        
        config.style = JSON.parse(config.styleRaw);
        if (config.style.fontSize === 0) {
            
            config.style.fontSize = undefined;
        }
        
        config.type = typeEnum[config.type];
        
        config.icon = iconEnum[config.icon];
        const id = uid();
        gameClubButtonList[id] = wx.createGameClubButton(config);
        return id;
    },
    WXGameClubButtonDestroy(id) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        obj.destroy();
        if (gameClubButtonList) {
            delete gameClubButtonList[id];
        }
    },
    WXGameClubButtonHide(id) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        obj.hide();
    },
    WXGameClubButtonShow(id) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        obj.show();
    },
    WXGameClubButtonAddListener(id, key) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        obj[key](() => {
            moduleHelper.send('OnGameClubButtonCallback', JSON.stringify({
                callbackId: id,
                errMsg: key,
            }));
        });
    },
    WXGameClubButtonRemoveListener(id, key) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        obj[key]();
    },
    
    WXGameClubButtonSetProperty(id, key, value) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        obj[key] = value;
    },
    
    WXGameClubStyleChangeInt(id, key, value) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        obj.style[key] = value;
    },
    
    WXGameClubStyleChangeStr(id, key, value) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        obj.style[key] = value;
    },
};
