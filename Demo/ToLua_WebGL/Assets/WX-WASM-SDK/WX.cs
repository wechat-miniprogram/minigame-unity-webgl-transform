using UnityEngine;
using System;

namespace WeChatWASM
{
    /// <summary>
    /// 微信SDK对外暴露的API
    /// </summary>
    public class WX:WXBase
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
        /// 提前向用户发起授权请求。调用后会立刻弹窗询问用户是否同意授权小程序使用某项功能或获取用户的某些数据，但不会实际调用对应接口。如果用户之前已经同意授权，则不会出现弹窗，直接返回成功。更多用法详见 [用户授权](https://developers.weixin.qq.com/minigame/dev/guide/framework/authorize.html)。
        /// > 小程序插件可以使用 [wx.authorizeForMiniProgram](#)
        /// **示例代码**
        /// ```js
        /// // 可以通过 wx.getSetting 先查询一下用户是否授权了 "scope.record" 这个 scope
        /// wx.getSetting({
        /// success(res) {
        /// if (!res.authSetting['scope.record']) {
        /// wx.authorize({
        /// scope: 'scope.record',
        /// success () {
        /// // 用户已经同意小程序使用录音功能，后续调用 wx.startRecord 接口不会弹窗询问
        /// wx.startRecord()
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
        /// [wx.checkHandoffEnabled(Object object)](https://developers.weixin.qq.com/minigame/dev/api/share/wx.checkHandoffEnabled.html)
        /// 需要基础库： `2.14.4`
        /// 检查是否可以进行接力，该接口需要在开放数据域调用
        /// </summary>
        public static void CheckHandoffEnabled(CheckHandoffEnabledOption callback)
        {
            WXSDKManagerHandler.Instance.CheckHandoffEnabled(callback);
        }
        /// <summary>
        /// [wx.checkIsUserAdvisedToRest(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/anti-addiction/wx.checkIsUserAdvisedToRest.html)
        /// 需要基础库： `1.9.97`
        /// 根据用户当天游戏时间判断用户是否需要休息
        /// </summary>
        public static void CheckIsUserAdvisedToRest(CheckIsUserAdvisedToRestOption callback)
        {
            WXSDKManagerHandler.Instance.CheckIsUserAdvisedToRest(callback);
        }
        /// <summary>
        /// [wx.checkSession(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/login/wx.checkSession.html)
        /// 检查登录态是否过期。
        /// 通过 wx.login 接口获得的用户登录态拥有一定的时效性。用户越久未使用小程序，用户登录态越有可能失效。反之如果用户一直在使用小程序，则用户登录态一直保持有效。具体时效逻辑由微信维护，对开发者透明。开发者只需要调用 wx.checkSession 接口检测当前用户登录态是否有效。
        /// 登录态过期后开发者可以再调用 wx.login 获取新的用户登录态。调用成功说明当前 session_key 未过期，调用失败说明 session_key 已过期。更多使用方法详见 [小程序登录](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/login.html)。
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
        /// 从本地相册选择图片或使用相机拍照。此接口不再更新，建议使用 `wx.chooseMedia`。
        /// ****
        /// ```js
        /// wx.chooseImage({
        /// count: 1,
        /// sizeType: ['original', 'compressed'],
        /// sourceType: ['album', 'camera'],
        /// success (res) {
        /// // tempFilePath可以作为img标签的src属性显示图片
        /// const tempFilePaths = res.tempFilePaths
        /// }
        /// })
        /// ```
        /// </summary>
        public static void ChooseImage(ChooseImageOption callback)
        {
            WXSDKManagerHandler.Instance.ChooseImage(callback);
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
        /// [wx.closeSocket(Object object)](https://developers.weixin.qq.com/minigame/dev/api/network/websocket/wx.closeSocket.html)
        /// 关闭 WebSocket 连接。**推荐使用 [SocketTask](https://developers.weixin.qq.com/minigame/dev/api/network/websocket/SocketTask.html) 的方式去管理 webSocket 链接，每一条链路的生命周期都更加可控。同时存在多个 webSocket 的链接的情况下使用 wx 前缀的方法可能会带来一些和预期不一致的情况。**
        /// **示例代码**
        /// ```js
        /// wx.connectSocket({
        /// url: 'test.php'
        /// })
        /// //注意这里有时序问题，
        /// //如果 wx.connectSocket 还没回调 wx.onSocketOpen，而先调用 wx.closeSocket，那么就做不到关闭 WebSocket 的目的。
        /// //必须在 WebSocket 打开期间调用 wx.closeSocket 才能关闭。
        /// wx.onSocketOpen(function() {
        /// wx.closeSocket()
        /// })
        /// wx.onSocketClose(function(res) {
        /// console.log('WebSocket 已关闭！')
        /// })
        /// ```
        /// </summary>
        public static void CloseSocket(CloseSocketOption callback)
        {
            WXSDKManagerHandler.Instance.CloseSocket(callback);
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
        /// 人脸识别，使用前需要通过 wx.initFaceDetect 进行一次初始化，推荐使用相机接口返回的帧数据
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
        /// [wx.getFileInfo(Object object)](https://developers.weixin.qq.com/minigame/dev/api/file/wx.getFileInfo.html)
        /// 需要基础库： `1.4.0`
        /// 获取文件信息
        /// **示例代码**
        /// ```js
        /// wx.getFileInfo({
        /// success (res) {
        /// console.log(res.size)
        /// console.log(res.digest)
        /// }
        /// })
        /// ```
        /// </summary>
        public static void GetFileInfo(WxGetFileInfoOption callback)
        {
            WXSDKManagerHandler.Instance.GetFileInfo(callback);
        }
        /// <summary>
        /// [wx.getFriendCloudStorage(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/data/wx.getFriendCloudStorage.html)
        /// 需要基础库： `1.9.92`
        /// 拉取当前用户所有同玩好友的托管数据。该接口需要用户授权，且只在开放数据域下可用。
        /// </summary>
        public static void GetFriendCloudStorage(GetFriendCloudStorageOption callback)
        {
            WXSDKManagerHandler.Instance.GetFriendCloudStorage(callback);
        }
        /// <summary>
        /// [wx.getGroupCloudStorage(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/data/wx.getGroupCloudStorage.html)
        /// 需要基础库： `1.9.92`
        /// 获取群同玩成员的游戏数据。小游戏通过群分享卡片打开的情况下才可以调用。该接口需要用户授权，且只在开放数据域下可用。
        /// </summary>
        public static void GetGroupCloudStorage(GetGroupCloudStorageOption callback)
        {
            WXSDKManagerHandler.Instance.GetGroupCloudStorage(callback);
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
        /// [wx.getGroupInfo(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/data/wx.getGroupInfo.html)
        /// 需要基础库： `2.10.1`
        /// 获取群信息。小游戏通过群分享卡片打开的情况下才可以调用。该接口需要用户授权，且只在开放数据域下可用。
        /// </summary>
        public static void GetGroupInfo(GetGroupInfoOption callback)
        {
            WXSDKManagerHandler.Instance.GetGroupInfo(callback);
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
        /// [wx.getLocation(Object object)](https://developers.weixin.qq.com/minigame/dev/api/location/wx.getLocation.html)
        /// 获取当前的地理位置、速度。当用户离开小程序后，此接口无法调用。开启高精度定位，接口耗时会增加，可指定 highAccuracyExpireTime 作为超时时间。地图相关使用的坐标格式应为 gcj02。高频率调用会导致耗电，如有需要可使用持续定位接口 `wx.onLocationChange`。基础库 `2.17.0` 版本起 `wx.getLocation` 增加调用频率限制，[相关公告](https://developers.weixin.qq.com/community/develop/doc/000aee91a98d206bc6dbe722b51801)。
        /// **示例代码**
        /// ```js
        /// wx.getLocation({
        /// type: 'wgs84',
        /// success (res) {
        /// const latitude = res.latitude
        /// const longitude = res.longitude
        /// const speed = res.speed
        /// const accuracy = res.accuracy
        /// }
        /// })
        /// ```
        /// **注意**
        /// - `2.17.0 起 `wx.getLocation` 增加调用频率限制，[相关公告](https://developers.weixin.qq.com/community/develop/doc/000aee91a98d206bc6dbe722b51801)
        /// - 工具中定位模拟使用IP定位，可能会有一定误差。且工具目前仅支持 gcj02 坐标。
        /// - 使用第三方服务进行逆地址解析时，请确认第三方服务默认的坐标系，正确进行坐标转换。
        /// </summary>
        public static void GetLocation(GetLocationOption callback)
        {
            WXSDKManagerHandler.Instance.GetLocation(callback);
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
        /// [wx.getPotentialFriendList(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/data/wx.getPotentialFriendList.html)
        /// 需要基础库： `2.9.0`
        /// 获取可能对游戏感兴趣的未注册的好友名单。每次调用最多可获得 5 个好友。该接口需要用户授权，且只在开放数据域下可用。
        /// </summary>
        public static void GetPotentialFriendList(GetPotentialFriendListOption callback)
        {
            WXSDKManagerHandler.Instance.GetPotentialFriendList(callback);
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
        /// [wx.getSetting(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/setting/wx.getSetting.html)
        /// 需要基础库： `1.2.0`
        /// 获取用户的当前设置。**返回值中只会出现小程序已经向用户请求过的[权限](https://developers.weixin.qq.com/minigame/dev/guide/framework/authorize.html)**。
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
        /// 获取转发详细信息
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
        /// 异步获取当前storage的相关信息。缓存相关策略请查看 [存储](https://developers.weixin.qq.com/minigame/dev/guide/base-ability/storage.html)。
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
        /// 需要基础库： `2.14.1`
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
        /// [wx.getUserCloudStorage(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/data/wx.getUserCloudStorage.html)
        /// 需要基础库： `1.9.92`
        /// 获取当前用户托管数据当中对应 key 的数据。该接口只可在开放数据域下使用
        /// </summary>
        public static void GetUserCloudStorage(GetUserCloudStorageOption callback)
        {
            WXSDKManagerHandler.Instance.GetUserCloudStorage(callback);
        }
        /// <summary>
        /// [wx.getUserCloudStorageKeys(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/data/wx.getUserCloudStorageKeys.html)
        /// 需要基础库： `2.16.1`
        /// 获取当前用户托管数据当中所有的 key。该接口需要用户授权，且只在开放数据域下可用。
        /// </summary>
        public static void GetUserCloudStorageKeys(GetUserCloudStorageKeysOption callback)
        {
            WXSDKManagerHandler.Instance.GetUserCloudStorageKeys(callback);
        }
        /// <summary>
        /// [wx.getUserInfo(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/user-info/wx.getUserInfo.html)
        /// 获取用户信息。
        /// **接口调整说明**
        /// 为优化用户登录体验，该接口将进行调整，详见 [用户信息接口调整说明](https://developers.weixin.qq.com/community/develop/doc/000cacfa20ce88df04cb468bc52801)
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
        /// **小程序用户信息组件示例代码**
        /// ```html
        /// <!-- 如果只是展示用户头像昵称，可以使用 <open-data /> 组件 -->
        /// <open-data type="userAvatarUrl"></open-data>
        /// <open-data type="userNickName"></open-data>
        /// <!-- 需要使用 button 来授权登录 -->
        /// <button wx:if="{{canIUse}}" open-type="getUserInfo" bindgetuserinfo="bindGetUserInfo">授权登录</button>
        /// <view wx:else>请升级微信版本</view>
        /// ```
        /// ```js
        /// Page({
        /// data: {
        /// canIUse: wx.canIUse('button.open-type.getUserInfo')
        /// },
        /// onLoad: function() {
        /// // 查看是否授权
        /// wx.getSetting({
        /// success (res){
        /// if (res.authSetting['scope.userInfo']) {
        /// // 已经授权，可以直接调用 getUserInfo 获取头像昵称
        /// wx.getUserInfo({
        /// success: function(res) {
        ///   console.log(res.userInfo)
        /// }
        /// })
        /// }
        /// }
        /// })
        /// },
        /// bindGetUserInfo (e) {
        /// console.log(e.detail.userInfo)
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
        /// 获取用户过去三十天微信运动步数。需要先调用 [wx.login](https://developers.weixin.qq.com/minigame/dev/api/open-api/login/wx.login.html) 接口。步数信息会在用户主动进入小程序时更新。
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
        /// 初始化人脸识别
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
        /// 调用接口获取登录凭证（code）。通过凭证进而换取用户登录态信息，包括用户在当前小程序的唯一标识（openid）、微信开放平台帐号下的唯一标识（unionid，若当前小程序已绑定到微信开放平台帐号）及本次登录的会话密钥（session_key）等。用户数据的加解密通讯需要依赖会话密钥完成。更多使用方法详见 [小程序登录](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/login.html)。
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
        /// [wx.modifyFriendInteractiveStorage(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/data/wx.modifyFriendInteractiveStorage.html)
        /// 需要基础库： `2.7.7`
        /// 修改好友的互动型托管数据，该接口只可在开放数据域下使用。
        /// **赠送动作的校验**
        /// 调用该接口需要上传 JSServer 函数 "checkInteractiveData"，该函数可用于执行赠送动作的校验逻辑，校验通过后返回结果表示本次赠送是否合法。只有 checkInteractiveData 返回了 `{ret: true}`，此次修改才会成功。
        /// **使用模板规则进行交互**
        /// 每次调用该接口会弹窗询问用户是否确认执行该操作，2.9.0 之后版本，需要在 game.json 中设置 `modifyFriendInteractiveStorageTemplates` 来定制交互的文案。
        /// `modifyFriendInteractiveStorageTemplates` 是一个模板数组，每一个模板需要有 key, action, object 参数，还有一个可选参数 ratio，详细说明见示例配置：
        /// ```json
        /// {
        /// "modifyFriendInteractiveStorageTemplates": [
        /// {
        /// "key": "1", // 这个 key 与接口中同名参数相对应，不同的 key 对应不同的模板
        /// "action": "赠送", // 互动行为
        /// "object": "金币", // 互动物品
        /// "ratio": 10 // 物品比率，opNum * ratio 代表物品个数
        /// }
        /// ]
        /// }
        /// ```
        /// 最后生成的文案为 "确认 ${action} ${nickname} ${object}？"，或者 "确认 ${action} ${nickname} ${object} x ${opNum * ratio}？"
        /// **使用自定义文案进行交互**
        /// 2.7.7 之后，2.9.0 之前的版本，文案通过 game.json 的 `modifyFriendInteractiveStorageConfirmWording` 字段配置。
        /// 配置内容可包含 nickname 变量，用 ${nickname} 表示，实际调用时会被替换成好友的昵称。示例配置：
        /// ```json
        /// {
        /// "modifyFriendInteractiveStorageConfirmWording": "确认送给${nickname}一个体力？"
        /// }
        /// ```
        /// 2.9.0 之后，在 `modifyFriendInteractiveStorageTemplates` 和 `modifyFriendInteractiveStorageConfirmWording` 都存在的情况下，会优先使用前者。
        /// </summary>
        public static void ModifyFriendInteractiveStorage(ModifyFriendInteractiveStorageOption callback)
        {
            WXSDKManagerHandler.Instance.ModifyFriendInteractiveStorage(callback);
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
        /// [wx.openCustomerServiceConversation(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/customer-message/wx.openCustomerServiceConversation.html)
        /// 需要基础库： `2.0.3`
        /// 进入客服会话。要求在用户发生过至少一次 touch 事件后才能调用。后台接入方式与小程序一致，详见 [客服消息接入](https://developers.weixin.qq.com/miniprogram/dev/framework/open-ability/customer-message/customer-message.html)
        /// </summary>
        public static void OpenCustomerServiceConversation(OpenCustomerServiceConversationOption callback)
        {
            WXSDKManagerHandler.Instance.OpenCustomerServiceConversation(callback);
        }
        /// <summary>
        /// [wx.openSetting(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/setting/wx.openSetting.html)
        /// 需要基础库： `1.1.0`
        /// 调起客户端小程序设置界面，返回用户设置的操作结果。**设置界面只会出现小程序已经向用户请求过的[权限](https://developers.weixin.qq.com/minigame/dev/guide/framework/authorize.html)**。
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
        /// [wx.previewImage(Object object)](https://developers.weixin.qq.com/minigame/dev/api/media/image/wx.previewImage.html)
        /// 在新页面中全屏预览图片。预览的过程中用户可以进行保存图片、发送给朋友等操作。
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
        /// 从本地缓存中移除指定 key。缓存相关策略请查看 [存储](https://developers.weixin.qq.com/minigame/dev/guide/base-ability/storage.html)。
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
        /// [wx.requestMidasFriendPayment(Object object)](https://developers.weixin.qq.com/minigame/dev/api/midas-payment/wx.requestMidasFriendPayment.html)
        /// 需要基础库： `2.11.0`
        /// 发起米大师朋友礼物索要。接口用法详见 [小游戏礼物索要接入指南](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/friend-payment.html)
        /// **示例代码**
        /// ```js
        /// wx.requestMidasFriendPayment({
        /// success(res) {
        /// // res
        /// {
        /// errMsg: 'requestMidasFriendPayment:ok',
        /// encryptedData: 'xxxx',
        /// iv: 'xxx'
        /// }
        /// },
        /// fail() {
        /// }
        /// })
        /// ```
        /// encryptedData 解密后数据结构如下：
        /// ```json
        /// {
        /// "outTradeNo": "xxxxxxxx",
        /// "orderNo": "PBgAAHMjeOhixxxx",
        /// "watermark": {
        /// "timestamp": 1585537091,
        /// "appid": "wx7a727ff7d940xxxx"
        /// }
        /// }
        /// ```
        /// **buyQuantity限制说明**
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
        /// [wx.sendSocketMessage(Object object)](https://developers.weixin.qq.com/minigame/dev/api/network/websocket/wx.sendSocketMessage.html)
        /// 通过 WebSocket 连接发送数据。需要先 wx.connectSocket，并在 wx.onSocketOpen 回调之后才能发送。**推荐使用 [SocketTask](https://developers.weixin.qq.com/minigame/dev/api/network/websocket/SocketTask.html) 的方式去管理 webSocket 链接，每一条链路的生命周期都更加可控。同时存在多个 webSocket 的链接的情况下使用 wx 前缀的方法可能会带来一些和预期不一致的情况。**
        /// **示例代码**
        /// ```js
        /// let socketOpen = false
        /// let socketMsgQueue = []
        /// wx.connectSocket({
        /// url: 'test.php'
        /// })
        /// wx.onSocketOpen(function(res) {
        /// socketOpen = true
        /// for (let i = 0; i < socketMsgQueue.length; i++){
        /// sendSocketMessage(socketMsgQueue[i])
        /// }
        /// socketMsgQueue = []
        /// })
        /// function sendSocketMessage(msg) {
        /// if (socketOpen) {
        /// wx.sendSocketMessage({
        /// data:msg
        /// })
        /// } else {
        /// socketMsgQueue.push(msg)
        /// }
        /// }
        /// ```
        /// </summary>
        public static void SendSocketMessage(SendSocketMessageOption callback)
        {
            WXSDKManagerHandler.Instance.SendSocketMessage(callback);
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
        /// [wx.shareMessageToFriend(Object object)](https://developers.weixin.qq.com/minigame/dev/api/open-api/data/wx.shareMessageToFriend.html)
        /// 需要基础库： `2.9.0`
        /// 给指定的好友分享游戏信息，该接口只可在开放数据域下使用。接收者打开之后，可以用 `wx.modifyFriendInteractiveStorage` 传入参数 quiet=true 发起一次无需弹框确认的好友互动。
        /// ****
        /// 定向分享不允许直接在开放数据域设置 query 参数
        /// 需要设置请参见游戏域 `wx.setMessageToFriendQuery` 接口
        /// </summary>
        public static void ShareMessageToFriend(ShareMessageToFriendOption callback)
        {
            WXSDKManagerHandler.Instance.ShareMessageToFriend(callback);
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
        /// [wx.startGyroscope(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/gyroscope/wx.startGyroscope.html)
        /// 需要基础库： `2.3.0`
        /// 开始监听陀螺仪数据。
        /// </summary>
        public static void StartGyroscope(StartGyroscopeOption callback)
        {
            WXSDKManagerHandler.Instance.StartGyroscope(callback);
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
        /// 停止人脸识别
        /// </summary>
        public static void StopFaceDetect(StopFaceDetectOption callback)
        {
            WXSDKManagerHandler.Instance.StopFaceDetect(callback);
        }
        /// <summary>
        /// [wx.stopGyroscope(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/gyroscope/wx.stopGyroscope.html)
        /// 需要基础库： `2.3.0`
        /// 停止监听陀螺仪数据。
        /// </summary>
        public static void StopGyroscope(StopGyroscopeOption callback)
        {
            WXSDKManagerHandler.Instance.StopGyroscope(callback);
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
public static void ReportEvent<T>(string eventId,T data)
{
    WXSDKManagerHandler.Instance.ReportEvent(eventId,data);
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
public static void ReportMonitor(string name,double value)
{
    WXSDKManagerHandler.Instance.ReportMonitor(name,value);
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
public static void ReportPerformance(double id,double value,string dimensions)
{
    WXSDKManagerHandler.Instance.ReportPerformance(id,value,dimensions);
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
/// [wx.setStorageSync(string key, any data, Boolean encrypt)](https://developers.weixin.qq.com/minigame/dev/api/storage/wx.setStorageSync.html)
/// [wx.setStorage](https://developers.weixin.qq.com/minigame/dev/api/storage/wx.setStorage.html) 的同步版本
/// **示例代码**
/// ```js
/// wx.setStorage({
/// key:"key",
/// data:"value"
/// })
/// ```
/// ```js
/// try {
/// wx.setStorageSync('key', 'value')
/// } catch (e) { }
/// ```
/// ```js
/// // 开启加密存储
/// wx.setStorage({
/// key: "key",
/// data: "value",
/// encrypt: true, // 若开启加密存储，setStorage 和 getStorage 需要同时声明 encrypt 的值为 true
/// success() {
/// wx.getStorage({
/// key: "key",
/// encrypt: true, // 若开启加密存储，setStorage 和 getStorage 需要同时声明 encrypt 的值为 true
/// success(res) {
/// console.log(res.data)
/// }
/// })
/// }
/// })
/// ```
/// </summary>
public static void SetStorageSync<T>(string key,T data,bool encrypt)
{
    WXSDKManagerHandler.Instance.SetStorageSync(key,data,encrypt);
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
    /// [wx.onAccelerometerChange(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/accelerometer/wx.onAccelerometerChange.html)
    /// 监听加速度数据事件。频率根据 [wx.startAccelerometer()](https://developers.weixin.qq.com/minigame/dev/api/device/accelerometer/wx.startAccelerometer.html) 的 interval 参数, 接口调用后会自动开始监听。
    /// **示例代码**
    /// ```js
    /// wx.onAccelerometerChange(callback)
    /// ```
    /// </summary>
    public static void OnAccelerometerChange(Action<OnAccelerometerChangeCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnAccelerometerChange(result);
    }
    public static void OffAccelerometerChange(Action<OnAccelerometerChangeCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffAccelerometerChange(result);
    }
    /// <summary>
    /// [wx.onAudioInterruptionBegin(function callback)](https://developers.weixin.qq.com/minigame/dev/api/base/app/app-event/wx.onAudioInterruptionBegin.html)
    /// 需要基础库： `1.8.0`
    /// 监听音频因为受到系统占用而被中断开始事件。以下场景会触发此事件：闹钟、电话、FaceTime 通话、微信语音聊天、微信视频聊天。此事件触发后，小程序内所有音频会暂停。
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
    /// [wx.onAudioInterruptionEnd(function callback)](https://developers.weixin.qq.com/minigame/dev/api/base/app/app-event/wx.onAudioInterruptionEnd.html)
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
    /// [wx.onBLECharacteristicValueChange(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.onBLECharacteristicValueChange.html)
    /// 需要基础库： `2.9.2`
    /// 监听蓝牙低功耗设备的特征值变化事件。必须先调用 [wx.notifyBLECharacteristicValueChange](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.notifyBLECharacteristicValueChange.html) 接口才能接收到设备推送的 notification。
    /// **示例代码**
    /// [在微信开发者工具中查看示例](https://developers.weixin.qq.com/s/pQU51zmz7a3K)
    /// ```js
    /// // ArrayBuffer转16进制字符串示例
    /// function ab2hex(buffer) {
    /// let hexArr = Array.prototype.map.call(
    /// new Uint8Array(buffer),
    /// function(bit) {
    /// return ('00' + bit.toString(16)).slice(-2)
    /// }
    /// )
    /// return hexArr.join('');
    /// }
    /// wx.onBLECharacteristicValueChange(function(res) {
    /// console.log(`characteristic ${res.characteristicId} has changed, now is ${res.value}`)
    /// console.log(ab2hex(res.value))
    /// })
    /// ```
    /// </summary>
    public static void OnBLECharacteristicValueChange(Action<OnBLECharacteristicValueChangeCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnBLECharacteristicValueChange(result);
    }
    public static void OffBLECharacteristicValueChange(Action<OnBLECharacteristicValueChangeCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffBLECharacteristicValueChange(result);
    }
    /// <summary>
    /// [wx.onBLEConnectionStateChange(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.onBLEConnectionStateChange.html)
    /// 需要基础库： `2.9.2`
    /// 监听蓝牙低功耗连接状态的改变事件。包括开发者主动连接或断开连接，设备丢失，连接异常断开等等
    /// **示例代码**
    /// [在微信开发者工具中查看示例](https://developers.weixin.qq.com/s/pQU51zmz7a3K)
    /// ```js
    /// wx.onBLEConnectionStateChange(function(res) {
    /// // 该方法回调中可以用于处理连接意外断开等异常情况
    /// console.log(`device ${res.deviceId} state has changed, connected: ${res.connected}`)
    /// })
    /// ```
    /// </summary>
    public static void OnBLEConnectionStateChange(Action<OnBLEConnectionStateChangeCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnBLEConnectionStateChange(result);
    }
    public static void OffBLEConnectionStateChange(Action<OnBLEConnectionStateChangeCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffBLEConnectionStateChange(result);
    }
    /// <summary>
    /// [wx.onBLEMTUChange(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.onBLEMTUChange.html)
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
    public static void OnBLEMTUChange(Action<OnBLEMTUChangeCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnBLEMTUChange(result);
    }
    public static void OffBLEMTUChange(Action<OnBLEMTUChangeCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffBLEMTUChange(result);
    }
    /// <summary>
    /// [wx.onBLEPeripheralConnectionStateChanged(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-peripheral/wx.onBLEPeripheralConnectionStateChanged.html)
    /// 需要基础库： `2.10.3`
    /// 监听当前外围设备被连接或断开连接事件
    /// </summary>
    public static void OnBLEPeripheralConnectionStateChanged(Action<OnBLEPeripheralConnectionStateChangedCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnBLEPeripheralConnectionStateChanged(result);
    }
    public static void OffBLEPeripheralConnectionStateChanged(Action<OnBLEPeripheralConnectionStateChangedCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffBLEPeripheralConnectionStateChanged(result);
    }
    /// <summary>
    /// [wx.onBeaconServiceChange(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/ibeacon/wx.onBeaconServiceChange.html)
    /// 需要基础库： `2.9.2`
    /// 监听 Beacon 服务状态变化事件，仅能注册一个监听
    /// </summary>
    public static void OnBeaconServiceChange(Action<OnBeaconServiceChangeCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnBeaconServiceChange(result);
    }
    public static void OffBeaconServiceChange(Action<OnBeaconServiceChangeCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffBeaconServiceChange(result);
    }
    /// <summary>
    /// [wx.onBeaconUpdate(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/ibeacon/wx.onBeaconUpdate.html)
    /// 需要基础库： `2.9.2`
    /// 监听 Beacon 设备更新事件，仅能注册一个监听
    /// </summary>
    public static void OnBeaconUpdate(Action<OnBeaconUpdateCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnBeaconUpdate(result);
    }
    public static void OffBeaconUpdate(Action<OnBeaconUpdateCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffBeaconUpdate(result);
    }
    /// <summary>
    /// [wx.onBluetoothAdapterStateChange(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth/wx.onBluetoothAdapterStateChange.html)
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
    public static void OnBluetoothAdapterStateChange(Action<OnBluetoothAdapterStateChangeCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnBluetoothAdapterStateChange(result);
    }
    public static void OffBluetoothAdapterStateChange(Action<OnBluetoothAdapterStateChangeCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffBluetoothAdapterStateChange(result);
    }
    /// <summary>
    /// [wx.onBluetoothDeviceFound(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth/wx.onBluetoothDeviceFound.html)
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
    public static void OnBluetoothDeviceFound(Action<OnBluetoothDeviceFoundCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnBluetoothDeviceFound(result);
    }
    public static void OffBluetoothDeviceFound(Action<OnBluetoothDeviceFoundCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffBluetoothDeviceFound(result);
    }
    /// <summary>
    /// [wx.onCompassChange(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/compass/wx.onCompassChange.html)
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
    public static void OnCompassChange(Action<OnCompassChangeCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnCompassChange(result);
    }
    public static void OffCompassChange(Action<OnCompassChangeCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffCompassChange(result);
    }
    /// <summary>
    /// [wx.onDeviceMotionChange(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/motion/wx.onDeviceMotionChange.html)
    /// 需要基础库： `2.3.0`
    /// 监听设备方向变化事件。频率根据 [wx.startDeviceMotionListening()](https://developers.weixin.qq.com/minigame/dev/api/device/motion/wx.startDeviceMotionListening.html) 的 interval 参数。可以使用 [wx.stopDeviceMotionListening()](https://developers.weixin.qq.com/minigame/dev/api/device/motion/wx.stopDeviceMotionListening.html) 停止监听。
    /// </summary>
    public static void OnDeviceMotionChange(Action<OnDeviceMotionChangeCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnDeviceMotionChange(result);
    }
    public static void OffDeviceMotionChange(Action<OnDeviceMotionChangeCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffDeviceMotionChange(result);
    }
    /// <summary>
    /// [wx.onDeviceOrientationChange(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/orientation/wx.onDeviceOrientationChange.html)
    /// 需要基础库： `2.1.0`
    /// 监听横竖屏切换事件
    /// </summary>
    public static void OnDeviceOrientationChange(Action<OnDeviceOrientationChangeCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnDeviceOrientationChange(result);
    }
    public static void OffDeviceOrientationChange(Action<OnDeviceOrientationChangeCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffDeviceOrientationChange(result);
    }
    /// <summary>
    /// [wx.onError(function callback)](https://developers.weixin.qq.com/minigame/dev/api/base/app/app-event/wx.onError.html)
    /// 监听全局错误事件
    /// </summary>
    public static void OnError(Action<WxOnErrorCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnError(result);
    }
    public static void OffError(Action<WxOnErrorCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffError(result);
    }
    /// <summary>
    /// [wx.onGyroscopeChange(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/gyroscope/wx.onGyroscopeChange.html)
    /// 需要基础库： `2.3.0`
    /// 监听陀螺仪数据变化事件。频率根据 [wx.startGyroscope()](https://developers.weixin.qq.com/minigame/dev/api/device/gyroscope/wx.startGyroscope.html) 的 interval 参数。可以使用 [wx.stopGyroscope()](https://developers.weixin.qq.com/minigame/dev/api/device/gyroscope/wx.stopGyroscope.html) 停止监听。
    /// </summary>
    public static void OnGyroscopeChange(Action<OnGyroscopeChangeCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnGyroscopeChange(result);
    }
    public static void OffGyroscopeChange(Action<OnGyroscopeChangeCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffGyroscopeChange(result);
    }
    /// <summary>
    /// [wx.onHide(function callback)](https://developers.weixin.qq.com/minigame/dev/api/base/app/life-cycle/wx.onHide.html)
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
    /// [wx.onKeyDown(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/keyboard/wx.onKeyDown.html)
    /// 需要基础库： `2.10.1`
    /// 监听键盘按键按下事件，仅适用于 PC 平台
    /// </summary>
    public static void OnKeyDown(Action<OnKeyDownCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnKeyDown(result);
    }
    public static void OffKeyDown(Action<OnKeyDownCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffKeyDown(result);
    }
    /// <summary>
    /// [wx.onKeyUp(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/keyboard/wx.onKeyUp.html)
    /// 需要基础库： `2.10.1`
    /// 监听键盘按键弹起事件，仅适用于 PC 平台
    /// </summary>
    public static void OnKeyUp(Action<OnKeyDownCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnKeyUp(result);
    }
    public static void OffKeyUp(Action<OnKeyDownCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffKeyUp(result);
    }
    /// <summary>
    /// [wx.onKeyboardComplete(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/keyboard/wx.onKeyboardComplete.html)
    /// 监听监听键盘收起的事件
    /// </summary>
    public static void OnKeyboardComplete(Action<OnKeyboardInputCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnKeyboardComplete(result);
    }
    public static void OffKeyboardComplete(Action<OnKeyboardInputCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffKeyboardComplete(result);
    }
    /// <summary>
    /// [wx.onKeyboardConfirm(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/keyboard/wx.onKeyboardConfirm.html)
    /// 监听用户点击键盘 Confirm 按钮时的事件
    /// </summary>
    public static void OnKeyboardConfirm(Action<OnKeyboardInputCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnKeyboardConfirm(result);
    }
    public static void OffKeyboardConfirm(Action<OnKeyboardInputCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffKeyboardConfirm(result);
    }
    /// <summary>
    /// [wx.onKeyboardHeightChange(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/keyboard/wx.onKeyboardHeightChange.html)
    /// 需要基础库： `2.21.3`
    /// 监听键盘高度变化
    /// **示例代码**
    /// ```js
    /// wx.onKeyboardHeightChange(res => {
    /// console.log(res.height)
    /// })
    /// ```
    /// </summary>
    public static void OnKeyboardHeightChange(Action<OnKeyboardHeightChangeCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnKeyboardHeightChange(result);
    }
    public static void OffKeyboardHeightChange(Action<OnKeyboardHeightChangeCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffKeyboardHeightChange(result);
    }
    /// <summary>
    /// [wx.onKeyboardInput(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/keyboard/wx.onKeyboardInput.html)
    /// 监听键盘输入事件
    /// </summary>
    public static void OnKeyboardInput(Action<OnKeyboardInputCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnKeyboardInput(result);
    }
    public static void OffKeyboardInput(Action<OnKeyboardInputCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffKeyboardInput(result);
    }
    /// <summary>
    /// [wx.onMemoryWarning(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/memory/wx.onMemoryWarning.html)
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
    public static void OnMemoryWarning(Action<OnMemoryWarningCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnMemoryWarning(result);
    }
    public static void OffMemoryWarning(Action<OnMemoryWarningCallbackResult> result)
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
    public static void OffMessage(Action<string> res)
    {
        WXSDKManagerHandler.Instance.OffMessage(res);
    }
    /// <summary>
    /// [wx.onNetworkStatusChange(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/network/wx.onNetworkStatusChange.html)
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
    public static void OnNetworkStatusChange(Action<OnNetworkStatusChangeCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnNetworkStatusChange(result);
    }
    public static void OffNetworkStatusChange(Action<OnNetworkStatusChangeCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffNetworkStatusChange(result);
    }
    /// <summary>
    /// [wx.onNetworkWeakChange(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/network/wx.onNetworkWeakChange.html)
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
    public static void OnNetworkWeakChange(Action<OnNetworkWeakChangeCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnNetworkWeakChange(result);
    }
    public static void OffNetworkWeakChange(Action<OnNetworkWeakChangeCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffNetworkWeakChange(result);
    }
    /// <summary>
    /// [wx.onShareMessageToFriend(function callback)](https://developers.weixin.qq.com/minigame/dev/api/share/wx.onShareMessageToFriend.html)
    /// 需要基础库： `2.9.4`
    /// 监听主域接收 `wx.shareMessageToFriend` 接口的成功失败通知
    /// </summary>
    public static void OnShareMessageToFriend(Action<OnShareMessageToFriendCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnShareMessageToFriend(result);
    }
    public static void OffShareMessageToFriend(Action<OnShareMessageToFriendCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffShareMessageToFriend(result);
    }
    /// <summary>
    /// [wx.onShow(function callback)](https://developers.weixin.qq.com/minigame/dev/api/base/app/life-cycle/wx.onShow.html)
    /// 监听小游戏回到前台的事件
    /// </summary>
    public static void OnShow(Action<OnShowCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnShow(result);
    }
    public static void OffShow(Action<OnShowCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffShow(result);
    }
    /// <summary>
    /// [wx.onSocketClose(function callback)](https://developers.weixin.qq.com/minigame/dev/api/network/websocket/wx.onSocketClose.html)
    /// 监听 WebSocket 连接关闭事件。**推荐使用 [SocketTask](https://developers.weixin.qq.com/minigame/dev/api/network/websocket/SocketTask.html) 的方式去管理 webSocket 链接，每一条链路的生命周期都更加可控。同时存在多个 webSocket 的链接的情况下使用 wx 前缀的方法可能会带来一些和预期不一致的情况。**
    /// </summary>
    public static void OnSocketClose(Action<SocketTaskOnCloseCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnSocketClose(result);
    }
    public static void OffSocketClose(Action<SocketTaskOnCloseCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffSocketClose(result);
    }
    /// <summary>
    /// [wx.onSocketError(function callback)](https://developers.weixin.qq.com/minigame/dev/api/network/websocket/wx.onSocketError.html)
    /// 监听 WebSocket 错误事件。**推荐使用 [SocketTask](https://developers.weixin.qq.com/minigame/dev/api/network/websocket/SocketTask.html) 的方式去管理 webSocket 链接，每一条链路的生命周期都更加可控。同时存在多个 webSocket 的链接的情况下使用 wx 前缀的方法可能会带来一些和预期不一致的情况。**
    /// </summary>
    public static void OnSocketError(Action<GeneralCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnSocketError(result);
    }
    public static void OffSocketError(Action<GeneralCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffSocketError(result);
    }
    /// <summary>
    /// [wx.onSocketMessage(function callback)](https://developers.weixin.qq.com/minigame/dev/api/network/websocket/wx.onSocketMessage.html)
    /// 监听 WebSocket 接受到服务器的消息事件。**推荐使用 [SocketTask](https://developers.weixin.qq.com/minigame/dev/api/network/websocket/SocketTask.html) 的方式去管理 webSocket 链接，每一条链路的生命周期都更加可控。同时存在多个 webSocket 的链接的情况下使用 wx 前缀的方法可能会带来一些和预期不一致的情况。**
    /// </summary>
    public static void OnSocketMessage(Action<SocketTaskOnMessageCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnSocketMessage(result);
    }
    public static void OffSocketMessage(Action<SocketTaskOnMessageCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffSocketMessage(result);
    }
    /// <summary>
    /// [wx.onSocketOpen(function callback)](https://developers.weixin.qq.com/minigame/dev/api/network/websocket/wx.onSocketOpen.html)
    /// 监听 WebSocket 连接打开事件。**推荐使用 [SocketTask](https://developers.weixin.qq.com/minigame/dev/api/network/websocket/SocketTask.html) 的方式去管理 webSocket 链接，每一条链路的生命周期都更加可控。同时存在多个 webSocket 的链接的情况下使用 wx 前缀的方法可能会带来一些和预期不一致的情况。**
    /// </summary>
    public static void OnSocketOpen(Action<OnSocketOpenCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnSocketOpen(result);
    }
    public static void OffSocketOpen(Action<OnSocketOpenCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffSocketOpen(result);
    }
    /// <summary>
    /// [wx.onTouchCancel(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/touch-event/wx.onTouchCancel.html)
    /// 监听触点失效事件
    /// </summary>
    public static void OnTouchCancel(Action<OnTouchStartCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnTouchCancel(result);
    }
    public static void OffTouchCancel(Action<OnTouchStartCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffTouchCancel(result);
    }
    /// <summary>
    /// [wx.onTouchEnd(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/touch-event/wx.onTouchEnd.html)
    /// 监听触摸结束事件
    /// </summary>
    public static void OnTouchEnd(Action<OnTouchStartCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnTouchEnd(result);
    }
    public static void OffTouchEnd(Action<OnTouchStartCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffTouchEnd(result);
    }
    /// <summary>
    /// [wx.onTouchMove(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/touch-event/wx.onTouchMove.html)
    /// 监听触点移动事件
    /// </summary>
    public static void OnTouchMove(Action<OnTouchStartCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnTouchMove(result);
    }
    public static void OffTouchMove(Action<OnTouchStartCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffTouchMove(result);
    }
    /// <summary>
    /// [wx.onTouchStart(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/touch-event/wx.onTouchStart.html)
    /// 监听开始触摸事件
    /// </summary>
    public static void OnTouchStart(Action<OnTouchStartCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnTouchStart(result);
    }
    public static void OffTouchStart(Action<OnTouchStartCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffTouchStart(result);
    }
    /// <summary>
    /// [wx.onUnhandledRejection(function callback)](https://developers.weixin.qq.com/minigame/dev/api/base/app/app-event/wx.onUnhandledRejection.html)
    /// 需要基础库： `2.10.0`
    /// 监听未处理的 Promise 拒绝事件
    /// **注意**
    /// 安卓平台暂时不会派发该事件
    /// </summary>
    public static void OnUnhandledRejection(Action<OnUnhandledRejectionCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnUnhandledRejection(result);
    }
    public static void OffUnhandledRejection(Action<OnUnhandledRejectionCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffUnhandledRejection(result);
    }
    /// <summary>
    /// [wx.onUserCaptureScreen(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/screen/wx.onUserCaptureScreen.html)
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
    /// [wx.onVoIPChatInterrupted(function callback)](https://developers.weixin.qq.com/minigame/dev/api/media/voip/wx.onVoIPChatInterrupted.html)
    /// 需要基础库： `2.7.0`
    /// 监听被动断开实时语音通话事件。包括小游戏切入后端时断开
    /// </summary>
    public static void OnVoIPChatInterrupted(Action<OnVoIPChatInterruptedCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnVoIPChatInterrupted(result);
    }
    public static void OffVoIPChatInterrupted(Action<OnVoIPChatInterruptedCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffVoIPChatInterrupted(result);
    }
    /// <summary>
    /// [wx.onVoIPChatMembersChanged(function callback)](https://developers.weixin.qq.com/minigame/dev/api/media/voip/wx.onVoIPChatMembersChanged.html)
    /// 需要基础库： `2.7.0`
    /// 监听实时语音通话成员在线状态变化事件。有成员加入/退出通话时触发回调
    /// </summary>
    public static void OnVoIPChatMembersChanged(Action<OnVoIPChatMembersChangedCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnVoIPChatMembersChanged(result);
    }
    public static void OffVoIPChatMembersChanged(Action<OnVoIPChatMembersChangedCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffVoIPChatMembersChanged(result);
    }
    /// <summary>
    /// [wx.onVoIPChatSpeakersChanged(function callback)](https://developers.weixin.qq.com/minigame/dev/api/media/voip/wx.onVoIPChatSpeakersChanged.html)
    /// 需要基础库： `2.7.0`
    /// 监听实时语音通话成员通话状态变化事件。有成员开始/停止说话时触发回调
    /// </summary>
    public static void OnVoIPChatSpeakersChanged(Action<OnVoIPChatSpeakersChangedCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnVoIPChatSpeakersChanged(result);
    }
    public static void OffVoIPChatSpeakersChanged(Action<OnVoIPChatSpeakersChangedCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffVoIPChatSpeakersChanged(result);
    }
    /// <summary>
    /// [wx.onVoIPChatStateChanged(function callback)](https://developers.weixin.qq.com/minigame/dev/api/media/voip/wx.onVoIPChatStateChanged.html)
    /// 需要基础库： `2.16.0`
    /// 监听房间状态变化事件。
    /// </summary>
    public static void OnVoIPChatStateChanged(Action<OnVoIPChatStateChangedCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OnVoIPChatStateChanged(result);
    }
    public static void OffVoIPChatStateChanged(Action<OnVoIPChatStateChangedCallbackResult> result)
    {
        WXSDKManagerHandler.Instance.OffVoIPChatStateChanged(result);
    }

    /// <summary>
    /// [wx.onAddToFavorites(function callback)](https://developers.weixin.qq.com/minigame/dev/api/share/wx.onAddToFavorites.html)
    /// 需要基础库： `2.10.3`
    /// 监听用户点击菜单「收藏」按钮时触发的事件（安卓7.0.15起支持，iOS 暂不支持）
    /// </summary>
    public static void OnAddToFavorites(Action<Action<OnAddToFavoritesCallbackResult>> callback)
    {
        WXSDKManagerHandler.Instance.OnAddToFavorites(callback);
    }
    public static void OffAddToFavorites(Action<Action<OnAddToFavoritesCallbackResult>> callback = null)
    {
        WXSDKManagerHandler.Instance.OffAddToFavorites(callback);
    }   
    /// <summary>
    /// [wx.onCopyUrl(function callback)](https://developers.weixin.qq.com/minigame/dev/api/share/wx.onCopyUrl.html)
    /// 需要基础库： `2.14.3`
    /// 监听用户点击右上角菜单的「复制链接」按钮时触发的事件。本接口为 Beta 版本，暂只在 Android 平台支持。
    /// </summary>
    public static void OnCopyUrl(Action<Action<OnCopyUrlCallbackResult>> callback)
    {
        WXSDKManagerHandler.Instance.OnCopyUrl(callback);
    }
    public static void OffCopyUrl(Action<Action<OnCopyUrlCallbackResult>> callback = null)
    {
        WXSDKManagerHandler.Instance.OffCopyUrl(callback);
    }   
    /// <summary>
    /// [wx.onHandoff(function callback)](https://developers.weixin.qq.com/minigame/dev/api/share/wx.onHandoff.html)
    /// 需要基础库： `2.14.4`
    /// 监听用户点击菜单「在电脑上打开」按钮时触发的事件
    /// </summary>
    public static void OnHandoff(Action<Action<OnHandoffCallbackResult>> callback)
    {
        WXSDKManagerHandler.Instance.OnHandoff(callback);
    }
    public static void OffHandoff(Action<Action<OnHandoffCallbackResult>> callback = null)
    {
        WXSDKManagerHandler.Instance.OffHandoff(callback);
    }   
    /// <summary>
    /// [wx.onShareTimeline(function callback)](https://developers.weixin.qq.com/minigame/dev/api/share/wx.onShareTimeline.html)
    /// 需要基础库： `2.11.3`
    /// 监听用户点击右上角菜单的「分享到朋友圈」按钮时触发的事件。本接口为 Beta 版本，暂只在 Android 平台支持。
    /// </summary>
    public static void OnShareTimeline(Action<Action<OnShareTimelineCallbackResult>> callback)
    {
        WXSDKManagerHandler.Instance.OnShareTimeline(callback);
    }
    public static void OffShareTimeline(Action<Action<OnShareTimelineCallbackResult>> callback = null)
    {
        WXSDKManagerHandler.Instance.OffShareTimeline(callback);
    }   
    /// <summary>
    /// 监听小游戏直播状态变化事件
    /// 需要基础库： `2.18.1`
    /// </summary>
    public static void OnGameLiveStateChange(Action<OnGameLiveStateChangeCallbackResult,Action<OnGameLiveStateChangeCallbackResponse>> callback)
    {
        WXSDKManagerHandler.Instance.OnGameLiveStateChange(callback);
    }
    public static void OffGameLiveStateChange(Action<OnGameLiveStateChangeCallbackResult,Action<OnGameLiveStateChangeCallbackResponse>> callback = null)
    {
        WXSDKManagerHandler.Instance.OffGameLiveStateChange(callback);
    }   

/// <summary>
/// [Boolean wx.setHandoffQuery(String query)](https://developers.weixin.qq.com/minigame/dev/api/share/wx.setHandoffQuery.html)
/// 需要基础库： `2.14.4`
/// 设置接力参数，该接口需要在游戏域调用
/// </summary>
public static bool SetHandoffQuery(string query)
{
    return WXSDKManagerHandler.Instance.SetHandoffQuery(query);
}
/// <summary>
/// [Object wx.getAccountInfoSync()](https://developers.weixin.qq.com/minigame/dev/api/open-api/account-info/wx.getAccountInfoSync.html)
/// 需要基础库： `2.11.2`
/// 获取当前帐号信息。线上小程序版本号仅支持在正式版小程序中获取，开发版和体验版中无法获取。
/// **示例代码**
/// ```js
/// const accountInfo = wx.getAccountInfoSync();
/// console.log(accountInfo.miniProgram.appId) // 小程序 appId
/// console.log(accountInfo.plugin.appId) // 插件 appId
/// console.log(accountInfo.plugin.version) // 插件版本号， 'a.b.c' 这样的形式
/// ```
/// </summary>
public static AccountInfo GetAccountInfoSync()
{
    return WXSDKManagerHandler.Instance.GetAccountInfoSync();
}
/// <summary>
/// [Object wx.getBatteryInfoSync()](https://developers.weixin.qq.com/minigame/dev/api/device/battery/wx.getBatteryInfoSync.html)
/// [wx.getBatteryInfo](https://developers.weixin.qq.com/minigame/dev/api/device/battery/wx.getBatteryInfo.html) 的同步版本
/// </summary>
public static GetBatteryInfoSyncResult GetBatteryInfoSync()
{
    return WXSDKManagerHandler.Instance.GetBatteryInfoSync();
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
/// **注意**
/// 部分版本在无`referrerInfo`的时候会返回 `undefined`，建议使用 `options.referrerInfo && options.referrerInfo.appId` 进行判断。
/// </summary>
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
public static T GetExtConfigSync<T>()
{
    return WXSDKManagerHandler.Instance.GetExtConfigSync<T>();
}
/// <summary>
/// [Object wx.getLaunchOptionsSync()](https://developers.weixin.qq.com/minigame/dev/api/base/app/life-cycle/wx.getLaunchOptionsSync.html)
/// 获取小游戏冷启动时的参数。热启动参数通过 [wx.onShow](https://developers.weixin.qq.com/minigame/dev/api/base/app/life-cycle/wx.onShow.html) 接口获取。
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
public static SystemInfo GetSystemInfoSync()
{
    return WXSDKManagerHandler.Instance.GetSystemInfoSync();
}
/// <summary>
/// [boolean wx.setCursor(string path, number x, number y)](https://developers.weixin.qq.com/minigame/dev/api/render/cursor/wx.setCursor.html)
/// 需要基础库： `2.10.1`
/// 加载自定义光标，仅支持 PC 平台
/// **注意**
/// - 传入图片太大可能会导致设置无效，推荐图标大小 32x32
/// - 基础库 v2.16.0 后，支持更多图片格式以及关键字种类（参考 CSS 标准）
/// </summary>
public static bool SetCursor(string path,double x,double y)
{
    return WXSDKManagerHandler.Instance.SetCursor(path,x,y);
}
/// <summary>
/// [boolean wx.setMessageToFriendQuery(Object object)](https://developers.weixin.qq.com/minigame/dev/api/share/wx.setMessageToFriendQuery.html)
/// 设置 wx.shareMessageToFriend 接口 query 字段的值
/// </summary>
public static bool SetMessageToFriendQuery(SetMessageToFriendQueryOption option)
{
    return WXSDKManagerHandler.Instance.SetMessageToFriendQuery(option);
}
/// <summary>
/// [number wx.getTextLineHeight(Object object)](https://developers.weixin.qq.com/minigame/dev/api/render/font/wx.getTextLineHeight.html)
/// 获取一行文本的行高
/// </summary>
public static double GetTextLineHeight(GetTextLineHeightOption option)
{
    return WXSDKManagerHandler.Instance.GetTextLineHeight(option);
}
/// <summary>
/// [string wx.loadFont(string path)](https://developers.weixin.qq.com/minigame/dev/api/render/font/wx.loadFont.html)
/// 加载自定义字体文件
/// </summary>
public static string LoadFont(string path)
{
    return WXSDKManagerHandler.Instance.LoadFont(path);
}
/// <summary>
/// 查询当前直播状态
/// </summary>
public static GameLiveState GetGameLiveState()
{
    return WXSDKManagerHandler.Instance.GetGameLiveState();
}

/// <summary>
/// [[UpdateManager](https://developers.weixin.qq.com/minigame/dev/api/base/update/UpdateManager.html) wx.getUpdateManager()](https://developers.weixin.qq.com/minigame/dev/api/base/update/wx.getUpdateManager.html)
/// 需要基础库： `1.9.90`
/// 获取**全局唯一**的版本更新管理器，用于管理小程序更新。关于小程序的更新机制，可以查看[运行机制](https://developers.weixin.qq.com/minigame/dev/guide/runtime/operating-mechanism.html)文档。
/// **示例代码**
/// [示例代码](https://developers.weixin.qq.com/minigame/dev/api/base/update/UpdateManager.html#示例代码)
/// </summary>
public static UpdateManager GetUpdateManager()
{
    return WXSDKManagerHandler.Instance.GetUpdateManager();
}

    }
}

