var Stats= {
  Memory: {
    init: function(initialHeapSize){
      this.element = UI.createSection("Memory (mb)");
      this.initialHeapSize = this.heapSize = initialHeapSize;
      this.updateInterval = setInterval(() => {
        Stats.Memory.updateText();
      }, 1000);

      this.updateText();
    },
    updateText: function(){
      Stats.Memory.element.innerText = "Initial Heap Size: " + (Stats.Memory.initialHeapSize / 1024 / 1024);
      Stats.Memory.element.innerText += "\nHeap Size: " + (gameInstance.Module.asmLibraryArg.getTotalMemory() / 1024 / 1024);
      Stats.Memory.element.innerText += "\nHigh Watermark: " + (gameInstance.Module.HEAP32[gameInstance.Module.asmLibraryArg.DYNAMICTOP_PTR>> 2] / 1024 / 1024).toFixed(0);
    }
  },
  Loading: {
    timers: [],
    init: function(Module){
      this.element = UI.createSection("Load Times (ms)");
      this.updateInterval = setInterval(function(){
        Stats.Loading.updateText();
      }, 500);

      // UnityLoader.Job.schedule(Module, "wasmFrameworkDownloadFinished", ["downloadWasmFramework"], downloadFinishedJob.bind(null, "WebAssembly Framwork"));
      UnityLoader.Job.schedule(Module, "downloadFinished", ["downloadWasmCode", "downloadData", "downloadWasmFramework"], this.downloadFinishedJob);
    },
    term: function(){
        Stats.Loading.updateText();
        clearInterval(Stats.Loading.updateInterval);
    },
    updateText: function(){
      Stats.Loading.element.innerText = "";
      Stats.Loading.timers.forEach(function(timer) {
        Stats.Loading.element.innerText += timer.toString();
        Stats.Loading.element.innerText += "\n";
      });
    },
    downloadFinishedJob: function (Module, job) {
      Stats.Loading.timers.unshift(
        new Timer("Data", Module.Jobs["downloadData"]),
        new Timer("Code", Module.Jobs["downloadWasmCode"]),
        new Timer("Framework", Module.Jobs["downloadWasmFramework"])
      );
    }
  }
};
