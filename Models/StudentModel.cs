using System.ComponentModel.DataAnnotations;

namespace sageb.Models
{
    public class StudentModel : UsuarioModel
    {
        public StudentModel(int id, string name, string senha, string email, string telefone, DateTime dataDeNascimento, string codigoDoAluno) : base(id, name, senha, email, telefone, dataDeNascimento)
        {
            this.CodigoDoAluno = codigoDoAluno;
           
        }

  

        [Required]
        [StringLength(50)]
        public string CodigoDoAluno { get; set; }

      

     
    }
}
