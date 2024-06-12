using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Security.Principal;
using System.Web;
using System.Linq;

namespace ShyamDhokiya_557API.JWTAuthentication
{
    public class JwtAuthenticationAttribute : ActionFilterAttribute
    {
     
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var request = actionContext.Request;
            var authHeader = request.Headers.Authorization;

            if (authHeader == null || authHeader.Scheme != "Bearer" || string.IsNullOrEmpty(authHeader.Parameter))
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Authorization header is missing or invalid.");
                return;
            }

            var token = authHeader.Parameter;
            var userName = Authentication.ValidateToken(token);

            if (userName == null)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid token.");
                return;
            }

            base.OnActionExecuting(actionContext);
        }

        /*
                public override void OnAuthorization(HttpActionContext actionContext)
                {
                    var request = actionContext.Request;
                    var headers = request.Headers;

                    // Check if the Authorization header is present
                    if (!headers.Contains("Authorization"))
                    {
                        actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Authorization header is missing.");
                        return;
                    }

                    // Extract the token from the Authorization header
                    var authHeader = headers.GetValues("Authorization").FirstOrDefault();
                    var token = authHeader?.Replace("Bearer ", "");

                    if (string.IsNullOrEmpty(token))
                    {
                        actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Token is missing.");
                        return;
                    }
                    if (token != null)
                    {
                        var Username = Authentication.ValidateToken(token);
                        if (Username != null)
                        {
                            actionContext.Request.Properties["IsTokenValid"] = true;
                        }
                        else
                        {
                            actionContext.Request.Properties["IsTokenValid"] = false;
                        }
                    }
                    base.OnAuthorization(actionContext);
                }*/
    }
}