export default {
  WXReportGameStart() {
    GameGlobal.manager.reportCustomLaunchInfo();
  },
  WXSetGameStage(stageType) {
    if (GameGlobal.manager && GameGlobal.manager.setGameStage) {
      GameGlobal.manager.setGameStage(stageType);
    }
  },
  WXReportGameStageCostTime(ms, extInfo) {
    if (GameGlobal.manager && GameGlobal.manager.reportGameStageCostTime) {
      GameGlobal.manager.reportGameStageCostTime(ms, extInfo);
    }
  },
  WXReportGameStageError(errorType, errStr, extInfo) {
    if (GameGlobal.manager && GameGlobal.manager.reportGameStageError) {
      GameGlobal.manager.reportGameStageError(errorType, errStr, extInfo);
    }
  },
  WXWriteLog(str) {
    if (GameGlobal.manager && GameGlobal.manager.writeLog) {
      GameGlobal.manager.writeLog(str);
    }
  },
  WXWriteWarn(str) {
    if (GameGlobal.manager && GameGlobal.manager.writeWarn) {
      GameGlobal.manager.writeWarn(str);
    }
  },
  WXHideLoadingPage() {
    if (GameGlobal.manager && GameGlobal.manager.hideLoadingPage) {
      GameGlobal.manager.hideLoadingPage();
    }
  },
  WXReportUserBehaviorBranchAnalytics(branchId, branchDim, eventType){
    wx.reportUserBehaviorBranchAnalytics(branchId, branchDim, eventType);
    
  },
  WXPreloadConcurrent(count) {
    if (GameGlobal.manager && GameGlobal.manager.setConcurrent) {
      GameGlobal.manager.setConcurrent(count)
    }
  },
  WXIsCloudTest() {
    if (typeof GameGlobal.isTest !== "undefined" && GameGlobal.isTest ) { 
      return true;
    }
    return false;
  },
  WXUncaughtException(needAbort) {
    function currentStackTrace() {
      var err = new Error('WXUncaughtException');
      return err
    }
    let err = currentStackTrace();
    let fullTrace = err.stack.toString()
    let posOfThisFunc = fullTrace.indexOf('WXUncaughtException')
    if (posOfThisFunc != -1) fullTrace = fullTrace.substr(posOfThisFunc);
    let posOfRaf = fullTrace.lastIndexOf("browserIterationFunc");
    if (posOfRaf != -1) fullTrace = fullTrace.substr(0, posOfRaf);
    const realTimelog = wx.getRealtimeLogManager();
    realTimelog.error(fullTrace)
    const logmanager = wx.getLogManager()
    logmanager.warn(fullTrace)
    if (needAbort === true) {
      GameGlobal.onCrash(err);
      throw err;
    } else {
      setTimeout(() => {
        throw err;
      }, 0);
    }
  },
  WXCleanAllFileCache() {
    if (GameGlobal.manager && GameGlobal.manager.cleanAllCache) {
      return GameGlobal.manager.cleanAllCache()
    }
    return false;
  }
}