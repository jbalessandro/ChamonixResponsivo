using Chamonix.Domain.Abstract;
using Chamonix.Domain.Models.Admin;
using Chamonix.Domain.Repository;
using System;
using System.Linq;

namespace Chamonix.Domain.Service.Admin
{
    public class CargoService : IBaseService<Cargo>
    {
        private IBaseRepository<Cargo> repository;

        public CargoService()
        {
            repository = new EFRepository<Cargo>();
        }

        public Cargo Excluir(int id)
        {
            try
            {
                return repository.Excluir(id);
            }
            catch (Exception)
            {
                Cargo cargo = repository.Find(id);

                if (cargo != null)
                {
                    cargo.Ativo = false;
                    repository.Alterar(cargo);
                }

                return cargo;
            }
        }

        public Cargo Find(int id)
        {
            return repository.Find(id);
        }

        public int Gravar(Cargo item)
        {
            item.Descricao = item.Descricao.ToUpper().Trim();

            if (repository.Listar().Where(x => x.Descricao == item.Descricao && x.CargoId != item.CargoId).Count() > 0)
            {
                throw new ArgumentException("Já existe um cargo cadastrado com esta descrição");
            }

            if (item.CargoId == 0)
            {
                item.Ativo = true;
                return repository.Incluir(item).CargoId;
            }

            return repository.Alterar(item).CargoId;
        }

        public IQueryable<Cargo> Listar()
        {
            return repository.Listar();
        }
    }
}