using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ElektronikMagazaWebsite.Startup))]
namespace ElektronikMagazaWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app) { ConfigureAuth(app); }
    }
}