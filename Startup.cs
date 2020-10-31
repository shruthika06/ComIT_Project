using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Online_Shopping.Startup))]
namespace Online_Shopping
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
