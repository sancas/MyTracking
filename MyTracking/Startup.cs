using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyTracking.Startup))]
namespace MyTracking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
