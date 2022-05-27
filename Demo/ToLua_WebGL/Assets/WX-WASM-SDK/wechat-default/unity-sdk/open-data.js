import response from "./response";

let needRenderOpenData = false;
let textureId= '';
let runningTaskId = 0;
let textureObject;
function createTextureByImgObject(){
    var webgl = GameGlobal.manager.gameInstance.Module.GL.currentContext.GLctx;
    let openDataContext = wx.getOpenDataContext();
    let sharedCanvas = openDataContext.canvas;
    if(!textureObject){
        textureObject = webgl.createTexture();
    }
    webgl.bindTexture(webgl.TEXTURE_2D, textureObject);
    webgl.texImage2D(webgl.TEXTURE_2D, 0, webgl.RGBA, webgl.RGBA, webgl.UNSIGNED_BYTE, sharedCanvas);
    webgl.texParameteri(webgl.TEXTURE_2D, webgl.TEXTURE_MIN_FILTER, webgl.LINEAR);
    webgl.texParameteri(webgl.TEXTURE_2D, webgl.TEXTURE_MAG_FILTER, webgl.LINEAR);
    webgl.texParameteri(webgl.TEXTURE_2D, webgl.TEXTURE_WRAP_S, webgl.CLAMP_TO_EDGE);
    webgl.texParameteri(webgl.TEXTURE_2D, webgl.TEXTURE_WRAP_T, webgl.CLAMP_TO_EDGE);
    return textureObject;
}
export default {
    WXDataContextPostMessage(msg){
        var openDataContext = wx.getOpenDataContext();
        openDataContext.postMessage(msg);
    },
    WXShowOpenData(id,x,y,width,height){
        const taskId = new Date().getTime();
        runningTaskId = taskId; //这里保存一个id是为了避免两次
        let openDataContext = wx.getOpenDataContext();
        let sharedCanvas = openDataContext.canvas;
        sharedCanvas.width = width;
        sharedCanvas.height = height;
        openDataContext.postMessage({
            type:"WXRender",
            x: x,
            y: y,
            width: width,
            height:  height,
            devicePixelRatio:window.devicePixelRatio
        });
        const manager = GameGlobal.manager;
        needRenderOpenData = true;
        renderTexture();
        textureId = id;
        function renderTexture(){
            if(needRenderOpenData && runningTaskId === taskId){
                manager.gameInstance.Module.GL.textures[id] = createTextureByImgObject();
                manager.gameInstance.Module.requestAnimationFrame(renderTexture);
            }
        }
    },
    WXHideOpenData(){
        needRenderOpenData = false;
        let openDataContext = wx.getOpenDataContext();
        let sharedCanvas = openDataContext.canvas;
        openDataContext.postMessage({
            type:"WXDestroy"
        });
        sharedCanvas.width = 10;
        sharedCanvas.height = 10;
        manager.gameInstance.Module.GL.textures[textureId] = createTextureByImgObject();
        textureObject = null;
    },
}
