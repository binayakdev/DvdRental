using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Credentials.Startup))]
namespace Credentials
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
