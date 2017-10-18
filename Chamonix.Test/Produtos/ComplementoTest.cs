using Chamonix.Domain.Abstract;
using Chamonix.Domain.Models.Produtos;
using Chamonix.Domain.Service.Admin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Chamonix.Test.Produtos
{
    [TestClass]
    public class ComplementoTest
    {
        IBaseService<Complemento> service;

        public ComplementoTest() => service = new ComplementoService();

        [TestMethod]
        public void TestIncluir()
        {
            var item = new Complemento
            {
                Descricao = "GELO"
            };

            item.ComplementoId = service.Gravar(item);

            Assert.IsTrue(item.ComplementoId > 0);
        }

        [TestMethod]
        public void TestListar()
        {
            Assert.IsTrue(service.Listar().ToList().Count > 0);
        }
    }
}
