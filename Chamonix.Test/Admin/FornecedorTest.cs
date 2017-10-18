using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chamonix.Domain.Abstract;
using Chamonix.Domain.Models.Admin;
using Chamonix.Domain.Service.Admin;
using System.Linq;

namespace Chamonix.Test.Admin
{
    [TestClass]
    public class FornecedorTest
    {
        IBaseService<Fornecedor> service;

        public FornecedorTest()
        {
            service = new FornecedorService();
        }

        [TestMethod]
        public void TestIncluir()
        {
            var fornecedor = new Fornecedor
            {
                AlteradoEm = DateTime.Now,
                Ativo = true,
                Bairro = "Vale dos Vinhedos",
                Cep = "01234567",
                Cidade = "Bento Goncalves",
                Email = "vinicula@teste.com.br",
                Fantasia = "Vinicula",
                RamoId = 5,
                Telefone = "1234556677",
                EstadoId = 3,
                UsuarioId = 4
            };

            fornecedor.FornecedorId = service.Gravar(fornecedor);

            Assert.IsTrue(fornecedor.FornecedorId > 0);
        }

        [TestMethod]
        public void TestListar()
        {
            var lista = service.Listar().ToList();

            Assert.IsTrue(lista.Count > 0);
        }
    }
}
