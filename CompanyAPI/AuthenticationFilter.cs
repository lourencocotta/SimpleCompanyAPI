using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CompanyAPI
{
    public class AuthenticationFilter: ActionFilterAttribute
    {
        [AuthenticationFilter]
        public override void OnActionExecuting (HttpActionContext actionContext)
        {
            if(actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                string userName = decodedToken.Substring(0, decodedToken.IndexOf(":"));
                string userPassword = decodedToken.Substring(decodedToken.IndexOf(":") + 1);
                if (userName.Equals("admin") && userPassword.Equals("admin"))
                { //authorized
                }
                else
                {
                    actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}