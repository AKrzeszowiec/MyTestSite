using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyTestSite.Startup))]
namespace MyTestSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
