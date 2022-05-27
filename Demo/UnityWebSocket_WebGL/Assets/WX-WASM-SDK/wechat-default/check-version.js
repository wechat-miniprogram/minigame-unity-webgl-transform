const { version, SDKVersion, platform, renderer, system } =
    wx.getSystemInfoSync()

function compareVersion(v1, v2) {
    return (
        v1
            .split(".")
            .map((v) => v.padStart(2, "0"))
            .join("") >=
        v2
            .split(".")
            .map((v) => v.padStart(2, "0"))
            .join("")
    )
}

const isPc = platform === "windows"
const isDevtools = platform === "devtools"
const isMobile = !isPc && !isDevtools
// 是否iOSH5模式
const isH5Renderer = isMobile && renderer === "h5"
// 操作系统版本号
const systemVersionArr = system ? system.split(" ") : []
const systemVersion = systemVersionArr.length
    ? systemVersionArr[systemVersionArr.length - 1]
    : ""

// pc微信版本号不一致，需要>=3.3
const isPcWeChatVersionValid = compareVersion(version, "3.3")
// 支持unity小游戏，需要基础库>=2.14.0，但低版本基础库iOS存在诸多问题，将版本最低版本提高到2.17.0
const isLibVersionValid = compareVersion(SDKVersion, "2.17.0")
// 如果是iOSH5，基础库需要>=2.19.1
const isH5LibVersionValid = compareVersion(SDKVersion, "2.19.1")
// iOSH5模式，支持wss的基础库版本>=2.21.1
const isWssLibVersionValid = compareVersion(SDKVersion, "2.21.1")
// 压缩纹理需要iOS系统版本>=14.0，检测到不支持压缩纹理时会提示升级系统
const isIOSH5SystemVersionValid = compareVersion(systemVersion, "14.0")

// 是否能以iOSH5模式运行
const canUseH5Renderer = (GameGlobal.canUseH5Renderer =
    isH5Renderer && isH5LibVersionValid)

// pc微信版本不满足要求
const isPcInvalid = isPc && !isPcWeChatVersionValid
// 移动设备基础库版本或客户端版本不支持运行unity小游戏
const isMobileInvalid = isMobile && !isLibVersionValid
// 基础库不支持iOSH5
const isIOSH5Invalid = isH5Renderer && !isH5LibVersionValid

// 视情况添加，没用到对应能力就不需要判断
// 是否用了wss
const useWss = false
// 是否只能iOS高档机运行
const disableFallback = false
// iOSH5模式基础库不支持wss
const isWssNotEnable = canUseH5Renderer && !isWssLibVersionValid && useWss
// 压缩纹理需要iOS系统版本>=14.0，检测到不支持压缩纹理时会提示升级系统
const isH5SystemVersionInvalid =
    canUseH5Renderer && !isIOSH5SystemVersionValid && disableFallback

/**
 * 判断环境是否可使用coverview
 * coverview实际需要基础库版本>=2.16.1，但因为移动端要>=2.17.0才能运行，所以移动端基本都支持coverview
 *
 * @export
 * @returns
 */
export function canUseCoverview() {
    return isMobile
}

export default () => {
    return new Promise((resolve, reject) => {
        if (!isDevtools) {
            if (
                isPcInvalid ||
                isMobileInvalid ||
                isIOSH5Invalid ||
                isWssNotEnable ||
                isH5SystemVersionInvalid
            ) {
                wx.showModal({
                    title: "提示",
                    content: isH5SystemVersionInvalid
                        ? "当前操作系统版本过低\n请更新iOS系统后进行游戏"
                        : "当前微信版本过低\n请更新微信后进行游戏",
                    showCancel: false,
                    success(res) {
                        if (res.confirm) {
                            wx.exitMiniProgram({
                                success: (res) => {},
                            })
                        }
                    },
                })
                return resolve(false)
            }
        }
        return resolve(true)
    })
}
