using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SotnWiki.WebFormsClient.Startup))]
namespace SotnWiki.WebFormsClient
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
