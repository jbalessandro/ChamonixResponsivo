using Chamonix.Domain.Abstract;
using Chamonix.Domain.Models.Admin;
using Chamonix.Domain.Repository;
using System;
using System.Linq;

namespace Chamonix.Domain.Service.Admin
{
    public class EstadoService : IBaseService<Estado>
    {
        private IBaseRepository<Estado> repository;

        public EstadoService()
        {
            repository = new EFRepository<Estado>();
        }

        public Estado Excluir(int id)
        {
            try
            {
                return repository.Excluir(id);
            }
            catch (Exception)
            {
                throw new ArgumentException("Não foi possível excluir este Estado");
            }
        }

        public Estado Find(int id)
        {
            return repository.Find(id);
        }

        public int Gravar(Estado item)
        {
            item.UF = item.UF.ToUpper().Trim();

            if (repository.Listar().Where(x => x.UF == item.UF && x.EstadoId != item.EstadoId).Count() > 0)
            {
                throw new ArgumentException("Estado já cadastrado");
            }

            if (item.EstadoId == 0)
            {
                return repository.Incluir(item).EstadoId;
            }

            return repository.Alterar(item).EstadoId;
        }

        public IQueryable<Estado> Listar()
        {
            return repository.Listar();
        }
    }
}
