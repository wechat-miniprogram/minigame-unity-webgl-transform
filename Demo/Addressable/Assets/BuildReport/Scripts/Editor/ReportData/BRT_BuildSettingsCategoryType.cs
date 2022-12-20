namespace BuildReportTool
{
	public enum BuildSettingCategory
	{
		None = 0,

		WindowsDesktopStandalone = 10,
		WindowsStoreApp,
		MacStandalone = 20,
		LinuxStandalone = 25,

		WebPlayer = 30,
		FlashPlayer,
		WebGL,

		iOS = 40,
		Android = 50,
		Blackberry = 60,
		WindowsPhone8,
		Tizen,

		Xbox360 = 70,
		XboxOne,

		PS3 = 80,
		PS4,
		PSVita,
		PSM,

		SamsungTV = 90,
	}
}