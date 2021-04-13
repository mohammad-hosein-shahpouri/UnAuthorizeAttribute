using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;

namespace UnAuthorizeAttribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class UnAuthorizeAttribute : ActionFilterAttribute
    {

        /// <summary>
        /// This Properties Should Be Filled:
        /// Url Property
        /// Or
        /// Action and Controller Properties (Area is not Required)
        /// </summary>

        public string Url { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        /// <summary>
        /// You Can Use Attribute by Filling Properties
        /// Or You Can Use Constructors .
        /// To Use Constructor to Set a Url to Redirect:
        /// [UnAuthorize("https://github.com/mohammad-hosein-shahpouri")] ,
        /// Or You Can Use Constructor to Set a Route to Redirect:
        /// [UnAuthorize("{Controller Name},{Action Name},{Area Name}")] 
        /// Area Name is Not Required and default value is null .
        /// If you fill none of Properties above, Action or Controller Redirects to /home/index .
        /// </summary>
        public UnAuthorizeAttribute()
        {

        }

        public UnAuthorizeAttribute(string Url) => this.Url = Url;

        public UnAuthorizeAttribute(string Controller, string Action, string Area = null)
        {
            this.Area = Area ?? "";
            this.Controller = Controller;
            this.Action = Action;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                base.OnActionExecuting(filterContext);
            else if (Url != null)
                filterContext.Result = new RedirectResult(Url);
            else if (Controller != null && Action != null)
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { area = Area ?? string.Empty, controller = Controller, action = Action }));
            else
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { controller = "Home", action = "Index" }));
        }
    }
}
