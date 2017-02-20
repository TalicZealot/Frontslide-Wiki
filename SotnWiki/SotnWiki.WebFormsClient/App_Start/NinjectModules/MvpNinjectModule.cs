using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Parameters;
using SotnWiki.Mvp.Page;
using SotnWiki.WebFormsClient.App_Start.PresenterFactories;
using System;
using System.Linq;
using WebFormsMvp;
using WebFormsMvp.Binder;

namespace SotnWiki.WebFormsClient.App_Start.NinjectModules
{
    public class MvpNinjectModule : NinjectModule, INinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(x =>
                x.FromAssemblyContaining<IPageView>()
                .SelectAllClasses()
                .BindDefaultInterface()
            );

            this.Bind<IPresenterFactory>()
                .To<WebFormsMvpPresenterFactory>()
                .InSingletonScope();

            this.Bind<ICustomPresenterFactory>()
                .ToFactory()
                .InSingletonScope();

            this.Bind<IPresenter>()
                .ToMethod(this.GetPresenterFactoryMethod)
                .NamedLikeFactoryMethod((ICustomPresenterFactory factory) => factory.GetPresenter(null, null));
        }
        
        private IPresenter GetPresenterFactoryMethod(IContext context)
        {
            var parameters = context.Parameters.ToList();

            var requestedType = (Type)parameters[0].GetValue(context, null);
            var viewInstance = (IView)parameters[1].GetValue(context, null);

            var viewInstanceCtorParameter = new ConstructorArgument("view", viewInstance);

            return (IPresenter)context.Kernel.Get(requestedType, viewInstanceCtorParameter);
        }
    }
}