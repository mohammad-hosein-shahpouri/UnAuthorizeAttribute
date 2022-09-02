# UnAuthorizeAttribute
This Library allows User to access the Controller or Actions if they aren't signed in (Works Opposite of Authorize Attribute)

## Usage

```C#
using UnAuthorizeAttribute;

[UnAuthorize]
Public class LoginController : Controller {} //redirects to /home/index

[UnAuthorize("https://www.google.com/")]
Public class LoginController : Controller {} //redirects to google.com
[UnAuthorize(Url = "https://www.google.com/")]
Public class LoginController : Controller {} //redirects to google.com

[UnAuthorize("Controller","Action","Area")]
Public class LoginController : Controller {} //redirects to /Area/Controller/Action
[UnAuthorize(Area ="Area",Controller = "Controller", Action = "Action")]
Public class LoginController : Controller {} //redirects to /Area/Controller/Action

[UnAuthorize("Controller","Action")]
Public class LoginController : Controller {} //redirects to /Controller/Action
[UnAuthorize(Controller = "Controller", Action = "Action")]
Public class LoginController : Controller {} //redirects to /Controller/Action
```
