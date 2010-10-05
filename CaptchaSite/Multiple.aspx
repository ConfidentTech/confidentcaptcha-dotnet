<%@ Page Language="C#" Inherits="CaptchaSite.Multiple" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
<head runat="server">
  <title>Multiple CAPTCHA</title>
</head>
<body>
  <p>
    This is a sample page for the multiple method of Confident CAPTCHA.
    If this were a real page, then this would be part of a form, such as a 
    sign-up form, a blog comment form, or some other page where you want to 
    prove that the user is human before allowing them access.
  </p>
  <p>
    <b>The multiple method is incomplete</b>.  More work is needed to:
  </p>
  <ol>
    <li>Flesh out this example with a complete form</li>
    <li>Add a server-side session data store</li>
    <li>Initialize the CAPTCHA state in the data store at creation</li>
    <li>Update the CAPTCHA state when the callback is called</li>
    <li>Check the CAPTCHA state when the form is posted</li>
    store hasn't been implemented, so the library is not usable as-is.
  </ol>
  <p>
    At this time, we do not recommend using the multiple method in your
    own project.  Use the single method instead.
  </p>
  <p>
    When you solve the CAPTCHA below, it will immediately confirm if the
    CAPTCHA is correct.  If you fail it the first time, a new CAPTCHA will
    be generated without refreshing the page.
  </p>
  <script type='text/javascript'>
    var CALLBACK_URL = 'Callback.ashx';
    var INCLUDE_AUDIO = true;
  </script> 
  <script type='text/javascript' src='http://code.jquery.com/jquery-1.4.2.min.js'></script>
  <%= MultipleCaptcha() %>
</body>
</html>