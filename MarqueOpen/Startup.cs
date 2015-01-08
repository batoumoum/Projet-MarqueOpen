using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MarqueOpen.Startup))]
namespace MarqueOpen
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
