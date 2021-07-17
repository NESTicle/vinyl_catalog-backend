using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Diagnostics;
using System.Net;
using VinylCollection.Data.Models.Security;
using VinylCollection.Domain.Helper;
using VinylCollection.Domain.Transversal;
using VinylCollection.Service.Interfaces;

namespace VinylCollection.Web.Helper
{
    public class SecurityFilter : IActionFilter
    {
        private string _functionality;
        private Stopwatch _stopWatch;
        private readonly IUserService _userService;
        private IAppPrincipal _appPrincipal { get; }

        public SecurityFilter(string functionality, IUserService userService, IAppPrincipal appPrincipal)
        {
            _functionality = functionality;
            _userService = userService;
            _appPrincipal = appPrincipal;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                _stopWatch = Stopwatch.StartNew();

                if (_functionality == "All")
                    return;

                string Controller = context.RouteData.Values["Controller"].ToString().ToLower();
                string Action = context.RouteData.Values["Action"].ToString().ToLower();

                string bearer = context.HttpContext.Request.Headers["Authorization"];

                if (bearer == null || string.IsNullOrEmpty(bearer.ToString()))
                {
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    context.Result = new UnauthorizedResult();

                    return;
                }

                string jwtUniqueName = JwtHelper.GetUniqueName(bearer);

                if (jwtUniqueName == null)
                {
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
                    context.Result = new ForbidResult();

                    return;
                }
                
                var user = _userService.GetUserByUserName(jwtUniqueName);

                if (_functionality == "Jwt")
                {

                    if (user == null)
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        context.Result = new ForbidResult();
                    }

                    SetUserInfoToAppPrincipal(user);

                    return;
                }

                SetUserInfoToAppPrincipal(user);

                //UserTokens userToken = _securityService.GetUserTokenByUserId(user._id.ToString());

                //if (userToken == null || DateTime.Compare(DateTime.Now, userToken.ExpirationDate) > 0)
                //{
                //    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                //    context.Result = new ForbidResult();

                //    return;
                //}

                //if (user.Modules == null || user.Modules.Count < 1)
                //{
                //    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
                //    context.Result = new ForbidResult();

                //    return;
                //}

                //var hasPermissions = user.Modules.Where(x => x.Components.Any(a => a.Name.Replace(" ", string.Empty).ToLower() == Controller && a.Actions.Any(ac => ac.Name == _functionality))).ToList();

                //if (hasPermissions == null || hasPermissions.Count < 1)
                //{
                //    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
                //    context.Result = new ForbidResult();

                //    return;
                //}

                //base.OnActionExecuting(context);
            }
            catch (Exception e)
            {
                context.Result = new StatusCodeResult((int)HttpStatusCode.Unauthorized);
                throw e;
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            _stopWatch.Stop();

            if (filterContext.Exception == null)
            {
                filterContext.HttpContext.Response.Headers.Add("ExecutionTime", _stopWatch.Elapsed.TotalSeconds.ToString());
            }
        }

        private void SetUserInfoToAppPrincipal(User user)
        {
            _appPrincipal.Id = user.Id;
            _appPrincipal.UserName = user.UserName;
        }
    }
}
