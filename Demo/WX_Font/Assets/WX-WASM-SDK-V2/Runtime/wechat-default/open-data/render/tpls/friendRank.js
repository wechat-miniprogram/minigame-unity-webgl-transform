export default function anonymous(it) {
    let out = '<view class="container" id="main"> <view class="rankList"> <scrollview class="list" scrollY="true"> ';
    const arr1 = it.data;
    if (arr1) {
        let item;
        let index = -1;
        const l1 = arr1.length - 1;
        while (index < l1) {
            item = arr1[(index += 1)];
            out += ` <view class="listItem"> <image src="open-data/render/image/rankBg.png" class="rankBg"></image> <image class="rankAvatarBg" src="open-data/render/image/rankAvatar.png"></image> <image class="rankAvatar" src="${item.avatarUrl}"></image> <view class="rankNameView"> <image class="rankNameBg" src="open-data/render/image/nameBg.png"></image> <text class="rankName" value="${item.nickname}"></text> <text class="rankScoreTip" value="战力值:"></text> <text class="rankScoreVal" value="${item.score || 0}"></text> </view> <view class="shareToBtn" data-isSelf="${!!item.isSelf}" data-id="${item.openid || ''}"> <image src="open-data/render/image/${item.isSelf ? 'button3' : 'button2'}.png" class="shareBtnBg"></image> <text class="shareText" value="${item.isSelf ? '你自己' : '分享'}"></text> </view> </view> `;
        }
    }
    out += ' </scrollview> </view></view>';
    return out;
}
