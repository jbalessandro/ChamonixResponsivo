using Chamonix.Domain.Abstract;
using Chamonix.Domain.Models.Produtos;
using Chamonix.Domain.Repository;
using System;
using System.Linq;

namespace Chamonix.Domain.Service.Admin
{
    public class ComplementoService: IBaseService<Complemento>
    {
        private IBaseRepository<Complemento> repository;

        public ComplementoService()
        {
            repository = new EFRepository<Complemento>();
        }

        public Complemento Excluir(int id)
        {
            try
            {
                return repository.Excluir(id);
            }
            catch (Exception)
            {
                var item = repository.Find(id);

                if (item != null)
                {
                    item.Ativo = false;
                    repository.Alterar(item);
                }

                return item;
            }
        }

        public Complemento Find(int id)
        {
            return repository.Find(id);
        }

        public int Gravar(Complemento item)
        {
            item.Descricao = item.Descricao.ToUpper().Trim();

            if (repository.Listar().Where(x => x.Descricao == item.Descricao && x.ComplementoId != item.ComplementoId).Count() > 0)
            {
                throw new ArgumentException("Já existe um complemento cadastrado com esta descrição");
            }

            if (item.ComplementoId == 0)
            {
                item.Ativo = true;
                return repository.Incluir(item).ComplementoId;
            }

            return repository.Alterar(item).ComplementoId;
        }

        public IQueryable<Complemento> Listar()
        {
            return repository.Listar();
        }
    }
}
