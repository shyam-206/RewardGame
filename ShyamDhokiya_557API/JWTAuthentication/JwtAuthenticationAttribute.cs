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
            var Token = request.Headers.Authorization;

            if (Token == null || Token.Scheme == null)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Authorization header is missing or invalid.");
                return;
            }

            
            var userName = Authentication.ValidateToken(Token.Scheme);

            if (userName == null)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid token.");
                return;
            }

            base.OnActionExecuting(actionContext);
        }
    }
}