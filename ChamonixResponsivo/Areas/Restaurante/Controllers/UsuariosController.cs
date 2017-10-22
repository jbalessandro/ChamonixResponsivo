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
    public class UsuariosController : Controller
    {
        IBaseService<Usuario> service;

        public UsuariosController()
        {
            this.service = new UsuarioService();
        }

        // GET: Restaurante/Usuarios
        public ActionResult Index()
        {
            var usuarios = service.Listar().OrderBy(x => x.Nome).ToList();
            return View(usuarios);
        }

        // GET: Restaurante/Usuarios/Details/5
        public ActionResult Details(int id)
        {
            var usuario = service.Find(id);

            if (usuario == null)
            {
                return HttpNotFound();
            }

            return View(usuario);
        }

        // GET: Restaurante/Usuarios/Create
        public ActionResult Create()
        {
            var usuario = new Usuario
            {
                AlteradoEm = DateTime.Now,
                Ativo = true,
            };

            return View(usuario);
        }

        // POST: Restaurante/Usuarios/Create
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.Gravar(usuario);
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (ArgumentException e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(usuario);
            }
        }

        // GET: Restaurante/Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var usuario = service.Find((int)id);

            if (usuario == null)
            {
                return HttpNotFound();
            }

            return View(usuario);
        }

        // POST: Restaurante/Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.Gravar(usuario);
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (ArgumentException e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(usuario);
            }
        }

        // GET: Restaurante/Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var usuario = service.Find((int)id);

            if (usuario == null)
            {
                return HttpNotFound();
            }

            return View(usuario);

        }

        // POST: Restaurante/Usuarios/Delete/5
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
                var usuario = service.Find(id);
                if (usuario == null)
                {
                    return HttpNotFound();
                }
                return View(usuario);
            }
        }
    }
}
