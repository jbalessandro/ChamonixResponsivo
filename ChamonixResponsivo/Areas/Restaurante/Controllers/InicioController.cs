using ChamonixResponsivo.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChamonixResponsivo.Areas.Restaurante.Controllers
{
    [AreaAuthorizeAttribute("Restaurante", Roles = "admin")]
    public class InicioController : Controller
    {
        // GET: Restaurante/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}