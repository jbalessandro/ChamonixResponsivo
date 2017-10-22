using Chamonix.Domain.Models.Admin;

namespace Chamonix.Domain.Abstract
{
    public interface ILogin
    {
        Usuario ValidaLogin(string login, string senha);
        int GetIdUsuario(string login);
    }
}
