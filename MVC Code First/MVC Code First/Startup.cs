using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Code_First.Startup))]
namespace MVC_Code_First
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
