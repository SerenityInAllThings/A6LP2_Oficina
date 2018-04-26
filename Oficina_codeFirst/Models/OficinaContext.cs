using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Oficina_codeFirst.Models
{
    public class OficinaContext: DbContext
    {
        public OficinaContext() : base("name=oficinaContext") { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Atendimento> Atendimentos{ get; set; }
        public DbSet<Peca> Peca { get; set; }
        public DbSet<TipoPeca> TipoPeca { get; set; }
        public DbSet<Fatura> Fatura { get; set; }
    }
}