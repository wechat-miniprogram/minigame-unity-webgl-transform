#if UNITY_WEBGL || WEIXINMINIGAME || UNITY_EDITOR
using System;

namespace WeChatWASM
{
    /// <summary>
    /// 微信SDK对外暴露的API
    /// </summary>
    public class WX : WXBase
    {
        /// <summary>
        /// [wx.addCard(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/card/wx.addCard.html)
        /// 需要基础库： `2.5.0`
        /// 批量添加卡券。只有通过 [认证](https://developers.weixin.qq.com/miniprogram/product/renzheng.html) 的小程序或文化互动类目的小游戏才能使用。更多文档请参考 [微信卡券接口文档](https://mp.weixin.qq.com/cgi-bin/announce?action=getannouncement&key=1490190158&version=1&lang=zh_CN&platform=2)。
        /// **cardExt 说明**
        /// cardExt 是卡券的扩展参数，其值是一个 JSON 字符串。
        /// **示例代码**
        /// ```js
        /// wx.addCard({
        /// cardList: [
        /// {
        /// cardId: '',
        /// cardExt: '{"code": "", "openid": "", "timestamp": "", "signature":""}'
        /// }, {
        /// cardId: '',
        /// cardExt: '{"code": "", "openid": "", "timestamp": "", "signature":""}'
        /// }
        /// ],
        /// success (res) {
        /// console.log(res.cardList) // 卡券添加结果
        /// }
        /// })
        /// ```
        /// </summary>
        public static void AddCard(AddCardOption callback)
        {
            WXSDKManagerHandler.Instance.AddCard(callback);
        }

        /// <summary>
        /// [wx.authPrivateMessage(Object object)](https://developers.weixin.qq.com/minigame/dev/api/share/wx.authPrivateMessage.html)
        /// 需要基础库： `2.13.0`
        /// 验证私密消息。用法详情见 [小程序私密消息使用指南](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/share/private-message.html)
        /// **示例代码**
        /// ```js
        /// wx.authPrivateMessage({
        /// shareTicket: 'xxxxxx',
        /// success(res) {
        /// console.log('authPrivateMessage success', res)
        /// // res
        /// // {
        /// //   errMsg: 'authPrivateMessage:ok'
        /// //   valid: true
        /// //   iv: 'xxxx',
        /// //   encryptedData: 'xxxxxx'
        /// // }
        /// },
        /// fail(res) {
        /// console.log('authPrivateMessage fail', res)
        /// }
        /// })
        /// ```
        /// </summary>
        public static void AuthPrivateMessage(AuthPrivateMessageOption callback)
        {
            WXSDKManagerHandler.Instance.AuthPrivateMessage(callback);
        }

        /// <summary>
        /// [wx.authorize(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/authorize/wx.authorize.html)
        /// 需要基础库： `1.2.0`
        /// 提前向用户发起授权请求。调用后会立刻弹窗询问用户是否同意授权小程序使用某项功能或获取用户的某些数据，但不会实际调用对应接口。如果用户之前已经同意授权，则不会出现弹窗，直接返回成功。更多用法详见 [用户授权](https://developers.weixin.qq.com/minigame/dev/guide/base-ability/authorize.html)。
        /// **注意事项**
        /// - 小游戏内使用 `wx.authorize({scope: "scope.userInfo"})`，不会弹出授权窗口，请使用 [wx.createUserInfoButton](https://developers.weixin.qq.com/minigame/dev/api/open-api/user-info/wx.createUserInfoButton.html)
        /// - 需要授权 `scope.userFuzzyLocation` 时必须[配置地理位置用途说明](https://developers.weixin.qq.com/minigame/dev/reference/configuration/app.html#permission)。
        /// **示例代码**
        /// ```js
        /// // 可以通过 wx.getSetting 先查询一下用户是否授权了 "scope.writePhotosAlbum" 这个 scope
        /// wx.getSetting({
        /// success(res) {
        /// if (!res.authSetting['scope.writePhotosAlbum']) {
        /// wx.authorize({
        /// scope: 'scope.writePhotosAlbum',
        /// success () {
        /// // 用户已经同意保存到相册功能，后续调用 wx.saveImageToPhotosAlbum 接口不会弹窗询问
        /// wx.saveImageToPhotosAlbum()
        /// }
        /// })
        /// }
        /// }
        /// })
        /// ```
        /// </summary>
        public static void Authorize(AuthorizeOption callback)
        {
            WXSDKManagerHandler.Instance.Authorize(callback);
        }

        /// <summary>
        /// [wx.checkIsAddedToMyMiniProgram(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/my-miniprogram/wx.checkIsAddedToMyMiniProgram.html)
        /// 需要基础库： `2.30.3`
        /// 检查小程序是否被添加至 「我的小程序」
        /// </summary>
        public static void CheckIsAddedToMyMiniProgram(CheckIsAddedToMyMiniProgramOption callback)
        {
            WXSDKManagerHandler.Instance.CheckIsAddedToMyMiniProgram(callback);
        }

        /// <summary>
        /// [wx.checkSession(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/login/wx.checkSession.html)
        /// 检查登录态是否过期。
        /// 通过 wx.login 接口获得的用户登录态拥有一定的时效性。用户越久未使用小程序，用户登录态越有可能失效。反之如果用户一直在使用小程序，则用户登录态一直保持有效。具体时效逻辑由微信维护，对开发者透明。开发者只需要调用 wx.checkSession 接口检测当前用户登录态是否有效。
        /// 登录态过期后开发者可以再调用 wx.login 获取新的用户登录态。调用成功说明当前 session_key 未过期，调用失败说明 session_key 已过期。
        /// **示例代码**
        /// ```js
        /// wx.checkSession({
        /// success () {
        /// //session_key 未过期，并且在本生命周期一直有效
        /// },
        /// fail () {
        /// // session_key 已经失效，需要重新执行登录流程
        /// wx.login() //重新登录
        /// }
        /// })
        /// ```
        /// </summary>
        public static void CheckSession(CheckSessionOption callback)
        {
            WXSDKManagerHandler.Instance.CheckSession(callback);
        }

        /// <summary>
        /// [wx.chooseImage(Object object)](https://developers.weixin.qq.com/minigame/dev/api/media/image/wx.chooseImage.html)
        /// </summary>
        public static void ChooseImage(ChooseImageOption callback)
        {
            WXSDKManagerHandler.Instance.ChooseImage(callback);
        }

        /// <summary>
        /// [wx.chooseMedia(Object object)](https://developers.weixin.qq.com/minigame/dev/api/media/video/wx.chooseMedia.html)
        /// 需要基础库： `2.23.0`
        /// 拍摄或从手机相册中选择图片或视频。
        /// **示例代码**
        /// ```js
        /// wx.chooseMedia({
        /// count: 9,
        /// mediaType: ['image','video'],
        /// sourceType: ['album', 'camera'],
        /// maxDuration: 30,
        /// camera: 'back',
        /// success(res) {
        /// console.log(res.tempFiles.tempFilePath)
        /// console.log(res.tempFiles.size)
        /// }
        /// })
        /// ```
        /// </summary>
        public static void ChooseMedia(ChooseMediaOption callback)
        {
            WXSDKManagerHandler.Instance.ChooseMedia(callback);
        }

        /// <summary>
        /// [wx.chooseMessageFile(Object object)](https://developers.weixin.qq.com/minigame/dev/api/media/image/wx.chooseMessageFile.html)
        /// 需要基础库： `2.23.0`
        /// 从客户端会话选择文件。
        /// ****
        /// ```js
        /// wx.chooseMessageFile({
        /// count: 10,
        /// type: 'image',
        /// success (res) {
        /// // tempFilePath可以作为img标签的src属性显示图片
        /// const tempFilePaths = res.tempFiles
        /// }
        /// })
        /// ```
        /// </summary>
        public static void ChooseMessageFile(ChooseMessageFileOption callback)
        {
            WXSDKManagerHandler.Instance.ChooseMessageFile(callback);
        }

        /// <summary>
        /// [wx.closeBLEConnection(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.closeBLEConnection.html)
        /// 需要基础库： `2.9.2`
        /// 断开与蓝牙低功耗设备的连接。
        /// **示例代码**
        /// [在微信开发者工具中查看示例](https://developers.weixin.qq.com/s/pQU51zmz7a3K)
        /// ```js
        /// wx.closeBLEConnection({
        /// deviceId,
        /// success (res) {
        /// console.log(res)
        /// }
        /// })
        /// ```
        /// </summary>
        public static void CloseBLEConnection(CloseBLEConnectionOption callback)
        {
            WXSDKManagerHandler.Instance.CloseBLEConnection(callback);
        }

        /// <summary>
        /// [wx.closeBluetoothAdapter(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth/wx.closeBluetoothAdapter.html)
        /// 需要基础库： `2.9.2`
        /// 关闭蓝牙模块。调用该方法将断开所有已建立的连接并释放系统资源。建议在使用蓝牙流程后，与 [wx.openBluetoothAdapter](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth/wx.openBluetoothAdapter.html) 成对调用。
        /// **示例代码**
        /// [在微信开发者工具中查看示例](https://developers.weixin.qq.com/s/pQU51zmz7a3K)
        /// ```js
        /// wx.closeBluetoothAdapter({
        /// success (res) {
        /// console.log(res)
        /// }
        /// })
        /// ```
        /// </summary>
        public static void CloseBluetoothAdapter(CloseBluetoothAdapterOption callback)
        {
            WXSDKManagerHandler.Instance.CloseBluetoothAdapter(callback);
        }

        /// <summary>
        /// [wx.compressImage(Object object)](https://developers.weixin.qq.com/minigame/dev/api/media/image/wx.compressImage.html)
        /// 需要基础库： `3.0.1`
        /// 压缩图片接口，可选压缩质量
        /// **示例代码**
        /// ```js
        /// wx.compressImage({
        /// src: '', // 图片路径
        /// quality: 80 // 压缩质量
        /// })
        /// ```
        /// </summary>
        public static void CompressImage(CompressImageOption callback)
        {
            WXSDKManagerHandler.Instance.CompressImage(callback);
        }

        /// <summary>
        /// [wx.createBLEConnection(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.createBLEConnection.html)
        /// 需要基础库： `2.9.2`
        /// 连接蓝牙低功耗设备。
        /// 若小程序在之前已有搜索过某个蓝牙设备，并成功建立连接，可直接传入之前搜索获取的 deviceId 直接尝试连接该设备，无需再次进行搜索操作。
        /// **注意**
        /// - 请保证尽量成对的调用 [wx.createBLEConnection](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.createBLEConnection.html) 和 [wx.closeBLEConnection](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.closeBLEConnection.html) 接口。安卓如果重复调用 [wx.createBLEConnection](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.createBLEConnection.html) 创建连接，有可能导致系统持有同一设备多个连接的实例，导致调用 `closeBLEConnection` 的时候并不能真正的断开与设备的连接。
        /// - 蓝牙连接随时可能断开，建议监听 [wx.onBLEConnectionStateChange](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.onBLEConnectionStateChange.html) 回调事件，当蓝牙设备断开时按需执行重连操作
        /// - 若对未连接的设备或已断开连接的设备调用数据读写操作的接口，会返回 10006 错误，建议进行重连操作。
        /// **示例代码**
        /// [在微信开发者工具中查看示例](https://developers.weixin.qq.com/s/pQU51zmz7a3K)
        /// ```js
        /// wx.createBLEConnection({
        /// deviceId,
        /// success (res) {
        /// console.log(res)
        /// }
        /// })
        /// ```
        /// </summary>
        public static void CreateBLEConnection(CreateBLEConnectionOption callback)
        {
            WXSDKManagerHandler.Instance.CreateBLEConnection(callback);
        }

        /// <summary>
        /// [wx.createBLEPeripheralServer(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-peripheral/wx.createBLEPeripheralServer.html)
        /// 需要基础库： `2.10.3`
        /// 建立本地作为蓝牙低功耗外围设备的服务端，可创建多个。
        /// </summary>
        public static void CreateBLEPeripheralServer(CreateBLEPeripheralServerOption callback)
        {
            WXSDKManagerHandler.Instance.CreateBLEPeripheralServer(callback);
        }

        /// <summary>
        /// [wx.exitMiniProgram(Object object)](https://developers.weixin.qq.com/minigame/dev/api/navigate/wx.exitMiniProgram.html)
        /// 需要基础库： `2.17.3`
        /// 退出当前小程序。必须有点击行为才能调用成功。
        /// </summary>
        public static void ExitMiniProgram(ExitMiniProgramOption callback)
        {
            WXSDKManagerHandler.Instance.ExitMiniProgram(callback);
        }

        /// <summary>
        /// [wx.exitVoIPChat(Object object)](https://developers.weixin.qq.com/minigame/dev/api/media/voip/wx.exitVoIPChat.html)
        /// 需要基础库： `2.7.0`
        /// 退出（销毁）实时语音通话
        /// </summary>
        public static void ExitVoIPChat(ExitVoIPChatOption callback)
        {
            WXSDKManagerHandler.Instance.ExitVoIPChat(callback);
        }

        /// <summary>
        /// [wx.faceDetect(Object object)](https://developers.weixin.qq.com/minigame/dev/api/ai/face/wx.faceDetect.html)
        /// 需要基础库： `2.18.0`
        /// </summary>
        public static void FaceDetect(FaceDetectOption callback)
        {
            WXSDKManagerHandler.Instance.FaceDetect(callback);
        }

        /// <summary>
        /// [wx.getAvailableAudioSources(Object object)](https://developers.weixin.qq.com/minigame/dev/api/media/audio/wx.getAvailableAudioSources.html)
        /// 需要基础库： `2.1.0`
        /// 获取当前支持的音频输入源
        /// </summary>
        public static void GetAvailableAudioSources(GetAvailableAudioSourcesOption callback)
        {
            WXSDKManagerHandler.Instance.GetAvailableAudioSources(callback);
        }

        /// <summary>
        /// [wx.getBLEDeviceCharacteristics(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.getBLEDeviceCharacteristics.html)
        /// 需要基础库： `2.9.2`
        /// 获取蓝牙低功耗设备某个服务中所有特征 (characteristic)。
        /// **示例代码**
        /// [在微信开发者工具中查看示例](https://developers.weixin.qq.com/s/pQU51zmz7a3K)
        /// ```js
        /// wx.getBLEDeviceCharacteristics({
        /// // 这里的 deviceId 需要已经通过 wx.createBLEConnection 与对应设备建立链接
        /// deviceId,
        /// // 这里的 serviceId 需要在 wx.getBLEDeviceServices 接口中获取
        /// serviceId,
        /// success (res) {
        /// console.log('device getBLEDeviceCharacteristics:', res.characteristics)
        /// }
        /// })
        /// ```
        /// </summary>
        public static void GetBLEDeviceCharacteristics(GetBLEDeviceCharacteristicsOption callback)
        {
            WXSDKManagerHandler.Instance.GetBLEDeviceCharacteristics(callback);
        }

        /// <summary>
        /// [wx.getBLEDeviceRSSI(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.getBLEDeviceRSSI.html)
        /// 需要基础库： `2.11.0`
        /// 获取蓝牙低功耗设备的信号强度 (Received Signal Strength Indication, RSSI)。
        /// </summary>
        public static void GetBLEDeviceRSSI(GetBLEDeviceRSSIOption callback)
        {
            WXSDKManagerHandler.Instance.GetBLEDeviceRSSI(callback);
        }

        /// <summary>
        /// [wx.getBLEDeviceServices(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.getBLEDeviceServices.html)
        /// 需要基础库： `2.9.2`
        /// 获取蓝牙低功耗设备所有服务 (service)。
        /// **示例代码**
        /// [在微信开发者工具中查看示例](https://developers.weixin.qq.com/s/pQU51zmz7a3K)
        /// ```js
        /// wx.getBLEDeviceServices({
        /// // 这里的 deviceId 需要已经通过 wx.createBLEConnection 与对应设备建立连接
        /// deviceId,
        /// success (res) {
        /// console.log('device services:', res.services)
        /// }
        /// })
        /// ```
        /// </summary>
        public static void GetBLEDeviceServices(GetBLEDeviceServicesOption callback)
        {
            WXSDKManagerHandler.Instance.GetBLEDeviceServices(callback);
        }

        /// <summary>
        /// [wx.getBLEMTU(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.getBLEMTU.html)
        /// 需要基础库： `2.20.1`
        /// 获取蓝牙低功耗的最大传输单元。需在 [wx.createBLEConnection](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.createBLEConnection.html) 调用成功后调用。
        /// **注意**
        /// - 小程序中 MTU 为 ATT_MTU，包含 Op-Code 和 Attribute Handle 的长度，实际可以传输的数据长度为 `ATT_MTU - 3`
        /// - iOS 系统中 MTU 为固定值；安卓系统中，MTU 会在系统协商成功之后发生改变，建议使用 [wx.onBLEMTUChange](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.onBLEMTUChange.html) 监听。
        /// **示例代码**
        /// [在微信开发者工具中查看示例](https://developers.weixin.qq.com/s/pQU51zmz7a3K)
        /// ```js
        /// wx.getBLEMTU({
        /// deviceId: '',
        /// writeType: 'write',
        /// success (res) {
        /// console.log(res)
        /// }
        /// })
        /// ```
        /// </summary>
        public static void GetBLEMTU(GetBLEMTUOption callback)
        {
            WXSDKManagerHandler.Instance.GetBLEMTU(callback);
        }

        /// <summary>
        /// [wx.getBackgroundFetchData(object object)](https://developers.weixin.qq.com/minigame/dev/api/storage/background-fetch/wx.getBackgroundFetchData.html)
        /// 需要基础库： `3.0.1`
        /// 拉取 backgroundFetch 客户端缓存数据。
        /// 当调用接口时，若当次请求未结束，会先返回本地的旧数据（之前打开小程序时请求的），如果本地没有旧数据，安卓上会返回fail，不会等待请求完成，iOS上会返回success但fetchedData为空，也不会等待请求完成。
        /// </summary>
        public static void GetBackgroundFetchData(GetBackgroundFetchDataOption callback)
        {
            WXSDKManagerHandler.Instance.GetBackgroundFetchData(callback);
        }

        /// <summary>
        /// [wx.getBackgroundFetchToken(Object object)](https://developers.weixin.qq.com/minigame/dev/api/storage/background-fetch/wx.getBackgroundFetchToken.html)
        /// 需要基础库： `3.0.1`
        /// 获取设置过的自定义登录态。若无，则返回 fail。
        /// </summary>
        public static void GetBackgroundFetchToken(GetBackgroundFetchTokenOption callback)
        {
            WXSDKManagerHandler.Instance.GetBackgroundFetchToken(callback);
        }

        /// <summary>
        /// [wx.getBatteryInfo(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/battery/wx.getBatteryInfo.html)
        /// 获取设备电量。同步 API [wx.getBatteryInfoSync](https://developers.weixin.qq.com/minigame/dev/api/device/battery/wx.getBatteryInfoSync.html) 在 iOS 上不可用。
        /// </summary>
        public static void GetBatteryInfo(GetBatteryInfoOption callback)
        {
            WXSDKManagerHandler.Instance.GetBatteryInfo(callback);
        }

        /// <summary>
        /// [wx.getBeacons(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/ibeacon/wx.getBeacons.html)
        /// 需要基础库： `2.9.2`
        /// 获取所有已搜索到的 Beacon 设备
        /// </summary>
        public static void GetBeacons(GetBeaconsOption callback)
        {
            WXSDKManagerHandler.Instance.GetBeacons(callback);
        }

        /// <summary>
        /// [wx.getBluetoothAdapterState(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth/wx.getBluetoothAdapterState.html)
        /// 需要基础库： `2.9.2`
        /// 获取本机蓝牙适配器状态。
        /// **示例代码**
        /// [在微信开发者工具中查看示例](https://developers.weixin.qq.com/s/pQU51zmz7a3K)
        /// ```js
        /// wx.getBluetoothAdapterState({
        /// success (res) {
        /// console.log(res)
        /// }
        /// })
        /// ```
        /// </summary>
        public static void GetBluetoothAdapterState(GetBluetoothAdapterStateOption callback)
        {
            WXSDKManagerHandler.Instance.GetBluetoothAdapterState(callback);
        }

        /// <summary>
        /// [wx.getBluetoothDevices(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth/wx.getBluetoothDevices.html)
        /// 需要基础库： `2.9.2`
        /// 获取在蓝牙模块生效期间所有搜索到的蓝牙设备。包括已经和本机处于连接状态的设备。
        /// **示例代码**
        /// [在微信开发者工具中查看示例](https://developers.weixin.qq.com/s/pQU51zmz7a3K)
        /// ```js
        /// // ArrayBuffer转16进度字符串示例
        /// function ab2hex(buffer) {
        /// var hexArr = Array.prototype.map.call(
        /// new Uint8Array(buffer),
        /// function(bit) {
        /// return ('00' + bit.toString(16)).slice(-2)
        /// }
        /// )
        /// return hexArr.join('');
        /// }
        /// wx.getBluetoothDevices({
        /// success: function (res) {
        /// console.log(res)
        /// if (res.devices[0]) {
        /// console.log(ab2hex(res.devices[0].advertisData))
        /// }
        /// }
        /// })
        /// ```
        /// **注意**
        /// - 该接口获取到的设备列表为**蓝牙模块生效期间所有搜索到的蓝牙设备**，若在蓝牙模块使用流程结束后未及时调用 [wx.closeBluetoothAdapter](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth/wx.closeBluetoothAdapter.html) 释放资源，会存在调用该接口会返回之前的蓝牙使用流程中搜索到的蓝牙设备，可能设备已经不在用户身边，无法连接。
        /// </summary>
        public static void GetBluetoothDevices(GetBluetoothDevicesOption callback)
        {
            WXSDKManagerHandler.Instance.GetBluetoothDevices(callback);
        }

        /// <summary>
        /// [wx.getChannelsLiveInfo(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/channels/wx.getChannelsLiveInfo.html)
        /// 需要基础库： `2.15.0`
        /// 获取视频号直播信息
        /// </summary>
        public static void GetChannelsLiveInfo(GetChannelsLiveInfoOption callback)
        {
            WXSDKManagerHandler.Instance.GetChannelsLiveInfo(callback);
        }

        /// <summary>
        /// [wx.getChannelsLiveNoticeInfo(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/channels/wx.getChannelsLiveNoticeInfo.html)
        /// 需要基础库： `2.19.0`
        /// 获取视频号直播预告信息
        /// </summary>
        public static void GetChannelsLiveNoticeInfo(GetChannelsLiveNoticeInfoOption callback)
        {
            WXSDKManagerHandler.Instance.GetChannelsLiveNoticeInfo(callback);
        }

