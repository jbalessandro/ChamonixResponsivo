using Chamonix.Domain.Abstract;
using Chamonix.Domain.Models.Admin;
using Chamonix.Domain.Repository;
using System;
using System.Linq;

namespace Chamonix.Domain.Service.Admin
{
    public class ContaBancariaService : IBaseService<ContaBancaria>
    {
        private IBaseRepository<ContaBancaria> repository;

        public ContaBancariaService() => repository = new EFRepository<ContaBancaria>();

        public ContaBancaria Excluir(int id)
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

        public ContaBancaria Find(int id)
        {
            return repository.Find(id);
        }

        public int Gravar(ContaBancaria item)
        {
            item.Descricao = item.Descricao.ToUpper().Trim();

            if (repository.Listar().Where(x => x.Descricao == item.Descricao && x.ContaBancariaId != item.ContaBancariaId).Count() > 0)
            {
                throw new ArgumentException("Já existe uma conta cadastrada com este nome");
            }

            item.Agencia = item.Agencia.ToUpper().Trim();
            item.Conta = item.Conta.ToUpper().Trim();
            item.NomeBanco = item.NomeBanco.ToUpper().Trim();
            item.Observacao = string.IsNullOrEmpty(item.Observacao) ? string.Empty : item.Observacao.ToUpper().Trim();
            item.Telefone = item.Telefone.ToUpper().Trim();

            if (item.ContaBancariaId == 0)
            {
                item.Ativo = true;
                return repository.Incluir(item).ContaBancariaId;
            }

            return repository.Alterar(item).ContaBancariaId;
        }

        public IQueryable<ContaBancaria> Listar()
        {
            return repository.Listar();
        }
    }
}
