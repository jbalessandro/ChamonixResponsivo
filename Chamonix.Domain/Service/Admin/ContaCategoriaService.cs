using Chamonix.Domain.Abstract;
using Chamonix.Domain.Models.Admin;
using Chamonix.Domain.Repository;
using System;
using System.Linq;

namespace Chamonix.Domain.Service.Admin
{
    public class ContaCategoriaService : IBaseService<ContaCategoria>
    {
        private IBaseRepository<ContaCategoria> repository;

        public ContaCategoriaService() => repository = new EFRepository<ContaCategoria>();

        public ContaCategoria Excluir(int id)
        {
            try
            {
                return repository.Excluir(id);
            }
            catch (Exception)
            {
                ContaCategoria contaCategoria = repository.Find(id);

                if (contaCategoria != null)
                {
                    contaCategoria.Ativo = false;
                    repository.Alterar(contaCategoria);
                }

                return contaCategoria;
            }
        }

        public ContaCategoria Find(int id)
        {
            return repository.Find(id);
        }

        public int Gravar(ContaCategoria item)
        {
            item.Descricao = item.Descricao.ToUpper().Trim();
            item.AlteradoEm = DateTime.Now;

            if (repository.Listar().Where(x => x.Descricao == item.Descricao && x.ContaCategoriaId != item.ContaCategoriaId).Count() > 0)
            {
                throw new ArgumentException("Já existe uma categoria cadastrada com esta descrição");
            }

            if (item.ContaCategoriaId == 0)
            {
                item.Ativo = true;
                return repository.Incluir(item).ContaCategoriaId;
            }

            return repository.Alterar(item).ContaCategoriaId;
        }

        public IQueryable<ContaCategoria> Listar()
        {
            return repository.Listar();
        }
    }
}