using Chamonix.Domain.Models.Admin;

namespace Chamonix.Domain.Abstract
{
    public interface IUsuarioService: IBaseService<Usuario>
    {
        Usuario TrocarSenha(Usuario usuario, string novaSenha);
    }
}
