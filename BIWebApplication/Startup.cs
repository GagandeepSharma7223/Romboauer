using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BIWebApplication.Startup))]
namespace BIWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
