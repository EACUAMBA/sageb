using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace sageb.Models
{
    public class DevolucoesModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("IdLivrosEmprestados")]
        [Required]
        public string Id_Emprestimos { get; set; }

        public Livros_Emprestados emprestados { get; set; }

        public DateTime DataDaEntrega { get; set; }
    }
}
