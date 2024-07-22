const callbacks = [];
let isTriggered = false;
export default {
    addCreatedListener(callback) {
        if (isTriggered) {
            callback();
        }
        else {
            callbacks.push(callback);
        }
    },
    _triggerCallback() {
        isTriggered = true;
        callbacks.forEach(v => v());
    },
};
