using System.ComponentModel.DataAnnotations;

namespace sageb.Models
{
    public class LivrosModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(45)]
        public string Titulo { get; set; }
        [Required]
        [StringLength(45)]
        public string Autor { get; set; }

        public int Quantidade { get; set; }
        public int NumeroDePaginas { get; set; }

        public DateTime DataDeLancamento { get; set; }
    }
}
