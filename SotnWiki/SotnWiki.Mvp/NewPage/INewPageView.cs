using SotnWiki.Mvp.CustomEventArgs;
using System;
using WebFormsMvp;

namespace SotnWiki.Mvp.NewPage
{
    public interface INewPageView : IView<NewPageViewModel>
    {
        event EventHandler<PageSubmitEventArgs> OnSubmitNewPage;
    }
}