        /// <summary>
        /// [wx.getClipboardData(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/clipboard/wx.getClipboardData.html)
        /// 需要基础库： `1.1.0`
        /// 获取系统剪贴板的内容
        /// **示例代码**
        /// ```js
        /// wx.getClipboardData({
        /// success (res){
        /// console.log(res.data)
        /// }
        /// })
        /// ```
        /// </summary>
        public static void GetClipboardData(GetClipboardDataOption callback)
        {
            WXSDKManagerHandler.Instance.GetClipboardData(callback);
        }

        /// <summary>
        /// [wx.getConnectedBluetoothDevices(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth/wx.getConnectedBluetoothDevices.html)
        /// 需要基础库： `2.9.2`
        /// 根据主服务 UUID 获取已连接的蓝牙设备。
        /// **示例代码**
        /// [在微信开发者工具中查看示例](https://developers.weixin.qq.com/s/pQU51zmz7a3K)
        /// ```js
        /// wx.getConnectedBluetoothDevices({
        /// services: ['FEE7'],
        /// success (res) {
        /// console.log(res)
        /// }
        /// })
        /// ```
        /// </summary>
        public static void GetConnectedBluetoothDevices(GetConnectedBluetoothDevicesOption callback)
        {
            WXSDKManagerHandler.Instance.GetConnectedBluetoothDevices(callback);
        }

        /// <summary>
        /// [wx.getExtConfig(Object object)](https://developers.weixin.qq.com/minigame/dev/api/ext/wx.getExtConfig.html)
        /// 需要基础库： `2.8.3`
        /// 获取[第三方平台](https://developers.weixin.qq.com/minigame/dev/devtools/ext.html)自定义的数据字段。
        /// **Tips**
        /// 1. 本接口暂时无法通过 [wx.canIUse](#) 判断是否兼容，开发者需要自行判断 [wx.getExtConfig](https://developers.weixin.qq.com/minigame/dev/api/ext/wx.getExtConfig.html) 是否存在来兼容
        /// ****
        /// ```js
        /// if (wx.getExtConfig) {
        /// wx.getExtConfig({
        /// success (res) {
        /// console.log(res.extConfig)
        /// }
        /// })
        /// }
        /// ```
        /// </summary>
        public static void GetExtConfig(GetExtConfigOption callback)
        {
            WXSDKManagerHandler.Instance.GetExtConfig(callback);
        }

        /// <summary>
        /// [wx.getFuzzyLocation(Object object)](https://developers.weixin.qq.com/minigame/dev/api/location/wx.getFuzzyLocation.html)
        /// 需要基础库： `2.25.0`
        /// 获取当前的模糊地理位置。
        /// **示例代码**
        /// ```js
        /// wx.getFuzzyLocation({
        /// type: 'wgs84',
        /// success (res) {
        /// const latitude = res.latitude
        /// const longitude = res.longitude
        /// }
        /// })
        /// ```
        /// </summary>
        public static void GetFuzzyLocation(GetFuzzyLocationOption callback)
        {
            WXSDKManagerHandler.Instance.GetFuzzyLocation(callback);
        }

        /// <summary>
        /// [wx.getGameClubData(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/game-club/wx.getGameClubData.html)
        /// 需要基础库： `2.25.4`
        /// 获取游戏圈数据。
        /// **type说明**
        /// | type取值 | 说明                                   | subKey  | GameClubDataByType.value |
        /// | ------- | -------------------------------------- | -------- | -------- |
        /// | 1   | 加入该游戏圈时间                            | 无需传入 | 秒级Unix时间戳 |
        /// | 3   | 用户禁言状态                                | 无需传入  | 0：正常 1：禁言  |
        /// | 4   | 当天(自然日)点赞贴子数                       | 无需传入  |  |
        /// | 5   | 当天(自然日)评论贴子数                        | 无需传入  |  |
        /// | 6   | 当天(自然日)发表贴子数                       | 无需传入  |  |
        /// | 7   | 当天(自然日)发表视频贴子数                    | 无需传入  |  |
        /// | 8   | 当天(自然日)赞官方贴子数                      | 无需传入  |  |
        /// | 9   | 当天(自然日)评论官方贴子数                     | 无需传入  |  |
        /// | 10   | 当天(自然日)发表到本圈子话题的贴子数           | 传入话题id，从mp-游戏圈话题管理处获取  |  |
        /// **encryptedData 解密后得到的 GameClubData 的结构**
        /// | 属性 | 类型 | 说明                                   |
        /// | ------- | ------- | -------------------------------------- |
        /// |  dataList   | Array<GameClubDataByType> | 游戏圈相关数据的对象数组           |
        /// **GameClubDataByType 的结构**
        /// | 属性 | 类型 | 说明                                   |
        /// | ------- |------- |  -------------------------------------- |
        /// |  dataType   | number | 与输入的 dataType 一致          |
        /// |  value   | number | 不同type返回的value含义不同，见type表格说明           |
        /// </summary>
        public static void GetGameClubData(GetGameClubDataOption callback)
        {
            WXSDKManagerHandler.Instance.GetGameClubData(callback);
        }

        /// <summary>
        /// [wx.getGroupEnterInfo(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/group/wx.getGroupEnterInfo.html)
        /// 需要基础库： `2.10.4`
        /// 获取微信群聊场景下的小程序启动信息。群聊场景包括群聊小程序消息卡片、群待办、群工具。可用于获取当前群的 opengid。
        /// ## 注意事项
        /// - 基础库 v2.10.4 开始支持获取群工具小程序启动信息
        /// - 基础库 v2.17.3 开始支持获取群聊小程序消息卡片、群待办小程序启动信息
        /// **示例代码**
        /// ```js
        /// wx.getGroupEnterInfo({
        /// success(res) {
        /// // res
        /// {
        /// errMsg: 'getGroupEnterInfo:ok',
        /// encryptedData: '',
        /// iv: ''
        /// }
        /// },
        /// fail() {
        /// }
        /// })
        /// ```
        /// 敏感数据有两种获取方式，一是使用 [加密数据解密算法](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/signature.html#加密数据解密算法) 。
        /// 获取得到的开放数据为以下 json 结构（其中 opengid 为当前群的唯一标识）：
        /// ```json
        /// {
        /// "opengid": "OPENGID"
        /// }
        /// ```
        /// **Tips**
        /// - 如需要展示群名称，小程序可以使用[开放数据组件](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/open-data.html)
        /// - 小游戏可以通过 `wx.getGroupInfo` 接口获取群名称
        /// </summary>
        public static void GetGroupEnterInfo(GetGroupEnterInfoOption callback)
        {
            WXSDKManagerHandler.Instance.GetGroupEnterInfo(callback);
        }

        /// <summary>
        /// [wx.getInferenceEnvInfo(Object object)](https://developers.weixin.qq.com/minigame/dev/api/ai/inference/wx.getInferenceEnvInfo.html)
        /// 需要基础库： `2.30.1`
        /// 获取通用AI推理引擎版本。使用前可参考[AI指南文档](https://developers.weixin.qq.com/miniprogram/dev/framework/open-ability/inference/tutorial.html)
        /// **示例代码**
        /// ```js
        /// // 获取通用AI推理引擎版本
        /// wx.getInferenceEnvInfo({
        /// complete: (res) => {
        /// console.log(res.ver)
        /// console.log(res.errMsg)
        /// },
        /// })
        /// ```
        /// </summary>
        public static void GetInferenceEnvInfo(GetInferenceEnvInfoOption callback)
        {
            WXSDKManagerHandler.Instance.GetInferenceEnvInfo(callback);
        }

        /// <summary>
        /// [wx.getLocalIPAddress(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/network/wx.getLocalIPAddress.html)
        /// 需要基础库： `2.20.1`
        /// 获取局域网IP地址
        /// **示例代码**
        /// ```js
        /// wx.getLocalIPAddress({
        /// success (res) {
        /// const localip = res.localip
        /// }
        /// })
        /// ```
        /// </summary>
        public static void GetLocalIPAddress(GetLocalIPAddressOption callback)
        {
            WXSDKManagerHandler.Instance.GetLocalIPAddress(callback);
        }

        /// <summary>
        /// [wx.getNetworkType(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/network/wx.getNetworkType.html)
        /// 获取网络类型
        /// **示例代码**
        /// ```js
        /// wx.getNetworkType({
        /// success (res) {
        /// const networkType = res.networkType
        /// }
        /// })
        /// ```
        /// </summary>
        public static void GetNetworkType(GetNetworkTypeOption callback)
        {
            WXSDKManagerHandler.Instance.GetNetworkType(callback);
        }

        /// <summary>
        /// [wx.getPrivacySetting(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/privacy/wx.getPrivacySetting.html)
        /// 需要基础库： `2.32.3`
        /// 查询隐私授权情况。隐私合规开发指南详情可见[《小游戏隐私合规开发指南》](https://developers.weixin.qq.com/community/develop/doc/000aa25cf1c8a0e64310ac3ef66401?highLine=%25E9%259A%2590%25E7%25A7%2581)
        /// ****
        /// ## 具体说明：
        /// 1. 一定要调用 wx.getPrivacySetting 接口吗？
        /// - 不是，wx.getPrivacySetting 只是一个辅助接口，可以根据实际情况选择使用。
        /// **示例代码**
        /// ```js
        /// wx.getPrivacySetting({
        /// success: res => {
        /// console.log(res)
        /// // 返回结果为: res = { needAuthorization: true/false, privacyContractName: '《xxx隐私保护指引》' }
        /// },
        /// fail: () => {},
        /// complete: () => {}
        /// })
        /// ```
        /// </summary>
        public static void GetPrivacySetting(GetPrivacySettingOption callback)
        {
            WXSDKManagerHandler.Instance.GetPrivacySetting(callback);
        }

        /// <summary>
        /// [wx.getScreenBrightness(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/screen/wx.getScreenBrightness.html)
        /// 需要基础库： `1.2.0`
        /// 获取屏幕亮度
        /// **说明**
        /// - 若安卓系统设置中开启了自动调节亮度功能，则屏幕亮度会根据光线自动调整，该接口仅能获取自动调节亮度之前的值，而非实时的亮度值。
        /// </summary>
        public static void GetScreenBrightness(GetScreenBrightnessOption callback)
        {
            WXSDKManagerHandler.Instance.GetScreenBrightness(callback);
        }

        /// <summary>
        /// [wx.getScreenRecordingState(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/screen/wx.getScreenRecordingState.html)
        /// 需要基础库： `3.1.4`
        /// 查询用户是否在录屏。
        /// **示例代码**
        /// ```js
        /// wx.getScreenRecordingState({
        ///  success: function (res) {
        ///    console.log(res.state)
        ///  },
        /// })
        /// </summary>
        public static void GetScreenRecordingState(GetScreenRecordingStateOption callback)
        {
            WXSDKManagerHandler.Instance.GetScreenRecordingState(callback);
        }

        /// <summary>
        /// [wx.getSetting(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/setting/wx.getSetting.html)
        /// 需要基础库： `1.2.0`
        /// 获取用户的当前设置。**返回值中只会出现小程序已经向用户请求过的[权限](https://developers.weixin.qq.com/minigame/dev/guide/base-ability/authorize.html)**。
        /// **示例代码**
        /// ```js
        /// wx.getSetting({
        /// success (res) {
        /// console.log(res.authSetting)
        /// // res.authSetting = {
        /// //   "scope.userInfo": true,
        /// //   "scope.userLocation": true
        /// // }
        /// }
        /// })
        /// ```
        /// ```js
        /// wx.getSetting({
        /// withSubscriptions: true,
        /// success (res) {
        /// console.log(res.authSetting)
        /// // res.authSetting = {
        /// //   "scope.userInfo": true,
        /// //   "scope.userLocation": true
        /// // }
        /// console.log(res.subscriptionsSetting)
        /// // res.subscriptionsSetting = {
        /// //   mainSwitch: true, // 订阅消息总开关
        /// //   itemSettings: {   // 每一项开关
        /// //     SYS_MSG_TYPE_INTERACTIVE: 'accept', // 小游戏系统订阅消息
        /// //     SYS_MSG_TYPE_RANK: 'accept'
        /// //     zun-LzcQyW-edafCVvzPkK4de2Rllr1fFpw2A_x0oXE: 'reject', // 普通一次性订阅消息
        /// //     ke_OZC_66gZxALLcsuI7ilCJSP2OJ2vWo2ooUPpkWrw: 'ban',
        /// //   }
        /// // }
        /// }
        /// })
        /// ```
        /// </summary>
        public static void GetSetting(GetSettingOption callback)
        {
            WXSDKManagerHandler.Instance.GetSetting(callback);
        }

        /// <summary>
        /// [wx.getShareInfo(Object object)](https://developers.weixin.qq.com/minigame/dev/api/share/wx.getShareInfo.html)
        /// 需要基础库： `1.1.0`
        /// 获取转发详细信息（主要是获取群ID）。 从群聊内的小程序消息卡片打开小程序时，调用此接口才有效。从基础库 v2.17.3 开始，推荐用 [wx.getGroupEnterInfo](https://developers.weixin.qq.com/minigame/dev/api/open-api/group/wx.getGroupEnterInfo.html) 替代此接口。
        /// **示例代码**
        /// 敏感数据获取方式 [加密数据解密算法](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/signature.html#加密数据解密算法) 。
        /// 获取得到的开放数据为以下 json 结构（其中 openGId 为当前群的唯一标识）：
        /// ```json
        /// {
        /// "openGId": "OPENGID"
        /// }
        /// ```
        /// **Tips**
        /// - 如需要展示群名称，小程序可以使用 [开放数据组件](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/open-data.html)
        /// - 小游戏可以通过 [`wx.getGroupInfo`](https://developers.weixin.qq.com/minigame/dev/api/open-api/data/wx.getGroupInfo.html) 接口获取群名称
        /// </summary>
        public static void GetShareInfo(GetShareInfoOption callback)
        {
            WXSDKManagerHandler.Instance.GetShareInfo(callback);
        }

        /// <summary>
        /// [wx.getStorageInfo(Object object)](https://developers.weixin.qq.com/minigame/dev/api/storage/wx.getStorageInfo.html)
        /// 异步获取当前storage的相关信息。
        /// **示例代码**
        /// ```js
        /// wx.getStorageInfo({
        /// success (res) {
        /// console.log(res.keys)
        /// console.log(res.currentSize)
        /// console.log(res.limitSize)
        /// }
        /// })
        /// ```
        /// ```js
        /// try {
        /// const res = wx.getStorageInfoSync()
        /// console.log(res.keys)
        /// console.log(res.currentSize)
        /// console.log(res.limitSize)
        /// } catch (e) {
        /// // Do something when catch error
        /// }
        /// ```
        /// </summary>
        public static void GetStorageInfo(GetStorageInfoOption callback)
        {
            WXSDKManagerHandler.Instance.GetStorageInfo(callback);
        }

        /// <summary>
        /// [wx.getSystemInfo(Object object)](https://developers.weixin.qq.com/minigame/dev/api/base/system/wx.getSystemInfo.html)
        /// 获取系统信息。**由于历史原因，wx.getSystemInfo 是异步的调用格式，但是是同步返回，需要异步获取系统信息请使用 [wx.getSystemInfoAsync](https://developers.weixin.qq.com/minigame/dev/api/base/system/wx.getSystemInfoAsync.html)。**
        /// **示例代码**
        /// [在微信开发者工具中查看示例](https://developers.weixin.qq.com/s/WkUCgXmS7mqO)
        /// ```js
        /// wx.getSystemInfo({
        /// success (res) {
        /// console.log(res.model)
        /// console.log(res.pixelRatio)
        /// console.log(res.windowWidth)
        /// console.log(res.windowHeight)
        /// console.log(res.language)
        /// console.log(res.version)
        /// console.log(res.platform)
        /// }
        /// })
        /// ```
        /// ```js
        /// try {
        /// const res = wx.getSystemInfoSync()
        /// console.log(res.model)
        /// console.log(res.pixelRatio)
        /// console.log(res.windowWidth)
        /// console.log(res.windowHeight)
        /// console.log(res.language)
        /// console.log(res.version)
        /// console.log(res.platform)
        /// } catch (e) {
        /// // Do something when catch error
        /// }
        /// ```
        /// </summary>
        public static void GetSystemInfo(GetSystemInfoOption callback)
        {
            WXSDKManagerHandler.Instance.GetSystemInfo(callback);
        }

        /// <summary>
        /// [wx.getSystemInfoAsync(Object object)](https://developers.weixin.qq.com/minigame/dev/api/base/system/wx.getSystemInfoAsync.html)
        /// 需要基础库： `2.25.3`
        /// 异步获取系统信息。需要一定的微信客户端版本支持，在不支持的客户端上，会使用同步实现来返回。
        /// **示例代码**
        /// [在微信开发者工具中查看示例](https://developers.weixin.qq.com/s/WkUCgXmS7mqO)
        /// ```js
        /// wx.getSystemInfoAsync({
        /// success (res) {
        /// console.log(res.model)
        /// console.log(res.pixelRatio)
        /// console.log(res.windowWidth)
        /// console.log(res.windowHeight)
        /// console.log(res.language)
        /// console.log(res.version)
        /// console.log(res.platform)
        /// }
        /// })
        /// ```
        /// </summary>
        public static void GetSystemInfoAsync(GetSystemInfoAsyncOption callback)
        {
            WXSDKManagerHandler.Instance.GetSystemInfoAsync(callback);
        }

        /// <summary>
        /// [wx.getUserInfo(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/user-info/wx.getUserInfo.html)
        /// 获取用户信息。详情参考 [用户信息获取](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/user-info.html)
        /// **示例代码**
        /// ```js
        /// // 必须是在用户已经授权的情况下调用
        /// wx.getUserInfo({
        /// success: function(res) {
        /// var userInfo = res.userInfo
        /// var nickName = userInfo.nickName
        /// var avatarUrl = userInfo.avatarUrl
        /// var gender = userInfo.gender //性别 0：未知、1：男、2：女
        /// var province = userInfo.province
        /// var city = userInfo.city
        /// var country = userInfo.country
        /// }
        /// })
        /// ```
        /// 敏感数据有两种获取方式：
        /// 1. 使用 [加密数据解密算法](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/signature.html#加密数据解密算法)
        /// 2. 使用 [云调用直接获取开放数据](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/signature.html#云调用直接获取开放数据)
        /// 获取得到的开放数据为以下 json 结构：
        /// ```json
        /// {
        /// "openId": "OPENID",
        /// "nickName": "NICKNAME",
        /// "gender": GENDER,
        /// "city": "CITY",
        /// "province": "PROVINCE",
        /// "country": "COUNTRY",
        /// "avatarUrl": "AVATARURL",
        /// "unionId": "UNIONID",
        /// "watermark": {
        /// "appid":"APPID",
        /// "timestamp":TIMESTAMP
        /// }
        /// }
        /// ```
        /// **最佳用法**
        /// ```js
        /// // 通过 wx.getSetting 查询用户是否已授权头像昵称信息
        /// wx.getSetting({
        /// success (res){
        /// if (res.authSetting['scope.userInfo']) {
        /// // 已经授权，可以直接调用 getUserInfo 获取头像昵称
        /// wx.getUserInfo({
        /// success: function(res) {
        /// console.log(res.userInfo)
        /// }
        /// })
        /// } else {
        /// // 否则，先通过 wx.createUserInfoButton 接口发起授权
        /// let button = wx.createUserInfoButton({
        /// type: 'text',
        /// text: '获取用户信息',
        /// style: {
        /// left: 10,
        /// top: 76,
        /// width: 200,
        /// height: 40,
        /// lineHeight: 40,
        /// backgroundColor: '#ff0000',
        /// color: '#ffffff',
        /// textAlign: 'center',
        /// fontSize: 16,
        /// borderRadius: 4
        /// }
        /// })
        /// button.onTap((res) => {
        /// // 用户同意授权后回调，通过回调可获取用户头像昵称信息
        /// console.log(res)
        /// })
        /// }
        /// }
        /// })
        /// ```
        /// </summary>
        public static void GetUserInfo(GetUserInfoOption callback)
        {
            WXSDKManagerHandler.Instance.GetUserInfo(callback);
        }

        /// <summary>
        /// [wx.getUserInteractiveStorage(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/data/wx.getUserInteractiveStorage.html)
        /// 需要基础库： `2.7.7`
        /// 获取当前用户互动型托管数据对应 key 的数据。该接口需要用户授权。
        /// </summary>
        public static void GetUserInteractiveStorage(GetUserInteractiveStorageOption callback)
        {
            WXSDKManagerHandler.Instance.GetUserInteractiveStorage(callback);
        }

        /// <summary>
        /// [wx.getWeRunData(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/werun/wx.getWeRunData.html)
        /// 需要基础库： `1.2.0`
        /// 获取用户过去三十一天微信运动步数。需要先调用 [wx.login](https://developers.weixin.qq.com/minigame/dev/api/open-api/login/wx.login.html) 接口。步数信息会在用户主动进入小程序时更新。
        /// **示例代码**
        /// ```js
        /// wx.getWeRunData({
        /// success (res) {
        /// // 拿 encryptedData 到开发者后台解密开放数据
        /// const encryptedData = res.encryptedData
        /// // 或拿 cloudID 通过云调用直接获取开放数据
        /// const cloudID = res.cloudID
        /// }
        /// })
        /// ```
        /// **开放数据 JSON 结构**
        /// 敏感数据有两种获取方式，一是使用 [加密数据解密算法](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/signature.html#加密数据解密算法) 。
        /// 获取得到的开放数据为以下 json 结构：
        /// ```json
        /// {
        /// "stepInfoList": [
        /// {
        /// "timestamp": 1445866601,
        /// "step": 100
        /// },
        /// {
        /// "timestamp": 1445876601,
        /// "step": 120
        /// }
        /// ]
        /// }
        /// ```
        /// stepInfoList 中，每一项结构如下：
        /// | 属性 | 类型 | 说明 |
        /// | --- | ---- | --- |
        /// | timestamp | number | 时间戳，表示数据对应的时间 |
        /// | step | number | 微信运动步数 |
        /// </summary>
        public static void GetWeRunData(GetWeRunDataOption callback)
        {
            WXSDKManagerHandler.Instance.GetWeRunData(callback);
        }

