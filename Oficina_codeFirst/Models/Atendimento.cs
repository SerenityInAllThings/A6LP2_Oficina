using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Oficina_codeFirst.Models
{
    [Table("Atendimentos")]
    public class Atendimento
    {
        [Key]
        public int Oid { get; set; }
        public string Codigo { get; set; }
        [Required]
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int CarroOid { get; set; }
        [ForeignKey("CarroOid")]
        public Carro Carro { get; set; }
        public Fatura Fatura { get; set; }
    }
}