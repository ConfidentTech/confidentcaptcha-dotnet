using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI;

using ConfidentTechnologies.Captcha;

namespace CaptchaSite
{
	public partial class Single : System.Web.UI.Page
	{
		public static string SingleCaptcha()
		{
			Dictionary<string, string> credentials = new Dictionary<string, string>();
			credentials["api_username"] = ConfigurationSettings.AppSettings["api_username"];
			credentials["api_password"] = ConfigurationSettings.AppSettings["api_password"];
			credentials["customer_id"] = ConfigurationSettings.AppSettings["customer_id"];
			credentials["site_id"] = ConfigurationSettings.AppSettings["site_id"];
			string api_url = ConfigurationSettings.AppSettings["api_url"];

			VisualCaptchaSettings cap_settings = new VisualCaptchaSettings();
			cap_settings.include_audio = ConfigurationSettings.AppSettings["include_audio"];
			HttpWebResponse resp = CaptchaLib.create_captcha(credentials, cap_settings, 
				HttpContext.Current.Request.UserHostAddress,
				HttpContext.Current.Request.UserAgent, api_url);
			
			return new StreamReader(resp.GetResponseStream()).ReadToEnd().ToString();
		}
		
		public static string CheckCaptcha(string captcha_id, string code)
		{
			Dictionary<string, string> credentials = new Dictionary<string, string>();
			credentials["api_username"] = ConfigurationSettings.AppSettings["api_username"];
			credentials["api_password"] = ConfigurationSettings.AppSettings["api_password"];
			credentials["customer_id"] = ConfigurationSettings.AppSettings["customer_id"];
			credentials["site_id"] = ConfigurationSettings.AppSettings["site_id"];
			string api_url = ConfigurationSettings.AppSettings["api_url"];
			
			HttpWebResponse resp = CaptchaLib.check_captcha(credentials, 
				captcha_id, code, api_url);
			
			string successful = new StreamReader(
				resp.GetResponseStream()).ReadToEnd().ToString();
			return "<p>CAPTCHA solution was " + 
				((successful=="True")?"correct":"incorrect") +". Click above to try " + 
				"another, or go back to the <a href=\"/\">config check</a>.</p>";
		}
	}
}