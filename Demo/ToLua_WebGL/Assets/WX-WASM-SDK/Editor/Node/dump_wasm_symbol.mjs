import binaryen from "binaryen";
import process from "process";
import fs from "fs";

if (process.argv.length < 3) {
    console.error("cannot find wasmcode, Usage: node dump_wasm_symbo.mjs <your_minigame_dir>");
    process.exit(-1);
}
let dir = process.argv[2];
if (!dir.endsWith("/")) {
    dir += "/";
}
let bin = fs.readFileSync(dir + "webgl/Build/webgl.wasm");
let mod = binaryen.readBinary(bin);

let symbols = {};
for (let i = 0; i < mod.getNumFunctions(); ++i) {
    let ref = mod.getFunctionByIndex(i);
    let func = binaryen.getFunctionInfo(ref);
    symbols[i] = func.name;
}

fs.writeFileSync(dir + "minigame/webgl.wasm.symbols.unityweb", JSON.stringify(symbols));
