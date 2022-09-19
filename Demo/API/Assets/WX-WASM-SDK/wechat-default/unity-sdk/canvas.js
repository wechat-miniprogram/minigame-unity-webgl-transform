import response from './response';
import moduleHelper from './module-helper';

export default {
  WXToTempFilePathSync(conf) {
    return canvas.toTempFilePathSync(JSON.parse(conf));
  },
  WXToTempFilePath(conf, s, f, c) {
    canvas.toTempFilePath({
      ...JSON.parse(conf),
      ...response.handleText(s, f, c),
      success: (res) => {
        moduleHelper.send('ToTempFilePathCallback', JSON.stringify({
          callbackId: s,
          errMsg: res.errMsg,
          errCode: res.errCode,
          tempFilePath: res.tempFilePath,
        }));
      },
    });
  },
};
