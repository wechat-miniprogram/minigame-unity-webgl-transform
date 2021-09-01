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
  }
}