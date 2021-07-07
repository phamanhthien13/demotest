using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(demotest.Startup))]
namespace demotest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
