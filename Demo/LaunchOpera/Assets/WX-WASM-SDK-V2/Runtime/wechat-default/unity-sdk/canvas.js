import response from './response';
import moduleHelper from './module-helper';
import { formatJsonStr } from './utils';
function getDefaultData(canvas, conf) {
    const config = formatJsonStr(conf);
    if (typeof config.x === 'undefined') {
        config.x = 0;
    }
    if (typeof config.y === 'undefined') {
        config.y = 0;
    }
    if (typeof config.width === 'undefined' || config.width === 0) {
        config.width = canvas.width;
    }
    if (typeof config.height === 'undefined' || config.height === 0) {
        config.height = canvas.height;
    }
    if (typeof config.destWidth === 'undefined' || config.destWidth === 0) {
        config.destWidth = canvas.width;
    }
    if (typeof config.destHeight === 'undefined' || config.destHeight === 0) {
        config.destHeight = canvas.height;
    }
    return config;
}
export default {
    WXToTempFilePathSync(conf) {
        return canvas.toTempFilePathSync(getDefaultData(canvas, conf));
    },
    WXToTempFilePath(conf, s, f, c) {
        if (conf) {
            canvas.toTempFilePath({
                ...getDefaultData(canvas, conf),
                ...response.handleText(s, f, c),
                success: (res) => {
                    moduleHelper.send('ToTempFilePathCallback', JSON.stringify({
                        callbackId: s,
                        errMsg: res.errMsg,
                        errCode: res.errCode || 0,
                        tempFilePath: res.tempFilePath,
                    }));
                },
            });
        }
    },
};
