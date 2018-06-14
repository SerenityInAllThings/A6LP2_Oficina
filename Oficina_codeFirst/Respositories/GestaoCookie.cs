using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oficina_codeFirst.Respositories
{
    public class GestaoCookie
    {
        public static void CriarCookieAutenticacao(long IDUsuario)
        {
            var cookieUsuario = new HttpCookie("CookieUsuario");

            cookieUsuario.Values["IDUsuario"] = IDUsuario.ToString();

            cookieUsuario.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cookieUsuario);
        }
            
    }
}