using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BritehouseProject2.Startup))]
namespace BritehouseProject2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
