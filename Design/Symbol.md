# Symbol 相关

### Tool

开发者工具或者线上打印出来的堆栈，一般都是 wasm 函数 id，需要通过 symbol 映射到函数名，才能用于定位问题

这里提供了一个小工具用来替换函数 id，用法如下：

比如以下这段堆栈

```
at Object.WXUncaughtException (https://usr/game.js:108:1264)
    at abort (https://usr/game.js:593:247583)
    at j88421 (wasm-function[67190]:0x13a062b)
    at j88421 (wasm-function[44572]:0x801bd1)
    at j23511 (wasm-function[9866]:0x432503)
```

将这段内容保存到文件，和 symbol 文件一起传给工具处理

```
node tools/rewrite_exception_symbol.js exception.txt webgl.wasm.symbols.unityweb
```

symbol 文件一般会自动生成在 minigame 目录

Unity 2021 的引擎暂时还不支持导出 symbol，因此需要手动跑工具生成，导出插件导出到 webgl 时的 console 信息有说明要如何操作
