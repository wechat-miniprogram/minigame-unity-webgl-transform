const { exec } = require('child_process');
const fs = require('fs');
const Conf = require('./conf');
//最多同时调用8个子进程
const MaxThreadCount = 8;

//模拟信号量
const Semaphore = {
    _count:0,
    _waitList:[],
    waitOne(){
        return new Promise((resolve)=>{
            if(this._count < MaxThreadCount){
                this._count++;
                resolve();
            }else{
                this._waitList.push(resolve);
            }
        })
    },
    release(){
        this._count--;
        if(this._count<0){
            this._count = 0;
        }
        const resolve = this._waitList.shift();
        resolve && resolve();
    }
};

const Mod = {
    async start(){
        console.log("开始生成！");
        await this.startTextureTask();
        await this.startNotPot();
    },

    async startTextureTask(){
        for(let i=0;i<Conf.textureList.length;i++){
            let {p,w,h} = Conf.textureList[i];
            const backupPath = `${Conf.dst}/backup/${p}`;
            let dstPath = `${Conf.dst}/webgl/${p}`;
            const dir = dstPath.substring(0,dstPath.lastIndexOf('/'));
            if(!fs.existsSync(dir)){
                fs.mkdirSync(dir,{ recursive: true });
            }
            let src = backupPath;
            await this.png({
                src,
                dstPath:dstPath+".png",
                width:w,
                height:h,
                callback:async ()=>{
                    src = dstPath+".png";
                    await this.astc({
                        src,
                        dstPath:dstPath+".astc",
                    });
                    if(!Conf.isAstcOnly){
                        await this.etc2({
                            src,
                            dstPath:dstPath+".pkm"
                        });
                        if(w === h){
                            await this.pvrtc({
                                src,
                                dstPath:dstPath+".pvr"
                            });
                        }
                        await this.minPng({src});
                    }
                }
            });

        }
    },
    async startNotPot(){
        for(let i=0;i<Conf.noPotList.length;i++){
            let {p,w,h} = Conf.noPotList[i];
            const backupPath = `${Conf.dst}/backup/${p}`;
            let dstPath = `${Conf.dst}/webgl/${p}.png`;
            const dir = dstPath.substring(0,dstPath.lastIndexOf('/'));
            if(!fs.existsSync(dir)){
                fs.mkdirSync(dir,{ recursive: true });
            }
            let src = backupPath;
            await this.png({
                src,
                dstPath,
                width:w,
                height:h,
                callback:async ()=>{
                    src = dstPath;
                    await this.minPng({src});
                }
            });

        }
    },
    async png({src,dstPath,width,height,callback}){
        await Semaphore.waitOne();
        let quality = 65;
        if (Conf.qualityList != null && Conf.qualityList.length > 0)
        {
            Conf.qualityList.forEach(v=>{
                if(src.indexOf(v.path)>-1){
                    quality = v.Quality;
                }
            });
        }
        exec(`magick convert "${src}[0]" -quality ${quality} ${ /\.tga$/i.test(src)? '': '-flip'} -resize ${width}x${height}! "${dstPath}"`, (error, stdout, stderr) => {
            if (error) {
                console.error(`exec error: ${error}`);
            }
            callback();
            Semaphore.release();
        });
    },
    async astc({src,dstPath}){
        await Semaphore.waitOne();
        exec(`${Conf.dataPath}/WX-WASM-SDK/Editor/astcenc-avx2 -cs "${src}" "${dstPath}" 8x8 -medium`, (error, stdout, stderr) => {
            if (error) {
                console.error(`exec error: ${error}`);
            }
            fs.rename(dstPath,dstPath+".txt",(err)=>{
                if(err){
                    console.error(err,"图片：" + src + " 生成astc压缩纹理失败！");
                }
            });
            Semaphore.release();
        });
    },
    async etc2({src,dstPath}){
        await Semaphore.waitOne();
        exec(`${Conf.dataPath}/WX-WASM-SDK/Editor/PVRTexToolCLI -i "${src}" -o "${dstPath}" -f ETC2_RGB_A1,UBN,sRGB`, (error, stdout, stderr) => {
            if (error) {
                console.error(`exec error: ${error}`);
            }
            const finalDst = dstPath + ".txt";

            fs.rename(dstPath + ".pvr", finalDst,(err)=>{
                if(err){
                    console.error("图片：" + src + " 生成etc2压缩纹理失败！");
                }else{
                    fs.readFile(finalDst,(e,buffer)=>{

                        fs.writeFile(finalDst,buffer.slice(52),(e)=>{
                            if(e){
                                console.error("图片：" + src + " 生成etc2压缩纹理失败！");
                            }
                        });
                    });
                }
            });
            Semaphore.release();
        });
    },
    async pvrtc({src,dstPath}){
        await Semaphore.waitOne();
        exec(`${Conf.dataPath}/WX-WASM-SDK/Editor/PVRTexToolCLI -i "${src}" -o "${dstPath}" -f PVRTC1_4,UBN,sRGB`, (error, stdout, stderr) => {
            if (error) {
                console.error(`exec error: ${error}`);
            }
            const finalDst = dstPath + ".txt";

            fs.rename(dstPath, finalDst,(err)=>{
                if(err){
                    console.error("图片：" + src + " 生pvrtc压缩纹理失败！");
                }
            });
            Semaphore.release();
        });
    },
    async minPng({src}){
        await Semaphore.waitOne();
        exec(`${Conf.dataPath}/WX-WASM-SDK/Editor/pngquant "${src}" -o "${src}" -f`, (error, stdout, stderr) => {
            if (error) {
                console.error(`exec error: ${error}`);
            }
            Semaphore.release();
        });
    }
};



Mod.start().then(()=>{
    console.log("生成完成");
});
