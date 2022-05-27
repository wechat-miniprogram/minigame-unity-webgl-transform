const fs = require('fs');
const Conf = require('./conf');
const { spawn } = require('child_process');
const os = require('os');
//最多同时调用4个子进程，如果觉得卡死了电脑可以把这个改小，但是生成速度就会变慢
const MaxThreadCount = 4;
// 判断是M1芯片
const isM1 = os.cpus().some((v)=>v.model.toLowerCase().indexOf('apple')>-1);
const potList = [1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096];
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
        const resolve = this._waitList.shift();
        if(!resolve){
            this._count--;
            if(this._count<0){
                this._count = 0;
            }
        }else{
            resolve();
        }
    }
};

const Mod = {
    startTime:0,
    async start(isFull){
        if(typeof isFull!="undefined"){
            Conf.isAstcOnly = !isFull;
        }
        Mod.startTime = new Date();
        console.warn("格式转换开始！",new Date().toLocaleString());
        await this.startTextureTask();
        await this.startSpriteAtlasTask();
    },

    async startTextureTask(){
        for(let i=0;i<Conf.textureList.length;i++){
            let {path,width,height,pathHash,fileName,dataHash,needUnityPng} = Conf.textureList[i];
            const backupPath = `${Conf.dst}/${needUnityPng? "UnityPng" :"backup"}/${path}${needUnityPng?".png" :""}`;
            let dstPath = `${Conf.dst}/webgl/Assets/Textures/${pathHash}/${fileName}.${dataHash}`;
            const dir = dstPath.substring(0,dstPath.lastIndexOf('/'));
            if(!fs.existsSync(dir)){
                fs.mkdirSync(dir,{ recursive: true });
            }
            let src = backupPath;
            await this.png({
                src,
                dstPath:dstPath+".png",
                width,
                height,
                callback:(isExists)=>{
                    src = dstPath+".png";
                    this.astc({
                        src,
                        dstPath:dstPath+".astc",
                    });
                    if(Conf.useDXT5 && width%4=== 0 && height%4===0){
                        this.dxt5({
                            src,
                            dstPath:dstPath+".dds"
                        });
                    }
                    if(!Conf.isAstcOnly){
                        this.etc2({
                            src,
                            dstPath:dstPath+".pkm"
                        });
                        if(width === height && potList.indexOf(width)>-1){
                            this.pvrtc({
                                src,
                                dstPath:dstPath+".pvr"
                            });
                        }
                        !isExists && this.minPng({src});
                    }
                }
            });

        }
    },
    async startSpriteAtlasTask(){
        for(let i=0;i<Conf.spriteAtlasList.length;i++){
            let {width,height,pathHash,fileName,dataHash} = Conf.spriteAtlasList[i];
            const backupPath = `${Conf.dst}/spriteAtlas/${pathHash}/${fileName}.${dataHash}.png`;
            let dstPath = `${Conf.dst}/webgl/Assets/Textures/${pathHash}/${fileName}.${dataHash}`;
            const dir = dstPath.substring(0,dstPath.lastIndexOf('/'));
            if(!fs.existsSync(dir)){
                fs.mkdirSync(dir,{ recursive: true });
            }
            let src = backupPath;
            await this.png({
                src,
                dstPath:dstPath+".png",
                width,
                height,
                callback:(isExists)=>{
                    src = dstPath+".png";
                    this.astc({
                        src,
                        dstPath:dstPath+".astc",
                    });
                    if(Conf.useDXT5 && width%4=== 0 && height%4===0){
                        this.dxt5({
                            src,
                            dstPath:dstPath+".dds"
                        });
                    }
                    if(!Conf.isAstcOnly){
                        this.etc2({
                            src,
                            dstPath:dstPath+".pkm"
                        });
                        if(width === height && potList.indexOf(width)>-1){
                            this.pvrtc({
                                src,
                                dstPath:dstPath+".pvr"
                            });
                        }
                        !isExists && this.minPng({src});
                    }
                }
            });

        }
    },
    async png({src,dstPath,width,height,callback}){
        try{
            await fs.promises.access(dstPath);
            callback(true);
            return true;
        }catch (e){}

        await Semaphore.waitOne();
        const startTime = new Date();
        let quality = 65;
        if (Conf.qualityList != null && Conf.qualityList.length > 0)
        {
            Conf.qualityList.forEach(v=>{
                if(src.indexOf(v.path)>-1){
                    quality = v.Quality;
                }
            });
        }

        let param = ['convert',`${src}[0]`, `-quality`, quality];
        if( !/\.tga$/i.test(src)){
            param.push('-flip');
        }
        param = param.concat(['-resize',`${width}x${height}!`,`${dstPath}`])
        const cm = spawn('magick', param);

        cm.stdout.on('data', (data) => {
             //   console.log(`${src} stdout: ${data}`);
        });

        cm.stderr.on('data', (data) => {
            //     console.error(`${src} stderr: ${data}`);
        });

        cm.on('close', (code) => {
            console.log(`【png】${src.substring(src.lastIndexOf('/')+1)}  耗时：${new Date() - startTime}ms`);
            callback();
            Semaphore.release();
        });

    },
    async astc({src,dstPath}){
        try{
            await fs.promises.access(dstPath+".txt");
            return;
        }catch (e){}

        await Semaphore.waitOne();
        const startTime = new Date();
        let exe = 'astcenc-sse4.1.exe';
        if(os.type() === 'Darwin'){
            if(isM1){
                exe = 'astcenc-neon';
            }else{
                exe = 'astcenc-avx2';
            }
        }
        const cm = spawn(`${Conf.dataPath}/WX-WASM-SDK/Editor/${exe}`, ['-cs', src, dstPath,'8x8', '-medium']);

        cm.stdout.on('data', (data) => {
         //      console.log(`${src} astc stdout: ${data}`);
        });

        cm.stderr.on('data', (data) => {
         //      console.error(`${src} astc stderr: ${data}`);
        });

        cm.on('close', (code) => {
            console.log(`【astc】${src.substring(src.lastIndexOf('/')+1)}  耗时：${new Date() - startTime}ms`);
            fs.rename(dstPath,dstPath+".txt",(err)=>{
                if(err){
                    console.error(err,"图片：" + src + " 生成astc压缩纹理失败！");
                }
            });
            Semaphore.release();
        });
    },
    async etc2({src,dstPath,callback}){
        try{
            await fs.promises.access(dstPath+".txt");
            callback && callback();
            return;
        }catch (e){}

        await Semaphore.waitOne();
        const startTime = new Date();
        const cm = spawn(`${Conf.dataPath}/WX-WASM-SDK/Editor/PVRTexToolCLI${os.type() === 'Darwin' ? '' : '.exe'}`, ['-i', src, '-o', dstPath, '-f', 'ETC2_RGB_A1,UBN,sRGB']);

        cm.stdout.on('data', (data) => {
             //  console.log(`${src} etc2 stdout: ${data}`);
        });

        cm.stderr.on('data', (data) => {
            //   console.error(`${src} etc2 stderr: ${data}`);
        });

        cm.on('close', (code) => {
            console.log(`【etc2】${src.substring(src.lastIndexOf('/')+1)}  耗时：${new Date() - startTime}ms`);
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

            callback && callback();
            Semaphore.release();
        });
    },
    async dxt5({src,dstPath,callback}){
        try{
            await fs.promises.access(dstPath+".txt");
            callback && callback();
            return;
        }catch (e){}

        await Semaphore.waitOne();
        const startTime = new Date();
        const cm = spawn(`${Conf.dataPath}/WX-WASM-SDK/Editor/PVRTexToolCLI${os.type() === 'Darwin' ? '' : '.exe'}`, ['-i', src, '-o', dstPath, '-f', 'BC3,UBN,sRGB']);

        cm.stdout.on('data', (data) => {
            //   console.log(`${src} pvrtc stdout: ${data}`);
        });

        cm.stderr.on('data', (data) => {
            //   console.error(`${src} pvrtc stderr: ${data}`);
        });

        cm.on('close', (code) => {
            console.log(`【DXT5】${src.substring(src.lastIndexOf('/')+1)}  耗时：${new Date() - startTime}ms`);
            const finalDst = dstPath + ".txt";

            fs.rename(dstPath, finalDst,(err)=>{
                if(err){
                    console.error("图片：" + src + " 生dxt5压缩纹理失败！");
                }
            });
            callback && callback();
            Semaphore.release();
        });
    },
    async pvrtc({src,dstPath,callback}){
        try{
            await fs.promises.access(dstPath+".txt");
            callback && callback();
            return;
        }catch (e){}

        await Semaphore.waitOne();
        const startTime = new Date();
         const cm = spawn(`${Conf.dataPath}/WX-WASM-SDK/Editor/PVRTexToolCLI${os.type() === 'Darwin' ? '' : '.exe'}`, ['-i', src, '-o', dstPath, '-f', 'PVRTC1_4,UBN,sRGB']);

        cm.stdout.on('data', (data) => {
             //   console.log(`${src} pvrtc stdout: ${data}`);
        });

        cm.stderr.on('data', (data) => {
            //   console.error(`${src} pvrtc stderr: ${data}`);
        });

        cm.on('close', (code) => {
            console.log(`【pvrtc】${src.substring(src.lastIndexOf('/')+1)}  耗时：${new Date() - startTime}ms`);
            const finalDst = dstPath + ".txt";

            fs.rename(dstPath, finalDst,(err)=>{
                if(err){
                    console.error("图片：" + src + " 生pvrtc压缩纹理失败！");
                }
            });
            callback && callback();
            Semaphore.release();
        });
    },
    async minPng({src}){

        await Semaphore.waitOne();
        const startTime = new Date();

        const cm = spawn(`${Conf.dataPath}/WX-WASM-SDK/Editor/pngquant${os.type() === 'Darwin' ? '' : '.exe'}`, [src, '-o', src, '-f']);

        cm.stdout.on('data', (data) => {
           //     console.log(`${src} minPng stdout: ${data}`);
        });

        cm.stderr.on('data', (data) => {
           //     console.error(`${src} minPng stderr: ${data}`);
        });

        cm.on('close', (code) => {
            console.log(`【minPng】${src.substring(src.lastIndexOf('/')+1)}  耗时：${new Date() - startTime}`);

            Semaphore.release();
        });
    }
};



process.on('exit',()=>{
    console.warn(new Date().toLocaleString(),`格式转换结束！！！总耗时：${(new Date() - Mod.startTime)/1000}秒。如果有提示转换失败的可以再次执行本条命令。`)
});


module.exports = {
    start:function(isFull){
        Mod.start(isFull);
    }
};
