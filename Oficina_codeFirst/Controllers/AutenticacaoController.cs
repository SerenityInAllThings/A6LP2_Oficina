using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oficina_codeFirst.Respositories;

namespace Oficina_codeFirst.Controllers
{
    public class AutenticacaoController : Controller
    {
        public JsonResult AutenticarUsuario(string login, string senha)
        {
            if (GestaoUsuarios.Autenticar(login, senha))
            {
                var corpoResposta = new { OK = true, Mensagem = "Usuario encontrado, Redirecionando..." };
                return Json(corpoResposta, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var corpoResposta = new { OK = false, Mensagem = "Usuario não encontrado" };
                return Json(corpoResposta, JsonRequestBehavior.AllowGet);
            }
        }
    }
}