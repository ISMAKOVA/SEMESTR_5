using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BIPIT_10.Startup))]
namespace BIPIT_10
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
