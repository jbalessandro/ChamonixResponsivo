using Chamonix.Domain.Abstract;
using Chamonix.Domain.Models.Admin;
using Chamonix.Domain.Repository;
using System;
using System.Linq;

namespace Chamonix.Domain.Service.Admin
{
    public class FornecedorService : IBaseService<Fornecedor>
    {
        private IBaseRepository<Fornecedor> repository;

        public FornecedorService()
        {
            repository = new EFRepository<Fornecedor>();
        }

        public Fornecedor Excluir(int id)
        {
            try
            {
                return repository.Excluir(id);
            }
            catch (Exception)
            {
                Fornecedor fornecedor = repository.Find(id);

                if (fornecedor != null)
                {
                    fornecedor.Ativo = false;
                    fornecedor.AlteradoEm = DateTime.Now;
                    return repository.Alterar(fornecedor);
                }

                return fornecedor;
            }
        }

        public Fornecedor Find(int id)
        {
            return repository.Find(id);
        }

        public int Gravar(Fornecedor item)
        {
            item.AlteradoEm = DateTime.Now;
            item.Bairro = item.Bairro?.ToUpper().Trim() ?? string.Empty;
            item.Cidade = item.Cidade?.ToUpper().Trim() ?? string.Empty;
            item.Cep = item.Cep?.Trim() ?? string.Empty;
            item.Cnpj = item.Cnpj?.Trim() ?? string.Empty;
            item.Email = item.Email?.ToLower().Trim() ?? string.Empty;
            item.Endereco = item.Endereco?.ToUpper().Trim() ?? string.Empty;
            item.Fantasia = item.Fantasia?.ToUpper().Trim();
            item.RazaoSocial = item.RazaoSocial?.ToUpper().Trim() ?? string.Empty;
            item.Telefone = item.Telefone?.ToUpper().Trim() ?? string.Empty;

            if (repository.Listar().Where(x => x.Fantasia == item.Fantasia && x.FornecedorId != item.FornecedorId).Count() > 0)
            {
                throw new ArgumentException("Já existe um fornecedor cadastrado com este nome fantasia");
            }

            if (item.FornecedorId == 0)
            {
                item.Ativo = true;
                return repository.Incluir(item).FornecedorId;
            }

            return repository.Alterar(item).FornecedorId;
        }

        public IQueryable<Fornecedor> Listar()
        {
            return repository.Listar();
        }
    }
}
