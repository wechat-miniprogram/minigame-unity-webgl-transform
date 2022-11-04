var Timer = /** @class */ (function () {
    function Timer(label, job) {
        this.label = label;
        if (job == null) {
          this.startTime = performance.now();
        }
        else {
          this.job = job;
          this.set(job.starttime, job.endtime);
        }
    }
    Timer.prototype.start = function () {
        this.startTime = performance.now();
    };
    Timer.prototype.stop = function () {
        this.endTime = performance.now();
    };
    Timer.prototype.set = function (startTime, endTime) {
        this.startTime = startTime;
        this.endTime = endTime;
    };
    Timer.prototype.isDone = function () {
        return typeof this.endTime != "undefined";
    };
    Timer.prototype.toString = function () {
        var text = this.label + ": ";
        if (this.isDone()) {
          // text += (this.endTime - this.startTime).toFixed(2);
          text += (this.endTime - this.startTime).toFixed(0);
          if ((typeof this.job !== "undefined") && this.job.result.value.cached) {
            text += " (from cache)";
          }
        }
        else {
          var progress = ((performance.now() - this.startTime).toFixed(2) / 1000) % 3;
          text += "in progress ";
          for (i = 0; i < progress; i++) {
              text += ".";
          }
        }
        return text;
    };
    return Timer;
}());
