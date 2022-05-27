namespace WeChatWASM
{

    public class WXAdBaseStyle
    {
        // 这个类是为了和JS的API保持一致的调用方法
        private Style style;
        private string ADId;

        public WXAdBaseStyle(string id, Style style)
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
        public int width
        {
            get
            {
                return style.width;
            }
            set
            {
                style.width = value;
                WXSDKManagerHandler.Instance.ADStyleChange(ADId, "width", value);
            }
        }
        public int height
        {
            get
            {
                return style.height;
            }
            set
            {
                style.height = value;
                WXSDKManagerHandler.Instance.ADStyleChange(ADId, "height", value);
            }
        }

        public int realHeight
        {
            get
            {
                return WXSDKManagerHandler.Instance.ADGetStyleValue(ADId, "realHeight");
            }
        }

        public int realWidth
        {
            get
            {
                return WXSDKManagerHandler.Instance.ADGetStyleValue(ADId, "realWidth");
            }
        }

    }
}
