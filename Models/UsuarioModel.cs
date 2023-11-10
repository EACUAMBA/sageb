namespace sageb.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Senha { get; set; }

        public string Email { get; set;}
        public string Telefone { get; set;}

        public DateTime DataDeNascimento { get; set; }

        public UsuarioModel(int id, string name, string senha, string email, string telefone, DateTime dataDeNascimento)
        {
            Id = id;
            Name = name;
            Senha = senha;
            Email = email;
            Telefone = telefone;
            DataDeNascimento = dataDeNascimento;
        }
    }
}
