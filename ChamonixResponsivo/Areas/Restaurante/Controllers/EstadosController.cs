using Chamonix.Domain.Abstract;
using Chamonix.Domain.Models.Admin;
using Chamonix.Domain.Service.Admin;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ChamonixResponsivo.Areas.Restaurante.Controllers
{
    public class EstadosController : Controller
    {
        IBaseService<Estado> service;

        public EstadosController()
        {
            service = new EstadoService();
        }

        // GET: Restaurante/Estados
        public ActionResult Index()
        {
            var estados = service.Listar().OrderBy(x => x.UF).ToList();
            return View(estados);
        }

        // GET: Restaurante/Estados/Create
        public ActionResult Create()
        {
            var estado = new Estado
            {
                AlteradoEm = DateTime.Now,
                Ativo = true,
                UsuarioId = 4
            };

            return View(estado);
        }

        // POST: Restaurante/Estados/Create
        [HttpPost]
        public ActionResult Create(Estado estado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.Gravar(estado);
                    return RedirectToAction("Index");
                }

                return View(estado);
            }
            catch (ArgumentException e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(estado);
            }
        }

        // GET: Restaurante/Estados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var estado = service.Find((int)id);

            return View(estado);
        }

        // POST: Restaurante/Estados/Edit/5
        [HttpPost]
        public ActionResult Edit(Estado estado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.Gravar(estado);
                    return RedirectToAction("Index");
                }
                return View(estado);
            }
            catch (ArgumentException e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(estado);
            }
        }

        // GET: Restaurante/Estados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var estado = service.Find((int)id);

            if (estado == null)
            {
                return HttpNotFound();
            }

            return View(estado);
        }

        // POST: Restaurante/Estados/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                service.Excluir(id);
                return RedirectToAction("Index");
            }
            catch (ArgumentException e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                var estado = service.Find(id);
                if (estado == null)
                {
                    return HttpNotFound();
                }
                return View(estado);
            }
        }
    }
}
