<%@ Page Language="C#" Inherits="CaptchaSite.Single" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
<head runat="server">
	<title>Single CAPTCHA</title>
</head>
<body>
  <p>This is a sample page for the single method of Confident CAPTCHA.
  If this were a real page, then this would be part of a form, such as a sign-up
  form, a blog comment form, or some other page where you want to prove that the
  user is human before allowing them access.</p>
  <p>When you solve the CAPTCHA below, nothing will happen until you submit the
  form.  At that point, the CAPTCHA will be checked.</p>
  <p>Things to try:</p>
  <ol>
    <li>Solve the CAPTCHA, then Submit</li>
    <li>Fail the CAPTCHA, then Submit</li>
  </ol>

  <script type='text/javascript'>
    var CALLBACK_URL = 'Callback.ashx';
    var INCLUDE_AUDIO = true;
  </script> 
  <script type='text/javascript' src='http://code.jquery.com/jquery-1.4.2.min.js'></script>
  <form method="post"runat="server">
    <%= SingleCaptcha() %>
    <input type='submit' name='submit' value='Submit' />
  </form>
  <% if (Request.Params["submit"] == "Submit") {%>  
  <%= CheckCaptcha(Request.Params["captcha_id"], Request.Params["code"]) %>
  <% } %>
</body>
</html>