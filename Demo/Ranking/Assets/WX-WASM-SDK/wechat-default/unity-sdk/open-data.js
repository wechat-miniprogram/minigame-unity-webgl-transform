// 调用 wx.getOpenDataContext 获得的实例
let cachedOpenDataContext;
let cachedSharedCanvas;
// 获取当前可用的开放数据域实例
function getOpenDataContext() {
  return cachedOpenDataContext || wx.getOpenDataContext();
}
// 获取当前可用的开放数据域 canvas
function getSharedCanvas() {
  return cachedSharedCanvas || getOpenDataContext().canvas;
}

let timerId;
let textureObject;
let textureId;
// 将 Unity 本来要渲染的 RawImage 的纹理替换成 sharedCanvas
function hookUnityRender() {
  if (!textureId) {
    return;
  }

  const GL = GameGlobal.manager.gameInstance.Module.GL;
  const gl = GL.currentContext.GLctx;
  if (!textureObject) {
    textureObject = gl.createTexture();

    gl.bindTexture(gl.TEXTURE_2D, textureObject);
    gl.texImage2D(
      gl.TEXTURE_2D,
      0,
      gl.RGBA,
      gl.RGBA,
      gl.UNSIGNED_BYTE,
      getSharedCanvas()
    );

    gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_MIN_FILTER, gl.LINEAR);
    gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_MAG_FILTER, gl.LINEAR);
    gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_WRAP_S, gl.CLAMP_TO_EDGE);
    gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_WRAP_T, gl.CLAMP_TO_EDGE);
  } else {
    // 仅仅需要刷新纹理不需要设置纹理参数
    gl.bindTexture(gl.TEXTURE_2D, textureObject);
    gl.texImage2D(
      gl.TEXTURE_2D,
      0,
      gl.RGBA,
      gl.RGBA,
      gl.UNSIGNED_BYTE,
      getSharedCanvas()
    );
  }

  GL.textures[textureId] = textureObject;

  timerId = requestAnimationFrame(hookUnityRender);
}

// 排行榜关系，终止 hook 的渲染循环
function stopLastRenderLoop() {
  // 终止上次的循环
  if (typeof timerId !== "undefined") {
    cancelAnimationFrame(timerId);
  }
}

function startHookUnityRender() {
  stopLastRenderLoop();

  hookUnityRender();
}

function stopHookUnityRender() {
  stopLastRenderLoop();

  // 将开放数据域的纹理尺寸缩小
  const sharedCanvas = getSharedCanvas();
  sharedCanvas.width = 1;
  sharedCanvas.height = 1;

  // 将sharedCanvas对应的纹理从 GPU 删除，否则二次打开可能会现纹理异常
  const GL = GameGlobal.manager.gameInstance.Module.GL;
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
      console.error(
        "[unity-sdk]: WXShowOpenData要求 width 和 height 参数必须大于0"
      );
    }

    // 初始化小游戏的开放数据域
    const openDataContext = getOpenDataContext();
    const sharedCanvas = openDataContext.canvas;
    sharedCanvas.width = width;
    sharedCanvas.height = height;

    openDataContext.postMessage({
      type: "WXRender",
      x: x,
      y: y,
      width: width,
      height: height,
      devicePixelRatio: window.devicePixelRatio,
    });

    textureId = id;
    startHookUnityRender();
  },
  WXHideOpenData() {
    getOpenDataContext().postMessage({
      type: "WXDestroy",
    });

    stopHookUnityRender();
  },
};

