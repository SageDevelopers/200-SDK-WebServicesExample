using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Web;

namespace WebService1
{
	/// <summary>
	/// Create an impersonation scope for the user specified allowing for the specified windows user
	/// to use the Sage 200 API when running n a remote client via WMI.
	/// </summary>

 
    //#region StartSample
	internal class ImpersonationScope : IDisposable
	{
		// Obtains a user token
		[DllImport("advapi32.dll", SetLastError = true)]
		public static extern bool LogonUser(string pszUsername, string pszDomain, string pszPassword,
			int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

		// Closes open handles returned by LogonUser
		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		public extern static bool CloseHandle(IntPtr handle);

		/// <summary>
		/// The windows impersonation context we are using
		/// </summary>
		private WindowsImpersonationContext _context;

		private WindowsPrincipal _oldPrincipal = null;

		/// <summary>
		/// Constructor for impersonation scope which will create the scope
		/// </summary>
		/// <param name="user">The windows user name</param>
		/// <param name="password">The windows user password</param>
		public ImpersonationScope(string user, string password)
		{
			char[] div = new char[] { '\\' };

			string[] split = user.Split(div);

			string domain = string.Empty;

			if (split.Length > 1)
			{
				domain = split[0];
				user = split[1];
			}

			// HttpContext contains user if service is using Windows Authentication, or Impersonation.
			// Should be doing neither of these if we are performing further impersonation within the service.
			if (HttpContext.Current != null)
			{
				_oldPrincipal = HttpContext.Current.User as WindowsPrincipal;

				if (_oldPrincipal != null)
				{
					HttpContext.Current.User = null;
				}
			}

			System.Diagnostics.Debug.WriteLine("Identity before impersonation = " + WindowsIdentity.GetCurrent().Name);

			_context = CreateImpersonationContext(domain, user, password);

			System.Diagnostics.Debug.WriteLine("Identity after impersonation = " + WindowsIdentity.GetCurrent().Name);
		}


		/// <summary>
		/// Create the windows impersonation context
		/// </summary>
		/// <param name="domain">The windows domain name</param>
		/// <param name="user">The windows user name</param>
		/// <param name="password">The windows user password</param>
		/// <returns>The impersonation context</returns>
		private static WindowsImpersonationContext CreateImpersonationContext(string domain, string user, string password)
		{
			// Elevate privileges before doing file copy to handle domain security
			WindowsImpersonationContext impersonationContext = null;
			IntPtr userHandle = IntPtr.Zero;
			const int LOGON32_PROVIDER_DEFAULT = 0;
			const int LOGON32_LOGON_INTERACTIVE = 2;

			try
			{
				// Call LogonUser to get a token for the user
				bool loggedOn = LogonUser(user,
											domain,
											password,
											LOGON32_LOGON_INTERACTIVE,
											LOGON32_PROVIDER_DEFAULT,
											ref userHandle);

				if (!loggedOn)
				{
					throw new System.Exception("Exception impersonating user, error code: " + Marshal.GetLastWin32Error());
				}

				// Begin impersonating the user
				impersonationContext = WindowsIdentity.Impersonate(userHandle);
			}
			catch (Exception ex)
			{
				throw new System.Exception(string.Format("Exception impersonating user '{0}' with password '{1}' on domain '{2}': {3}",
					user, password, domain, ex.Message));
			}
			finally
			{
				if (userHandle != IntPtr.Zero)
				{
					CloseHandle(userHandle);
				}
			}

			return impersonationContext;
		}


		/// <summary>
		/// Dispose of the windows impersonation context
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
		}


		/// <summary>
		/// Dispose of the windows impersonation context
		/// </summary>
		/// <param name="isDisposing">True if called from Dispose(), false if called from the finaliser.</param>
		protected virtual void Dispose(bool isDisposing)
		{
			if (_context != null)
			{
				_context.Undo();
				_context = null;
			}

			if (_oldPrincipal != null)
			{	
				if (HttpContext.Current != null)
				{
					HttpContext.Current.User = _oldPrincipal;
				}
			}
		}
	}
    //#endregion StartSample
}