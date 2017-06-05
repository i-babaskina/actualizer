using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Actualizer.Startup))]
namespace Actualizer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
