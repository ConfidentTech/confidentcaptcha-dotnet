
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI;

using ConfidentTechnologies.Captcha;

namespace CaptchaSite
{
	public class Callback : System.Web.IHttpHandler
	{
		public virtual bool IsReusable {
			get { return false; }
		}

		public virtual void ProcessRequest(HttpContext context)
		{
			string api_url = ConfigurationSettings.AppSettings["api_url"];
			string block_id = context.Request.Params["block_id"];
			HttpWebResponse resp;
			switch (context.Request.Params["endpoint"])
			{
			case "block_onekey_start":
				string phone = context.Request.Params["phone_number"];
				
				resp = CaptchaLib.create_block_audio(block_id, 
					phone, api_url);
				string onekey_id = new StreamReader(
				resp.GetResponseStream()).ReadToEnd().ToString();
				string xml = string.Format("<?xml version=\"1.0\"?>\n<response>" +
					"<status>{0:d}</status><onekey_id>{1}</onekey_id></response>",
					resp.StatusCode, onekey_id);
				context.Response.AddHeader("Content-type", "text/xml");
				context.Response.Write(xml);
				return;
			
			
			case "block_onekey_verify":
				string audio_id = context.Request.Params["captcha_id"];
				resp = CaptchaLib.check_block_audio(block_id, audio_id, api_url);
				context.Response.ContentType = "text/xml";
				context.Response.Write(new StreamReader(
					resp.GetResponseStream()).ReadToEnd().ToString());
				return;
			
			
			case "create_block":
				Dictionary<string, string> credentials = new Dictionary<string, string>();
				credentials["api_username"] = ConfigurationSettings.AppSettings["api_username"];
				credentials["api_password"] = ConfigurationSettings.AppSettings["api_password"];
				credentials["customer_id"] = ConfigurationSettings.AppSettings["customer_id"];
				credentials["site_id"] = ConfigurationSettings.AppSettings["site_id"];
				resp = CaptchaLib.create_block(credentials, 
					HttpContext.Current.Request.UserHostAddress, 
					HttpContext.Current.Request.UserAgent, api_url);

				context.Response.Write(new StreamReader(
					resp.GetResponseStream()).ReadToEnd().ToString());
				return;
			
			
			case "create_captcha_instance":
				VisualCaptchaSettings cap_settings = new VisualCaptchaSettings(
					ConfigurationSettings.AppSettings);
				resp = CaptchaLib.create_instance(block_id, cap_settings, api_url);
				if (resp.StatusCode == HttpStatusCode.Gone) {
					context.Response.StatusCode = 410;
					context.Response.StatusDescription = "Gone";
					return;
				}
				context.Response.Write(new StreamReader(
					resp.GetResponseStream()).ReadToEnd().ToString());
				return;
			
			
			case "verify_block_captcha":
				string code = context.Request.Params["code"];
				string captcha_id = context.Request.Params["captcha_id"];
				resp = CaptchaLib.check_instance(block_id, captcha_id, code, api_url);
				string vbcStr = new StreamReader(
				resp.GetResponseStream()).ReadToEnd().ToString();
				if (resp.StatusCode == HttpStatusCode.OK && vbcStr == "True") {
					context.Response.Write("true");
					return;
				}
				context.Response.Write("false");
				return;
			
			
			default:
				break;
			}
		}
	}
}
