namespace WeChatWASM
{

    public class WXAdCustomStyle
    {
        // 这个类是为了和JS的API保持一致的调用方法
        private CustomStyle style;
        private readonly string ADId;


        public WXAdCustomStyle(string id, CustomStyle style)
        {
            ADId = id;
            this.style = style;
        }


        public int left
        {
            get
            {
                return style.left;
            }
            set
            {
                style.left = value;
                WXSDKManagerHandler.Instance.ADStyleChange(ADId, "left", value);
            }
        }
        public int top
        {
            get
            {
                return style.top;
            }
            set
            {
                style.top = value;
                WXSDKManagerHandler.Instance.ADStyleChange(ADId, "top", value);
            }
        }
        public bool isFixed
        {
            get
            {
                return style.isFixed;
            }
            set
            {
                style.isFixed = value;
                WXSDKManagerHandler.Instance.ADStyleChange(ADId, "fixed", value ? 1 : 0);
            }
        }

    }
}
