#if UNITY_EDITOR

namespace BuildReportTool.Window
{
	public static class Settings
	{
		// GUI Settings
		public const string DEFAULT_GUI_SKIN_FILENAME = "BuildReportWindow.guiskin";
		public const string DARK_GUI_SKIN_FILENAME = "BuildReportWindowDark.guiskin";

		// list normal is a list style with normal font size
		public const string LIST_NORMAL_STYLE_NAME = "ListNormal";
		public const string LIST_NORMAL_ALT_STYLE_NAME = "ListAltNormal";

		// list normal is a list style with normal font size
		public const string LIST_ICON_STYLE_NAME = "ListIcon";
		public const string LIST_ICON_ALT_STYLE_NAME = "ListAltIcon";

		// list small is a list style with smaller font size (for the asset list)
		public const string LIST_SMALL_STYLE_NAME = "List";
		public const string LIST_SMALL_ALT_STYLE_NAME = "ListAlt";
		public const string LIST_SMALL_SELECTED_NAME = "ListAltSelected";


		public const string TOOLBAR_LEFT_STYLE_NAME = "ToolbarLeft";
		public const string TOOLBAR_MIDDLE_STYLE_NAME = "ToolbarMiddle";
		public const string TOOLBAR_RIGHT_STYLE_NAME = "ToolbarRight";


		public const string TAB_LEFT_STYLE_NAME = "TabLeft";
		public const string TAB_MIDDLE_STYLE_NAME = "TabMiddle";
		public const string TAB_RIGHT_STYLE_NAME = "TabRight";

		public const string STATUS_BAR_BG_STYLE_NAME = "StatusBarBg";
		public const string STATUS_BAR_LABEL_STYLE_NAME = "StatusBarLabel";

		public const string VERSION_STYLE_NAME = "Version";


		public const string TOP_BAR_LABEL_STYLE_NAME = "TopBarLabel";
		public const string TOP_BAR_BTN_STYLE_NAME = "TopBarButton";
		public const string TOP_BAR_BG_STYLE_NAME = "TopBarBg";


		public const string LIST_COLUMN_HEADER_STYLE_NAME = "ListColumnHeader";
		public const string LIST_COLUMN_HEADER_ASC_STYLE_NAME = "ListColumnHeader-Asc";
		public const string LIST_COLUMN_HEADER_DESC_STYLE_NAME = "ListColumnHeader-Desc";


		public const string FILE_FILTER_POPUP_STYLE_NAME = "TopBarPopup";


		public const string LIST_FILENAME_STYLE = "button";
		public const string LIST_FILEPATH_STYLE = "button";

		public const string HIDDEN_SCROLLBAR_STYLE_NAME = "HiddenScrollbar";

		public const string MAIN_TITLE_STYLE_NAME = "Title";
		public const string MAIN_SUBTITLE_STYLE_NAME = "Subtitle";
		public const string TINY_HELP_STYLE_NAME = "TinyHelp";

		public const string BOXED_LABEL_STYLE_NAME = "Text-Boxed";

		public const string INFO_TITLE_STYLE_NAME = "Big1";

		public const string INFO_SUBTITLE_STYLE_NAME = "Header2";
		public const string INFO_SUBTITLE_BOLD_STYLE_NAME = "Header2Bold";

		public const string BIG_NUMBER_STYLE_NAME = "Big2";

		public const string INFO_TEXT_STYLE_NAME = "TextInfo";

		public const string SETTING_NAME_STYLE_NAME = "TextBold";
		public const string SETTING_VALUE_STYLE_NAME = "Text";

		public const float CATEGORY_VERTICAL_SPACING = 40;
		public const float CATEGORY_HORIZONTAL_SPACING = 30;


		public const string BIG_LEFT_ARROW_ICON_STYLE_NAME = "Icon-ArrowBig-Left";
		public const string BIG_RIGHT_ARROW_ICON_STYLE_NAME = "Icon-ArrowBig-Right";
	}
}

#endif