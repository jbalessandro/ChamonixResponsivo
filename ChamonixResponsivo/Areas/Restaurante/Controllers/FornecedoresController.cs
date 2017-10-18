using Chamonix.Domain.Abstract;
using Chamonix.Domain.Models.Admin;
using Chamonix.Domain.Service.Admin;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ChamonixResponsivo.Areas.Restaurante.Controllers
{
    public class FornecedoresController : Controller
    {
        IBaseService<Fornecedor> service;

        public FornecedoresController()
        {
            this.service = new FornecedorService();
        }

        // GET: Restaurante/Fornecedor
        public ActionResult Index()
        {
            var fornecedores = service.Listar().OrderBy(x => x.Fantasia).ToList();
            return View(fornecedores);
        }

        // GET: Restaurante/Fornecedor/Details/5
        public ActionResult Details(int id)
        {
            var fornecedor = service.Find(id);

            if (fornecedor == null)
            {
                return HttpNotFound();
            }

            return View(fornecedor);
        }

        // GET: Restaurante/Fornecedor/Create
        public ActionResult Create()
        {
            var fornecedor = new Fornecedor
            {
                AlteradoEm = DateTime.Now,
                Ativo = true,
                UsuarioId = 4
            };

            return View(fornecedor);
        }

        // POST: Restaurante/Fornecedor/Create
        [HttpPost]
        public ActionResult Create(Fornecedor fornecedor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.Gravar(fornecedor);
                    return RedirectToAction("Index");
                }

                return View(fornecedor);
            }
            catch (ArgumentException e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(fornecedor);
            }
        }

        // GET: Restaurante/Fornecedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var fornecedor = service.Find((int)id);

            if (fornecedor == null)
            {
                return HttpNotFound();
            }

            return View(fornecedor);
        }

        // POST: Restaurante/Fornecedor/Edit/5
        [HttpPost]
        public ActionResult Edit(Fornecedor fornecedor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.Gravar(fornecedor);
                    return RedirectToAction("Index");
                }

                return View(fornecedor);

            }
            catch (ArgumentException e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(fornecedor);
            }
        }

        // GET: Restaurante/Fornecedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var fornecedor = service.Find((int)id);

            if (fornecedor == null)
            {
                return HttpNotFound();
            }

            return View(fornecedor);
        }

        // POST: Restaurante/Fornecedor/Delete/5
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
                var fornecedor = service.Find(id);
                if (fornecedor == null)
                {
                    return HttpNotFound();
                }
                return View(fornecedor);
            }
        }
    }
}
