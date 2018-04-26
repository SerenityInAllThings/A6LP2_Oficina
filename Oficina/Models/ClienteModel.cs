using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Oficina.Models
{
    [Table("Clientes")]
    public class ClienteModel
    {
        [Key]
        public int Oid { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime Aniversario { get; set; }

    }
}