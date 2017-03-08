using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using SotnWiki.Data;
using SotnWiki.Data.Common;
using System;

namespace SotnWiki.MvcClient.App_Start.Ninject_Modules
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ISotnWikiDbContext>().To<SotnWikiDbContext>().InRequestScope();
            this.Bind<Func<IUnitOfWork>>().ToMethod(ctx => () => ctx.Kernel.Get<IUnitOfWork>());
            this.Bind<IUnitOfWork>().To<EfUnitOfWork>();

            this.Bind(typeof(IRepository<>)).To(typeof(EfGenericRepository<>));
        }
    }
}