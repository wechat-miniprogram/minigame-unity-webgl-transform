import moduleHelper from "./module-helper";

export default {
    handleText(s,f,c){
        const self = this;
        return {
            success(res){
                self.textFormat(s,res);
            },
            fail(res){
                self.textFormat(f,res);
            },
            complete(res){
                self.textFormat(c,res);
            }
        }
    },
    handleTextLongBack(s,f,c){
        const self = this;
        return {
            success(res){
                self.textFormatLongBack(s,res);
            },
            fail(res){
                self.textFormatLongBack(f,res);
            },
            complete(res){
                self.textFormatLongBack(c,res);
            }
        }
    },
    textFormat(id,res){
        if(!id){
            return false;
        }
        moduleHelper.send('TextResponseCallback', JSON.stringify({
            callbackId:id,
            errMsg:res.errMsg,
            errCode:res.errCode
        }));
    },
    textFormatLongBack(id,res){
        if(!id){
            return false;
        }
        moduleHelper.send('TextResponseLongCallback', JSON.stringify({
            callbackId:id,
            errMsg:res.errMsg,
            errCode:res.errCode
        }));
    },
    handlecloudCallFunction(s,f,c){
        const self = this;
        return {
            success(res){
                self.cloudCallFunctionFormat(s,res);
            },
            fail(res){
                self.cloudCallFunctionFormat(f,res);
            },
            complete(res){
                self.cloudCallFunctionFormat(c,res);
            }
        }
    },
    cloudCallFunctionFormat(id,res){
        if(!id){
            return false;
        }
        moduleHelper.send('CloudCallFunctionResponseCallback', JSON.stringify({
            callbackId:id,
            errMsg:res.errMsg,
            result:typeof res.result === "object" ? JSON.stringify(res.result) : res.result,
            requestID:res.requestID
        }));
    },

    handleLogin(s,f,c){
        const self = this;
        return {
            success(res){
                self.loginFormat(s,res);
            },
            fail(res){
                self.loginFormat(f,res);
            },
            complete(res){
                self.loginFormat(c,res);
            }
        }
    },
    loginFormat(id,res){
        if(!id){
            return false;
        }

        moduleHelper.send('LoginResponseCallback', JSON.stringify({
            callbackId:id,
            code:res.code || '',
            errMsg:res.errMsg || ''
        }));
    },
    handleUserInfo(s,f,c){
        const self = this;
        return {
            success(res){
                self.userInfoFormat(s,res);
            },
            fail(res){
                self.userInfoFormat(f,res);
            },
            complete(res){
                self.userInfoFormat(c,res);
            }
        }
    },
    userInfoFormat(id,res){
        if(!id){
            return false;
        }
        res.userInfo = res.userInfo || {};
        moduleHelper.send('UserInfoResponseCallback', JSON.stringify({
            callbackId:id,
            errCode:res.err_code || 0,
            errMsg:res.errMsg || '',
            signature:res.signature || '',
            encryptedData: res.encryptedData || '',
            iv:res.iv|| '',
            cloudID:res.cloudID || '',
            userInfoRaw:JSON.stringify({
                nickName:res.userInfo.nickName || '',
                avatarUrl:res.userInfo.avatarUrl || '',
                country:res.userInfo.country || '',
                province:res.userInfo.province || '',
                city:res.userInfo.city || '',
                language:res.userInfo.language || '',
                gender:res.userInfo.gender || 0
            }),
        }));
    },
    handleShareInfo(s,f,c){
        const self = this;
        return {
            success(res){
                self.shareInfoFormat(s,res);
            },
            fail(res){
                self.shareInfoFormat(f,res);
            },
            complete(res){
                self.shareInfoFormat(c,res);
            }
        }
    },
    shareInfoFormat(id,res){
        if(!id){
            return false;
        }
        moduleHelper.send('ShareInfoResponseCallback', JSON.stringify({
            callbackId:id,
            errMsg:res.errMsg || '',
            encryptedData: res.encryptedData || '',
            iv:res.iv|| '',
            cloudID:res.cloudID || ''
        }));
    },
    handleAuthPrivateMessage(s,f,c){
        const self = this;
        return {
            success(res){
                self.AuthPrivateMessageFormat(s,res);
            },
            fail(res){
                self.AuthPrivateMessageFormat(f,res);
            },
            complete(res){
                self.AuthPrivateMessageFormat(c,res);
            }
        }
    },
    AuthPrivateMessageFormat(id,res){
        if(!id){
            return false;
        }
        moduleHelper.send('AuthPrivateMessageFormatCallback', JSON.stringify({
            callbackId:id,
            errMsg:res.errMsg || '',
            valid:res.valid || false,
            encryptedData: res.encryptedData || '',
            iv:res.iv|| ''
        }));
    },
    handleNetworkType(s,f,c){
        const self = this;
        return {
            success(res){
                self.networkTypeFormat(s,res);
            },
            fail(res){
                self.networkTypeFormat(f,res);
            },
            complete(res){
                self.networkTypeFormat(c,res);
            }
        }
    },
    networkTypeFormat(id,res){
        if(!id){
            return false;
        }
        moduleHelper.send('GetNetworkTypeCallback', JSON.stringify({
            callbackId:id,
            ...res
        }));
    },
};