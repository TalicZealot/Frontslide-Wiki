using Microsoft.AspNet.Identity.Owin;
using Ninject.Extensions.Conventions;
using Ninject.Modules;
using SotnWiki.Auth;
using SotnWiki.Auth.Contracts;
using SotnWiki.DataServices.Contracts;
using SotnWiki.TextManipulation;
using SotnWiki.TextManipulation.Contracts;
using System.Web;

namespace SotnWiki.MvcClient.App_Start.Ninject_Modules
{
    public class ServicesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(x =>
                x.FromAssemblyContaining<IPageService>()
                .SelectAllClasses()
                .BindDefaultInterface()
            );

            this.Bind<IMarkupConverter>().To<TextileConverter>().WhenInjectedInto(typeof(IMarkupConverter)).InSingletonScope();
            this.Bind<IMarkupConverter>().To<TextileConverterWithDivs>().InSingletonScope();

            this.Bind<ISignInService>().ToMethod(_ => HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>());
            this.Bind<IUserService>().ToMethod(_ => HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>());
        }
    }
}