using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chamonix.Domain.Abstract;
using Chamonix.Domain.Service.Admin;
using Chamonix.Domain.Models.Admin;
using System.Linq;

namespace Chamonix.Test.Admin
{
    [TestClass]
    public class UsuarioTest
    {
        private IUsuarioService service;

        public UsuarioTest() => service = new UsuarioService();

        [TestMethod]
        public void TestInclusao()
        {
            var usuario = new Usuario
            {
                AlteradoEm = DateTime.Now,
                Ativo = true,
                CargoId = 1,
                Logon = "fernando",
                Nome = "fernando henrique",
                Senha = "fhlb"
            };

            usuario.UsuarioId = service.Gravar(usuario);

            Assert.IsTrue(usuario.UsuarioId > 0);
        }

        [TestMethod]
        public void TestListar()
        {
            Assert.IsTrue(service.Listar().ToList().Count > 0);
        }
    }
}
