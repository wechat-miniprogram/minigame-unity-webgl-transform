namespace WeChatWASM
{
    public interface IWXAdResizable
    {
        void OnResizeCallback(WXADResizeResponse res);
    }

    public interface IWXAdVideoCloseable
    {
        void OnCloseCallback(WXRewardedVideoAdOnCloseResponse res);
    }

    public interface IWXADCloseable
    {
        void OnCloseCallback();
    }

}
