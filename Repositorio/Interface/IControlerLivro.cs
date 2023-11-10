using sageb.Models;

namespace sageb.Repositorio.Interface
{
    public interface IControlerLivro
    {
        List<LivrosModel> Buscar();
        LivrosModel BuscarPorId(int id);

        LivrosModel Adcionar(LivrosModel livros);

        bool Apagar(int id);
    }
}
