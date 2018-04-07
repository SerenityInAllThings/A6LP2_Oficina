using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Oficina.Startup))]
namespace Oficina
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
