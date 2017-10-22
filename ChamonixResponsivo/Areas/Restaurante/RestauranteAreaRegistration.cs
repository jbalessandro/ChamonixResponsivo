using System.Web.Mvc;

namespace ChamonixResponsivo.Areas.Restaurante
{
    public class RestauranteAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Restaurante";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Restaurante",
                "Restaurante",
                new { action = "Index", Controller = "Inicio" }
        );

            context.MapRoute(
                "Restaurante_default",
                "Restaurante/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}