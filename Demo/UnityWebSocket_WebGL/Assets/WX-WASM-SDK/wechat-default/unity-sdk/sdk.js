import ResType from "./resType";
import moduleHelper from "./module-helper";

var identifierCache = [];

function formatIdentifier(identifier){
    if(Math.abs(identifier)<2147483648){
        return Math.round(identifier);
    }
    for(var key in identifierCache){
        if(identifierCache[key] && identifierCache[key].key === identifier){
            return identifierCache[key].value;
        }
    }
    var value = parseInt(Math.random()*2147483648);
    while(identifierCache.some(v=>v.value === value)){
        value++;
    }
    identifierCache.push({
        key:identifier,
        value
    });
    if(identifierCache.length>30){
        identifierCache.shift();
    }
    return value;
}

function formatTouchEvent(v){
    //这里将坐标转换为Unity的坐标
    return {
        identifier:formatIdentifier(v.identifier),
        clientX : v.clientX * devicePixelRatio,
        clientY :(window.innerHeight - v.clientY) * devicePixelRatio,
        pageX : v.pageX * devicePixelRatio,
        pageY : (window.innerHeight - v.pageY) * devicePixelRatio
    }
}

function formatResponse(type,data){
    let conf = ResType[type];
    let typeMap = { "array":[],"string":"","int":0,"bool":false,"object":{} };
    if(!conf){
        return;
    }
    if(conf && !data){
        data = {};
    }
    for(var key in conf){
        if(data[key] == null){
            if(typeof typeMap[conf[key]] ==="undefined"){
                data[key] = {};
                if(ResType[conf[key]]){
                    formatResponse(conf[key],data[key])
                }
            }else{
                data[key] = typeMap[conf[key]];
            }
        }else if(typeof data[key] == "object" && ResType[conf[key]]){
            formatResponse(conf[key],data[key])
        }else if(typeof data[key] == "object" && conf[key] === "object"){
            Object.keys(data[key]).forEach(v=>{
               data[key][v] += '';
            });
        }
    }
}

function formatJsonStr(str){
    if(!str){
        return {};
    }
    let conf = JSON.parse(str);
    var keys = Object.keys(conf);
    keys.forEach(v=>{
        if(conf[v] === null){
            delete conf[v];
        }
    });
    return conf;
}

