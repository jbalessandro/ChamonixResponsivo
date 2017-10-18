using Chamonix.Domain.Abstract;
using Chamonix.Domain.Models.Admin;
using Chamonix.Domain.Service.Admin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Chamonix.Test.Admin
{
    [TestClass]
    public class CargoTest
    {
        private IBaseService<Cargo> service;

        public CargoTest() => service = new CargoService();

        [TestMethod]
        public void ListarCargosTest()
        {
            // Arrange
            List<Cargo> cargos;

            // Act
            cargos = service.Listar().ToList();

            // Assert
            Assert.IsTrue(cargos.Count > 0);
        }

        [TestMethod]
        public void IncluirCargoTest()
        {
            // Arrange
            Cargo cargo = new Cargo { Descricao = "ATENDENTE" };

            // Act
            cargo.CargoId = service.Gravar(cargo);

            // Assert
            Assert.IsTrue(cargo.CargoId > 0);
        }
    }
}
