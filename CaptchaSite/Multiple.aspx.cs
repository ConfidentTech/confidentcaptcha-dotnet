using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI;

using ConfidentTechnologies.Captcha;

namespace CaptchaSite
{
	public partial class Multiple : System.Web.UI.Page
	{
		public static string MultipleCaptcha()
		{
			Dictionary<string, string> credentials = new Dictionary<string, string>();
			credentials["api_username"] = ConfigurationSettings.AppSettings["api_username"];
			credentials["api_password"] = ConfigurationSettings.AppSettings["api_password"];
			credentials["customer_id"] = ConfigurationSettings.AppSettings["customer_id"];
			credentials["site_id"] = ConfigurationSettings.AppSettings["site_id"];
			string api_url = ConfigurationSettings.AppSettings["api_url"];
			
			HttpWebResponse resp = CaptchaLib.create_block(credentials, HttpContext.Current.Request.UserHostAddress, HttpContext.Current.Request.UserAgent, api_url);
			string block_id = new StreamReader(resp.GetResponseStream()).ReadToEnd().ToString();
			
			VisualCaptchaSettings cap_settings = new VisualCaptchaSettings();
			cap_settings.include_audio = ConfigurationSettings.AppSettings["include_audio"];
			resp = CaptchaLib.create_instance(block_id, cap_settings, api_url);
			
			return new StreamReader(resp.GetResponseStream()).ReadToEnd().ToString();
		}
	}
}