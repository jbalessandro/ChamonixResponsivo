using Chamonix.Domain.Abstract;
using Chamonix.Domain.Models.Restaurante;
using Chamonix.Domain.Repository;
using System;
using System.Linq;

namespace Chamonix.Domain.Service.Restaurante
{
    public class MesaSituacaoService : IBaseService<MesaSituacao>
    {
        private IBaseRepository<MesaSituacao> repository;

        public MesaSituacaoService() => repository = new EFRepository<MesaSituacao>();

        public MesaSituacao Excluir(int id)
        {
            try
            {
                return repository.Excluir(id);
            }
            catch (Exception)
            {
                MesaSituacao situacao = repository.Find(id);

                if (situacao != null)
                {
                    situacao.Ativo = false;
                    repository.Alterar(situacao);
                }

                return situacao;
            }
        }

        public MesaSituacao Find(int id)
        {
            return repository.Find(id);
        }

        public int Gravar(MesaSituacao item)
        {
            item.Descricao = item.Descricao.ToUpper().Trim();

            if (repository.Listar().Where(x => x.Descricao == item.Descricao && x.MesaSituacaoId != item.MesaSituacaoId).Count() > 0)
            {
                throw new ArgumentException("Já existe uma situação cadastrada com esta descrição");
            }

            if (item.MesaSituacaoId == 0)
            {
                item.Ativo = true;
                return repository.Incluir(item).MesaSituacaoId;
            }

            return repository.Alterar(item).MesaSituacaoId;
        }

        public IQueryable<MesaSituacao> Listar()
        {
            return repository.Listar();
        }
    }
}
