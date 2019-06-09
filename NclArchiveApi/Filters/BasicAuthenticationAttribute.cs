using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace NclArchiveApi.Filters
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        private readonly string _password = WebConfigurationManager.AppSettings["ApiPassword"];
        private readonly string _message = "This API is password protected.  " +
                                           "Put the password in the Basic Auth of the HTTP request (username can be any value).";

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (SkipAuthorization(actionContext)) return;

            AuthenticationHeaderValue authenticationHeaderValue = actionContext.Request.Headers.Authorization;

            if (authenticationHeaderValue != null)
            {
                string userNamePasswordString = authenticationHeaderValue == null ? ":" :
                    Encoding.UTF8.GetString(Convert.FromBase64String(authenticationHeaderValue.Parameter));

                string username = userNamePasswordString.Split(':')[0];
                string password = userNamePasswordString.Split(':')[1];

                if (password == _password)
                {
                    return;
                }
            }

            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, _message);
        }

        private static bool SkipAuthorization(HttpActionContext actionContext)
        {
            Contract.Assert(actionContext != null);

            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
                   || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }
    }
}