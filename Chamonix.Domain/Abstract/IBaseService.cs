using System.Linq;

namespace Chamonix.Domain.Abstract
{
    public interface IBaseService<T> where T : class
    {
        IQueryable<T> Listar();
        int Gravar(T item);
        T Excluir(int id);
        T Find(int id);
    }
}
