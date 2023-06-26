var fs = require("fs");
var process = require("process");

function demangle(func) {
  // var hasLibcxxabi = !!Module["___cxa_demangle"];
  var hasLibcxxabi = false;
  // if (hasLibcxxabi) {
  //   try {
  //     var buf = _malloc(func.length);
  //     writeStringToMemory(func.substr(1), buf);
  //     var status = _malloc(4);
  //     var ret = Module["___cxa_demangle"](buf, 0, 0, status);
  //     if (getValue(status, "i32") === 0 && ret) {
  //       return Pointer_stringify(ret);
  //     }
  //   } catch (e) {
  //   } finally {
  //     if (buf) _free(buf);
  //     if (status) _free(status);
  //     if (ret) _free(ret);
  //   }
  // }
  var i = 3;
  var basicTypes = {
    v: "void",
    b: "bool",
    c: "char",
    s: "short",
    i: "int",
    l: "long",
    f: "float",
    d: "double",
    w: "wchar_t",
    a: "signed char",
    h: "unsigned char",
    t: "unsigned short",
    j: "unsigned int",
    m: "unsigned long",
    x: "long long",
    y: "unsigned long long",
    z: "...",
  };
  var subs = [];
  var first = true;
  function dump(x) {
    if (x) Module.print(x);
    Module.print(func);
    var pre = "";
    for (var a = 0; a < i; a++) pre += " ";
    Module.print(pre + "^");
  }
  function parseNested() {
    i++;
    if (func[i] === "K") i++;
    var parts = [];
    while (func[i] !== "E") {
      if (func[i] === "S") {
        i++;
        var next = func.indexOf("_", i);
        var num = func.substring(i, next) || 0;
        parts.push(subs[num] || "?");
        i = next + 1;
        continue;
      }
      if (func[i] === "C") {
        parts.push(parts[parts.length - 1]);
        i += 2;
        continue;
      }
      var size = parseInt(func.substr(i));
      var pre = size.toString().length;
      if (!size || !pre) {
        i--;
        break;
      }
      var curr = func.substr(i + pre, size);
      parts.push(curr);
      subs.push(curr);
      i += pre + size;
    }
    i++;
    return parts;
  }
  function parse(rawList, limit, allowVoid) {
    limit = limit || Infinity;
    var ret = "",
      list = [];
    function flushList() {
      return "(" + list.join(", ") + ")";
    }
    var name;
    if (func[i] === "N") {
      name = parseNested().join("::");
      limit--;
      if (limit === 0) return rawList ? [name] : name;
    } else {
      if (func[i] === "K" || (first && func[i] === "L")) i++;
      var size = parseInt(func.substr(i));
      if (size) {
        var pre = size.toString().length;
        name = func.substr(i + pre, size);
        i += pre + size;
      }
    }
    first = false;
    if (func[i] === "I") {
      i++;
      var iList = parse(true);
      var iRet = parse(true, 1, true);
      ret += iRet[0] + " " + name + "<" + iList.join(", ") + ">";
    } else {
      ret = name;
    }
    paramLoop: while (i < func.length && limit-- > 0) {
      var c = func[i++];
      if (c in basicTypes) {
        list.push(basicTypes[c]);
      } else {
        switch (c) {
          case "P":
            list.push(parse(true, 1, true)[0] + "*");
            break;
          case "R":
            list.push(parse(true, 1, true)[0] + "&");
            break;
          case "L": {
            i++;
            var end = func.indexOf("E", i);
            var size = end - i;
            list.push(func.substr(i, size));
            i += size + 2;
            break;
          }
          case "A": {
            var size = parseInt(func.substr(i));
            i += size.toString().length;
            if (func[i] !== "_") throw "?";
            i++;
            list.push(parse(true, 1, true)[0] + " [" + size + "]");
            break;
          }
          case "E":
            break paramLoop;
          default:
            ret += "?" + c;
            break paramLoop;
        }
      }
    }
    if (!allowVoid && list.length === 1 && list[0] === "void") list = [];
    if (rawList) {
      if (ret) {
        list.push(ret + "?");
      }
      return list;
    } else {
      return ret + flushList();
    }
  }
  var parsed = func;
  try {
    if (func == "Object._main" || func == "_main") {
      return "main()";
    }
    // if (typeof func === "number") func = Pointer_stringify(func);
    if (func[0] !== "_") return func;
    if (func[1] !== "_") return func;
    if (func[2] !== "Z") return func;
    switch (func[3]) {
      case "n":
        return "operator new()";
      case "d":
        return "operator delete()";
    }
    parsed = parse();
  } catch (e) {
    parsed += "?";
  }
  if (parsed.indexOf("?") >= 0 && !hasLibcxxabi) {
    // Runtime.warnOnce(
    //   "warning: a problem occurred in builtin C++ name demangling; build with  -s DEMANGLE_SUPPORT=1  to link in libcxxabi demangling"
    // );
    return func;
  }
  return parsed;
}

