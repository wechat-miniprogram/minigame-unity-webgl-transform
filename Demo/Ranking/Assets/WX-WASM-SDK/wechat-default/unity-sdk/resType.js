export default {
  AccountInfo: {
    miniProgram: 'MiniProgram',
    plugin: 'Plugin',
  },
  MiniProgram: {
    appId: 'string',
    envVersion: 'string',
    version: 'string',
  },
  Plugin: {
    appId: 'string',
    version: 'string',
  },
  GetBatteryInfoSyncResult: {
    isCharging: 'bool',
    level: 'int',
  },
  EnterOptionsGame: {
    query: 'object',
    referrerInfo: 'EnterOptionsGameReferrerInfo',
    scene: 'int',
    chatType: 'int',
    shareTicket: 'string',
  },
  EnterOptionsGameReferrerInfo: {
    appId: 'string',
    extraData: 'object',
    gameLiveInfo: 'GameLiveInfo',
  },
  GameLiveInfo: {
    streamerOpenId: 'string',
    feedId: 'string',
  },
  LaunchOptionsGame: {
    query: 'object',
    referrerInfo: 'EnterOptionsGameReferrerInfo',
    scene: 'int',
    chatType: 'int',
    shareTicket: 'string',
  },
  ClientRect: {
    bottom: 'int',
    height: 'int',
    left: 'int',
    right: 'int',
    top: 'int',
    width: 'int',
  },
  GetStorageInfoSyncOption: {
    currentSize: 'int',
    keys: 'array',
    limitSize: 'int',
  },
  SystemInfo: {
    SDKVersion: 'string',
    albumAuthorized: 'bool',
    benchmarkLevel: 'int',
    bluetoothEnabled: 'bool',
    brand: 'string',
    cameraAuthorized: 'bool',
    deviceOrientation: 'string',
    enableDebug: 'bool',
    fontSizeSetting: 'int',
    host: 'Host',
    language: 'string',
    locationAuthorized: 'bool',
    locationEnabled: 'bool',
    locationReducedAccuracy: 'bool',
    microphoneAuthorized: 'bool',
    model: 'string',
    notificationAlertAuthorized: 'bool',
    notificationAuthorized: 'bool',
    notificationBadgeAuthorized: 'bool',
    notificationSoundAuthorized: 'bool',
    phoneCalendarAuthorized: 'bool',
    pixelRatio: 'int',
    platform: 'string',
    safeArea: 'SafeArea',
    screenHeight: 'int',
    screenWidth: 'int',
    statusBarHeight: 'int',
    system: 'string',
    version: 'string',
    wifiEnabled: 'bool',
    windowHeight: 'int',
    windowWidth: 'int',
    theme: 'string',
  },
  Host: {
    appId: 'string',
  },
  SafeArea: {
    bottom: 'int',
    height: 'int',
    left: 'int',
    right: 'int',
    top: 'int',
    width: 'int',
  },
  OnCheckForUpdateCallbackResult: {
    hasUpdate: 'bool',
  },
  GeneralCallbackResult: {
    errMsg: 'string',
  },
  SetMessageToFriendQueryOption: {
    shareMessageToFriendScene: 'int',
  },
  AddCardRequestInfo: {
    cardExt: 'string',
    cardId: 'string',
  },
  AddCardSuccessCallbackResult: {
    cardList: 'array',
    errMsg: 'string',
  },
  AddCardResponseInfo: {
    cardExt: 'string',
    cardId: 'string',
    code: 'string',
    isSuccess: 'bool',
  },
  AuthPrivateMessageSuccessCallbackResult: {
    encryptedData: 'string',
    errMsg: 'string',
    iv: 'string',
    valid: 'bool',
  },
  CheckIsUserAdvisedToRestSuccessCallbackResult: {
    result: 'bool',
    errMsg: 'string',
  },
  ChooseImageSuccessCallbackResult: {
    tempFilePaths: 'array',
    tempFiles: 'array',
    errMsg: 'string',
  },
  ImageFile: {
    path: 'string',
    size: 'int',
  },
  BluetoothError: {
    errMsg: 'string',
    errCode: 'int',
  },
  CreateBLEPeripheralServerSuccessCallbackResult: {
    server: 'BLEPeripheralServer',
    errMsg: 'string',
  },
  BLEPeripheralService: {
    characteristics: 'array',
    uuid: 'string',
  },
  Characteristic: {
    uuid: 'string',
    descriptors: 'array',
    permission: 'CharacteristicPermission',
    properties: 'CharacteristicProperties',
    value: 'array',
  },
  Descriptor: {
    uuid: 'string',
    permission: 'DescriptorPermission',
    value: 'array',
  },
  DescriptorPermission: {
    read: 'bool',
    write: 'bool',
  },
  CharacteristicPermission: {
    readEncryptionRequired: 'bool',
    readable: 'bool',
    writeEncryptionRequired: 'bool',
    writeable: 'bool',
  },
  CharacteristicProperties: {
    indicate: 'bool',
    notify: 'bool',
    read: 'bool',
    write: 'bool',
    writeNoResponse: 'bool',
  },
  OnCharacteristicReadRequestCallbackResult: {
    callbackId: 'int',
    characteristicId: 'string',
    serviceId: 'string',
  },
  OnCharacteristicSubscribedCallbackResult: {
    characteristicId: 'string',
    serviceId: 'string',
  },
  OnCharacteristicWriteRequestCallbackResult: {
    callbackId: 'int',
    characteristicId: 'string',
    serviceId: 'string',
    value: 'array',
  },
  AdvertiseReqObj: {
    beacon: 'BeaconInfoObj',
    connectable: 'bool',
    deviceName: 'string',
    manufacturerData: 'array',
    serviceUuids: 'array',
  },
  BeaconInfoObj: {
    major: 'int',
    minor: 'int',
    uuid: 'string',
    measuredPower: 'int',
  },
  ManufacturerData: {
    manufacturerId: 'string',
    manufacturerSpecificData: 'array',
  },
  FaceDetectSuccessCallbackResult: {
    angleArray: 'FaceAngel',
    confArray: 'FaceConf',
    detectRect: 'object',
    faceInfo: 'array',
    pointArray: 'array',
    x: 'int',
    y: 'int',
    errMsg: 'string',
  },
  FaceAngel: {
    pitch: 'int',
    roll: 'int',
    yaw: 'int',
  },
  FaceConf: {
    global: 'int',
    leftEye: 'int',
    mouth: 'int',
    nose: 'int',
    rightEye: 'int',
  },
  GetAvailableAudioSourcesSuccessCallbackResult: {
    errMsg: 'string',
  },
  GetBLEDeviceCharacteristicsSuccessCallbackResult: {
    characteristics: 'array',
    errMsg: 'string',
  },
  BLECharacteristic: {
    properties: 'BLECharacteristicProperties',
    uuid: 'string',
  },
  BLECharacteristicProperties: {
    indicate: 'bool',
    notify: 'bool',
    read: 'bool',
    write: 'bool',
  },
  GetBLEDeviceRSSISuccessCallbackResult: {
    RSSI: 'int',
    errMsg: 'string',
  },
  GetBLEDeviceServicesSuccessCallbackResult: {
    services: 'array',
    errMsg: 'string',
  },
  BLEService: {
    isPrimary: 'bool',
    uuid: 'string',
  },
  GetBLEMTUSuccessCallbackResult: {
    mtu: 'int',
    errMsg: 'string',
  },
  GetBatteryInfoSuccessCallbackResult: {
    isCharging: 'bool',
    level: 'int',
    errMsg: 'string',
  },
  BeaconError: {
    errMsg: 'string',
    errCode: 'int',
  },
  GetBeaconsSuccessCallbackResult: {
    beacons: 'array',
    errMsg: 'string',
  },
  BeaconInfo: {
    accuracy: 'int',
    major: 'int',
    minor: 'int',
    proximity: 'int',
    rssi: 'int',
    uuid: 'string',
  },
  GetBluetoothAdapterStateSuccessCallbackResult: {
    available: 'bool',
    discovering: 'bool',
    errMsg: 'string',
  },
  GetBluetoothDevicesSuccessCallbackResult: {
    devices: 'array',
    errMsg: 'string',
  },
  BlueToothDevice: {
    RSSI: 'int',
    advertisData: 'array',
    advertisServiceUUIDs: 'array',
    deviceId: 'string',
    localName: 'string',
    name: 'string',
    serviceData: 'object',
  },
  GetChannelsLiveInfoSuccessCallbackResult: {
    description: 'string',
    feedId: 'string',
    headUrl: 'string',
    nickname: 'string',
    nonceId: 'string',
    status: 'int',
    errMsg: 'string',
  },
  GetChannelsLiveNoticeInfoSuccessCallbackResult: {
    headUrl: 'string',
    nickname: 'string',
    noticeId: 'string',
    reservable: 'bool',
    startTime: 'string',
    status: 'int',
    errMsg: 'string',
  },
  GetClipboardDataSuccessCallbackOption: {
    data: 'string',
  },
  GetConnectedBluetoothDevicesSuccessCallbackResult: {
    devices: 'array',
    errMsg: 'string',
  },
  BluetoothDeviceInfo: {
    deviceId: 'string',
    name: 'string',
  },
  GetExtConfigSuccessCallbackResult: {
    extConfig: 'object',
    errMsg: 'string',
  },
  WxGetFileInfoSuccessCallbackResult: {
    digest: 'string',
    size: 'int',
    errMsg: 'string',
  },
  GetGroupEnterInfoSuccessCallbackResult: {
    cloudID: 'string',
    encryptedData: 'string',
    errMsg: 'string',
    iv: 'string',
  },
  GetLocalIPAddressSuccessCallbackResult: {
    errMsg: 'string',
    localip: 'string',
  },
  GetLocationSuccessCallbackResult: {
    accuracy: 'int',
    altitude: 'int',
    horizontalAccuracy: 'int',
    latitude: 'int',
    longitude: 'int',
    speed: 'int',
    verticalAccuracy: 'int',
    errMsg: 'string',
  },
  GetNetworkTypeSuccessCallbackResult: {
    networkType: 'string',
    signalStrength: 'int',
    errMsg: 'string',
  },
  GetScreenBrightnessSuccessCallbackOption: {
    value: 'int',
    errMsg: 'string',
  },
  GetSettingSuccessCallbackResult: {
    authSetting: 'AuthSetting',
    subscriptionsSetting: 'SubscriptionsSetting',
    miniprogramAuthSetting: 'AuthSetting',
    errMsg: 'string',
  },
  AuthSetting: {
  },
  SubscriptionsSetting: {
    mainSwitch: 'bool',
    itemSettings: 'object',
  },
  GetStorageInfoSuccessCallbackOption: {
    currentSize: 'int',
    keys: 'array',
    limitSize: 'int',
  },
  GetUserInfoSuccessCallbackResult: {
    cloudID: 'string',
    encryptedData: 'string',
    iv: 'string',
    rawData: 'string',
    signature: 'string',
    userInfo: 'UserInfo',
    errMsg: 'string',
  },
  UserInfo: {
    avatarUrl: 'string',
    city: 'string',
    country: 'string',
    gender: 'int',
    language: 'string',
    nickName: 'string',
    province: 'string',
  },
  GetUserInteractiveStorageFailCallbackResult: {
    errCode: 'int',
    errMsg: 'string',
  },
  GetUserInteractiveStorageSuccessCallbackResult: {
    cloudID: 'string',
    encryptedData: 'string',
    errMsg: 'string',
    iv: 'string',
  },
  GetWeRunDataSuccessCallbackResult: {
    cloudID: 'string',
    encryptedData: 'string',
    iv: 'string',
    errMsg: 'string',
  },
  JoinVoIPChatError: {
    errMsg: 'string',
    errCode: 'int',
  },
  MuteConfig: {
    muteEarphone: 'bool',
    muteMicrophone: 'bool',
  },
  JoinVoIPChatSuccessCallbackResult: {
    errCode: 'int',
    errMsg: 'string',
    openIdList: 'array',
  },
  LoginSuccessCallbackResult: {
    code: 'string',
    errMsg: 'string',
  },
  OnAccelerometerChangeCallbackResult: {
    x: 'int',
    y: 'int',
    z: 'int',
  },
  OnAddToFavoritesCallbackResult: {
    disableForward: 'bool',
    imageUrl: 'string',
    query: 'string',
    title: 'string',
  },
  OnBLECharacteristicValueChangeCallbackResult: {
    characteristicId: 'string',
    deviceId: 'string',
    serviceId: 'string',
    value: 'array',
  },
  OnBLEConnectionStateChangeCallbackResult: {
    connected: 'bool',
    deviceId: 'string',
  },
  OnBLEMTUChangeCallbackResult: {
    deviceId: 'string',
    mtu: 'int',
  },
  OnBLEPeripheralConnectionStateChangedCallbackResult: {
    connected: 'bool',
    deviceId: 'string',
    serverId: 'string',
  },
  OnBeaconServiceChangeCallbackResult: {
    available: 'bool',
    discovering: 'bool',
  },
  OnBeaconUpdateCallbackResult: {
    beacons: 'array',
  },
  OnBluetoothAdapterStateChangeCallbackResult: {
    available: 'bool',
    discovering: 'bool',
  },
  OnBluetoothDeviceFoundCallbackResult: {
    devices: 'array',
  },
  OnCompassChangeCallbackResult: {
    accuracy: 'int',
    direction: 'int',
  },
  OnCopyUrlCallbackResult: {
    query: 'string',
  },
  OnDeviceMotionChangeCallbackResult: {
    alpha: 'int',
    beta: 'int',
    gamma: 'int',
  },
  OnDeviceOrientationChangeCallbackResult: {
    value: 'string',
  },
  WxOnErrorCallbackResult: {
    message: 'string',
    stack: 'string',
  },
  OnGyroscopeChangeCallbackResult: {
    x: 'int',
    y: 'int',
    z: 'int',
  },
  OnHandoffCallbackResult: {
    query: 'string',
  },
  OnKeyDownCallbackResult: {
    code: 'string',
    key: 'string',
    timeStamp: 'int',
  },
  OnKeyboardInputCallbackResult: {
    value: 'string',
  },
  OnKeyboardHeightChangeCallbackResult: {
    height: 'int',
  },
  OnMemoryWarningCallbackResult: {
    level: 'int',
  },
  OnNetworkStatusChangeCallbackResult: {
    isConnected: 'bool',
    networkType: 'string',
  },
  OnNetworkWeakChangeCallbackResult: {
    networkType: 'string',
    weakNet: 'bool',
  },
  OnShareTimelineCallbackResult: {
    imageUrl: 'string',
    imagePreviewUrl: 'string',
    imagePreviewUrlId: 'string',
    imageUrlId: 'string',
    path: 'string',
    query: 'string',
    title: 'string',
  },
  OnShowCallbackResult: {
    query: 'object',
    referrerInfo: 'ResultReferrerInfo',
    scene: 'int',
    shareTicket: 'string',
  },
  ResultReferrerInfo: {
    appId: 'string',
    extraData: 'object',
  },
  SocketTaskOnCloseCallbackResult: {
    code: 'int',
    reason: 'string',
  },
  SocketTaskOnMessageCallbackResult: {
    data: 'string',
  },
  OnSocketOpenCallbackResult: {
    header: 'object',
  },
  OnTouchStartCallbackResult: {
    changedTouches: 'array',
    timeStamp: 'int',
    touches: 'array',
  },
  Touch: {
    clientX: 'int',
    clientY: 'int',
    force: 'int',
    identifier: 'int',
    pageX: 'int',
    pageY: 'int',
  },
  OnUnhandledRejectionCallbackResult: {
    promise: 'string',
    reason: 'string',
  },
  OnVoIPChatInterruptedCallbackResult: {
    errCode: 'int',
    errMsg: 'string',
  },
  OnVoIPChatMembersChangedCallbackResult: {
    errCode: 'int',
    errMsg: 'string',
    openIdList: 'array',
  },
  OnVoIPChatSpeakersChangedCallbackResult: {
    errCode: 'int',
    errMsg: 'string',
    openIdList: 'array',
  },
  OnVoIPChatStateChangedCallbackResult: {
    code: 'int',
    data: 'object',
    errCode: 'int',
    errMsg: 'string',
  },
  OnWindowResizeCallbackResult: {
    windowHeight: 'int',
    windowWidth: 'int',
  },
  OpenCardRequestInfo: {
    cardId: 'string',
    code: 'string',
  },
  OpenSettingSuccessCallbackResult: {
    authSetting: 'AuthSetting',
    subscriptionsSetting: 'SubscriptionsSetting',
    errMsg: 'string',
  },
  MediaSource: {
    url: 'string',
    poster: 'string',
    type: 'string',
  },
  ReportUserBehaviorBranchAnalyticsOption: {
    branchId: 'string',
    eventType: 'int',
    branchDim: 'string',
  },
  MidasFriendPaymentError: {
    errMsg: 'string',
    errCode: 'int',
  },
  RequestMidasFriendPaymentSuccessCallbackResult: {
    cloudID: 'string',
    encryptedData: 'string',
    errMsg: 'string',
    iv: 'string',
  },
  MidasPaymentError: {
    errMsg: 'string',
    errCode: 'int',
  },
  RequestSubscribeMessageFailCallbackResult: {
    errCode: 'int',
    errMsg: 'string',
  },
  RequestSubscribeMessageSuccessCallbackResult: {
    errMsg: 'string',
  },
  RequestSubscribeSystemMessageSuccessCallbackResult: {
    errMsg: 'string',
  },
  ReserveChannelsLiveOption: {
    noticeId: 'string',
  },
  ScanCodeSuccessCallbackResult: {
    charSet: 'string',
    path: 'string',
    rawData: 'string',
    result: 'string',
    scanType: 'string',
    errMsg: 'string',
  },
  SetBLEMTUFailCallbackResult: {
    mtu: 'int',
  },
  SetBLEMTUSuccessCallbackResult: {
    mtu: 'int',
    errMsg: 'string',
  },
  KVData: {
    key: 'string',
    value: 'string',
  },
  ShareAppMessageOption: {
    imageUrl: 'string',
    imageUrlId: 'string',
    path: 'string',
    query: 'string',
    title: 'string',
    toCurrentGroup: 'bool',
  },
  ShowActionSheetSuccessCallbackResult: {
    tapIndex: 'int',
    errMsg: 'string',
  },
  ShowModalSuccessCallbackResult: {
    cancel: 'bool',
    confirm: 'bool',
    content: 'string',
    errMsg: 'string',
  },
  UpdatableMessageFrontEndTemplateInfo: {
    parameterList: 'array',
  },
  UpdatableMessageFrontEndParameter: {
    name: 'string',
    value: 'string',
  },
  CheckGameLiveEnabledSuccessCallbackOption: {
    errMsg: 'string',
    isEnabled: 'bool',
  },
  OnGameLiveStateChangeCallbackResult: {
    state: 'string',
    feedId: 'string',
  },
  OnGameLiveStateChangeCallbackResponse: {
    query: 'string',
  },
  GameLiveState: {
    isLive: 'bool',
  },
  GetUserCurrentGameliveInfoSuccessCallbackOption: {
    feedIdList: 'array',
  },
  GetUserGameLiveDetailsSuccessCallbackOption: {
    encryptedData: 'string',
    iv: 'string',
    cloudID: 'string',
    feedIdList: 'array',
    errMsg: 'string',
  },
  GameClubDataType: {
    type: 'int',
    subKey: 'string',
    value: 'int',
  },
  getGameClubDataSuccessCallbackResult: {
    signature: 'string',
    encryptedData: 'string',
    iv: 'string',
    cloudID: 'string',
    errMsg: 'string',
  },
};
