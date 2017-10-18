using Chamonix.Domain.Abstract;
using Chamonix.Domain.Models.Admin;
using Chamonix.Domain.Service.Admin;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ChamonixResponsivo.Areas.Restaurante.Controllers
{
    public class RamoController : Controller
    {
        IBaseService<Ramo> service;

        public RamoController()
        {
            this.service = new RamoService();
        }

        // GET: Restaurante/Ramo
        public ActionResult Index()
        {
            var ramos = service.Listar().OrderBy(x => x.Descricao).ToList();
            return View(ramos);
        }

        // GET: Restaurante/Ramo/Details/5
        public ActionResult Details(int id)
        {
            var ramo = service.Find(id);

            if (ramo == null)
            {
                return HttpNotFound();
            }

            return View(ramo);
        }

        // GET: Restaurante/Ramo/Create
        public ActionResult Create()
        {
            var ramo = new Ramo
            {
                AlteradoEm = DateTime.Now,
                Ativo = true,
                UsuarioId = 4
            };

            return View(ramo);
        }

        // POST: Restaurante/Ramo/Create
        [HttpPost]
        public ActionResult Create(Ramo ramo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.Gravar(ramo);
                    return RedirectToAction("Index");
                }

                return View(ramo);
            }
            catch (ArgumentException e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(ramo);
            }
        }

        // GET: Restaurante/Ramo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ramo = service.Find((int)id);

            if (ramo == null)
            {
                return HttpNotFound();
            }

            return View(ramo);
        }

        // POST: Restaurante/Ramo/Edit/5
        [HttpPost]
        public ActionResult Edit(Ramo ramo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.Gravar(ramo);
                    return RedirectToAction("Index");
                }

                return View(ramo);
            }
            catch (ArgumentException e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(ramo);
            }
        }

        // GET: Restaurante/Ramo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ramo = service.Find((int)id);

            if (ramo == null)
            {
                return HttpNotFound();
            }

            return View(ramo);
        }

        // POST: Restaurante/Ramo/Delete/5
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
                var ramo = service.Find(id);
                if (ramo == null)
                {
                    return HttpNotFound();
                }
                return View(ramo);
            }
        }
    }
}
