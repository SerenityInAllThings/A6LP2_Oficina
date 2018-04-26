using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Oficina_codeFirst.Startup))]
namespace Oficina_codeFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
