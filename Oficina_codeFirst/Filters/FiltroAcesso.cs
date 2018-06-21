using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oficina_codeFirst.Respositories;

namespace Oficina_codeFirst.Filters
{
    public class FiltroAcesso: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var action = filterContext.ActionDescriptor.ActionName;

            if (controller != "Home" && controller != "Autenticacao" && action != "ConsultaUnica")
            {
                if (GestaoUsuarios.RecuperarUsuarioLogado() == null)
                {
                    filterContext.RequestContext.HttpContext.Response.Redirect("Home/Login");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}