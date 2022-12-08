using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Fiap.Web.AspNet4.Controllers.Filters
{
    public class FiapAuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var usuarioLogado = context.HttpContext.Session.GetString("usuarioLogado");
            if ( String.IsNullOrEmpty( usuarioLogado))
            {
                context.Result = new RedirectResult("~/Login/Index");
            } else
            {
                base.OnActionExecuting(context);
            }

            
        }
    }
}
