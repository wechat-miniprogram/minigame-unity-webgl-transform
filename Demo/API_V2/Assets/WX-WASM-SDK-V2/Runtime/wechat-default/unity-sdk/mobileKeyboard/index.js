let FrameworkData = null;
const keyboardSetting = {
    value: '',
    maxLength: 140,
    multiple: false,
    confirmHold: false,
    confirmType: 'done',
};
const keyboardInputlistener = function (res) {
    keyboardSetting.value = res.value;
};
const keyboardConfirmlistener = function (res) {
    keyboardSetting.value = res.value;
    _JS_MobileKeyboard_Hide(false);
};
const keyboardCompletelistener = function (res) {
    removeKeyboardListeners();
};
let hasExistingMobileInput = false;
let mobile_input_hide_delay = null;
let mobile_input_ignore_blur_event = false;
function _JS_MobileKeybard_GetIgnoreBlurEvent() {
    
    
    
    return mobile_input_ignore_blur_event;
}
function _JS_MobileKeyboard_GetKeyboardStatus() {
    const kKeyboardStatusVisible = 0;
    const kKeyboardStatusDone = 1;
    
    
    if (!hasExistingMobileInput) {
        return kKeyboardStatusDone;
    }
    return kKeyboardStatusVisible;
}
function _JS_MobileKeyboard_GetText(buffer, bufferSize) {
    if (buffer) {
        FrameworkData.stringToUTF8(keyboardSetting.value, buffer, bufferSize);
    }
    return FrameworkData.lengthBytesUTF8(keyboardSetting.value);
}
function _JS_MobileKeyboard_GetTextSelection(outStart, outLength) {
    
    const n = keyboardSetting.value.length;
    FrameworkData.HEAP32[outStart >> 2] = n;
    FrameworkData.HEAP32[outLength >> 2] = 0;
}
function _JS_MobileKeyboard_Hide(delay) {
    if (mobile_input_hide_delay) {
        return;
    }
    mobile_input_ignore_blur_event = true;
    function hideMobileKeyboard() {
        if (hasExistingMobileInput) {
            wx.hideKeyboard();
        }
        hasExistingMobileInput = false;
        mobile_input_hide_delay = null;
        
        
        
        
        setTimeout(() => {
            mobile_input_ignore_blur_event = false;
        }, 100);
    }
    if (delay) {
        
        
        
        
        const hideDelay = 200;
        mobile_input_hide_delay = setTimeout(hideMobileKeyboard, hideDelay);
    }
    else {
        hideMobileKeyboard();
    }
}
function _JS_MobileKeyboard_SetCharacterLimit(limit) {
    keyboardSetting.maxLength = limit;
}
function _JS_MobileKeyboard_SetText(text) {
    if (!hasExistingMobileInput) {
        return;
    }
    keyboardSetting.value = FrameworkData.UTF8ToString(text);
}
function _JS_MobileKeyboard_SetTextSelection(start, length) {
    
}
function _JS_MobileKeyboard_Show(text, keyboardType, autocorrection, multiline, secure, alert, placeholder, characterLimit, data) {
    if (FrameworkData === null) {
        FrameworkData = data;
    }
    if (mobile_input_hide_delay) {
        clearTimeout(mobile_input_hide_delay);
        mobile_input_hide_delay = null;
    }
    if (hasExistingMobileInput) {
        if (keyboardSetting.multiple != !!multiline) {
            _JS_MobileKeyboard_Hide(false);
            return;
        }
    }
    keyboardSetting.value = FrameworkData.UTF8ToString(text);
    keyboardSetting.maxLength = characterLimit > 0 ? characterLimit : 524288;
    keyboardSetting.multiple = !!multiline;
    wx.showKeyboard({ defaultValue: keyboardSetting.value, maxLength: keyboardSetting.maxLength, multiple: keyboardSetting.multiple, confirmHold: keyboardSetting.confirmHold, confirmType: keyboardSetting.confirmType });
    addKeyboardListeners();
    hasExistingMobileInput = true;
}
function addKeyboardListeners() {
    wx.onKeyboardInput(keyboardInputlistener);
    wx.onKeyboardConfirm(keyboardConfirmlistener);
    wx.onKeyboardComplete(keyboardCompletelistener);
}
function removeKeyboardListeners() {
    wx.offKeyboardInput(keyboardInputlistener);
    wx.offKeyboardConfirm(keyboardConfirmlistener);
    wx.offKeyboardComplete(keyboardCompletelistener);
}
export default {
    _JS_MobileKeybard_GetIgnoreBlurEvent,
    _JS_MobileKeyboard_GetKeyboardStatus,
    _JS_MobileKeyboard_GetText,
    _JS_MobileKeyboard_GetTextSelection,
    _JS_MobileKeyboard_Hide,
    _JS_MobileKeyboard_SetCharacterLimit,
    _JS_MobileKeyboard_SetText,
    _JS_MobileKeyboard_SetTextSelection,
    _JS_MobileKeyboard_Show,
};
