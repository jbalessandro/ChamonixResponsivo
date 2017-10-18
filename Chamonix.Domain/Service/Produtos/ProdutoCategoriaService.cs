using Chamonix.Domain.Abstract;
using Chamonix.Domain.Models.Produtos;
using Chamonix.Domain.Repository;
using System;
using System.Linq;

namespace Chamonix.Domain.Service.Produtos
{
    public class ProdutoCategoriaService : IBaseService<ProdutoCategoria>
    {
        private IBaseRepository<ProdutoCategoria> repository;

        public ProdutoCategoriaService()
        {
            repository = new EFRepository<ProdutoCategoria>();
        }

        public ProdutoCategoria Excluir(int id)
        {
            try
            {
                return repository.Excluir(id);
            }
            catch (Exception)
            {
                var produtoCategoria = repository.Find(id);

                if (produtoCategoria != null)
                {
                    produtoCategoria.Ativo = false;
                    return repository.Alterar(produtoCategoria);
                }

                return produtoCategoria;
            }
        }

        public ProdutoCategoria Find(int id)
        {
            return repository.Find(id);
        }

        public int Gravar(ProdutoCategoria item)
        {
            item.Descricao = item.Descricao.ToUpper().Trim();

            if (repository.Listar().Where(x => x.Descricao == item.Descricao && x.ProdutoCategoriaId != item.ProdutoCategoriaId).Count() > 0)
            {
                throw new ArgumentException("Já existe uma categoria de produto cadastrada com esta descrição");
            }

            if (item.ProdutoCategoriaId == 0)
            {
                item.Ativo = true;
                return repository.Incluir(item).ProdutoCategoriaId;
            }

            return repository.Alterar(item).ProdutoCategoriaId;
        }

        public IQueryable<ProdutoCategoria> Listar()
        {
            return repository.Listar();
        }
    }
}
