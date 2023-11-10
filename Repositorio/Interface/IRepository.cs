using sageb.Models;

namespace sageb.Repositorio.Interface
{
    public interface IRepository<T> where T : UsuarioModel
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Delete(int id);
        void Update(T entity);
        void Add(T entity);
    }
}
