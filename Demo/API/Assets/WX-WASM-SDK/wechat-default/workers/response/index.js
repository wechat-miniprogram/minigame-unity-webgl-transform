// 消息类型
const messageType = {
  config: 0, // 检查是否支持worker写文件
  writeFile: 1, // 写文件
}

const fs = worker.getFileSystemManager ? worker.getFileSystemManager() : null;
const createSharedArrayBuffer = worker.createSharedArrayBuffer;

function compareVersion(_v1, _v2) {
  return (
    _v1
      .split('.')
      .map((v) => v.padStart(2, '0'))
      .join('') >=
    _v2
      .split('.')
      .map((v) => v.padStart(2, '0'))
      .join('')
  );
}

worker.onMessage((res) => {
  const {type, payload} = res;
  if (type === messageType.writeFile) {
    const {filePath, data, isSharedBuffer} = payload
    let content = data
    if (isSharedBuffer) {
      content = data.buffer
    }
    fs.writeFile({
      filePath,
      data: content,
      success: () => {
        worker.postMessage({
          type: messageType.writeFile,
          payload: {
            isok: true,
            filePath,
          }
        })
      },
      fail: err => {
        worker.postMessage({
          type: messageType.writeFile,
          payload: {
            isok: false,
            filePath,
            err
          }
        })
      }
    })
  }
  if (type === messageType.config) {
    const {systemInfo} = payload
    const {platform, version} = systemInfo

    // 安卓才需要使用worker写文件
    const isAndroid = platform.toLocaleLowerCase() === 'android'
    // 8.0.18以下版本出现写文件报错
    const isClientValid = compareVersion(version, '8.0.18')

    worker.postMessage({
      type: messageType.config,
      payload: {
        supportWorkerFs: isAndroid && !!fs && isClientValid,
        supportSharedBuffer: isAndroid && !!createSharedArrayBuffer,
      }
    })
  }
})

