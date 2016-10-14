using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(testweb.Startup))]
namespace testweb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
