using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chamonix.Domain.Models.Admin;
using Chamonix.Domain.Abstract;
using Chamonix.Domain.Service.Admin;
using System.Linq;

namespace Chamonix.Test.Admin
{
    [TestClass]
    public class ContaBancariaTest
    {
        private IBaseService<ContaBancaria> service;

        public ContaBancariaTest() => service = new ContaBancariaService();

        [TestMethod]
        public void ContaBancariaIncluirTest()
        {
            var item = new ContaBancaria
            {
                Agencia = "0574",
                Ativo = true,
                CodigoBanco = 341,
                Conta = "00000",
                Descricao = "Itau",
                NomeBanco = "Itau Unibanco",
                Saldo = 0M,
                Telefone = "(54)3452-5311"
            };

            item.ContaBancariaId = service.Gravar(item);

            Assert.IsTrue(item.ContaBancariaId > 0);
        }

        [TestMethod]
        public void ContaBancariaListarTest()
        {
            var lista = service.Listar().ToList();

            Assert.IsTrue(lista.Count > 0);
        }
    }
}
