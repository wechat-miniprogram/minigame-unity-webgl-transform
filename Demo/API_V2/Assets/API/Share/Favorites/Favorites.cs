using WeChatWASM;
using System;

public class Favorites : Details
{
    private bool _isListeningAddToFavorites = false;
    private readonly Action<Action<OnAddToFavoritesListenerResult>> _onAddToFavorites = (
    callback
) =>
{
    callback(
        new OnAddToFavoritesListenerResult
        {
            title = "收藏标题",
            imageUrl = "xx",
            query = "key1=val1&key2=val2",
            disableForward = false
        }
    );
};
    protected override void TestAPI(string[] args)
    {
        onAddToFavorites();
    }
    private void Start()
    {
        //GameManager.Instance.detailsController.BindExtraButtonAction(0, onAddToFavorites);
    }
    public void onAddToFavorites()
    {
        if (!_isListeningAddToFavorites)
        {
            WX.OnAddToFavorites(_onAddToFavorites);
        }
        else
        {
            WX.OffAddToFavorites(_onAddToFavorites);
        }
        _isListeningAddToFavorites = !_isListeningAddToFavorites;
        GameManager.Instance.detailsController.ChangeInitialButtonText(
            _isListeningAddToFavorites ? "取消监听收藏" : "开始监听收藏"
        );
    }
}
