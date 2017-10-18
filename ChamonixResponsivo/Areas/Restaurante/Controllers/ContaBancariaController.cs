using Chamonix.Domain.Abstract;
using Chamonix.Domain.Models.Admin;
using Chamonix.Domain.Service.Admin;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ChamonixResponsivo.Areas.Restaurante.Controllers
{
    public class ContaBancariaController : Controller
    {
        IBaseService<ContaBancaria> service;

        public ContaBancariaController()
        {
            service = new ContaBancariaService();
        }

        // GET: Restaurante/ContaBancaria
        public ActionResult Index()
        {
            var contas = service.Listar().OrderBy(x => x.Descricao).ToList();
            return View(contas);
        }

        // GET: Restaurante/ContaBancaria/Details/5
        public ActionResult Details(int id)
        {
            var item = service.Find(id);

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        // GET: Restaurante/ContaBancaria/Create
        public ActionResult Create()
        {
            var item = new ContaBancaria { Ativo = true, Saldo = 0 };
            return View(item);
        }

        // POST: Restaurante/ContaBancaria/Create
        [HttpPost]
        public ActionResult Create(ContaBancaria item)
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

        // GET: Restaurante/ContaBancaria/Edit/5
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

        // POST: Restaurante/ContaBancaria/Edit/5
        [HttpPost]
        public ActionResult Edit(ContaBancaria item)
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

        // GET: Restaurante/ContaBancaria/Delete/5
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

        // GET: Restaurante/ContaBancaria/Delete/5
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