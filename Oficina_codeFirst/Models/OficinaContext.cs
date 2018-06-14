using Oficina_codeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Oficina_codeFirst.Models
{
    public class OficinaContext: DbContext
    {
        public OficinaContext() : base("name=oficinaContext")
        {
            Database.SetInitializer<OficinaContext>(new OficinaDatabaseInitializer());
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Atendimento> Atendimentos{ get; set; }
        public DbSet<Peca> Peca { get; set; }
        public DbSet<TipoPeca> TipoPeca { get; set; }
        public DbSet<Fatura> Fatura { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}

public class OficinaDatabaseInitializer : CreateDatabaseIfNotExists<OficinaContext>
{
    protected override void Seed(OficinaContext db)
    {
        // Criando usuário admin padrão
        var usuarioAdmin = new Usuario
        {
            Oid = 1,
            Login = "admin",
            Senha = "abc@123"
        };
        db.Usuario.Add(usuarioAdmin);

        db.SaveChanges();
        base.Seed(db);
    }
}