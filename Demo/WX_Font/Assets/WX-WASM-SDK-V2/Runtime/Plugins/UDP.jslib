var UDPSocketLibrary = 
{
  $udpSocketManager: 
  {
    /*
     * Map of instances
     *
     * Instance structure:
     * {
     * 	url: string,
     * 	ws: WebSocket
     * }
     */
    instances: {},

    /* Last instance ID */
    lastId: 0,

    /* Event listeners */
    onOpen: null,
    onMessage: null,
    onError: null,
    onClose: null,
  }, 


  WXCreateUDPSocket: function (server, remotePort, localPort) {
    var instanceId = ++udpSocketManager.lastId;
    var udpSocket = wx.createUDPSocket();
    if (localPort == 0) {
      localPort = udpSocket.bind()
    } else {
      udpSocket.bind(localPort)
    }
    var instance = {
      instanceId: instanceId,
      socket: udpSocket,
      server: UTF8ToString(server),
      remotePort: remotePort,
      localPort: localPort,
      OnMessage: (function (res) {
        if (udpSocketManager.onMessage) {
          var dataBuffer = new Uint8Array(res.message);
          var buffer = _malloc(dataBuffer.length);
          HEAPU8.set(dataBuffer, buffer);
          Module.dynCall_viii(udpSocketManager.onMessage, instanceId, buffer, dataBuffer.length);
          _free(buffer)
        }
      }),
      OnError: (function (res) {
        if (udpSocketManager.onError) {
          var msg = res.errMsg;
          console.log("udp socket on error " + instanceId + " " + msg);
          var length = lengthBytesUTF8(msg) + 1;
          var buffer = _malloc(length);
          stringToUTF8(msg, buffer, length);
          Module.dynCall_vii(udpSocketManager.onError, instanceId, buffer);
          _free(buffer)
        }
      }),
      OnClose: (function (res) {
        if (udpSocketManager.onClose) {
          Module.dynCall_vi(udpSocketManager.onClose, instanceId)
        }
      })
    };
    udpSocket.onMessage(instance.OnMessage);
    udpSocket.onError(instance.OnError);
    udpSocket.onClose(instance.OnClose);
    udpSocket.connect({
      address:instance.server,
      port:instance.remotePort
    });
    udpSocketManager.instances[instanceId] = instance;
    return instanceId
  },
   
  WXSendUDPSocket: function (instanceId, bufferPtr, offset, length) {
    var instance = udpSocketManager.instances[instanceId];
    if (instance && instance.socket) {
      instance.socket.write({
        address: instance.server,
        port: instance.remotePort,
        message: buffer.slice(bufferPtr + offset, bufferPtr + length)
      })
    } else {
      console.log("udp socket instance not found " + instanceId)
    }
  },

  WXCloseUDPSocket: function (instanceId) {
    var instance = udpSocketManager.instances[instanceId];
    if (instance && instance.socket) {
      instance.socket.close();
      instance.socket = null;
      delete udpSocketManager.instances[instanceId]
    } else {
      console.log("udp socket instance not found " + instanceId)
    }
  },
  WXUDPSocketSetOnMessage: function (callback) {
    udpSocketManager.onMessage = callback
  },

  WXUDPSocketSetOnClose: function (callback) {
    udpSocketManager.onClose = callback
  },
  WXUDPSocketSetOnError: function (callback) {
    udpSocketManager.onError = callback
  }
};

autoAddDeps(UDPSocketLibrary, '$udpSocketManager');
mergeInto(LibraryManager.library, UDPSocketLibrary);