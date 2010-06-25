<%@ Page Language="C#" Inherits="CaptchaSite.Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
<head runat="server">
	<title>Confident CAPTCHA</title>
</head>
<body>
  <p>Welcome to the Confident CAPTCHA .NET sample code.  The table below 
  details if your configuration is supported by Confident CAPTCHA.  Local settings
  are set in <tt>web.config</tt>, and remote settings come from
  <a href="http://captcha.confidenttechnologies.com/">captcha.confidenttechnologies.com</a>.</p>

  <%= CheckSettings() %>
  
  <p>There are two CAPTCHA configurations available:</p>
  <ul>
    <li><a href="Single.aspx">Single CAPTCHA Method</a> - One CAPTCHA attempt, checked at form submit</li>
    <li><a href="Multiple.aspx">Multiple CAPTCHA Method</a> - Multiple CAPTCHA attempts, checked at CAPTCHA completion</li>
  </ul>

</body>
</html>