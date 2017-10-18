using Chamonix.Domain.Abstract;
using Chamonix.Domain.Models.Produtos;
using Chamonix.Domain.Service.Produtos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Chamonix.Test.Admin
{
    [TestClass]
    public class ProdutoCategoriaTest
    {
        IBaseService<ProdutoCategoria> service;

        public ProdutoCategoriaTest()
        {
            service = new ProdutoCategoriaService();
        }

        [TestMethod]
        public void TestIncluir()
        {
            var item = new ProdutoCategoria
            {
                Descricao = "FONDUES SALGADAS",
                UsuarioId = 4
            };

            item.UsuarioId = service.Gravar(item);

            Assert.IsTrue(item.UsuarioId > 0);
        }

        [TestMethod]
        public void TestListar()
        {
            Assert.IsTrue(service.Listar().ToList().Count > 0);
        }
    }
}
