using Chamonix.Domain.Abstract;
using Chamonix.Domain.Service.Admin;
using ChamonixResponsivo.Areas.Restaurante.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace ChamonixResponsivo.Areas.Restaurante.Controllers
{
    public class LoginController : Controller
    {
        private ILogin _service;

        public LoginController()
        {
            _service = new UsuarioService();
        }

        // GET: Restaurante/Login
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginUsuario());
        }

        [HttpPost]
        public ActionResult Index(LoginUsuario loginUsuario, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var usuario = _service.ValidaLogin(loginUsuario.Login, loginUsuario.Senha);

                if (usuario != null)
                {
                    FormsAuthentication.SetAuthCookie(usuario.Logon, false);
                    Session["IdUsuario"] = usuario.UsuarioId;
                    if (Url.IsLocalUrl(returnUrl)
                        && returnUrl.Length > 1
                        && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//")
                        && !returnUrl.StartsWith(@"\//"))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "HomeAdm");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Usuário inválido");
                }
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(loginUsuario);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect(Url.Content("~/"));
        }
    }
}