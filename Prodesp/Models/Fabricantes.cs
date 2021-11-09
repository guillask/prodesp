using System;
using System.ComponentModel.DataAnnotations;

namespace Prodesp.Models
{
    public class Fabricantes
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Nome do fabricante é obrigatório")]
        [Display(Name = "Fabricante")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Data do Lote é obrigatório")]
        [DataType(DataType.Date)]
        [Display(Name = "Data do Lote")]
        public DateTime DataCadastro { get; set; }
    }
}
