using ChamonixResponsivo.Models;
using System.Configuration;
using System.Text;
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
                try
                {
                    System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage
                    {
                        From = new System.Net.Mail.MailAddress("postmaster@chamonixfondue.com.br")
                    };
                    message.To.Add(new System.Net.Mail.MailAddress("reservas@chamonixfondue.com.br"));

                    message.Subject = "Chamonix - contato pelo site";
                    message.Body = model.Mensagem.Trim() + "<br /><br />Enviada por: " + model.Nome + " - " + model.Email?.ToLower().Trim();
                    message.IsBodyHtml = true;
                    message.BodyEncoding = Encoding.UTF8;

                    System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("mail.chamonixfondue.com.br");
                    var credentials = new System.Net.NetworkCredential("postmaster@chamonixfondue.com.br", "b&e8lU98");

                    client.Credentials = credentials;
                    client.Port = 587;
                    client.Send(message);

                    ViewBag.Obrigado = "Obrigado pelo contato!";
                    return View(model);
                }
                catch (System.Exception ex)
                {
                    var x = ex.Message;
                }
            }

            return View(model);
        }
    }
}