function printHelp() {
  console.log(
    "Usage: node rewrite_exception_symbol.js <exception_file> <symbol_file>\n"
  );
}

if (process.argv.length < 4) {
  printHelp();
  process.exit(0);
}

var exceptionText = fs.readFileSync(process.argv[2], { encoding: "utf8" });
var symbolText = fs.readFileSync(process.argv[3], { encoding: "utf8" });

function parseSymbol(symbolText) {
  var symbolMap = new Map();
  try {
    var symbols = JSON.parse(symbolText);
    console.log("json symbols");
    Object.entries(symbols).forEach(function (value) {
      symbolMap.set(value[0], value[1]);
    });
    return symbolMap;
  } catch (e) {}
  var startLine = "var debugSymbols = {";
  var start = symbolText.indexOf(startLine);
  start += startLine.length;
  for (;;) {
    var next = symbolText.indexOf(",", start);
    var s = symbolText.substr(start, next - start).trim();
    // console.log("symbol line:", s);
    var b = s.length > 0 ? s.charCodeAt(0) : 0;
    if (b < 48 || b > 57) {
      // not in [0-9]
      break;
    }
    var mid = s.indexOf(":");
    if (mid < 0) {
      break;
    }
    var left = s.substr(0, mid);
    var right = s.substr(mid + 1, s.length - mid - 1);
    if (right[0] === "'" && right[right.length - 1] === "'") {
      right = right.substr(1, right.length - 2);
    }
    // console.log("symbol:", left, right);
    right = demangle(right);
    // console.log("after demangle:", right);

    // console.log("symbol:", start, mid, left, right);
    symbolMap.set(left, right);
    start = next + 1;
  }
  return symbolMap;
}

var symbolMap = parseSymbol(symbolText);

function replaceWithSymbol(src, symbolMap, regex, replaceFunc) {
  var res = src.matchAll(regex);
  // console.log("to replace symbol:", src, regex);
  var output = "";
  var start = 0;
  var matched = false;
  for (;;) {
    var d = res.next();
    if (d.value) {
      matched = true;
      var ret = replaceFunc(d, symbolMap);
      output += src.substr(start, d.value.index - start);
      if (ret) {
        output += ret;
      } else {
        output += d.value[0];
      }
      start = d.value.index + d.value[0].length;
    }
    if (d.done) {
      output += src.substr(start);
      break;
    }
  }
  return { output: output, matched: matched };
}

var res = replaceWithSymbol(
  exceptionText,
  symbolMap,
  /j(\d+)(.*)wasm-function\[(\d+)]/g,
  (match_info, symbolMap) => {
    var s = symbolMap.get(match_info.value[1]);
    if (!s) {
      return null;
    }
    return (
      s + match_info.value[2] + "wasm-function[" + match_info.value[3] + "]"
    );
  }
);
if (!res.matched) {
  res = replaceWithSymbol(
    exceptionText,
    symbolMap,
    /wasm-function\[j(\d+)]/g,
    (match_info, symbolMap) => {
      var s = symbolMap.get(match_info.value[1]);
      if (!s) {
        return null;
      }
      return "wasm-function[" + s + "]";
    }
  );
}
if (!res.matched) {
  res = replaceWithSymbol(
    exceptionText,
    symbolMap,
    /wasm-function\[(\d+)\]/g,
    (match_info, symbolMap) => {
      var s = symbolMap.get(match_info.value[1]);
      if (!s) {
        return null;
      }
      return "wasm-function[" + s + "]";
    }
  );
}
console.log(res.output);
