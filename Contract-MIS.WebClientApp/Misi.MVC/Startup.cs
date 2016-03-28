using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Misi.MVC.Startup))]
namespace Misi.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
