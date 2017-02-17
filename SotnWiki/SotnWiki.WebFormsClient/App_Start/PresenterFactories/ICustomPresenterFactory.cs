using System;

using WebFormsMvp;

namespace SotnWiki.WebFormsClient.App_Start.PresenterFactories
{
    public interface ICustomPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, IView viewInstance);
    }
}
