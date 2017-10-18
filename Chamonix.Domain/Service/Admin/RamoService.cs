using Chamonix.Domain.Abstract;
using Chamonix.Domain.Models.Admin;
using Chamonix.Domain.Repository;
using System;
using System.Linq;

namespace Chamonix.Domain.Service.Admin
{
    public class RamoService : IBaseService<Ramo>
    {
        private IBaseRepository<Ramo> repository;

        public RamoService()
        {
            repository = new EFRepository<Ramo>();
        }

        public Ramo Excluir(int id)
        {
            try
            {
                return repository.Excluir(id);
            }
            catch (Exception)
            {
                Ramo ramo = repository.Find(id);

                if (ramo != null)
                {
                    ramo.Ativo = false;
                    repository.Alterar(ramo);
                }

                return ramo;
            }
        }

        public Ramo Find(int id)
        {
            return repository.Find(id);
        }

        public int Gravar(Ramo item)
        {
            item.AlteradoEm = DateTime.Now;
            item.Descricao = item.Descricao.ToUpper().Trim();

            if (repository.Listar().Where(x => x.Descricao == item.Descricao && x.RamoId != item.RamoId).Count() > 0)
            {
                throw new ArgumentException("Já existe um ramo cadastrado com esta descrição");
            }

            if (item.RamoId == 0)
            {
                item.Ativo = true;
                return repository.Incluir(item).RamoId;
            }

            return repository.Alterar(item).RamoId;
        }

        public IQueryable<Ramo> Listar()
        {
            return repository.Listar();
        }
    }
}
