using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MushRoom_Manager.Startup))]
namespace MushRoom_Manager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
