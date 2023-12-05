// 消息类型
const messageType = {
    config: 0,
    writeFile: 1, // 写文件
};
// @ts-ignore SDK实际有暴露这几个API，但是协议里没有
const { createSharedArrayBuffer, getFileSystemManager } = worker;
const fs = getFileSystemManager ? getFileSystemManager() : null;
function compareVersion(_v1, _v2) {
    return (_v1
        .split('.')
        .map(v => v.padStart(2, '0'))
        .join('')
        >= _v2
            .split('.')
            .map(v => v.padStart(2, '0'))
            .join(''));
}
worker.onMessage((res) => {
    const { type, payload } = res;
    if (type === messageType.writeFile) {
        const { filePath, data, isSharedBuffer } = payload;
        let content = data;
        if (isSharedBuffer) {
            content = data.buffer;
        }
        if (!fs) {
            console.error('getFileSystemManager不存在');
            return;
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
                    },
                });
            },
            fail: (err) => {
                worker.postMessage({
                    type: messageType.writeFile,
                    payload: {
                        isok: false,
                        filePath,
                        err,
                    },
                });
            },
        });
    }
    if (type === messageType.config) {
        const { systemInfo } = payload;
        const { platform, version } = systemInfo;
        // 安卓才需要使用worker写文件
        const isAndroid = platform.toLocaleLowerCase() === 'android';
        // 8.0.18以下版本出现写文件报错
        const isClientValid = compareVersion(version, '8.0.18');
        worker.postMessage({
            type: messageType.config,
            payload: {
                supportWorkerFs: isAndroid && !!fs && isClientValid,
                supportSharedBuffer: isAndroid && !!createSharedArrayBuffer,
            },
        });
    }
});
