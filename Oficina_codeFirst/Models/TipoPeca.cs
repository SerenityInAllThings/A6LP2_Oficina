using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Oficina_codeFirst.Models
{
    [Table("TiposPeca")]
    public class TipoPeca
    {
        [Key]
        public int Oid { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public ICollection<Peca> Pecas { get; set; }
    }
}