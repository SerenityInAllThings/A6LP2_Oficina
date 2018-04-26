using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Oficina_codeFirst.Models
{
    [Table("Pecas")]
    public class Peca
    {
        [Key]
        public int Oid { get; set; }
        public string Codigo { get; set; }
        public int AtendimentoOid { get; set; }
        [ForeignKey("AtendimentoOid")]
        public Atendimento Atendimento { get; set; }
        public int TipoPecaOid { get; set; }
        [ForeignKey("TipoPecaOid")]
        public TipoPeca TipoPea { get; set; }

    }
}