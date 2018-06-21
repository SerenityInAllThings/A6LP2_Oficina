using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oficina_codeFirst.Respositories
{
    public class GestaoCookie
    {
        private static string cookieUser = "CookieUsuario";
        public static string chaveCookieUsuario_ID = "IDUsuario";
        public static void CriarCookieAutenticacao(long IDUsuario)
        {
            var cookieUsuario = new HttpCookie(cookieUser);

            cookieUsuario.Values[chaveCookieUsuario_ID] = IDUsuario.ToString();

            cookieUsuario.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cookieUsuario);
        }

        public static bool ApagarCookieAutenticacao()
        {
            var usuario = GetCookieUsuario();
            if (usuario == null)
                return false;
            else
            {
                HttpContext.Current.Response.Cookies[cookieUser].Expires = DateTime.Now.AddDays(-1);
                return true;
            }
        }
    
        public static HttpCookie GetCookieUsuario()
        {
            var cookieUsuario = HttpContext.Current.Request.Cookies[cookieUser];
            return cookieUsuario;
        }
    }
}