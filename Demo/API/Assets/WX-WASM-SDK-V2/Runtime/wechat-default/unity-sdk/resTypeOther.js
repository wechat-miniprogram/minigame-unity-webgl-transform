export const ResTypeOther = {
    Stats: {
        lastAccessedTime: 'number',
        lastModifiedTime: 'number',
        mode: 'number',
        size: 'number',
    },
    TCPSocketOnMessageListenerResult: {
        localInfo: 'LocalInfo',
        message: 'arrayBuffer',
        remoteInfo: 'RemoteInfo',
    },
    LocalInfo: {
        address: 'string',
        family: 'string',
        port: 'number',
    },
    RemoteInfo: {
        address: 'string',
        family: 'string',
        port: 'number',
    },
    UDPSocketConnectOption: {
        address: 'string',
        port: 'number',
    },
    UDPSocketOnMessageListenerResult: {
        localInfo: 'LocalInfo',
        message: 'arrayBuffer',
        remoteInfo: 'RemoteInfo',
    },
    UDPSocketSendOption: {
        address: 'string',
        message: 'string|arrayBuffer',
        port: 'number',
        length: 'number',
        offset: 'number',
        setBroadcast: 'bool',
    },
    UDPSocketSendParam: {
        address: 'string',
        port: 'number',
        length: 'number',
        offset: 'number',
        setBroadcast: 'bool',
    },
};