        /// <summary>
        /// [wx.hideKeyboard(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/keyboard/wx.hideKeyboard.html)
        /// 隐藏键盘
        /// </summary>
        public static void HideKeyboard(HideKeyboardOption callback)
        {
            WXSDKManagerHandler.Instance.HideKeyboard(callback);
        }

        /// <summary>
        /// [wx.hideLoading(Object object)](https://developers.weixin.qq.com/minigame/dev/api/ui/interaction/wx.hideLoading.html)
        /// 需要基础库： `1.1.0`
        /// 隐藏 loading 提示框
        /// </summary>
        public static void HideLoading(HideLoadingOption callback)
        {
            WXSDKManagerHandler.Instance.HideLoading(callback);
        }

        /// <summary>
        /// [wx.hideShareMenu(Object object)](https://developers.weixin.qq.com/minigame/dev/api/share/wx.hideShareMenu.html)
        /// 需要基础库： `1.1.0`
        /// 隐藏当前页面的转发按钮
        /// ****
        /// ## 注意事项
        /// - "shareAppMessage"表示“发送给朋友”按钮，"shareTimeline"表示“分享到朋友圈”按钮
        /// - 隐藏“发送给朋友”按钮时必须同时隐藏“分享到朋友圈”按钮，隐藏“分享到朋友圈”按钮时则允许不隐藏“发送给朋友”按钮
        /// **示例代码**
        /// ```js
        /// wx.hideShareMenu({
        /// menus: ['shareAppMessage', 'shareTimeline']
        /// })
        /// ```
        /// </summary>
        public static void HideShareMenu(HideShareMenuOption callback)
        {
            WXSDKManagerHandler.Instance.HideShareMenu(callback);
        }

        /// <summary>
        /// [wx.hideToast(Object object)](https://developers.weixin.qq.com/minigame/dev/api/ui/interaction/wx.hideToast.html)
        /// 隐藏消息提示框
        /// </summary>
        public static void HideToast(HideToastOption callback)
        {
            WXSDKManagerHandler.Instance.HideToast(callback);
        }

        /// <summary>
        /// [wx.initFaceDetect(Object object)](https://developers.weixin.qq.com/minigame/dev/api/ai/face/wx.initFaceDetect.html)
        /// 需要基础库： `2.18.0`
        /// </summary>
        public static void InitFaceDetect(InitFaceDetectOption callback)
        {
            WXSDKManagerHandler.Instance.InitFaceDetect(callback);
        }

        /// <summary>
        /// [wx.isBluetoothDevicePaired(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth/wx.isBluetoothDevicePaired.html)
        /// 需要基础库： `2.20.1`
        /// 查询蓝牙设备是否配对，仅安卓支持。
        /// </summary>
        public static void IsBluetoothDevicePaired(IsBluetoothDevicePairedOption callback)
        {
            WXSDKManagerHandler.Instance.IsBluetoothDevicePaired(callback);
        }

        /// <summary>
        /// [wx.joinVoIPChat(Object object)](https://developers.weixin.qq.com/minigame/dev/api/media/voip/wx.joinVoIPChat.html)
        /// 需要基础库： `2.7.0`
        /// 加入 (创建) 实时语音通话，更多信息可见 [实时语音指南](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/voip-chat.html)。调用前需要用户授权 `scope.record`，若房间类型为视频房间需要用户授权 `scope.camera`。
        /// </summary>
        public static void JoinVoIPChat(JoinVoIPChatOption callback)
        {
            WXSDKManagerHandler.Instance.JoinVoIPChat(callback);
        }

        /// <summary>
        /// [wx.login(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/login/wx.login.html)
        /// 调用接口获取登录凭证（code）。通过凭证进而换取用户登录态信息，包括用户在当前小程序的唯一标识（openid）、微信开放平台账号下的唯一标识（unionid，若当前小程序已绑定到微信开放平台账号）及本次登录的会话密钥（session_key）等。用户数据的加解密通讯需要依赖会话密钥完成。
        /// **示例代码**
        /// ```js
        /// wx.login({
        /// success (res) {
        /// if (res.code) {
        /// //发起网络请求
        /// wx.request({
        /// url: 'https://example.com/onLogin',
        /// data: {
        /// code: res.code
        /// }
        /// })
        /// } else {
        /// console.log('登录失败！' + res.errMsg)
        /// }
        /// }
        /// })
        /// ```
        /// </summary>
        public static void Login(LoginOption callback)
        {
            WXSDKManagerHandler.Instance.Login(callback);
        }

        /// <summary>
        /// [wx.makeBluetoothPair(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth/wx.makeBluetoothPair.html)
        /// 需要基础库： `2.12.0`
        /// 蓝牙配对接口，仅安卓支持。
        /// 通常情况下（需要指定 `pin` 码或者密码时）系统会接管配对流程，直接调用 [wx.createBLEConnection](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.createBLEConnection.html) 即可。该接口只应当在开发者不想让用户手动输入 `pin` 码且真机验证确认可以正常生效情况下用。
        /// </summary>
        public static void MakeBluetoothPair(MakeBluetoothPairOption callback)
        {
            WXSDKManagerHandler.Instance.MakeBluetoothPair(callback);
        }

        /// <summary>
        /// [wx.navigateToMiniProgram(Object object)](https://developers.weixin.qq.com/minigame/dev/api/navigate/wx.navigateToMiniProgram.html)
        /// 需要基础库： `2.2.0`
        /// 打开另一个小程序
        /// **使用限制**
        /// ##### 需要用户触发跳转
        /// 从 2.3.0 版本开始，若用户未点击小程序页面任意位置，则开发者将无法调用此接口自动跳转至其他小程序。
        /// ##### 需要用户确认跳转
        /// 从 2.3.0 版本开始，在跳转至其他小程序前，将统一增加弹窗，询问是否跳转，用户确认后才可以跳转其他小程序。如果用户点击取消，则回调 `fail cancel`。
        /// ##### 无需声明跳转名单，不限跳转数量（众测中）
        /// 1. 从2020年4月24日起，使用跳转其他小程序功能将无需在全局配置中声明跳转名单，调用此接口时将不再校验所跳转的 AppID 是否在 navigateToMiniProgramAppIdList 中。
        /// 2. 从2020年4月24日起，跳转其他小程序将不再受数量限制，使用此功能时请注意遵守运营规范。
        /// **运营规范**
        /// 平台将坚决打击小程序盒子等互推行为，使用此功能时请严格遵守[《微信小程序平台运营规范》](https://developers.weixin.qq.com/miniprogram/product/#_5-10-%E4%BA%92%E6%8E%A8%E8%A1%8C%E4%B8%BA)，若发现小程序违反运营规范将被下架处理。
        /// **关于调试**
        /// - 在开发者工具上调用此 API 并不会真实的跳转到另外的小程序，但是开发者工具会校验本次调用跳转是否成功。[详情](https://developers.weixin.qq.com/miniprogram/dev/devtools/different.html#跳转小程序调试支持)
        /// - 开发者工具上支持被跳转的小程序处理接收参数的调试。[详情](https://developers.weixin.qq.com/miniprogram/dev/devtools/different.html#跳转小程序调试支持)
        /// **示例代码**
        /// ```js
        /// wx.navigateToMiniProgram({
        /// appId: '',
        /// path: 'page/index/index?id=123',
        /// extraData: {
        /// foo: 'bar'
        /// },
        /// envVersion: 'develop',
        /// success(res) {
        /// // 打开成功
        /// }
        /// })
        /// ```
        /// </summary>
        public static void NavigateToMiniProgram(NavigateToMiniProgramOption callback)
        {
            WXSDKManagerHandler.Instance.NavigateToMiniProgram(callback);
        }

        /// <summary>
        /// [wx.notifyBLECharacteristicValueChange(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.notifyBLECharacteristicValueChange.html)
        /// 需要基础库： `2.9.2`
        /// 启用蓝牙低功耗设备特征值变化时的 notify 功能，订阅特征。注意：必须设备的特征支持 notify 或者 indicate 才可以成功调用。
        /// 另外，必须先启用 [wx.notifyBLECharacteristicValueChange](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.notifyBLECharacteristicValueChange.html) 才能监听到设备 `characteristicValueChange` 事件
        /// **注意**
        /// - 订阅操作成功后需要设备主动更新特征的 value，才会触发 [wx.onBLECharacteristicValueChange](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.onBLECharacteristicValueChange.html) 回调。
        /// - 安卓平台上，在本接口调用成功后立即调用 [wx.writeBLECharacteristicValue](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.writeBLECharacteristicValue.html) 接口，在部分机型上会发生 10008 系统错误
        /// **示例代码**
        /// [在微信开发者工具中查看示例](https://developers.weixin.qq.com/s/pQU51zmz7a3K)
        /// ```js
        /// wx.notifyBLECharacteristicValueChange({
        /// state: true, // 启用 notify 功能
        /// // 这里的 deviceId 需要已经通过 createBLEConnection 与对应设备建立链接
        /// deviceId,
        /// // 这里的 serviceId 需要在 getBLEDeviceServices 接口中获取
        /// serviceId,
        /// // 这里的 characteristicId 需要在 getBLEDeviceCharacteristics 接口中获取
        /// characteristicId,
        /// success (res) {
        /// console.log('notifyBLECharacteristicValueChange success', res.errMsg)
        /// }
        /// })
        /// ```
        /// </summary>
        public static void NotifyBLECharacteristicValueChange(NotifyBLECharacteristicValueChangeOption callback)
        {
            WXSDKManagerHandler.Instance.NotifyBLECharacteristicValueChange(callback);
        }

        /// <summary>
        /// [wx.openAppAuthorizeSetting(Object object)](https://developers.weixin.qq.com/minigame/dev/api/base/system/wx.openAppAuthorizeSetting.html)
        /// 需要基础库： `2.25.3`
        /// 跳转系统微信授权管理页
        /// **示例代码**
        /// ```js
        /// wx.openAppAuthorizeSetting({
        /// success (res) {
        /// console.log(res)
        /// }
        /// })
        /// ```
        /// </summary>
        public static void OpenAppAuthorizeSetting(OpenAppAuthorizeSettingOption callback)
        {
            WXSDKManagerHandler.Instance.OpenAppAuthorizeSetting(callback);
        }

        /// <summary>
        /// [wx.openBluetoothAdapter(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth/wx.openBluetoothAdapter.html)
        /// 需要基础库： `2.9.2`
        /// 初始化蓝牙模块。iOS 上开启主机/从机（外围设备）模式时需分别调用一次，并指定对应的 `mode`。
        /// **object.fail 回调函数返回的 state 参数（仅 iOS）**
        /// | 状态码 | 说明   |
        /// | ------ | ------ |
        /// | 0      | 未知   |
        /// | 1      | 重置中 |
        /// | 2      | 不支持 |
        /// | 3      | 未授权 |
        /// | 4      | 未开启 |
        /// **注意**
        /// - 其他蓝牙相关 API 必须在 [wx.openBluetoothAdapter](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth/wx.openBluetoothAdapter.html) 调用之后使用。否则 API 会返回错误（errCode=10000）。
        /// - 在用户蓝牙开关未开启或者手机不支持蓝牙功能的情况下，调用 [wx.openBluetoothAdapter](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth/wx.openBluetoothAdapter.html) 会返回错误（errCode=10001），表示手机蓝牙功能不可用。此时小程序蓝牙模块已经初始化完成，可通过 [wx.onBluetoothAdapterStateChange](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth/wx.onBluetoothAdapterStateChange.html) 监听手机蓝牙状态的改变，也可以调用蓝牙模块的所有API。
        /// **示例代码**
        /// [在微信开发者工具中查看示例](https://developers.weixin.qq.com/s/pQU51zmz7a3K)
        /// ```js
        /// wx.openBluetoothAdapter({
        /// success (res) {
        /// console.log(res)
        /// }
        /// })
        /// ```
        /// </summary>
        public static void OpenBluetoothAdapter(OpenBluetoothAdapterOption callback)
        {
            WXSDKManagerHandler.Instance.OpenBluetoothAdapter(callback);
        }

        /// <summary>
        /// [wx.openCard(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/card/wx.openCard.html)
        /// 需要基础库： `2.5.0`
        /// 查看微信卡包中的卡券。只有通过 [认证](https://developers.weixin.qq.com/miniprogram/product/renzheng.html) 的小程序或文化互动类目的小游戏才能使用。更多文档请参考 [微信卡券接口文档](https://mp.weixin.qq.com/cgi-bin/announce?action=getannouncement&key=1490190158&version=1&lang=zh_CN&platform=2)。
        /// **示例代码**
        /// ```js
        /// wx.openCard({
        /// cardList: [{
        /// cardId: '',
        /// code: ''
        /// }, {
        /// cardId: '',
        /// code: ''
        /// }],
        /// success (res) { }
        /// })
        /// ```
        /// </summary>
        public static void OpenCard(OpenCardOption callback)
        {
            WXSDKManagerHandler.Instance.OpenCard(callback);
        }

        /// <summary>
        /// [wx.openChannelsActivity(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/channels/wx.openChannelsActivity.html)
        /// 需要基础库： `2.19.2`
        /// 打开视频号视频
        /// </summary>
        public static void OpenChannelsActivity(OpenChannelsActivityOption callback)
        {
            WXSDKManagerHandler.Instance.OpenChannelsActivity(callback);
        }

        /// <summary>
        /// [wx.openChannelsEvent(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/channels/wx.openChannelsEvent.html)
        /// 需要基础库： `2.21.0`
        /// 打开视频号活动页
        /// </summary>
        public static void OpenChannelsEvent(OpenChannelsEventOption callback)
        {
            WXSDKManagerHandler.Instance.OpenChannelsEvent(callback);
        }

        /// <summary>
        /// [wx.openChannelsLive(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/channels/wx.openChannelsLive.html)
        /// 需要基础库： `2.15.0`
        /// 打开视频号直播
        /// </summary>
        public static void OpenChannelsLive(OpenChannelsLiveOption callback)
        {
            WXSDKManagerHandler.Instance.OpenChannelsLive(callback);
        }

        /// <summary>
        /// [wx.openChannelsUserProfile(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/channels/wx.openChannelsUserProfile.html)
        /// 需要基础库： `2.21.2`
        /// 打开视频号主页
        /// </summary>
        public static void OpenChannelsUserProfile(OpenChannelsUserProfileOption callback)
        {
            WXSDKManagerHandler.Instance.OpenChannelsUserProfile(callback);
        }

        /// <summary>
        /// [wx.openCustomerServiceChat(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/service-chat/wx.openCustomerServiceChat.html)
        /// 需要基础库： `2.30.4`
        /// 打开微信客服，页面产生点击事件（例如 button 上 bindtap 的回调中）后才可调用。了解更多信息，可以参考[微信客服介绍](https://work.weixin.qq.com/kf/)。
        /// **示例代码**
        /// ```js
        /// wx.openCustomerServiceChat({
        /// extInfo: {url: ''},
        /// corpId: '',
        /// success(res) {}
        /// })
        /// ```
        /// </summary>
        public static void OpenCustomerServiceChat(OpenCustomerServiceChatOption callback)
        {
            WXSDKManagerHandler.Instance.OpenCustomerServiceChat(callback);
        }

        /// <summary>
        /// [wx.openCustomerServiceConversation(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/customer-message/wx.openCustomerServiceConversation.html)
        /// 需要基础库： `2.0.3`
        /// 进入客服会话。要求在用户发生过至少一次 touch 事件后才能调用。后台接入方式与小程序一致，详见 [客服消息接入](https://developers.weixin.qq.com/miniprogram/dev/framework/open-ability/customer-message/customer-message.html)
        /// **注意事项**
        /// - 在客服会话内点击小程序消息卡片进入小程序时，不能通过 wx.onShow 或 wx.getEnterOptionsSync 等接口获取启动路径和参数，而是应该通过 wx.openCustomerServiceConversation 接口的 success 回调获取启动路径和参数
        /// </summary>
        public static void OpenCustomerServiceConversation(OpenCustomerServiceConversationOption callback)
        {
            WXSDKManagerHandler.Instance.OpenCustomerServiceConversation(callback);
        }

        /// <summary>
        /// [wx.openPrivacyContract(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/privacy/wx.openPrivacyContract.html)
        /// 需要基础库： `2.32.3`
        /// 跳转至隐私协议页面。隐私合规开发指南详情可见[《小游戏隐私合规开发指南》](https://developers.weixin.qq.com/community/develop/doc/000aa25cf1c8a0e64310ac3ef66401?highLine=%25E9%259A%2590%25E7%25A7%2581)
        /// ****
        /// ## 具体说明：
        /// - 1. 一定要调用 wx.openPrivacyContract 接口吗？
        /// - 不是。开发者也可以选择在小游戏内自行展示完整的隐私协议。但推荐使用该接口。
        /// **示例代码**
        /// ```js
        /// wx.openPrivacyContract({
        /// success: () => {}, // 打开成功
        /// fail: () => {}, // 打开失败
        /// complete: () => {}
        /// })
        /// ```
        /// </summary>
        public static void OpenPrivacyContract(OpenPrivacyContractOption callback)
        {
            WXSDKManagerHandler.Instance.OpenPrivacyContract(callback);
        }

        /// <summary>
        /// [wx.openSetting(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/setting/wx.openSetting.html)
        /// 需要基础库： `1.1.0`
        /// 调起客户端小程序设置界面，返回用户设置的操作结果。**设置界面只会出现小程序已经向用户请求过的[权限](https://developers.weixin.qq.com/minigame/dev/guide/base-ability/authorize.html)**。
        /// ****
        /// - 注意：[2.3.0](https://developers.weixin.qq.com/miniprogram/dev/framework/compatibility.html) 版本开始，用户发生点击行为后，才可以跳转打开设置页，管理授权信息。[详情](https://developers.weixin.qq.com/community/develop/doc/000cea2305cc5047af5733de751008)
        /// **示例代码**
        /// ```js
        /// wx.openSetting({
        /// success (res) {
        /// console.log(res.authSetting)
        /// // res.authSetting = {
        /// //   "scope.userInfo": true,
        /// //   "scope.userLocation": true
        /// // }
        /// }
        /// })
        /// ```
        /// </summary>
        public static void OpenSetting(OpenSettingOption callback)
        {
            WXSDKManagerHandler.Instance.OpenSetting(callback);
        }

        /// <summary>
        /// [wx.openSystemBluetoothSetting(Object object)](https://developers.weixin.qq.com/minigame/dev/api/base/system/wx.openSystemBluetoothSetting.html)
        /// 需要基础库： `2.25.3`
        /// 跳转系统蓝牙设置页。仅支持安卓。
        /// **示例代码**
        /// ```js
        /// wx.openSystemBluetoothSetting({
        /// success (res) {
        /// console.log(res)
        /// }
        /// })
        /// ```
        /// </summary>
        public static void OpenSystemBluetoothSetting(OpenSystemBluetoothSettingOption callback)
        {
            WXSDKManagerHandler.Instance.OpenSystemBluetoothSetting(callback);
        }

        /// <summary>
        /// [wx.previewImage(Object object)](https://developers.weixin.qq.com/minigame/dev/api/media/image/wx.previewImage.html)
        /// 在新页面中全屏预览图片。预览的过程中用户可以进行保存图片、发送给朋友等操作。
        /// **支持长按识别的码**
        /// | 类型 | 说明 | 最低版本 |
        /// |------|------| -------|
        /// | 小程序码 |    |
        /// | 微信个人码 | 不支持小游戏   | [2.18.0](https://developers.weixin.qq.com/miniprogram/dev/framework/compatibility.html) |
        /// | 企业微信个人码 | 不支持小游戏   | [2.18.0](https://developers.weixin.qq.com/miniprogram/dev/framework/compatibility.html) |
        /// | 普通群码 | 指仅包含微信用户的群，不支持小游戏   | [2.18.0](https://developers.weixin.qq.com/miniprogram/dev/framework/compatibility.html) |
        /// | 互通群码 |  指既有微信用户也有企业微信用户的群，不支持小游戏  | [2.18.0](https://developers.weixin.qq.com/miniprogram/dev/framework/compatibility.html) |
        /// | 公众号二维码 | 不支持小游戏  | [2.18.0](https://developers.weixin.qq.com/miniprogram/dev/framework/compatibility.html) |
        /// **示例代码**
        /// ```js
        /// wx.previewImage({
        /// current: '', // 当前显示图片的http链接
        /// urls: [] // 需要预览的图片http链接列表
        /// })
        /// ```
        /// </summary>
        public static void PreviewImage(PreviewImageOption callback)
        {
            WXSDKManagerHandler.Instance.PreviewImage(callback);
        }

        /// <summary>
        /// [wx.previewMedia(Object object)](https://developers.weixin.qq.com/minigame/dev/api/media/image/wx.previewMedia.html)
        /// 需要基础库： `2.12.0`
        /// 预览图片和视频。
        /// **支持长按识别的码**
        /// | 类型 | 说明 | 最低版本 |
        /// |------|------| -------|
        /// | 小程序码 |    |
        /// | 微信个人码 | 不支持小游戏   | [2.18.0](https://developers.weixin.qq.com/miniprogram/dev/framework/compatibility.html) |
        /// | 企业微信个人码 | 不支持小游戏   | [2.18.0](https://developers.weixin.qq.com/miniprogram/dev/framework/compatibility.html) |
        /// | 普通群码 | 指仅包含微信用户的群，不支持小游戏   | [2.18.0](https://developers.weixin.qq.com/miniprogram/dev/framework/compatibility.html) |
        /// | 互通群码 |  指既有微信用户也有企业微信用户的群，不支持小游戏  | [2.18.0](https://developers.weixin.qq.com/miniprogram/dev/framework/compatibility.html) |
        /// | 公众号二维码 | 不支持小游戏  | [2.18.0](https://developers.weixin.qq.com/miniprogram/dev/framework/compatibility.html) |
        /// </summary>
        public static void PreviewMedia(PreviewMediaOption callback)
        {
            WXSDKManagerHandler.Instance.PreviewMedia(callback);
        }

