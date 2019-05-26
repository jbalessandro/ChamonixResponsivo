using Chamonix.Domain.Abstract;
using Chamonix.Domain.Models.Admin;
using Chamonix.Domain.Service.Admin;
using ChamonixResponsivo.Areas.Restaurante.Models;
using ChamonixResponsivo.Common;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ChamonixResponsivo.Areas.Restaurante.Controllers
{
    [AreaAuthorizeAttribute("Restaurante", Roles = "admin")]
    public class ContaParcelaController : Controller
    {
        private IBaseService<ContaParcela> service;
        private ILogin login;

        public ContaParcelaController()
        {
            service = new ContaParcelaService();
            login = new UsuarioService();
        }

        public PartialViewResult Parcelas(int contaId, bool soAtivos = true)
        {
            var parcelas = service.Listar()
                .Where(x => x.ContaId == contaId
                && (soAtivos == false || (soAtivos == true && x.Ativo == true)))
                .OrderBy(x => x.Vencto)
                .ToList();

            ViewBag.ValorTotal = parcelas.Sum(x => x.Valor).ToString("c2");
            ViewBag.ContaId = contaId;
            return PartialView(parcelas);
        }

        public ActionResult Details(int id)
        {
            var parcela = service.Find(id);

            return PartialView(parcela);
        }

        public PartialViewResult Create(int contaId)
        {
            ViewBag.ContaId = contaId;
            return PartialView(new ParcelaAddModel { Parcelas = 1 });
        }

        [HttpPost]
        public ActionResult Create(ParcelaAddModel model, int contaId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    for (int i = 0; i < model.Parcelas; i++)
                    {
                        var parcela = new ContaParcela
                        {
                            Ativo = true,
                            ContaId = contaId,
                            UsuarioId = login.GetIdUsuario(System.Web.HttpContext.Current.User.Identity.Name),
                            Valor = model.Valor
                        };
                        switch (model.Periodicidade)
                        {
                            case Periodicidade.Mensal:
                                parcela.Vencto = model.Vencto.AddMonths(i * (int)model.Periodicidade);
                                break;
                            case Periodicidade.Semanal:
                                parcela.Vencto = model.Vencto.AddDays(i * (int)model.Periodicidade);
                                break;
                            case Periodicidade.Quinzenal:
                                parcela.Vencto = model.Vencto.AddDays(i * (int)model.Periodicidade);
                                break;
                            case Periodicidade.Bimestral:
                                parcela.Vencto = model.Vencto.AddMonths(i * (int)model.Periodicidade);
                                break;
                            case Periodicidade.Trimestral:
                                parcela.Vencto = model.Vencto.AddMonths(i * (int)model.Periodicidade);
                                break;
                            case Periodicidade.Semestral:
                                parcela.Vencto = model.Vencto.AddMonths(i * (int)model.Periodicidade);
                                break;
                            case Periodicidade.Anual:
                                parcela.Vencto = model.Vencto.AddMonths(i * (int)model.Periodicidade);
                                break;
                            case Periodicidade.Nenhuma:
                                parcela.Vencto = model.Vencto;
                                break;
                            default:
                                break;
                        }

                        // grava nova parcela
                        service.Gravar(parcela);
                    }

                    ViewBag.ContaId = contaId;

                    return Json(new { success = true });
                }

                ViewBag.ContaId = contaId;
                return PartialView(model);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                ViewBag.ContaId = contaId;
                return PartialView(model);
            }
        }

        // GET: Erp/Parcela/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var parcela = service.Find((int)id);
            parcela.UsuarioId = login.GetIdUsuario(System.Web.HttpContext.Current.User.Identity.Name);

            if (parcela == null)
            {
                return HttpNotFound();
            }

            // TODO: parcela paga tem que ter view diferenciada

            return PartialView(parcela);
        }

        // POST: Erp/Parcela/Edit/5
        [HttpPost]
        public ActionResult Edit(ContaParcela parcela)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.Gravar(parcela);
                    return Json(new { success = true });
                }

                // TODO: parcela paga tem que ter view diferenciada
                return PartialView(parcela);
            }
            catch (ArgumentException e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return PartialView(parcela);
            }
        }

        public ActionResult Delete(int id)
        {
            var parcela = service.Find(id);

            if (parcela == null)
            {
                return HttpNotFound();
            }

            return PartialView(parcela);
        }

        // POST: Erp/Parcela/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var parcela = service.Excluir(id);
                return RedirectToAction("Edit", "Agendamento", new { id = parcela.ContaId });
            }
            catch (ArgumentException e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                var parcela = service.Find(id);
                if (parcela == null)
                {
                    return HttpNotFound();
                }
                return PartialView(parcela);
            }
        }
    }
}