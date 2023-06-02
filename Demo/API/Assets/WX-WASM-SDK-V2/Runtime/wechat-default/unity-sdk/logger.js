let logger;
export default {
    WXLogManagerDebug(str) {
        if (!logger) {
            logger = wx.getLogManager({ level: 0 });
        }
        logger.debug(str);
    },
    WXLogManagerInfo(str) {
        if (!logger) {
            logger = wx.getLogManager({ level: 0 });
        }
        logger.info(str);
    },
    WXLogManagerLog(str) {
        if (!logger) {
            logger = wx.getLogManager({ level: 0 });
        }
        logger.log(str);
    },
    WXLogManagerWarn(str) {
        if (!logger) {
            logger = wx.getLogManager({ level: 0 });
        }
        logger.warn(str);
    },
};
