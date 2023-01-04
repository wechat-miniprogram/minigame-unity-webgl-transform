export function getCurrTime() {
  return parseInt(+new Date() / 1000);
}

export function promisify(func) {
  return (args = {}) =>
    new Promise((resolve, reject) => {
      func(
        Object.assign(args, {
          success: resolve,
          fail: reject,
        }),
      );
    });
}