        /// <summary>
        /// [wx.readBLECharacteristicValue(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.readBLECharacteristicValue.html)
        /// 需要基础库： `2.9.2`
        /// 读取蓝牙低功耗设备特征值的二进制数据。注意：必须设备的特征支持 read 才可以成功调用。
        /// **注意**
        /// - 并行调用多次会存在读失败的可能性。
        /// - 接口读取到的信息需要在 [wx.onBLECharacteristicValueChange](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.onBLECharacteristicValueChange.html) 方法注册的回调中获取。
        /// **示例代码**
        /// [在微信开发者工具中查看示例](https://developers.weixin.qq.com/s/pQU51zmz7a3K)
        /// ```js
        /// // 必须在这里的回调才能获取
        /// wx.onBLECharacteristicValueChange(function(characteristic) {
        /// console.log('characteristic value comed:', characteristic)
        /// })
        /// wx.readBLECharacteristicValue({
        /// // 这里的 deviceId 需要已经通过 createBLEConnection 与对应设备建立链接
        /// deviceId,
        /// // 这里的 serviceId 需要在 getBLEDeviceServices 接口中获取
        /// serviceId,
        /// // 这里的 characteristicId 需要在 getBLEDeviceCharacteristics 接口中获取
        /// characteristicId,
        /// success (res) {
        /// console.log('readBLECharacteristicValue:', res.errCode)
        /// }
        /// })
        /// ```
        /// </summary>
        public static void ReadBLECharacteristicValue(ReadBLECharacteristicValueOption callback)
        {
            WXSDKManagerHandler.Instance.ReadBLECharacteristicValue(callback);
        }

        /// <summary>
        /// [wx.removeStorage(Object object)](https://developers.weixin.qq.com/minigame/dev/api/storage/wx.removeStorage.html)
        /// 从本地缓存中移除指定 key。
        /// **示例代码**
        /// ```js
        /// wx.removeStorage({
        /// key: 'key',
        /// success (res) {
        /// console.log(res)
        /// }
        /// })
        /// ```
        /// ```js
        /// try {
        /// wx.removeStorageSync('key')
        /// } catch (e) {
        /// // Do something when catch error
        /// }
        /// ```
        /// </summary>
        public static void RemoveStorage(RemoveStorageOption callback)
        {
            WXSDKManagerHandler.Instance.RemoveStorage(callback);
        }

        /// <summary>
        /// [wx.removeUserCloudStorage(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/data/wx.removeUserCloudStorage.html)
        /// 需要基础库： `1.9.92`
        /// 删除用户托管数据当中对应 key 的数据。
        /// </summary>
        public static void RemoveUserCloudStorage(RemoveUserCloudStorageOption callback)
        {
            WXSDKManagerHandler.Instance.RemoveUserCloudStorage(callback);
        }

        /// <summary>
        /// [wx.reportScene(Object object)](https://developers.weixin.qq.com/minigame/dev/api/data-analysis/wx.reportScene.html)
        /// 需要基础库： `2.26.2`
        /// 用于游戏启动阶段的自定义场景上报。使用前请注意阅读[相关说明](https://developers.weixin.qq.com/minigame/dev/guide/performance/perf-action-start-reportScene.html)。
        /// **示例代码**
        /// ```js
        /// wx.reportScene({
        /// sceneId: 1000,
        /// costTime: 350,
        /// dimension: {
        /// d1: '2.1.0', // value仅支持传入String类型。若value表示Boolean，请将值处理为'0'、'1'进行上报；若value为Number，请转换为String进行上报
        /// },
        /// metric: {
        /// m1: '546', // value仅支持传入数值且需要转换为String类型进行上报
        /// },
        /// success (res) {
        /// // 上报接口执行完成后的回调，用于检查上报数据是否符合预期
        /// console.log(res)
        /// },
        /// fail (res) {
        /// // 上报报错时的回调，用于查看上报错误的原因：如参数类型错误等
        /// console.log(res)
        /// }
        /// })
        /// ```
        /// </summary>
        public static void ReportScene(ReportSceneOption callback)
        {
            WXSDKManagerHandler.Instance.ReportScene(callback);
        }

        /// <summary>
        /// [wx.requestMidasFriendPayment(Object object)](https://developers.weixin.qq.com/minigame/dev/api/midas-payment/wx.requestMidasFriendPayment.html)
        /// 需要基础库： `2.11.0`
        /// </summary>
        public static void RequestMidasFriendPayment(RequestMidasFriendPaymentOption callback)
        {
            WXSDKManagerHandler.Instance.RequestMidasFriendPayment(callback);
        }

        /// <summary>
        /// [wx.requestMidasPayment(Object object)](https://developers.weixin.qq.com/minigame/dev/api/midas-payment/wx.requestMidasPayment.html)
        /// 发起米大师支付
        /// **buyQuantity 限制说明**
        /// 购买游戏币的时候，buyQuantity 不可任意填写。需满足 buyQuantity * 游戏币单价 = 限定的价格等级。如：游戏币单价为 0.1 元，一次购买最少数量是 10。
        /// 有效价格等级如下：
        /// | 价格等级（单位：人民币） |
        /// |----------------------|
        /// | 1 |
        /// | 3 |
        /// | 6 |
        /// | 8 |
        /// | 12 |
        /// | 18 |
        /// | 25 |
        /// | 30 |
        /// | 40 |
        /// | 45 |
        /// | 50 |
        /// | 60 |
        /// | 68 |
        /// | 73 |
        /// | 78 |
        /// | 88 |
        /// | 98 |
        /// | 108 |
        /// | 118 |
        /// | 128 |
        /// | 148 |
        /// | 168 |
        /// | 188 |
        /// | 198 |
        /// | 328 |
        /// | 648 |
        /// | 998 |
        /// | 1998 |
        /// | 2998 |
        /// </summary>
        public static void RequestMidasPayment(RequestMidasPaymentOption callback)
        {
            WXSDKManagerHandler.Instance.RequestMidasPayment(callback);
        }

        /// <summary>
        /// [wx.requestSubscribeMessage(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/subscribe-message/wx.requestSubscribeMessage.html)
        /// 需要基础库： `2.4.4`
        /// 调起客户端小游戏订阅消息界面，返回用户订阅消息的操作结果。当用户勾选了订阅面板中的“总是保持以上选择，不再询问”时，模板消息会被添加到用户的小游戏设置页，通过 [wx.getSetting](https://developers.weixin.qq.com/minigame/dev/api/open-api/setting/wx.getSetting.html) 接口可获取用户对相关模板消息的订阅状态。
        /// ## 注意事项
        /// - 一次性模板 id 和永久模板 id 不可同时使用。
        /// - 低版本基础库2.4.4~2.8.3 已支持订阅消息接口调用，仅支持传入一个一次性 tmplId / 永久 tmplId。
        /// - [2.8.2](https://developers.weixin.qq.com/miniprogram/dev/framework/compatibility.html) 版本开始，用户发生点击行为或者发起支付回调后，才可以调起订阅消息界面。
        /// - [2.10.0](https://developers.weixin.qq.com/miniprogram/dev/framework/compatibility.html) 版本开始，开发版和体验版小游戏将禁止使用模板消息 fomrId。
        /// - 使用前建议阅读 [小游戏订阅消息使用指引](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/subscribe-message.html)。
        /// - 一次授权调用里，每个tmplId对应的模板标题不能存在相同的，若出现相同的，只保留一个。
        /// **错误码**
        /// | errCode | errMsg                                                 | 说明                                                           |
        /// | ------- | ------------------------------------------------------ | -------------------------------------------------------------- |
        /// | 10001   | TmplIds can't be empty                                 | 参数传空了                                                     |
        /// | 10002   | Request list fail                                       | 网络问题，请求消息列表失败                                     |
        /// | 10003   | Request subscribe fail                                 | 网络问题，订阅请求发送失败                                     |
        /// | 10004   | Invalid template id                                    | 参数类型错误                                                   |
        /// | 10005   | Cannot show subscribe message UI                       | 无法展示 UI，一般是小游戏这个时候退后台了导致的                |
        /// | 20001   | No template data return, verify the template id exist  | 没有模板数据，一般是模板 ID 不存在 或者和模板类型不对应 导致的 |
        /// | 20002   | Templates type must be same                            | 模板消息类型 既有一次性的又有永久的                            |
        /// | 20003   | Templates count out of max bounds                      | 模板消息数量超过上限                                           |
        /// | 20004   | The main switch is switched off                        | 用户关闭了主开关，无法进行订阅                                 |
        /// | 20005   | This mini program was banned from subscribing messages | 小游戏被禁封                                                   |
        /// **示例代码**
        /// ```js
        /// wx.requestSubscribeMessage({
        /// tmplIds: [''],
        /// success (res) {
        /// console.log(res)
        /// res === {
        /// errMsg: "requestSubscribeMessage:ok",
        /// "zun-LzcQyW-edafCVvzPkK4de2Rllr1fFpw2A_x0oXE": "accept"
        /// }
        /// }
        /// })
        /// ```
        /// </summary>
        public static void RequestSubscribeMessage(RequestSubscribeMessageOption callback)
        {
            WXSDKManagerHandler.Instance.RequestSubscribeMessage(callback);
        }

        /// <summary>
        /// [wx.requestSubscribeSystemMessage(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/subscribe-message/wx.requestSubscribeSystemMessage.html)
        /// 需要基础库： `2.9.4`
        /// 调起小游戏系统订阅消息界面，返回用户订阅消息的操作结果。当用户勾选了订阅面板中的“总是保持以上选择，不再询问”时，模板消息会被添加到用户的小游戏设置页，通过 [wx.getSetting](https://developers.weixin.qq.com/minigame/dev/api/open-api/setting/wx.getSetting.html) 接口可获取用户对相关模板消息的订阅状态。
        /// ## 注意事项
        /// - 需要在 touchend 事件的回调中调用。
        /// - 使用前建议阅读 [小游戏系统订阅消息使用指引](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/subscribe-system-message.html)。
        /// - 系统订阅消息只需要订阅一次，永久有效。
        /// **错误码**
        /// | errCode | errMsg                                                 | 说明                                                           |
        /// | ------- | ------------------------------------------------------ | -------------------------------------------------------------- |
        /// | 10001   | TmplIds can't be empty                                 | 参数传空了                                                     |
        /// | 10002   | Request list fail                                       | 网络问题，请求消息列表失败                                     |
        /// | 10003   | Request subscribe fail                                 | 网络问题，订阅请求发送失败                                     |
        /// | 10004   | Invalid template id                                    | 参数类型错误                                                   |
        /// | 10005   | Cannot show subscribe message UI                       | 无法展示 UI，一般是小游戏这个时候退后台了导致的                |
        /// | 20004   | The main switch is switched off                        | 用户关闭了主开关，无法进行订阅                                 |
        /// | 20005   | This mini program was banned from subscribing messages | 小游戏被禁封                                                   |
        /// **示例代码**
        /// ```js
        /// wx.requestSubscribeSystemMessage({
        /// msgTypeList: ['SYS_MSG_TYPE_INTERACTIVE', 'SYS_MSG_TYPE_RANK'],
        /// success (res) {
        /// console.log(res)
        /// // res === {
        /// //   errMsg: "requestSubscribeSystemMessage:ok",
        /// //   SYS_MSG_TYPE_INTERACTIVE: "accept",
        /// //   SYS_MSG_TYPE_RANK: 'reject'
        /// // }
        /// }
        /// })
        /// ```
        /// </summary>
        public static void RequestSubscribeSystemMessage(RequestSubscribeSystemMessageOption callback)
        {
            WXSDKManagerHandler.Instance.RequestSubscribeSystemMessage(callback);
        }

        /// <summary>
        /// [wx.requirePrivacyAuthorize(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/privacy/wx.requirePrivacyAuthorize.html)
        /// 需要基础库： `2.32.3`
        /// 模拟隐私接口调用，并触发隐私弹窗逻辑。隐私合规开发指南详情可见[《小游戏隐私合规开发指南》](https://developers.weixin.qq.com/community/develop/doc/000aa25cf1c8a0e64310ac3ef66401?highLine=%25E9%259A%2590%25E7%25A7%2581)
        /// ****
        /// ## 具体说明：
        /// 1. 调用 wx.requirePrivacyAuthorize() 时：
        /// - 1. 如果用户之前已经同意过隐私授权，会立即返回success回调，不会触发 wx.onNeedPrivacyAuthorization 事件。
        /// - 2. 如果用户之前没有授权过，并且开发者注册了 [wx.onNeedPrivacyAuthorization()](https://developers.weixin.qq.com/minigame/dev/api/open-api/privacy/wx.onNeedPrivacyAuthorization.html) 事件监听，就会立即触发 wx.onNeedPrivacyAuthorization 事件，然后开发者在 onNeedPrivacyAuthorization 回调中弹出自定义隐私授权弹窗，用户点了同意后开发者调用 wx.onNeedPrivacyAuthorization 的回调接口 resolve({ event: 'agree' })，会触发 requirePrivacyAuthorize 的 success 回调。用户点击拒绝授权后开发者调用 wx.onNeedPrivacyAuthorization 的回调接口 resolve({ event: 'disagree' }) 的话，会触发 requirePrivacyAuthorize 的 fail 回调。
        /// - 3. 如果用户之前没有授权过，并且开发者没有注册 [wx.onNeedPrivacyAuthorization()](https://developers.weixin.qq.com/minigame/dev/api/open-api/privacy/wx.onNeedPrivacyAuthorization.html) 事件监听，就会立即弹出平台提供的统一隐私授权弹窗，用户点了同意之后，会触发 requirePrivacyAuthorize 的 success 回调，用户点了拒绝后会触发 requirePrivacyAuthorize 的 fail 回调。
        /// - 4. 基于上述特性，开发者可以在调用任何真实隐私接口之前调用 wx.requirePrivacyAuthorize 接口来模拟隐私接口调用，并触发隐私弹窗（包括自定义弹窗或平台弹窗）逻辑。
        /// 2. 一定要调用 wx.requirePrivacyAuthorize 接口吗？
        /// - 不是，wx.requirePrivacyAuthorize 只是一个辅助接口，可以根据实际情况选择使用。当开发者希望在调用隐私接口之前就主动弹出隐私弹窗时，就可以使用这个接口。
        /// **示例代码**
        /// ```js
        /// wx.requirePrivacyAuthorize({
        /// success: () => {
        /// // 用户同意授权
        /// // runGame() 继续游戏逻辑
        /// },
        /// fail: () => {}, // 用户拒绝授权
        /// complete: () => {}
        /// })
        /// ```
        /// </summary>
        public static void RequirePrivacyAuthorize(RequirePrivacyAuthorizeOption callback)
        {
            WXSDKManagerHandler.Instance.RequirePrivacyAuthorize(callback);
        }

        /// <summary>
        /// [wx.restartMiniProgram(Object object)](https://developers.weixin.qq.com/minigame/dev/api/navigate/wx.restartMiniProgram.html)
        /// 需要基础库： `2.22.1`
        /// 重启当前小程序
        /// </summary>
        public static void RestartMiniProgram(RestartMiniProgramOption callback)
        {
            WXSDKManagerHandler.Instance.RestartMiniProgram(callback);
        }

        /// <summary>
        /// [wx.saveFileToDisk(Object object)](https://developers.weixin.qq.com/minigame/dev/api/file/wx.saveFileToDisk.html)
        /// 需要基础库： `2.11.0`
        /// 保存文件系统的文件到用户磁盘，仅在 PC 端支持
        /// **示例代码**
        /// ```js
        /// wx.saveFileToDisk({
        /// filePath: `${wx.env.USER_DATA_PATH}/hello.txt`,
        /// success(res) {
        /// console.log(res)
        /// },
        /// fail(res) {
        /// console.error(res)
        /// }
        /// })
        /// ```
        /// </summary>
        public static void SaveFileToDisk(SaveFileToDiskOption callback)
        {
            WXSDKManagerHandler.Instance.SaveFileToDisk(callback);
        }

        /// <summary>
        /// [wx.saveImageToPhotosAlbum(Object object)](https://developers.weixin.qq.com/minigame/dev/api/media/image/wx.saveImageToPhotosAlbum.html)
        /// 需要基础库： `1.2.0`
        /// 保存图片到系统相册。
        /// **示例代码**
        /// ```js
        /// wx.saveImageToPhotosAlbum({
        /// success(res) { }
        /// })
        /// ```
        /// </summary>
        public static void SaveImageToPhotosAlbum(SaveImageToPhotosAlbumOption callback)
        {
            WXSDKManagerHandler.Instance.SaveImageToPhotosAlbum(callback);
        }

        /// <summary>
        /// [wx.scanCode(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/scan/wx.scanCode.html)
        /// 需要基础库： `2.16.1`
        /// 调起客户端扫码界面进行扫码
        /// **示例代码**
        /// ```js
        /// // 允许从相机和相册扫码
        /// wx.scanCode({
        /// success (res) {
        /// console.log(res)
        /// }
        /// })
        /// // 只允许从相机扫码
        /// wx.scanCode({
        /// onlyFromCamera: true,
        /// success (res) {
        /// console.log(res)
        /// }
        /// })
        /// ```
        /// </summary>
        public static void ScanCode(ScanCodeOption callback)
        {
            WXSDKManagerHandler.Instance.ScanCode(callback);
        }

        /// <summary>
        /// [wx.setBLEMTU(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.setBLEMTU.html)
        /// 需要基础库： `2.11.0`
        /// 协商设置蓝牙低功耗的最大传输单元 (Maximum Transmission Unit, MTU)。需在 [wx.createBLEConnection](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.createBLEConnection.html) 调用成功后调用。仅安卓系统 5.1 以上版本有效，iOS 因系统限制不支持。
        /// </summary>
        public static void SetBLEMTU(SetBLEMTUOption callback)
        {
            WXSDKManagerHandler.Instance.SetBLEMTU(callback);
        }

        /// <summary>
        /// [wx.setBackgroundFetchToken(object object)](https://developers.weixin.qq.com/minigame/dev/api/storage/background-fetch/wx.setBackgroundFetchToken.html)
        /// 需要基础库： `3.0.1`
        /// 设置自定义登录态，在周期性拉取数据时带上，便于第三方服务器验证请求合法性
        /// </summary>
        public static void SetBackgroundFetchToken(SetBackgroundFetchTokenOption callback)
        {
            WXSDKManagerHandler.Instance.SetBackgroundFetchToken(callback);
        }

        /// <summary>
        /// [wx.setClipboardData(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/clipboard/wx.setClipboardData.html)
        /// 需要基础库： `1.1.0`
        /// 设置系统剪贴板的内容。调用成功后，会弹出 toast 提示"内容已复制"，持续 1.5s
        /// **示例代码**
        /// ```js
        /// wx.setClipboardData({
        /// data: 'data',
        /// success (res) {
        /// wx.getClipboardData({
        /// success (res) {
        /// console.log(res.data) // data
        /// }
        /// })
        /// }
        /// })
        /// ```
        /// </summary>
        public static void SetClipboardData(SetClipboardDataOption callback)
        {
            WXSDKManagerHandler.Instance.SetClipboardData(callback);
        }

        /// <summary>
        /// [wx.setDeviceOrientation(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/orientation/wx.setDeviceOrientation.html)
        /// 需要基础库： `2.26.0`
        /// 切换横竖屏。接口调用成功后会触发 wx.onDeviceOrientationChange 事件
        /// </summary>
        public static void SetDeviceOrientation(SetDeviceOrientationOption callback)
        {
            WXSDKManagerHandler.Instance.SetDeviceOrientation(callback);
        }

        /// <summary>
        /// [wx.setEnableDebug(Object object)](https://developers.weixin.qq.com/minigame/dev/api/base/debug/wx.setEnableDebug.html)
        /// 需要基础库： `1.4.0`
        /// 设置是否打开调试开关。此开关对正式版也能生效。
        /// **示例代码**
        /// ```javascript
        /// // 打开调试
        /// wx.setEnableDebug({
        /// enableDebug: true
        /// })
        /// // 关闭调试
        /// wx.setEnableDebug({
        /// enableDebug: false
        /// })
        /// ```
        /// **Tips**
        /// - 在正式版打开调试还有一种方法，就是先在开发版或体验版打开调试，再切到正式版就能看到vConsole。
        /// </summary>
        public static void SetEnableDebug(SetEnableDebugOption callback)
        {
            WXSDKManagerHandler.Instance.SetEnableDebug(callback);
        }

        /// <summary>
        /// [wx.setInnerAudioOption(Object object)](https://developers.weixin.qq.com/minigame/dev/api/media/audio/wx.setInnerAudioOption.html)
        /// 需要基础库： `2.3.0`
        /// 设置 [InnerAudioContext](https://developers.weixin.qq.com/minigame/dev/api/media/audio/InnerAudioContext.html) 的播放选项。设置之后对当前小程序全局生效。
        /// ****
        /// ## 注意事项
        /// - 为保证微信整体体验，speakerOn 为 true 时，客户端会忽略 mixWithOthers 参数的内容，强制与其它音频互斥
        /// - 不支持在播放音频的过程中切换为扬声器播放，开发者如需切换可以先暂停当前播放的音频并记录下当前暂停的时间点，然后切换后重新从原来暂停的时间点开始播放音频
        /// - 目前 wx.setInnerAudioOption 接口不兼容 wx.createWebAudioContext 接口，也不兼容 wx.createInnerAudioContext 开启 useWebAudioImplement 的情况，将在后续版本中支持
        /// </summary>
        public static void SetInnerAudioOption(SetInnerAudioOption callback)
        {
            WXSDKManagerHandler.Instance.SetInnerAudioOption(callback);
        }

        /// <summary>
        /// [wx.setKeepScreenOn(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/screen/wx.setKeepScreenOn.html)
        /// 需要基础库： `1.4.0`
        /// 设置是否保持常亮状态。仅在当前小程序生效，离开小程序后设置失效。
        /// **示例代码**
        /// ```js
        /// wx.setKeepScreenOn({
        /// keepScreenOn: true
        /// })
        /// ```
        /// </summary>
        public static void SetKeepScreenOn(SetKeepScreenOnOption callback)
        {
            WXSDKManagerHandler.Instance.SetKeepScreenOn(callback);
        }

        /// <summary>
        /// [wx.setMenuStyle(Object object)](https://developers.weixin.qq.com/minigame/dev/api/ui/menu/wx.setMenuStyle.html)
        /// 动态设置通过右上角按钮拉起的菜单的样式。
        /// </summary>
        public static void SetMenuStyle(SetMenuStyleOption callback)
        {
            WXSDKManagerHandler.Instance.SetMenuStyle(callback);
        }

        /// <summary>
        /// [wx.setScreenBrightness(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/screen/wx.setScreenBrightness.html)
        /// 需要基础库： `1.2.0`
        /// 设置屏幕亮度
        /// </summary>
        public static void SetScreenBrightness(SetScreenBrightnessOption callback)
        {
            WXSDKManagerHandler.Instance.SetScreenBrightness(callback);
        }

