using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chamonix.Domain.Models.Admin;
using Chamonix.Domain.Abstract;
using Chamonix.Domain.Service.Admin;
using System.Linq;

namespace Chamonix.Test.Admin
{
    [TestClass]
    public class ContaParcelaTest
    {
        private IBaseService<ContaParcela> service;

        public ContaParcelaTest() => service = new ContaParcelaService();

        [TestMethod]
        public void ContaParcelaIncluirTest()
        {
            var item = new ContaParcela
            {
                Ativo = true,
                ContaId = 6,
                Desconto = 0M,
                Juros = 0M,
                Pago = false,
                TotalPago = 0M,
                UsuarioId = 4,
                Valor = 10M,
                Vencto = DateTime.Today.Date.AddDays(10),
            };

            item.ContaParcelaId = service.Gravar(item);

            Assert.IsTrue(item.ContaParcelaId > 0);
        }

        [TestMethod]
        public void ContaParcelaListarTest()
        {
            var lista = service.Listar().ToList();

            Assert.IsTrue(lista.Count > 0);
        }
    }
}
