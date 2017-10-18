using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chamonix.Domain.Models.Admin;
using Chamonix.Domain.Abstract;
using Chamonix.Domain.Service.Admin;
using System.Linq;

namespace Chamonix.Test.Admin
{
    [TestClass]
    public class EstadoTest
    {

        private IBaseService<Estado> service;

        public EstadoTest()
        {
            service = new EstadoService();
        }

        [TestMethod]
        public void TestIncluir()
        {
            var estado = new Estado
            {
                AlteradoEm = DateTime.Now,
                Ativo = true,
                UF = "RS",
                UsuarioId = 4
            };

            estado.UsuarioId = service.Gravar(estado);

            Assert.IsTrue(estado.UsuarioId > 0);
        }

        [TestMethod]
        public void TestListar()
        {
            Assert.IsTrue(service.Listar().ToList().Count > 0);
        }
    }
}
