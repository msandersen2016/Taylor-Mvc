using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Taylor_Mvc.Startup))]
namespace Taylor_Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
