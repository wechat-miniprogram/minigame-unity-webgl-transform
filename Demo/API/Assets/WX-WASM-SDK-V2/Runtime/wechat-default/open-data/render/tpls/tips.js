export default function anonymous(it) {
    const out = `<view id="container"> <text class="tips"  value="${it.tips || ''}"></text></view>`;
    return out;
}
