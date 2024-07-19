/* eslint-disable no-unused-vars */
/* eslint-disable no-plusplus */
const fs = require('fs');
const Conf = require('./conf');
const { spawn } = require('child_process');
const os = require('os');
// 最多同时调用4个子进程，如果觉得卡死了电脑可以把这个改小，但是生成速度就会变慢
const MaxThreadCount = 4;
// 判断是M1芯片
const isM1 = os.cpus().some(v => v.model.toLowerCase().indexOf('apple') > -1);
const potList = [1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096];
// 模拟信号量
const Semaphore = {
  _count: 0,
  _waitList: [],
  waitOne() {
    return new Promise((resolve) => {
      if (this._count < MaxThreadCount) {
        this._count++;
        resolve();
      } else {
        this._waitList.push(resolve);
      }
    });
  },
  release() {
    const resolve = this._waitList.shift();
    if (!resolve) {
      this._count--;
      if (this._count < 0) {
        this._count = 0;
      }
    } else {
      resolve();
    }
  },
};

const Mod = {
  startTime: 0,
  async start(isFull) {
    Conf.isAstcOnly = !isFull;
    Mod.startTime = new Date();
    console.warn('格式转换开始！', new Date().toLocaleString());
    await this.startTextureTask();
  },

  async startTextureTask() {
    console.log('total textureList:', Conf.textureList.length);
    for (let i = 0;i < Conf.textureList.length;i++) {
      let { path, width, height, astc, limittype } = Conf.textureList[i];
      path = decodeURIComponent(path);
      const src = `${Conf.dst}/Assets/Textures/png/${width}/${path}.png`;
      if (!fs.existsSync(`${Conf.dst}/Assets/Textures/astc/${width}/`)) {
        fs.mkdirSync(`${Conf.dst}/Assets/Textures/astc/${width}/`, { recursive: true });
      }
      if (i % 20 == 0) {
        console.log('-----current progress-----', i, Conf.textureList.length);
      }
      await this.astc({
        src,
        dstPath: `${Conf.dst}/Assets/Textures/astc/${width}/${path}`,
        astc,
      });

      if (Conf.useDXT5 && !limittype && width % 4 === 0 && height % 4 === 0) {
        if (!fs.existsSync(`${Conf.dst}/Assets/Textures/dds/${width}/`)) {
          fs.mkdirSync(`${Conf.dst}/Assets/Textures/dds/${width}/`, { recursive: true });
        }
        await this.dxt5({
          src,
          dstPath: `${Conf.dst}/Assets/Textures/dds/${width}/${path}`,
        });
      }
      if (!Conf.isAstcOnly) {
        if (!limittype && width === height && potList.indexOf(width) > -1) {
          if (!fs.existsSync(`${Conf.dst}/Assets/Textures/pvr/${width}/`)) {
            fs.mkdirSync(`${Conf.dst}/Assets/Textures/pvr/${width}/`, { recursive: true });
          }
          await this.pvrtc({
            src,
            dstPath: `${Conf.dst}/Assets/Textures/pvr/${width}/${path}`,
          });
        }
        if (!fs.existsSync(`${Conf.dst}/Assets/Textures/etc2/${width}/`)) {
          fs.mkdirSync(`${Conf.dst}/Assets/Textures/etc2/${width}/`, { recursive: true });
        }
        await this.etc2({
          src,
          dstPath: `${Conf.dst}/Assets/Textures/etc2/${width}/${path}`,
          callback: async (isExist) => {
            !isExist && await this.minPng({ src });
          },
        });
      }
    }
  },
  async astc({ src, dstPath, astc }) {
    if (!astc) {
      astc = '8x8';
    }
    try {
      await fs.promises.access(`${dstPath}.txt`);
      return;
    } catch (e) {}

    await Semaphore.waitOne();
    const startTime = new Date();
    let exe = 'astcenc-sse4.1.exe';
    if (os.type() === 'Darwin') {
      if (isM1) {
        exe = 'astcenc-neon';
      } else {
        exe = 'astcenc-avx2';
      }
    }
    const cm = spawn(`${Conf.dataPath}/WX-WASM-SDK/Editor/${exe}`, ['-cs', src, `${dstPath}.astc`, astc, '-medium']);

    cm.stdout.on('data', (data) => {
      //      console.log(`${src} astc stdout: ${data}`);
    });

    cm.stderr.on('data', (data) => {
      console.error(`${src} astc stderr: ${data}`);
    });

    cm.on('close', (code) => {
      console.log(`【astc】${src.substring(src.lastIndexOf('/') + 1)}  耗时：${new Date() - startTime}ms`);
      fs.rename(`${dstPath}.astc`, `${dstPath}.txt`, (err) => {
        if (err) {
          console.error(err, `图片：${src} 生成astc压缩纹理失败！`);
        }
      });
      Semaphore.release();
    });
  },
  async etc2({ src, dstPath, callback }) {
    try {
      await fs.promises.access(`${dstPath}.txt`);
      callback && callback(true);
      return;
    } catch (e) {}

    await Semaphore.waitOne();
    const startTime = new Date();
    const cm = spawn(`${Conf.dataPath}/WX-WASM-SDK/Editor/PVRTexToolCLI${os.type() === 'Darwin' ? '' : '.exe'}`, ['-i', src, '-o', dstPath, '-f', 'ETC2_RGBA,UBN,sRGB']);

    cm.stdout.on('data', (data) => {
      //  console.log(`${src} etc2 stdout: ${data}`);
    });

    cm.stderr.on('data', (data) => {
      //   console.error(`${src} etc2 stderr: ${data}`);
    });

    cm.on('close', (code) => {
      console.log(`【etc2】${src.substring(src.lastIndexOf('/') + 1)}  耗时：${new Date() - startTime}ms`);
      const finalDst = `${dstPath}.txt`;

      fs.rename(`${dstPath}.pvr`, finalDst, (err) => {
        if (err) {
          console.error(`图片：${src} 生成etc2压缩纹理失败！`);
        } else {
          fs.readFile(finalDst, (e, buffer) => {
            fs.writeFile(finalDst, buffer.slice(52), (e) => {
              if (e) {
                console.error(`图片：${src} 生成etc2压缩纹理失败！`);
              }
            });
          });
        }
      });

      callback && callback();
      Semaphore.release();
    });
  },
  async dxt5({ src, dstPath, callback }) {
    try {
      await fs.promises.access(`${dstPath}.txt`);
      callback && callback();
      return;
    } catch (e) {}

    await Semaphore.waitOne();
    const startTime = new Date();
    const cm = spawn(`${Conf.dataPath}/WX-WASM-SDK/Editor/PVRTexToolCLI${os.type() === 'Darwin' ? '' : '.exe'}`, ['-i', src, '-o', `${dstPath}.dds`, '-f', 'BC3,UBN,sRGB']);

    cm.stdout.on('data', (data) => {
      //   console.log(`${src} pvrtc stdout: ${data}`);
    });

    cm.stderr.on('data', (data) => {
      //   console.error(`${src} pvrtc stderr: ${data}`);
    });

    cm.on('close', (code) => {
      console.log(`【DXT5】${src.substring(src.lastIndexOf('/') + 1)}  耗时：${new Date() - startTime}ms`);
      const finalDst = `${dstPath}.txt`;

      fs.rename(`${dstPath}.dds`, finalDst, (err) => {
        if (err) {
          console.error(`图片：${src} 生dxt5压缩纹理失败！`);
        }
      });
      callback && callback();
      Semaphore.release();
    });
  },
  async pvrtc({ src, dstPath, callback }) {
    try {
      await fs.promises.access(`${dstPath}.txt`);
      callback && callback();
      return;
    } catch (e) {}

    await Semaphore.waitOne();
    const startTime = new Date();
    const cm = spawn(`${Conf.dataPath}/WX-WASM-SDK/Editor/PVRTexToolCLI${os.type() === 'Darwin' ? '' : '.exe'}`, ['-i', src, '-o', `${dstPath}.pvr`, '-f', 'PVRTC1_4,UBN,sRGB']);

    cm.stdout.on('data', (data) => {
      //   console.log(`${src} pvrtc stdout: ${data}`);
    });

    cm.stderr.on('data', (data) => {
      //   console.error(`${src} pvrtc stderr: ${data}`);
    });

    cm.on('close', (code) => {
      console.log(`【pvrtc】${src.substring(src.lastIndexOf('/') + 1)}  耗时：${new Date() - startTime}ms`);
      const finalDst = `${dstPath}.txt`;

      fs.rename(`${dstPath}.pvr`, finalDst, (err) => {
        if (err) {
          console.error(`图片：${src} 生pvrtc压缩纹理失败！`);
        }
      });
      callback && callback();
      Semaphore.release();
    });
  },
  async minPng({ src }) {
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
      console.log(`【minPng】${src.substring(src.lastIndexOf('/') + 1)}  耗时：${new Date() - startTime}ms`);

      Semaphore.release();
    });
  },
};


process.on('exit', () => {
  console.warn(new Date().toLocaleString(), `格式转换结束！！！总耗时：${(new Date() - Mod.startTime) / 1000}秒。如果有提示转换失败的可以再次执行本条命令。`);
});


module.exports = {
  start(isFull) {
    Mod.start(isFull);
  },
};
