using Ninject.Extensions.Conventions;
using Ninject.Modules;
using Ninject.Web.Common;
using SotnWiki.DataServices.Contracts;
using SotnWiki.TextManipulation;
using SotnWiki.TextManipulation.Contracts;

namespace SotnWiki.WebFormsClient.App_Start.NinjectModules
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

            this.Bind<IMarkupConverter>().To<TextileConverter>().WhenInjectedInto(typeof(IMarkupConverter));
            this.Bind<IMarkupConverter>().To<TextileConverterWithDivs>().InRequestScope();
        }
    }
}