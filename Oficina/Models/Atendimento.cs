//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Oficina.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Atendimento
    {
        public Atendimento()
        {
            this.PecasUtilizadas = new HashSet<Peca>();
        }
    
        public int Oid { get; set; }
        public string Codigo { get; set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
    
        public virtual Carro Carro { get; set; }
        public virtual Fatura Fatura { get; set; }
        public virtual ICollection<Peca> PecasUtilizadas { get; set; }
    }
}
