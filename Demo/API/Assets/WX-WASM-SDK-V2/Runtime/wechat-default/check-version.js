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


const disableHighPerformanceFallback = $DISABLE_HIGHPERFORMANCE_FALLBACK && isIOS;

const isH5Renderer = GameGlobal.isIOSHighPerformanceMode;

const systemVersionArr = system ? system.split(' ') : [];
const systemVersion = systemVersionArr.length ? systemVersionArr[systemVersionArr.length - 1] : '';
// pc微信版本号不一致，需要>=3.3
const isPcWeChatVersionValid = compareVersion(version, '3.3');

const isLibVersionValid = compareVersion(SDKVersion, '2.17.0');

const isH5LibVersionValid = compareVersion(SDKVersion, '2.19.1');

const isWssLibVersionValid = compareVersion(SDKVersion, '2.21.1');

const isIOSH5SystemVersionValid = compareVersion(systemVersion, '14.0');

const isIOSWebgl2SystemVersionValid = compareVersion(systemVersion, '15.0');

const isWebgl2 = () => GameGlobal.managerConfig.contextConfig.contextType === 2;

export const isSupportBufferURL = !isPc
    && (isH5Renderer
        ? compareVersion(SDKVersion, '2.29.1') && compareVersion(version, '8.0.30')
        : typeof wx.createBufferURL === 'function');

export const isSupportPlayBackRate = !isAndroid || compareVersion(version, '8.0.23');

export const isSupportCacheAudio = !isIOS || compareVersion(version, '8.0.31');

const canUseH5Renderer = (GameGlobal.canUseH5Renderer = isH5Renderer && isH5LibVersionValid);

const isPcInvalid = isPc && !isPcWeChatVersionValid;

const isMobileInvalid = isMobile && !isLibVersionValid;

const isIOSH5Invalid = (isH5Renderer && !isH5LibVersionValid) || (!isH5Renderer && disableHighPerformanceFallback);


const useWss = false;

const isWssNotEnable = canUseH5Renderer && !isWssLibVersionValid && useWss;

const isWebgl2SystemVersionInvalid = () => isIOS && isWebgl2() && !isIOSWebgl2SystemVersionValid;

export const webAudioNeedResume = compareVersion(SDKVersion, '2.25.3') && isH5Renderer;

const needToastEnableHpMode = isDevelop && isIOS && isH5LibVersionValid && isIOSH5SystemVersionValid && !isH5Renderer;
export function canUseCoverview() {
    return isMobile || isDevtools;
}
if (needToastEnableHpMode) {
    console.error('此AppID未开通高性能模式\n请前往mp后台-能力地图-开发提效包-高性能模式开通\n可大幅提升游戏运行性能');
    
    
    
    
    
    
    
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
