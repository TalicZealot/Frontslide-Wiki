using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using Ninject.Extensions.Conventions;
using SotnWiki.Data;
using SotnWiki.Data.Common;
using System;
using SotnWiki.Data.Common.Contracts;

namespace SotnWiki.WebFormsClient.App_Start.NinjectModules
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(x =>
                x.FromAssemblyContaining<ICharacterRepository>()
                .SelectAllClasses()
                .BindDefaultInterface()
            );

            this.Bind<ISotnWikiDbContext>().To<SotnWikiDbContext>().InRequestScope();
            this.Bind<Func<IUnitOfWork>>().ToMethod(ctx => () => ctx.Kernel.Get<IUnitOfWork>());
            this.Bind<IUnitOfWork>().To<EfUnitOfWork>();
        }
    }
}