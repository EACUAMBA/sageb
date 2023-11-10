using System.ComponentModel.DataAnnotations;

namespace sageb.Models
{
    public class AdministratorModel : UsuarioModel
    {
        public AdministratorModel(int id, string name, string senha, string email, string telefone, DateTime dataDeNascimento, string CodigoDoAdministrador) : base(id, name, senha, email, telefone, dataDeNascimento)
        {
            this.CodigoDoAdministrador = CodigoDoAdministrador;
        }
      

        [Required]
        [StringLength(50)]
        public string CodigoDoAdministrador { get; set; }



    }
}
