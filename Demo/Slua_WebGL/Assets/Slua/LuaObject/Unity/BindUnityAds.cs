using System;
using System.Collections.Generic;
namespace SLua {
	[LuaBinder(2)]
	public class BindUnityAds {
		public static Action<IntPtr>[] GetBindList() {
			Action<IntPtr>[] list= {
			};
			return list;
		}
	}
}
