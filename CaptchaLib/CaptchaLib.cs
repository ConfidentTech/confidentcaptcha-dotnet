/*=============================================================
Chad Blomquist
(c) 2010 by Confident Technologies, Inc.
All rights reserved.
================================================================*/

using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System;
using System.Configuration;

namespace ConfidentTechnologies.Captcha
{
	public class CaptchaLib
	{
		static HttpWebResponse call (string url, string method, 
			Dictionary<string, string> parameters)
		{
			Dictionary<string, string> p;
			if (parameters != null) {
				p = new Dictionary<string, string> (parameters);
			}
			else {
				p = new Dictionary<string, string> ();
			}
			p["library_version"] = ConfigurationSettings.AppSettings["library_version"];
			string dataStr = "";
			StringBuilder data = new StringBuilder ();
			foreach (KeyValuePair<String, String> entry in p) {
				data.Append (HttpUtility.UrlEncode (entry.Key) + '=' + 
					HttpUtility.UrlEncode (entry.Value) + '&');
			}
			dataStr = data.ToString ().Trim ("&".ToCharArray ());
			if (method == "GET") {
				url += "?" + dataStr;
			}
			HttpWebRequest req = (HttpWebRequest)WebRequest.Create (url);
			req.Method = method;
			
			if (method == "POST") {
				byte[] byteData = UTF8Encoding.UTF8.GetBytes (dataStr);
				req.ContentLength = byteData.Length;
				req.ContentType = "application/x-www-form-urlencoded";
				req.GetRequestStream ().Write (byteData, 0, byteData.Length);
			}
			
			try {
				return (HttpWebResponse)req.GetResponse();
			} catch (WebException ex) {
				return (HttpWebResponse)ex.Response;
			}
		}

		
		
		public static HttpWebResponse check_credentials (
			Dictionary<string,string> credentials, string api_url)
		{
			return call (api_url + "/check_credentials", "GET", credentials);
		}
		
		
		
		public static HttpWebResponse create_block (
			Dictionary<string, string> credentials, string ipaddr, 
			string user_agent, string api_url)
		{
			Dictionary<string, string> parameters = 
				new Dictionary<string, string> (credentials);
			
			parameters["ip_addr"] = ipaddr;
			parameters["user_agent"] = user_agent;
			return call(api_url + "/block", "POST", parameters);
		}

		
		
		public static HttpWebResponse create_instance (string block_id,
			VisualCaptchaSettings settings, string api_url)
		{
			string url = api_url + "/block/" + block_id + "/visual";
			return call(url, "POST", settings.get_dict());
		}
		
		
		
		
		public static HttpWebResponse check_instance (string block_id, 
			string captcha_id, string code, string api_url)
		{
			Dictionary<string, string> parameters = 
				new Dictionary<string, string> ();
			parameters["code"] = code;
			string url = string.Format (api_url + "/block/{0}/visual/{1}",
				block_id, captcha_id);
			return call (url, "POST", parameters);
		}
		
		
		
		public static HttpWebResponse create_block_audio (string block_id, 
			string phone_number, string api_url)
		{
			Dictionary<string, string> parameters = 
				new Dictionary<string, string> ();
			parameters["phone_number"] = phone_number;
			string url = string.Format (api_url + "/block/{0}/audio",
				block_id);
			return call (url, "POST", parameters);
		}

		
		
		public static HttpWebResponse check_block_audio (string block_id, 
			string captcha_id, string api_url)
		{
			string url = string.Format (api_url + "/block/{0}/audio/{1}",
				block_id, captcha_id);
			return call (url, "GET", null);
		}




		public static HttpWebResponse create_captcha (
			Dictionary<string, string> credentials, 
			VisualCaptchaSettings settings, string ipaddr, 
			string user_agent, string api_url)
		{
			Dictionary<string, string> parameters = 
				new Dictionary<string, string> (settings.get_dict ());
			foreach (string key in credentials.Keys) {
				parameters.Add (key, credentials[key]);
			}
			parameters.Add ("ip_addr", ipaddr);
			parameters.Add ("user_agent", user_agent);
			
			string url = api_url + "/captcha";
			return call (url, "POST", parameters);
		}

		
		public static HttpWebResponse check_captcha (
			Dictionary<string, string> credentials, string captcha_id,
			string code, string api_url)
		{
			Dictionary<string, string> parameters = 
				new Dictionary<string, string> (credentials);
			parameters.Add ("code", code);
			string url = api_url + "/captcha/" + captcha_id;
			return call (url, "POST", parameters);
		}

			
			
		public static HttpWebResponse create_audio (
			Dictionary<string, string> credentials, string phone_number,
			string api_url)
		{
			Dictionary<string, string> parameters = 
				new Dictionary<string, string> (credentials);
			parameters["phone_number"] = phone_number;
			string url = api_url + "/onekey";
			return call (url, "POST", parameters);
		}

		public static HttpWebResponse check_audio (
			Dictionary<string, string> credentials, string audio_id, string api_url)
		{
			
			string url = string.Format (api_url + "/onekey/{0}", audio_id);
			return call (url, "POST", credentials);
		}

	}


	public class VisualCaptchaSettings
	{
		public VisualCaptchaSettings(){}
		
		public VisualCaptchaSettings (
			System.Collections.Specialized.NameValueCollection settings)
		{
			string s = settings["display_style"];
			if (s != "") {
				this._display_style = s;
			}
			s = settings["include_audio"];
			if (s != "") {
				this._include_audio = s;
			}
			s = settings["image_code_color"];
			if (s != "") {
				this._image_code_color = s;
			}
			s = settings["height"];
			if (s != "") {
				this._height = int.Parse(s);
			}
			s = settings["width"];
			if (s != "") {
				this._width = int.Parse(s);
			}
			s = settings["captcha_length"];
			if (s != "") {
				this._length = int.Parse(s);
			}
		}
		
		private string _display_style="flyout";
		private string _include_audio="false";
		private string _image_code_color="White";
		private int _width = 3;
		private int _height = 3;
		private int _length = 4;
		
		public Dictionary<string, string> get_dict ()
		{
			Dictionary<string, string> dict = new Dictionary<string, string> ();
			dict["display_style"] = _display_style;
			dict["include_audio_form"] = _include_audio.ToString ();
			dict["image_code_color"] = _image_code_color;
			dict["width"] = _width.ToString ();
			dict["height"] = _height.ToString ();
			dict["captcha_length"] = _length.ToString ();
			return dict;
		}
		
		public string display_style {
			get {
				return _display_style;
			}
			set {
				_display_style = value;
			}
		}
		public string include_audio {
			get {
				return _include_audio;
			}
			set {
				_include_audio = value;
			}
		}
		public string image_code_color {
			get {
				return _image_code_color;
			}
			set {
				_image_code_color = value;
			}
		}
		public int width {
			get {
				return _width;
			}
			set {
				_width = value;
			}
		}
		public int height {
			get {
				return _height;
			}
			set {
				_height = value;
			}
		}
		public int length {
			get {
				return _length;
			}
			set {
				_length = value;
			}
		}
		
	}


}
