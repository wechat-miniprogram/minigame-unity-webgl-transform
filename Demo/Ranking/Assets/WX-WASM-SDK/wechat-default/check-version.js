const { version, SDKVersion, platform, renderer } = wx.getSystemInfoSync()

function compareVersion(v1, v2) {
  v1 = v1.split('.')
  v2 = v2.split('.')
  const len = Math.max(v1.length, v2.length)

  while (v1.length < len) {
    v1.push('0')
  }
  while (v2.length < len) {
    v2.push('0')
  }

  for (let i = 0; i < len; i++) {
    const num1 = parseInt(v1[i])
    const num2 = parseInt(v2[i])

    if (num1 > num2) {
      return true
    } else if (num1 < num2) {
      return false
    }
  }

  return true
}

/**
 * 判断环境是否可使用coverview
 *
 * @export
 * @returns
 */
export function canUseCoverview() {
  // coverview在基础库>=2.16.1开始支持
  return compareVersion(SDKVersion, '2.16.1') && platform !== 'windows'
}

const isH5Renderer = renderer === 'h5'
const isH5ValidLibVersion = compareVersion(SDKVersion, '2.19.1')
// 如果是h5，基础库需要>=2.19.1
GameGlobal.canUseH5Renderer = isH5Renderer && isH5ValidLibVersion

export default () => {
  return new Promise((resolve, reject) => {
    // 微信版本须>=7.0.19，基础库版本>=2.14.0，开发者工具除外
    if (platform !== 'devtools') {
      if (!compareVersion(version, '7.0.19') || !compareVersion(SDKVersion, '2.14.0') || (isH5Renderer && !isH5ValidLibVersion)) {
        wx.showModal({
          title: '提示',
          content: '当前微信版本过低\n请更新微信后进行游戏',
          showCancel: false,
          success(res) {
            if (res.confirm) {
              wx.exitMiniProgram({
                success: (res) => {},
              })
            }
          }
        })
        return resolve(false);
      }

    }
    return resolve(true)
  })
}