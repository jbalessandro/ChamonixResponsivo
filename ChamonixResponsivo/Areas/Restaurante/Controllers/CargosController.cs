using Chamonix.Domain.Abstract;
using Chamonix.Domain.Models.Admin;
using Chamonix.Domain.Service.Admin;
using ChamonixResponsivo.Common;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ChamonixResponsivo.Areas.Restaurante.Controllers
{
    [AreaAuthorizeAttribute("Restaurante", Roles="admin")]
    public class CargosController : Controller
    {
        IBaseService<Cargo> service;

        public CargosController()
        {
            this.service = new CargoService();
        }

        // GET: Restaurante/Cargos
        public ActionResult Index()
        {
            var cargos = service.Listar().OrderBy(x => x.Descricao).ToList();
            return View(cargos);
        }

        // GET: Restaurante/Cargos/Details/5
        public ActionResult Details(int id)
        {
            var cargo = service.Find(id);

            if (cargo == null)
            {
                return HttpNotFound();
            }

            return View(cargo);
        }

        // GET: Restaurante/Cargos/Create
        public ActionResult Create()
        {
            var cargo = new Cargo { Ativo = true };
            return View(cargo);
        }

        // POST: Restaurante/Cargos/Create
        [HttpPost]
        public ActionResult Create(Cargo cargo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.Gravar(cargo);
                    return RedirectToAction("Index");
                }

                return View(cargo);
            }
            catch (ArgumentException e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(cargo);
            }
        }

        // GET: Restaurante/Cargos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cargo = service.Find((int)id);

            if (cargo == null)
            {
                return HttpNotFound();
            }

            return View(cargo);
        }

        // POST: Restaurante/Cargos/Edit/5
        [HttpPost]
        public ActionResult Edit(Cargo cargo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.Gravar(cargo);
                    return RedirectToAction("Index");
                }

                return View(cargo);
            }
            catch (ArgumentException e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(cargo);
            }
        }

        // GET: Restaurante/Cargos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cargo = service.Find((int)id);

            if (cargo == null)
            {
                return HttpNotFound();
            }

            return View(cargo);
        }

        // POST: Restaurante/Cargos/Delete/5
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
                var cargo = service.Find(id);
                if (cargo == null)
                {
                    return HttpNotFound();
                }
                return View(cargo);
            }
        }
    }
}
