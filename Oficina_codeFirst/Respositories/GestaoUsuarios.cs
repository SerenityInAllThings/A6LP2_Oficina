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
    }
}