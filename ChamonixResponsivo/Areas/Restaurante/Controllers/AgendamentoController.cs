using Chamonix.Domain.Abstract;
using Chamonix.Domain.Models.Admin;
using Chamonix.Domain.Service.Admin;
using ChamonixResponsivo.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ChamonixResponsivo.Areas.Restaurante.Controllers
{
    [AreaAuthorizeAttribute("Restaurante", Roles ="admin")]
    public class AgendamentoController : Controller
    {
        private IBaseService<Conta> service;
        private ILogin login;

        public AgendamentoController()
        {
            service = new ContaService();
            login = new UsuarioService();
        }

        public ActionResult Create(string message = "")
        {
            var conta = new Conta
            {
                Ativo = true,
                PedidoEm = DateTime.Now,
                UsuarioId = login.GetIdUsuario(System.Web.HttpContext.Current.User.Identity.Name)
            };

            ViewBag.Message = message;
            return View(conta);
        }

        [HttpPost]
        public ActionResult Create(Conta conta)
        {
            try
            {
                conta.PedidoEm = DateTime.Now;
                TryUpdateModel(conta);

                if (ModelState.IsValid)
                {
                    conta.ContaId = service.Gravar(conta);
                    return RedirectToAction("Edit", new { id = conta.ContaId });
                }

                return View(conta);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(conta);
            }
        }

        public ActionResult Edit(int id)
        {
            var conta = service.Find(id);

            if (conta == null)
            {
                return HttpNotFound();
            }

            ViewBag.Message = string.Empty;
            return View(conta);
        }

        [HttpPost]
        public ActionResult Edit(Conta conta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.Gravar(conta);
                    ViewBag.Message = "Conta gravada";
                    return View(conta);
                }

                ViewBag.Message = string.Empty;
                return View(conta);
            }
            catch (ArgumentException e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(conta);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var conta = service.Find((int)id);

            if (conta == null)
            {
                return HttpNotFound();
            }

            ViewBag.ContaId = id;
            return PartialView();
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                service.Excluir(id);
                return Json(new { success = true });
            }
            catch (ArgumentException e)
            {
                return Json(new { success = false, message = e.Message });
            }
        }
    }
}