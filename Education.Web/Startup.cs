using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Education.Web.Startup))]
namespace Education.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
