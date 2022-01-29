using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Projet_REING.Startup))]
namespace Projet_REING
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
