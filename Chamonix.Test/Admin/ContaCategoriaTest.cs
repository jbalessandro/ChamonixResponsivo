using Chamonix.Domain.Abstract;
using Chamonix.Domain.Models.Admin;
using Chamonix.Domain.Service.Admin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Chamonix.Test.Admin
{
    [TestClass]
    public class ContaCategoriaTest
    {
        private IBaseService<ContaCategoria> service;

        public ContaCategoriaTest() => service = new ContaCategoriaService();

        [TestMethod]
        public void IncluirContaCategoriaTest()
        {
            // Arrange
            ContaCategoria item = new ContaCategoria()
            {
                AlteradoEm = DateTime.Now,
                Ativo = true,
                Descricao = "Concessionária",
                UsuarioId = 4
            };

            // Act
            item.ContaCategoriaId = service.Gravar(item);

            // Assert
            Assert.IsTrue(item.ContaCategoriaId > 0);
        }

        [TestMethod]
        public void ListarContaCategoriaTest()
        {
            var lista = service.Listar().ToList();

            Assert.IsTrue(lista.Count > 0);
        }
    }

}
