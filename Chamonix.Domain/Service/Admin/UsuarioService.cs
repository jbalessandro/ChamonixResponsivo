using Chamonix.Domain.Abstract;
using Chamonix.Domain.Models.Admin;
using Chamonix.Domain.Repository;
using System;
using System.Linq;

namespace Chamonix.Domain.Service.Admin
{
    public class UsuarioService : IUsuarioService, ILogin
    {
        private IBaseRepository<Usuario> repository;

        public UsuarioService()
        {
            repository = new EFRepository<Usuario>();
        }

        public Usuario Excluir(int id)
        {
            try
            {
                return repository.Excluir(id);
            }
            catch (Exception)
            {
                Usuario usuario = repository.Find(id);

                if (usuario != null)
                {
                    usuario.Ativo = false;
                    repository.Alterar(usuario);
                }

                return usuario;
            }
        }

        public Usuario Find(int id)
        {
            return repository.Find(id);
        }

        public int GetIdUsuario(string login)
        {
            var usuario = repository.Listar().Where(x => x.Ativo == true && x.Logon == login).FirstOrDefault();

            if (usuario != null)
            {
                return usuario.UsuarioId;
            }

            return 0;
        }

        public int Gravar(Usuario item)
        {
            item.AlteradoEm = DateTime.Now;
            item.Logon = item.Logon.ToUpper().Trim();
            item.Nome = item.Nome.ToUpper().Trim();
            item.Senha = item.Senha.Trim();

            if (repository.Listar().Where(x => x.Logon == item.Logon && x.UsuarioId != item.UsuarioId).Count() > 0)
            {
                throw new ArgumentException("Já existe um usuário cadastrado com este logon");
            }

            if (item.UsuarioId == 0)
            {
                item.Ativo = true;
                return repository.Incluir(item).UsuarioId;
            }

            return repository.Alterar(item).UsuarioId;
        }

        public IQueryable<Usuario> Listar()
        {
            return repository.Listar();
        }

        public Usuario TrocarSenha(Usuario usuario, string novaSenha)
        {
            if (usuario.Senha == novaSenha)
            {
                throw new ArgumentException("Informe uma senha diferente da atual");
            }

            usuario.Senha = novaSenha;
            return repository.Alterar(usuario);
        }

        public Usuario ValidaLogin(string login, string senha)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(senha))
            {
                return repository.Listar().Where(x => x.Ativo == true && x.Logon == login && x.Senha == senha).FirstOrDefault();
            }

            return null;
        }
    }
}
