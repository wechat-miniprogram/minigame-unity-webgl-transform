// 通过插件的方式引用 Layout
const Layout = requirePlugin('Layout').default;
const sharedCanvas = wx.getSharedCanvas();
const sharedContext = sharedCanvas.getContext('2d');
const style = {
    container: {
        width: '100%',
        height: '100%',
        justifyContent: 'center',
        alignItems: 'center',
    },
    loading: {
        width: 150,
        height: 150,
        borderRadius: 75,
    },
};
const tpl = `
<view id="container">
  <image src="open-data/render/image/loading.png" id="loading"></image>
</view>
`;
export function showLoading() {
    Layout.clear();
    Layout.init(tpl, style);
    Layout.layout(sharedContext);
    const image = Layout.getElementById('loading');
    let degrees = 0;
    Layout.ticker.add(() => {
        degrees = (degrees + 2) % 360;
        image.style.transform = `rotate(${degrees}deg)`;
    });
}
