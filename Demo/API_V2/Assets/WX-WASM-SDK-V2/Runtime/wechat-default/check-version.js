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
// @ts-ignore
const disableHighPerformanceFallback = $DISABLE_HIGHPERFORMANCE_FALLBACK && isIOS;
// 是否iOS高性能模式
export const isH5Renderer = GameGlobal.isIOSHighPerformanceMode;
// 操作系统版本号
const systemVersionArr = system ? system.split(' ') : [];
const systemVersion = systemVersionArr.length ? systemVersionArr[systemVersionArr.length - 1] : '';
// pc微信版本号不一致，需要>=3.3
const isPcWeChatVersionValid = compareVersion(version, '3.3');
// 支持unity小游戏，需要基础库>=2.14.0，但低版本基础库iOS存在诸多问题，将版本最低版本提高到2.17.0
const isLibVersionValid = compareVersion(SDKVersion, '2.17.0');
// 如果是iOS高性能模式，基础库需要>=2.23.1
const isH5LibVersionValid = compareVersion(SDKVersion, '2.23.1');
// 压缩纹理需要iOS系统版本>=14.0，检测到不支持压缩纹理时会提示升级系统
const isIOSH5SystemVersionValid = compareVersion(systemVersion, '14.0');
// iOS系统版本>=15支持webgl2，高性能模式+无此系统要求
const isIOSWebgl2SystemVersionValid = compareVersion(systemVersion, '15.0') || GameGlobal.isIOSHighPerformanceModePlus;
// Android客户端版本>=8.0.19支持webgl2
const isAndroidWebGL2ClientVersionValid = compareVersion(version, '8.0.19');
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
// // 安卓旧客户端版本innerAudio偶现会导致闪退，大于等于8.0.38才使用innerAudio减少内存
export const isSupportInnerAudio = compareVersion(version, '8.0.38');
// 检查是否支持brotli压缩，pc基础库>=2.29.2，真机基础库>=2.21.1
// @ts-ignore
const isPcBrotliInvalid = isPc && !compareVersion(SDKVersion, $LOAD_DATA_FROM_SUBPACKAGE ? '2.29.2' : '2.32.3');
const isMobileBrotliInvalid = isMobile && !compareVersion(SDKVersion, '2.21.1');
// @ts-ignore
const isBrotliInvalid = $COMPRESS_DATA_PACKAGE && (isPcBrotliInvalid || isMobileBrotliInvalid);
// 是否能以iOS高性能模式运行
// 请勿修改GameGlobal.canUseH5Renderer赋值！！！
GameGlobal.canUseH5Renderer = isH5Renderer && isH5LibVersionValid;
// iOS高性能模式定期GC
GameGlobal.canUseiOSAutoGC = isH5Renderer && compareVersion(SDKVersion, '2.32.1');
// pc微信版本不满足要求
const isPcInvalid = isPc && !isPcWeChatVersionValid;
// 移动设备基础库版本或客户端版本不支持运行unity小游戏
const isMobileInvalid = isMobile && !isLibVersionValid;
// 基础库/客户端不支持iOS高性能模式
const isIOSH5Invalid = (isH5Renderer && !isH5LibVersionValid) || (!isH5Renderer && disableHighPerformanceFallback);
// 是否支持VideoPlayer组件，注意：开发者工具需要1.06.2310312以上版本
export const isSupportVideoPlayer = (isIOS && compareVersion(SDKVersion, '3.1.1')) || (isAndroid && compareVersion(SDKVersion, '3.0.0')) || ((isPc || isDevtools) && compareVersion(SDKVersion, '3.2.1'));
// 视情况添加，没用到对应能力就不需要判断
// 是否支持webgl2
const isWebgl2SystemVersionInvalid = () => isWebgl2() && ((!isIOSWebgl2SystemVersionValid && isIOS) || (isAndroid && !isAndroidWebGL2ClientVersionValid));
// IOS高性能模式2.25.3以上基础库需要手动启动webAudio
export const webAudioNeedResume = compareVersion(SDKVersion, '2.25.3') && isH5Renderer;
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
// @ts-ignore
if (isIOS && typeof $IOS_DEVICE_PIXEL_RATIO === 'number' && $IOS_DEVICE_PIXEL_RATIO > 0) {
    // @ts-ignore
    window.devicePixelRatio = $IOS_DEVICE_PIXEL_RATIO;
}
export default () => new Promise((resolve) => {
    if (!isDevtools) {
        if (isPcInvalid
            || isMobileInvalid
            || isIOSH5Invalid
            || isWebgl2SystemVersionInvalid()
            || isBrotliInvalid) {
            let updateWechat = true;
            let content = '当前微信版本过低\n请更新微信后进行游戏';
            if (isIOS) {
                if (!isIOSH5SystemVersionValid || (isWebgl2SystemVersionInvalid() && isIOS)) {
                    content = '当前操作系统版本过低\n请更新iOS系统后进行游戏';
                    updateWechat = false;
                }
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
                        }
                        else {
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
