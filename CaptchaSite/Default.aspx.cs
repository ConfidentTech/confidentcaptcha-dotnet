using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web.UI;

using ConfidentTechnologies.Captcha;

namespace CaptchaSite
{
	public partial class Default : System.Web.UI.Page
	{
		public static string CheckSettings()
		{
			Dictionary<string, string> credentials = 
				new Dictionary<string, string>();
			credentials["api_username"] = ConfigurationSettings.AppSettings["api_username"];
			credentials["api_password"] = ConfigurationSettings.AppSettings["api_password"];
			credentials["customer_id"] = ConfigurationSettings.AppSettings["customer_id"];
			credentials["site_id"] = ConfigurationSettings.AppSettings["site_id"];
			string api_url = ConfigurationSettings.AppSettings["api_url"];

			HttpWebResponse resp = CaptchaLib.check_credentials(credentials, api_url);
			return new StreamReader(resp.GetResponseStream()).ReadToEnd().ToString();	
		}
	}
}