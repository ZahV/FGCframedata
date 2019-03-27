using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FGCframedata.Startup))]
namespace FGCframedata
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
