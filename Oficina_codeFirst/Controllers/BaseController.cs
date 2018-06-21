using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oficina_codeFirst.Filters;

namespace Oficina_codeFirst.Controllers
{
    [FiltroAcesso]
    public class BaseController: Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}