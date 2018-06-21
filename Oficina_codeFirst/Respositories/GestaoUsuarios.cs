using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oficina_codeFirst.Models;

namespace Oficina_codeFirst.Respositories
{
    public class GestaoUsuarios
    {
        public static bool Autenticar(string login, string senha)
        {
            try
            {
                var db = new OficinaContext();
                var usuario = db.Usuario.SingleOrDefault(u => u.Login == login && u.Senha == senha);
                if (usuario == null)
                {
                    return false;
                }
                else
                {
                    GestaoCookie.CriarCookieAutenticacao(usuario.Oid);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string GetNomeUsuarioLogado()
        {
            var cookieUsuario = GestaoCookie.GetCookieUsuario();
            if (cookieUsuario == null)
                return "Usuário desconhecido";
            var idUsuario = Convert.ToInt32(cookieUsuario.Values[GestaoCookie.chaveCookieUsuario_ID]);
            var db = new OficinaContext();
            var usuario = db.Usuario.FirstOrDefault(u => u.Oid == idUsuario);
            if (usuario == null)
                return "Usuário estranho";
            return usuario.Login;
        }
    
        public static Usuario RecuperarUsuarioLogado()
        {
            var cookieUsuario = GestaoCookie.GetCookieUsuario();
            if (cookieUsuario == null)
                return null;
            var idUsuario = Convert.ToInt32(cookieUsuario[GestaoCookie.chaveCookieUsuario_ID]);
            var db = new OficinaContext();
            var usuario = db.Usuario.FirstOrDefault(u => u.Oid == idUsuario);
            return usuario;
        }
    }
}