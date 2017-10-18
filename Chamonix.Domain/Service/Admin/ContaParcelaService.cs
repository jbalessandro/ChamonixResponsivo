using Chamonix.Domain.Abstract;
using Chamonix.Domain.Models.Admin;
using Chamonix.Domain.Repository;
using System;
using System.Linq;

namespace Chamonix.Domain.Service.Admin
{
    public class ContaParcelaService : IBaseService<ContaParcela>
    {
        private IBaseRepository<ContaParcela> repository;

        public ContaParcelaService() => repository = new EFRepository<ContaParcela>();

        public ContaParcela Excluir(int id)
        {
            try
            {
                var parcela = repository.Find(id);

                if (parcela == null)
                {
                    throw new ArgumentException("Parcela inexistente");
                }

                if (parcela.Pago == true)
                {
                    throw new ArgumentException("Esta parcela já foi paga");
                }

                return repository.Excluir(id);
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível excluir esta parcela");
            }
        }

        public ContaParcela Find(int id)
        {
            return repository.Find(id);
        }

        public int Gravar(ContaParcela item)
        {
            try
            {
                if (item.ContaId == 0)
                {
                    throw new Exception("Conta inválida");
                }

                if (item.ContaParcelaId != 0)
                {
                    var parcela = repository.Find(item.ContaParcelaId);

                    if (parcela == null)
                    {
                        throw new ArgumentException("Parcela inexistente");
                    }

                    if (parcela.Pago == true)
                    {
                        throw new ArgumentException("Esta parcela já foi paga e não pode ser alterada");
                    }

                    return repository.Alterar(item).ContaParcelaId;
                }
                else
                {
                    item.Ativo = true;
                    item.Pago = false;
                    item.PagoEm = null;
                    item.TotalPago = 0;
                    item.Juros = 0;
                    item.Desconto = 0;

                    return repository.Incluir(item).ContaParcelaId;
                }
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível gravar esta parcela");
            }
        }

        public IQueryable<ContaParcela> Listar()
        {
            return repository.Listar();
        }
    }
}