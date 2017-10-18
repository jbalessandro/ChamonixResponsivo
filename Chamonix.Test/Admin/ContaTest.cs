using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chamonix.Domain.Abstract;
using Chamonix.Domain.Models.Admin;
using Chamonix.Domain.Service.Admin;
using System.Linq;

namespace Chamonix.Test.Admin
{
    [TestClass]
    public class ContaTest
    {
        private IBaseService<Conta> service;

        public ContaTest() => service = new ContaService();

        [TestMethod]
        public void IncluirContaTest()
        {
            var conta = new Conta
            {
                Ativo = true,
                ContaCategoriaId = 6,
                FornecedorId = 2,
                PedidoEm = DateTime.Today.Date,
                UsuarioId = 4
            };

            conta.ContaId = service.Gravar(conta);

            Assert.IsTrue(conta.ContaId > 0);
        }

        [TestMethod]
        public void ListarContaTest()
        {
            var contas = service.Listar().ToList();

            Assert.IsTrue(contas.Count > 0);
        }
    }
}
