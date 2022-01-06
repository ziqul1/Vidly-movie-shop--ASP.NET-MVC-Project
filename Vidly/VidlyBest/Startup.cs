using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyBest.Startup))]
namespace VidlyBest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();

            ConfigureAuth(app);
        }
    }
}
