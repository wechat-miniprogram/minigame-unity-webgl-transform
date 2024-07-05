export function getCurrTime() {
    return Math.floor(Date.now() / 1000);
}
export function promisify(func) {
    return (args = {}) => new Promise((resolve, reject) => {
        func(Object.assign(args, {
            success: resolve,
            fail: reject,
        }));
    });
}
