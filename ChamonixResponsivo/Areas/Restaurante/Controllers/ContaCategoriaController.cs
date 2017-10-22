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
    [AreaAuthorizeAttribute("Restaurante", Roles = "admin")]
    public class ContaCategoriaController : Controller
    {
        IBaseService<ContaCategoria> service;

        public ContaCategoriaController() {
            service = new ContaCategoriaService();
        }

        // GET: Restaurante/ContaCategoria
        public ActionResult Index()
        {
            var categorias = service.Listar().OrderBy(x => x.Descricao).ToList();
            return View(categorias);
        }

        // GET: Restaurante/ContaCategoria/Details/5
        public ActionResult Details(int id)
        {
            var item = service.Find(id);

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        // GET: Restaurante/ContaCategoria/Create
        public ActionResult Create()
        {
            var item = new ContaCategoria();
            return View(item);
        }

        // POST: Restaurante/ContaCategoria/Create
        [HttpPost]
        public ActionResult Create(ContaCategoria item)
        {
            try
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        service.Gravar(item);
                        return RedirectToAction("Index");
                    }

                    return View(item);
                }
                catch (ArgumentException e)
                {
                    ModelState.AddModelError(string.Empty, e.Message);
                    return View(item);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurante/ContaCategoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var item = service.Find((int)id);

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        // POST: Restaurante/ContaCategoria/Edit/5
        [HttpPost]
        public ActionResult Edit(ContaCategoria item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.Gravar(item);
                    return RedirectToAction("Index");
                }

                return View(item);
            }
            catch (ArgumentException e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(item);
            }
        }

        // GET: Restaurante/ContaCategoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var item = service.Find((int)id);

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        // POST: Restaurante/ContaCategoria/Delete/5
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
                var item = service.Find(id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                return View(item);
            }
        }
    }
}