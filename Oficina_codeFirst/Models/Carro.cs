using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Oficina_codeFirst.Models
{
    [Table("Carros")]
    public class Carro
    {
        [Key]
        public int Oid { get; set; }
        [Required]
        public string Placa { get; set; }
        public string Cor { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public int ClienteOid { get; set; }
        [ForeignKey("ClienteOid")]
        public Cliente Cliente { get; set; }
        public ICollection<Atendimento> Atendimentos{ get; set; }
    }
}