        /// <summary>
        /// [wx.setStatusBarStyle(Object object)](https://developers.weixin.qq.com/minigame/dev/api/ui/statusbar/wx.setStatusBarStyle.html)
        /// 当在配置中设置 showStatusBarStyle 时，屏幕顶部会显示状态栏。此接口可以修改状态栏的样式。
        /// </summary>
        public static void SetStatusBarStyle(SetStatusBarStyleOption callback)
        {
            WXSDKManagerHandler.Instance.SetStatusBarStyle(callback);
        }

        /// <summary>
        /// [wx.setUserCloudStorage(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/data/wx.setUserCloudStorage.html)
        /// 需要基础库： `1.9.92`
        /// 对用户托管数据进行写数据操作。允许同时写多组 KV 数据。
        /// **托管数据的限制**
        /// 1. 每个openid所标识的微信用户在每个游戏上托管的数据不能超过128个key-value对。
        /// 2. 上报的key-value列表当中每一项的key+value长度都不能超过1K(1024)字节。
        /// 3. 上报的key-value列表当中每一个key长度都不能超过128字节。
        /// </summary>
        public static void SetUserCloudStorage(SetUserCloudStorageOption callback)
        {
            WXSDKManagerHandler.Instance.SetUserCloudStorage(callback);
        }

        /// <summary>
        /// [wx.setVisualEffectOnCapture(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/screen/wx.setVisualEffectOnCapture.html)
        /// 需要基础库： `3.1.4`
        /// 设置截屏/录屏时屏幕表现，仅支持在 Android 端调用
        /// </summary>
        public static void SetVisualEffectOnCapture(SetVisualEffectOnCaptureOption callback)
        {
            WXSDKManagerHandler.Instance.SetVisualEffectOnCapture(callback);
        }

        /// <summary>
        /// [wx.showActionSheet(Object object)](https://developers.weixin.qq.com/minigame/dev/api/ui/interaction/wx.showActionSheet.html)
        /// 显示操作菜单
        /// **示例代码**
        /// ```js
        /// wx.showActionSheet({
        /// itemList: ['A', 'B', 'C'],
        /// success (res) {
        /// console.log(res.tapIndex)
        /// },
        /// fail (res) {
        /// console.log(res.errMsg)
        /// }
        /// })
        /// ```
        /// **注意**
        /// - Android 6.7.2 以下版本，点击取消或蒙层时，回调 fail, errMsg 为 "fail cancel"；
        /// - Android 6.7.2 及以上版本 和 iOS 点击蒙层不会关闭模态弹窗，所以尽量避免使用「取消」分支中实现业务逻辑
        /// </summary>
        public static void ShowActionSheet(ShowActionSheetOption callback)
        {
            WXSDKManagerHandler.Instance.ShowActionSheet(callback);
        }

        /// <summary>
        /// [wx.showKeyboard(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/keyboard/wx.showKeyboard.html)
        /// 显示键盘
        /// </summary>
        public static void ShowKeyboard(ShowKeyboardOption callback)
        {
            WXSDKManagerHandler.Instance.ShowKeyboard(callback);
        }

        /// <summary>
        /// [wx.showLoading(Object object)](https://developers.weixin.qq.com/minigame/dev/api/ui/interaction/wx.showLoading.html)
        /// 需要基础库： `1.1.0`
        /// 显示 loading 提示框。需主动调用 wx.hideLoading 才能关闭提示框
        /// **示例代码**
        /// ```js
        /// wx.showLoading({
        /// title: '加载中',
        /// })
        /// setTimeout(function () {
        /// wx.hideLoading()
        /// }, 2000)
        /// ```
        /// **注意**
        /// - [wx.showLoading](https://developers.weixin.qq.com/minigame/dev/api/ui/interaction/wx.showLoading.html) 和 [wx.showToast](https://developers.weixin.qq.com/minigame/dev/api/ui/interaction/wx.showToast.html) 同时只能显示一个
        /// - [wx.showLoading](https://developers.weixin.qq.com/minigame/dev/api/ui/interaction/wx.showLoading.html) 应与 [wx.hideLoading](https://developers.weixin.qq.com/minigame/dev/api/ui/interaction/wx.hideLoading.html) 配对使用
        /// </summary>
        public static void ShowLoading(ShowLoadingOption callback)
        {
            WXSDKManagerHandler.Instance.ShowLoading(callback);
        }

        /// <summary>
        /// [wx.showModal(Object object)](https://developers.weixin.qq.com/minigame/dev/api/ui/interaction/wx.showModal.html)
        /// 显示模态对话框
        /// **示例代码**
        /// ```js
        /// wx.showModal({
        /// title: '提示',
        /// content: '这是一个模态弹窗',
        /// success (res) {
        /// if (res.confirm) {
        /// console.log('用户点击确定')
        /// } else if (res.cancel) {
        /// console.log('用户点击取消')
        /// }
        /// }
        /// })
        /// ```
        /// **注意**
        /// - Android 6.7.2 以下版本，点击取消或蒙层时，回调 fail, errMsg 为 "fail cancel"；
        /// - Android 6.7.2 及以上版本 和 iOS 点击蒙层不会关闭模态弹窗，所以尽量避免使用「取消」分支中实现业务逻辑
        /// - 自基础库 2.17.1 版本起，支持传入 editable 参数，显示带输入框的弹窗
        /// </summary>
        public static void ShowModal(ShowModalOption callback)
        {
            WXSDKManagerHandler.Instance.ShowModal(callback);
        }

        /// <summary>
        /// [wx.showShareImageMenu(Object object)](https://developers.weixin.qq.com/minigame/dev/api/share/wx.showShareImageMenu.html)
        /// 需要基础库： `2.14.3`
        /// 打开分享图片弹窗，可以将图片发送给朋友、收藏或下载
        /// </summary>
        public static void ShowShareImageMenu(ShowShareImageMenuOption callback)
        {
            WXSDKManagerHandler.Instance.ShowShareImageMenu(callback);
        }

        /// <summary>
        /// [wx.showShareMenu(Object object)](https://developers.weixin.qq.com/minigame/dev/api/share/wx.showShareMenu.html)
        /// 需要基础库： `1.1.0`
        /// 显示当前页面的转发按钮
        /// ****
        /// ## 注意事项
        /// - "shareAppMessage"表示“发送给朋友”按钮，"shareTimeline"表示“分享到朋友圈”按钮
        /// - 显示“分享到朋友圈”按钮时必须同时显示“发送给朋友”按钮，显示“发送给朋友”按钮时则允许不显示“分享到朋友圈”按钮
        /// **示例代码**
        /// ```js
        /// wx.showShareMenu({
        /// withShareTicket: true,
        /// menus: ['shareAppMessage', 'shareTimeline']
        /// })
        /// ```
        /// </summary>
        public static void ShowShareMenu(ShowShareMenuOption callback)
        {
            WXSDKManagerHandler.Instance.ShowShareMenu(callback);
        }

        /// <summary>
        /// [wx.showToast(Object object)](https://developers.weixin.qq.com/minigame/dev/api/ui/interaction/wx.showToast.html)
        /// 显示消息提示框
        /// **示例代码**
        /// ```js
        /// wx.showToast({
        /// title: '成功',
        /// icon: 'success',
        /// duration: 2000
        /// })
        /// ```
        /// **注意**
        /// - [wx.showLoading](https://developers.weixin.qq.com/minigame/dev/api/ui/interaction/wx.showLoading.html) 和 [wx.showToast](https://developers.weixin.qq.com/minigame/dev/api/ui/interaction/wx.showToast.html) 同时只能显示一个
        /// - [wx.showToast](https://developers.weixin.qq.com/minigame/dev/api/ui/interaction/wx.showToast.html) 应与 [wx.hideToast](https://developers.weixin.qq.com/minigame/dev/api/ui/interaction/wx.hideToast.html) 配对使用
        /// </summary>
        public static void ShowToast(ShowToastOption callback)
        {
            WXSDKManagerHandler.Instance.ShowToast(callback);
        }

        /// <summary>
        /// [wx.startAccelerometer(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/accelerometer/wx.startAccelerometer.html)
        /// 需要基础库： `1.1.0`
        /// 开始监听加速度数据。
        /// **示例代码**
        /// ```js
        /// wx.startAccelerometer({
        /// interval: 'game'
        /// })
        /// ```
        /// **注意**
        /// - 根据机型性能、当前 CPU 与内存的占用情况，`interval` 的设置与实际 `wx.onAccelerometerChange()` 回调函数的执行频率会有一些出入。
        /// </summary>
        public static void StartAccelerometer(StartAccelerometerOption callback)
        {
            WXSDKManagerHandler.Instance.StartAccelerometer(callback);
        }

        /// <summary>
        /// [wx.startBeaconDiscovery(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/ibeacon/wx.startBeaconDiscovery.html)
        /// 需要基础库： `2.9.2`
        /// 开始搜索附近的 Beacon 设备
        /// **示例代码**
        /// ```js
        /// wx.startBeaconDiscovery({
        /// success(res) { }
        /// })
        /// ```
        /// </summary>
        public static void StartBeaconDiscovery(StartBeaconDiscoveryOption callback)
        {
            WXSDKManagerHandler.Instance.StartBeaconDiscovery(callback);
        }

        /// <summary>
        /// [wx.startBluetoothDevicesDiscovery(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth/wx.startBluetoothDevicesDiscovery.html)
        /// 需要基础库： `2.9.2`
        /// 开始搜寻附近的蓝牙外围设备。
        /// **此操作比较耗费系统资源，请在搜索到需要的设备后及时调用 [wx.stopBluetoothDevicesDiscovery](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth/wx.stopBluetoothDevicesDiscovery.html) 停止搜索。**
        /// **注意**
        /// - 考虑到蓝牙功能可以间接进行定位，安卓 6.0 及以上版本，无定位权限或定位开关未打开时，无法进行设备搜索。这种情况下，安卓 8.0.16 前，接口调用成功但无法扫描设备；8.0.16 及以上版本，会返回错误。
        /// **示例代码**
        /// [在微信开发者工具中查看示例](https://developers.weixin.qq.com/s/m7klFDmZ72i1)
        /// ```js
        /// // 以微信硬件平台的蓝牙智能灯为例，主服务的 UUID 是 FEE7。传入这个参数，只搜索主服务 UUID 为 FEE7 的设备
        /// wx.startBluetoothDevicesDiscovery({
        /// services: ['FEE7'],
        /// success (res) {
        /// console.log(res)
        /// }
        /// })
        /// ```
        /// </summary>
        public static void StartBluetoothDevicesDiscovery(StartBluetoothDevicesDiscoveryOption callback)
        {
            WXSDKManagerHandler.Instance.StartBluetoothDevicesDiscovery(callback);
        }

        /// <summary>
        /// [wx.startCompass(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/compass/wx.startCompass.html)
        /// 需要基础库： `1.1.0`
        /// 开始监听罗盘数据
        /// **示例代码**
        /// ```js
        /// wx.startCompass()
        /// ```
        /// </summary>
        public static void StartCompass(StartCompassOption callback)
        {
            WXSDKManagerHandler.Instance.StartCompass(callback);
        }

        /// <summary>
        /// [wx.startDeviceMotionListening(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/motion/wx.startDeviceMotionListening.html)
        /// 需要基础库： `2.3.0`
        /// 开始监听设备方向的变化。
        /// </summary>
        public static void StartDeviceMotionListening(StartDeviceMotionListeningOption callback)
        {
            WXSDKManagerHandler.Instance.StartDeviceMotionListening(callback);
        }

        /// <summary>
        /// [wx.stopAccelerometer(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/accelerometer/wx.stopAccelerometer.html)
        /// 需要基础库： `1.1.0`
        /// 停止监听加速度数据。
        /// **示例代码**
        /// ```js
        /// wx.stopAccelerometer()
        /// ```
        /// </summary>
        public static void StopAccelerometer(StopAccelerometerOption callback)
        {
            WXSDKManagerHandler.Instance.StopAccelerometer(callback);
        }

        /// <summary>
        /// [wx.stopBeaconDiscovery(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/ibeacon/wx.stopBeaconDiscovery.html)
        /// 需要基础库： `2.9.2`
        /// 停止搜索附近的 Beacon 设备
        /// </summary>
        public static void StopBeaconDiscovery(StopBeaconDiscoveryOption callback)
        {
            WXSDKManagerHandler.Instance.StopBeaconDiscovery(callback);
        }

        /// <summary>
        /// [wx.stopBluetoothDevicesDiscovery(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth/wx.stopBluetoothDevicesDiscovery.html)
        /// 需要基础库： `2.9.2`
        /// 停止搜寻附近的蓝牙外围设备。若已经找到需要的蓝牙设备并不需要继续搜索时，建议调用该接口停止蓝牙搜索。
        /// **示例代码**
        /// [在微信开发者工具中查看示例](https://developers.weixin.qq.com/s/pQU51zmz7a3K)
        /// ```js
        /// wx.stopBluetoothDevicesDiscovery({
        /// success (res) {
        /// console.log(res)
        /// }
        /// })
        /// ```
        /// </summary>
        public static void StopBluetoothDevicesDiscovery(StopBluetoothDevicesDiscoveryOption callback)
        {
            WXSDKManagerHandler.Instance.StopBluetoothDevicesDiscovery(callback);
        }

        /// <summary>
        /// [wx.stopCompass(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/compass/wx.stopCompass.html)
        /// 需要基础库： `1.1.0`
        /// 停止监听罗盘数据
        /// **示例代码**
        /// ```js
        /// wx.stopCompass()
        /// ```
        /// </summary>
        public static void StopCompass(StopCompassOption callback)
        {
            WXSDKManagerHandler.Instance.StopCompass(callback);
        }

        /// <summary>
        /// [wx.stopDeviceMotionListening(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/motion/wx.stopDeviceMotionListening.html)
        /// 需要基础库： `2.3.0`
        /// 停止监听设备方向的变化。
        /// </summary>
        public static void StopDeviceMotionListening(StopDeviceMotionListeningOption callback)
        {
            WXSDKManagerHandler.Instance.StopDeviceMotionListening(callback);
        }

        /// <summary>
        /// [wx.stopFaceDetect(Object object)](https://developers.weixin.qq.com/minigame/dev/api/ai/face/wx.stopFaceDetect.html)
        /// 需要基础库： `2.18.0`
        /// </summary>
        public static void StopFaceDetect(StopFaceDetectOption callback)
        {
            WXSDKManagerHandler.Instance.StopFaceDetect(callback);
        }

        /// <summary>
        /// [wx.updateKeyboard(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/keyboard/wx.updateKeyboard.html)
        /// 需要基础库： `2.1.0`
        /// 更新键盘输入框内容。只有当键盘处于拉起状态时才会产生效果
        /// </summary>
        public static void UpdateKeyboard(UpdateKeyboardOption callback)
        {
            WXSDKManagerHandler.Instance.UpdateKeyboard(callback);
        }

        /// <summary>
        /// [wx.updateShareMenu(Object object)](https://developers.weixin.qq.com/minigame/dev/api/share/wx.updateShareMenu.html)
        /// 需要基础库： `1.2.0`
        /// 更新转发属性
        /// ****
        /// ## 注意事项
        /// - bug：在iOS上，如果 withShareTicket 传了 true ，同时 isUpdatableMessage 传了 false，会导致 withShareTicket 失效。解决办法：当 withShareTicket 传了 true 的时候，isUpdatableMessage 传 true 或者不传都可以，但不要传 false。如果需要关掉动态消息设置，则另外单独调用一次 wx.updateShareMenu({ isUpdatableMessage: false }) 即可。
        /// **示例代码**
        /// ```js
        /// wx.updateShareMenu({
        /// withShareTicket: true,
        /// success () { }
        /// })
        /// ```
        /// ```js
        /// // 转发私密消息
        /// wx.updateShareMenu({
        /// isPrivateMessage: true,
        /// activityId: 'xxx',
        /// templateInfo: {},
        /// success () { },
        /// fail () {}
        /// })
        /// ```
        /// </summary>
        public static void UpdateShareMenu(UpdateShareMenuOption callback)
        {
            WXSDKManagerHandler.Instance.UpdateShareMenu(callback);
        }

        /// <summary>
        /// [wx.updateVoIPChatMuteConfig(Object object)](https://developers.weixin.qq.com/minigame/dev/api/media/voip/wx.updateVoIPChatMuteConfig.html)
        /// 需要基础库： `2.7.0`
        /// 更新实时语音静音设置
        /// </summary>
        public static void UpdateVoIPChatMuteConfig(UpdateVoIPChatMuteConfigOption callback)
        {
            WXSDKManagerHandler.Instance.UpdateVoIPChatMuteConfig(callback);
        }

        /// <summary>
        /// [wx.updateWeChatApp(Object object)](https://developers.weixin.qq.com/minigame/dev/api/base/update/wx.updateWeChatApp.html)
        /// 需要基础库： `2.12.0`
        /// 更新客户端版本。当判断用户小程序所在客户端版本过低时，可使用该接口跳转到更新微信页面。
        /// </summary>
        public static void UpdateWeChatApp(UpdateWeChatAppOption callback)
        {
            WXSDKManagerHandler.Instance.UpdateWeChatApp(callback);
        }

        /// <summary>
        /// [wx.vibrateLong(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/vibrate/wx.vibrateLong.html)
        /// 需要基础库： `1.2.0`
        /// 使手机发生较长时间的振动（400 ms)
        /// </summary>
        public static void VibrateLong(VibrateLongOption callback)
        {
            WXSDKManagerHandler.Instance.VibrateLong(callback);
        }

        /// <summary>
        /// [wx.vibrateShort(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/vibrate/wx.vibrateShort.html)
        /// 需要基础库： `1.2.0`
        /// 使手机发生较短时间的振动（15 ms）。仅在 iPhone `7 / 7 Plus` 以上及 Android 机型生效
        /// </summary>
        public static void VibrateShort(VibrateShortOption callback)
        {
            WXSDKManagerHandler.Instance.VibrateShort(callback);
        }

        /// <summary>
        /// [wx.writeBLECharacteristicValue(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.writeBLECharacteristicValue.html)
        /// 需要基础库： `2.9.2`
        /// 向蓝牙低功耗设备特征值中写入二进制数据。注意：必须设备的特征支持 write 才可以成功调用。
        /// **注意**
        /// - 并行调用多次会存在写失败的可能性。
        /// - 小程序不会对写入数据包大小做限制，但系统与蓝牙设备会限制蓝牙 4.0 单次传输的数据大小，超过最大字节数后会发生写入错误，建议每次写入不超过 20 字节。
        /// - 若单次写入数据过长，iOS 上存在系统不会有任何回调的情况（包括错误回调）。
        /// - 安卓平台上，在调用 [wx.notifyBLECharacteristicValueChange](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.notifyBLECharacteristicValueChange.html) 成功后立即调用本接口，在部分机型上会发生 10008 系统错误
        /// **示例代码**
        /// [在微信开发者工具中查看示例](https://developers.weixin.qq.com/s/pQU51zmz7a3K)
        /// ```js
        /// // 向蓝牙设备发送一个0x00的16进制数据
        /// let buffer = new ArrayBuffer(1)
        /// let dataView = new DataView(buffer)
        /// dataView.setUint8(0, 0)
        /// wx.writeBLECharacteristicValue({
        /// // 这里的 deviceId 需要在 getBluetoothDevices 或 onBluetoothDeviceFound 接口中获取
        /// deviceId,
        /// // 这里的 serviceId 需要在 getBLEDeviceServices 接口中获取
        /// serviceId,
        /// // 这里的 characteristicId 需要在 getBLEDeviceCharacteristics 接口中获取
        /// characteristicId,
        /// // 这里的value是ArrayBuffer类型
        /// value: buffer,
        /// success (res) {
        /// console.log('writeBLECharacteristicValue success', res.errMsg)
        /// }
        /// })
        /// ```
        /// </summary>
        public static void WriteBLECharacteristicValue(WriteBLECharacteristicValueOption callback)
        {
            WXSDKManagerHandler.Instance.WriteBLECharacteristicValue(callback);
        }

        /// <summary>
        /// 小游戏内主动发起直播，开发者可在游戏内设置一键开播入口
        /// wx.startGameLive 接口需要用户产生点击行为后才能调用,要在WX.OnTouchEnd事件中调用
        /// 需要基础库： `2.19.0`
        /// </summary>
        public static void StartGameLive(StartGameLiveOption callback)
        {
            WXSDKManagerHandler.Instance.StartGameLive(callback);
        }

        /// <summary>
        /// 检查用户是否有直播权限以及用户设备是否支持直播
        /// 需要基础库： `2.19.0`
        /// </summary>
        public static void CheckGameLiveEnabled(CheckGameLiveEnabledOption callback)
        {
            WXSDKManagerHandler.Instance.CheckGameLiveEnabled(callback);
        }

        /// <summary>
        /// 获取小游戏用户当前正在直播的信息（可查询当前直播的 feedId）
        /// </summary>
        public static void GetUserCurrentGameliveInfo(GetUserCurrentGameliveInfoOption callback)
        {
            WXSDKManagerHandler.Instance.GetUserCurrentGameliveInfo(callback);
        }

        /// <summary>
        /// 获取小游戏用户最近已结束的直播的信息（可查询最近已结束的直播的 feedId）
        /// </summary>
        public static void GetUserRecentGameLiveInfo(GetUserRecentGameLiveInfoOption callback)
        {
            WXSDKManagerHandler.Instance.GetUserRecentGameLiveInfo(callback);
        }

        /// <summary>
        /// 获取小游戏用户的已结束的直播数据
        /// 错误码：-10000400：参数无效；-10115001：存在未结束的直播
        /// encryptedData 解密后得到的数据结构：
        /// {
        ///  watermark: {
        ///      timestamp,
        ///      appid
        ///  },
        ///  liveInfoList: [{
        ///      feedId,                    // 直播id
        ///      description,               // 直播主题
        ///      startTime,                 // 开播时间戳
        ///      endTime,                   // 关播时间戳
        ///      totalCheerCount,           // 主播收到的喝彩总数
        ///      totalAudienceCount,        // 直播间总观众人数
        ///      liveDurationInSeconds      // 直播总时长
        ///  }]
        ///  }
        /// </summary>
        public static void GetUserGameLiveDetails(GetUserGameLiveDetailsOption callback)
        {
            WXSDKManagerHandler.Instance.GetUserGameLiveDetails(callback);
        }

