using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sage.Common.Contexts;
using Sage.MMS.SAA.Client;

namespace WebService1
{
    //#region StartSample
	public class Sage200Context
	{
		private static Sage.Accounting.Application _application = new Sage.Accounting.Application();

		public static string OpenSession(string user, string password, string companyName)
		{
			string sessionID = string.Empty;

			using (ImpersonationScope scope = new ImpersonationScope(user, password))
			{
				SAAClientAPI.Logon(SessionSourceEnum.Web);
				List<Company> companies = SAAClientAPI.CompaniesGet();

				foreach (Company company in companies)
				{
					if (string.Compare(company.CompanyName, companyName) == 0)
					{
						SAAClientAPI.ConnectCompany(company);
						sessionID = Sage.Common.Contexts.SessionContextValues.SessionID;

						break;
					}
				}
			}

			return sessionID;
		}


		public static void CloseSession(string sessionID)
		{
			SAAClientAPI.SetSessionContext(sessionID);
			SAAClientAPI.DisconnectCompany();
			SAAClientAPI.Logoff();
		}
	}
    //#endregion StartSample
}