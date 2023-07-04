
let cachedOpenDataContext;
let cachedSharedCanvas;

function getOpenDataContext() {
    return cachedOpenDataContext || wx.getOpenDataContext();
}

function getSharedCanvas() {
    return cachedSharedCanvas || getOpenDataContext().canvas;
}
let timerId;
let textureObject = null;
let textureId;

function hookUnityRender() {
    if (!textureId) {
        return;
    }
    const { GL } = GameGlobal.manager.gameInstance.Module;
    const gl = GL.currentContext.GLctx;
    if (!textureObject) {
        textureObject = gl.createTexture();
        gl.bindTexture(gl.TEXTURE_2D, textureObject);
        gl.texImage2D(gl.TEXTURE_2D, 0, gl.RGBA, gl.RGBA, gl.UNSIGNED_BYTE, getSharedCanvas());
        gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_MIN_FILTER, gl.LINEAR);
        gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_MAG_FILTER, gl.LINEAR);
        gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_WRAP_S, gl.CLAMP_TO_EDGE);
        gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_WRAP_T, gl.CLAMP_TO_EDGE);
    }
    else {
        
        gl.bindTexture(gl.TEXTURE_2D, textureObject);
        gl.texImage2D(gl.TEXTURE_2D, 0, gl.RGBA, gl.RGBA, gl.UNSIGNED_BYTE, getSharedCanvas());
    }
    GL.textures[textureId] = textureObject;
    timerId = requestAnimationFrame(hookUnityRender);
}

function stopLastRenderLoop() {
    
    if (typeof timerId !== 'undefined') {
        cancelAnimationFrame(timerId);
    }
}
function startHookUnityRender() {
    stopLastRenderLoop();
    hookUnityRender();
}
function stopHookUnityRender() {
    stopLastRenderLoop();
    
    const sharedCanvas = getSharedCanvas();
    sharedCanvas.width = 1;
    sharedCanvas.height = 1;
    
    const { GL } = GameGlobal.manager.gameInstance.Module;
    const gl = GL.currentContext.GLctx;
    gl.deleteTexture(textureObject);
    textureObject = null;
}
export default {
    WXDataContextPostMessage(msg) {
        getOpenDataContext().postMessage(msg);
    },
    WXShowOpenData(id, x, y, width, height) {
        if (width <= 0 || height <= 0) {
            console.error('[unity-sdk]: WXShowOpenData要求 width 和 height 参数必须大于0');
        }
        
        const openDataContext = getOpenDataContext();
        const sharedCanvas = openDataContext.canvas;
        sharedCanvas.width = width;
        sharedCanvas.height = height;
        openDataContext.postMessage({
            type: 'WXRender',
            x,
            y,
            width,
            height,
            devicePixelRatio: window.devicePixelRatio,
        });
        textureId = id;
        startHookUnityRender();
    },
    WXHideOpenData() {
        getOpenDataContext().postMessage({
            type: 'WXDestroy',
        });
        stopHookUnityRender();
    },
};
