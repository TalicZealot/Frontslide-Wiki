using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SotnWiki.MvcClient.Startup))]
namespace SotnWiki.MvcClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
