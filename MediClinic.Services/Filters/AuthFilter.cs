using MedliClinic.Utilities.Utility.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Filters
{
    public class AuthFilter : ActionFilterAttribute
    {
        public string[] Roles { get; set; }
        public AuthFilter(params string[] roles)
        {
            this.Roles = roles;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var roleId = context.HttpContext.Session.GetString(SessionNames.RoleId);

            if (context.HttpContext.Session.GetString(SessionNames.UserId) == null)
            {
                string[] excludePath = { "/Auth/AuthUser" };

                if (!excludePath.Contains(context.HttpContext.Request.Path.Value))
                {
                    bool isAjaxCall = context.HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest";
                    
                    if(!isAjaxCall)
                    {
                        context.Result = new RedirectToRouteResult("Default",
                           new RouteValueDictionary{
                                {"controller", "Auth"},
                                {"action", "AuthUser"},
                                {"returnUrl", context.HttpContext.Request.Path.Value}
                           });
                    }
                }
            }
            else
            {
                if ("/Auth/AuthUser".Equals(context.HttpContext.Request.Path.Value))
                {
                    if (roleId.Equals(1))
                    {
                       context.Result = new RedirectToRouteResult("Default",
                        new RouteValueDictionary{
                            {"controller", "Home"},
                            {"action", "Patient"}
                        });
                    }
                    else if (roleId.Equals(2))
                    {
                        context.Result = new RedirectToRouteResult("Default",
                        new RouteValueDictionary{
                            {"controller", "Home"},
                            {"action", "Index"}
                        });
                    }
                }
                else
                {
                    if (!Roles.Contains(roleId))
                    {
                        context.Result = new RedirectToRouteResult("Default",
                               new RouteValueDictionary{
                                {"controller", "Error"},
                                {"action", "AccessDenied"},
                                {"returnUrl", context.HttpContext.Request.Path.Value}
                               });
                    }
                }
                
            }

            base.OnActionExecuting(context);    
        }

    }
}
