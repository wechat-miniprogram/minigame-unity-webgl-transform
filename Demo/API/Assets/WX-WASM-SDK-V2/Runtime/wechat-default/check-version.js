/* eslint-disable no-multi-assign */
/* eslint-disable @typescript-eslint/naming-convention */
const { version, SDKVersion, platform, system } = wx.getSystemInfoSync();
const accountInfo = wx.getAccountInfoSync();
const envVersion = accountInfo?.miniProgram?.envVersion;
function compareVersion(v1, v2) {
  if (!v1 || !v2) {
    return false;
  }
  return (v1
    .split('.')
    .map(v => v.padStart(2, '0'))
    .join('')
        >= v2
          .split('.')
          .map(v => v.padStart(2, '0'))
          .join(''));
}
export const isPc = platform === 'windows' || platform === 'mac';
export const isIOS = platform === 'ios';
export const isAndroid = platform === 'android';
export const isDevtools = platform === 'devtools';
export const isMobile = !isPc && !isDevtools;
export const isDevelop = envVersion === 'develop';
// 是否禁止**开通了高性能模式**的小游戏在不支持的iOS设备上回退成普通模式，回退可能导致无法正常体验游戏
const disableHighPerformanceFallback = $DISABLE_HIGHPERFORMANCE_FALLBACK && isIOS;
// 是否iOSH5模式
const isH5Renderer = GameGlobal.isIOSHighPerformanceMode;
// 操作系统版本号
const systemVersionArr = system ? system.split(' ') : [];
const systemVersion = systemVersionArr.length ? systemVersionArr[systemVersionArr.length - 1] : '';
// pc微信版本号不一致，需要>=3.3
const isPcWeChatVersionValid = compareVersion(version, '3.3');
// 支持unity小游戏，需要基础库>=2.14.0，但低版本基础库iOS存在诸多问题，将版本最低版本提高到2.17.0
const isLibVersionValid = compareVersion(SDKVersion, '2.17.0');
// 如果是iOSH5，基础库需要>=2.19.1
const isH5LibVersionValid = compareVersion(SDKVersion, '2.19.1');
// iOSH5模式，支持wss的基础库版本>=2.21.1
const isWssLibVersionValid = compareVersion(SDKVersion, '2.21.1');
// 压缩纹理需要iOS系统版本>=14.0，检测到不支持压缩纹理时会提示升级系统
const isIOSH5SystemVersionValid = compareVersion(systemVersion, '14.0');
// iOS系统版本>=15支持webgl2
const isIOSWebgl2SystemVersionValid = compareVersion(systemVersion, '15.0');
// 是否用了webgl2
const isWebgl2 = () => GameGlobal.managerConfig.contextConfig.contextType === 2;
// 是否支持BufferURL
export const isSupportBufferURL = !isPc
    && (isH5Renderer
      ? compareVersion(SDKVersion, '2.29.1') && compareVersion(version, '8.0.30')
      : typeof wx.createBufferURL === 'function');
// 安卓innerAudio支持playbackRate
export const isSupportPlayBackRate = !isAndroid || compareVersion(version, '8.0.23');
// IOS innerAudio支持复用时再次触发onCanplay
export const isSupportCacheAudio = !isIOS || compareVersion(version, '8.0.31');
// 是否能以iOSH5模式运行
const canUseH5Renderer = (GameGlobal.canUseH5Renderer = isH5Renderer && isH5LibVersionValid);
// pc微信版本不满足要求
const isPcInvalid = isPc && !isPcWeChatVersionValid;
// 移动设备基础库版本或客户端版本不支持运行unity小游戏
const isMobileInvalid = isMobile && !isLibVersionValid;
// 基础库/客户端不支持iOSH5
const isIOSH5Invalid = (isH5Renderer && !isH5LibVersionValid) || (!isH5Renderer && disableHighPerformanceFallback);
// 视情况添加，没用到对应能力就不需要判断
// 是否用了wss
const useWss = false;
// iOSH5模式基础库不支持wss
const isWssNotEnable = canUseH5Renderer && !isWssLibVersionValid && useWss;
// 是否支持webgl2
const isWebgl2SystemVersionInvalid = () => isIOS && isWebgl2() && !isIOSWebgl2SystemVersionValid;
// 2.25.3以上基础库需要手动启动webAudio
export const webAudioNeedResume = compareVersion(SDKVersion, '2.25.3');
// 满足iOS高性能条件，但未开通高性能模式
const needToastEnableHpMode = isDevelop && isIOS && isH5LibVersionValid && isIOSH5SystemVersionValid && !isH5Renderer;
/**
 * 判断环境是否可使用coverview
 * coverview实际需要基础库版本>=2.16.1，但因为移动端要>=2.17.0才能运行，所以移动端基本都支持coverview
 *
 * @export
 * @returns
 */
export function canUseCoverview() {
  return isMobile || isDevtools;
}
if (needToastEnableHpMode) {
  console.error('此AppID未开通高性能模式\n请前往mp后台-能力地图-开发提效包-高性能模式开通\n可大幅提升游戏运行性能');
  // setTimeout(() => {
  //   wx.showModal({
  //     title: '[开发版提示]建议',
  //     content: '此AppID未开通高性能模式\n请前往mp后台-能力地图-开发提效包-高性能模式开通\n可大幅提升游戏运行性能',
  //     showCancel: false,
  //   })
  // }, 10000);
}
export default () => new Promise((resolve) => {
  if (!isDevtools) {
    if (isPcInvalid
            || isMobileInvalid
            || isIOSH5Invalid
            || isWssNotEnable
            || isWebgl2SystemVersionInvalid()) {
      let updateWechat = true;
      let content = '当前微信版本过低\n请更新微信后进行游戏';
      if (!isIOSH5SystemVersionValid || isWebgl2SystemVersionInvalid()) {
        content = '当前操作系统版本过低\n请更新iOS系统后进行游戏';
        updateWechat = false;
      }
      wx.showModal({
        title: '提示',
        content,
        showCancel: false,
        confirmText: updateWechat ? '更新微信' : '确定',
        success(res) {
          if (res.confirm) {
            const showUpdateWechat = updateWechat && typeof wx.createBufferURL === 'function';
            if (showUpdateWechat) {
              wx.updateWeChatApp();
            } else {
              wx.exitMiniProgram({
                success: () => { },
              });
            }
          }
        },
      });
      return resolve(false);
    }
  }
  return resolve(true);
});