        /// <summary>
        /// 支持打开当前游戏的直播专区
        /// 接口需要用户产生点击行为后才能调用,要在WX.OnTouchEnd事件中调用
        /// </summary>
        public static void OpenChannelsLiveCollection(OpenChannelsLiveCollectionOption callback)
        {
            WXSDKManagerHandler.Instance.OpenChannelsLiveCollection(callback);
        }

        /// <summary>
        /// 打开游戏内容页面，从 2.25.1 基础库开始支持
        /// | 参数 | 类型 | 说明 |
        /// | openlink | string | 用于打开指定游戏内容页面的开放链接 |
        /// </summary>
        public static void OpenPage(OpenPageOption callback)
        {
            WXSDKManagerHandler.Instance.OpenPage(callback);
        }

        /// <summary>
        /// [wx.requestMidasPaymentGameItem(Object object)]
        /// 发起米大师支付
        /// </summary>
        public static void RequestMidasPaymentGameItem(RequestMidasPaymentGameItemOption callback)
        {
            WXSDKManagerHandler.Instance.RequestMidasPaymentGameItem(callback);
        }

        public static void RequestSubscribeLiveActivity(RequestSubscribeLiveActivityOption callback)
        {
            WXSDKManagerHandler.Instance.RequestSubscribeLiveActivity(callback);
        }

        /// <summary>
        /// 打开业务页面
        /// 从基础库 v3.1.0 开始支持
        /// </summary>
        public static void OpenBusinessView(OpenBusinessViewOption callback)
        {
            WXSDKManagerHandler.Instance.OpenBusinessView(callback);
        }

        /// <summary>
        /// [wx.exitPointerLock()](https://developers.weixin.qq.com/minigame/dev/api/render/cursor/wx.exitPointerLock.html)
        /// 需要基础库： `3.2.0`
        /// 解除锁定鼠标指针。此接口仅在 Windows、Mac 端支持。
        /// </summary>
        public static void ExitPointerLock()
        {
            WXSDKManagerHandler.Instance.ExitPointerLock();
        }

        /// <summary>
        /// [wx.operateGameRecorderVideo(Object object)](https://developers.weixin.qq.com/minigame/dev/api/game-recorder/wx.operateGameRecorderVideo.html)
        /// 需要基础库： `2.26.1`
        /// 分享游戏对局回放。安卓微信8.0.28开始支持，iOS微信8.0.30开始支持。
        /// </summary>
        public static void OperateGameRecorderVideo(OperateGameRecorderVideoOption option)
        {
            WXSDKManagerHandler.Instance.OperateGameRecorderVideo(option);
        }

        /// <summary>
        /// [wx.removeStorageSync(string key)](https://developers.weixin.qq.com/minigame/dev/api/storage/wx.removeStorageSync.html)
        /// [wx.removeStorage](https://developers.weixin.qq.com/minigame/dev/api/storage/wx.removeStorage.html) 的同步版本
        /// **示例代码**
        /// ```js
        /// wx.removeStorage({
        /// key: 'key',
        /// success (res) {
        /// console.log(res)
        /// }
        /// })
        /// ```
        /// ```js
        /// try {
        /// wx.removeStorageSync('key')
        /// } catch (e) {
        /// // Do something when catch error
        /// }
        /// ```
        /// </summary>
        public static void RemoveStorageSync(string key)
        {
            WXSDKManagerHandler.Instance.RemoveStorageSync(key);
        }

        /// <summary>
        /// [wx.reportEvent(string eventId, object data)](https://developers.weixin.qq.com/minigame/dev/api/data-analysis/wx.reportEvent.html)
        /// 需要基础库： `2.14.4`
        /// 事件上报
        /// </summary>
        public static void ReportEvent<T>(string eventId, T data)
        {
            WXSDKManagerHandler.Instance.ReportEvent(eventId, data);
        }

        /// <summary>
        /// [wx.reportMonitor(string name, number value)](https://developers.weixin.qq.com/minigame/dev/api/data-analysis/wx.reportMonitor.html)
        /// 需要基础库： `2.1.2`
        /// 自定义业务数据监控上报接口。
        /// **使用说明**
        /// 使用前，需要在「小程序管理后台-运维中心-性能监控-业务数据监控」中新建监控事件，配置监控描述与告警类型。每一个监控事件对应唯一的监控ID，开发者最多可以创建128个监控事件。
        /// **示例代码**
        /// ```js
        /// wx.reportMonitor('1', 1)
        /// ```
        /// </summary>
        public static void ReportMonitor(string name, double value)
        {
            WXSDKManagerHandler.Instance.ReportMonitor(name, value);
        }

        /// <summary>
        /// [wx.reportPerformance(Number id, Number value, String|Array dimensions)](https://developers.weixin.qq.com/minigame/dev/api/base/performance/wx.reportPerformance.html)
        /// 需要基础库： `2.10.0`
        /// 小程序测速上报。使用前，需要在小程序管理后台配置。 详情参见[小程序测速](https://developers.weixin.qq.com/miniprogram/dev/framework/performanceReport/)指南。
        /// **示例代码**
        /// ```js
        /// wx.reportPerformance(1101, 680)
        /// wx.reportPerformance(1101, 680, 'custom')
        /// ```
        /// </summary>
        public static void ReportPerformance(double id, double value, string dimensions)
        {
            WXSDKManagerHandler.Instance.ReportPerformance(id, value, dimensions);
        }

        /// <summary>
        /// [wx.reportUserBehaviorBranchAnalytics(Object object)](https://developers.weixin.qq.com/minigame/dev/api/data-analysis/wx.reportUserBehaviorBranchAnalytics.html)
        /// 需要基础库： `2.12.0`
        /// 用于分支相关的UI组件（一般是按钮）相关事件的上报，事件目前有曝光、点击两种
        /// </summary>
        public static void ReportUserBehaviorBranchAnalytics(ReportUserBehaviorBranchAnalyticsOption option)
        {
            WXSDKManagerHandler.Instance.ReportUserBehaviorBranchAnalytics(option);
        }

        /// <summary>
        /// [wx.requestPointerLock()](https://developers.weixin.qq.com/minigame/dev/api/render/cursor/wx.requestPointerLock.html)
        /// 需要基础库： `3.2.0`
        /// 锁定鼠标指针。锁定指针后，鼠标会被隐藏，可以通过 [wx.touchMove](#) 事件获取鼠标偏移量。 **此接口仅在 Windows、Mac 端支持，且必须在用户进行操作后才可调用。**
        /// **示例代码</title>
        /// ```js
        /// wx.onTouchEnd(() => {
        /// wx.requestPointerLock() // 触发鼠标锁定
        /// })
        /// ```
        /// <title>示例 demo**
        /// 下方打开后点按窗口会鼠标锁定，同时会在 touchMove 时持续在控制台打印偏移量。
        /// [https://developers.weixin.qq.com/s/wGruMHm97tMF](https://developers.weixin.qq.com/s/wGruMHm97tMF)
        /// </summary>
        public static void RequestPointerLock()
        {
            WXSDKManagerHandler.Instance.RequestPointerLock();
        }

        /// <summary>
        /// [wx.reserveChannelsLive(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/channels/wx.reserveChannelsLive.html)
        /// 需要基础库： `2.19.0`
        /// 预约视频号直播
        /// </summary>
        public static void ReserveChannelsLive(ReserveChannelsLiveOption option)
        {
            WXSDKManagerHandler.Instance.ReserveChannelsLive(option);
        }

        /// <summary>
        /// [wx.revokeBufferURL(string url)](https://developers.weixin.qq.com/minigame/dev/api/storage/wx.revokeBufferURL.html)
        /// 需要基础库： `2.14.0`
        /// 根据 URL 销毁存在内存中的数据
        /// </summary>
        public static void RevokeBufferURL(string url)
        {
            WXSDKManagerHandler.Instance.RevokeBufferURL(url);
        }

        /// <summary>
        /// [wx.setPreferredFramesPerSecond(number fps)](https://developers.weixin.qq.com/minigame/dev/api/render/frame/wx.setPreferredFramesPerSecond.html)
        /// 可以修改渲染帧率。默认渲染帧率为 60 帧每秒。修改后，requestAnimationFrame 的回调频率会发生改变。
        /// </summary>
        public static void SetPreferredFramesPerSecond(double fps)
        {
            WXSDKManagerHandler.Instance.SetPreferredFramesPerSecond(fps);
        }

        /// <summary>
        /// [wx.setStorageSync(string key, any data)](https://developers.weixin.qq.com/minigame/dev/api/storage/wx.setStorageSync.html)
        /// 将数据存储在本地缓存中指定的 key 中。会覆盖掉原来该 key 对应的内容。除非用户主动删除或因存储空间原因被系统清理，否则数据都一直可用。单个 key 允许存储的最大数据长度为 1MB，所有数据存储上限为 10MB。
        /// **注意**
        /// storage 应只用来进行数据的持久化存储，不应用于运行时的数据传递或全局状态管理。启动过程中过多的同步读写存储，会显著影响启动耗时。
        /// **示例代码**
        /// ```js
        /// try {
        /// wx.setStorageSync('key', 'value')
        /// } catch (e) { }
        /// ```
        /// </summary>
        public static void SetStorageSync<T>(string key, T data)
        {
            WXSDKManagerHandler.Instance.SetStorageSync(key, data);
        }

        /// <summary>
        /// [wx.shareAppMessage(Object object)](https://developers.weixin.qq.com/minigame/dev/api/share/wx.shareAppMessage.html)
        /// 主动拉起转发，进入选择通讯录界面。
        /// </summary>
        public static void ShareAppMessage(ShareAppMessageOption option)
        {
            WXSDKManagerHandler.Instance.ShareAppMessage(option);
        }

        /// <summary>
        /// [wx.triggerGC()](https://developers.weixin.qq.com/minigame/dev/api/base/performance/wx.triggerGC.html)
        /// 加快触发 JavaScriptCore 垃圾回收（Garbage Collection）。GC 时机是由 JavaScriptCore 来控制的，并不能保证调用后马上触发 GC。
        /// </summary>
        public static void TriggerGC()
        {
            WXSDKManagerHandler.Instance.TriggerGC();
        }

        /// <summary>
        /// [wx.onAccelerometerChange(function listener)](https://developers.weixin.qq.com/minigame/dev/api/device/accelerometer/wx.onAccelerometerChange.html)
        /// 监听加速度数据事件。频率根据 [wx.startAccelerometer()](https://developers.weixin.qq.com/minigame/dev/api/device/accelerometer/wx.startAccelerometer.html) 的 interval 参数, 接口调用后会自动开始监听。
        /// **示例代码**
        /// ```js
        /// wx.onAccelerometerChange(callback)
        /// ```
        /// </summary>
        public static void OnAccelerometerChange(Action<OnAccelerometerChangeListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnAccelerometerChange(result);
        }

        public static void OffAccelerometerChange(Action<OnAccelerometerChangeListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffAccelerometerChange(result);
        }

        /// <summary>
        /// [wx.onAudioInterruptionBegin(function listener)](https://developers.weixin.qq.com/minigame/dev/api/base/app/app-event/wx.onAudioInterruptionBegin.html)
        /// 需要基础库： `1.8.0`
        /// 监听音频因为受到系统占用而被中断开始事件。以下场景会触发此事件：闹钟、电话、FaceTime 通话、微信语音聊天、微信视频聊天、有声广告开始播放、实名认证页面弹出等。此事件触发后，小程序内所有音频会暂停。
        /// </summary>
        public static void OnAudioInterruptionBegin(Action<GeneralCallbackResult> res)
        {
            WXSDKManagerHandler.Instance.OnAudioInterruptionBegin(res);
        }

        public static void OffAudioInterruptionBegin(Action<GeneralCallbackResult> res)
        {
            WXSDKManagerHandler.Instance.OffAudioInterruptionBegin(res);
        }

        /// <summary>
        /// [wx.onAudioInterruptionEnd(function listener)](https://developers.weixin.qq.com/minigame/dev/api/base/app/app-event/wx.onAudioInterruptionEnd.html)
        /// 需要基础库： `1.8.0`
        /// 监听音频中断结束事件。在收到 onAudioInterruptionBegin 事件之后，小程序内所有音频会暂停，收到此事件之后才可再次播放成功
        /// </summary>
        public static void OnAudioInterruptionEnd(Action<GeneralCallbackResult> res)
        {
            WXSDKManagerHandler.Instance.OnAudioInterruptionEnd(res);
        }

        public static void OffAudioInterruptionEnd(Action<GeneralCallbackResult> res)
        {
            WXSDKManagerHandler.Instance.OffAudioInterruptionEnd(res);
        }

        /// <summary>
        /// [wx.onBLEConnectionStateChange(function listener)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.onBLEConnectionStateChange.html)
        /// 需要基础库： `2.9.2`
        /// 监听蓝牙低功耗连接状态改变事件。包括开发者主动连接或断开连接，设备丢失，连接异常断开等等
        /// **示例代码**
        /// [在微信开发者工具中查看示例](https://developers.weixin.qq.com/s/pQU51zmz7a3K)
        /// ```js
        /// wx.onBLEConnectionStateChange(function(res) {
        /// // 该方法回调中可以用于处理连接意外断开等异常情况
        /// console.log(`device ${res.deviceId} state has changed, connected: ${res.connected}`)
        /// })
        /// ```
        /// </summary>
        public static void OnBLEConnectionStateChange(Action<OnBLEConnectionStateChangeListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnBLEConnectionStateChange(result);
        }

        public static void OffBLEConnectionStateChange(Action<OnBLEConnectionStateChangeListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffBLEConnectionStateChange(result);
        }

        /// <summary>
        /// [wx.onBLEMTUChange(function listener)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.onBLEMTUChange.html)
        /// 需要基础库： `2.20.1`
        /// 监听蓝牙低功耗的最大传输单元变化事件（仅安卓触发）。
        /// **示例代码**
        /// [在微信开发者工具中查看示例](https://developers.weixin.qq.com/s/pQU51zmz7a3K)
        /// ```js
        /// wx.onBLEMTUChange(function (res) {
        /// console.log('bluetooth mtu is', res.mtu)
        /// })
        /// ```
        /// </summary>
        public static void OnBLEMTUChange(Action<OnBLEMTUChangeListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnBLEMTUChange(result);
        }

        public static void OffBLEMTUChange(Action<OnBLEMTUChangeListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffBLEMTUChange(result);
        }

        /// <summary>
        /// [wx.onBLEPeripheralConnectionStateChanged(function listener)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-peripheral/wx.onBLEPeripheralConnectionStateChanged.html)
        /// 需要基础库： `2.10.3`
        /// 监听当前外围设备被连接或断开连接事件
        /// </summary>
        public static void OnBLEPeripheralConnectionStateChanged(Action<OnBLEPeripheralConnectionStateChangedListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnBLEPeripheralConnectionStateChanged(result);
        }

        public static void OffBLEPeripheralConnectionStateChanged(Action<OnBLEPeripheralConnectionStateChangedListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffBLEPeripheralConnectionStateChanged(result);
        }

        /// <summary>
        /// [wx.onBackgroundFetchData(function listener)](https://developers.weixin.qq.com/minigame/dev/api/storage/background-fetch/wx.onBackgroundFetchData.html)
        /// 需要基础库： `3.0.1`
        /// 监听收到 backgroundFetch 数据事件。如果监听时请求已经完成，则事件不会触发。建议和 [wx.getBackgroundFetchData](https://developers.weixin.qq.com/minigame/dev/api/storage/background-fetch/wx.getBackgroundFetchData.html) 配合使用
        /// </summary>
        public static void OnBackgroundFetchData(Action<OnBackgroundFetchDataListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnBackgroundFetchData(result);
        }


        /// <summary>
        /// [wx.onBeaconServiceChange(function listener)](https://developers.weixin.qq.com/minigame/dev/api/device/ibeacon/wx.onBeaconServiceChange.html)
        /// 需要基础库： `2.9.2`
        /// 监听 Beacon 服务状态变化事件，仅能注册一个监听
        /// **示例代码**
        /// ```js
        /// wx.onBeaconServiceChange(res => {
        /// console.log(res.available, res.discovering)
        /// })
        /// ```
        /// </summary>
        public static void OnBeaconServiceChange(Action<OnBeaconServiceChangeListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnBeaconServiceChange(result);
        }

        public static void OffBeaconServiceChange(Action<OnBeaconServiceChangeListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffBeaconServiceChange(result);
        }

        /// <summary>
        /// [wx.onBeaconUpdate(function listener)](https://developers.weixin.qq.com/minigame/dev/api/device/ibeacon/wx.onBeaconUpdate.html)
        /// 需要基础库： `2.9.2`
        /// 监听 Beacon 设备更新事件，仅能注册一个监听
        /// **示例代码**
        /// ```js
        /// wx.onBeaconUpdate(res => {
        /// console.log(res.beacons)
        /// })
        /// ```
        /// </summary>
        public static void OnBeaconUpdate(Action<OnBeaconUpdateListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnBeaconUpdate(result);
        }

        public static void OffBeaconUpdate(Action<OnBeaconUpdateListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffBeaconUpdate(result);
        }

        /// <summary>
        /// [wx.onBluetoothAdapterStateChange(function listener)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth/wx.onBluetoothAdapterStateChange.html)
        /// 需要基础库： `2.9.2`
        /// 监听蓝牙适配器状态变化事件
        /// **示例代码**
        /// [在微信开发者工具中查看示例](https://developers.weixin.qq.com/s/pQU51zmz7a3K)
        /// ```js
        /// wx.onBluetoothAdapterStateChange(function (res) {
        /// console.log('adapterState changed, now is', res)
        /// })
        /// ```
        /// </summary>
        public static void OnBluetoothAdapterStateChange(Action<OnBluetoothAdapterStateChangeListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnBluetoothAdapterStateChange(result);
        }

        public static void OffBluetoothAdapterStateChange(Action<OnBluetoothAdapterStateChangeListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffBluetoothAdapterStateChange(result);
        }

        /// <summary>
        /// [wx.onBluetoothDeviceFound(function listener)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth/wx.onBluetoothDeviceFound.html)
        /// 需要基础库： `2.9.2`
        /// 监听搜索到新设备的事件
        /// **注意**
        /// - 若在 [wx.onBluetoothDeviceFound](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth/wx.onBluetoothDeviceFound.html) 回调了某个设备，则此设备会添加到 [wx.getBluetoothDevices](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth/wx.getBluetoothDevices.html) 接口获取到的数组中。
        /// **示例代码**
        /// [在微信开发者工具中查看示例](https://developers.weixin.qq.com/s/pQU51zmz7a3K)
        /// ```js
        /// // ArrayBuffer转16进度字符串示例
        /// function ab2hex(buffer) {
        /// var hexArr = Array.prototype.map.call(
        /// new Uint8Array(buffer),
        /// function(bit) {
        /// return ('00' + bit.toString(16)).slice(-2)
        /// }
        /// )
        /// return hexArr.join('');
        /// }
        /// wx.onBluetoothDeviceFound(function(res) {
        /// var devices = res.devices;
        /// console.log('new device list has founded')
        /// console.dir(devices)
        /// console.log(ab2hex(devices[0].advertisData))
        /// })
        /// ```
        /// **注意**
        /// - 蓝牙设备在被搜索到时，系统返回的 `name` 字段一般为广播包中的 `LocalName` 字段中的设备名称，而如果与蓝牙设备建立连接，系统返回的 `name` 字段会改为从蓝牙设备上获取到的 `GattName`。若需要动态改变设备名称并展示，建议使用 `localName` 字段。
        /// - 安卓下部分机型需要有位置权限才能搜索到设备，需留意是否开启了位置权限
        /// </summary>
        public static void OnBluetoothDeviceFound(Action<OnBluetoothDeviceFoundListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnBluetoothDeviceFound(result);
        }

        public static void OffBluetoothDeviceFound(Action<OnBluetoothDeviceFoundListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffBluetoothDeviceFound(result);
        }

        /// <summary>
        /// [wx.onCompassChange(function listener)](https://developers.weixin.qq.com/minigame/dev/api/device/compass/wx.onCompassChange.html)
        /// 监听罗盘数据变化事件。频率：5 次/秒，接口调用后会自动开始监听，可使用 wx.stopCompass 停止监听。
        /// **accuracy 在 iOS/Android 的差异**
        /// 由于平台差异，accuracy 在 iOS/Android 的值不同。
        /// - iOS：accuracy 是一个 number 类型的值，表示相对于磁北极的偏差。0 表示设备指向磁北，90 表示指向东，180 表示指向南，依此类推。
        /// - Android：accuracy 是一个 string 类型的枚举值。
        /// | 值              | 说明                                                                                   |
        /// | --------------- | -------------------------------------------------------------------------------------- |
        /// | high            | 高精度                                                                                 |
        /// | medium          | 中等精度                                                                               |
        /// | low             | 低精度                                                                                 |
        /// | no-contact      | 不可信，传感器失去连接                                                                 |
        /// | unreliable      | 不可信，原因未知                                                                       |
        /// | unknow ${value} | 未知的精度枚举值，即该 Android 系统此时返回的表示精度的 value 不是一个标准的精度枚举值 |
        /// </summary>
        public static void OnCompassChange(Action<OnCompassChangeListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnCompassChange(result);
        }

        public static void OffCompassChange(Action<OnCompassChangeListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffCompassChange(result);
        }

        /// <summary>
        /// [wx.onDeviceMotionChange(function listener)](https://developers.weixin.qq.com/minigame/dev/api/device/motion/wx.onDeviceMotionChange.html)
        /// 需要基础库： `2.3.0`
        /// 监听设备方向变化事件。频率根据 [wx.startDeviceMotionListening()](https://developers.weixin.qq.com/minigame/dev/api/device/motion/wx.startDeviceMotionListening.html) 的 interval 参数。可以使用 [wx.stopDeviceMotionListening()](https://developers.weixin.qq.com/minigame/dev/api/device/motion/wx.stopDeviceMotionListening.html) 停止监听。
        /// </summary>
        public static void OnDeviceMotionChange(Action<OnDeviceMotionChangeListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnDeviceMotionChange(result);
        }

        public static void OffDeviceMotionChange(Action<OnDeviceMotionChangeListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffDeviceMotionChange(result);
        }

        /// <summary>
        /// [wx.onDeviceOrientationChange(function listener)](https://developers.weixin.qq.com/minigame/dev/api/device/orientation/wx.onDeviceOrientationChange.html)
        /// 需要基础库： `2.1.0`
        /// 监听屏幕转向切换事件
        /// ****
        /// ## 注意事项
        /// - 在基础库 v2.26.0 之前，wx.onDeviceOrientationChange 只监听左横屏和右横屏之间切换的事件，且仅在 game.json 中配置 deviceOrientation 的值为 landscape 时生效。
        /// - 从基础库 v2.26.0 开始，wx.onDeviceOrientationChange 会同时监听通过 wx.setDeviceOrientation 接口切换横竖屏的事件。
        /// </summary>
        public static void OnDeviceOrientationChange(Action<OnDeviceOrientationChangeListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnDeviceOrientationChange(result);
        }

