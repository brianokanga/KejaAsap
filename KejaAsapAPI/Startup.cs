using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KejaAsapAPI.Startup))]
namespace KejaAsapAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
