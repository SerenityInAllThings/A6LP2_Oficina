using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Oficina_codeFirst.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public int Oid { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime Aniversario { get; set; }
        public ICollection<Carro> Carros { get; set; }
    }
}