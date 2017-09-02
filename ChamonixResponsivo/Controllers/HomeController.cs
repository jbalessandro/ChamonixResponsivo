using ChamonixResponsivo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ChamonixResponsivo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Restaurante()
        {
            return View();
        }

        public ActionResult Cardapio()
        {
            return View();
        }

        public ActionResult Localizacao()
        {
            var key = ConfigurationManager.AppSettings["googlemaps"].ToString();
            var src = "https://maps.googleapis.com/maps/api/js?key=" + key + "&callback=initMap";
            ViewBag.Gmap = src;
            return View();
        }

        public ActionResult Historia()
        {
            return View();
        }

        public ActionResult CartaVinhosBebidas()
        {
            return View();
        }

        public ActionResult Contato()
        {
            return View(new ContatoViewModels());
        }

        [HttpPost]
        public ActionResult Contato(ContatoViewModels model)
        {
            if (ModelState.IsValid)
            {
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

                message.From = new System.Net.Mail.MailAddress("contato@chamonixfondue.com");
                message.To.Add(new System.Net.Mail.MailAddress("contato@chamonixfondue.com"));

                message.IsBodyHtml = true;
                message.BodyEncoding = Encoding.UTF8;
                message.Subject = "Chamonix - contato pelo site";
                message.Body = model.Mensagem;

                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                client.Send(message);

                ViewBag.Obrigado = "Obrigado pelo contato!";
                return View(model);
            }

            return View(model);
        }
    }
}