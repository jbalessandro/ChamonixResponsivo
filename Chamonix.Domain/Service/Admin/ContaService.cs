using Chamonix.Domain.Abstract;
using Chamonix.Domain.Models.Admin;
using Chamonix.Domain.Repository;
using System;
using System.Linq;

namespace Chamonix.Domain.Service.Admin
{
    public class ContaService : IBaseService<Conta>
    {
        private IBaseRepository<Conta> repository;

        public ContaService() => repository = new EFRepository<Conta>();

        public Conta Excluir(int id)
        {
            try
            {
                return repository.Excluir(id);
            }
            catch (Exception)
            {
                Conta conta = repository.Find(id);

                if (conta != null)
                {
                    conta.Ativo = false;
                    repository.Alterar(conta);
                }

                return conta;
            }
        }

        public Conta Find(int id)
        {
            return repository.Find(id);
        }

        public int Gravar(Conta item)
        {
            if (item.ContaId == 0)
            {
                item.Ativo = true;
                return repository.Incluir(item).ContaId;
            }

            return repository.Alterar(item).ContaId;
        }

        public IQueryable<Conta> Listar()
        {
            return repository.Listar();
        }
    }
}
