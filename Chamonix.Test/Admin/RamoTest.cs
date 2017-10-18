using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chamonix.Domain.Abstract;
using Chamonix.Domain.Models.Admin;
using Chamonix.Domain.Service.Admin;
using System.Linq;

namespace Chamonix.Test.Admin
{
    [TestClass]
    public class RamoTest
    {
        IBaseService<Ramo> service;

        public RamoTest()
        {
            service = new RamoService();
        }

        [TestMethod]
        public void TestIncluir()
        {
            var ramo = new Ramo
            {
                AlteradoEm = DateTime.Now,
                Ativo = true,
                Descricao = "QUEIJOS",
                UsuarioId = 4
            };

            ramo.RamoId = service.Gravar(ramo);

            Assert.IsTrue(ramo.RamoId > 0);
        }

        [TestMethod]
        public void TestListar()
        {
            Assert.IsTrue(service.Listar().ToList().Count > 0);
        }
    }
}