        public static void OffDeviceOrientationChange(Action<OnDeviceOrientationChangeListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffDeviceOrientationChange(result);
        }

        /// <summary>
        /// [wx.onError(function listener)](https://developers.weixin.qq.com/minigame/dev/api/base/app/app-event/wx.onError.html)
        /// 监听全局错误事件
        /// </summary>
        public static void OnError(Action<Error> error)
        {
            WXSDKManagerHandler.Instance.OnError(error);
        }

        public static void OffError(Action<Error> error)
        {
            WXSDKManagerHandler.Instance.OffError(error);
        }

        /// <summary>
        /// [wx.onHide(function listener)](https://developers.weixin.qq.com/minigame/dev/api/base/app/life-cycle/wx.onHide.html)
        /// 监听小游戏隐藏到后台事件。锁屏、按 HOME 键退到桌面、显示在聊天顶部等操作会触发此事件。
        /// </summary>
        public static void OnHide(Action<GeneralCallbackResult> res)
        {
            WXSDKManagerHandler.Instance.OnHide(res);
        }

        public static void OffHide(Action<GeneralCallbackResult> res)
        {
            WXSDKManagerHandler.Instance.OffHide(res);
        }

        /// <summary>
        /// [wx.onInteractiveStorageModified(function callback)](https://developers.weixin.qq.com/minigame/dev/api/open-api/data/wx.onInteractiveStorageModified.html)
        /// 需要基础库： `2.9.0`
        /// 监听成功修改好友的互动型托管数据事件，该接口在游戏主域使用
        /// </summary>
        public static void OnInteractiveStorageModified(Action<string> res)
        {
            WXSDKManagerHandler.Instance.OnInteractiveStorageModified(res);
        }

        public static void OffInteractiveStorageModified(Action<string> res)
        {
            WXSDKManagerHandler.Instance.OffInteractiveStorageModified(res);
        }

        /// <summary>
        /// [wx.onKeyDown(function listener)](https://developers.weixin.qq.com/minigame/dev/api/device/keyboard/wx.onKeyDown.html)
        /// 需要基础库： `2.10.1`
        /// 监听键盘按键按下事件，仅适用于 PC 平台
        /// </summary>
        public static void OnKeyDown(Action<OnKeyDownListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnKeyDown(result);
        }

        public static void OffKeyDown(Action<OnKeyDownListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffKeyDown(result);
        }

        /// <summary>
        /// [wx.onKeyUp(function listener)](https://developers.weixin.qq.com/minigame/dev/api/device/keyboard/wx.onKeyUp.html)
        /// 需要基础库： `2.10.1`
        /// 监听键盘按键弹起事件，仅适用于 PC 平台
        /// </summary>
        public static void OnKeyUp(Action<OnKeyDownListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnKeyUp(result);
        }

        public static void OffKeyUp(Action<OnKeyDownListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffKeyUp(result);
        }

        /// <summary>
        /// [wx.onKeyboardComplete(function listener)](https://developers.weixin.qq.com/minigame/dev/api/device/keyboard/wx.onKeyboardComplete.html)
        /// 监听监听键盘收起的事件
        /// </summary>
        public static void OnKeyboardComplete(Action<OnKeyboardInputListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnKeyboardComplete(result);
        }

        public static void OffKeyboardComplete(Action<OnKeyboardInputListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffKeyboardComplete(result);
        }

        /// <summary>
        /// [wx.onKeyboardConfirm(function listener)](https://developers.weixin.qq.com/minigame/dev/api/device/keyboard/wx.onKeyboardConfirm.html)
        /// 监听用户点击键盘 Confirm 按钮时的事件
        /// </summary>
        public static void OnKeyboardConfirm(Action<OnKeyboardInputListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnKeyboardConfirm(result);
        }

        public static void OffKeyboardConfirm(Action<OnKeyboardInputListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffKeyboardConfirm(result);
        }

        /// <summary>
        /// [wx.onKeyboardHeightChange(function listener)](https://developers.weixin.qq.com/minigame/dev/api/device/keyboard/wx.onKeyboardHeightChange.html)
        /// 需要基础库： `2.21.3`
        /// 监听键盘高度变化事件
        /// **示例代码**
        /// ```js
        /// wx.onKeyboardHeightChange(res => {
        /// console.log(res.height)
        /// })
        /// ```
        /// </summary>
        public static void OnKeyboardHeightChange(Action<OnKeyboardHeightChangeListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnKeyboardHeightChange(result);
        }

        public static void OffKeyboardHeightChange(Action<OnKeyboardHeightChangeListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffKeyboardHeightChange(result);
        }

        /// <summary>
        /// [wx.onKeyboardInput(function listener)](https://developers.weixin.qq.com/minigame/dev/api/device/keyboard/wx.onKeyboardInput.html)
        /// 监听键盘输入事件
        /// </summary>
        public static void OnKeyboardInput(Action<OnKeyboardInputListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnKeyboardInput(result);
        }

        public static void OffKeyboardInput(Action<OnKeyboardInputListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffKeyboardInput(result);
        }

        /// <summary>
        /// [wx.onMemoryWarning(function listener)](https://developers.weixin.qq.com/minigame/dev/api/device/memory/wx.onMemoryWarning.html)
        /// 需要基础库： `2.0.2`
        /// 监听内存不足告警事件。
        /// 当 iOS/Android 向小程序进程发出内存警告时，触发该事件。触发该事件不意味小程序被杀，大部分情况下仅仅是告警，开发者可在收到通知后回收一些不必要资源避免进一步加剧内存紧张。
        /// **示例代码**
        /// ```js
        /// wx.onMemoryWarning(function () {
        ///  console.log('onMemoryWarningReceive')
        /// })
        /// ``
        /// </summary>
        public static void OnMemoryWarning(Action<OnMemoryWarningListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnMemoryWarning(result);
        }

        public static void OffMemoryWarning(Action<OnMemoryWarningListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffMemoryWarning(result);
        }

        /// <summary>
        /// [wx.onMessage(function callback)](https://developers.weixin.qq.com/minigame/dev/api/open-api/context/wx.onMessage.html)
        /// 监听主域发送的消息
        /// </summary>
        public static void OnMessage(Action<string> res)
        {
            WXSDKManagerHandler.Instance.OnMessage(res);
        }


        /// <summary>
        /// [wx.onMouseDown(function listener)](https://developers.weixin.qq.com/minigame/dev/api/device/mouse-event/wx.onMouseDown.html)
        /// 监听鼠标按键按下事件
        /// </summary>
        public static void OnMouseDown(Action<OnMouseDownListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnMouseDown(result);
        }

        public static void OffMouseDown(Action<OnMouseDownListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffMouseDown(result);
        }

        /// <summary>
        /// [wx.onMouseMove(function listener)](https://developers.weixin.qq.com/minigame/dev/api/device/mouse-event/wx.onMouseMove.html)
        /// 监听鼠标移动事件
        /// </summary>
        public static void OnMouseMove(Action<OnMouseMoveListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnMouseMove(result);
        }

        public static void OffMouseMove(Action<OnMouseMoveListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffMouseMove(result);
        }

        /// <summary>
        /// [wx.onMouseUp(function listener)](https://developers.weixin.qq.com/minigame/dev/api/device/mouse-event/wx.onMouseUp.html)
        /// 监听鼠标按键弹起事件
        /// </summary>
        public static void OnMouseUp(Action<OnMouseDownListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnMouseUp(result);
        }

        public static void OffMouseUp(Action<OnMouseDownListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffMouseUp(result);
        }

        /// <summary>
        /// [wx.onNetworkStatusChange(function listener)](https://developers.weixin.qq.com/minigame/dev/api/device/network/wx.onNetworkStatusChange.html)
        /// 需要基础库： `1.1.0`
        /// 监听网络状态变化事件
        /// **示例代码**
        /// ```js
        /// wx.onNetworkStatusChange(function (res) {
        /// console.log(res.isConnected)
        /// console.log(res.networkType)
        /// })
        /// ```
        /// </summary>
        public static void OnNetworkStatusChange(Action<OnNetworkStatusChangeListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnNetworkStatusChange(result);
        }

        public static void OffNetworkStatusChange(Action<OnNetworkStatusChangeListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffNetworkStatusChange(result);
        }

        /// <summary>
        /// [wx.onNetworkWeakChange(function listener)](https://developers.weixin.qq.com/minigame/dev/api/device/network/wx.onNetworkWeakChange.html)
        /// 需要基础库： `2.21.0`
        /// 监听弱网状态变化事件
        /// **示例代码**
        /// ```js
        /// wx.onNetworkWeakChange(function (res) {
        /// console.log(res.weakNet)
        /// console.log(res.networkType)
        /// })
        /// // 取消监听
        /// wx.offNetworkWeakChange()
        /// ```
        /// </summary>
        public static void OnNetworkWeakChange(Action<OnNetworkWeakChangeListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnNetworkWeakChange(result);
        }

        public static void OffNetworkWeakChange(Action<OnNetworkWeakChangeListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffNetworkWeakChange(result);
        }

        /// <summary>
        /// [wx.onScreenRecordingStateChanged(function listener)](https://developers.weixin.qq.com/minigame/dev/api/device/screen/wx.onScreenRecordingStateChanged.html)
        /// 需要基础库： `3.1.4`
        /// 监听用户录屏事件。
        /// </summary>
        public static void OnScreenRecordingStateChanged(Action<OnScreenRecordingStateChangedListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnScreenRecordingStateChanged(result);
        }

        public static void OffScreenRecordingStateChanged(Action<OnScreenRecordingStateChangedListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffScreenRecordingStateChanged(result);
        }

        /// <summary>
        /// [wx.onShareMessageToFriend(function listener)](https://developers.weixin.qq.com/minigame/dev/api/share/wx.onShareMessageToFriend.html)
        /// 需要基础库： `2.9.4`
        /// 监听主域接收`wx.shareMessageToFriend`接口的成功失败通知事件
        /// </summary>
        public static void OnShareMessageToFriend(Action<OnShareMessageToFriendListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnShareMessageToFriend(result);
        }


        /// <summary>
        /// [wx.onShow(function listener)](https://developers.weixin.qq.com/minigame/dev/api/base/app/life-cycle/wx.onShow.html)
        /// 监听小游戏回到前台的事件
        /// </summary>
        public static void OnShow(Action<OnShowListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnShow(result);
        }

        public static void OffShow(Action<OnShowListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffShow(result);
        }

        /// <summary>
        /// [wx.onUnhandledRejection(function listener)](https://developers.weixin.qq.com/minigame/dev/api/base/app/app-event/wx.onUnhandledRejection.html)
        /// 需要基础库： `2.10.0`
        /// 监听未处理的 Promise 拒绝事件
        /// **注意**
        /// 安卓平台暂时不会派发该事件
        /// </summary>
        public static void OnUnhandledRejection(Action<OnUnhandledRejectionListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnUnhandledRejection(result);
        }

        public static void OffUnhandledRejection(Action<OnUnhandledRejectionListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffUnhandledRejection(result);
        }

        /// <summary>
        /// [wx.onUserCaptureScreen(function listener)](https://developers.weixin.qq.com/minigame/dev/api/device/screen/wx.onUserCaptureScreen.html)
        /// 需要基础库： `2.8.1`
        /// 监听用户主动截屏事件。用户使用系统截屏按键截屏时触发，只能注册一个监听
        /// **示例代码**
        /// ```js
        /// wx.onUserCaptureScreen(function (res) {
        /// console.log('用户截屏了')
        /// })
        /// ```
        /// </summary>
        public static void OnUserCaptureScreen(Action<GeneralCallbackResult> res)
        {
            WXSDKManagerHandler.Instance.OnUserCaptureScreen(res);
        }

        public static void OffUserCaptureScreen(Action<GeneralCallbackResult> res)
        {
            WXSDKManagerHandler.Instance.OffUserCaptureScreen(res);
        }

        /// <summary>
        /// [wx.onVoIPChatInterrupted(function listener)](https://developers.weixin.qq.com/minigame/dev/api/media/voip/wx.onVoIPChatInterrupted.html)
        /// 需要基础库： `2.7.0`
        /// 监听被动断开实时语音通话事件。包括小游戏切入后端时断开
        /// </summary>
        public static void OnVoIPChatInterrupted(Action<OnVoIPChatInterruptedListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnVoIPChatInterrupted(result);
        }

        public static void OffVoIPChatInterrupted(Action<OnVoIPChatInterruptedListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffVoIPChatInterrupted(result);
        }

        /// <summary>
        /// [wx.onVoIPChatMembersChanged(function listener)](https://developers.weixin.qq.com/minigame/dev/api/media/voip/wx.onVoIPChatMembersChanged.html)
        /// 需要基础库： `2.7.0`
        /// 监听实时语音通话成员在线状态变化事件。有成员加入/退出通话时触发回调
        /// </summary>
        public static void OnVoIPChatMembersChanged(Action<OnVoIPChatMembersChangedListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnVoIPChatMembersChanged(result);
        }

        public static void OffVoIPChatMembersChanged(Action<OnVoIPChatMembersChangedListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffVoIPChatMembersChanged(result);
        }

        /// <summary>
        /// [wx.onVoIPChatSpeakersChanged(function listener)](https://developers.weixin.qq.com/minigame/dev/api/media/voip/wx.onVoIPChatSpeakersChanged.html)
        /// 需要基础库： `2.7.0`
        /// 监听实时语音通话成员通话状态变化事件。有成员开始/停止说话时触发回调
        /// </summary>
        public static void OnVoIPChatSpeakersChanged(Action<OnVoIPChatSpeakersChangedListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnVoIPChatSpeakersChanged(result);
        }

        public static void OffVoIPChatSpeakersChanged(Action<OnVoIPChatSpeakersChangedListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffVoIPChatSpeakersChanged(result);
        }

        /// <summary>
        /// [wx.onVoIPChatStateChanged(function listener)](https://developers.weixin.qq.com/minigame/dev/api/media/voip/wx.onVoIPChatStateChanged.html)
        /// 需要基础库： `2.16.0`
        /// 监听房间状态变化事件。
        /// </summary>
        public static void OnVoIPChatStateChanged(Action<OnVoIPChatStateChangedListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnVoIPChatStateChanged(result);
        }

        public static void OffVoIPChatStateChanged(Action<OnVoIPChatStateChangedListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffVoIPChatStateChanged(result);
        }

        /// <summary>
        /// [wx.onWheel(function listener)](https://developers.weixin.qq.com/minigame/dev/api/device/wheel-event/wx.onWheel.html)
        /// 监听鼠标滚轮事件
        /// </summary>
        public static void OnWheel(Action<OnWheelListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnWheel(result);
        }

        public static void OffWheel(Action<OnWheelListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffWheel(result);
        }

        /// <summary>
        /// [wx.onWindowResize(function listener)](https://developers.weixin.qq.com/minigame/dev/api/ui/window/wx.onWindowResize.html)
        /// 监听窗口尺寸变化事件
        /// </summary>
        public static void OnWindowResize(Action<OnWindowResizeListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OnWindowResize(result);
        }

        public static void OffWindowResize(Action<OnWindowResizeListenerResult> result)
        {
            WXSDKManagerHandler.Instance.OffWindowResize(result);
        }

        /// <summary>
        /// [wx.onAddToFavorites(function listener)](https://developers.weixin.qq.com/minigame/dev/api/share/wx.onAddToFavorites.html)
        /// 需要基础库： `2.10.3`
        /// 监听用户点击菜单「收藏」按钮时触发的事件（安卓7.0.15起支持，iOS 暂不支持）
        /// </summary>
        public static void OnAddToFavorites(Action<Action<OnAddToFavoritesListenerResult>> callback)
        {
            WXSDKManagerHandler.Instance.OnAddToFavorites(callback);
        }

        public static void OffAddToFavorites(Action<Action<OnAddToFavoritesListenerResult>> callback = null)
        {
            WXSDKManagerHandler.Instance.OffAddToFavorites(callback);
        }

        /// <summary>
        /// [wx.onCopyUrl(function listener)](https://developers.weixin.qq.com/minigame/dev/api/share/wx.onCopyUrl.html)
        /// 需要基础库： `2.14.3`
        /// 监听用户点击右上角菜单的「复制链接」按钮时触发的事件。本接口为 Beta 版本，暂只在 Android 平台支持。
        /// </summary>
        public static void OnCopyUrl(Action<Action<OnCopyUrlListenerResult>> callback)
        {
            WXSDKManagerHandler.Instance.OnCopyUrl(callback);
        }

        public static void OffCopyUrl(Action<Action<OnCopyUrlListenerResult>> callback = null)
        {
            WXSDKManagerHandler.Instance.OffCopyUrl(callback);
        }

        /// <summary>
        /// [wx.onHandoff(function listener)](https://developers.weixin.qq.com/minigame/dev/api/share/wx.onHandoff.html)
        /// 需要基础库： `2.14.4`
        /// 监听用户点击菜单「在电脑上打开」按钮时触发的事件
        /// </summary>
        public static void OnHandoff(Action<Action<OnHandoffListenerResult>> callback)
        {
            WXSDKManagerHandler.Instance.OnHandoff(callback);
        }

        public static void OffHandoff(Action<Action<OnHandoffListenerResult>> callback = null)
        {
            WXSDKManagerHandler.Instance.OffHandoff(callback);
        }

        /// <summary>
        /// [wx.onShareTimeline(function listener)](https://developers.weixin.qq.com/minigame/dev/api/share/wx.onShareTimeline.html)
        /// 需要基础库： `2.11.3`
        /// 监听用户点击右上角菜单的「分享到朋友圈」按钮时触发的事件。本接口为 Beta 版本，暂只在 Android 平台支持。
        /// </summary>
        public static void OnShareTimeline(Action<Action<OnShareTimelineListenerResult>> callback)
        {
            WXSDKManagerHandler.Instance.OnShareTimeline(callback);
        }

        public static void OffShareTimeline(Action<Action<OnShareTimelineListenerResult>> callback = null)
        {
            WXSDKManagerHandler.Instance.OffShareTimeline(callback);
        }

        /// <summary>
        /// 监听小游戏直播状态变化事件
        /// 需要基础库： `2.18.1`
        /// </summary>
        public static void OnGameLiveStateChange(Action<OnGameLiveStateChangeCallbackResult, Action<OnGameLiveStateChangeCallbackResponse>> callback)
        {
            WXSDKManagerHandler.Instance.OnGameLiveStateChange(callback);
        }

        public static void OffGameLiveStateChange(Action<OnGameLiveStateChangeCallbackResult, Action<OnGameLiveStateChangeCallbackResponse>> callback = null)
        {
            WXSDKManagerHandler.Instance.OffGameLiveStateChange(callback);
        }

        /// <summary>
        /// [Boolean wx.setHandoffQuery(String query)](https://developers.weixin.qq.com/minigame/dev/api/share/wx.setHandoffQuery.html)
        /// 需要基础库： `2.14.4`
        /// 设置接力参数，该接口需要在游戏域调用
        /// </summary>
        /// <returns></returns>
        public static bool SetHandoffQuery(string query)
        {
            return WXSDKManagerHandler.Instance.SetHandoffQuery(query);
        }

        /// <summary>
        /// [Object wx.getAccountInfoSync()](https://developers.weixin.qq.com/minigame/dev/api/open-api/account-info/wx.getAccountInfoSync.html)
        /// 需要基础库： `2.11.2`
        /// 获取当前账号信息。线上小程序版本号仅支持在正式版小程序中获取，开发版和体验版中无法获取。
        /// **示例代码**
        /// ```js
        /// const accountInfo = wx.getAccountInfoSync();
        /// console.log(accountInfo.miniProgram.appId) // 小程序 appId
        /// console.log(accountInfo.plugin.appId) // 插件 appId
        /// console.log(accountInfo.plugin.version) // 插件版本号， 'a.b.c' 这样的形式
        /// ```
        /// </summary>
        /// <returns></returns>
        public static AccountInfo GetAccountInfoSync()
        {
            return WXSDKManagerHandler.Instance.GetAccountInfoSync();
        }

        /// <summary>
        /// [Object wx.getAppAuthorizeSetting()](https://developers.weixin.qq.com/minigame/dev/api/base/system/wx.getAppAuthorizeSetting.html)
        /// 需要基础库： `2.25.3`
        /// 获取微信APP授权设置
        /// **示例代码**
        /// ```js
        /// const appAuthorizeSetting = wx.getAppAuthorizeSetting()
        /// console.log(appAuthorizeSetting.albumAuthorized)
        /// console.log(appAuthorizeSetting.bluetoothAuthorized)
        /// console.log(appAuthorizeSetting.cameraAuthorized)
        /// console.log(appAuthorizeSetting.locationAuthorized)
        /// console.log(appAuthorizeSetting.locationReducedAccuracy)
        /// console.log(appAuthorizeSetting.microphoneAuthorized)
        /// console.log(appAuthorizeSetting.notificationAlertAuthorized)
        /// console.log(appAuthorizeSetting.notificationAuthorized)
        /// console.log(appAuthorizeSetting.notificationBadgeAuthorized)
        /// console.log(appAuthorizeSetting.notificationSoundAuthorized)
        /// console.log(appAuthorizeSetting.phoneCalendarAuthorized)
        /// ```
        /// **返回值说明**
        /// `'authorized'` 表示已经获得授权，无需再次请求授权；
        /// `'denied'` 表示请求授权被拒绝，无法再次请求授权；（此情况需要引导用户[打开系统设置](https://developers.weixin.qq.com/minigame/dev/api/base/system/wx.openAppAuthorizeSetting.html)，在设置页中打开权限）
        /// `'non determined'` 表示尚未请求授权，会在微信下一次调用系统相应权限时请求；（仅 iOS 会出现。此种情况下引导用户打开系统设置，不展示开关）
        /// </summary>
        /// <returns></returns>
        public static AppAuthorizeSetting GetAppAuthorizeSetting()
        {
            return WXSDKManagerHandler.Instance.GetAppAuthorizeSetting();
        }

