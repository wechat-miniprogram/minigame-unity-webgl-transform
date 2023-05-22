import { formatJsonStr, formatResponse } from './utils';
import moduleHelper from './module-helper';
export default {
  WXReportScene(conf, callbackId) {
    const config = formatJsonStr(conf);
    if (wx.reportScene) {
      if (GameGlobal.manager && GameGlobal.manager.setGameStage) {
        GameGlobal.manager.setGameStage(config.sceneId);
      }
      wx.reportScene({
        ...config,
        success(res) {
          formatResponse('GeneralCallbackResult', res);
          moduleHelper.send('ReportSceneCallback', JSON.stringify({
            callbackId, type: 'success', res: JSON.stringify(res),
          }));
        },
        fail(res) {
          formatResponse('GeneralCallbackResult', res);
          moduleHelper.send('ReportSceneCallback', JSON.stringify({
            callbackId, type: 'fail', res: JSON.stringify(res),
          }));
        },
        complete(res) {
          formatResponse('GeneralCallbackResult', res);
          moduleHelper.send('ReportSceneCallback', JSON.stringify({
            callbackId, type: 'complete', res: JSON.stringify(res),
          }));
        },
      });
    }
  },
};