export default {
    WX_AddCard(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.addCard({
            ...conf,
            success(res){
                formatResponse("AddCardSuccessCallbackResult",res);
                moduleHelper.send('AddCardCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('AddCardCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('AddCardCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_AuthPrivateMessage(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.authPrivateMessage({
            ...conf,
            success(res){
                formatResponse("AuthPrivateMessageSuccessCallbackResult",res);
                moduleHelper.send('AuthPrivateMessageCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('AuthPrivateMessageCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('AuthPrivateMessageCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_Authorize(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.authorize({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('AuthorizeCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('AuthorizeCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('AuthorizeCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_CheckHandoffEnabled(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.checkHandoffEnabled({
            ...conf,
            success(res){
                formatResponse("CheckHandoffEnabledSuccessCallbackResult",res);
                moduleHelper.send('CheckHandoffEnabledCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('CheckHandoffEnabledCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('CheckHandoffEnabledCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_CheckIsUserAdvisedToRest(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.checkIsUserAdvisedToRest({
            ...conf,
            success(res){
                formatResponse("CheckIsUserAdvisedToRestSuccessCallbackResult",res);
                moduleHelper.send('CheckIsUserAdvisedToRestCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('CheckIsUserAdvisedToRestCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('CheckIsUserAdvisedToRestCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_CheckSession(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.checkSession({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('CheckSessionCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('CheckSessionCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('CheckSessionCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_ChooseImage(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.chooseImage({
            ...conf,
            success(res){
                formatResponse("ChooseImageSuccessCallbackResult",res);
                moduleHelper.send('ChooseImageCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ChooseImageCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ChooseImageCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_CloseBLEConnection(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.closeBLEConnection({
            ...conf,
            success(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('CloseBLEConnectionCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('CloseBLEConnectionCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('CloseBLEConnectionCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_CloseBluetoothAdapter(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.closeBluetoothAdapter({
            ...conf,
            success(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('CloseBluetoothAdapterCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('CloseBluetoothAdapterCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('CloseBluetoothAdapterCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_CloseSocket(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.closeSocket({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('CloseSocketCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('CloseSocketCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('CloseSocketCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_CreateBLEConnection(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.createBLEConnection({
            ...conf,
            success(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('CreateBLEConnectionCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('CreateBLEConnectionCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('CreateBLEConnectionCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_CreateBLEPeripheralServer(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.createBLEPeripheralServer({
            ...conf,
            success(res){
                formatResponse("CreateBLEPeripheralServerSuccessCallbackResult",res);
                moduleHelper.send('CreateBLEPeripheralServerCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('CreateBLEPeripheralServerCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('CreateBLEPeripheralServerCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_ExitMiniProgram(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.exitMiniProgram({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ExitMiniProgramCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ExitMiniProgramCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ExitMiniProgramCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_ExitVoIPChat(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.exitVoIPChat({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ExitVoIPChatCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ExitVoIPChatCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ExitVoIPChatCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_FaceDetect(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.faceDetect({
            ...conf,
            success(res){
                formatResponse("FaceDetectSuccessCallbackResult",res);
                moduleHelper.send('FaceDetectCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('FaceDetectCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('FaceDetectCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetAvailableAudioSources(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getAvailableAudioSources({
            ...conf,
            success(res){
                formatResponse("GetAvailableAudioSourcesSuccessCallbackResult",res);
                moduleHelper.send('GetAvailableAudioSourcesCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetAvailableAudioSourcesCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetAvailableAudioSourcesCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetBLEDeviceCharacteristics(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getBLEDeviceCharacteristics({
            ...conf,
            success(res){
                formatResponse("GetBLEDeviceCharacteristicsSuccessCallbackResult",res);
                moduleHelper.send('GetBLEDeviceCharacteristicsCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('GetBLEDeviceCharacteristicsCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('GetBLEDeviceCharacteristicsCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetBLEDeviceRSSI(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getBLEDeviceRSSI({
            ...conf,
            success(res){
                formatResponse("GetBLEDeviceRSSISuccessCallbackResult",res);
                moduleHelper.send('GetBLEDeviceRSSICallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetBLEDeviceRSSICallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetBLEDeviceRSSICallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetBLEDeviceServices(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getBLEDeviceServices({
            ...conf,
            success(res){
                formatResponse("GetBLEDeviceServicesSuccessCallbackResult",res);
                moduleHelper.send('GetBLEDeviceServicesCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('GetBLEDeviceServicesCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('GetBLEDeviceServicesCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetBLEMTU(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getBLEMTU({
            ...conf,
            success(res){
                formatResponse("GetBLEMTUSuccessCallbackResult",res);
                moduleHelper.send('GetBLEMTUCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('GetBLEMTUCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('GetBLEMTUCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetBatteryInfo(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getBatteryInfo({
            ...conf,
            success(res){
                formatResponse("GetBatteryInfoSuccessCallbackResult",res);
                moduleHelper.send('GetBatteryInfoCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetBatteryInfoCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetBatteryInfoCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetBeacons(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getBeacons({
            ...conf,
            success(res){
                formatResponse("GetBeaconsSuccessCallbackResult",res);
                moduleHelper.send('GetBeaconsCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("BeaconError",res);
                moduleHelper.send('GetBeaconsCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("BeaconError",res);
                moduleHelper.send('GetBeaconsCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetBluetoothAdapterState(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getBluetoothAdapterState({
            ...conf,
            success(res){
                formatResponse("GetBluetoothAdapterStateSuccessCallbackResult",res);
                moduleHelper.send('GetBluetoothAdapterStateCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('GetBluetoothAdapterStateCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('GetBluetoothAdapterStateCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetBluetoothDevices(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getBluetoothDevices({
            ...conf,
            success(res){
                formatResponse("GetBluetoothDevicesSuccessCallbackResult",res);
                moduleHelper.send('GetBluetoothDevicesCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('GetBluetoothDevicesCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('GetBluetoothDevicesCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetChannelsLiveInfo(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getChannelsLiveInfo({
            ...conf,
            success(res){
                formatResponse("GetChannelsLiveInfoSuccessCallbackResult",res);
                moduleHelper.send('GetChannelsLiveInfoCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetChannelsLiveInfoCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetChannelsLiveInfoCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetChannelsLiveNoticeInfo(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getChannelsLiveNoticeInfo({
            ...conf,
            success(res){
                formatResponse("GetChannelsLiveNoticeInfoSuccessCallbackResult",res);
                moduleHelper.send('GetChannelsLiveNoticeInfoCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetChannelsLiveNoticeInfoCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetChannelsLiveNoticeInfoCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetClipboardData(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getClipboardData({
            ...conf,
            success(res){
                formatResponse("GetClipboardDataSuccessCallbackOption",res);
                moduleHelper.send('GetClipboardDataCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetClipboardDataCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetClipboardDataCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetConnectedBluetoothDevices(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getConnectedBluetoothDevices({
            ...conf,
            success(res){
                formatResponse("GetConnectedBluetoothDevicesSuccessCallbackResult",res);
                moduleHelper.send('GetConnectedBluetoothDevicesCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('GetConnectedBluetoothDevicesCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('GetConnectedBluetoothDevicesCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetExtConfig(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getExtConfig({
            ...conf,
            success(res){
                formatResponse("GetExtConfigSuccessCallbackResult",res);
                moduleHelper.send('GetExtConfigCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetExtConfigCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetExtConfigCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetFileInfo(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getFileInfo({
            ...conf,
            success(res){
                formatResponse("WxGetFileInfoSuccessCallbackResult",res);
                moduleHelper.send('GetFileInfoCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetFileInfoCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetFileInfoCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetFriendCloudStorage(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getFriendCloudStorage({
            ...conf,
            success(res){
                formatResponse("GetFriendCloudStorageSuccessCallbackResult",res);
                moduleHelper.send('GetFriendCloudStorageCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetFriendCloudStorageCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetFriendCloudStorageCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetGroupCloudStorage(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getGroupCloudStorage({
            ...conf,
            success(res){
                formatResponse("GetGroupCloudStorageSuccessCallbackResult",res);
                moduleHelper.send('GetGroupCloudStorageCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetGroupCloudStorageCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetGroupCloudStorageCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetGroupEnterInfo(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getGroupEnterInfo({
            ...conf,
            success(res){
                formatResponse("GetGroupEnterInfoSuccessCallbackResult",res);
                moduleHelper.send('GetGroupEnterInfoCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetGroupEnterInfoCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetGroupEnterInfoCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetGroupInfo(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getGroupInfo({
            ...conf,
            success(res){
                formatResponse("GetGroupInfoSuccessCallbackResult",res);
                moduleHelper.send('GetGroupInfoCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetGroupInfoCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetGroupInfoCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetLocalIPAddress(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getLocalIPAddress({
            ...conf,
            success(res){
                formatResponse("GetLocalIPAddressSuccessCallbackResult",res);
                moduleHelper.send('GetLocalIPAddressCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetLocalIPAddressCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetLocalIPAddressCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetLocation(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getLocation({
            ...conf,
            success(res){
                formatResponse("GetLocationSuccessCallbackResult",res);
                moduleHelper.send('GetLocationCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetLocationCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetLocationCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetNetworkType(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getNetworkType({
            ...conf,
            success(res){
                formatResponse("GetNetworkTypeSuccessCallbackResult",res);
                moduleHelper.send('GetNetworkTypeCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetNetworkTypeCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetNetworkTypeCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetPotentialFriendList(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getPotentialFriendList({
            ...conf,
            success(res){
                formatResponse("GetPotentialFriendListSuccessCallbackResult",res);
                moduleHelper.send('GetPotentialFriendListCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetPotentialFriendListCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetPotentialFriendListCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetScreenBrightness(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getScreenBrightness({
            ...conf,
            success(res){
                formatResponse("GetScreenBrightnessSuccessCallbackOption",res);
                moduleHelper.send('GetScreenBrightnessCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetScreenBrightnessCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetScreenBrightnessCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetSetting(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getSetting({
            ...conf,
            success(res){
                formatResponse("GetSettingSuccessCallbackResult",res);
                moduleHelper.send('GetSettingCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetSettingCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetSettingCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetShareInfo(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getShareInfo({
            ...conf,
            success(res){
                formatResponse("GetGroupEnterInfoSuccessCallbackResult",res);
                moduleHelper.send('GetShareInfoCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetShareInfoCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetShareInfoCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetStorageInfo(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getStorageInfo({
            ...conf,
            success(res){
                formatResponse("GetStorageInfoSuccessCallbackOption",res);
                moduleHelper.send('GetStorageInfoCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetStorageInfoCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetStorageInfoCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetSystemInfo(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getSystemInfo({
            ...conf,
            success(res){
                formatResponse("SystemInfo",res);
                moduleHelper.send('GetSystemInfoCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetSystemInfoCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetSystemInfoCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetSystemInfoAsync(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getSystemInfoAsync({
            ...conf,
            success(res){
                formatResponse("SystemInfo",res);
                moduleHelper.send('GetSystemInfoAsyncCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetSystemInfoAsyncCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetSystemInfoAsyncCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetUserCloudStorage(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getUserCloudStorage({
            ...conf,
            success(res){
                formatResponse("GetUserCloudStorageSuccessCallbackResult",res);
                moduleHelper.send('GetUserCloudStorageCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetUserCloudStorageCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetUserCloudStorageCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetUserCloudStorageKeys(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getUserCloudStorageKeys({
            ...conf,
            success(res){
                formatResponse("GetUserCloudStorageKeysSuccessCallbackResult",res);
                moduleHelper.send('GetUserCloudStorageKeysCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetUserCloudStorageKeysCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetUserCloudStorageKeysCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetUserInfo(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getUserInfo({
            ...conf,
            success(res){
                formatResponse("GetUserInfoSuccessCallbackResult",res);
                moduleHelper.send('GetUserInfoCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetUserInfoCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetUserInfoCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetUserInteractiveStorage(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getUserInteractiveStorage({
            ...conf,
            success(res){
                formatResponse("GetUserInteractiveStorageSuccessCallbackResult",res);
                moduleHelper.send('GetUserInteractiveStorageCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GetUserInteractiveStorageFailCallbackResult",res);
                moduleHelper.send('GetUserInteractiveStorageCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetUserInteractiveStorageCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetWeRunData(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getWeRunData({
            ...conf,
            success(res){
                formatResponse("GetWeRunDataSuccessCallbackResult",res);
                moduleHelper.send('GetWeRunDataCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetWeRunDataCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetWeRunDataCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_HideKeyboard(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.hideKeyboard({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('HideKeyboardCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('HideKeyboardCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('HideKeyboardCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_HideLoading(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.hideLoading({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('HideLoadingCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('HideLoadingCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('HideLoadingCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_HideShareMenu(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.hideShareMenu({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('HideShareMenuCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('HideShareMenuCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('HideShareMenuCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_HideToast(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.hideToast({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('HideToastCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('HideToastCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('HideToastCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_InitFaceDetect(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.initFaceDetect({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('InitFaceDetectCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('InitFaceDetectCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('InitFaceDetectCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_IsBluetoothDevicePaired(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.isBluetoothDevicePaired({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('IsBluetoothDevicePairedCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('IsBluetoothDevicePairedCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('IsBluetoothDevicePairedCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_JoinVoIPChat(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.joinVoIPChat({
            ...conf,
            success(res){
                formatResponse("JoinVoIPChatSuccessCallbackResult",res);
                moduleHelper.send('JoinVoIPChatCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("JoinVoIPChatError",res);
                moduleHelper.send('JoinVoIPChatCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("JoinVoIPChatError",res);
                moduleHelper.send('JoinVoIPChatCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_Login(conf, callbackId){
        conf = formatJsonStr(conf);
            if(!conf.timeout){
                delete conf.timeout
            }
        wx.login({
            ...conf,
            success(res){
                formatResponse("LoginSuccessCallbackResult",res);
                moduleHelper.send('LoginCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('LoginCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('LoginCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_MakeBluetoothPair(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.makeBluetoothPair({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('MakeBluetoothPairCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('MakeBluetoothPairCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('MakeBluetoothPairCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_ModifyFriendInteractiveStorage(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.modifyFriendInteractiveStorage({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ModifyFriendInteractiveStorageCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("ModifyFriendInteractiveStorageFailCallbackResult",res);
                moduleHelper.send('ModifyFriendInteractiveStorageCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ModifyFriendInteractiveStorageCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_NavigateToMiniProgram(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.navigateToMiniProgram({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('NavigateToMiniProgramCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('NavigateToMiniProgramCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('NavigateToMiniProgramCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_NotifyBLECharacteristicValueChange(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.notifyBLECharacteristicValueChange({
            ...conf,
            success(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('NotifyBLECharacteristicValueChangeCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('NotifyBLECharacteristicValueChangeCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('NotifyBLECharacteristicValueChangeCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_OpenBluetoothAdapter(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.openBluetoothAdapter({
            ...conf,
            success(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('OpenBluetoothAdapterCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('OpenBluetoothAdapterCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('OpenBluetoothAdapterCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_OpenCard(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.openCard({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('OpenCardCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('OpenCardCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('OpenCardCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_OpenChannelsActivity(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.openChannelsActivity({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('OpenChannelsActivityCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('OpenChannelsActivityCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('OpenChannelsActivityCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_OpenChannelsEvent(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.openChannelsEvent({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('OpenChannelsEventCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('OpenChannelsEventCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('OpenChannelsEventCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_OpenChannelsLive(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.openChannelsLive({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('OpenChannelsLiveCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('OpenChannelsLiveCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('OpenChannelsLiveCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_OpenChannelsUserProfile(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.openChannelsUserProfile({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('OpenChannelsUserProfileCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('OpenChannelsUserProfileCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('OpenChannelsUserProfileCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_OpenCustomerServiceConversation(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.openCustomerServiceConversation({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('OpenCustomerServiceConversationCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('OpenCustomerServiceConversationCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('OpenCustomerServiceConversationCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_OpenSetting(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.openSetting({
            ...conf,
            success(res){
                formatResponse("OpenSettingSuccessCallbackResult",res);
                moduleHelper.send('OpenSettingCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('OpenSettingCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('OpenSettingCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_PreviewImage(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.previewImage({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('PreviewImageCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('PreviewImageCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('PreviewImageCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_PreviewMedia(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.previewMedia({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('PreviewMediaCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('PreviewMediaCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('PreviewMediaCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_ReadBLECharacteristicValue(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.readBLECharacteristicValue({
            ...conf,
            success(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('ReadBLECharacteristicValueCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('ReadBLECharacteristicValueCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('ReadBLECharacteristicValueCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_RemoveStorage(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.removeStorage({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('RemoveStorageCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('RemoveStorageCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('RemoveStorageCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_RemoveUserCloudStorage(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.removeUserCloudStorage({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('RemoveUserCloudStorageCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('RemoveUserCloudStorageCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('RemoveUserCloudStorageCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_RequestMidasFriendPayment(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.requestMidasFriendPayment({
            ...conf,
            success(res){
                formatResponse("RequestMidasFriendPaymentSuccessCallbackResult",res);
                moduleHelper.send('RequestMidasFriendPaymentCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("MidasFriendPaymentError",res);
                moduleHelper.send('RequestMidasFriendPaymentCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("MidasFriendPaymentError",res);
                moduleHelper.send('RequestMidasFriendPaymentCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_RequestMidasPayment(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.requestMidasPayment({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('RequestMidasPaymentCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("MidasPaymentError",res);
                moduleHelper.send('RequestMidasPaymentCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("MidasPaymentError",res);
                moduleHelper.send('RequestMidasPaymentCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_RequestSubscribeMessage(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.requestSubscribeMessage({
            ...conf,
            success(res){
                formatResponse("RequestSubscribeMessageSuccessCallbackResult",res);
                moduleHelper.send('RequestSubscribeMessageCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("RequestSubscribeMessageFailCallbackResult",res);
                moduleHelper.send('RequestSubscribeMessageCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('RequestSubscribeMessageCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_RequestSubscribeSystemMessage(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.requestSubscribeSystemMessage({
            ...conf,
            success(res){
                formatResponse("RequestSubscribeSystemMessageSuccessCallbackResult",res);
                moduleHelper.send('RequestSubscribeSystemMessageCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("RequestSubscribeMessageFailCallbackResult",res);
                moduleHelper.send('RequestSubscribeSystemMessageCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('RequestSubscribeSystemMessageCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_SaveFileToDisk(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.saveFileToDisk({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SaveFileToDiskCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SaveFileToDiskCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SaveFileToDiskCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_SaveImageToPhotosAlbum(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.saveImageToPhotosAlbum({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SaveImageToPhotosAlbumCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SaveImageToPhotosAlbumCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SaveImageToPhotosAlbumCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_ScanCode(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.scanCode({
            ...conf,
            success(res){
                formatResponse("ScanCodeSuccessCallbackResult",res);
                moduleHelper.send('ScanCodeCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ScanCodeCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ScanCodeCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_SendSocketMessage(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.sendSocketMessage({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SendSocketMessageCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SendSocketMessageCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SendSocketMessageCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_SetBLEMTU(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.setBLEMTU({
            ...conf,
            success(res){
                formatResponse("SetBLEMTUSuccessCallbackResult",res);
                moduleHelper.send('SetBLEMTUCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("SetBLEMTUFailCallbackResult",res);
                moduleHelper.send('SetBLEMTUCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SetBLEMTUCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_SetClipboardData(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.setClipboardData({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SetClipboardDataCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SetClipboardDataCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SetClipboardDataCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_SetEnableDebug(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.setEnableDebug({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SetEnableDebugCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SetEnableDebugCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SetEnableDebugCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_SetInnerAudioOption(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.setInnerAudioOption({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SetInnerAudioOptionCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SetInnerAudioOptionCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SetInnerAudioOptionCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_SetKeepScreenOn(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.setKeepScreenOn({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SetKeepScreenOnCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SetKeepScreenOnCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SetKeepScreenOnCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_SetMenuStyle(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.setMenuStyle({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SetMenuStyleCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SetMenuStyleCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SetMenuStyleCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_SetScreenBrightness(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.setScreenBrightness({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SetScreenBrightnessCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SetScreenBrightnessCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SetScreenBrightnessCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_SetStatusBarStyle(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.setStatusBarStyle({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SetStatusBarStyleCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SetStatusBarStyleCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SetStatusBarStyleCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_SetUserCloudStorage(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.setUserCloudStorage({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SetUserCloudStorageCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SetUserCloudStorageCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('SetUserCloudStorageCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_ShareMessageToFriend(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.shareMessageToFriend({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ShareMessageToFriendCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ShareMessageToFriendCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ShareMessageToFriendCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_ShowActionSheet(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.showActionSheet({
            ...conf,
            success(res){
                formatResponse("ShowActionSheetSuccessCallbackResult",res);
                moduleHelper.send('ShowActionSheetCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ShowActionSheetCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ShowActionSheetCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_ShowKeyboard(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.showKeyboard({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ShowKeyboardCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ShowKeyboardCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ShowKeyboardCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_ShowLoading(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.showLoading({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ShowLoadingCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ShowLoadingCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ShowLoadingCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_ShowModal(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.showModal({
            ...conf,
            success(res){
                formatResponse("ShowModalSuccessCallbackResult",res);
                moduleHelper.send('ShowModalCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ShowModalCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ShowModalCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_ShowShareImageMenu(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.showShareImageMenu({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ShowShareImageMenuCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ShowShareImageMenuCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ShowShareImageMenuCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_ShowShareMenu(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.showShareMenu({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ShowShareMenuCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ShowShareMenuCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ShowShareMenuCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_ShowToast(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.showToast({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ShowToastCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ShowToastCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('ShowToastCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_StartAccelerometer(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.startAccelerometer({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StartAccelerometerCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StartAccelerometerCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StartAccelerometerCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_StartBeaconDiscovery(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.startBeaconDiscovery({
            ...conf,
            success(res){
                formatResponse("BeaconError",res);
                moduleHelper.send('StartBeaconDiscoveryCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("BeaconError",res);
                moduleHelper.send('StartBeaconDiscoveryCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("BeaconError",res);
                moduleHelper.send('StartBeaconDiscoveryCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_StartBluetoothDevicesDiscovery(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.startBluetoothDevicesDiscovery({
            ...conf,
            success(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('StartBluetoothDevicesDiscoveryCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('StartBluetoothDevicesDiscoveryCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('StartBluetoothDevicesDiscoveryCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_StartCompass(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.startCompass({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StartCompassCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StartCompassCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StartCompassCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_StartDeviceMotionListening(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.startDeviceMotionListening({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StartDeviceMotionListeningCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StartDeviceMotionListeningCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StartDeviceMotionListeningCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_StartGyroscope(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.startGyroscope({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StartGyroscopeCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StartGyroscopeCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StartGyroscopeCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_StopAccelerometer(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.stopAccelerometer({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StopAccelerometerCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StopAccelerometerCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StopAccelerometerCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_StopBeaconDiscovery(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.stopBeaconDiscovery({
            ...conf,
            success(res){
                formatResponse("BeaconError",res);
                moduleHelper.send('StopBeaconDiscoveryCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("BeaconError",res);
                moduleHelper.send('StopBeaconDiscoveryCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("BeaconError",res);
                moduleHelper.send('StopBeaconDiscoveryCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_StopBluetoothDevicesDiscovery(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.stopBluetoothDevicesDiscovery({
            ...conf,
            success(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('StopBluetoothDevicesDiscoveryCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('StopBluetoothDevicesDiscoveryCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('StopBluetoothDevicesDiscoveryCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_StopCompass(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.stopCompass({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StopCompassCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StopCompassCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StopCompassCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_StopDeviceMotionListening(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.stopDeviceMotionListening({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StopDeviceMotionListeningCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StopDeviceMotionListeningCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StopDeviceMotionListeningCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_StopFaceDetect(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.stopFaceDetect({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StopFaceDetectCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StopFaceDetectCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StopFaceDetectCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_StopGyroscope(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.stopGyroscope({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StopGyroscopeCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StopGyroscopeCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StopGyroscopeCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_UpdateKeyboard(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.updateKeyboard({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('UpdateKeyboardCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('UpdateKeyboardCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('UpdateKeyboardCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_UpdateShareMenu(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.updateShareMenu({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('UpdateShareMenuCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('UpdateShareMenuCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('UpdateShareMenuCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_UpdateVoIPChatMuteConfig(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.updateVoIPChatMuteConfig({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('UpdateVoIPChatMuteConfigCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('UpdateVoIPChatMuteConfigCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('UpdateVoIPChatMuteConfigCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_UpdateWeChatApp(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.updateWeChatApp({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('UpdateWeChatAppCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('UpdateWeChatAppCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('UpdateWeChatAppCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_VibrateLong(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.vibrateLong({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('VibrateLongCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('VibrateLongCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('VibrateLongCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_VibrateShort(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.vibrateShort({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('VibrateShortCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('VibrateShortCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('VibrateShortCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_WriteBLECharacteristicValue(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.writeBLECharacteristicValue({
            ...conf,
            success(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('WriteBLECharacteristicValueCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('WriteBLECharacteristicValueCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("BluetoothError",res);
                moduleHelper.send('WriteBLECharacteristicValueCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_StartGameLive(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.startGameLive({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StartGameLiveCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StartGameLiveCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('StartGameLiveCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_CheckGameLiveEnabled(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.checkGameLiveEnabled({
            ...conf,
            success(res){
                formatResponse("CheckGameLiveEnabledSuccessCallbackOption",res);
                moduleHelper.send('CheckGameLiveEnabledCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('CheckGameLiveEnabledCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('CheckGameLiveEnabledCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetUserCurrentGameliveInfo(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getUserCurrentGameliveInfo({
            ...conf,
            success(res){
                formatResponse("GetUserCurrentGameliveInfoSuccessCallbackOption",res);
                moduleHelper.send('GetUserCurrentGameliveInfoCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetUserCurrentGameliveInfoCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetUserCurrentGameliveInfoCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetUserRecentGameLiveInfo(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getUserRecentGameLiveInfo({
            ...conf,
            success(res){
                formatResponse("GetUserGameLiveDetailsSuccessCallbackOption",res);
                moduleHelper.send('GetUserRecentGameLiveInfoCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetUserRecentGameLiveInfoCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetUserRecentGameLiveInfoCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_GetUserGameLiveDetails(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.getUserGameLiveDetails({
            ...conf,
            success(res){
                formatResponse("GetUserGameLiveDetailsSuccessCallbackOption",res);
                moduleHelper.send('GetUserGameLiveDetailsCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetUserGameLiveDetailsCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('GetUserGameLiveDetailsCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },
    WX_OpenChannelsLiveCollection(conf, callbackId){
        conf = formatJsonStr(conf);
        wx.openChannelsLiveCollection({
            ...conf,
            success(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('OpenChannelsLiveCollectionCallback', JSON.stringify({
                    callbackId,type:"success",res:JSON.stringify(res)
                }));
            },
            fail(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('OpenChannelsLiveCollectionCallback', JSON.stringify({
                callbackId,type:"fail",res:JSON.stringify(res)
                }));
            },
            complete(res){
                formatResponse("GeneralCallbackResult",res);
                moduleHelper.send('OpenChannelsLiveCollectionCallback', JSON.stringify({
                callbackId,type:"complete",res:JSON.stringify(res)
                }));
            }
        });
    },

    WX_RemoveStorageSync(key){
        wx.removeStorageSync(key);
    },
    WX_ReportEvent(eventId,data){
        wx.reportEvent(eventId,formatJsonStr(data));
    },
    WX_ReportMonitor(name,value){
        wx.reportMonitor(name,value);
    },
    WX_ReportPerformance(id,value,dimensions){
        wx.reportPerformance(id,value,dimensions);
    },
    WX_ReportUserBehaviorBranchAnalytics(option){
        wx.reportUserBehaviorBranchAnalytics(formatJsonStr(option));
    },
    WX_ReserveChannelsLive(option){
        wx.reserveChannelsLive(formatJsonStr(option));
    },
    WX_RevokeBufferURL(url){
        wx.revokeBufferURL(url);
    },
    WX_SetPreferredFramesPerSecond(fps){
        wx.setPreferredFramesPerSecond(fps);
    },
    WX_SetStorageSync(key,data,encrypt){
        wx.setStorageSync(key,formatJsonStr(data),encrypt);
    },
    WX_ShareAppMessage(option){
        wx.shareAppMessage(formatJsonStr(option));
    },
    WX_TriggerGC(){
        wx.triggerGC();
    },

    WX_OnAccelerometerChange(){
        this.OnAccelerometerChangeList = this.OnAccelerometerChangeList || [];
        let callback = (res)=>{
            formatResponse("OnAccelerometerChangeCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnAccelerometerChangeCallback',resStr );
        };
        this.OnAccelerometerChangeList.push(callback);
        wx.onAccelerometerChange(callback);
    },
    WX_OffAccelerometerChange(){
        (this.OnAccelerometerChangeList || []).forEach(v=>{
            wx.offAccelerometerChange(v);
        });
    },
    WX_OnAudioInterruptionBegin(){
        this.OnAudioInterruptionBeginList = this.OnAudioInterruptionBeginList || [];
        let callback = (res)=>{
            formatResponse("GeneralCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnAudioInterruptionBeginCallback',resStr );
        };
        this.OnAudioInterruptionBeginList.push(callback);
        wx.onAudioInterruptionBegin(callback);
    },
    WX_OffAudioInterruptionBegin(){
        (this.OnAudioInterruptionBeginList || []).forEach(v=>{
            wx.offAudioInterruptionBegin(v);
        });
    },
    WX_OnAudioInterruptionEnd(){
        this.OnAudioInterruptionEndList = this.OnAudioInterruptionEndList || [];
        let callback = (res)=>{
            formatResponse("GeneralCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnAudioInterruptionEndCallback',resStr );
        };
        this.OnAudioInterruptionEndList.push(callback);
        wx.onAudioInterruptionEnd(callback);
    },
    WX_OffAudioInterruptionEnd(){
        (this.OnAudioInterruptionEndList || []).forEach(v=>{
            wx.offAudioInterruptionEnd(v);
        });
    },
    WX_OnBLECharacteristicValueChange(){
        this.OnBLECharacteristicValueChangeList = this.OnBLECharacteristicValueChangeList || [];
        let callback = (res)=>{
            formatResponse("OnBLECharacteristicValueChangeCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnBLECharacteristicValueChangeCallback',resStr );
        };
        this.OnBLECharacteristicValueChangeList.push(callback);
        wx.onBLECharacteristicValueChange(callback);
    },
    WX_OffBLECharacteristicValueChange(){
        (this.OnBLECharacteristicValueChangeList || []).forEach(v=>{
            wx.offBLECharacteristicValueChange(v);
        });
    },
    WX_OnBLEConnectionStateChange(){
        this.OnBLEConnectionStateChangeList = this.OnBLEConnectionStateChangeList || [];
        let callback = (res)=>{
            formatResponse("OnBLEConnectionStateChangeCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnBLEConnectionStateChangeCallback',resStr );
        };
        this.OnBLEConnectionStateChangeList.push(callback);
        wx.onBLEConnectionStateChange(callback);
    },
    WX_OffBLEConnectionStateChange(){
        (this.OnBLEConnectionStateChangeList || []).forEach(v=>{
            wx.offBLEConnectionStateChange(v);
        });
    },
    WX_OnBLEMTUChange(){
        this.OnBLEMTUChangeList = this.OnBLEMTUChangeList || [];
        let callback = (res)=>{
            formatResponse("OnBLEMTUChangeCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnBLEMTUChangeCallback',resStr );
        };
        this.OnBLEMTUChangeList.push(callback);
        wx.onBLEMTUChange(callback);
    },
    WX_OffBLEMTUChange(){
        (this.OnBLEMTUChangeList || []).forEach(v=>{
            wx.offBLEMTUChange(v);
        });
    },
    WX_OnBLEPeripheralConnectionStateChanged(){
        this.OnBLEPeripheralConnectionStateChangedList = this.OnBLEPeripheralConnectionStateChangedList || [];
        let callback = (res)=>{
            formatResponse("OnBLEPeripheralConnectionStateChangedCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnBLEPeripheralConnectionStateChangedCallback',resStr );
        };
        this.OnBLEPeripheralConnectionStateChangedList.push(callback);
        wx.onBLEPeripheralConnectionStateChanged(callback);
    },
    WX_OffBLEPeripheralConnectionStateChanged(){
        (this.OnBLEPeripheralConnectionStateChangedList || []).forEach(v=>{
            wx.offBLEPeripheralConnectionStateChanged(v);
        });
    },
    WX_OnBeaconServiceChange(){
        this.OnBeaconServiceChangeList = this.OnBeaconServiceChangeList || [];
        let callback = (res)=>{
            formatResponse("OnBeaconServiceChangeCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnBeaconServiceChangeCallback',resStr );
        };
        this.OnBeaconServiceChangeList.push(callback);
        wx.onBeaconServiceChange(callback);
    },
    WX_OffBeaconServiceChange(){
        (this.OnBeaconServiceChangeList || []).forEach(v=>{
            wx.offBeaconServiceChange(v);
        });
    },
    WX_OnBeaconUpdate(){
        this.OnBeaconUpdateList = this.OnBeaconUpdateList || [];
        let callback = (res)=>{
            formatResponse("OnBeaconUpdateCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnBeaconUpdateCallback',resStr );
        };
        this.OnBeaconUpdateList.push(callback);
        wx.onBeaconUpdate(callback);
    },
    WX_OffBeaconUpdate(){
        (this.OnBeaconUpdateList || []).forEach(v=>{
            wx.offBeaconUpdate(v);
        });
    },
    WX_OnBluetoothAdapterStateChange(){
        this.OnBluetoothAdapterStateChangeList = this.OnBluetoothAdapterStateChangeList || [];
        let callback = (res)=>{
            formatResponse("OnBluetoothAdapterStateChangeCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnBluetoothAdapterStateChangeCallback',resStr );
        };
        this.OnBluetoothAdapterStateChangeList.push(callback);
        wx.onBluetoothAdapterStateChange(callback);
    },
    WX_OffBluetoothAdapterStateChange(){
        (this.OnBluetoothAdapterStateChangeList || []).forEach(v=>{
            wx.offBluetoothAdapterStateChange(v);
        });
    },
    WX_OnBluetoothDeviceFound(){
        this.OnBluetoothDeviceFoundList = this.OnBluetoothDeviceFoundList || [];
        let callback = (res)=>{
            formatResponse("OnBluetoothDeviceFoundCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnBluetoothDeviceFoundCallback',resStr );
        };
        this.OnBluetoothDeviceFoundList.push(callback);
        wx.onBluetoothDeviceFound(callback);
    },
    WX_OffBluetoothDeviceFound(){
        (this.OnBluetoothDeviceFoundList || []).forEach(v=>{
            wx.offBluetoothDeviceFound(v);
        });
    },
    WX_OnCompassChange(){
        this.OnCompassChangeList = this.OnCompassChangeList || [];
        let callback = (res)=>{
            formatResponse("OnCompassChangeCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnCompassChangeCallback',resStr );
        };
        this.OnCompassChangeList.push(callback);
        wx.onCompassChange(callback);
    },
    WX_OffCompassChange(){
        (this.OnCompassChangeList || []).forEach(v=>{
            wx.offCompassChange(v);
        });
    },
    WX_OnDeviceMotionChange(){
        this.OnDeviceMotionChangeList = this.OnDeviceMotionChangeList || [];
        let callback = (res)=>{
            formatResponse("OnDeviceMotionChangeCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnDeviceMotionChangeCallback',resStr );
        };
        this.OnDeviceMotionChangeList.push(callback);
        wx.onDeviceMotionChange(callback);
    },
    WX_OffDeviceMotionChange(){
        (this.OnDeviceMotionChangeList || []).forEach(v=>{
            wx.offDeviceMotionChange(v);
        });
    },
    WX_OnDeviceOrientationChange(){
        this.OnDeviceOrientationChangeList = this.OnDeviceOrientationChangeList || [];
        let callback = (res)=>{
            formatResponse("OnDeviceOrientationChangeCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnDeviceOrientationChangeCallback',resStr );
        };
        this.OnDeviceOrientationChangeList.push(callback);
        wx.onDeviceOrientationChange(callback);
    },
    WX_OffDeviceOrientationChange(){
        (this.OnDeviceOrientationChangeList || []).forEach(v=>{
            wx.offDeviceOrientationChange(v);
        });
    },
    WX_OnError(){
        this.OnErrorList = this.OnErrorList || [];
        let callback = (res)=>{
            formatResponse("WxOnErrorCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnErrorCallback',resStr );
        };
        this.OnErrorList.push(callback);
        wx.onError(callback);
    },
    WX_OffError(){
        (this.OnErrorList || []).forEach(v=>{
            wx.offError(v);
        });
    },
    WX_OnGyroscopeChange(){
        this.OnGyroscopeChangeList = this.OnGyroscopeChangeList || [];
        let callback = (res)=>{
            formatResponse("OnGyroscopeChangeCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnGyroscopeChangeCallback',resStr );
        };
        this.OnGyroscopeChangeList.push(callback);
        wx.onGyroscopeChange(callback);
    },
    WX_OffGyroscopeChange(){
        (this.OnGyroscopeChangeList || []).forEach(v=>{
            wx.offGyroscopeChange(v);
        });
    },
    WX_OnHide(){
        this.OnHideList = this.OnHideList || [];
        let callback = (res)=>{
            formatResponse("GeneralCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnHideCallback',resStr );
        };
        this.OnHideList.push(callback);
        wx.onHide(callback);
    },
    WX_OffHide(){
        (this.OnHideList || []).forEach(v=>{
            wx.offHide(v);
        });
    },
    WX_OnInteractiveStorageModified(){
        this.OnInteractiveStorageModifiedList = this.OnInteractiveStorageModifiedList || [];
        let callback = (res)=>{
            formatResponse("string",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnInteractiveStorageModifiedCallback',resStr );
        };
        this.OnInteractiveStorageModifiedList.push(callback);
        wx.onInteractiveStorageModified(callback);
    },
    WX_OffInteractiveStorageModified(){
        (this.OnInteractiveStorageModifiedList || []).forEach(v=>{
            wx.offInteractiveStorageModified(v);
        });
    },
    WX_OnKeyDown(){
        this.OnKeyDownList = this.OnKeyDownList || [];
        let callback = (res)=>{
            formatResponse("OnKeyDownCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnKeyDownCallback',resStr );
        };
        this.OnKeyDownList.push(callback);
        wx.onKeyDown(callback);
    },
    WX_OffKeyDown(){
        (this.OnKeyDownList || []).forEach(v=>{
            wx.offKeyDown(v);
        });
    },
    WX_OnKeyUp(){
        this.OnKeyUpList = this.OnKeyUpList || [];
        let callback = (res)=>{
            formatResponse("OnKeyDownCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnKeyUpCallback',resStr );
        };
        this.OnKeyUpList.push(callback);
        wx.onKeyUp(callback);
    },
    WX_OffKeyUp(){
        (this.OnKeyUpList || []).forEach(v=>{
            wx.offKeyUp(v);
        });
    },
    WX_OnKeyboardComplete(){
        this.OnKeyboardCompleteList = this.OnKeyboardCompleteList || [];
        let callback = (res)=>{
            formatResponse("OnKeyboardInputCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnKeyboardCompleteCallback',resStr );
        };
        this.OnKeyboardCompleteList.push(callback);
        wx.onKeyboardComplete(callback);
    },
    WX_OffKeyboardComplete(){
        (this.OnKeyboardCompleteList || []).forEach(v=>{
            wx.offKeyboardComplete(v);
        });
    },
    WX_OnKeyboardConfirm(){
        this.OnKeyboardConfirmList = this.OnKeyboardConfirmList || [];
        let callback = (res)=>{
            formatResponse("OnKeyboardInputCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnKeyboardConfirmCallback',resStr );
        };
        this.OnKeyboardConfirmList.push(callback);
        wx.onKeyboardConfirm(callback);
    },
    WX_OffKeyboardConfirm(){
        (this.OnKeyboardConfirmList || []).forEach(v=>{
            wx.offKeyboardConfirm(v);
        });
    },
    WX_OnKeyboardHeightChange(){
        this.OnKeyboardHeightChangeList = this.OnKeyboardHeightChangeList || [];
        let callback = (res)=>{
            formatResponse("OnKeyboardHeightChangeCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnKeyboardHeightChangeCallback',resStr );
        };
        this.OnKeyboardHeightChangeList.push(callback);
        wx.onKeyboardHeightChange(callback);
    },
    WX_OffKeyboardHeightChange(){
        (this.OnKeyboardHeightChangeList || []).forEach(v=>{
            wx.offKeyboardHeightChange(v);
        });
    },
    WX_OnKeyboardInput(){
        this.OnKeyboardInputList = this.OnKeyboardInputList || [];
        let callback = (res)=>{
            formatResponse("OnKeyboardInputCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnKeyboardInputCallback',resStr );
        };
        this.OnKeyboardInputList.push(callback);
        wx.onKeyboardInput(callback);
    },
    WX_OffKeyboardInput(){
        (this.OnKeyboardInputList || []).forEach(v=>{
            wx.offKeyboardInput(v);
        });
    },
    WX_OnMemoryWarning(){
        this.OnMemoryWarningList = this.OnMemoryWarningList || [];
        let callback = (res)=>{
            formatResponse("OnMemoryWarningCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnMemoryWarningCallback',resStr );
        };
        this.OnMemoryWarningList.push(callback);
        wx.onMemoryWarning(callback);
    },
    WX_OffMemoryWarning(){
        (this.OnMemoryWarningList || []).forEach(v=>{
            wx.offMemoryWarning(v);
        });
    },
    WX_OnMessage(){
        this.OnMessageList = this.OnMessageList || [];
        let callback = (res)=>{
            formatResponse("string",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnMessageCallback',resStr );
        };
        this.OnMessageList.push(callback);
        wx.onMessage(callback);
    },
    WX_OffMessage(){
        (this.OnMessageList || []).forEach(v=>{
            wx.offMessage(v);
        });
    },
    WX_OnNetworkStatusChange(){
        this.OnNetworkStatusChangeList = this.OnNetworkStatusChangeList || [];
        let callback = (res)=>{
            formatResponse("OnNetworkStatusChangeCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnNetworkStatusChangeCallback',resStr );
        };
        this.OnNetworkStatusChangeList.push(callback);
        wx.onNetworkStatusChange(callback);
    },
    WX_OffNetworkStatusChange(){
        (this.OnNetworkStatusChangeList || []).forEach(v=>{
            wx.offNetworkStatusChange(v);
        });
    },
    WX_OnNetworkWeakChange(){
        this.OnNetworkWeakChangeList = this.OnNetworkWeakChangeList || [];
        let callback = (res)=>{
            formatResponse("OnNetworkWeakChangeCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnNetworkWeakChangeCallback',resStr );
        };
        this.OnNetworkWeakChangeList.push(callback);
        wx.onNetworkWeakChange(callback);
    },
    WX_OffNetworkWeakChange(){
        (this.OnNetworkWeakChangeList || []).forEach(v=>{
            wx.offNetworkWeakChange(v);
        });
    },
    WX_OnShareMessageToFriend(){
        this.OnShareMessageToFriendList = this.OnShareMessageToFriendList || [];
        let callback = (res)=>{
            formatResponse("OnShareMessageToFriendCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnShareMessageToFriendCallback',resStr );
        };
        this.OnShareMessageToFriendList.push(callback);
        wx.onShareMessageToFriend(callback);
    },
    WX_OffShareMessageToFriend(){
        (this.OnShareMessageToFriendList || []).forEach(v=>{
            wx.offShareMessageToFriend(v);
        });
    },
    WX_OnShow(){
        this.OnShowList = this.OnShowList || [];
        let callback = (res)=>{
            formatResponse("OnShowCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnShowCallback',resStr );
        };
        this.OnShowList.push(callback);
        wx.onShow(callback);
    },
    WX_OffShow(){
        (this.OnShowList || []).forEach(v=>{
            wx.offShow(v);
        });
    },
    WX_OnSocketClose(){
        this.OnSocketCloseList = this.OnSocketCloseList || [];
        let callback = (res)=>{
            formatResponse("SocketTaskOnCloseCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnSocketCloseCallback',resStr );
        };
        this.OnSocketCloseList.push(callback);
        wx.onSocketClose(callback);
    },
    WX_OffSocketClose(){
        (this.OnSocketCloseList || []).forEach(v=>{
            wx.offSocketClose(v);
        });
    },
    WX_OnSocketError(){
        this.OnSocketErrorList = this.OnSocketErrorList || [];
        let callback = (res)=>{
            formatResponse("GeneralCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnSocketErrorCallback',resStr );
        };
        this.OnSocketErrorList.push(callback);
        wx.onSocketError(callback);
    },
    WX_OffSocketError(){
        (this.OnSocketErrorList || []).forEach(v=>{
            wx.offSocketError(v);
        });
    },
    WX_OnSocketMessage(){
        this.OnSocketMessageList = this.OnSocketMessageList || [];
        let callback = (res)=>{
            formatResponse("SocketTaskOnMessageCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnSocketMessageCallback',resStr );
        };
        this.OnSocketMessageList.push(callback);
        wx.onSocketMessage(callback);
    },
    WX_OffSocketMessage(){
        (this.OnSocketMessageList || []).forEach(v=>{
            wx.offSocketMessage(v);
        });
    },
    WX_OnSocketOpen(){
        this.OnSocketOpenList = this.OnSocketOpenList || [];
        let callback = (res)=>{
            formatResponse("OnSocketOpenCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnSocketOpenCallback',resStr );
        };
        this.OnSocketOpenList.push(callback);
        wx.onSocketOpen(callback);
    },
    WX_OffSocketOpen(){
        (this.OnSocketOpenList || []).forEach(v=>{
            wx.offSocketOpen(v);
        });
    },
    WX_OnTouchCancel(){
        this.OnTouchCancelList = this.OnTouchCancelList || [];
        let callback = (res)=>{
            var touches = res.touches.map(v=>formatTouchEvent(v));
            var resStr = JSON.stringify({
                touches,
                timeStamp:parseInt(res.timeStamp),
                changedTouches:res.changedTouches.map(v=>formatTouchEvent(v))
            })
            moduleHelper.send('_OnTouchCancelCallback',resStr );
        };
        this.OnTouchCancelList.push(callback);
        wx.onTouchCancel(callback);
    },
    WX_OffTouchCancel(){
        (this.OnTouchCancelList || []).forEach(v=>{
            wx.offTouchCancel(v);
        });
    },
    WX_OnTouchEnd(){
        this.OnTouchEndList = this.OnTouchEndList || [];
        let callback = (res)=>{
            var touches = res.touches.map(v=>formatTouchEvent(v));
            var resStr = JSON.stringify({
                touches,
                timeStamp:parseInt(res.timeStamp),
                changedTouches:res.changedTouches.map(v=>formatTouchEvent(v))
            })
            moduleHelper.send('_OnTouchEndCallback',resStr );
        };
        this.OnTouchEndList.push(callback);
        wx.onTouchEnd(callback);
    },
    WX_OffTouchEnd(){
        (this.OnTouchEndList || []).forEach(v=>{
            wx.offTouchEnd(v);
        });
    },
    WX_OnTouchMove(){
        this.OnTouchMoveList = this.OnTouchMoveList || [];
        let callback = (res)=>{
            var touches = res.touches.map(v=>formatTouchEvent(v));
            var resStr = JSON.stringify({
                touches,
                timeStamp:parseInt(res.timeStamp),
                changedTouches:res.changedTouches.map(v=>formatTouchEvent(v))
            })
            moduleHelper.send('_OnTouchMoveCallback',resStr );
        };
        this.OnTouchMoveList.push(callback);
        wx.onTouchMove(callback);
    },
    WX_OffTouchMove(){
        (this.OnTouchMoveList || []).forEach(v=>{
            wx.offTouchMove(v);
        });
    },
    WX_OnTouchStart(){
        this.OnTouchStartList = this.OnTouchStartList || [];
        let callback = (res)=>{
            var touches = res.touches.map(v=>formatTouchEvent(v));
            var resStr = JSON.stringify({
                touches,
                timeStamp:parseInt(res.timeStamp),
                changedTouches:res.changedTouches.map(v=>formatTouchEvent(v))
            })
            moduleHelper.send('_OnTouchStartCallback',resStr );
        };
        this.OnTouchStartList.push(callback);
        wx.onTouchStart(callback);
    },
    WX_OffTouchStart(){
        (this.OnTouchStartList || []).forEach(v=>{
            wx.offTouchStart(v);
        });
    },
    WX_OnUnhandledRejection(){
        this.OnUnhandledRejectionList = this.OnUnhandledRejectionList || [];
        let callback = (res)=>{
            formatResponse("OnUnhandledRejectionCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnUnhandledRejectionCallback',resStr );
        };
        this.OnUnhandledRejectionList.push(callback);
        wx.onUnhandledRejection(callback);
    },
    WX_OffUnhandledRejection(){
        (this.OnUnhandledRejectionList || []).forEach(v=>{
            wx.offUnhandledRejection(v);
        });
    },
    WX_OnUserCaptureScreen(){
        this.OnUserCaptureScreenList = this.OnUserCaptureScreenList || [];
        let callback = (res)=>{
            formatResponse("GeneralCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnUserCaptureScreenCallback',resStr );
        };
        this.OnUserCaptureScreenList.push(callback);
        wx.onUserCaptureScreen(callback);
    },
    WX_OffUserCaptureScreen(){
        (this.OnUserCaptureScreenList || []).forEach(v=>{
            wx.offUserCaptureScreen(v);
        });
    },
    WX_OnVoIPChatInterrupted(){
        this.OnVoIPChatInterruptedList = this.OnVoIPChatInterruptedList || [];
        let callback = (res)=>{
            formatResponse("OnVoIPChatInterruptedCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnVoIPChatInterruptedCallback',resStr );
        };
        this.OnVoIPChatInterruptedList.push(callback);
        wx.onVoIPChatInterrupted(callback);
    },
    WX_OffVoIPChatInterrupted(){
        (this.OnVoIPChatInterruptedList || []).forEach(v=>{
            wx.offVoIPChatInterrupted(v);
        });
    },
    WX_OnVoIPChatMembersChanged(){
        this.OnVoIPChatMembersChangedList = this.OnVoIPChatMembersChangedList || [];
        let callback = (res)=>{
            formatResponse("OnVoIPChatMembersChangedCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnVoIPChatMembersChangedCallback',resStr );
        };
        this.OnVoIPChatMembersChangedList.push(callback);
        wx.onVoIPChatMembersChanged(callback);
    },
    WX_OffVoIPChatMembersChanged(){
        (this.OnVoIPChatMembersChangedList || []).forEach(v=>{
            wx.offVoIPChatMembersChanged(v);
        });
    },
    WX_OnVoIPChatSpeakersChanged(){
        this.OnVoIPChatSpeakersChangedList = this.OnVoIPChatSpeakersChangedList || [];
        let callback = (res)=>{
            formatResponse("OnVoIPChatSpeakersChangedCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnVoIPChatSpeakersChangedCallback',resStr );
        };
        this.OnVoIPChatSpeakersChangedList.push(callback);
        wx.onVoIPChatSpeakersChanged(callback);
    },
    WX_OffVoIPChatSpeakersChanged(){
        (this.OnVoIPChatSpeakersChangedList || []).forEach(v=>{
            wx.offVoIPChatSpeakersChanged(v);
        });
    },
    WX_OnVoIPChatStateChanged(){
        this.OnVoIPChatStateChangedList = this.OnVoIPChatStateChangedList || [];
        let callback = (res)=>{
            formatResponse("OnVoIPChatStateChangedCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnVoIPChatStateChangedCallback',resStr );
        };
        this.OnVoIPChatStateChangedList.push(callback);
        wx.onVoIPChatStateChanged(callback);
    },
    WX_OffVoIPChatStateChanged(){
        (this.OnVoIPChatStateChangedList || []).forEach(v=>{
            wx.offVoIPChatStateChanged(v);
        });
    },

    WX_OnAddToFavorites(){
        this.OnAddToFavoritesList = this.OnAddToFavoritesList || [];
        let callback = (res)=>{
            res = res || {};
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnAddToFavoritesCallback',resStr);
            return this.WX_OnAddToFavorites_ResolveConf;
        };
        this.OnAddToFavoritesList.push(callback);
        wx.onAddToFavorites(callback);
    },
    WX_OnAddToFavorites_Resolve(conf){
        try{
            conf = JSON.parse(conf);
            this.WX_OnAddToFavorites_ResolveConf = conf;
            return;
        }catch(e){
        }
        this.WX_OnAddToFavorites_ResolveConf = {};
    },
    WX_OffAddToFavorites(){
        wx.offAddToFavorites();
    },
    WX_OnCopyUrl(){
        this.OnCopyUrlList = this.OnCopyUrlList || [];
        let callback = (res)=>{
            res = res || {};
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnCopyUrlCallback',resStr);
            return this.WX_OnCopyUrl_ResolveConf;
        };
        this.OnCopyUrlList.push(callback);
        wx.onCopyUrl(callback);
    },
    WX_OnCopyUrl_Resolve(conf){
        try{
            conf = JSON.parse(conf);
            this.WX_OnCopyUrl_ResolveConf = conf;
            return;
        }catch(e){
        }
        this.WX_OnCopyUrl_ResolveConf = {};
    },
    WX_OffCopyUrl(){
        wx.offCopyUrl();
    },
    WX_OnHandoff(){
        this.OnHandoffList = this.OnHandoffList || [];
        let callback = (res)=>{
            res = res || {};
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnHandoffCallback',resStr);
            return this.WX_OnHandoff_ResolveConf;
        };
        this.OnHandoffList.push(callback);
        wx.onHandoff(callback);
    },
    WX_OnHandoff_Resolve(conf){
        try{
            conf = JSON.parse(conf);
            this.WX_OnHandoff_ResolveConf = conf;
            return;
        }catch(e){
        }
        this.WX_OnHandoff_ResolveConf = {};
    },
    WX_OffHandoff(){
        wx.offHandoff();
    },
    WX_OnShareTimeline(){
        this.OnShareTimelineList = this.OnShareTimelineList || [];
        let callback = (res)=>{
            res = res || {};
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnShareTimelineCallback',resStr);
            return this.WX_OnShareTimeline_ResolveConf;
        };
        this.OnShareTimelineList.push(callback);
        wx.onShareTimeline(callback);
    },
    WX_OnShareTimeline_Resolve(conf){
        try{
            conf = JSON.parse(conf);
            this.WX_OnShareTimeline_ResolveConf = conf;
            return;
        }catch(e){
        }
        this.WX_OnShareTimeline_ResolveConf = {};
    },
    WX_OffShareTimeline(){
        wx.offShareTimeline();
    },
    WX_OnGameLiveStateChange(){
        this.OnGameLiveStateChangeList = this.OnGameLiveStateChangeList || [];
        let callback = (res)=>{
            res = res || {};
            formatResponse("OnGameLiveStateChangeCallbackResult",res);
            var resStr = JSON.stringify(res);
            moduleHelper.send('_OnGameLiveStateChangeCallback',resStr);
            return this.WX_OnGameLiveStateChange_ResolveConf;
        };
        this.OnGameLiveStateChangeList.push(callback);
        wx.onGameLiveStateChange(callback);
    },
    WX_OnGameLiveStateChange_Resolve(conf){
        try{
            conf = JSON.parse(conf);
            this.WX_OnGameLiveStateChange_ResolveConf = conf;
            return;
        }catch(e){
        }
        this.WX_OnGameLiveStateChange_ResolveConf = {};
    },
    WX_OffGameLiveStateChange(){
        wx.offGameLiveStateChange();
    },

    WX_SetHandoffQuery(query){
        var res = wx.setHandoffQuery(formatJsonStr(query));
        return res;
    },
    WX_GetAccountInfoSync(){
        var res = wx.getAccountInfoSync();
        formatResponse("AccountInfo",res);
        return JSON.stringify(res);
    },
    WX_GetBatteryInfoSync(){
        var res = wx.getBatteryInfoSync();
        formatResponse("GetBatteryInfoSyncResult",res);
        return JSON.stringify(res);
    },
    WX_GetEnterOptionsSync(){
        var res = wx.getEnterOptionsSync();
        formatResponse("EnterOptionsGame",res);
        return JSON.stringify(res);
    },
    WX_GetExptInfoSync(keys){
        var res = wx.getExptInfoSync(formatJsonStr(keys));
        formatResponse("IAnyObject",res);
        return JSON.stringify(res);
    },
    WX_GetExtConfigSync(){
        var res = wx.getExtConfigSync();
        formatResponse("IAnyObject",res);
        return JSON.stringify(res);
    },
    WX_GetLaunchOptionsSync(){
        var res = wx.getLaunchOptionsSync();
        formatResponse("LaunchOptionsGame",res);
        return JSON.stringify(res);
    },
    WX_GetMenuButtonBoundingClientRect(){
        var res = wx.getMenuButtonBoundingClientRect();
        formatResponse("ClientRect",res);
        return JSON.stringify(res);
    },
    WX_GetStorageInfoSync(){
        var res = wx.getStorageInfoSync();
        formatResponse("GetStorageInfoSyncOption",res);
        return JSON.stringify(res);
    },
    WX_GetSystemInfoSync(){
        var res = wx.getSystemInfoSync();
        formatResponse("SystemInfo",res);
        return JSON.stringify(res);
    },
    WX_SetCursor(path,x,y){
        var res = wx.setCursor(formatJsonStr(path),x,y);
        return res;
    },
    WX_SetMessageToFriendQuery(option){
        var res = wx.setMessageToFriendQuery(formatJsonStr(option));
        return res;
    },
    WX_GetTextLineHeight(option){
        var res = wx.getTextLineHeight(formatJsonStr(option));
        return res;
    },
    WX_LoadFont(path){
        var res = wx.loadFont(formatJsonStr(path));
        return res;
    },
    WX_GetGameLiveState(){
        var res = wx.getGameLiveState();
        formatResponse("GameLiveState",res);
        return JSON.stringify(res);
    },

    WX_GetUpdateManager(){
        let obj = wx.getUpdateManager();
        this.UpdateManagerList = this.UpdateManagerList || {};
        let list = this.UpdateManagerList;
        let count = Object.keys(list);
        let key = count+(new Date().getTime());
        list[key] = obj;
        return key;
    },

    WX_ApplyUpdate(id){
        var obj = this.UpdateManagerList[id];
        if(obj){
            obj.applyUpdate();
        }
    },            
    WX_OnCheckForUpdate(id){
        var obj = this.UpdateManagerList[id];
        obj.OnCheckForUpdateList = obj.OnCheckForUpdateList || [];
        let callback = (res)=>{
            formatResponse("OnCheckForUpdateCallbackResult",res);
            var resStr = JSON.stringify({
                callbackId:id,
                res:JSON.stringify(res)
            });
            moduleHelper.send('_OnCheckForUpdateCallback',resStr );
        };
        obj.OnCheckForUpdateList.push(callback);
        obj.onCheckForUpdate(callback);
    },
    WX_OnUpdateFailed(id){
        var obj = this.UpdateManagerList[id];
        obj.OnUpdateFailedList = obj.OnUpdateFailedList || [];
        let callback = (res)=>{
            formatResponse("GeneralCallbackResult",res);
            var resStr = JSON.stringify({
                callbackId:id,
                res:JSON.stringify(res)
            });
            moduleHelper.send('_OnUpdateFailedCallback',resStr );
        };
        obj.OnUpdateFailedList.push(callback);
        obj.onUpdateFailed(callback);
    },
    WX_OnUpdateReady(id){
        var obj = this.UpdateManagerList[id];
        obj.OnUpdateReadyList = obj.OnUpdateReadyList || [];
        let callback = (res)=>{
            formatResponse("GeneralCallbackResult",res);
            var resStr = JSON.stringify({
                callbackId:id,
                res:JSON.stringify(res)
            });
            moduleHelper.send('_OnUpdateReadyCallback',resStr );
        };
        obj.OnUpdateReadyList.push(callback);
        obj.onUpdateReady(callback);
    },

}
