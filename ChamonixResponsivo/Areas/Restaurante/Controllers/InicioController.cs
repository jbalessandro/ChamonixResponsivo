using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChamonixResponsivo.Areas.Restaurante.Controllers
{
    public class InicioController : Controller
    {
        // GET: Restaurante/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}