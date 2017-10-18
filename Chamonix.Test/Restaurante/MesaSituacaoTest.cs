using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chamonix.Domain.Abstract;
using Chamonix.Domain.Models.Restaurante;
using Chamonix.Domain.Service.Restaurante;
using System.Linq;

namespace Chamonix.Test.Restaurante
{
    [TestClass]
    public class MesaSituacaoTest
    {
        private IBaseService<MesaSituacao> service;

        public MesaSituacaoTest() => service = new MesaSituacaoService();

        [TestMethod]
        public void TestIncluirMesaSituacao()
        {
            var situacao = new MesaSituacao
            {
                Descricao = "LIVRE"
            };

            situacao.MesaSituacaoId = service.Gravar(situacao);

            Assert.IsTrue(situacao.MesaSituacaoId > 0);
        }

        [TestMethod]
        public void TestListarMesaSituacao() => Assert.IsTrue(service.Listar().Count() > 0);
    }
}
