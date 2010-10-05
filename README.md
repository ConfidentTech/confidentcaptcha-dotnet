.NET Library and Sample Code for Confident CAPTCHA
==================================================
version 20100610_DOTNET.0.1

Thank you for downloading this library and sample code.

REQUIREMENTS
------------
 * The sample requires a Mono or .NET runtime environment version 3.5 or 
   later.
 * The page that renders the Confident CAPTCHA requires jQuery 1.4.2.

USAGE
-----

  1. Sign up for Confident CAPTCHA at:
     <http://confidenttechnologies.com/purchase/CAPTCHA_signup.php>
  2. Create an account at: <https://login.confidenttechnologies.com>
  3. Modify web.config, filling in the API credentials from:
     <https://login.confidenttechnologies.com/dashboard/sites/>
  4. Try out the sample code
  5. Integrate the library into your code.  You need to compile CaptchaLib.cs
     and a (customized) web.config in your project.  Look at Default.aspx and
     Single.aspx for integration ideas. Be sure to include jQuery in your 
     page.

Please send your questions and feedback to:
<https://login.confidenttechnologies.com/dashboard/contactus/general/>

FILES
-----
The included files are:

 * README.TXT - This document
 * CaptchaLib/CaptchaLib.sln - The Visual Studio or MonoDevelop solution file
 * CaptchaLib/Captcha.csproj - The Visual Studio or MonoDevelop project file
   for the Captcha Library
 * CaptchaLib/CaptchaLib.cs - The Captcha Library source code
 * CaptchaSite/CaptchaSite.csproj - The Visual Studio or MonoDevelop project
   file for the .NET Sample website
 * CaptchaSite/Callback.ashx - The ASP code for the Callback handler
 * CaptchaSite/Callback.ashx.cs - The code-behind for the Callback handler
 * CaptchaSite/Default.aspx - The ASP code for the configuration check page
 * CaptchaSite/Default.aspx.cs - the code-behind for the configuration check
   page
 * CaptchaSite/Multiple.aspx - The ASP code for the /block -based 
   multiple-captcha sample
 * CaptchaSite/Multiple.aspx.cs - The code-behind for the multiple-captcha 
   sample
 * CaptchaSite/Single.aspx - The ASP code for the for the /captcha -based 
   single-captcha sample
 * CaptchaSite/Single.aspx.cs - The code-behind for the single-captcha sample
 * CaptchaSite/web.config - The configuration file

VERSION HISTORY
---------------
- 20100610_DOTNET_0.1 - October 4th, 2010
  * Make configuration clearer
  * Add notes to Multiple method saying that it isn't complete

- 20100610_DOTNET - June 10th, 2010
  * Original release
