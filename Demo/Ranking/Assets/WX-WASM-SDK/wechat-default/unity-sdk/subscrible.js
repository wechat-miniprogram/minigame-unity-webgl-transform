import response from "./response";
export default {
    WXRequestSubscribeSystemMessage(list,s,f,c){

        wx.requestSubscribeSystemMessage({
            msgTypeList: list.split(','),
            success (res) {
                console.log(res)
                // res === {
                //   errMsg: "requestSubscribeSystemMessage:ok",
                //   SYS_MSG_TYPE_INTERACTIVE: "accept",
                //   SYS_MSG_TYPE_RANK: 'reject'
                // }
            }
        })
    }
}
