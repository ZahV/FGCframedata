using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FGCFrameData.Startup))]
namespace FGCFrameData
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
