using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService1
{
	// Separate class so that we can use Assembly Path resolving to find assembly in sage200services\bin folder
	public static class Startup
	{
		public static void Init()
		{
			Sage.Web.Services.AutoStartProvider.ServiceAutoStart start =
				new Sage.Web.Services.AutoStartProvider.ServiceAutoStart();
			start.Preload(new string[] { });
		}
	}
}