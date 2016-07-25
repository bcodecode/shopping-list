using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Checkout.ShoppingListWebApi.Auth
{
    public class BasicAuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            try
            {
                if (actionContext.Request.Headers.Authorization == null ||
                    actionContext.Request.Headers.Authorization.Scheme == null ||
                    string.IsNullOrWhiteSpace(actionContext.Request.Headers.Authorization.Scheme) ||
                    actionContext.Request.Headers.Authorization.Scheme != ConfigurationManager.AppSettings["Checkout.SecretKey"])
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }
            }
            catch
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}