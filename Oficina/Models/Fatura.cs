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
    
    public partial class Fatura
    {
        public int Oid { get; set; }
        public decimal ValorRecebido { get; set; }
        public string TipoPagamento { get; set; }
    
        public virtual Atendimento Atendimento { get; set; }
    }
}
