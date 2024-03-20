
import moduleHelper from './module-helper';
import { uid, formatResponse, formatJsonStr, onEventCallback, offEventCallback, getListObject, stringifyRes } from './utils';
let OnAccelerometerChangeList;
let OnAudioInterruptionBeginList;
let OnAudioInterruptionEndList;
let OnBLEConnectionStateChangeList;
let OnBLEMTUChangeList;
let OnBLEPeripheralConnectionStateChangedList;
let OnBeaconServiceChangeList;
let OnBeaconUpdateList;
let OnBluetoothAdapterStateChangeList;
let OnBluetoothDeviceFoundList;
let OnCompassChangeList;
let OnDeviceMotionChangeList;
let OnDeviceOrientationChangeList;
let OnErrorList;
let OnHideList;
let OnInteractiveStorageModifiedList;
let OnKeyDownList;
let OnKeyUpList;
let OnKeyboardCompleteList;
let OnKeyboardConfirmList;
let OnKeyboardHeightChangeList;
let OnKeyboardInputList;
let OnMemoryWarningList;
let OnMouseDownList;
let OnMouseMoveList;
let OnMouseUpList;
let OnNetworkStatusChangeList;
let OnNetworkWeakChangeList;
let OnScreenRecordingStateChangedList;
let OnShowList;
let OnUnhandledRejectionList;
let OnUserCaptureScreenList;
let OnVoIPChatInterruptedList;
let OnVoIPChatMembersChangedList;
let OnVoIPChatSpeakersChangedList;
let OnVoIPChatStateChangedList;
let OnWheelList;
let OnWindowResizeList;
let wxOnAddToFavoritesResolveConf;
let wxOnCopyUrlResolveConf;
let wxOnHandoffResolveConf;
let wxOnShareTimelineResolveConf;
let wxOnGameLiveStateChangeResolveConf;
const DownloadTaskList = {};
const FeedbackButtonList = {};
const LogManagerList = {};
const RealtimeLogManagerList = {};
const UpdateManagerList = {};
const VideoDecoderList = {};
const wxDownloadTaskHeadersReceivedList = {};
const wxDownloadTaskProgressUpdateList = {};
const wxFeedbackButtonTapList = {};
const wxVideoDecoderList = {};
const getDownloadTaskObject = getListObject(DownloadTaskList, 'DownloadTask');
const getFeedbackButtonObject = getListObject(FeedbackButtonList, 'FeedbackButton');
const getLogManagerObject = getListObject(LogManagerList, 'LogManager');
const getRealtimeLogManagerObject = getListObject(RealtimeLogManagerList, 'RealtimeLogManager');
const getUpdateManagerObject = getListObject(UpdateManagerList, 'UpdateManager');
const getVideoDecoderObject = getListObject(VideoDecoderList, 'VideoDecoder');
export default {
    WX_AddCard(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.addCard({
            ...config,
            success(res) {
                formatResponse('AddCardSuccessCallbackResult', res);
                moduleHelper.send('AddCardCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('AddCardCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('AddCardCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_AuthPrivateMessage(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.authPrivateMessage({
            ...config,
            success(res) {
                formatResponse('AuthPrivateMessageSuccessCallbackResult', res);
                moduleHelper.send('AuthPrivateMessageCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('AuthPrivateMessageCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('AuthPrivateMessageCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_Authorize(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.authorize({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('AuthorizeCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('AuthorizeCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('AuthorizeCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_CheckIsAddedToMyMiniProgram(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.checkIsAddedToMyMiniProgram({
            ...config,
            success(res) {
                formatResponse('CheckIsAddedToMyMiniProgramSuccessCallbackResult', res);
                moduleHelper.send('CheckIsAddedToMyMiniProgramCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('CheckIsAddedToMyMiniProgramCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('CheckIsAddedToMyMiniProgramCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_CheckSession(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.checkSession({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('CheckSessionCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('CheckSessionCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('CheckSessionCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_ChooseImage(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.chooseImage({
            ...config,
            success(res) {
                formatResponse('ChooseImageSuccessCallbackResult', res);
                moduleHelper.send('ChooseImageCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ChooseImageCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ChooseImageCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_ChooseMedia(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.chooseMedia({
            ...config,
            success(res) {
                formatResponse('ChooseMediaSuccessCallbackResult', res);
                moduleHelper.send('ChooseMediaCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ChooseMediaCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ChooseMediaCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_ChooseMessageFile(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.chooseMessageFile({
            ...config,
            success(res) {
                formatResponse('ChooseMessageFileSuccessCallbackResult', res);
                moduleHelper.send('ChooseMessageFileCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ChooseMessageFileCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ChooseMessageFileCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_CloseBLEConnection(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.closeBLEConnection({
            ...config,
            success(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('CloseBLEConnectionCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('CloseBLEConnectionCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('CloseBLEConnectionCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_CloseBluetoothAdapter(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.closeBluetoothAdapter({
            ...config,
            success(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('CloseBluetoothAdapterCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('CloseBluetoothAdapterCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('CloseBluetoothAdapterCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_CompressImage(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.compressImage({
            ...config,
            success(res) {
                formatResponse('CompressImageSuccessCallbackResult', res);
                moduleHelper.send('CompressImageCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('CompressImageCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('CompressImageCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_CreateBLEConnection(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.createBLEConnection({
            ...config,
            success(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('CreateBLEConnectionCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('CreateBLEConnectionCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('CreateBLEConnectionCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_CreateBLEPeripheralServer(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.createBLEPeripheralServer({
            ...config,
            success(res) {
                formatResponse('CreateBLEPeripheralServerSuccessCallbackResult', res);
                moduleHelper.send('CreateBLEPeripheralServerCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('CreateBLEPeripheralServerCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('CreateBLEPeripheralServerCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_ExitMiniProgram(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.exitMiniProgram({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ExitMiniProgramCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ExitMiniProgramCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ExitMiniProgramCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_ExitVoIPChat(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.exitVoIPChat({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ExitVoIPChatCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ExitVoIPChatCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ExitVoIPChatCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_FaceDetect(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.faceDetect({
            ...config,
            success(res) {
                formatResponse('FaceDetectSuccessCallbackResult', res);
                moduleHelper.send('FaceDetectCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('FaceDetectCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('FaceDetectCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetAvailableAudioSources(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getAvailableAudioSources({
            ...config,
            success(res) {
                formatResponse('GetAvailableAudioSourcesSuccessCallbackResult', res);
                moduleHelper.send('GetAvailableAudioSourcesCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetAvailableAudioSourcesCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetAvailableAudioSourcesCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetBLEDeviceCharacteristics(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getBLEDeviceCharacteristics({
            ...config,
            success(res) {
                formatResponse('GetBLEDeviceCharacteristicsSuccessCallbackResult', res);
                moduleHelper.send('GetBLEDeviceCharacteristicsCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('GetBLEDeviceCharacteristicsCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('GetBLEDeviceCharacteristicsCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetBLEDeviceRSSI(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getBLEDeviceRSSI({
            ...config,
            success(res) {
                formatResponse('GetBLEDeviceRSSISuccessCallbackResult', res);
                moduleHelper.send('GetBLEDeviceRSSICallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetBLEDeviceRSSICallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetBLEDeviceRSSICallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetBLEDeviceServices(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getBLEDeviceServices({
            ...config,
            success(res) {
                formatResponse('GetBLEDeviceServicesSuccessCallbackResult', res);
                moduleHelper.send('GetBLEDeviceServicesCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('GetBLEDeviceServicesCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('GetBLEDeviceServicesCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetBLEMTU(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getBLEMTU({
            ...config,
            success(res) {
                formatResponse('GetBLEMTUSuccessCallbackResult', res);
                moduleHelper.send('GetBLEMTUCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('GetBLEMTUCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('GetBLEMTUCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetBackgroundFetchData(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getBackgroundFetchData({
            ...config,
            success(res) {
                formatResponse('GetBackgroundFetchDataSuccessCallbackResult', res);
                moduleHelper.send('GetBackgroundFetchDataCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetBackgroundFetchDataCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetBackgroundFetchDataCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetBackgroundFetchToken(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getBackgroundFetchToken({
            ...config,
            success(res) {
                formatResponse('GetBackgroundFetchTokenSuccessCallbackResult', res);
                moduleHelper.send('GetBackgroundFetchTokenCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetBackgroundFetchTokenCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetBackgroundFetchTokenCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetBatteryInfo(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getBatteryInfo({
            ...config,
            success(res) {
                formatResponse('GetBatteryInfoSuccessCallbackResult', res);
                moduleHelper.send('GetBatteryInfoCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetBatteryInfoCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetBatteryInfoCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetBeacons(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getBeacons({
            ...config,
            success(res) {
                formatResponse('GetBeaconsSuccessCallbackResult', res);
                moduleHelper.send('GetBeaconsCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('BeaconError', res);
                moduleHelper.send('GetBeaconsCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('BeaconError', res);
                moduleHelper.send('GetBeaconsCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetBluetoothAdapterState(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getBluetoothAdapterState({
            ...config,
            success(res) {
                formatResponse('GetBluetoothAdapterStateSuccessCallbackResult', res);
                moduleHelper.send('GetBluetoothAdapterStateCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('GetBluetoothAdapterStateCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('GetBluetoothAdapterStateCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetBluetoothDevices(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getBluetoothDevices({
            ...config,
            success(res) {
                formatResponse('GetBluetoothDevicesSuccessCallbackResult', res);
                moduleHelper.send('GetBluetoothDevicesCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('GetBluetoothDevicesCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('GetBluetoothDevicesCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetChannelsLiveInfo(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getChannelsLiveInfo({
            ...config,
            success(res) {
                formatResponse('GetChannelsLiveInfoSuccessCallbackResult', res);
                moduleHelper.send('GetChannelsLiveInfoCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetChannelsLiveInfoCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetChannelsLiveInfoCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetChannelsLiveNoticeInfo(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getChannelsLiveNoticeInfo({
            ...config,
            success(res) {
                formatResponse('GetChannelsLiveNoticeInfoSuccessCallbackResult', res);
                moduleHelper.send('GetChannelsLiveNoticeInfoCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetChannelsLiveNoticeInfoCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetChannelsLiveNoticeInfoCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetClipboardData(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getClipboardData({
            ...config,
            success(res) {
                formatResponse('GetClipboardDataSuccessCallbackOption', res);
                moduleHelper.send('GetClipboardDataCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetClipboardDataCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetClipboardDataCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetConnectedBluetoothDevices(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getConnectedBluetoothDevices({
            ...config,
            success(res) {
                formatResponse('GetConnectedBluetoothDevicesSuccessCallbackResult', res);
                moduleHelper.send('GetConnectedBluetoothDevicesCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('GetConnectedBluetoothDevicesCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('GetConnectedBluetoothDevicesCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetExtConfig(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getExtConfig({
            ...config,
            success(res) {
                formatResponse('GetExtConfigSuccessCallbackResult', res);
                moduleHelper.send('GetExtConfigCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetExtConfigCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetExtConfigCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetFuzzyLocation(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getFuzzyLocation({
            ...config,
            success(res) {
                formatResponse('GetFuzzyLocationSuccessCallbackResult', res);
                moduleHelper.send('GetFuzzyLocationCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetFuzzyLocationCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetFuzzyLocationCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetGameClubData(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getGameClubData({
            ...config,
            success(res) {
                formatResponse('GetGameClubDataSuccessCallbackResult', res);
                moduleHelper.send('GetGameClubDataCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetGameClubDataCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetGameClubDataCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetGroupEnterInfo(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getGroupEnterInfo({
            ...config,
            success(res) {
                formatResponse('GetGroupEnterInfoSuccessCallbackResult', res);
                moduleHelper.send('GetGroupEnterInfoCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetGroupEnterInfoCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetGroupEnterInfoCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetInferenceEnvInfo(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getInferenceEnvInfo({
            ...config,
            success(res) {
                formatResponse('GetInferenceEnvInfoSuccessCallbackResult', res);
                moduleHelper.send('GetInferenceEnvInfoCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetInferenceEnvInfoCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetInferenceEnvInfoCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetLocalIPAddress(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getLocalIPAddress({
            ...config,
            success(res) {
                formatResponse('GetLocalIPAddressSuccessCallbackResult', res);
                moduleHelper.send('GetLocalIPAddressCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetLocalIPAddressCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetLocalIPAddressCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetNetworkType(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getNetworkType({
            ...config,
            success(res) {
                formatResponse('GetNetworkTypeSuccessCallbackResult', res);
                moduleHelper.send('GetNetworkTypeCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetNetworkTypeCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetNetworkTypeCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetPrivacySetting(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getPrivacySetting({
            ...config,
            success(res) {
                formatResponse('GetPrivacySettingSuccessCallbackResult', res);
                moduleHelper.send('GetPrivacySettingCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetPrivacySettingCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetPrivacySettingCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetScreenBrightness(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getScreenBrightness({
            ...config,
            success(res) {
                formatResponse('GetScreenBrightnessSuccessCallbackOption', res);
                moduleHelper.send('GetScreenBrightnessCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetScreenBrightnessCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetScreenBrightnessCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetScreenRecordingState(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getScreenRecordingState({
            ...config,
            success(res) {
                formatResponse('GetScreenRecordingStateSuccessCallbackResult', res);
                moduleHelper.send('GetScreenRecordingStateCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetScreenRecordingStateCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetScreenRecordingStateCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetSetting(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getSetting({
            ...config,
            success(res) {
                formatResponse('GetSettingSuccessCallbackResult', res);
                moduleHelper.send('GetSettingCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetSettingCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetSettingCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetShareInfo(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getShareInfo({
            ...config,
            success(res) {
                formatResponse('GetGroupEnterInfoSuccessCallbackResult', res);
                moduleHelper.send('GetShareInfoCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetShareInfoCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetShareInfoCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetStorageInfo(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getStorageInfo({
            ...config,
            success(res) {
                formatResponse('GetStorageInfoSuccessCallbackOption', res);
                moduleHelper.send('GetStorageInfoCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetStorageInfoCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetStorageInfoCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetSystemInfo(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getSystemInfo({
            ...config,
            success(res) {
                formatResponse('SystemInfo', res);
                moduleHelper.send('GetSystemInfoCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetSystemInfoCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetSystemInfoCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetSystemInfoAsync(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getSystemInfoAsync({
            ...config,
            success(res) {
                formatResponse('SystemInfo', res);
                moduleHelper.send('GetSystemInfoAsyncCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetSystemInfoAsyncCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetSystemInfoAsyncCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetUserInfo(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getUserInfo({
            ...config,
            success(res) {
                formatResponse('GetUserInfoSuccessCallbackResult', res);
                moduleHelper.send('GetUserInfoCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetUserInfoCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetUserInfoCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetUserInteractiveStorage(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getUserInteractiveStorage({
            ...config,
            success(res) {
                formatResponse('GetUserInteractiveStorageSuccessCallbackResult', res);
                moduleHelper.send('GetUserInteractiveStorageCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GetUserInteractiveStorageFailCallbackResult', res);
                moduleHelper.send('GetUserInteractiveStorageCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetUserInteractiveStorageCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetWeRunData(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getWeRunData({
            ...config,
            success(res) {
                formatResponse('GetWeRunDataSuccessCallbackResult', res);
                moduleHelper.send('GetWeRunDataCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetWeRunDataCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetWeRunDataCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_HideKeyboard(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.hideKeyboard({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('HideKeyboardCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('HideKeyboardCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('HideKeyboardCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_HideLoading(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.hideLoading({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('HideLoadingCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('HideLoadingCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('HideLoadingCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_HideShareMenu(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.hideShareMenu({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('HideShareMenuCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('HideShareMenuCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('HideShareMenuCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_HideToast(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.hideToast({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('HideToastCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('HideToastCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('HideToastCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_InitFaceDetect(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.initFaceDetect({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('InitFaceDetectCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('InitFaceDetectCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('InitFaceDetectCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_IsBluetoothDevicePaired(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.isBluetoothDevicePaired({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('IsBluetoothDevicePairedCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('IsBluetoothDevicePairedCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('IsBluetoothDevicePairedCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_JoinVoIPChat(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.joinVoIPChat({
            ...config,
            success(res) {
                formatResponse('JoinVoIPChatSuccessCallbackResult', res);
                moduleHelper.send('JoinVoIPChatCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('JoinVoIPChatError', res);
                moduleHelper.send('JoinVoIPChatCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('JoinVoIPChatError', res);
                moduleHelper.send('JoinVoIPChatCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_Login(conf, callbackId) {
        const config = formatJsonStr(conf);
        if (!config.timeout) {
            delete config.timeout;
        }
        wx.login({
            ...config,
            success(res) {
                formatResponse('LoginSuccessCallbackResult', res);
                moduleHelper.send('LoginCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('RequestFailCallbackErr', res);
                moduleHelper.send('LoginCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('LoginCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_MakeBluetoothPair(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.makeBluetoothPair({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('MakeBluetoothPairCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('MakeBluetoothPairCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('MakeBluetoothPairCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_NavigateToMiniProgram(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.navigateToMiniProgram({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('NavigateToMiniProgramCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('NavigateToMiniProgramCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('NavigateToMiniProgramCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_NotifyBLECharacteristicValueChange(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.notifyBLECharacteristicValueChange({
            ...config,
            success(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('NotifyBLECharacteristicValueChangeCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('NotifyBLECharacteristicValueChangeCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('NotifyBLECharacteristicValueChangeCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_OpenAppAuthorizeSetting(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.openAppAuthorizeSetting({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenAppAuthorizeSettingCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenAppAuthorizeSettingCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenAppAuthorizeSettingCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_OpenBluetoothAdapter(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.openBluetoothAdapter({
            ...config,
            success(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('OpenBluetoothAdapterCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('OpenBluetoothAdapterCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('OpenBluetoothAdapterCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_OpenCard(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.openCard({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenCardCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenCardCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenCardCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_OpenChannelsActivity(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.openChannelsActivity({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenChannelsActivityCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenChannelsActivityCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenChannelsActivityCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_OpenChannelsEvent(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.openChannelsEvent({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenChannelsEventCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenChannelsEventCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenChannelsEventCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_OpenChannelsLive(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.openChannelsLive({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenChannelsLiveCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenChannelsLiveCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenChannelsLiveCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_OpenChannelsUserProfile(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.openChannelsUserProfile({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenChannelsUserProfileCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenChannelsUserProfileCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenChannelsUserProfileCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_OpenCustomerServiceChat(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.openCustomerServiceChat({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenCustomerServiceChatCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenCustomerServiceChatCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenCustomerServiceChatCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_OpenCustomerServiceConversation(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.openCustomerServiceConversation({
            ...config,
            success(res) {
                formatResponse('OpenCustomerServiceConversationSuccessCallbackResult', res);
                moduleHelper.send('OpenCustomerServiceConversationCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenCustomerServiceConversationCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenCustomerServiceConversationCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_OpenPrivacyContract(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.openPrivacyContract({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenPrivacyContractCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenPrivacyContractCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenPrivacyContractCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_OpenSetting(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.openSetting({
            ...config,
            success(res) {
                formatResponse('OpenSettingSuccessCallbackResult', res);
                moduleHelper.send('OpenSettingCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenSettingCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenSettingCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_OpenSystemBluetoothSetting(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.openSystemBluetoothSetting({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenSystemBluetoothSettingCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenSystemBluetoothSettingCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenSystemBluetoothSettingCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_PreviewImage(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.previewImage({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('PreviewImageCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('PreviewImageCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('PreviewImageCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_PreviewMedia(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.previewMedia({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('PreviewMediaCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('PreviewMediaCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('PreviewMediaCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_ReadBLECharacteristicValue(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.readBLECharacteristicValue({
            ...config,
            success(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('ReadBLECharacteristicValueCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('ReadBLECharacteristicValueCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('ReadBLECharacteristicValueCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_RemoveStorage(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.removeStorage({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('RemoveStorageCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('RemoveStorageCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('RemoveStorageCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_RemoveUserCloudStorage(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.removeUserCloudStorage({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('RemoveUserCloudStorageCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('RemoveUserCloudStorageCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('RemoveUserCloudStorageCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_ReportScene(conf, callbackId) {
        const config = formatJsonStr(conf);
        if (GameGlobal.manager && GameGlobal.manager.setGameStage) {
            GameGlobal.manager.setGameStage(config.sceneId);
        }
        wx.reportScene({
            ...config,
            success(res) {
                formatResponse('ReportSceneSuccessCallbackResult', res);
                moduleHelper.send('ReportSceneCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('ReportSceneFailCallbackErr', res);
                moduleHelper.send('ReportSceneCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('ReportSceneError', res);
                moduleHelper.send('ReportSceneCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_RequestMidasFriendPayment(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.requestMidasFriendPayment({
            ...config,
            success(res) {
                formatResponse('RequestMidasFriendPaymentSuccessCallbackResult', res);
                moduleHelper.send('RequestMidasFriendPaymentCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('MidasFriendPaymentError', res);
                moduleHelper.send('RequestMidasFriendPaymentCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('MidasFriendPaymentError', res);
                moduleHelper.send('RequestMidasFriendPaymentCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_RequestMidasPayment(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.requestMidasPayment({
            ...config,
            success(res) {
                formatResponse('RequestMidasPaymentSuccessCallbackResult', res);
                moduleHelper.send('RequestMidasPaymentCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('RequestMidasPaymentFailCallbackErr', res);
                moduleHelper.send('RequestMidasPaymentCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('MidasPaymentError', res);
                moduleHelper.send('RequestMidasPaymentCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_RequestSubscribeMessage(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.requestSubscribeMessage({
            ...config,
            success(res) {
                formatResponse('RequestSubscribeMessageSuccessCallbackResult', res);
                moduleHelper.send('RequestSubscribeMessageCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('RequestSubscribeMessageFailCallbackResult', res);
                moduleHelper.send('RequestSubscribeMessageCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('RequestSubscribeMessageCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_RequestSubscribeSystemMessage(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.requestSubscribeSystemMessage({
            ...config,
            success(res) {
                formatResponse('RequestSubscribeSystemMessageSuccessCallbackResult', res);
                moduleHelper.send('RequestSubscribeSystemMessageCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('RequestSubscribeMessageFailCallbackResult', res);
                moduleHelper.send('RequestSubscribeSystemMessageCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('RequestSubscribeSystemMessageCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_RequirePrivacyAuthorize(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.requirePrivacyAuthorize({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('RequirePrivacyAuthorizeCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('RequirePrivacyAuthorizeCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('RequirePrivacyAuthorizeCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_RestartMiniProgram(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.restartMiniProgram({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('RestartMiniProgramCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('RestartMiniProgramCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('RestartMiniProgramCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_SaveFileToDisk(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.saveFileToDisk({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SaveFileToDiskCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SaveFileToDiskCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SaveFileToDiskCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_SaveImageToPhotosAlbum(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.saveImageToPhotosAlbum({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SaveImageToPhotosAlbumCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SaveImageToPhotosAlbumCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SaveImageToPhotosAlbumCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_ScanCode(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.scanCode({
            ...config,
            success(res) {
                formatResponse('ScanCodeSuccessCallbackResult', res);
                moduleHelper.send('ScanCodeCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ScanCodeCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ScanCodeCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_SetBLEMTU(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.setBLEMTU({
            ...config,
            success(res) {
                formatResponse('SetBLEMTUSuccessCallbackResult', res);
                moduleHelper.send('SetBLEMTUCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('SetBLEMTUFailCallbackResult', res);
                moduleHelper.send('SetBLEMTUCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetBLEMTUCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_SetBackgroundFetchToken(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.setBackgroundFetchToken({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetBackgroundFetchTokenCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetBackgroundFetchTokenCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetBackgroundFetchTokenCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_SetClipboardData(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.setClipboardData({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetClipboardDataCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetClipboardDataCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetClipboardDataCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_SetDeviceOrientation(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.setDeviceOrientation({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetDeviceOrientationCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetDeviceOrientationCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetDeviceOrientationCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_SetEnableDebug(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.setEnableDebug({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetEnableDebugCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetEnableDebugCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetEnableDebugCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_SetInnerAudioOption(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.setInnerAudioOption({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetInnerAudioOptionCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetInnerAudioOptionCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetInnerAudioOptionCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_SetKeepScreenOn(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.setKeepScreenOn({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetKeepScreenOnCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetKeepScreenOnCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetKeepScreenOnCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_SetMenuStyle(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.setMenuStyle({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetMenuStyleCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetMenuStyleCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetMenuStyleCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_SetScreenBrightness(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.setScreenBrightness({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetScreenBrightnessCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetScreenBrightnessCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetScreenBrightnessCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_SetStatusBarStyle(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.setStatusBarStyle({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetStatusBarStyleCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetStatusBarStyleCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetStatusBarStyleCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_SetUserCloudStorage(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.setUserCloudStorage({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetUserCloudStorageCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetUserCloudStorageCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetUserCloudStorageCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_SetVisualEffectOnCapture(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.setVisualEffectOnCapture({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetVisualEffectOnCaptureCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetVisualEffectOnCaptureCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('SetVisualEffectOnCaptureCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_ShowActionSheet(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.showActionSheet({
            ...config,
            success(res) {
                formatResponse('ShowActionSheetSuccessCallbackResult', res);
                moduleHelper.send('ShowActionSheetCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ShowActionSheetCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ShowActionSheetCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_ShowKeyboard(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.showKeyboard({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ShowKeyboardCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ShowKeyboardCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ShowKeyboardCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_ShowLoading(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.showLoading({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ShowLoadingCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ShowLoadingCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ShowLoadingCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_ShowModal(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.showModal({
            ...config,
            success(res) {
                formatResponse('ShowModalSuccessCallbackResult', res);
                moduleHelper.send('ShowModalCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ShowModalCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ShowModalCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_ShowShareImageMenu(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.showShareImageMenu({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ShowShareImageMenuCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ShowShareImageMenuCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ShowShareImageMenuCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_ShowShareMenu(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.showShareMenu({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ShowShareMenuCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ShowShareMenuCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ShowShareMenuCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_ShowToast(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.showToast({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ShowToastCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ShowToastCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('ShowToastCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_StartAccelerometer(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.startAccelerometer({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('StartAccelerometerCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('StartAccelerometerCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('StartAccelerometerCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_StartBeaconDiscovery(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.startBeaconDiscovery({
            ...config,
            success(res) {
                formatResponse('BeaconError', res);
                moduleHelper.send('StartBeaconDiscoveryCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('BeaconError', res);
                moduleHelper.send('StartBeaconDiscoveryCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('BeaconError', res);
                moduleHelper.send('StartBeaconDiscoveryCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_StartBluetoothDevicesDiscovery(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.startBluetoothDevicesDiscovery({
            ...config,
            success(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('StartBluetoothDevicesDiscoveryCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('StartBluetoothDevicesDiscoveryCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('StartBluetoothDevicesDiscoveryCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_StartCompass(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.startCompass({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('StartCompassCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('StartCompassCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('StartCompassCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_StartDeviceMotionListening(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.startDeviceMotionListening({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('StartDeviceMotionListeningCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('StartDeviceMotionListeningCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('StartDeviceMotionListeningCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_StopAccelerometer(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.stopAccelerometer({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('StopAccelerometerCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('StopAccelerometerCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('StopAccelerometerCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_StopBeaconDiscovery(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.stopBeaconDiscovery({
            ...config,
            success(res) {
                formatResponse('BeaconError', res);
                moduleHelper.send('StopBeaconDiscoveryCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('BeaconError', res);
                moduleHelper.send('StopBeaconDiscoveryCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('BeaconError', res);
                moduleHelper.send('StopBeaconDiscoveryCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_StopBluetoothDevicesDiscovery(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.stopBluetoothDevicesDiscovery({
            ...config,
            success(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('StopBluetoothDevicesDiscoveryCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('StopBluetoothDevicesDiscoveryCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('StopBluetoothDevicesDiscoveryCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_StopCompass(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.stopCompass({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('StopCompassCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('StopCompassCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('StopCompassCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_StopDeviceMotionListening(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.stopDeviceMotionListening({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('StopDeviceMotionListeningCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('StopDeviceMotionListeningCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('StopDeviceMotionListeningCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_StopFaceDetect(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.stopFaceDetect({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('StopFaceDetectCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('StopFaceDetectCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('StopFaceDetectCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_UpdateKeyboard(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.updateKeyboard({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('UpdateKeyboardCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('UpdateKeyboardCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('UpdateKeyboardCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_UpdateShareMenu(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.updateShareMenu({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('UpdateShareMenuCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('UpdateShareMenuCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('UpdateShareMenuCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_UpdateVoIPChatMuteConfig(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.updateVoIPChatMuteConfig({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('UpdateVoIPChatMuteConfigCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('UpdateVoIPChatMuteConfigCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('UpdateVoIPChatMuteConfigCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_UpdateWeChatApp(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.updateWeChatApp({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('UpdateWeChatAppCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('UpdateWeChatAppCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('UpdateWeChatAppCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_VibrateLong(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.vibrateLong({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('VibrateLongCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('VibrateLongCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('VibrateLongCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_VibrateShort(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.vibrateShort({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('VibrateShortCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('VibrateShortFailCallbackResult', res);
                moduleHelper.send('VibrateShortCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('VibrateShortCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_WriteBLECharacteristicValue(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.writeBLECharacteristicValue({
            ...config,
            success(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('WriteBLECharacteristicValueCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('WriteBLECharacteristicValueCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('BluetoothError', res);
                moduleHelper.send('WriteBLECharacteristicValueCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_StartGameLive(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.startGameLive({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('StartGameLiveCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('StartGameLiveCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('StartGameLiveCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_CheckGameLiveEnabled(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.checkGameLiveEnabled({
            ...config,
            success(res) {
                formatResponse('CheckGameLiveEnabledSuccessCallbackOption', res);
                moduleHelper.send('CheckGameLiveEnabledCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('CheckGameLiveEnabledCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('CheckGameLiveEnabledCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetUserCurrentGameliveInfo(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getUserCurrentGameliveInfo({
            ...config,
            success(res) {
                formatResponse('GetUserCurrentGameliveInfoSuccessCallbackOption', res);
                moduleHelper.send('GetUserCurrentGameliveInfoCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetUserCurrentGameliveInfoCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetUserCurrentGameliveInfoCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetUserRecentGameLiveInfo(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getUserRecentGameLiveInfo({
            ...config,
            success(res) {
                formatResponse('GetUserGameLiveDetailsSuccessCallbackOption', res);
                moduleHelper.send('GetUserRecentGameLiveInfoCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetUserRecentGameLiveInfoCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetUserRecentGameLiveInfoCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_GetUserGameLiveDetails(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getUserGameLiveDetails({
            ...config,
            success(res) {
                formatResponse('GetUserGameLiveDetailsSuccessCallbackOption', res);
                moduleHelper.send('GetUserGameLiveDetailsCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetUserGameLiveDetailsCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('GetUserGameLiveDetailsCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_OpenChannelsLiveCollection(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.openChannelsLiveCollection({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenChannelsLiveCollectionCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenChannelsLiveCollectionCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenChannelsLiveCollectionCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_OpenPage(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.openPage({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenPageCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenPageCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenPageCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_RequestMidasPaymentGameItem(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.requestMidasPaymentGameItem({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('RequestMidasPaymentGameItemCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('MidasPaymentGameItemError', res);
                moduleHelper.send('RequestMidasPaymentGameItemCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('MidasPaymentGameItemError', res);
                moduleHelper.send('RequestMidasPaymentGameItemCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_RequestSubscribeLiveActivity(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.requestSubscribeLiveActivity({
            ...config,
            success(res) {
                formatResponse('RequestSubscribeLiveActivitySuccessCallbackResult', res);
                moduleHelper.send('RequestSubscribeLiveActivityCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('RequestSubscribeLiveActivityCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('RequestSubscribeLiveActivityCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_OpenBusinessView(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.openBusinessView({
            ...config,
            success(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenBusinessViewCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenBusinessViewCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('OpenBusinessViewCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_ExitPointerLock() {
        wx.exitPointerLock();
    },
    WX_OperateGameRecorderVideo(option) {
        wx.operateGameRecorderVideo(formatJsonStr(option));
    },
    WX_RemoveStorageSync(key) {
        wx.removeStorageSync(key);
    },
    WX_ReportEvent(eventId, data) {
        wx.reportEvent(eventId, formatJsonStr(data));
    },
    WX_ReportMonitor(name, value) {
        wx.reportMonitor(name, value);
    },
    WX_ReportPerformance(id, value, dimensions) {
        wx.reportPerformance(id, value, dimensions);
    },
    WX_ReportUserBehaviorBranchAnalytics(option) {
        wx.reportUserBehaviorBranchAnalytics(formatJsonStr(option));
    },
    WX_RequestPointerLock() {
        wx.requestPointerLock();
    },
    WX_ReserveChannelsLive(option) {
        wx.reserveChannelsLive(formatJsonStr(option));
    },
    WX_RevokeBufferURL(url) {
        wx.revokeBufferURL(url);
    },
    WX_SetPreferredFramesPerSecond(fps) {
        wx.setPreferredFramesPerSecond(fps);
    },
    WX_SetStorageSync(key, data) {
        wx.setStorageSync(key, formatJsonStr(data));
    },
    WX_ShareAppMessage(option) {
        wx.shareAppMessage(formatJsonStr(option));
    },
    WX_TriggerGC() {
        wx.triggerGC();
    },
    WX_OnAccelerometerChange() {
        if (!OnAccelerometerChangeList) {
            OnAccelerometerChangeList = [];
        }
        const callback = (res) => {
            formatResponse('OnAccelerometerChangeListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnAccelerometerChangeCallback', resStr);
        };
        OnAccelerometerChangeList.push(callback);
        wx.onAccelerometerChange(callback);
    },
    WX_OffAccelerometerChange() {
        (OnAccelerometerChangeList || []).forEach((v) => {
            wx.offAccelerometerChange(v);
        });
    },
    WX_OnAudioInterruptionBegin() {
        if (!OnAudioInterruptionBeginList) {
            OnAudioInterruptionBeginList = [];
        }
        const callback = (res) => {
            formatResponse('GeneralCallbackResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnAudioInterruptionBeginCallback', resStr);
        };
        OnAudioInterruptionBeginList.push(callback);
        wx.onAudioInterruptionBegin(callback);
    },
    WX_OffAudioInterruptionBegin() {
        (OnAudioInterruptionBeginList || []).forEach((v) => {
            wx.offAudioInterruptionBegin(v);
        });
    },
    WX_OnAudioInterruptionEnd() {
        if (!OnAudioInterruptionEndList) {
            OnAudioInterruptionEndList = [];
        }
        const callback = (res) => {
            formatResponse('GeneralCallbackResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnAudioInterruptionEndCallback', resStr);
        };
        OnAudioInterruptionEndList.push(callback);
        wx.onAudioInterruptionEnd(callback);
    },
    WX_OffAudioInterruptionEnd() {
        (OnAudioInterruptionEndList || []).forEach((v) => {
            wx.offAudioInterruptionEnd(v);
        });
    },
    WX_OnBLEConnectionStateChange() {
        if (!OnBLEConnectionStateChangeList) {
            OnBLEConnectionStateChangeList = [];
        }
        const callback = (res) => {
            formatResponse('OnBLEConnectionStateChangeListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnBLEConnectionStateChangeCallback', resStr);
        };
        OnBLEConnectionStateChangeList.push(callback);
        wx.onBLEConnectionStateChange(callback);
    },
    WX_OffBLEConnectionStateChange() {
        (OnBLEConnectionStateChangeList || []).forEach((v) => {
            wx.offBLEConnectionStateChange(v);
        });
    },
    WX_OnBLEMTUChange() {
        if (!OnBLEMTUChangeList) {
            OnBLEMTUChangeList = [];
        }
        const callback = (res) => {
            formatResponse('OnBLEMTUChangeListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnBLEMTUChangeCallback', resStr);
        };
        OnBLEMTUChangeList.push(callback);
        wx.onBLEMTUChange(callback);
    },
    WX_OffBLEMTUChange() {
        (OnBLEMTUChangeList || []).forEach((v) => {
            wx.offBLEMTUChange(v);
        });
    },
    WX_OnBLEPeripheralConnectionStateChanged() {
        if (!OnBLEPeripheralConnectionStateChangedList) {
            OnBLEPeripheralConnectionStateChangedList = [];
        }
        const callback = (res) => {
            formatResponse('OnBLEPeripheralConnectionStateChangedListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnBLEPeripheralConnectionStateChangedCallback', resStr);
        };
        OnBLEPeripheralConnectionStateChangedList.push(callback);
        wx.onBLEPeripheralConnectionStateChanged(callback);
    },
    WX_OffBLEPeripheralConnectionStateChanged() {
        (OnBLEPeripheralConnectionStateChangedList || []).forEach((v) => {
            wx.offBLEPeripheralConnectionStateChanged(v);
        });
    },
    WX_OnBackgroundFetchData() {
        const callback = (res) => {
            formatResponse('OnBackgroundFetchDataListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnBackgroundFetchDataCallback', resStr);
        };
        wx.onBackgroundFetchData(callback);
    },
    WX_OnBeaconServiceChange() {
        if (!OnBeaconServiceChangeList) {
            OnBeaconServiceChangeList = [];
        }
        const callback = (res) => {
            formatResponse('OnBeaconServiceChangeListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnBeaconServiceChangeCallback', resStr);
        };
        OnBeaconServiceChangeList.push(callback);
        wx.onBeaconServiceChange(callback);
    },
    WX_OffBeaconServiceChange() {
        (OnBeaconServiceChangeList || []).forEach((v) => {
            wx.offBeaconServiceChange(v);
        });
    },
    WX_OnBeaconUpdate() {
        if (!OnBeaconUpdateList) {
            OnBeaconUpdateList = [];
        }
        const callback = (res) => {
            formatResponse('OnBeaconUpdateListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnBeaconUpdateCallback', resStr);
        };
        OnBeaconUpdateList.push(callback);
        wx.onBeaconUpdate(callback);
    },
    WX_OffBeaconUpdate() {
        (OnBeaconUpdateList || []).forEach((v) => {
            wx.offBeaconUpdate(v);
        });
    },
    WX_OnBluetoothAdapterStateChange() {
        if (!OnBluetoothAdapterStateChangeList) {
            OnBluetoothAdapterStateChangeList = [];
        }
        const callback = (res) => {
            formatResponse('OnBluetoothAdapterStateChangeListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnBluetoothAdapterStateChangeCallback', resStr);
        };
        OnBluetoothAdapterStateChangeList.push(callback);
        wx.onBluetoothAdapterStateChange(callback);
    },
    WX_OffBluetoothAdapterStateChange() {
        (OnBluetoothAdapterStateChangeList || []).forEach((v) => {
            wx.offBluetoothAdapterStateChange(v);
        });
    },
    WX_OnBluetoothDeviceFound() {
        if (!OnBluetoothDeviceFoundList) {
            OnBluetoothDeviceFoundList = [];
        }
        const callback = (res) => {
            formatResponse('OnBluetoothDeviceFoundListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnBluetoothDeviceFoundCallback', resStr);
        };
        OnBluetoothDeviceFoundList.push(callback);
        wx.onBluetoothDeviceFound(callback);
    },
    WX_OffBluetoothDeviceFound() {
        (OnBluetoothDeviceFoundList || []).forEach((v) => {
            wx.offBluetoothDeviceFound(v);
        });
    },
    WX_OnCompassChange() {
        if (!OnCompassChangeList) {
            OnCompassChangeList = [];
        }
        const callback = (res) => {
            formatResponse('OnCompassChangeListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnCompassChangeCallback', resStr);
        };
        OnCompassChangeList.push(callback);
        wx.onCompassChange(callback);
    },
    WX_OffCompassChange() {
        (OnCompassChangeList || []).forEach((v) => {
            wx.offCompassChange(v);
        });
    },
    WX_OnDeviceMotionChange() {
        if (!OnDeviceMotionChangeList) {
            OnDeviceMotionChangeList = [];
        }
        const callback = (res) => {
            formatResponse('OnDeviceMotionChangeListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnDeviceMotionChangeCallback', resStr);
        };
        OnDeviceMotionChangeList.push(callback);
        wx.onDeviceMotionChange(callback);
    },
    WX_OffDeviceMotionChange() {
        (OnDeviceMotionChangeList || []).forEach((v) => {
            wx.offDeviceMotionChange(v);
        });
    },
    WX_OnDeviceOrientationChange() {
        if (!OnDeviceOrientationChangeList) {
            OnDeviceOrientationChangeList = [];
        }
        const callback = (res) => {
            formatResponse('OnDeviceOrientationChangeListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnDeviceOrientationChangeCallback', resStr);
        };
        OnDeviceOrientationChangeList.push(callback);
        wx.onDeviceOrientationChange(callback);
    },
    WX_OffDeviceOrientationChange() {
        (OnDeviceOrientationChangeList || []).forEach((v) => {
            wx.offDeviceOrientationChange(v);
        });
    },
    WX_OnError() {
        if (!OnErrorList) {
            OnErrorList = [];
        }
        const callback = (res) => {
            formatResponse('Error', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnErrorCallback', resStr);
        };
        OnErrorList.push(callback);
        wx.onError(callback);
    },
    WX_OffError() {
        (OnErrorList || []).forEach((v) => {
            wx.offError(v);
        });
    },
    WX_OnHide() {
        if (!OnHideList) {
            OnHideList = [];
        }
        const callback = (res) => {
            formatResponse('GeneralCallbackResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnHideCallback', resStr);
        };
        OnHideList.push(callback);
        wx.onHide(callback);
    },
    WX_OffHide() {
        (OnHideList || []).forEach((v) => {
            wx.offHide(v);
        });
    },
    WX_OnInteractiveStorageModified() {
        if (!OnInteractiveStorageModifiedList) {
            OnInteractiveStorageModifiedList = [];
        }
        const callback = (res) => {
            const resStr = res;
            moduleHelper.send('_OnInteractiveStorageModifiedCallback', resStr);
        };
        OnInteractiveStorageModifiedList.push(callback);
        wx.onInteractiveStorageModified(callback);
    },
    WX_OffInteractiveStorageModified() {
        (OnInteractiveStorageModifiedList || []).forEach((v) => {
            wx.offInteractiveStorageModified(v);
        });
    },
    WX_OnKeyDown() {
        if (!OnKeyDownList) {
            OnKeyDownList = [];
        }
        const callback = (res) => {
            formatResponse('OnKeyDownListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnKeyDownCallback', resStr);
        };
        OnKeyDownList.push(callback);
        wx.onKeyDown(callback);
    },
    WX_OffKeyDown() {
        (OnKeyDownList || []).forEach((v) => {
            wx.offKeyDown(v);
        });
    },
    WX_OnKeyUp() {
        if (!OnKeyUpList) {
            OnKeyUpList = [];
        }
        const callback = (res) => {
            formatResponse('OnKeyDownListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnKeyUpCallback', resStr);
        };
        OnKeyUpList.push(callback);
        wx.onKeyUp(callback);
    },
    WX_OffKeyUp() {
        (OnKeyUpList || []).forEach((v) => {
            wx.offKeyUp(v);
        });
    },
    WX_OnKeyboardComplete() {
        if (!OnKeyboardCompleteList) {
            OnKeyboardCompleteList = [];
        }
        const callback = (res) => {
            formatResponse('OnKeyboardInputListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnKeyboardCompleteCallback', resStr);
        };
        OnKeyboardCompleteList.push(callback);
        wx.onKeyboardComplete(callback);
    },
    WX_OffKeyboardComplete() {
        (OnKeyboardCompleteList || []).forEach((v) => {
            wx.offKeyboardComplete(v);
        });
    },
    WX_OnKeyboardConfirm() {
        if (!OnKeyboardConfirmList) {
            OnKeyboardConfirmList = [];
        }
        const callback = (res) => {
            formatResponse('OnKeyboardInputListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnKeyboardConfirmCallback', resStr);
        };
        OnKeyboardConfirmList.push(callback);
        wx.onKeyboardConfirm(callback);
    },
    WX_OffKeyboardConfirm() {
        (OnKeyboardConfirmList || []).forEach((v) => {
            wx.offKeyboardConfirm(v);
        });
    },
    WX_OnKeyboardHeightChange() {
        if (!OnKeyboardHeightChangeList) {
            OnKeyboardHeightChangeList = [];
        }
        const callback = (res) => {
            formatResponse('OnKeyboardHeightChangeListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnKeyboardHeightChangeCallback', resStr);
        };
        OnKeyboardHeightChangeList.push(callback);
        wx.onKeyboardHeightChange(callback);
    },
    WX_OffKeyboardHeightChange() {
        (OnKeyboardHeightChangeList || []).forEach((v) => {
            wx.offKeyboardHeightChange(v);
        });
    },
    WX_OnKeyboardInput() {
        if (!OnKeyboardInputList) {
            OnKeyboardInputList = [];
        }
        const callback = (res) => {
            formatResponse('OnKeyboardInputListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnKeyboardInputCallback', resStr);
        };
        OnKeyboardInputList.push(callback);
        wx.onKeyboardInput(callback);
    },
    WX_OffKeyboardInput() {
        (OnKeyboardInputList || []).forEach((v) => {
            wx.offKeyboardInput(v);
        });
    },
    WX_OnMemoryWarning() {
        if (!OnMemoryWarningList) {
            OnMemoryWarningList = [];
        }
        const callback = (res) => {
            formatResponse('OnMemoryWarningListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnMemoryWarningCallback', resStr);
        };
        OnMemoryWarningList.push(callback);
        wx.onMemoryWarning(callback);
    },
    WX_OffMemoryWarning() {
        (OnMemoryWarningList || []).forEach((v) => {
            wx.offMemoryWarning(v);
        });
    },
    WX_OnMessage() {
        const callback = (res) => {
            const resStr = res;
            moduleHelper.send('_OnMessageCallback', resStr);
        };
        wx.onMessage(callback);
    },
    WX_OnMouseDown() {
        if (!OnMouseDownList) {
            OnMouseDownList = [];
        }
        const callback = (res) => {
            formatResponse('OnMouseDownListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnMouseDownCallback', resStr);
        };
        OnMouseDownList.push(callback);
        wx.onMouseDown(callback);
    },
    WX_OffMouseDown() {
        (OnMouseDownList || []).forEach((v) => {
            wx.offMouseDown(v);
        });
    },
    WX_OnMouseMove() {
        if (!OnMouseMoveList) {
            OnMouseMoveList = [];
        }
        const callback = (res) => {
            formatResponse('OnMouseMoveListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnMouseMoveCallback', resStr);
        };
        OnMouseMoveList.push(callback);
        wx.onMouseMove(callback);
    },
    WX_OffMouseMove() {
        (OnMouseMoveList || []).forEach((v) => {
            wx.offMouseMove(v);
        });
    },
    WX_OnMouseUp() {
        if (!OnMouseUpList) {
            OnMouseUpList = [];
        }
        const callback = (res) => {
            formatResponse('OnMouseDownListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnMouseUpCallback', resStr);
        };
        OnMouseUpList.push(callback);
        wx.onMouseUp(callback);
    },
    WX_OffMouseUp() {
        (OnMouseUpList || []).forEach((v) => {
            wx.offMouseUp(v);
        });
    },
    WX_OnNetworkStatusChange() {
        if (!OnNetworkStatusChangeList) {
            OnNetworkStatusChangeList = [];
        }
        const callback = (res) => {
            formatResponse('OnNetworkStatusChangeListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnNetworkStatusChangeCallback', resStr);
        };
        OnNetworkStatusChangeList.push(callback);
        wx.onNetworkStatusChange(callback);
    },
    WX_OffNetworkStatusChange() {
        (OnNetworkStatusChangeList || []).forEach((v) => {
            wx.offNetworkStatusChange(v);
        });
    },
    WX_OnNetworkWeakChange() {
        if (!OnNetworkWeakChangeList) {
            OnNetworkWeakChangeList = [];
        }
        const callback = (res) => {
            formatResponse('OnNetworkWeakChangeListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnNetworkWeakChangeCallback', resStr);
        };
        OnNetworkWeakChangeList.push(callback);
        wx.onNetworkWeakChange(callback);
    },
    WX_OffNetworkWeakChange() {
        (OnNetworkWeakChangeList || []).forEach((v) => {
            wx.offNetworkWeakChange(v);
        });
    },
    WX_OnScreenRecordingStateChanged() {
        if (!OnScreenRecordingStateChangedList) {
            OnScreenRecordingStateChangedList = [];
        }
        const callback = (res) => {
            formatResponse('OnScreenRecordingStateChangedListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnScreenRecordingStateChangedCallback', resStr);
        };
        OnScreenRecordingStateChangedList.push(callback);
        wx.onScreenRecordingStateChanged(callback);
    },
    WX_OffScreenRecordingStateChanged() {
        (OnScreenRecordingStateChangedList || []).forEach((v) => {
            wx.offScreenRecordingStateChanged(v);
        });
    },
    WX_OnShareMessageToFriend() {
        const callback = (res) => {
            formatResponse('OnShareMessageToFriendListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnShareMessageToFriendCallback', resStr);
        };
        wx.onShareMessageToFriend(callback);
    },
    WX_OnShow() {
        if (!OnShowList) {
            OnShowList = [];
        }
        const callback = (res) => {
            formatResponse('OnShowListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnShowCallback', resStr);
        };
        OnShowList.push(callback);
        wx.onShow(callback);
    },
    WX_OffShow() {
        (OnShowList || []).forEach((v) => {
            wx.offShow(v);
        });
    },
    WX_OnUnhandledRejection() {
        if (!OnUnhandledRejectionList) {
            OnUnhandledRejectionList = [];
        }
        const callback = (res) => {
            formatResponse('OnUnhandledRejectionListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnUnhandledRejectionCallback', resStr);
        };
        OnUnhandledRejectionList.push(callback);
        wx.onUnhandledRejection(callback);
    },
    WX_OffUnhandledRejection() {
        (OnUnhandledRejectionList || []).forEach((v) => {
            wx.offUnhandledRejection(v);
        });
    },
    WX_OnUserCaptureScreen() {
        if (!OnUserCaptureScreenList) {
            OnUserCaptureScreenList = [];
        }
        const callback = (res) => {
            formatResponse('GeneralCallbackResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnUserCaptureScreenCallback', resStr);
        };
        OnUserCaptureScreenList.push(callback);
        wx.onUserCaptureScreen(callback);
    },
    WX_OffUserCaptureScreen() {
        (OnUserCaptureScreenList || []).forEach((v) => {
            wx.offUserCaptureScreen(v);
        });
    },
    WX_OnVoIPChatInterrupted() {
        if (!OnVoIPChatInterruptedList) {
            OnVoIPChatInterruptedList = [];
        }
        const callback = (res) => {
            formatResponse('OnVoIPChatInterruptedListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnVoIPChatInterruptedCallback', resStr);
        };
        OnVoIPChatInterruptedList.push(callback);
        wx.onVoIPChatInterrupted(callback);
    },
    WX_OffVoIPChatInterrupted() {
        (OnVoIPChatInterruptedList || []).forEach((v) => {
            wx.offVoIPChatInterrupted(v);
        });
    },
    WX_OnVoIPChatMembersChanged() {
        if (!OnVoIPChatMembersChangedList) {
            OnVoIPChatMembersChangedList = [];
        }
        const callback = (res) => {
            formatResponse('OnVoIPChatMembersChangedListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnVoIPChatMembersChangedCallback', resStr);
        };
        OnVoIPChatMembersChangedList.push(callback);
        wx.onVoIPChatMembersChanged(callback);
    },
    WX_OffVoIPChatMembersChanged() {
        (OnVoIPChatMembersChangedList || []).forEach((v) => {
            wx.offVoIPChatMembersChanged(v);
        });
    },
    WX_OnVoIPChatSpeakersChanged() {
        if (!OnVoIPChatSpeakersChangedList) {
            OnVoIPChatSpeakersChangedList = [];
        }
        const callback = (res) => {
            formatResponse('OnVoIPChatSpeakersChangedListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnVoIPChatSpeakersChangedCallback', resStr);
        };
        OnVoIPChatSpeakersChangedList.push(callback);
        wx.onVoIPChatSpeakersChanged(callback);
    },
    WX_OffVoIPChatSpeakersChanged() {
        (OnVoIPChatSpeakersChangedList || []).forEach((v) => {
            wx.offVoIPChatSpeakersChanged(v);
        });
    },
    WX_OnVoIPChatStateChanged() {
        if (!OnVoIPChatStateChangedList) {
            OnVoIPChatStateChangedList = [];
        }
        const callback = (res) => {
            formatResponse('OnVoIPChatStateChangedListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnVoIPChatStateChangedCallback', resStr);
        };
        OnVoIPChatStateChangedList.push(callback);
        wx.onVoIPChatStateChanged(callback);
    },
    WX_OffVoIPChatStateChanged() {
        (OnVoIPChatStateChangedList || []).forEach((v) => {
            wx.offVoIPChatStateChanged(v);
        });
    },
    WX_OnWheel() {
        if (!OnWheelList) {
            OnWheelList = [];
        }
        const callback = (res) => {
            formatResponse('OnWheelListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnWheelCallback', resStr);
        };
        OnWheelList.push(callback);
        wx.onWheel(callback);
    },
    WX_OffWheel() {
        (OnWheelList || []).forEach((v) => {
            wx.offWheel(v);
        });
    },
    WX_OnWindowResize() {
        if (!OnWindowResizeList) {
            OnWindowResizeList = [];
        }
        const callback = (res) => {
            formatResponse('OnWindowResizeListenerResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnWindowResizeCallback', resStr);
        };
        OnWindowResizeList.push(callback);
        wx.onWindowResize(callback);
    },
    WX_OffWindowResize() {
        (OnWindowResizeList || []).forEach((v) => {
            wx.offWindowResize(v);
        });
    },
    WX_OnAddToFavorites() {
        const callback = (res) => {
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnAddToFavoritesCallback', resStr);
            return wxOnAddToFavoritesResolveConf;
        };
        wx.onAddToFavorites(callback);
    },
    WX_OnAddToFavorites_Resolve(conf) {
        try {
            wxOnAddToFavoritesResolveConf = formatJsonStr(conf);
            return;
        }
        catch (e) {
        }
        wxOnAddToFavoritesResolveConf = {};
    },
    WX_OffAddToFavorites() {
        wx.offAddToFavorites();
    },
    WX_OnCopyUrl() {
        const callback = (res) => {
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnCopyUrlCallback', resStr);
            return wxOnCopyUrlResolveConf;
        };
        wx.onCopyUrl(callback);
    },
    WX_OnCopyUrl_Resolve(conf) {
        try {
            wxOnCopyUrlResolveConf = formatJsonStr(conf);
            return;
        }
        catch (e) {
        }
        wxOnCopyUrlResolveConf = {};
    },
    WX_OffCopyUrl() {
        wx.offCopyUrl();
    },
    WX_OnHandoff() {
        const callback = (res) => {
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnHandoffCallback', resStr);
            return wxOnHandoffResolveConf;
        };
        wx.onHandoff(callback);
    },
    WX_OnHandoff_Resolve(conf) {
        try {
            wxOnHandoffResolveConf = formatJsonStr(conf);
            return;
        }
        catch (e) {
        }
        wxOnHandoffResolveConf = {};
    },
    WX_OffHandoff() {
        wx.offHandoff();
    },
    WX_OnShareTimeline() {
        const callback = (res) => {
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnShareTimelineCallback', resStr);
            return wxOnShareTimelineResolveConf;
        };
        wx.onShareTimeline(callback);
    },
    WX_OnShareTimeline_Resolve(conf) {
        try {
            wxOnShareTimelineResolveConf = formatJsonStr(conf);
            return;
        }
        catch (e) {
        }
        wxOnShareTimelineResolveConf = {};
    },
    WX_OffShareTimeline() {
        wx.offShareTimeline();
    },
    WX_OnGameLiveStateChange() {
        const callback = (res) => {
            formatResponse('OnGameLiveStateChangeCallbackResult', res);
            const resStr = stringifyRes(res);
            moduleHelper.send('_OnGameLiveStateChangeCallback', resStr);
            return wxOnGameLiveStateChangeResolveConf;
        };
        wx.onGameLiveStateChange(callback);
    },
    WX_OnGameLiveStateChange_Resolve(conf) {
        try {
            wxOnGameLiveStateChangeResolveConf = formatJsonStr(conf);
            return;
        }
        catch (e) {
        }
        wxOnGameLiveStateChangeResolveConf = {};
    },
    WX_OffGameLiveStateChange() {
        wx.offGameLiveStateChange();
    },
    WX_SetHandoffQuery(query) {
        const res = wx.setHandoffQuery(formatJsonStr(query));
        return res;
    },
    WX_GetAccountInfoSync() {
        const res = wx.getAccountInfoSync();
        formatResponse('AccountInfo', res);
        return JSON.stringify(res);
    },
    WX_GetAppAuthorizeSetting() {
        const res = wx.getAppAuthorizeSetting();
        formatResponse('AppAuthorizeSetting', JSON.parse(JSON.stringify(res)));
        return JSON.stringify(res);
    },
    WX_GetAppBaseInfo() {
        const res = wx.getAppBaseInfo();
        formatResponse('AppBaseInfo', res);
        return JSON.stringify(res);
    },
    WX_GetBatteryInfoSync() {
        const res = wx.getBatteryInfoSync();
        formatResponse('GetBatteryInfoSyncResult', res);
        return JSON.stringify(res);
    },
    WX_GetDeviceInfo() {
        const res = wx.getDeviceInfo();
        formatResponse('DeviceInfo', res);
        return JSON.stringify(res);
    },
    WX_GetEnterOptionsSync() {
        const res = wx.getEnterOptionsSync();
        formatResponse('EnterOptionsGame', res);
        return JSON.stringify(res);
    },
    WX_GetExptInfoSync(keys) {
        const res = wx.getExptInfoSync(formatJsonStr(keys));
        formatResponse('IAnyObject', res);
        return JSON.stringify(res);
    },
    WX_GetExtConfigSync() {
        const res = wx.getExtConfigSync();
        formatResponse('IAnyObject', res);
        return JSON.stringify(res);
    },
    WX_GetLaunchOptionsSync() {
        const res = wx.getLaunchOptionsSync();
        formatResponse('LaunchOptionsGame', res);
        return JSON.stringify(res);
    },
    WX_GetMenuButtonBoundingClientRect() {
        const res = wx.getMenuButtonBoundingClientRect();
        formatResponse('ClientRect', res);
        return JSON.stringify(res);
    },
    WX_GetStorageInfoSync() {
        const res = wx.getStorageInfoSync();
        formatResponse('GetStorageInfoSyncOption', res);
        return JSON.stringify(res);
    },
    WX_GetSystemInfoSync() {
        const res = wx.getSystemInfoSync();
        formatResponse('SystemInfo', res);
        return JSON.stringify(res);
    },
    WX_GetSystemSetting() {
        const res = wx.getSystemSetting();
        formatResponse('SystemSetting', JSON.parse(JSON.stringify(res)));
        return JSON.stringify(res);
    },
    WX_GetWindowInfo() {
        const res = wx.getWindowInfo();
        formatResponse('WindowInfo', res);
        return JSON.stringify(res);
    },
    WX_CreateImageData() {
        const res = wx.createImageData();
        formatResponse('ImageData', res);
        return JSON.stringify(res);
    },
    WX_CreatePath2D() {
        const res = wx.createPath2D();
        formatResponse('Path2D', res);
        return JSON.stringify(res);
    },
    WX_IsPointerLocked() {
        const res = wx.isPointerLocked();
        return res;
    },
    WX_IsVKSupport(version) {
        const res = wx.isVKSupport(formatJsonStr(version));
        return res;
    },
    WX_SetCursor(path, x, y) {
        const res = wx.setCursor(formatJsonStr(path), x, y);
        return res;
    },
    WX_SetMessageToFriendQuery(option) {
        const res = wx.setMessageToFriendQuery(formatJsonStr(option));
        return res;
    },
    WX_GetTextLineHeight(option) {
        const res = wx.getTextLineHeight(formatJsonStr(option));
        return res;
    },
    WX_LoadFont(path) {
        const res = wx.loadFont(formatJsonStr(path));
        return res;
    },
    WX_GetGameLiveState() {
        const res = wx.getGameLiveState();
        formatResponse('GameLiveState', res);
        return JSON.stringify(res);
    },
    WX_DownloadFile(conf) {
        const config = formatJsonStr(conf);
        const callbackId = uid();
        const obj = wx.downloadFile({
            ...config,
            success(res) {
                formatResponse('DownloadFileSuccessCallbackResult', res);
                moduleHelper.send('DownloadFileCallback', JSON.stringify({
                    callbackId, type: 'success', res: JSON.stringify(res),
                }));
            },
            fail(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('DownloadFileCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res),
                }));
            },
            complete(res) {
                formatResponse('GeneralCallbackResult', res);
                moduleHelper.send('DownloadFileCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res),
                }));
            },
        });
        DownloadTaskList[callbackId] = obj;
        return callbackId;
    },
    WX_CreateFeedbackButton(option) {
        const obj = wx.createFeedbackButton(formatJsonStr(option));
        const key = uid();
        FeedbackButtonList[key] = obj;
        return key;
    },
    WX_GetLogManager(option) {
        const obj = wx.getLogManager(formatJsonStr(option));
        const key = uid();
        LogManagerList[key] = obj;
        return key;
    },
    WX_GetRealtimeLogManager() {
        const obj = wx.getRealtimeLogManager();
        const key = uid();
        RealtimeLogManagerList[key] = obj;
        return key;
    },
    WX_GetUpdateManager() {
        const obj = wx.getUpdateManager();
        const key = uid();
        UpdateManagerList[key] = obj;
        return key;
    },
    WX_CreateVideoDecoder() {
        const obj = wx.createVideoDecoder();
        const key = uid();
        VideoDecoderList[key] = obj;
        return key;
    },
    WX_DownloadTaskAbort(id) {
        const obj = getDownloadTaskObject(id);
        if (!obj) {
            return;
        }
        obj.abort();
    },
    WX_DownloadTaskOffHeadersReceived(id) {
        const obj = getDownloadTaskObject(id);
        if (!obj) {
            return;
        }
        offEventCallback(wxDownloadTaskHeadersReceivedList, (v) => {
            obj.offHeadersReceived(v);
        }, id);
    },
    WX_DownloadTaskOffProgressUpdate(id) {
        const obj = getDownloadTaskObject(id);
        if (!obj) {
            return;
        }
        offEventCallback(wxDownloadTaskProgressUpdateList, (v) => {
            obj.offProgressUpdate(v);
        }, id);
    },
    WX_DownloadTaskOnHeadersReceived(id) {
        const obj = getDownloadTaskObject(id);
        if (!obj) {
            return;
        }
        const callback = onEventCallback(wxDownloadTaskHeadersReceivedList, '_DownloadTaskOnHeadersReceivedCallback', id, id);
        obj.onHeadersReceived(callback);
    },
    WX_DownloadTaskOnProgressUpdate(id) {
        const obj = getDownloadTaskObject(id);
        if (!obj) {
            return;
        }
        const callback = onEventCallback(wxDownloadTaskProgressUpdateList, '_DownloadTaskOnProgressUpdateCallback', id, id);
        obj.onProgressUpdate(callback);
    },
    WXFeedbackButtonSetProperty(id, key, value) {
        const obj = getFeedbackButtonObject(id);
        if (!obj) {
            return;
        }
        if (/^\s*(\{.*\}|\[.*\])\s*$/.test(value)) {
            try {
                const jsonValue = JSON.parse(value);
                Object.assign(obj[key], jsonValue);
            }
            catch (e) {
                obj[key] = value;
            }
        }
        else {
            obj[key] = value;
        }
    },
    WX_FeedbackButtonDestroy(id) {
        const obj = getFeedbackButtonObject(id);
        if (!obj) {
            return;
        }
        obj.destroy();
    },
    WX_FeedbackButtonHide(id) {
        const obj = getFeedbackButtonObject(id);
        if (!obj) {
            return;
        }
        obj.hide();
    },
    WX_FeedbackButtonOffTap(id) {
        const obj = getFeedbackButtonObject(id);
        if (!obj) {
            return;
        }
        offEventCallback(wxFeedbackButtonTapList, (v) => {
            obj.offTap(v);
        }, id);
    },
    WX_FeedbackButtonOnTap(id) {
        const obj = getFeedbackButtonObject(id);
        if (!obj) {
            return;
        }
        const callback = onEventCallback(wxFeedbackButtonTapList, '_FeedbackButtonOnTapCallback', id, id);
        obj.onTap(callback);
    },
    WX_FeedbackButtonShow(id) {
        const obj = getFeedbackButtonObject(id);
        if (!obj) {
            return;
        }
        obj.show();
    },
    WX_LogManagerDebug(id, args) {
        const obj = getLogManagerObject(id);
        if (!obj) {
            return;
        }
        obj.debug(args);
    },
    WX_LogManagerInfo(id, args) {
        const obj = getLogManagerObject(id);
        if (!obj) {
            return;
        }
        obj.info(args);
    },
    WX_LogManagerLog(id, args) {
        const obj = getLogManagerObject(id);
        if (!obj) {
            return;
        }
        obj.log(args);
    },
    WX_LogManagerWarn(id, args) {
        const obj = getLogManagerObject(id);
        if (!obj) {
            return;
        }
        obj.warn(args);
    },
    WX_RealtimeLogManagerAddFilterMsg(id, msg) {
        const obj = getRealtimeLogManagerObject(id);
        if (!obj) {
            return;
        }
        obj.addFilterMsg(msg);
    },
    WX_RealtimeLogManagerError(id, args) {
        const obj = getRealtimeLogManagerObject(id);
        if (!obj) {
            return;
        }
        obj.error(args);
    },
    WX_RealtimeLogManagerInfo(id, args) {
        const obj = getRealtimeLogManagerObject(id);
        if (!obj) {
            return;
        }
        obj.info(args);
    },
    WX_RealtimeLogManagerSetFilterMsg(id, msg) {
        const obj = getRealtimeLogManagerObject(id);
        if (!obj) {
            return;
        }
        obj.setFilterMsg(msg);
    },
    WX_RealtimeLogManagerWarn(id, args) {
        const obj = getRealtimeLogManagerObject(id);
        if (!obj) {
            return;
        }
        obj.warn(args);
    },
    WX_UpdateManagerApplyUpdate(id) {
        const obj = getUpdateManagerObject(id);
        if (!obj) {
            return;
        }
        obj.applyUpdate();
    },
    WX_UpdateManagerOnCheckForUpdate(id) {
        const obj = getUpdateManagerObject(id);
        if (!obj) {
            return;
        }
        const callback = (res) => {
            formatResponse('OnCheckForUpdateListenerResult', res);
            const resStr = JSON.stringify({
                callbackId: id,
                res: JSON.stringify(res),
            });
            moduleHelper.send('_UpdateManagerOnCheckForUpdateCallback', resStr);
        };
        obj.onCheckForUpdate(callback);
    },
    WX_UpdateManagerOnUpdateFailed(id) {
        const obj = getUpdateManagerObject(id);
        if (!obj) {
            return;
        }
        const callback = (res) => {
            formatResponse('GeneralCallbackResult', res);
            const resStr = JSON.stringify({
                callbackId: id,
                res: JSON.stringify(res),
            });
            moduleHelper.send('_UpdateManagerOnUpdateFailedCallback', resStr);
        };
        obj.onUpdateFailed(callback);
    },
    WX_UpdateManagerOnUpdateReady(id) {
        const obj = getUpdateManagerObject(id);
        if (!obj) {
            return;
        }
        const callback = (res) => {
            formatResponse('GeneralCallbackResult', res);
            const resStr = JSON.stringify({
                callbackId: id,
                res: JSON.stringify(res),
            });
            moduleHelper.send('_UpdateManagerOnUpdateReadyCallback', resStr);
        };
        obj.onUpdateReady(callback);
    },
    WX_VideoDecoderGetFrameData(id) {
        const obj = getVideoDecoderObject(id);
        if (!obj) {
            return JSON.stringify(formatResponse('FrameDataOptions'));
        }
        return JSON.stringify(formatResponse('FrameDataOptions', obj.getFrameData(), id));
    },
    WX_VideoDecoderRemove(id) {
        const obj = getVideoDecoderObject(id);
        if (!obj) {
            return;
        }
        obj.remove();
    },
    WX_VideoDecoderSeek(id, position) {
        const obj = getVideoDecoderObject(id);
        if (!obj) {
            return;
        }
        obj.seek(position);
    },
    WX_VideoDecoderStart(id, option) {
        const obj = getVideoDecoderObject(id);
        if (!obj) {
            return;
        }
        obj.start(formatJsonStr(option));
    },
    WX_VideoDecoderStop(id) {
        const obj = getVideoDecoderObject(id);
        if (!obj) {
            return;
        }
        obj.stop();
    },
    WX_VideoDecoderOff(id, eventName) {
        const obj = getVideoDecoderObject(id);
        if (!obj) {
            return;
        }
        offEventCallback(wxVideoDecoderList, (v) => {
            obj.off(eventName, v);
        }, id);
    },
    WX_VideoDecoderOn(id, eventName) {
        const obj = getVideoDecoderObject(id);
        if (!obj) {
            return;
        }
        const callback = onEventCallback(wxVideoDecoderList, '_VideoDecoderOnCallback', id, id + eventName);
        obj.on(eventName, callback);
    },
};
