binaryen.js
===========

**binaryen.js** is a port of [Binaryen](https://github.com/WebAssembly/binaryen) to the Web, allowing you to generate [WebAssembly](https://webassembly.org) using a JavaScript API.

<a href="https://github.com/AssemblyScript/binaryen.js/actions?query=workflow%3ABuild"><img src="https://img.shields.io/github/workflow/status/AssemblyScript/binaryen.js/Build/main?label=build&logo=github" alt="Build status" /></a>
<a href="https://www.npmjs.com/package/binaryen"><img src="https://img.shields.io/npm/v/binaryen.svg?label=latest&color=007acc&logo=npm" alt="npm version" /></a>
<a href="https://www.npmjs.com/package/binaryen"><img src="https://img.shields.io/npm/v/binaryen/nightly.svg?label=nightly&color=007acc&logo=npm" alt="npm nightly version" /></a>

Usage
-----

```
$> npm install binaryen
```

```js
import binaryen from "binaryen";

// Create a module with a single function
var myModule = new binaryen.Module();

myModule.addFunction("add", binaryen.createType([ binaryen.i32, binaryen.i32 ]), binaryen.i32, [ binaryen.i32 ],
  myModule.block(null, [
    myModule.local.set(2,
      myModule.i32.add(
        myModule.local.get(0, binaryen.i32),
        myModule.local.get(1, binaryen.i32)
      )
    ),
    myModule.return(
      myModule.local.get(2, binaryen.i32)
    )
  ])
);
myModule.addFunctionExport("add", "add");

// Optimize the module using default passes and levels
myModule.optimize();

// Validate the module
if (!myModule.validate())
  throw new Error("validation error");

// Generate text format and binary
var textData = myModule.emitText();
var wasmData = myModule.emitBinary();

// Example usage with the WebAssembly API
var compiled = new WebAssembly.Module(wasmData);
var instance = new WebAssembly.Instance(compiled, {});
console.log(instance.exports.add(41, 1));
```

The buildbot also publishes nightly versions once a day if there have been changes. The latest nightly can be installed through

```
$> npm install binaryen@nightly
```

or you can use one of the [previous versions](https://github.com/AssemblyScript/binaryen.js/tags) instead if necessary.

### Usage with a CDN

  * From GitHub via [jsDelivr](https://www.jsdelivr.com):<br />
    `https://cdn.jsdelivr.net/gh/AssemblyScript/binaryen.js@VERSION/index.js`
  * From npm via [jsDelivr](https://www.jsdelivr.com):<br />
    `https://cdn.jsdelivr.net/npm/binaryen@VERSION/index.js`
  * From npm via [unpkg](https://unpkg.com):<br />
    `https://unpkg.com/binaryen@VERSION/index.js`

  Replace `VERSION` with a [specific version](https://github.com/AssemblyScript/binaryen.js/releases) or omit it (not recommended in production) to use main/latest.

### Command line

The package includes Node.js builds of [wasm-opt](https://github.com/WebAssembly/binaryen#wasm-opt) and [wasm2js](https://github.com/WebAssembly/binaryen#wasm2js).

API
---

**Please note** that the Binaryen API is evolving fast and that definitions and documentation provided by the package tend to get out of sync despite our best efforts. It's a bot after all. If you rely on binaryen.js and spot an issue, please consider sending a PR our way by updating [index.d.ts](./index.d.ts) and [README.md](./README.md) to reflect the [current API](https://github.com/WebAssembly/binaryen/blob/main/src/js/binaryen.js-post.js).

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->
### Contents

- [Types](#types)
- [Module construction](#module-construction)
- [Module manipulation](#module-manipulation)
- [Module validation](#module-validation)
- [Module optimization](#module-optimization)
- [Module creation](#module-creation)
- [Expression construction](#expression-construction)
  - [Control flow](#control-flow)
  - [Variable accesses](#variable-accesses)
  - [Integer operations](#integer-operations)
  - [Floating point operations](#floating-point-operations)
  - [Datatype conversions](#datatype-conversions)
  - [Function calls](#function-calls)
  - [Linear memory accesses](#linear-memory-accesses)
  - [Host operations](#host-operations)
  - [Vector operations 🦄](#vector-operations-)
  - [Atomic memory accesses 🦄](#atomic-memory-accesses-)
  - [Atomic read-modify-write operations 🦄](#atomic-read-modify-write-operations-)
  - [Atomic wait and notify operations 🦄](#atomic-wait-and-notify-operations-)
  - [Sign extension operations 🦄](#sign-extension-operations-)
  - [Multi-value operations 🦄](#multi-value-operations-)
  - [Exception handling operations 🦄](#exception-handling-operations-)
  - [Reference types operations 🦄](#reference-types-operations-)
  - [Bulk memory operations 🦄](#bulk-memory-operations-)
- [Expression manipulation](#expression-manipulation)
- [Relooper](#relooper)
- [Source maps](#source-maps)
- [Debugging](#debugging)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

[Future features](http://webassembly.org/docs/future-features/) 🦄 might not be supported by all runtimes.

### Types

 * **none**: `Type`<br />
   The none type, e.g., `void`.

 * **i32**: `Type`<br />
   32-bit integer type.

 * **i64**: `Type`<br />
   64-bit integer type.

 * **f32**: `Type`<br />
   32-bit float type.

 * **f64**: `Type`<br />
   64-bit float (double) type.

 * **v128**: `Type`<br />
   128-bit vector type. 🦄

 * **funcref**: `Type`<br />
   A function reference. 🦄

 * **anyref**: `Type`<br />
   Any host reference. 🦄

 * **nullref**: `Type`<br />
   A null reference. 🦄

 * **exnref**: `Type`<br />
   An exception reference. 🦄

 * **unreachable**: `Type`<br />
   Special type indicating unreachable code when obtaining information about an expression.

 * **auto**: `Type`<br />
   Special type used in **Module#block** exclusively. Lets the API figure out a block's result type automatically.

 * **createType**(types: `Type[]`): `Type`<br />
   Creates a multi-value type from an array of types.

 * **expandType**(type: `Type`): `Type[]`<br />
   Expands a multi-value type to an array of types.

### Module construction

 * new **Module**()<br />
   Constructs a new module.

 * **parseText**(text: `string`): `Module`<br />
   Creates a module from Binaryen's s-expression text format (not official stack-style text format).

 * **readBinary**(data: `Uint8Array`): `Module`<br />
   Creates a module from binary data.

### Module manipulation

* Module#**addFunction**(name: `string`, params: `Type`, results: `Type`, vars: `Type[]`, body: `ExpressionRef`): `FunctionRef`<br />
  Adds a function. `vars` indicate additional locals, in the given order.

* Module#**getFunction**(name: `string`): `FunctionRef`<br />
  Gets a function, by name,

* Module#**removeFunction**(name: `string`): `void`<br />
  Removes a function, by name.

* Module#**getNumFunctions**(): `number`<br />
  Gets the number of functions within the module.

* Module#**getFunctionByIndex**(index: `number`): `FunctionRef`<br />
  Gets the function at the specified index.

* Module#**addFunctionImport**(internalName: `string`, externalModuleName: `string`, externalBaseName: `string`, params: `Type`, results: `Type`): `void`<br />
  Adds a function import.

* Module#**addTableImport**(internalName: `string`, externalModuleName: `string`, externalBaseName: `string`): `void`<br />
  Adds a table import. There's just one table for now, using name `"0"`.

* Module#**addMemoryImport**(internalName: `string`, externalModuleName: `string`, externalBaseName: `string`): `void`<br />
  Adds a memory import. There's just one memory for now, using name `"0"`.

* Module#**addGlobalImport**(internalName: `string`, externalModuleName: `string`, externalBaseName: `string`, globalType: `Type`): `void`<br />
  Adds a global variable import. Imported globals must be immutable.

* Module#**addFunctionExport**(internalName: `string`, externalName: `string`): `ExportRef`<br />
  Adds a function export.

* Module#**addTableExport**(internalName: `string`, externalName: `string`): `ExportRef`<br />
  Adds a table export. There's just one table for now, using name `"0"`.

* Module#**addMemoryExport**(internalName: `string`, externalName: `string`): `ExportRef`<br />
  Adds a memory export. There's just one memory for now, using name `"0"`.

* Module#**addGlobalExport**(internalName: `string`, externalName: `string`): `ExportRef`<br />
  Adds a global variable export. Exported globals must be immutable.

* Module#**getNumExports**(): `number`<br />
  Gets the number of exports witin the module.

* Module#**getExportByIndex**(index: `number`): `ExportRef`<br />
  Gets the export at the specified index.

* Module#**removeExport**(externalName: `string`): `void`<br />
  Removes an export, by external name.

* Module#**addGlobal**(name: `string`, type: `Type`, mutable: `number`, value: `ExpressionRef`): `GlobalRef`<br />
  Adds a global instance variable.

* Module#**getGlobal**(name: `string`): `GlobalRef`<br />
  Gets a global, by name,

* Module#**removeGlobal**(name: `string`): `void`<br />
  Removes a global, by name.

* Module#**setFunctionTable**(initial: `number`, maximum: `number`, funcs: `string[]`, offset?: `ExpressionRef`): `void`<br />
  Sets the contents of the function table. There's just one table for now, using name `"0"`.

* Module#**getFunctionTable**(): `{ imported: boolean, segments: TableElement[] }`<br />
  Gets the contents of the function table.

  * TableElement#**offset**: `ExpressionRef`
  * TableElement#**names**: `string[]`

* Module#**setMemory**(initial: `number`, maximum: `number`, exportName: `string | null`, segments: `MemorySegment[]`, flags?: `number[]`, shared?: `boolean`): `void`<br />
  Sets the memory. There's just one memory for now, using name `"0"`. Providing `exportName` also creates a memory export.

  * MemorySegment#**offset**: `ExpressionRef`
  * MemorySegment#**data**: `Uint8Array`
  * MemorySegment#**passive**: `boolean`

* Module#**getNumMemorySegments**(): `number`<br />
  Gets the number of memory segments within the module.

* Module#**getMemorySegmentInfoByIndex**(index: `number`): `MemorySegmentInfo`<br />
  Gets information about the memory segment at the specified index.

  * MemorySegmentInfo#**offset**: `number`
  * MemorySegmentInfo#**data**: `Uint8Array`
  * MemorySegmentInfo#**passive**: `boolean`

* Module#**setStart**(start: `FunctionRef`): `void`<br />
  Sets the start function.

* Module#**getFeatures**(): `Features`<br />
  Gets the WebAssembly features enabled for this module.

  Note that the return value may be a bitmask indicating multiple features. Possible feature flags are:

  * Features.**MVP**: `Features`
  * Features.**Atomics**: `Features`
  * Features.**BulkMemory**: `Features`
  * Features.**MutableGlobals**: `Features`
  * Features.**NontrappingFPToInt**: `Features`
  * Features.**SignExt**: `Features`
  * Features.**SIMD128**: `Features`
  * Features.**ExceptionHandling**: `Features`
  * Features.**TailCall**: `Features`
  * Features.**ReferenceTypes**: `Features`
  * Features.**Multivalue**: `Features`
  * Features.**All**: `Features`

* Module#**setFeatures**(features: `Features`): `void`<br />
  Sets the WebAssembly features enabled for this module.

* Module#**addCustomSection**(name: `string`, contents: `Uint8Array`): `void`<br />
  Adds a custom section to the binary.

* Module#**autoDrop**(): `void`<br />
  Enables automatic insertion of `drop` operations where needed. Lets you not worry about dropping when creating your code.

* **getFunctionInfo**(ftype: `FunctionRef`: `FunctionInfo`<br />
  Obtains information about a function.

  * FunctionInfo#**name**: `string`
  * FunctionInfo#**module**: `string | null` (if imported)
  * FunctionInfo#**base**: `string | null` (if imported)
  * FunctionInfo#**params**: `Type`
  * FunctionInfo#**results**: `Type`
  * FunctionInfo#**vars**: `Type`
  * FunctionInfo#**body**: `ExpressionRef`

* **getGlobalInfo**(global: `GlobalRef`): `GlobalInfo`<br />
  Obtains information about a global.

  * GlobalInfo#**name**: `string`
  * GlobalInfo#**module**: `string | null` (if imported)
  * GlobalInfo#**base**: `string | null` (if imported)
  * GlobalInfo#**type**: `Type`
  * GlobalInfo#**mutable**: `boolean`
  * GlobalInfo#**init**: `ExpressionRef`

* **getExportInfo**(export_: `ExportRef`): `ExportInfo`<br />
  Obtains information about an export.

  * ExportInfo#**kind**: `ExternalKind`
  * ExportInfo#**name**: `string`
  * ExportInfo#**value**: `string`

  Possible `ExternalKind` values are:

  * **ExternalFunction**: `ExternalKind`
  * **ExternalTable**: `ExternalKind`
  * **ExternalMemory**: `ExternalKind`
  * **ExternalGlobal**: `ExternalKind`
  * **ExternalEvent**: `ExternalKind`

* **getEventInfo**(event: `EventRef`): `EventInfo`<br />
  Obtains information about an event.

  * EventInfo#**name**: `string`
  * EventInfo#**module**: `string | null` (if imported)
  * EventInfo#**base**: `string | null` (if imported)
  * EventInfo#**attribute**: `number`
  * EventInfo#**params**: `Type`
  * EventInfo#**results**: `Type`

* **getSideEffects**(expr: `ExpressionRef`, features: `FeatureFlags`): `SideEffects`<br />
  Gets the side effects of the specified expression.

  * SideEffects.**None**: `SideEffects`
  * SideEffects.**Branches**: `SideEffects`
  * SideEffects.**Calls**: `SideEffects`
  * SideEffects.**ReadsLocal**: `SideEffects`
  * SideEffects.**WritesLocal**: `SideEffects`
  * SideEffects.**ReadsGlobal**: `SideEffects`
  * SideEffects.**WritesGlobal**: `SideEffects`
  * SideEffects.**ReadsMemory**: `SideEffects`
  * SideEffects.**WritesMemory**: `SideEffects`
  * SideEffects.**ImplicitTrap**: `SideEffects`
  * SideEffects.**IsAtomic**: `SideEffects`
  * SideEffects.**Throws**: `SideEffects`
  * SideEffects.**Any**: `SideEffects`

### Module validation

* Module#**validate**(): `boolean`<br />
  Validates the module. Returns `true` if valid, otherwise prints validation errors and returns `false`.

### Module optimization

* Module#**optimize**(): `void`<br />
  Optimizes the module using the default optimization passes.

* Module#**optimizeFunction**(func: `FunctionRef | string`): `void`<br />
  Optimizes a single function using the default optimization passes.

* Module#**runPasses**(passes: `string[]`): `void`<br />
  Runs the specified passes on the module.

* Module#**runPassesOnFunction**(func: `FunctionRef | string`, passes: `string[]`): `void`<br />
  Runs the specified passes on a single function.

* **getOptimizeLevel**(): `number`<br />
  Gets the currently set optimize level. `0`, `1`, `2` correspond to `-O0`, `-O1`, `-O2` (default), etc.

* **setOptimizeLevel**(level: `number`): `void`<br />
  Sets the optimization level to use. `0`, `1`, `2` correspond to `-O0`, `-O1`, `-O2` (default), etc.

* **getShrinkLevel**(): `number`<br />
  Gets the currently set shrink level. `0`, `1`, `2` correspond to `-O0`, `-Os` (default), `-Oz`.

* **setShrinkLevel**(level: `number`): `void`<br />
  Sets the shrink level to use. `0`, `1`, `2` correspond to `-O0`, `-Os` (default), `-Oz`.

* **getDebugInfo**(): `boolean`<br />
  Gets whether generating debug information is currently enabled or not.

* **setDebugInfo**(on: `boolean`): `void`<br />
  Enables or disables debug information in emitted binaries.

* **getLowMemoryUnused**(): `boolean`<br />
  Gets whether the low 1K of memory can be considered unused when optimizing.

* **setLowMemoryUnused**(on: `boolean`): `void`<br />
  Enables or disables whether the low 1K of memory can be considered unused when optimizing.

* **getPassArgument**(key: `string`): `string | null`<br />
  Gets the value of the specified arbitrary pass argument.

* **setPassArgument**(key: `string`, value: `string | null`): `void`<br />
  Sets the value of the specified arbitrary pass argument. Removes the respective argument if `value` is `null`.

* **clearPassArguments**(): `void`<br />
  Clears all arbitrary pass arguments.

* **getAlwaysInlineMaxSize**(): `number`<br />
  Gets the function size at which we always inline.

* **setAlwaysInlineMaxSize**(size: `number`): `void`<br />
  Sets the function size at which we always inline.

* **getFlexibleInlineMaxSize**(): `number`<br />
  Gets the function size which we inline when functions are lightweight.

* **setFlexibleInlineMaxSize**(size: `number`): `void`<br />
  Sets the function size which we inline when functions are lightweight.

* **getOneCallerInlineMaxSize**(): `number`<br />
  Gets the function size which we inline when there is only one caller.

* **setOneCallerInlineMaxSize**(size: `number`): `void`<br />
  Sets the function size which we inline when there is only one caller.

### Module creation

* Module#**emitBinary**(): `Uint8Array`<br />
  Returns the module in binary format.

* Module#**emitBinary**(sourceMapUrl: `string | null`): `BinaryWithSourceMap`<br />
  Returns the module in binary format with its source map. If `sourceMapUrl` is `null`, source map generation is skipped.

  * BinaryWithSourceMap#**binary**: `Uint8Array`
  * BinaryWithSourceMap#**sourceMap**: `string | null`

* Module#**emitText**(): `string`<br />
  Returns the module in Binaryen's s-expression text format (not official stack-style text format).

* Module#**emitAsmjs**(): `string`<br />
  Returns the [asm.js](http://asmjs.org/) representation of the module.

* Module#**dispose**(): `void`<br />
  Releases the resources held by the module once it isn't needed anymore.

### Expression construction

#### [Control flow](http://webassembly.org/docs/semantics/#control-constructs-and-instructions)

* Module#**block**(label: `string | null`, children: `ExpressionRef[]`, resultType?: `Type`): `ExpressionRef`<br />
  Creates a block. `resultType` defaults to `none`.

* Module#**if**(condition: `ExpressionRef`, ifTrue: `ExpressionRef`, ifFalse?: `ExpressionRef`): `ExpressionRef`<br />
  Creates an if or if/else combination.

* Module#**loop**(label: `string | null`, body: `ExpressionRef`): `ExpressionRef`<br />
  Creates a loop.

* Module#**br**(label: `string`, condition?: `ExpressionRef`, value?: `ExpressionRef`): `ExpressionRef`<br />
  Creates a branch (br) to a label.

* Module#**switch**(labels: `string[]`, defaultLabel: `string`, condition: `ExpressionRef`, value?: `ExpressionRef`): `ExpressionRef`<br />
  Creates a switch (br_table).

* Module#**nop**(): `ExpressionRef`<br />
  Creates a no-operation (nop) instruction.

* Module#**return**(value?: `ExpressionRef`): `ExpressionRef`
  Creates a return.

* Module#**unreachable**(): `ExpressionRef`<br />
  Creates an [unreachable](http://webassembly.org/docs/semantics/#unreachable) instruction that will always trap.

* Module#**drop**(value: `ExpressionRef`): `ExpressionRef`<br />
  Creates a [drop](http://webassembly.org/docs/semantics/#type-parametric-operators) of a value.

* Module#**select**(condition: `ExpressionRef`, ifTrue: `ExpressionRef`, ifFalse: `ExpressionRef`, type?: `Type`): `ExpressionRef`<br />
  Creates a [select](http://webassembly.org/docs/semantics/#type-parametric-operators) of one of two values.

#### [Variable accesses](http://webassembly.org/docs/semantics/#local-variables)

* Module#**local.get**(index: `number`, type: `Type`): `ExpressionRef`<br />
  Creates a local.get for the local at the specified index. Note that we must specify the type here as we may not have created the local being accessed yet.

* Module#**local.set**(index: `number`, value: `ExpressionRef`): `ExpressionRef`<br />
  Creates a local.set for the local at the specified index.

* Module#**local.tee**(index: `number`, value: `ExpressionRef`, type: `Type`): `ExpressionRef`<br />
  Creates a local.tee for the local at the specified index. A tee differs from a set in that the value remains on the stack. Note that we must specify the type here as we may not have created the local being accessed yet.

* Module#**global.get**(name: `string`, type: `Type`): `ExpressionRef`<br />
  Creates a global.get for the global with the specified name. Note that we must specify the type here as we may not have created the global being accessed yet.

* Module#**global.set**(name: `string`, value: `ExpressionRef`): `ExpressionRef`<br />
  Creates a global.set for the global with the specified name.

#### [Integer operations](http://webassembly.org/docs/semantics/#32-bit-integer-operators)

* Module#i32.**const**(value: `number`): `ExpressionRef`
* Module#i32.**clz**(value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**ctz**(value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**popcnt**(value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**eqz**(value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**add**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32.**sub**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32.**mul**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32.**div_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32.**div_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32.**rem_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32.**rem_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32.**and**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32.**or**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32.**xor**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32.**shl**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32.**shr_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32.**shr_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32.**rotl**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32.**rotr**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32.**eq**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32.**ne**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32.**lt_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32.**lt_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32.**le_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32.**le_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32.**gt_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32.**gt_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32.**ge_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32.**ge_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
>
* Module#i64.**const**(low: `number`, high: `number`): `ExpressionRef`
* Module#i64.**clz**(value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**ctz**(value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**popcnt**(value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**eqz**(value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**add**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i64.**sub**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i64.**mul**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i64.**div_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i64.**div_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i64.**rem_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i64.**rem_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i64.**and**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i64.**or**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i64.**xor**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i64.**shl**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i64.**shr_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i64.**shr_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i64.**rotl**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i64.**rotr**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i64.**eq**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i64.**ne**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i64.**lt_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i64.**lt_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i64.**le_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i64.**le_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i64.**gt_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i64.**gt_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i64.**ge_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i64.**ge_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`

#### [Floating point operations](http://webassembly.org/docs/semantics/#floating-point-operators)

* Module#f32.**const**(value: `number`): `ExpressionRef`
* Module#f32.**const_bits**(value: `number`): `ExpressionRef`
* Module#f32.**neg**(value: `ExpressionRef`): `ExpressionRef`
* Module#f32.**abs**(value: `ExpressionRef`): `ExpressionRef`
* Module#f32.**ceil**(value: `ExpressionRef`): `ExpressionRef`
* Module#f32.**floor**(value: `ExpressionRef`): `ExpressionRef`
* Module#f32.**trunc**(value: `ExpressionRef`): `ExpressionRef`
* Module#f32.**nearest**(value: `ExpressionRef`): `ExpressionRef`
* Module#f32.**sqrt**(value: `ExpressionRef`): `ExpressionRef`
* Module#f32.**add**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f32.**sub**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f32.**mul**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f32.**div**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f32.**copysign**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f32.**min**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f32.**max**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f32.**eq**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f32.**ne**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f32.**lt**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f32.**le**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f32.**gt**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f32.**ge**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
>
* Module#f64.**const**(value: `number`): `ExpressionRef`
* Module#f64.**const_bits**(value: `number`): `ExpressionRef`
* Module#f64.**neg**(value: `ExpressionRef`): `ExpressionRef`
* Module#f64.**abs**(value: `ExpressionRef`): `ExpressionRef`
* Module#f64.**ceil**(value: `ExpressionRef`): `ExpressionRef`
* Module#f64.**floor**(value: `ExpressionRef`): `ExpressionRef`
* Module#f64.**trunc**(value: `ExpressionRef`): `ExpressionRef`
* Module#f64.**nearest**(value: `ExpressionRef`): `ExpressionRef`
* Module#f64.**sqrt**(value: `ExpressionRef`): `ExpressionRef`
* Module#f64.**add**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f64.**sub**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f64.**mul**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f64.**div**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f64.**copysign**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f64.**min**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f64.**max**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f64.**eq**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f64.**ne**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f64.**lt**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f64.**le**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f64.**gt**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f64.**ge**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`

#### [Datatype conversions](http://webassembly.org/docs/semantics/#datatype-conversions-truncations-reinterpretations-promotions-and-demotions)

* Module#i32.**trunc_s.f32**(value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**trunc_s.f64**(value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**trunc_u.f32**(value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**trunc_u.f64**(value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**reinterpret**(value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**wrap**(value: `ExpressionRef`): `ExpressionRef`
>
* Module#i64.**trunc_s.f32**(value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**trunc_s.f64**(value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**trunc_u.f32**(value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**trunc_u.f64**(value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**reinterpret**(value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**extend_s**(value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**extend_u**(value: `ExpressionRef`): `ExpressionRef`
>
* Module#f32.**reinterpret**(value: `ExpressionRef`): `ExpressionRef`
* Module#f32.**convert_s.i32**(value: `ExpressionRef`): `ExpressionRef`
* Module#f32.**convert_s.i64**(value: `ExpressionRef`): `ExpressionRef`
* Module#f32.**convert_u.i32**(value: `ExpressionRef`): `ExpressionRef`
* Module#f32.**convert_u.i64**(value: `ExpressionRef`): `ExpressionRef`
* Module#f32.**demote**(value: `ExpressionRef`): `ExpressionRef`
>
* Module#f64.**reinterpret**(value: `ExpressionRef`): `ExpressionRef`
* Module#f64.**convert_s.i32**(value: `ExpressionRef`): `ExpressionRef`
* Module#f64.**convert_s.i64**(value: `ExpressionRef`): `ExpressionRef`
* Module#f64.**convert_u.i32**(value: `ExpressionRef`): `ExpressionRef`
* Module#f64.**convert_u.i64**(value: `ExpressionRef`): `ExpressionRef`
* Module#f64.**promote**(value: `ExpressionRef`): `ExpressionRef`

#### [Function calls](http://webassembly.org/docs/semantics/#calls)

* Module#**call**(name: `string`, operands: `ExpressionRef[]`, returnType: `Type`): `ExpressionRef`
Creates a call to a function. Note that we must specify the return type here as we may not have created the function being called yet.

* Module#**return_call**(name: `string`, operands: `ExpressionRef[]`, returnType: `Type`): `ExpressionRef`<br />
  Like **call**, but creates a tail-call. 🦄

* Module#**call_indirect**(target: `ExpressionRef`, operands: `ExpressionRef[]`, params: `Type`, results: `Type`): `ExpressionRef`<br />
  Similar to **call**, but calls indirectly, i.e., via a function pointer, so an expression replaces the name as the called value.

* Module#**return_call_indirect**(target: `ExpressionRef`, operands: `ExpressionRef[]`, params: `Type`, results: `Type`): `ExpressionRef`<br />
  Like **call_indirect**, but creates a tail-call. 🦄

#### [Linear memory accesses](http://webassembly.org/docs/semantics/#linear-memory-accesses)

* Module#i32.**load**(offset: `number`, align: `number`, ptr: `ExpressionRef`): `ExpressionRef`<br />
* Module#i32.**load8_s**(offset: `number`, align: `number`, ptr: `ExpressionRef`): `ExpressionRef`<br />
* Module#i32.**load8_u**(offset: `number`, align: `number`, ptr: `ExpressionRef`): `ExpressionRef`<br />
* Module#i32.**load16_s**(offset: `number`, align: `number`, ptr: `ExpressionRef`): `ExpressionRef`<br />
* Module#i32.**load16_u**(offset: `number`, align: `number`, ptr: `ExpressionRef`): `ExpressionRef`<br />
* Module#i32.**store**(offset: `number`, align: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`<br />
* Module#i32.**store8**(offset: `number`, align: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`<br />
* Module#i32.**store16**(offset: `number`, align: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`<br />
>
* Module#i64.**load**(offset: `number`, align: `number`, ptr: `ExpressionRef`): `ExpressionRef`
* Module#i64.**load8_s**(offset: `number`, align: `number`, ptr: `ExpressionRef`): `ExpressionRef`
* Module#i64.**load8_u**(offset: `number`, align: `number`, ptr: `ExpressionRef`): `ExpressionRef`
* Module#i64.**load16_s**(offset: `number`, align: `number`, ptr: `ExpressionRef`): `ExpressionRef`
* Module#i64.**load16_u**(offset: `number`, align: `number`, ptr: `ExpressionRef`): `ExpressionRef`
* Module#i64.**load32_s**(offset: `number`, align: `number`, ptr: `ExpressionRef`): `ExpressionRef`
* Module#i64.**load32_u**(offset: `number`, align: `number`, ptr: `ExpressionRef`): `ExpressionRef`
* Module#i64.**store**(offset: `number`, align: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**store8**(offset: `number`, align: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**store16**(offset: `number`, align: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**store32**(offset: `number`, align: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
>
* Module#f32.**load**(offset: `number`, align: `number`, ptr: `ExpressionRef`): `ExpressionRef`
* Module#f32.**store**(offset: `number`, align: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
>
* Module#f64.**load**(offset: `number`, align: `number`, ptr: `ExpressionRef`): `ExpressionRef`
* Module#f64.**store**(offset: `number`, align: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`

#### [Host operations](http://webassembly.org/docs/semantics/#resizing)

* Module#**memory.size**(): `ExpressionRef`
* Module#**memory.grow**(value: `number`): `ExpressionRef`

#### [Vector operations](https://github.com/WebAssembly/simd/blob/main/proposals/simd/SIMD.md) 🦄

* Module#v128.**const**(bytes: `Uint8Array`): `ExpressionRef`
* Module#v128.**load**(offset: `number`, align: `number`, ptr: `ExpressionRef`): `ExpressionRef`
* Module#v128.**store**(offset: `number`, align: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#v128.**not**(value: `ExpressionRef`): `ExpressionRef`
* Module#v128.**and**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#v128.**or**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#v128.**xor**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#v128.**andnot**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#v128.**bitselect**(left: `ExpressionRef`, right: `ExpressionRef`, cond: `ExpressionRef`): `ExpressionRef`
>
* Module#i8x16.**splat**(value: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**extract_lane_s**(vec: `ExpressionRef`, index: `number`): `ExpressionRef`
* Module#i8x16.**extract_lane_u**(vec: `ExpressionRef`, index: `number`): `ExpressionRef`
* Module#i8x16.**replace_lane**(vec: `ExpressionRef`, index: `number`, value: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**eq**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**ne**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**lt_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**lt_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**gt_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**gt_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**le_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**lt_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**ge_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**ge_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**neg**(value: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**any_true**(value: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**all_true**(value: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**shl**(vec: `ExpressionRef`, shift: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**shr_s**(vec: `ExpressionRef`, shift: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**shr_u**(vec: `ExpressionRef`, shift: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**add**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**add_saturate_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**add_saturate_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**sub**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**sub_saturate_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**sub_saturate_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**mul**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**min_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**min_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**max_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**max_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**avgr_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**narrow_i16x8_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i8x16.**narrow_i16x8_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
>
* Module#i16x8.**splat**(value: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**extract_lane_s**(vec: `ExpressionRef`, index: `number`): `ExpressionRef`
* Module#i16x8.**extract_lane_u**(vec: `ExpressionRef`, index: `number`): `ExpressionRef`
* Module#i16x8.**replace_lane**(vec: `ExpressionRef`, index: `number`, value: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**eq**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**ne**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**lt_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**lt_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**gt_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**gt_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**le_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**lt_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**ge_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**ge_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**neg**(value: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**any_true**(value: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**all_true**(value: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**shl**(vec: `ExpressionRef`, shift: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**shr_s**(vec: `ExpressionRef`, shift: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**shr_u**(vec: `ExpressionRef`, shift: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**add**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**add_saturate_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**add_saturate_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**sub**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**sub_saturate_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**sub_saturate_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**mul**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**min_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**min_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**max_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**max_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**avgr_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**narrow_i32x4_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**narrow_i32x4_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**widen_low_i8x16_s**(value: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**widen_high_i8x16_s**(value: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**widen_low_i8x16_u**(value: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**widen_high_i8x16_u**(value: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**load8x8_s**(offset: `number`, align: `number`, ptr: `ExpressionRef`): `ExpressionRef`
* Module#i16x8.**load8x8_u**(offset: `number`, align: `number`, ptr: `ExpressionRef`): `ExpressionRef`
>
* Module#i32x4.**splat**(value: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**extract_lane_s**(vec: `ExpressionRef`, index: `number`): `ExpressionRef`
* Module#i32x4.**extract_lane_u**(vec: `ExpressionRef`, index: `number`): `ExpressionRef`
* Module#i32x4.**replace_lane**(vec: `ExpressionRef`, index: `number`, value: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**eq**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**ne**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**lt_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**lt_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**gt_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**gt_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**le_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**lt_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**ge_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**ge_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**neg**(value: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**any_true**(value: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**all_true**(value: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**shl**(vec: `ExpressionRef`, shift: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**shr_s**(vec: `ExpressionRef`, shift: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**shr_u**(vec: `ExpressionRef`, shift: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**add**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**sub**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**mul**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**min_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**min_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**max_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**max_u**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**dot_i16x8_s**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**trunc_sat_f32x4_s**(value: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**trunc_sat_f32x4_u**(value: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**widen_low_i16x8_s**(value: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**widen_high_i16x8_s**(value: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**widen_low_i16x8_u**(value: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**widen_high_i16x8_u**(value: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**load16x4_s**(offset: `number`, align: `number`, ptr: `ExpressionRef`): `ExpressionRef`
* Module#i32x4.**load16x4_u**(offset: `number`, align: `number`, ptr: `ExpressionRef`): `ExpressionRef`
>
* Module#i64x2.**splat**(value: `ExpressionRef`): `ExpressionRef`
* Module#i64x2.**extract_lane_s**(vec: `ExpressionRef`, index: `number`): `ExpressionRef`
* Module#i64x2.**extract_lane_u**(vec: `ExpressionRef`, index: `number`): `ExpressionRef`
* Module#i64x2.**replace_lane**(vec: `ExpressionRef`, index: `number`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64x2.**neg**(value: `ExpressionRef`): `ExpressionRef`
* Module#i64x2.**any_true**(value: `ExpressionRef`): `ExpressionRef`
* Module#i64x2.**all_true**(value: `ExpressionRef`): `ExpressionRef`
* Module#i64x2.**shl**(vec: `ExpressionRef`, shift: `ExpressionRef`): `ExpressionRef`
* Module#i64x2.**shr_s**(vec: `ExpressionRef`, shift: `ExpressionRef`): `ExpressionRef`
* Module#i64x2.**shr_u**(vec: `ExpressionRef`, shift: `ExpressionRef`): `ExpressionRef`
* Module#i64x2.**add**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i64x2.**sub**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#i64x2.**trunc_sat_f64x2_s**(value: `ExpressionRef`): `ExpressionRef`
* Module#i64x2.**trunc_sat_f64x2_u**(value: `ExpressionRef`): `ExpressionRef`
* Module#i64x2.**load32x2_s**(offset: `number`, align: `number`, ptr: `ExpressionRef`): `ExpressionRef`
* Module#i64x2.**load32x2_u**(offset: `number`, align: `number`, ptr: `ExpressionRef`): `ExpressionRef`
>
* Module#f32x4.**splat**(value: `ExpressionRef`): `ExpressionRef`
* Module#f32x4.**extract_lane**(vec: `ExpressionRef`, index: `number`): `ExpressionRef`
* Module#f32x4.**replace_lane**(vec: `ExpressionRef`, index: `number`, value: `ExpressionRef`): `ExpressionRef`
* Module#f32x4.**eq**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f32x4.**ne**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f32x4.**lt**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f32x4.**gt**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f32x4.**le**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f32x4.**ge**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f32x4.**abs**(value: `ExpressionRef`): `ExpressionRef`
* Module#f32x4.**neg**(value: `ExpressionRef`): `ExpressionRef`
* Module#f32x4.**sqrt**(value: `ExpressionRef`): `ExpressionRef`
* Module#f32x4.**qfma**(a: `ExpressionRef`, b: `ExpressionRef`, c: `ExpressionRef`): `ExpressionRef`
* Module#f32x4.**qfms**(a: `ExpressionRef`, b: `ExpressionRef`, c: `ExpressionRef`): `ExpressionRef`
* Module#f32x4.**add**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f32x4.**sub**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f32x4.**mul**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f32x4.**div**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f32x4.**min**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f32x4.**max**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f32x4.**convert_i32x4_s**(value: `ExpressionRef`): `ExpressionRef`
* Module#f32x4.**convert_i32x4_u**(value: `ExpressionRef`): `ExpressionRef`
>
* Module#f64x2.**splat**(value: `ExpressionRef`): `ExpressionRef`
* Module#f64x2.**extract_lane**(vec: `ExpressionRef`, index: `number`): `ExpressionRef`
* Module#f64x2.**replace_lane**(vec: `ExpressionRef`, index: `number`, value: `ExpressionRef`): `ExpressionRef`
* Module#f64x2.**eq**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f64x2.**ne**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f64x2.**lt**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f64x2.**gt**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f64x2.**le**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f64x2.**ge**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f64x2.**abs**(value: `ExpressionRef`): `ExpressionRef`
* Module#f64x2.**neg**(value: `ExpressionRef`): `ExpressionRef`
* Module#f64x2.**sqrt**(value: `ExpressionRef`): `ExpressionRef`
* Module#f64x2.**qfma**(a: `ExpressionRef`, b: `ExpressionRef`, c: `ExpressionRef`): `ExpressionRef`
* Module#f64x2.**qfms**(a: `ExpressionRef`, b: `ExpressionRef`, c: `ExpressionRef`): `ExpressionRef`
* Module#f64x2.**add**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f64x2.**sub**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f64x2.**mul**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f64x2.**div**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f64x2.**min**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f64x2.**max**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#f64x2.**convert_i64x2_s**(value: `ExpressionRef`): `ExpressionRef`
* Module#f64x2.**convert_i64x2_u**(value: `ExpressionRef`): `ExpressionRef`
>
* Module#v8x16.**shuffle**(left: `ExpressionRef`, right: `ExpressionRef`, mask: `Uint8Array`): `ExpressionRef`
* Module#v8x16.**swizzle**(left: `ExpressionRef`, right: `ExpressionRef`): `ExpressionRef`
* Module#v8x16.**load_splat**(offset: `number`, align: `number`, ptr: `ExpressionRef`): `ExpressionRef`
>
* Module#v16x8.**load_splat**(offset: `number`, align: `number`, ptr: `ExpressionRef`): `ExpressionRef`
>
* Module#v32x4.**load_splat**(offset: `number`, align: `number`, ptr: `ExpressionRef`): `ExpressionRef`
>
* Module#v64x2.**load_splat**(offset: `number`, align: `number`, ptr: `ExpressionRef`): `ExpressionRef`

#### [Atomic memory accesses](https://github.com/WebAssembly/threads/blob/master/proposals/threads/Overview.md#atomic-memory-accesses) 🦄

* Module#i32.**atomic.load**(offset: `number`, ptr: `ExpressionRef`): `ExpressionRef`
* Module#i32.**atomic.load8_u**(offset: `number`, ptr: `ExpressionRef`): `ExpressionRef`
* Module#i32.**atomic.load16_u**(offset: `number`, ptr: `ExpressionRef`): `ExpressionRef`
* Module#i32.**atomic.store**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**atomic.store8**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**atomic.store16**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
>
* Module#i64.**atomic.load**(offset: `number`, ptr: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.load8_u**(offset: `number`, ptr: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.load16_u**(offset: `number`, ptr: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.load32_u**(offset: `number`, ptr: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.store**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.store8**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.store16**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.store32**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`

#### [Atomic read-modify-write operations](https://github.com/WebAssembly/threads/blob/master/proposals/threads/Overview.md#read-modify-write) 🦄

* Module#i32.**atomic.rmw.add**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**atomic.rmw.sub**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**atomic.rmw.and**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**atomic.rmw.or**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**atomic.rmw.xor**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**atomic.rmw.xchg**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**atomic.rmw.cmpxchg**(offset: `number`, ptr: `ExpressionRef`, expected: `ExpressionRef`, replacement: `ExpressionRef`): `ExpressionRef`
* Module#i32.**atomic.rmw8_u.add**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**atomic.rmw8_u.sub**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**atomic.rmw8_u.and**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**atomic.rmw8_u.or**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**atomic.rmw8_u.xor**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**atomic.rmw8_u.xchg**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**atomic.rmw8_u.cmpxchg**(offset: `number`, ptr: `ExpressionRef`, expected: `ExpressionRef`, replacement: `ExpressionRef`): `ExpressionRef`
* Module#i32.**atomic.rmw16_u.add**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**atomic.rmw16_u.sub**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**atomic.rmw16_u.and**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**atomic.rmw16_u.or**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**atomic.rmw16_u.xor**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**atomic.rmw16_u.xchg**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**atomic.rmw16_u.cmpxchg**(offset: `number`, ptr: `ExpressionRef`, expected: `ExpressionRef`, replacement: `ExpressionRef`): `ExpressionRef`
>
* Module#i64.**atomic.rmw.add**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.rmw.sub**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.rmw.and**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.rmw.or**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.rmw.xor**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.rmw.xchg**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.rmw.cmpxchg**(offset: `number`, ptr: `ExpressionRef`, expected: `ExpressionRef`, replacement: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.rmw8_u.add**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.rmw8_u.sub**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.rmw8_u.and**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.rmw8_u.or**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.rmw8_u.xor**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.rmw8_u.xchg**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.rmw8_u.cmpxchg**(offset: `number`, ptr: `ExpressionRef`, expected: `ExpressionRef`, replacement: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.rmw16_u.add**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.rmw16_u.sub**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.rmw16_u.and**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.rmw16_u.or**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.rmw16_u.xor**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.rmw16_u.xchg**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.rmw16_u.cmpxchg**(offset: `number`, ptr: `ExpressionRef`, expected: `ExpressionRef`, replacement: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.rmw32_u.add**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.rmw32_u.sub**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.rmw32_u.and**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.rmw32_u.or**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.rmw32_u.xor**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.rmw32_u.xchg**(offset: `number`, ptr: `ExpressionRef`, value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**atomic.rmw32_u.cmpxchg**(offset: `number`, ptr: `ExpressionRef`, expected: `ExpressionRef`, replacement: `ExpressionRef`): `ExpressionRef`

#### [Atomic wait and notify operations](https://github.com/WebAssembly/threads/blob/master/proposals/threads/Overview.md#wait-and-notify-operators) 🦄

* Module#memory.**atomic.wait32**(ptr: `ExpressionRef`, expected: `ExpressionRef`, timeout: `ExpressionRef`): `ExpressionRef`
* Module#memory.**atomic.wait64**(ptr: `ExpressionRef`, expected: `ExpressionRef`, timeout: `ExpressionRef`): `ExpressionRef`
* Module#memory**atomic.notify**(ptr: `ExpressionRef`, notifyCount: `ExpressionRef`): `ExpressionRef`
* Module#**atomic.fence**(): `ExpressionRef`

#### [Sign extension operations](https://github.com/WebAssembly/sign-extension-ops/blob/master/proposals/sign-extension-ops/Overview.md) 🦄

* Module#i32.**extend8_s**(value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**extend16_s**(value: `ExpressionRef`): `ExpressionRef`
>
* Module#i64.**extend8_s**(value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**extend16_s**(value: `ExpressionRef`): `ExpressionRef`
* Module#i64.**extend32_s**(value: `ExpressionRef`): `ExpressionRef`

#### [Multi-value operations](https://github.com/WebAssembly/multi-value/blob/master/proposals/multi-value/Overview.md) 🦄

Note that these are pseudo instructions enabling Binaryen to reason about multiple values on the stack.

* Module#**push**(value: `ExpressionRef`): `ExpressionRef`
* Module#i32.**pop**(): `ExpressionRef`
* Module#i64.**pop**(): `ExpressionRef`
* Module#f32.**pop**(): `ExpressionRef`
* Module#f64.**pop**(): `ExpressionRef`
* Module#v128.**pop**(): `ExpressionRef`
* Module#funcref.**pop**(): `ExpressionRef`
* Module#anyref.**pop**(): `ExpressionRef`
* Module#nullref.**pop**(): `ExpressionRef`
* Module#exnref.**pop**(): `ExpressionRef`
* Module#tuple.**make**(elements: `ExpressionRef[]`): `ExpressionRef`
* Module#tuple.**extract**(tuple: `ExpressionRef`, index: `number`): `ExpressionRef`

#### [Exception handling operations](https://github.com/WebAssembly/exception-handling/blob/master/proposals/Exceptions.md) 🦄

* Module#**try**(name: `string`, body: `ExpressionRef`, catchTags: `string[]`, catchBodies: `ExpressionRef[]`, delegateTarget: `string`): `ExpressionRef`
* Module#**throw**(event: `string`, operands: `ExpressionRef[]`): `ExpressionRef`
* Module#**rethrow**(exnref: `ExpressionRef`): `ExpressionRef`
* Module#**br_on_exn**(label: `string`, event: `string`, exnref: `ExpressionRef`): `ExpressionRef`
>
* Module#**addEvent**(name: `string`, attribute: `number`, params: `Type`, results: `Type`): `Event`
* Module#**getEvent**(name: `string`): `Event`
* Module#**removeEvent**(name: `stirng`): `void`
* Module#**addEventImport**(internalName: `string`, externalModuleName: `string`, externalBaseName: `string`, attribute: `number`, params: `Type`, results: `Type`): `void`
* Module#**addEventExport**(internalName: `string`, externalName: `string`): `ExportRef`

#### [Reference types operations](https://github.com/WebAssembly/reference-types/blob/master/proposals/reference-types/Overview.md) 🦄

* Module#ref.**null**(): `ExpressionRef`
* Module#ref.**is_null**(value: `ExpressionRef`): `ExpressionRef`
* Module#ref.**func**(name: `string`): `ExpressionRef`

#### [Bulk memory operations](https://github.com/WebAssembly/bulk-memory-operations/blob/master/proposals/bulk-memory-operations/Overview.md) 🦄

* Module#memory.**init**(segment: `number`, dest: `ExpressionRef`, offset: `ExpressionRef`, size: `ExpressionRef`): `ExpressionRef`
* Module#memory.**copy**(dest: `ExpressionRef`, source: `ExpressionRef`, size: `ExpressionRef`): `ExpressionRef`
* Module#memory.**fill**(dest: `ExpressionRef`, value: `ExpressionRef`, size: `ExpressionRef`): `ExpressionRef`

### Expression manipulation

* **getExpressionId**(expr: `ExpressionRef`): `ExpressionId`<br />
  Gets the id (kind) of the specified expression. Possible values are:

  * **InvalidId**: `ExpressionId`
  * **BlockId**: `ExpressionId`
  * **IfId**: `ExpressionId`
  * **LoopId**: `ExpressionId`
  * **BreakId**: `ExpressionId`
  * **SwitchId**: `ExpressionId`
  * **CallId**: `ExpressionId`
  * **CallIndirectId**: `ExpressionId`
  * **LocalGetId**: `ExpressionId`
  * **LocalSetId**: `ExpressionId`
  * **GlobalGetId**: `ExpressionId`
  * **GlobalSetId**: `ExpressionId`
  * **LoadId**: `ExpressionId`
  * **StoreId**: `ExpressionId`
  * **ConstId**: `ExpressionId`
  * **UnaryId**: `ExpressionId`
  * **BinaryId**: `ExpressionId`
  * **SelectId**: `ExpressionId`
  * **DropId**: `ExpressionId`
  * **ReturnId**: `ExpressionId`
  * **HostId**: `ExpressionId`
  * **NopId**: `ExpressionId`
  * **UnreachableId**: `ExpressionId`
  * **AtomicCmpxchgId**: `ExpressionId`
  * **AtomicRMWId**: `ExpressionId`
  * **AtomicWaitId**: `ExpressionId`
  * **AtomicNotifyId**: `ExpressionId`
  * **AtomicFenceId**: `ExpressionId`
  * **SIMDExtractId**: `ExpressionId`
  * **SIMDReplaceId**: `ExpressionId`
  * **SIMDShuffleId**: `ExpressionId`
  * **SIMDTernaryId**: `ExpressionId`
  * **SIMDShiftId**: `ExpressionId`
  * **SIMDLoadId**: `ExpressionId`
  * **MemoryInitId**: `ExpressionId`
  * **DataDropId**: `ExpressionId`
  * **MemoryCopyId**: `ExpressionId`
  * **MemoryFillId**: `ExpressionId`
  * **RefNullId**: `ExpressionId`
  * **RefIsNullId**: `ExpressionId`
  * **RefFuncId**: `ExpressionId`
  * **TryId**: `ExpressionId`
  * **ThrowId**: `ExpressionId`
  * **RethrowId**: `ExpressionId`
  * **BrOnExnId**: `ExpressionId`
  * **PushId**: `ExpressionId`
  * **PopId**: `ExpressionId`

* **getExpressionType**(expr: `ExpressionRef`): `Type`<br />
  Gets the type of the specified expression.

* **getExpressionInfo**(expr: `ExpressionRef`): `ExpressionInfo`<br />
  Obtains information about an expression, always including:

  * Info#**id**: `ExpressionId`
  * Info#**type**: `Type`

  Additional properties depend on the expression's `id` and are usually equivalent to the respective parameters when creating such an expression:

  * BlockInfo#**name**: `string`
  * BlockInfo#**children**: `ExpressionRef[]`
  >
  * IfInfo#**condition**: `ExpressionRef`
  * IfInfo#**ifTrue**: `ExpressionRef`
  * IfInfo#**ifFalse**: `ExpressionRef | null`
  >
  * LoopInfo#**name**: `string`
  * LoopInfo#**body**: `ExpressionRef`
  >
  * BreakInfo#**name**: `string`
  * BreakInfo#**condition**: `ExpressionRef | null`
  * BreakInfo#**value**: `ExpressionRef | null`
  >
  * SwitchInfo#**names**: `string[]`
  * SwitchInfo#**defaultName**: `string | null`
  * SwitchInfo#**condition**: `ExpressionRef`
  * SwitchInfo#**value**: `ExpressionRef | null`
  >
  * CallInfo#**target**: `string`
  * CallInfo#**operands**: `ExpressionRef[]`
  >
  * CallImportInfo#**target**: `string`
  * CallImportInfo#**operands**: `ExpressionRef[]`
  >
  * CallIndirectInfo#**target**: `ExpressionRef`
  * CallIndirectInfo#**operands**: `ExpressionRef[]`
  >
  * LocalGetInfo#**index**: `number`
  >
  * LocalSetInfo#**isTee**: `boolean`
  * LocalSetInfo#**index**: `number`
  * LocalSetInfo#**value**: `ExpressionRef`
  >
  * GlobalGetInfo#**name**: `string`
  >
  * GlobalSetInfo#**name**: `string`
  * GlobalSetInfo#**value**: `ExpressionRef`
  >
  * LoadInfo#**isAtomic**: `boolean`
  * LoadInfo#**isSigned**: `boolean`
  * LoadInfo#**offset**: `number`
  * LoadInfo#**bytes**: `number`
  * LoadInfo#**align**: `number`
  * LoadInfo#**ptr**: `ExpressionRef`
  >
  * StoreInfo#**isAtomic**: `boolean`
  * StoreInfo#**offset**: `number`
  * StoreInfo#**bytes**: `number`
  * StoreInfo#**align**: `number`
  * StoreInfo#**ptr**: `ExpressionRef`
  * StoreInfo#**value**: `ExpressionRef`
  >
  * ConstInfo#**value**: `number | { low: number, high: number }`
  >
  * UnaryInfo#**op**: `number`
  * UnaryInfo#**value**: `ExpressionRef`
  >
  * BinaryInfo#**op**: `number`
  * BinaryInfo#**left**: `ExpressionRef`
  * BinaryInfo#**right**: `ExpressionRef`
  >
  * SelectInfo#**ifTrue**: `ExpressionRef`
  * SelectInfo#**ifFalse**: `ExpressionRef`
  * SelectInfo#**condition**: `ExpressionRef`
  >
  * DropInfo#**value**: `ExpressionRef`
  >
  * ReturnInfo#**value**: `ExpressionRef | null`
  >
  * NopInfo
  >
  * UnreachableInfo
  >
  * HostInfo#**op**: `number`
  * HostInfo#**nameOperand**: `string | null`
  * HostInfo#**operands**: `ExpressionRef[]`
  >
  * AtomicRMWInfo#**op**: `number`
  * AtomicRMWInfo#**bytes**: `number`
  * AtomicRMWInfo#**offset**: `number`
  * AtomicRMWInfo#**ptr**: `ExpressionRef`
  * AtomicRMWInfo#**value**: `ExpressionRef`
  >
  * AtomicCmpxchgInfo#**bytes**: `number`
  * AtomicCmpxchgInfo#**offset**: `number`
  * AtomicCmpxchgInfo#**ptr**: `ExpressionRef`
  * AtomicCmpxchgInfo#**expected**: `ExpressionRef`
  * AtomicCmpxchgInfo#**replacement**: `ExpressionRef`
  >
  * AtomicWaitInfo#**ptr**: `ExpressionRef`
  * AtomicWaitInfo#**expected**: `ExpressionRef`
  * AtomicWaitInfo#**timeout**: `ExpressionRef`
  * AtomicWaitInfo#**expectedType**: `Type`
  >
  * AtomicNotifyInfo#**ptr**: `ExpressionRef`
  * AtomicNotifyInfo#**notifyCount**: `ExpressionRef`
  >
  * AtomicFenceInfo
  >
  * SIMDExtractInfo#**op**: `Op`
  * SIMDExtractInfo#**vec**: `ExpressionRef`
  * SIMDExtractInfo#**index**: `ExpressionRef`
  >
  * SIMDReplaceInfo#**op**: `Op`
  * SIMDReplaceInfo#**vec**: `ExpressionRef`
  * SIMDReplaceInfo#**index**: `ExpressionRef`
  * SIMDReplaceInfo#**value**: `ExpressionRef`
  >
  * SIMDShuffleInfo#**left**: `ExpressionRef`
  * SIMDShuffleInfo#**right**: `ExpressionRef`
  * SIMDShuffleInfo#**mask**: `Uint8Array`
  >
  * SIMDTernaryInfo#**op**: `Op`
  * SIMDTernaryInfo#**a**: `ExpressionRef`
  * SIMDTernaryInfo#**b**: `ExpressionRef`
  * SIMDTernaryInfo#**c**: `ExpressionRef`
  >
  * SIMDShiftInfo#**op**: `Op`
  * SIMDShiftInfo#**vec**: `ExpressionRef`
  * SIMDShiftInfo#**shift**: `ExpressionRef`
  >
  * SIMDLoadInfo#**op**: `Op`
  * SIMDLoadInfo#**offset**: `number`
  * SIMDLoadInfo#**align**: `number`
  * SIMDLoadInfo#**ptr**: `ExpressionRef`
  >
  * MemoryInitInfo#**segment**: `number`
  * MemoryInitInfo#**dest**: `ExpressionRef`
  * MemoryInitInfo#**offset**: `ExpressionRef`
  * MemoryInitInfo#**size**: `ExpressionRef`
  >
  * MemoryDropInfo#**segment**: `number`
  >
  * MemoryCopyInfo#**dest**: `ExpressionRef`
  * MemoryCopyInfo#**source**: `ExpressionRef`
  * MemoryCopyInfo#**size**: `ExpressionRef`
  >
  * MemoryFillInfo#**dest**: `ExpressionRef`
  * MemoryFillInfo#**value**: `ExpressionRef`
  * MemoryFillInfo#**size**: `ExpressionRef`
  >
  * TryInfo#**body**: `ExpressionRef`
  * TryInfo#**catchBody**: `ExpressionRef`
  >
  * RefNullInfo
  >
  * RefIsNullInfo#**value**: `ExpressionRef`
  >
  * RefFuncInfo#**func**: `string`
  >
  * ThrowInfo#**event**: `string`
  * ThrowInfo#**operands**: `ExpressionRef[]`
  >
  * RethrowInfo#**exnref**: `ExpressionRef`
  >
  * BrOnExnInfo#**name**: `string`
  * BrOnExnInfo#**event**: `string`
  * BrOnExnInfo#**exnref**: `ExpressionRef`
  >
  * PopInfo
  >
  * PushInfo#**value**: `ExpressionRef`

* **emitText**(expression: `ExpressionRef`): `string`<br />
  Emits the expression in Binaryen's s-expression text format (not official stack-style text format).

* **copyExpression**(expression: `ExpressionRef`): `ExpressionRef`<br />
  Creates a deep copy of an expression.

### Relooper

* new **Relooper**()<br />
  Constructs a relooper instance. This lets you provide an arbitrary CFG, and the relooper will structure it for WebAssembly.

* Relooper#**addBlock**(code: `ExpressionRef`): `RelooperBlockRef`<br />
  Adds a new block to the CFG, containing the provided code as its body.

* Relooper#**addBranch**(from: `RelooperBlockRef`, to: `RelooperBlockRef`, condition: `ExpressionRef`, code: `ExpressionRef`): `void`<br />
  Adds a branch from a block to another block, with a condition (or nothing, if this is the default branch to take from the origin - each block must have one such branch), and optional code to execute on the branch (useful for phis).

* Relooper#**addBlockWithSwitch**(code: `ExpressionRef`, condition: `ExpressionRef`): `RelooperBlockRef`<br />
  Adds a new block, which ends with a switch/br_table, with provided code and condition (that determines where we go in the switch).

* Relooper#**addBranchForSwitch**(from: `RelooperBlockRef`, to: `RelooperBlockRef`, indexes: `number[]`, code: `ExpressionRef`): `void`<br />
  Adds a branch from a block ending in a switch, to another block, using an array of indexes that determine where to go, and optional code to execute on the branch.

* Relooper#**renderAndDispose**(entry: `RelooperBlockRef`, labelHelper: `number`, module: `Module`): `ExpressionRef`<br />
  Renders and cleans up the Relooper instance. Call this after you have created all the blocks and branches, giving it the entry block (where control flow begins), a label helper variable (an index of a local we can use, necessary for irreducible control flow), and the module. This returns an expression - normal WebAssembly code - that you can use normally anywhere.

### Source maps

* Module#**addDebugInfoFileName**(filename: `string`): `number`<br />
  Adds a debug info file name to the module and returns its index.

* Module#**getDebugInfoFileName**(index: `number`): `string | null` <br />
  Gets the name of the debug info file at the specified index.

* Module#**setDebugLocation**(func: `FunctionRef`, expr: `ExpressionRef`, fileIndex: `number`, lineNumber: `number`, columnNumber: `number`): `void`<br />
  Sets the debug location of the specified `ExpressionRef` within the specified `FunctionRef`.

### Debugging

* Module#**interpret**(): `void`<br />
  Runs the module in the interpreter, calling the start function.
