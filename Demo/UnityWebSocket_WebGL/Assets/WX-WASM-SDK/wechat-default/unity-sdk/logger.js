export default {
    WXLogManagerDebug(str){
        const logger = wx.getLogManager();
        logger.debug(str);
    },
    WXLogManagerInfo(str){
        const logger = wx.getLogManager();
        logger.info(str);
    },
    WXLogManagerLog(str){
        const logger = wx.getLogManager();
        logger.log(str);
    },
    WXLogManagerWarn(str){
        const logger = wx.getLogManager();
        logger.warn(str);
    }
};
