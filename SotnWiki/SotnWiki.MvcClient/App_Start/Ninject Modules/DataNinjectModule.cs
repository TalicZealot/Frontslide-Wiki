using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using SotnWiki.Data;
using SotnWiki.Data.Common.Contracts;
using SotnWiki.Data.Repositories;
using System;

namespace SotnWiki.MvcClient.App_Start.Ninject_Modules
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {

            this.Bind<ISotnWikiDbContext>().To<SotnWikiDbContext>().InRequestScope();
            this.Bind<Func<IEfUnitOfWork>>().ToMethod(ctx => () => ctx.Kernel.Get<IEfUnitOfWork>());
            this.Bind<ICharacterRepository>().To<CharacterEfRepository>();
            this.Bind<IContentSubmissionRepository>().To<ContentSubmissionEfRepository>();
            this.Bind<IPageEfRepository>().To<PageEfRepository>();
            this.Bind<IRunRepository>().To<RunEfRepository>();
            this.Bind<IEfUnitOfWork>().To<EfUnitOfWork>();
        }
    }
}