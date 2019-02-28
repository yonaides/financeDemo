using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinanceMVC.Startup))]
namespace FinanceMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            ConfigureAuth(app);
        }
    }
}
