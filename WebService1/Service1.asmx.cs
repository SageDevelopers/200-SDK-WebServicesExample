using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Sage.MMS.SAA.Client;
using Sage.Accounting.SalesLedger;

namespace WebService1
{
    //#region StartSample
	/// <summary>
	/// Summary description for Service1
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class Service1 : System.Web.Services.WebService
	{

		[WebMethod]
		public string OpenSession(string user, string password, string company)
		{
			return Sage200Context.OpenSession(user, password, company);
		}


		[WebMethod]
		public void CloseSession(string sessionID)
		{
			Sage200Context.CloseSession(sessionID);
		}


		[WebMethod]
		public string FetchCustomer(string sessionID, string reference)
		{
			string value = string.Empty;

			SAAClientAPI.SetSessionContext(sessionID);

			Customer customer = CustomerFactory.Factory.Fetch(reference);

			value = "Ref=" + customer.Reference + ", name=" + customer.Name;

			return value;
		}
	}
    //#endregion StartSample
}