        /// <summary>
        /// [Object wx.getAppBaseInfo()](https://developers.weixin.qq.com/minigame/dev/api/base/system/wx.getAppBaseInfo.html)
        /// 需要基础库： `2.25.3`
        /// 获取微信APP基础信息
        /// **示例代码**
        /// ```js
        /// const appBaseInfo = wx.getAppBaseInfo()
        /// console.log(appBaseInfo.SDKVersion)
        /// console.log(appBaseInfo.enableDebug)
        /// console.log(appBaseInfo.host)
        /// console.log(appBaseInfo.language)
        /// console.log(appBaseInfo.version)
        /// console.log(appBaseInfo.theme)
        /// ```
        /// </summary>
        /// <returns></returns>
        public static AppBaseInfo GetAppBaseInfo()
        {
            return WXSDKManagerHandler.Instance.GetAppBaseInfo();
        }

        /// <summary>
        /// [Object wx.getBatteryInfoSync()](https://developers.weixin.qq.com/minigame/dev/api/device/battery/wx.getBatteryInfoSync.html)
        /// [wx.getBatteryInfo](https://developers.weixin.qq.com/minigame/dev/api/device/battery/wx.getBatteryInfo.html) 的同步版本
        /// </summary>
        /// <returns></returns>
        public static GetBatteryInfoSyncResult GetBatteryInfoSync()
        {
            return WXSDKManagerHandler.Instance.GetBatteryInfoSync();
        }

        /// <summary>
        /// [Object wx.getDeviceInfo()](https://developers.weixin.qq.com/minigame/dev/api/base/system/wx.getDeviceInfo.html)
        /// 需要基础库： `2.25.3`
        /// 获取设备基础信息
        /// **示例代码**
        /// ```js
        /// const deviceInfo = wx.getDeviceInfo()
        /// console.log(deviceInfo.abi)
        /// console.log(deviceInfo.benchmarkLevel)
        /// console.log(deviceInfo.brand)
        /// console.log(deviceInfo.model)
        /// console.log(deviceInfo.platform)
        /// console.log(deviceInfo.system)
        /// ```
        /// </summary>
        /// <returns></returns>
        public static DeviceInfo GetDeviceInfo()
        {
            return WXSDKManagerHandler.Instance.GetDeviceInfo();
        }

        /// <summary>
        /// [Object wx.getEnterOptionsSync()](https://developers.weixin.qq.com/minigame/dev/api/base/app/life-cycle/wx.getEnterOptionsSync.html)
        /// 需要基础库： `2.13.2`
        /// 获取小游戏打开的参数（包括冷启动和热启动）
        /// **返回有效 referrerInfo 的场景**
        /// | 场景值 | 场景                            | appId含义  |
        /// | ------ | ------------------------------- | ---------- |
        /// | 1020   | 公众号 profile 页相关小程序列表 | 来源公众号 |
        /// | 1035   | 公众号自定义菜单                | 来源公众号 |
        /// | 1036   | App 分享消息卡片                | 来源App    |
        /// | 1037   | 小程序打开小程序                | 来源小程序 |
        /// | 1038   | 从另一个小程序返回              | 来源小程序 |
        /// | 1043   | 公众号模板消息                  | 来源公众号 |
        /// **不同 apiCategory 场景下的 API 限制**
        /// `X` 表示 API 被限制无法使用；不在表格中的 API 不限制。
        /// |                                       | default | nativeFunctionalized | browseOnly | embedded |
        /// |-|-|-|-|-|
        /// |navigateToMiniProgram                  |         | `X`                  | `X`        |          |
        /// |openSetting                            |         |                      | `X`        |          |
        /// |&lt;button open-type="share"&gt;       |         | `X`                  | `X`        | `X`      |
        /// |&lt;button open-type="feedback"&gt;    |         |                      | `X`        |          |
        /// |&lt;button open-type="open-setting"&gt;|         |                      | `X`        |          |
        /// |openEmbeddedMiniProgram                |         | `X`                  | `X`        | `X`      |
        /// **注意**
        /// 部分版本在无`referrerInfo`的时候会返回 `undefined`，建议使用 `options.referrerInfo && options.referrerInfo.appId` 进行判断。
        /// </summary>
        /// <returns></returns>
        public static EnterOptionsGame GetEnterOptionsSync()
        {
            return WXSDKManagerHandler.Instance.GetEnterOptionsSync();
        }

        /// <summary>
        /// [Object wx.getExptInfoSync(Array.&lt;string&gt; keys)](https://developers.weixin.qq.com/minigame/dev/api/data-analysis/wx.getExptInfoSync.html)
        /// 需要基础库： `2.17.0`
        /// 给定实验参数数组，获取对应的实验参数值
        /// **提示**
        /// 假设实验参数有 `color`, `size`
        /// 调用 wx.getExptInfoSync() 会返回 `{color:'#fff',size:20}` 类似的结果
        /// 而 wx.getExptInfoSync(['color']) 则只会返回 `{color:'#fff'}`
        /// </summary>
        /// <returns></returns>
        public static T GetExptInfoSync<T>(string[] keys)
        {
            return WXSDKManagerHandler.Instance.GetExptInfoSync<T>(keys);
        }

        /// <summary>
        /// [Object wx.getExtConfigSync()](https://developers.weixin.qq.com/minigame/dev/api/ext/wx.getExtConfigSync.html)
        /// 需要基础库： `2.8.3`
        /// [wx.getExtConfig](https://developers.weixin.qq.com/minigame/dev/api/ext/wx.getExtConfig.html) 的同步版本。
        /// **Tips**
        /// 1. 本接口暂时无法通过 [wx.canIUse](#) 判断是否兼容，开发者需要自行判断 [wx.getExtConfigSync](https://developers.weixin.qq.com/minigame/dev/api/ext/wx.getExtConfigSync.html) 是否存在来兼容
        /// ****
        /// ```js
        /// let extConfig = wx.getExtConfigSync? wx.getExtConfigSync(): {}
        /// console.log(extConfig)
        /// ```
        /// </summary>
        /// <returns></returns>
        public static T GetExtConfigSync<T>()
        {
            return WXSDKManagerHandler.Instance.GetExtConfigSync<T>();
        }

        /// <summary>
        /// [Object wx.getLaunchOptionsSync()](https://developers.weixin.qq.com/minigame/dev/api/base/app/life-cycle/wx.getLaunchOptionsSync.html)
        /// 获取小游戏冷启动时的参数。热启动参数通过 [wx.onShow](https://developers.weixin.qq.com/minigame/dev/api/base/app/life-cycle/wx.onShow.html) 或 [wx.getEnterOptionsSync](https://developers.weixin.qq.com/minigame/dev/api/base/app/life-cycle/wx.getEnterOptionsSync.html) 接口获取。
        /// **返回有效 referrerInfo 的场景**
        /// | 场景值 | 场景                            | appId含义  |
        /// | ------ | ------------------------------- | ---------- |
        /// | 1020   | 公众号 profile 页相关小程序列表 | 来源公众号 |
        /// | 1035   | 公众号自定义菜单                | 来源公众号 |
        /// | 1036   | App 分享消息卡片                | 来源App    |
        /// | 1037   | 小程序打开小程序                | 来源小程序 |
        /// | 1038   | 从另一个小程序返回              | 来源小程序 |
        /// | 1043   | 公众号模板消息                  | 来源公众号 |
        /// **注意**
        /// 部分版本在无`referrerInfo`的时候会返回 `undefined`，
        /// 建议使用 `options.referrerInfo && options.referrerInfo.appId` 进行判断。
        /// </summary>
        /// <returns></returns>
        public static LaunchOptionsGame GetLaunchOptionsSync()
        {
            return WXSDKManagerHandler.Instance.GetLaunchOptionsSync();
        }

        /// <summary>
        /// [Object wx.getMenuButtonBoundingClientRect()](https://developers.weixin.qq.com/minigame/dev/api/ui/menu/wx.getMenuButtonBoundingClientRect.html)
        /// 需要基础库： `2.1.0`
        /// 获取菜单按钮（右上角胶囊按钮）的布局位置信息。坐标信息以屏幕左上角为原点。
        /// **示例代码**
        /// ```js
        /// const res = wx.getMenuButtonBoundingClientRect()
        /// console.log(res.width)
        /// console.log(res.height)
        /// console.log(res.top)
        /// console.log(res.right)
        /// console.log(res.bottom)
        /// console.log(res.left)
        /// ```
        /// </summary>
        /// <returns></returns>
        public static ClientRect GetMenuButtonBoundingClientRect()
        {
            return WXSDKManagerHandler.Instance.GetMenuButtonBoundingClientRect();
        }

        /// <summary>
        /// [Object wx.getStorageInfoSync()](https://developers.weixin.qq.com/minigame/dev/api/storage/wx.getStorageInfoSync.html)
        /// [wx.getStorageInfo](https://developers.weixin.qq.com/minigame/dev/api/storage/wx.getStorageInfo.html) 的同步版本
        /// **示例代码**
        /// ```js
        /// wx.getStorageInfo({
        /// success (res) {
        /// console.log(res.keys)
        /// console.log(res.currentSize)
        /// console.log(res.limitSize)
        /// }
        /// })
        /// ```
        /// ```js
        /// try {
        /// const res = wx.getStorageInfoSync()
        /// console.log(res.keys)
        /// console.log(res.currentSize)
        /// console.log(res.limitSize)
        /// } catch (e) {
        /// // Do something when catch error
        /// }
        /// ```
        /// </summary>
        /// <returns></returns>
        public static GetStorageInfoSyncOption GetStorageInfoSync()
        {
            return WXSDKManagerHandler.Instance.GetStorageInfoSync();
        }

        /// <summary>
        /// [Object wx.getSystemInfoSync()](https://developers.weixin.qq.com/minigame/dev/api/base/system/wx.getSystemInfoSync.html)
        /// [wx.getSystemInfo](https://developers.weixin.qq.com/minigame/dev/api/base/system/wx.getSystemInfo.html) 的同步版本
        /// **示例代码**
        /// [在微信开发者工具中查看示例](https://developers.weixin.qq.com/s/WkUCgXmS7mqO)
        /// ```js
        /// wx.getSystemInfo({
        /// success (res) {
        /// console.log(res.model)
        /// console.log(res.pixelRatio)
        /// console.log(res.windowWidth)
        /// console.log(res.windowHeight)
        /// console.log(res.language)
        /// console.log(res.version)
        /// console.log(res.platform)
        /// }
        /// })
        /// ```
        /// ```js
        /// try {
        /// const res = wx.getSystemInfoSync()
        /// console.log(res.model)
        /// console.log(res.pixelRatio)
        /// console.log(res.windowWidth)
        /// console.log(res.windowHeight)
        /// console.log(res.language)
        /// console.log(res.version)
        /// console.log(res.platform)
        /// } catch (e) {
        /// // Do something when catch error
        /// }
        /// ```
        /// </summary>
        /// <returns></returns>
        public static SystemInfo GetSystemInfoSync()
        {
            return WXSDKManagerHandler.Instance.GetSystemInfoSync();
        }

        /// <summary>
        /// [Object wx.getSystemSetting()](https://developers.weixin.qq.com/minigame/dev/api/base/system/wx.getSystemSetting.html)
        /// 需要基础库： `2.25.3`
        /// 获取设备设置
        /// **示例代码**
        /// ```js
        /// const systemSetting = wx.getSystemSetting()
        /// console.log(systemSetting.bluetoothEnabled)
        /// console.log(systemSetting.deviceOrientation)
        /// console.log(systemSetting.locationEnabled)
        /// console.log(systemSetting.wifiEnabled)
        /// ```
        /// </summary>
        /// <returns></returns>
        public static SystemSetting GetSystemSetting()
        {
            return WXSDKManagerHandler.Instance.GetSystemSetting();
        }

        /// <summary>
        /// [Object wx.getWindowInfo()](https://developers.weixin.qq.com/minigame/dev/api/base/system/wx.getWindowInfo.html)
        /// 需要基础库： `2.25.3`
        /// 获取窗口信息
        /// **示例代码**
        /// ```js
        /// const windowInfo = wx.getWindowInfo()
        /// console.log(windowInfo.pixelRatio)
        /// console.log(windowInfo.screenWidth)
        /// console.log(windowInfo.screenHeight)
        /// console.log(windowInfo.windowWidth)
        /// console.log(windowInfo.windowHeight)
        /// console.log(windowInfo.statusBarHeight)
        /// console.log(windowInfo.safeArea)
        /// console.log(windowInfo.screenTop)
        /// ```
        /// </summary>
        /// <returns></returns>
        public static WindowInfo GetWindowInfo()
        {
            return WXSDKManagerHandler.Instance.GetWindowInfo();
        }

        /// <summary>
        /// [[ImageData](https://developers.weixin.qq.com/minigame/dev/api/render/image/ImageData.html) wx.createImageData()](https://developers.weixin.qq.com/minigame/dev/api/render/image/wx.createImageData.html)
        /// 需要基础库： `2.24.6`
        /// 创建一个 ImageData 图片数据对象
        /// </summary>
        /// <returns></returns>
        public static ImageData CreateImageData()
        {
            return WXSDKManagerHandler.Instance.CreateImageData();
        }

        /// <summary>
        /// [[Path2D](https://developers.weixin.qq.com/minigame/dev/api/render/canvas/Path2D.html) wx.createPath2D()](https://developers.weixin.qq.com/minigame/dev/api/render/canvas/wx.createPath2D.html)
        /// 需要基础库： `2.24.6`
        /// 创建一个 Path2D 路径对象
        /// </summary>
        /// <returns></returns>
        public static Path2D CreatePath2D()
        {
            return WXSDKManagerHandler.Instance.CreatePath2D();
        }

        /// <summary>
        /// [boolean wx.isPointerLocked()](https://developers.weixin.qq.com/minigame/dev/api/render/cursor/wx.isPointerLocked.html)
        /// 需要基础库： `3.2.0`
        /// 检查鼠标指针是否被锁定。此接口仅在 Windows、Mac 端支持。
        /// </summary>
        /// <returns></returns>
        public static bool IsPointerLocked()
        {
            return WXSDKManagerHandler.Instance.IsPointerLocked();
        }

        /// <summary>
        /// [boolean wx.isVKSupport(string version)](https://developers.weixin.qq.com/minigame/dev/api/ai/visionkit/wx.isVKSupport.html)
        /// 需要基础库： `2.22.0`
        /// 判断支持版本
        /// **示例代码**
        /// ```js
        /// const isSupportV2 = wx.isVKSupport('v2')
        /// ```
        /// </summary>
        /// <returns></returns>
        public static bool IsVKSupport(string version)
        {
            return WXSDKManagerHandler.Instance.IsVKSupport(version);
        }

        /// <summary>
        /// [boolean wx.setCursor(string path, number x, number y)](https://developers.weixin.qq.com/minigame/dev/api/render/cursor/wx.setCursor.html)
        /// 需要基础库： `2.10.1`
        /// 加载自定义光标，仅支持 PC 平台
        /// **注意**
        /// - 传入图片太大可能会导致设置无效，推荐图标大小 32x32
        /// - 基础库 v2.16.0 后，支持更多图片格式以及关键字种类（参考 CSS 标准）
        /// </summary>
        /// <returns></returns>
        public static bool SetCursor(string path, double x, double y)
        {
            return WXSDKManagerHandler.Instance.SetCursor(path, x, y);
        }

        /// <summary>
        /// [boolean wx.setMessageToFriendQuery(Object object)](https://developers.weixin.qq.com/minigame/dev/api/share/wx.setMessageToFriendQuery.html)
        /// 设置 wx.shareMessageToFriend 接口 query 字段的值
        /// </summary>
        /// <returns></returns>
        public static bool SetMessageToFriendQuery(SetMessageToFriendQueryOption option)
        {
            return WXSDKManagerHandler.Instance.SetMessageToFriendQuery(option);
        }

        /// <summary>
        /// [number wx.getTextLineHeight(Object object)](https://developers.weixin.qq.com/minigame/dev/api/render/font/wx.getTextLineHeight.html)
        /// 获取一行文本的行高
        /// </summary>
        /// <returns></returns>
        public static double GetTextLineHeight(GetTextLineHeightOption option)
        {
            return WXSDKManagerHandler.Instance.GetTextLineHeight(option);
        }

        /// <summary>
        /// [string wx.loadFont(string path)](https://developers.weixin.qq.com/minigame/dev/api/render/font/wx.loadFont.html)
        /// 加载自定义字体文件
        /// </summary>
        /// <returns></returns>
        public static string LoadFont(string path)
        {
            return WXSDKManagerHandler.Instance.LoadFont(path);
        }

        /// <summary>
        /// 查询当前直播状态
        /// </summary>
        /// <returns></returns>
        public static GameLiveState GetGameLiveState()
        {
            return WXSDKManagerHandler.Instance.GetGameLiveState();
        }

        /// <summary>
        /// [[DownloadTask](https://developers.weixin.qq.com/minigame/dev/api/network/download/DownloadTask.html) wx.downloadFile(Object object)](https://developers.weixin.qq.com/minigame/dev/api/network/download/wx.downloadFile.html)
        /// 下载文件资源到本地。客户端直接发起一个 HTTPS GET 请求，返回文件的本地临时路径 (本地路径)，单次下载允许的最大文件为 200MB。使用前请注意阅读[相关说明](https://developers.weixin.qq.com/minigame/dev/guide/base-ability/network.html)。
        /// 注意：请在服务端响应的 header 中指定合理的 `Content-Type` 字段，以保证客户端正确处理文件类型。
        /// **示例代码**
        /// ```js
        /// wx.downloadFile({
        /// url: 'https://example.com/audio/123', //仅为示例，并非真实的资源
        /// success (res) {
        /// // 只要服务器有响应数据，就会把响应内容写入文件并进入 success 回调，业务需要自行判断是否下载到了想要的内容
        /// if (res.statusCode === 200) {
        /// wx.playVoice({
        /// filePath: res.tempFilePath
        /// })
        /// }
        /// }
        /// })
        /// ```
        /// </summary>
        /// <returns></returns>
        public static WXDownloadTask DownloadFile(DownloadFileOption option)
        {
            return WXSDKManagerHandler.Instance.DownloadFile(option);
        }

        /// <summary>
        /// [[FeedbackButton](https://developers.weixin.qq.com/minigame/dev/api/open-api/feedback/FeedbackButton.html) wx.createFeedbackButton(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/feedback/wx.createFeedbackButton.html)
        /// 需要基础库： `2.1.2`
        /// 创建打开意见反馈页面的按钮
        /// </summary>
        /// <returns></returns>
        public static WXFeedbackButton CreateFeedbackButton(CreateOpenSettingButtonOption option)
        {
            return WXSDKManagerHandler.Instance.CreateFeedbackButton(option);
        }

        /// <summary>
        /// [[LogManager](https://developers.weixin.qq.com/minigame/dev/api/base/debug/LogManager.html) wx.getLogManager(Object object)](https://developers.weixin.qq.com/minigame/dev/api/base/debug/wx.getLogManager.html)
        /// 需要基础库： `2.1.0`
        /// 获取日志管理器对象。
        /// **示例代码**
        /// ```js
        /// const logger = wx.getLogManager({level: 1})
        /// logger.log({str: 'hello world'}, 'basic log', 100, [1, 2, 3])
        /// logger.info({str: 'hello world'}, 'info log', 100, [1, 2, 3])
        /// logger.debug({str: 'hello world'}, 'debug log', 100, [1, 2, 3])
        /// logger.warn({str: 'hello world'}, 'warn log', 100, [1, 2, 3])
        /// ```
        /// </summary>
        /// <returns></returns>
        public static WXLogManager GetLogManager(GetLogManagerOption option)
        {
            return WXSDKManagerHandler.Instance.GetLogManager(option);
        }

        /// <summary>
        /// [[RealtimeLogManager](https://developers.weixin.qq.com/minigame/dev/api/base/debug/RealtimeLogManager.html) wx.getRealtimeLogManager()](https://developers.weixin.qq.com/minigame/dev/api/base/debug/wx.getRealtimeLogManager.html)
        /// 需要基础库： `2.14.4`
        /// 获取实时日志管理器对象。
        /// **示例代码**
        /// ```js
        /// // 小程序端
        /// const logger = wx.getRealtimeLogManager()
        /// logger.info({str: 'hello world'}, 'info log', 100, [1, 2, 3])
        /// logger.error({str: 'hello world'}, 'error log', 100, [1, 2, 3])
        /// logger.warn({str: 'hello world'}, 'warn log', 100, [1, 2, 3])
        /// // 插件端，基础库 2.16.0 版本后支持，只允许采用 key-value 的新格式上报
        /// const logManager = wx.getRealtimeLogManager()
        /// const logger = logManager.tag('plugin-log1')
        /// logger.info('key1', 'value1')
        /// logger.error('key2', {str: 'value2'})
        /// logger.warn('key3', 'value3')
        /// ```
        /// </summary>
        /// <returns></returns>
        public static WXRealtimeLogManager GetRealtimeLogManager()
        {
            return WXSDKManagerHandler.Instance.GetRealtimeLogManager();
        }

        /// <summary>
        /// [[UpdateManager](https://developers.weixin.qq.com/minigame/dev/api/base/update/UpdateManager.html) wx.getUpdateManager()](https://developers.weixin.qq.com/minigame/dev/api/base/update/wx.getUpdateManager.html)
        /// 需要基础库： `1.9.90`
        /// 获取**全局唯一**的版本更新管理器，用于管理小程序更新。关于小程序的更新机制，可以查看[运行机制](https://developers.weixin.qq.com/minigame/dev/guide/runtime/operating-mechanism.html)文档。
        /// **示例代码**
        /// [示例代码](https://developers.weixin.qq.com/minigame/dev/api/base/update/UpdateManager.html#示例代码)
        /// </summary>
        /// <returns></returns>
        public static WXUpdateManager GetUpdateManager()
        {
            return WXSDKManagerHandler.Instance.GetUpdateManager();
        }

        /// <summary>
        /// [[VideoDecoder](https://developers.weixin.qq.com/minigame/dev/api/media/video-decoder/VideoDecoder.html) wx.createVideoDecoder()](https://developers.weixin.qq.com/minigame/dev/api/media/video-decoder/wx.createVideoDecoder.html)
        /// 需要基础库： `2.11.1`
        /// 创建视频解码器，可逐帧获取解码后的数据
        /// </summary>
        /// <returns></returns>
        public static WXVideoDecoder CreateVideoDecoder()
        {
            return WXSDKManagerHandler.Instance.CreateVideoDecoder();
        }

    }
}
#endif
