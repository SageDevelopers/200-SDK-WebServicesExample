using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebService1
{
	public class Global : System.Web.HttpApplication
	{
		private const string DEFAULT_ASSEMBLY = "Sage.Common.dll";
		private const string ASSEMBLY_RESOLVER = "Sage.Common.Utilities.AssemblyResolver";
		private const string RESOLVER_METHOD = "GetResolver";

        //#region StartSample
		protected void Application_Start(object sender, EventArgs e)
		{
			FindCore200();

			Startup.Init();
		}
        //#endregion StartSample

		protected void Session_Start(object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{

		}

		protected void Application_Error(object sender, EventArgs e)
		{

		}

		protected void Session_End(object sender, EventArgs e)
		{

		}

		protected void Application_End(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// Locates and invokes assemblies from the client folder at runtime.
		/// </summary>
		static void FindCore200()
		{
			// getSage 200 server path from config file
			string path = System.Configuration.ConfigurationManager.AppSettings["Sage200Path"];

			if (string.IsNullOrEmpty(path) == false)
			{
				string commonDllAssemblyName = System.IO.Path.Combine(path, DEFAULT_ASSEMBLY);

				if (System.IO.File.Exists(commonDllAssemblyName))
				{
					System.Reflection.Assembly defaultAssembly = System.Reflection.Assembly.LoadFrom(commonDllAssemblyName);
					Type type = defaultAssembly.GetType(ASSEMBLY_RESOLVER);
					MethodInfo method = type.GetMethod(RESOLVER_METHOD);
					method.Invoke(null, null);
				}
			}
		}
	}
}