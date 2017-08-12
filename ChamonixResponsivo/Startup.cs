using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChamonixResponsivo.Startup))]
namespace ChamonixResponsivo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
