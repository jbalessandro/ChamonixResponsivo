using Chamonix.Domain.Abstract;
using Chamonix.Domain.Models.Produtos;
using Chamonix.Domain.Service.Produtos;
using ChamonixResponsivo.Common;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ChamonixResponsivo.Areas.Restaurante.Controllers
{
    [AreaAuthorizeAttribute("Restaurante", Roles = "admin")]
    public class ProdutoCategoriaController : Controller
    {
        IBaseService<ProdutoCategoria> service;

        public ProdutoCategoriaController()
        {
            this.service = new ProdutoCategoriaService();
        }

        // GET: Restaurante/ProdutoCategoria
        public ActionResult Index()
        {
            var categorias = service.Listar().OrderBy(x => x.Descricao).ToList();
            return View(categorias);
        }

        // GET: Restaurante/ProdutoCategoria/Details/5
        public ActionResult Details(int id)
        {
            var categoria = service.Find(id);

            if (categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);
        }

        // GET: Restaurante/ProdutoCategoria/Create
        public ActionResult Create()
        {
            var categoria = new ProdutoCategoria
            {
                Ativo = true,
                UsuarioId = 4
            };

            return View(categoria);
        }

        // POST: Restaurante/ProdutoCategoria/Create
        [HttpPost]
        public ActionResult Create(ProdutoCategoria produtoCategoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.Gravar(produtoCategoria);
                    return RedirectToAction("Index");
                }

                return View(produtoCategoria);
            }
            catch (ArgumentException e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(produtoCategoria);
            }
        }

        // GET: Restaurante/ProdutoCategoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var produtoCategoria = service.Find((int)id);

            if (produtoCategoria == null)
            {
                return HttpNotFound();
            }

            return View(produtoCategoria);
        }

        // POST: Restaurante/ProdutoCategoria/Edit/5
        [HttpPost]
        public ActionResult Edit(ProdutoCategoria produtoCategoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.Gravar(produtoCategoria);
                    return RedirectToAction("Index");
                }

                return View(produtoCategoria);
            }
            catch (ArgumentException e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(produtoCategoria);
            }
        }

        // GET: Restaurante/ProdutoCategoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var produtoCategoria = service.Find((int)id);

            if (produtoCategoria == null)
            {
                return HttpNotFound();
            }

            return View(produtoCategoria);
        }

        // POST: Restaurante/ProdutoCategoria/Delete/5
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
                var produtoCategoria = service.Find(id);
                if (produtoCategoria == null)
                {
                    return HttpNotFound();
                }
                return View(produtoCategoria);
            }
        }
    }
}