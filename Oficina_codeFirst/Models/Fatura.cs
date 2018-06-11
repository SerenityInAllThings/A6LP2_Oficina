using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Oficina_codeFirst.Models
{
    [Table("Faturas")]
    public class Fatura
    {
        [Key, ForeignKey("Atendimento")]
        public int Oid { get; set; }
        public decimal ValorRecebido { get; set; }
        public string TipoPagamento { get; set; }
        public int parcelas { get; set; }
        public Atendimento Atendimento { get; set; }
    }
}